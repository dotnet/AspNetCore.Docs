using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

// Key/value  set in appsettings.Development.json

namespace ConfigSample
{
// <snippet>
    public class TestNumModel : PageModel
    {
        private readonly IConfiguration Configuration;

        public TestNumModel(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public ContentResult OnGet()
        {
            var number = Configuration.GetValue<int>("NumberKey", 99);
            return Content($"{number}");
        }
    }
// </snippet>
}
