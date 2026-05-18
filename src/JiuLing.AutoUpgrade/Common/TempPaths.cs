using System;
using System.IO;

namespace JiuLing.AutoUpgrade.Common
{
    /// <summary>
    /// 临时路径
    /// </summary>
    internal static class TempPaths
    {
        static TempPaths()
        {
            Directory.CreateDirectory(RootDir);
            Directory.CreateDirectory(ExtractedDir);
        }

        /// <summary>
        /// 根目录
        /// </summary>
        public static readonly string RootDir = Path.Combine(Path.GetTempPath(), $"JiuLing.AutoUpgrade_{Guid.NewGuid():N}");

        /// <summary>
        /// 更新包的完整路径（包含文件名）
        /// </summary>
        public static string ZipFilePath = Path.Combine(RootDir, "upgrade.zip");

        /// <summary>
        /// 更新文件解压的路径
        /// </summary>
        public static string ExtractedDir = Path.Combine(RootDir, "extracted");

    }
}
