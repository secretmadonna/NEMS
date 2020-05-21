using System.Web.Mvc;

namespace SecretMadonna.NEMS.UI.TeacherWebUI.Controllers
{
    [AllowAnonymous]
    public class NoFormController : Controller
    {
        // GET: NoForm
        public ActionResult Index()
        {
            return View();
        }
    }
}