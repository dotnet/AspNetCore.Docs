---
title: Use connection middleware with the ASP.NET Core Kestrel web server
author: tdykstra
description: Learn about using connection middleware with Kestrel, the cross-platform web server for ASP.NET Core.
monikerRange: '>= aspnetcore-5.0'
ms.author: riande
ms.custom: mvc
ms.date: 06/21/2023
uid: fundamentals/servers/kestrel/connection-middleware
---

# Connection middleware

Kestrel supports connection middleware. Connection middleware is software that is assembled into a connection pipeline and runs when Kestrel receives a new connection. Each component:

* Chooses whether to pass the request to the next component in the pipeline.
* Can perform work before and after the next component in the pipeline.

Connection delegates are used to build the connection pipeline. Connection delegates are configured with the <xref:Microsoft.AspNetCore.Server.Kestrel.Core.ListenOptions.Use%2A?displayProperty=nameWithType> method.

Connection middleware is different from <xref:fundamentals/middleware/index>. Connection middleware runs per-connection instead of per-request.

## Connection logging

Connection logging is connection middleware that is included with ASP.NET Core. Call <xref:Microsoft.AspNetCore.Hosting.ListenOptionsConnectionLoggingExtensions.UseConnectionLogging%2A> to emit Debug level logs for byte-level communication on a connection.

Connection logging is helpful for troubleshooting problems in low-level communication, such as during TLS encryption and behind proxies. If `UseConnectionLogging` is placed before `UseHttps`, encrypted traffic is logged. If `UseConnectionLogging` is placed after `UseHttps`, decrypted traffic is logged.

:::code language="csharp" source="~/fundamentals/servers/kestrel/samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_ConfigureKestrelUseConnectionLogging":::

## Create custom connection middleware

The following example shows a custom connection middleware that can filter TLS handshakes on a per-connection basis for specific ciphers if necessary. The middleware throws <xref:System.NotSupportedException> for any cipher algorithm that the app doesn't support. Alternatively, define and compare <xref:Microsoft.AspNetCore.Connections.Features.ITlsHandshakeFeature.CipherAlgorithm%2A?displayProperty=nameWithType> to a list of acceptable cipher suites.

No encryption is used with a <xref:System.Security.Authentication.CipherAlgorithmType.Null?displayProperty=nameWithType> cipher algorithm.

:::code language="csharp" source="~/fundamentals/servers/kestrel/samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_ConfigureKestrelMiddleware":::

## See also

* <xref:fundamentals/servers/kestrel/endpoints>
