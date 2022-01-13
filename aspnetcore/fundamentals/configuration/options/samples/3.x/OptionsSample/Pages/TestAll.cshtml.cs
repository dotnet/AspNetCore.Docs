using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

// Requires StartupAll in Main
// TODO remove, doesn't work correctly and not in doc

namespace SampleApp.Pages
{
    // <snippet>
    public class TestAllModel : PageModel
    {
        private readonly IConfiguration Configuration;

        public TestAllModel(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public ContentResult OnGet()
        {
            var myOpts = new TopItemSettings();
            Configuration.GetSection("TopItem:Month").Bind(myOpts);

            return Content($"TopItem:Month:Model: { myOpts.Model} \n" +
                           $"TopItem:Month.Name :{ myOpts.Name}");
        }
    }
    // </snippet>
}
