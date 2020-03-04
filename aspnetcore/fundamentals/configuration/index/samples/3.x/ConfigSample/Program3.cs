#define MAIN3
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

#if MAIN3
namespace ConfigSample
{
    #region snippet
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var switchMappings = new Dictionary<string, string>()
             {
                 { "-k1", "key1" },
                 { "-k2", "key2" },
                 { "--alt3", "key3" },
                 { "--alt4", "key4" },
                 { "--alt5", "key5" },
                 { "--alt6", "key6" },
             };

            return Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddCommandLine(args, switchMappings);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        }
    }
    #endregion
}
#endif