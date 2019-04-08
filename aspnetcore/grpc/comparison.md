---
title: Comparing gRPC services with HTTP APIs
author: jamesnk
description: Learn how gRPC compares with HTTP APIs and what it's recommend scenarios are.
monikerRange: '>= aspnetcore-3.0'
ms.author: jamesnk
ms.date: 03/31/2019
uid: grpc/comparison
---
#  gRPC服务与HTTP APIs进行比较

By [依乐祝](https://www.cnblogs.com/yilezhu/)

这篇文章我们将一起探讨下[gRPC services](https://grpc.io/docs/guides/)如何与HTTP APIs进行比较。用于为应用程序提供API的技术是一个重要的选择，与HTTP APIs相比，gRPC提供了独特的优势。 本文从gRPC的优缺点出发，并推荐了一些建议使用gRPC服务以及不建议使用gRPC服务的场景。

#### 概览

|    特性                |    gRPC                                                 |    使用Json的HTTP APIs                      |
|------------------------|---------------------------------------------------------|----------------------------------------------|
|    约定                |    需要 (`*.proto`)                                      |    可选 (OpenAPI)                        |
|    传输协议             |    HTTP/2                                               |    HTTP                                      |
|    负载                |    [Protobuf (small, binary)](#性能)                     |    JSON (large, human readable)              |
|    规约性              |    [严格的规范](#严格的规范)                               |    Loose. Any HTTP is valid                  |
|    流                  |    [Client, server, bi-directional](#流)         |    Client, server                            |
|    浏览器支持           |    [No (requires grpc-web)](#浏览器支持有限)   |    Yes                                       |
|    安全                |    Transport (HTTPS)                                    |    Transport (HTTPS)                         |
|    客户端代码生成       |    [Yes](#代码生成)                              |    OpenAPI + third-party tooling             |

## gRPC 优势

### 性能

gRPC 消息使用一种有效的二进制消息格式 [Protobuf](https://developers.google.com/protocol-buffers/docs/overview)进行序列化。 Protobuf 在服务器和客户机上的序列化非常快. Protobuf 序列化后的消息体积很小，能够有效负载，在移动应用程序等有限带宽场景中显得很重要。

gRPC 是为HTTP/2而设计的，它是HTTP的一个主要版本，与HTTP 1.x相比具有显著的性能优势:

* 二进制框架和压缩。HTTP/2协议在发送和接收方面都很紧凑和高效。.
* 通过单个TCP连接复用多个HTTP/2调用。多路复用消除了[线头阻塞(https://en.wikipedia.org/wiki/Head-of-line_blocking).

### 代码生成

所有gRPC框架都为代码生成提供了一流的支持.gRPC开发的核心文件是 [`*.proto` 文件](https://developers.google.com/protocol-buffers/docs/proto3), 它定义了gRPC服务和消息的约定. 根据这个文件，gRPC框架将生成服务基类，消息和完整的客户端代码。

通过在服务器和客户端之间共享`*.proto文件`，可以从端到端生成消息和客户端代码。客户端的代码生成消除了客户端和服务器上的重复消息，并为您创建了一个强类型的客户端。无需编写客户端代码，可在具有许多服务的应用程序中节省大量开发时间。

### 严格的规范

不存在具有JSON的HTTP API的正式规范. 开发人员不需要讨论URL，HTTP动词和响应代码的最佳格式.

该[gRPC 规范](https://github.com/grpc/grpc/blob/master/doc/PROTOCOL-HTTP2.md) 是规定有关gRPC服务必须遵循的格式。gRPC消除了争论并节省了开发人员的时间，因为gPRC在各个平台和实现之间是一致的。

### 流

HTTP/2为长期的实时通信流提供了基础。gRPC通过HTTP/2为流媒体提供一流的支持。

gRPC服务支持所有流组合:

* 一元（没有流媒体）
* 服务器到客户端流
* 客户端到服务器流
* 双向流媒体

### 截止时间/超时 和 取消

gRPC服务允许客户端指定他们愿意等待RPC完成的时间. 该 [截止时间](https://grpc.io/blog/deadlines) 被发送到服务端，服务端可以决定在超出了限期时采取什么行动。例如，服务器可能会在超时时取消正在进行的gRPC / HTTP /数据库请求。

通过子gRPC调用截至时间和取消操作有助于实施资源使用限制。

## 推荐使用gRPC的场景

gRPC非常适合以下场景:

* **微服务** &ndash; gRPC设计为低延迟和高吞吐量通信。gRPC非常适用于效率至关重要的轻型微服务。
* **点对点实时通信** &ndash;gRPC对双向流媒体提供出色的支持。gRPC服务可以实时推送消息而无需轮询。
* **多语言混合开发环境** &ndash; gRPC工具支持所有流行的开发语言，使gRPC成为多语言开发环境的理想选择。
* **网络受限环境** &ndash; 使用Protobuf（一种轻量级消息格式）序列化gRPC消息。gRPC消息始终小于等效的JSON消息。

## gRPC 弱点

### 浏览器支持有限

当下，不可能直接从浏览器调用gRPC服务。gRPC大量使用HTTP/2功能，没有浏览器提供支持gRPC客户机的Web请求所需的控制级别。例如，浏览器不允许调用者要求使用的HTTP/2，或者提供对底层HTTP/2框架的访问。

[gRPC-Web](https://grpc.io/docs/tutorials/basic/web.html)是gRPC团队的一项附加技术，它在浏览器中提供有限的gRPC支持。gRPC Web由两部分组成：支持所有现代浏览器的JavaScript客户端和服务器上的gRPC Web代理。gRPC Web客户端调用代理，代理将在gRPC请求上转发到gRPC服务器。

gRPC Web并非支持所有gRPC功能。不支持客户端和双向流，并且对服务器流的支持有限。

### 不是人类可读的

HTTP API请求以文本形式发送，可以由人读取和创建。

默认情况下，gRPC消息使用protobuf编码。虽然protobuf的发送和接收效率很高，但它的二进制格式是不可读的。protobuf需要在`*.proto`文件中指定的消息接口描述才能正确反序列化。需要额外的工具来分析线路上的Protobuf有效负载，并手工编写请求。

存在诸如[服务器反射](https://github.com/grpc/grpc/blob/master/doc/server-reflection.md) 和[gRPC 命令行工具](https://github.com/grpc/grpc/blob/master/doc/command_line_tool.md) 等功能以帮助处理二进制protobuf消息. 另外，Protobuf消息支持与 [与JSON之间的转换](https://developers.google.com/protocol-buffers/docs/proto3#json)。 内置的JSON转换提供了一种有效的方法，可以在调试时将Protobuf消息转换为可读的形式。

## 建议使用其他框架的场景

在以下场景中，建议使用其他框架而不是gRPC:

* **浏览器可访问的API** &ndash; 浏览器不完全支持gRPC。gRPC-Web可以提供浏览器支持，但它有局限性并引入了服务器代理。
* **广播实时通信** &ndash;  gRPC支持通过流媒体进行实时通信，但不存在向已注册连接广播消息的概念。例如，在应该将新聊天消息发送到聊天室中的所有客户端的聊天室场景中，需要每个gRPC呼叫以单独地将新的聊天消息流传输到客户端。 [SignalR](xref:signalr/introduction) 是这种情况的有用框架。SignalR具有持久连接的概念和对广播消息的内置支持。
* **进程间通信** &ndash; 进程必须承载HTTP/2服务才能接受传入的gRPC调用. 对于Windows，进程间通信[管道](/dotnet/standard/io/pipe-operations) 是一种快速，轻量级的通信方法。

## 其他资源

* <xref:tutorials/grpc/grpc-start>
* <xref:grpc/index>
* <xref:grpc/basics>
* <xref:grpc/migration>

