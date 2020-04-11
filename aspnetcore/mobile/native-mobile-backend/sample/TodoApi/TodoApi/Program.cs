using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

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

            host.Run ();
        }
    }
}