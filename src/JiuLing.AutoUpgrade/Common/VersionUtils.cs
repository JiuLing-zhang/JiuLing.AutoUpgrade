using System;
using JiuLing.AutoUpgrade.Models;
using JiuLing.AutoUpgrade.ExtensionMethods;

namespace JiuLing.AutoUpgrade.Common
{
    /// <summary>
    /// 程序版本的工具类
    /// </summary>
    internal class VersionUtils
    {
        /// <summary>
        /// 检查是否需要更新
        /// </summary>
        public static (bool IsNeedUpdate, bool IsAllowUse) CheckNeedUpdate(AppVersionInfo appNewVersion, string currentVersion)
        {
            if (appNewVersion.MinVersion.IsEmpty())
            {
                //如果没有指定最小版本号，则认为当前版本可以使用
                var isNeedUpdate = CheckNeedUpdate(new Version(currentVersion), new Version(appNewVersion.Version));
                return (isNeedUpdate, true);
            }

            return CheckNeedUpdate(new Version(currentVersion), new Version(appNewVersion.Version), new Version(appNewVersion.MinVersion));
        }

        /// <summary>
        /// 检查当前版本是否需要更新
        /// </summary>
        /// <param name="currentVersion">当前版本</param>
        /// <param name="newVersion">最新版本</param>
        /// <returns>返回是否需要更新</returns>
        private static bool CheckNeedUpdate(Version currentVersion, Version newVersion)
        {
            return currentVersion.CompareTo(newVersion) < 0;
        }

        private static (bool IsNeedUpdate, bool IsAllowUse) CheckNeedUpdate(Version currentVersion, Version newVersion, Version minVersion)
        {
            if (!CheckNeedUpdate(currentVersion, newVersion))
            {
                return (false, true);
            }

            if (currentVersion.CompareTo(minVersion) < 0)
            {
                return (true, false);
            }

            return (true, true);
        }
    }
}
