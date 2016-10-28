using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace StaticFiles
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .AddCommandLine(args)
                .AddEnvironmentVariables();

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup(typeof(Program).GetTypeInfo().Assembly.GetName().Name)
                .UseConfiguration(builder.Build())
                .Build();

            host.Run();
        }
    }
}
