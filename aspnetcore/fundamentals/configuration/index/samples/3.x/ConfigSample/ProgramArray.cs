//#define MAIN2
//#define MAIN3
//#define MAIN4

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

#if MAIN2
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
            var arrayDict = new Dictionary<string, string>
            {
                {"array:entries:0", "value0"},
                {"array:entries:1", "value1"},
                {"array:entries:2", "value2"},
                //              3   Skipped
                {"array:entries:4", "value4"},
                {"array:entries:5", "value5"}
            };

            return Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddInMemoryCollection(arrayDict);
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

#if MAIN3
namespace ConfigSample
{
#region snippet2
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var arrayDict = new Dictionary<string, string>
            {
                {"array:entries:0", "value0"},
                {"array:entries:1", "value1"},
                {"array:entries:2", "value2"},
                //              3   Skipped
                {"array:entries:4", "value4"},
                {"array:entries:5", "value5"}
            };

            return Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddInMemoryCollection(arrayDict);
                    config.AddJsonFile("Value3.json",
                                        optional: false, reloadOnChange: false);
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

#if MAIN4
namespace ConfigSample
{
#region snippet6
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var Dict = new Dictionary<string, string>
            {
               {"MyKey", "Dictionary MyKey Value"},
               {"Position:Title", "Dictionary_Title"},
               {"Position:Name", "Dictionary_Name" },
               {"Logging:LogLevel:Default", "Warning"}
            };

            return Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddInMemoryCollection(Dict);
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