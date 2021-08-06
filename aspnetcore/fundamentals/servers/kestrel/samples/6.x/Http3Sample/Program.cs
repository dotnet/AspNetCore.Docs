using System;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Server.Kestrel.Https;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Http3Sample
{
    public class Program
    {
        #region snippet_UseHttp3
        public static void Main(string[] args)
        {
            var cert = CertificateLoader.LoadFromStoreCert("localhost", StoreName.My.ToString(), StoreLocation.CurrentUser, false);

            var hostBuilder = new HostBuilder()
                .ConfigureWebHost(webHost =>
                {
                    webHost.UseKestrel()
                    // Set up Quic options
                    .UseQuic(options =>
                    {
                        options.Alpn = "h3-29";
                        options.IdleTimeout = TimeSpan.FromHours(1);
                    })
                    .ConfigureKestrel((context, options) =>
                    {
                        var basePort = 5557;
                        options.EnableAltSvc = true;

                        options.Listen(IPAddress.Any, basePort, listenOptions =>
                        {
                            listenOptions.UseHttps(httpsOptions =>
                            {
                                httpsOptions.ServerCertificate = cert;
                            });
                            listenOptions.UseConnectionLogging();
                            // Use Http3
                            listenOptions.Protocols = HttpProtocols.Http3;
                        });
                    })
                    .UseStartup<Startup>();
                });
            #endregion
            hostBuilder.Build().Run();
        }
    }
}
