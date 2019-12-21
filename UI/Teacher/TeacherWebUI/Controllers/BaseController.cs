using log4net;
using System.Reflection;
using System.Web.Mvc;

namespace SecretMadonna.NEMS.UI.TeacherWebUI.Controllers
{
    public class BaseController : Controller
    {
        public static ILog logger = LogManager.GetLogger(typeof(BaseController));
        public static int numberIndex = 0;

        static BaseController()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        public BaseController()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        ~BaseController()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
    }
}