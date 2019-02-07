using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using System;

namespace Clients.ConsoleTwo
{
    class Program
    {
        public static void Main(string[] args)
        {
            var host = new HostBuilder()
                .ConfigureLogging(logging =>
                {
                    logging.AddConsole();
                })
                .ConfigureServices((services) =>
                {
                    services.AddHostedService<ClockHubClient>();
                })
                .Build();

            host.Run();
        }
    }
}
