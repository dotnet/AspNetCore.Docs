---
title: Test services with gRPC tools
author: jamesnk
description: Learn how to test services with gRPC tools. gRPCurl a command-line tool for interacting with gRPC services. gRPCui is an interactive web UI.
monikerRange: '>= aspnetcore-3.0'
ms.author: jamesnk
ms.date: 08/09/2020
no-loc: ["ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: grpc/test-tools
---
# Test services with gRPC tools

By [James Newton-King](https://twitter.com/jamesnk)

Tooling is available for gRPC that allows developers to test services without building client apps. [gRPCurl](https://github.com/fullstorydev/grpcurl) is a command-line tool that provides interaction with gRPC services. [gRPCui](https://github.com/fullstorydev/grpcui) adds an interactive web UI for gRPC.

This article discusses how to:

* Download and install gRPCurl and gRPCui.
* Setup gRPC reflection with a gRPC ASP.NET Core app.
* Discover and test gRPC services with `grpcurl`.
* Interact with gRPC services via a browser using `grpcui`.

## About gRPCurl

gRPCurl is a command-line tool created by the gRPC community. Its features include:

* Calling gRPC services, including streaming services.
* Service discovery using [gRPC reflection](https://github.com/grpc/grpc/blob/master/doc/server-reflection.md).
* Listing and describing gRPC services.
* Works with secure (TLS) and insecure (plain-text) servers.

For information about downloading and installing `grpcurl`, see the [gRPCurl GitHub homepage](https://github.com/fullstorydev/grpcurl#installation).

## Setup gRPC reflection

`grpcurl` needs to know the Protobuf contract of services before it can call them. There are two ways to do this:

* Use gRPC reflection to discover service contracts.
* Specify *.proto* files in command-line arguments.

It's easier to use gRPCurl with gRPC reflection and service discovery. gRPC ASP.NET Core has built-in support for gRPC reflection with the [Grpc.AspNetCore.Server.Reflection](https://www.nuget.org/packages/Grpc.AspNetCore.Server.Reflection) package. To configure reflection in an app:

* Add `Grpc.AspNetCore.Server.Reflection` package reference.
* Register reflection in *Startup.cs*:
  * `AddGrpcReflection` to register services that enable reflection.
  * `MapGrpcReflectionService` to add reflection service endpoint.

[!code-csharp[](~/grpc/test-tools/Startup.cs?name=snippet_1&highlight=4,14)]

## Use `grpcurl`

The `-help` argument explains `grpcurl` command-line options:

```powershell
> grpcurl.exe -help
```

### Discover services

Use the `describe` verb to view the services defined by the server:

```powershell
> grpcurl.exe localhost:5001 describe
greet.Greeter is a service:
service Greeter {
  rpc SayHello ( .greet.HelloRequest ) returns ( .greet.HelloReply );
  rpc SayHellos ( .greet.HelloRequest ) returns ( stream .greet.HelloReply );
}
grpc.reflection.v1alpha.ServerReflection is a service:
service ServerReflection {
  rpc ServerReflectionInfo ( stream .grpc.reflection.v1alpha.ServerReflectionRequest ) returns ( stream .grpc.reflection.v1alpha.ServerReflectionResponse );
}
```

The preceding example:

* Runs `describe` verb on server `localhost:5001`.
* Prints services and methods returned by gRPC reflection.
  * `Greeter` is a service implemented by the app.
  * `ServerReflection` is the service added by the `Grpc.AspNetCore.Server.Reflection` package.

Combine `describe` with a service, method or message name to view its detail:

```powershell
> grpcurl.exe localhost:5001 describe greet.HelloRequest
greet.HelloRequest is a message:
message HelloRequest {
  string name = 1;
}
```

### Call gRPC services

Call a gRPC service by specifying a service and method name, along with a JSON argument that represents the request message. The JSON is converted into Protobuf and sent to the service.

```powershell
> grpcurl.exe -d '{ \"name\": \"World\" }' localhost:5001 greet.Greeter/SayHello
{
  "message": "Hello World"
}
```

The preceding example:

* `-d` argument specifies a request message with JSON. This argument must come before the server address and method name.
* Calls the `SayHello` method on the `greeter.Greeter` service.
* Prints the response message as JSON.

## About gRPCui

gRPCui is an interactive web UI for gRPC. It builds on top of gRPCurl, and offers a GUI for discovering and testing gRPC services, similar to HTTP tools like Postman.

For information about downloading and installing `grpcui`, see the [gRPCui GitHub homepage](https://github.com/fullstorydev/grpcui#installation).

## Using `grpcui`

Run `grpcui` with the server address to interact with as an argument.

```powershell
> grpcui.exe localhost:5001
gRPC Web UI available at http://127.0.0.1:55038/
```

The tool will launch a browser window with the interactive web UI. gRPC services are automatically discovered using gRPC reflection.

![gRPCui web UI](~/grpc/test-tools/static/grpcui.png)

## Additional resources

* [gRPCurl GitHub homepage](https://github.com/fullstorydev/grpcurl)
* [gRPCui GitHub homepage](https://github.com/fullstorydev/grpcui)
* [Grpc.AspNetCore.Server.Reflection](https://www.nuget.org/packages/Grpc.AspNetCore.Server.Reflection)
