using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Security.Cryptography;
using System.Text;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;

namespace RSAEncDec
{
    public class RSACrypt
    {
        private string publicKeyString = null;
        private string privateKeyString = null;
        private static RSACrypt instance = null;

        public RSACrypt()
        {
            //createKey();
        }
        public static RSACrypt getInstance()
        {
            if(instance == null)
            {
                instance = new RSACrypt();
            }
            return instance;
        }
        public string PublicKey   
        {
            get {
                if (publicKeyString == null)
                {
                    createKey();
                }
                return publicKeyString;
            }
            set { publicKeyString = value; }  
        }
        public string PrivateKey   
        {
            get {
                if (publicKeyString == null)
                {
                    createKey();
                }
                return privateKeyString; }   
            set { privateKeyString = value; }  
        }
        public void createKey()
        {
            var cryptoServiceProvider = new RSACryptoServiceProvider(1024); 
            var privateKey = cryptoServiceProvider.ExportParameters(true); 
            var publicKey = cryptoServiceProvider.ExportParameters(false); 

            publicKeyString = GetKeyString(publicKey);
            privateKeyString = GetKeyString(privateKey);
        }
        private string GetKeyString(RSAParameters publicKey)
        {

            var stringWriter = new System.IO.StringWriter();
            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
            xmlSerializer.Serialize(stringWriter, publicKey);
            return stringWriter.ToString();
        }

        public string Encrypt(string textToEncrypt)
        {
            var bytesToEncrypt = Encoding.UTF8.GetBytes(textToEncrypt);
            
            using (var rsa = new RSACryptoServiceProvider(1024))
            {
                try
                {
                    rsa.FromXmlString(PublicKey);
                    var encryptedData = rsa.Encrypt(bytesToEncrypt, true);
                    var base64Encrypted = Convert.ToBase64String(encryptedData);
                    return base64Encrypted;
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
        }
        public string Decrypt(string textToDecrypt)
        {
            var bytesToDescrypt = Encoding.UTF8.GetBytes(textToDecrypt);

            using (var rsa = new RSACryptoServiceProvider(1024))
            {
                try
                {
                    // server decrypting data with private key                    
                    rsa.FromXmlString(PrivateKey);
                    var resultBytes = Convert.FromBase64String(textToDecrypt);
                    var decryptedBytes = rsa.Decrypt(resultBytes, true);
                    var decryptedData = Encoding.UTF8.GetString(decryptedBytes);
                    return decryptedData.ToString();
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
        }

    }
    
    
}
