---
title: Test gRPC services in ASP.NET Core
author: jamesnk
description: Learn how to test gRPC services in ASP.NET Core apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: jamesnk
ms.custom: mvc
ms.date: 01/01/2022
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: grpc/test-services
---
# Test gRPC services in ASP.NET Core

By: [James Newton-King](https://twitter.com/jamesnk)

Testing is an important aspect of building stable and maintainable software. This article discusses how to test ASP.NET Core gRPC services.

There are two common approaches for testing gRPC services:

* **Unit testing** - Test gRPC services directly from a unit testing library.
* **Integration testing** - The gRPC app is hosted in ([`TestServer`](/dotnet/api/microsoft.aspnetcore.testhost.testserver)) from the [`Microsoft.AspNetCore.TestHost`](https://www.nuget.org/packages/Microsoft.AspNetCore.TestHost/) package. gRPC services are tested by calling them using a gRPC client from a unit testing library.

In unit testing, only the gRPC service is involved. Dependencies injected into the service must be mocked. In integration testing, the gRPC service and all of its auxiliary infrastructure are part of the test. This includes app startup, dependency injection, routing and authentication and authorization.

## Example testable service

To demonstrate service tests, review the following service in the sample app. 

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/mvc/controllers/testing/samples/) ([how to download](xref:index#how-to-download-a-sample))

The `TesterService` returns greetings using gRPC's four method types.

[!code-csharp[](testing/samples/3.x/TestingControllersSample/src/TestingControllersSample/Controllers/HomeController.cs?name=snippet_HomeController&highlight=1,5,10,31-32)]

The preceding gRPC service:

* Follows the [Explicit Dependencies Principle](/dotnet/architecture/modern-web-apps-azure/architectural-principles#explicit-dependencies).
* Expects [dependency injection (DI)](xref:fundamentals/dependency-injection) to provide an instance of `IGreeter`.
* Can be tested with a mocked `IGreeter` service using a mock object framework, such as [Moq](https://www.nuget.org/packages/Moq/). A *mocked object* is a fabricated object with a predetermined set of property and method behaviors used for testing. For more information, see [Introduction to integration tests](xref:test/integration-tests#introduction-to-integration-tests).

## Unit testing gRPC services

gRPC services can be tested directly from a unit test library. Unit tests allow a gRPC service to be tested in isolation.

[!code-csharp[](testing/samples/3.x/TestingControllersSample/src/TestingControllersSample/Controllers/HomeController.cs?name=snippet_HomeController&highlight=1,5,10,31-32)]

The preceding unit test:

* Mocks `IGreeter` using [Moq](https://www.nuget.org/packages/Moq/).
* Executes the `SayHelloUnary` method. All gRPC service methods have a `ServerCallContext` argument. In this test that type is provided using the `TestServerCallContext.Create()` helper method. This helper method is included in the sample code.
* Makes assertions:
  * Verifies the request name is passed to `IGreeter`.
  * Expected reply message is returned by the service.

### Unit test HttpContext in gRPC methods

gRPC methods can access a request's `HttpContext` using the `ServerCallContext.GetHttpContext()` extension method. To unit test a method that uses `HttpContext`, the context must be configured in test setup. If `HttpContext` isn't configured then `GetHttpContext()` returns `null`.

To configure a `HttpContext` during test setup, create a new instance and add it to `ServerCallContext.UserState` collection using the `__HttpContext` key.

```csharp
var httpContext = new DefaultHttpContext();

var serverCallContext = TestServerCallContext.Create();
serviceCallContext.UserState["__HttpContext"] = httpContext;
```

## Integration testing gRPC services

Integration tests evaluate an app's components on a broader level than unit tests. The gRPC app is hosted in ([`TestServer`](/dotnet/api/microsoft.aspnetcore.testhost.testserver)), an in-memory test server from the [`Microsoft.AspNetCore.TestHost`](https://www.nuget.org/packages/Microsoft.AspNetCore.TestHost/) package.

In integration tests, the gRPC app is started by the unit test library, and then gRPC services are tested by calling them using the gRPC client.

The [sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/mvc/controllers/testing/samples/) contains infrastructure to make integration testing possible:
* The `GrpcTestFixture<TStartup>` class configures the ASP.NET Core host and starts the gRPC app in an in-memory test server.
* The `IntegrationTestBase` class is the base type that integration tests inherit from. It contains the fixture state, and APIs for creating a gRPC client to call the gRPC app.

[!code-csharp[](testing/samples/3.x/TestingControllersSample/src/TestingControllersSample/Controllers/HomeController.cs?name=snippet_HomeController&highlight=1,5,10,31-32)]

The preceding integration test:

* Creates a gRPC client using the channel provided by `IntegrationTestBase`.  This type is included in the sample code.
* Calls the `SayHelloUnary` method using the gRPC client.
* Asserts the expected reply message is returned by the service.

### Inject mock dependencies

Dependencies can be overridden in a test with a call to `ConfigureWebHost` on the fixture. This is useful when a dependency is not available in the test environment. For example, using this feature to override a dependency that calls an external web API to a mock instance.

[!code-csharp[](testing/samples/3.x/TestingControllersSample/src/TestingControllersSample/Controllers/HomeController.cs?name=snippet_HomeController&highlight=1,5,10,31-32)]

The preceding integration test:

* In the test class's constructor:
  * Mocks `IGreeter` using [Moq](https://www.nuget.org/packages/Moq/).
  * Overrides the `IGreeter` registered with dependency injection using `ConfigureWebHost`. 
* Calls the `SayHelloUnary` method using the gRPC client.
* Asserts the expected reply message based on the mock `IGreeter` instance.
