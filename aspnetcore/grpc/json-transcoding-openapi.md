---
title: Use OpenAPI with gRPC JSON transcoding ASP.NET Core gRPC apps
author: jamesnk
description: Learn how to configure gRPC JSON transcoding to generate OpenAPI.
monikerRange: '>= aspnetcore-7.0'
ms.author: jamesnk
ms.date: 09/20/2022
uid: grpc/json-transcoding-openapi
---
# gRPC JSON transcoding documentation with Swagger / OpenAPI

By [James Newton-King](https://twitter.com/jamesnk)

[OpenAPI (Swagger)](https://swagger.io/specification/) is a language-agnostic specification for describing REST APIs. gRPC JSON transcoding supports generating OpenAPI from transcoded RESTful APIs. The [Microsoft.AspNetCore.Grpc.Swagger](https://www.nuget.org/packages/Microsoft.AspNetCore.Grpc.Swagger) package:

* Integrates gRPC JSON transcoding with [Swashbuckle](xref:tutorials/get-started-with-swashbuckle).
* Is experimental in .NET 7 to allow us to explore the best way to provide OpenAPI support.

## Get started

To enable OpenAPI with gRPC JSON transcoding:

1. Add a package reference to [Microsoft.AspNetCore.Grpc.Swagger](https://www.nuget.org/packages/Microsoft.AspNetCore.Grpc.Swagger). The version must be 0.3.0-xxx or greater.
2. Configure Swashbuckle in startup. The `AddGrpcSwagger` method configures Swashbuckle to include gRPC endpoints.

[!code-csharp[](~/grpc/httpapi/Program.cs?name=snippet_1&highlight=3-8,11-15)]

## Add OpenAPI descriptions from `.proto` comments

Generate OpenAPI descriptions from comments in the `.proto` contract, as in the following example:

```protobuf
// My amazing greeter service.
service Greeter {
  // Sends a greeting.
  rpc SayHello (HelloRequest) returns (HelloReply) {
    option (google.api.http) = {
      get: "/v1/greeter/{name}"
    };
  }
}

message HelloRequest {
  // Name to say hello to.
  string name = 1;
}

message HelloReply {
  // Hello reply message.
  string message = 1;
}
```

To enable gRPC OpenAPI comments:

1. Enable the XML documentation file in the server project with `<GenerateDocumentationFile>true</GenerateDocumentationFile>`.
2. Configure `AddSwaggerGen` to read the generated XML file. Pass the XML file path to `IncludeXmlComments` and `IncludeGrpcXmlComments`, as in the following example:

```csharp
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new OpenApiInfo { Title = "gRPC transcoding", Version = "v1" });

    var filePath = Path.Combine(System.AppContext.BaseDirectory, "Server.xml");
    c.IncludeXmlComments(filePath);
    c.IncludeGrpcXmlComments(filePath, includeControllerXmlComments: true);
});
```

To confirm that Swashbuckle is generating OpenAPI with descriptions for the RESTful gRPC services, start the app and navigate to the Swagger UI page:

![Swagger UI](~/grpc/httpapi/static/swaggerui.png)

## Additional resources

* <xref:grpc/json-transcoding>
* [OpenAPI homepage](https://www.openapis.org/)
* [Swashbuckle.AspNetCore GitHub repository](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)
