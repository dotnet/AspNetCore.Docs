using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAPI
{
    public class Test2Model : PageModel
    {
        public ContentResult OnGet()
        {
            return Content("Test2Model");
        }
    }
}