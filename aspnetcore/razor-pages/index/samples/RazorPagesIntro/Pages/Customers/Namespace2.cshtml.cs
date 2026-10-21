using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace RazorPagesIntro.Pages.Customers
{
    public class NameSpaceModel : PageModel
    {
        public string Message { get; private set; } = "";

        public void OnGet()
        {
            Message += $" Server time is { DateTime.Now }";
        }
    }
}

// docFX won't allow a filename namespace.cshtml