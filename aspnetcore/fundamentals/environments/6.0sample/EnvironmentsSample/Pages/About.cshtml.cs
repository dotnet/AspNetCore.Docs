using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace EnvironmentsSample.Pages
{
    public class AboutModel : PageModel
    {
        public string? Message { get; set; }

        public void OnGet()
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            Message = $"ASPNETCORE_ENVIRONMENT = {env}";
        }
    }
}
