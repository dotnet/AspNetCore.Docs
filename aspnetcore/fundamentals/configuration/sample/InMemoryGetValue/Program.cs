using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

public class Program
{   
    public static IConfigurationRoot Configuration { get; set; }

    public static void Main(string[] args = null)
    {
        var dict = new Dictionary<string, string>
            {
                {"Profile:MachineName", "Rick"},
                {"App:MainWindow:Height", "11"},
                {"App:MainWindow:Width", "11"},
                {"App:MainWindow:Top", "11"},
                {"App:MainWindow:Left", "11"}
            };

        var builder = new ConfigurationBuilder();
        builder.AddInMemoryCollection(dict);

        Configuration = builder.Build();

        Console.WriteLine($"Hello {Configuration["Profile:MachineName"]}");

        // Show GetValue overload and set the default value to 80
        // Requires NuGet package "Microsoft.Extensions.Configuration.Binder"
        var left = Configuration.GetValue<int>("App:MainWindow:Left", 80);
        Console.WriteLine($"Left {left}");

        var window = new MyWindow();
        Configuration.GetSection("App:MainWindow").Bind(window);
        Console.WriteLine($"Left {window.Left}");
        Console.WriteLine();

        Console.WriteLine("Press a key...");
        Console.ReadKey();
    }
}