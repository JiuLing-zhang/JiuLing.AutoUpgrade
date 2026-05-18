using JiuLing.AutoUpgrade.Enums;
using JiuLing.AutoUpgrade.Models;
using System;

namespace JiuLing.AutoUpgrade.Downloader
{
    internal class DownloaderFactory
    {
        /// <summary>
        /// 创建组件
        /// </summary>
        /// <returns></returns>
        public static DownloaderBase Create(TargetAppUpgradeInfo upgradeInfo)
        {
            switch (upgradeInfo.UpgradeMode)
            {
                case UpgradeModeEnum.Http:
                    return new HttpDownloader();
                case UpgradeModeEnum.Ftp:
                    return new FtpDownloader((FtpConnectionConfig)upgradeInfo.ConnectionConfig);
                case UpgradeModeEnum.GitHub:
                    return new GitHubDownloader();
                default:
                    throw new ArgumentException(AutoUpgrade.Properties.Resources.UnsupportedUpdateMethod);
            }
        }
    }
}
