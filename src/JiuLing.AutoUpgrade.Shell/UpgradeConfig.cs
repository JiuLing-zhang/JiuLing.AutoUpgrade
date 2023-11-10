using JiuLing.AutoUpgrade.Shared;

namespace JiuLing.AutoUpgrade.Shell
{
    /// <summary>
    /// 更新时的一些设置
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
        /// <summary>
        /// 检查更新时的超时时间（秒）
        /// </summary>
        public int TimeoutSecond { get; set; } = 5;
        /// <summary>
        /// 主题
        /// </summary>
        public ThemeEnum Theme { get; set; } = ThemeEnum.System;
        /// <summary>
        /// 语言
        /// </summary>
        public string Lang { get; set; }
    }
}
