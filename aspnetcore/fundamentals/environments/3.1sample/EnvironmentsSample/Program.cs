using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace EnvironmentsSample
{
#if MULTI
    #region snippet
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var assemblyName = typeof(Startup).GetTypeInfo().Assembly.FullName;

            return   Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup(assemblyName);
                });
        }
    }
    #endregion
#else
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                   // webBuilder.UseStartup<First.Startup>();
                   // webBuilder.UseStartup<Inject.Startup>();
                    webBuilder.UseStartup<MethodConventions.Startup>();

                });
    }
#endif
}
