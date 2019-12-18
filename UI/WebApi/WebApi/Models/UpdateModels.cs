using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecretMadonna.NEMS.UI.WebApi.Models
{
    public class AppVersion
    {
        public string AppId { get; set; }
        public string AppName { get; set; }
        public string AppDesciption { get; set; }
        public int VersionCode { get; set; }
        public string VersionName { get; set; }
        public string VersionTitle { get; set; }
        public string VersionContent { get; set; }
        public string InstallationPackageUrl { get; set; }
        public long InstallationPackageSize { get; set; }
        public string InstallationPackageMD5 { get; set; }
        public bool IsFocus { get; set; }
    }
    public class UpdateCheckVersionModel
    {
        /// <summary>
        /// 0：不更新；1：更新；其他：强制更新
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 最新版本号
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// 下载地址
        /// </summary>
        public string Url { get; set; }
    }
}