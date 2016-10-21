using Microsoft.Extensions.Configuration;
using System;
using System.IO;

// Add NuGet <package id="Microsoft.Extensions.Configuration" and
// <package id="Microsoft.Extensions.Configuration.Json"
public class Program
{
    static public IConfigurationRoot Configuration { get; set; }
    public static void Main(string[] args = null)
    {
        var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
            // .Net 4.X requires parent.parent directory.
            //.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), @"..\.."))
            .AddJsonFile("appsettings.json");

        Configuration = builder.Build();

        Console.WriteLine($"option1 = {Configuration["option1"]}");
        Console.WriteLine($"option2 = {Configuration["option2"]}");
        Console.WriteLine(
            $"option1 = {Configuration["subsection:suboption1"]}");
    }
}