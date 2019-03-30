---
title: Comparing gRPC services with HTTP APIs
author: jamesnk
description: Learn how gRPC compares with HTTP APIs and what it's recommend scenarios are.
monikerRange: '>= aspnetcore-3.0'
ms.author: jamesnk
ms.date: 03/26/2019
uid: grpc/comparison
---
# Comparing gRPC services with HTTP APIs

By [James Newton-King](https://twitter.com/jamesnk)

This article provides a comparison between [gRPC services](https://grpc.io/docs/guides/) and HTTP APIs, and recommends scenarios for using gRPC over other technologies.

#### Overview

|    Feature             |    gRPC                                                 |    HTTP APIs with JSON                       |
|------------------------|---------------------------------------------------------|----------------------------------------------|
|    Contract            |    Required (`*.proto`)                                 |    Optional (OpenAPI)                        |
|    Transport           |    HTTP/2                                               |    HTTP                                      |
|    Payload             |    [Protobuf (small, binary)](#performance)             |    JSON (large, human readable)              |
|    Prescriptiveness    |    [Strict specification](#strict-specification)        |    Loose. Any HTTP is valid                  |
|    Streaming           |    [Client, server, bi-directional](#streaming)         |    Client, server                            |
|    Browser support     |    [No (requires grpc-web)](#limited-browser-support)   |    Yes                                       |
|    Security            |    Transport (HTTPS)                                    |    Transport (HTTPS)                         |
|    Client code-gen     |    [Yes](#code-generation)                              |    OpenAPI + third-party tooling             |

## gRPC strengths

### Performance

gRPC messages are serialized using [Protobuf](https://developers.google.com/protocol-buffers/docs/overview), an efficient binary message format. Protobuf serializes very quickly on the server and client. Protobuf serialization results in small message payloads, important in limited bandwidth scenarios like mobile apps.

gRPC is designed for HTTP/2, a major revision of HTTP that provides significant performance benefits over HTTP 1.x:

* Binary framing and compression. HTTP/2 protocol is compact and efficient both in sending and receiving.
* Multiplexing of multiple HTTP/2 calls over a single TCP connection. Multiplexing eliminates [head-of-line blocking](https://en.wikipedia.org/wiki/Head-of-line_blocking).

### Code generation

All gRPC frameworks provide first-class support for code generation. A core file to gRPC development is the [`*.proto` file](https://developers.google.com/protocol-buffers/docs/proto3), which defines the contact of gRPC services and messages. From this file gRPC frameworks will code generate a service base class, messages, and a complete client.

By sharing the `*.proto` file between the server and client, messages and client code can be generated from end to end. Code generation of the client eliminates duplication of messages on the client and server, and creates a strongly-typed client for you. Not having to write a client saves significant development time in applications with many services.

### Strict specification

There is no a formal agreement of what an HTTP API with JSON should look like. The lack of an agreement creates debate over the format of URLs, HTTP verbs, and response codes.

The [gRPC specification](https://github.com/grpc/grpc/blob/master/doc/PROTOCOL-HTTP2.md) is prescriptive about the format a gRPC service must follow. gRPC eliminates debate and saves developer time through its simplicity.

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

* **Microservices** - gRPC is designed low latency and high throughput communication. gRPC is great for lightweight microservices where efficiency is critical.
* **Point-to-point real-time communication** - gRPC has excellent support for bi-directional streaming. gRPC services can push messages in real-time without polling.
* **Polygot environments** - gRPC tooling supports all popular development languages, making gRPC a good choice for multi-language environments.
* **Network constrained environments** - gRPC messages are serialized with Protobuf, a lightweight message format. A gRPC message will always be smaller than an equivalent JSON message.

## gRPC weaknesses

### Limited browser support

It's impossible to directly call a gRPC service from a browser today. gRPC heavily uses HTTP/2 features and no browser provides the level of control required over web requests to support a gRPC client. For example, browsers do not allow a caller to require that HTTP/2 be used, or provide access to underlying HTTP/2 frames.

[gRPC-Web](https://grpc.io/docs/tutorials/basic/web.html) is an additional technology from the gRPC team that provides limited gRPC support in the browser. gRPC-Web consists of two parts: a JavaScript client that supports all modern browsers, and a gRPC-Web proxy on the server. The gRPC-Web client calls the proxy and the proxy will forward on the gRPC requests to the gRPC server.

Not all of gRPC's features are supported by gRPC-Web. Client and bi-directional streaming isn't supported, and there is limited support for server streaming.

### Not human readable

HTTP API requests are sent as text and can be read and created by humans.

gRPC messages are encoded with Protobuf by default. While Protobuf is efficient to send and receive, its binary format is not human readable. Protobuf requires the message's interface description specified in the `*.proto` file to properly deserialize. Additional tooling needs to be used to analyze Protobuf payloads on the wire and to compose requests by hand.
Features like [server reflection](https://github.com/grpc/grpc/blob/master/doc/server-reflection.md) and [gRPC command line tool](https://github.com/grpc/grpc/blob/master/doc/command_line_tool.md) exist to get around this limitation. Also, Protobuf messages support [conversion to and from JSON](https://developers.google.com/protocol-buffers/docs/proto3#json). The built-in JSON conversion provides a good way to convert the protobuf messages to/from human readable form when debugging.

## Alternative framework scenarios

Other frameworks are recommended over gRPC in the following scenarios:

* **Browser accessible APIs** - gRPC is not fully supported in the browser. gRPC-Web can offer browser support, but it has limitations and introduces a server proxy.
* **Broadcast real-time communication** - gRPC supports real-time communication via streaming, but it does not have the concept broadcasting a message out to registered connections. For example, in a chat room scenario where new chat messages should be sent to all clients in the chat room, each gRPC call would need to individually stream new chat messages to the client. [SignalR](xref:signalr/introduction) is a good framework for this scenario. It has the concept of persistent connections and built-in support for broadcasting messages.
* **Inter-process communication** &ndash; A process must host an HTTP/2 server to accept incoming gRPC calls. For Windows, inter-process communication [pipes](/dotnet/standard/io/pipe-operations) is a fast, lightweight method of communication.

## Additional resources

* <xref:tutorials/grpc/grpc-start>
* <xref:grpc/index>
* <xref:grpc/basics>
* <xref:grpc/migration>
