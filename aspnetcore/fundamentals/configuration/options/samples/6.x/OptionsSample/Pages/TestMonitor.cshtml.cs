using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using SampleApp.Models;

// Requires Startup3 in Main

namespace SampleApp.Pages
{
    // <snippet>
    public class TestMonitorModel : PageModel
    {
        private readonly IOptionsMonitor<MyOptions> _optionsDelegate;

        public TestMonitorModel(IOptionsMonitor<MyOptions> optionsDelegate )
        {
            _optionsDelegate = optionsDelegate;
        }

        public ContentResult OnGet()
        {
            return Content($"Option1: {_optionsDelegate.CurrentValue.Option1} \n" +
                           $"Option2: {_optionsDelegate.CurrentValue.Option2}");
        }
    }
    // </snippet>
}
