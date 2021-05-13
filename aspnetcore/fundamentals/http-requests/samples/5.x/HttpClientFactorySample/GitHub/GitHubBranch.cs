using System.Text.Json.Serialization;

namespace HttpClientFactorySample.GitHub
{
    /// <summary>
    /// A partial representation of a branch object from the GitHub API
    /// </summary>
    public class GitHubBranch
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}