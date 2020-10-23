using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebSameSite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            #region snippet
            HttpContext.Response.Cookies.Append(
                                 "name", "value",
                                 new CookieOptions() { SameSite = SameSiteMode.Lax });
            #endregion
        }
    }
}
