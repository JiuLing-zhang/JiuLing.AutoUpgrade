using System.Threading.Tasks;

namespace JiuLing.AutoUpgrade.Shell.Creator
{
    /// <summary>
    /// 更新程序
    /// </summary>
    public interface IUpgradeApp
    {
        /// <summary>
        /// 设置更新参数
        /// </summary>
        /// <param name="builder">更新参数构建器</param>
        /// <returns></returns>
        IUpgradeApp SetUpgrade(UpgradeSettingBuilder builder);
        /// <summary>
        /// 启动
        /// </summary>
        void Run();

#if NET5_0_OR_GREATER
        /// <summary>
        /// 异步启动
        /// </summary>
        /// <returns></returns>
        Task RunAsync();
#endif

    }
}
