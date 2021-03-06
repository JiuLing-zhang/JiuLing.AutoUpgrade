using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using JiuLing.AutoUpgrade.CommandArgs;
using JiuLing.AutoUpgrade.Common;
using JiuLing.AutoUpgrade.Enums;
using JiuLing.AutoUpgrade.Models;
using JiuLing.AutoUpgrade.Security;
using JiuLing.AutoUpgrade.Strategies;
using JiuLing.AutoUpgrade.Templates;

namespace JiuLing.AutoUpgrade
{
    public partial class FmMain : Form
    {
        private readonly FmLoading _fmLoading = new FmLoading();
        /// <summary>
        /// 自动更新的配置信息
        /// </summary>
        private UpgradeConfigInfo _upgradeConfig;
        /// <summary>
        /// 主进程信息（待更新的程序进程）
        /// </summary>
        private ProcessInfo _mainProcess;
        /// <summary>
        /// 主进程版本
        /// </summary>
        private string _mainAppVersion = "";
        /// <summary>
        /// 新版本更新信息
        /// </summary>
        private AppVersionInfo _appNewVersion;

        /// <summary>
        /// 配置更新时的一些设置
        /// </summary>
        private readonly UpgradeSetting _upgradeSetting = new UpgradeSetting();
        public FmMain()
        {
            InitializeComponent();
        }

        private async void FmMain_Load(object sender, EventArgs e)
        {
            try
            {
                HideWindow();

                _upgradeConfig = ReadUpgradeConfigFromCommandArgs();
                _mainProcess = AppUtils.GetMainProcess(_upgradeConfig.MainProcessName);

                string windowTitle = $"{_mainProcess.Title} - 自动更新";
                this.Text = windowTitle;
                MessageUtils.SetWindowTitle(windowTitle);

                _mainAppVersion = AppUtils.GetMainAppVersion(_mainProcess);
                if (!_upgradeSetting.IsBackgroundCheck)
                {
                    _fmLoading.ShowLoading();
                    _fmLoading.SetMessage("正在检查更新");
                }

                var upgradeStrategy = UpgradeStrategyFactory.Create(_upgradeConfig);
                _appNewVersion = await new UpgradeStrategyContext(upgradeStrategy).GetUpgradeInfo();

                bool isNeedUpdate;
                (isNeedUpdate, _mainProcess.AllowRun) = VersionUtils.CheckNeedUpdate(_appNewVersion, _mainAppVersion);
                if (isNeedUpdate == false)
                {
                    _fmLoading.HideLoading();
                    if (!_upgradeSetting.IsBackgroundCheck)
                    {
                        MessageUtils.ShowInfo("当前版本为最新版");
                    }
                    Application.Exit();
                    return;
                }

                _fmLoading.HideLoading();

                BindingUi();
                ShowWindow();

            }
            catch (Exception ex)
            {
                if (!_upgradeSetting.IsBackgroundCheck)
                {
                    MessageUtils.ShowError($"更新失败，{ex.Message}");
                }
                Application.Exit();
            }
        }

