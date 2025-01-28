using JiuLing.AutoUpgrade.Shell.Creator;

namespace JiuLing.AutoUpgrade.Shell
{
    /// <summary>
    /// 自动更新组件工厂
    /// </summary>
    public static class UpgradeFactory
    {
        /// <summary>
        /// 创建 HTTP 更新组件
        /// </summary>
        /// <param name="upgradeUrl">更新信息接口</param>
        /// <returns></returns>
        public static IUpgradeApp CreateHttpApp(string upgradeUrl)
        {
            return new HttpApp(upgradeUrl);
        }

        /// <summary>
        /// 创建 FTP 更新组件
        /// </summary>
        /// <param name="upgradePath">更新文件地址</param>
        /// <param name="username">FTP用户名</param>
        /// <param name="password">FTP密码</param>
        /// <returns></returns>
        public static IUpgradeApp CreateFtpApp(string upgradePath, string username, string password)
        {
            return new FtpApp(upgradePath, username, password);
        }

        /// <summary>
        /// 创建 GitHub 更新组件
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="repo">仓库</param>
        /// <param name="assetName">资源名称</param>
        /// <returns></returns>
        public static IUpgradeApp CreateGitHubApp(string user, string repo, string assetName)
        {
            return new GitHubApp(user, repo, assetName);
        }
    }
}
