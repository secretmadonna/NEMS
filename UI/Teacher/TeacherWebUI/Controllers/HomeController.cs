using log4net;
using SecretMadonna.NEMS.UI.TeacherWebUI.Models;
using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Web.Mvc;

namespace SecretMadonna.NEMS.UI.TeacherWebUI.Controllers
{
    public class HomeController : BaseController
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(HomeController));
        private static int numberIndex = 0;

        static HomeController()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        public HomeController()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        ~HomeController()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        // GET: Home
        public ActionResult Index()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            var vm = new HomeIndexViewModel();
            return View(vm);
        }

        public ActionResult TestPost()
        {
            var vm = new HomeTestPostViewModel();
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TestPost(HomeTestPostViewModel vm)
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




        #region 辽科大项目，打印“成绩报告单”
        /// <summary>
        /// 辽科大项目，打印“成绩报告单”
        /// </summary>
        /// <returns></returns>
        public ActionResult PrintScore()
        {
            return View();
        }
        #endregion

        [HttpPost]
        public ActionResult Test()
        {
            return Json(new { ret = "success" });
        }
    }
}