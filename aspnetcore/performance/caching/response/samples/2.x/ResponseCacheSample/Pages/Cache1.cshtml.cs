using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ResponseCacheSample.Pages
{
    #region snippet
    [ResponseCache(VaryByHeader = "User-Agent", Duration = 30)]
    public class Cache1Model : PageModel
    {
    #endregion
        public void OnGet()
        {
        }
    }
}
