using System;
using JiuLing.AutoUpgrade.Models;
using JiuLing.AutoUpgrade.Net;
using System.Threading.Tasks;
using JiuLing.CommonLibs.Model;
using Newtonsoft.Json;

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
                var upgradeInfo = JsonConvert.DeserializeObject<AppUpgradeInfo>(result);
                if (upgradeInfo == null)
                {
                    throw new Exception("服务器响应错误");
                }
                return upgradeInfo;
            }
            catch (Exception)
            {
                throw new Exception("服务器响应异常");
            }
        }
    }
}
