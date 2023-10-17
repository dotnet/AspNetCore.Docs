---
title: Test gRPC services in ASP.NET Core
author: jamesnk
description: Learn how to test gRPC services in ASP.NET Core apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: jamesnk
ms.custom: mvc
ms.date: 01/01/2022
uid: grpc/test-services
---
# Test gRPC services in ASP.NET Core

By: [James Newton-King](https://twitter.com/jamesnk)

Testing is an important aspect of building stable and maintainable software. This article discusses how to test ASP.NET Core gRPC services.

There are three common approaches for testing gRPC services:

* **Unit testing**: Test gRPC services directly from a unit testing library.
* **Integration testing**: The gRPC app is hosted in <xref:Microsoft.AspNetCore.TestHost.TestServer>, an in-memory test server from the [`Microsoft.AspNetCore.TestHost`](https://www.nuget.org/packages/Microsoft.AspNetCore.TestHost) package. gRPC services are tested by calling them using a gRPC client from a unit testing library.
* **Manual testing**: Test gRPC servers with ad hoc calls. For information about how to use command-line and UI tooling with gRPC services, see <xref:grpc/test-tools>.

In unit testing, only the gRPC service is involved. Dependencies injected into the service must be mocked. In integration testing, the gRPC service and its auxiliary infrastructure are part of the test. This includes app startup, dependency injection, routing and authentication, and authorization.

## Example testable service

To demonstrate service tests, review the following service in the sample app. 

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/grpc/test-services/sample) ([how to download](xref:index#how-to-download-a-sample))

The `TesterService` returns greetings using gRPC's four method types.

[!code-csharp[](test-services/sample/Server/Services/TesterService.cs?name=snippet_TesterService)]

The preceding gRPC service:

* Follows the [Explicit Dependencies Principle](/dotnet/architecture/modern-web-apps-azure/architectural-principles#explicit-dependencies).
* Expects [dependency injection (DI)](xref:fundamentals/dependency-injection) to provide an instance of `IGreeter`.
* Can be tested with a mocked `IGreeter` service using a mock object framework, such as [Moq](https://www.nuget.org/packages/Moq). A *mocked object* is a fabricated object with a predetermined set of property and method behaviors used for testing. For more information, see <xref:test/integration-tests#introduction-to-integration-tests>.

## Unit test gRPC services

A unit test library can directly test gRPC services by calling its methods. Unit tests test a gRPC service in isolation.

[!code-csharp[](test-services/sample/Tests/Server/UnitTests/GreeterServiceTests.cs?name=snippet_SayHelloUnaryTest)]

The preceding unit test:

* Mocks `IGreeter` using [Moq](https://www.nuget.org/packages/Moq).
* Executes the `SayHelloUnary` method with a request message and a `ServerCallContext`. All service methods have a `ServerCallContext` argument. In this test, the type is provided using the `TestServerCallContext.Create()` helper method. This helper method is included in the sample code.
* Makes assertions:
  * Verifies the request name is passed to `IGreeter`.
  * The service returns the expected reply message.

### Unit test `HttpContext` in gRPC methods

gRPC methods can access a request's <xref:Microsoft.AspNetCore.Http.HttpContext> using the `ServerCallContext.GetHttpContext` extension method. To unit test a method that uses `HttpContext`, the context must be configured in test setup. If <xref:Microsoft.AspNetCore.Http.HttpContext> isn't configured then `GetHttpContext` returns `null`.

To configure a `HttpContext` during test setup, create a new instance and add it to `ServerCallContext.UserState` collection using the `__HttpContext` key.

```csharp
var httpContext = new DefaultHttpContext();

var serverCallContext = TestServerCallContext.Create();
serverCallContext.UserState["__HttpContext"] = httpContext;
```

Execute service methods with this call context to use the configured `HttpContext` instance.

## Integration test gRPC services

Integration tests evaluate an app's components on a broader level than unit tests. The gRPC app is hosted in <xref:Microsoft.AspNetCore.TestHost.TestServer>, an in-memory test server from the [`Microsoft.AspNetCore.TestHost`](https://www.nuget.org/packages/Microsoft.AspNetCore.TestHost) package.

A unit test library starts the gRPC app and then gRPC services are tested using the gRPC client.

The [sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/grpc/test-services/sample) contains infrastructure to make integration testing possible:

  * The `GrpcTestFixture<TStartup>` class configures the ASP.NET Core host and starts the gRPC app in an in-memory test server.
  * The `IntegrationTestBase` class is the base type that integration tests inherit from. It contains the fixture state and APIs for creating a gRPC client to call the gRPC app.

[!code-csharp[](test-services/sample/Tests/Server/IntegrationTests/GreeterServiceTests.cs?name=snippet_SayHelloUnaryTest)]

The preceding integration test:

* Creates a gRPC client using the channel provided by `IntegrationTestBase`. This type is included in the sample code.
* Calls the `SayHelloUnary` method using the gRPC client.
* Asserts the service returns the expected reply message.

### Inject mock dependencies

Use `ConfigureWebHost` on the fixture to override dependencies. Overriding dependencies is useful when an external dependency is unavailable in the test environment. For example, an app that uses an external payment gateway shouldn't call the external dependency when executing tests. Instead, use a mock gateway for the test.

[!code-csharp[](test-services/sample/Tests/Server/IntegrationTests/MockedGreeterServiceTests.cs?name=snippet_SayHelloUnaryTest)]

The preceding integration test:

* In the test class's (`MockedGreeterServiceTests`) constructor:
  * Mocks `IGreeter` using [Moq](https://www.nuget.org/packages/Moq).
  * Overrides the `IGreeter` registered with dependency injection using `ConfigureWebHost`. 
* Calls the `SayHelloUnary` method using the gRPC client.
* Asserts the expected reply message based on the mock `IGreeter` instance.

## Additional resources

* <xref:grpc/test-tools>
* <xref:grpc/test-client>
