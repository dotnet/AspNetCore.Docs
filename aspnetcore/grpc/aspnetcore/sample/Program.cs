using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace GrpcGreeter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        #region snippet
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel(options =>
                    {
                        options.Listen(IPAddress.Any, 5001, listenOptions =>
                        {
                            // This endpoint will use HTTP/2
                            listenOptions.Protocols = HttpProtocols.Http2;
                            
                            // Secured with TLS on port 5001.
                            listenOptions.UseHttps("<path to .pfx file>", 
                                "<certificate password>");
                        });
                    });
                    webBuilder.UseStartup<Startup>();
                });
        #endregion
    }
}