        /// <summary>
        /// 解析本次的更新方式
        /// </summary>
        /// <returns></returns>
        private UpgradeConfigInfo ReadUpgradeConfigFromCommandArgs()
        {

            /******************参数说明*********************
            * -p MainProcess
              设置主进程,[MainProcess:主进程名称]

            * -http UpgradeUrl
              使用 HTTP 方式更新,[UpgradeUrl:更新地址]

            * -ftp UpgradeUrl UserName pwd
              使用 FTP 方式更新,[UpgradeUrl:更新地址] [UserName:用户名] [pwd:密码]
            
            * -s IsBackgroundCheck
              常规设置,[IsBackgroundCheck:是否在后台进行更新检查]
            **********************************************/

            var upgradeConfig = new UpgradeConfigInfo();
            ArgumentUtils.Initialize(string.Join(" ", Environment.GetCommandLineArgs()));
            if (!ArgumentUtils.TryGetCommandValue($"-{ArgumentTypeEnum.p}", out List<string> mainProcessArgs))
            {
                throw new ArgumentException("缺少主进程参数");
            }
            upgradeConfig.MainProcessName = mainProcessArgs[0];

            if (ArgumentUtils.HasCommand($"-{ArgumentTypeEnum.background}"))
            {
                _upgradeSetting.IsBackgroundCheck = true;
            }

            if (ArgumentUtils.HasCommand($"-{ArgumentTypeEnum.check}"))
            {
                _upgradeSetting.IsCheckSign = true;
            }

            if (ArgumentUtils.TryGetCommandValue($"-{ArgumentTypeEnum.http}", out List<string> httpArgs))
            {
                upgradeConfig.UpgradeMode = UpgradeModeEnum.Http;
                try
                {
                    upgradeConfig.ConnectionConfig = new HttpConnectionConfig()
                    {
                        UpgradeUrl = httpArgs[0]
                    };
                    return upgradeConfig;
                }
                catch (Exception)
                {
                    throw new ArgumentException("Http参数配置异常");
                }
            }

            if (ArgumentUtils.TryGetCommandValue($"-{ArgumentTypeEnum.ftp}", out List<string> ftpArgs))
            {
                upgradeConfig.UpgradeMode = UpgradeModeEnum.Ftp;
                try
                {
                    upgradeConfig.ConnectionConfig = new FtpConnectionConfig()
                    {
                        UpgradePath = ftpArgs[0],
                        UserName = ftpArgs[1],
                        Password = ftpArgs[2]
                    };
                    return upgradeConfig;
                }
                catch (Exception)
                {
                    throw new ArgumentException("Ftp参数配置异常");
                }
            }

            throw new ArgumentException("不支持的更新方式");
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

        private void BindingUi()
        {
            LblCurrentVersion.Text = _mainAppVersion;
            LblNewVersion.Text = _appNewVersion.Version;
            TxtLog.Text = _appNewVersion.Log;
            if (!_mainProcess.AllowRun)
            {
                LblVersionOverdue.Visible = true;
                BtnCancel.Visible = false;
            }
        }

        private async void BtnUpgrade_Click(object sender, EventArgs e)
        {
            try
            {
                BtnUpgrade.Enabled = false;

                _fmLoading.ShowLoading();
                _fmLoading.SetMessage("准备下载");
                var process = new Progress<float>((percent) =>
                {
                    _fmLoading.SetMessage($"正在下载：{(percent * 100):f2}%");
                });

                await UpgradeTemplateFactory.Create(_upgradeConfig)
                    .Update(_appNewVersion.DownloadUrl, GlobalArgs.MainAppPath, GlobalArgs.TempPackagePath, GlobalArgs.TempZipDirectory,
                        () =>
                        {
                            if (_upgradeSetting.IsCheckSign)
                            {
                                string fileSign = "";
                                switch (_appNewVersion.SignType)
                                {
                                    case SignTypeEnum.MD5:
                                        fileSign = MD5Utils.GetFileValueToLower(GlobalArgs.TempPackagePath);
                                        break;
                                    case SignTypeEnum.SHA1:
                                        fileSign = SHA1Utils.GetFileValueToLower(GlobalArgs.TempPackagePath);
                                        break;
                                    default:
                                        throw new Exception("文件校验不通过。");
                                }

                                if (_appNewVersion.SignValue?.ToLower() != fileSign)
                                {
                                    throw new Exception("文件校验失败。");
                                }
                            }
                            KillMainApp();
                        }, process);

                MessageUtils.ShowInfo("更新完成");
                Application.Exit();
                RunMainApp();

            }
            catch (Exception ex)
            {
                _fmLoading.HideLoading();
                MessageUtils.ShowError($"更新失败：{ex.Message}");
                BtnUpgrade.Enabled = true;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (_mainProcess.AllowRun == false)
                {
                    KillMainApp();
                }
            }
            catch (Exception)
            {
                //出现异常时不能终止程序退出，所以
                //TODO 这里可以考虑记录日志？
            }
        }

        private void KillMainApp()
        {
            foreach (var process in Process.GetProcesses())
            {
                if (process.Id == _mainProcess.Id)
                {
                    process.Kill();
                    break;
                }
            }
        }
        private void RunMainApp()
        {
            Process.Start(_mainProcess.FileName);
        }
    }
}