#define FIRST // FIRST SECOND
#if NEVER
#elif FIRST
// <snippet_1>
// <snippet_2>
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Server.HttpSys;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseHttpSys(options =>
{
    options.AllowSynchronousIO = false;
    options.Authentication.Schemes = AuthenticationSchemes.None;
    options.Authentication.AllowAnonymous = true;
    options.MaxConnections = null;
    options.MaxRequestBodySize = 30_000_000;
    options.UrlPrefixes.Add("http://localhost:5005");
});

builder.Services.AddRazorPages();

var app = builder.Build();
// </snippet_1>

app.Use((context, next) =>
{
   context.Features.GetRequiredFeature<IHttpMaxRequestBodySizeFeature>()
                                         .MaxRequestBodySize = 10 * 1024;

    var server = context.RequestServices.GetRequiredService<IServer>();
    var serverAddressesFeature = server.Features
                                       .GetRequiredFeature<IServerAddressesFeature>();

    var addresses = string.Join(", ", serverAddressesFeature.Addresses);

    var loggerFactory = context.RequestServices.GetRequiredService<ILoggerFactory>();
    var logger = loggerFactory.CreateLogger("Sample");

    logger.LogInformation("Addresses: {addresses}", addresses);

    return next(context);
});

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();

app.Run();
// </snippet_2>
#elif SECOND
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http.Features;

// <snippet_11>
var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseHttpSys(options =>
{
    options.UrlPrefixes.Add("https://10.0.0.4:443");
});

builder.Services.AddRazorPages();

var app = builder.Build();
// </snippet_11>
// <snippet_12>
app.Use((context, next) =>
{
    context.Features.GetRequiredFeature<IHttpMaxRequestBodySizeFeature>()
                                             .MaxRequestBodySize = 10 * 1024;

    var server = context.RequestServices
        .GetRequiredService<IServer>();
    var serverAddressesFeature = server.Features
                                 .GetRequiredFeature<IServerAddressesFeature>();

    var addresses = string.Join(", ", serverAddressesFeature.Addresses);

    var loggerFactory = context.RequestServices
        .GetRequiredService<ILoggerFactory>();
    var logger = loggerFactory.CreateLogger("Sample");

    logger.LogInformation("Addresses: {addresses}", addresses);

    return next(context);
});
// </snippet_12>

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();

app.Run();
#endif
