using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace RazorPages
{
    public class IndexModel2 : PageModel
    {
        public string Message { get; private set; } = "PageModel in C#";

        public void OnGet()
        {
            Message += $" Server time is { DateTime.Now }";
        }
    }
}

