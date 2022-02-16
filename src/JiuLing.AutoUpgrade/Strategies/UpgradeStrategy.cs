using System.Threading.Tasks;
using JiuLing.AutoUpgrade.Models;

namespace JiuLing.AutoUpgrade.Strategies
{
    internal abstract class UpgradeStrategy
    {
        public abstract Task<AppVersionInfo> GetUpgradeInfo();
    }
}
