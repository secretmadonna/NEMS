using System.ComponentModel;

namespace SecretMadonna.NEMS.UI.WebApi.Models
{
    public enum AccountLoginErrorCode
    {
        [Description("登录名不存在")]
        LoginnameNotExist = -1,
        [Description("登录名和密码不匹配")]
        LoginnameAndPasswordNotMatch = -2,
        [Description("账户被禁用")]
        AccountIsDisabled = -3
    }
}