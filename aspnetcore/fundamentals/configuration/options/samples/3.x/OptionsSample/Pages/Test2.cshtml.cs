using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using SampleApp.Models;

// Requires Startup2 in Main

namespace SampleApp.Pages
{
    #region snippet
    public class Test2Model : PageModel
    {
        private readonly MyOptions _optionsDelegate;

        public Test2Model(IOptionsMonitor<MyOptions> optionsDelegate )
        {
            _optionsDelegate = optionsDelegate.CurrentValue;
        }

        public ContentResult OnGet()
        {
            return Content($"Option1: {_optionsDelegate.Option1} \n" +
                           $"Option2: {_optionsDelegate.Option2}");
        }
    }
    #endregion
}