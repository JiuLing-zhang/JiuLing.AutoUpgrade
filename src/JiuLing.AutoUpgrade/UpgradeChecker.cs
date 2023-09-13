using JiuLing.AutoUpgrade.Common;
using JiuLing.AutoUpgrade.Strategies;
using JiuLing.CommonLibs;
using JiuLing.CommonLibs.ExtensionMethods;
using System.Threading.Tasks;

namespace JiuLing.AutoUpgrade
{
    internal static class UpgradeChecker
    {
        public static async Task DoAsync()
        {
            UpgradeInfo.MainAppVersion = AppUtils.GetMainAppVersion(UpgradeInfo.MainProcess);

            var upgradeStrategy = UpgradeStrategyFactory.Create(UpgradeInfo.UpgradeConfig);
            UpgradeInfo.AppNewVersion = await new UpgradeStrategyContext(upgradeStrategy).GetUpgradeInfo();


            if (UpgradeInfo.AppNewVersion.MinVersion.IsEmpty())
            {
                UpgradeInfo.MainProcess.AllowRun = true;
                UpgradeInfo.IsNeedUpdate = VersionUtils.CheckNeedUpdate(UpgradeInfo.MainAppVersion, UpgradeInfo.AppNewVersion.Version);
            }
            else
            {
                (UpgradeInfo.IsNeedUpdate, UpgradeInfo.MainProcess.AllowRun) = VersionUtils.CheckNeedUpdate(UpgradeInfo.MainAppVersion, UpgradeInfo.AppNewVersion.Version, UpgradeInfo.AppNewVersion.MinVersion);
            }
        }
    }
}
