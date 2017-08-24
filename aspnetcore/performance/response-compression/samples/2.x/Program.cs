using System;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;

namespace ResponseCompressionSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    #region snippet1
                    services.AddResponseCompression(options =>
                    {
                        options.Providers.Add<GzipCompressionProvider>();
                        options.Providers.Add<CustomCompressionProvider>();
                        options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "image/svg+xml" });
                    });

                    services.Configure<GzipCompressionProviderOptions>(options => 
                    {
                        options.Level = CompressionLevel.Fastest;
                    });
                    #endregion
                })
                .Configure(app =>
                {
                    app.UseResponseCompression();

                    app.Map("/testfile1kb.txt", fileApp =>
                    {
                        fileApp.Run(context =>
                        {
                            context.Response.ContentType = "text/plain";
                            return context.Response.SendFileAsync("testfile1kb.txt");
                        });
                    });

                    app.Map("/trickle", trickleApp =>
                    {
                        trickleApp.Run(async context =>
                        {
                            context.Response.ContentType = "text/plain";

                            for (int i = 0; i < 20; i++)
                            {
                                await context.Response.WriteAsync("a");
                                await context.Response.Body.FlushAsync();
                                await Task.Delay(TimeSpan.FromSeconds(1));
                            }
                        });
                    });

                    app.Map("/banner.svg", fileApp =>
                    {
                        fileApp.Run(context =>
                        {
                            context.Response.ContentType = "image/svg+xml";
                            return context.Response.SendFileAsync("banner.svg");
                        });
                    });

                    app.Run(async context =>
                    {
                        context.Response.ContentType = "text/plain";
                        await context.Response.WriteAsync(LoremIpsum.Text);
                    });
                })
                .Build();
    }
}
