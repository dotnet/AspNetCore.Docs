using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ResponseCacheSample.Pages
{
    #region snippet
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class Cache2Model : PageModel
    {
    #endregion
        public void OnGet()
        {
        }
    }
}