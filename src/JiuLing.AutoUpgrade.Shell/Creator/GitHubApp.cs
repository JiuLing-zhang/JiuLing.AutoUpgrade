using JiuLing.AutoUpgrade.Shared;
using System;

namespace JiuLing.AutoUpgrade.Shell.Creator
{
    internal class GitHubApp : BaseUpgradeApp
    {
        private readonly string _user;
        private readonly string _repo;
        private readonly string _assetName;

        public GitHubApp(string user, string repo, string assetName)
        {
            if (string.IsNullOrEmpty(user))
            {
                throw new ArgumentException("GitHub 用户未配置");
            }
            if (string.IsNullOrEmpty(repo))
            {
                throw new ArgumentException("GitHub 仓库未配置");
            }
            if (string.IsNullOrEmpty(assetName))
            {
                throw new ArgumentException("GitHub 资源名称未配置");
            }

            _user = user;
            _repo = repo;
            _assetName = assetName;
        }

        protected override string GetInnerArguments()
        {
            return $"-{ArgumentTypeEnum.github} {_user} {_repo} {_assetName}";
        }
    }
}
