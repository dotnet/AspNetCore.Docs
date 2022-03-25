using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Docs.Samples;

namespace RPareas.Areas.Services.Pages.Manage
{
    public class AboutModel : PageModel
    {
        public void OnGet()
        {
            ViewData["routeInfo"] = PageContext.MyDisplayRouteInfoRP();
        }
    }
}
