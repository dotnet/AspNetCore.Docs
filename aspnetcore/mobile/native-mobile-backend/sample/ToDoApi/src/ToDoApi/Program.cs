using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace ToDoApi {
    public class Program {
        public static void Main (string[] args) {
            // use this to allow command line parameters in the config
            var configuration = new ConfigurationBuilder ()
                .AddCommandLine (args)
                .Build ();

            var hostUrl = configuration["hosturl"];
            if (string.IsNullOrEmpty (hostUrl))
                hostUrl = "http://0.0.0.0:5001";

            var host = new WebHostBuilder ()
                .UseKestrel ()
                .UseUrls (hostUrl)
                .UseContentRoot (Directory.GetCurrentDirectory ())
                .UseIISIntegration ()
                .UseStartup<Startup> ()
                .UseConfiguration (configuration)
                .Build ();

            host.Run ();
        }
    }
}