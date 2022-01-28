using JiuLing.AutoUpgrade.Models;
using JiuLing.AutoUpgrade.Net;
using System.Text.Json;

namespace JiuLing.AutoUpgrade.Strategies
{
    /// <summary>
    /// Ftp参数构造策略
    /// </summary>
    internal class UpgradeStrategyUsingFtp : UpgradeStrategy
    {
        private readonly FtpClientHelper _clientHelper;
        private readonly string _upgradePath;
        public UpgradeStrategyUsingFtp(FtpConnectionConfig connectionConfig)
        {
            _clientHelper = new FtpClientHelper(connectionConfig.UserName, connectionConfig.Password);
            _upgradePath = connectionConfig.UpgradePath;
        }

        public override async Task<AppVersionInfo> GetUpgradeInfo()
        {
            try
            {
                var result = await _clientHelper.ReadFileText(_upgradePath);
                var upgradeInfo = JsonSerializer.Deserialize<AppVersionInfo>(result);
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
