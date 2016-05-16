using System.IO;
using DependencyInjectionSample;
using Microsoft.AspNetCore.Hosting;

public static class Program
{
    public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
}