using System.ComponentModel.DataAnnotations;

namespace SecretMadonna.NEMS.UI.TeacherWebUI.Models
{
    public class AccountLoginViewModel
    {
        public string Loginname { get; set; }
        public string Password { get; set; }
        [Display(Name = "记住我？", Description = "创建持久cookie", ShortName = "记住我")]
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}