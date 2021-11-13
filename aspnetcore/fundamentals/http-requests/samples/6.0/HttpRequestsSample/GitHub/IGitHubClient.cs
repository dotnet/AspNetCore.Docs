using Refit;

namespace HttpRequestsSample.GitHub
{
    #region snippet_Interface
    public interface IGitHubClient
    {
        [Get("/repos/dotnet/AspNetCore.Docs/branches")]
        Task<IEnumerable<GitHubBranch>> GetAspNetCoreDocsBranchesAsync();
    }
    #endregion
}
