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
        public static UpdateStrategyBase Create(TargetAppUpgradeInfo upgradeInfo)
        {
            switch (upgradeInfo.UpgradeMode)
            {
                case UpgradeModeEnum.Http:
                    return new HttpUpdateStrategy((HttpConnectionConfig)upgradeInfo.ConnectionConfig);
                case UpgradeModeEnum.Ftp:
                    return new FtpUpdateStrategy((FtpConnectionConfig)upgradeInfo.ConnectionConfig);
                case UpgradeModeEnum.GitHub:
                    return new GitHubUpdateStrategy((GitHubConnectionConfig)upgradeInfo.ConnectionConfig);
                default:
                    throw new ArgumentException(Properties.Resources.UnsupportedUpdateMethod);
            }
        }
    }
}
