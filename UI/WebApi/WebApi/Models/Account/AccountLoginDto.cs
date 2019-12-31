using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Http;

namespace SecretMadonna.NEMS.UI.WebApi.Models
{
    [HttpBindRequired]
    public class AccountLoginDto
    {
        [Required]
        public string Loginname { get; set; }
        [Required]
        public string Password { get; set; }
    }
}