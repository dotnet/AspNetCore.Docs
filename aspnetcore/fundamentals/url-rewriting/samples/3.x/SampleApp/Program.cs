using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace SampleApp
{
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
                    webBuilder.ConfigureKestrel(serverOptions =>
                    {
                        // The following option to use port 443 only works if port 
                        // 443 hasn't already been assigned by the server or is 
                        // otherwise in use. For example, IIS might be using the 
                        // port on a Windows server or local system.
                        serverOptions.Listen(IPAddress.Loopback, 443, listenOptions =>
                        {
                            listenOptions.UseHttps("testCert.pfx", "testPassword");
                        });
                        serverOptions.Listen(IPAddress.Loopback, 5000);
                        serverOptions.Listen(IPAddress.Loopback, 5001, listenOptions =>
                        {
                            listenOptions.UseHttps("testCert.pfx", "testPassword");
                        });
                    })
                    .UseStartup<Startup>();
                });
    }
}
