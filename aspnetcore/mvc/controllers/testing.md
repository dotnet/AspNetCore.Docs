---
title: Test controller logic in ASP.NET Core
author: ardalis
description: Learn how to test controller logic in ASP.NET Core with Moq and xUnit.
ms.author: riande
ms.date: 10/14/2016
uid: mvc/controllers/testing
---
# Test controller logic in ASP.NET Core

By [Steve Smith](https://ardalis.com/)

Controllers are a central part of any ASP.NET Core MVC application. As such, you should have confidence they behave as intended for your app. Automated tests can provide you with this confidence and can detect errors before they reach production. It's important to avoid placing unnecessary responsibilities within your controllers and ensure your tests focus only on controller responsibilities.

Controller logic should be minimal and not be focused on business logic or infrastructure concerns (for example, data access). Test controller logic, not the framework. Test how the controller *behaves* based on valid or invalid inputs. Test controller responses based on the result of the business operation it performs.

Typical controller responsibilities:

* Verify `ModelState.IsValid`.
* Return an error response if `ModelState` is invalid.
* Retrieve a business entity from persistence.
* Perform an action on the business entity.
* Save the business entity to persistence.
* Return an appropriate `IActionResult`.

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/mvc/controllers/testing/sample) ([how to download](xref:tutorials/index#how-to-download-a-sample))

## Unit tests of controller logic

[Unit tests](/dotnet/articles/core/testing/unit-testing-with-dotnet-test) involve testing a part of an app in isolation from its infrastructure and dependencies. When unit testing controller logic, only the contents of a single action is tested, not the behavior of its dependencies or of the framework itself. As you unit test your controller actions, make sure you focus only on its behavior. A controller unit test avoids things like [filters](xref:mvc/controllers/filters), [routing](xref:fundamentals/routing), or [model binding](xref:mvc/models/model-binding). By focusing on testing just one thing, unit tests are generally simple to write and quick to run. A well-written set of unit tests can be run frequently without much overhead. However, unit tests don't detect issues in the interaction between components, which is the purpose of [integration tests](xref:test/integration-tests).

If you're writing custom filters and routes, you should unit test them in isolation, not as part of your tests on a particular controller action.

> [!TIP]
> [Create and run unit tests with Visual Studio](/visualstudio/test/unit-test-your-code).

To demonstrate unit testing, review the following controller. It displays a list of brainstorming sessions and allows new brainstorming sessions to be created with a POST:

[!code-csharp[](testing/sample/TestingControllersSample/src/TestingControllersSample/Controllers/HomeController.cs?highlight=12,16,21,42,43)]

The controller is following the [explicit dependencies principle](http://deviq.com/explicit-dependencies-principle/), expecting dependency injection to provide it with an instance of `IBrainstormSessionRepository`. This makes it fairly easy to test using a mock object framework, like [Moq](https://www.nuget.org/packages/Moq/). The `HTTP GET Index` method has no looping or branching and only calls one method. To test this `Index` method, we need to verify that a `ViewResult` is returned, with a `ViewModel` from the repository's `List` method.

[!code-csharp[](testing/sample/TestingControllersSample/tests/TestingControllersSample.Tests/UnitTests/HomeControllerTests.cs?highlight=17-18&range=1-33,76-95)]

The `HomeController` `HTTP POST Index` method (shown above) should verify:

* The action method returns a Bad Request `ViewResult` with the appropriate data when `ModelState.IsValid` is `false`.

* The `Add` method on the repository is called and a `RedirectToActionResult` is returned with the correct arguments when `ModelState.IsValid` is true.

Invalid model state can be tested by adding errors using `AddModelError` as shown in the first test below.

[!code-csharp[](testing/sample/TestingControllersSample/tests/TestingControllersSample.Tests/UnitTests/HomeControllerTests.cs?highlight=8,15-16,37-39&range=35-75)]

The first test confirms when `ModelState` isn't valid, the same `ViewResult` is returned as for a `GET` request. Note that the test doesn't attempt to pass in an invalid model. That wouldn't work anyway since model binding isn't running (though an [integration test](xref:test/integration-tests) would use exercise model binding). In this case, model binding isn't being tested. These unit tests are only testing what the code in the action method does.

The second test verifies that when `ModelState` is valid, a new `BrainstormSession` is added (via the repository), and the method returns a `RedirectToActionResult` with the expected properties. Mocked calls that aren't called are normally ignored, but calling `Verifiable` at the end of the setup call allows it to be verified in the test. This is done with the call to `mockRepo.Verify`, which will fail the test if the expected method wasn't called.

> [!NOTE]
> The Moq library used in this sample makes it easy to mix verifiable, or "strict", mocks with non-verifiable mocks (also called "loose" mocks or stubs). Learn more about [customizing Mock behavior with Moq](https://github.com/Moq/moq4/wiki/Quickstart#customizing-mock-behavior).

Another controller in the app displays information related to a particular brainstorming session. It includes some logic to deal with invalid id values:

[!code-csharp[](testing/sample/TestingControllersSample/src/TestingControllersSample/Controllers/SessionController.cs?highlight=19,20,21,22,25,26,27,28)]

The controller action has three cases to test, one for each `return` statement:

[!code-csharp[](testing/sample/TestingControllersSample/tests/TestingControllersSample.Tests/UnitTests/SessionControllerTests.cs?highlight=27,28,29,46,47,64,65,66,67,68)]

The app exposes functionality as a web API (a list of ideas associated with a brainstorming session and a method for adding new ideas to a session):

[!code-csharp[](testing/sample/TestingControllersSample/src/TestingControllersSample/Api/IdeasController.cs?highlight=21,22,27,30,31,32,33,34,35,36,41,42,46,52,65)]

The `ForSession` method returns a list of `IdeaDTO` types. Avoid returning your business domain entities directly via API calls, since frequently they include more data than the API client requires, and they unnecessarily couple your app's internal domain model with the API you expose externally. Mapping between domain entities and the types you will return over the wire can be done manually (using a LINQ `Select` as shown here) or using a library like [AutoMapper](https://github.com/AutoMapper/AutoMapper).

The unit tests for the `Create` and `ForSession` API methods:

[!code-csharp[](testing/sample/TestingControllersSample/tests/TestingControllersSample.Tests/UnitTests/ApiIdeasControllerTests.cs?highlight=18,23,29,33,38-39,43,50,58-59,68-70,76-78&range=1-83,121-135)]

As stated previously, to test the behavior of the method when `ModelState` is invalid, add a model error to the controller as part of the test. Don't try to test model validation or model binding in your unit tests - just test your action method's behavior when confronted with a particular `ModelState` value.

The second test depends on the repository returning null, so the mock repository is configured to return null. There's no need to create a test database (in memory or otherwise) and construct a query that will return this result - it can be done in a single statement as shown.

The last test verifies that the repository's `Update` method is called. As we did previously, the mock is called with `Verifiable` and then the mocked repository's `Verify` method is called to confirm the verifiable method was executed. It's not a unit test responsibility to ensure that the `Update` method saved the data; that can be done with an integration test.

## Additional resources

* <xref:test/integration-tests>
