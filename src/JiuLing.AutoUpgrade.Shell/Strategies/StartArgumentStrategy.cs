using JiuLing.AutoUpgrade.Shell.Enums;

namespace JiuLing.AutoUpgrade.Shell.Strategies
{
    internal abstract class NetworkStrategy
    {
        //TODO 重命名文件
        public abstract string Build(NetworkTypeEnum networkType);
    }
}
