using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace HostingStartupSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                // To scan the assembly for HostingStartupAttributes, the
                // ApplicationName must be set. This can be done with
                // UseSetting, Configure, or UseStartup.
                // .UseSetting(WebHostDefaults.ApplicationKey, "HostingStartupSample")
                // .Configure(_ => { })
                .UseStartup<Startup>()
                .Build();
    }
}
