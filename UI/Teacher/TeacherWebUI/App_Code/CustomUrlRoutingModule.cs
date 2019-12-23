using log4net;
using System.Reflection;
using System.Web;
using System.Web.Routing;

namespace SecretMadonna.NEMS.UI.TeacherWebUI
{
    public class CustomUrlRoutingModule : UrlRoutingModule, IHttpModule
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(CustomUrlRoutingModule));
        private static int numberIndex = 0;
        
        static CustomUrlRoutingModule()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        public CustomUrlRoutingModule()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        ~CustomUrlRoutingModule()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        public override void PostResolveRequestCache(HttpContextBase context)
        {
            base.PostResolveRequestCache(context);
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            var ctx = context;
        }
    }
}