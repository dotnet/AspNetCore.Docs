using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace RazorPagesContacts.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }

        #region snippet
        public void OnHead()
        {
            HttpContext.Response.Headers.Add("Head Test", "Handled by OnHead!");
        }
        #endregion
    }
}
