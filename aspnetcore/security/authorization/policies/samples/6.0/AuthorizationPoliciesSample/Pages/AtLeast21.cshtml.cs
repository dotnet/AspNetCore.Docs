using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AuthorizationPoliciesSample.Pages;

[Authorize(Policy = "AtLeast21")]
public class AtLeast21Model : PageModel { }
