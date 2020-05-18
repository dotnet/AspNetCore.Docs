using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using SampleApp.Models;

// Requires StartupNO in Main

namespace SampleApp.Pages
{
    #region snippet
    public class TestNOModel : PageModel
    {
        private readonly MyOptions _snapshotOptions;

        public TestNOModel(IOptionsSnapshot<MyOptions> snapshotOptionsAccessor)
        {
            _snapshotOptions = snapshotOptionsAccessor.Value;
        }

        public ContentResult OnGet()
        {

            return Content($"Option1: {_snapshotOptions.Option1} \n" +
                           $"Option2: {_snapshotOptions.Option2}");
        }
    }
    #endregion
}