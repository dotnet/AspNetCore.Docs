#define DefaultBuilder // or Limits or UnixSocket or FileDescriptor

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System;
using System.Net;

namespace KestrelDemo
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
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseKestrel(options =>
                {
                    options.Listen(IPAddress.Loopback, 5000);
                    options.Listen(IPAddress.Loopback, 5001, listenOptions =>
                    {
                        listenOptions.UseHttps("testCert.pfx", "testPassword");
                    });
                })
                .Build();
        #endregion
#elif UnixSocket
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
        #region snippet_UnixSocket
                .UseKestrel(options =>
                {
                    options.ListenUnixSocket("/tmp/kestrel-test.sock");
                    options.ListenUnixSocket("/tmp/kestrel-test.sock", listenOptions =>
                    {
                        listenOptions.UseHttps("testCert.pfx", "testpassword");
                    });
                })
        #endregion
                .Build();
#elif FileDescriptor
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
        #region snippet_FileDescriptor
                .UseKestrel(options =>
                {
                    var fds = Environment.GetEnvironmentVariable("SD_LISTEN_FDS_START");
                    ulong fd = ulong.Parse(fds);

                    options.ListenHandle(fd);
                    options.ListenHandle(fd, listenOptions =>
                    {
                        listenOptions.UseHttps("testCert.pfx", "testpassword");
                    });
                })
        #endregion
                .Build();
#elif Limits
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
        #region snippet_Limits
                .UseKestrel(options =>
                {
                    options.Limits.MaxConcurrentConnections = 100;
                    options.Limits.MaxConcurrentUpgradedConnections = 100;
                    options.Limits.MaxRequestBodySize = 10 * 1024;
                    options.Limits.MinRequestBodyDataRate =
                        new MinDataRate(bytesPerSecond: 100, gracePeriod: TimeSpan.FromSeconds(10));
                    options.Limits.MinResponseDataRate =
                        new MinDataRate(bytesPerSecond: 100, gracePeriod: TimeSpan.FromSeconds(10));
                    options.Listen(IPAddress.Loopback, 5000);
                    options.Listen(IPAddress.Loopback, 5001, listenOptions =>
                    {
                        listenOptions.UseHttps("testCert.pfx", "testPassword");
                    });
                })
        #endregion
               .Build();
#endif
    }
}


