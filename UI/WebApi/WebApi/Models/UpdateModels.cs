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
        /// 0：不更新；1：强制更新；其他：更新
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 最新版本编号
        /// </summary>
        public int LatestVersionCode { get; set; }
        /// <summary>
        /// 最新版本名称
        ///   主版本号（Major）.次版本号（Minor）.内部版本号（Build）.修订号（Revision）_阶段标识
        ///   主版本号（Major）        : 当功能模块有较大的变动，比如增加多个模块或者整体架构发生变化。此版本号由项目决定是否修改。
        ///   次版本号（Minor）        : 当功能有一定的增加或变化，比如增加了对权限控制、增加自定义视图等功能。此版本号由项目决定是否修改。
        ///   内部版本号（Build）      : 一般是 Bug 修复或是一些小的变动，要经常发布修订版，时间间隔不限，修复一个严重的bug即可发布一个修订版。此版本号由项目经理决定是否修改。
        ///   修订号（Revision）       : 用于记录修改项目的当前日期，每天对项目的修改都需要更改日期版本号。此版本号由开发人员决定是否修改。
        ///   阶段标识                 : 用于标注当前版本的软件处于哪个开发阶段，当软件进入到另一个阶段时需要修改此版本号。此版本号由项目决定是否修改。
        /// </summary>
        public string LatestVersionName { get; set; }
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