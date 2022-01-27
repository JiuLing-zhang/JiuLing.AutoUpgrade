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
            switch (config.UpgradeMode)
            {
                case UpgradeModeEnum.Http:
                    return new UpgradeUsingHttp();
                case UpgradeModeEnum.Ftp:
                    throw new NotImplementedException("暂时不支持该方式");
                default:
                    throw new ArgumentException("创建更新策略失败：更新方式不正确");
            }
        }
    }
}
