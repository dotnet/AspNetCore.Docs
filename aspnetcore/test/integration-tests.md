---
title: Integration tests in ASP.NET Core
author: guardrex
description: Learn how integration tests ensure that an app's components function correctly at the infrastructure level, including the database, file system, and network.
manager: wpickett
ms.author: riande
ms.custom: mvc
ms.date: 05/24/2018
ms.prod: asp.net-core
ms.technology: aspnet
ms.topic: article
uid: test/integration-tests
---
# Integration tests in ASP.NET Core

::: moniker range=">= aspnetcore-2.1"

By [Luke Latham](https://github.com/guardrex)

Integration tests ensure that an app's components function correctly at a level that includes the app's supporting infrastructure, such as the database, file system, and network. ASP.NET Core supports integration tests using a unit test framework with a test web host and in-memory test server.

This topic assumes a basic understanding of unit tests. If unfamiliar with test concepts, see the [Unit Testing in .NET Core and .NET Standard](/dotnet/core/testing/) topic and its linked content.

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/test/integration-tests-2.1/samples) ([how to download](xref:tutorials/index#how-to-download-a-sample))

The sample app is a Razor Pages app and assumes a basic understanding of Razor Pages. If unfamiliar with Razor Pages, see the following topics:

* [Introduction to Razor Pages](xref:mvc/razor-pages/index)
* [Get started with Razor Pages](xref:tutorials/razor-pages/razor-pages-start)
* [Razor Pages unit tests](xref:test/razor-pages-tests)

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

> [!TIP]
> Don't write integration tests for every possible permutation of data and file access with databases and file systems. Regardless of how many places across an app interact with databases and file systems, a focused set of read, write, update, and delete integration tests are usually capable of adequately testing database and file system components. Use unit tests for routine tests of method logic that interact with these components. In unit tests, the use of infrastructure fakes/mocks result in faster test execution.

> [!NOTE]
> In discussions of integration tests, the tested project is frequently called the *system under test*, or "SUT" for short.

## ASP.NET Core integration tests

Integration tests in ASP.NET Core require the following:

* A test project is used to contain and execute the tests. The test project has a reference to the tested ASP.NET Core project, called the *system under test* (SUT). _"SUT" is used throughout this topic to refer to the tested app._
* The test project creates a test web host for the SUT and uses a test server client to handle requests and responses to the SUT.
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

Infrastructure components, such as the test web host and in-memory test server ([TestServer](/dotnet/api/microsoft.aspnetcore.testhost.testserver)), are provided or managed by the [Microsoft.AspNetCore.Mvc.Testing](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Testing) package. Use of this package streamlines test creation and execution.

The `Microsoft.AspNetCore.Mvc.Testing` package handles the following tasks:

* Copies the dependencies file (*\*.deps*) from the SUT into the test project's *bin* folder.
* Sets the content root to the SUT's project root so that static files and pages/views are found when tests are executed.
* Provides the [WebApplicationFactory](/dotnet/api/microsoft.aspnetcore.mvc.testing.webapplicationfactory-1) class to streamline bootstrapping the SUT with `TestServer`.

The [unit tests](/dotnet/articles/core/testing/unit-testing-with-dotnet-test) documentation describes how to set up a test project and test runner, along with detailed instructions on how to run tests and recommendations for how to name tests and test classes.

> [!NOTE]
> When creating a test project for an app, separate the unit tests from the integration tests into different projects. This helps ensure that infrastructure testing components aren't accidently included in the unit tests. Separation of unit and integration tests also allows control over which set of tests are run.

There's virtually no difference between the configuration for tests of Razor Pages apps and MVC apps. The only difference is in how the tests are named. In a Razor Pages app, tests of page endpoints are usually named after the page model class (for example, `IndexPageTests` to test component integration for the Index page). In an MVC app, tests are usually organized by controller classes and named after the controllers they test (for example, `HomeControllerTests` to test component integration for the Home controller).

## Test app prerequisites

The test project must:

* Have a package reference for [Microsoft.AspNetCore.App](https://www.nuget.org/packages/Microsoft.AspNetCore.App/).
* Use the Web SDK in the project file (`<Project Sdk="Microsoft.NET.Sdk.Web">`).

These prerequesities can be seen in the [sample app](https://github.com/aspnet/Docs/tree/master/aspnetcore/test/integration-tests-2.1/samples/). Inspect the *tests/RazorPagesProject.Tests/RazorPagesProject.Tests.csproj* file.

## Basic tests with the default WebApplicationFactory

[WebApplicationFactory&lt;TEntryPoint&gt;](/dotnet/api/microsoft.aspnetcore.mvc.testing.webapplicationfactory-1) is used to create a [TestServer](/dotnet/api/microsoft.aspnetcore.testhost.testserver) for the integration tests. `TEntryPoint` is the entry point class of the SUT, usually the `Startup` class.

Test classes implement a *class fixture* interface (`IClassFixture`) to indicate the class contains tests and provide shared object instances across the tests in the class.

### Basic test of app endpoints

The following test class, `BasicTests`, uses the `WebApplicationFactory` to bootstrap the SUT and provide an [HttpClient](/dotnet/api/system.net.http.httpclient) to a test method, `Request_EndpointsReturnOKAndCorrectContentType`. The method checks if the response status code is successful (status codes in the range 200-299) and the `Content-Type` header is `text/html; charset=utf-8` for several app pages.

[CreateClient](/dotnet/api/microsoft.aspnetcore.mvc.testing.webapplicationfactory-1.createclient) creates an instance of `HttpClient` that automatically follows redirects and handles cookies.

[!code-csharp[](integration-tests-2.1/samples/2.x/IntegrationTestsSample/tests/RazorPagesProject.Tests/IntegrationTests/BasicTests.cs?name=snippet1)]

### Test a secure endpoint

Another test in the `BasicTests` class checks that a secure endpoint redirects an unauthenticated user to the app's Login page.

In the SUT, the `/SecurePage` page uses an [AuthorizePage](/dotnet/api/microsoft.extensions.dependencyinjection.pageconventioncollectionextensions.authorizepage) convention to apply an [AuthorizeFilter](/dotnet/api/microsoft.aspnetcore.mvc.authorization.authorizefilter) to the page. For more information, see [Razor Pages authorization conventions](xref:security/authorization/razor-pages-authorization#require-authorization-to-access-a-page).

[!code-csharp[](integration-tests-2.1/samples/2.x/IntegrationTestsSample/src/RazorPagesProject/Startup.cs?name=snippet1)]

In the `SecurePageRequiresAnAuthenticatedUser` test, a [WebApplicationFactoryClientOptions](/dotnet/api/microsoft.aspnetcore.mvc.testing.webapplicationfactoryclientoptions) is set to disallow redirects by setting [AllowAutoRedirect](/dotnet/api/microsoft.aspnetcore.mvc.testing.webapplicationfactoryclientoptions.allowautoredirect) to `false`:

[!code-csharp[](integration-tests-2.1/samples/2.x/IntegrationTestsSample/tests/RazorPagesProject.Tests/IntegrationTests/BasicTests.cs?name=snippet2)]

By disallowing the client to follow the redirect, the following checks can be made:

* The status code returned by the SUT can be checked against the expected [HttpStatusCode.Redirect](/dotnet/api/system.net.httpstatuscode) result, not the final status code after the redirect to the Login page, which would be [HttpStatusCode.OK](/dotnet/api/system.net.httpstatuscode).
* The `Location` header value in the response headers is checked to confirm that it starts with `http://localhost/Identity/Account/Login`, not the final Login page response, where the `Location` header wouldn't be present.

For more information on `WebApplicationFactoryClientOptions`, see the [Client options](#client-options) section.

## Customize WebApplicationFactory

Web host configuration can be created independently of the test classes by inheriting from `WebApplicationFactory` to create one or more custom factories:

1. Inherit from `WebApplicationFactory` and override [ConfigureWebHost](/dotnet/api/microsoft.aspnetcore.mvc.testing.webapplicationfactory-1.configurewebhost). The [IWebHostBuilder](/dotnet/api/microsoft.aspnetcore.hosting.iwebhostbuilder) allows the configuration of the service collection with [ConfigureServices](/dotnet/api/microsoft.aspnetcore.hosting.istartup.configureservices):

   [!code-csharp[](integration-tests-2.1/samples/2.x/IntegrationTestsSample/tests/RazorPagesProject.Tests/CustomWebApplicationFactory.cs?name=snippet1)]

   Database seeding in the [sample app](https://github.com/aspnet/Docs/tree/master/aspnetcore/test/integration-tests-2.1/samples) is performed by the `InitializeDbForTests` method. The method is described in the [Integration tests sample: Test app organization](#test-app-organization) section.

2. Use the custom `CustomWebApplicationFactory` in test classes. The following example uses the factory in the `IndexPageTests` class:

   [!code-csharp[](integration-tests-2.1/samples/2.x/IntegrationTestsSample/tests/RazorPagesProject.Tests/IntegrationTests/IndexPageTests.cs?name=snippet1)]

   The sample app's client is configured to prevent the `HttpClient` from following redirects. As explained in the [Test a secure endpoint](#test-a-secure-endpoint) section, this permits tests to check the result of the app's first response. The first response is a redirect in many of these tests with a `Location` header.

3. A typical test uses the `HttpClient` and helper methods to process the request and the response:

   [!code-csharp[](integration-tests-2.1/samples/2.x/IntegrationTestsSample/tests/RazorPagesProject.Tests/IntegrationTests/IndexPageTests.cs?name=snippet2)]

Any POST request to the SUT must satisfy the antiforgery check that's automatically made by the app's [data protection antiforgery system](xref:security/data-protection/introduction). In order to arrange for a test's POST request, the test app must:

1. Make a request for the page.
1. Parse the antiforgery cookie and request validation token from the response.
1. Make the POST request with the antiforgery cookie and request validation token in place.

The `SendAsync` helper extension methods (*Helpers/HttpClientExtensions.cs*) and the `GetDocumentAsync` helper method (*Helpers/HtmlHelpers.cs*) in the [sample app](https://github.com/aspnet/Docs/tree/master/aspnetcore/test/integration-tests-2.1/samples/) use the [AngleSharp](https://anglesharp.github.io/) parser to handle the antiforgery check with the following methods:

* `GetDocumentAsync` &ndash; Receives the [HttpResponseMessage](/dotnet/api/system.net.http.httpresponsemessage) and returns an `IHtmlDocument`. `GetDocumentAsync` uses a factory that prepares a *virtual response* based on the original `HttpResponseMessage`. For more information, see the [AngleSharp documentation](https://github.com/AngleSharp/AngleSharp#documentation).
* `SendAsync` extension methods for the `HttpClient` compose an [HttpRequestMessage](/dotnet/api/system.net.http.httprequestmessage) and call [SendAsync(HttpRequestMessage)](/dotnet/api/system.net.http.httpclient.sendasync#System_Net_Http_HttpClient_SendAsync_System_Net_Http_HttpRequestMessage_) to submit requests to the SUT. Overloads for `SendAsync` accept the HTML form (`IHtmlFormElement`) and the following:
  - Submit button of the form (`IHtmlElement`)
  - Form values collection (`IEnumerable<KeyValuePair<string, string>>`)
  - Submit button (`IHtmlElement`) and form values (`IEnumerable<KeyValuePair<string, string>>`)

> [!NOTE]
> [AngleSharp](https://anglesharp.github.io/) is a third-party parsing library used for demonstration purposes in this topic and the sample app. AngleSharp isn't supported or required for integration testing of ASP.NET Core apps. Other parsers can be used, such as the [Html Agility Pack (HAP)](http://html-agility-pack.net/). Another approach is to write code to handle the antiforgery system's request verification token and antiforgery cookie directly.

## Customize the client with WithWebHostBuilder

When additional configuration is required within a test method, [WithWebHostBuilder](/dotnet/api/microsoft.aspnetcore.mvc.testing.webapplicationfactory-1.withwebhostbuilder) creates a new `WebApplicationFactory` with an [IWebHostBuilder](/dotnet/api/microsoft.aspnetcore.hosting.iwebhostbuilder) that is further customized by configuration.

The `Post_DeleteMessageHandler_ReturnsRedirectToRoot` test method of the [sample app](https://github.com/aspnet/Docs/tree/master/aspnetcore/test/integration-tests-2.1/samples) demonstrates the use of `WithWebHostBuilder`. This test performs a record delete in the database by triggering a form submission in the SUT.

Because another test in the `IndexPageTests` class performs an operation that deletes all of the records in the database and may run before the `Post_DeleteMessageHandler_ReturnsRedirectToRoot` method, the database is seeded in this test method to ensure that a record is present for the SUT to delete. Selecting the `deleteBtn1` button of the `messages` form in the SUT is simulated in the request to the SUT:

[!code-csharp[](integration-tests-2.1/samples/2.x/IntegrationTestsSample/tests/RazorPagesProject.Tests/IntegrationTests/IndexPageTests.cs?name=snippet3)]

## Client options

The following table shows the default [WebApplicationFactoryClientOptions](/dotnet/api/microsoft.aspnetcore.mvc.testing.webapplicationfactoryclientoptions) available when creating `HttpClient` instances.

| Option | Description | Default |
| ------ | ----------- | ------- |
| [AllowAutoRedirect](/dotnet/api/microsoft.aspnetcore.mvc.testing.webapplicationfactoryclientoptions.allowautoredirect) | Gets or sets whether or not `HttpClient` instances should automatically follow redirect responses. | `true` |
| [BaseAddress](/dotnet/api/microsoft.aspnetcore.mvc.testing.webapplicationfactoryclientoptions.baseaddress) | Gets or sets the base address of `HttpClient` instances. | `http://localhost` |
| [HandleCookies](/dotnet/api/microsoft.aspnetcore.mvc.testing.webapplicationfactoryclientoptions.handlecookies) | Gets or sets whether `HttpClient` instances should handle cookies. | `true` |
| [MaxAutomaticRedirections](/dotnet/api/microsoft.aspnetcore.mvc.testing.webapplicationfactoryclientoptions.maxautomaticredirections) | Gets or sets the maximum number of redirect responses that `HttpClient` instances should follow. | 7 |

Create the `WebApplicationFactoryClientOptions` class and pass it to the [CreateClient](/dotnet/api/microsoft.aspnetcore.mvc.testing.webapplicationfactory-1.createclient) method (default values are shown in the code example):

```csharp
// Default client option values are shown
var clientOptions = new WebApplicationFactoryClientOptions();
clientOptions.AllowAutoRedirect = true;
clientOptions.BaseAddress = new Uri("http://localhost");
clientOptions.HandleCookies = true;
clientOptions.MaxAutomaticRedirections = 7;

_client = _factory.CreateClient(clientOptions);
```

## How the test infrastructure infers the app content root path

The `WebApplicationFactory` constructor infers the app content root path by searching for a [WebApplicationFactoryContentRootAttribute](/dotnet/api/microsoft.aspnetcore.mvc.testing.webapplicationfactorycontentrootattribute) on the assembly containing the integration tests with a key equal to the `TEntryPoint` assembly `System.Reflection.Assembly.FullName`. In case an attribute with the correct key isn't found, `WebApplicationFactory` falls back to searching for a solution file (*\*.sln*) and appends the `TEntryPoint` assembly name to the solution directory. The app root directory (the content root path) is used to discover views and content files.

In most cases, it isn't necessary to explicitly set the app content root, as the search logic usually finds the correct content root at runtime. In special scenarios where the content root isn't found using the built-in search algorithm, the app content root can be specified explicitly or by using custom logic. To set the app content root in those scenarios, call the `UseSolutionRelativeContentRoot` extension method from the [Microsoft.AspNetCore.TestHost](https://www.nuget.org/packages/Microsoft.AspNetCore.TestHost) package. Supply the solution's relative path and optional solution file name or glob pattern (default = `*.sln`).

Call the [UseSolutionRelativeContentRoot](/dotnet/api/microsoft.aspnetcore.testhost.webhostbuilderextensions.usesolutionrelativecontentroot) extension method using *ONE* of the following approaches:

* When configuring test classes with `WebApplicationFactory`, provide a custom configuration with the [IWebHostBuilder](/dotnet/api/microsoft.aspnetcore.hosting.iwebhostbuilder):

   ```csharp
   public IndexPageTests(
       WebApplicationFactory<RazorPagesProject.Startup> factory)
   {
       var _factory = factory.WithWebHostBuilder(builder =>
       {
           builder.UseSolutionRelativeContentRoot("<SOLUTION-RELATIVE-PATH>");

           ...
       });
   }
   ```

* When configuring test classes with a custom `WebApplicationFactory`, inherit from `WebApplicationFactory` and override [ConfigureWebHost](/dotnet/api/microsoft.aspnetcore.mvc.testing.webapplicationfactory-1.configurewebhost):

   ```csharp
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

## Disable shadow copying

Shadow copying causes the tests to execute in a different folder than the output folder. For tests to work properly, shadow copying must be disabled. The [sample app](https://github.com/aspnet/Docs/tree/master/aspnetcore/test/integration-tests-2.1/samples) uses xUnit and disables shadow copying for xUnit by including an *xunit.runner.json* file with the correct configuration setting. For more information, see [Configuring xUnit.net with JSON](https://xunit.github.io/docs/configuring-with-json.html).

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
* The app includes a `/SecurePage` that can only be accessed by an authenticated user.

&#8224;The EF topic, [Test with InMemory](/ef/core/miscellaneous/testing/in-memory), explains how to use an in-memory database for tests with MSTest. This topic uses the [xUnit](https://xunit.github.io/) test framework. Test concepts and test implementations across different test frameworks are similar but not identical.

Although the app doesn't use the [repository pattern](http://martinfowler.com/eaaCatalog/repository.html) and isn't an effective example of the [Unit of Work (UoW) pattern](https://martinfowler.com/eaaCatalog/unitOfWork.html), Razor Pages supports these patterns of development. For more information, see [Designing the infrastructure persistence layer](/dotnet/standard/microservices-architecture/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-design), [Implementing the Repository and Unit of Work Patterns in an ASP.NET MVC Application](/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application), and [Test controller logic](/aspnet/core/mvc/controllers/testing) (the sample implements the repository pattern).

### Test app organization

The test app is a console app inside the *tests/RazorPagesProject.Tests* folder.

| Test app folder | Description |
| --------------- | ----------- |
| *BasicTests* | *BasicTests.cs* contains test methods for routing, accessing a secure page by an unauthenticated user, and obtaining a GitHub user profile and checking the profile's user login. |
| *IntegrationTests* | *IndexPageTests.cs* contains the integration tests for the Index page using custom `WebApplicationFactory` class. |
| *Helpers/Utilities* | <ul><li>*Utilities.cs* contains the `InitializeDbForTests` method used to seed the database with test data.</li><li>*HtmlHelpers.cs* provides a method to return an AngleSharp `IHtmlDocument` for use by the test methods.</li><li>*HttpClientExtensions.cs* provide overloads for `SendAsync` to submit requests to the SUT.</li></ul> |

The test framework is [xUnit](https://xunit.github.io/). Integration tests are conducted using the [Microsoft.AspNetCore.TestHost](/dotnet/api/microsoft.aspnetcore.testhost), which includes the [TestServer](/dotnet/api/microsoft.aspnetcore.testhost.testserver). Because the [Microsoft.AspNetCore.Mvc.Testing](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Testing) package is used to configure the test host and test server, the `TestHost` and `TestServer` packages don't require direct package references in the test app's project file or developer configuration in the test app.

**Seeding the database for testing**

Integration tests usually require a small dataset in the database prior to the test execution. For example, a delete test calls for a database record deletion, so the database must have at least one record for the delete request to succeed.

The sample app seeds the database with three messages in *Utilities.cs* that tests can use when they execute:

[!code-csharp[](integration-tests-2.1/samples/2.x/IntegrationTestsSample/tests/RazorPagesProject.Tests/Helpers/Utilities.cs?name=snippet1)]

## Additional resources

* [Unit tests](/dotnet/articles/core/testing/unit-testing-with-dotnet-test)
* [Razor Pages unit tests](xref:test/razor-pages-tests)
* [Middleware](xref:fundamentals/middleware/index)
* [Test controllers](xref:mvc/controllers/testing)

::: moniker-end
::: moniker range="<= aspnetcore-2.0"

By [Steve Smith](https://ardalis.com/)

Integration tests ensure that an app's components function correctly at the infrastructure level, including the database, file system, and network. ASP.NET Core supports integration tests using unit test frameworks and a built-in test web host to handle simulated requests without network overhead.

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/test/integration-tests/sample) ([how to download](xref:tutorials/index#how-to-download-a-sample))

## Introduction

Integration tests evaluate an app's components at a broader level than [unit tests](/dotnet/core/testing/). Unit tests are used to test individual software components or the logic inside individual methods. Integration tests are used to text the app's infrastructure and whole framework, often including the following components:

* Database
* File system
* Network resources
* Request-response pipeline

Unit tests use *fakes* (fabricated components) or *mock objects* in place of infrastructure components, but integration tests use the actual components that the app uses. Integration tests confirm that the whole app works as expected.

Integration tests process more code than unit tests and rely on fully working infrastructure elements. Integration tests are usually slower than unit tests. Therefore, limit the use of integration tests to the most important infrastructure scenarios. If a behavior can be tested using either a unit test or an integration test, choose the unit test.

> [!TIP]
> Don't write integration tests for every possible permutation of data and file access with databases and file systems. Regardless of how many places across an app interact with databases and file systems, a focused set of read, write, update, and delete integration tests are usually capable of adequately testing database and file system components. Use unit tests for routine tests of method logic that interact with these components. In unit tests, the use of infrastructure fakes/mocks result in faster testing.

## Integration testing ASP.NET Core

Integration tests use the following:

* Test project with a reference to the tested ASP.NET Core project
* Test runner to execute the tests of the app's code and report the test results

The [unit testing](/dotnet/articles/core/testing/unit-testing-with-dotnet-test) documentation describes how to set up a test project and test runner, along with detailed instructions on how to run tests and recommendations for how to name tests and test classes.

> [!NOTE]
> Separate unit tests from integration tests into different projects. This helps ensure that infrastructure concerns aren't accidently included in unit tests. Separation of unit and integration tests also allows control over which set of tests are run.

### Test Host

ASP.NET Core offers a *test host* that can be added to integration test projects and used to host ASP.NET Core apps. The test host processes requests and responses without the need for a real web host. The [sample app](https://github.com/aspnet/Docs/tree/master/aspnetcore/test/integration-tests/sample) includes an integration test project configured to use [xUnit](https://xunit.github.io) and the ASP.NET Core test host ([Microsoft.AspNetCore.TestHost](/dotnet/api/microsoft.aspnetcore.testhost)).

After the `Microsoft.AspNetCore.TestHost` package is included in the test project, a [test server](/dotnet/api/microsoft.aspnetcore.testhost.testserver) is available for use in integration tests. The following test shows how to verify that a request made to the root of a site returns "Hello World!" The example test runs successfully against an app created using the default ASP.NET Core Empty Web template. For more information on creating an app from a template, see the [dotnet new](/dotnet/core/tools/dotnet-new) command or use the built-in new project system in [Visual Studio](https://www.visualstudio.com/vs/).

[!code-csharp[](integration-tests/sample/test/PrimeWeb.IntegrationTests/PrimeWebDefaultRequestShould.cs?name=snippet_WebDefault&highlight=7,16,22)]

> [!NOTE]
> In discussions of testing, the tested project is frequently called the *system under test*, or "SUT" for short.

This test is using the Arrange-Act-Assert pattern. The Arrange step is performed in the constructor, which creates an instance of `TestServer`. A configured [WebHostBuilder](/dotnet/api/microsoft.aspnetcore.hosting.webhostbuilder) is used to create a `TestHost`. The [Configure](/dotnet/api/microsoft.aspnetcore.hosting.istartup.configure) method from the SUT's `Startup` class is passed to the `WebHostBuilder`. This method is used to configure the request pipeline of the `TestServer` identically to how the SUT's server is configured.

In the Act portion of the test, a request is made to the `TestServer` instance for the `/` (root) path. The response is read back into a string. The actual (returned) string is compared with the expected string of "Hello World!" If actual string and the expected string match, the test passes. Otherwise, the test fails.

Add a couple of additional integration tests to confirm that the app's prime checking functionality works:

[!code-csharp[](integration-tests/sample/test/PrimeWeb.IntegrationTests/PrimeWebCheckPrimeShould.cs?name=snippet_CheckPrime)]

Note that these tests aren't trying to test the correctness of the prime number checker but rather that the web app is processing requests correctly. One or more unit tests are already testing the `PrimeService` to ensure the prime number checker works properly:

![Test Explorer](integration-tests/_static/test-explorer.png)

To learn more about the unit tests, see the [Unit testing](/dotnet/articles/core/testing/unit-testing-with-dotnet-test) topic.

### Integration testing MVC/Razor

Test projects that contain Razor views require `<PreserveCompilationContext>` be set to `true` in the project file:

```xml
<PreserveCompilationContext>true</PreserveCompilationContext>
```

Projects missing this element generate an error similar to the following:

```
Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationFailedException: 'One or more compilation failures occurred:
ooebhccx.1bd(4,62): error CS0012: The type 'Attribute' is defined in an assembly that is not referenced. You must add a reference to assembly 'netstandard, Version=2.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'.
```

## Refactoring to use middleware

*Refactoring* is the process of changing an app's code to improve its design without changing its behavior. Refactoring should ideally be performed when a suite of tests are passing. Refactoring after tests pass helps to ensure that the system's behavior remains the same before and after refactoring.

The prime checking logic is implemented in the web app's `Configure` method:

```csharp
public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }

    app.Run(async (context) =>
    {
        if (context.Request.Path.Value.Contains("checkprime"))
        {
            int numberToCheck;
            try
            {
                numberToCheck = int.Parse(context.Request.QueryString.Value.Replace("?", ""));
                var primeService = new PrimeService();
                if (primeService.IsPrime(numberToCheck))
                {
                    await context.Response.WriteAsync($"{numberToCheck} is prime!");
                }
                else
                {
                    await context.Response.WriteAsync($"{numberToCheck} is NOT prime!");
                }
            }
            catch
            {
                await context.Response.WriteAsync("Pass in a number to check in the form /checkprime?5");
            }
        }
        else
        {
            await context.Response.WriteAsync("Hello World!");
        }
    });
}
```

This code works, but it's far from how one would like to implement this kind of functionality in an ASP.NET Core app. Imagine what the `Configure` method would look like if testing requried this much code added every time another URL endpoint is added!

One option to consider is adding [MVC](xref:mvc/overview) to the app and creating a controller to handle prime checking. Assume the app doesn't currently require additional MVC functionality. Adding MVC merely for the purpose of testing the prime checking code creates an inefficient burden on the app and test suite.

ASP.NET Core [middleware](xref:fundamentals/middleware/index) provides a solution, which helps encapsulate the prime checking logic in its own class to achieve better [separation of concerns](http://deviq.com/separation-of-concerns/) in the `Configure` method.

The path the middleware uses is specified as a parameter. The middleware class expects a `RequestDelegate` and a `PrimeCheckerOptions` instance in its constructor. If the path of the request doesn't match what this middleware is configured to expect, the next middleware in the chain is called. The remainder of the implementation code that was in `Configure` is now in the `Invoke` method.

> [!NOTE]
> Since the middleware depends on `PrimeService`, an instance of this service is requested with the constructor. The framework provides this service via [dependency injection](xref:fundamentals/dependency-injection), assuming it's configured (for example in `ConfigureServices`).

[!code-csharp[](integration-tests/sample/src/PrimeWeb/Middleware/PrimeCheckerMiddleware.cs?highlight=39-63)]

Since this middleware acts as an endpoint in the request delegate chain when its path matches, there's no call to `_next.Invoke` when this middleware handles the request.

With this middleware in place and helpful extension methods for easier configuration, the refactored `Configure` method looks like the following:

[!code-csharp[](integration-tests/sample/src/PrimeWeb/Startup.cs?highlight=9&range=19-33)]

Following refactoring, the web app works as it did before, since the integration tests are passing.

> [!NOTE]
> It's a good idea to commit the changes to source control after refactoring is complete and the tests pass. If practicing [Test Driven Development (TDD)](http://deviq.com/test-driven-development/), [consider adding Commit to your Red-Green-Refactor cycle](https://ardalis.com/rgrc-is-the-new-red-green-refactor-for-test-first-development).

## Additional resources

* [Unit testing](/dotnet/articles/core/testing/unit-testing-with-dotnet-test)
* [Razor Pages unit tests](xref:test/razor-pages-tests)
* [Middleware](xref:fundamentals/middleware/index)
* [Test controllers](xref:mvc/controllers/testing)

::: moniker-end
