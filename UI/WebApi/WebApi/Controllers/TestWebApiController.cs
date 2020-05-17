using log4net;
using System.Reflection;
using System.Web.Http;

namespace SecretMadonna.NEMS.UI.WebApi.Controllers
{
    public class TestWebApiController : BaseApiController
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(TestWebApiController));
        private static int numberIndex = 0;

        static TestWebApiController()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        public TestWebApiController()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        ~TestWebApiController()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        public IHttpActionResult Index()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            return Ok("TestWebApi/Index");
        }
    }
}