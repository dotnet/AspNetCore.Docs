using FiltersSample.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

// In Program.cs, call webBuilder.UseStartup<StartupRP>();

namespace FiltersSample.Pages.Movies
{
    // <snippet>
    [AddHeader("Author", "Rick Anderson")]
    [ServiceFilter(typeof(MyActionFilterAttribute))]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
    // </snippet>
}
