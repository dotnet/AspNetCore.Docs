using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebApplication22.Pages
{
    #region snippet
    [TypeFilter(typeof(AuthorizeIndexPageHandlerFilter))]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public void OnPost()
        {

        }

        [AuthorizePageHandler]
        public void OnPostAuthorized()
        {

        }
    }
    #endregion
}
