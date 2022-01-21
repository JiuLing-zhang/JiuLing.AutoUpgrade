using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiuLing.AutoUpgrade.Models
{
    internal class AppConfigInfo
    {
        /// <summary>
        /// 主进程名称
        /// </summary>
        public string MainProcessName { get; set; } = "";
        /// <summary>
        /// 自动更新的检查地址
        /// </summary>
        public string UpgradeUrl { get; set; } = "";
    }
}
