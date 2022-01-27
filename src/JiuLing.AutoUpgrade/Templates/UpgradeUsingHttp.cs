using JiuLing.AutoUpgrade.Models;
using JiuLing.AutoUpgrade.Net;

namespace JiuLing.AutoUpgrade.Templates
{
    internal class UpgradeUsingHttp : UpgradeAbstract
    {
        private readonly HttpClientHelper _clientHelper = new();
        public UpgradeUsingHttp()
        {
        }
        public override async Task DownloadApp(string downloadUrl, string updatePackPath, IProgress<float> progress)
        {
            if (File.Exists(updatePackPath))
            {
                File.Delete(updatePackPath);
            }
            var result = await _clientHelper.GetFileByteArray(downloadUrl, progress);
            await File.WriteAllBytesAsync(updatePackPath, result);
        }
    }
}
