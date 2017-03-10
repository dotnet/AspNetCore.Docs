using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

// Add NuGet  <package id="Microsoft.Extensions.Configuration.Binder"

public class MyWindow
{
    public int Height { get; set; }
    public int Width { get; set; }
    public int Top { get; set; }
    public int Left { get; set; }

}

public class Program
{
    static IReadOnlyDictionary<string, string> DefaultConfigurationStrings { get; } =
      new Dictionary<string, string>()
      {
          ["Profile:UserName"] = Environment.UserName,
          ["AppConfiguration:MainWindow:Height"] = "400",
          ["AppConfiguration:MainWindow:Width"] = "600",
          ["AppConfiguration:MainWindow:Top"] = "5",
          ["AppConfiguration:MainWindow:Left"] = "11",
      };
    public static IConfiguration Configuration { get; set; }
    public static void Main(string[] args = null)
    {
        var builder = new ConfigurationBuilder();
        builder.AddInMemoryCollection(DefaultConfigurationStrings);
        Configuration = builder.Build();
        Console.WriteLine($"Hello {Configuration["Profile:UserName"]}");

        // Set the default value to 80
        var left = Configuration.GetValue<int>("AppConfiguration:MainWindow:Left", 80);
        Console.WriteLine($"Left {left}");

        var window = new MyWindow();
        Configuration.GetSection("AppConfiguration:MainWindow").Bind(window);
        Configuration.GetValue<MyWindow>("AppConfiguration:MainWindow");
        Console.WriteLine($"Left {window.Left}");
    }
}
