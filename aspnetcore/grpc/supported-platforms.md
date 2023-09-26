---
title: gRPC on .NET supported platforms
author: jamesnk
description: Learn about the supported platforms for gRPC on .NET.
monikerRange: '>= aspnetcore-3.0'
ms.author: jamesnk
ms.date: 10/27/2022
uid: grpc/supported-platforms
---
# gRPC on .NET supported platforms

By [James Newton-King](https://twitter.com/jamesnk)

This article discusses the requirements and supported platforms for using gRPC with .NET. There are different requirements for the two major gRPC workloads:

* [Hosting gRPC services in ASP.NET Core](#aspnet-core-grpc-server-requirements)
* [Calling gRPC from .NET client apps](#net-grpc-client-requirements)

## Wire-formats

gRPC takes advantage of advanced features available in HTTP/2. HTTP/2 isn't supported everywhere, but a second wire-format using HTTP/1.1 is available for gRPC:

* [`application/grpc`](https://github.com/grpc/grpc/blob/master/doc/PROTOCOL-HTTP2.md) - gRPC over HTTP/2 is how gRPC is typically used.
* [`application/grpc-web`](https://github.com/grpc/grpc/blob/master/doc/PROTOCOL-WEB.md) - gRPC-Web modifies the gRPC protocol to be compatible with HTTP/1.1. gRPC-Web can be used in more places. gRPC-Web can be used by browser apps and in networks without complete support for HTTP/2. Two advanced gRPC features are no longer supported: client streaming and bidirectional streaming.

gRPC on .NET supports both wire-formats. `application/grpc` is used by default. gRPC-Web must be configured on the client and the server for successful gRPC-Web calls. For information on setting up gRPC-Web, see <xref:grpc/grpcweb>.

## ASP.NET Core gRPC server requirements

Hosting gRPC services with ASP.NET Core requires .NET Core 3.x or later.

> [!div class="checklist"]
>
> * .NET 5 or later
> * .NET Core 3

ASP.NET Core gRPC services can be hosted on all operating system that .NET Core supports.

:::moniker range=">= aspnetcore-8.0"

> [!div class="checklist"]
>
> * Windows
> * Linux
> * macOS

:::moniker-end

:::moniker range="< aspnetcore-8.0"

> [!div class="checklist"]
>
> * Windows
> * Linux
> * macOS&dagger;

&dagger;[macOS doesn't support hosting ASP.NET Core apps with HTTPS](xref:grpc/troubleshoot#unable-to-start-aspnet-core-grpc-app-on-macos).

:::moniker-end

### Supported ASP.NET Core servers

All built-in ASP.NET Core servers are supported.

> [!div class="checklist"]
>
> * Kestrel
> * TestServer
> * IIS&dagger;
> * HTTP.sys&dagger;

&dagger;Requires .NET 5 and Windows 11 Build 22000 or Windows Server 2022 Build 20348 or later.

For information about configuring ASP.NET Core servers to run gRPC, see <xref:grpc/aspnetcore#server-options>.

### Azure services

> [!div class="checklist"]
>
> * [Azure Kubernetes Service (AKS)](https://azure.microsoft.com/services/kubernetes-service/)
> * [Azure Container Apps](https://azure.microsoft.com/services/container-apps/)
> * [Azure App Service](https://azure.microsoft.com/services/app-service/)&dagger;

&dagger;gRPC requires a Linux-based environment on Azure App Service. See [How-to deploy a .NET 6 gRPC app on App Service](https://github.com/Azure/app-service-linux-docs/blob/master/HowTo/gRPC/use_gRPC_with_dotnet.md) for Azure App Service deployment information.

## .NET gRPC client requirements

The [Grpc.Net.Client](https://www.nuget.org/packages/Grpc.Net.Client/) package supports gRPC calls over HTTP/2 on .NET Core 3 and .NET 5 or later.

Limited support is available for gRPC over HTTP/2 on .NET Framework. Other .NET versions such as UWP, Xamarin and Unity don't have required HTTP/2 support, and must use gRPC-Web instead.

The following table lists .NET implementations and their gRPC client support:

| .NET implementation                          | gRPC over HTTP/2   | gRPC-Web   |
|----------------------------------------------|--------------------|------------|
| .NET 5 or later                              | ✔️                | ✔️         |
| .NET Core 3                                  | ✔️                | ✔️         |
| .NET Core 2.1                                | ❌                | ✔️         |
| .NET Framework 4.6.1                         | ⚠️&dagger;        | ✔️         |
| Blazor WebAssembly                           | ❌                | ✔️         |
| Mono 5.4                                     | ❌                | ✔️         |
| Xamarin.iOS 10.14                            | ❌                | ✔️         |
| Xamarin.Android 8.0                          | ❌                | ✔️         |
| Universal Windows Platform 10.0.16299        | ❌                | ✔️         |
| Unity 2018.1                                 | ❌                | ✔️         |

&dagger;.NET Framework requires configuration of <xref:System.Net.Http.WinHttpHandler> and Windows 11 or later, Windows Server 2022 or later. For more information, see [Make gRPC calls on .NET Framework](xref:grpc/netstandard#net-framework).

Using `Grpc.Net.Client` with gRPC-Web requires additional configuration. For more information:

* [Configure gRPC-Web with the .NET gRPC client](xref:grpc/grpcweb#configure-grpc-web-with-the-net-grpc-client)
* <xref:grpc/netstandard>

> [!IMPORTANT]
> gRPC-Web requires the client ***and*** server to support it. gRPC-Web can be [quickly configured by an ASP.NET Core gRPC server](xref:grpc/grpcweb#configure-grpc-web-in-aspnet-core). Other gRPC server implementations require a proxy to support gRPC-Web.

## Additional resources

* <xref:grpc/netstandard>
* [gRPC C# core-library](https://grpc.io/docs/languages/csharp/quickstart/)
