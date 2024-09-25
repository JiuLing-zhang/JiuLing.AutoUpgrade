using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using JiuLing.AutoUpgrade.Shared;

namespace JiuLing.AutoUpgrade.Shell.Creator
{
    internal abstract class BaseUpgradeApp : IUpgradeApp
    {
        protected readonly string _coreAppDirectory;
        protected readonly string _coreAppFullFileName;
        protected UpgradeSetting _upgradeSetting;
        private readonly UpgradeSettingBuilder _upgradeSettingBuilder;
        protected static Mutex _mutex;

        internal BaseUpgradeApp()
        {
            _upgradeSetting = new UpgradeSetting();
            _upgradeSettingBuilder = new UpgradeSettingBuilder();
            _coreAppDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "JiuLing.AutoUpgrade.Core.Temp");
            _coreAppFullFileName = Path.Combine(_coreAppDirectory, "JiuLing.AutoUpgrade.exe");
        }

        [Obsolete("已过时，请改用 lambda 方式调用")]
        public IUpgradeApp SetUpgrade(UpgradeSettingBuilder builder)
        {
            _upgradeSetting = builder.Build();
            return this;
        }

        public IUpgradeApp SetUpgrade(Action<UpgradeSettingBuilder> configAction)
        {
            configAction?.Invoke(_upgradeSettingBuilder);
            _upgradeSetting = _upgradeSettingBuilder.Build();
            return this;
        }

        public void Run()
        {
            if (CheckLock())
            {
                return;
            }

            // 释放更新文件
            ReleaseAutoUpgradeFiles();

            // 创建并启动自动更新进程
            CallUpgrade();

            // 删除主应用程序文件
            DeleteMainApplication();

            // 释放互斥锁
            _mutex.ReleaseMutex();
        }
        private void CallUpgrade()
        {
            var process = new Process();
            process.StartInfo.FileName = _coreAppFullFileName;
            process.StartInfo.Arguments = GenerateStartArguments();
            process.Start();
            process.WaitForExit();
        }
#if NET5_0_OR_GREATER
        public async Task RunAsync()
        {
            if (CheckLock())
            {
                return;
            }

            // 释放更新文件
            ReleaseAutoUpgradeFiles();

            // 创建并启动自动更新进程
            await CallUpgradeAsync();

            // 删除主应用程序文件
            DeleteMainApplication();

            // 释放互斥锁
            _mutex.ReleaseMutex();
        }
        private async Task CallUpgradeAsync()
        {
            var process = new Process();
            process.StartInfo.FileName = _coreAppFullFileName;
            process.StartInfo.Arguments = GenerateStartArguments();
            process.Start();
            await process.WaitForExitAsync();
        }
#endif
        private bool CheckLock()
        {
            // 检查并创建互斥锁，防止多个实例同时运行
            _mutex = new Mutex(false, $"JiuLing.AutoUpgrade.{Process.GetCurrentProcess().ProcessName}");
            if (!_mutex.WaitOne(0, false))
            {
                Debug.WriteLine("不允许同一个程序的自动更新组件同时运行。");
                return true;
            }
            return false;
        }

        private string GenerateStartArguments()
        {
            var arguments = GetProcessArgument();
            arguments = arguments + " " + GetInnerArguments();
            arguments = arguments + " " + GetUpgradeSettingArguments();
            return arguments;
        }
        /// <summary>
        /// 主进程参数
        /// </summary>
        /// <returns></returns>
        private string GetProcessArgument()
        {
            return $"-{ArgumentTypeEnum.p} {Process.GetCurrentProcess().ProcessName}";
        }
        protected abstract string GetInnerArguments();
        private string GetUpgradeSettingArguments()
        {
            string arguments = $"-{ArgumentTypeEnum.t} {_upgradeSetting.TimeoutSecond} ";

            if (_upgradeSetting.IsBackgroundCheck)
            {
                arguments += $"-{ArgumentTypeEnum.background} ";
            }

            if (_upgradeSetting.IsCheckSign)
            {
                arguments += $"-{ArgumentTypeEnum.check} ";
            }

            arguments += $"-{ArgumentTypeEnum.theme} {(int)_upgradeSetting.Theme} ";

            if (!string.IsNullOrEmpty(_upgradeSetting.Lang))
            {
                arguments += $"-{ArgumentTypeEnum.lang} {_upgradeSetting.Lang} ";
            }

            arguments += $"-{ArgumentTypeEnum.versionFormat} {(int)_upgradeSetting.VersionFormat} ";

            if (!string.IsNullOrEmpty(_upgradeSetting.IconPath))
            {
                if (!File.Exists(_upgradeSetting.IconPath))
                {
                    throw new FileNotFoundException($"文件不存在, file does not exist. {_upgradeSetting.IconPath}");
                }
                var fullPath = Path.GetFullPath(_upgradeSetting.IconPath);
                arguments += $"-{ArgumentTypeEnum.icon} {fullPath} ";
            }

            return arguments.Trim();
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
