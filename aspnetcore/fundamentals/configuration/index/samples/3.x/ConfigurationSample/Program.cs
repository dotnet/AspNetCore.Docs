using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using ConfigurationSample.Extensions;

namespace ConfigurationSample
{
    #region snippet_Program
    public class Program
    {
        public static Dictionary<string, string> arrayDict = 
            new Dictionary<string, string>
            {
                {"array:entries:0", "value0"},
                {"array:entries:1", "value1"},
                {"array:entries:2", "value2"},
                {"array:entries:4", "value4"},
                {"array:entries:5", "value5"}
            };

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddInMemoryCollection(arrayDict);
                    config.AddJsonFile(
                        "json_array.json", optional: false, reloadOnChange: false);
                    config.AddJsonFile(
                        "starship.json", optional: false, reloadOnChange: false);
                    config.AddXmlFile(
                        "tvshow.xml", optional: false, reloadOnChange: false);
                    config.AddEFConfiguration(
                        options => options.UseInMemoryDatabase("InMemoryDb"));
                    config.AddCommandLine(args);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
    #endregion
}
