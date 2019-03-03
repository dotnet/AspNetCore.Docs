using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ResponseCacheSample.Pages
{
    #region snippet
    [ResponseCache(CacheProfileName = "Default30")]
    public class Cache4Model : PageModel
    {
    #endregion
        public void OnGet()
        {
        }
    }
}
