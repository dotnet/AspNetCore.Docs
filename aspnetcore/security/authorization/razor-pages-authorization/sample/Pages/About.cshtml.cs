using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AuthorizationSample.Pages
{
    public class AboutModel : PageModel
    {
        public string Message { get; private set; }

        public string RouteDataText { get; private set; }

        public void OnGet()
        {
            Message = "Your application description page.";
        }
    }
}
