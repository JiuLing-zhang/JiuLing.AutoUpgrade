using JiuLing.AutoUpgrade.Models;
using JiuLing.AutoUpgrade.Net;

namespace JiuLing.AutoUpgrade.Templates
{
    internal class UpgradeUsingHttp : UpgradeAbstract
    {
        private readonly HttpConnectionConfig _connectionConfig;
        private readonly HttpClientHelper _clientHelper = new();
        public UpgradeUsingHttp(HttpConnectionConfig connectionConfig)
        {
            _connectionConfig = connectionConfig;
        }
        public override async Task DownloadApp(string updatePackPath, IProgress<float> progress)
        {
            if (File.Exists(updatePackPath))
            {
                File.Delete(updatePackPath);
            }
            var result = await _clientHelper.GetFileByteArray(_connectionConfig.UpgradeUrl, progress);
            await File.WriteAllBytesAsync(updatePackPath, result);
        }
    }
}
