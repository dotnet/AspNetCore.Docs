using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using RewriteRules;

namespace SampleApp
{
    public class Startup
    {
        #region snippet1
        public void Configure(IApplicationBuilder app)
        {
            using (StreamReader apacheModRewriteStreamReader = 
                File.OpenText("ApacheModRewrite.txt"))
            using (StreamReader iisUrlRewriteStreamReader = 
                File.OpenText("IISUrlRewrite.xml")) 
            {
                var options = new RewriteOptions()
                    .AddRedirect("redirect-rule/(.*)", "redirected/$1")
                    .AddRewrite(@"^rewrite-rule/(\d+)/(\d+)", "rewritten?var1=$1&var2=$2", 
                        skipRemainingRules: true)
                    .AddApacheModRewrite(apacheModRewriteStreamReader)
                    .AddIISUrlRewrite(iisUrlRewriteStreamReader)
                    .Add(MethodRules.RedirectXmlFileRequests)
                    .Add(MethodRules.RewriteTextFileRequests)
                    .Add(new RedirectImageRequests(".png", "/png-images"))
                    .Add(new RedirectImageRequests(".jpg", "/jpg-images"));

                app.UseRewriter(options);
            }

            app.UseStaticFiles();

            app.Run(context => context.Response.WriteAsync(
                $"Rewritten or Redirected Url: " +
                $"{context.Request.Path + context.Request.QueryString}"));
        }
        #endregion
    }
}
