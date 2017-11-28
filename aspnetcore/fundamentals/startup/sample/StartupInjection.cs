using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

#region snippet1
[assembly: HostingStartup(typeof(HostingStartupSample.StartupInjection))]

namespace HostingStartupSample
{
    public class StartupInjection : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            Console.WriteLine("StartupInjection.Configure");

            builder.ConfigureServices(services =>
            {
                services.Configure<InjectedOptions>(options =>
                {
                    options.Option1 = "Option 1 Value";
                    options.Option2 = "Option 2 Value";
                });
            });
        }
    }

    public class InjectedOptions
    {
        public string Option1 { get; set; } = "Option 1 Default Value";
        public string Option2 { get; set; } = "Option 2 Default Value";
    }
}
#endregion
