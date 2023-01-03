using System;
using JiuLing.AutoUpgrade.Models;
using JiuLing.AutoUpgrade.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JiuLing.AutoUpgrade.Strategies
{
    /// <summary>
    /// Ftp参数构造策略
    /// </summary>
    internal class UpgradeStrategyUsingFtp : UpgradeStrategy
    {
        private readonly FtpClientHelper _clientHelper;
        private readonly string _upgradePath;
        private TimeSpan _timeout;
        public UpgradeStrategyUsingFtp(FtpConnectionConfig connectionConfig)
        {
            _clientHelper = new FtpClientHelper(connectionConfig.UserName, connectionConfig.Password);
            _upgradePath = connectionConfig.UpgradePath;
            _timeout = connectionConfig.Timeout;
        }

        public override async Task<AppVersionInfo> GetUpgradeInfo()
        {
            try
            {
                var result = await _clientHelper.ReadFileText(_upgradePath, _timeout);
                var upgradeInfo = JsonConvert.DeserializeObject<AppVersionInfo>(result);
                if (upgradeInfo == null)
                {
                    throw new Exception("服务器响应错误");
                }
                return upgradeInfo;
            }
            catch (Exception)
            {
                throw new Exception("连接服务器失败");
            }

        }
    }
}
