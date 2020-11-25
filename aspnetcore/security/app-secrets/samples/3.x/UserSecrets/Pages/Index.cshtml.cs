using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace UserSecrets.Pages
{
    #region snippet_PageModel
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _config;

        public IndexModel(IConfiguration config)
        {
            _config = config;
        }

        public void OnGet()
        {
            var moviesApiKey = _config["Movies:ServiceApiKey"];

            // call Movies service with the API key
        }
    }
    #endregion snippet_PageModel
}
