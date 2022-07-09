---
title: Versioning gRPC services
author: jamesnk
description: Learn how to version gRPC services.
monikerRange: '>= aspnetcore-3.0'
ms.author: jamesnk
ms.date: 01/09/2020
uid: grpc/versioning
---
# Versioning gRPC services

By [James Newton-King](https://twitter.com/jamesnk)

New features added to an app can require gRPC services provided to clients to change, sometimes in unexpected and breaking ways. When gRPC services change:

* Consideration should be given on how changes impact clients.
* A versioning strategy to support changes should be implemented.

## Backwards compatibility

The gRPC protocol is designed to support services that change over time. Generally, additions to gRPC services and methods are non-breaking. Non-breaking changes allow existing clients to continue working without changes. Changing or deleting gRPC services are breaking changes. When gRPC services have breaking changes, clients using that service have to be updated and redeployed.

Making non-breaking changes to a service has a number of benefits:

* Existing clients continue to run.
* Avoids work involved with notifying clients of breaking changes, and updating them.
* Only one version of the service needs to be documented and maintained.

### Non-breaking changes

These changes are non-breaking at a gRPC protocol level and .NET binary level.

* **Adding a new service**
* **Adding a new method to a service**
* **Adding a field to a request message** - Fields added to a request message are deserialized with the [default value](https://developers.google.com/protocol-buffers/docs/proto3#default) on the server when not set. To be a non-breaking change, the service must succeed when the new field isn't set by older clients.
* **Adding a field to a response message** - Fields added to a response message are deserialized into the message's [unknown fields](https://developers.google.com/protocol-buffers/docs/proto3#unknowns) collection on the client.
* **Adding a value to an enum** - Enums are serialized as a numeric value. New enum values are deserialized on the client to the enum value without an enum name. To be a non-breaking change, older clients must run correctly when receiving the new enum value.

### Binary breaking changes

The following changes are non-breaking at a gRPC protocol level, but the client needs to be updated if it upgrades to the latest `.proto` contract or client .NET assembly. Binary compatibility is important if you plan to publish a gRPC library to NuGet.

* **Removing a field** - Values from a removed field are deserialized to a message's [unknown fields](https://developers.google.com/protocol-buffers/docs/proto3#unknowns). This isn't a gRPC protocol breaking change, but the client needs to be updated if it upgrades to the latest contract. It's important that a removed field number isn't accidentally reused in the future. To ensure this doesn't happen, specify deleted field numbers and names on the message using Protobuf's [reserved](https://developers.google.com/protocol-buffers/docs/proto3#reserved) keyword.
* **Renaming a message** - Message names aren't typically sent on the network, so this isn't a gRPC protocol breaking change. The client will need to be updated if it upgrades to the latest contract. One situation where message names **are** sent on the network is with [Any](https://developers.google.com/protocol-buffers/docs/proto3#any) fields, when the message name is used to identify the message type.
* **Nesting or unnesting a message** - Message types can be [nested](https://developers.google.com/protocol-buffers/docs/proto3#nested). Nesting or unnesting a message changes its message name. Changing how a message type is nested has the same impact on compatibility as renaming.
* **Changing csharp_namespace** - Changing `csharp_namespace` will change the namespace of generated .NET types. This isn't a gRPC protocol breaking change, but the client needs to be updated if it upgrades to the latest contract.

### Protocol breaking changes

The following items are protocol and binary breaking changes:

* **Renaming a field** - With Protobuf content, the field names are only used in generated code. The field number is used to identify fields on the network. Renaming a field isn't a protocol breaking change for Protobuf. However, if a server is using JSON content then renaming a field is a breaking change.
* **Changing a field data type** - Changing a field's data type to an [incompatible type](https://developers.google.com/protocol-buffers/docs/proto3#updating) will cause errors when deserializing the message. Even if the new data type is compatible, it's likely the client needs to be updated to support the new type if it upgrades to the latest contract.
* **Changing a field number** - With Protobuf payloads, the field number is used to identify fields on the network.
* **Renaming a package, service or method** - gRPC uses the package name, service name, and method name to build the URL. The client gets an *UNIMPLEMENTED* status from the server.
* **Removing a service or method** - The client gets an *UNIMPLEMENTED* status from the server when calling the removed method.

### Behavior breaking changes

When making non-breaking changes, you must also consider whether older clients can continue working with the new service behavior. For example, adding a new field to a request message:

* Isn't a protocol breaking change.
* Returning an error status on the server if the new field isn't set makes it a breaking change for old clients.

Behavior compatibility is determined by your app-specific code.

## Version number services

Services should strive to remain backwards compatible with old clients. Eventually changes to your app may require breaking changes. Breaking old clients and forcing them to be updated along with your service isn't a good user experience. A way to maintain backwards compatibility while making breaking changes is to publish multiple versions of a service.

gRPC supports an optional [package](https://developers.google.com/protocol-buffers/docs/proto3#packages) specifier, which functions much like a .NET namespace. In fact, the `package` will be used as the .NET namespace for generated .NET types if `option csharp_namespace` is not set in the `.proto` file. The package can be used to specify a version number for your service and its messages:

[!code-protobuf[](versioning/sample/greet.v1.proto?highlight=3)]

The package name is combined with the service name to identify a service address. A service address allows multiple versions of a service to be hosted side-by-side:

* `greet.v1.Greeter`
* `greet.v2.Greeter`

Implementations of the versioned service are registered in `Startup.cs`:

```csharp
app.UseEndpoints(endpoints =>
{
    // Implements greet.v1.Greeter
    endpoints.MapGrpcService<GreeterServiceV1>();

    // Implements greet.v2.Greeter
    endpoints.MapGrpcService<GreeterServiceV2>();
});
```

Including a version number in the package name gives you the opportunity to publish a *v2* version of your service with breaking changes, while continuing to support older clients who call the *v1* version. Once clients have updated to use the *v2* service, you can choose to remove the old version. When planning to publish multiple versions of a service:

* Avoid breaking changes if reasonable.
* Don't update the version number unless making breaking changes.
* Do update the version number when you make breaking changes.

Publishing multiple versions of a service duplicates it. To reduce duplication, consider moving business logic from the service implementations to a centralized location that can be reused by the old and new implementations:

[!code-csharp[](versioning/sample/GreeterServiceV1.cs?highlight=10,19)]

Services and messages generated with different package names are **different .NET types**. Moving business logic to a centralized location requires mapping messages to common types.

## Additional resources

* <xref:grpc/protobuf>
