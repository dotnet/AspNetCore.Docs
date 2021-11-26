using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ErrorHandlingSample.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        // <snippet>
        public void OnGet()
        {
            // using Microsoft.AspNetCore.Diagnostics;
            var statusCodePagesFeature = HttpContext.Features.Get<IStatusCodePagesFeature>();

            if (statusCodePagesFeature != null)
            {
                statusCodePagesFeature.Enabled = false;
            }
        }
        // </snippet>
    }
}
