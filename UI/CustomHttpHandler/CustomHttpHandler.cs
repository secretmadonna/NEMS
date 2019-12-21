using log4net;
using System.Reflection;
using System.Web;

namespace SecretMadonna.NEMS.UI.CustomHttpHandler
{
    public class CustomHttpHandler : IHttpHandler
    {
        public static ILog logger = LogManager.GetLogger(typeof(CustomHttpHandler));
        public static int numberIndex = 0;

        static CustomHttpHandler()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        public CustomHttpHandler()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        ~CustomHttpHandler()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        /// <summary>
        /// 您将需要在网站的 Web.config 文件中配置此处理程序 
        /// 并向 IIS 注册它，然后才能使用它。有关详细信息，
        /// 请参阅以下链接: https://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Members
        public bool IsReusable
        {
            // 如果无法为其他请求重用托管处理程序，则返回 false。
            // 如果按请求保留某些状态信息，则通常这将为 false。
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            //在此处写入您的处理程序实现。
        }
        #endregion
    }
}
