---
title: Configure HTTP and JSON for gRPC JSON transcoding ASP.NET Core apps
author: jamesnk
description: Learn how to configure HTTP and JSON for gRPC JSON transcoding apps.
monikerRange: '>= aspnetcore-7.0'
ms.author: jamesnk
ms.date: 09/20/2022
uid: grpc/json-transcoding-binding
---
# Configure HTTP and JSON for gRPC JSON transcoding

By [James Newton-King](https://twitter.com/jamesnk)

gRPC JSON transcoding creates RESTful JSON web APIs from gRPC methods. It uses annotations and options for customizing how a RESTful API maps to the gRPC methods.

## HTTP rules

gRPC methods must be annotated with an HTTP rule before they support transcoding. The HTTP rule includes information about calling the gRPC method as a RESTful API, such as the HTTP method and route.

[!code-protobuf[](~/grpc/json-transcoding-binding/basic.proto?highlight=1,5-7)]

An HTTP rule is:

* An annotation on gRPC methods.
* Identified by the name `google.api.http`.
* Imported from the `google/api/annotations.proto` file. The [`google/api/http.proto`](https://github.com/dotnet/aspnetcore/blob/main/src/Grpc/JsonTranscoding/test/testassets/Sandbox/google/api/http.proto) and [`google/api/annotations.proto`](https://github.com/dotnet/aspnetcore/blob/main/src/Grpc/JsonTranscoding/test/testassets/Sandbox/google/api/annotations.proto) files need to be in the project.

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

### HTTP method

The HTTP method is specified by setting the route to the matching HTTP method field name:

* `get`
* `put`
* `post`
* `delete`
* `patch`

The `custom` field allows for other HTTP methods.

In the following example, the `CreateAddress` method is mapped to `POST` with the specified route:

[!code-protobuf[](~/grpc/json-transcoding-binding/httpmethod.proto?highlight=4)]

### Route

gRPC JSON transcoding routes support route parameters. For example, `{name}` in a route binds to the `name` field on the request message.

To bind a field on a nested message, specify the path to the field. In the following example, `{params.org}` binds to the `org` field on the `IssueParams` message:

[!code-protobuf[](~/grpc/json-transcoding-binding/route.proto?highlight=4,11)]

Transcoding routes and [ASP.NET Core routes](xref:fundamentals/routing) have a similar syntax and feature set. However, some ASP.NET Core routing features aren't supported by transcoding. These include:

* [Route constraints](xref:fundamentals/routing#route-constraints)
* [Default values](xref:fundamentals/routing#route-templates)
* [Optional parameters](xref:fundamentals/routing#route-templates)
* [Complex segments](xref:fundamentals/routing#complex-segments)

### Request body

Transcoding deserializes the request body JSON to the request message. The `body` field specifies how the HTTP request body maps to the request message. The value is either the name of the request field whose value is mapped to the HTTP request body or `*` for mapping all request fields.

In the following example, the HTTP request body is deserialized to the `address` field:

[!code-protobuf[](~/grpc/json-transcoding-binding/requestbody.proto?highlight=5,12)]

### Query parameters

Any fields in the request message that aren't bound by route parameters or the request body can be set using HTTP query parameters.

[!code-protobuf[](~/grpc/json-transcoding-binding/queryparameters.proto?highlight=12-13)]

In the preceding example:

* `org` and `repo` fields are bound from route parameters.
* Other fields, such as `text` and the nested fields from `page`, can be bound from the query string: `?text=value&page.index=0&page.size=10`

### Response body

By default, transcoding serializes the entire response message as JSON. The `response_body` field allows serialization of a subset of the response message.

[!code-protobuf[](~/grpc/json-transcoding-binding/responsebody.proto?highlight=5,12)]

In the preceding example, the `address` field is serialized to the response body as JSON.

### Specification

For more information about customizing gRPC transcoding, see the [HttpRule specification](https://cloud.google.com/service-infrastructure/docs/service-management/reference/rpc/google.api#google.api.HttpRule).

## Customize JSON

Messages are converted to and from JSON using the [JSON mapping in the Protobuf specification](https://developers.google.com/protocol-buffers/docs/proto3#json). Protobuf's JSON mapping is a standardized way to convert between JSON and Protobuf, and all serialization follows these rules.

However, gRPC JSON transcoding offers some limited options for customizing JSON with <xref:Microsoft.AspNetCore.Grpc.JsonTranscoding.GrpcJsonSettings>, as shown in the following table.

| Option | Default Value | Description |
| ------ | ------------- | ----------- |
| <xref:Microsoft.AspNetCore.Grpc.JsonTranscoding.GrpcJsonSettings.IgnoreDefaultValues> | `false` | If set to `true`, fields with default values are ignored during serialization. |
| <xref:Microsoft.AspNetCore.Grpc.JsonTranscoding.GrpcJsonSettings.WriteEnumsAsIntegers> | `false` | If set to `true`, enum values are written as integers instead of strings. |
| <xref:Microsoft.AspNetCore.Grpc.JsonTranscoding.GrpcJsonSettings.WriteInt64sAsStrings> | `false` | If set to `true`, `Int64` and `UInt64` values are written as strings instead of numbers. |
| <xref:Microsoft.AspNetCore.Grpc.JsonTranscoding.GrpcJsonSettings.WriteIndented> | `false` | If set to `true`, JSON is written using pretty printing. This option doesn't affect streaming methods, which write line-delimited JSON messages and can't use pretty printing. |

```csharp
builder.Services.AddGrpc().AddJsonTranscoding(o =>
{
    o.JsonSettings.WriteIndented = true;
});
```

In the `.proto` file, the `json_name` field option customizes a field's name when it's serialized as JSON, as in the following example:

```protobuf
message TestMessage {
  string my_field = 1 [json_name="customFieldName"];
}
```

Transcoding doesn't support advanced JSON customization. Apps requiring precise JSON structure control should consider using [ASP.NET Core Web API](xref:web-api/index).

## Additional resources

* <xref:grpc/json-transcoding>
* [HttpRule specification](https://cloud.google.com/service-infrastructure/docs/service-management/reference/rpc/google.api#google.api.HttpRule)
