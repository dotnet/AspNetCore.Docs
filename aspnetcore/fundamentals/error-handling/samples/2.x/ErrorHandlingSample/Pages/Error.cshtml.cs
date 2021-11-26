using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ErrorHandlingSample.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class ErrorModel : PageModel
    {
        public string RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public string Referrer { get; set; }
        public bool ShowReferrer => !string.IsNullOrEmpty(Referrer);

        public string ExceptionMessage { get; set; }
        public bool ShowExceptionMessage => !string.IsNullOrEmpty(ExceptionMessage);

        public void OnGet()
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            Referrer = HttpContext.Request.Headers["referer"];

            // Do NOT expose sensitive error information directly to the client.
            var exceptionHandlerPathFeature =
                HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            if (exceptionHandlerPathFeature?.Error is FileNotFoundException)
            {
                ExceptionMessage = "File error thrown";
            }
            if (exceptionHandlerPathFeature?.Path == "/index")
            {
                ExceptionMessage += " from home page";
            }
        }
    }
}
