using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Docs.Samples;

namespace RPareas.Areas.Services.Pages.Manage;

public class IndexModel : PageModel
{
    public ContentResult OnGet() =>
     Content(PageContext.MyDisplayRouteInfoRP().ToString()!);
}
