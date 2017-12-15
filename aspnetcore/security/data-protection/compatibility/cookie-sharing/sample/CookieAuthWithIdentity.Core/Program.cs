using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace CookieAuthWithIdentityCore
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
                .UseUrls("http://localhost:5002")
                .Build();
    }
}
