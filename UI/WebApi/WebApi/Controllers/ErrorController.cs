using log4net;
using SecretMadonna.NEMS.Infrastructure.Common;
using SecretMadonna.NEMS.UI.WebApi.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

namespace SecretMadonna.NEMS.UI.WebApi.Controllers
{
    public class ErrorController : ApiController
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(ErrorController));
        private static int numberIndex = 0;

        static ErrorController()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        public ErrorController()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        ~ErrorController()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        [HttpGet, HttpPost, Route("error/index")]
        public IHttpActionResult Index()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);

            var result = new CommonResponse();
            result.Code = (int)CommonErrorCode.Fail;
            result.Description = CommonErrorCode.Fail.Description();
            var qs = Request.RequestUri.Query.TrimStart(new char[] { '?' });
            result.Data = qs;

            var httpStatusCode = HttpStatusCode.InternalServerError;
            var tempstrs = string.IsNullOrWhiteSpace(qs) ? null : qs.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            if (tempstrs != null && tempstrs.Length > 0)
            {
                int.TryParse(tempstrs[0], out int intHttpStatusCode);
                if (intHttpStatusCode > 0)
                {
                    httpStatusCode = (HttpStatusCode)intHttpStatusCode;
                }
            }
            return ResponseMessage(Request.CreateResponse(httpStatusCode, result));
        }
        [HttpGet, HttpPost, Route("error/details")]
        private IHttpActionResult Details()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);

            var result = new CommonResponse();
            result.Code = (int)CommonErrorCode.Fail;
            result.Description = CommonErrorCode.Fail.Description();
            var qs = Request.RequestUri.Query.TrimStart(new char[] { '?' });
            result.Data = qs;

            var httpStatusCode = HttpStatusCode.InternalServerError;
            var tempstrs = string.IsNullOrWhiteSpace(qs) ? null : qs.Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries);
            if (tempstrs != null && tempstrs.Length > 0)
            {
                tempstrs = tempstrs[tempstrs.Length - 1].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                if (tempstrs != null && tempstrs.Length > 1)
                {
                    tempstrs = tempstrs[1].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    if (tempstrs != null && tempstrs.Length > 1)
                    {
                        int.TryParse(tempstrs[0], out int intHttpStatusCode);
                        if (intHttpStatusCode > 0)
                        {
                            httpStatusCode = (HttpStatusCode)intHttpStatusCode;
                        }
                    }
                }
            }
            //return ResponseMessage(Request.CreateResponse(httpStatusCode, result));
            return Ok(result);
        }

        [HttpGet, HttpPost, Route("error/sc400")]
        public IHttpActionResult Sc400()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);

            var result = new CommonResponse();
            result.Code = (int)CommonErrorCode.Fail;
            result.Description = CommonErrorCode.Fail.Description();
            result.Data = new { Query = Request.RequestUri.Query.TrimStart(new char[] { '?' }), HttpStatusCode = HttpStatusCode.BadRequest, };
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, result));
        }
        [HttpGet, HttpPost, Route("error/sc404")]
        public IHttpActionResult Sc404()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);

            var result = new CommonResponse();
            result.Code = (int)CommonErrorCode.Fail;
            result.Description = CommonErrorCode.Fail.Description();
            result.Data = new { Query = Request.RequestUri.Query.TrimStart(new char[] { '?' }), HttpStatusCode = HttpStatusCode.NotFound, };
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, result));
        }
        [HttpGet, HttpPost, Route("error/sc500")]
        public IHttpActionResult Sc500()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);

            var result = new CommonResponse();
            result.Code = (int)CommonErrorCode.Fail;
            result.Description = CommonErrorCode.Fail.Description();
            result.Data = new { Query = Request.RequestUri.Query.TrimStart(new char[] { '?' }), HttpStatusCode = HttpStatusCode.InternalServerError, };
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, result));
        }
    }
}
