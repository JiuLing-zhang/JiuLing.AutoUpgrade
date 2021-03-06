using System;
using System.Collections.Generic;
using System.Text;
using JiuLing.AutoUpgrade.Shell.Enums;

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
    }
}
