using System.Diagnostics;
using JiuLing.AutoUpgrade.Common;
using JiuLing.AutoUpgrade.Enums;
using JiuLing.AutoUpgrade.Models;
using JiuLing.AutoUpgrade.Strategies;
using JiuLing.AutoUpgrade.Templates;

namespace JiuLing.AutoUpgrade
{
    public partial class FmMain : Form
    {
        private readonly FmLoading _fmLoading = new();
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
        private string _mainAppVersion;
        /// <summary>
        /// 新版本更新信息
        /// </summary>
        public AppUpgradeInfo _upgradeInfo;
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

                _mainAppVersion = AppUtils.GetMainAppVersion(_mainProcess);
                _fmLoading.ShowLoading();
                _fmLoading.SetMessage("正在检查更新");

                var upgradeStrategy = UpgradeStrategyFactory.Create(_upgradeConfig);
                _upgradeInfo = await new UpgradeStrategyContext(upgradeStrategy).GetUpgradeInfo();


                (bool isNeedUpdate, _mainProcess.AllowRun) = VersionUtils.CheckNeedUpdate(_upgradeInfo, _mainAppVersion);
                if (isNeedUpdate == false)
                {
                    _fmLoading.HideLoading();
                    MessageUtils.ShowInfo("当前版本为最新版");
                    Application.Exit();
                    return;
                }

                _fmLoading.HideLoading();

                BindingUi();
                ShowWindow();

            }
            catch (Exception ex)
            {
                MessageUtils.ShowError($"更新失败，{ex.Message}");
                Application.Exit();
            }
        }

        /// <summary>
        /// 解析本次的更新方式
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        private UpgradeConfigInfo ReadUpgradeConfigFromCommandArgs()
        {
            var upgradeConfig = new UpgradeConfigInfo();
            string[] cmdArgs = Environment.GetCommandLineArgs();
            if (cmdArgs.Length < 2)
            {
                throw new ArgumentException("启动参数不正确");
            }

            upgradeConfig.MainProcessName = cmdArgs[1];

            if (!Enum.TryParse(cmdArgs[2], out UpgradeModeEnum upgradeMode))
            {
                throw new ArgumentException("更新方式配置错误");
            }
            upgradeConfig.UpgradeMode = upgradeMode;

            switch (upgradeMode)
            {
                case UpgradeModeEnum.Http:
                    try
                    {
                        upgradeConfig.ConnectionConfig = new HttpConnectionConfig()
                        {
                            UpgradeUrl = cmdArgs[3]
                        };
                        return upgradeConfig;
                    }
                    catch (Exception)
                    {
                        throw new ArgumentException("Http参数配置异常");
                    }
                case UpgradeModeEnum.Ftp:
                    try
                    {
                        upgradeConfig.ConnectionConfig = new FtpConnectionConfig()
                        {
                            UserName = cmdArgs[3],
                            Password = cmdArgs[4],
                            UpgradePath = cmdArgs[5]
                        };
                        return upgradeConfig;
                    }
                    catch (Exception)
                    {
                        throw new ArgumentException("Ftp参数配置异常");
                    }
                default:
                    throw new ArgumentException("不支持的更新方式");
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

        private void BindingUi()
        {
            LblCurrentVersion.Text = _mainAppVersion;
            LblNewVersion.Text = _upgradeInfo.Version;
            TxtLog.Text = _upgradeInfo.Log;
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

                KillMainApp();
                _fmLoading.ShowLoading();
                _fmLoading.SetMessage("准备下载");
                var process =
                    new Progress<float>((percent) => { _fmLoading.SetMessage($"正在下载：{(percent * 100):f2}%"); });
                await UpgradeTemplateFactory.Create(_upgradeConfig)
                    .Update(GlobalArgs.AppPath, GlobalArgs.TempPackagePath, GlobalArgs.TempZipDirectory, process);

                MessageUtils.ShowInfo("更新完成");
                Application.Exit();
                RunMainApp();
            }
            catch (Exception ex)
            {
                MessageUtils.ShowError($"更新失败：{ex.Message}");
                BtnUpgrade.Enabled = true;
            }
            finally
            {
                _fmLoading.HideLoading();
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