using System.Diagnostics;
using System.IO.Compression;
using System.Text.Json;
using AutoUpgrade.Common;
using AutoUpgrade.ExtensionMethods;
using AutoUpgrade.Models;
using AutoUpgrade.Net;

namespace AutoUpgrade
{
    public partial class FmMain : Form
    {
        private readonly FmLoading _fmLoading = new();
        private readonly HttpClientHelper _clientHelper = new();
        public FmMain()
        {
            InitializeComponent();
        }

        private async void FmMain_Load(object sender, EventArgs e)
        {
            try
            {
                HideWindow();

                LoadingAppConfig();
                GetMainProcess();
                string currentVersion = GetMainAppVersion();
                _fmLoading.ShowLoading();
                _fmLoading.SetMessage("正在检查更新");
                GlobalArgs.UpgradeInfo = await GetAppUpgradeInfo();

                (bool isNeedUpdate, GlobalArgs.MainProcess.AllowRun) = CheckNeedUpdate(GlobalArgs.UpgradeInfo, currentVersion);
                if (isNeedUpdate == false)
                {
                    _fmLoading.HideLoading();
                    MessageUtils.ShowInfo("当前版本为最新版");
                    Application.Exit();
                    return;
                }

                _fmLoading.HideLoading();
                ShowWindow();
                BindingUi(currentVersion, GlobalArgs.UpgradeInfo);

            }
            catch (Exception ex)
            {
                MessageUtils.ShowError($"更新失败：{ex.Message}");
                Application.Exit();
            }
        }

        private void HideWindow()
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }

        private void ShowWindow()
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void BindingUi(string currentVersion, AppUpgradeInfo upgradeInfo)
        {
            LblCurrentVersion.Text = currentVersion;
            LblNewVersion.Text = upgradeInfo.Version;
            TxtLog.Text = upgradeInfo.Log;
            if (!GlobalArgs.MainProcess.AllowRun)
            {
                LblVersionOverdue.Visible = true;
                BtnCancel.Visible = false;
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
        /// 获取主程序的进程
        /// </summary>
        private void GetMainProcess()
        {
            Process[] process = Process.GetProcessesByName(GlobalArgs.AppConfig.MainProcessName);

            foreach (Process p in process)
            {
                string fileName = p.MainModule?.FileName ?? throw new ArgumentException("未找到主进程启动路径");
                string processDirectory = Path.GetDirectoryName(fileName) ?? throw new ArgumentException("未找到主进程启动目录");
                string? myDirectory = Path.GetDirectoryName(GlobalArgs.AppPath);

                if (myDirectory != processDirectory)
                {
                    throw new ApplicationException("主程序和自动更新程序不在同一目录");
                }

                GlobalArgs.MainProcess = new ProcessInfo()
                {
                    Id = p.Id,
                    FileName = fileName
                };
                return;
            }
            throw new ApplicationException($"未找到主进程{GlobalArgs.AppConfig.MainProcessName}");
        }

        /// <summary>
        /// 获取主程序版本
        /// </summary>
        private string GetMainAppVersion()
        {
            if (GlobalArgs.MainProcess == null)
            {
                throw new ApplicationException($"未找到主进程{GlobalArgs.AppConfig.MainProcessName}");
            }
            FileVersionInfo info = FileVersionInfo.GetVersionInfo(GlobalArgs.MainProcess.FileName);
            if (info.FileVersion == null)
            {
                throw new ArgumentException($"主程序版本号异常");
            }
            return info.FileVersion;
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
                    throw new Exception("服务器响应错误");
                }
                return upgradeInfo;
            }
            catch (Exception)
            {
                throw new Exception("服务器响应异常");
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
                var isNeedUpdate = VersionUtils.CheckNeedUpdate(currentVersion, upgradeInfo.Version);
                return (isNeedUpdate, true);
            }

            return VersionUtils.CheckNeedUpdate(currentVersion, upgradeInfo.Version, upgradeInfo.MinVersion);
        }

        private async void BtnUpgrade_Click(object sender, EventArgs e)
        {
            try
            {
                BtnUpgrade.Enabled = false;

                KillMainApp();
                await DownloadApp(GlobalArgs.UpgradeInfo.DownloadUrl, GlobalArgs.TempPackagePath);
                PublishZipFile(GlobalArgs.TempPackagePath, GlobalArgs.TempZipDirectory);
                CopyFiles(GlobalArgs.TempZipDirectory, GlobalArgs.AppPath);
                ClearFileCache();

                MessageUtils.ShowInfo("更新完成");
                Application.Exit();
                RunMainApp();
            }
            catch (Exception ex)
            {
                MessageUtils.ShowError($"更新失败：{ex.Message}");
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (GlobalArgs.MainProcess.AllowRun == false)
            {
                KillMainApp();
            }
        }

        private void KillMainApp()
        {
            try
            {
                Process process = Process.GetProcessById(GlobalArgs.MainProcess.Id);
                process.Kill();
            }
            catch (Exception)
            {
                MessageUtils.ShowError("主程序未被正确关闭");
            }
        }
        private void RunMainApp()
        {
            Process.Start(GlobalArgs.MainProcess.FileName);
        }
        private async Task DownloadApp(string url, string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            byte[] result;
            try
            {
                _fmLoading.ShowLoading();
                _fmLoading.SetMessage("准备下载");
                var process = new Progress<float>((percent) =>
                {
                    _fmLoading.SetMessage($"正在下载：{percent:f2}%");
                });
                result = await _clientHelper.GetFileByteArray(url, process);
            }
            catch (Exception)
            {
                throw new Exception("服务器响应异常");
            }
            finally
            {
                _fmLoading.HideLoading();
            }
            await File.WriteAllBytesAsync(filePath, result);
        }

        private void PublishZipFile(string filePath, string dstPath)
        {
            if (Directory.Exists(dstPath))
            {
                Directory.Delete(dstPath, true);
            }
            ZipFile.ExtractToDirectory(filePath, dstPath);
        }

        private void CopyFiles(string sourcePath, string destinationPath)
        {
            if (!Directory.Exists(destinationPath))
            {
                Directory.CreateDirectory(destinationPath);
            }

            var files = Directory.GetFiles(sourcePath);
            foreach (var file in files)
            {
                var fi = new FileInfo(file);
                File.Copy(file, Path.Combine(destinationPath, fi.Name), true);
            }

            var directories = Directory.GetDirectories(sourcePath);
            foreach (var directory in directories)
            {
                var di = new DirectoryInfo(directory);
                CopyFiles(directory, Path.Combine(destinationPath, di.Name));
            }
        }

        private void ClearFileCache()
        {
            File.Delete(GlobalArgs.TempPackagePath);
            Directory.Delete(GlobalArgs.TempZipDirectory, true);
        }
    }
}