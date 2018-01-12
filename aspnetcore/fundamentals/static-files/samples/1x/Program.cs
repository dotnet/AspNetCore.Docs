using Microsoft.AspNetCore.Hosting;
using StaticFiles;
using System.IO;

namespace sample
{
    #region snippet_ProgramClass
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<StartupAddHeader>()
                .UseApplicationInsights()
                .Build();

            host.Run();
        }        
    }
    #endregion
}
