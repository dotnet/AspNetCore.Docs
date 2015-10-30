using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.Framework.Configuration;

namespace CustomConfigurationSource
{
    public class Program
    {
        public void Main(string[] args)
        {
            var builder = new ConfigurationBuilder(".");
            builder.AddJsonFile("appsettings.json");
            builder.AddEnvironmentVariables();
            var config = builder.Build();

            builder.AddEntityFramework(options => options.UseSqlServer(config["Data:DefaultConnection:ConnectionString"]));
            config = builder.Build();

            Console.WriteLine("key1={0}", config.Get("key1"));
            Console.WriteLine("key2={0}", config.Get("key2"));
            Console.WriteLine("key3={0}", config.Get("key3"));

        }
    }
}
