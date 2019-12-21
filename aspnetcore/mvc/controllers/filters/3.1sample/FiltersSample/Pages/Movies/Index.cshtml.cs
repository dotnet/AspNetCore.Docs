using FiltersSample.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FiltersSample.Pages.Movies
{
    #region snippet
    [AddHeader("Author", "Rick Anderson")]
    [ServiceFilter(typeof(MyActionFilterAttribute))]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
    #endregion
}
