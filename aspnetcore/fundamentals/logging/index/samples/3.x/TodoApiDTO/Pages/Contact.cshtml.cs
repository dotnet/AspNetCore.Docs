using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace TodoApi.Pages
{
    public class ContactModel : PageModel
    {
        private readonly ILogger _logger;

        public ContactModel(ILoggerFactory logger)
        {
            _logger = logger.CreateLogger("TodoApi.Pages.ContactModel");
        }

        public void OnGet()
        {
            _logger.LogInformation("GET Pages.ContactModel called.");
        }
    }
}