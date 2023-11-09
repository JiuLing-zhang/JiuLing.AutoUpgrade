using System;
using System.Diagnostics;
using System.IO;
using JiuLing.AutoUpgrade.Models;

namespace JiuLing.AutoUpgrade.Common
{
    /// <summary>
    /// 程序相关的辅助类
    /// </summary>
    internal class AppUtils
    {
        /// <summary>
        /// 获取主程序的进程
        /// </summary>
        public static ProcessInfo GetMainProcess(string mainProcessName)
        {
            Process[] process = Process.GetProcessesByName(mainProcessName);

            foreach (Process p in process)
            {
                string fileName = p.MainModule?.FileName ?? throw new ArgumentException(AutoUpgrade.Properties.Resources.StartupPathNotFound);
                string processDirectory = Path.GetDirectoryName(fileName) ?? throw new ArgumentException(AutoUpgrade.Properties.Resources.StartupDirectoryNotFound);

                if (Path.GetDirectoryName(GlobalArgs.AppPath) != Path.Combine(processDirectory, GlobalArgs.AppReleasedDirectoryName))
                {
                    throw new ApplicationException(AutoUpgrade.Properties.Resources.ProgramDirectoryError);
                }

                GlobalArgs.MainAppPath = processDirectory;
                return new ProcessInfo()
                {
                    Id = p.Id,
                    Title = p.MainWindowTitle,
                    FileName = fileName,
                };
            }
            throw new ApplicationException($"{AutoUpgrade.Properties.Resources.MainProcessNotFound} {mainProcessName}");
        }

        /// <summary>
        /// 获取主程序版本
        /// </summary>
        public static string GetMainAppVersion(ProcessInfo mainProcess)
        {
            FileVersionInfo info = FileVersionInfo.GetVersionInfo(mainProcess.FileName);
            if (info.FileVersion == null)
            {
                throw new ArgumentException(AutoUpgrade.Properties.Resources.MainProcessVersionError);
            }
            return info.FileVersion;
        }
    }
}
