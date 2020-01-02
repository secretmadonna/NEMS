using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;

namespace SecretMadonna.NEMS.Infrastructure.Common
{
    public static class XmlHelper
    {
        #region 序列化
        public static string Serialize<T>(T obj, Encoding encoding) where T : new()
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            var xmlSerializer = new XmlSerializer(obj.GetType());
            using (var ms = new MemoryStream())
            {
                using (var xtw = new XmlTextWriter(ms, encoding))
                {
                    xtw.Formatting = Formatting.Indented;
                    xmlSerializer.Serialize(xtw, obj);
                }
                var xml = encoding.GetString(ms.ToArray());
                xml = xml.Replace("xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"", "");
                xml = xml.Replace("xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"", "");
                xml = Regex.Replace(xml, @"\s{2}", "");
                xml = Regex.Replace(xml, @"\s{1}/>", "/>");
                return xml;
            }
        }
        public static string Serialize<T>(T obj) where T : new()
        {
            return Serialize<T>(obj, Encoding.Default);
        }

        public static string ObjectToXml(object obj)
        {
            using (var ms = new MemoryStream())
            {
                var xmlSerializer = new XmlSerializer(obj.GetType());
                xmlSerializer.Serialize(ms, obj);
                using (var sr = new StreamReader(ms))
                {
                    return sr.ReadToEnd();
                }
            }
        }
        #endregion

        #region 反序列化
        public static T DeSerialize<T>(string xml, Encoding encoding) where T : new()
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            using (var ms = new MemoryStream(encoding.GetBytes(xml)))
            {
                using (var sr = new StreamReader(ms, encoding))
                {
                    return (T)xmlSerializer.Deserialize(sr);
                }
            }
        }
        public static T DeSerialize<T>(string xml) where T : new()
        {
            return DeSerialize<T>(xml, Encoding.Default);
        }
        #endregion
    }
}
