using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CustomConfigurationProvider
{
    public static class Program
    {
        public static void Main()
        {
            // work with with a builder using multiple calls
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json").Build();
            var connectionStringConfig = builder.Build();

            // chain calls together as a fluent API
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEntityFrameworkConfig(options =>
                    options.UseSqlServer(connectionStringConfig.GetConnectionString("DefaultConnection"))
                )
                .Build();

            Console.WriteLine("key1={0}", config["key1"]);
            Console.WriteLine("key2={0}", config["key2"]);
            Console.WriteLine("key3={0}", config["key3"]);
        }
    }
}
