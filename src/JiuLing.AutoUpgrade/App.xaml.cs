using FirstFloor.ModernUI.Presentation;
using JiuLing.AutoUpgrade.Enums;
using JiuLing.AutoUpgrade.Models;
using JiuLing.CommonLibs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using JiuLing.AutoUpgrade.Common;
using JiuLing.AutoUpgrade.Shared;
using Microsoft.Win32;

namespace JiuLing.AutoUpgrade
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private ThemeEnum _theme;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            try
            {
                UpgradeInfo.UpgradeConfig = ReadUpgradeConfigFromCommandArgs();
                UpgradeInfo.MainProcess = AppUtils.GetMainProcess(UpgradeInfo.UpgradeConfig.MainProcessName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"更新失败：参数配置异常。{ex.Message}", "自动更新", MessageBoxButton.OK, MessageBoxImage.Error);
                App.Current.Shutdown();
                return;
            }

            bool isDarkTheme;
            switch (_theme)
            {
                case ThemeEnum.System:
                    isDarkTheme = CheckSystemIsDarkTheme();
                    break;
                case ThemeEnum.Light:
                    isDarkTheme = false;
                    break;
                case ThemeEnum.Dark:
                    isDarkTheme = true;
                    break;
                default:
                    isDarkTheme = false;
                    break;
            }
            AppearanceManager.Current.ThemeSource = isDarkTheme ? AppearanceManager.DarkThemeSource : AppearanceManager.LightThemeSource;

            if (!UpgradeInfo.UpgradeSetting.IsBackgroundCheck)
            {
                new UpgradeCheckWindow().Show();
            }
            else
            {
                try
                {
                    var task = Task.Run(UpgradeChecker.DoAsync);
                    task.Wait();

                    if (UpgradeInfo.IsNeedUpdate == false)
                    {
                        Application.Current.Shutdown();
                        return;
                    }
                    new UpgradeWindow().Show();

                }
                catch (Exception ex)
                {
                    Application.Current.Shutdown();
                }
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

            * -t 10
              超时时间,[10:10秒]

            * -http UpgradeUrl
              使用 HTTP 方式更新,[UpgradeUrl:更新地址]

            * -ftp UpgradeUrl UserName pwd
              使用 FTP 方式更新,[UpgradeUrl:更新地址] [UserName:用户名] [pwd:密码]
            
            * -s IsBackgroundCheck
              常规设置,[IsBackgroundCheck:是否在后台进行更新检查]

            * -theme [system|light|dark]
              系统主题
            **********************************************/

            CommandLineArgsHelper _commandLineArgsHelper = new CommandLineArgsHelper();

            var upgradeConfig = new UpgradeConfigInfo();
            if (!_commandLineArgsHelper.TryGetCommandValue($"-{ArgumentTypeEnum.p}", out List<string> mainProcessArgs))
            {
                throw new ArgumentException("缺少主进程参数");
            }
            upgradeConfig.MainProcessName = mainProcessArgs[0];

            TimeSpan timeout;
            if (!_commandLineArgsHelper.TryGetCommandValue($"-{ArgumentTypeEnum.t}", out List<string> timeoutArgs))
            {
                timeout = TimeSpan.FromSeconds(5);
            }
            else
            {
                int timeoutInt;
                if (!int.TryParse(timeoutArgs[0], out timeoutInt))
                {
                    timeout = TimeSpan.FromSeconds(5);
                }
                else
                {
                    timeout = TimeSpan.FromSeconds(timeoutInt);
                }
            }

            if (_commandLineArgsHelper.HasCommand($"-{ArgumentTypeEnum.background}"))
            {
                UpgradeInfo.UpgradeSetting.IsBackgroundCheck = true;
            }

            if (_commandLineArgsHelper.HasCommand($"-{ArgumentTypeEnum.check}"))
            {
                UpgradeInfo.UpgradeSetting.IsCheckSign = true;
            }

            if (!_commandLineArgsHelper.TryGetCommandValue($"-{ArgumentTypeEnum.theme}", out List<string> themeArgs))
            {
                throw new ArgumentException("缺少主题参数");
            }
            _theme = (ThemeEnum)Enum.Parse(typeof(ThemeEnum), themeArgs[0]);

            if (_commandLineArgsHelper.TryGetCommandValue($"-{ArgumentTypeEnum.http}", out List<string> httpArgs))
            {
                upgradeConfig.UpgradeMode = UpgradeModeEnum.Http;
                try
                {
                    upgradeConfig.ConnectionConfig = new HttpConnectionConfig()
                    {
                        Timeout = timeout,
                        UpgradeUrl = httpArgs[0]
                    };
                    return upgradeConfig;
                }
                catch (Exception)
                {
                    throw new ArgumentException("Http参数配置异常");
                }
            }

            if (_commandLineArgsHelper.TryGetCommandValue($"-{ArgumentTypeEnum.ftp}", out List<string> ftpArgs))
            {
                upgradeConfig.UpgradeMode = UpgradeModeEnum.Ftp;
                try
                {
                    upgradeConfig.ConnectionConfig = new FtpConnectionConfig()
                    {
                        Timeout = timeout,
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

        private bool CheckSystemIsDarkTheme()
        {
            try
            {
                var registryValue = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", "AppsUseLightTheme", null);

                if (registryValue != null && registryValue is int themeValue)
                {
                    return themeValue == 0;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
