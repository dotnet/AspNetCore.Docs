using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Memory;

namespace ConfigConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            Console.WriteLine("Initial Config Sources: " + builder.Sources.Count());

            var defaultSettings = new MemoryConfigurationSource();
            var initialData = new Dictionary<string,string>()
            {
                {"username","Guest"}
            };
            defaultSettings.InitialData = initialData;
            builder.Add(defaultSettings);
            Console.WriteLine("Added Memory Source. Sources: " + builder.Sources.Count());

            builder.AddCommandLine(args);
            Console.WriteLine("Added Command Line Source. Sources: " + builder.Sources.Count());

            var config = builder.Build();
            string username = config["username"];

            Console.WriteLine($"Hello, {username}!");
        }
    }
}
