---
title: Kestrel web server implementation in ASP.NET Core
author: rick-anderson
description: Learn about Kestrel, the cross-platform web server for ASP.NET Core.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 01/26/2023
uid: fundamentals/servers/kestrel
---
# Kestrel web server implementation in ASP.NET Core

By [Tom Dykstra](https://github.com/tdykstra), [Chris Ross](https://github.com/Tratcher), and [Stephen Halter](https://twitter.com/halter73)

:::moniker range=">= aspnetcore-8.0"

Kestrel is a cross-platform [web server for ASP.NET Core](xref:fundamentals/servers/index). Kestrel is the web server that's included and enabled by default in ASP.NET Core project templates.

Kestrel supports the following scenarios:

* HTTPS
* [HTTP/2](xref:fundamentals/servers/kestrel/http2)
* Opaque upgrade used to enable [WebSockets](xref:fundamentals/websockets)
* Unix sockets for high performance behind Nginx

Kestrel is supported on all platforms and versions that .NET Core supports.

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

## Shutdown

The following list details server shutdown:

* The Host receives a shutdown signal, for example, from `CTL+C`, [StopAsync](/aspnet/core/fundamentals/host/hosted-services#stopasync), etc.
* [IHostApplicationLifetime.ApplicationStopping](xref:Microsoft.Extensions.Hosting.IHostApplicationLifetime.ApplicationStopping) is signaled to notify the app. Long running operations should subscribe to this event.
* The Host calls [IServer.StopAsync](xref:Microsoft.AspNetCore.Hosting.Server.IServer.StopAsync%2A) with a configurable shutdown timeout. The default shutdown is 30 seconds.
* Kestrel (and [Http.Sys](/aspnet/core/fundamentals/servers/#kestrel-vs-httpsys)):
  * Close their port bindings and stop accepting new connections.
  * Signal current connections to stop processing new requests. For HTTP/2 and HTTP/3 this involves sending a preliminary GoAway message to the client. For HTTP/1.1, requests are processed in order so it stops that connection loop.
    * IIS is a little different, it rejects new requests with a [503](https://developer.mozilla.org/docs/Web/HTTP/Status/503) status.
* Active requests are given until the shutdown timeout to complete. If everything completes before the timeout then the server returns control to the host sooner. If the timeout expires then pending connections and requests are forcibly aborted. Aborting connections and requests can cause errors to be reported in the logs and to the clients.

### Using a load balancer for graceful shutdown

When working with a load balancer several steps can ensure a smooth transition of clients to a new destination:

* If other instances aren't running and able to meet demand, start a new server instance.
* Start balancing traffic to the other instances. Many apps run multiple instances and [auto scaling](/azure/azure-monitor/autoscale/autoscale-get-started?toc=%2Fazure%2Fapp-service%2Ftoc.json) to meet demand.
* Disable or remove the old instance in the load balancer configuration so it stops receiving new traffic.
* Signal the old instance to shut down.
* Wait for the shutting down server to drain or timeout.
<!--
(need specific examples for different environments)
-->

For detailed information on Generic host shutdown, see [Host shutdown](/dotnet/core/extensions/generic-host#host-shutdown). Although the [minimal hosting model has some differences with the generic host](/aspnet/core/migration/50-to-60#faq), the generic host underpins the minimal hosting model and behaves similarly on shutdown.

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