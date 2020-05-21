using log4net;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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
            //base.HandleUnauthorizedRequest(filterContext);
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = new JsonResult
                {
                    Data = new
                    {
                        ret = (int)HttpStatusCode.Unauthorized,
                        msg = HttpStatusCode.Unauthorized.ToString()
                    },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            else
            {
                FormsAuthentication.RedirectToLoginPage();//重定向到登录页
            }
            filterContext.HttpContext.Response.Redirect(FormsAuthentication.LoginUrl, true);
        }
        protected override HttpValidationStatus OnCacheAuthorization(HttpContextBase httpContext)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            return base.OnCacheAuthorization(httpContext);
        }
    }
}