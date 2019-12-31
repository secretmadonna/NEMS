using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SecretMadonna.NEMS.Infrastructure.Common
{
    public static class AesHelper
    {
        #region 加密
        public static string Encrypt(string plaintext, string key)
        {
            var plaintextBytes = Encoding.Default.GetBytes(plaintext);
            var keyBytes = Encoding.Default.GetBytes(key);
            var rijndael = Rijndael.Create("");

            //rijndael

            //var rijndaelManaged = new RijndaelManaged() {
            //    m
            //    Key = keyBytes;
            //};
            //Rijndael.Create()
            //

            //Byte[] keyArray = System.Text.Encoding.UTF8.GetBytes(key);
            //Byte[] toEncryptArray = System.Text.Encoding.UTF8.GetBytes(str);
            //var rijndaelManaged = new RijndaelManaged();
            //rijndaelManaged.Key = keyArray;
            //rijndaelManaged.Mode = CipherMode.ECB;
            //rijndaelManaged.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
            //rijndaelManaged.IV = System.Text.Encoding.UTF8.GetBytes(Iv);
            //System.Security.Cryptography.ICryptoTransform cTransform = rijndaelManaged.CreateEncryptor();
            //Byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            //return Convert.ToBase64String(resultArray, 0, resultArray.Length);

            return null;
        }
        #endregion

        #region 解密
        public static string Decrypt(string ciphertext, string key)
        {
            //RSACryptoServiceProvider rsaCsp = new RSACryptoServiceProvider();
            //rsaCsp.FromXmlString(xmlPrivateKey);
            //var ciphertextBa = Convert.FromBase64String(ciphertext);
            //var plaintextBa = rsaCsp.Encrypt(ciphertextBa, false);
            //var plaintext = Encoding.Default.GetString(ciphertextBa);
            //return plaintext;
            return null;
        }
        #endregion
    }
}
