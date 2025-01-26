using System;
using JiuLing.AutoUpgrade.Enums;
using JiuLing.AutoUpgrade.Models;

namespace JiuLing.AutoUpgrade.Updater
{
    internal class UpdateStrategyFactory
    {
        /// <summary>
        /// 创建组件
        /// </summary>
        /// <returns></returns>
        public static UpdateStrategyBase Create(UpgradeConfigInfo config)
        {
            switch (config.UpgradeMode)
            {
                case UpgradeModeEnum.Http:
                    return new HttpUpdateStrategy(config.ConnectionConfig);
                case UpgradeModeEnum.Ftp:
                    return new FtpUpdateStrategy(config.ConnectionConfig);
                default:
                    throw new ArgumentException(AutoUpgrade.Properties.Resources.UnsupportedUpdateMethod);
            }
        }
    }
}
