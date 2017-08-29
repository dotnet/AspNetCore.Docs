using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.HttpSys;
using System;

// The default listening address is http://localhost:5000 if none is specified.

namespace HttpSysDemo
{
    /// <summary>
    /// Executing the "dotnet run" command in the application folder will run this app.
    /// </summary>
    public class Program
    {
        #region snippet_Main
        public static void Main(string[] args)
        {
            Console.WriteLine("Running demo with HTTP.sys.");

            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                #region snippet_Options
                .UseHttpSys(options =>
                {
                    options.Authentication.Schemes = AuthenticationSchemes.None;
                    options.Authentication.AllowAnonymous = true;
                    options.MaxConnections = 100;
                    options.MaxRequestBodySize = 30000000;
                    options.UrlPrefixes.Add("http://localhost:5000");
                })
                #endregion
                .Build();
        #endregion
    }
}
