using HttpRequestsSample.GitHub;
using Microsoft.AspNetCore.Mvc;

namespace HttpRequestsSample.ViewComponents;

public class GitHubBranchesViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(IEnumerable<GitHubBranch>? gitHubBranches) =>
        View(gitHubBranches);
}
