using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;

public class Program
{
    public static IConfigurationRoot Configuration { get; set; }

    public static void Main(string[] args = null)
    {
        var dict = new Dictionary<string, string>
            {
                {"Profile:MachineName", "MairaPC"},
                {"App:MainWindow:Left", "1980"}
            };

        var builder = new ConfigurationBuilder();

        builder.AddInMemoryCollection(dict)
            .AddCommandLine(args);

        Configuration = builder.Build();

        Console.WriteLine($"MachineName: {Configuration["Profile:MachineName"]}");
        Console.WriteLine($"Left: {Configuration["App:MainWindow:Left"]}");
        Console.WriteLine();

        Console.WriteLine("Press a key...");
        Console.ReadKey();
    }
}
