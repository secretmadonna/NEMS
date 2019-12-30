using log4net;
using SecretMadonna.NEMS.Application;
using SecretMadonna.NEMS.Application.Models;
using SecretMadonna.NEMS.Infrastructure.Common;
using SecretMadonna.NEMS.UI.WebApi.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

namespace SecretMadonna.NEMS.UI.WebApi.Controllers
{
    public class AccountController : BaseApiController
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(AccountController));
        private static int numberIndex = 0;

        private UserApplicationService userApplicationService = new UserApplicationService();

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost, Route("account/login")]
        public IHttpActionResult Login([Required]AccountLoginDto dto)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            var result = new CommonResponse();
            if (dto == null)
            {
                result.Code = (int)CommonErrorCode.ParameterError;
                result.Description = CommonErrorCode.ParameterError.Description();
                //return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, result));
                return Ok(result);
            }
            var user = userApplicationService.GetByLoginname(dto.Loginname);
            if (user == null)
            {
                result.Code = (int)AccountLoginErrorCode.LoginnameNotExist;
                result.Description = AccountLoginErrorCode.LoginnameNotExist.Description();
                return Ok(result);
            }
            else if (!user.Password.Equals(dto.Password))
            {
                result.Code = (int)AccountLoginErrorCode.LoginnameAndPasswordNotMatch;
                result.Description = AccountLoginErrorCode.LoginnameAndPasswordNotMatch.Description();
                return Ok(result);
            }
            else if (user.Status == (int)UserStatus.Disabled)
            {
                result.Code = (int)AccountLoginErrorCode.AccountIsDisabled;
                result.Description = AccountLoginErrorCode.AccountIsDisabled.Description();
                return Ok(result);
            }
            result.Code = (int)CommonErrorCode.Success;
            result.Description = CommonErrorCode.Success.Description();
            result.Data = user;
            return Ok(result);
        }
    }
}
