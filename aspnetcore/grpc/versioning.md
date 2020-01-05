---
title: Versioning gRPC services
author: jamesnk
description: Learn how to version gRPC services.
monikerRange: '>= aspnetcore-3.0'
ms.author: jamesnk
ms.date: 01/06/2020
uid: grpc/versioning
---
# Versioning gRPC services

New features added to an app can require gRPC services provided to clients to evolve, sometimes in unexpected and breaking ways. You need to consider how changes to gRPC services will impact clients, and come up with a versioning strategy to support them.

## Backwards compatibility

The gRPC protocol is designed to support services that change over time. Generally additions to gRPC services and methods are non-breaking (existing clients continue to work), while changing or deleting gRPC services are breaking (existing clients will fail).

Making non-breaking changes to a service has a number of benefits:

- Existing clients continue to run.
- Avoid work involved with notifying clients of breaking changes, and updating them.
- You only need to maintain and document one version of your service.

> [!NOTE]
> This content focuses on whether changes are breaking at a gRPC protocol and .NET binary compatibility level. When making changes you must also consider whether older clients can logically still work. For example, adding a new field to a request message is not a protocol breaking change, but erroring if it is not set makes it a breaking change for old clients.

### Non-breaking changes

These changes are non-breaking at a gRPC protocol level, and .NET binary level.

- **Adding a new service** - Adding a new service to an app has no impact on existing clients.
- **Adding a new method to a service** - Adding a new method to a service has no impact on existing clients.
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

- **Changing a field data type** - Changing a field's data type to an [incompatible type](https://developers.google.com/protocol-buffers/docs/proto3#updating) will cause errors when deserializing the message. Even if the new data type is compatible, it is likely the client will need to be updated to support the new type if it upgrades to the latest contract.
- **Changing a field number** - The field number is used to identify fields on the wire.
- **Renaming a package, service or method** - gRPC uses the package name, service name and method name to build the URL. The client will get an *UNIMPLEMENTED* status from the server.
- **Removing a service or method** - The client will get an *UNIMPLEMENTED* status from the server when calling the removed method.

## Version number your services

Services should strive to remain backwards compatible with old clients, but eventually changes to your app may force you to make breaking changes. A simple answer is to break old clients and force them to be updated along with your service, but that isn't a good experience for users. A way to maintain backwards compatibility while making breaking changes is to publish multiple versions of a service.

gRPC supports an optional [`package`](https://developers.google.com/protocol-buffers/docs/proto3#packages) specifier, which functions much like a .NET namespace. In fact the `package` will be used as the .NET namespace for generated .NET types if `option csharp_namespace` is not set in the *.proto* file. The package can be used to specify a version number for your service and its messages:

[!code-protobuf[](versioning/sample/greet.v1.proto?highlight=3)]

The package name is combined with the service name to identify a service address, which allows multiple versions of a service to be hosted side-by-side:

* `greet.v1.Greeter`
* `greet.v2.Greeter`

Including a [SemVer major version number](https://semver.org/) in the package name gives you the opporutunity to publish a *v2* version of your service with breaking changes, while continuing to support older clients who call the *v1* version. To avoid duplication you should considering moving business logic from the service implementations to a centralized location that can be reused by the old and new implementations:

[!code-csharp[](versioning/sample/GreeterServiceV1.cs?highlight=10,19)]

> [!NOTE]
> Services and messages generated from different packages are different .NET types. Moving business logic to a centralized location will require mapping messages to common types.
