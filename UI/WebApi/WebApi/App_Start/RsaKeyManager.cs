using log4net;
using SecretMadonna.NEMS.Infrastructure.Common;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Web;
using System.Xml;

namespace SecretMadonna.NEMS.UI.WebApi
{
    public static class RsaKeyManager
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(RsaKeyManager));
        private static int numberIndex = 0;

        private static readonly int keySize = 1024;

        static RsaKeyManager()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);

            var webRootDir = HttpRuntime.AppDomainAppPath;
            var appDataDir = Path.Combine(webRootDir, "App_Data");
            if (!Directory.Exists(appDataDir))
            {
                Directory.CreateDirectory(appDataDir);
            }
            string xmlPrivateKey = null, xmlPublicKey = null;
            var xmlPrivateKeyXmlDocument = new XmlDocument();
            var xmlPublicKeyXmlDocument = new XmlDocument();
            var privateKeyFile = Path.Combine(appDataDir, "RsaPrivateKey.xml");
            var publicKeyFile = Path.Combine(appDataDir, "RsaPublicKey.xml");
            if (File.Exists(privateKeyFile))
            {
                xmlPrivateKeyXmlDocument.Load(privateKeyFile);
                xmlPrivateKey = xmlPrivateKeyXmlDocument.OuterXml;
            }
            if (File.Exists(publicKeyFile))
            {
                xmlPublicKeyXmlDocument.Load(publicKeyFile);
                xmlPublicKey = xmlPublicKeyXmlDocument.OuterXml;
            }
            if (string.IsNullOrEmpty(xmlPrivateKey) || string.IsNullOrEmpty(xmlPublicKey))
            {
                var rsaKeySize = ConfigurationManager.AppSettings["RsaKeySize"];
                var isParseSuccess = int.TryParse(rsaKeySize, out var result);
                if (isParseSuccess && result > 0)
                {
                    keySize = result;
                }
                RsaHelper.GenerateKey(keySize, out xmlPrivateKey, out xmlPublicKey);
                xmlPrivateKeyXmlDocument.InnerXml = xmlPrivateKey;
                xmlPrivateKeyXmlDocument.Save(privateKeyFile);
                xmlPublicKeyXmlDocument.InnerXml = xmlPublicKey;
                xmlPublicKeyXmlDocument.Save(publicKeyFile);
            }
            XmlPrivateKey = xmlPrivateKey;
            XmlPublicKey = xmlPublicKey;
            PemPublicKey = RsaHelper.Xml2Pem(xmlPublicKey);
        }

        public static string XmlPrivateKey { get; private set; }
        public static string XmlPublicKey { get; private set; }
        public static string PemPublicKey { get; private set; }
    }
}