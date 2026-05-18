using System;
using System.Text;
using JiuLing.AutoUpgrade.Enums;
using JiuLing.CommonLibs.Enums;
using System.Windows.Media.Imaging;
using JiuLing.CommonLibs.ExtensionMethods;

namespace JiuLing.AutoUpgrade.Models
{
    /// <summary>
    /// 自动更新目标程序的信息
    /// </summary>
    internal class TargetAppUpgradeInfo
    {
        /// <summary>
        /// 标题（原始）
        /// </summary>
        public string TitleRaw { get; set; } = "";
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            get
            {
                if (TitleRaw.IsEmpty())
                {
                    throw new ArgumentException("应用名称格式错误");
                }
                try
                {
                    var bytes = Convert.FromBase64String(TitleRaw);
                    return Encoding.UTF8.GetString(bytes);
                }
                catch
                {
                    throw new ArgumentException("应用名称格式错误");
                }
            }
        }

        /// <summary>
        /// 完整路径（原始）
        /// </summary>
        public string FullPathRaw { get; set; } = "";

        /// <summary>
        /// 完整路径
        /// </summary>
        public string FullPath
        {
            get
            {
                if (FullPathRaw.IsEmpty())
                {
                    throw new ArgumentException("应用完整路径格式错误");
                }
                try
                {
                    var bytes = Convert.FromBase64String(FullPathRaw);
                    return Encoding.UTF8.GetString(bytes);
                }
                catch
                {
                    throw new ArgumentException("应用完整路径格式错误");
                }
            }
        }

        /// <summary>
        /// 版本（原始）
        /// </summary>
        public string VersionRaw { get; set; } = "";

        /// <summary>
        /// 版本
        /// </summary>
        public Version Version
        {
            get
            {
                if (VersionRaw.IsEmpty())
                {
                    throw new ArgumentException("应用版本格式错误");
                }
                if (Version.TryParse(VersionRaw, out var version))
                {
                    return version;
                }
                throw new ArgumentException("应用版本格式错误");
            }
        }

        /// <summary>
        /// 更新方式
        /// </summary>
        public UpgradeModeEnum UpgradeMode { get; set; }

        /// <summary>
        /// 请求连接配置
        /// </summary>
        public ConnectionConfigBase ConnectionConfig { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public BitmapFrame Icon { get; set; } = null;

        /// <summary>
        /// 版本号的显示格式
        /// </summary>
        public VersionFormatEnum VersionFormat { get; set; }
    }
}
