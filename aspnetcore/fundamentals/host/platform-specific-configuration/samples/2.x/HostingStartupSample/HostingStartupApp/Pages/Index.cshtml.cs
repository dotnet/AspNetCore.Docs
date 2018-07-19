using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace HostingStartupApp.Pages
{
    #region snippet1
    public class IndexModel : PageModel
    {
        public IndexModel(IConfiguration config)
        {
            ServiceKey_Development = config["DevAccount"];
            ServiceKey_Production = config["ProdAccount"];
        }

        public string ServiceKey_Development { get; private set; }
        public string ServiceKey_Production { get; private set; }

        public void OnGet()
        {
        }
    }
    #endregion
}
