﻿using JiuLing.AutoUpgrade.Models;

namespace JiuLing.AutoUpgrade.Strategies
{
    internal class UpgradeStrategyContext
    {
        private readonly UpgradeStrategy _strategy;
        public UpgradeStrategyContext(UpgradeStrategy strategy)
        {
            _strategy = strategy;
        }

        public Task<AppUpgradeInfo> GetUpgradeInfo()
        {
            return _strategy.GetUpgradeInfo();
        }
    }
}
