using System.Web.Mvc;

namespace SecretMadonna.NEMS.UI.TeacherWebUI.Controllers
{
    [AllowAnonymous]
    public class NoFormController : BaseController
    {
        // GET: NoForm
        public ActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        public ActionResult Test()
        {
            return Json(new { ret = "success" }, JsonRequestBehavior.AllowGet);
        }
    }
}