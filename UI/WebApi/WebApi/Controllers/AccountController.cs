using log4net;
using System.Reflection;
using System.Web.Http;

namespace SecretMadonna.NEMS.UI.WebApi.Controllers
{
    public class AccountController : BaseApiController
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(AccountController));
        private static int numberIndex = 0;

        static AccountController()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        public AccountController()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        ~AccountController()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        public IHttpActionResult Login()
        {
            return null;
        }
    }
}
