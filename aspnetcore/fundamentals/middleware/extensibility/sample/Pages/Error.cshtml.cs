using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MiddlewareExtensibilitySample.Pages
{
    public class ErrorModel : PageModel
    {
        public string RequestId { get; private set; }
        
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public void Get()
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}
