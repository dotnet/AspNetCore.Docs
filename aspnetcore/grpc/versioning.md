---
title: gRPC versioning
author: jamesnk
description: Learn how to version gRPC services.
monikerRange: '>= aspnetcore-3.0'
ms.author: jamesnk
ms.date: 06/01/2020
uid: grpc/versioning
---
# Versioning

Most apps will change over time. As new features are added and bugs are fixed in an app, the services exposed to clients will also evolve, in unexpected and potentially breaking ways. As you make changes after your initial release you need to consider how changes to services will impact clients of your gRPC services, and come up with a versioning strategy to support them.

A simple answer to versioning is to break old clients and force them to be updated along with your service, but that isn't a good experience for users. This article looks at strategies to evolve gRPC services while providing backwards compatibility with older clients.

## Backwards compatibility

The gRPC protocol is designed to support services that change over time. A general rule of thumb is adding to a *.proto* contract is backwards compatible, and clients implemented using an older contract are able to call the updated gRPC services. Changing and deleting what already exists in a contract is breaking to old clients, and requires them to be updated to continue working correctly.

> !NOTE
> This content focuses on whether changes are breaking at a gRPC protocol and .NET binary compatibility level. When making changes you must also consider whether older clients can logically still work. For example, adding a new field to a request message is not a protocol breaking change, but if the service errors when the field is not set then older clients will still be broken.

Making non-breaking changes to a service has a number of benefits:

- Existing clients continue to run correctly
- You only need to maintain and document one version of your service

### Non-breaking changes

These changes are non-breaking at a gRPC protocol level, and .NET binary level.

- **Adding a new service** - Services are independent of each other. Adding a new service to an app has no impact on existing clients.
- **Adding a new method to a service** - Methods are independent of each other. Adding a new method to a service has no impact on existing clients.
- **Adding a field to a request message** - Fields added to a request message will be deserialized with the [default value](https://developers.google.com/protocol-buffers/docs/proto3#default) on the server when not set.
- **Adding a field to a response message** - Fields added to a response message will be deserialized into the message's [unknown fields](https://developers.google.com/protocol-buffers/docs/proto3#unknowns) collection on the client.
- **Adding a value to an enum** - Enums are serialized as a numeric value. New enum values are deserialized on the client to the enum value without an enum name.

### Binary breaking changes

These changes are non-breaking at a gRPC protocol level, but the client will need to be updated if it upgrades to the latest *.proto* contract or client .NET assembly.

- **Removing a field** - Values from a removed field are deserialized to a message's [unknown fields](https://developers.google.com/protocol-buffers/docs/proto3#unknowns). This isn't a gRPC protocol breaking change, but the client will need to be updated if it upgrades to the latest contract. It is important that a removed field number is not accidently reused in the future. One way to make sure this doesn't happen is to specify deleted field numbers and names on the message using Protobuf's [`reserved`](https://developers.google.com/protocol-buffers/docs/proto3#reserved) keyword.
- **Renaming a field** - Field names are only used in generated code. The field number is used to identify fields on the wire. The client will need to be updated if it upgrades to the latest contract.
- **Renaming a message** - Message names are not sent on the wire so this isn't a gRPC protocol breaking change, but the client will need to be updated if it upgrades to the latest contract.

### Breaking changes

These are protocol and binary breaking changes.

1. **Changing a field data type** - Changing a field's data type to an [incompatible type](https://developers.google.com/protocol-buffers/docs/proto3#updating) will cause errors when deserializing the message. Even if the new data type is compatible, it is likely the client will need to be updated to support the new type if it upgrades to the latest contract.
2. **Changing a field number** - The field number is used to identify fields on the wire.
3. **Renaming a package, service or method** - gRPC uses the package name, service name and method name to build the URL. The client will get an *UNIMPLEMENTED* status from the server.
4. **Removing a service or method** - The client will get an *UNIMPLEMENTED* status from the server when calling the removed method.

## Versioning your services

Services should strive to remain backwards compatible with old clients, but eventually changes to your app may force you to make breaking changes. In this situation you can continue to maintain backwards compatibility by publishing multiple versions of a service.

gRPC supports an optional [`package`](https://developers.google.com/protocol-buffers/docs/proto3#packages) specifier, which functions much like a .NET namespace. In fact the `package` will be used as the .NET namespace for generated .NET types if `option csharp_namespace` is not set in the *.proto* file. The package can be used to specify a version number for your service and its messages:

[!code-protobuf[](versioning/sample/greet.v1.proto?highlight=3)]

The package name is combined with the service name to identify a service address, which allows multiple versions of a service to be hosted side-by-side:

* `greet.v1.Greeter`
* `greet.v2.Greeter`

Including a version number in the package gives you the opporutunity to publish a *v2* version of your service with breaking changes, while continuing to support older clients who call the *v1* version. To avoid duplication you should considering moving business logic from the service implementations to a centralized location that can be reused by the old and new implementations:

[!code-csharp[](versioning/sample/GreeterServiceV1.cs?highlight=19)]

> !NOTE
> Services and messages generated from different packages are different .NET types. Moving business logic to a centralized location will require mapping messages to common types.
