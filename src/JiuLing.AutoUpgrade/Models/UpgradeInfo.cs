using JiuLing.AutoUpgrade.Models;
using JiuLing.CommonLibs.Model;

namespace JiuLing.AutoUpgrade
{
    internal static class UpgradeInfo
    {
        /// <summary>
        /// 自动更新的配置信息
        /// </summary>
        public static UpgradeConfigInfo UpgradeConfig { get; set; }

        /// <summary>
        /// 主进程信息（待更新的程序进程）
        /// </summary>
        public static ProcessInfo MainProcess { get; set; }

        /// <summary>
        /// 主进程版本
        /// </summary>
        public static string MainAppVersion { get; set; }

        /// <summary>
        /// 新版本更新信息
        /// </summary>
        public static AppUpgradeInfo AppNewVersion { get; set; }

        /// <summary>
        /// 本次是否需要更新
        /// </summary>
        public static bool IsNeedUpdate { get; set; }

        /// <summary>
        /// 配置更新时的一些设置
        /// </summary>
        public static UpgradeSetting UpgradeSetting { get; set; } = new UpgradeSetting();
    }
}
