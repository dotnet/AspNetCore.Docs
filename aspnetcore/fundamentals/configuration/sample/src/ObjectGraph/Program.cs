using Microsoft.Extensions.Configuration;
using System;
using System.IO;

// Add these NuGet packages:
// "Microsoft.Extensions.Configuration.Binder"
// "Microsoft.Extensions.Configuration.FileExtensions"
// "Microsoft.Extensions.Configuration.Json": 
public class Program
{
    public static void Main(string[] args = null)
    {
        var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json");

        var config = builder.Build();

        var appConfig = new AppOptions();
        config.GetSection("App").Bind(appConfig);

        Console.WriteLine($"Height {appConfig.Window.Height}");
    }
}
