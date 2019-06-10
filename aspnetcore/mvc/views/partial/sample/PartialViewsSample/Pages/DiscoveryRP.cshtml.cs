using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PartialViewsSample.Pages
{
    public class DiscoveryModel : PageModel
    {
        public void OnGet() => Page();

        public IActionResult OnGetPartial()
        {
            return new PartialViewResult
            {
                ViewName = "_AuthorPartialRP",
                ViewData = ViewData,
            };
        }
    }
}
