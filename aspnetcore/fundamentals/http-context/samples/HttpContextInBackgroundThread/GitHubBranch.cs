using System.Text.Json.Serialization;

namespace HttpContextInBackgroundThread;

public record GitHubBranch([property: JsonPropertyName("name")] string Name);
