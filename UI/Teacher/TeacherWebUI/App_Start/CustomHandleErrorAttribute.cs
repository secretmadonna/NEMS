using log4net;
using System.Reflection;
using System.Web.Mvc;

namespace SecretMadonna.NEMS.UI.TeacherWebUI
{
    public class CustomHandleErrorAttribute : HandleErrorAttribute
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(CustomActionFilterAttribute));
        private static int numberIndex = 0;

        public override void OnException(ExceptionContext filterContext)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            base.OnException(filterContext);
        }
    }
}