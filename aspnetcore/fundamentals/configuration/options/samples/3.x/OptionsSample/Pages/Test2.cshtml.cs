using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using SampleApp.Models;

// Requires Startup2 in Main, overridden by delegate.
// Used in fundamentals\configuration\index.md, not the Options topic

namespace SampleApp.Pages
{
    // <snippet>
    public class Test2Model : PageModel
    {
        private readonly IOptions<MyOptions> _optionsDelegate;

        public Test2Model(IOptions<MyOptions> optionsDelegate )
        {
            _optionsDelegate = optionsDelegate;
        }

        public ContentResult OnGet()
        {
            return Content($"Option1: {_optionsDelegate.Value.Option1} \n" +
                           $"Option2: {_optionsDelegate.Value.Option2}");
        }
    }
    // </snippet>
}
