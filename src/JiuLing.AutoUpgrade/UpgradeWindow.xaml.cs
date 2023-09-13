using FirstFloor.ModernUI.Windows.Controls;
using JiuLing.AutoUpgrade.Common;
using JiuLing.AutoUpgrade.Templates;
using JiuLing.CommonLibs.ExtensionMethods;
using JiuLing.CommonLibs.Security;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace JiuLing.AutoUpgrade
{
    /// <summary>
    /// UpgradeWindow.xaml 的交互逻辑
    /// </summary>
    public partial class UpgradeWindow : ModernWindow
    {
        public UpgradeWindow()
        {
            InitializeComponent();
        }

        private void ModernWindow_Loaded(object sender, RoutedEventArgs e)
        {
            TxtTitle.Text = UpgradeInfo.MainProcess.Title;

            LblCurrentVersion.Text = UpgradeInfo.MainAppVersion;
            LblVersion.Text = UpgradeInfo.AppNewVersion.Version;

            LblSize.Text = !UpgradeInfo.AppNewVersion.FileLength.HasValue ? "-" : $"{(decimal)UpgradeInfo.AppNewVersion.FileLength.Value / 1024 / 1024:N2} MB";
            LblTime.Text = !UpgradeInfo.AppNewVersion.CreateTime.HasValue ? "-" : UpgradeInfo.AppNewVersion.CreateTime.Value.ToString("yyyy-MM-dd");

            var log = UpgradeInfo.AppNewVersion.Log.Trim();
            if (log.IsEmpty())
            {
                log = "无";
            }
            TxtLog.Text = log;
            TxtWarn.Visibility = UpgradeInfo.MainProcess.AllowRun ? Visibility.Hidden : Visibility.Visible;
        }

        private void ModernWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ModernWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (UpgradeInfo.MainProcess?.AllowRun == false)
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

        private async void BtnUpgrade_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BtnUpgrade.IsEnabled = false;
                PanelUpdateDetail.Visibility = Visibility.Hidden;
                PanelDoUpdate.Visibility = Visibility.Visible;

                var process = new Progress<float>((percent) =>
                {
                    ProgressBarPercent.Value = percent;
                    TxtPercent.Text = $"正在更新 {percent * 100:f1} %";
                });

                await UpgradeTemplateFactory.Create(UpgradeInfo.UpgradeConfig)
                    .Update(UpgradeInfo.AppNewVersion.DownloadUrl, GlobalArgs.MainAppPath, GlobalArgs.TempPackagePath, GlobalArgs.TempZipDirectory,
                        () =>
                        {
                            if (UpgradeInfo.UpgradeSetting.IsCheckSign)
                            {
                                string fileSign;
                                switch (UpgradeInfo.AppNewVersion.SignType.ToLower())
                                {
                                    case "md5":
                                        fileSign = MD5Utils.GetFileValueToLower(GlobalArgs.TempPackagePath);
                                        break;
                                    case "sha1":
                                        fileSign = SHA1Utils.GetFileValueToLower(GlobalArgs.TempPackagePath);
                                        break;
                                    default:
                                        throw new Exception("文件校验不通过。");
                                }

                                if (UpgradeInfo.AppNewVersion.SignValue?.ToLower() != fileSign)
                                {
                                    throw new Exception("文件校验失败。");
                                }
                            }
                            KillMainApp();
                        }, process);

                Application.Current.Shutdown();
                RunMainApp();

            }
            catch (Exception ex)
            {
                ShowFinalMessage($"更新失败，{ex.Message}");
            }
        }

        private void KillMainApp()
        {
            foreach (var process in Process.GetProcesses())
            {
                if (process.Id == UpgradeInfo.MainProcess.Id)
                {
                    process.Kill();
                    break;
                }
            }
        }
        private void RunMainApp()
        {
            Process.Start(UpgradeInfo.MainProcess.FileName);
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ShowFinalMessage(string message)
        {
            PanelUpdateDetail.Visibility = Visibility.Hidden;
            PanelDoUpdate.Visibility = Visibility.Hidden;
            PanelMessage.Visibility = Visibility.Visible;
            TxtMessage.Text = message;
        }
    }
}
