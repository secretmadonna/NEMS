using System.Web.Mvc;

namespace SecretMadonna.NEMS.UI.TeacherWebUI.Controllers
{
    public class TestController : BaseController
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TestInputChange()
        {
            return View();
        }
    }
}
