using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RPareas.Areas.Services.Pages.Manage
{
    public class AboutModel : PageModel
    {
        public void OnGet()
        {
            ViewData["routeInfo"] = PageContext.ToCtxStringP();
        }
    }
}