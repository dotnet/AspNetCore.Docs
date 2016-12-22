using Microsoft.Extensions.Configuration;
using System;
using System.IO;

// Add NuGet <package id="Microsoft.Extensions.Configuration" and
// <package id="Microsoft.Extensions.Configuration.Json"
// .NET Framework 4.x use the following path:
//.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), @"..\.."))

public class Program
{
    static public IConfigurationRoot Configuration { get; set; }
    public static void Main(string[] args = null)
    {
        var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

        Configuration = builder.Build();

        Console.WriteLine($"option1 = {Configuration["option1"]}");
        Console.WriteLine($"option2 = {Configuration["option2"]}");
        Console.WriteLine(
            $"option1 = {Configuration["subsection:suboption1"]}");
    }
}