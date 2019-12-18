using log4net;
using SecretMadonna.NEMS.UI.TeacherWebUI.Models;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web.Mvc;

namespace SecretMadonna.NEMS.UI.TeacherWebUI.Controllers
{
    public class HomeController : Controller
    {
        public ILog logger = LogManager.GetLogger(typeof(HomeController));
        // GET: Home
        public ActionResult Index()
        {
            var vm = new HomeIndexModel();
            return View(vm);
        }

        public ActionResult TestPost()
        {
            var vm = new HomeTestPostModel();
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TestPost(HomeTestPostModel vm)
        {
            logger.Info(vm);
            var saveFile = Server.MapPath($"~/ResourceFiles/{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.jpg");
            Base64ToImageFile(vm.ImageBase64, saveFile);
            return Json(new { ret = "success" });
        }


        private void Base64ToImageFile(string base64, string saveFile)
        {
            var realBase64 = base64.Replace("data:image/png;base64,", "")
                .Replace("data:image/jgp;base64,", "")
                    .Replace("data:image/jpg;base64,", "")
                    .Replace("data:image/jpeg;base64,", ""); // 将 base64 头部信息处理掉
            var bytes = Convert.FromBase64String(realBase64);
            using (var ms = new MemoryStream(bytes))
            {
                using (var bitmap = new Bitmap(ms))
                {
                    var savePath = Path.GetDirectoryName(saveFile);
                    if (!Directory.Exists(savePath))
                    {
                        Directory.CreateDirectory(savePath);
                    }
                    bitmap.Save(saveFile);
                }
            }
        }
    }
}