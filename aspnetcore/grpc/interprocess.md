---
title: Inter-process communication with gRPC
author: jamesnk
description: Learn how to use gRPC for inter-process communication.
monikerRange: '>= aspnetcore-5.0'
ms.author: jamesnk
ms.date: 08/08/2022
uid: grpc/interprocess
---
# Inter-process communication with gRPC

By [James Newton-King](https://twitter.com/jamesnk)

Apps on the same machine can be designed to communicate with each other. Operating systems provide technologies for enabling fast and efficient [inter-process communication (IPC)](https://wikipedia.org/wiki/Inter-process_communication). Popular examples of IPC technologies are Unix domain sockets and Named pipes.

.NET provides support for inter-process communication using gRPC.

## Get started

IPC calls are sent from a client to a server. To communicate between apps on a machine with gRPC, at least one app must host an ASP.NET Core gRPC server.

An ASP.NET Core gRPC server is usually created from the gRPC template. The project file created by the template uses `Microsoft.NET.SDK.Web` as the SDK:

[!code-xml[](~/grpc/interprocess/Server-web.csproj?highlight=1)]

The `Microsoft.NET.SDK.Web` SDK value automatically adds a reference to the ASP.NET Core framework. The reference allows the app to use ASP.NET Core types required to host a server.

It is also possible to add a server to existing non-ASP.NET Core projects. Add the `Microsoft.AspNetCore.App` framework to the project file:

[!code-xml[](~/grpc/interprocess/Server.csproj?highlight=4)]

The preceding project file:

* Adds a framework reference to `Microsoft.AspNetCore.App`. The framework reference allows non-ASP.NET Core apps, such as Windows Services, WPF apps, or WinForms apps to use ASP.NET Core APIs. The app can now use ASP.NET Core APIs to start an ASP.NET Core server.
* Adds gRPC requirements:
  * NuGet package reference to [`Grpc.AspNetCore`](https://www.nuget.org/packages/Grpc.AspNetCore).
  * `.proto` file.

## Inter-process communication (IPC) transports

gRPC calls between a client and server on different machines are usually sent over TCP sockets. TCP is a great choice for communicating across a network or the Internet.

There are transports optimized for IPC workloads. .NET supports multiple IPC transports:

* [Unix domain sockets (UDS)](https://wikipedia.org/wiki/Unix_domain_socket) is a widely supported IPC technology that's more efficient than TCP when the client and server are on the same machine. UDS is usable on Linux, macOS, and [Windows 10/Windows Server 2019 or later](https://devblogs.microsoft.com/commandline/af_unix-comes-to-windows/).
* [Named pipes](https://wikipedia.org/wiki/Named_pipe) are supported by all versions of Windows. Named pipes integrate well with [Windows security](/windows/win32/ipc/named-pipe-security-and-access-rights) to control client access to the pipe.

Implement other IPC technologies using the extensibility in Kestrel and `SocketsHttpHandler`.

## Configure client and server

The client and server must be configured to use an inter-process communication (IPC) transport. For more information about configuring Kestrel and <xref:System.Net.Http.SocketsHttpHandler> to use IPC:

* [Inter-process communication with gRPC and Unix domain sockets](xref:grpc/interprocess-uds)
* [Inter-process communication with gRPC and Named pipes](xref:grpc/interprocess-namedpipes)

> [!NOTE]
> Named pipes requires .NET 8 or later.
