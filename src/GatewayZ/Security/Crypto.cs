using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace GatewayZ.Security
{
    public class Crypto
    {
        static TripleDES CreateDES(string key)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            TripleDES des = new TripleDESCryptoServiceProvider();
            des.Key = md5.ComputeHash(Encoding.Unicode.GetBytes(key));
            des.IV = new byte[des.BlockSize / 8];
            return des;
        }

        public string EncryptString(string plainText, string password)
        {
            byte[] plainTextBytes = Encoding.Unicode.GetBytes(plainText);

            MemoryStream myStream = new MemoryStream();

            TripleDES des = CreateDES(password);

            CryptoStream cryptoStream = new CryptoStream(myStream, des.CreateEncryptor(), CryptoStreamMode.Write);

            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();

            return Convert.ToBase64String(myStream.ToArray());
        }

        public string DecryptString(string encryptedText, string password)
        {
            byte[] encryptedTextBytes = Convert.FromBase64String(encryptedText);

            MemoryStream myStream = new MemoryStream();

            TripleDES des = CreateDES(password);

            CryptoStream decryptStream = new CryptoStream(myStream, des.CreateDecryptor(), CryptoStreamMode.Write);

            decryptStream.Write(encryptedTextBytes, 0, encryptedTextBytes.Length);
            decryptStream.FlushFinalBlock();

            return Encoding.Unicode.GetString(myStream.ToArray());
        }
    }
}
