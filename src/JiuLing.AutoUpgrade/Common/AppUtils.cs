using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                string fileName = p.MainModule?.FileName ?? throw new ArgumentException("未找到主进程启动路径");
                string processDirectory = Path.GetDirectoryName(fileName) ?? throw new ArgumentException("未找到主进程启动目录");
                string? myDirectory = Path.GetDirectoryName(GlobalArgs.AppPath);

                if (myDirectory != processDirectory)
                {
                    throw new ApplicationException("主程序和自动更新程序不在同一目录");
                }

                return new ProcessInfo()
                {
                    Id = p.Id,
                    Title = p.MainWindowTitle,
                    FileName = fileName,
                };
            }
            throw new ApplicationException($"未找到主进程{GlobalArgs.AppConfig.MainProcessName}");
        }

        /// <summary>
        /// 获取主程序版本
        /// </summary>
        public static string GetMainAppVersion(ProcessInfo mainProcess)
        {
            FileVersionInfo info = FileVersionInfo.GetVersionInfo(mainProcess.FileName);
            if (info.FileVersion == null)
            {
                throw new ArgumentException($"主程序版本号异常");
            }
            return info.FileVersion;
        }
    }
}
