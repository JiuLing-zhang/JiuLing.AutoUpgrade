using JiuLing.AutoUpgrade.Enums;

namespace JiuLing.AutoUpgrade.Models
{
    internal class AppConfigInfo
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
        /// 自动更新的检查地址
        /// </summary>
        public string UpgradeUrl { get; set; } = "";
    }
}
