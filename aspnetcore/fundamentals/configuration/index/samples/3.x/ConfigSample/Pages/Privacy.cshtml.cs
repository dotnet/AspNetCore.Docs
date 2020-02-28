using ConfigSample.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace ConfigSample.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly PositionOptions _options;

        public PrivacyModel(IOptions<PositionOptions> options)
        {
            _options = options.Value;
        }

        public ContentResult OnGet()
        {
            return Content($"Title: {_options.Title}" +
                           $" Name: {_options.Name}");
        }
    }
}
