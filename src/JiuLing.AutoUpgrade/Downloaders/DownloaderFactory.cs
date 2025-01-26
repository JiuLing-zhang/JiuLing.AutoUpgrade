using System;
using JiuLing.AutoUpgrade.Enums;
using JiuLing.AutoUpgrade.Models;

namespace JiuLing.AutoUpgrade.Templates
{
    internal class DownloaderFactory
    {
        /// <summary>
        /// 创建组件
        /// </summary>
        /// <returns></returns>
        public static DownloaderBase Create(UpgradeConfigInfo config)
        {
            switch (config.UpgradeMode)
            {
                case UpgradeModeEnum.Http:
                    return new HttpDownloader();
                case UpgradeModeEnum.Ftp:
                    return new FtpDownloader(config.ConnectionConfig);
                default:
                    throw new ArgumentException(AutoUpgrade.Properties.Resources.UnsupportedUpdateMethod);
            }
        }
    }
}
