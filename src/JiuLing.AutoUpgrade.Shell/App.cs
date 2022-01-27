using System.Diagnostics;
using JiuLing.AutoUpgrade.Shell.Enums;
using JiuLing.AutoUpgrade.Shell.Strategies;

namespace JiuLing.AutoUpgrade.Shell
{
    /// <summary>
    /// 自动更新组件服务
    /// </summary>
    public class App
    {
        private readonly string _appPath = AppDomain.CurrentDomain.BaseDirectory;
        private readonly string _autoUpgradePathExe;
        private readonly string _autoUpgradePathDll;
        private readonly string _autoUpgradePathPdb;
        private readonly string _autoUpgradePathRuntime;

        private ConnectionTypeEnum _connectionType;
        /// <summary>
        /// 初始化组件
        /// </summary>
        public App()
        {
            _autoUpgradePathExe = Path.Combine(_appPath, "JiuLing.AutoUpgrade.exe");
            _autoUpgradePathDll = Path.Combine(_appPath, "JiuLing.AutoUpgrade.dll");
            _autoUpgradePathPdb = Path.Combine(_appPath, "JiuLing.AutoUpgrade.pdb");
            _autoUpgradePathRuntime = Path.Combine(_appPath, "JiuLing.AutoUpgrade.runtimeconfig.json");
        }

        private string _upgradeUrl = "";
        /// <summary>
        /// 使用Http方式更新
        /// </summary>
        /// <param name="upgradeUrl">更新信息接口</param>
        /// <returns></returns>
        public App UseHttpMode(string upgradeUrl)
        {
            _connectionType = ConnectionTypeEnum.Http;
            _upgradeUrl = upgradeUrl;
            return this;
        }

        private string _userName = "";
        private string _password = "";
        private string _upgradePath = "";

        /// <summary>
        /// 使用Ftp方式更新
        /// </summary>
        /// <param name="userName">Ftp用户名</param>
        /// <param name="password">Ftp密码</param>
        /// <param name="upgradePath">更新文件地址</param>
        /// <returns></returns>
        public App UseFtpMode(string userName, string password, string upgradePath)
        {
            _connectionType = ConnectionTypeEnum.Ftp;
            _userName = userName;
            _password = password;
            _upgradePath = upgradePath;
            return this;
        }

        /// <summary>
        /// 启动更新
        /// </summary>
        public void Run()
        {
            string mainProcessName = Process.GetCurrentProcess().ProcessName;
            string startArguments;
            switch (_connectionType)
            {
                case ConnectionTypeEnum.Http:
                    if (string.IsNullOrEmpty(_upgradeUrl))
                    {
                        throw new ArgumentException("自动更新地址未配置");
                    }

                    startArguments = new StartArgumentContext(new StartArgumentHttp(_upgradeUrl)).GetStartArguments(mainProcessName, _connectionType);
                    break;
                case ConnectionTypeEnum.Ftp:

                    if (string.IsNullOrEmpty(_userName))
                    {
                        throw new ArgumentException("FTP用户名未配置");
                    }
                    if (string.IsNullOrEmpty(_password))
                    {
                        throw new ArgumentException("FTP密码未配置");
                    }
                    if (string.IsNullOrEmpty(_upgradePath))
                    {
                        throw new ArgumentException("FTP更新地址未配置");
                    }
                    startArguments = new StartArgumentContext(new StartArgumentFtp(_userName, _password, _upgradePath)).GetStartArguments(mainProcessName, _connectionType);
                    break;
                default:
                    throw new ArgumentException("更新方式未配置");
            }

            ReleaseAutoUpgradeFiles();

            var process = new Process();
            process.StartInfo.FileName = _autoUpgradePathExe;
            process.StartInfo.Arguments = startArguments;
            process.Start();
        }

        private void ReleaseAutoUpgradeFiles()
        {
            File.WriteAllBytes(_autoUpgradePathExe, Resource.AutoUpgrade_exe);
            File.WriteAllBytes(_autoUpgradePathDll, Resource.AutoUpgrade_dll);
            File.WriteAllBytes(_autoUpgradePathPdb, Resource.AutoUpgrade_pdb);
            File.WriteAllBytes(_autoUpgradePathRuntime, Resource.AutoUpgrade_runtime);
        }
    }
}