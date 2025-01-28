using JiuLing.AutoUpgrade.Models;
using JiuLing.AutoUpgrade.Net;
using JiuLing.CommonLibs.ExtensionMethods;
using JiuLing.CommonLibs.Model;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace JiuLing.AutoUpgrade.Updater
{
    /// <summary>
    /// GitHub参数构造策略
    /// </summary>
    internal class GitHubUpdateStrategy : UpdateStrategyBase
    {
        private readonly GitHubConnectionConfig _connectionConfig;

        private readonly HttpClientHelper _clientHelper = new HttpClientHelper();
        public GitHubUpdateStrategy(GitHubConnectionConfig connectionConfig)
        {
            _connectionConfig = connectionConfig;
        }
        public override async Task<AppUpgradeInfo> GetUpgradeInfo()
        {
            try
            {
                var url = $"https://api.github.com/repos/{_connectionConfig.User}/{_connectionConfig.Repo}/releases/latest";

                HttpClientHelper.HttpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "http://developer.github.com/v3/#user-agent-required");
                var result = await _clientHelper.GetReadString(url, _connectionConfig.Timeout);
                var release = result.ToObject<GitHubReleaseResponse>();

                if (release?.Assets == null)
                {
                    throw new Exception(Properties.Resources.NoUpdatesAvailable);
                }

                var asset = release.Assets.FirstOrDefault(x => x.Name == _connectionConfig.AssetName);
                if (asset == null)
                {
                    throw new Exception(Properties.Resources.NoUpdatesAvailable);
                }

                return new AppUpgradeInfo
                {
                    Name = asset.Name,
                    Version = release.Name.TrimStart('v').TrimStart('V').Trim(),
                    DownloadUrl = asset?.BrowserDownloadUrl,
                    Log = release.Body,
                    CreateTime = release.PublishedAt,
                    FileLength = asset?.Size
                };
            }
            catch (Exception)
            {
                throw new Exception(Properties.Resources.UnableConnectServer);
            }
        }
    }
}
