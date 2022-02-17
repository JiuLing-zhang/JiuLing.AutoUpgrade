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


        private readonly string _mainAppTempDirectory;
        private readonly string _autoUpgradePathExe;
        private readonly string _newtonsoftJsonPath;
        private readonly string _compressionZipFilePath;

        private NetworkTypeEnum _networkType;
        /// <summary>
        /// 初始化组件
        /// </summary>
        public App()
        {
            _mainAppTempDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "JiuLing.AutoUpgrade.main.temp");
            if (!Directory.Exists(_mainAppTempDirectory))
            {
                Directory.CreateDirectory(_mainAppTempDirectory);
            }
            _autoUpgradePathExe = Path.Combine(_mainAppTempDirectory, "JiuLing.AutoUpgrade.exe");
            _newtonsoftJsonPath = Path.Combine(_mainAppTempDirectory, "Newtonsoft.Json.dll");
            _compressionZipFilePath = Path.Combine(_mainAppTempDirectory, "System.IO.Compression.ZipFile");
        }

        private string _upgradeUrl = "";
        /// <summary>
        /// 使用Http方式更新
        /// </summary>
        /// <param name="upgradeUrl">更新信息接口</param>
        /// <returns></returns>
        public App UseHttpMode(string upgradeUrl)
        {
            if (string.IsNullOrEmpty(upgradeUrl))
            {
                throw new ArgumentException("自动更新地址未配置");
            }

            _networkType = NetworkTypeEnum.Http;
            _upgradeUrl = upgradeUrl;
            return this;
        }

        private string _userName = "";
        private string _password = "";
        private string _upgradePath = "";

        /// <summary>
        /// 使用Ftp方式更新
        /// </summary>
        /// <param name="upgradePath">更新文件地址</param>
        /// <param name="userName">Ftp用户名</param>
        /// <param name="password">Ftp密码</param>
        /// <returns></returns>
        public App UseFtpMode(string upgradePath, string userName, string password)
        {
            if (string.IsNullOrEmpty(upgradePath))
            {
                throw new ArgumentException("FTP更新地址未配置");
            }
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentException("FTP用户名未配置");
            }
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("FTP密码未配置");
            }

            _networkType = NetworkTypeEnum.Ftp;
            _upgradePath = upgradePath;
            _userName = userName;
            _password = password;
            return this;
        }

        /// <summary>
        /// 启动更新
        /// </summary>
        public void Run()
        {
            string startArguments = "";
            startArguments = $"{startArguments}{GetProcessArgument()} ";
            startArguments = $"{startArguments}{GetNetworkArgument()} ";
            startArguments = startArguments.Trim();

            ReleaseAutoUpgradeFiles();

            var process = new Process();
            process.StartInfo.FileName = _autoUpgradePathExe;
            process.StartInfo.Arguments = startArguments;
            process.Start();
            process.WaitForExit();

            DeleteMainApplication();
        }

        /// <summary>
        /// 主进程参数
        /// </summary>
        /// <returns></returns>
        private static string GetProcessArgument()
        {
            return $"-p {Process.GetCurrentProcess().ProcessName}";
        }

        /// <summary>
        /// 网络参数
        /// </summary>
        /// <returns></returns>
        private string GetNetworkArgument()
        {
            return _networkType switch
            {
                NetworkTypeEnum.Http => new NetworkArgumentContext(new NetworkHttpStrategy(_upgradeUrl)).GetStartArguments(_networkType),
                NetworkTypeEnum.Ftp => new NetworkArgumentContext(new NetworkFtpStrategy(_userName, _password, _upgradePath)).GetStartArguments(_networkType),
                _ => throw new ArgumentException("不支持的网络参数")
            };
        }
        private void ReleaseAutoUpgradeFiles()
        {
            File.WriteAllBytes(_autoUpgradePathExe, Resource.AutoUpgrade_exe);
            File.WriteAllBytes(_newtonsoftJsonPath, Resource.Newtonsoft_Json);
            File.WriteAllBytes(_compressionZipFilePath, Resource.System_IO_Compression_ZipFile);
        }

        private void DeleteMainApplication()
        {
            Directory.Delete(_mainAppTempDirectory, true);
        }
    }
}