using log4net;
using System.Reflection;
using System.Web.Http;

namespace SecretMadonna.NEMS.UI.WebApi.Controllers
{
    public class BaseApiController : ApiController
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(BaseApiController));
        private static int numberIndex = 0;

        static BaseApiController()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        public BaseApiController()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        ~BaseApiController()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
    }
}
