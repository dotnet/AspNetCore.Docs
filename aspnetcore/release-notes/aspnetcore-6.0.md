---
title: What's new in ASP.NET Core 6.0
author: rick-anderson
description: Learn about the new features in ASP.NET Core 6.0.
ms.author: riande
ms.custom: mvc
ms.date: 10/29/2021
no-loc: [Home, Privacy, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR, Kestrel]
uid: aspnetcore-6.0
---
# What's new in ASP.NET Core 6.0

This article highlights the most significant changes in ASP.NET Core 6.0 with links to relevant documentation.

## ASP.NET Core MVC and Razor improvements

## Minimal APIs

Minimal APIs are architected to create HTTP APIs with minimal dependencies. They are ideal for microservices and apps that want to include only the minimum files, features, and dependencies in ASP.NET Core. See <xref:tutorials/min-web-api> for more information.

## Blazor

## SignalR

## Kestrel

See <xref:fundamentals/servers/kestrel/http3> and the blog entry [HTTP/3 support in .NET 6](https://devblogs.microsoft.com/dotnet/http-3-support-in-dotnet-6/).

### Emit KestrelServerOptions via EventSource event

The [KestrelEventSource](https://github.com/dotnet/aspnetcore/blob/v6.0.0-rc.2.21480.10/src/Servers/Kestrel/Core/src/Internal/Infrastructure/KestrelEventSource.cs) emits a new event containing the JSON-serialized <xref:Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions> when enabled with verbosity `EventLevel.LogAlways`. This event makes it easier to reason about the server behavior when analyzing collected traces. The following JSON is an example of the event payload:

```json
{
  "AllowSynchronousIO": false,
  "AddServerHeader": true,
  "AllowAlternateSchemes": false,
  "AllowResponseHeaderCompression": true,
  "EnableAltSvc": false,
  "IsDevCertLoaded": true,
  "RequestHeaderEncodingSelector": "default",
  "ResponseHeaderEncodingSelector": "default",
  "Limits": {
    "KeepAliveTimeout": "00:02:10",
    "MaxConcurrentConnections": null,
    "MaxConcurrentUpgradedConnections": null,
    "MaxRequestBodySize": 30000000,
    "MaxRequestBufferSize": 1048576,
    "MaxRequestHeaderCount": 100,
    "MaxRequestHeadersTotalSize": 32768,
    "MaxRequestLineSize": 8192,
    "MaxResponseBufferSize": 65536,
    "MinRequestBodyDataRate": "Bytes per second: 240, Grace Period: 00:00:05",
    "MinResponseDataRate": "Bytes per second: 240, Grace Period: 00:00:05",
    "RequestHeadersTimeout": "00:00:30",
    "Http2": {
      "MaxStreamsPerConnection": 100,
      "HeaderTableSize": 4096,
      "MaxFrameSize": 16384,
      "MaxRequestHeaderFieldSize": 16384,
      "InitialConnectionWindowSize": 131072,
      "InitialStreamWindowSize": 98304,
      "KeepAlivePingDelay": "10675199.02:48:05.4775807",
      "KeepAlivePingTimeout": "00:00:20"
    },
    "Http3": {
      "HeaderTableSize": 0,
      "MaxRequestHeaderFieldSize": 16384
    }
  },
  "ListenOptions": [
    {
      "Address": "https://127.0.0.1:7030",
      "IsTls": true,
      "Protocols": "Http1AndHttp2"
    },
    {
      "Address": "https://[::1]:7030",
      "IsTls": true,
      "Protocols": "Http1AndHttp2"
    },
    {
      "Address": "http://127.0.0.1:5030",
      "IsTls": false,
      "Protocols": "Http1AndHttp2"
    },
    {
      "Address": "http://[::1]:5030",
      "IsTls": false,
      "Protocols": "Http1AndHttp2"
    }
  ]
}
```

### New DiagnosticSource event for rejected HTTP requests

Kestrel now emits a new `DiagnosticSource` event for HTTP requests rejected at the server layer. Prior to this change, there was no way to observe these rejected requests. The new `DiagnosticSource` event `Microsoft.AspNetCore.Server.Kestrel.BadRequest` contains a <xref:Microsoft.AspNetCore.Http.Features.IBadRequestExceptionFeature> that can be used to introspect the reason for rejecting the request.

[!code-csharp[](aspnetcore-6.0/samples/WebApp1/Program.cs?name=snippet_diag)]

For more information, see <xref:fundamentals/servers/kestrel/diagnostics>.

### Create a ConnectionContext from an Accept Socket

The new <xref:Microsoft.AspNetCore.Server.Kestrel.Transport.Sockets.SocketConnectionContextFactory> makes it possible to create a <xref:Microsoft.AspNetCore.Connections.ConnectionContext> from an accepted socket. This makes it possible to build a custom socket-based <xref:Microsoft.AspNetCore.Connections.IConnectionListenerFactory> without losing out on all the performance work and pooling happening in [SocketConnection](https://github.com/dotnet/aspnetcore/blob/v6.0.0-rc.2.21480.10/src/Servers/Kestrel/Transport.Sockets/src/Internal/SocketConnection.cs).

See [this example of a custom IConnectionListenerFactory](https://github.com/davidfowl/TcpProxy/blob/main/Backend/DelegatedConnectionListenerFactory.cs) which shows how to use this `SocketConnectionContextFactory`.

## Authentication and authorization

### Authentication servers

.NET 3 to .NET 5 used [IdentityServer4](https://identityserver4.readthedocs.io/latest/) as part of our template to support the issuing of JWT tokens for SPA and Blazor applications. The templates now use the [Duende Identity Server](https://docs.duendesoftware.com/identityserver/v5).

If you are extending the identity models and are updating existing projects you will need to update the namespaces in your code from `IdentityServer4.IdentityServer` to `Duende.IdentityServer` and follow their [migration instructions](https://docs.duendesoftware.com/identityserver/v5/upgrades/).

The license model for Duende Identity Server has changed to a reciprocal license, which may require license fees when it's used commercially in production. See the [Duende license page](https://duendesoftware.com/products/identityserver#pricing) for more details.

## API improvements

## Miscellaneous

### Hot reload

Quickly make UI and code updates to running apps without losing app state for faster and more productive developer experience using [Hot reload](https://devblogs.microsoft.com/dotnet/introducing-net-hot-reload/). For more information, see [Update on .NET Hot Reload progress and Visual Studio 2022 Highlights](https://devblogs.microsoft.com/dotnet/update-on-net-hot-reload-progress-and-visual-studio-2022-highlights/).

<!-- Notes:
### Single-file publishing
Moved to .NET 7 https://github.com/dotnet/aspnetcore/issues/27888#event-5487147790
-->

### Single-page app (SPA) support
<!-- TODO @LadyNaggaga to provide this section-->

### Draft HTTP/3 support in .NET 6

[HTTP/3](https://datatracker.ietf.org/doc/html/draft-ietf-quic-http-34) is currently in draft and therefore subject to change. HTTP/3 support in ASP.NET Core is not released, it's a preview feature included in .NET 6.

See the blog entry [HTTP/3 support in .NET 6](https://devblogs.microsoft.com/dotnet/http-3-support-in-dotnet-6/).

### Nullable Reference Type Annotations

Portions of the [ASP.NET Core 6.0 source code](https://github.com/dotnet/aspnetcore/tree/v6.0.0-rc.2.21480.10/src) has had [nullability annotations](/dotnet/csharp/nullable-migration-strategies) applied.

By utilizing the new Nullable feature in C# 8, ASP.NET Core can provide additional compile-time safety in the handling of reference types. For example, protecting against `null` reference exceptions. Projects that have opted in to using nullable annotations may see new build-time warnings from ASP.NET Core APIs.

To enable nullable reference types, add the following property to project files:

```xml
<PropertyGroup>
    <Nullable>enable</Nullable>
</PropertyGroup>
```

 For more information, see [Nullable reference types](/dotnet/csharp/nullable-references).

### Source Code Analysis

Several .NET compiler platform analyzers were added that inspect application code for problems such as incorrect middleware configuration or order, routing conflicts, etc. For more information, see <xref:diagnostics/code-analysis>.

### Web app template improvements

The web app templates enable [implicit `global using` directives](/dotnet/core/compatibility/sdk/6.0/implicit-namespaces).

Random ports are assigned during project creation for use by the Kestrel web server. Random ports help minimize a port conflict when multiple projects are run on the same machine.

When a project is created, a random HTTP port between 5000-5300 and a random HTTPS port between 7000-7300 is specified in the generated *Properties/launchSettings.json* file. The ports can be changed in the *Properties/launchSettings.json* file. If no port is specified, Kestrel  defaults to the HTTP 5000 and HTTPS 5001 ports. For more information, see <xref:fundamentals/servers/kestrel/endpoints>.

#### New logging defaults

The following changes were made to both `appsettings.json` and `appsettings.Development.json`:

```diff
- "Microsoft": "Warning",
- "Microsoft.Hosting.Lifetime": "Information"
+ "Microsoft.AspNetCore": "Warning"
```

The change from `"Microsoft": "Warning"` to `"Microsoft.AspNetCore": "Warning"` results in logging all informational messages from the `Microsoft` namespace ***except*** `Microsoft.AspNetCore`. For example, `Microsoft.EntityFrameworkCore` is now logged at the informational level.

### Developer exception page Middleware added automatically

In the [develoment environment](xref:fundamentals/environments), the <xref:Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware> is added by default. It's no longer necessary to add the following code to web UI apps:

```csharp
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
```

### Support for Latin1 encoded request headers in HttpSysServer

`HttpSysServer` now supports decoding request headers that are `Latin1` encoded by setting the <xref:Microsoft.AspNetCore.Server.HttpSys.HttpSysOptions.UseLatin1RequestHeaders> property on <xref:Microsoft.AspNetCore.Server.HttpSys.HttpSysOptions> to `true`:

[!code-csharp[](aspnetcore-6.0/samples/WebApp1/Program.cs?name=snippet_latin)]

### The ASP.NET Core Module logs include timestamps and PID

The <xref:host-and-deploy/aspnet-core-module> (ANCM) enhanced diagnostic logs include timestamps and [PID](https://wikipedia.org/wiki/Process_identifier) of the process emitting the logs. Logging timestamps and PID makes it easier to diagnose issues with overlapping process restarts in IIS when multiple IIS worker processes are running.

The resulting logs now resemble the sample output show below:

```dotnetcli
[2021-07-28T19:23:44.076Z, PID: 11020] [aspnetcorev2.dll] Initializing logs for 'C:\<path>\aspnetcorev2.dll'. Process Id: 11020. File Version: 16.0.21209.0. Description: IIS ASP.NET Core Module V2. Commit: 96475a2acdf50d7599ba8e96583fa73efbe27912.
[2021-07-28T19:23:44.079Z, PID: 11020] [aspnetcorev2.dll] Resolving hostfxr parameters for application: '.\InProcessWebSite.exe' arguments: '' path: 'C:\Temp\e86ac4e9ced24bb6bacf1a9415e70753\'
[2021-07-28T19:23:44.080Z, PID: 11020] [aspnetcorev2.dll] Known dotnet.exe location: ''
```