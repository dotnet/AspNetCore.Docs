---
title: Why migrate WCF to ASP.NET Core gRPC
author: markrendle
description: This article provides a summary of why ASP.NET Core gRPC is a good fit for Windows Communication Foundation (WCF) developers who want to migrate to modern architectures and platforms.
monikerRange: '>= aspnetcore-3.0'
ms.author: wpickett
ms.date: 09/02/2020
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: grpc/wcf
---
# gRPC for Windows Communication Foundation (WCF) developers

This article provides a summary of why ASP.NET Core gRPC is a good fit for Windows Communication Foundation (WCF) developers who want to migrate to modern architectures and platforms.

## Comparison to WCF

Although the implementation and approach are different for gRPC, the experience of developing and consuming services with gRPC should be intuitive for WCF developers. WCF and gRPC are RPC (remote procedure call) frameworks with the same goals:

* Make it possible to code as though the client and server are on the same platform.
* Provide a simplified portable networking API.

Both platforms share the requirement of declaring and implementing an interface, although the process for declaring the interface is different. The many types of RPC calls that gRPC supports map well to the bindings available to WCF services. For more information and examples, see [Migrate a WCF solution to gRPC](/dotnet/architecture/grpc-for-wcf-developers/migrate-wcf-to-grpc).

## Benefits of gRPC

gRPC provides a better framework than other approaches for the following reasons.

### Performance

gRPC uses HTTP/2. In contrast to HTTP/1.1, HTTP/2:

* Is a smaller, faster binary protocol.
* Is more efficient for computers to parse.
* Supports multiplexing requests over a single connection. Multiplexing enables multiple requests to be sent over one connection without requests blocking each other. In HTTP/1.1, the blocking is known as "head-of-line (HOL) blocking."

gRPC uses Protobuf, an efficient binary format, to serialize messages. Protobuf messages are:
* Fast to serialize and deserialize.
* Use less bandwidth than text-based formats. 

gRPC is a good solution for mobile devices and networks with bandwidth restrictions.

### Interoperability

There are gRPC tools and libraries for all major programming languages and platforms, including .NET, Java, Python, Go, C++, Node.js, Swift, Dart, Ruby, and PHP. Thanks to the Protobuf binary wire format and the efficient code generation for each platform, developers can build cross-platform, performant apps.

### Usability and productivity

gRPC is a comprehensive RPC solution. It works consistently across multiple languages and platforms. It also provides excellent tooling, with much of the boilerplate code automatically generated. Like WCF, gRPC automatically generates messages and a strongly typed client. Developer time is freed up to focus on business logic.

### Streaming

gRPC has full bidirectional streaming, which provides similar functionality to WCF's full duplex services. gRPC streaming can operate over regular internet connections, load balancers, and service meshes.

### Deadlines, timeouts, and cancellation

gRPC allows clients to specify a maximum time for an RPC to finish. If the specified deadline is exceeded, the server can cancel the operation independently of the client. Deadlines and cancellations can be propagated through subsequent gRPC calls to help enforce resource usage limits. Clients can stop operations when a deadline is exceeded, or earlier if necessary. For example, clients can stop operations because of a user interaction.

### Security

gRPC can use TLS and HTTP/2 to provide an end-to-end encrypted connection between the client and the server. Support for client certificate authentication further increases security and trust between client and server.

## gRPC as a migration path for WCF to .NET Core and .NET 5

.NET Core and .NET 5 marks a shift in the way that Microsoft delivers remote communication solutions to developers who want to deliver services across a range of platforms. .NET Core and .NET 5 support [calling WCF services](/dotnet/core/additional-tools/wcf-web-service-reference-guide), but won't offer server-side support for hosting WCF.

There are two recommended paths for modernizing WCF apps:

* gRPC is built on modern technologies and has emerged as the most popular choice across the developer community for RPC apps. Starting with .NET Core 3.0, modern .NET platforms have excellent support for gRPC. Migrating WCF services to use gRPC helps provide the RPC features, performance, an interoperability needed in modern apps.

* [CoreWCF](https://github.com/CoreWCF/CoreWCF) is a community effort to bring support for hosting WCF services to .NET Core and .NET 5. A preview release is available and the project is working towards being production ready. CoreWCF only supports a subset of WCF's features, and .NET Framework apps that migrate to use it will need code changes and testing to be successful. CoreWCF is a good choice if an app has to maintain compatibility with existing clients that call WCF services.

## Get started

For detailed guidance on building gRPC services in ASP.NET Core for WCF developers, see [ASP.NET Core gRPC for WCF Developers](/dotnet/architecture/grpc-for-wcf-developers)
