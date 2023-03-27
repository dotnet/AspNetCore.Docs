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

Processes running on the same machine can be designed to communicate with each other. Operating systems provide technologies for enabling fast and efficient [inter-process communication (IPC)](https://wikipedia.org/wiki/Inter-process_communication). Popular examples of IPC technologies are Unix domain sockets and Named pipes.

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

gRPC calls between a client and server on different machines are usually sent over TCP sockets. TCP is a great choice for communicating across a network or the Internet. However, IPC transports can offer performance advantages and better integration with OS features when the client and server are on the same machine.

.NET supports multiple IPC transports:

* [Unix domain sockets (UDS)](https://wikipedia.org/wiki/Unix_domain_socket) is a widely supported IPC technology. UDS is the best choice for building cross-platform apps, and it's usable on Linux, macOS, and [Windows 10/Windows Server 2019 or later](https://devblogs.microsoft.com/commandline/af_unix-comes-to-windows/).
* [Named pipes](https://wikipedia.org/wiki/Named_pipe) are supported by all versions of Windows. Named pipes integrate well with [Windows security](/windows/win32/ipc/named-pipe-security-and-access-rights), which can be used to control client access to the pipe.
* Other IPC transports by implementing <xref:Microsoft.AspNetCore.Connections.IConnectionListenerFactory> and registering the implementation at app startup.

Cross-platform apps may want to use different IPC transports, depending on the current OS. An app can check the current operating system on startup and chose the desired transport for that platform:

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    if (OperatingSystem.IsWindows())
    {
        serverOptions.ListenNamedPipe("MyPipeName");
    }
    else
    {
        var socketPath = Path.Combine(Path.GetTempPath(), "socket.tmp");
        serverOptions.ListenUnixSocket(socketPath);
    }

    serverOptions.ConfigureEndpointDefaults(listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http2;
    });
});
```

## Configure client and server

The client and server must be configured to use an inter-process communication (IPC) transport. For more information about configuring Kestrel and <xref:System.Net.Http.SocketsHttpHandler> to use IPC:

* [Inter-process communication with gRPC and Unix domain sockets](xref:grpc/interprocess-uds)
* [Inter-process communication with gRPC and Named pipes](xref:grpc/interprocess-namedpipes)

> [!NOTE]
> Built-in support for Named pipes in ASP.NET Core requires .NET 8 or later. .NET 8 is currently in preview and will be released near the end of 2023.
