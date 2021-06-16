using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace LargeFilesSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel((context, options) =>
                    {
                        // 调整请求的大小限制，使得可以上传大文件
                        options.Limits.MaxRequestBodySize = long.MaxValue;
                    })
                    .UseStartup<Startup>();
                });
    }
}
