using JiuLing.AutoUpgrade.Enums;
using JiuLing.AutoUpgrade.Models;

namespace JiuLing.AutoUpgrade.Templates
{
    internal class UpgradeTemplateFactory
    {
        /// <summary>
        /// 创建组件
        /// </summary>
        /// <returns></returns>
        public static UpgradeAbstract Create(UpgradeConfigInfo config)
        {
            return config.UpgradeMode switch
            {
                UpgradeModeEnum.Http => new UpgradeUsingHttp(),
                UpgradeModeEnum.Ftp => new UpgradeUsingFtp(config.ConnectionConfig),
                _ => throw new ArgumentException("创建更新策略失败：更新方式不正确")
            };
        }
    }
}
