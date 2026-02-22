---
title: "Breaking change: Kestrel: Libuv transport marked as obsolete"
description: "Learn about the breaking change in ASP.NET Core 5.0 titled Kestrel: Libuv transport marked as obsolete"
ms.author: scaddie
ms.date: 10/01/2020
ms.custom: https://github.com/aspnet/Announcements/issues/424
---
# Kestrel: Libuv transport marked as obsolete

Earlier versions of ASP.NET Core used Libuv as an implementation detail of how asynchronous input and output was performed. In ASP.NET Core 2.0, an alternative, <xref:System.Net.Sockets.Socket>-based transport was developed. In ASP.NET Core 2.1, Kestrel switched to using the `Socket`-based transport by default. Libuv support was maintained for compatibility reasons.

At this point, use of the `Socket`-based transport is far more common than the Libuv transport. Consequently, Libuv support is marked as obsolete in .NET 5 and will be removed entirely in .NET 6.0.

As part of this change, Libuv support for new operating system platforms (like Windows Arm64) won't be added in the .NET 5 timeframe.

For discussion on blocking issues that require the use of the Libuv transport, see the GitHub issue at [dotnet/aspnetcore#23409](https://github.com/dotnet/aspnetcore/issues/23409).

## Version introduced

5.0 Preview 8

## Old behavior

The Libuv APIs aren't marked as obsolete.

## New behavior

The Libuv APIs are marked as obsolete.

## Reason for change

The `Socket`-based transport is the default. There aren't any compelling reasons to continue using the Libuv transport.

## Recommended action

Discontinue use of the [Libuv package](https://www.nuget.org/packages/Libuv) and extension methods.

## Affected APIs

- [WebHostBuilderLibuvExtensions](/dotnet/api/microsoft.aspnetcore.hosting.webhostbuilderlibuvextensions?view=aspnetcore-3.0&preserve-view=false)
- [WebHostBuilderLibuvExtensions.UseLibuv](/dotnet/api/microsoft.aspnetcore.hosting.webhostbuilderlibuvextensions.uselibuv?view=aspnetcore-3.0&preserve-view=false)
- [Microsoft.AspNetCore.Server.Kestrel.Transport.Libuv.LibuvTransportOptions](/dotnet/api/microsoft.aspnetcore.server.kestrel.transport.libuv.libuvtransportoptions?view=aspnetcore-3.0&preserve-view=false)
- [Microsoft.AspNetCore.Server.Kestrel.Transport.Libuv.LibuvTransportOptions.ThreadCount](/dotnet/api/microsoft.aspnetcore.server.kestrel.transport.libuv.libuvtransportoptions.threadcount?view=aspnetcore-3.0&preserve-view=false)
- [Microsoft.AspNetCore.Server.Kestrel.Transport.Libuv.LibuvTransportOptions.NoDelay](/dotnet/api/microsoft.aspnetcore.server.kestrel.transport.libuv.libuvtransportoptions.nodelay?view=aspnetcore-3.0&preserve-view=false)
- [Microsoft.AspNetCore.Server.Kestrel.Transport.Libuv.LibuvTransportOptions.MaxWriteBufferSize](/dotnet/api/microsoft.aspnetcore.server.kestrel.transport.libuv.libuvtransportoptions.maxwritebuffersize?view=aspnetcore-3.0&preserve-view=false)
- [Microsoft.AspNetCore.Server.Kestrel.Transport.Libuv.LibuvTransportOptions.MaxReadBufferSize](/dotnet/api/microsoft.aspnetcore.server.kestrel.transport.libuv.libuvtransportoptions.maxreadbuffersize?view=aspnetcore-3.0&preserve-view=false)
- `Microsoft.AspNetCore.Server.Kestrel.Transport.Libuv.LibuvTransportOptions.Backlog`

<!--

### Category

ASP.NET Core

### Affected APIs

- `T:Microsoft.AspNetCore.Hosting.WebHostBuilderLibuvExtensions`
- `Overload:Microsoft.AspNetCore.Hosting.WebHostBuilderLibuvExtensions.UseLibuv`
- `T:Microsoft.AspNetCore.Server.Kestrel.Transport.Libuv.LibuvTransportOptions`
- `P:Microsoft.AspNetCore.Server.Kestrel.Transport.Libuv.LibuvTransportOptions.ThreadCount`
- `P:Microsoft.AspNetCore.Server.Kestrel.Transport.Libuv.LibuvTransportOptions.NoDelay`
- `P:Microsoft.AspNetCore.Server.Kestrel.Transport.Libuv.LibuvTransportOptions.MaxWriteBufferSize`
- `P:Microsoft.AspNetCore.Server.Kestrel.Transport.Libuv.LibuvTransportOptions.MaxReadBufferSize`
- `P:Microsoft.AspNetCore.Server.Kestrel.Transport.Libuv.LibuvTransportOptions.Backlog`

-->
