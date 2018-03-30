using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace PageFilter.Pages
{
    public class About2Model : PageModel
    {
        private readonly ILogger _logger;

        public About2Model(ILogger<About2Model> logger)
        {
            _logger = logger;
        }

        public string Message { get; set; }

        public void OnGet()
        {
            Message = "Your application description page.";
            _logger.LogDebug("About2/OnGet");
        }

        public void OnPost()
        {
            _logger.LogDebug("About2/OnPost");
        }
    }
}
