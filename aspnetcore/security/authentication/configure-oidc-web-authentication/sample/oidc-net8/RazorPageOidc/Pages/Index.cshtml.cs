using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageOidc.Pages;

[Authorize]
public class IndexModel : PageModel
{
    public void OnGet()
    {
    }
}
