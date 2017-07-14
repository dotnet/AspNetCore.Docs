#define Debug

using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace RazorPagesContacts
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
#if  Debug
                .UseStartup<StartupDebug>()
#else
                .UseStartup<Startup>()
#endif
                .Build();

            host.Run();
        }
    }
}
