using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HttpClientFactorySample.GitHub;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HttpClientFactorySample.Pages
{
    #region snippet1
    public class TypedClientModel : PageModel
    {
        private readonly GitHubService _gitHubService;

        public IEnumerable<GitHubIssue> LastestIssues { get; private set; }

        public bool HasIssue => LastestIssues.Any();

        public bool GetIssuesError { get; private set; }

        public TypedClientModel(GitHubService gitHubService)
        {
            _gitHubService = gitHubService;
        }

        public async Task OnGet()
        {
            try
            {
                LastestIssues = await _gitHubService.GetAspNetDocsIssues();
            }
            catch(HttpRequestException)
            {
                GetIssuesError = true;
                LastestIssues = Array.Empty<GitHubIssue>();
            }            
        }
    }
    #endregion
}