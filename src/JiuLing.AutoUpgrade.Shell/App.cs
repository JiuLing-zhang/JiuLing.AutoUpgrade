using System.Diagnostics;
using JiuLing.AutoUpgrade.Shell.Enums;

namespace JiuLing.AutoUpgrade.Shell
{
    public class App
    {
        private readonly string _appPath = AppDomain.CurrentDomain.BaseDirectory;
        private readonly string AutoUpgradePath_exe;
        private readonly string AutoUpgradePath_dll;
        private readonly string AutoUpgradePath_pdb;
        private readonly string AutoUpgradePath_runtime;

        private ConnectionTypeEnum _connectionType;
        private string _upgradeUrl = "";

        public App()
        {
            AutoUpgradePath_exe = Path.Combine(_appPath, "JiuLing.AutoUpgrade.exe");
            AutoUpgradePath_dll = Path.Combine(_appPath, "JiuLing.AutoUpgrade.dll");
            AutoUpgradePath_pdb = Path.Combine(_appPath, "JiuLing.AutoUpgrade.pdb");
            AutoUpgradePath_runtime = Path.Combine(_appPath, "JiuLing.AutoUpgrade.runtimeconfig.json");
        }
        /// <summary>
        /// 使用Http方式更新
        /// </summary>
        public App UseHttpMode(string upgradeUrl)
        {
            _connectionType = ConnectionTypeEnum.Http;
            _upgradeUrl = upgradeUrl;
            return this;
        }
        /// <summary>
        /// 启动更新
        /// </summary>
        public void Run()
        {
            if (string.IsNullOrEmpty(_upgradeUrl))
            {
                throw new ArgumentNullException("自动更新地址未配置");
            }
            ReleaseAutoUpgradeFiles();
            string mainProcessName = Process.GetCurrentProcess().ProcessName;
            var process = new Process();
            process.StartInfo.FileName = AutoUpgradePath_exe;
            process.StartInfo.Arguments = $"{mainProcessName} {_connectionType} {_upgradeUrl}";
            process.Start();
        }

        private void ReleaseAutoUpgradeFiles()
        {
            File.WriteAllBytes(AutoUpgradePath_exe, Resource.AutoUpgrade_exe);
            File.WriteAllBytes(AutoUpgradePath_dll, Resource.AutoUpgrade_dll);
            File.WriteAllBytes(AutoUpgradePath_pdb, Resource.AutoUpgrade_pdb);
            File.WriteAllBytes(AutoUpgradePath_runtime, Resource.AutoUpgrade_runtime);
        }
    }
}