using JiuLing.AutoUpgrade.Enums;
using System;

namespace JiuLing.AutoUpgrade.Models
{
    /// <summary>
    /// 一个通用的App自动更新所需的模型
    /// </summary>
    public class AppVersionInfo
    {
        /// <summary>
        /// 程序名称
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// 当前版本
        /// </summary>
        public string Version { get; set; } = "";
        /// <summary>
        /// 程序运行的最小版本
        /// </summary>
        public string MinVersion { get; set; } = "";
        /// <summary>
        /// 下载地址
        /// </summary>
        public string DownloadUrl { get; set; } = "";
        /// <summary>
        /// 更新日志
        /// </summary>
        public string Log { get; set; } = "";
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime CreateTime { get; set; } = DateTime.MinValue;
        /// <summary>
        /// 签名类型
        /// </summary>
        public SignTypeEnum? SignType { get; set; }
        /// <summary>
        /// 签名值
        /// </summary>
        public string SignValue { get; set; }
    }
}
