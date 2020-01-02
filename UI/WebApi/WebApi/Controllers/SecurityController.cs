using log4net;
using SecretMadonna.NEMS.Infrastructure.Common;
using SecretMadonna.NEMS.UI.WebApi.Models;
using System.Reflection;
using System.Web.Http;

namespace SecretMadonna.NEMS.UI.WebApi.Controllers
{
    public class SecurityController : ApiController
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(SecurityController));
        private static int numberIndex = 0;

        static SecurityController()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        public SecurityController()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        ~SecurityController()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        [HttpGet, Route("security/getpublickey")]
        public IHttpActionResult GetPublicKey()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            var result = new CommonResponse()
            {
                Code = (int)CommonErrorCode.Success,
                Description = CommonErrorCode.Success.Description(),
                Data = RsaKeyManager.PublicKey
            };
            return Ok(result);
        }
    }
}