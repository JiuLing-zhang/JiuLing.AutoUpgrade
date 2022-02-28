using System;
using System.Diagnostics;
using System.IO;
using JiuLing.AutoUpgrade.Shell.Enums;
using JiuLing.AutoUpgrade.Shell.Strategies;

namespace JiuLing.AutoUpgrade.Shell
{
    /// <summary>
    /// 自动更新组件服务
    /// </summary>
    public class App
    {
        /// <summary>
        /// 核心程序的释放路径
        /// </summary>
        private readonly string _coreAppDirectory;
        /// <summary>
        /// 核心程序的文件名（含路径）
        /// </summary>
        private readonly string _coreAppFullFileName;

        private NetworkTypeEnum _networkType;
        /// <summary>
        /// 初始化组件
        /// </summary>
        public App()
        {
            _coreAppDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "JiuLing.AutoUpgrade.Core.Temp");
            _coreAppFullFileName = Path.Combine(_coreAppDirectory, "JiuLing.AutoUpgrade.exe");
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

        private readonly UpgradeSetting _upgradeSetting = new UpgradeSetting();
        /// <summary>
        /// 配置更新时的一些设置
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public App SetUpgrade(Action<UpgradeSetting> config)
        {
            config?.Invoke(_upgradeSetting);
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
            startArguments = $"{startArguments}{GetSettingArgument()} ";
            startArguments = startArguments.Trim();

            ReleaseAutoUpgradeFiles();

            var process = new Process();
            process.StartInfo.FileName = _coreAppFullFileName;
            process.StartInfo.Arguments = startArguments;
            process.Start();
            process.WaitForExit();

            DeleteMainApplication();
        }

        /// <summary>
        /// 主进程参数
        /// </summary>
        /// <returns></returns>
        private string GetProcessArgument()
        {
            return $"-{ArgumentTypeEnum.p} {Process.GetCurrentProcess().ProcessName}";
        }

        /// <summary>
        /// 网络参数
        /// </summary>
        /// <returns></returns>
        private string GetNetworkArgument()
        {
            switch (_networkType)
            {
                case NetworkTypeEnum.Http:
                    return new NetworkArgumentContext(new NetworkHttpStrategy(_upgradeUrl)).GetStartArguments(_networkType);
                case NetworkTypeEnum.Ftp:
                    return new NetworkArgumentContext(new NetworkFtpStrategy(_userName, _password, _upgradePath)).GetStartArguments(_networkType);
                default:
                    throw new ArgumentException("不支持的网络参数");
            }
        }

        /// <summary>
        /// 获取设置参数
        /// </summary>
        /// <returns></returns>
        private string GetSettingArgument()
        {

            string noticesArgument = "";
            if (_upgradeSetting.IsBackgroundCheck)
            {
                noticesArgument = $"-{ArgumentTypeEnum.background} ";
            }

            if (_upgradeSetting.IsCheckSign)
            {
                noticesArgument = $"{noticesArgument}-{ArgumentTypeEnum.check} ";
            }
            return noticesArgument;
        }

        private void ReleaseAutoUpgradeFiles()
        {
            if (!Directory.Exists(_coreAppDirectory))
            {
                Directory.CreateDirectory(_coreAppDirectory);
            }
            File.WriteAllBytes(_coreAppFullFileName, Resource.AutoUpgrade_exe);
        }

        private void DeleteMainApplication()
        {
            Directory.Delete(_coreAppDirectory, true);
        }
    }
}