using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

// Add NuGet  <package id="Microsoft.Extensions.Configuration.Binder"
// Add NuGet  <package id="Microsoft.Extensions.Configuration.CommandLine"
public class Program
{
    public static IConfigurationRoot Configuration { get; set; }

    public static Dictionary<string, string> GetSwitchMappings(
    IReadOnlyDictionary<string, string> configurationStrings)
    {
        return configurationStrings.Select(item =>
            new KeyValuePair<string, string>(
                "-" + item.Key.Substring(item.Key.LastIndexOf(':') + 1),
                item.Key))
                .ToDictionary(
                    item => item.Key, item => item.Value);
    }
    public static void Main(string[] args = null)
    {
        var dict = new Dictionary<string, string>
            {
                {"Profile:MachineName", "Rick"},
                {"App:MainWindow:Left", "11"}
            };

        var builder = new ConfigurationBuilder();
        builder.AddInMemoryCollection(dict)
              .AddCommandLine(args, GetSwitchMappings(dict));
        Configuration = builder.Build();
        Console.WriteLine($"Hello {Configuration["Profile:MachineName"]}");

        // Set the default value to 80
        var left = Configuration.GetValue<int>("App:MainWindow:Left", 80);
        Console.WriteLine($"Left {left}");
    }
}
