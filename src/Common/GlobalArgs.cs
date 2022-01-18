using AutoUpgrade.Models;

namespace AutoUpgrade.Common
{
    internal class GlobalArgs
    {
        public static string AppPath = AppDomain.CurrentDomain.BaseDirectory;
        public static string AppConfigPath = Path.Combine(AppPath, "AutoUpgrade.config.json");
        public static AppConfigInfo AppConfig = new();
    }
}
