namespace AuthorizationPoliciesSample.Controllers;

#region snippet_noNamespace
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize(Policy = "AtLeast21")]
public class AgeRestrictedController : Controller
{
    public IActionResult Index() => View();
}
#endregion
