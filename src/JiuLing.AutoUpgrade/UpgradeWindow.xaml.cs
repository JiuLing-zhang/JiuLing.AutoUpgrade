using JiuLing.AutoUpgrade.Common;
using JiuLing.CommonLibs.ExtensionMethods;
using JiuLing.CommonLibs.Security;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using JiuLing.AutoUpgrade.Downloader;
using JiuLing.AutoUpgrade.Models;

namespace JiuLing.AutoUpgrade
{
    /// <summary>
    /// UpgradeWindow.xaml 的交互逻辑
    /// </summary>
    public partial class UpgradeWindow : Window
    {
        public UpgradeWindow()
        {
            InitializeComponent();
            if (UpgradeInfo.TargetAppUpgradeInfo.Icon != null)
            {
                this.Icon = UpgradeInfo.TargetAppUpgradeInfo.Icon;
            }
        }

        private void UpgradeWindow_Loaded(object sender, RoutedEventArgs e)
        {
            TxtTitle.Text = $"{UpgradeInfo.TargetAppUpgradeInfo.Title}";

            LblCurrentVersion.Text = UpgradeInfo.TargetAppUpgradeInfo.Version.ToFormatString(UpgradeInfo.TargetAppUpgradeInfo.VersionFormat);
            var version = new Version(UpgradeInfo.AppNewVersion.Version);
            LblVersion.Text = version.ToFormatString(UpgradeInfo.TargetAppUpgradeInfo.VersionFormat);

            LblSize.Text = !UpgradeInfo.AppNewVersion.FileLength.HasValue ? "-" : $"{(decimal)UpgradeInfo.AppNewVersion.FileLength.Value / 1024 / 1024:N2} MB";
            LblTime.Text = !UpgradeInfo.AppNewVersion.CreateTime.HasValue ? "-" : UpgradeInfo.AppNewVersion.CreateTime.Value.ToString("yyyy-MM-dd");

            var log = UpgradeInfo.AppNewVersion.Log.Trim();
            if (log.IsEmpty())
            {
                log = AutoUpgrade.Properties.Resources.Nothing;
            }
            TxtLog.Text = log;
            if (UpgradeInfo.AllowRun)
            {
                TxtWarn.Visibility = Visibility.Collapsed;
            }
            else
            {
                TxtWarn.Visibility = Visibility.Visible;
                BtnSkip.Visibility = Visibility.Collapsed;
                BtnCancel.Visibility = Visibility.Collapsed;
            }
        }

        private void UpgradeWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void UpgradeWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (UpgradeInfo.AllowRun == false)
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
        private void BtnSkip_Click(object sender, RoutedEventArgs e)
        {
            // TODO：考虑使用应用 hash 来充当唯一条件，避免重名版本被跳过
            var versionSkipChecker = new VersionSkipChecker(UpgradeInfo.TargetAppUpgradeInfo.Title, UpgradeInfo.AppNewVersion.Version);
            versionSkipChecker.SetSkip();
            Application.Current.Shutdown();
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
                    TxtPercent.Text = $"{AutoUpgrade.Properties.Resources.Updating} {percent * 100:f1} %";
                });

                ((IProgress<float>)process).Report(0f);

                var targetAppDic = Path.GetDirectoryName(UpgradeInfo.TargetAppUpgradeInfo.FullPath);
                await DownloaderFactory.Create(UpgradeInfo.TargetAppUpgradeInfo)
                    .Update(UpgradeInfo.AppNewVersion.DownloadUrl, targetAppDic, TempPaths.ZipFilePath, TempPaths.ExtractedDir,
                        () =>
                        {
                            if (UpgradeInfo.UpgradeSetting.IsCheckSign)
                            {
                                string fileSign;
                                switch (UpgradeInfo.AppNewVersion.SignType.ToLower())
                                {
                                    case "md5":
                                        fileSign = MD5Utils.GetFileValueToLower(TempPaths.ZipFilePath);
                                        break;
                                    case "sha1":
                                        fileSign = SHA1Utils.GetFileValueToLower(TempPaths.ZipFilePath);
                                        break;
                                    default:
                                        fileSign = "";
                                        break;
                                }

                                if (UpgradeInfo.AppNewVersion.SignValue?.ToLower() != fileSign)
                                {
                                    throw new Exception(AutoUpgrade.Properties.Resources.FileSignatureError);
                                }
                            }
                            KillMainApp();
                        }, process);

                Application.Current.Shutdown();
                RunMainApp();

            }
            catch (Exception ex)
            {
                ShowFinalMessage($"{AutoUpgrade.Properties.Resources.ExUpdateFailed}{ex.Message}");
            }
        }

        private void KillMainApp()
        {
            var processes = Process.GetProcesses()
                .Where(p =>
                {
                    try
                    {
                        return !p.HasExited && p.MainModule.FileName.Equals(UpgradeInfo.TargetAppUpgradeInfo.FullPath, StringComparison.OrdinalIgnoreCase);
                    }
                    catch
                    {
                        // 某些系统进程会拒绝访问 MainModule
                        return false;
                    }
                }).ToList();

            foreach (var process in processes)
            {
                try
                {
                    process.Kill();
                    process.WaitForExit();
                }
                catch (Exception ex)
                {
                    ShowFinalMessage($"{AutoUpgrade.Properties.Resources.ExUpdateFailed}{ex.Message}");
                }
            }
        }
        private void RunMainApp()
        {
            try
            {
                Process.Start(UpgradeInfo.TargetAppUpgradeInfo.FullPath);
            }
            catch (Exception ex)
            {
                ShowFinalMessage($"{AutoUpgrade.Properties.Resources.ExUpdateFailed}{ex.Message}");
            }
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
