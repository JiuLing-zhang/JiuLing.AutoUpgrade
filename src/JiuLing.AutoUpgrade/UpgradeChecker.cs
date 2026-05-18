using JiuLing.AutoUpgrade.Common;
using JiuLing.CommonLibs;
using JiuLing.CommonLibs.ExtensionMethods;
using System.Threading.Tasks;
using JiuLing.AutoUpgrade.Models;
using JiuLing.AutoUpgrade.Updater;

namespace JiuLing.AutoUpgrade
{
    internal static class UpgradeChecker
    {
        public static async Task DoAsync()
        {
            var upgradeStrategy = UpdateStrategyFactory.Create(UpgradeInfo.TargetAppUpgradeInfo);
            UpgradeInfo.AppNewVersion = await new UpdateContext(upgradeStrategy).GetUpgradeInfo();

            var versionKey = UpgradeInfo.AppNewVersion.SignValue.IsEmpty() ? UpgradeInfo.TargetAppUpgradeInfo.Title : UpgradeInfo.AppNewVersion.SignValue;
            var versionSkipChecker = new VersionSkipChecker(versionKey, UpgradeInfo.AppNewVersion.Version);
            if (versionSkipChecker.CheckSkip())
            {
                UpgradeInfo.AllowRun = true;
                UpgradeInfo.IsNeedUpdate = false;
                return;
            }

            if (UpgradeInfo.AppNewVersion.MinVersion.IsEmpty())
            {
                UpgradeInfo.AllowRun = true;
                UpgradeInfo.IsNeedUpdate = VersionUtils.CheckNeedUpdate(UpgradeInfo.TargetAppUpgradeInfo.VersionRaw, UpgradeInfo.AppNewVersion.Version);
            }
            else
            {
                (UpgradeInfo.IsNeedUpdate, UpgradeInfo.AllowRun) = VersionUtils.CheckNeedUpdate(UpgradeInfo.TargetAppUpgradeInfo.VersionRaw, UpgradeInfo.AppNewVersion.Version, UpgradeInfo.AppNewVersion.MinVersion);
            }
        }
    }
}
