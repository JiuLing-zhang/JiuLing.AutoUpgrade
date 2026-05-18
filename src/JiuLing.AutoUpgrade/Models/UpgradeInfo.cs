using JiuLing.CommonLibs.Model;

namespace JiuLing.AutoUpgrade.Models
{
    internal static class UpgradeInfo
    {
        /// <summary>
        /// 自动更新的配置信息
        /// </summary>
        public static TargetAppUpgradeInfo TargetAppUpgradeInfo { get; set; }

        /// <summary>
        /// 新版本更新信息
        /// </summary>
        public static AppUpdateInfo AppNewVersion { get; set; }

        /// <summary>
        /// 本次是否允许运行
        /// </summary>
        public static bool AllowRun { get; set; }

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
