using System;
using System.Text.Json.Serialization;

namespace JiuLing.AutoUpgrade.Models
{
    internal class GitHubReleaseResponse
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("body")]
        public string Body { get; set; }

        [JsonPropertyName("published_at")]
        public DateTime PublishedAt { get; set; }

        [JsonPropertyName("assets")]
        public GitHubReleaseAsset[] Assets { get; set; }
    }

    internal class GitHubReleaseAsset
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("browser_download_url")]
        public string BrowserDownloadUrl { get; set; }

        [JsonPropertyName("size")]
        public int Size { get; set; }
    }
}
