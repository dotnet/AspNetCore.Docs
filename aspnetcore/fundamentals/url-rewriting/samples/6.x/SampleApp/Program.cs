#define REDIRECT3 // FIRST REDIRECT REDIRECT2 REDIRECT3
#if NEVER
#elif FIRST
#region snippet1
using Microsoft.AspNetCore.Rewrite;
using RewriteRules;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

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

app.Run();
#endregion
#elif REDIRECT
#region snippet_redirect
using Microsoft.AspNetCore.Rewrite;
using RewriteRules;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

int? localhostHTTPSport = null;
if (app.Environment.IsDevelopment())
{
    localhostHTTPSport = Int32.Parse(Environment.GetEnvironmentVariable(
                   "ASPNETCORE_URLS")!.Split(new Char[] { ':', ';' })[2]);
}

using (StreamReader apacheModRewriteStreamReader =
    File.OpenText("ApacheModRewrite.txt"))
using (StreamReader iisUrlRewriteStreamReader =
    File.OpenText("IISUrlRewrite.xml"))
{
    var options = new RewriteOptions()
        // localhostHTTPport not needed for production, used only with localhost.
        .AddRedirectToHttps(301, localhostHTTPSport)
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

app.Run();
#endregion
#elif REDIRECT2
#region snippet_redirect2
using Microsoft.AspNetCore.Rewrite;
using RewriteRules;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

using (StreamReader apacheModRewriteStreamReader =
    File.OpenText("ApacheModRewrite.txt"))
using (StreamReader iisUrlRewriteStreamReader =
    File.OpenText("IISUrlRewrite.xml"))
{
    var options = new RewriteOptions()
        .AddRedirectToHttpsPermanent()
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

app.Run();
#endregion
#elif REDIRECT3
#region snippet_redirect3
using Microsoft.AspNetCore.Rewrite;
using RewriteRules;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

using (StreamReader apacheModRewriteStreamReader =
    File.OpenText("ApacheModRewrite.txt"))
using (StreamReader iisUrlRewriteStreamReader =
    File.OpenText("IISUrlRewrite.xml"))
{
    var options = new RewriteOptions()
        .AddRedirectToHttpsPermanent()
        .AddRedirect("redirect-rule/(.*)", "redirected/$1")
        .AddRewrite(@"^rewrite-rule/(\d+)/(\d+)", "rewritten?var1=$1&var2=$2",
            skipRemainingRules: true)

        // Rewrite path to QS.
        .AddRewrite(@"^path/(.*)/(.*)", "path?var1=$1&var2=$2",
            skipRemainingRules: true)
        // Skip trailing slash.
        .AddRewrite(@"^path2/(.*)/$", "path2/$1",
            skipRemainingRules: true)
         // Enforce trailing slash.
         .AddRewrite(@"^path3/(.*[^/])$", "path3/$1/",
            skipRemainingRules: true)
         // Avoid rewriting specific requests.
         .AddRewrite(@"^path4/(.*)(?<!\.axd)$", "rewritten/$1",
            skipRemainingRules: true)
         // Rearrange URL segments
         .AddRewrite(@"^path5/(.*)/(.*)/(.*)", "path5/$3/$2/$1",
            skipRemainingRules: true)
          // Replace a URL segment
          .AddRewrite(@"^path6/(.*)/segment2/(.*)", "path6/$1/replaced/$2",
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

app.Run();
#endregion
#endif
