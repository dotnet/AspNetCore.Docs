using System;
using System.Linq;
using Microsoft.Framework.Configuration;

namespace ConfigConsole
{
    public class Program
    {
        public void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            Console.WriteLine("Initial Config Sources: " + builder.Sources.Count());

            var defaultSettings = new MemoryConfigurationSource();
            defaultSettings.Set("username", "Guest");
            builder.Add(defaultSettings);
            Console.WriteLine("Added Memory Source. Sources: " + builder.Sources.Count());

            builder.AddCommandLine(args);
            Console.WriteLine("Added Command Line Source. Sources: " + builder.Sources.Count());

            var config = builder.Build();
            string username = config.Get("username");

            Console.WriteLine($"Hello, {username}!");
        }
    }
}
