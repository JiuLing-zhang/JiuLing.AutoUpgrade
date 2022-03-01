using System;
using System.IO;

namespace JiuLing.AutoUpgrade.Common
{
    internal class GlobalArgs
    {

        public static readonly string AppPath = AppDomain.CurrentDomain.BaseDirectory;
        /// <summary>
        /// 当前程序被释放的文件夹路径
        /// </summary>
        public static string AppReleasedDirectoryName = "JiuLing.AutoUpgrade.Core.Temp";
        /// <summary>
        /// 待更新程序的路径
        /// </summary>
        public static string MainAppPath;

        /// <summary>
        /// 临时下载的更新包位置
        /// </summary>
        public static string TempPackagePath = Path.Combine(AppPath, "AutoUpgrade.temp.zip");

        /// <summary>
        /// 更新文件解压的路径
        /// </summary>
        public static string TempZipDirectory = Path.Combine(AppPath, "AutoUpgrade.temp");

    }
}
