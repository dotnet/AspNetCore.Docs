using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TodoApi.Pages
{
    #region snippet_CallLogMethods
    public class AboutModel : PageModel
    {
        private readonly ILogger _logger;

        public AboutModel(ILogger<AboutModel> logger)
        {
            _logger = logger;
        }

        public string? Message { get; set; }

        public void OnGet()
        {
            Message = "About page visited at {DT}";
            _logger.LogInformation(Message, DateTime.UtcNow.ToLongTimeString());
        }
    }
    #endregion
}
