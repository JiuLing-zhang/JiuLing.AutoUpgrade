using JiuLing.AutoUpgrade.Common;
using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Threading.Tasks;

namespace JiuLing.AutoUpgrade.Downloader
{
    internal abstract class DownloaderBase
    {
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="downloadUrl">更新包的下载地址</param>
        /// <param name="appPath">程序运行路径</param>
        /// <param name="updatePackageFile">更新包的完整路径</param>
        /// <param name="tempExtractedDir">更新文件的临时解压路径</param>
        /// <param name="downloadCompleted">文件下载完成之后</param>
        /// <param name="progress">进度</param>
        public async Task Update(string downloadUrl, string appPath, string updatePackageFile, string tempExtractedDir, Action downloadCompleted, IProgress<float> progress)
        {
            try
            {
                await DownloadApp(downloadUrl, updatePackageFile, progress);
                downloadCompleted?.Invoke();
                PublishZipFile(updatePackageFile, tempExtractedDir);

                CopyFiles(tempExtractedDir, appPath);

            }
            finally
            {
                ClearTempFiles();
            }
        }

        public abstract Task DownloadApp(string downloadUrl, string updatePackPath, IProgress<float> progress);

        private static void PublishZipFile(string filePath, string dstPath)
        {
            if (Directory.Exists(dstPath))
            {
                Directory.Delete(dstPath, true);
            }
            ZipFile.ExtractToDirectory(filePath, dstPath, Encoding.GetEncoding("GBK"));
        }

        private void CopyFiles(string sourcePath, string destinationPath)
        {
            if (!Directory.Exists(destinationPath))
            {
                Directory.CreateDirectory(destinationPath);
            }

            var files = Directory.GetFiles(sourcePath);
            foreach (var file in files)
            {
                var fi = new FileInfo(file);
                File.Copy(file, Path.Combine(destinationPath, fi.Name), true);
            }

            var directories = Directory.GetDirectories(sourcePath);
            foreach (var directory in directories)
            {
                var di = new DirectoryInfo(directory);
                CopyFiles(directory, Path.Combine(destinationPath, di.Name));
            }
        }

        /// <summary>
        /// 清理临时文件
        /// </summary>
        private static void ClearTempFiles()
        {
            try
            {
                if (Directory.Exists(TempPaths.RootDir))
                {
                    Directory.Delete(TempPaths.RootDir, true);
                }
            }
            catch
            {
                // 忽略删除异常
            }
        }
    }
}
