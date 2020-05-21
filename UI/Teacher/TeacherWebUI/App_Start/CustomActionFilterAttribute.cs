using log4net;
using System.Reflection;
using System.Web.Mvc;

namespace SecretMadonna.NEMS.UI.TeacherWebUI
{
    public class CustomActionFilterAttribute : ActionFilterAttribute
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(CustomActionFilterAttribute));
        private static int numberIndex = 0;

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            base.OnActionExecuted(filterContext);
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            base.OnActionExecuting(filterContext);
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            base.OnResultExecuted(filterContext);
        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            base.OnResultExecuting(filterContext);
        }
    }
}