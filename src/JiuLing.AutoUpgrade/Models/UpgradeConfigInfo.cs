using JiuLing.AutoUpgrade.Enums;

namespace JiuLing.AutoUpgrade.Models
{
    /// <summary>
    /// 自动更新配置
    /// </summary>
    internal class UpgradeConfigInfo
    {
        /// <summary>
        /// 主进程名称
        /// </summary>
        public string MainProcessName { get; set; } = "";
        /// <summary>
        /// 更新方式
        /// </summary>
        public UpgradeModeEnum UpgradeMode { get; set; }
        /// <summary>
        /// 请求连接配置
        /// </summary>
        public dynamic ConnectionConfig { get; set; }
    }

    internal class HttpConnectionConfig
    {
        public string UpgradeUrl { get; set; } = "";
    }

    internal class FtpConnectionConfig
    {
        public string UserName { get; set; } = "";
        public string Password { get; set; } = "";
        public string UpgradePath { get; set; } = "";
    }
}
