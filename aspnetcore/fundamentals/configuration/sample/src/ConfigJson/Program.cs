using Microsoft.Extensions.Configuration;
using System;
using System.IO;

// Add NuGet <package id="Microsoft.Extensions.Configuration" and
// <package id="Microsoft.Extensions.Configuration.Json"
// .NET Framework 4.x use the following path:
//.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), @"..\.."))

public class Program
{
    public static IConfigurationRoot Configuration { get; set; }
    public static void Main(string[] args = null)
    {
        var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

        Configuration = builder.Build();

        Console.WriteLine($"option1 = {Configuration["option1"]}");
        Console.WriteLine($"option2 = {Configuration["option2"]}");
        Console.WriteLine(
            $"suboption1 = {Configuration["subsection:suboption1"]}");
        Console.WriteLine();

        Console.WriteLine("Wizards:");
        Console.Write($"{Configuration["wizards:0:Name"]}, ");
        Console.WriteLine($"age {Configuration["wizards:0:Age"]}");
        Console.Write($"{Configuration["wizards:1:Name"]}, ");
        Console.WriteLine($"age {Configuration["wizards:1:Age"]}");
    }
}