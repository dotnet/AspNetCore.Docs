using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Sample2x
{
    #region snippet_ProgramClass
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
    #endregion
}
