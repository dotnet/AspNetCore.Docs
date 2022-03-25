---
title: Create JSON Web APIs from gRPC
author: jamesnk
description: Learn how to create JSON HTTP APIs for gRPC services.
monikerRange: '>= aspnetcore-3.0'
ms.author: jamesnk
ms.date: 08/28/2020
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: grpc/httpapi
---
# Create JSON Web APIs from gRPC

By [James Newton-King](https://twitter.com/jamesnk)

> [!IMPORTANT]
> gRPC HTTP API is an experimental project, not a committed product. We want to:
>
> * Test that our approach to creating JSON Web APIs for gRPC services works.
> * Get feedback on if this approach is useful to .NET developers.
>
> Please [leave feedback](https://github.com/grpc/grpc-dotnet/issues/167) to ensure we build something that developers like and are productive with.

gRPC is a modern way to communicate between apps. gRPC uses HTTP/2, streaming, Protobuf and message contracts to create high-performance, real-time services.

One limitation with gRPC is not every platform can use it. Browsers don't fully support HTTP/2, making REST and JSON the primary way to get data into browser apps. Even with the benefits that gRPC brings, REST and JSON have an important place in modern apps. Building gRPC ***and*** JSON Web APIs adds unwanted overhead to app development.

This document discusses how to create JSON Web APIs using gRPC services.

## gRPC HTTP API

gRPC HTTP API is an experimental extension for ASP.NET Core that creates RESTful JSON APIs for gRPC services. Once configured, gRPC HTTP API allows apps to call gRPC services with familiar HTTP concepts:

* HTTP verbs
* URL parameter binding
* JSON requests/responses

gRPC can still be used to call services.

### Usage

1. Add a package reference to [Microsoft.AspNetCore.Grpc.HttpApi](https://www.nuget.org/packages/Microsoft.AspNetCore.Grpc.HttpApi).
1. Register services in `Startup.cs` with `AddGrpcHttpApi`.
1. Add [google/api/http.proto](https://github.com/aspnet/AspLabs/blob/c1e59cacf7b9606650d6ec38e54fa3a82377f360/src/GrpcHttpApi/sample/Proto/google/api/http.proto) and [google/api/annotations.proto](https://github.com/aspnet/AspLabs/blob/c1e59cacf7b9606650d6ec38e54fa3a82377f360/src/GrpcHttpApi/sample/Proto/google/api/annotations.proto) files to your project.
1. Annotate gRPC methods in your `.proto` files with HTTP bindings and routes:

[!code-protobuf[](~/grpc/httpapi/greet.proto?highlight=3,9-11)]

The `SayHello` gRPC method can now be invoked as gRPC+Protobuf and as an HTTP API:

* Request: `HTTP/1.1 GET /v1/greeter/world`
* Response: `{ "message": "Hello world" }`

Server logs show that the HTTP call is executed by a gRPC service. gRPC HTTP API maps the incoming HTTP request to a gRPC message, and then converts the response message to JSON.

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

### Enable Swagger/OpenAPI support

Swagger (OpenAPI) is a language-agnostic specification for describing REST APIs. gRPC HTTP API can integrate with [Swashbuckle](https://github.com/domaindrivendev/Swashbuckle.AspNetCore) to generate a Swagger endpoint for RESTful gRPC services. The Swagger endpoint can then be used with [Swagger UI](https://swagger.io/swagger-ui/) and other tooling.

To enable Swagger with gRPC HTTP API:

1. Add a package reference to [Microsoft.AspNetCore.Grpc.Swagger](https://www.nuget.org/packages/Microsoft.AspNetCore.Grpc.Swagger).
2. Configure Swashbuckle in `Startup.cs`. The `AddGrpcSwagger` method configures Swashbuckle to include gRPC HTTP API endpoints.

[!code-csharp[](~/grpc/httpapi/Startup.cs?name=snippet_1&highlight=6-10,15-19)]

To confirm that Swashbuckle is generating Swagger for the RESTful gRPC services, start the app and navigate to the Swagger UI page:

![Swagger UI](~/grpc/httpapi/static/swaggerui.png)

### gRPC HTTP API vs gRPC-Web

Both gRPC HTTP API and gRPC-Web allow gRPC services to be called from a browser. However, the way each does this is different:

* gRPC-Web lets browser apps call gRPC services from the browser with the gRPC-Web client and Protobuf. gRPC-Web requires the browser app generate a gRPC client, and has the advantage of sending small, fast Protobuf messages.
* gRPC HTTP API allows browser apps to call gRPC services as if they were RESTful APIs with JSON. The browser app doesn't need to generate a gRPC client or know anything about gRPC.

No generated client is created for gRPC HTTP API. The previous `Greeter` service can be called using browser JavaScript APIs:

```javascript
var name = nameInput.value;

fetch("/v1/greeter/" + name).then(function (response) {
  response.json().then(function (data) {
    console.log("Result: " + data.message);
  });
});
```

### Experimental status

gRPC HTTP API is an experiment. It is not complete and it is not supported. We're interested in this technology, and the ability it gives app developers to quickly create gRPC and JSON services at the same time. There is no commitment to completing the gRPC HTTP API.

We want to gauge developer interest in gRPC HTTP API. If gRPC HTTP API is interesting to you then please [give feedback](https://github.com/grpc/grpc-dotnet/issues/167).

## grpc-gateway

[grpc-gateway](https://grpc-ecosystem.github.io/grpc-gateway/) is another technology for creating RESTful JSON APIs from gRPC services. It uses the same `.proto` annotations to map HTTP concepts to gRPC services.

The biggest difference between grpc-gateway and gRPC HTTP API is grpc-gateway uses code generation to create a reverse-proxy server. The reverse-proxy translates RESTful calls into gRPC and then sends them on to the gRPC service.

For installation and usage of grpc-gateway, see the [grpc-gateway README](https://github.com/grpc-ecosystem/grpc-gateway/#grpc-gateway).

## Additional resources

* [google.api.HttpRule documentation](https://cloud.google.com/service-infrastructure/docs/service-management/reference/rpc/google.api#google.api.HttpRule)
* <xref:grpc/browser>
