using JiuLing.AutoUpgrade.Models;

namespace JiuLing.AutoUpgrade.Strategies
{
    internal abstract class UpgradeStrategy
    {
        public abstract Task<AppUpgradeInfo> GetUpgradeInfo();
    }
}
