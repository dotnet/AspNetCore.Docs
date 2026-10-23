#define Debug

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace RazorPagesContacts
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
#if Debug
                .UseStartup<StartupDebug>()
#else
                .UseStartup<Startup>()
#endif
                .Build();
    }
}
