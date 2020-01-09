using Microsoft.AspNetCore.Mvc.RazorPages;
using PageFilter.Filters;

namespace PageFilter.Movies
{
    [AddHeader("Author", "Rick")]
    public class TestModel : PageModel
    {
        public void OnGet()
        {

        }
    }
}