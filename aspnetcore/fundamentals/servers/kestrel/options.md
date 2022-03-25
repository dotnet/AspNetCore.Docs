---
title: Configure options for the ASP.NET Core Kestrel web server
author: rick-anderson
description: Learn about configuring options for Kestrel, the cross-platform web server for ASP.NET Core.
monikerRange: '>= aspnetcore-5.0'
ms.author: riande
ms.custom: mvc
ms.date: 01/20/2022
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: fundamentals/servers/kestrel/options
---
# Configure options for the ASP.NET Core Kestrel web server

:::moniker range=">= aspnetcore-6.0"

The Kestrel web server has constraint configuration options that are especially useful in Internet-facing deployments. To configure Kestrel configuration options, call <xref:Microsoft.AspNetCore.Hosting.WebHostBuilderKestrelExtensions.ConfigureKestrel%2A> in `Program.cs`:

:::code language="csharp" source="samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_ConfigureKestrel":::

Set constraints on the <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.Limits%2A?displayProperty=nameWithType> property. This property holds an instance of the <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerLimits> class.

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

By default, Kestrel configuration is loaded from the `Kestrel` section using a preconfigured set of configuration providers. For more information on the default set of configuration providers, see [Default configuration](xref:fundamentals/configuration/index#default-configuration).

> [!NOTE]
> <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions> and [endpoint configuration](xref:fundamentals/servers/kestrel/endpoints) are configurable from configuration providers. Set other Kestrel configuration in C# code.

## General limits

### Keep-alive timeout

<xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerLimits.KeepAliveTimeout> gets or sets the [keep-alive timeout](https://tools.ietf.org/html/rfc7230#section-6.5):

:::code language="csharp" source="samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_ConfigureKestrelLimitsKeepAliveTimeout" highlight="3":::

### Maximum client connections

<xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerLimits.MaxConcurrentConnections> gets or sets the maximum number of open connections:

:::code language="csharp" source="samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_ConfigureKestrelLimitsMaxConcurrentConnections" highlight="3":::

<xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerLimits.MaxConcurrentUpgradedConnections> gets or sets the maximum number of open, upgraded connections:

:::code language="csharp" source="samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_ConfigureKestrelLimitsMaxConcurrentUpgradedConnections" highlight="3":::

An upgraded connection is one that has been switched from HTTP to another protocol, such as WebSockets. After a connection is upgraded, it isn't counted against the `MaxConcurrentConnections` limit.

### Maximum request body size

<xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerLimits.MaxRequestBodySize> gets or sets the maximum allowed size of any request body in bytes.

The recommended approach to override the limit in an ASP.NET Core MVC app is to use the <xref:Microsoft.AspNetCore.Mvc.RequestSizeLimitAttribute> attribute on an action method:

:::code language="csharp" source="samples/6.x/KestrelSample/Snippets/Controllers/SampleController.cs" id="snippet_RequestSizeLimit":::

The following example configures `MaxRequestBodySize` for all requests:

:::code language="csharp" source="samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_ConfigureKestrelLimitsMaxRequestBodySize" highlight="3":::

The following example configures `MaxRequestBodySize` for a specific request using <xref:Microsoft.AspNetCore.Http.Features.IHttpMaxRequestBodySizeFeature> in a custom middleware:

:::code language="csharp" source="samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_IHttpMaxRequestBodySizeFeatureMiddleware":::

If the app attempts to configure the limit on a request after it starts to read the request, an exception is thrown. Ue the <xref:Microsoft.AspNetCore.Http.Features.IHttpMaxRequestBodySizeFeature.IsReadOnly%2A?displayProperty=nameWithType> property to check if it's safe to set the `MaxRequestBodySize` property.

When an app runs [out-of-process](xref:host-and-deploy/iis/index#out-of-process-hosting-model) behind the [ASP.NET Core Module](xref:host-and-deploy/aspnet-core-module), IIS sets the limit and Kestrel's request body size limit is disabled.

### Minimum request body data rate

Kestrel checks every second if data is arriving at the specified rate in bytes/second. If the rate drops below the minimum, the connection is timed out. The grace period is the amount of time Kestrel allows the client to increase its send rate up to the minimum. The rate isn't checked during that time. The grace period helps avoid dropping connections that are initially sending data at a slow rate because of TCP slow-start. A minimum rate also applies to the response.

<xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerLimits.MinRequestBodyDataRate> gets or sets the request body minimum data rate in bytes/second. <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerLimits.MinResponseDataRate> gets or sets the response minimum data rate in bytes/second.

The following example configures `MinRequestBodyDataRate` and `MinResponseDataRate` for all requests:

:::code language="csharp" source="samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_ConfigureKestrelLimitsMinDataRates" highlight="3-6":::

The following example configures `MinRequestBodyDataRate` and `MinResponseDataRate` for a specific request using <xref:Microsoft.AspNetCore.Server.Kestrel.Core.Features.IHttpMinRequestBodyDataRateFeature> and <xref:Microsoft.AspNetCore.Server.Kestrel.Core.Features.IHttpMinResponseDataRateFeature> in a custom middleware:

:::code language="csharp" source="samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_DataRateFeaturesMiddleware":::

`IHttpMinResponseDataRateFeature` isn't present in <xref:Microsoft.AspNetCore.Http.HttpContext.Features?displayProperty=nameWithType> for HTTP/2 requests. Modifying rate limits on a per-request basis isn't generally supported for HTTP/2 because of the protocol's support for request multiplexing. However, `IHttpMinRequestBodyDataRateFeature` is still present in `HttpContext.Features` for HTTP/2 requests, because the read rate limit can still be *disabled entirely* on a per-request basis by setting <xref:Microsoft.AspNetCore.Server.Kestrel.Core.Features.IHttpMinResponseDataRateFeature.MinDataRate?displayProperty=nameWithType> to `null`, even for an HTTP/2 request. Attempts to read `IHttpMinRequestBodyDataRateFeature.MinDataRate` or attempts to set it to a value other than `null` result in a <xref:System.NotSupportedException> for HTTP/2 requests.

Server-wide rate limits configured via <xref:Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions.Limits?displayProperty=nameWithType> still apply to both HTTP/1.x and HTTP/2 connections.

### Request headers timeout

<xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerLimits.RequestHeadersTimeout> gets or sets the maximum amount of time the server spends receiving request headers:

:::code language="csharp" source="samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_ConfigureKestrelLimitsRequestHeadersTimeout" highlight="3":::

## HTTP/2 limits

The limits in this section are set on <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerLimits.Http2?displayProperty=nameWithType>.

### Maximum streams per connection

<xref:Microsoft.AspNetCore.Server.Kestrel.Core.Http2Limits.MaxStreamsPerConnection> limits the number of concurrent request streams per HTTP/2 connection. Excess streams are refused:

:::code language="csharp" source="samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_ConfigureKestrelHttp2LimitsMaxStreamsPerConnection" highlight="3":::

### Header table size

<xref:Microsoft.AspNetCore.Server.Kestrel.Core.Http2Limits.HeaderTableSize> limits the size of the header compression tables, in octets, the HPACK encoder and decoder on the server can use. The HPACK decoder decompresses HTTP headers for HTTP/2 connections:

:::code language="csharp" source="samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_ConfigureKestrelHttp2LimitsHeaderTableSize" highlight="3":::

### Maximum frame size

<xref:Microsoft.AspNetCore.Server.Kestrel.Core.Http2Limits.MaxFrameSize> indicates the size of the largest frame payload that is allowed to be received, in octets:

:::code language="csharp" source="samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_ConfigureKestrelHttp2LimitsMaxFrameSize" highlight="3":::

### Maximum request header size

<xref:Microsoft.AspNetCore.Server.Kestrel.Core.Http2Limits.MaxRequestHeaderFieldSize> indicates the size of the maximum allowed size of a request header field sequence. This limit applies to both name and value sequences in their compressed and uncompressed representations:

:::code language="csharp" source="samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_ConfigureKestrelHttp2LimitsMaxRequestHeaderFieldSize" highlight="3":::

### Initial connection window size

<xref:Microsoft.AspNetCore.Server.Kestrel.Core.Http2Limits.InitialConnectionWindowSize> indicates how much request body data the server is willing to receive and buffer at a time aggregated across all requests (streams) per connection:

:::code language="csharp" source="samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_ConfigureKestrelHttp2LimitsInitialConnectionWindowSize" highlight="3":::

Requests are also limited by [`InitialStreamWindowSize`](#initial-stream-window-size).

### Initial stream window size

<xref:Microsoft.AspNetCore.Server.Kestrel.Core.Http2Limits.InitialStreamWindowSize> indicates how much request body data the server is willing to receive and buffer at a time per stream:

:::code language="csharp" source="samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_ConfigureKestrelHttp2LimitsInitialStreamWindowSize" highlight="3":::

Requests are also limited by [`InitialConnectionWindowSize`](#initial-connection-window-size).

### HTTP/2 keep alive ping configuration

Kestrel can be configured to send HTTP/2 pings to connected clients. HTTP/2 pings serve multiple purposes:

* Keep idle connections alive. Some clients and proxy servers close connections that are idle. HTTP/2 pings are considered as activity on a connection and prevent the connection from being closed as idle.
* Close unhealthy connections. Connections where the client doesn't respond to the keep alive ping in the configured time are closed by the server.

There are two configuration options related to HTTP/2 keep alive pings:

* <xref:Microsoft.AspNetCore.Server.Kestrel.Core.Http2Limits.KeepAlivePingDelay> is a <xref:System.TimeSpan> that configures the ping interval. The server sends a keep alive ping to the client if it doesn't receive any frames for this period of time. Keep alive pings are disabled when this option is set to <xref:System.TimeSpan.MaxValue?displayProperty=nameWithType>.
* <xref:Microsoft.AspNetCore.Server.Kestrel.Core.Http2Limits.KeepAlivePingTimeout> is a <xref:System.TimeSpan> that configures the ping timeout. If the server doesn't receive any frames, such as a response ping, during this timeout then the connection is closed. Keep alive timeout is disabled when this option is set to <xref:System.TimeSpan.MaxValue?displayProperty=nameWithType>.

The following example sets `KeepAlivePingDelay` and `KeepAlivePingTimeout`:

:::code language="csharp" source="samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_ConfigureKestrelHttp2LimitsKeepAlivePings" highlight="3-4":::

## Other options

### Synchronous I/O

<xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.AllowSynchronousIO> controls whether synchronous I/O is allowed for the request and response.

> [!WARNING]
> A large number of blocking synchronous I/O operations can lead to thread pool starvation, which makes the app unresponsive. Only enable `AllowSynchronousIO` when using a library that doesn't support asynchronous I/O.

The following example enables synchronous I/O:

:::code language="csharp" source="samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_ConfigureKestrelAllowSynchronousIO" highlight="3":::

For information about other Kestrel options and limits, see:

* <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions>
* <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerLimits>
* <xref:Microsoft.AspNetCore.Server.Kestrel.Core.ListenOptions>
    
:::moniker-end

:::moniker range="< aspnetcore-6.0"

The Kestrel web server has constraint configuration options that are especially useful in Internet-facing deployments.

To provide more configuration after calling <xref:Microsoft.Extensions.Hosting.GenericHostBuilderExtensions.ConfigureWebHostDefaults%2A>, use <xref:Microsoft.AspNetCore.Hosting.WebHostBuilderKestrelExtensions.ConfigureKestrel%2A>:

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
> <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions> and [endpoint configuration](xref:fundamentals/servers/kestrel/endpoints) are configurable from configuration providers. Remaining Kestrel configuration must be configured in C# code.

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

## General limits

### Keep-alive timeout

<xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerLimits.KeepAliveTimeout>

Gets or sets the [keep-alive timeout](https://tools.ietf.org/html/rfc7230#section-6.5). Defaults to 2 minutes.

:::code language="csharp" source="samples/5.x/KestrelSample/Program.cs" id="snippet_Limits" highlight="19-20":::

### Maximum client connections

<xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerLimits.MaxConcurrentConnections><br>
<xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerLimits.MaxConcurrentUpgradedConnections>

The maximum number of concurrent open TCP connections can be set for the entire app with the following code:

:::code language="csharp" source="samples/5.x/KestrelSample/Program.cs" id="snippet_Limits" highlight="3":::

There's a separate limit for connections that have been upgraded from HTTP or HTTPS to another protocol (for example, on a WebSockets request). After a connection is upgraded, it isn't counted against the `MaxConcurrentConnections` limit.

:::code language="csharp" source="samples/5.x/KestrelSample/Program.cs" id="snippet_Limits" highlight="4":::

The maximum number of connections is unlimited (null) by default.

### Maximum request body size

<xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerLimits.MaxRequestBodySize>

The default maximum request body size is 30,000,000 bytes, which is approximately 28.6 MB.

The recommended approach to override the limit in an ASP.NET Core MVC app is to use the <xref:Microsoft.AspNetCore.Mvc.RequestSizeLimitAttribute> attribute on an action method:

```csharp
[RequestSizeLimit(100000000)]
public IActionResult MyActionMethod()
```

The following example shows how to configure the constraint for the app on every request:

:::code language="csharp" source="samples/5.x/KestrelSample/Program.cs" id="snippet_Limits" highlight="5":::

Override the setting on a specific request in middleware:

:::code language="csharp" source="samples/5.x/KestrelSample/Startup.cs" id="snippet_Limits" highlight="3-4":::

An exception is thrown if the app configures the limit on a request after the app has started to read the request. There's an `IsReadOnly` property that indicates if the `MaxRequestBodySize` property is in read-only state, meaning it's too late to configure the limit.

When an app runs [out-of-process](xref:host-and-deploy/iis/index#out-of-process-hosting-model) behind the [ASP.NET Core Module](xref:host-and-deploy/aspnet-core-module), Kestrel's request body size limit is disabled. IIS already sets the limit.

### Minimum request body data rate

<xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerLimits.MinRequestBodyDataRate><br>
<xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerLimits.MinResponseDataRate>

Kestrel checks every second if data is arriving at the specified rate in bytes/second. If the rate drops below the minimum, the connection is timed out. The grace period is the amount of time Kestrel allows the client to increase its send rate up to the minimum. The rate isn't checked during that time. The grace period helps avoid dropping connections that are initially sending data at a slow rate because of TCP slow-start.

The default minimum rate is 240 bytes/second with a 5-second grace period.

A minimum rate also applies to the response. The code to set the request limit and the response limit is the same except for having `RequestBody` or `Response` in the property and interface names.

Here's an example that shows how to configure the minimum data rates in `Program.cs`:

:::code language="csharp" source="samples/5.x/KestrelSample/Program.cs" id="snippet_Limits" highlight="6-11":::

Override the minimum rate limits per request in middleware:

:::code language="csharp" source="samples/5.x/KestrelSample/Startup.cs" id="snippet_Limits" highlight="6-21":::

The <xref:Microsoft.AspNetCore.Server.Kestrel.Core.Features.IHttpMinResponseDataRateFeature> referenced in the prior sample isn't present in <xref:Microsoft.AspNetCore.Http.HttpContext.Features?displayProperty=nameWithType> for HTTP/2 requests. Modifying rate limits on a per-request basis isn't generally supported for HTTP/2 because of the protocol's support for request multiplexing. However, the <xref:Microsoft.AspNetCore.Server.Kestrel.Core.Features.IHttpMinRequestBodyDataRateFeature> is still present `HttpContext.Features` for HTTP/2 requests, because the read rate limit can still be *disabled entirely* on a per-request basis by setting <xref:Microsoft.AspNetCore.Server.Kestrel.Core.Features.IHttpMinResponseDataRateFeature.MinDataRate?displayProperty=nameWithType> to `null` even for an HTTP/2 request. Attempting to read `IHttpMinRequestBodyDataRateFeature.MinDataRate` or attempting to set it to a value other than `null` will result in a <xref:System.NotSupportedException> being thrown given an HTTP/2 request.

Server-wide rate limits configured via <xref:Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions.Limits?displayProperty=nameWithType> still apply to both HTTP/1.x and HTTP/2 connections.

### Request headers timeout

<xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerLimits.RequestHeadersTimeout>

Gets or sets the maximum amount of time the server spends receiving request headers. Defaults to 30 seconds.

:::code language="csharp" source="samples/5.x/KestrelSample/Program.cs" id="snippet_Limits" highlight="21-22":::

## HTTP/2 limits

The limits in this section are set on <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerLimits.Http2?displayProperty=nameWithType>.

### Maximum streams per connection

<xref:Microsoft.AspNetCore.Server.Kestrel.Core.Http2Limits.MaxStreamsPerConnection>

Limits the number of concurrent request streams per HTTP/2 connection. Excess streams are refused.

```csharp
webBuilder.ConfigureKestrel(serverOptions =>
{
    serverOptions.Limits.Http2.MaxStreamsPerConnection = 100;
});
```

The default value is 100.

### Header table size

<xref:Microsoft.AspNetCore.Server.Kestrel.Core.Http2Limits.HeaderTableSize>

The HPACK decoder decompresses HTTP headers for HTTP/2 connections. `HeaderTableSize` limits the size of the header compression table that the HPACK decoder uses. The value is provided in octets and must be greater than zero (0).

```csharp
webBuilder.ConfigureKestrel(serverOptions =>
{
    serverOptions.Limits.Http2.HeaderTableSize = 4096;
});
```

The default value is 4096.

### Maximum frame size

<xref:Microsoft.AspNetCore.Server.Kestrel.Core.Http2Limits.MaxFrameSize>

Indicates the maximum allowed size of an HTTP/2 connection frame payload received or sent by the server. The value is provided in octets and must be between 2^14 (16,384) and 2^24-1 (16,777,215).

```csharp
webBuilder.ConfigureKestrel(serverOptions =>
{
    serverOptions.Limits.Http2.MaxFrameSize = 16384;
});
```

The default value is 2^14 (16,384).

### Maximum request header size

<xref:Microsoft.AspNetCore.Server.Kestrel.Core.Http2Limits.MaxRequestHeaderFieldSize>

Indicates the maximum allowed size in octets of request header values. This limit applies to both name and value in their compressed and uncompressed representations. The value must be greater than zero (0).

```csharp
webBuilder.ConfigureKestrel(serverOptions =>
{
    serverOptions.Limits.Http2.MaxRequestHeaderFieldSize = 8192;
});
```

The default value is 8,192.

### Initial connection window size

<xref:Microsoft.AspNetCore.Server.Kestrel.Core.Http2Limits.InitialConnectionWindowSize>

Indicates the maximum request body data in bytes the server buffers at one time, aggregated across all requests (streams) per connection. Requests are also limited by `Http2.InitialStreamWindowSize`. The value must be greater than or equal to 65,535 and less than 2^31 (2,147,483,648).

```csharp
webBuilder.ConfigureKestrel(serverOptions =>
{
    serverOptions.Limits.Http2.InitialConnectionWindowSize = 131072;
});
```

The default value is 128 KB (131,072).

### Initial stream window size

<xref:Microsoft.AspNetCore.Server.Kestrel.Core.Http2Limits.InitialStreamWindowSize>

Indicates the maximum request body data in bytes the server buffers at one time per request (stream). Requests are also limited by [`InitialConnectionWindowSize`](#initial-connection-window-size). The value must be greater than or equal to 65,535 and less than 2^31 (2,147,483,648).

```csharp
webBuilder.ConfigureKestrel(serverOptions =>
{
    serverOptions.Limits.Http2.InitialStreamWindowSize = 98304;
});
```

The default value is 96 KB (98,304).

### HTTP/2 keep alive ping configuration

Kestrel can be configured to send HTTP/2 pings to connected clients. HTTP/2 pings serve multiple purposes:

* Keep idle connections alive. Some clients and proxy servers close connections that are idle. HTTP/2 pings are considered as activity on a connection and prevent the connection from being closed as idle.
* Close unhealthy connections. Connections where the client doesn't respond to the keep alive ping in the configured time are closed by the server.

There are two configuration options related to HTTP/2 keep alive pings:

* <xref:Microsoft.AspNetCore.Server.Kestrel.Core.Http2Limits.KeepAlivePingDelay> is a <xref:System.TimeSpan> that configures the ping interval. The server sends a keep alive ping to the client if it doesn't receive any frames for this period of time. Keep alive pings are disabled when this option is set to <xref:System.TimeSpan.MaxValue?displayProperty=nameWithType>. The default value is <xref:System.TimeSpan.MaxValue?displayProperty=nameWithType>.
* <xref:Microsoft.AspNetCore.Server.Kestrel.Core.Http2Limits.KeepAlivePingTimeout> is a <xref:System.TimeSpan> that configures the ping timeout. If the server doesn't receive any frames, such as a response ping, during this timeout then the connection is closed. Keep alive timeout is disabled when this option is set to <xref:System.TimeSpan.MaxValue?displayProperty=nameWithType>. The default value is 20 seconds.

```csharp
webBuilder.ConfigureKestrel(serverOptions =>
{
    serverOptions.Limits.Http2.KeepAlivePingDelay = TimeSpan.FromSeconds(30);
    serverOptions.Limits.Http2.KeepAlivePingTimeout = TimeSpan.FromSeconds(60);
});
```

## Other options

### Synchronous I/O

<xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.AllowSynchronousIO> controls whether synchronous I/O is allowed for the request and response. The default value is `false`.

> [!WARNING]
> A large number of blocking synchronous I/O operations can lead to thread pool starvation, which makes the app unresponsive. Only enable `AllowSynchronousIO` when using a library that doesn't support asynchronous I/O.

The following example enables synchronous I/O:

:::code language="csharp" source="samples/5.x/KestrelSample/Program.cs" id="snippet_SyncIO":::

For information about other Kestrel options and limits, see:

* <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions>
* <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerLimits>
* <xref:Microsoft.AspNetCore.Server.Kestrel.Core.ListenOptions>

:::moniker-end
