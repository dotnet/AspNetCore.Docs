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

namespace KestrelSample
{
    /// <summary>
    /// Executing the "dotnet run" command in the application folder will run this app.
    /// </summary>
    public class Program
    {
        // The default listening address is http://localhost:5000 if none is specified.

#if DefaultBuilder
        #region snippet_DefaultBuilder
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
        #endregion
#elif TCPSocket
        #region snippet_TCPSocket
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureKestrel((context, serverOptions) =>
                {
                    serverOptions.Listen(IPAddress.Loopback, 5000);
                    serverOptions.Listen(IPAddress.Loopback, 5001, listenOptions =>
                    {
                        listenOptions.UseHttps("testCert.pfx", "testPassword");
                    });
                });
        #endregion
#elif UnixSocket
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                #region snippet_UnixSocket
                .ConfigureKestrel((context, serverOptions) =>
                {
                    serverOptions.ListenUnixSocket("/tmp/kestrel-test.sock");
                    serverOptions.ListenUnixSocket("/tmp/kestrel-test.sock", listenOptions =>
                    {
                        listenOptions.UseHttps("testCert.pfx", "testpassword");
                    });
                });
                #endregion
#elif FileDescriptor
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseLibuv()
                .UseStartup<Startup>()
                #region snippet_FileDescriptor
                .ConfigureKestrel((context, serverOptions) =>
                {
                    var fds = Environment.GetEnvironmentVariable("SD_LISTEN_FDS_START");
                    var fd = ulong.Parse(fds);

                    serverOptions.ListenHandle(fd);
                    serverOptions.ListenHandle(fd, listenOptions =>
                    {
                        listenOptions.UseHttps("testCert.pfx", "testpassword");
                    });
                });
                #endregion
#elif Limits
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                #region snippet_Limits
                .ConfigureKestrel((context, serverOptions) =>
                {
                    serverOptions.Limits.MaxConcurrentConnections = 100;
                    serverOptions.Limits.MaxConcurrentUpgradedConnections = 100;
                    serverOptions.Limits.MaxRequestBodySize = 10 * 1024;
                    serverOptions.Limits.MinRequestBodyDataRate =
                        new MinDataRate(bytesPerSecond: 100, gracePeriod: TimeSpan.FromSeconds(10));
                    serverOptions.Limits.MinResponseDataRate =
                        new MinDataRate(bytesPerSecond: 100, gracePeriod: TimeSpan.FromSeconds(10));
                    serverOptions.Listen(IPAddress.Loopback, 5000);
                    serverOptions.Listen(IPAddress.Loopback, 5001, listenOptions =>
                    {
                        listenOptions.UseHttps("testCert.pfx", "testPassword");
                    });
                    serverOptions.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(2);
                    serverOptions.Limits.RequestHeadersTimeout = TimeSpan.FromMinutes(1);
                });
                #endregion
#elif Port0
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                #region snippet_Port0
                .ConfigureKestrel((context, serverOptions) =>
                {
                    serverOptions.Listen(IPAddress.Loopback, 0);
                });
                #endregion
#elif SyncIO
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                #region snippet_SyncIO
                .ConfigureKestrel((context, serverOptions) =>
                {
                    serverOptions.AllowSynchronousIO = true;
                });
                #endregion
#endif
    }
}


