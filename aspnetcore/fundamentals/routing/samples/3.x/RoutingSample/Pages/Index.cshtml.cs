using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RoutingSample.Pages
{
    // <snippet>
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            var url = Url.Page("./Edit", new { id = 17, });
            ViewData["URL"] = url;
        }
    }
    // </snippet>
}
