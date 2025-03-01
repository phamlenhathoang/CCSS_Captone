 using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Model
{
    public static class PasswordHash
    {
        private static readonly byte[] _key = new byte[32] {
            0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
            0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F, 0x10,
            0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17, 0x18,
            0x19, 0x1A, 0x1B, 0x1C, 0x1D, 0x1E, 0x1F, 0x20
        };

        private static readonly byte[] _iv = new byte[16] {
            0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
            0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F, 0x10
        };


        public static string ConvertToEncrypt(string password)
        {
            //if (string.IsNullOrEmpty(password)) return "";
            //byte[] storePassword = ASCIIEncoding.ASCII.GetBytes(password);
            //string encryptedPassword = Convert.ToBase64String(storePassword);
            //return encryptedPassword;
            using (var aes = Aes.Create())
            {
                aes.Key = _key;
                aes.IV = _iv;

                var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                var encrypted = encryptor.TransformFinalBlock(Encoding.UTF8.GetBytes(password), 0, password.Length);
                return Convert.ToBase64String(encrypted);
            }
        }

        public static string ConvertToDecrypt(string base64EncodeData)
        {
            //if (string.IsNullOrEmpty(base64EncodeData)) return "";
            //byte[] encryptedPassword = Convert.FromBase64String(base64EncodeData);
            //string decryptedPassword = ASCIIEncoding.ASCII.GetString(encryptedPassword);
            //return decryptedPassword;
            using (var aes = Aes.Create())
            {
                aes.Key = _key;
                aes.IV = _iv;

                var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                var decrypted = decryptor.TransformFinalBlock(Convert.FromBase64String(base64EncodeData), 0, base64EncodeData.Length);
                return Encoding.UTF8.GetString(decrypted);
            }
        }
    }
}
