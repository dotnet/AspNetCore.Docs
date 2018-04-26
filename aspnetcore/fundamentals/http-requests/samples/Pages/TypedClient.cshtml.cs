using System.Threading.Tasks;
using HttpClientFactorySample.GitHub;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HttpClientFactorySample.Pages
{
    #region snippet1
    public class TypedClientModel : PageModel
    {
        private readonly GitHubService _gitHubService;

        public GitHubIssue LastestIssue { get; private set; }

        public bool HasIssue => LastestIssue != null;

        public TypedClientModel(GitHubService gitHubService)
        {
            _gitHubService = gitHubService;
        }

        public async Task OnGet()
        {
            LastestIssue = await _gitHubService.GetLatestDocsIssue();
        }
    }
    #endregion
}