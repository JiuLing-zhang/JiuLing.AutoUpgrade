using JiuLing.AutoUpgrade.Enums;
using JiuLing.CommonLibs.Enums;
using System.Windows.Media.Imaging;

namespace JiuLing.AutoUpgrade.Models
{
    /// <summary>
    /// 自动更新配置
    /// </summary>
    internal class UpgradeConfigInfo
    {
        /// <summary>
        /// 主进程名称
        /// </summary>
        public string MainProcessName { get; set; } = "";
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
