using System;
using System.Threading.Tasks;
using JiuLing.AutoUpgrade.Models;
using JiuLing.AutoUpgrade.Net;
using JiuLing.CommonLibs.ExtensionMethods;
using JiuLing.CommonLibs.Model;

namespace JiuLing.AutoUpgrade.Updater
{
    /// <summary>
    /// Ftp参数构造策略
    /// </summary>
    internal class FtpUpdateStrategy : UpdateStrategyBase
    {
        private readonly FtpClientHelper _clientHelper;
        private readonly string _upgradePath;
        private readonly TimeSpan _timeout;
        public FtpUpdateStrategy(FtpConnectionConfig connectionConfig)
        {
            _clientHelper = new FtpClientHelper(connectionConfig.UserName, connectionConfig.Password);
            _upgradePath = connectionConfig.UpgradePath;
            _timeout = connectionConfig.Timeout;
        }

        public override async Task<AppUpgradeInfo> GetUpgradeInfo()
        {
            try
            {
                var result = await _clientHelper.ReadFileText(_upgradePath, _timeout);
                var upgradeInfo = result.ToObject<AppUpgradeInfo>();
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
