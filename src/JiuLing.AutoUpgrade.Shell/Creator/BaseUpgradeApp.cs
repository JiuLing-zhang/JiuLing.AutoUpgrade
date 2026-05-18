using JiuLing.AutoUpgrade.Shared;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JiuLing.AutoUpgrade.Shell.Creator
{
    internal abstract class BaseUpgradeApp : IUpgradeApp
    {
        private readonly string _tempUpdaterExeFullPath;
        private UpgradeSetting _upgradeSetting;
        private readonly UpgradeSettingBuilder _upgradeSettingBuilder;
        private static Mutex _mutex;

        internal BaseUpgradeApp()
        {
            _upgradeSetting = new UpgradeSetting();
            _upgradeSettingBuilder = new UpgradeSettingBuilder();
            _tempUpdaterExeFullPath = Path.Combine(Path.GetTempPath(), $"JiuLing.AutoUpgrade_{Guid.NewGuid():N}.exe");
        }

        [Obsolete("已过时，请改用 lambda 方式调用", true)]
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
            process.StartInfo.FileName = _tempUpdaterExeFullPath;
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
            process.StartInfo.FileName = _tempUpdaterExeFullPath;
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
            var arguments = GetAppBaseArgument();
            arguments = arguments + " " + GetInnerArguments();
            arguments = arguments + " " + GetUpgradeSettingArguments();
            return arguments;
        }
        /// <summary>
        /// 获取主程序基础参数
        /// </summary>
        /// <returns></returns>
        private string GetAppBaseArgument()
        {
            if (string.IsNullOrEmpty(_upgradeSetting.Title))
            {
                _upgradeSetting.Title = Process.GetCurrentProcess().ProcessName;
            }

            if (string.IsNullOrEmpty(_upgradeSetting.FullPath))
            {
                _upgradeSetting.FullPath = Process.GetCurrentProcess().MainModule?.FileName ?? throw new InvalidOperationException("无法获取主程序完整路径，无法执行更新。");
            }

            if (!File.Exists(_upgradeSetting.FullPath))
            {
                throw new FileNotFoundException($"主程序不存在, file does not exist. {_upgradeSetting.FullPath}");
            }

            _upgradeSetting.Version = Assembly.GetEntryAssembly()?.GetName().Version?.ToString() ?? throw new InvalidOperationException("无法获取主程序版本信息，无法执行更新。");

            string titleBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(_upgradeSetting.Title));
            string pathBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(_upgradeSetting.FullPath));

            return $"-{ArgumentTypeEnum.titleBase64} {titleBase64} " +
                   $"-{ArgumentTypeEnum.fullPathBase64} {pathBase64} " +
                   $"-{ArgumentTypeEnum.version} {_upgradeSetting.Version}";
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
            File.WriteAllBytes(_tempUpdaterExeFullPath, Resource.AutoUpgrade_exe);
        }

        private void DeleteMainApplication()
        {
            try
            {
                File.Delete(_tempUpdaterExeFullPath);
            }
            catch
            {
                // ignored 删除失败忽略错误
            }
        }
    }
}
