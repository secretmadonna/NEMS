namespace SecretMadonna.NEMS.Application.Models
{
    public class UserDto
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string NickName { get; set; }
        public int Status { get; set; }
    }
    public enum UserStatus
    {
        Normal = 1,
        Disabled = 2
    }
}
