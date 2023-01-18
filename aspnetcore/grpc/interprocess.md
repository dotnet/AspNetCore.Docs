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

Apps on the same machine can be designed to communicate with each other. Operating systems provide technologies for enabling fast and efficient [inter-process communication (IPC)](https://wikipedia.org/wiki/Inter-process_communication). Popular examples of IPC technologies are named pipes and Unix domain sockets.

.NET provides support for inter-process communication using gRPC.

## Get started with gRPC

gRPC calls are sent from a client to a server. To communicate between apps on a machine with gRPC, at least one app must host an ASP.NET Core gRPC server.

An ASP.NET Core gRPC server is usually create from the gRPC template.

[!code-xml[](~/grpc/interprocess/Server-web.csproj?highlight=1)]

The SDK value of `Microsoft.NET.SDK.Web` automatically adds a reference to the ASP.NET Core framework.

ASP.NET Core and gRPC can be added to other project types, such as a console, WinForms or WPF app, by adding the `Microsoft.AspNetCore.App` framework to the project.

[!code-xml[](~/grpc/interprocess/Server.csproj?highlight=4-6)]

The preceding project file:

* Adds a framework reference to `Microsoft.AspNetCore.App`. The framework reference allows non-ASP.NET Core apps, such as Windows Services, WPF apps, or WinForms apps to use ASP.NET Core and host an ASP.NET Core server.
* Adds a NuGet package reference to [`Grpc.AspNetCore`](https://www.nuget.org/packages/Grpc.AspNetCore).
* Adds a `.proto` file.

## Inter-process communication transports

gRPC calls between a client and server on different machines are usually sent over TCP sockets. TCP was designed for communicating across a network. .NET provides built-in support for transports that are optimized for IPC.

.NET provides built-in support for two IPC transports:

* [Unix domain sockets](https://wikipedia.org/wiki/Unix_domain_socket) is a widely supported IPC technology that's more efficient than TCP when the client and server are on the same machine. UDS can be used on Linux, macOS and [Windows 10/Windows Server 2019 or later](https://devblogs.microsoft.com/commandline/af_unix-comes-to-windows/).
* [Named pipes](https://wikipedia.org/wiki/Named_pipe) are supported by all versions of Windows. Named pipes integrate well with [Windows security](/windows/win32/ipc/named-pipe-security-and-access-rights) to control client access to the pipe.

Support for other IPC technologies can be implemented using the extensibility in Kestrel and `SocketsHttpHandler`.

## Configure client and server

Configuring a client and server depends on the IPC transport used. Instructions for configuring Kestrel and SocketsHttpHandler to use IPC:

* [Inter-process communication with gRPC and Unix domain sockets](xref:grpc/interprocess-uds)
* [Inter-process communication with gRPC and Named pipes](xref:grpc/interprocess-namedpipes)
