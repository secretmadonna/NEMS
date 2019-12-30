using log4net;
using SecretMadonna.NEMS.Infrastructure.Common;
using SecretMadonna.NEMS.UI.WebApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace SecretMadonna.NEMS.UI.WebApi
{
    public class CustomActionFilterAttribute : ActionFilterAttribute
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(CustomActionFilterAttribute));
        private static int numberIndex = 0;

        static CustomActionFilterAttribute()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        public CustomActionFilterAttribute()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        ~CustomActionFilterAttribute()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        #region override
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            base.OnActionExecuted(actionExecutedContext);
        }
        public override Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            return base.OnActionExecutedAsync(actionExecutedContext, cancellationToken);
        }
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            base.OnActionExecuting(actionContext);
            var httpActionDescriptor = actionContext.ActionDescriptor as HttpActionDescriptor;
            if (httpActionDescriptor != null)
            {
                var httpParameterDescriptors = httpActionDescriptor.GetParameters();
                foreach (var httpParameterDescriptor in httpParameterDescriptors)
                {
                    var validationAttributes = httpParameterDescriptor.GetCustomAttributes<ValidationAttribute>();
                    foreach (var validationAttribute in validationAttributes)
                    {
                        if (validationAttribute != null)
                        {
                            var isValid = validationAttribute.IsValid(actionContext.ActionArguments[httpParameterDescriptor.ParameterName]);
                            if (!isValid)
                            {
                                actionContext.ModelState.AddModelError(httpParameterDescriptor.ParameterName, validationAttribute.FormatErrorMessage(httpParameterDescriptor.ParameterName));
                            }
                        }
                    }
                }
            }
            if (!actionContext.ModelState.IsValid)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.OK, new CommonResponse()
                {
                    Code = (int)CommonErrorCode.ParameterError,
                    Description = CommonErrorCode.ParameterError.Description(),
                    Data = actionContext.ModelState
                });
            }
        }
        public override Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            return base.OnActionExecutingAsync(actionContext, cancellationToken);
        }
        #endregion
    }
}