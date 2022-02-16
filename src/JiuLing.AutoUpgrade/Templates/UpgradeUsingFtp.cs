using System;
using System.IO;
using System.Threading.Tasks;
using JiuLing.AutoUpgrade.Models;
using JiuLing.AutoUpgrade.Net;

namespace JiuLing.AutoUpgrade.Templates
{
    internal class UpgradeUsingFtp : UpgradeAbstract
    {
        private readonly FtpClientHelper _clientHelper;

        public UpgradeUsingFtp(FtpConnectionConfig connectionConfig)
        {
            _clientHelper = new FtpClientHelper(connectionConfig.UserName, connectionConfig.Password);
        }
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
