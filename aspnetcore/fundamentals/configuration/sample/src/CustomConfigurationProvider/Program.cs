using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CustomConfigurationProvider;

public static class Program
{
    public static void Main()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

        var connectionStringConfig = builder.Build();

        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            // Add "appsettings.json" to bootstrap EF config.
            .AddJsonFile("appsettings.json")
            // Add the EF configuration provider, which will override any
            // config made with the JSON provider.
            .AddEntityFrameworkConfig(options =>
                options.UseSqlServer(connectionStringConfig.GetConnectionString(
                    "DefaultConnection"))
            )
            .Build();

        Console.WriteLine("key1={0}", config["key1"]);
        Console.WriteLine("key2={0}", config["key2"]);
        Console.WriteLine("key3={0}", config["key3"]);
        Console.WriteLine();

        Console.WriteLine("Press a key...");
        Console.ReadKey();
    }
}
