using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.OpenSsl;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SecretMadonna.NEMS.Infrastructure.Common
{
    /// <summary>
    /// 注意：1、KEY 必须是XML的形式，返回的是字符串；2、该加密方式有长度限制的。
    /// </summary>
    public static class RsaHelper
    {
        #region RSA 加密 解密

        #region RSA 生成秘钥
        /// <summary>
        /// RSA 生成秘钥
        /// </summary>
        /// <param name="xmlPrivateKey">私钥</param>
        /// <param name="xmlPublicKey">公钥</param>
        public static void GenerateKey(int keySize, out string xmlPrivateKey, out string xmlPublicKey)
        {
            var rsaCsp = new RSACryptoServiceProvider(keySize);
            xmlPrivateKey = rsaCsp.ToXmlString(true);
            xmlPublicKey = rsaCsp.ToXmlString(false);
        }
        /// <summary>
        /// “xml秘钥”转“pem秘钥”
        /// </summary>
        /// <param name="key"></param>
        /// <param name="isPrivateKey"></param>
        /// <returns></returns>
        public static string Xml2Pem(string key, bool isPrivateKey = false)
        {
            var rsaCsp = new RSACryptoServiceProvider();
            rsaCsp.FromXmlString(key);
            RSAParameters rsaParameters = new RSAParameters();
            RsaKeyParameters rsaKeyParameters = null;
            if (isPrivateKey)
            {
                rsaParameters = rsaCsp.ExportParameters(true);
                rsaKeyParameters = new RsaPrivateCrtKeyParameters(
                    new BigInteger(1, rsaParameters.Modulus),
                    new BigInteger(1, rsaParameters.Exponent),
                    new BigInteger(1, rsaParameters.D),
                    new BigInteger(1, rsaParameters.P),
                    new BigInteger(1, rsaParameters.Q),
                    new BigInteger(1, rsaParameters.DP),
                    new BigInteger(1, rsaParameters.DQ),
                    new BigInteger(1, rsaParameters.InverseQ));
            }
            else
            {
                rsaParameters = rsaCsp.ExportParameters(false);
                rsaKeyParameters = new RsaKeyParameters(false,
                    new BigInteger(1, rsaParameters.Modulus),
                    new BigInteger(1, rsaParameters.Exponent));
            }
            using (var sw = new StringWriter())
            {
                var pemWriter = new PemWriter(sw);
                pemWriter.WriteObject(rsaKeyParameters);
                pemWriter.Writer.Flush();
                var pemKey = sw.ToString();
                return pemKey;
            }
        }
        #endregion

        #region RSA 公钥加密
        public static byte[] Encrypt(byte[] plainBytes, string xmlPublicKey)
        {
            RSACryptoServiceProvider rsaCsp = new RSACryptoServiceProvider();
            rsaCsp.FromXmlString(xmlPublicKey);
            var cipherBytes = rsaCsp.Encrypt(plainBytes, false);
            return cipherBytes;
        }
        public static string Encrypt(string plainText, string xmlPublicKey)
        {
            var plainBytes = Encoding.Default.GetBytes(plainText);
            var cipherBytes = Encrypt(plainBytes, xmlPublicKey);
            var cipherText = Convert.ToBase64String(cipherBytes);
            return cipherText;
        }
        #endregion

        #region RSA 私钥解密
        public static byte[] Decrypt(byte[] cipherBytes, string xmlPrivateKey)
        {
            RSACryptoServiceProvider rsaCsp = new RSACryptoServiceProvider();
            rsaCsp.FromXmlString(xmlPrivateKey);
            var plainBytes = rsaCsp.Decrypt(cipherBytes, false);
            return plainBytes;
        }
        public static string Decrypt(string cipherText, string xmlPrivateKey)
        {
            var cipherBytes = Convert.FromBase64String(cipherText);
            var plainBytes = Decrypt(cipherBytes, xmlPrivateKey);
            var plainText = Encoding.Default.GetString(plainBytes);
            return plainText;
        }
        #endregion

        #endregion

        #region RSA 签名 验签

        #region RSA 私钥签名
        public static byte[] SignToByte(byte[] digestBytes, string xmlPrivateKey)
        {
            var rsaCsp = new RSACryptoServiceProvider();
            rsaCsp.FromXmlString(xmlPrivateKey);
            var rsaPsf = new RSAPKCS1SignatureFormatter(rsaCsp);
            rsaPsf.SetHashAlgorithm("MD5");
            var signatureBytes = rsaPsf.CreateSignature(digestBytes);
            return signatureBytes;
        }
        public static string SignToString(byte[] digestBytes, string xmlPrivateKey)
        {
            var signatureBytes = SignToByte(digestBytes, xmlPrivateKey);
            var signatureText = Convert.ToBase64String(signatureBytes);
            return signatureText;
        }
        public static byte[] SignToByte(string digestText, string xmlPrivateKey)
        {
            var digestBytes = Convert.FromBase64String(digestText);
            var signaturebytes = SignToByte(digestBytes, xmlPrivateKey);
            return signaturebytes;
        }
        public static string SignToString(string digestText, string xmlPrivateKey)
        {
            var digestBytes = Convert.FromBase64String(digestText);
            var signatureBytes = SignToByte(digestBytes, xmlPrivateKey);
            var signatureText = Convert.ToBase64String(signatureBytes);
            return signatureText;
        }
        #endregion

        #region RSA 公钥验签
        public static bool ValidSignature(byte[] digestBytes, byte[] signatureBytes, string xmlPublicKey)
        {
            var rsaCsp = new RSACryptoServiceProvider();
            rsaCsp.FromXmlString(xmlPublicKey);
            var rsaPsd = new RSAPKCS1SignatureDeformatter(rsaCsp);
            rsaPsd.SetHashAlgorithm("MD5");
            var isValid = rsaPsd.VerifySignature(digestBytes, signatureBytes);
            return isValid;
        }
        public static bool ValidSignature(byte[] digestBytes, string signatureText, string xmlPublicKey)
        {
            var signatureBytes = Convert.FromBase64String(signatureText);
            return ValidSignature(digestBytes, signatureBytes, xmlPublicKey);
        }
        public static bool ValidSignature(string digestText, byte[] signatureBytes, string xmlPublicKey)
        {
            var digestBytes = Convert.FromBase64String(digestText);
            return ValidSignature(digestBytes, signatureBytes, xmlPublicKey);
        }
        public static bool ValidSignature(string digestText, string signatureText, string xmlPublicKey)
        {
            var digestBytes = Convert.FromBase64String(digestText);
            var signatureBytes = Convert.FromBase64String(signatureText);
            return ValidSignature(digestBytes, signatureBytes, xmlPublicKey);
        }
        #endregion

        #endregion
    }
}