using System;
using System.Collections.Generic;
using System.Text;

namespace JiuLing.AutoUpgrade.Shell
{
    /// <summary>
    /// 通知设置
    /// </summary>
    public class NoticeConfig
    {
        /// <summary>
        /// 无可用更新时是否弹窗提醒
        /// </summary>
        public bool NoUpdateShowDialog { get; set; } = true;
    }
}
