using Refit;

namespace HttpRequestsSample.GitHub;

// <snippet_Interface>
public interface IGitHubClient
{
    [Get("/repos/dotnet/AspNetCore.Docs/branches")]
    Task<IEnumerable<GitHubBranch>> GetAspNetCoreDocsBranchesAsync();
}
// </snippet_Interface>
