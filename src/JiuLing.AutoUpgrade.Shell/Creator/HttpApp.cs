using System;
using JiuLing.AutoUpgrade.Shared;

namespace JiuLing.AutoUpgrade.Shell.Creator
{
    internal class HttpApp: BaseUpgradeApp
    {
        private readonly string _upgradeUrl;

        public HttpApp(string upgradeUrl)
        {
            if (string.IsNullOrEmpty(upgradeUrl))
            {
                throw new ArgumentException("自动更新地址未配置");
            }
            _upgradeUrl = upgradeUrl;
        }

        protected override string GetInnerArguments()
        {
            return $"-{ArgumentTypeEnum.http} {_upgradeUrl}";
        }
    }
}
