using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace HostingStartupSample.Pages
{
    #region snippet1
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _config;

        public IndexModel(IConfiguration config)
        {
            _config = config;
        }

        public string[] LoadedHostingStartupAssemblies { get; private set; }

        public void OnGet()
        {
            LoadedHostingStartupAssemblies = 
                _config[WebHostDefaults.HostingStartupAssembliesKey]
                .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries) ?? new string[0];
        }
    }
    #endregion
}
