using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace PageFilter.Pages.subFolder
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
            _logger.LogDebug("subfolder/About/OnGet");
        }

        public void OnPost()
        {
            _logger.LogDebug("subfolder/About/OnPost");
        }
    }
}
