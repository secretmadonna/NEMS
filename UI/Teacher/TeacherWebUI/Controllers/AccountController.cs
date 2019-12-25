using SecretMadonna.NEMS.UI.TeacherWebUI.Models;
using System.Web.Mvc;
using System.Web.Security;

namespace SecretMadonna.NEMS.UI.TeacherWebUI.Controllers
{
    public class AccountController : BaseController
    {
        // GET: Accont
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            var loginModel = new AccountLoginModel()
            {
                Loginname = "test",
                Password = "123456",
                ReturnUrl = Request.QueryString["ReturnUrl"]
            };
            return View(loginModel);
        }
        [HttpPost]
        public ActionResult Login(AccountLoginModel model)
        {
            if (model.Loginname.Equals("test") && model.Password.Equals("123456"))
            {
                FormsAuthentication.SetAuthCookie(model.Loginname, model.RememberMe);
                var url = string.IsNullOrEmpty(model.ReturnUrl) ? FormsAuthentication.DefaultUrl : model.ReturnUrl;
                return Redirect(url);
            }
            return View();
        }
    }
}