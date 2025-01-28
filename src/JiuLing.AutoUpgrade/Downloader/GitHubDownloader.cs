using JiuLing.AutoUpgrade.Net;
using System;
using System.IO;
using System.Threading.Tasks;

namespace JiuLing.AutoUpgrade.Downloader
{
    internal class GitHubDownloader : DownloaderBase
    {
        private readonly HttpClientHelper _clientHelper = new HttpClientHelper();

        public override async Task DownloadApp(string downloadUrl, string updatePackPath, IProgress<float> progress)
        {
            if (File.Exists(updatePackPath))
            {
                File.Delete(updatePackPath);
            }
            var result = await _clientHelper.GetFileByteArray(downloadUrl, progress);
            File.WriteAllBytes(updatePackPath, result);
        }
    }
}
