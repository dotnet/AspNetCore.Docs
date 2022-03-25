---
title: Compare gRPC services with HTTP APIs
author: jamesnk
description: Learn how gRPC compares with HTTP APIs and what it's recommend scenarios are.
monikerRange: '>= aspnetcore-3.0'
ms.author: jamesnk
ms.date: 12/05/2019
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: grpc/comparison
---
# Compare gRPC services with HTTP APIs

By [James Newton-King](https://twitter.com/jamesnk)

This article explains how [gRPC services](https://grpc.io/docs/guides/) compare to HTTP APIs with JSON (including ASP.NET Core [web APIs](xref:web-api/index)). The technology used to provide an API for your app is an important choice, and gRPC offers unique benefits compared to HTTP APIs. This article discusses the strengths and weaknesses of gRPC and recommends scenarios for using gRPC over other technologies.

## High-level comparison

The following table offers a high-level comparison of features between gRPC and HTTP APIs with JSON.

| Feature          | gRPC                                               | HTTP APIs with JSON           |
| ---------------- | -------------------------------------------------- | ----------------------------- |
| Contract         | Required (`.proto`)                                | Optional (OpenAPI)            |
| Protocol         | HTTP/2                                             | HTTP                          |
| Payload          | [Protobuf (small, binary)](#performance)           | JSON (large, human readable)  |
| Prescriptiveness | [Strict specification](#strict-specification)      | Loose. Any HTTP is valid.     |
| Streaming        | [Client, server, bi-directional](#streaming)       | Client, server                |
| Browser support  | [No (requires grpc-web)](#limited-browser-support) | Yes                           |
| Security         | Transport (TLS)                                    | Transport (TLS)               |
| Client code-generation | [Yes](#code-generation)                      | OpenAPI + third-party tooling |

## gRPC strengths

### Performance

gRPC messages are serialized using [Protobuf](https://developers.google.com/protocol-buffers/docs/overview), an efficient binary message format. Protobuf serializes very quickly on the server and client. Protobuf serialization results in small message payloads, important in limited bandwidth scenarios like mobile apps.

gRPC is designed for HTTP/2, a major revision of HTTP that provides significant performance benefits over HTTP 1.x:

* Binary framing and compression. HTTP/2 protocol is compact and efficient both in sending and receiving.
* Multiplexing of multiple HTTP/2 calls over a single TCP connection. Multiplexing eliminates [head-of-line blocking](https://en.wikipedia.org/wiki/Head-of-line_blocking).

HTTP/2 is not exclusive to gRPC. Many request types, including HTTP APIs with JSON, can use HTTP/2 and benefit from its performance improvements.

### Code generation

All gRPC frameworks provide first-class support for code generation. A core file to gRPC development is the [`.proto` file](https://developers.google.com/protocol-buffers/docs/proto3), which defines the contract of gRPC services and messages. From this file, gRPC frameworks generate a service base class, messages, and a complete client.

By sharing the `.proto` file between the server and client, messages and client code can be generated from end to end. Code generation of the client eliminates duplication of messages on the client and server, and creates a strongly-typed client for you. Not having to write a client saves significant development time in applications with many services.

### Strict specification

A formal specification for HTTP API with JSON doesn't exist. Developers debate the best format of URLs, HTTP verbs, and response codes.

The [gRPC specification](https://github.com/grpc/grpc/blob/master/doc/PROTOCOL-HTTP2.md) is prescriptive about the format a gRPC service must follow. gRPC eliminates debate and saves developer time because gRPC is consistent across platforms and implementations.

### Streaming

HTTP/2 provides a foundation for long-lived, real-time communication streams. gRPC provides first-class support for streaming through HTTP/2.

A gRPC service supports all streaming combinations:

* Unary (no streaming)
* Server to client streaming
* Client to server streaming
* Bi-directional streaming

### Deadline/timeouts and cancellation

gRPC allows clients to specify how long they are willing to wait for an RPC to complete. The [deadline](https://grpc.io/blog/deadlines) is sent to the server, and the server can decide what action to take if it exceeds the deadline. For example, the server might cancel in-progress gRPC/HTTP/database requests on timeout.

Propagating the deadline and cancellation through child gRPC calls helps enforce resource usage limits.

## gRPC recommended scenarios

gRPC is well suited to the following scenarios:

* **Microservices**: gRPC is designed for low latency and high throughput communication. gRPC is great for lightweight microservices where efficiency is critical.
* **Point-to-point real-time communication**: gRPC has excellent support for bi-directional streaming. gRPC services can push messages in real-time without polling.
* **Polyglot environments**: gRPC tooling supports all popular development languages, making gRPC a good choice for multi-language environments.
* **Network constrained environments**: gRPC messages are serialized with Protobuf, a lightweight message format. A gRPC message is always smaller than an equivalent JSON message.
* **Inter-process communication (IPC)**: IPC transports such as Unix domain sockets and named pipes can be used with gRPC to communicate between apps on the same machine. For more information, see <xref:grpc/interprocess>.

## gRPC weaknesses

### Limited browser support

It's impossible to directly call a gRPC service from a browser today. gRPC heavily uses HTTP/2 features and no browser provides the level of control required over web requests to support a gRPC client. For example, browsers do not allow a caller to require that HTTP/2 be used, or provide access to underlying HTTP/2 frames.

There are two common approaches to bring gRPC to browser apps:

* [gRPC-Web](https://grpc.io/docs/tutorials/basic/web.html) is an additional technology from the gRPC team that provides gRPC support in the browser. gRPC-Web allows browser apps to benefit from the high-performance and low network usage of gRPC. Not all of gRPC's features are supported by gRPC-Web. Client and bi-directional streaming isn't supported, and there is limited support for server streaming.

  .NET Core has support for gRPC-Web. For more information, see <xref:grpc/browser>.

* RESTful JSON Web APIs can be automatically created from gRPC services by annotating the `.proto` file with [HTTP metadata](https://cloud.google.com/service-infrastructure/docs/service-management/reference/rpc/google.api#google.api.HttpRule). This allows an app to support both gRPC and JSON web APIs, without duplicating effort of building separate services for both.

  .NET Core has experimental support for creating JSON web APIs from gRPC services. For more information, see <xref:grpc/httpapi>.

### Not human readable

HTTP API requests are sent as text and can be read and created by humans.

gRPC messages are encoded with Protobuf by default. While Protobuf is efficient to send and receive, its binary format isn't human readable. Protobuf requires the message's interface description specified in the `.proto` file to properly deserialize. Additional tooling is required to analyze Protobuf payloads on the wire and to compose requests by hand.

Features such as [server reflection](https://github.com/grpc/grpc/blob/master/doc/server-reflection.md) and the [gRPC command line tool](https://github.com/grpc/grpc/blob/master/doc/command_line_tool.md) exist to assist with binary Protobuf messages. Also, Protobuf messages support [conversion to and from JSON](https://developers.google.com/protocol-buffers/docs/proto3#json). The built-in JSON conversion provides an efficient way to convert Protobuf messages to and from human readable form when debugging.

## Alternative framework scenarios

Other frameworks are recommended over gRPC in the following scenarios:

* **Browser accessible APIs**: gRPC isn't fully supported in the browser. gRPC-Web can offer browser support, but it has limitations and introduces a server proxy.
* **Broadcast real-time communication**: gRPC supports real-time communication via streaming, but the concept of broadcasting a message out to registered connections doesn't exist. For example in a chat room scenario where new chat messages should be sent to all clients in the chat room, each gRPC call is required to individually stream new chat messages to the client. [SignalR](xref:signalr/introduction) is a useful framework for this scenario. SignalR has the concept of persistent connections and built-in support for broadcasting messages.

## Additional resources

* <xref:tutorials/grpc/grpc-start>
* <xref:grpc/index>
* <xref:grpc/basics>
* <xref:grpc/migration>
