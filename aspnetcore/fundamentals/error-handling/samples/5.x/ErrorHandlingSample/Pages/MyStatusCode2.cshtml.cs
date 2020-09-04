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
    #region snippet_StatusCodeReExecute
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class MyStatusCode2Model : PageModel
    {
        private readonly ILogger _logger;

        public string RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public string ErrorStatusCode { get; set; }

        public string OriginalURL { get; set; }
        public bool ShowOriginalURL => !string.IsNullOrEmpty(OriginalURL);

        public MyStatusCode2Model(ILogger<MyStatusCode2Model> logger)
        {
            _logger = logger;
        }

        public void OnGet(string code)
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            ErrorStatusCode = code;

            var statusCodeReExecuteFeature = HttpContext.Features.Get<
                                                   IStatusCodeReExecuteFeature>();
            if (statusCodeReExecuteFeature != null)
            {
                OriginalURL =
                    statusCodeReExecuteFeature.OriginalPathBase
                    + statusCodeReExecuteFeature.OriginalPath
                    + statusCodeReExecuteFeature.OriginalQueryString;
            }
        }
        #endregion
    }
}
