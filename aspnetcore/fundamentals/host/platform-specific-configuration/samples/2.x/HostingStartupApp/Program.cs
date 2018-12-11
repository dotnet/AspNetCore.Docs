using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace HostingStartupApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("ASPNETCORE_HOSTINGSTARTUPASSEMBLIES: " +
                Environment.GetEnvironmentVariable("ASPNETCORE_HOSTINGSTARTUPASSEMBLIES"));
            Console.WriteLine("DOTNET_ADDITIONAL_DEPS: " +
                Environment.GetEnvironmentVariable("DOTNET_ADDITIONAL_DEPS"));

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                // To scan the assembly for HostingStartupAttributes, the
                // ApplicationName must be set. This can be done with
                // UseSetting, Configure, or UseStartup.
                // .UseSetting(WebHostDefaults.ApplicationKey, "HostingStartupApp")
                // .Configure(_ => { })
                .UseStartup<Startup>();
    }
}
