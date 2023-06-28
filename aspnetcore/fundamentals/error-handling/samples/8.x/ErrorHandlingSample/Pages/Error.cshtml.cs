using System.Diagnostics;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ErrorHandlingSample.Pages;

// <snippet_Class>
[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
[IgnoreAntiforgeryToken]
public class ErrorModel : PageModel
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

    public string? ExceptionMessage { get; set; }

    public void OnGet()
    {
        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;

        var exceptionHandlerPathFeature =
            HttpContext.Features.Get<IExceptionHandlerPathFeature>();

        if (exceptionHandlerPathFeature?.Error is FileNotFoundException)
        {
            ExceptionMessage = "The file was not found.";
        }

        if (exceptionHandlerPathFeature?.Path == "/")
        {
            ExceptionMessage ??= string.Empty;
            ExceptionMessage += " Page: Home.";
        }
    }
}
// </snippet_Class>
