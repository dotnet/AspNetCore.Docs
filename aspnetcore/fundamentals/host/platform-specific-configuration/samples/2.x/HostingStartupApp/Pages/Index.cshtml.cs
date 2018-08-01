using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace HostingStartupApp.Pages
{
    #region snippet1
    public class IndexModel : PageModel
    {
        public IndexModel(IConfiguration config)
        {
            ServiceKey_Development_Library = config["DevAccount_FromLibrary"];
            ServiceKey_Production_Library = config["ProdAccount_FromLibrary"];
            ServiceKey_Development_Package = config["DevAccount_FromPackage"];
            ServiceKey_Production_Package = config["ProdAccount_FromPackage"];
        }

        public string ServiceKey_Development_Library { get; private set; }
        public string ServiceKey_Production_Library { get; private set; }
        public string ServiceKey_Development_Package { get; private set; }
        public string ServiceKey_Production_Package { get; private set; }

        public void OnGet()
        {
        }
    }
    #endregion
}
