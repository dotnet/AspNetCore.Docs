using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesApp.Pages
{
    public class ContactModel2 : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            Message = "From Web app";
        }
    }
}
