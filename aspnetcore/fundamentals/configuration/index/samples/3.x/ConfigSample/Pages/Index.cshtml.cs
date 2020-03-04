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
            var x = ConfigRoot.Providers.Select(x => x.GetType().Name);

            string cp = "";
            foreach (var y in x)
            {
                cp += y.ToString() + " ";
            }

            ViewData["configProviders"] = cp;
        }
    }
}
