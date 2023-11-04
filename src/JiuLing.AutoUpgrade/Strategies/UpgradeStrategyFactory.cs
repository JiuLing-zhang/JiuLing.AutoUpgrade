using System;
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
            switch (config.UpgradeMode)
            {
                case UpgradeModeEnum.Http:
                    return new UpgradeStrategyUsingHttp(config.ConnectionConfig);
                case UpgradeModeEnum.Ftp:
                    return new UpgradeStrategyUsingFtp(config.ConnectionConfig);
                default:
                    throw new ArgumentException(lang.UnsupportedUpdateMethod);
            }
        }
    }
}
