namespace JiuLing.AutoUpgrade.Models
{
    internal class FtpConnectionConfig : ConnectionConfigBase
    {
        public string UserName { get; set; } = "";
        public string Password { get; set; } = "";
        public string UpgradePath { get; set; } = "";
    }
}
