using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

// Test with ProgramJSONsection.cs

namespace ConfigSample
{
// <snippet>
    public class TestSection4Model : PageModel
    {
        private readonly IConfiguration Config;

        public TestSection4Model(IConfiguration configuration)
        {
            Config = configuration;
        }

        public ContentResult OnGet()
        {
            string s = "";
            var selection = Config.GetSection("section2");
            if (!selection.Exists())
            {
                throw new Exception("section2 does not exist.");
            }
            var children = selection.GetChildren();

            foreach (var subSection in children)
            {
                int i = 0;
                var key1 = subSection.Key + ":key" + i++.ToString();
                var key2 = subSection.Key + ":key" + i.ToString();
                s += key1 + " value: " + selection[key1] + "\n";
                s += key2 + " value: " + selection[key2] + "\n";
            }
            return Content(s);
        }
    }
// </snippet>
}
