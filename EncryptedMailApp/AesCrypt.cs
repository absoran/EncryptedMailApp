using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace EncDec
{
    class AesCrypt
    {
                                  //Ho7YXVAoQ2EZywkI
        private static string IV = "Ho7YXVAoQ2EZywkI"; //16 char
        private static string Key = "oEAywkyVv203XEhtKubgfLQbEc39JNus"; //32 char
        public static void setKey(string Keyvalue)
        {
            Key = Keyvalue;
        }

        public static void setIV(string IVvalue)
        {   
            Key = IVvalue;
        }
        public static string getKey()
        {
            return Key;
        }
        public static string getIV()
        {
            return IV;
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

        public static string EncryptParam(string decrypted,string AESKEY)
        {
            byte[] textbyte = ASCIIEncoding.ASCII.GetBytes(decrypted);
            AesCryptoServiceProvider cryptos = new AesCryptoServiceProvider();
            cryptos.BlockSize = 128;
            cryptos.KeySize = 256;
            cryptos.Key = ASCIIEncoding.ASCII.GetBytes(AESKEY);
            cryptos.IV = ASCIIEncoding.ASCII.GetBytes(IV);
            cryptos.Padding = PaddingMode.PKCS7;
            cryptos.Mode = CipherMode.CBC;

            ICryptoTransform icrypt = cryptos.CreateEncryptor(cryptos.Key, cryptos.IV);

            byte[] encryptos = icrypt.TransformFinalBlock(textbyte, 0, textbyte.Length);
            icrypt.Dispose();
            return Convert.ToBase64String(encryptos);
        }

        public static string DecryptParam(string encrypted,string AESKEY)
        {
            byte[] encbytes = Convert.FromBase64String(encrypted);
            AesCryptoServiceProvider cryptos = new AesCryptoServiceProvider();
            cryptos.BlockSize = 128;
            cryptos.KeySize = 256;
            cryptos.Key = ASCIIEncoding.ASCII.GetBytes(AESKEY);
            cryptos.IV = ASCIIEncoding.ASCII.GetBytes(IV);
            cryptos.Padding = PaddingMode.PKCS7;
            cryptos.Mode = CipherMode.CBC;

            ICryptoTransform icrypt = cryptos.CreateDecryptor(cryptos.Key, cryptos.IV);

            byte[] decryptos = icrypt.TransformFinalBlock(encbytes, 0, encbytes.Length);
            icrypt.Dispose();
            return ASCIIEncoding.ASCII.GetString(decryptos);
        }


        public static void FileEncrypt(string inputFile, string AESKEY)
        {
            byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(AESKEY);
            FileStream fsCrypt = new FileStream(inputFile + ".aes", FileMode.Create);
            RijndaelManaged Filecryptor = new RijndaelManaged();
            Filecryptor.KeySize = 256;
            Filecryptor.BlockSize = 128;
            Filecryptor.Padding = PaddingMode.PKCS7;
            Filecryptor.Key = ASCIIEncoding.ASCII.GetBytes(AESKEY);
            Filecryptor.IV = ASCIIEncoding.ASCII.GetBytes(IV);
            Filecryptor.Mode = CipherMode.CFB;
            CryptoStream cs = new CryptoStream(fsCrypt,Filecryptor.CreateEncryptor() ,CryptoStreamMode.Write);
            FileStream fsIn = new FileStream(inputFile, FileMode.Open);
            byte[] buffer = new byte[1048576];
            int read;
            try
            {
                while ((read = fsIn.Read(buffer, 0, buffer.Length)) > 0)
                {
                    Application.DoEvents(); // -> for responsive GUI, using Task will be better!
                    cs.Write(buffer, 0, read);
                }
                fsIn.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine("error accured : " + ex.Message);
            }
            finally
            {
                cs.Close();
                fsCrypt.Close();
                Console.WriteLine("file encrypted !");
            }
        }

        public static void FileDecrypt(string inputFile,string outputFile, string AESKEY)
        {
            byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(AESKEY);

            FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);

            RijndaelManaged AES = new RijndaelManaged();
            AES.KeySize = 256;
            AES.BlockSize = 128;
            AES.Key = ASCIIEncoding.ASCII.GetBytes(AESKEY);
            AES.IV = ASCIIEncoding.ASCII.GetBytes(IV);
            AES.Padding = PaddingMode.PKCS7;
            AES.Mode = CipherMode.CFB;
            CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateDecryptor(), CryptoStreamMode.Read);
            FileStream fsOut = new FileStream(outputFile, FileMode.Create);

            int read;
            byte[] buffer = new byte[1048576];

            try
            {
                while ((read = cs.Read(buffer, 0, buffer.Length)) > 0)
                {
                    Application.DoEvents();
                    fsOut.Write(buffer, 0, read);
                }
            }
            catch (CryptographicException ex_CryptographicException)
            {
                Console.WriteLine("CryptographicException error: " + ex_CryptographicException.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            try
            {
                cs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error by closing CryptoStream: " + ex.Message);
            }
            finally
            {
                fsOut.Close();
                fsCrypt.Close();
            }
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
        public static void EncryptFile(string password, string in_file, string out_file)
        {
            CryptFile(password, in_file, out_file, true);
        }
        public static void DecryptFile(string password, string in_file, string out_file)
        {
            CryptFile(password, in_file, out_file, false);
        }
        public static void CryptFile(string password, string in_file, string out_file, bool encrypt)
        {
            // Create input and output file streams.
            using (FileStream in_stream = new FileStream(in_file, FileMode.Open, FileAccess.Read))
            {
                using (FileStream out_stream = new FileStream(out_file, FileMode.Create, FileAccess.Write))
                {
                    // Encrypt/decrypt the input stream into the output stream.
                    CryptStream(in_stream, out_stream, encrypt);
                }
            }
        }

 

        public static void CryptStream(Stream in_stream, Stream out_stream, bool encrypt)
        {
            // Make an AES service provider.
            AesCryptoServiceProvider aes_provider = new AesCryptoServiceProvider();
            aes_provider.BlockSize = 128;
            aes_provider.KeySize = 256;
            aes_provider.Key = ASCIIEncoding.ASCII.GetBytes(Key);
            aes_provider.IV = ASCIIEncoding.ASCII.GetBytes(IV);
            byte[] key = Convert.FromBase64String(Key);
            byte[] iv = Convert.FromBase64String(IV);

            // Make the encryptor or decryptor.
            ICryptoTransform crypto_transform;
            if (encrypt)
            {
                crypto_transform = aes_provider.CreateEncryptor(key, iv);
            }
            else
            {
                crypto_transform = aes_provider.CreateDecryptor(key, iv);
            }

            // Attach a crypto stream to the output stream.
            // Closing crypto_stream sometimes throws an
            // exception if the decryption didn't work
            // (e.g. if we use the wrong password).
            try
            {
                using (CryptoStream crypto_stream = new CryptoStream(out_stream, crypto_transform, CryptoStreamMode.Write))
                {
                    // Encrypt or decrypt the file.
                    const int block_size = 1024;
                    byte[] buffer = new byte[block_size];
                    int bytes_read;
                    while (true)
                    {
                        // Read some bytes.
                        bytes_read = in_stream.Read(buffer, 0, block_size);
                        if (bytes_read == 0) break;

                        // Write the bytes into the CryptoStream.
                        crypto_stream.Write(buffer, 0, bytes_read);
                    }
                } // using crypto_stream 
            }
            catch
            {
            }

            crypto_transform.Dispose();
        }























    }
}
