using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

// Test with ProgramJSONsection.cs

namespace ConfigSample
{
    #region snippet
    public class TestSection2Model : PageModel
    {
        private readonly IConfiguration Config;

        public TestSection2Model(IConfiguration configuration)
        {
            Config = configuration.GetSection("section2:subsection0");
        }

        public ContentResult OnGet()
        {
            return Content(
                    $"section2:subsection0:key0 '{Config["key0"]}'\n" +
                    $"section2:subsection0:key1:'{Config["key1"]}'");
        }
    }
    #endregion
}