---
title: Integration tests in ASP.NET Core
author: rick-anderson
description: Learn how integration tests ensure that an app's components function correctly at the infrastructure level, including the database, file system, and network.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 1/29/2024
uid: test/integration-tests
---
# Integration tests in ASP.NET Core

By [Jos van der Til](https://jvandertil.nl), [Martin Costello](https://martincostello.com/), and [Javier Calvarro Nelson](https://github.com/javiercn).

Integration tests ensure that an app's components function correctly at a level that includes the app's supporting infrastructure, such as the database, file system, and network. ASP.NET Core supports integration tests using a unit test framework with a test web host and an in-memory test server.

:::moniker range=">= aspnetcore-6.0"

This article assumes a basic understanding of unit tests. If unfamiliar with test concepts, see the [Unit Testing in .NET Core and .NET Standard](/dotnet/core/testing/) article and its linked content.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/test/integration-tests/IntegrationTestsSample) ([how to download](xref:index#how-to-download-a-sample))

The sample app is a Razor Pages app and assumes a basic understanding of Razor Pages. If you're unfamiliar with Razor Pages, see the following articles:

* [Introduction to Razor Pages](xref:razor-pages/index)
* [Get started with Razor Pages](xref:tutorials/razor-pages/razor-pages-start)
* [Razor Pages unit tests](xref:test/razor-pages-tests)

**For testing SPAs**, we recommend a tool such as [Playwright for .NET](https://playwright.dev/dotnet/), which can automate a browser.

[!INCLUDE[](~/includes/integrationTests.md)]

There's virtually no difference between the configuration for tests of Razor Pages apps and MVC apps. The only difference is in how the tests are named. In a Razor Pages app, tests of page endpoints are usually named after the page model class (for example, `IndexPageTests` to test component integration for the Index page). In an MVC app, tests are usually organized by controller classes and named after the controllers they test (for example, `HomeControllerTests` to test component integration for the Home controller).

## Test app prerequisites

The test project must:

* Reference the [`Microsoft.AspNetCore.Mvc.Testing`](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Testing) package.
* Specify the Web SDK in the project file (`<Project Sdk="Microsoft.NET.Sdk.Web">`).

These prerequisites can be seen in the [sample app](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/test/integration-tests/IntegrationTestsSample). Inspect the `tests/RazorPagesProject.Tests/RazorPagesProject.Tests.csproj` file. The sample app uses the [xUnit](https://xunit.net/) test framework and the [AngleSharp](https://anglesharp.github.io/) parser library, so the sample app also references:

* [`AngleSharp`](https://www.nuget.org/packages/AngleSharp)
* [`xunit`](https://www.nuget.org/packages/xunit)
* [`xunit.runner.visualstudio`](https://www.nuget.org/packages/xunit.runner.visualstudio)

In apps that use [`xunit.runner.visualstudio`](https://www.nuget.org/packages/xunit.runner.visualstudio) version 2.4.2 or later, the test project must reference the [`Microsoft.NET.Test.Sdk`](https://www.nuget.org/packages/Microsoft.NET.Test.Sdk) package.

Entity Framework Core is also used in the tests. See the [project file in GitHub](https://github.com/dotnet/AspNetCore.Docs.Samples/blob/main/test/integration-tests/IntegrationTestsSample/src/RazorPagesProject/RazorPagesProject.csproj).

## SUT environment

If the SUT's [environment](xref:fundamentals/environments) isn't set, the environment defaults to Development.

## Basic tests with the default WebApplicationFactory


Expose the implicitly defined `Program` class to the test project by doing one of the following:

* Expose internal types from the web app to the test project. This can be done in the SUT project's file (`.csproj`):
  ```xml
  <ItemGroup>
       <InternalsVisibleTo Include="MyTestProject" />
  </ItemGroup>
  ```
* Make the [`Program` class public using a partial class](https://github.com/dotnet/AspNetCore.Docs.Samples/blob/main/test/integration-tests/IntegrationTestsSample/src/RazorPagesProject/Program.cs) declaration:

  ```diff
  var builder = WebApplication.CreateBuilder(args);
  // ... Configure services, routes, etc.
  app.Run();
  + public partial class Program { }
  ```

  The [sample app](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/test/integration-tests/IntegrationTestsSample) uses the `Program` partial class approach.

<xref:Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactory%601> is used to create a <xref:Microsoft.AspNetCore.TestHost.TestServer> for the integration tests. `TEntryPoint` is the entry point class of the SUT, usually `Program.cs`.

Test classes implement a *class fixture* interface ([`IClassFixture`](https://xunit.net/docs/shared-context#class-fixture)) to indicate the class contains tests and provide shared object instances across the tests in the class.

The following test class, `BasicTests`, uses the `WebApplicationFactory` to bootstrap the SUT and provide an <xref:System.Net.Http.HttpClient> to a test method, `Get_EndpointsReturnSuccessAndCorrectContentType`. The method verifies the response status code is successful (200-299) and the `Content-Type` header is `text/html; charset=utf-8` for several app pages.

<xref:Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactory%601.CreateClient> creates an instance of `HttpClient` that automatically follows redirects and handles cookies.
  
[!code-csharp[](~/../AspNetCore.Docs.Samples/test/integration-tests/IntegrationTestsSample/tests/RazorPagesProject.Tests/IntegrationTests/BasicTests.cs?name=snippet1)]

By default, non-essential cookies aren't preserved across requests when the [General Data Protection Regulation consent policy](xref:security/gdpr) is enabled. To preserve non-essential cookies, such as those used by the TempData provider, mark them as essential in your tests. For instructions on marking a cookie as essential, see [Essential cookies](xref:security/gdpr#essential-cookies).

<a name="asap7"></a>

## AngleSharp vs `Application Parts` for antiforgery checks

This article uses the [AngleSharp](https://anglesharp.github.io/) parser to handle the antiforgery checks by loading pages and parsing the HTML. For testing the endpoints of controller and Razor Pages views at a lower-level, without caring about how they render in the browser, consider using `Application Parts`. The [Application Parts](xref:mvc/extensibility/app-parts) approach injects a controller or Razor Page into the app that can be used to make JSON requests to get the required values. For more information, see the blog [Integration Testing ASP.NET Core Resources Protected with Antiforgery Using Application Parts](https://blog.martincostello.com/integration-testing-antiforgery-with-application-parts/) and [associated GitHub repo](https://github.com/martincostello/antiforgery-testing-application-part) by [Martin Costello](https://github.com/martincostello). <!--See https://github.com/dotnet/AspNetCore.Docs/issues/18860 -->

## Customize WebApplicationFactory

Web host configuration can be created independently of the test classes by inheriting from <xref:Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactory%601> to create one or more custom factories:

1. Inherit from `WebApplicationFactory` and override <xref:Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactory%601.ConfigureWebHost%2A>. The <xref:Microsoft.AspNetCore.Hosting.IWebHostBuilder> allows the configuration of the service collection with [`IWebHostBuilder.ConfigureServices`](xref:Microsoft.AspNetCore.Hosting.IWebHostBuilder.ConfigureServices%2A)

   [!code-csharp[](~/../AspNetCore.Docs.Samples/test/integration-tests/IntegrationTestsSample/tests/RazorPagesProject.Tests/CustomWebApplicationFactory.cs?name=snippet1)]

   Database seeding in the [sample app](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/test/integration-tests/IntegrationTestsSample) is performed by the `InitializeDbForTests` method. The method is described in the [Integration tests sample: Test app organization](#test-app-organization) section.

   The SUT's database context is registered in `Program.cs`. The test app's `builder.ConfigureServices` callback is executed *after* the app's `Program.cs` code is executed. To use a different database for the tests than the app's database, the app's database context must be replaced in `builder.ConfigureServices`.

   The sample app finds the service descriptor for the database context and uses the descriptor to remove the service registration. The factory then adds a new `ApplicationDbContext` that uses an in-memory database for the tests..

   To connect to a different database, change the `DbConnection`. To use a SQL Server test database:

   * Reference the [`Microsoft.EntityFrameworkCore.SqlServer`](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/) NuGet package in the project file.
   * Call `UseInMemoryDatabase`.
<!--
    [!code-csharp[](~/../AspNetCore.Docs.Samples/test/integration-tests/IntegrationTestsSample/src/RazorPagesProject/Program.cs?name=snippet_all)]
-->
2. Use the custom `CustomWebApplicationFactory` in test classes. The following example uses the factory in the `IndexPageTests` class:

   [!code-csharp[](~/../AspNetCore.Docs.Samples/test/integration-tests/IntegrationTestsSample/tests/RazorPagesProject.Tests/IntegrationTests/IndexPageTests.cs?name=snippet1)]

   The sample app's client is configured to prevent the `HttpClient` from following redirects. As explained later in the [Mock authentication](#mock-authentication) section, this permits tests to check the result of the app's first response. The first response is a redirect in many of these tests with a `Location` header.

3. A typical test uses the `HttpClient` and helper methods to process the request and the response:

   [!code-csharp[](~/../AspNetCore.Docs.Samples/test/integration-tests/IntegrationTestsSample/tests/RazorPagesProject.Tests/IntegrationTests/IndexPageTests.cs?name=snippet2)]

Any POST request to the SUT must satisfy the antiforgery check that's automatically made by the app's [data protection antiforgery system](xref:security/data-protection/introduction). In order to arrange for a test's POST request, the test app must:

1. Make a request for the page.
1. Parse the antiforgery cookie and request validation token from the response.
1. Make the POST request with the antiforgery cookie and request validation token in place.

The `SendAsync` helper extension methods (`Helpers/HttpClientExtensions.cs`) and the `GetDocumentAsync` helper method (`Helpers/HtmlHelpers.cs`) in the [sample app](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/test/integration-tests/IntegrationTestsSample/) use the [AngleSharp](https://anglesharp.github.io/) parser to handle the antiforgery check with the following methods:

* `GetDocumentAsync`: Receives the <xref:System.Net.Http.HttpResponseMessage> and returns an `IHtmlDocument`. `GetDocumentAsync` uses a factory that prepares a *virtual response* based on the original `HttpResponseMessage`. For more information, see the [AngleSharp documentation](https://github.com/AngleSharp/AngleSharp#documentation).
* `SendAsync` extension methods for the `HttpClient` compose an <xref:System.Net.Http.HttpRequestMessage> and call <xref:System.Net.Http.HttpClient.SendAsync(System.Net.Http.HttpRequestMessage)> to submit requests to the SUT. Overloads for `SendAsync` accept the HTML form (`IHtmlFormElement`) and the following:
  * Submit button of the form (`IHtmlElement`)
  * Form values collection (`IEnumerable<KeyValuePair<string, string>>`)
  * Submit button (`IHtmlElement`) and form values (`IEnumerable<KeyValuePair<string, string>>`)

[AngleSharp](https://anglesharp.github.io/) is a **third-party parsing library used for demonstration purposes** in this article and the sample app. AngleSharp isn't supported or required for integration testing of ASP.NET Core apps. Other parsers can be used, such as the [Html Agility Pack (HAP)](https://html-agility-pack.net/). Another approach is to write code to handle the antiforgery system's request verification token and antiforgery cookie directly. See [AngleSharp vs `Application Parts` for antiforgery checks](#asap7) in this article for more information.

The [EF-Core in-memory database provider](/ef/core/testing/choosing-a-testing-strategy#in-memory-as-a-database-fake) can be used for limited and basic testing, however the ***[SQLite provider](/ef/core/testing/choosing-a-testing-strategy#sqlite-as-a-database-fake) is the recommended choice for in-memory testing***.

See [Extend Startup with startup filters](xref:fundamentals/startup#IStartupFilter) which shows how to configure middleware using <xref:Microsoft.AspNetCore.Hosting.IStartupFilter>, which is useful when a test requires a custom service or middleware.

## Customize the client with WithWebHostBuilder

When additional configuration is required within a test method, <xref:Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactory%601.WithWebHostBuilder%2A> creates a new `WebApplicationFactory` with an <xref:Microsoft.AspNetCore.Hosting.IWebHostBuilder> that is further customized by configuration.


The [sample code](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/test/integration-tests/IntegrationTestsSample/tests/RazorPagesProject.Tests/IntegrationTests) calls `WithWebHostBuilder` to replace configured services with test stubs. For more information and example usage, see [Inject mock services](#inject-mock-services) in this article.

The `Post_DeleteMessageHandler_ReturnsRedirectToRoot` test method of the [sample app](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/test/integration-tests/IntegrationTestsSample) demonstrates the use of `WithWebHostBuilder`. This test performs a record delete in the database by triggering a form submission in the SUT.

Because another test in the `IndexPageTests` class performs an operation that deletes all of the records in the database and may run before the `Post_DeleteMessageHandler_ReturnsRedirectToRoot` method, the database is reseeded in this test method to ensure that a record is present for the SUT to delete. Selecting the first delete button of the `messages` form in the SUT is simulated in the request to the SUT:

[!code-csharp[](~/../AspNetCore.Docs.Samples/test/integration-tests/IntegrationTestsSample/tests/RazorPagesProject.Tests/IntegrationTests/IndexPageTests.cs?name=snippet3)]

## Client options

See the <xref:Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactoryClientOptions> page for defaults and available options when creating `HttpClient` instances.

Create the `WebApplicationFactoryClientOptions` class and pass it to the <xref:Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactory%601.CreateClient> method:

[!code-csharp[](~/../AspNetCore.Docs.Samples/test/integration-tests/IntegrationTestsSample/tests/RazorPagesProject.Tests/IntegrationTests/IndexPageTests.cs?name=snippet1)]

***NOTE:*** To avoid HTTPS redirection warnings in logs when using HTTPS Redirection Middleware, set `BaseAddress = new Uri("https://localhost")`

## Inject mock services

Services can be overridden in a test with a call to xref:Microsoft.AspNetCore.TestHost.WebHostBuilderExtensions.ConfigureTestServices%2A on the host builder. To scope the overridden services to the test itself, the <xref:Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactory%601.WithWebHostBuilder%2A> method is used to retrieve a host builder. This can be seen in the following tests:

* [Get_QuoteService_ProvidesQuoteInPage](https://github.com/dotnet/AspNetCore.Docs.Samples/blob/main/test/integration-tests/IntegrationTestsSample/tests/RazorPagesProject.Tests/IntegrationTests/IndexPageTests.cs#L166-L173)
* [Get_GithubProfilePageCanGetAGithubUser](https://github.com/dotnet/AspNetCore.Docs.Samples/blob/main/test/integration-tests/IntegrationTestsSample/tests/RazorPagesProject.Tests/IntegrationTests/AuthTests.cs#L35-L38)
* [Get_SecurePageIsReturnedForAnAuthenticatedUser](https://github.com/dotnet/AspNetCore.Docs.Samples/blob/main/test/integration-tests/IntegrationTestsSample/tests/RazorPagesProject.Tests/IntegrationTests/AuthTests.cs#L105-L117)

The sample SUT includes a scoped service that returns a quote. The quote is embedded in a hidden field on the Index page when the Index page is requested.

`Services/IQuoteService.cs`:

[!code-csharp[](~/../AspNetCore.Docs.Samples/test/integration-tests/IntegrationTestsSample/src/RazorPagesProject/Services/IQuoteService.cs?name=snippet1)]

`Services/QuoteService.cs`:

[!code-csharp[](~/../AspNetCore.Docs.Samples/test/integration-tests/IntegrationTestsSample/src/RazorPagesProject/Services/QuoteService.cs?name=snippet1)]

`Program.cs`:

[!code-csharp[](~/../AspNetCore.Docs.Samples/test/integration-tests/IntegrationTestsSample/src/RazorPagesProject/Program.cs?name=snippet2)]

`Pages/Index.cshtml.cs`:

[!code-csharp[](~/../AspNetCore.Docs.Samples/test/integration-tests/IntegrationTestsSample/src/RazorPagesProject/Pages/Index.cshtml.cs?name=snippet1&highlight=4,9,20,26)]

`Pages/Index.cs`:

[!code-cshtml[](~/../AspNetCore.Docs.Samples/test/integration-tests/IntegrationTestsSample/src/RazorPagesProject/Pages/Index.cshtml?name=snippet_Quote)]

The following markup is generated when the SUT app is run:

```html
<input id="quote" type="hidden" value="Come on, Sarah. We&#x27;ve an appointment in 
    London, and we&#x27;re already 30,000 years late.">
```

To test the service and quote injection in an integration test, a mock service is injected into the SUT by the test. The mock service replaces the app's `QuoteService` with a service provided by the test app, called `TestQuoteService`:

`IntegrationTests.IndexPageTests.cs`:

[!code-csharp[](~/../AspNetCore.Docs.Samples/test/integration-tests/IntegrationTestsSample/tests/RazorPagesProject.Tests/IntegrationTests/IndexPageTests.cs?name=snippet4)]

`ConfigureTestServices` is called, and the scoped service is registered:

[!code-csharp[](~/../AspNetCore.Docs.Samples/test/integration-tests/IntegrationTestsSample/tests/RazorPagesProject.Tests/IntegrationTests/IndexPageTests.cs?name=snippet5&highlight=7-10,17,20-21)]

The markup produced during the test's execution reflects the quote text supplied by `TestQuoteService`, thus the assertion passes:

```html
<input id="quote" type="hidden" value="Something&#x27;s interfering with time, 
    Mr. Scarman, and time is my business.">
```

## Mock authentication

Tests in the `AuthTests` class check that a secure endpoint:

* Redirects an unauthenticated user to the app's sign in page.
* Returns content for an authenticated user.

In the SUT, the `/SecurePage` page uses an <xref:Microsoft.Extensions.DependencyInjection.PageConventionCollectionExtensions.AuthorizePage%2A> convention to apply an <xref:Microsoft.AspNetCore.Mvc.Authorization.AuthorizeFilter> to the page. For more information, see [Razor Pages authorization conventions](xref:security/authorization/razor-pages-authorization#require-authorization-to-access-a-page).

[!code-csharp[](~/../AspNetCore.Docs.Samples/test/integration-tests/IntegrationTestsSample/src/RazorPagesProject/Program.cs?name=snippet1)]

In the `Get_SecurePageRedirectsAnUnauthenticatedUser` test, a <xref:Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactoryClientOptions> is set to disallow redirects by setting <xref:Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactoryClientOptions.AllowAutoRedirect> to `false`:

[!code-csharp[](~/../AspNetCore.Docs.Samples/test/integration-tests/IntegrationTestsSample/tests/RazorPagesProject.Tests/IntegrationTests/AuthTests.cs?name=snippet2)]

By disallowing the client to follow the redirect, the following checks can be made:

* The status code returned by the SUT can be checked against the expected <xref:System.Net.HttpStatusCode.Redirect?displayProperty=nameWithType> result, not the final status code after the redirect to the sign in page, which would be <xref:System.Net.HttpStatusCode.OK?displayProperty=nameWithType>.
* The `Location` header value in the response headers is checked to confirm that it starts with `http://localhost/Identity/Account/Login`, not the final sign in page response, where the `Location` header wouldn't be present.

The test app can mock an <xref:Microsoft.AspNetCore.Authentication.AuthenticationHandler%601> in <xref:Microsoft.AspNetCore.TestHost.WebHostBuilderExtensions.ConfigureTestServices%2A> in order to test aspects of authentication and authorization. A minimal scenario returns an <xref:Microsoft.AspNetCore.Authentication.AuthenticateResult.Success%2A?displayProperty=nameWithType>:

[!code-csharp[](~/../AspNetCore.Docs.Samples/test/integration-tests/IntegrationTestsSample/tests/RazorPagesProject.Tests/IntegrationTests/AuthTests.cs?name=snippet4&highlight=11-18)]

The `TestAuthHandler` is called to authenticate a user when the authentication scheme is set to `TestScheme` where `AddAuthentication` is registered for `ConfigureTestServices`. It's important for the `TestScheme` scheme to match the scheme your app expects. Otherwise, authentication won't work.

[!code-csharp[](~/../AspNetCore.Docs.Samples/test/integration-tests/IntegrationTestsSample/tests/RazorPagesProject.Tests/IntegrationTests/AuthTests.cs?name=snippet3&highlight=7-12)]

For more information on `WebApplicationFactoryClientOptions`, see the [Client options](#client-options) section.

### Basic tests for authentication middleware

See [this GitHub repository](https://github.com/blowdart/idunno.Authentication/tree/dev/test/idunno.Authentication.Basic.Test) for basic tests of authentication middleware. It contains a [test server](https://github.com/blowdart/idunno.Authentication/blob/dev/test/idunno.Authentication.Basic.Test/BasicAuthenticationTests.cs#L331) that’s specific to the test scenario.

## Set the environment

Set the [environment](xref:fundamentals/environments) in the custom application factory:

[!code-csharp[](~/../AspNetCore.Docs.Samples/test/integration-tests/IntegrationTestsSample/tests/RazorPagesProject.Tests/CustomWebApplicationFactory.cs?name=snippet1&highlight=36)]

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

The [sample app](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/test/integration-tests/IntegrationTestsSample) is composed of two apps:

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

&#8224;The EF article, [Test with InMemory](/ef/core/miscellaneous/testing/in-memory), explains how to use an in-memory database for tests with MSTest. This topic uses the [xUnit](https://xunit.net/) test framework. Test concepts and test implementations across different test frameworks are similar but not identical.

Although the app doesn't use the repository pattern and isn't an effective example of the [Unit of Work (UoW) pattern](https://martinfowler.com/eaaCatalog/unitOfWork.html), Razor Pages supports these patterns of development. For more information, see [Designing the infrastructure persistence layer](/dotnet/standard/microservices-architecture/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-design) and [Test controller logic](xref:mvc/controllers/testing) (the sample implements the repository pattern).

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

[!code-csharp[](~/../AspNetCore.Docs.Samples/test/integration-tests/IntegrationTestsSample/tests/RazorPagesProject.Tests/Helpers/Utilities.cs?name=snippet1)]

The SUT's database context is registered in `Program.cs`. The test app's `builder.ConfigureServices` callback is executed *after* the app's `Program.cs` code is executed. To use a different database for the tests, the app's database context must be replaced in `builder.ConfigureServices`. For more information, see the [Customize WebApplicationFactory](#customize-webapplicationfactory) section.

## Additional resources

* [Unit tests](/dotnet/articles/core/testing/unit-testing-with-dotnet-test)
* <xref:test/razor-pages-tests>
* <xref:fundamentals/middleware/index>
* <xref:mvc/controllers/testing>
* [Basic tests for authentication middleware](https://github.com/blowdart/idunno.Authentication/tree/dev/test/idunno.Authentication.Basic.Test)

:::moniker-end

[!INCLUDE[](~/test/integration-tests/includes/integration-tests5.md)]