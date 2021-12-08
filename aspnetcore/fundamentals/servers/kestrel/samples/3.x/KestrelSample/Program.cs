#define DefaultBuilder
// Define any of the following for the scenarios described in the Kestrel topic:
// DefaultBuilder Limits TCPSocket UnixSocket FileDescriptor Port0 SyncIO
// The following require an X.509 certificate:
// TCPSocket UnixSocket FileDescriptor Limits

using System;
using System.Net;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;

namespace KestrelSample
{
    public class Program
    {
#if DefaultBuilder
        // <snippet_DefaultBuilder>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        // </snippet_DefaultBuilder>
#elif TCPSocket
        // <snippet_TCPSocket>
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
                        serverOptions.Listen(IPAddress.Loopback, 5000);
                        serverOptions.Listen(IPAddress.Loopback, 5001, 
                            listenOptions =>
                            {
                                listenOptions.UseHttps("testCert.pfx", 
                                    "testPassword");
                            });
                    })
                    .UseStartup<Startup>();
                });
        // </snippet_TCPSocket>
#elif UnixSocket
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // <snippet_UnixSocket>
                    webBuilder.ConfigureKestrel(serverOptions =>
                    {
                        serverOptions.ListenUnixSocket("/tmp/kestrel-test.sock");
                        serverOptions.ListenUnixSocket("/tmp/kestrel-test.sock", 
                            listenOptions =>
                            {
                                listenOptions.UseHttps("testCert.pfx", 
                                    "testpassword");
                            });
                    })
                    // </snippet_UnixSocket>
                    .UseStartup<Startup>();
                });
#elif FileDescriptor
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseLibuv()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // <snippet_FileDescriptor>
                    webBuilder.ConfigureKestrel(serverOptions =>
                    {
                        var fds = Environment
                            .GetEnvironmentVariable("SD_LISTEN_FDS_START");
                        var fd = ulong.Parse(fds);

                        serverOptions.ListenHandle(fd);
                        serverOptions.ListenHandle(fd, listenOptions =>
                        {
                            listenOptions.UseHttps("testCert.pfx", "testpassword");
                        });
                    })
                    // </snippet_FileDescriptor>
                    .UseStartup<Startup>();
                });
#elif Limits
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // <snippet_Limits>
                    webBuilder.ConfigureKestrel(serverOptions =>
                    {
                        serverOptions.Limits.MaxConcurrentConnections = 100;
                        serverOptions.Limits.MaxConcurrentUpgradedConnections = 100;
                        serverOptions.Limits.MaxRequestBodySize = 10 * 1024;
                        serverOptions.Limits.MinRequestBodyDataRate =
                            new MinDataRate(bytesPerSecond: 100, 
                                gracePeriod: TimeSpan.FromSeconds(10));
                        serverOptions.Limits.MinResponseDataRate =
                            new MinDataRate(bytesPerSecond: 100, 
                                gracePeriod: TimeSpan.FromSeconds(10));
                        serverOptions.Listen(IPAddress.Loopback, 5000);
                        serverOptions.Listen(IPAddress.Loopback, 5001, 
                            listenOptions =>
                            {
                                listenOptions.UseHttps("testCert.pfx", 
                                    "testPassword");
                            });
                        serverOptions.Limits.KeepAliveTimeout = 
                            TimeSpan.FromMinutes(2);
                        serverOptions.Limits.RequestHeadersTimeout = 
                            TimeSpan.FromMinutes(1);
                    })
                    // </snippet_Limits>
                    .UseStartup<Startup>();
                });
#elif Port0
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // <snippet_Port0>
                    webBuilder.ConfigureKestrel(serverOptions =>
                    {
                        serverOptions.Listen(IPAddress.Loopback, 0);
                    })
                    // </snippet_Port0>
                    .UseStartup<Startup>();
                });
#elif SyncIO
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // <snippet_SyncIO>
                    webBuilder.ConfigureKestrel(serverOptions =>
                    {
                        serverOptions.AllowSynchronousIO = true;
                    })
                    // </snippet_SyncIO>
                    .UseStartup<Startup>();
                });
#endif
    }
}
