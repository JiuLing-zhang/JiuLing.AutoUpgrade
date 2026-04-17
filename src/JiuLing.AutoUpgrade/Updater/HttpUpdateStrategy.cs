using System;
using System.Text.Json;
using System.Threading.Tasks;
using JiuLing.AutoUpgrade.Models;
using JiuLing.AutoUpgrade.Net;
using JiuLing.CommonLibs.ExtensionMethods;
using JiuLing.CommonLibs.Model;

namespace JiuLing.AutoUpgrade.Updater
{
    /// <summary>
    /// Http参数构造策略
    /// </summary>
    internal class HttpUpdateStrategy : UpdateStrategyBase
    {
        private readonly HttpConnectionConfig _connectionConfig;

        private readonly HttpClientHelper _clientHelper = new HttpClientHelper();
        public HttpUpdateStrategy(HttpConnectionConfig connectionConfig)
        {
            _connectionConfig = connectionConfig;
        }
        public override async Task<AppUpdateInfo> GetUpgradeInfo()
        {
            try
            {
                var result = await _clientHelper.GetReadString(_connectionConfig.UpgradeUrl, _connectionConfig.Timeout);
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    PropertyNameCaseInsensitive = true
                };
                var upgradeInfo = System.Text.Json.JsonSerializer.Deserialize<AppUpdateInfo>(result, options);
                if (upgradeInfo == null)
                {
                    throw new Exception(AutoUpgrade.Properties.Resources.DataError);
                }
                return upgradeInfo;
            }
            catch (Exception)
            {
                throw new Exception(AutoUpgrade.Properties.Resources.UnableConnectServer);
            }
        }
    }
}
