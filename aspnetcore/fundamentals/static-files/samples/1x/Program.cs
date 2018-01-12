using Microsoft.AspNetCore.Hosting;
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
                .UseStartup<Startup>()
                .UseApplicationInsights()
                .Build();

            host.Run();
        }        
    }
    #endregion
}
