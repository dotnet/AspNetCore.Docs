using System;
using Microsoft.Framework.ConfigurationModel;
using System.Linq;

namespace ConfigConsole
{
    public class Program
    {
        // TODO: Add a MemoryConfigurationSource and specify a default username
        public void Main(string[] args)
        {
            var configuration = new Configuration();
            Console.WriteLine("Sources: " + configuration.Sources.Count());

            configuration.AddCommandLine(args);
            Console.WriteLine("Sources: " + configuration.Sources.Count());

            string username = configuration.Get("username");

            Console.WriteLine($"Hello, {username}!");
        }
    }
}
