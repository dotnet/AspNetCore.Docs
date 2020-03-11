using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

// Test with ProgramJSONsection.cs

namespace ConfigSample
{
    #region snippet
    public class TestSection4Model : PageModel
    {
        private readonly IConfiguration Config;

        public TestSection4Model(IConfiguration configuration)
        {
            Config = configuration;
        }

        public ContentResult OnGet()
        {
            string s = null;
            var selection = Config.GetSection("section2");
            var children = Config.GetSection("section2").GetChildren();

            foreach (var subSection in children)
            {
                int i = 0;
                var configSection = Config.GetSection("section2");
                var key1 = subSection.Key + ":key" + i++.ToString();
                var key2 = subSection.Key + ":key" + i.ToString();
                s += key1 + " value: " + configSection[key1] + "\n";
                s += key2 + " value: " + configSection[key2] + "\n";
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