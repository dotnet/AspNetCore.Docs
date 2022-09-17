---
title: Test gRPC services with Postman or gRPCurl in ASP.NET Core
author: jamesnk
description: Learn how to test services with gRPC tools. Postman is an interactive web UI. gRPCurl a command-line tool for interacting with gRPC services. gRPCui is an interactive web UI.
monikerRange: '>= aspnetcore-3.0'
ms.author: jamesnk
ms.date: 03/31/2022
uid: grpc/test-tools
---
# Test gRPC services with Postman or gRPCurl in ASP.NET Core

By [James Newton-King](https://twitter.com/jamesnk)
:::moniker range=">= aspnetcore-6.0"
Tooling is available for gRPC that allows developers to test services without building client apps:

* [Postman](https://www.postman.com/) is an API platform with an interactive UI for calling APIs. Postman can run in the browser or be downloaded and run locally. Postman supports calling gRPC services.
* [gRPCurl](https://github.com/fullstorydev/grpcurl) is an open-source command-line tool that provides interaction with gRPC services.
* [gRPCui](https://github.com/fullstorydev/grpcui) builds on top of gRPCurl and adds an open-source interactive web UI for gRPC.

This article discusses how to:

* Set up gRPC server reflection with a gRPC ASP.NET Core app.
* Interact with gRPC using test tools:
  * Call gRPC services in Postman.
  * Discover and test gRPC services with `grpcurl`.
  * Interact with gRPC services via a browser using `grpcui`.

> [!NOTE]
> To learn how to unit test gRPC services, see <xref:grpc/test-services>.

## Set up gRPC reflection

Tooling must know the Protobuf contract of services before it can call them. There are two ways to do this:

* Set up [gRPC reflection](https://github.com/grpc/grpc/blob/master/doc/server-reflection.md) on the server. Tools, such as gRPCurl and Postman, use reflection to automatically discover service contracts.
* Add `.proto` files to the tool manually.

It's easier to use gRPC reflection. gRPC reflection adds a new gRPC service to the app that clients can call to discover services.

gRPC ASP.NET Core has built-in support for gRPC reflection with the [`Grpc.AspNetCore.Server.Reflection`](https://www.nuget.org/packages/Grpc.AspNetCore.Server.Reflection) package. To configure reflection in an app:

* Add a `Grpc.AspNetCore.Server.Reflection` package reference.
* Register reflection in `Program.cs`:
  * `AddGrpcReflection` to register services that enable reflection.
  * `MapGrpcReflectionService` to add a reflection service endpoint.

[!code-csharp[](~/grpc/test-tools/samples/6.x/Program.cs?name=snippet_1&highlight=2,10-13)]

When gRPC reflection is set up:

* A gRPC reflection service is added to the server app.
* Client apps that support gRPC reflection can call the reflection service to discover services hosted by the server.
* gRPC services are still called from the client. Reflection only enables service discovery and doesn't bypass server-side security. Endpoints protected by [authentication and authorization](xref:grpc/authn-and-authz) require the caller to pass credentials for the endpoint to be called successfully.

## Postman

Postman is an API platform. It supports calling gRPC services with an interactive UI, among its many features.

To download and install Postman, see the [Download Postman page](https://www.postman.com/downloads/).

### Use Postman

Postman has an interactive UI for calling gRPC services. To call a gRPC service using Postman:

1. Select the **New** button and choose **gRPC Request**.
2. Enter the gRPC server's hostname and port in the server URL. For example, `localhost:5000`. Don't include the `http` or `https` scheme in the URL. If the server uses [Transport Layer Security (TLS)](https://tools.ietf.org/html/rfc5246), select the padlock next to the server URL to enable TLS in Postman.
3. Navigate to the **Service definition** section, then select server reflection or import the app's proto file. When complete, the dropdown list next to the server URL textbox has a list of gRPC methods available.
4. To call a gRPC method, select it in the dropdown, select **Generate Example Message**, then select **Invoke** to send the gRPC call to the server.

![gRPC in Postman](~/grpc/test-tools/static/postman.png)

A short video is also available that [walks through using Postman with gRPC](https://youtu.be/gfYGqMb81GQ).

## gRPCurl

gRPCurl is a command-line tool created by the gRPC community. Its features include:

* Calling gRPC services, including streaming services.
* Service discovery using [gRPC reflection](https://github.com/grpc/grpc/blob/master/doc/server-reflection.md).
* Listing and describing gRPC services.
* Works with secure (TLS) and insecure (plain-text) servers.

For information about downloading and installing `grpcurl`, see the [gRPCurl GitHub homepage](https://github.com/fullstorydev/grpcurl#installation).

![gRPCurl command line](~/grpc/test-tools/static/grpcurl.png)

### Use `grpcurl`

The `-help` argument explains `grpcurl` command-line options:

```console
$ grpcurl -help
```

### Discover services

Use the `describe` verb to view the services defined by the server. Specify `<port>` as the localhost port number of the gRPC server. The port number is randomly assigned when the project is created and set in `Properties/launchSettings.json`:

```console
$ grpcurl localhost:<port> describe
greet.Greeter is a service:
service Greeter {
  rpc SayHello ( .greet.HelloRequest ) returns ( .greet.HelloReply );
  rpc SayHellos ( .greet.HelloRequest ) returns ( stream .greet.HelloReply );
}
grpc.reflection.v1alpha.ServerReflection is a service:
service ServerReflection {
  rpc ServerReflectionInfo ( stream .grpc.reflection.v1alpha.ServerReflectionRequest ) returns ( stream .grpc.reflection.v1alpha.ServerReflectionResponse );
}
```

The preceding example:

* Runs the `describe` verb on server `localhost:<port>`. Where `<port>` is randomly assigned when the gRPC server project is created and set in `Properties/launchSettings.json`
* Prints services and methods returned by gRPC reflection.
  * `Greeter` is a service implemented by the app.
  * `ServerReflection` is the service added by the `Grpc.AspNetCore.Server.Reflection` package.

Combine `describe` with a service, method, or message name to view its detail:

```powershell
$ grpcurl localhost:<port> describe greet.HelloRequest
greet.HelloRequest is a message:
message HelloRequest {
  string name = 1;
}
```

### Call gRPC services

Call a gRPC service by specifying a service and method name along with a JSON argument that represents the request message. The JSON is converted into Protobuf and sent to the service.

```console
$ grpcurl -d '{ \"name\": \"World\" }' localhost:<port> greet.Greeter/SayHello
{
  "message": "Hello World"
}
```

In the preceding example:

* The `-d` argument specifies a request message with JSON. This argument must come before the server address and method name.
* Calls the `SayHello` method on the `greeter.Greeter` service.
* Prints the response message as JSON.
* Where `<port>` is randomly assigned when the gRPC server project is created and set in `Properties/launchSettings.json`

The preceding example uses `\` to escape the `"` character. Escaping `"` is required in a PowerShell console but must not be used in some consoles. For example, the previous command for a macOS console:

```console
$ grpcurl -d '{ "name": "World" }' localhost:<port> greet.Greeter/SayHello
{
  "message": "Hello World"
}
```

## gRPCui

gRPCui is an interactive web UI for gRPC. gRPCui builds on top of gRPCurl. gRPCui offers a GUI for discovering and testing gRPC services, similar to HTTP tools such as Postman or Swagger UI.

For information about downloading and installing `grpcui`, see the [gRPCui GitHub homepage](https://github.com/fullstorydev/grpcui#installation).

### Using `grpcui`

Run `grpcui` with the server address to interact with as an argument:

```powershell
$ grpcui localhost:<port>
gRPC Web UI available at http://127.0.0.1:55038/
```

In the preceding example, specify `<port>` as the localhost port number of the gRPC server. The port number is randomly assigned when the project is created and set in `Properties/launchSettings.json`

The tool launches a browser window with the interactive web UI. gRPC services are automatically discovered using gRPC reflection.

![gRPCui web UI](~/grpc/test-tools/static/grpcui.png)

## Additional resources

* [Postman homepage](https://www.postman.com/)
* [gRPCurl GitHub homepage](https://github.com/fullstorydev/grpcurl)
* [gRPCui GitHub homepage](https://github.com/fullstorydev/grpcui)
* [`Grpc.AspNetCore.Server.Reflection`](https://www.nuget.org/packages/Grpc.AspNetCore.Server.Reflection)
* <xref:grpc/test-services>
* <xref:grpc/test-client>

:::moniker-end

:::moniker range=">= aspnetcore-3.0 < aspnetcore-6.0"
Tooling is available for gRPC that allows developers to test services without building client apps:

* [Postman](https://www.postman.com/) is an API platform with an interactive UI for calling APIs. Postman can run in the browser or be downloaded and run locally. Postman supports calling gRPC services.
* [gRPCurl](https://github.com/fullstorydev/grpcurl) is an open-source command-line tool that provides interaction with gRPC services.
* [gRPCui](https://github.com/fullstorydev/grpcui) builds on top of gRPCurl and adds an open-source interactive web UI for gRPC.

This article discusses how to:

* Set up gRPC server reflection with a gRPC ASP.NET Core app.
* Interact with gRPC using test tools:
  * Call gRPC services in Postman.
  * Discover and test gRPC services with `grpcurl`.
  * Interact with gRPC services via a browser using `grpcui`.

> [!NOTE]
> To learn how to unit test gRPC services, see <xref:grpc/test-services>.

## Set up gRPC reflection

Tooling must know the Protobuf contract of services before it can call them. There are two ways to do this:

* Set up [gRPC reflection](https://github.com/grpc/grpc/blob/master/doc/server-reflection.md) on the server. Tools, such as gRPCurl and Postman, use reflection to automatically discover service contracts.
* Add `.proto` files to the tool manually.

It's easier to use gRPC reflection. gRPC reflection adds a new gRPC service to the app that clients can call to discover services.

gRPC ASP.NET Core has built-in support for gRPC reflection with the [`Grpc.AspNetCore.Server.Reflection`](https://www.nuget.org/packages/Grpc.AspNetCore.Server.Reflection) package. To configure reflection in an app:

* Add a `Grpc.AspNetCore.Server.Reflection` package reference.
* Register reflection in `Startup.cs`:
  * `AddGrpcReflection` to register services that enable reflection.
  * `MapGrpcReflectionService` to add a reflection service endpoint.

[!code-csharp[](~/grpc/test-tools/samples/5.x/Startup.cs?name=snippet_1&highlight=4,15-18)]

When gRPC reflection is set up:

* A gRPC reflection service is added to the server app.
* Client apps that support gRPC reflection can call the reflection service to discover services hosted by the server.
* gRPC services are still called from the client. Reflection only enables service discovery and doesn't bypass server-side security. Endpoints protected by [authentication and authorization](xref:grpc/authn-and-authz) require the caller to pass credentials for the endpoint to be called successfully.

## Postman

Postman is an API platform. It supports calling gRPC services with an interactive UI, among its many features.

To download and install Postman, see the [Download Postman page](https://www.postman.com/downloads/).

### Use Postman

Postman has an interactive UI for calling gRPC services. To call a gRPC service using Postman:

1. Select the **New** button and choose **gRPC Request**.
2. Enter the gRPC server's hostname and port in the server URL. For example, `localhost:5000`. Don't include the `http` or `https` scheme in the URL. If the server uses [Transport Layer Security (TLS)](https://tools.ietf.org/html/rfc5246), select the padlock next to the server URL to enable TLS in Postman.
3. Navigate to the **Service definition** section, then select server reflection or import the app's proto file. When complete, the dropdown list next to the server URL textbox has a list of gRPC methods available.
4. To call a gRPC method, select it in the dropdown, select **Generate Example Message**, then select **Invoke** to send the gRPC call to the server.

![gRPC in Postman](~/grpc/test-tools/static/postman.png)

A short video is also available that [walks through using Postman with gRPC](https://youtu.be/gfYGqMb81GQ).

## gRPCurl

gRPCurl is a command-line tool created by the gRPC community. Its features include:

* Calling gRPC services, including streaming services.
* Service discovery using [gRPC reflection](https://github.com/grpc/grpc/blob/master/doc/server-reflection.md).
* Listing and describing gRPC services.
* Works with secure (TLS) and insecure (plain-text) servers.

For information about downloading and installing `grpcurl`, see the [gRPCurl GitHub homepage](https://github.com/fullstorydev/grpcurl#installation).

![gRPCurl command line](~/grpc/test-tools/static/grpcurl.png)

### Use `grpcurl`

The `-help` argument explains `grpcurl` command-line options:

```console
$ grpcurl -help
```

### Discover services

Use the `describe` verb to view the services defined by the server:

```console
$ grpcurl localhost:5001 describe
greet.Greeter is a service:
service Greeter {
  rpc SayHello ( .greet.HelloRequest ) returns ( .greet.HelloReply );
  rpc SayHellos ( .greet.HelloRequest ) returns ( stream .greet.HelloReply );
}
grpc.reflection.v1alpha.ServerReflection is a service:
service ServerReflection {
  rpc ServerReflectionInfo ( stream .grpc.reflection.v1alpha.ServerReflectionRequest ) returns ( stream .grpc.reflection.v1alpha.ServerReflectionResponse );
}
```

The preceding example:

* Runs the `describe` verb on server `localhost:5001`.
* Prints services and methods returned by gRPC reflection.
  * `Greeter` is a service implemented by the app.
  * `ServerReflection` is the service added by the `Grpc.AspNetCore.Server.Reflection` package.

Combine `describe` with a service, method, or message name to view its detail:

```powershell
$ grpcurl localhost:5001 describe greet.HelloRequest
greet.HelloRequest is a message:
message HelloRequest {
  string name = 1;
}
```

### Call gRPC services

Call a gRPC service by specifying a service and method name along with a JSON argument that represents the request message. The JSON is converted into Protobuf and sent to the service.

```console
$ grpcurl -d '{ \"name\": \"World\" }' localhost:5001 greet.Greeter/SayHello
{
  "message": "Hello World"
}
```

In the preceding example:

* The `-d` argument specifies a request message with JSON. This argument must come before the server address and method name.
* Calls the `SayHello` method on the `greeter.Greeter` service.
* Prints the response message as JSON.

The preceding example uses `\` to escape the `"` character. Escaping `"` is required in a PowerShell console but must not be used in some consoles. For example, the previous command for a macOS console:

```console
$ grpcurl -d '{ "name": "World" }' localhost:5001 greet.Greeter/SayHello
{
  "message": "Hello World"
}
```

## gRPCui

gRPCui is an interactive web UI for gRPC. gRPCui builds on top of gRPCurl. gRPCui offers a GUI for discovering and testing gRPC services, similar to HTTP tools such as Postman or Swagger UI.

For information about downloading and installing `grpcui`, see the [gRPCui GitHub homepage](https://github.com/fullstorydev/grpcui#installation).

### Using `grpcui`

Run `grpcui` with the server address to interact with as an argument:

```powershell
$ grpcui localhost:5001
gRPC Web UI available at http://127.0.0.1:55038/
```

The tool launches a browser window with the interactive web UI. gRPC services are automatically discovered using gRPC reflection.

![gRPCui web UI](~/grpc/test-tools/static/grpcui.png)

## Additional resources

* [Postman homepage](https://www.postman.com/)
* [gRPCurl GitHub homepage](https://github.com/fullstorydev/grpcurl)
* [gRPCui GitHub homepage](https://github.com/fullstorydev/grpcui)
* [`Grpc.AspNetCore.Server.Reflection`](https://www.nuget.org/packages/Grpc.AspNetCore.Server.Reflection)
* <xref:grpc/test-services>
* <xref:grpc/test-client>

:::moniker-end