using System.ComponentModel;

namespace SecretMadonna.NEMS.UI.WebApi.Models
{
    public enum CommonErrorCode
    {
        [Description("成功")]
        Success = 0,
        [Description("失败")]
        Fail = -999999,
        [Description("参数错误")]
        ParameterError = -888888
    }
}