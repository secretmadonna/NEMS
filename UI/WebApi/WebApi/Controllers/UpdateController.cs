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
        /// HttpResponseMessage 和 IHttpActionResult
        /// </summary>
        /// <param name="version">AppVersionCode</param>
        /// <returns></returns>
        [Route("api/update/checkversion/{version:min(0)}")]
        public HttpResponseMessage CheckVersion(int version)
        {
            return null;
        }
    }
}
