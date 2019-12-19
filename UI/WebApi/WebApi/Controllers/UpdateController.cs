using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SecretMadonna.NEMS.UI.WebApi.Controllers
{
    public class UpdateController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="version">StudentApp.VersionCode</param>
        /// <returns></returns>
        [Route("api/studentapp/update/checkversion/{version:min(0)}")]
        public IHttpActionResult CheckStuAppVersion(int version)
        {
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        [Route("api/frnas/update/checkversion/{version:min(0)}")]
        public IHttpActionResult CheckFrnasVersion(int version)
        {
            return null;
        }
    }
}
