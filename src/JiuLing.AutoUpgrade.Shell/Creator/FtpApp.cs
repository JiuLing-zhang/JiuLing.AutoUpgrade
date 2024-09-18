using System;
using JiuLing.AutoUpgrade.Shared;

namespace JiuLing.AutoUpgrade.Shell.Creator
{
    internal class FtpApp : BaseUpgradeApp
    {
        private readonly string _upgradePath;
        private readonly string _username;
        private readonly string _password;

        public FtpApp(string upgradePath, string username, string password)
        {
            if (string.IsNullOrEmpty(upgradePath))
            {
                throw new ArgumentException("FTP更新地址未配置");
            }
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException("FTP用户名未配置");
            }
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("FTP密码未配置");
            }

            _upgradePath = upgradePath;
            _username = username;
            _password = password;
        }

        protected override string GetInnerArguments()
        {
            return $"-{ArgumentTypeEnum.ftp} {_upgradePath} {_username} {_password}";
        }
    }
}
