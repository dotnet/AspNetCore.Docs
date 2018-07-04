using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace ResponseCompressionSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .ConfigureLogging(factory =>
                {
                    factory.AddConsole(LogLevel.Debug);
                })
                .UseKestrel()
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
