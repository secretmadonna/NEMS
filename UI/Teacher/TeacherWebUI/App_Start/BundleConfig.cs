﻿using System.Text.RegularExpressions;
using System.Web;
using System.Web.Optimization;

namespace SecretMadonna.NEMS.UI.TeacherWebUI
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.DirectoryFilter.Clear();
            bundles.FileExtensionReplacementList.Clear();
            bundles.FileSetOrderList.Clear();
            bundles.IgnoreList.Clear();

            //bundles.UseCdn = true;

            #region bootstrap（css、js）
            bundles.Add(new ScriptBundle("~/bundles/css/bootstrapcss")
                .Include("~/Content/plugins/normalize/normalize.css")
                .Include("~/Content/plugins/twitter-bootstrap/css/bootstrap.css", new CssRewriteUrlTransformWrapper())
                .Include("~/Content/plugins/twitter-bootstrap/css/bootstrap-theme.css"));

            bundles.Add(new ScriptBundle("~/bundles/js/bootstrapjs").Include("~/Content/plugins/twitter-bootstrap/js/bootstrap.js"));
            #endregion

            #region font-awesome（css）
            var faBundle = new StyleBundle("~/bundles/css/font-awesome")
                .Include("~/Content/plugins/font-awesome/css/font-awesome.css", new CssRewriteUrlTransformWrapper());
            bundles.Add(faBundle);
            #endregion

            #region modernizr（js）
            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好生产准备就绪，请使用 https://modernizr.com 上的生成工具仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/js/modernizr").Include("~/Content/plugins/modernizr/modernizr.js"));
            #endregion

            #region h5、css3（js）
            bundles.Add(new ScriptBundle("~/bundles/js/h5css3")
                .Include("~/Content/plugins/html5shiv/html5shiv.js"
                , "~/Content/plugins/html5shiv/html5shiv-printshiv.js"
                , "~/Content/plugins/respond.js/respond.js"));
            #endregion

            #region jquery（js）
            var jqueryBundle = new ScriptBundle("~/bundles/js/jquery").Include("~/Content/plugins/jquery/jquery.js");
            bundles.Add(jqueryBundle);
            #endregion

            #region jquery.validate（js）
            bundles.Add(new ScriptBundle("~/bundles/js/jqueryval")
                .Include("~/Content/plugins/jquery-validate/jquery.validate.js")
                .Include("~/Content/plugins/jquery-validate/additional-methods.js")
                .Include("~/Content/plugins/jquery-validate/localization/messages_zh.js")
                .Include("~/Content/plugins/jquery-validation-unobtrusive/jquery.validate.unobtrusive.js"));
            #endregion

            BundleTable.EnableOptimizations = true; //是否打包压缩
        }
    }
    public class CssRewriteUrlTransformWrapper : IItemTransform
    {
        public string Process(string includedVirtualPath, string input)
        {
            return new CssRewriteUrlTransform().Process($"~{VirtualPathUtility.ToAbsolute(includedVirtualPath)}", input);
        }
    }
    public class CssRewriteUrlBundleTransform : IBundleTransform
    {
        public void Process(BundleContext context, BundleResponse response)
        {
            throw new System.NotImplementedException();
        }
    }
}
