﻿using System.Threading.Tasks;
using JiuLing.CommonLibs.Model;

namespace JiuLing.AutoUpgrade.Strategies
{
    internal abstract class UpgradeStrategy
    {
        public abstract Task<AppUpgradeInfo> GetUpgradeInfo();
    }
}
