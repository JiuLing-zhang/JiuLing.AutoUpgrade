namespace JiuLing.AutoUpgrade.Models
{
    /// <summary>
    /// HTTP 连接配置
    /// </summary>
    internal class HttpConnectionConfig : ConnectionConfigBase
    {
        public string UpgradeUrl { get; set; } = "";
    }

}
