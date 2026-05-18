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

            // TODO：考虑使用应用 hash 来充当唯一条件，避免重名版本被跳过
            var versionSkipChecker = new VersionSkipChecker(UpgradeInfo.TargetAppUpgradeInfo.Name, UpgradeInfo.AppNewVersion.Version);
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
