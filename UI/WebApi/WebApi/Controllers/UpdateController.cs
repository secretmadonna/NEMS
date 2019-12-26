using log4net;
using System.Reflection;
using System.Web.Http;

namespace SecretMadonna.NEMS.UI.WebApi.Controllers
{
    public class UpdateController : BaseApiController
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(UpdateController));
        private static int numberIndex = 0;

        static UpdateController()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        public UpdateController()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        ~UpdateController()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="version">StudentApp.VersionCode</param>
        /// <returns></returns>
        [Route("studentapp/update/checkversion/{version:min(0)}")]
        public IHttpActionResult CheckStuAppVersion(int version)
        {
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        [Route("frnas/update/checkversion/{version:min(0)}")]
        public IHttpActionResult CheckFrnasVersion(int version)
        {
            return null;
        }
    }
}
