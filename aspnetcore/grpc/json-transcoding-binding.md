---
title: Configure HTTP rules for gRPC JSON transcoding in ASP.NET Core gRPC apps
author: jamesnk
description: Learn how to configure HTTP rules for gRPC JSON transcoding in ASP.NET Core gRPC apps.
monikerRange: '>= aspnetcore-7.0'
ms.author: jamesnk
ms.date: 05/20/2022
uid: grpc/json-transcoding-binding
---
# Configure HTTP and JSON for gRPC JSON transcoding

By [James Newton-King](https://twitter.com/jamesnk)

gRPC JSON transcoding creates RESTful JSON web APIs from gRPC methods. There are annotations and options for customizing how a RESTful API maps to the gRPC methods.

## HTTP rules

gRPC methods must be annotated with an HTTP rule before they support transcoding. The HTTP rule includes information about how to call the gRPC method as a RESTful API, such as the HTTP method and route.

```protobuf
import "google/api/annotations.proto";

service Greeter {
  rpc SayHello (HelloRequest) returns (HelloReply) {
    option (google.api.http) = {
      get: "/v1/greeter/{name}"
    };
  }
}
```

The proceeding example:

* Defines a `Greeter` service with a `SayHello` method. The method has a HTTP rule specified using the name `google.api.http`.
* The method is accessible with `GET` requests and the `/v1/greeter/{name}` route.
* The `name` field on the request message is bound to a route parameter.

This is a basic example. See [HttpRule](https://cloud.google.com/service-infrastructure/docs/service-management/reference/rpc/google.api#google.api.HttpRule) for more customization options.

### HTTP method

The HTTP method and route is specified by setting the route to the matching HTTP method field name:

* `get`
* `put`
* `post`
* `delete`
* `patch`

```protobuf
service Address {
  rpc CreateAddress (CreateAddressRequest) returns (CreateAddressReply) {
    option (google.api.http) = {
      post: "/v1/address",
      body: "*"
    };
  }
}
```

The `custom` field allows for other HTTP methods.

### Route

gRPC JSON transcoding routes support route parameters. For example, `{name}` in a route binds to the `name` field on the request message.

Fields on nested messages can be bound by specifying the path to the field. In the example below, `{filter.org}` binds to the `org` field on the `IssueParams` message.

```protobuf
service Repository {
  rpc GetIssue (GetIssueRequest) returns (GetIssueReply) {
    option (google.api.http) = {
      get: "/{apiVersion}/{params.org}/{params.repo}/issue/{params.issueId}"
    };
  }
}

message GetIssueRequest {
  int32 api_version = 1;
  IssueParams params = 2;
}
message IssueParams {
  string org = 1;
  string repo = 2;
  int32 issueId = 3;
}
```

Note that ASP.NET Core features such as route constraints, default values, and optional parameters aren't supported by transcoding.

### Request body

Transcoding supports converting JSON sent in the HTTP request body to the request message. The `body` field specifies how the HTTP request body maps to the request message. The value is either the name of the request field whose value is mapped to the HTTP request body, or `*` for mapping all request fields.

In the following example, the HTTP request body is bound to the `address` field:

```protobuf
service Address {
  rpc AddAddress (AddAddressRequest) returns (AddAddressReply) {
    option (google.api.http) = {
      post: "/{apiVersion}/address",
      body: "address"
    };
  }
}

message AddAddressRequest {
  int32 api_version = 1;
  Address address = 2;
}
message Address {
  string street = 1;
  string city = 2;
  string country = 3;
}
```

### Query parameters

Any fields in the request message which are not bound by route parameters, or request body, can be set using HTTP query parameters.

```protobuf
service Repository {
  rpc GetIssues (GetIssuesRequest) returns (GetIssuesReply) {
    option (google.api.http) = {
      get: "/v1/{org}/{repo}/issue"
    };
  }
}

message GetIssuesRequest {
  string org = 1;
  string repo = 2;
  string text = 3;
  PageParams page = 4;
}
message PageParams {
  int32 index = 1;
  int32 size = 2;
}
```

In the preceding example:

* `org` and `repo` fields are bound from route parameters.
* Other fields, including nested fields, can be bound from the query string: `?text=value&page.index=0&page.size=10`

### Response body

By default, transcoding serializes the entire return message as JSON to the response. This can be customized by using the `response_body` field.

```protobuf
service Address {
  rpc GetAddress (GetAddressRequest) returns (GetAddressReply) {
    option (google.api.http) = {
      get: "/v1/address/{id}",
      response_body: "address"
    };
  }
}

message GetAddressReply {
  int32 version = 1;
  Address address = 2;
}
message Address {
  string street = 1;
  string city = 2;
  string country = 3;
}
```

In the preceding example, the `address` field is serialized to the response body as JSON.

## Customize JSON

Messages are converted to and from JSON using the [JSON mapping in the Protobuf specification](https://developers.google.com/protocol-buffers/docs/proto3#json). There are limited options for customizing JSON with <xref:Microsoft.AspNetCore.Grpc.JsonTranscoding.GrpcJsonSettings>:

| Option | Default Value | Description |
| ------ | ------------- | ----------- |
| `IgnoreDefaultValues` | false | If set to `true`, fields with default values are ignored during serialization. |
| `WriteEnumsAsIntegers` | false | If set to `true`, enum values are written as integers instead of strings. |
| `WriteInt64sAsStrings` | false | If set to `true`, `Int64` and `UInt64` values are written as strings instead of numbers. |
| `WriteIndented` | false | If set to `true`, JSON is written using pretty printing. Note that this option doesn't effect streaming methods, which write line delimited JSON messages and can't use pretty printing. |

```csharp
builder.Services.AddGrpc().AddJsonTranscoding(o =>
{
    o.JsonSettings.WriteIndented = true;
});
```

In the `.proto` file, the `json_name` field option customizes a field's name when it's serialized as JSON:

```protobuf
message TestMessage {
  string my_field = 1 [json_name="customFieldName"];
}
```

Advanced JSON customization isn't supported by transcoding. Apps that require exact control of JSON structure should consider using [ASP.NET Core Web API](xref:web-api/index).

## Additional resources

* <xref:grpc/json-transcoding>
* [google.api.HttpRule documentation](https://cloud.google.com/service-infrastructure/docs/service-management/reference/rpc/google.api#google.api.HttpRule)
