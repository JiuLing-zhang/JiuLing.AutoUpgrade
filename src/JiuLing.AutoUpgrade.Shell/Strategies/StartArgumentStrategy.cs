using JiuLing.AutoUpgrade.Shell.Enums;

namespace JiuLing.AutoUpgrade.Shell.Strategies
{
    internal abstract class StartArgumentStrategy
    {
        public abstract string Build(string mainProcessName, ConnectionTypeEnum connectionType);
    }
}
