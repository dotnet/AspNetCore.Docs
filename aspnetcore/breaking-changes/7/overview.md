---
title: Breaking changes in ASP.NET Core 7
titleSuffix: ""
description: Navigate to the breaking changes in ASP.NET Core 7.
ms.date: 07/28/2023
no-loc: [Blazor, Razor, Kestrel]
---
# Breaking changes in ASP.NET Core 7

If you're migrating an app to ASP.NET Core 7, the breaking changes listed here might affect you.

[!INCLUDE [binary-source-behavioral](../includes/binary-source-behavioral.md)]

| Title                                                                                                                                   | Type of change             |
|-----------------------------------------------------------------------------------------------------------------------------------------|:--------------------------:|
| [API controller actions try to infer parameters from DI](api-controller-action-parameters-di.md)                        | Source incompatible        |
| [ASPNET-prefixed environment variable precedence](environment-variable-precedence.md)                                   | Behavioral change          |
| [AuthenticateAsync for remote auth providers](authenticateasync-anonymous-request.md)                                   | Source incompatible        |
| [Authentication in WebAssembly apps](wasm-app-authentication.md)                                                        | Binary incompatible        |
| [Default authentication scheme](default-authentication-scheme.md)                                                       | Binary incompatible        |
| [Event IDs for some Microsoft.AspNetCore.Mvc.Core log messages changed](microsoft-aspnetcore-mvc-core-log-event-ids.md) | Binary incompatible        |
| [Fallback file endpoints](fallback-file-endpoints.md)                                                                   | Binary incompatible        |
| [IHubClients and IHubCallerClients hide members](ihubclients-ihubcallerclients.md)                                      | Source incompatible        |
| [Kestrel: Default HTTPS binding removed](https-binding-kestrel.md)                                                      | Binary incompatible        |
| [Microsoft.AspNetCore.Server.Kestrel.Transport.Libuv and libuv.dll removed](libuv-transport-dll-removed.md)             | Binary/source incompatible |
| [Microsoft.Data.SqlClient updated to 4.0.1](microsoft-data-sqlclient-updated-to-4-0-1.md)                               | Source incompatible        |
| [Middleware no longer defers to endpoint with null request delegate](middleware-null-requestdelegate.md)                | Binary incompatible        |
| [MVC's detection of an empty body in model binding changed](mvc-empty-body-model-binding.md)                            | Binary incompatible        |
| [Output caching API changes](output-caching-renames.md)                                                                 | Binary/source incompatible |
| [SignalR Hub methods try to resolve parameters from DI](signalr-hub-method-parameters-di.md)                            | Source incompatible        |
