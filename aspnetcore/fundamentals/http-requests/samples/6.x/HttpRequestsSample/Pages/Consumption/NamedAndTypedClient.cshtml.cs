using HttpRequestsSample.GitHub;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Http;

namespace HttpRequestsSample.Pages;

// <snippet_Class>
public class NamedAndTypedClientModel : PageModel
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ITypedHttpClientFactory<GitHubService> _gitHubServiceFactory;

    public NamedAndTypedClientModel(IHttpClientFactory httpClientFactory, 
        ITypedHttpClientFactory<GitHubService> gitHubServiceFactory)
    {
        _httpClientFactory = httpClientFactory;
        _gitHubServiceFactory = gitHubServiceFactory;
    }

    public IEnumerable<GitHubBranch>? GitHubBranches { get; set; }

    public async Task OnGet()
    {
        try
        {
            var quickClient = _httpClientFactory.CreateClient("Quick");
            var gitHubService = _gitHubServiceFactory.CreateClient(quickClient);
            GitHubBranches = await gitHubService.GetAspNetCoreDocsBranchesAsync();
        }
        catch (TaskCanceledException ex) when (ex.InnerException is TimeoutException)
        {
            var tolerantClient = _httpClientFactory.CreateClient("LatencyTolerant");
            var gitHubService = _gitHubServiceFactory.CreateClient(tolerantClient);
            GitHubBranches = await gitHubService.GetAspNetCoreDocsBranchesAsync();
        }
    }
}
// </snippet_Class>
