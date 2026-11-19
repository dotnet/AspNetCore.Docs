using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Docs.Samples;

namespace RPareas.Pages;

public class AboutModel : PageModel
{
    public IActionResult OnGet() =>
            PageContext.MyDisplayRouteInfoRP();
}
