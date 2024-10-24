using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageOidcClient.Pages;

[Authorize]
public class IndexModel : PageModel
{
    public void OnGet()
    {
    }
}
