using HttpRequestsSample.GitHub;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Refit;

namespace HttpRequestsSample.Pages
{
    #region snippet_Class
    public class RefitModel : PageModel
    {
        private readonly IGitHubClient _gitHubClient;

        public RefitModel(IGitHubClient gitHubClient) =>
            _gitHubClient = gitHubClient;

        public IEnumerable<GitHubBranch>? GitHubBranches { get; set; }

        public async Task OnGet()
        {
            try
            {
                GitHubBranches = await _gitHubClient.GetAspNetCoreDocsBranchesAsync();
            }
            catch (ApiException)
            {
                // ...
            }
        }
    }
    #endregion
}
