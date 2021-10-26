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

## Authentication and authorization

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