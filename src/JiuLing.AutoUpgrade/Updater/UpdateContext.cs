using System.Threading.Tasks;
using JiuLing.CommonLibs.Model;

namespace JiuLing.AutoUpgrade.Updater
{
    internal class UpdateContext
    {
        private readonly UpdateStrategyBase _strategy;
        public UpdateContext(UpdateStrategyBase strategy)
        {
            _strategy = strategy;
        }

        public Task<AppUpgradeInfo> GetUpgradeInfo()
        {
            return _strategy.GetUpgradeInfo();
        }
    }
}
