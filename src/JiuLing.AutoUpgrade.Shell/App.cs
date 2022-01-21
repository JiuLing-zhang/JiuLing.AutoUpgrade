using System.Diagnostics;

namespace JiuLing.AutoUpgrade.Shell
{
    public class App
    {
        private static readonly string AppPath = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string AutoUpgradePath_exe = Path.Combine(AppPath, "JiuLing.AutoUpgrade.exe");
        private static readonly string AutoUpgradePath_dll = Path.Combine(AppPath, "JiuLing.AutoUpgrade.dll");
        private static readonly string AutoUpgradePath_pdb = Path.Combine(AppPath, "JiuLing.AutoUpgrade.pdb");
        private static readonly string AutoUpgradePath_runtime = Path.Combine(AppPath, "JiuLing.AutoUpgrade.runtimeconfig.json");

        public static void Run(string upgradeUrl)
        {
            ReleaseAutoUpgradeFiles();
            string mainProcessName = Process.GetCurrentProcess().ProcessName;
            var process = new Process();
            process.StartInfo.FileName = AutoUpgradePath_exe;
            process.StartInfo.Arguments = $"{mainProcessName} {upgradeUrl}";
            process.Start();
        }

        private static void ReleaseAutoUpgradeFiles()
        {
            File.WriteAllBytes(AutoUpgradePath_exe, Resource.AutoUpgrade_exe);
            File.WriteAllBytes(AutoUpgradePath_dll, Resource.AutoUpgrade_dll);
            File.WriteAllBytes(AutoUpgradePath_pdb, Resource.AutoUpgrade_pdb);
            File.WriteAllBytes(AutoUpgradePath_runtime, Resource.AutoUpgrade_runtime);
        }
    }
}