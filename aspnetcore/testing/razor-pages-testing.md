---
title: Razor Pages unit and integration testing in ASP.NET Core
author: guardrex
description: Learn how to create unit and integration tests for Razor Pages apps.
ms.author: riande
manager: wpickett
ms.custom: mvc
ms.date: 11/27/2017
ms.topic: article
ms.technology: aspnet
ms.prod: asp.net-core
uid: testing/razor-pages-testing
---
# Razor Pages unit and integration testing in ASP.NET Core

By [Luke Latham](https://github.com/guardrex)

ASP.NET Core supports unit and integration testing of Razor Pages apps. Testing the data access layer (DAL), page models, and integrated page components helps ensure:

* Parts of a Razor Pages app work independently and together as a unit during app construction.
* Classes and methods have limited scopes of responsibility.
* Additional documentation exists on how the app should behave.
* Regressions, which are errors brought about by updates to the code, are found during automated building and deployment.

This topic assumes that you have a basic understanding of Razor Pages apps, unit testing, and integration testing. If you're unfamiliar with Razor Pages apps or testing concepts, see the following topics:

* [Introduction to Razor Pages](xref:mvc/razor-pages/index)
* [Getting started with Razor Pages](xref:tutorials/razor-pages/razor-pages-start)
* [Unit testing C# in .NET Core using dotnet test and xUnit](/dotnet/articles/core/testing/unit-testing-with-dotnet-test)
* [Integration testing](xref:testing/integration-testing)

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/testing/razor-pages-testing/sample/) ([how to download](xref:tutorials/index#how-to-download-a-sample))

The sample project is composed of two apps:

| App         | Project folder                        | Description |
| ----------- | ------------------------------------- | ----------- |
| Message app | *src/RazorPagesTestingSample*         | Allows a user to add, delete one, delete all, and analyze messages. |
| Test app    | *tests/RazorPagesTestingSample.Tests* | Used to test the message app.<ul><li>Unit tests: Data access layer (DAL), Index page model</li><li>Integration tests: Index page</li></ul> |

The tests can be run using the built-in testing features of an IDE, such as [Visual Studio](https://www.visualstudio.com/vs/). If using [Visual Studio Code](https://code.visualstudio.com/) or the command line, execute the following command at a command prompt in the *tests/RazorPagesTestingSample.Tests* folder:

```console
dotnet test
```

## Message app organization

The message app is a simple Razor Pages message system with the following characteristics:

* The Index page of the app (*Pages/Index.cshtml* and *Pages/Index.cshtml.cs*) provides a UI and page model methods to control the addition, deletion, and analysis of messages (average words per message).
* A message is described by the `Message` class (*Data/Message.cs*) with two properties: `Id` (key) and `Text` (message). The `Text` property is required and limited to 200 characters.
* Messages are stored using [Entity Framework's in-memory database](/ef/core/providers/in-memory/)&#8224;.
* The app contains a data access layer (DAL) in its database context class, `AppDbContext` (*Data/AppDbContext.cs*). The DAL methods are marked `virtual`, which allows mocking the methods for use in the tests.
* If the database is empty on app startup, the message store is initialized with three messages. These *seeded messages* are also used in testing.

&#8224;The EF topic, [Testing with InMemory](/ef/core/miscellaneous/testing/in-memory), explains how to use an in-memory database for testing with MSTest. This topic uses the [xUnit](https://xunit.github.io/) testing framework. Testing concepts and test implementations across different testing frameworks are similar but not identical.

Although the app doesn't use the [repository pattern](http://martinfowler.com/eaaCatalog/repository.html) and isn't an effective example of the [Unit of Work (UoW) pattern](https://martinfowler.com/eaaCatalog/unitOfWork.html), Razor Pages supports these patterns of development. For more information, see [Designing the infrastructure persistence layer](/dotnet/standard/microservices-architecture/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-design), [Implementing the Repository and Unit of Work Patterns in an ASP.NET MVC Application](/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application), and [Testing controller logic](/aspnet/core/mvc/controllers/testing) (the sample implements the repository pattern).

## Test app organization

The test app is a console app inside the *tests/RazorPagesTestingSample.Tests* folder:

| Test app folder    | Description |
| ------------------ | ----------- |
| *IntegrationTests* | <ul><li>*IndexPageTest.cs* contains the integration tests for the Index page.</li><li>*TestFixture.cs* creates the test host to test the message app.</li></ul> |
| *UnitTests*        | <ul><li>*DataAccessLayerTest.cs* contains the unit tests for the DAL.</li><li>*IndexPageTest.cs* contains the unit tests for the Index page model.</li></ul> |
| *Utilities*        | *Utilities.cs* contains the:<ul><li>`TestingDbContextOptions` method used to create new database context options for each DAL unit test so that the database is reset to its baseline condition for each test.</li><li>`GetRequestContentAsync` method used to prepare the `HttpClient` and content for requests that are sent to the message app during integration testing.</li></ul>

The test framework is [xUnit](https://xunit.github.io/). The object mocking framework is [Moq](https://github.com/moq/moq4). Integration tests are conducted using the [ASP.NET Core Test Host](xref:testing/integration-testing#the-test-host).

## Unit testing the data access layer (DAL)

The message app has a DAL with four methods contained in the `AppDbContext` class (*src/RazorPagesTestingSample/Data/AppDbContext.cs*). Each method has one or two unit tests in the test app.

| DAL method               | Function                                                                   |
| ------------------------ | -------------------------------------------------------------------------- |
| `GetMessagesAsync`       | Obtains a `List<Message>` from the database sorted by the `Text` property. |
| `AddMessageAsync`        | Adds a `Message` to the database.                                          |
| `DeleteAllMessagesAsync` | Deletes all `Message` entries from the database.                           |
| `DeleteMessageAsync`     | Deletes a single `Message` from the database by `Id`.                      |

Unit tests of the DAL require [DbContextOptions](/dotnet/api/microsoft.entityframeworkcore.dbcontextoptions) when creating a new `AppDbContext` for each test. One approach to creating the `DbContextOptions` for each test is to use a [DbContextOptionsBuilder](/dotnet/api/microsoft.entityframeworkcore.dbcontextoptionsbuilder):

```csharp
var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>()
    .UseInMemoryDatabase("InMemoryDb");

using (var db = new AppDbContext(optionsBuilder.Options))
{
    // Use the db here in the unit test.
}
```

The problem with this approach is that each test receives the database in whatever state the previous test left it. This can be problematic when trying to write atomic unit tests that don't interfere with each other. To force the `AppDbContext` to use a new database context for each test, supply a `DbContextOptions` instance that's based on a new service provider. The test app shows how to do this using its `Utilities` class method `TestingDbContextOptions` (*tests/RazorPagesTestingSample.Tests/Utilities/Utilities.cs*):

[!code-csharp[Main](razor-pages-testing/sample/tests/RazorPagesTestingSample.Tests/Utilities/Utilities.cs?name=snippet1)]

Using the `DbContextOptions` in the DAL unit tests allows each test to run atomically with a a fresh database instance:

```csharp
using (var db = new AppDbContext(Utilities.TestingDbContextOptions()))
{
    // Use the db here in the unit test.
}
```

Each test method in the `DataAccessLayerTest` class (*UnitTests/DataAccessLayerTest.cs*) follows a similar Arrange-Act-Assert pattern:

1. Arrange: The database is configured for the test and/or the expected outcome is defined.
1. Act: The test is executed.
1. Assert: Assertions are made to determine if the test result is a success.

For example, the `DeleteMessageAsync` method is responsible for removing a single message identified by its `Id` (*src/RazorPagesTestingSample/Data/AppDbContext.cs*):

[!code-csharp[Main](razor-pages-testing/sample/src/RazorPagesTestingSample/Data/AppDbContext.cs?name=snippet4)]

There are two tests for this method. One test checks that the method deletes a message when the message is present in the database. The other method tests that the database doesn't change if the message `Id` for deletion doesn't exist. The `DeleteMessageAsync_MessageIsDeleted_WhenMessageIsFound` method is shown below:

[!code-csharp[Main](razor-pages-testing/sample_snapshot/tests/RazorPagesTestingSample.Tests/UnitTests/DataAccessLayerTest.cs?name=snippet1)]

First, the method performs the Arrange step, where preparation for the Act step takes place. The seeding messages are obtained and held in `seedMessages`. The seeding messages are saved into the database. The message with an `Id` of `1` is set for deletion. When the `DeleteMessageAsync` method is executed, the expected messages should have all of the messages except for the one with an `Id` of `1`. The `expectedMessages` variable represents this expected outcome.

[!code-csharp[Main](razor-pages-testing/sample/tests/RazorPagesTestingSample.Tests/UnitTests/DataAccessLayerTest.cs?name=snippet1)]

The method acts: The `DeleteMessageAsync` method is executed passing in the `recId` of `1`:

[!code-csharp[Main](razor-pages-testing/sample/tests/RazorPagesTestingSample.Tests/UnitTests/DataAccessLayerTest.cs?name=snippet2)]

Finally, the method obtains the `Messages` from the context and compares it to the `expectedMessages` asserting that the two are equal:

[!code-csharp[Main](razor-pages-testing/sample/tests/RazorPagesTestingSample.Tests/UnitTests/DataAccessLayerTest.cs?name=snippet3)]

In order to compare that the two `List<Message>` are the same:

* The messages are ordered by `Id`.
* Message pairs are compared on the `Text` property.

A similar test method, `DeleteMessageAsync_NoMessageIsDeleted_WhenMessageIsNotFound` checks the result of attempting to delete a message that doesn't exist. In this case, the expected messages in the database should be equal to the actual messages after the `DeleteMessageAsync` method is executed. There should be no change to the database's content:

[!code-csharp[Main](razor-pages-testing/sample/tests/RazorPagesTestingSample.Tests/UnitTests/DataAccessLayerTest.cs?name=snippet4)]

## Unit testing the page model methods

Another set of unit tests is responsible for testing page model methods. In the message app, the Index page models are found in the `IndexModel` class in *src/RazorPagesTestingSample/Pages/Index.cshtml.cs*.

| Page model method | Function |
| ----------------- | -------- | 
| `OnGetAsync` | Obtains the messages from the DAL for the UI using the `GetMessagesAsync` method. |
| `OnPostAddMessageAsync` | If the `ModelState` is valid, calls `AddMessageAsync` to add a message to the database. | 
| `OnPostDeleteAllMessagesAsync` | Calls `DeleteAllMessagesAsync` to delete all of the messages in the database. |
| `OnPostDeleteMessageAsync` | Executes `DeleteMessageAsync` to delete a message with the `Id` specified. |
| `OnPostAnalyzeMessagesAsync` | If one or more messages are in the database, calculates the average number of words per message. |

The page model methods are tested using seven tests in the `IndexPageTest` class (*tests/RazorPagesTestingSample.Tests/UnitTests/IndexPageTest.cs*). The tests use the familiar Arrange-Assert-Act pattern. These tests focus on:

* Determining if the methods follow the correct behavior when the `ModelState` is invalid.
* Confirming the methods produce the correct `IActionResult`.
* Checking that property value assignments are made correctly.

This group of tests often mock the methods of the DAL to produce expected data for the Act step where a page model method is executed. For example, the `GetMessagesAsync` method of the `AppDbContext` is mocked to produce output. When a page model method executes this method, the mock returns the result. The data doesn't come from the database. This creates predictable, reliable test conditions for using the DAL in the page model tests.

The `OnGetAsync_PopulatesThePageModel_WithAListOfMessages` test shows how the `GetMessagesAsync` method is mocked for the page model:

[!code-csharp[Main](razor-pages-testing/sample/tests/RazorPagesTestingSample.Tests/UnitTests/IndexPageTest.cs?name=snippet1&highlight=3-4)]

When the `OnGetAsync` method is executed in the Act step, it calls the page model's `GetMessagesAsync` method.

Unit test Act step (*tests/RazorPagesTestingSample.Tests/UnitTests/IndexPageTest.cs*):

[!code-csharp[Main](razor-pages-testing/sample/tests/RazorPagesTestingSample.Tests/UnitTests/IndexPageTest.cs?name=snippet2)]

`IndexPage` page model's `OnGetAsync` method (*src/RazorPagesTestingSample/Pages/Index.cshtml.cs*):

[!code-csharp[Main](razor-pages-testing/sample/src/RazorPagesTestingSample/Pages/Index.cshtml.cs?name=snippet1&highlight=3)]

The `GetMessagesAsync` method in the DAL doesn't return the result for this method call. The mocked version of the method returns the result.

In the `Assert` step, the actual messages (`actualMessages`) are assigned from the `Messages` property of the page model. A type check is also performed when the messages are assigned. The expected and actual messages are compared by their `Text` properties. The test asserts that the two `List<Message>` instances contain the same messages.

[!code-csharp[Main](razor-pages-testing/sample/tests/RazorPagesTestingSample.Tests/UnitTests/IndexPageTest.cs?name=snippet3)]

Other tests in this group create page model objects that include the `DefaultHttpContext`, the `ModelStateDictionary`, an `ActionContext` to establish the `PageContext`, a `ViewDataDictionary`, and a `PageContext`. These are useful in conducting tests. For example, the message app establishes a `ModelState` error with `AddModelError` to check that a valid `PageResult` is returned when `OnPostAddMessageAsync` is executed:

[!code-csharp[Main](razor-pages-testing/sample/tests/RazorPagesTestingSample.Tests/UnitTests/IndexPageTest.cs?name=snippet4&highlight=11,26,29,32)]

## Integration testing the app

The integration tests focus on testing that the app's components work together. Integration tests are conducted using the [ASP.NET Core Test Host](xref:testing/integration-testing#the-test-host). Full request-response lifecycle processing is tested. These tests assert that the page produces the correct status code and `Location` header, if set.

An integration testing example from the sample checks the result of requesting the Index page of the message app (*tests/RazorPagesTestingSample.Tests/IntegrationTests/IndexPageTest.cs*):

[!code-csharp[Main](razor-pages-testing/sample/tests/RazorPagesTestingSample.Tests/IntegrationTests/IndexPageTest.cs?name=snippet1)]

There's no Arrange step. The `GetAsync` method is called on the `HttpClient` to send a GET request to the endpoint. The test asserts that the result is a 200-OK status code.

Any POST request to the message app must satisfy the antiforgery check that's automatically made by the app's [data protection antiforgery system](xref:security/data-protection/introduction). In order to arrange for a test's POST request, the test app must:

1. Make a request for the page.
1. Parse the antiforgery cookie and request validation token from the response.
1. Make the POST request with the antiforgery cookie and request validation token in place.

The `Post_AddMessageHandler_ReturnsRedirectToRoot` test method:

* Prepares a message and the `HttpClient`.
* Makes a POST request to the app.
* Checks the response is a redirect back to the Index page.

`Post_AddMessageHandler_ReturnsRedirectToRoot ` method (*tests/RazorPagesTestingSample.Tests/IntegrationTests/IndexPageTest.cs*):

[!code-csharp[Main](razor-pages-testing/sample/tests/RazorPagesTestingSample.Tests/IntegrationTests/IndexPageTest.cs?name=snippet2)]

The `GetRequestContentAsync` utility method manages preparing the client with the antiforgery cookie and request verification token. Note how the method receives an `IDictionary` that permits the calling test method to pass in data for the request to encode along with the request verification token (*tests/RazorPagesTestingSample.Tests/Utilities/Utilities.cs*):

[!code-csharp[Main](razor-pages-testing/sample/tests/RazorPagesTestingSample.Tests/Utilities/Utilities.cs?name=snippet2&highlight=1-2,8-9,29)]

Integration tests can also pass bad data to the app to test the app's response behavior. The message app limits message length to 200 characters (*src/RazorPagesTestingSample/Data/Message.cs*):

[!code-csharp[Main](razor-pages-testing/sample/src/RazorPagesTestingSample/Data/Message.cs?name=snippet1&highlight=7)]

The `Post_AddMessageHandler_ReturnsSuccess_WhenMessageTextTooLong` test `Message` explicitly passes in text with 201 "X" characters. This results in a `ModelState` error. The POST doesn't redirect back to the Index page. It returns a 200-OK with a `null` `Location` header (*tests/RazorPagesTestingSample.Tests/IntegrationTests/IndexPageTest.cs*):

[!code-csharp[Main](razor-pages-testing/sample/tests/RazorPagesTestingSample.Tests/IntegrationTests/IndexPageTest.cs?name=snippet3&highlight=7,16-17)]

## See also

* [Unit testing C# in .NET Core using dotnet test and xUnit](/dotnet/articles/core/testing/unit-testing-with-dotnet-test)
* [Integration testing](xref:testing/integration-testing)
* [Testing controllers](xref:mvc/controllers/testing)
* [Unit Test Your Code](/visualstudio/test/unit-test-your-code) (Visual Studio)
* [xUnit.net](https://xunit.github.io/)
* [Getting started with xUnit.net (.NET Core/ASP.NET Core)](https://xunit.github.io/docs/getting-started-dotnet-core)
* [Moq](https://github.com/moq/moq4)
* [Moq Quickstart](https://github.com/Moq/moq4/wiki/Quickstart)
