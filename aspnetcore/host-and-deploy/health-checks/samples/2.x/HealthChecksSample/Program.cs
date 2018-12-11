using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SampleApp
{
    public class Program
    {
        private static readonly Dictionary<string, Type> _scenarios;

        static Program()
        {
            _scenarios = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase)
            {
                { "basic", typeof(BasicStartup) },
                { "db", typeof(DbHealthStartup) },
                { "dbcontext", typeof(DbContextHealthStartup) },
                { "liveness", typeof(LivenessProbeStartup) },
                { "writer", typeof(CustomWriterStartup) },
                { "port", typeof(ManagementPortStartup) },
                
            };
        }

        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables(prefix: "ASPNETCORE_")
                .AddCommandLine(args)
                .Build();

            var scenario = config["scenario"] ?? "basic";

            if (!_scenarios.TryGetValue(scenario, out var startupType))
            {
                startupType = typeof(BasicStartup);
            }

            return new WebHostBuilder()
                .UseConfiguration(config)
                .ConfigureLogging(builder =>
                {
                    builder.SetMinimumLevel(LogLevel.Trace);
                    builder.AddConfiguration(config);
                    builder.AddConsole();
                })
                .UseKestrel()
                .UseStartup(startupType)
                .Build();
        }
    }
}
