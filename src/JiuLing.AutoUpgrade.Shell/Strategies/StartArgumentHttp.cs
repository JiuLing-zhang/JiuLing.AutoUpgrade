using JiuLing.AutoUpgrade.Shell.Enums;

namespace JiuLing.AutoUpgrade.Shell.Strategies
{
    /// <summary>
    /// Http参数构造策略
    /// </summary>
    internal class StartArgumentHttp : StartArgumentStrategy
    {
        private readonly string _upgradeUrl;
        public StartArgumentHttp(string upgradeUrl)
        {
            _upgradeUrl = upgradeUrl;
        }

        public override string Build(string mainProcessName, ConnectionTypeEnum connectionType)
        {
            return $"{mainProcessName} {connectionType} {_upgradeUrl}";
        }
    }
}
