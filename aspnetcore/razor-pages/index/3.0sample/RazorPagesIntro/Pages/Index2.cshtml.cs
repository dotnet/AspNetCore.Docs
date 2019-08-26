using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;

namespace RazorPagesIntro.Pages
{
    public class Index2Model : PageModel
    {
        private readonly ILogger<Index2Model> _logger;
        public string Message { get; private set; } = "PageModel in C#";

        public Index2Model(ILogger<Index2Model> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Message += $" Server time is { DateTime.Now }";
        }
    }
}
