---
title: Integration tests in ASP.NET Core
author: guardrex
description: Learn how integration tests ensure that an app's components function correctly at the infrastructure level, including the database, file system, and network.
manager: wpickett
monikerRange: '>= aspnetcore-2.1'
ms.author: riande
ms.custom: mvc
ms.date: 04/27/2018
ms.prod: asp.net-core
ms.technology: aspnet
ms.topic: article
uid: test/integration-tests2
---
# Integration tests in ASP.NET Core

<!--
    When updating the 'Introduction to integration tests' or 'Integration testing ASP.NET Core' sections, be sure to update the integration-tests.md file with the same changes.
-->

By [Luke Latham](https://github.com/guardrex)

[!INCLUDE[](~/includes/2.1.md)]

Integration tests ensure that an app's components function correctly at a level that includes the app's supporting infrastructure, such as the database, file system, and network. ASP.NET Core supports integration tests using a unit test framework with a test web host and in-memory test server.

This topic assumes a basic understanding of unit tests. If unfamiliar with test concepts, see the [Unit Testing in .NET Core and .NET Standard](/dotnet/core/testing/) topic and its linked content.

The process to set up a project for integration testing is virtually the same for Razor Pages and MVC projects. The only significant difference is in the naming of test classes:

* When testing a Razor Pages project, the test classes are usually named after the page model classes that they test.
* When testing an MVC project, the test classes are usually named after the controllers that they test.

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/test/integration-tests-2.1/samples) ([how to download](xref:tutorials/index#how-to-download-a-sample))

The sample app is a Razor Pages app and assumes a basic understanding of Razor Pages. If unfamiliar with Razor Pages apps, see the following topics:

* [Introduction to Razor Pages](xref:mvc/razor-pages/index)
* [Get started with Razor Pages](xref:tutorials/razor-pages/razor-pages-start)
* [Razor Pages unit tests](xref:test/razor-pages-tests)

## Introduction to integration tests

Integration tests evaluate an app's components on a broader level than [unit tests](/dotnet/core/testing/). Unit tests are used to test individual software components or the logic inside individual methods. Integration tests are used to test the app's infrastructure and whole framework, often including the following components:

* Database
* File system
* Network resources
* Request-response pipeline

Unit tests use fabricated components, known as *fakes* or *mock objects*, in place of infrastructure components. Integration tests use the actual components that the app uses in production. Integration tests confirm that the whole app works as expected.

Integration tests usually:

* Require more code and data processing than unit tests require.
* Take longer to run than unit tests.

Therefore, limit the use of integration tests to the most important infrastructure scenarios. If a behavior can be tested using either a unit test or an integration test, choose the unit test.

> [!TIP]
> Don't write integration tests for every possible permutation of data and file access with databases and file systems. Regardless of how many places across an app interact with databases and file systems, a focused set of read, write, update, and delete integration tests are usually capable of adequately testing database and file system components. Use unit tests for routine tests of method logic that interact with these components. In unit tests, the use of infrastructure fakes/mocks result in faster test execution.

> [!NOTE]
> In discussions of integration tests, the tested project is frequently called the *system under test*, or "SUT" for short.

## Integration tests in ASP.NET Core

Integration tests in ASP.NET Core require the following:

* A test project is used to contain and execute the tests. The test project has a reference to the tested ASP.NET Core project, called the *system under test* (SUT). _"SUT" is used throughout this topic to reference the tested app._
* The test project creates a test web host for the SUT and uses a test server client to handle requests and responses.
* A test runner is used to execute the tests and report the test results.

Integration tests follow a sequence of events:

1. The SUT's web host is configured, and a test server client is created to submit requests to the app.
1. The test app prepares a request, and the client submits the request.
1. The SUT responds, and the client provides the response to the test method logic.
1. The *actual* response is validated as a *pass* or *fail* based on an *expected* response.
1. The testing process continues until all of the tests are executed.
1. The test results are reported.

Usually, the test web host is configured differently than the app's normal web host for the test runs. For example, a different database or different app settings might be used for testing. Customizing the host is described in the [Customize the web host and create a client](#customize-the-web-host-and-create-a-client) section.

Infrastructure components, such as the test web host and in-memory test server ([TestServer](/dotnet/api/microsoft.aspnetcore.testhost.testserver)), are provided or managed by the [Microsoft.AspNetCore.Mvc.Testing](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Testing) package. Use of this package streamlines test creation and execution.

The `Microsoft.AspNetCore.Mvc.Testing` package handles the following tasks:

* Copies the dependencies file (*\*.deps*) from the SUT into the test project's *bin* folder.
* Sets the content root to the SUT's project root so that static files and views are found when tests are executed.
* Provides a class, `WebApplicationFactory<TStartup>`, to streamline bootstrapping the SUT with `TestServer`.

The [unit tests](/dotnet/articles/core/testing/unit-testing-with-dotnet-test) documentation describes how to set up a test project and test runner, along with detailed instructions on how to run tests and recommendations for how to name tests and test classes.

> [!NOTE]
> When creating a test project for an app, separate the unit tests from the integration tests into different projects. This helps ensure that infrastructure testing components aren't accidently included in the unit tests. Separation of unit and integration tests also allows control over which set of tests are run.

There's virtually no difference between the configuration for tests of Razor Pages apps and MVC apps. The only difference is in how the tests are named. In a Razor Pages app, tests of page endpoints are usually named after the page model class (for example, `IndexPageTests` to test component integration for the Index page). In an MVC app, tests are usually organized by controller classes and named after the controllers they test.

## Customize the web host and create a client

There are two approaches for customizing the web host of the SUT, and both approaches can be used independently or together in the same test app:

* [Per-test class configuration](#per-test-class-configuration) &ndash; Configures the SUT web host in each test class constructor.
* [Custom WebApplicationFactory implementations](#custom-webapplicationfactory-implementations) &ndash; Configures the SUT web host for each test class using a `WebApplicationFactory` implementation. Several implementations can be created and used across the app's test classes.

In the examples that follow, database seeding is performed by an `InitializeDbForTests` method. The sample app implements this method. The method is described further in the [Integration tests sample: Test app organization](#test-app-organization) section.

### Per-test class configuration

The test web host can be configured on a per-test class basis. A typical example configures the SUT's services, especially database access. The code example that follows is used in the sample app (*IndexPageTests.cs*) and performs the following steps:

* Create a new service provider. The service provider is used to override and add services to the test host.
* Add a database context (AppDbContext) using an in-memory database for testing. If required, other services can be added and configured here.
* Build the service provider.
* Create a service provider scope.
* Ensure the database is created and seed the database with test data.
* Create an `HttpClient` to submit requests against the test host.

[!code-csharp[](integration-tests-2.1/samples/2.x/IntegrationTestsSample/tests/RazorPagesProject.Tests/IntegrationTests/IndexPageTests.cs?name=snippet1)]

### Custom WebApplicationFactory implementations

Web host configuration can be created independently of the test classes by inheriting from `WebApplicationFactory` to create one or more custom factory implementations. These implementations can be used throughout the test classes. The code example that follows is used in the sample app (*IndexPageTests2.cs*) and performs the same configuration shown earlier in the [Per-test class configuration](#per-test-class-configuration) section:

1. Inherit from `WebApplicationFactory` and override `ConfigureWebHost`:

    [!code-csharp[](integration-tests-2.1/samples/2.x/IntegrationTestsSample/tests/RazorPagesProject.Tests/IntegrationTests/IndexPageTests2.cs?name=snippet1)]

1. Use the custom `WebApplicationFactory` in test classes:

    [!code-csharp[](integration-tests-2.1/samples/2.x/IntegrationTestsSample/tests/RazorPagesProject.Tests/IntegrationTests/IndexPageTests2.cs?name=snippet2)]

The preceding example shows the creation of a single custom `WebApplicationFactory` implementation (`CustomWebApplicationFactory`). Multiple factories can be created using this approach. Each test class fixture can specify any of the available `WebApplicationFactory` instances that are created.

## Client options

The the following table shows the default `WebApplicationFactoryClientOptions` available when creating `HttpClient` instances.

| Option | Description | Default |
| ------ | ----------- | ------- |
| `AllowAutoRedirect` | Gets or sets whether or not `HttpClient` instances should automatically follow redirect responses. | `true` |
| `BaseAddress` | Gets or sets the base address of `HttpClient` instances. | `http://localhost` |
| `HandleCookies` | Gets or sets whether `HttpClient` instances should handle cookies. | `true` |
| `MaxAutomaticRedirections` | Gets or sets the maximum number of redirect responses that `HttpClient` instances should follow. | 7 |

Create the `WebApplicationFactoryClientOptions` class and pass it to the `CreateClient` method (default values are shown in the code example):

```csharp
// Default client option values are shown
var clientOptions = new WebApplicationFactoryClientOptions();
clientOptions.AllowAutoRedirect = true;
clientOptions.BaseAddress = new Uri("http://localhost");
clientOptions.HandleCookies = true;
clientOptions.MaxAutomaticRedirections = 7;

_client = testWebAppFactory.CreateClient(clientOptions);
```

## How the test infrastructure infers the app content root path

The `WebApplicationFactory` constructor infers the app content root path by searching for a `WebApplicationFactoryContentRootAttribute` on the assembly containing the integration tests with a key equal to the `TEntryPoint` assembly `System.Reflection.Assembly.FullName`. In case an attribute with the correct key isn't found, `WebApplicationFactory` falls back to searching for a solution file (*\*.sln*) and appends the `TEntryPoint` assembly name to the solution directory. The app root directory (the content root path) is used to discover views and content files.

In most cases, it isn't necessary to explicitly set the app content root, as the search logic usually finds the correct content root at runtime. In special scenarios where the content root isn't found using the built-in search algorithm, the app content root can be specified explicitly or by using custom logic. To set the app content root in those scenarios, call the `UseSolutionRelativeContentRoot` extension method from the [Microsoft.AspNetCore.TestHost](https://www.nuget.org/packages/Microsoft.AspNetCore.TestHost) package. Supply the solution's relative path and optional solution file name or glob pattern (default = `*.sln`).

Call the `UseSolutionRelativeContentRoot` extension method using *ONE* of the following approaches:

* When configuring test classes on a [per-test class basis (shown earlier in this topic)](#per-test-class-configuration), provide a custom configuration with the [IWebHostBuilder](/dotnet/api/microsoft.aspnetcore.hosting.iwebhostbuilder) provided to the `WebApplicationFactory`:

    ```csharp
    using Microsoft.AspNetCore.TestHost;

    public IndexPageTests(
        WebApplicationFactory<RazorPagesProject.Startup> webAppFactory)
    {
        var testWebAppFactory = webAppFactory.WithWebHostBuilder(builder =>
        {
            builder.UseSolutionRelativeContentRoot("<SOLUTION-RELATIVE-PATH>");
            
            ...
        });
    }
    ```

* When configuring test classes with [WebApplicationFactory implementations (shown earlier in this topic)](#customize-the-web-host-and-create-a-client), inherit from `WebApplicationFactory` and override `ConfigureWebHost`:

    ```csharp
    using Microsoft.AspNetCore.TestHost;
    
    public class CustomWebApplicationFactory<TStartup> 
        : WebApplicationFactory<RazorPagesProject.Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                builder.UseSolutionRelativeContentRoot("<SOLUTION-RELATIVE-PATH>");

                ...
            });
        }
    }
    ```

## Disable shadow copying (xUnit only)

xUnit shadow copying causes the tests to execute in a different folder than the output folder. For tests to work properly, shadow copying must be disabled. The [sample app](https://github.com/aspnet/Docs/tree/master/aspnetcore/test/integration-tests-2.1/samples) uses xUnit and disables shadow copying. For more information, see [Configuring xUnit.net with JSON](https://xunit.github.io/docs/configuring-with-json.html).

In the project file, add an **\<ItemGroup>** to disable shadow copying:

```xml
<ItemGroup>
  <Content Include="xunit.runner.json" 
           CopyToOutputDirectory="Always" 
           CopyToPublishDirectory="PreserveNewest" />
</ItemGroup>
```

Add the *xunit.runner.json* file to root of the test project with the following content:

```json
{
  "shadowCopy": false
}
```

## Integration tests sample

The [sample app](https://github.com/aspnet/Docs/tree/master/aspnetcore/test/integration-tests-2.1/samples) is composed of two apps:

| App | Project folder | Description |
| --- | -------------- | ----------- |
| Message app (the SUT) | *src/RazorPagesProject* | Allows a user to add, delete one, delete all, and analyze messages. |
| Test app | *tests/RazorPagesProject.Tests* | Used to integration test the SUT. |

The tests can be run using the built-in test features of an IDE, such as [Visual Studio](https://www.visualstudio.com/vs/). If using [Visual Studio Code](https://code.visualstudio.com/) or the command line, execute the following command at a command prompt in the *tests/RazorPagesProject.Tests* folder:

```console
dotnet test
```

### Message app (SUT) organization

The SUT is a Razor Pages message system with the following characteristics:

* The Index page of the app (*Pages/Index.cshtml* and *Pages/Index.cshtml.cs*) provides a UI and page model methods to control the addition, deletion, and analysis of messages (average words per message).
* A message is described by the `Message` class (*Data/Message.cs*) with two properties: `Id` (key) and `Text` (message). The `Text` property is required and limited to 200 characters.
* Messages are stored using [Entity Framework's in-memory database](/ef/core/providers/in-memory/)&#8224;.
* The app contains a data access layer (DAL) in its database context class, `AppDbContext` (*Data/AppDbContext.cs*).
* If the database is empty on app startup, the message store is initialized with three messages.

&#8224;The EF topic, [Test with InMemory](/ef/core/miscellaneous/testing/in-memory), explains how to use an in-memory database for tests with MSTest. This topic uses the [xUnit](https://xunit.github.io/) test framework. Test concepts and test implementations across different test frameworks are similar but not identical.

Although the app doesn't use the [repository pattern](http://martinfowler.com/eaaCatalog/repository.html) and isn't an effective example of the [Unit of Work (UoW) pattern](https://martinfowler.com/eaaCatalog/unitOfWork.html), Razor Pages supports these patterns of development. For more information, see [Designing the infrastructure persistence layer](/dotnet/standard/microservices-architecture/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-design), [Implementing the Repository and Unit of Work Patterns in an ASP.NET MVC Application](/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application), and [Test controller logic](/aspnet/core/mvc/controllers/testing) (the sample implements the repository pattern).

### Test app organization

The test app is a console app inside the *tests/RazorPagesProject.Tests* folder.

| Test app folder | Description |
| --------------- | ----------- |
| *IntegrationTests* | *IndexPageTests.cs* contains the integration tests for the Index page using a [per-test class configuration](#per-test-class-configuration) approach. *IndexPageTests2.cs* contains the integration tests for the Index page using a [custom WebApplicationFactory implementations](#custom-webapplicationfactory-implementations) approach. |
| *Utilities* | *Utilities.cs* contains the:<ul><li>`InitializeDbForTests` method used to seed the database with test data for each test.</li><li>`GetRequestContentAsync` method used to prepare the `HttpClient` and content for requests that are sent to the SUT during integration tests.</li></ul> |

The test framework is [xUnit](https://xunit.github.io/). Integration tests are conducted using the [Microsoft.AspNetCore.TestHost](/dotnet/api/microsoft.aspnetcore.testhost), which includes the [TestServer](/dotnet/api/microsoft.aspnetcore.testhost.testserver). Because the [Microsoft.AspNetCore.Mvc.Testing](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Testing) package is used to configure the test host and test server, the `TestHost` and `TestServer` packages don't require direct package references in the test app's project file or developer configuration in the test app.

**Seeding the database for testing**

Integration tests usually require a small dataset in the database prior to the test execution. For example, a delete test calls for a database record deletion, so the database must have at least one record for the delete request to succeed.

The sample app seeds the database with three messages in *Utilities.cs* that tests can use when they execute:

[!code-csharp[](integration-tests-2.1/samples/2.x/IntegrationTestsSample/tests/RazorPagesProject.Tests/Utilities/Utilities.cs?name=snippet1)]

### Integration tests of the SUT

An integration test example from the sample app checks the result of requesting the Index page of the SUT (*tests/RazorPagesProject.Tests/IntegrationTests/IndexPageTests.cs*):

[!code-csharp[](integration-tests-2.1/sample_snapshot/IntegrationTestsSample/tests/RazorPagesProject.Tests/IntegrationTests/IndexPageTests.cs?name=snippet1)]

There's no Arrange step. The `GetAsync` method is called on the `HttpClient` to send a GET request to the endpoint. The test asserts that the result is a *200 OK* status code.

Any POST request to the SUT must satisfy the antiforgery check that's automatically made by the app's [data protection antiforgery system](xref:security/data-protection/introduction). In order to arrange for a test's POST request, the test app must:

1. Make a request for the page.
1. Parse the antiforgery cookie and request validation token from the response.
1. Make the POST request with the antiforgery cookie and request validation token in place.

The `Post_AddMessageHandler_ReturnsRedirectToRoot` test method:

* Prepares a message and the `HttpClient`.
* Makes a POST request to the app.
* Checks the response is a redirect back to the Index page.

`Post_AddMessageHandler_ReturnsRedirectToRoot ` method (*tests/RazorPagesProject.Tests/IntegrationTests/IndexPageTests.cs*):

[!code-csharp[](integration-tests-2.1/samples/2.x/IntegrationTestsSample/tests/RazorPagesProject.Tests/IntegrationTests/IndexPageTests.cs?name=snippet3)]

The `GetRequestContentAsync` utility method manages preparing the client with the antiforgery cookie and request verification token. Note how the method receives an `IDictionary` that permits the calling test method to pass in data for the request to encode along with the request verification token (*tests/RazorPagesProject.Tests/Utilities/Utilities.cs*):

[!code-csharp[](integration-tests-2.1/samples/2.x/IntegrationTestsSample/tests/RazorPagesProject.Tests/Utilities/Utilities.cs?name=snippet2&highlight=1-2,8-9,29)]

Integration tests can also pass bad data to the app to test the app's response behavior. The SUT limits message length to 200 characters (*src/RazorPagesProject/Data/Message.cs*):

[!code-csharp[](integration-tests-2.1/samples/2.x/IntegrationTestsSample/src/RazorPagesProject/Data/Message.cs?name=snippet1&highlight=7)]

The `Post_AddMessageHandler_ReturnsSuccess_WhenMessageTextTooLong` test `Message` explicitly passes in text with 201 "X" characters. This results in a `ModelState` error. The POST doesn't redirect back to the Index page. It returns a *200 OK* response with a `null` `Location` header (*tests/RazorPagesProject.Tests/IntegrationTests/IndexPageTests.cs*):

[!code-csharp[](integration-tests-2.1/samples/2.x/IntegrationTestsSample/tests/RazorPagesProject.Tests/IntegrationTests/IndexPageTests.cs?name=snippet4&highlight=7,16-17)]

## Additional resources

* [Unit tests](/dotnet/articles/core/testing/unit-testing-with-dotnet-test)
* [Razor Pages unit tests](xref:test/razor-pages-tests)
* [Middleware](xref:fundamentals/middleware/index)
* [Test controllers](xref:mvc/controllers/testing)
