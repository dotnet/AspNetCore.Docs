using System;
using System.Text.Json.Serialization;

namespace HttpClientFactorySample.GitHub
{
    /// <summary>
    /// A partial representation of an issue object from the GitHub API
    /// </summary>
    public class GitHubIssue
    {
        [JsonPropertyName("html_url")]
        public string Url { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime Created { get; set; }
    }
}