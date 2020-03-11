using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

// Test with ProgramJSONsection.cs

namespace ConfigSample
{
    #region snippet
    public class TestSection3Model : PageModel
    {
        private readonly IConfiguration Config;

        public TestSection3Model(IConfiguration configuration)
        {
            Config = configuration;
        }

        public ContentResult OnGet()
        {
            string s = null;
            var children = Config.GetSection("section2").GetChildren();

            foreach (var subSection in children)
            {
                int i = 0;
                var key1 = subSection.Path + ":key" + i++.ToString();
                var key2 = subSection.Path + ":key" + i.ToString();
                s += key1 + " value: " + Config[key1] + "\n";
                s += key2 + " value: " + Config[key2] + "\n";
            }
            return Content(s);
        }
    }
    #endregion
}

/* 
 * Does the same thing as the following code;
 * 
           var configSection = Config.GetSection("section2");
            return Content(
                    $"section2:subsection0:key0: '{configSection["subsection0:key0"]}'\n" +
                    $"section2:subsection0:key1: '{configSection["subsection0:key1"]}'\n" + 
                    $"section2:subsection1:key0: '{configSection["subsection1:key0"]}'\n" +
                    $"section2:subsection1:key1: '{configSection["subsection1:key1"]}'");
*/