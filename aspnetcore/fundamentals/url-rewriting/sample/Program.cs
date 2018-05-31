using System.Net;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace UrlRewritingSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel(options =>
                {
                    options.Listen(IPAddress.Loopback, 443, listenOptions =>
                    {
                        listenOptions.UseHttps("testCert.pfx", "testPassword");
                    });
                    options.Listen(IPAddress.Loopback, 5000);
                    options.Listen(IPAddress.Loopback, 5001, listenOptions =>
                    {
                        listenOptions.UseHttps("testCert.pfx", "testPassword");
                    });
                })
                .UseStartup<Startup>();
    }
}
