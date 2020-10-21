using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using WebJsonLog;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }
    #region snippet
    public static IHostBuilder CreateHostBuilder(string[] args) =>
               Host.CreateDefaultBuilder(args)
      .ConfigureLogging(logging =>
      {
         logging.AddJsonConsole(options =>
         {
             options.JsonWriterOptions = new JsonWriterOptions()
             { Indented = true };
         });
      })
      .ConfigureWebHostDefaults(webBuilder =>
      {
        webBuilder.UseStartup<Startup>();
      });
    #endregion
}