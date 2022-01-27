using JiuLing.AutoUpgrade.Models;

namespace JiuLing.AutoUpgrade.Common
{
    internal class GlobalArgs
    {
        public static string AppPath = AppDomain.CurrentDomain.BaseDirectory;
        public static string? AppVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version?.ToString();
        public const string AppName = "AutoUpgrade.exe";
        public const string DllName = "AutoUpgrade.dll";
        public static string AppConfigPath = Path.Combine(AppPath, "AutoUpgrade.config");
        /// <summary>
        /// 临时下载的更新包位置
        /// </summary>
        public static string TempPackagePath = Path.Combine(AppPath, "AutoUpgrade.temp.zip");

        /// <summary>
        /// 更新文件解压的路径
        /// </summary>
        public static string TempZipDirectory = Path.Combine(AppPath, "AutoUpgrade.temp");

        public static AppConfigInfo AppConfig = new();
    }
}
