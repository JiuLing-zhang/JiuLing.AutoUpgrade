using JiuLing.AutoUpgrade.Enums;
using System;
using System.Windows.Media.Imaging;

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

        /// <summary>
        /// 图标
        /// </summary>
        public BitmapFrame Icon { get; set; } = null;
    }

    internal class HttpConnectionConfig
    {
        /// <summary>
        /// 超时时间
        /// </summary>
        public TimeSpan Timeout { get; set; }
        public string UpgradeUrl { get; set; } = "";
    }

    internal class FtpConnectionConfig
    {
        /// <summary>
        /// 超时时间
        /// </summary>
        public TimeSpan Timeout { get; set; }
        public string UserName { get; set; } = "";
        public string Password { get; set; } = "";
        public string UpgradePath { get; set; } = "";
    }

    /// <summary>
    /// 设置
    /// </summary>
    public class UpgradeSetting
    {
        /// <summary>
        /// 是否在后台进行更新检查
        /// </summary>
        public bool IsBackgroundCheck { get; set; } = false;
        /// <summary>
        /// 是否校验签名
        /// </summary>
        public bool IsCheckSign { get; set; } = false;
    }
}
