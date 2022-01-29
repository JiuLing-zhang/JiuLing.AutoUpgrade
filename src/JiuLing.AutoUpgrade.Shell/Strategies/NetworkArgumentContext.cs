using JiuLing.AutoUpgrade.Shell.Enums;

namespace JiuLing.AutoUpgrade.Shell.Strategies
{
    internal class NetworkArgumentContext
    {
        private readonly NetworkStrategy _strategy;
        public NetworkArgumentContext(NetworkStrategy strategy)
        {
            _strategy = strategy;
        }

        public string GetStartArguments(NetworkTypeEnum networkType)
        {
            return _strategy.Build(networkType);
        }
    }
}
