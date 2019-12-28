using SecretMadonna.NEMS.Application.Models;

namespace SecretMadonna.NEMS.Application
{
    public class UserApplicationService
    {
        /// <summary>
        /// 根据登录名获取用户
        ///   密码：明文、加密（对称加密、非对称加密、不可逆加密（散列？？？））
        /// </summary>
        /// <param name="loginname">用户名、手机号、邮箱</param>
        /// <returns></returns>
        public UserDto GetByLoginname(string loginname)
        {
            if (loginname.Equals("normaluser"))
            {
                return new UserDto()
                {
                    UserId = "12345678",
                    UserName = "normaluser",
                    Password = "123456",
                    NickName = "normaluser",
                    Status = (int)UserStatus.Normal,
                };
            }
            else if (loginname.Equals("disableduser"))
            {
                return new UserDto()
                {
                    UserId = "12345679",
                    UserName = "disableduser",
                    Password = "123456",
                    NickName = "disableduser",
                    Status = (int)UserStatus.Disabled,
                };
            }
            return null;
        }
    }
}
