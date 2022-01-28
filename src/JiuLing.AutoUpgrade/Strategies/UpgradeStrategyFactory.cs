using JiuLing.AutoUpgrade.Enums;
using JiuLing.AutoUpgrade.Models;

namespace JiuLing.AutoUpgrade.Strategies
{
    internal class UpgradeStrategyFactory
    {
        /// <summary>
        /// 创建组件
        /// </summary>
        /// <returns></returns>
        public static UpgradeStrategy Create(UpgradeConfigInfo config)
        {
            return config.UpgradeMode switch
            {
                UpgradeModeEnum.Http => new UpgradeStrategyUsingHttp(config.ConnectionConfig),
                UpgradeModeEnum.Ftp => new UpgradeStrategyUsingFtp(config.ConnectionConfig),
                _ => throw new ArgumentException("创建更新策略失败：更新方式不正确")
            };
        }
    }
}
