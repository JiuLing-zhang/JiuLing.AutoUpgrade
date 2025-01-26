using System.Threading.Tasks;
using JiuLing.CommonLibs.Model;

namespace JiuLing.AutoUpgrade.Updater
{
    internal abstract class UpdateStrategyBase
    {
        public abstract Task<AppUpgradeInfo> GetUpgradeInfo();
    }
}
