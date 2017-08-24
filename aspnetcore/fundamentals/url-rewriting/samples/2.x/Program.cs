using System.IO;
using System.Net;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using RewriteRules;

namespace UrlRewritingSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel(options =>
                {
                    options.Listen(IPAddress.Any, 5000);
                    options.Listen(IPAddress.Any, 5001);
                    options.Listen(IPAddress.Loopback, 443, listenOptions =>
                    {
                        listenOptions.UseHttps("testCert.pfx", "testPassword");
                    });
                })
                .Configure(app =>
                {
                    #region snippet1
                    using (StreamReader apacheModRewriteStreamReader = File.OpenText("ApacheModRewrite.txt"))
                    using (StreamReader iisUrlRewriteStreamReader = File.OpenText("IISUrlRewrite.xml")) 
                    {
                        var options = new RewriteOptions()
                            .AddRedirect("redirect-rule/(.*)", "redirected/$1")
                            .AddRewrite(@"^rewrite-rule/(\d+)/(\d+)", "rewritten?var1=$1&var2=$2", skipRemainingRules: true)
                            .AddApacheModRewrite(apacheModRewriteStreamReader)
                            .AddIISUrlRewrite(iisUrlRewriteStreamReader)
                            .Add(MethodRules.RedirectXMLRequests)
                            .Add(new RedirectImageRequests(".png", "/png-images"))
                            .Add(new RedirectImageRequests(".jpg", "/jpg-images"));

                        app.UseRewriter(options);
                    }
                    #endregion

                    app.Run(context => context.Response.WriteAsync($"Rewritten or Redirected Url: {context.Request.Path + context.Request.QueryString}"));
                })
                .Build();
    }
}
