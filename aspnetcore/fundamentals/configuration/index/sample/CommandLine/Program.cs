using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;

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
                {"Profile:MachineName", "RickPC"},
                {"App:MainWindow:Left", "1980"}
            };

        var builder = new ConfigurationBuilder();

        builder.AddInMemoryCollection(dict)
            .AddCommandLine(args, GetSwitchMappings(dict));

        Configuration = builder.Build();

        Console.WriteLine($"MachineName: {Configuration["Profile:MachineName"]}");
        Console.WriteLine($"Left: {Configuration["App:MainWindow:Left"]}");
        Console.WriteLine();

        Console.WriteLine("Press a key...");
        Console.ReadKey();
    }
}
