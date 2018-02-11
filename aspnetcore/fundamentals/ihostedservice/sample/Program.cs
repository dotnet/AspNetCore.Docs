using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace BackgroundTasksSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureLogging((hostingContext, logging) =>
                {
                    // Remove the Debug provider (and other providers) and filter most
                    // of the remaining logging. Reducing the logging output makes it
                    // easier to see the messages produced by the background tasks
                    // demonstrated in this sample app.
                    logging.ClearProviders();
                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    logging.AddFilter("Microsoft.AspNetCore.Mvc.RedirectToRouteResult", LogLevel.None);
                    logging.AddFilter("Microsoft.AspNetCore.Mvc.RazorPages.Internal.PageActionInvoker", LogLevel.None);
                    logging.AddFilter("Microsoft.AspNetCore.StaticFiles.StaticFileMiddleware", LogLevel.None);
                })
                .Build();
    }
}
