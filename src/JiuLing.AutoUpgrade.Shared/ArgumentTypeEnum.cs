namespace JiuLing.AutoUpgrade.Shared
{
    /// <summary>
    /// 参数类型
    /// </summary>
    enum ArgumentTypeEnum
    {
        /// <summary>
        /// 主进程参数
        /// </summary>
        p,
        /// <summary>
        /// 超时时间
        /// </summary>
        t,
        /// <summary>
        /// ftp更新参数
        /// </summary>
        ftp,
        /// <summary>
        /// http更新参数
        /// </summary>
        http,
        /// <summary>
        /// github更新参数
        /// </summary>
        github,
        /// <summary>
        /// 后台检查更新参数
        /// </summary>
        background,
        /// <summary>
        /// 校验文件参数
        /// </summary>
        check,
        /// <summary>
        /// 主题
        /// </summary>
        theme,
        /// <summary>
        /// 语言
        /// </summary>
        lang,
        /// <summary>
        /// 图标
        /// </summary>
        icon,
        /// <summary>
        /// 版本号展示格式
        /// </summary>
        versionFormat
    }
}
