---
title: Kestrel web server implementation in ASP.NET Core
author: rick-anderson
description: Learn about Kestrel, the cross-platform web server for ASP.NET Core.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 04/01/2022
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: fundamentals/servers/kestrel
---
# Kestrel web server implementation in ASP.NET Core

By [Tom Dykstra](https://github.com/tdykstra), [Chris Ross](https://github.com/Tratcher), and [Stephen Halter](https://twitter.com/halter73)

:::moniker range=">= aspnetcore-6.0"

Kestrel is a cross-platform [web server for ASP.NET Core](xref:fundamentals/servers/index). Kestrel is the web server that's included and enabled by default in ASP.NET Core project templates.

Kestrel supports the following scenarios:

* HTTPS
* [HTTP/2](xref:fundamentals/servers/kestrel/http2) (except on macOS&dagger;)
* Opaque upgrade used to enable [WebSockets](xref:fundamentals/websockets)
* Unix sockets for high performance behind Nginx

&dagger;HTTP/2 will be supported on macOS in a future release.

Kestrel is supported on all platforms and versions that .NET Core supports.

## Get started

ASP.NET Core project templates use Kestrel by default when not hosted with IIS. In the following template-generated `Program.cs`, the <xref:Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder%2A?displayProperty=nameWithType> method calls <xref:Microsoft.AspNetCore.Hosting.WebHostBuilderKestrelExtensions.UseKestrel%2A> internally:

:::code language="csharp" source="kestrel/samples/6.x/KestrelSample/Program.cs" id="snippet_CreateBuilder" highlight="1":::

For more information on configuring `WebApplication` and `WebApplicationBuilder`, see <xref:fundamentals/minimal-apis>.

## Optional client certificates

For information on apps that must protect a subset of the app with a certificate, see [Optional client certificates](xref:security/authentication/certauth#optional-client-certificates).

## Additional resources

<a name="endpoint-configuration"></a>
* <xref:fundamentals/servers/kestrel/endpoints>
* Source for [`WebApplication.CreateBuilder` method call call to `UseKestrel`](https://github.com/dotnet/aspnetcore/blob/v6.0.2/src/DefaultBuilder/src/WebHost.cs#L224)
<a name="kestrel-options"></a>
* <xref:fundamentals/servers/kestrel/options>
<a name="http2-support"></a>
* <xref:fundamentals/servers/kestrel/http2>
<a name="when-to-use-kestrel-with-a-reverse-proxy"></a>
* <xref:fundamentals/servers/kestrel/when-to-use-a-reverse-proxy>
<a name="host-filtering"></a>
* <xref:fundamentals/servers/kestrel/host-filtering>
* <xref:test/troubleshoot>
* <xref:security/enforcing-ssl>
* <xref:host-and-deploy/proxy-load-balancer>
* [RFC 7230: Message Syntax and Routing (Section 5.4: Host)](https://tools.ietf.org/html/rfc7230#section-5.4)
* When using UNIX sockets on Linux, the socket isn't automatically deleted on app shutdown. For more information, see [this GitHub issue](https://github.com/dotnet/aspnetcore/issues/14134).

> [!NOTE]
> As of ASP.NET Core 5.0, Kestrel's libuv transport is obsolete. The libuv transport doesn't receive updates to support new OS platforms, such as Windows ARM64, and will be removed in a future release. Remove any calls to the obsolete <xref:Microsoft.AspNetCore.Hosting.WebHostBuilderLibuvExtensions.UseLibuv%2A> method and use Kestrel's default Socket transport instead.

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

Kestrel is a cross-platform [web server for ASP.NET Core](xref:fundamentals/servers/index). Kestrel is the web server that's included and enabled by default in ASP.NET Core project templates.

Kestrel supports the following scenarios:

* HTTPS
* [HTTP/2](xref:fundamentals/servers/kestrel/http2) (except on macOS&dagger;)
* Opaque upgrade used to enable [WebSockets](xref:fundamentals/websockets)
* Unix sockets for high performance behind Nginx

&dagger;HTTP/2 will be supported on macOS in a future release.

Kestrel is supported on all platforms and versions that .NET Core supports.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/servers/kestrel/samples/5.x) ([how to download](xref:index#how-to-download-a-sample))

## Get started

ASP.NET Core project templates use Kestrel by default when not hosted with IIS. In `Program.cs`, the <xref:Microsoft.Extensions.Hosting.GenericHostBuilderExtensions.ConfigureWebHostDefaults%2A> method calls <xref:Microsoft.AspNetCore.Hosting.WebHostBuilderKestrelExtensions.UseKestrel%2A>:

:::code language="csharp" source="kestrel/samples/5.x/KestrelSample/Program.cs" id="snippet_DefaultBuilder" highlight="8":::

For more information on building the host, see the *Set up a host* and *Default builder settings* sections of <xref:fundamentals/host/generic-host#set-up-a-host>.

## Optional client certificates

For information on apps that must protect a subset of the app with a certificate, see [Optional client certificates](xref:security/authentication/certauth#optional-client-certificates).

## Additional resources

<a name="endpoint-configuration"></a>
* <xref:fundamentals/servers/kestrel/endpoints>
<a name="kestrel-options"></a>
* <xref:fundamentals/servers/kestrel/options>
<a name="http2-support"></a>
* <xref:fundamentals/servers/kestrel/http2>
<a name="when-to-use-kestrel-with-a-reverse-proxy"></a>
* <xref:fundamentals/servers/kestrel/when-to-use-a-reverse-proxy>
<a name="host-filtering"></a>
* <xref:fundamentals/servers/kestrel/host-filtering>
* <xref:test/troubleshoot>
* <xref:security/enforcing-ssl>
* <xref:host-and-deploy/proxy-load-balancer>
* [RFC 7230: Message Syntax and Routing (Section 5.4: Host)](https://tools.ietf.org/html/rfc7230#section-5.4)
* When using UNIX sockets on Linux, the socket is not automatically deleted on app shut down. For more information, see [this GitHub issue](https://github.com/dotnet/aspnetcore/issues/14134).

> [!NOTE]
> As of ASP.NET Core 5.0, Kestrel's libuv transport is obsolete. The libuv transport doesn't receive updates to support new OS platforms, such as Windows ARM64, and will be removed in a future release. Remove any calls to the obsolete <xref:Microsoft.AspNetCore.Hosting.WebHostBuilderLibuvExtensions.UseLibuv%2A> method and use Kestrel's default Socket transport instead.

:::moniker-end

:::moniker range="< aspnetcore-5.0"

Kestrel is a cross-platform [web server for ASP.NET Core](xref:fundamentals/servers/index). Kestrel is the web server that's included by default in ASP.NET Core project templates.

Kestrel supports the following scenarios:

* HTTPS
* Opaque upgrade used to enable [WebSockets](https://github.com/aspnet/websockets)
* Unix sockets for high performance behind Nginx
* HTTP/2 (except on macOS&dagger;)

&dagger;HTTP/2 will be supported on macOS in a future release.

Kestrel is supported on all platforms and versions that .NET Core supports.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/servers/kestrel/samples/3.x) ([how to download](xref:index#how-to-download-a-sample))

## HTTP/2 support

[HTTP/2](https://httpwg.org/specs/rfc7540.html) is available for ASP.NET Core apps if the following base requirements are met:

* Operating system&dagger;
  * Windows Server 2016/Windows 10 or later&Dagger;
  * Linux with OpenSSL 1.0.2 or later (for example, Ubuntu 16.04 or later)
* Target framework: .NET Core 2.2 or later
* [Application-Layer Protocol Negotiation (ALPN)](https://tools.ietf.org/html/rfc7301#section-3) connection
* TLS 1.2 or later connection

&dagger;HTTP/2 will be supported on macOS in a future release.
&Dagger;Kestrel has limited support for HTTP/2 on Windows Server 2012 R2 and Windows 8.1. Support is limited because the list of supported TLS cipher suites available on these operating systems is limited. A certificate generated using an Elliptic Curve Digital Signature Algorithm (ECDSA) may be required to secure TLS connections.

If an HTTP/2 connection is established, <xref:Microsoft.AspNetCore.Http.HttpRequest.Protocol%2A?displayProperty=nameWithType> reports `HTTP/2`.

Starting with .NET Core 3.0, HTTP/2 is enabled by default. For more information on configuration, see the [Kestrel options](#kestrel-options) and [ListenOptions.Protocols](#listenoptionsprotocols) sections.

## When to use Kestrel with a reverse proxy

Kestrel can be used by itself or with a *reverse proxy server*. A reverse proxy server receives HTTP requests from the network and forwards them to Kestrel. Examples of a reverse proxy server include:

* [Internet Information Services (IIS)](https://www.iis.net/)
* [Nginx](https://nginx.org)
* [Apache](https://httpd.apache.org/)
* [YARP: Yet Another Reverse Proxy](https://microsoft.github.io/reverse-proxy/)

Kestrel used as an edge (Internet-facing) web server:

:::image source="kestrel/_static/kestrel-to-internet2.png" alt-text="Kestrel communicates directly with the Internet without a reverse proxy server":::

Kestrel used in a reverse proxy configuration:

:::image source="kestrel/_static/kestrel-to-internet.png" alt-text="Kestrel communicates indirectly with the Internet through a reverse proxy server, such as IIS, Nginx, or Apache":::

Either configuration, with or without a reverse proxy server, is a supported hosting configuration.

Kestrel used as an edge server without a reverse proxy server doesn't support sharing the same IP and port among multiple processes. When Kestrel is configured to listen on a port, Kestrel handles all of the traffic for that port regardless of requests' `Host` headers. A reverse proxy that can share ports has the ability to forward requests to Kestrel on a unique IP and port.

Even if a reverse proxy server isn't required, using a reverse proxy server might be a good choice.

A reverse proxy:

* Can limit the exposed public surface area of the apps that it hosts.
* Provide an additional layer of configuration and defense.
* Might integrate better with existing infrastructure.
* Simplify load balancing and secure communication (HTTPS) configuration. Only the reverse proxy server requires an X.509 certificate, and that server can communicate with the app's servers on the internal network using plain HTTP.

> [!WARNING]
> Hosting in a reverse proxy configuration requires [Forwarded Headers Middleware configuration](xref:host-and-deploy/proxy-load-balancer).

## Kestrel in ASP.NET Core apps

ASP.NET Core project templates use Kestrel by default. In `Program.cs`, the <xref:Microsoft.Extensions.Hosting.GenericHostBuilderExtensions.ConfigureWebHostDefaults%2A> method calls <xref:Microsoft.AspNetCore.Hosting.WebHostBuilderKestrelExtensions.UseKestrel%2A>:

:::code language="csharp" source="kestrel/samples/3.x/KestrelSample/Program.cs" id="snippet_DefaultBuilder" highlight="8":::

For more information on building the host, see the *Set up a host* and *Default builder settings* sections of <xref:fundamentals/host/generic-host#set-up-a-host>.

To provide additional configuration after calling `ConfigureWebHostDefaults`, use `ConfigureKestrel`:

```csharp
public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.ConfigureKestrel(serverOptions =>
            {
                // Set properties and call methods on options
            })
            .UseStartup<Startup>();
        });
```

## Kestrel options

The Kestrel web server has constraint configuration options that are especially useful in Internet-facing deployments.

Set constraints on the <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.Limits> property of the <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions> class. The `Limits` property holds an instance of the <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerLimits> class.

The following examples use the <xref:Microsoft.AspNetCore.Server.Kestrel.Core> namespace:

```csharp
using Microsoft.AspNetCore.Server.Kestrel.Core;
```

In examples shown later in this article, Kestrel options are configured in C# code. Kestrel options can also be set using a [configuration provider](xref:fundamentals/configuration/index). For example, the [File Configuration Provider](xref:fundamentals/configuration/index#file-configuration-provider) can load Kestrel configuration from an `appsettings.json` or `appsettings.{Environment}.json` file:

```json
{
  "Kestrel": {
    "Limits": {
      "MaxConcurrentConnections": 100,
      "MaxConcurrentUpgradedConnections": 100
    },
    "DisableStringReuse": true
  }
}
```

> [!NOTE]
> <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions> and [endpoint configuration](#endpoint-configuration) are configurable from configuration providers. Remaining Kestrel configuration must be configured in C# code.

Use **one** of the following approaches:

* Configure Kestrel in `Startup.ConfigureServices`:

  1. Inject an instance of `IConfiguration` into the `Startup` class. The following example assumes that the injected configuration is assigned to the `Configuration` property.
  2. In `Startup.ConfigureServices`, load the `Kestrel` section of configuration into Kestrel's configuration:

     ```csharp
     using Microsoft.Extensions.Configuration
     
     public class Startup
     {
         public Startup(IConfiguration configuration)
         {
             Configuration = configuration;
         }

         public IConfiguration Configuration { get; }

         public void ConfigureServices(IServiceCollection services)
         {
             services.Configure<KestrelServerOptions>(
                 Configuration.GetSection("Kestrel"));
         }

         public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
         {
             ...
         }
     }
     ```

* Configure Kestrel when building the host:

  In `Program.cs`, load the `Kestrel` section of configuration into Kestrel's configuration:

  ```csharp
  // using Microsoft.Extensions.DependencyInjection;

  public static IHostBuilder CreateHostBuilder(string[] args) =>
      Host.CreateDefaultBuilder(args)
          .ConfigureServices((context, services) =>
          {
              services.Configure<KestrelServerOptions>(
                  context.Configuration.GetSection("Kestrel"));
          })
          .ConfigureWebHostDefaults(webBuilder =>
          {
              webBuilder.UseStartup<Startup>();
          });
  ```

Both of the preceding approaches work with any [configuration provider](xref:fundamentals/configuration/index).

### Keep-alive timeout

<xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerLimits.KeepAliveTimeout>

Gets or sets the [keep-alive timeout](https://tools.ietf.org/html/rfc7230#section-6.5). Defaults to 2 minutes.

:::code language="csharp" source="kestrel/samples/3.x/KestrelSample/Program.cs" id="snippet_Limits" highlight="19-20":::

### Maximum client connections

<xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerLimits.MaxConcurrentConnections>
<xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerLimits.MaxConcurrentUpgradedConnections>

The maximum number of concurrent open TCP connections can be set for the entire app with the following code:

:::code language="csharp" source="kestrel/samples/3.x/KestrelSample/Program.cs" id="snippet_Limits" highlight="3":::

There's a separate limit for connections that have been upgraded from HTTP or HTTPS to another protocol (for example, on a WebSockets request). After a connection is upgraded, it isn't counted against the `MaxConcurrentConnections` limit.

:::code language="csharp" source="kestrel/samples/3.x/KestrelSample/Program.cs" id="snippet_Limits" highlight="4":::

The maximum number of connections is unlimited (null) by default.

### Maximum request body size

<xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerLimits.MaxRequestBodySize>

The default maximum request body size is 30,000,000 bytes, which is approximately 28.6 MB.

The recommended approach to override the limit in an ASP.NET Core MVC app is to use the <xref:Microsoft.AspNetCore.Mvc.RequestSizeLimitAttribute> attribute on an action method:

```csharp
[RequestSizeLimit(100000000)]
public IActionResult MyActionMethod()
```

Here's an example that shows how to configure the constraint for the app on every request:

:::code language="csharp" source="kestrel/samples/3.x/KestrelSample/Program.cs" id="snippet_Limits" highlight="5":::

Override the setting on a specific request in middleware:

:::code language="csharp" source="kestrel/samples/3.x/KestrelSample/Startup.cs" id="snippet_Limits" highlight="3-4":::

An exception is thrown if the app configures the limit on a request after the app has started to read the request. There's an `IsReadOnly` property that indicates if the `MaxRequestBodySize` property is in read-only state, meaning it's too late to configure the limit.

When an app is run [out-of-process](xref:host-and-deploy/iis/index#out-of-process-hosting-model) behind the [ASP.NET Core Module](xref:host-and-deploy/aspnet-core-module), Kestrel's request body size limit is disabled because IIS already sets the limit.

### Minimum request body data rate

<xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerLimits.MinRequestBodyDataRate>
<xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerLimits.MinResponseDataRate>

Kestrel checks every second if data is arriving at the specified rate in bytes/second. If the rate drops below the minimum, the connection is timed out. The grace period is the amount of time that Kestrel gives the client to increase its send rate up to the minimum; the rate isn't checked during that time. The grace period helps avoid dropping connections that are initially sending data at a slow rate due to TCP slow-start.

The default minimum rate is 240 bytes/second with a 5 second grace period.

A minimum rate also applies to the response. The code to set the request limit and the response limit is the same except for having `RequestBody` or `Response` in the property and interface names.

Here's an example that shows how to configure the minimum data rates in `Program.cs`:

:::code language="csharp" source="kestrel/samples/3.x/KestrelSample/Program.cs" id="snippet_Limits" highlight="6-11":::

Override the minimum rate limits per request in middleware:

:::code language="csharp" source="kestrel/samples/3.x/KestrelSample/Startup.cs" id="snippet_Limits" highlight="6-21":::

The <xref:Microsoft.AspNetCore.Server.Kestrel.Core.Features.IHttpMinResponseDataRateFeature> referenced in the prior sample is not present in `HttpContext.Features` for HTTP/2 requests because modifying rate limits on a per-request basis is generally not supported for HTTP/2 due to the protocol's support for request multiplexing. However, the <xref:Microsoft.AspNetCore.Server.Kestrel.Core.Features.IHttpMinRequestBodyDataRateFeature> is still present `HttpContext.Features` for HTTP/2 requests, because the read rate limit can still be *disabled entirely* on a per-request basis by setting `IHttpMinRequestBodyDataRateFeature.MinDataRate` to `null` even for an HTTP/2 request. Attempting to read `IHttpMinRequestBodyDataRateFeature.MinDataRate` or attempting to set it to a value other than `null` will result in a `NotSupportedException` being thrown given an HTTP/2 request.

Server-wide rate limits configured via `KestrelServerOptions.Limits` still apply to both HTTP/1.x and HTTP/2 connections.

### Request headers timeout

<xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerLimits.RequestHeadersTimeout>

Gets or sets the maximum amount of time the server spends receiving request headers. Defaults to 30 seconds.

:::code language="csharp" source="kestrel/samples/3.x/KestrelSample/Program.cs" id="snippet_Limits" highlight="21-22":::

### Maximum streams per connection

`Http2.MaxStreamsPerConnection` limits the number of concurrent request streams per HTTP/2 connection. Excess streams are refused.

```csharp
webBuilder.ConfigureKestrel(serverOptions =>
{
    serverOptions.Limits.Http2.MaxStreamsPerConnection = 100;
});
```

The default value is 100.

### Header table size

The HPACK decoder decompresses HTTP headers for HTTP/2 connections. `Http2.HeaderTableSize` limits the size of the header compression table that the HPACK decoder uses. The value is provided in octets and must be greater than zero (0).

```csharp
webBuilder.ConfigureKestrel(serverOptions =>
{
    serverOptions.Limits.Http2.HeaderTableSize = 4096;
});
```

The default value is 4096.

### Maximum frame size

`Http2.MaxFrameSize` indicates the maximum allowed size of an HTTP/2 connection frame payload received or sent by the server. The value is provided in octets and must be between 2^14 (16,384) and 2^24-1 (16,777,215).

```csharp
webBuilder.ConfigureKestrel(serverOptions =>
{
    serverOptions.Limits.Http2.MaxFrameSize = 16384;
});
```

The default value is 2^14 (16,384).

### Maximum request header size

`Http2.MaxRequestHeaderFieldSize` indicates the maximum allowed size in octets of request header values. This limit applies to both name and value in their compressed and uncompressed representations. The value must be greater than zero (0).

```csharp
webBuilder.ConfigureKestrel(serverOptions =>
{
    serverOptions.Limits.Http2.MaxRequestHeaderFieldSize = 8192;
});
```

The default value is 8,192.

### Initial connection window size

`Http2.InitialConnectionWindowSize` indicates the maximum request body data in bytes the server buffers at one time aggregated across all requests (streams) per connection. Requests are also limited by `Http2.InitialStreamWindowSize`. The value must be greater than or equal to 65,535 and less than 2^31 (2,147,483,648).

```csharp
webBuilder.ConfigureKestrel(serverOptions =>
{
    serverOptions.Limits.Http2.InitialConnectionWindowSize = 131072;
});
```

The default value is 128 KB (131,072).

### Initial stream window size

`Http2.InitialStreamWindowSize` indicates the maximum request body data in bytes the server buffers at one time per request (stream). Requests are also limited by `Http2.InitialConnectionWindowSize`. The value must be greater than or equal to 65,535 and less than 2^31 (2,147,483,648).

```csharp
webBuilder.ConfigureKestrel(serverOptions =>
{
    serverOptions.Limits.Http2.InitialStreamWindowSize = 98304;
});
```

The default value is 96 KB (98,304).

### Trailers

[!INCLUDE[](~/includes/trailers.md)]

### Reset

[!INCLUDE[](~/includes/reset.md)]

### Synchronous I/O

<xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.AllowSynchronousIO> controls whether synchronous I/O is allowed for the request and response. The default value is `false`.

> [!WARNING]
> A large number of blocking synchronous I/O operations can lead to thread pool starvation, which makes the app unresponsive. Only enable `AllowSynchronousIO` when using a library that doesn't support asynchronous I/O.

The following example enables synchronous I/O:

:::code language="csharp" source="kestrel/samples/3.x/KestrelSample/Program.cs" id="snippet_SyncIO":::

For information about other Kestrel options and limits, see:

* <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions>
* <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerLimits>
* <xref:Microsoft.AspNetCore.Server.Kestrel.Core.ListenOptions>

## Endpoint configuration

By default, ASP.NET Core binds to:

* `http://localhost:5000`
* `https://localhost:5001` (when a local development certificate is present)

Specify URLs using the:

* `ASPNETCORE_URLS` environment variable.
* `--urls` command-line argument.
* `urls` host configuration key.
* `UseUrls` extension method.

The value provided using these approaches can be one or more HTTP and HTTPS endpoints (HTTPS if a default cert is available). Configure the value as a semicolon-separated list (for example, `"Urls": "http://localhost:8000;http://localhost:8001"`).

For more information on these approaches, see [Server URLs](xref:fundamentals/host/web-host#server-urls) and [Override configuration](xref:fundamentals/host/web-host#override-configuration).

A development certificate is created:

* When the [.NET Core SDK](/dotnet/core/sdk) is installed.
* The [dev-certs tool](xref:aspnetcore-2.1#https) is used to create a certificate.

Some browsers require granting explicit permission to trust the local development certificate.

Project templates configure apps to run on HTTPS by default and include [HTTPS redirection and HSTS support](xref:security/enforcing-ssl).

Call <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.Listen%2A> or <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.ListenUnixSocket%2A> methods on <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions> to configure URL prefixes and ports for Kestrel.

`UseUrls`, the `--urls` command-line argument, `urls` host configuration key, and the `ASPNETCORE_URLS` environment variable also work but have the limitations noted later in this section (a default certificate must be available for HTTPS endpoint configuration).

`KestrelServerOptions` configuration:

### ConfigureEndpointDefaults(Action\<ListenOptions>)

Specifies a configuration `Action` to run for each specified endpoint. Calling `ConfigureEndpointDefaults` multiple times replaces prior `Action`s with the last `Action` specified.

```csharp
webBuilder.ConfigureKestrel(serverOptions =>
{
    serverOptions.ConfigureEndpointDefaults(listenOptions =>
    {
        // Configure endpoint defaults
    });
});
```

> [!NOTE]
> Endpoints created by calling <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.Listen%2A> **before** calling <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.ConfigureEndpointDefaults%2A> won't have the defaults applied.

### ConfigureHttpsDefaults(Action\<HttpsConnectionAdapterOptions>)

Specifies a configuration `Action` to run for each HTTPS endpoint. Calling `ConfigureHttpsDefaults` multiple times replaces prior `Action`s with the last `Action` specified.

```csharp
webBuilder.ConfigureKestrel(serverOptions =>
{
    serverOptions.ConfigureHttpsDefaults(listenOptions =>
    {
        // certificate is an X509Certificate2
        listenOptions.ServerCertificate = certificate;
    });
});
```

> [!NOTE]
> Endpoints created by calling <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.Listen%2A> **before** calling <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.ConfigureHttpsDefaults%2A> won't have the defaults applied.

### Configure(IConfiguration)

Creates a configuration loader for setting up Kestrel that takes an <xref:Microsoft.Extensions.Configuration.IConfiguration> as input. The configuration must be scoped to the configuration section for Kestrel.

### ListenOptions.UseHttps

Configure Kestrel to use HTTPS.

`ListenOptions.UseHttps` extensions:

* `UseHttps`: Configure Kestrel to use HTTPS with the default certificate. Throws an exception if no default certificate is configured.
* `UseHttps(string fileName)`
* `UseHttps(string fileName, string password)`
* `UseHttps(string fileName, string password, Action<HttpsConnectionAdapterOptions> configureOptions)`
* `UseHttps(StoreName storeName, string subject)`
* `UseHttps(StoreName storeName, string subject, bool allowInvalid)`
* `UseHttps(StoreName storeName, string subject, bool allowInvalid, StoreLocation location)`
* `UseHttps(StoreName storeName, string subject, bool allowInvalid, StoreLocation location, Action<HttpsConnectionAdapterOptions> configureOptions)`
* `UseHttps(X509Certificate2 serverCertificate)`
* `UseHttps(X509Certificate2 serverCertificate, Action<HttpsConnectionAdapterOptions> configureOptions)`
* `UseHttps(Action<HttpsConnectionAdapterOptions> configureOptions)`

`ListenOptions.UseHttps` parameters:

* `filename` is the path and file name of a certificate file, relative to the directory that contains the app's content files.
* `password` is the password required to access the X.509 certificate data.
* `configureOptions` is an `Action` to configure the `HttpsConnectionAdapterOptions`. Returns the `ListenOptions`.
* `storeName` is the certificate store from which to load the certificate.
* `subject` is the subject name for the certificate.
* `allowInvalid` indicates if invalid certificates should be considered, such as self-signed certificates.
* `location` is the store location to load the certificate from.
* `serverCertificate` is the X.509 certificate.

In production, HTTPS must be explicitly configured. At a minimum, a default certificate must be provided.

Supported configurations described next:

* No configuration
* Replace the default certificate from configuration
* Change the defaults in code

*No configuration*

Kestrel listens on `http://localhost:5000` and `https://localhost:5001` (if a default cert is available).

<a name="configuration"></a>

*Replace the default certificate from configuration*

`CreateDefaultBuilder` calls `Configure(context.Configuration.GetSection("Kestrel"))` by default to load Kestrel configuration. A default HTTPS app settings configuration schema is available for Kestrel. Configure multiple endpoints, including the URLs and the certificates to use, either from a file on disk or from a certificate store.

In the following `appsettings.json` example:

* Set **AllowInvalid** to `true` to permit the use of invalid certificates (for example, self-signed certificates).
* Any HTTPS endpoint that doesn't specify a certificate (**HttpsDefaultCert** in the example that follows) falls back to the cert defined under **Certificates** > **Default** or the development certificate.

```json
{
  "Kestrel": {
    "Endpoints": {
      "Http": {
        "Url": "http://localhost:5000"
      },
      "HttpsInlineCertFile": {
        "Url": "https://localhost:5001",
        "Certificate": {
          "Path": "<path to .pfx file>",
          "Password": "<certificate password>"
        }
      },
      "HttpsInlineCertStore": {
        "Url": "https://localhost:5002",
        "Certificate": {
          "Subject": "<subject; required>",
          "Store": "<certificate store; required>",
          "Location": "<location; defaults to CurrentUser>",
          "AllowInvalid": "<true or false; defaults to false>"
        }
      },
      "HttpsDefaultCert": {
        "Url": "https://localhost:5003"
      },
      "Https": {
        "Url": "https://*:5004",
        "Certificate": {
          "Path": "<path to .pfx file>",
          "Password": "<certificate password>"
        }
      }
    },
    "Certificates": {
      "Default": {
        "Path": "<path to .pfx file>",
        "Password": "<certificate password>"
      }
    }
  }
}
```

An alternative to using **Path** and **Password** for any certificate node is to specify the certificate using certificate store fields. For example, the **Certificates** > **Default** certificate can be specified as:

```json
"Default": {
  "Subject": "<subject; required>",
  "Store": "<cert store; required>",
  "Location": "<location; defaults to CurrentUser>",
  "AllowInvalid": "<true or false; defaults to false>"
}
```

Schema notes:

* Endpoints names are case-insensitive. For example, `HTTPS` and `Https` are valid.
* The `Url` parameter is required for each endpoint. The format for this parameter is the same as the top-level `Urls` configuration parameter except that it's limited to a single value.
* These endpoints replace those defined in the top-level `Urls` configuration rather than adding to them. Endpoints defined in code via `Listen` are cumulative with the endpoints defined in the configuration section.
* The `Certificate` section is optional. If the `Certificate` section isn't specified, the defaults defined in earlier scenarios are used. If no defaults are available, the server throws an exception and fails to start.
* The `Certificate` section supports both **Path**&ndash;**Password** and **Subject**&ndash;**Store** certificates.
* Any number of endpoints may be defined in this way so long as they don't cause port conflicts.
* `options.Configure(context.Configuration.GetSection("{SECTION}"))` returns a `KestrelConfigurationLoader` with an `.Endpoint(string name, listenOptions => { })` method that can be used to supplement a configured endpoint's settings:

```csharp
webBuilder.UseKestrel((context, serverOptions) =>
{
    serverOptions.Configure(context.Configuration.GetSection("Kestrel"))
        .Endpoint("HTTPS", listenOptions =>
        {
            listenOptions.HttpsOptions.SslProtocols = SslProtocols.Tls12;
        });
});
```

`KestrelServerOptions.ConfigurationLoader` can be directly accessed to continue iterating on the existing loader, such as the one provided by <xref:Microsoft.AspNetCore.WebHost.CreateDefaultBuilder%2A>.

* The configuration section for each endpoint is available on the options in the `Endpoint` method so that custom settings may be read.
* Multiple configurations may be loaded by calling `options.Configure(context.Configuration.GetSection("{SECTION}"))` again with another section. Only the last configuration is used, unless `Load` is explicitly called on prior instances. The metapackage doesn't call `Load` so that its default configuration section may be replaced.
* `KestrelConfigurationLoader` mirrors the `Listen` family of APIs from `KestrelServerOptions` as `Endpoint` overloads, so code and config endpoints may be configured in the same place. These overloads don't use names and only consume default settings from configuration.

*Change the defaults in code*

`ConfigureEndpointDefaults` and `ConfigureHttpsDefaults` can be used to change default settings for `ListenOptions` and `HttpsConnectionAdapterOptions`, including overriding the default certificate specified in the prior scenario. `ConfigureEndpointDefaults` and `ConfigureHttpsDefaults` should be called before any endpoints are configured.

```csharp
webBuilder.ConfigureKestrel(serverOptions =>
{
    serverOptions.ConfigureEndpointDefaults(listenOptions =>
    {
        // Configure endpoint defaults
    });

    serverOptions.ConfigureHttpsDefaults(listenOptions =>
    {
        listenOptions.SslProtocols = SslProtocols.Tls12;
    });
});
```

*Kestrel support for SNI*

[Server Name Indication (SNI)](https://tools.ietf.org/html/rfc6066#section-3) can be used to host multiple domains on the same IP address and port. For SNI to function, the client sends the host name for the secure session to the server during the TLS handshake so that the server can provide the correct certificate. The client uses the furnished certificate for encrypted communication with the server during the secure session that follows the TLS handshake.

Kestrel supports SNI via the `ServerCertificateSelector` callback. The callback is invoked once per connection to allow the app to inspect the host name and select the appropriate certificate.

SNI support requires:

* Running on target framework `netcoreapp2.1` or later. On `net461` or later, the callback is invoked but the `name` is always `null`. The `name` is also `null` if the client doesn't provide the host name parameter in the TLS handshake.
* All websites run on the same Kestrel instance. Kestrel doesn't support sharing an IP address and port across multiple instances without a reverse proxy.

```csharp
webBuilder.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(5005, listenOptions =>
    {
        listenOptions.UseHttps(httpsOptions =>
        {
            var localhostCert = CertificateLoader.LoadFromStoreCert(
                "localhost", "My", StoreLocation.CurrentUser,
                allowInvalid: true);
            var exampleCert = CertificateLoader.LoadFromStoreCert(
                "example.com", "My", StoreLocation.CurrentUser,
                allowInvalid: true);
            var subExampleCert = CertificateLoader.LoadFromStoreCert(
                "sub.example.com", "My", StoreLocation.CurrentUser,
                allowInvalid: true);
            var certs = new Dictionary<string, X509Certificate2>(
                StringComparer.OrdinalIgnoreCase);
            certs["localhost"] = localhostCert;
            certs["example.com"] = exampleCert;
            certs["sub.example.com"] = subExampleCert;

            httpsOptions.ServerCertificateSelector = (connectionContext, name) =>
            {
                if (name != null && certs.TryGetValue(name, out var cert))
                {
                    return cert;
                }

                return exampleCert;
            };
        });
    });
});
```

### Connection logging

Call <xref:Microsoft.AspNetCore.Hosting.ListenOptionsConnectionLoggingExtensions.UseConnectionLogging%2A> to emit Debug level logs for byte-level communication on a connection. Connection logging is helpful for troubleshooting problems in low-level communication, such as during TLS encryption and behind proxies. If `UseConnectionLogging` is placed before `UseHttps`, encrypted traffic is logged. If `UseConnectionLogging` is placed after `UseHttps`, decrypted traffic is logged.

```csharp
webBuilder.ConfigureKestrel(serverOptions =>
{
    serverOptions.Listen(IPAddress.Any, 8000, listenOptions =>
    {
        listenOptions.UseConnectionLogging();
    });
});
```

### Bind to a TCP socket

The <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.Listen%2A> method binds to a TCP socket, and an options lambda permits X.509 certificate configuration:

:::code language="csharp" source="kestrel/samples/3.x/KestrelSample/Program.cs" id="snippet_TCPSocket" highlight="12-18":::

The example configures HTTPS for an endpoint with <xref:Microsoft.AspNetCore.Server.Kestrel.Core.ListenOptions>. Use the same API to configure other Kestrel settings for specific endpoints.

[!INCLUDE [How to make an X.509 cert](~/includes/make-x509-cert.md)]

### Bind to a Unix socket

Listen on a Unix socket with <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.ListenUnixSocket%2A> for improved performance with Nginx, as shown in this example:

:::code language="csharp" source="kestrel/samples/3.x/KestrelSample/Program.cs" id="snippet_UnixSocket":::

* In the Nginx configuration file, set the `server` > `location` > `proxy_pass` entry to `http://unix:/tmp/{KESTREL SOCKET}:/;`. `{KESTREL SOCKET}` is the name of the socket provided to <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.ListenUnixSocket%2A> (for example, `kestrel-test.sock` in the preceding example).
* Ensure that the socket is writeable by Nginx (for example, `chmod go+w /tmp/kestrel-test.sock`).

### Port 0

When the port number `0` is specified, Kestrel dynamically binds to an available port. The following example shows how to determine which port Kestrel actually bound at runtime:

:::code language="csharp" source="kestrel/samples/3.x/KestrelSample/Startup.cs" id="snippet_Configure" highlight="3-4,15-21":::

When the app is run, the console window output indicates the dynamic port where the app can be reached:

```console
Listening on the following addresses: http://127.0.0.1:48508
```

### Limitations

Configure endpoints with the following approaches:

* <xref:Microsoft.AspNetCore.Hosting.HostingAbstractionsWebHostBuilderExtensions.UseUrls%2A>
* `--urls` command-line argument
* `urls` host configuration key
* `ASPNETCORE_URLS` environment variable

These methods are useful for making code work with servers other than Kestrel. However, be aware of the following limitations:

* HTTPS can't be used with these approaches unless a default certificate is provided in the HTTPS endpoint configuration (for example, using `KestrelServerOptions` configuration or a configuration file as shown earlier in this topic).
* When both the `Listen` and `UseUrls` approaches are used simultaneously, the `Listen` endpoints override the `UseUrls` endpoints.

### IIS endpoint configuration

When using IIS, the URL bindings for IIS override bindings are set by either `Listen` or `UseUrls`. For more information, see the [ASP.NET Core Module](xref:host-and-deploy/aspnet-core-module) topic.

### ListenOptions.Protocols

The `Protocols` property establishes the HTTP protocols (`HttpProtocols`) enabled on a connection endpoint or for the server. Assign a value to the `Protocols` property from the `HttpProtocols` enum.

| `HttpProtocols` enum value | Connection protocol permitted |
| -------------------------- | ----------------------------- |
| `Http1`                    | HTTP/1.1 only. Can be used with or without TLS. |
| `Http2`                    | HTTP/2 only. May be used without TLS only if the client supports a [Prior Knowledge mode](https://tools.ietf.org/html/rfc7540#section-3.4). |
| `Http1AndHttp2`            | HTTP/1.1 and HTTP/2. HTTP/2 requires the client to select HTTP/2 in the TLS [Application-Layer Protocol Negotiation (ALPN)](https://tools.ietf.org/html/rfc7301#section-3) handshake; otherwise, the connection defaults to HTTP/1.1. |

The default `ListenOptions.Protocols` value for any endpoint is `HttpProtocols.Http1AndHttp2`.

TLS restrictions for HTTP/2:

* TLS version 1.2 or later
* Renegotiation disabled
* Compression disabled
* Minimum ephemeral key exchange sizes:
  * Elliptic curve Diffie-Hellman (ECDHE) &lbrack;[RFC4492](https://www.ietf.org/rfc/rfc4492.txt)&rbrack;: 224 bits minimum
  * Finite field Diffie-Hellman (DHE) &lbrack;`TLS12`&rbrack;: 2048 bits minimum
* Cipher suite not prohibited. 

`TLS_ECDHE_RSA_WITH_AES_128_GCM_SHA256` &lbrack;`TLS-ECDHE`&rbrack; with the P-256 elliptic curve &lbrack;`FIPS186`&rbrack; is supported by default.

The following example permits HTTP/1.1 and HTTP/2 connections on port 8000. Connections are secured by TLS with a supplied certificate:

```csharp
webBuilder.ConfigureKestrel(serverOptions =>
{
    serverOptions.Listen(IPAddress.Any, 8000, listenOptions =>
    {
        listenOptions.UseHttps("testCert.pfx", "testPassword");
    });
});
```

Use Connection Middleware to filter TLS handshakes on a per-connection basis for specific ciphers if required.

The following example throws <xref:System.NotSupportedException> for any cipher algorithm that the app doesn't support. Alternatively, define and compare [ITlsHandshakeFeature.CipherAlgorithm](xref:Microsoft.AspNetCore.Connections.Features.ITlsHandshakeFeature.CipherAlgorithm) to a list of acceptable cipher suites.

No encryption is used with a [CipherAlgorithmType.Null](xref:System.Security.Authentication.CipherAlgorithmType) cipher algorithm.

```csharp
// using System.Net;
// using Microsoft.AspNetCore.Connections;

webBuilder.ConfigureKestrel(serverOptions =>
{
    serverOptions.Listen(IPAddress.Any, 8000, listenOptions =>
    {
        listenOptions.UseHttps("testCert.pfx", "testPassword");
        listenOptions.UseTlsFilter();
    });
});
```

```csharp
using System;
using System.Security.Authentication;
using Microsoft.AspNetCore.Connections.Features;

namespace Microsoft.AspNetCore.Connections
{
    public static class TlsFilterConnectionMiddlewareExtensions
    {
        public static IConnectionBuilder UseTlsFilter(
            this IConnectionBuilder builder)
        {
            return builder.Use((connection, next) =>
            {
                var tlsFeature = connection.Features.Get<ITlsHandshakeFeature>();

                if (tlsFeature.CipherAlgorithm == CipherAlgorithmType.Null)
                {
                    throw new NotSupportedException("Prohibited cipher: " +
                        tlsFeature.CipherAlgorithm);
                }

                return next();
            });
        }
    }
}
```

Connection filtering can also be configured via an <xref:Microsoft.AspNetCore.Connections.IConnectionBuilder> lambda:

```csharp
// using System;
// using System.Net;
// using System.Security.Authentication;
// using Microsoft.AspNetCore.Connections;
// using Microsoft.AspNetCore.Connections.Features;

webBuilder.ConfigureKestrel(serverOptions =>
{
    serverOptions.Listen(IPAddress.Any, 8000, listenOptions =>
    {
        listenOptions.UseHttps("testCert.pfx", "testPassword");
        listenOptions.Use((context, next) =>
        {
            var tlsFeature = context.Features.Get<ITlsHandshakeFeature>();

            if (tlsFeature.CipherAlgorithm == CipherAlgorithmType.Null)
            {
                throw new NotSupportedException(
                    $"Prohibited cipher: {tlsFeature.CipherAlgorithm}");
            }

            return next();
        });
    });
});
```

On Linux, <xref:System.Net.Security.CipherSuitesPolicy> can be used to filter TLS handshakes on a per-connection basis:

```csharp
// using System.Net.Security;
// using Microsoft.AspNetCore.Hosting;
// using Microsoft.AspNetCore.Server.Kestrel.Core;
// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.Extensions.Hosting;

webBuilder.ConfigureKestrel(serverOptions =>
{
    serverOptions.ConfigureHttpsDefaults(listenOptions =>
    {
        listenOptions.OnAuthenticate = (context, sslOptions) =>
        {
            sslOptions.CipherSuitesPolicy = new CipherSuitesPolicy(
                new[]
                {
                    TlsCipherSuite.TLS_ECDHE_ECDSA_WITH_AES_128_GCM_SHA256,
                    TlsCipherSuite.TLS_ECDHE_ECDSA_WITH_AES_256_GCM_SHA384,
                    // ...
                });
        };
    });
});
```

*Set the protocol from configuration*

`CreateDefaultBuilder` calls `serverOptions.Configure(context.Configuration.GetSection("Kestrel"))` by default to load Kestrel configuration.

The following `appsettings.json` example establishes HTTP/1.1 as the default connection protocol for all endpoints:

```json
{
  "Kestrel": {
    "EndpointDefaults": {
      "Protocols": "Http1"
    }
  }
}
```

The following `appsettings.json` example establishes the HTTP/1.1 connection protocol for a specific endpoint:

```json
{
  "Kestrel": {
    "Endpoints": {
      "HttpsDefaultCert": {
        "Url": "https://localhost:5001",
        "Protocols": "Http1"
      }
    }
  }
}
```

Protocols specified in code override values set by configuration.

### URL prefixes

When using `UseUrls`, `--urls` command-line argument, `urls` host configuration key, or `ASPNETCORE_URLS` environment variable, the URL prefixes can be in any of the following formats.

Only HTTP URL prefixes are valid. Kestrel doesn't support HTTPS when configuring URL bindings using `UseUrls`.

* IPv4 address with port number

  ```
  http://65.55.39.10:80/
  ```

  `0.0.0.0` is a special case that binds to all IPv4 addresses.

* IPv6 address with port number

  ```
  http://[0:0:0:0:0:ffff:4137:270a]:80/
  ```

  `[::]` is the IPv6 equivalent of IPv4 `0.0.0.0`.

* Host name with port number

  ```
  http://contoso.com:80/
  http://*:80/
  ```

  Host names, `*`, and `+`, aren't special. Anything not recognized as a valid IP address or `localhost` binds to all IPv4 and IPv6 IPs. To bind different host names to different ASP.NET Core apps on the same port, use [HTTP.sys](xref:fundamentals/servers/httpsys) or a reverse proxy server, such as IIS, Nginx, or Apache.

  > [!WARNING]
  > Hosting in a reverse proxy configuration requires [Forwarded Headers Middleware configuration](xref:host-and-deploy/proxy-load-balancer).

* Host `localhost` name with port number or loopback IP with port number

  ```
  http://localhost:5000/
  http://127.0.0.1:5000/
  http://[::1]:5000/
  ```

  When `localhost` is specified, Kestrel attempts to bind to both IPv4 and IPv6 loopback interfaces. If the requested port is in use by another service on either loopback interface, Kestrel fails to start. If either loopback interface is unavailable for any other reason (most commonly because IPv6 isn't supported), Kestrel logs a warning.

## Host filtering

While Kestrel supports configuration based on prefixes such as `http://example.com:5000`, Kestrel largely ignores the host name. Host `localhost` is a special case used for binding to loopback addresses. Any host other than an explicit IP address binds to all public IP addresses. `Host` headers aren't validated.

As a workaround, use Host Filtering Middleware. Host Filtering Middleware is provided by the [Microsoft.AspNetCore.HostFiltering](https://www.nuget.org/packages/Microsoft.AspNetCore.HostFiltering) package, which is implicitly provided for ASP.NET Core apps. The middleware is added by <xref:Microsoft.AspNetCore.WebHost.CreateDefaultBuilder%2A>, which calls <xref:Microsoft.AspNetCore.Builder.HostFilteringServicesExtensions.AddHostFiltering%2A>:

:::code language="csharp" source="kestrel/samples-snapshot/2.x/KestrelSample/Program.cs" id="snippet_Program" highlight="9":::

Host Filtering Middleware is disabled by default. To enable the middleware, define an `AllowedHosts` key in `appsettings.json`/`appsettings.{Environment}.json`. The value is a semicolon-delimited list of host names without port numbers:

`appsettings.json`:

```json
{
  "AllowedHosts": "example.com;localhost"
}
```

> [!NOTE]
> [Forwarded Headers Middleware](xref:host-and-deploy/proxy-load-balancer) also has an <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.AllowedHosts> option. Forwarded Headers Middleware and Host Filtering Middleware have similar functionality for different scenarios. Setting `AllowedHosts` with Forwarded Headers Middleware is appropriate when the `Host` header isn't preserved while forwarding requests with a reverse proxy server or load balancer. Setting `AllowedHosts` with Host Filtering Middleware is appropriate when Kestrel is used as a public-facing edge server or when the `Host` header is directly forwarded.
>
> For more information on Forwarded Headers Middleware, see <xref:host-and-deploy/proxy-load-balancer>.

## Libuv transport configuration

For projects that require the use of Libuv (<xref:Microsoft.AspNetCore.Hosting.WebHostBuilderLibuvExtensions.UseLibuv%2A>):

* Add a dependency for the [`Microsoft.AspNetCore.Server.Kestrel.Transport.Libuv`](https://www.nuget.org/packages/Microsoft.AspNetCore.Server.Kestrel.Transport.Libuv) package to the app's project file:

  ```xml
  <PackageReference Include="Microsoft.AspNetCore.Server.Kestrel.Transport.Libuv"
                    Version="{VERSION}" />
  ```

* Call <xref:Microsoft.AspNetCore.Hosting.WebHostBuilderLibuvExtensions.UseLibuv%2A> on the `IWebHostBuilder`:

  ```csharp
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
                  webBuilder.UseLibuv();
                  webBuilder.UseStartup<Startup>();
              });
  }
  ```

## HTTP/1.1 request draining

Opening HTTP connections is time consuming. For HTTPS, it's also resource intensive. Therefore, Kestrel tries to reuse connections per the HTTP/1.1 protocol. A request body must be fully consumed to allow the connection to be reused. The app doesn't always consume the request body, such as a `POST` requests where the server returns a redirect or 404 response. In the `POST`-redirect case:

* The client may already have sent part of the `POST` data.
* The server writes the 301 response.
* The connection can't be used for a new request until the `POST` data from the previous request body has been fully read.
* Kestrel tries to drain the request body. Draining the request body means reading and discarding the data without processing it.

The draining process makes a tradeoff between allowing the connection to be reused and the time it takes to drain any remaining data:

* Draining has a timeout of five seconds, which isn't configurable.
* If all of the data specified by the `Content-Length` or `Transfer-Encoding` header hasn't been read before the timeout, the connection is closed.

Sometimes you may want to terminate the request immediately, before or after writing the response. For example, clients may have restrictive data caps, so limiting uploaded data might be a priority. In such cases to terminate a request, call [HttpContext.Abort](xref:Microsoft.AspNetCore.Http.HttpContext.Abort%2A) from a controller, Razor Page, or middleware.

There are caveats to calling `Abort`:

* Creating new connections can be slow and expensive.
* There's no guarantee that the client has read the response before the connection closes.
* Calling `Abort` should be rare and reserved for severe error cases, not common errors.
  * Only call `Abort` when a specific problem needs to be solved. For example, call `Abort` if malicious clients are trying to `POST` data or when there's a bug in client code that causes large or numerous requests.
  * Don't call `Abort` for common error situations, such as HTTP 404 (Not Found).

Calling [HttpResponse.CompleteAsync](xref:Microsoft.AspNetCore.Http.HttpResponse.CompleteAsync%2A) before calling `Abort` ensures that the server has completed writing the response. However, client behavior isn't predictable and they may not read the response before the connection is aborted.

This process is different for HTTP/2 because the protocol supports aborting individual request streams without closing the connection. The five second drain timeout doesn't apply. If there's any unread request body data after completing a response, then the server sends an HTTP/2 RST frame. Additional request body data frames are ignored.

If possible, it's better for clients to utilize the [Expect: 100-continue](https://developer.mozilla.org/docs/Web/HTTP/Status/100) request header and wait for the server to respond before starting to send the request body. That gives the client an opportunity to examine the response and abort before sending unneeded data.

## Additional resources

* When using UNIX sockets on Linux, the socket is not automatically deleted on app shut down. For more information, see [this GitHub issue](https://github.com/dotnet/aspnetcore/issues/14134).
* <xref:test/troubleshoot>
* <xref:security/enforcing-ssl>
* <xref:host-and-deploy/proxy-load-balancer>
* [RFC 7230: Message Syntax and Routing (Section 5.4: Host)](https://tools.ietf.org/html/rfc7230#section-5.4)

:::moniker-end
