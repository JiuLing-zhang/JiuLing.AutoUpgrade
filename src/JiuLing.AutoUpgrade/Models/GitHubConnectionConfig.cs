namespace JiuLing.AutoUpgrade.Models
{
    internal class GitHubConnectionConfig : ConnectionConfigBase
    {
        public string User { get; set; } = "";
        public string Repo { get; set; } = "";
        public string AssetName { get; set; } = "";
    }
}
