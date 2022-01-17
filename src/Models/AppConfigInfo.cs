using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoUpgrade.Models
{
    internal class AppConfigInfo
    {
        /// <summary>
        /// 主程序名称
        /// </summary>
        public string MainAppName { get; set; } = "";
        /// <summary>
        /// 自动更新的检查地址
        /// </summary>
        public string UpgradeUrl { get; set; } = "";
        /// <summary>
        /// 是否自动安装
        /// </summary>
        public bool AutoInstall { get; set; } = false;
    }
}
