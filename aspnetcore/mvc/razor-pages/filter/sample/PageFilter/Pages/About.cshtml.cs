using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace PageFilter.Pages
{
    public class AboutModel : PageModel
    {
        private readonly ILogger _logger;

        public AboutModel(ILogger<AboutModel> logger)
        {
            _logger = logger;
        }

        public string Message { get; set; }

        public void OnGet()
        {
            Message = "Your application description page.";
            _logger.LogDebug("About/OnGet");
        }

        public void OnPost()
        {
            _logger.LogDebug("About/OnPost");
        }
    }
}
