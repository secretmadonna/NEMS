﻿namespace SecretMadonna.NEMS.UI.TeacherWebUI.Models
{
    public class AccountLoginModel
    {
        public string Loginname { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}