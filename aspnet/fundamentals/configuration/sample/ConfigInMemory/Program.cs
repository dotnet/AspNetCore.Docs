using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

// Add NuGet  <package id="Microsoft.Extensions.Configuration"
public class Program
{
    static IReadOnlyDictionary<string, string> ConfigStrings { get; } =
      new Dictionary<string, string>()
      {
          ["Profile:UserName"] = Environment.UserName,
          [$"AppConfig:MyconfigString"] = "Sample config string.",
          [$"AppConfig:MainWindow:Height"] = "400",
      };
    static public IConfiguration Configuration { get; set; }
    public static void Main(string[] args = null)
    {
        ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddInMemoryCollection(ConfigStrings);
        Configuration = configurationBuilder.Build();

        Console.WriteLine($"Hello  {Configuration["Profile:UserName"]}");
        Console.WriteLine(
          $"My config string: {Configuration["AppConfig:MyconfigString"]}");
        Console.WriteLine(
          $"Window Height: {Configuration["AppConfig:MainWindow:Height"]}");
    }
}