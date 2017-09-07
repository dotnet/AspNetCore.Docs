using System;
using System.IO;
using Microsoft.Extensions.Configuration;

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
        Console.WriteLine();

        Console.WriteLine("Press a key...");
        Console.ReadKey();
    }
}
