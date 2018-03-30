using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace PageFilter.Pages
{
    public class AboutModel : PageModel
    {
        private readonly ILogger _logger;

        public AboutModel(ILogger<AboutModel> logger)
        {
            _logger = logger;
        }

        [BindProperty]
        [Required]
        public InputModel Input { get; set; }

        public class InputModel
        {
            public string Name { get; set; }
            public string Message { get; set; }
        }

        public string Query { get; set; }

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
