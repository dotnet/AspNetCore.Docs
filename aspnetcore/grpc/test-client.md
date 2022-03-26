---
title: Mock gRPC client in tests
author: jamesnk
description: Learn how to mock gRPC client in .NET tests.
monikerRange: '>= aspnetcore-3.1'
ms.author: jamesnk
ms.custom: mvc
ms.date: 01/01/2022
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: grpc/test-client
---
# Mock gRPC client in tests

By: [James Newton-King](https://twitter.com/jamesnk)

Testing is an important aspect of building stable and maintainable software. Part of writing high-quality tests is removing external dependencies. This article discusses using mock gRPC clients in tests to remove gRPC calls to external servers.

## Example testable client app

To demonstrate client app tests, review the following type in the sample app. 

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/grpc/test-services/sample) ([how to download](xref:index#how-to-download-a-sample))

The `Worker` is a [BackgroundService](xref:Microsoft.Extensions.Hosting.BackgroundService) that makes calls to a gRPC server.

[!code-csharp[](test-services/sample/Client/Worker.cs?name=snippet_Worker)]

The preceding type:

* Follows the [Explicit Dependencies Principle](/dotnet/architecture/modern-web-apps-azure/architectural-principles#explicit-dependencies).
* Expects [dependency injection (DI)](xref:fundamentals/dependency-injection) to provide instances of `TesterClient` and `IGreetRepository`. The app is configured to use the [gRPC client factory](xref:grpc/clientfactory) to create `TesterClient`.
* Can be tested with a mocked `IGreetRepository` service and `TesterClient` client using a mock object framework, such as [Moq](https://www.nuget.org/packages/Moq). A *mocked object* is a fabricated object with a predetermined set of property and method behaviors used for testing. For more information, see <xref:test/integration-tests#introduction-to-integration-tests>.

## Mock a gRPC client

gRPC clients are concrete client types that are [generated from `.proto` files](xref:grpc/basics#generated-c-assets). The concrete gRPC client has methods that translate to the gRPC service in the `.proto` file. For example, a service called `Greeter` generates a `GreeterClient` type with methods to call the service.

A mocking framework can mock a gRPC client type. When a mocked client is passed to the type, the test uses the mocked method instead of sending a gRPC call to a server.

[!code-csharp[](test-services/sample/Tests/Client/WorkerTests.cs?name=snippet_Test)]

The preceding unit test:

* Mocks `IGreetRepository` and `TesterClient` using [Moq](https://www.nuget.org/packages/Moq).
* Starts the worker.
* Verifies `SaveGreeting` is called with the greeting message returned by the mocked `TesterClient`.

## Additional resources

* <xref:grpc/test-tools>
* <xref:grpc/test-services>
