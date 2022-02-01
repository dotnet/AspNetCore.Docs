using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using SampleApp.Models;

// Requires Startup3 in Main

namespace SampleApp.Pages
{
    // <snippet>
    public class TestSnapModel : PageModel
    {
        private readonly MyOptions _snapshotOptions;

        public TestSnapModel(IOptionsSnapshot<MyOptions> snapshotOptionsAccessor)
        {
            _snapshotOptions = snapshotOptionsAccessor.Value;
        }

        public ContentResult OnGet()
        {
            return Content($"Option1: {_snapshotOptions.Option1} \n" +
                           $"Option2: {_snapshotOptions.Option2}");
        }
    }
    // </snippet>
}
