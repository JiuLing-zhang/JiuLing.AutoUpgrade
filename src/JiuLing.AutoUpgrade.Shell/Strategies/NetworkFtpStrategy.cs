using JiuLing.AutoUpgrade.Shell.Enums;

namespace JiuLing.AutoUpgrade.Shell.Strategies
{
    /// <summary>
    /// Ftp参数构造策略
    /// </summary>
    internal class NetworkFtpStrategy : NetworkStrategy
    {
        private readonly string _userName;
        private readonly string _password;
        private readonly string _upgradePath;
        public NetworkFtpStrategy(string userName, string password, string upgradePath)
        {
            _userName = userName;
            _password = password;
            _upgradePath = upgradePath;
        }
        public override string Build(NetworkTypeEnum networkType)
        {
            return $"-ftp {_userName} {_password} {_upgradePath}";
        }
    }
}
