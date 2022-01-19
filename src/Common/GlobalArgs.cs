using AutoUpgrade.Models;
using JiuLing.CommonLibs.Model;

namespace AutoUpgrade.Common
{
    internal class GlobalArgs
    {
        public static string AppPath = AppDomain.CurrentDomain.BaseDirectory;
        public static string AppConfigPath = Path.Combine(AppPath, "AutoUpgrade.config.json");
        /// <summary>
        /// 临时下载的更新包位置
        /// </summary>
        public static string TempPackagePath = Path.Combine(AppPath, "AutoUpgrade.temp.zip");

        public static AppConfigInfo AppConfig = new();
        /// <summary>
        /// 更新信息
        /// </summary>
        public static AppUpgradeInfo UpgradeInfo = new();
        /// <summary>
        /// 主进程信息（待更新的程序进程）
        /// </summary>
        public static ProcessInfo MainProcess;
    }
}
