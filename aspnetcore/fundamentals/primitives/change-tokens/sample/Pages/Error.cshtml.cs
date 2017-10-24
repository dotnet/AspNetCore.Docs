using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChangeTokenSample.Pages
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
