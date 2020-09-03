---
title: Why migrate WCF to ASP.NET Core gRPC
author: markrendle
description: A summary of why ASP.NET Core gRPC is a good fit for Windows Communication Foundation (WCF) developers who want to migrate to modern architectures and platforms.
monikerRange: '>= aspnetcore-3.0'
ms.author: wpickett
ms.date: 09/02/2020
no-loc: ["ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: grpc/wcf
---

# Why we recommend gRPC for Windows Communication Foundation (WCF) developers

This article provides a summary of why ASP.NET Core gRPC is a good fit for Windows Communication Foundation (WCF) developers who want to migrate to modern architectures and platforms.

## Similarity to WCF

Although the implementation and approach are different for gRPC, the experience of developing and consuming services with gRPC should be intuitive for WCF developers. WCF and gRPC are both RPC (remote procedure call) frameworks and the underlying goal is the same: make it possible to code as though the client and server are on the same platform, without needing to worry about networking.

Both platforms share the principle of declaring and then implementing an interface, even though the process for declaring that interface is different. The different types of RPC calls that gRPC supports map well to the bindings available to WCF services. For more information and examples, see [Migrate a WCF solution to gRPC](https://docs.microsoft.com/dotnet/architecture/grpc-for-wcf-developers/migrate-wcf-to-grpc).

## Benefits of gRPC

gRPC stands above other solutions for the following reasons.

### Performance

gRPC uses HTTP/2.  HTTP/2 is a smaller, faster binary protocol than HTTP/1.1, which is more efficient for computers to parse. HTTP/2 also supports multiplexing requests over a single connection. Multiplexing enables multiple requests to be sent over one connection without requests blocking each other. (In HTTP/1.1, this issue is known as "head-of-line (HOL) blocking.") gRPC uses the Protobuf, an efficient binary format, to serialize messages. Protobuf messages are small in size and use less bandwidth than text-based formats. gRPC is a good solution to use for mobile devices and over slower networks where bandwidth is important.

### Interoperability

There are gRPC tools and libraries for all major programming languages and platforms, including .NET, Java, Python, Go, C++, Node.js, Swift, Dart, Ruby, and PHP. Thanks to the Protocol Buffers binary wire format and the efficient code generation for each platform, developers can build performant apps while still enjoying full cross-platform support.

### Usability and productivity

gRPC is a comprehensive RPC solution. It works consistently across multiple languages and platforms. It also provides excellent tooling, with much of the necessary boilerplate code automatically generated. Like WCF, gRPC automatically generates messages and a strongly typed client for you. Developer time is freed up to focus on business logic.

### Streaming

gRPC has full bidirectional streaming, which provides similar functionality to WCF's full duplex services. gRPC streaming can operate over regular internet connections, load balancers, and service meshes.

### Deadline/timeouts and cancellation

gRPC allows clients to specify a maximum time for an RPC to finish. If the specified deadline is exceeded, the server can cancel the operation independently of the client. Deadlines and cancellations can be propagated through further gRPC calls to help enforce resource usage limits. Clients can stop operations when a deadline is exceeded, or earlier if necessary (for example, because of a user interaction).

### Security

gRPC can use TLS and HTTP/2 to provide an end-to-end encrypted connection between the client and the server. Support for client certificate authentication further increases security and trust between client and server.

## gRPC as a migration path for WCF to .NET Core and .NET 5

The release of .NET Core 3.0 marked a shift in the way that Microsoft delivers remote communication solutions to developers who want to deliver services across a range of platforms. .NET Core and .NET 5 will not offer server-side support for the Windows Communication Foundation (WCF). With the release of ASP.NET Core 3.0, it does however provide built-in gRPC functionality.

## Get Started

For detailed guidance on building gRPC services in ASP.NET Core for WCF developers, see [ASP.NET Core gRPC for WCF Developers](https://docs.microsoft.com/dotnet/architecture/grpc-for-wcf-developers/)
