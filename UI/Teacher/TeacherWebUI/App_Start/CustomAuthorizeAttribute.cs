using log4net;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace SecretMadonna.NEMS.UI.TeacherWebUI
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(CustomActionFilterAttribute));
        private static int numberIndex = 0;

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            base.OnAuthorization(filterContext);
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            return base.AuthorizeCore(httpContext);
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            base.HandleUnauthorizedRequest(filterContext);
        }
        protected override HttpValidationStatus OnCacheAuthorization(HttpContextBase httpContext)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            return base.OnCacheAuthorization(httpContext);
        }
    }
}