using System;
using Microsoft.Framework.ConfigurationModel;
using System.Linq;
using System.Collections.Generic;

namespace ConfigConsole
{
    public class Program
    {
        public void Main(string[] args)
        {
            var configuration = new Configuration();
            Console.WriteLine("Initial Config Sources: " + configuration.Sources.Count());

            var defaultSettings = new MemoryConfigurationSource();
            defaultSettings.Set("username", "Guest");
            configuration.Add(defaultSettings);
            Console.WriteLine("Added Memory Source. Sources: " + configuration.Sources.Count());

            configuration.AddCommandLine(args);
            Console.WriteLine("Added Command Line Source. Sources: " + configuration.Sources.Count());

            string username = configuration.Get("username");

            Console.WriteLine($"Hello, {username}!");
        }
    }
}
