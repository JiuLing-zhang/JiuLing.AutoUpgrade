using JiuLing.AutoUpgrade.Shell.Enums;

namespace JiuLing.AutoUpgrade.Shell.Strategies
{
    internal abstract class NetworkStrategy
    {
        public abstract string Build(NetworkTypeEnum networkType);
    }
}
