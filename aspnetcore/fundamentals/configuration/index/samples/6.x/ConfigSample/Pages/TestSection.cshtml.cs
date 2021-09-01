using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

// Test with ProgramJSONsection.cs

namespace ConfigSample
{
    #region snippet
    public class TestSectionModel : PageModel
    {
        private readonly IConfiguration Config;

        public TestSectionModel(IConfiguration configuration)
        {
            Config = configuration.GetSection("section1");
        }

        public ContentResult OnGet()
        {
            return Content(
                    $"section1:key0: '{Config["key0"]}'\n" +
                    $"section1:key1: '{Config["key1"]}'");
        }
    }
    #endregion
}