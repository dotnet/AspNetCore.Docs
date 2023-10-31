using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace ConfigSample
{
// <snippet>
    public class Test3Model : PageModel
    {
        private readonly IConfiguration Config;

        public Test3Model(IConfiguration configuration)
        {
            Config = configuration;
        }

        public ContentResult OnGet()
        {
            return Content(
                    $"Key1: '{Config["Key1"]}'\n" +
                    $"Key2: '{Config["Key2"]}'\n" +
                    $"Key3: '{Config["Key3"]}'\n" +
                    $"Key4: '{Config["Key4"]}'\n" +
                    $"Key5: '{Config["Key5"]}'\n" +
                    $"Key6: '{Config["Key6"]}'");
        }
    }
// </snippet>
}
