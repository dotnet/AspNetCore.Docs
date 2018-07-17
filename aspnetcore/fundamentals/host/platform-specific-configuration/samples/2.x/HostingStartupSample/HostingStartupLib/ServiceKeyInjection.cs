using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace HostingStartupLib
{
    #region snippet1
    public class ServiceKeyInjection : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration(config =>
            {
                var dict = new Dictionary<string, string>
                {
                    {"DevAccount", "DEV_bebaf9e6-c623"},
                    {"ProdAccount", "PROD_18ae049f-88e1"}
                };

                config.AddInMemoryCollection(dict);
            });
        }
    }
    #endregion
}
