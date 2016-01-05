using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Memory;

namespace ConfigConsole
{
    public class Program
    {
        public void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            Console.WriteLine("Initial Config Providers: " + builder.Providers.Count());

            var defaultSettings = new MemoryConfigurationProvider();
            defaultSettings.Set("username", "Guest");
            builder.Add(defaultSettings);
            Console.WriteLine("Added Memory Provider. Providers: " + builder.Providers.Count());

            builder.AddCommandLine(args);
            Console.WriteLine("Added Command Line Provider. Providers: " + builder.Providers.Count());

            var config = builder.Build();
            string username = config["username"];

            Console.WriteLine($"Hello, {username}!");
        }
    }
}
