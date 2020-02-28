using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace ConfigSample
{
    public class TestModel : PageModel
    {
        private readonly IConfiguration Configuration;

        public TestModel(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public ContentResult OnGet()
        {
            var myKeyValue = Configuration["MyKey"];
            var title = Configuration["Position:Title"];
            var name = Configuration["Position:Name"];


            return Content($"MyKey value: {myKeyValue}" +
                           $" Title: {title}" +
                           $" Name: {name}");
        }
    }
}