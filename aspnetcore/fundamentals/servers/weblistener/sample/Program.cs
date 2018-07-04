using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Net.Http.Server;

// The default listening address is http://localhost:5000 if none is specified.
// Replace "localhost" with "*" to listen to external requests.
// You can use the --urls command-line flag to change the listening address. Ex:
// > dotnet run --urls http://*:8080;http://*:8081

// Use the following code to configure URLs in code:
// builder.UseUrls("http://*:8080", "http://*:8081");
// Put it after UseConfiguration(config) to take precedence over command-line configuration.

namespace WebListenerDemo
{
    /// <summary>
    /// Executing the "dotnet run" command in the application folder will run this app.
    /// </summary>
    public class Program
    {
        public static string Server;

        #region snippet_Main
        public static void Main(string[] args)
        {
            Console.WriteLine("Running demo with WebListener.");

            var config = new ConfigurationBuilder()
                .AddCommandLine(args)
                .Build();

            var builder = new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseConfiguration(config)
                .UseStartup<Startup>()
                .UseWebListener(options =>
                {
                    options.ListenerSettings.Authentication.Schemes = AuthenticationSchemes.None;
                    options.ListenerSettings.Authentication.AllowAnonymous = true;
                });

            var host = builder.Build();
            host.Run();
        }
        #endregion
    }
}
