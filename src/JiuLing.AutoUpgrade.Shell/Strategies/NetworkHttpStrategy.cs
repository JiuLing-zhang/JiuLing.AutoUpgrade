using JiuLing.AutoUpgrade.Shell.Enums;

namespace JiuLing.AutoUpgrade.Shell.Strategies
{
    /// <summary>
    /// Http参数构造策略
    /// </summary>
    internal class NetworkHttpStrategy : NetworkStrategy
    {
        private readonly string _upgradeUrl;
        public NetworkHttpStrategy(string upgradeUrl)
        {
            _upgradeUrl = upgradeUrl;
        }

        public override string Build(NetworkTypeEnum networkType)
        {
            return $"-n {networkType} {_upgradeUrl}";
        }
    }
}
