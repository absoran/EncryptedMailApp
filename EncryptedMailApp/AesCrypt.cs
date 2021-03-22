using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace EncDec
{
    class AesCrypt
    {
        private static string IV = "Ho7YXVAoQ2EZywkI"; //16 char
        private static string Key = "oEAywkyVv203XEhtKubgfLQbEc39JNus"; //32 char
        private static string MKey;
        private static string MIV;

        public static void setKey(string Keyvalue)
        {
            MKey = Keyvalue;
        }

        public static void setIV(string IVvalue)
        {
            MKey = IVvalue;
        }

        public static string Encrypt(string decrypted)
        {
            byte[] textbyte = ASCIIEncoding.ASCII.GetBytes(decrypted);
            AesCryptoServiceProvider cryptos = new AesCryptoServiceProvider();
            cryptos.BlockSize = 128;
            cryptos.KeySize = 256;
            cryptos.Key = ASCIIEncoding.ASCII.GetBytes(Key);
            cryptos.IV = ASCIIEncoding.ASCII.GetBytes(IV);
            cryptos.Padding = PaddingMode.PKCS7;
            cryptos.Mode = CipherMode.CBC;

            ICryptoTransform icrypt = cryptos.CreateEncryptor(cryptos.Key, cryptos.IV);

            byte[] encryptos = icrypt.TransformFinalBlock(textbyte, 0, textbyte.Length);
            icrypt.Dispose();
            return Convert.ToBase64String(encryptos);
        }

        public static string EncryptMail(string decrypted)
        {
            byte[] textbyte = ASCIIEncoding.ASCII.GetBytes(decrypted);
            AesCryptoServiceProvider cryptos = new AesCryptoServiceProvider();
            cryptos.BlockSize = 128;
            cryptos.KeySize = 256;
            cryptos.Key = ASCIIEncoding.ASCII.GetBytes(MKey);
            cryptos.IV = ASCIIEncoding.ASCII.GetBytes(MIV);
            cryptos.Padding = PaddingMode.PKCS7;
            cryptos.Mode = CipherMode.CBC;

            ICryptoTransform icrypt = cryptos.CreateEncryptor(cryptos.Key, cryptos.IV);

            byte[] encryptos = icrypt.TransformFinalBlock(textbyte, 0, textbyte.Length);
            icrypt.Dispose();
            return Convert.ToBase64String(encryptos);
        }



        internal static string Encrypt(TextBox usrpass)
        {
            throw new NotImplementedException();
        }

        public static string Decrypt(string encrypted)
        {
            byte[] encbytes = Convert.FromBase64String(encrypted);
            AesCryptoServiceProvider cryptos = new AesCryptoServiceProvider();
            cryptos.BlockSize = 128;
            cryptos.KeySize = 256;
            cryptos.Key = ASCIIEncoding.ASCII.GetBytes(Key);
            cryptos.IV = ASCIIEncoding.ASCII.GetBytes(IV);
            cryptos.Padding = PaddingMode.PKCS7;
            cryptos.Mode = CipherMode.CBC;

            ICryptoTransform icrypt = cryptos.CreateDecryptor(cryptos.Key, cryptos.IV);

            byte[] decryptos = icrypt.TransformFinalBlock(encbytes, 0, encbytes.Length);
            icrypt.Dispose();
            return ASCIIEncoding.ASCII.GetString(decryptos);
        }

        public static string DecryptMail(string encrypted)
        {
            byte[] encbytes = Convert.FromBase64String(encrypted);
            AesCryptoServiceProvider cryptos = new AesCryptoServiceProvider();
            cryptos.BlockSize = 128;
            cryptos.KeySize = 256;
            cryptos.Key = ASCIIEncoding.ASCII.GetBytes(MKey);
            cryptos.IV = ASCIIEncoding.ASCII.GetBytes(MIV);
            cryptos.Padding = PaddingMode.PKCS7;
            cryptos.Mode = CipherMode.CBC;

            ICryptoTransform icrypt = cryptos.CreateDecryptor(cryptos.Key, cryptos.IV);

            byte[] decryptos = icrypt.TransformFinalBlock(encbytes, 0, encbytes.Length);
            icrypt.Dispose();
            return ASCIIEncoding.ASCII.GetString(decryptos);
        }
    }
}
