using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ErrorHandlingSample.Pages;

// <snippet_Class>
[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
public class StatusCodeModel : PageModel
{
    public int OriginalStatusCode { get; set; }

    public string? OriginalPathAndQuery { get; set; }

    public void OnGet(int statusCode)
    {
        OriginalStatusCode = statusCode;

        var statusCodeReExecuteFeature =
            HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

        if (statusCodeReExecuteFeature is not null)
        {
            OriginalPathAndQuery = string.Join(
                statusCodeReExecuteFeature.OriginalPathBase,
                statusCodeReExecuteFeature.OriginalPath,
                statusCodeReExecuteFeature.OriginalQueryString);
        }
    }
}
// </snippet_Class>
