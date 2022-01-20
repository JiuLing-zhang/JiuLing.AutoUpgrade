namespace AutoUpgrade
{
    /// <summary>
    /// 程序版本帮助类
    /// </summary>
    public class VersionUtils
    {
        /// <summary>
        /// 检查当前版本是否需要更新
        /// </summary>
        /// <param name="currentVersion">当前版本</param>
        /// <param name="newVersion">最新版本</param>
        /// <returns>返回是否需要更新</returns>
        public static bool CheckNeedUpdate(string currentVersion, string newVersion)
        {
            Version current = new Version(currentVersion);
            Version version = new Version(newVersion);
            return CheckNeedUpdate(current, version);
        }

        /// <summary>
        /// 检查当前版本是否需要更新
        /// </summary>
        /// <param name="currentVersion">当前版本</param>
        /// <param name="newVersion">最新版本</param>
        /// <returns>返回是否需要更新</returns>
        public static bool CheckNeedUpdate(Version currentVersion, Version newVersion)
        {
            return currentVersion.CompareTo(newVersion) < 0;
        }

        /// <summary>
        /// 检查当前版本是否需要更新
        /// </summary>
        /// <param name="currentVersion">当前版本</param>
        /// <param name="newVersion">最新版本</param>
        /// <param name="minVersion">最小运行版本</param>
        /// <returns>返回（是否需要自动更新，当前版本是否允许使用）</returns>
        public static (bool IsNeedUpdate, bool IsAllowUse) CheckNeedUpdate(string currentVersion, string newVersion, string minVersion)
        {
            Version current = new Version(currentVersion);
            Version version = new Version(newVersion);
            Version min = new Version(minVersion);
            return CheckNeedUpdate(current, version, min);
        }

        /// <summary>
        /// 检查当前版本是否需要更新
        /// </summary>
        /// <param name="currentVersion">当前版本</param>
        /// <param name="newVersion">最新版本</param>
        /// <param name="minVersion">最小运行版本</param>
        /// <returns>返回（是否需要自动更新，当前版本是否允许使用）</returns>
        public static (bool IsNeedUpdate, bool IsAllowUse) CheckNeedUpdate(Version currentVersion, Version newVersion, Version minVersion)
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
