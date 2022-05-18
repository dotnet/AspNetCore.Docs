---
title: gRPC JSON transcoding
author: jamesnk
description: Learn how to create JSON HTTP APIs for gRPC services using gRPC JSON transcoding.
monikerRange: '>= aspnetcore-7.0'
ms.author: jamesnk
ms.date: 05/10/2022
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR, REST]
uid: grpc/httpapi
---
# gRPC JSON transcoding

By [James Newton-King](https://twitter.com/jamesnk)

[gRPC](https://grpc.io) is a high-performance Remote Procedure Call (RPC) framework. gRPC uses HTTP/2, streaming, Protobuf, and message contracts to create high-performance, real-time services.

One limitation with gRPC is not every platform can use it. Browsers don't fully support HTTP/2, making [REST APIs](https://www.redhat.com/topics/api/what-is-a-rest-api) and JSON the primary way to get data into browser apps. Even with the benefits that gRPC brings, REST APIs and JSON have an important place in modern apps. Building gRPC ***and*** JSON Web APIs adds unwanted overhead to app development.

This document discusses how to create JSON Web APIs using gRPC services.

## Overview

gRPC JSON transcoding is an extension for ASP.NET Core that creates RESTful JSON APIs for gRPC services. Once configured, JSON transcoding allows apps to call gRPC services with familiar HTTP concepts:

* HTTP verbs
* URL parameter binding
* JSON requests/responses

gRPC can still be used to call services.

### Usage

1. Add a package reference to [`Microsoft.AspNetCore.Grpc.JsonTranscoding`](https://www.nuget.org/packages/Microsoft.AspNetCore.Grpc.JsonTranscoding).
1. Register JSON transcoding in server startup code by adding `AddJsonTranscoding`. For example, `services.AddGrpc().AddJsonTranscoding()`.
1. Add [`google/api/http.proto`](https://github.com/dotnet/aspnetcore/blob/8b601c3a73ba66de4e6ca35530b5d32a48c76c5b/src/Grpc/JsonTranscoding/test/testassets/Sandbox/google/api/http.proto) and [`google/api/annotations.proto`](https://github.com/dotnet/aspnetcore/blob/main/src/Grpc/JsonTranscoding/test/testassets/Sandbox/google/api/annotations.proto) files to the project.
1. Annotate gRPC methods in your `.proto` files with HTTP bindings and routes:

[!code-protobuf[](~/grpc/httpapi/greet.proto?highlight=3,9-11)]

The `SayHello` gRPC method can now be invoked as gRPC and as a JSON Web API:

* Request: `HTTP/1.1 GET /v1/greeter/world`
* Response: `{ "message": "Hello world" }`

If the server is configured to write logs for each request, server logs show that the HTTP call is executed by a gRPC service. JSON transcoding maps the incoming HTTP request to a gRPC message and then converts the response message to JSON.

```
info: Microsoft.AspNetCore.Hosting.Diagnostics[1]
      Request starting HTTP/1.1 GET https://localhost:5001/v1/greeter/world
info: Microsoft.AspNetCore.Routing.EndpointMiddleware[0]
      Executing endpoint 'gRPC - /v1/greeter/{name}'
info: Server.GreeterService[0]
      Sending hello to world
info: Microsoft.AspNetCore.Routing.EndpointMiddleware[1]
      Executed endpoint 'gRPC - /v1/greeter/{name}'
info: Microsoft.AspNetCore.Hosting.Diagnostics[2]
      Request finished in 1.996ms 200 application/json
```

This is a basic example. See [HttpRule](https://cloud.google.com/service-infrastructure/docs/service-management/reference/rpc/google.api#google.api.HttpRule) for more customization options.

### OpenAPI support

JSON transcoding currently doesn't support OpenAPI. During the development of .NET 7, the .NET team will investigate the best way to support OpenAPI.

### JSON transcoding vs gRPC-Web

Both JSON transcoding and gRPC-Web allow gRPC services to be called from a browser. However, the way each does this is different:

* gRPC-Web lets browser apps call gRPC services from the browser with the gRPC-Web client and Protobuf. gRPC-Web requires the browser app generate a gRPC client, and has the advantage of sending small, fast Protobuf messages.
* JSON transcoding allows browser apps to call gRPC services as if they were RESTful APIs with JSON. The browser app doesn't need to generate a gRPC client or know anything about gRPC.

No generated client is created for JSON transcoding. The previous `Greeter` service can be called using browser JavaScript APIs:

```javascript
var name = nameInput.value;

fetch('/v1/greeter/' + name)
  .then((response) => response.json())
  .then((result) => {
    console.log(result.message);
    // Hello world
  });
```

## grpc-gateway

[grpc-gateway](https://grpc-ecosystem.github.io/grpc-gateway/) is another technology for creating RESTful JSON APIs from gRPC services. It uses the same `.proto` annotations to map HTTP concepts to gRPC services.

grpc-gateway uses code generation to create a reverse-proxy server. The reverse proxy translates RESTful calls into gRPC+Protobuf and sends the calls over HTTP/2 to the gRPC service. The benefit of this approach is the gRPC service doesn't know about the RESTful JSON APIs. Any gRPC server can use grpc-gateway.

Meanwhile, gRPC JSON transcoding runs inside an ASP.NET Core app. It deserializes JSON into Protobuf messages, then invokes the gRPC service directly. JSON transcoding in ASP.NET Core offers advantages to .NET app developers:

* Less complex: Both gRPC services and mapped RESTful JSON API run out of one ASP.NET Core app.
* Better performance: JSON transcoding deserializes JSON to Protobuf messages and invokes the gRPC service directly. There are significant performance benefits in doing this in-process versus making a new gRPC call to a different server.
* Lower cost: Fewer servers result in a smaller monthly hosting bill.

For installation and usage of grpc-gateway, see the [grpc-gateway README](https://github.com/grpc-ecosystem/grpc-gateway/#grpc-gateway).

## Additional resources

* [google.api.HttpRule documentation](https://cloud.google.com/service-infrastructure/docs/service-management/reference/rpc/google.api#google.api.HttpRule)
* <xref:grpc/browser>
