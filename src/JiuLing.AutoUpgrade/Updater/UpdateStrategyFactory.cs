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
                    return new HttpUpdateStrategy((HttpConnectionConfig)config.ConnectionConfig);
                case UpgradeModeEnum.Ftp:
                    return new FtpUpdateStrategy((FtpConnectionConfig)config.ConnectionConfig);
                case UpgradeModeEnum.GitHub:
                    return new GitHubUpdateStrategy((GitHubConnectionConfig)config.ConnectionConfig);
                default:
                    throw new ArgumentException(Properties.Resources.UnsupportedUpdateMethod);
            }
        }
    }
}
