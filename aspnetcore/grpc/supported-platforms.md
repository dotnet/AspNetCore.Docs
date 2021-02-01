---
title: gRPC on .NET supported platforms
author: jamesnk
description: Learn about the supported platforms for gRPC on .NET.
monikerRange: '>= aspnetcore-3.0'
ms.author: jamesnk
ms.date: 01/22/2021
no-loc: [appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: grpc/supported-platforms
---
# gRPC on .NET supported platforms

By [James Newton-King](https://twitter.com/jamesnk)

This article discusses the requirements and supported platforms for using gRPC with .NET.

gRPC takes advantage of advanced features available in  HTTP/2. HTTP/2 isn't supported everywhere, but a second wire-format using HTTP/1.1 is available for gRPC:

* [`application/grpc`](https://github.com/grpc/grpc/blob/master/doc/PROTOCOL-HTTP2.md) - gRPC over HTTP/2 is how gRPC is typically used.
* [`application/grpc-web`](https://github.com/grpc/grpc/blob/master/doc/PROTOCOL-WEB.md) - gRPC-Web modifies the gRPC protocol to be compatible with HTTP/1.1. gRPC-Web can be used in more places, notably it is callable by browser apps. Two advanced gRPC features are no longer supported: client streaming and bidirectional streaming.

gRPC on .NET supports both wire-formats. gRPC over HTTP/2 is used by default. For information on setting up gRPC-Web, see <xref:grpc/browser>.

## Device requirements

gRPC on .NET supports any device that .NET Core supports.

> [!div class="checklist"]
>
> * Windows
> * Linux
> * macOS&dagger;
> * Browsers&Dagger;

&dagger;[macOS doesn't support hosting ASP.NET Core apps with HTTPS](xref:grpc/troubleshoot#unable-to-start-aspnet-core-grpc-app-on-macos). gRPC clients on macOS can call remote services that use HTTPS.

&Dagger;Blazor WebAssembly apps can call gRPC services with gRPC-Web.

## ASP.NET Core server requirements

gRPC services can be hosted on all built-in ASP.NET Core servers.

> [!div class="checklist"]
>
> * Kestrel
> * TestServer
> * IIS&dagger;
> * HTTP.sys&Dagger;

&dagger;IIS requires .NET 5 and Windows 10 Build 20241 or later.

&Dagger;HTTP.sys requires .NET 5 and Windows 10 Build 19529 or later.

For information about configuring ASP.NET Core servers to run gRPC, see <xref:grpc/aspnetcore#server-options>.

## .NET version requirements

gRPC on .NET supports .NET Core 3 and .NET 5 or later.

> [!div class="checklist"]
>
> * .NET 5 or later
> * .NET Core 3

gRPC on .NET doesn't support running on .NET Framework and Xamarin. [gRPC C# core-library](https://grpc.io/docs/languages/csharp/quickstart/) is a third party library that supports .NET Framework and Xamarin. gRPC C-core is not supported by Microsoft.

## Azure services

> [!div class="checklist"]
>
> * [Azure Kubernetes Service (AKS)](https://azure.microsoft.com/services/kubernetes-service/)
> * [Azure App Service](https://azure.microsoft.com/services/app-service/)&dagger;

&dagger;Azure App Service doesn't support hosting gRPC over HTTP/2. gRPC-Web is a compatible alternative.

Work is in-progress to improve support for gRPC with HTTP/2 in Azure App Service. For more information, see [this GitHub issue](https://github.com/dotnet/AspNetCore/issues/9020).

## Additional resources

* [gRPC C# core-library](https://grpc.io/docs/languages/csharp/quickstart/)
