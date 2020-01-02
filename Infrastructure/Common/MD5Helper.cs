using System;
using System.Security.Cryptography;
using System.Text;

namespace SecretMadonna.NEMS.Infrastructure.Common
{
    public static class MD5Helper
    {
        #region 生成摘要
        public static byte[] GetByteDigest(byte[] plainBytes)
        {
            var md5 = HashAlgorithm.Create("MD5");
            var plainDigestBytes = md5.ComputeHash(plainBytes);
            return plainDigestBytes;
        }
        public static byte[] GetByteDigest(string plainText)
        {
            var plainBytes = Encoding.Default.GetBytes(plainText);
            var plainDigestBytes = GetByteDigest(plainBytes);
            return plainDigestBytes;
        }
        public static string GetTextDigest(byte[] plainBytes)
        {
            var plainDigestBytes = GetByteDigest(plainBytes);
            var plainDigestText = Convert.ToBase64String(plainDigestBytes);
            return plainDigestText;
        }
        public static string GetTextDigest(string plainText)
        {
            var plainBytes = Encoding.Default.GetBytes(plainText);
            var plainDigestBytes = GetByteDigest(plainBytes);
            var plainDigestText = Convert.ToBase64String(plainDigestBytes);
            return plainDigestText;
        }
        #endregion
    }
}
