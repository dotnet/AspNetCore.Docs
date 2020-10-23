using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace ConfigSample.Pages
{
    public class IndexModel : PageModel
    {
        private IConfigurationRoot ConfigRoot;

        public IndexModel(IConfiguration configRoot)
        {
            ConfigRoot = (IConfigurationRoot)configRoot;
        }

        public void OnGet()
        {
            string str = "";
            foreach (var provider in ConfigRoot.Providers.ToList())
            {
                str += provider.ToString() + "\n";
            }

            ViewData["configProviders"] = str;
        }
    }
}
