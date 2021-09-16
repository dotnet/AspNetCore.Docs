using System.Text.Json.Serialization;

namespace HttpClientFactorySample.GitHub
{
    /// <summary>
    /// A partial representation of a pull request object from the GitHub API
    /// </summary>
    public class GitHubPullRequest
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}