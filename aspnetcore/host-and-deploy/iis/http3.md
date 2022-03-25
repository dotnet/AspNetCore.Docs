---
title: Use ASP.NET Core with HTTP/3 on IIS
author: tratcher
description: Learn how to use HTTP/3 features with IIS.
monikerRange: '>= aspnetcore-6.0'
ms.author: chrross
ms.custom: mvc
ms.date: 09/09/2021
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: host-and-deploy/iis/http3
---

# Use ASP.NET Core with HTTP/3 on IIS

By [Chris Ross](https://github.com/tratcher)

[HTTP/3](https://quicwg.org/base-drafts/draft-ietf-quic-http.html) is supported with ASP.NET Core in the following IIS deployment scenarios:

* In-process
* [Out-of-Process](xref:host-and-deploy/iis/index#out-of-process-hosting-model). In Out-of-Process, IIS responds to the client using HTTP/3, but the reverse proxy connection to the [Kestrel server](xref:fundamentals/servers/kestrel) uses HTTP/1.1.

For more information on the in-process and out-of-process hosting models, see <xref:host-and-deploy/aspnet-core-module>.

The following requirements also need to be met: 

* Windows Server 2022 / Windows 11 or later
* An `https` url binding is used.
* The [EnableHttp3 registry key](https://techcommunity.microsoft.com/t5/networking-blog/enabling-http-3-support-on-windows-server-2022/ba-p/2676880) is set.

The preceding Windows 11 Build versions may require the use of a [Windows Insider](https://insider.windows.com) build.

For an in-process deployment when an HTTP/3 connection is established, [`HttpRequest.Protocol`](xref:Microsoft.AspNetCore.Http.HttpRequest.Protocol*) reports `HTTP/3`. For an out-of-process deployment when an HTTP/3 connection is established, [`HttpRequest.Protocol`](xref:Microsoft.AspNetCore.Http.HttpRequest.Protocol*) reports `HTTP/1.1` because that is how IIS proxies the requests to Kestrel.

## Alt-Svc

HTTP/3 is discovered as an upgrade from HTTP/1.1 or HTTP/2 via the `alt-svc` header. That means the first request will normally use HTTP/1.1 or HTTP/2 before switching to HTTP/3. IIS doesn't automatically add the `alt-svc` header, it must be added by the application. The following code is a middleware example that adds the `alt-svc` response header.

```C#
app.Use((context, next) =>
{
    context.Response.Headers.AltSvc = "h3=\":443\"";
    return next(context);
});
```

Place the preceding code early in the request pipeline.

IIS also supports sending an AltSvc HTTP/2 protocol message rather than a response header to notify the client that HTTP/3 is available. See the [EnableAltSvc registry key](https://techcommunity.microsoft.com/t5/networking-blog/enabling-http-3-support-on-windows-server-2022/ba-p/2676880). Note this requires netsh sslcert bindings that use host names rather than IP addresses.
