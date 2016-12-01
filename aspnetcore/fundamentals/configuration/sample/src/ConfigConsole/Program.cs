using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace ConfigConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            Console.WriteLine("Initial Config Sources: " + builder.Sources.Count());

            builder.AddInMemoryCollection(new Dictionary<string, string>
            {
                { "username", "Guest" }
            });

            Console.WriteLine("Added Memory Source. Sources: " + builder.Sources.Count());

            builder.AddCommandLine(args);
            Console.WriteLine("Added Command-line Source. Sources: " + builder.Sources.Count());

            var config = builder.Build();
            string username = config["username"];

            Console.WriteLine($"Hello, {username}!");
        }
    }
}
