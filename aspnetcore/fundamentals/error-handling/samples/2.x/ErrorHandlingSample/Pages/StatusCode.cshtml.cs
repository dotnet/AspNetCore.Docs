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
using Microsoft.Extensions.Logging;

namespace ErrorHandlingSample.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class StatusCodeModel : PageModel
    {
        private readonly ILogger _logger;

        public string RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public string ErrorStatusCode { get; set; }

        public string OriginalURL { get; set; }
        public bool ShowOriginalURL => !string.IsNullOrEmpty(OriginalURL);

        public StatusCodeModel(ILogger<StatusCodeModel> logger)
        {
            _logger = logger;
        }
        public void OnGet(string code)
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            ErrorStatusCode = code;

            // <snippet_StatusCodeReExecute>
            var statusCodeReExecuteFeature = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            if (statusCodeReExecuteFeature != null)
            {
                OriginalURL =
                    statusCodeReExecuteFeature.OriginalPathBase
                    + statusCodeReExecuteFeature.OriginalPath
                    + statusCodeReExecuteFeature.OriginalQueryString;
            }
            // </snippet_StatusCodeReExecute>
        }
    }
}
