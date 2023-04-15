---
title: Kestrel web server in ASP.NET Core
author: tdykstra
description: Learn about Kestrel, the cross-platform web server for ASP.NET Core.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 04/04/2023
uid: fundamentals/servers/kestrel
---
# Kestrel web server in ASP.NET Core

By [Tom Dykstra](https://github.com/tdykstra), [Chris Ross](https://github.com/Tratcher), and [Stephen Halter](https://twitter.com/halter73)

:::moniker range=">= aspnetcore-8.0"

Kestrel is a cross-platform [web server for ASP.NET Core](xref:fundamentals/servers/index). Kestrel is the recommended server for ASP.NET Core, and it's configured by default in ASP.NET Core project templates.

Kestrel's features include:

* **Cross-platform:** Kestrel is a cross-platform web server that runs on Windows, Linux, and macOS.
* **High performance:** Kestrel is optimized to handle a large number of concurrent connections efficiently.
* **Lightweight:** Optimized for running in resource-constrained environments, such as containers and edge devices.
* **Security hardened:** Kestrel supports HTTPS and is hardened against web server vulnerabilities.
* **Wide protocol support:** Kestrel supports common web protocols, including:
  * HTTP/1.1, [HTTP/2](xref:fundamentals/servers/kestrel/http2) and [HTTP/3](xref:fundamentals/servers/kestrel/http3)
  * [WebSockets](xref:fundamentals/websockets)
* **Integration with ASP.NET Core:** Seamless integration with other ASP.NET Core components, such as the middleware pipeline, dependency injection, and configuration system.
* **Flexible workloads**: Kestrel supports many workloads:
  * ASP.NET app frameworks such as Minimal APIs, MVC, Razor pages, SignalR, Blazor, and gRPC.
  * Building a reverse proxy with [YARP](https://github.com/microsoft/reverse-proxy).
* **Extensibility:** Customize Kestrel through configuration, middleware, and custom transports.
* **Performance diagnostics:** Kestrel provides built-in performance diagnostics features, such as logging and metrics.

## Get started

ASP.NET Core project templates use Kestrel by default when not hosted with IIS. In the following template-generated `Program.cs`, the <xref:Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder%2A?displayProperty=nameWithType> method calls <xref:Microsoft.AspNetCore.Hosting.WebHostBuilderKestrelExtensions.UseKestrel%2A> internally:

:::code language="csharp" source="~/fundamentals/servers/kestrel/samples/6.x/KestrelSample/Program.cs" id="snippet_CreateBuilder" highlight="1":::

For more information on configuring `WebApplication` and `WebApplicationBuilder`, see <xref:fundamentals/minimal-apis>.

## Optional client certificates

For information on apps that must protect a subset of the app with a certificate, see [Optional client certificates](xref:security/authentication/certauth#optional-client-certificates).

## Behavior with debugger attached

The following timeouts and rate limits aren't enforced when a debugger is attached to a Kestrel process:

* <xref:Microsoft.AspNetCore.Server.Kestrel.KestrelServerLimits.KeepAliveTimeout?displayProperty=nameWithType>
* <xref:Microsoft.AspNetCore.Server.Kestrel.KestrelServerLimits.RequestHeadersTimeout?displayProperty=nameWithType>
* <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerLimits.MinRequestBodyDataRate?displayProperty=nameWithType>
* <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerLimits.MinResponseDataRate?displayProperty=nameWithType>
* <xref:Microsoft.AspNetCore.Server.Kestrel.Core.Features.IConnectionTimeoutFeature>
* <xref:Microsoft.AspNetCore.Server.Kestrel.Core.Features.IHttpMinRequestBodyDataRateFeature>
* <xref:Microsoft.AspNetCore.Server.Kestrel.Core.Features.IHttpMinResponseDataRateFeature>

## Additional resources

<a name="endpoint-configuration"></a>
* <xref:fundamentals/servers/kestrel/endpoints>
* Source for [`WebApplication.CreateBuilder` method call to `UseKestrel`](https://github.com/dotnet/aspnetcore/blob/v6.0.2/src/DefaultBuilder/src/WebHost.cs#L224)
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
* [RFC 9110: HTTP Semantics (Section 7.2: Host and :authority)](https://www.rfc-editor.org/rfc/rfc9110#field.host)
* When using UNIX sockets on Linux, the socket isn't automatically deleted on app shutdown. For more information, see [this GitHub issue](https://github.com/dotnet/aspnetcore/issues/14134).

> [!NOTE]
> As of ASP.NET Core 5.0, Kestrel's libuv transport is obsolete. The libuv transport doesn't receive updates to support new OS platforms, such as Windows ARM64, and will be removed in a future release. Remove any calls to the obsolete <xref:Microsoft.AspNetCore.Hosting.WebHostBuilderLibuvExtensions.UseLibuv%2A> method and use Kestrel's default Socket transport instead.

:::moniker-end

[!INCLUDE[](~/fundamentals/servers/kestrel/includes/kestrel6.md)]
