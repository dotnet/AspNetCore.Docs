using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace TodoApi.Pages
{
    #region snippet
    public class ContactModel : PageModel
    {
        private readonly ILogger _logger;

        public ContactModel(ILoggerFactory logger)
        {
            _logger = logger.CreateLogger("MyCategory");
        }

        public void OnGet()
        {
            _logger.LogInformation("GET Pages.ContactModel called.");
        }
        #endregion
    }
}