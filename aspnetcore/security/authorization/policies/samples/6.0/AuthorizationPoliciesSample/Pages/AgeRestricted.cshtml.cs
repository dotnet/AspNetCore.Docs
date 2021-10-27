namespace AuthorizationPoliciesSample.Pages;

#region snippet_noNamespace
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

[Authorize(Policy = "AtLeast21")]
public class AgeRestrictedModel : PageModel { }
#endregion
