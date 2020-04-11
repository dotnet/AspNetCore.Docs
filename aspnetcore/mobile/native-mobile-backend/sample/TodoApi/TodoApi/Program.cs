using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TodoApi.Data;
using TodoApi.Models;

namespace TodoApi {
    public class Program {
        public static void Main (string[] args) {
            var host = new WebHostBuilder ()
                .UseKestrel ()
                .UseUrls ("http://*:5000")
                .UseContentRoot (Directory.GetCurrentDirectory ())
                .UseIISIntegration ()
                .UseStartup<Startup> ()
                .Build ();

            DataSeeding (host);

            host.Run ();
        }

        private static void DataSeeding (IWebHost host) {
            using (var scope = host.Services.CreateScope ()) {
                var services = scope.ServiceProvider;

                try {

                    var context = services.GetRequiredService<TodoContext> ();
                    DbInitializer.Initialize (context);

                } catch (Exception ex) {
                    var logger = services.GetRequiredService<ILogger<Program>> ();
                    logger.LogError (ex, "An error occurred.");
                }
            }
        }
    }
}