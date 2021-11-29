using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ErrorHandlingSample.Snippets.Pages;

public class IndexModel : PageModel
{
    // <snippet_OnGet>
    public void OnGet()
    {
        var statusCodePagesFeature =
            HttpContext.Features.Get<IStatusCodePagesFeature>();

        if (statusCodePagesFeature is not null)
        {
            statusCodePagesFeature.Enabled = false;
        }
    }
    // </snippet_OnGet>
}
