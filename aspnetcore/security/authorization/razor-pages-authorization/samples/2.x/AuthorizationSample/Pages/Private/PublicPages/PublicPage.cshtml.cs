using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AuthorizationSample.Pages.Private.Public
{
    public class PublicPageModel : PageModel
    {
        public string Message { get; private set; }

        public void OnGet()
        {
            Message = "A public page inside a PublicPages folder inside the Private folder.";
        }
    }
}
