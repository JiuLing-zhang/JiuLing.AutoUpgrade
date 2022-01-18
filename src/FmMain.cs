using System.Diagnostics;
using System.Text.Json;
using AutoUpgrade.Common;
using AutoUpgrade.Models;
using JiuLing.CommonLibs.ExtensionMethods;
using JiuLing.CommonLibs.Model;
using JiuLing.CommonLibs.Net;

namespace AutoUpgrade
{
    public partial class FmMain : Form
    {
        private readonly HttpClientHelper _clientHelper = new();
        /// <summary>
        /// 是否运行主程序运行（初始化为true，防止更新程序出现异常关闭时将主程序误杀）
        /// </summary>
        private bool _isAllowMainAppRun = true;
        public FmMain()
        {
            InitializeComponent();
        }

        private async void FmMain_Load(object sender, EventArgs e)
        {
            try
            {
                LoadingAppConfig();
                string currentVersion = GetMainAppVersion();
                var upgradeInfo = await GetAppUpgradeInfo();
                (bool isNeedUpdate, _isAllowMainAppRun) = CheckNeedUpdate(upgradeInfo, currentVersion);
                if (isNeedUpdate == false)
                {
                    MessageHelper.ShowInfo("当前版本为最新版");
                    Application.Exit();
                }

                LblCurrentVersion.Text = currentVersion;
                LblNewVersion.Text = upgradeInfo.Version;
                TxtLog.Text = upgradeInfo.Log;
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"初始化失败：{ex.Message}");
                Application.Exit();
            }
        }

        /// <summary>
        /// 加载本地配置文件
        /// </summary>
        private void LoadingAppConfig()
        {
            if (!File.Exists(GlobalArgs.AppConfigPath))
            {
                throw new FileNotFoundException($"未找到配置文件{GlobalArgs.AppConfigPath}");
            }
            string configString = File.ReadAllText(GlobalArgs.AppConfigPath);
            try
            {
                GlobalArgs.AppConfig = JsonSerializer.Deserialize<AppConfigInfo>(configString) ?? throw new JsonException($"配置文件解析失败{GlobalArgs.AppConfigPath}");
            }
            catch (JsonException)
            {
                throw new JsonException($"配置文件格式错误{GlobalArgs.AppConfigPath}");
            }
        }
        /// <summary>
        /// 获取主程序版本
        /// </summary>
        private string GetMainAppVersion()
        {
            string mainAppPath = Path.Combine(GlobalArgs.AppPath, GlobalArgs.AppConfig.MainAppName);
            if (!File.Exists(mainAppPath))
            {
                throw new FileNotFoundException($"未找到主程序{GlobalArgs.AppConfigPath}");
            }
            FileVersionInfo info = FileVersionInfo.GetVersionInfo(mainAppPath);
            if (info.ProductVersion == null)
            {
                throw new ArgumentException($"主程序版本号异常");
            }
            return info.ProductVersion;
        }

        /// <summary>
        /// 获取自动更新信息
        /// </summary>
        private async Task<AppUpgradeInfo> GetAppUpgradeInfo()
        {
            try
            {
                var result = await _clientHelper.GetReadString(GlobalArgs.AppConfig.UpgradeUrl);
                var upgradeInfo = JsonSerializer.Deserialize<AppUpgradeInfo>(result);
                if (upgradeInfo == null)
                {
                    throw new Exception("自动更新信息解析失败");
                }
                return upgradeInfo;
            }
            catch (Exception)
            {
                throw new Exception("自动更新信息获取失败");
            }
        }
        /// <summary>
        /// 检查是否需要更新
        /// </summary>
        private (bool IsNeedUpdate, bool IsAllowUse) CheckNeedUpdate(AppUpgradeInfo upgradeInfo, string currentVersion)
        {
            if (upgradeInfo.MinVersion.IsEmpty())
            {
                //如果没有指定最小版本号，则认为当前版本可以使用
                var isNeedUpdate = JiuLing.CommonLibs.VersionUtils.CheckNeedUpdate(currentVersion, upgradeInfo.Version);
                return (isNeedUpdate, true);
            }

            return JiuLing.CommonLibs.VersionUtils.CheckNeedUpdate(currentVersion, upgradeInfo.Version, upgradeInfo.MinVersion);
        }

        private void BtnUpgrade_Click(object sender, EventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isAllowMainAppRun == false)
            {
                KillMainApp();
            }
        }

        private void KillMainApp()
        {
            Process[] process = Process.GetProcessesByName(GlobalArgs.AppConfig.MainAppName);
            foreach (Process p in process)
            {
                p.Kill();
            }
        }
    }
}