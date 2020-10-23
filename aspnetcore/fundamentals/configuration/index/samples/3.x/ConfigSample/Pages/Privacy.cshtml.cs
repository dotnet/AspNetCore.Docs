using ConfigSample.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace ConfigSample.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly IConfiguration Config;

        public PrivacyModel(IConfiguration configuration)
        {
            Config = configuration;
        }

        public void OnGet()
        {
            var configProviders = Config.ToString();
            var x = Config.GetChildren();
            var z = x;
        }
    }
}
