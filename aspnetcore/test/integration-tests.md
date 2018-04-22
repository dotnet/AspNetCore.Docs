---
title: Integration tests in ASP.NET Core
author: ardalis
description: Learn how integration tests ensure that an app's components function correctly at the infrastructure level, including the database, file system, and network.
manager: wpickett
monikerRange: '<= aspnetcore-2.0'
ms.author: riande
ms.custom: mvc
ms.date: 04/21/2018
ms.prod: asp.net-core
ms.technology: aspnet
ms.topic: article
uid: test/integration-tests
---
# Integration tests in ASP.NET Core

<!--
    When updating the 'Introduction to integration tests' or 'Integration testing ASP.NET Core' sections, be sure to update the integration-tests-2.1.md file with the same changes.
-->

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

In the Act portion of the test, a request is made to the `TestServer` instance for the `/` (root) path. The response is read back into a string. The actual  (returned) string is compared with the expected string of "Hello World!" If actual string and the expected string match, the test passes. Otherwise, the test fails.

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
