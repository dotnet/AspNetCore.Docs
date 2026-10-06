using System.Diagnostics;
using System.Net;
using Yarp.ReverseProxy.Forwarder;
// <snippet_imports>
using Yarp.ReverseProxy.Transforms;
using Yarp.ReverseProxy.Transforms.Builder;
// </snippet_imports>

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpForwarder();

var app = builder.Build();

using var httpClient = new HttpMessageInvoker(new SocketsHttpHandler
{
    UseProxy = false,
    AllowAutoRedirect = false,
    AutomaticDecompression = DecompressionMethods.None,
    UseCookies = false,
    EnableMultipleHttp2Connections = true,
    ActivityHeadersPropagator = new ReverseProxyPropagator(DistributedContextPropagator.Current),
    ConnectTimeout = TimeSpan.FromSeconds(15),
});

// <snippet_create_transformer>
var transformBuilder = app.Services.GetRequiredService<ITransformBuilder>();
var transformer = transformBuilder.Create(context =>
{
    context.AddQueryRemoveKey("param1");
    context.AddQueryValue("area", "xx2", append: false);
});
// </snippet_create_transformer>

var requestConfig = new ForwarderRequestConfig
{
    ActivityTimeout = TimeSpan.FromSeconds(100),
};

app.Map("/test/{**catch-all}", async (HttpContext httpContext, IHttpForwarder forwarder) =>
{
    var error = await forwarder.SendAsync(httpContext, "https://localhost:10000/",
        httpClient, requestConfig, transformer);

    if (error != ForwarderError.None)
    {
        var errorFeature = httpContext.GetForwarderErrorFeature();
        app.Logger.LogError(errorFeature?.Exception, "Forwarding failed: {Error}", error);
    }
});

app.Run();
