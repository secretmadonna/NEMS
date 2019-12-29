using log4net;
using SecretMadonna.NEMS.Infrastructure.Common;
using SecretMadonna.NEMS.UI.WebApi.Models;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace SecretMadonna.NEMS.UI.WebApi
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(CustomExceptionFilterAttribute));
        private static int numberIndex = 0;

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            base.OnException(actionExecutedContext);
            logger.Error("CustomExceptionFilterAttribute", actionExecutedContext.Exception);
            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.InternalServerError, new CommonResponse()
            {
                Code = (int)CommonErrorCode.Fail,
                Description = CommonErrorCode.Fail.Description(),
                Data = actionExecutedContext.Exception
            });
        }
        public override Task OnExceptionAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            return base.OnExceptionAsync(actionExecutedContext, cancellationToken);
        }
    }
}