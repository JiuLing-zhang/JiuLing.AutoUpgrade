using JiuLing.AutoUpgrade.Models;

namespace JiuLing.AutoUpgrade.Strategies
{
    /// <summary>
    /// Ftp参数构造策略
    /// </summary>
    internal class UpgradeStrategyUsingFtp : UpgradeStrategy
    {
        private readonly FtpConnectionConfig _connectionConfig;
        public UpgradeStrategyUsingFtp(FtpConnectionConfig connectionConfig)
        {
            _connectionConfig = connectionConfig;
        }

        public override Task<AppVersionInfo> GetUpgradeInfo()
        {
            throw new NotImplementedException();
        }
    }
}
