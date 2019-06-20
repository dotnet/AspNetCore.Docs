using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.HttpSys;

namespace HttpSysSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        #region snippet1
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseHttpSys(options =>
                {
                    options.AllowSynchronousIO = true;
                    options.Authentication.Schemes = AuthenticationSchemes.None;
                    options.Authentication.AllowAnonymous = true;
                    options.MaxConnections = null;
                    options.MaxRequestBodySize = 30000000;
                    options.UrlPrefixes.Add("http://localhost:5000");
                });
        #endregion
    }
}
