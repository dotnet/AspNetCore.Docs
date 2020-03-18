using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAPI
{
    public class IndexModel : PageModel
    {
        public ContentResult OnGet()
        {
            return Content("IndexModel");
        }
    }
}