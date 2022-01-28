namespace JiuLing.AutoUpgrade.Models
{

    internal class ProcessInfo
    {
        public int Id { get; set; }

        public string Title { get; set; } = "";

        public string FileName { get; set; } = "";
        /// <summary>
        /// 主进程是否允许运行
        /// </summary>
        public bool AllowRun { get; set; } = true;
    }
}
