using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Server.HttpSys;

// <snippet_1>
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
// </snippet_1>

// <snippet_2>
var app = builder.Build();

app.Use((context, next) =>
{
    var maxRequestBodySizeFeature = context.Features.GetRequiredFeature<IHttpMaxRequestBodySizeFeature>();
    maxRequestBodySizeFeature.MaxRequestBodySize = 10 * 1024;

    var server = context.RequestServices.GetRequiredService<IServer>();
    var serverAddressesFeature = server.Features.GetRequiredFeature<IServerAddressesFeature>();

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
