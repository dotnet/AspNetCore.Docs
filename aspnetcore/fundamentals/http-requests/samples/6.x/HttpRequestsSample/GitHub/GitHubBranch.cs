using System.Text.Json.Serialization;

namespace HttpRequestsSample.GitHub;

public record GitHubBranch(
    [property: JsonPropertyName("name")] string Name);
