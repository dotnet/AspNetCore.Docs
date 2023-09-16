---
title: Razor Pages unit tests in ASP.NET Core
author: rick-anderson
description: Learn how to create unit tests for Razor Pages apps.
monikerRange: '>= aspnetcore-2.1'
ms.author: riande
ms.custom: mvc
ms.date: 7/30/2020
uid: test/razor-pages-tests
---
# Razor Pages unit tests in ASP.NET Core

:::moniker range=">= aspnetcore-3.0"

ASP.NET Core supports unit tests of Razor Pages apps. Tests of the data access layer (DAL) and page models help ensure:

* Parts of a Razor Pages app work independently and together as a unit during app construction.
* Classes and methods have limited scopes of responsibility.
* Additional documentation exists on how the app should behave.
* Regressions, which are errors brought about by updates to the code, are found during automated building and deployment.

This topic assumes that you have a basic understanding of Razor Pages apps and unit tests. If you're unfamiliar with Razor Pages apps or test concepts, see the following topics:

* <xref:razor-pages/index>
* <xref:tutorials/razor-pages/razor-pages-start>
* [Unit testing C# in .NET Core using dotnet test and xUnit](/dotnet/articles/core/testing/unit-testing-with-dotnet-test)

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/test/razor-pages-tests/samples) ([how to download](xref:index#how-to-download-a-sample))

The sample project is composed of two apps:

| App         | Project folder                     | Description |
| ----------- | ---------------------------------- | ----------- |
| Message app | *src/RazorPagesTestSample*         | Allows a user to add a message, delete one message, delete all messages, and analyze messages (find the average number of words per message). |
| Test app    | *tests/RazorPagesTestSample.Tests* | Used to unit test the DAL and Index page model of the message app. |

The tests can be run using the built-in test features of an IDE, such as [Visual Studio](/visualstudio/test/unit-test-your-code). If using [Visual Studio Code](https://code.visualstudio.com/) or the command line, execute the following command at a command prompt in the *tests/RazorPagesTestSample.Tests* folder:

```dotnetcli
dotnet test
```

## Message app organization

The message app is a Razor Pages message system with the following characteristics:

* The Index page of the app (`Pages/Index.cshtml` and `Pages/Index.cshtml.cs`) provides a UI and page model methods to control the addition, deletion, and analysis of messages (find the average number of words per message).
* A message is described by the `Message` class (`Data/Message.cs`) with two properties: `Id` (key) and `Text` (message). The `Text` property is required and limited to 200 characters.
* Messages are stored using [Entity Framework's in-memory database](/ef/core/providers/in-memory/)&#8224;.
* The app contains a DAL in its database context class, `AppDbContext` (`Data/AppDbContext.cs`). The DAL methods are marked `virtual`, which allows mocking the methods for use in the tests.
* If the database is empty on app startup, the message store is initialized with three messages. These *seeded messages* are also used in tests.

&#8224;The EF topic, [Test with InMemory](/ef/core/miscellaneous/testing/in-memory), explains how to use an in-memory database for tests with MSTest. This topic uses the [xUnit](https://github.com/xunit/xunit) test framework. Test concepts and test implementations across different test frameworks are similar but not identical.

Although the sample app doesn't use the repository pattern and isn't an effective example of the [Unit of Work (UoW) pattern](https://martinfowler.com/eaaCatalog/unitOfWork.html), Razor Pages supports these patterns of development. For more information, see [Designing the infrastructure persistence layer](/dotnet/standard/microservices-architecture/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-design) and <xref:mvc/controllers/testing> (the sample implements the repository pattern).

## Test app organization

The test app is a console app inside the *tests/RazorPagesTestSample.Tests* folder.

| Test app folder | Description |
| --------------- | ----------- |
| *UnitTests*     | <ul><li>`DataAccessLayerTest.cs` contains the unit tests for the DAL.</li><li>`IndexPageTests.cs` contains the unit tests for the Index page model.</li></ul> |
| *Utilities*     | Contains the `TestDbContextOptions` method used to create new database context options for each DAL unit test so that the database is reset to its baseline condition for each test. |

The test framework is [xUnit](https://github.com/xunit/xunit). The object mocking framework is [Moq](https://github.com/moq/moq4).

## Unit tests of the data access layer (DAL)

The message app has a DAL with four methods contained in the `AppDbContext` class (`src/RazorPagesTestSample/Data/AppDbContext.cs`). Each method has one or two unit tests in the test app.

| DAL method               | Function                                                                   |
| ------------------------ | -------------------------------------------------------------------------- |
| `GetMessagesAsync`       | Obtains a `List<Message>` from the database sorted by the `Text` property. |
| `AddMessageAsync`        | Adds a `Message` to the database.                                          |
| `DeleteAllMessagesAsync` | Deletes all `Message` entries from the database.                           |
| `DeleteMessageAsync`     | Deletes a single `Message` from the database by `Id`.                      |

Unit tests of the DAL require <xref:Microsoft.EntityFrameworkCore.DbContextOptions> when creating a new `AppDbContext` for each test. One approach to creating the `DbContextOptions` for each test is to use a <xref:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder>:

```csharp
var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>()
    .UseInMemoryDatabase("InMemoryDb");

using (var db = new AppDbContext(optionsBuilder.Options))
{
    // Use the db here in the unit test.
}
```

The problem with this approach is that each test receives the database in whatever state the previous test left it. This can be problematic when trying to write atomic unit tests that don't interfere with each other. To force the `AppDbContext` to use a new database context for each test, supply a `DbContextOptions` instance that's based on a new service provider. The test app shows how to do this using its `Utilities` class method `TestDbContextOptions` (`tests/RazorPagesTestSample.Tests/Utilities/Utilities.cs`):

[!code-csharp[](razor-pages-tests/samples/3.x/tests/RazorPagesTestSample.Tests/Utilities/Utilities.cs?name=snippet1)]

Using the `DbContextOptions` in the DAL unit tests allows each test to run atomically with a fresh database instance:

```csharp
using (var db = new AppDbContext(Utilities.TestDbContextOptions()))
{
    // Use the db here in the unit test.
}
```

Each test method in the `DataAccessLayerTest` class (`UnitTests/DataAccessLayerTest.cs`) follows a similar Arrange-Act-Assert pattern:

1. Arrange: The database is configured for the test and/or the expected outcome is defined.
1. Act: The test is executed.
1. Assert: Assertions are made to determine if the test result is a success.

For example, the `DeleteMessageAsync` method is responsible for removing a single message identified by its `Id` (`src/RazorPagesTestSample/Data/AppDbContext.cs`):

[!code-csharp[](razor-pages-tests/samples/3.x/src/RazorPagesTestSample/Data/AppDbContext.cs?name=snippet4)]

There are two tests for this method. One test checks that the method deletes a message when the message is present in the database. The other method tests that the database doesn't change if the message `Id` for deletion doesn't exist. The `DeleteMessageAsync_MessageIsDeleted_WhenMessageIsFound` method is shown below:

[!code-csharp[](razor-pages-tests/samples_snapshot/3.x/tests/RazorPagesTestSample.Tests/UnitTests/DataAccessLayerTest.cs?name=snippet1)]

First, the method performs the Arrange step, where preparation for the Act step takes place. The seeding messages are obtained and held in `seedMessages`. The seeding messages are saved into the database. The message with an `Id` of `1` is set for deletion. When the `DeleteMessageAsync` method is executed, the expected messages should have all of the messages except for the one with an `Id` of `1`. The `expectedMessages` variable represents this expected outcome.

[!code-csharp[](razor-pages-tests/samples/3.x/tests/RazorPagesTestSample.Tests/UnitTests/DataAccessLayerTest.cs?name=snippet1)]

The method acts: The `DeleteMessageAsync` method is executed passing in the `recId` of `1`:

[!code-csharp[](razor-pages-tests/samples/3.x/tests/RazorPagesTestSample.Tests/UnitTests/DataAccessLayerTest.cs?name=snippet2)]

Finally, the method obtains the `Messages` from the context and compares it to the `expectedMessages` asserting that the two are equal:

[!code-csharp[](razor-pages-tests/samples/3.x/tests/RazorPagesTestSample.Tests/UnitTests/DataAccessLayerTest.cs?name=snippet3)]

In order to compare that the two `List<Message>` are the same:

* The messages are ordered by `Id`.
* Message pairs are compared on the `Text` property.

A similar test method, `DeleteMessageAsync_NoMessageIsDeleted_WhenMessageIsNotFound` checks the result of attempting to delete a message that doesn't exist. In this case, the expected messages in the database should be equal to the actual messages after the `DeleteMessageAsync` method is executed. There should be no change to the database's content:

[!code-csharp[](razor-pages-tests/samples/3.x/tests/RazorPagesTestSample.Tests/UnitTests/DataAccessLayerTest.cs?name=snippet4)]

## Unit tests of the page model methods

Another set of unit tests is responsible for tests of page model methods. In the message app, the Index page models are found in the `IndexModel` class in `src/RazorPagesTestSample/Pages/Index.cshtml.cs`.

| Page model method | Function |
| ----------------- | -------- |
| `OnGetAsync` | Obtains the messages from the DAL for the UI using the `GetMessagesAsync` method. |
| `OnPostAddMessageAsync` | If the [ModelState](xref:Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary) is valid, calls `AddMessageAsync` to add a message to the database. |
| `OnPostDeleteAllMessagesAsync` | Calls `DeleteAllMessagesAsync` to delete all of the messages in the database. |
| `OnPostDeleteMessageAsync` | Executes `DeleteMessageAsync` to delete a message with the `Id` specified. |
| `OnPostAnalyzeMessagesAsync` | If one or more messages are in the database, calculates the average number of words per message. |

The page model methods are tested using seven tests in the `IndexPageTests` class (`tests/RazorPagesTestSample.Tests/UnitTests/IndexPageTests.cs`). The tests use the familiar Arrange-Assert-Act pattern. These tests focus on:

* Determining if the methods follow the correct behavior when the [ModelState](xref:Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary) is invalid.
* Confirming the methods produce the correct <xref:Microsoft.AspNetCore.Mvc.IActionResult>.
* Checking that property value assignments are made correctly.

This group of tests often mock the methods of the DAL to produce expected data for the Act step where a page model method is executed. For example, the `GetMessagesAsync` method of the `AppDbContext` is mocked to produce output. When a page model method executes this method, the mock returns the result. The data doesn't come from the database. This creates predictable, reliable test conditions for using the DAL in the page model tests.

The `OnGetAsync_PopulatesThePageModel_WithAListOfMessages` test shows how the `GetMessagesAsync` method is mocked for the page model:

[!code-csharp[](razor-pages-tests/samples/3.x/tests/RazorPagesTestSample.Tests/UnitTests/IndexPageTests.cs?name=snippet1&highlight=3-4)]

When the `OnGetAsync` method is executed in the Act step, it calls the page model's `GetMessagesAsync` method.

Unit test Act step (`tests/RazorPagesTestSample.Tests/UnitTests/IndexPageTests.cs`):

[!code-csharp[](razor-pages-tests/samples/3.x/tests/RazorPagesTestSample.Tests/UnitTests/IndexPageTests.cs?name=snippet2)]

`IndexPage` page model's `OnGetAsync` method (`src/RazorPagesTestSample/Pages/Index.cshtml.cs`):

[!code-csharp[](razor-pages-tests/samples/3.x/src/RazorPagesTestSample/Pages/Index.cshtml.cs?name=snippet1&highlight=3)]

The `GetMessagesAsync` method in the DAL doesn't return the result for this method call. The mocked version of the method returns the result.

In the `Assert` step, the actual messages (`actualMessages`) are assigned from the `Messages` property of the page model. A type check is also performed when the messages are assigned. The expected and actual messages are compared by their `Text` properties. The test asserts that the two `List<Message>` instances contain the same messages.

[!code-csharp[](razor-pages-tests/samples/3.x/tests/RazorPagesTestSample.Tests/UnitTests/IndexPageTests.cs?name=snippet3)]

Other tests in this group create page model objects that include the <xref:Microsoft.AspNetCore.Http.DefaultHttpContext>, the <xref:Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary>, an <xref:Microsoft.AspNetCore.Mvc.ActionContext> to establish the `PageContext`, a `ViewDataDictionary`, and a `PageContext`. These are useful in conducting tests. For example, the message app establishes a `ModelState` error with <xref:Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.AddModelError%2A> to check that a valid <xref:Microsoft.AspNetCore.Mvc.RazorPages.PageResult> is returned when `OnPostAddMessageAsync` is executed:

[!code-csharp[](razor-pages-tests/samples/3.x/tests/RazorPagesTestSample.Tests/UnitTests/IndexPageTests.cs?name=snippet4&highlight=11,26,29,32)]

## Additional resources

* [Unit testing C# in .NET Core using dotnet test and xUnit](/dotnet/articles/core/testing/unit-testing-with-dotnet-test)
* <xref:mvc/controllers/testing>
* [Unit Test Your Code](/visualstudio/test/unit-test-your-code) (Visual Studio)
* <xref:test/integration-tests>
* [xUnit.net](https://github.com/xunit/xunit)
* [Getting started with xUnit.net: Using .NET Core with the .NET SDK command line](https://xunit.net/docs/getting-started/netcore/cmdline)
* [Moq](https://github.com/moq/moq4)
* [Moq Quickstart](https://github.com/Moq/moq4/wiki/Quickstart)

:::moniker-end

:::moniker range="< aspnetcore-3.0"

ASP.NET Core supports unit tests of Razor Pages apps. Tests of the data access layer (DAL) and page models help ensure:

* Parts of a Razor Pages app work independently and together as a unit during app construction.
* Classes and methods have limited scopes of responsibility.
* Additional documentation exists on how the app should behave.
* Regressions, which are errors brought about by updates to the code, are found during automated building and deployment.

This topic assumes that you have a basic understanding of Razor Pages apps and unit tests. If you're unfamiliar with Razor Pages apps or test concepts, see the following topics:

* <xref:razor-pages/index>
* <xref:tutorials/razor-pages/razor-pages-start>
* [Unit testing C# in .NET Core using dotnet test and xUnit](/dotnet/articles/core/testing/unit-testing-with-dotnet-test)

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/test/razor-pages-tests/samples) ([how to download](xref:index#how-to-download-a-sample))

The sample project is composed of two apps:

| App         | Project folder                     | Description |
| ----------- | ---------------------------------- | ----------- |
| Message app | *src/RazorPagesTestSample*         | Allows a user to add a message, delete one message, delete all messages, and analyze messages (find the average number of words per message). |
| Test app    | *tests/RazorPagesTestSample.Tests* | Used to unit test the DAL and Index page model of the message app. |

The tests can be run using the built-in test features of an IDE, such as [Visual Studio](/visualstudio/test/unit-test-your-code). If using [Visual Studio Code](https://code.visualstudio.com/) or the command line, execute the following command at a command prompt in the *tests/RazorPagesTestSample.Tests* folder:

```dotnetcli
dotnet test
```

## Message app organization

The message app is a Razor Pages message system with the following characteristics:

* The Index page of the app (`Pages/Index.cshtml` and `Pages/Index.cshtml.cs`) provides a UI and page model methods to control the addition, deletion, and analysis of messages (find the average number of words per message).
* A message is described by the `Message` class (`Data/Message.cs`) with two properties: `Id` (key) and `Text` (message). The `Text` property is required and limited to 200 characters.
* Messages are stored using [Entity Framework's in-memory database](/ef/core/providers/in-memory/)&#8224;.
* The app contains a DAL in its database context class, `AppDbContext` (`Data/AppDbContext.cs`). The DAL methods are marked `virtual`, which allows mocking the methods for use in the tests.
* If the database is empty on app startup, the message store is initialized with three messages. These *seeded messages* are also used in tests.

&#8224;The EF topic, [Test with InMemory](/ef/core/miscellaneous/testing/in-memory), explains how to use an in-memory database for tests with MSTest. This topic uses the [xUnit](https://github.com/xunit/xunit) test framework. Test concepts and test implementations across different test frameworks are similar but not identical.

Although the sample app doesn't use the repository pattern and isn't an effective example of the [Unit of Work (UoW) pattern](https://martinfowler.com/eaaCatalog/unitOfWork.html), Razor Pages supports these patterns of development. For more information, see [Designing the infrastructure persistence layer](/dotnet/standard/microservices-architecture/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-design) and <xref:mvc/controllers/testing> (the sample implements the repository pattern).

## Test app organization

The test app is a console app inside the *tests/RazorPagesTestSample.Tests* folder.

| Test app folder | Description |
| --------------- | ----------- |
| *UnitTests*     | <ul><li>`DataAccessLayerTest.cs` contains the unit tests for the DAL.</li><li>`IndexPageTests.cs` contains the unit tests for the Index page model.</li></ul> |
| *Utilities*     | Contains the `TestDbContextOptions` method used to create new database context options for each DAL unit test so that the database is reset to its baseline condition for each test. |

The test framework is [xUnit](https://github.com/xunit/xunit). The object mocking framework is [Moq](https://github.com/moq/moq4).

## Unit tests of the data access layer (DAL)

The message app has a DAL with four methods contained in the `AppDbContext` class (`src/RazorPagesTestSample/Data/AppDbContext.cs`). Each method has one or two unit tests in the test app.

| DAL method               | Function                                                                   |
| ------------------------ | -------------------------------------------------------------------------- |
| `GetMessagesAsync`       | Obtains a `List<Message>` from the database sorted by the `Text` property. |
| `AddMessageAsync`        | Adds a `Message` to the database.                                          |
| `DeleteAllMessagesAsync` | Deletes all `Message` entries from the database.                           |
| `DeleteMessageAsync`     | Deletes a single `Message` from the database by `Id`.                      |

Unit tests of the DAL require <xref:Microsoft.EntityFrameworkCore.DbContextOptions> when creating a new `AppDbContext` for each test. One approach to creating the `DbContextOptions` for each test is to use a <xref:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder>:

```csharp
var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>()
    .UseInMemoryDatabase("InMemoryDb");

using (var db = new AppDbContext(optionsBuilder.Options))
{
    // Use the db here in the unit test.
}
```

The problem with this approach is that each test receives the database in whatever state the previous test left it. This can be problematic when trying to write atomic unit tests that don't interfere with each other. To force the `AppDbContext` to use a new database context for each test, supply a `DbContextOptions` instance that's based on a new service provider. The test app shows how to do this using its `Utilities` class method `TestDbContextOptions` (`tests/RazorPagesTestSample.Tests/Utilities/Utilities.cs`):

[!code-csharp[](razor-pages-tests/samples/2.x/tests/RazorPagesTestSample.Tests/Utilities/Utilities.cs?name=snippet1)]

Using the `DbContextOptions` in the DAL unit tests allows each test to run atomically with a fresh database instance:

```csharp
using (var db = new AppDbContext(Utilities.TestDbContextOptions()))
{
    // Use the db here in the unit test.
}
```

Each test method in the `DataAccessLayerTest` class (`UnitTests/DataAccessLayerTest.cs`) follows a similar Arrange-Act-Assert pattern:

1. Arrange: The database is configured for the test and/or the expected outcome is defined.
1. Act: The test is executed.
1. Assert: Assertions are made to determine if the test result is a success.

For example, the `DeleteMessageAsync` method is responsible for removing a single message identified by its `Id` (`src/RazorPagesTestSample/Data/AppDbContext.cs`):

[!code-csharp[](razor-pages-tests/samples/2.x/src/RazorPagesTestSample/Data/AppDbContext.cs?name=snippet4)]

There are two tests for this method. One test checks that the method deletes a message when the message is present in the database. The other method tests that the database doesn't change if the message `Id` for deletion doesn't exist. The `DeleteMessageAsync_MessageIsDeleted_WhenMessageIsFound` method is shown below:

[!code-csharp[](razor-pages-tests/samples_snapshot/2.x/tests/RazorPagesTestSample.Tests/UnitTests/DataAccessLayerTest.cs?name=snippet1)]

First, the method performs the Arrange step, where preparation for the Act step takes place. The seeding messages are obtained and held in `seedMessages`. The seeding messages are saved into the database. The message with an `Id` of `1` is set for deletion. When the `DeleteMessageAsync` method is executed, the expected messages should have all of the messages except for the one with an `Id` of `1`. The `expectedMessages` variable represents this expected outcome.

[!code-csharp[](razor-pages-tests/samples/2.x/tests/RazorPagesTestSample.Tests/UnitTests/DataAccessLayerTest.cs?name=snippet1)]

The method acts: The `DeleteMessageAsync` method is executed passing in the `recId` of `1`:

[!code-csharp[](razor-pages-tests/samples/2.x/tests/RazorPagesTestSample.Tests/UnitTests/DataAccessLayerTest.cs?name=snippet2)]

Finally, the method obtains the `Messages` from the context and compares it to the `expectedMessages` asserting that the two are equal:

[!code-csharp[](razor-pages-tests/samples/2.x/tests/RazorPagesTestSample.Tests/UnitTests/DataAccessLayerTest.cs?name=snippet3)]

In order to compare that the two `List<Message>` are the same:

* The messages are ordered by `Id`.
* Message pairs are compared on the `Text` property.

A similar test method, `DeleteMessageAsync_NoMessageIsDeleted_WhenMessageIsNotFound` checks the result of attempting to delete a message that doesn't exist. In this case, the expected messages in the database should be equal to the actual messages after the `DeleteMessageAsync` method is executed. There should be no change to the database's content:

[!code-csharp[](razor-pages-tests/samples/2.x/tests/RazorPagesTestSample.Tests/UnitTests/DataAccessLayerTest.cs?name=snippet4)]

## Unit tests of the page model methods

Another set of unit tests is responsible for tests of page model methods. In the message app, the Index page models are found in the `IndexModel` class in `src/RazorPagesTestSample/Pages/Index.cshtml.cs`.

| Page model method | Function |
| ----------------- | -------- |
| `OnGetAsync` | Obtains the messages from the DAL for the UI using the `GetMessagesAsync` method. |
| `OnPostAddMessageAsync` | If the [ModelState](xref:Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary) is valid, calls `AddMessageAsync` to add a message to the database. |
| `OnPostDeleteAllMessagesAsync` | Calls `DeleteAllMessagesAsync` to delete all of the messages in the database. |
| `OnPostDeleteMessageAsync` | Executes `DeleteMessageAsync` to delete a message with the `Id` specified. |
| `OnPostAnalyzeMessagesAsync` | If one or more messages are in the database, calculates the average number of words per message. |

The page model methods are tested using seven tests in the `IndexPageTests` class (`tests/RazorPagesTestSample.Tests/UnitTests/IndexPageTests.cs`). The tests use the familiar Arrange-Assert-Act pattern. These tests focus on:

* Determining if the methods follow the correct behavior when the [ModelState](xref:Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary) is invalid.
* Confirming the methods produce the correct <xref:Microsoft.AspNetCore.Mvc.IActionResult>.
* Checking that property value assignments are made correctly.

This group of tests often mock the methods of the DAL to produce expected data for the Act step where a page model method is executed. For example, the `GetMessagesAsync` method of the `AppDbContext` is mocked to produce output. When a page model method executes this method, the mock returns the result. The data doesn't come from the database. This creates predictable, reliable test conditions for using the DAL in the page model tests.

The `OnGetAsync_PopulatesThePageModel_WithAListOfMessages` test shows how the `GetMessagesAsync` method is mocked for the page model:

[!code-csharp[](razor-pages-tests/samples/2.x/tests/RazorPagesTestSample.Tests/UnitTests/IndexPageTests.cs?name=snippet1&highlight=3-4)]

When the `OnGetAsync` method is executed in the Act step, it calls the page model's `GetMessagesAsync` method.

Unit test Act step (`tests/RazorPagesTestSample.Tests/UnitTests/IndexPageTests.cs`):

[!code-csharp[](razor-pages-tests/samples/2.x/tests/RazorPagesTestSample.Tests/UnitTests/IndexPageTests.cs?name=snippet2)]

`IndexPage` page model's `OnGetAsync` method (`src/RazorPagesTestSample/Pages/Index.cshtml.cs`):

[!code-csharp[](razor-pages-tests/samples/2.x/src/RazorPagesTestSample/Pages/Index.cshtml.cs?name=snippet1&highlight=3)]

The `GetMessagesAsync` method in the DAL doesn't return the result for this method call. The mocked version of the method returns the result.

In the `Assert` step, the actual messages (`actualMessages`) are assigned from the `Messages` property of the page model. A type check is also performed when the messages are assigned. The expected and actual messages are compared by their `Text` properties. The test asserts that the two `List<Message>` instances contain the same messages.

[!code-csharp[](razor-pages-tests/samples/2.x/tests/RazorPagesTestSample.Tests/UnitTests/IndexPageTests.cs?name=snippet3)]

Other tests in this group create page model objects that include the <xref:Microsoft.AspNetCore.Http.DefaultHttpContext>, the <xref:Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary>, an <xref:Microsoft.AspNetCore.Mvc.ActionContext> to establish the `PageContext`, a `ViewDataDictionary`, and a `PageContext`. These are useful in conducting tests. For example, the message app establishes a `ModelState` error with <xref:Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.AddModelError%2A> to check that a valid <xref:Microsoft.AspNetCore.Mvc.RazorPages.PageResult> is returned when `OnPostAddMessageAsync` is executed:

[!code-csharp[](razor-pages-tests/samples/2.x/tests/RazorPagesTestSample.Tests/UnitTests/IndexPageTests.cs?name=snippet4&highlight=11,26,29,32)]

## Additional resources

* [Unit testing C# in .NET Core using dotnet test and xUnit](/dotnet/articles/core/testing/unit-testing-with-dotnet-test)
* <xref:mvc/controllers/testing>
* [Unit Test Your Code](/visualstudio/test/unit-test-your-code) (Visual Studio)
* <xref:test/integration-tests>
* [xUnit.net](https://github.com/xunit/xunit)
* [Getting started with xUnit.net: Using .NET Core with the .NET SDK command line](https://xunit.net/docs/getting-started/netcore/cmdline)
* [Moq](https://github.com/moq/moq4)
* [Moq Quickstart](https://github.com/Moq/moq4/wiki/Quickstart)
* [JustMockLite](https://github.com/telerik/JustMockLite): A mocking framework for .NET developers. (*Not maintained or supported by Microsoft.*)

:::moniker-end
