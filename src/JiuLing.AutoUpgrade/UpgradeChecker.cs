using JiuLing.AutoUpgrade.Common;
using JiuLing.CommonLibs;
using JiuLing.CommonLibs.ExtensionMethods;
using System.Threading.Tasks;
using JiuLing.AutoUpgrade.Updater;

namespace JiuLing.AutoUpgrade
{
    internal static class UpgradeChecker
    {
        public static async Task DoAsync()
        {
            UpgradeInfo.MainAppVersion = AppUtils.GetMainAppVersion(UpgradeInfo.MainProcess);

            var upgradeStrategy = UpdateStrategyFactory.Create(UpgradeInfo.UpgradeConfig);
            UpgradeInfo.AppNewVersion = await new UpdateContext(upgradeStrategy).GetUpgradeInfo();

            var versionSkipChecker = new VersionSkipChecker(UpgradeInfo.UpgradeConfig.MainProcessName, UpgradeInfo.AppNewVersion.Version);
            if (versionSkipChecker.CheckSkip())
            {
                UpgradeInfo.MainProcess.AllowRun = true;
                UpgradeInfo.IsNeedUpdate = false;
                return;
            }

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
