---
title: What's new in ASP.NET Core 5.0
author: rick-anderson
description: Learn about the new features in ASP.NET Core 5.0.
ms.author: riande
ms.custom: mvc
ms.date: 12/05/2019
no-loc: ["ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: aspnetcore-5.0
---
# What's new in ASP.NET Core 5.0

https://docs.microsoft.com/en-us

This article highlights the most significant changes in ASP.NET Core 5.0 with links to relevant documentation.

## Blazor

For more information, see <xref:blazor/index>.

### Blazor Server

### Blazor WebAssembly

Blazor can run client-side C# code directly in the browser, using [WebAssembly](xref:blazor/hosting-models#blazor-webassembly).

The Blazor WebAssembly template and the Blazor Server template are included in the .NET 5 SDK. along with the Blazor Server template.

To create a Blazor WebAssembly project, run the following command in a console window:

```dotnetcli
dotnet new blazorwasm
``` 

## gRPC

[gRPC](https://grpc.io/):

For more information, see <xref:grpc/index>.

## SignalR

SignalR Hub filters, called Hub pipelines in ASP.NET SignalR, is a feature that allows code to run before and after Hub methods are called. Running code before and after Hub methods are called is similar to how middleware has the ability to run code before and after an HTTP request. Common uses include logging, error handling, and argument validation.

For more information, see [Use hub filters in ASP.NET Core SignalR](xref:signalr/hub-filters).

You can read more about this Hub filters on the docs page.
<!--
See [Update SignalR code](xref:migration/31-to-50#signalr) for migration instructions.
-->

## Kestrel

* Reloadable endpoints via configuration: Kestrel can detect changes to configuration passed to [KestrelServerOptions.Configure](xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.Configure%2A) and unbind from existing endpoints and bind to new endpoints without requiring an application restart.
* HTTP/2 response headers improvements. For more information, see [Performance improvements](#performance-improvements) in the next section.
* Support for additional endpoints types in the sockets transport: Adding to the new API introduced in <xref:System.Net.Sockets?displayProperty=nameWithType>, the sockets default transport in [Kestrel](xref:fundamentals/servers/kestrel) allows binding to both existing file handles and unix domain sockets. Support for binding to existing file handles enables using the existing `Systemd` integration without requiring the `libuv` transport.
* Custom header decoding in Kestrel: Apps can now specify which <xref:System.Text.Encoding> to use to interpret incoming headers based on the header name instead of defaulting to `UTF-8`. Set the <xref:System.Net.Http.SocketsHttpHandler.RequestHeaderEncodingSelector> property on <xref:Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions> to specify which encoding to use:
 
  ```csharp
  public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.ConfigureKestrel(options =>
            {
                options.RequestHeaderEncodingSelector = encoding =>
                {
                    switch (encoding)
                    {
                        case "Host":
                            return System.Text.Encoding.Latin1;
                        default:
                            return System.Text.Encoding.UTF8;
                    }
                };
            });
            webBuilder.UseStartup<Startup>();
        });
  ```

## Performance improvements

### HTTP/2

* Significant reductions in allocations in the HTTP/2 code path.
* Support for [HPack dynamic compression](https://tools.ietf.org/html/rfc7541) of HTTP/2 response headers in [Kestrel](xref:fundamentals/servers/kestrel). For more information, see [Header table size](xref:fundamentals/servers/kestrel#header-table-size) and [HPACK: the silent killer (feature) of HTTP/2](https://blog.cloudflare.com/hpack-the-silent-killer-feature-of-http-2/).
* Sending HTTP/2 PING frames: HTTP/2 has a mechanism for sending PING frames to ensure an idle connection is still functional. Ensuring a viable connection is especially useful when working with long-lived streams that are often idle but only intermittently see activity, for example, gRPC streams. Apps can send periodic PING frames in [Kestrel](xref:fundamentals/servers/kestrel) by setting limits on 
<xref:Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions>:

   ```csharp
   public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.ConfigureKestrel(options =>
            {
                options.Limits.Http2.KeepAlivePingInterval =
                                               TimeSpan.FromSeconds(10);
                options.Limits.Http2.KeepAlivePingTimeout =
                                               TimeSpan.FromSeconds(1);
            });
            webBuilder.UseStartup<Startup>();
        });
   ```
   <!-- review: KeepAlivePingInterval not found in RC1. Try testing with RC1. See https://github.com/dotnet/aspnetcore/pull/22565/files see C:\Users\riande\source\repos\WebApplication128\WebApplication128 -->

### Containers

Prior to .NET 5, building and publishing a Dockerfile for an ASP.NET app required pulling the entire .NET Core SDK and the ASP.NET image. With this release, pulling the SDK images bytes is reduced and the bytes pulled for the ASP.NET image is largely eliminated. For more information, See [this GitHub issue comment](https://github.com/dotnet/dotnet-docker/issues/1814#issuecomment-625294750)

## API improvements

### JSON extension methods for HttpRequest and HttpResponse

JSON data can be read and written to from an `HttpRequest` and `HttpResponse` using the new <xref:System.Net.Http.Json.HttpContentJsonExtensions.ReadFromJsonAsync%2A> and `WriteAsJsonAsync` extension methods. These extension methods use the [System.Text.Json](xref:System.Text.Json) serializer to handle the JSON data. You can also check if a request has a JSON content type using the new `HasJsonContentType` extension method.

The JSON extension methods can be combined with [endpoint routing](xref:fundamentals/routing) to create JSON APIs in a style of programming we call ***route to code***. It is a new option for developers who want to create basic JSON APIs in a lightweight way. For example, a web app that has only a handful of endpoints might choose to use route to code rather than the full functionality of ASP.NET Core MVC:

```csharp
endpoints.MapGet("/weather/{city:alpha}", async context =>
{
    var city = (string)context.Request.RouteValues["city"];
    var weather = GetFromDatabase(city);

    await context.Response.WriteAsJsonAsync(weather);
});
```

For more information on the new JSON extension methods and route to code, see [this .NET show](WriteAsJsonAsync).

### allow anonymous access to an endpoint

The `AllowAnonymous` extension method allows anonymous access to an endpoint:

```csharp
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapGet("/", async context =>
        {
            await context.Response.WriteAsync("Hello World!");
        })
        .AllowAnonymous();
    });
}
```

### Custom handling of authorization failures

Custom handling of authorization failures is now easier with the new [IAuthorizationMiddlewareResultHandler](https://github.com/dotnet/aspnetcore/blob/v5.0.0-rc.1.20451.17/src/Security/Authorization/Policy/src/IAuthorizationMiddlewareResultHandler.cs) interface that is invoked by the [authorization](xref:Microsoft.AspNetCore.Builder.AuthorizationAppBuilderExtensions.UseAuthorization%2A) [Middleware](fundamentals/middleware). The default implementation remains the same, but a custom handler can be registered in [Dependency injection, which allows custom HTTP responses based on why authorization failed. See [this sample](https://github.com/dotnet/aspnetcore/blob/master/src/Security/samples/CustomAuthorizationFailureResponse/Authorization/SampleAuthorizationMiddlewareResultHandler.cs) that demonstrates usage of the `IAuthorizationMiddlewareResultHandler`.

### Authorization when using endpoint routing

Authorization when using endpoint routing now receives the `HttpContext` rather than the endpoint instance. This allows the authorization middleware to access the `RouteData` and other properties of the `HttpContext` that were not accessible though the <xref:Microsoft.AspNetCore.Http.Endpoint> class. The endpoint can be fetched from the context using [context.GetEndpoint(xref:Microsoft.AspNetCore.Http.EndpointHttpContextExtensions.GetEndpoint%2A).

### System.Diagnostics.Activity

The default format for <xref:System.Diagnostics.Activity?displayProperty=fullName> now defaults to the W3C format. This makes distributed tracing support in ASP.NET Core interoperable with more frameworks by default.

### FromBodyAttribute 

<xref:Microsoft.AspNetCore.Mvc.FromBodyAttribute> ow supports configuring an option that allows these parameters or properties to be considered optional:

```csharp
public IActionResult Post([FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Allow)] MyModel model) {
     ... 
     }
```
## Miscellaneous changes

* The <xref:System.ComponentModel.DataAnnotations.CompareAttribute> can now be applied to properties on Razor Page model.
* Parameters and properties bound from the body are considered required by default. <!-- Review: How is this different from 3.1
The validation system in .NET Core 3.0 and later treats non-nullable parameters or bound properties as if they had a [Required] attribute.
see https://docs.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-3.1   
-->
* We’ve started applying [nullable annotations](https://docs.microsoft.com/en-us/dotnet/csharp/nullable-references#attributes-describe-apis) to ASP.NET Core assemblies. We plan to annotate most of the common public API surface of the .NET 5 framework. <!-- Review: what's the impact of this? How does it work? Need more info.  Check the link I added -->