using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

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

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                // To scan the assembly for HostingStartupAttributes, the
                // ApplicationName must be set. This can be done with
                // UseSetting, Configure, or UseStartup.
                // .UseSetting(HostDefaults.ApplicationKey, "HostingStartupApp")
                // .Configure(_ => { })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
