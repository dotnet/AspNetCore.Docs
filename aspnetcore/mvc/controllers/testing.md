---
title: Test controller logic in ASP.NET Core
author: ardalis
description: Learn how to test controller logic in ASP.NET Core with Moq and xUnit.
ms.author: riande
ms.custom: mvc
ms.date: 08/23/2018
uid: mvc/controllers/testing
---
# Test controller logic in ASP.NET Core

By [Steve Smith](https://ardalis.com/)

[Controllers](xref:mvc/controllers/actions) play a central role in any ASP.NET Core MVC app. As such, you should have confidence that controllers behave as intended. Automated tests can detect errors before the app is deployed to a production environment.

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/mvc/controllers/testing/sample) ([how to download](xref:tutorials/index#how-to-download-a-sample))

## Unit tests of controller logic

[Unit tests](/dotnet/articles/core/testing/unit-testing-with-dotnet-test) involve testing a part of an app in isolation from its infrastructure and dependencies. When unit testing controller logic, only the contents of a single action are tested, not the behavior of its dependencies or of the framework itself.

Set up unit tests of controller actions to focus on the controller's behavior. A controller unit test avoids scenarios such as [filters](xref:mvc/controllers/filters), [routing](xref:fundamentals/routing), and [model binding](xref:mvc/models/model-binding). Tests that cover the interactions among components that collectively respond to a request are handled by *integration tests*. For more information on integration tests, see <xref:test/integration-tests>.

If you're writing custom filters and routes, unit test them in isolation, not as part of tests on a particular controller action.

> [!TIP]
> [Create and run unit tests with Visual Studio](/visualstudio/test/unit-test-your-code).

To demonstrate controller unit tests, review the following controller in the sample app. The Home controller displays a list of brainstorming sessions and allows the creation of new brainstorming sessions with a POST request:

[!code-csharp[](testing/sample/TestingControllersSample/src/TestingControllersSample/Controllers/HomeController.cs?name=snippet_HomeController&highlight=1,5,10,31-32)]

The controller follows the [Explicit Dependencies Principle](/dotnet/standard/modern-web-apps-azure-architecture/architectural-principles#explicit-dependencies). The controller expects [dependency injection (DI)](xref:fundamentals/dependency-injection) to provide an instance of `IBrainstormSessionRepository`. The controller can be tested with a mocked `IBrainstormSessionRepository` service using a mock object framework, such as [Moq](https://www.nuget.org/packages/Moq/).

The `HTTP GET Index` method has no looping or branching and only calls one method. The test for this action:

* Mocks the `IBrainstormSessionRepository` service using the `GetTestSessions` method. `GetTestSessions` creates two mock brainstorm sessions with dates and session names.
* Executes the `Index` method.
* Makes assertions on the result returned by the method:
  * A <xref:Microsoft.AspNetCore.Mvc.ViewResult> is returned.
  * The [ViewDataDictionary.Model](xref:Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary.Model*) is a `StormSessionViewModel`.
  * There are two brainstorming sessions stored in the `ViewDataDictionary.Model`.

[!code-csharp[](testing/sample/TestingControllersSample/tests/TestingControllersSample.Tests/UnitTests/HomeControllerTests.cs?name=snippet_Index_ReturnsAViewResult_WithAListOfBrainstormSessions&highlight=14-17)]

[!code-csharp[](testing/sample/TestingControllersSample/tests/TestingControllersSample.Tests/UnitTests/HomeControllerTests.cs?name=snippet_GetTestSessions)]

The Home controller's `HTTP POST Index` method tests verifies that:

* The action method returns a Bad Request <xref:Microsoft.AspNetCore.Mvc.ViewResult> with the appropriate data when [ModelState.IsValid](xref:Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.IsValid*) is `false`.
* When `ModelState.IsValid` is `true`:
  * The `Add` method on the repository is called.
  * A <xref:Microsoft.AspNetCore.Mvc.RedirectToActionResult> is returned with the correct arguments.

An invalid model state is tested by adding errors using <xref:Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.AddModelError*> as shown in the first test below:

[!code-csharp[](testing/sample/TestingControllersSample/tests/TestingControllersSample.Tests/UnitTests/HomeControllerTests.cs?name=snippet_ModelState_ValidOrInvalid&highlight=9,16-17,38-41)]

When [ModelState](xref:Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary) isn't valid, the same `ViewResult` is returned as for a GET request. The test doesn't attempt to pass in an invalid model. Passing an invalid model isn't a valid approach, since model binding isn't running (although an [integration test](xref:test/integration-tests) does use model binding). In this case, model binding isn't tested. These unit tests are only testing the code in the action method.

The second test verifies that when the `ModelState` is valid:

* A new `BrainstormSession` is added (via the [repository](xref:fundamentals/repository-pattern)).
* The method returns a `RedirectToActionResult` with the expected properties.

Mocked calls that aren't called are normally ignored, but calling `Verifiable` at the end of the setup call allows mock validation in the test. This is performed with the call to `mockRepo.Verify`, which fails the test if the expected method wasn't called.

> [!NOTE]
> The Moq library used in this sample makes it possible to mix verifiable, or "strict", mocks with non-verifiable mocks (also called "loose" mocks or stubs). Learn more about [customizing Mock behavior with Moq](https://github.com/Moq/moq4/wiki/Quickstart#customizing-mock-behavior).

Another controller in the sample app displays information related to a particular brainstorming session. The controller includes logic to deal with invalid `id` values (there are two `return` scenarios in the following example to cover these scenarios). The final `return` statement returns a new `StormSessionViewModel` to the view:

[!code-csharp[](testing/sample/TestingControllersSample/src/TestingControllersSample/Controllers/SessionController.cs?name=snippet_SessionController&highlight=12-16,18-22,31)]

The unit tests include one test for each `return` scenario in the Session controller `Index` action:

[!code-csharp[](testing/sample/TestingControllersSample/tests/TestingControllersSample.Tests/UnitTests/SessionControllerTests.cs?name=snippet_SessionControllerTests&highlight=2,11-14,18,31-32,36,50-55)]

Moving to the Ideas controller, the app exposes functionality as a Web API on the `api/ideas` route:

* A list of ideas (`IdeaDTO`) associated with a brainstorming session is returned by the `ForSession` method.
* The `Create` method adds new ideas to a session.

[!code-csharp[](testing/sample/TestingControllersSample/src/TestingControllersSample/Api/IdeasController.cs?name=snippet_ForSessionAndCreate&highlight=1-2,21-22)]

Avoid returning business domain entities directly via API calls:

* Domain entities often include more data than the client requires.
* Domain entities unnecessarily couple the app's internal domain model with the publicly exposed API.

Mapping between domain entities and the types returned to the client can be performed manually using:

* A LINQ `Select`, as the sample app uses.
* A library such as [AutoMapper](https://github.com/AutoMapper/AutoMapper).

Next, the sample app demonstrates unit tests for the `Create` and `ForSession` API methods of the Ideas controller.

The sample app contains two `ForSession` tests. The first test determines if `ForSession` returns a <xref:Microsoft.AspNetCore.Mvc.NotFoundObjectResult> (HTTP Not Found) for an invalid session:

[!code-csharp[](testing/sample/TestingControllersSample/tests/TestingControllersSample.Tests/UnitTests/ApiIdeasControllerTests.cs?name=snippet_ApiIdeasControllerTests4&highlight=5,7-8,15-16)]

The second `ForSession` test determines if `ForSession` returns a list of session ideas (`<List<IdeaDTO>>`) for a valid session. The checks also examine the first idea to confirm its `Name` property is correct:

[!code-csharp[](testing/sample/TestingControllersSample/tests/TestingControllersSample.Tests/UnitTests/ApiIdeasControllerTests.cs?name=snippet_ApiIdeasControllerTests5&highlight=5,7-8,15-18)]

To test the behavior of the `Create` method when the `ModelState` is invalid, the sample app adds a model error to the controller as part of the test. Don't try to test model validation or model binding in unit tests&mdash;just test the action method's behavior when confronted with an invalid `ModelState`:

[!code-csharp[](testing/sample/TestingControllersSample/tests/TestingControllersSample.Tests/UnitTests/ApiIdeasControllerTests.cs?name=snippet_ApiIdeasControllerTests1&highlight=7,13)]

The second test of `Create` depends on the repository returning `null`, so the mock repository is configured to return `null`. There's no need to create a test database (in memory or otherwise) and construct a query that returns this result. The test can be accomplished in a single statement, as the sample code illustrates:

[!code-csharp[](testing/sample/TestingControllersSample/tests/TestingControllersSample.Tests/UnitTests/ApiIdeasControllerTests.cs?name=snippet_ApiIdeasControllerTests2&highlight=7-8,15)]

The third `Create` test, `Create_ReturnsNewlyCreatedIdeaForSession`, verifies that the repository's `Update` method is called. The mock is called with `Verifiable`, and the mocked repository's `Verify` method is called to confirm the verifiable method is executed. It's not a unit test responsibility to ensure that the `Update` method saved the data&mdash;that can be performed with an integration test.

[!code-csharp[](testing/sample/TestingControllersSample/tests/TestingControllersSample.Tests/UnitTests/ApiIdeasControllerTests.cs?name=snippet_ApiIdeasControllerTests3&highlight=5-11,14-22,28-33)]

::: moniker range=">= aspnetcore-2.1"

In ASP.NET Core 2.1 or later, [ActionResult&lt;T&gt; type](xref:web-api/action-return-types#actionresultt-type) (<xref:Microsoft.AspNetCore.Mvc.ActionResult`1>) enables you to return a type deriving from `ActionResult` or return a specific type. The sample app includes a method that returns a `List<IdeaDTO>` for a given session `id`:

[!code-csharp[](testing/sample/TestingControllersSample/src/TestingControllersSample/Api/IdeasController.cs?name=snippet_ActionResult&highlight=4,11-17,19)]

Two tests of the `ForSessionActionResult` controller are included in the `ApiIdeasControllerTests`. The first test confirms that the method returns an `ActionResult`, session, and idea for a valid session `id`:

* The `ActionResult` type is `ActionResult<List<IdeaDTO>>`.
* The value of the `ActionResult` is a `List<IdeaDTO>`.
* The first item in the list is a valid `IdeaDTO` matching the idea added to the mock session.

[!code-csharp[](testing/sample/TestingControllersSample/tests/TestingControllersSample.Tests/UnitTests/ApiIdeasControllerTests.cs?name=snippet_ActionResult&highlight=15-18)]

The second test confirms that the controller returns an `ActionResult` but not a nonexistent session for a bad session `id`:

* The `ActionResult` type is `ActionResult<List<IdeaDTO>>`.
* The `ActionResult.Result` is a <xref:Microsoft.AspNetCore.Mvc.NotFoundObjectResult>.

[!code-csharp[](testing/sample/TestingControllersSample/tests/TestingControllersSample.Tests/UnitTests/ApiIdeasControllerTests.cs?name=snippet_ActionResultNotFoundObjectResult&highlight=7,10,13-14)]

::: moniker-end

## Additional resources

* <xref:test/index>
* <xref:test/integration-tests>
* [Explicit Dependencies Principle](http://deviq.com/explicit-dependencies-principle/)
* <xref:fundamentals/repository-pattern>
