using HttpRequestsSample.GitHub;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HttpRequestsSample.Pages;

// <snippet_Class>
public class TypedClientModel : PageModel
{
    private readonly GitHubService _gitHubService;

    public TypedClientModel(GitHubService gitHubService) =>
        _gitHubService = gitHubService;

    public IEnumerable<GitHubBranch>? GitHubBranches { get; set; }

    public async Task OnGet()
    {
        try
        {
            GitHubBranches = await _gitHubService.GetAspNetCoreDocsBranchesAsync();
        }
        catch (HttpRequestException)
        {
            // ...
        }
    }
}
// </snippet_Class>
