using JiuLing.AutoUpgrade.Shell.Enums;

namespace JiuLing.AutoUpgrade.Shell.Strategies
{
    //TODO 需要重命名文件
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
