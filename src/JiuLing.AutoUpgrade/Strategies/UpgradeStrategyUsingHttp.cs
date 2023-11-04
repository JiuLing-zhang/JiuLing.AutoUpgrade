using System;
using JiuLing.AutoUpgrade.Models;
using JiuLing.AutoUpgrade.Net;
using System.Threading.Tasks;
using JiuLing.CommonLibs.Model;
using JiuLing.CommonLibs.ExtensionMethods;

namespace JiuLing.AutoUpgrade.Strategies
{
    /// <summary>
    /// Http参数构造策略
    /// </summary>
    internal class UpgradeStrategyUsingHttp : UpgradeStrategy
    {
        private readonly HttpConnectionConfig _connectionConfig;

        private readonly HttpClientHelper _clientHelper = new HttpClientHelper();
        public UpgradeStrategyUsingHttp(HttpConnectionConfig connectionConfig)
        {
            _connectionConfig = connectionConfig;
        }
        public override async Task<AppUpgradeInfo> GetUpgradeInfo()
        {
            try
            {
                var result = await _clientHelper.GetReadString(_connectionConfig.UpgradeUrl, _connectionConfig.Timeout);
                var upgradeInfo = result.ToObject<AppUpgradeInfo>();
                if (upgradeInfo == null)
                {
                    throw new Exception(lang.DataError);
                }
                return upgradeInfo;
            }
            catch (Exception)
            {
                throw new Exception(lang.UnableConnectServer);
            }
        }
    }
}
