using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiuLing.AutoUpgrade.Models
{

    internal class ProcessInfo
    {
        public int Id { get; set; }
        public string FileName { get; set; } = "";
        /// <summary>
        /// 主进程是否允许运行
        /// </summary>
        public bool AllowRun { get; set; } = true;
    }
}
