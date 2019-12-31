using log4net;
using SecretMadonna.NEMS.Infrastructure.Common;
using SecretMadonna.NEMS.UI.WebApi.Models;
using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace SecretMadonna.NEMS.UI.WebApi
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(CustomExceptionFilterAttribute));
        private static int numberIndex = 0;
        private int maxRecursiveDepth = 3; // 0：无限递归？？？

        static CustomExceptionFilterAttribute()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        public CustomExceptionFilterAttribute()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);

            var exceptionMaxRecursiveDepth = ConfigurationManager.AppSettings["ExceptionMaxRecursiveDepth"];
            int.TryParse(exceptionMaxRecursiveDepth, out var result);
            if (result >= 0)
            {
                maxRecursiveDepth = result;
            }
        }
        ~CustomExceptionFilterAttribute()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            base.OnException(actionExecutedContext);

            var exception = actionExecutedContext.Exception;
            if (exception != null)
            {
                var exceptionInfo = new StringBuilder();
                exceptionInfo.Append($"******************** log exception begin **************************************************{Environment.NewLine}");
                var type = exception.GetType();
                exceptionInfo.Append($"{type.FullName} {exception.Message}{Environment.NewLine}");
                exceptionInfo.Append(exception.StackTrace);
                exception = exception.InnerException;
                var recursiveDepth = 1;
                while (exception != null && (recursiveDepth < maxRecursiveDepth || maxRecursiveDepth == 0))
                {
                    recursiveDepth++;
                    type = exception.GetType();
                    exceptionInfo.Append($"{Environment.NewLine}{type.FullName} {exception.Message}");
                    exceptionInfo.Append($"{Environment.NewLine}{exception.StackTrace}");
                    exception = exception.InnerException;
                }
                exceptionInfo.Append($"{Environment.NewLine}******************** log exception end **************************************************");
                logger.Error($"Exception{Environment.NewLine}{exceptionInfo}");
            }
            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.InternalServerError, new CommonResponse()
            {
                Code = (int)CommonErrorCode.Fail,
                Description = CommonErrorCode.Fail.Description(),
                Data =
#if DEBUG
                actionExecutedContext.Exception
#else
                "发生了不可预知的错误！"
#endif
            });
        }
        public override Task OnExceptionAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            return base.OnExceptionAsync(actionExecutedContext, cancellationToken);
        }
    }
}