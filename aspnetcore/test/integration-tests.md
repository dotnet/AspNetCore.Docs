---
title: Integration tests in ASP.NET Core
author: rick-anderson
description: Learn how integration tests ensure that an app's components function correctly at the infrastructure level, including the database, file system, and network.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 08/05/2021
uid: test/integration-tests
---
# Integration tests in ASP.NET Core

By [Javier Calvarro Nelson](https://github.com/javiercn), [Steve Smith](https://ardalis.com/), and [Jos van der Til](https://jvandertil.nl)

Integration tests ensure that an app's components function correctly at a level that includes the app's supporting infrastructure, such as the database, file system, and network. ASP.NET Core supports integration tests using a unit test framework with a test web host and an in-memory test server.

This topic assumes a basic understanding of unit tests. If unfamiliar with test concepts, see the [Unit Testing in .NET Core and .NET Standard](/dotnet/core/testing/) topic and its linked content.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/test/integration-tests/samples) ([how to download](xref:index#how-to-download-a-sample))

The sample app is a Razor Pages app and assumes a basic understanding of Razor Pages. If unfamiliar with Razor Pages, see the following topics:

* [Introduction to Razor Pages](xref:razor-pages/index)
* [Get started with Razor Pages](xref:tutorials/razor-pages/razor-pages-start)
* [Razor Pages unit tests](xref:test/razor-pages-tests)

> [!NOTE]
> For testing SPAs, we recommended a tool such as [Playwright for .NET](https://playwright.dev/dotnet/), which can automate a browser.

## Introduction to integration tests

Integration tests evaluate an app's components on a broader level than [unit tests](/dotnet/core/testing/). Unit tests are used to test isolated software components, such as individual class methods. Integration tests confirm that two or more app components work together to produce an expected result, possibly including every component required to fully process a request.

These broader tests are used to test the app's infrastructure and whole framework, often including the following components:

* Database
* File system
* Network appliances
* Request-response pipeline

Unit tests use fabricated components, known as *fakes* or *mock objects*, in place of infrastructure components.

In contrast to unit tests, integration tests:

* Use the actual components that the app uses in production.
* Require more code and data processing.
* Take longer to run.

Therefore, limit the use of integration tests to the most important infrastructure scenarios. If a behavior can be tested using either a unit test or an integration test, choose the unit test.

In discussions of integration tests, the tested project is frequently called the *System Under Test*, or "SUT" for short. "SUT" is used throughout this topic to refer to the tested ASP.NET Core app.

> [!TIP]
> Don't write integration tests for every possible permutation of data and file access with databases and file systems. Regardless of how many places across an app interact with databases and file systems, a focused set of read, write, update, and delete integration tests are usually capable of adequately testing database and file system components. Use unit tests for routine tests of method logic that interact with these components. In unit tests, the use of infrastructure fakes/mocks result in faster test execution.

## ASP.NET Core integration tests

Integration tests in ASP.NET Core require the following:

* A test project is used to contain and execute the tests. The test project has a reference to the SUT.
* The test project creates a test web host for the SUT and uses a test server client to handle requests and responses with the SUT.
* A test runner is used to execute the tests and report the test results.

Integration tests follow a sequence of events that include the usual *Arrange*, *Act*, and *Assert* test steps:

1. The SUT's web host is configured.
1. A test server client is created to submit requests to the app.
1. The *Arrange* test step is executed: The test app prepares a request.
1. The *Act* test step is executed: The client submits the request and receives the response.
1. The *Assert* test step is executed: The *actual* response is validated as a *pass* or *fail* based on an *expected* response.
1. The process continues until all of the tests are executed.
1. The test results are reported.

Usually, the test web host is configured differently than the app's normal web host for the test runs. For example, a different database or different app settings might be used for the tests.

Infrastructure components, such as the test web host and in-memory test server (<xref:Microsoft.AspNetCore.TestHost.TestServer>), are provided or managed by the [Microsoft.AspNetCore.Mvc.Testing](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Testing) package. Use of this package streamlines test creation and execution.

The `Microsoft.AspNetCore.Mvc.Testing` package handles the following tasks:

* Copies the dependencies file (`.deps`) from the SUT into the test project's `bin` directory.
* Sets the [content root](xref:fundamentals/index#content-root) to the SUT's project root so that static files and pages/views are found when the tests are executed.
* Provides the [WebApplicationFactory](xref:Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactory%601) class to streamline bootstrapping the SUT with `TestServer`.

The [unit tests](/dotnet/articles/core/testing/unit-testing-with-dotnet-test) documentation describes how to set up a test project and test runner, along with detailed instructions on how to run tests and recommendations for how to name tests and test classes.

> [!NOTE]
> When creating a test project for an app, separate the unit tests from the integration tests into different projects. This helps ensure that infrastructure testing components aren't accidentally included in the unit tests. Separation of unit and integration tests also allows control over which set of tests are run.

There's virtually no difference between the configuration for tests of Razor Pages apps and MVC apps. The only difference is in how the tests are named. In a Razor Pages app, tests of page endpoints are usually named after the page model class (for example, `IndexPageTests` to test component integration for the Index page). In an MVC app, tests are usually organized by controller classes and named after the controllers they test (for example, `HomeControllerTests` to test component integration for the Home controller).

## Test app prerequisites

The test project must:

* Reference the [`Microsoft.AspNetCore.Mvc.Testing`](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Testing) package.
* Specify the Web SDK in the project file (`<Project Sdk="Microsoft.NET.Sdk.Web">`).

These prerequisites can be seen in the [sample app](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/test/integration-tests/samples/). Inspect the `tests/RazorPagesProject.Tests/RazorPagesProject.Tests.csproj` file. The sample app uses the [xUnit](https://xunit.net/) test framework and the [AngleSharp](https://anglesharp.github.io/) parser library, so the sample app also references:

* [`AngleSharp`](https://www.nuget.org/packages/AngleSharp)
* [`xunit`](https://www.nuget.org/packages/xunit)
* [`xunit.runner.visualstudio`](https://www.nuget.org/packages/xunit.runner.visualstudio)

In apps that use [`xunit.runner.visualstudio`](https://www.nuget.org/packages/xunit.runner.visualstudio) version 2.4.2 or later, the test project must reference the [`Microsoft.NET.Test.Sdk`](https://www.nuget.org/packages/Microsoft.NET.Test.Sdk) package.

Entity Framework Core is also used in the tests. The app references:

* [`Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore`](https://www.nuget.org/packages/Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore)
* [`Microsoft.AspNetCore.Identity.EntityFrameworkCore`](https://www.nuget.org/packages/Microsoft.AspNetCore.Identity.EntityFrameworkCore)
* [`Microsoft.EntityFrameworkCore`](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore)
* [`Microsoft.EntityFrameworkCore.InMemory`](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.InMemory)
* [`Microsoft.EntityFrameworkCore.Tools`](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools)

## SUT environment

If the SUT's [environment](xref:fundamentals/environments) isn't set, the environment defaults to Development.

## Basic tests with the default WebApplicationFactory

:::moniker range=">= aspnetcore-6.0"

ASP.NET Core 6 introduced <xref:Microsoft.AspNetCore.Builder.WebApplication> which removed the need for a `Startup` class. To test with `WebApplicationFactory` without a `Startup` class, an ASP.NET Core 6 app needs to expose the implicitly defined `Program` class to the test project by doing one of the following:

* Expose internal types from the web app to the test project. This can be done in the project file (`.csproj`):
  ```xml
  <ItemGroup>
       <InternalsVisibleTo Include="MyTestProject" />
  </ItemGroup>
  ```
* Make the `Program` class public using a partial class declaration:
  ```diff
  var builder = WebApplication.CreateBuilder(args);
  // ... Configure services, routes, etc.
  app.Run();
  + public partial class Program { }
  ```

After making the changes in the web application, the test project now can use the `Program` class for the `WebApplicationFactory`.

```csharp
[Fact]
public async Task HelloWorldTest()
{
    var application = new WebApplicationFactory<Program>()
        .WithWebHostBuilder(builder =>
        {
            // ... Configure test services
        });
        
    var client = application.CreateClient();
    //...
}
```

:::moniker-end

<xref:Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactory%601> is used to create a <xref:Microsoft.AspNetCore.TestHost.TestServer> for the integration tests. `TEntryPoint` is the entry point class of the SUT, usually the `Startup` class.

Test classes implement a *class fixture* interface ([`IClassFixture`](https://xunit.net/docs/shared-context#class-fixture)) to indicate the class contains tests and provide shared object instances across the tests in the class.

The following test class, `BasicTests`, uses the `WebApplicationFactory` to bootstrap the SUT and provide an <xref:System.Net.Http.HttpClient> to a test method, `Get_EndpointsReturnSuccessAndCorrectContentType`. The method checks if the response status code is successful (status codes in the range 200-299) and the `Content-Type` header is `text/html; charset=utf-8` for several app pages.

<xref:Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactory%601.CreateClient> creates an instance of `HttpClient` that automatically follows redirects and handles cookies.

[!code-csharp[](integration-tests/samples/3.x/IntegrationTestsSample/tests/RazorPagesProject.Tests/IntegrationTests/BasicTests.cs?name=snippet1)]

By default, non-essential cookies aren't preserved across requests when the [GDPR consent policy](xref:security/gdpr) is enabled. To preserve non-essential cookies, such as those used by the TempData provider, mark them as essential in your tests. For instructions on marking a cookie as essential, see [Essential cookies](xref:security/gdpr#essential-cookies).

## Customize WebApplicationFactory

Web host configuration can be created independently of the test classes by inheriting from `WebApplicationFactory` to create one or more custom factories:

1. Inherit from `WebApplicationFactory` and override <xref:Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactory%601.ConfigureWebHost%2A>. The <xref:Microsoft.AspNetCore.Hosting.IWebHostBuilder> allows the configuration of the service collection with <xref:Microsoft.AspNetCore.Hosting.IStartup.ConfigureServices%2A>:

   [!code-csharp[](integration-tests/samples/3.x/IntegrationTestsSample/tests/RazorPagesProject.Tests/CustomWebApplicationFactory.cs?name=snippet1)]

   Database seeding in the [sample app](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/test/integration-tests/samples) is performed by the `InitializeDbForTests` method. The method is described in the [Integration tests sample: Test app organization](#test-app-organization) section.

   The SUT's database context is registered in its `Startup.ConfigureServices` method. The test app's `builder.ConfigureServices` callback is executed *after* the app's `Startup.ConfigureServices` code is executed. The execution order is a breaking change for the [Generic Host](xref:fundamentals/host/generic-host) with the release of ASP.NET Core 3.0. To use a different database for the tests than the app's database, the app's database context must be replaced in `builder.ConfigureServices`.

   For SUTs that still use the [Web Host](xref:fundamentals/host/web-host), the test app's `builder.ConfigureServices` callback is executed *before* the SUT's `Startup.ConfigureServices` code. The test app's `builder.ConfigureTestServices` callback is executed *after*.

   The sample app finds the service descriptor for the database context and uses the descriptor to remove the service registration. Next, the factory adds a new `ApplicationDbContext` that uses an in-memory database for the tests.

   To connect to a different database than the in-memory database, change the `UseInMemoryDatabase` call to connect the context to a different database. To use a SQL Server test database:

   * Reference the [`Microsoft.EntityFrameworkCore.SqlServer`](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/) NuGet package in the project file.
   * Call `UseSqlServer` with a connection string to the database.

   ```csharp
   services.AddDbContext<ApplicationDbContext>((options, context) => 
   {
       context.UseSqlServer(
           Configuration.GetConnectionString("TestingDbConnectionString"));
   });
   ```

2. Use the custom `CustomWebApplicationFactory` in test classes. The following example uses the factory in the `IndexPageTests` class:

   [!code-csharp[](integration-tests/samples/3.x/IntegrationTestsSample/tests/RazorPagesProject.Tests/IntegrationTests/IndexPageTests.cs?name=snippet1)]

   The sample app's client is configured to prevent the `HttpClient` from following redirects. As explained later in the [Mock authentication](#mock-authentication) section, this permits tests to check the result of the app's first response. The first response is a redirect in many of these tests with a `Location` header.

3. A typical test uses the `HttpClient` and helper methods to process the request and the response:

   [!code-csharp[](integration-tests/samples/3.x/IntegrationTestsSample/tests/RazorPagesProject.Tests/IntegrationTests/IndexPageTests.cs?name=snippet2)]

Any POST request to the SUT must satisfy the antiforgery check that's automatically made by the app's [data protection antiforgery system](xref:security/data-protection/introduction). In order to arrange for a test's POST request, the test app must:

1. Make a request for the page.
1. Parse the antiforgery cookie and request validation token from the response.
1. Make the POST request with the antiforgery cookie and request validation token in place.

The `SendAsync` helper extension methods (`Helpers/HttpClientExtensions.cs`) and the `GetDocumentAsync` helper method (`Helpers/HtmlHelpers.cs`) in the [sample app](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/test/integration-tests/samples/) use the [AngleSharp](https://anglesharp.github.io/) parser to handle the antiforgery check with the following methods:

* `GetDocumentAsync`: Receives the <xref:System.Net.Http.HttpResponseMessage> and returns an `IHtmlDocument`. `GetDocumentAsync` uses a factory that prepares a *virtual response* based on the original `HttpResponseMessage`. For more information, see the [AngleSharp documentation](https://github.com/AngleSharp/AngleSharp#documentation).
* `SendAsync` extension methods for the `HttpClient` compose an <xref:System.Net.Http.HttpRequestMessage> and call <xref:System.Net.Http.HttpClient.SendAsync(System.Net.Http.HttpRequestMessage)> to submit requests to the SUT. Overloads for `SendAsync` accept the HTML form (`IHtmlFormElement`) and the following:
  * Submit button of the form (`IHtmlElement`)
  * Form values collection (`IEnumerable<KeyValuePair<string, string>>`)
  * Submit button (`IHtmlElement`) and form values (`IEnumerable<KeyValuePair<string, string>>`)

> [!NOTE]
> [AngleSharp](https://anglesharp.github.io/) is a third-party parsing library used for demonstration purposes in this topic and the sample app. AngleSharp isn't supported or required for integration testing of ASP.NET Core apps. Other parsers can be used, such as the [Html Agility Pack (HAP)](https://html-agility-pack.net/). Another approach is to write code to handle the antiforgery system's request verification token and antiforgery cookie directly.

> [!NOTE]
> The [EF-Core in-memory database provider](/ef/core/testing/choosing-a-testing-strategy#in-memory-as-a-database-fake) can be used for limited and basic testing, however the [SQLite provider](/ef/core/testing/choosing-a-testing-strategy#sqlite-as-a-database-fake) is the recommend choice for in-memory testing.

## Customize the client with WithWebHostBuilder

When additional configuration is required within a test method, <xref:Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactory%601.WithWebHostBuilder%2A> creates a new `WebApplicationFactory` with an <xref:Microsoft.AspNetCore.Hosting.IWebHostBuilder> that is further customized by configuration.

The `Post_DeleteMessageHandler_ReturnsRedirectToRoot` test method of the [sample app](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/test/integration-tests/samples) demonstrates the use of `WithWebHostBuilder`. This test performs a record delete in the database by triggering a form submission in the SUT.

Because another test in the `IndexPageTests` class performs an operation that deletes all of the records in the database and may run before the `Post_DeleteMessageHandler_ReturnsRedirectToRoot` method, the database is reseeded in this test method to ensure that a record is present for the SUT to delete. Selecting the first delete button of the `messages` form in the SUT is simulated in the request to the SUT:

[!code-csharp[](integration-tests/samples/3.x/IntegrationTestsSample/tests/RazorPagesProject.Tests/IntegrationTests/IndexPageTests.cs?name=snippet3)]

## Client options

The following table shows the default <xref:Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactoryClientOptions> available when creating `HttpClient` instances.

| Option | Description | Default |
|--|--|--|
| <xref:Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactoryClientOptions.AllowAutoRedirect> | Gets or sets whether or not `HttpClient` instances should automatically follow redirect responses. | `true` |
| <xref:Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactoryClientOptions.BaseAddress> | Gets or sets the base address of `HttpClient` instances. | `http://localhost` |
| <xref:Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactoryClientOptions.HandleCookies> | Gets or sets whether `HttpClient` instances should handle cookies. | `true` |
| <xref:Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactoryClientOptions.MaxAutomaticRedirections> | Gets or sets the maximum number of redirect responses that `HttpClient` instances should follow. | 7 |

Create the `WebApplicationFactoryClientOptions` class and pass it to the <xref:Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactory%601.CreateClient> method (default values are shown in the code example):

```csharp
// Default client option values are shown
var clientOptions = new WebApplicationFactoryClientOptions();
clientOptions.AllowAutoRedirect = true;
clientOptions.BaseAddress = new Uri("http://localhost");
clientOptions.HandleCookies = true;
clientOptions.MaxAutomaticRedirections = 7;

_client = _factory.CreateClient(clientOptions);
```

## Inject mock services

Services can be overridden in a test with a call to <xref:Microsoft.AspNetCore.TestHost.WebHostBuilderExtensions.ConfigureTestServices%2A> on the host builder. **To inject mock services, the SUT must have a `Startup` class with a `Startup.ConfigureServices` method.**

The sample SUT includes a scoped service that returns a quote. The quote is embedded in a hidden field on the Index page when the Index page is requested.

`Services/IQuoteService.cs`:

[!code-csharp[](integration-tests/samples/3.x/IntegrationTestsSample/src/RazorPagesProject/Services/IQuoteService.cs?name=snippet1)]

`Services/QuoteService.cs`:

[!code-csharp[](integration-tests/samples/3.x/IntegrationTestsSample/src/RazorPagesProject/Services/QuoteService.cs?name=snippet1)]

`Startup.cs`:

[!code-csharp[](integration-tests/samples/3.x/IntegrationTestsSample/src/RazorPagesProject/Startup.cs?name=snippet2)]

`Pages/Index.cshtml.cs`:

[!code-csharp[](integration-tests/samples/3.x/IntegrationTestsSample/src/RazorPagesProject/Pages/Index.cshtml.cs?name=snippet1&highlight=4,9,20,26)]

`Pages/Index.cs`:

[!code-cshtml[](integration-tests/samples/3.x/IntegrationTestsSample/src/RazorPagesProject/Pages/Index.cshtml?name=snippet_Quote)]

The following markup is generated when the SUT app is run:

```html
<input id="quote" type="hidden" value="Come on, Sarah. We&#x27;ve an appointment in 
    London, and we&#x27;re already 30,000 years late.">
```

To test the service and quote injection in an integration test, a mock service is injected into the SUT by the test. The mock service replaces the app's `QuoteService` with a service provided by the test app, called `TestQuoteService`:

`IntegrationTests.IndexPageTests.cs`:

[!code-csharp[](integration-tests/samples/3.x/IntegrationTestsSample/tests/RazorPagesProject.Tests/IntegrationTests/IndexPageTests.cs?name=snippet4)]

`ConfigureTestServices` is called, and the scoped service is registered:

[!code-csharp[](integration-tests/samples/3.x/IntegrationTestsSample/tests/RazorPagesProject.Tests/IntegrationTests/IndexPageTests.cs?name=snippet5&highlight=7-10,17,20-21)]

The markup produced during the test's execution reflects the quote text supplied by `TestQuoteService`, thus the assertion passes:

```html
<input id="quote" type="hidden" value="Something&#x27;s interfering with time, 
    Mr. Scarman, and time is my business.">
```

## Mock authentication

Tests in the `AuthTests` class check that a secure endpoint:

* Redirects an unauthenticated user to the app's Login page.
* Returns content for an authenticated user.

In the SUT, the `/SecurePage` page uses an <xref:Microsoft.Extensions.DependencyInjection.PageConventionCollectionExtensions.AuthorizePage%2A> convention to apply an <xref:Microsoft.AspNetCore.Mvc.Authorization.AuthorizeFilter> to the page. For more information, see [Razor Pages authorization conventions](xref:security/authorization/razor-pages-authorization#require-authorization-to-access-a-page).

[!code-csharp[](integration-tests/samples/3.x/IntegrationTestsSample/src/RazorPagesProject/Startup.cs?name=snippet1)]

In the `Get_SecurePageRedirectsAnUnauthenticatedUser` test, a <xref:Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactoryClientOptions> is set to disallow redirects by setting <xref:Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactoryClientOptions.AllowAutoRedirect> to `false`:

[!code-csharp[](integration-tests/samples/3.x/IntegrationTestsSample/tests/RazorPagesProject.Tests/IntegrationTests/AuthTests.cs?name=snippet2)]

By disallowing the client to follow the redirect, the following checks can be made:

* The status code returned by the SUT can be checked against the expected <xref:System.Net.HttpStatusCode.Redirect?displayProperty=nameWithType> result, not the final status code after the redirect to the Login page, which would be <xref:System.Net.HttpStatusCode.OK?displayProperty=nameWithType>.
* The `Location` header value in the response headers is checked to confirm that it starts with `http://localhost/Identity/Account/Login`, not the final Login page response, where the `Location` header wouldn't be present.

The test app can mock an <xref:Microsoft.AspNetCore.Authentication.AuthenticationHandler%601> in <xref:Microsoft.AspNetCore.TestHost.WebHostBuilderExtensions.ConfigureTestServices%2A> in order to test aspects of authentication and authorization. A minimal scenario returns an <xref:Microsoft.AspNetCore.Authentication.AuthenticateResult.Success%2A?displayProperty=nameWithType>:

[!code-csharp[](integration-tests/samples/3.x/IntegrationTestsSample/tests/RazorPagesProject.Tests/IntegrationTests/AuthTests.cs?name=snippet4&highlight=11-18)]

The `TestAuthHandler` is called to authenticate a user when the authentication scheme is set to `Test` where `AddAuthentication` is registered for `ConfigureTestServices`. It's important for the `Test` scheme to match the scheme your app expects. Otherwise, authentication won't work.

[!code-csharp[](integration-tests/samples/3.x/IntegrationTestsSample/tests/RazorPagesProject.Tests/IntegrationTests/AuthTests.cs?name=snippet3&highlight=7-12)]

For more information on `WebApplicationFactoryClientOptions`, see the [Client options](#client-options) section.

## Set the environment

By default, the SUT's host and app environment is configured to use the Development environment. To override the SUT's environment when using `IHostBuilder`:

* Set the `ASPNETCORE_ENVIRONMENT` environment variable (for example, `Staging`, `Production`, or other custom value, such as `Testing`).
* Override `CreateHostBuilder` in the test app to read environment variables prefixed with `ASPNETCORE`.

```csharp
protected override IHostBuilder CreateHostBuilder() =>
    base.CreateHostBuilder()
        .ConfigureHostConfiguration(
            config => config.AddEnvironmentVariables("ASPNETCORE"));
```

If the SUT uses the Web Host (`IWebHostBuilder`), override `CreateWebHostBuilder`:

```csharp
protected override IWebHostBuilder CreateWebHostBuilder() =>
    base.CreateWebHostBuilder().UseEnvironment("Testing");
```

## How the test infrastructure infers the app content root path

The `WebApplicationFactory` constructor infers the app [content root](xref:fundamentals/index#content-root) path by searching for a <xref:Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactoryContentRootAttribute> on the assembly containing the integration tests with a key equal to the `TEntryPoint` assembly `System.Reflection.Assembly.FullName`. In case an attribute with the correct key isn't found, `WebApplicationFactory` falls back to searching for a solution file (*.sln*) and appends the `TEntryPoint` assembly name to the solution directory. The app root directory (the content root path) is used to discover views and content files.

## Disable shadow copying

Shadow copying causes the tests to execute in a different directory than the output directory. If your tests rely on loading files relative to `Assembly.Location` and you encounter issues, you might have to disable shadow copying.

To disable shadow copying when using xUnit, create a `xunit.runner.json` file in your test project directory, with the [correct configuration setting](https://xunit.net/docs/configuration-files#shadowCopy):

```json
{
  "shadowCopy": false
}
```

## Disposal of objects

After the tests of the `IClassFixture` implementation are executed, <xref:Microsoft.AspNetCore.TestHost.TestServer> and <xref:System.Net.Http.HttpClient> are disposed when xUnit disposes of the [`WebApplicationFactory`](xref:Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactory%601). If objects instantiated by the developer require disposal, dispose of them in the `IClassFixture` implementation. For more information, see [Implementing a Dispose method](/dotnet/standard/garbage-collection/implementing-dispose).

## Integration tests sample

The [sample app](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/test/integration-tests/samples) is composed of two apps:

| App | Project directory | Description |
|--|--|--|
| Message app (the SUT) | `src/RazorPagesProject` | Allows a user to add, delete one, delete all, and analyze messages. |
| Test app | `tests/RazorPagesProject.Tests` | Used to integration test the SUT. |

The tests can be run using the built-in test features of an IDE, such as [Visual Studio](https://visualstudio.microsoft.com). If using [Visual Studio Code](https://code.visualstudio.com/) or the command line, execute the following command at a command prompt in the `tests/RazorPagesProject.Tests` directory:

```console
dotnet test
```

### Message app (SUT) organization

The SUT is a Razor Pages message system with the following characteristics:

* The Index page of the app (`Pages/Index.cshtml` and `Pages/Index.cshtml.cs`) provides a UI and page model methods to control the addition, deletion, and analysis of messages (average words per message).
* A message is described by the `Message` class (`Data/Message.cs`) with two properties: `Id` (key) and `Text` (message). The `Text` property is required and limited to 200 characters.
* Messages are stored using [Entity Framework's in-memory database](/ef/core/providers/in-memory/)&#8224;.
* The app contains a data access layer (DAL) in its database context class, `AppDbContext` (`Data/AppDbContext.cs`).
* If the database is empty on app startup, the message store is initialized with three messages.
* The app includes a `/SecurePage` that can only be accessed by an authenticated user.

&#8224;The EF topic, [Test with InMemory](/ef/core/miscellaneous/testing/in-memory), explains how to use an in-memory database for tests with MSTest. This topic uses the [xUnit](https://xunit.net/) test framework. Test concepts and test implementations across different test frameworks are similar but not identical.

Although the app doesn't use the repository pattern and isn't an effective example of the [Unit of Work (UoW) pattern](https://martinfowler.com/eaaCatalog/unitOfWork.html), Razor Pages supports these patterns of development. For more information, see [Designing the infrastructure persistence layer](/dotnet/standard/microservices-architecture/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-design) and [Test controller logic](../mvc/controllers/testing.md) (the sample implements the repository pattern).

### Test app organization

The test app is a console app inside the `tests/RazorPagesProject.Tests` directory.

| Test app directory | Description |
|--|--|
| `AuthTests` | Contains test methods for:<ul><li>Accessing a secure page by an unauthenticated user.</li><li>Accessing a secure page by an authenticated user with a mock <xref:Microsoft.AspNetCore.Authentication.AuthenticationHandler%601>.</li><li>Obtaining a GitHub user profile and checking the profile's user login.</li></ul> |
| `BasicTests` | Contains a test method for routing and content type. |
| `IntegrationTests` | Contains the integration tests for the Index page using custom `WebApplicationFactory` class. |
| `Helpers/Utilities` | <ul><li>`Utilities.cs` contains the `InitializeDbForTests` method used to seed the database with test data.</li><li>`HtmlHelpers.cs` provides a method to return an AngleSharp `IHtmlDocument` for use by the test methods.</li><li>`HttpClientExtensions.cs` provide overloads for `SendAsync` to submit requests to the SUT.</li></ul> |

The test framework is [xUnit](https://xunit.net/). Integration tests are conducted using the <xref:Microsoft.AspNetCore.TestHost?displayProperty=fullNames>, which includes the <xref:Microsoft.AspNetCore.TestHost.TestServer>. Because the [`Microsoft.AspNetCore.Mvc.Testing`](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Testing) package is used to configure the test host and test server, the `TestHost` and `TestServer` packages don't require direct package references in the test app's project file or developer configuration in the test app.

Integration tests usually require a small dataset in the database prior to the test execution. For example, a delete test calls for a database record deletion, so the database must have at least one record for the delete request to succeed.

The sample app seeds the database with three messages in `Utilities.cs` that tests can use when they execute:

[!code-csharp[](integration-tests/samples/3.x/IntegrationTestsSample/tests/RazorPagesProject.Tests/Helpers/Utilities.cs?name=snippet1)]

The SUT's database context is registered in its `Startup.ConfigureServices` method. The test app's `builder.ConfigureServices` callback is executed *after* the app's `Startup.ConfigureServices` code is executed. To use a different database for the tests, the app's database context must be replaced in `builder.ConfigureServices`. For more information, see the [Customize WebApplicationFactory](#customize-webapplicationfactory) section.

For SUTs that still use the [Web Host](xref:fundamentals/host/web-host), the test app's `builder.ConfigureServices` callback is executed *before* the SUT's `Startup.ConfigureServices` code. The test app's `builder.ConfigureTestServices` callback is executed *after*.

## Additional resources

* [Unit tests](/dotnet/articles/core/testing/unit-testing-with-dotnet-test)
* <xref:test/razor-pages-tests>
* <xref:fundamentals/middleware/index>
* <xref:mvc/controllers/testing>
