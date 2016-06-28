:version: 1.0.0-rc1

Testing Controller Logic
========================
By `Steve Smith`_

Controllers in ASP.NET MVC apps should be small and focused on user-interface concerns. Large controllers that deal with non-UI concerns are more difficult to test and maintain.

.. contents:: Sections
	:local:
	:depth: 1
	
`View or download sample from GitHub <https://github.com/aspnet/Docs/tree/master/aspnet/mvc/controllers/testing/sample>`_

Why Test Controllers
--------------------

Controllers are a central part of any ASP.NET Core MVC application. As such, you should have confidence they behave as intended for your app. Automated tests can provide you with this confidence and can detect errors before they reach production. It's important to avoid placing unnecessary responsibilities within your controllers and ensure your tests focus only on controller responsibilities.

Controller logic should be minimal and not be focused on business logic or infrastructure concerns (for example, data access). Test controller logic, not the framework. Test how the controller *behaves* based on valid or invalid inputs. Test controller responses based on the result of the business operation it performs.

Typical controller responsibilities:

- Verify ``ModelState.IsValid``
- Return an error response if ``ModelState`` is invalid
- Retrieve a business entity from persistence
- Perform an action on the business entity
- Save the business entity to persistence
- Return an appropriate ``IActionResult``

Unit Testing
------------

:doc:`Unit testing </testing/unit-testing>` involves testing a part of an app in isolation from its infrastructure and dependencies. When unit testing controller logic, only the contents of a single action is tested, not the behavior of its dependencies or of the framework itself. As you unit test your controller actions, make sure you focus only on its behavior. A controller unit test avoids things like :doc:`filters <filters>`, :doc:`routing </fundamentals/routing>`, or :doc:`model binding </mvc/models/model-binding>`. By focusing on testing just one thing, unit tests are generally simple to write and quick to run. A well-written set of unit tests can be run frequently without much overhead. However, unit tests do not detect issues in the interaction between components, which is the purpose of :ref:`integration testing <integration-testing>`.

If you've writing custom filters, routes, etc, you should unit test them, but not as part of your tests on a particular controller action. They should be tested in isolation.

.. tip:: `Create and run unit tests with Visual Studio <https://www.visualstudio.com/en-us/get-started/code/create-and-run-unit-tests-vs>`__.

To demonstrate unit testing, review the following controller. It displays a list of brainstorming sessions and allows new brainstorming sessions to be created with a POST:

.. literalinclude:: testing/sample/TestingControllersSample/src/TestingControllersSample/Controllers/HomeController.cs
  :language: c#
  :emphasize-lines: 12,16,21,42-43

The controller is following the `explicit dependencies principle <http://deviq.com/explicit-dependencies-principle/>`_, expecting dependency injection to provide it with an instance of ``IBrainstormSessionRepository``. This makes it fairly easy to test using a mock object framework, like `Moq <https://www.nuget.org/packages/Moq/>`_. The ``HTTP GET Index`` method has no looping or branching and only calls one method. To test this ``Index`` method, we need to verify that a ``ViewResult`` is returned, with a ``ViewModel`` from the repository's ``List`` method.

.. literalinclude:: testing/sample/TestingControllersSample/tests/TestingControllersSample.Tests/UnitTests/HomeControllerTests.cs
  :language: c#
  :emphasize-lines: 17-18

The ``HTTP POST Index`` method (shown below) should verify:

- The action method returns a ``ViewResult`` with the appropriate data when ``ModelState.IsValid`` is ``false``
- The ``Add`` method on the repository is called and a ``RedirectToActionResult`` is returned with the correct arguments when ``ModelState.IsValid`` is true.

.. literalinclude:: testing/sample/TestingControllersSample/tests/TestingControllersSample.Tests/UnitTests/HomeControllerTests.cs
  :language: c#
  :lines: 29-57
  :dedent: 4
  :emphasize-lines: 1-2,10-12,15-16,19,24-25,28

The first test confirms when ``ModelState`` is not valid, the same ``ViewResult`` is returned as for a ``GET`` request. Note that the test doesn't attempt to pass in an invalid model. That wouldn't work anyway since model binding isn't running - we're just calling the method directly. However, we're not trying to test model binding - we're only testing what our code in the action method does. The simplest approach is to add an error to ``ModelState``.

The second test verifies that when ``ModelState`` is valid, a new ``BrainstormSession`` is added (via the repository), and the method returns a ``RedirectToActionResult`` with the expected properties. Mocked calls that aren't called are normally ignored, but calling ``Verifiable`` at the end of the setup call allows it to be verified in the test. This is done with the call to ``mockRepo.Verify``.

.. note:: The Moq library used in this sample makes it easy to mix verifiable, or "strict", mocks with non-verifiable mocks (also called "loose" mocks or stubs). Learn more about `customizing Mock behavior with Moq <https://github.com/Moq/moq4/wiki/Quickstart#customizing-mock-behavior>`_.

Another controller in the app displays information related to a particular brainstorming session. It includes some logic to deal with invalid id values:

.. literalinclude:: testing/sample/TestingControllersSample/src/TestingControllersSample/Controllers/SessionController.cs
  :language: c#
  :emphasize-lines: 16,20,25,33

The controller action has three cases to test, one for each ``return`` statement:

.. literalinclude:: testing/sample/TestingControllersSample/tests/TestingControllersSample.Tests/UnitTests/SessionControllerTests.cs
  :language: c#
  :emphasize-lines: 16,26,39

The app exposes functionality as a web API (a list of ideas associated with a brainstorming session and a method for adding new ideas to a session):

.. _ideas-controller:

.. literalinclude:: testing/sample/TestingControllersSample/src/TestingControllersSample/Api/IdeasController.cs
  :language: c#
  :emphasize-lines: 20-22,27,29-36,39-41,45,50,60

The ``ForSession`` method returns a list of ``IdeaDTO`` types, with property names camel cased to match JavaScript conventions. Avoid returning your business domain entities directly via API calls, since frequently they include more data than the API client requires, and they unnecessarily couple your app's internal domain model with the API you expose externally. Mapping between domain entities and the types you will return over the wire can be done manually (using a LINQ ``Select`` as shown here) or using a library like `AutoMapper <https://github.com/AutoMapper/AutoMapper>`_

The unit tests for the ``Create`` and ``ForSession`` API methods:

.. literalinclude:: testing/sample/TestingControllersSample/tests/TestingControllersSample.Tests/UnitTests/ApiIdeasControllerTests.cs
  :language: c#
  :emphasize-lines: 16-17,26-27,37-38,65-66,76-77

As stated previously, to test the behavior of the method when ``ModelState`` is invalid, add a model error to the controller as part of the test. Don't try to test model validation or model binding in your unit tests - just test your action method's behavior when confronted with a particular ``ModelState`` value.

The second test depends on the repository returning null, so the mock repository is configured to return null. There's no need to create a test database (in memory or otherwise) and construct a query that will return this result - it can be done in a single line as shown.

The last test verifies that the repository's ``Update`` method is called. As we did previously, the mock is called with ``Verifiable`` and then the mocked repository's ``Verify`` method is called to confirm the verifiable method was executed. It's not a unit test responsibility to ensure that the ``Update`` method saved the data; that can be done with an integration test.

.. _integration-testing:

Integration Testing
-------------------

:doc:`Integration testing </testing/integration-testing>` is done to ensure separate modules within your app work correctly together. Generally, anything you can test with a unit test, you can also test with an integration test, but the reverse isn't true. However, integration tests tend to be much slower than unit tests. Thus, it's best to test whatever you can with unit tests, and use integration tests for scenarios that involve multiple collaborators.

Although they may still be useful, mock objects are rarely used in integration tests. In unit testing, mock objects are an effective way to control how collaborators outside of the unit being tested should behave for the purposes of the test. In an integration test, real collaborators are used to confirm the whole subsystem works together correctly.

Application State
^^^^^^^^^^^^^^^^^

One important consideration when performing integration testing is how to set your app's state. Tests need to run independent of one another, and so each test should start with the app in a known state. If your app doesn't use a database or have any persistence, this may not be an issue. However, most real-world apps persist their state to some kind of data store, so any modifications made by one test could impact another test unless the data store is reset. Using the built-in ``TestServer``, it's very straightforward to host ASP.NET Core apps within our integration tests, but that doesn't necessarily grant access to the data it will use. If you're using an actual database, one approach is to have the app connect to a test database, which your tests can access and ensure is reset to a known state before each test executes.

In this sample application, I'm using Entity Framework Core's InMemoryDatabase support, so I can't just connect to it from my test project. Instead, I expose an ``InitializeDatabase`` method from the app's ``Startup`` class, which I call when the app starts up if it's in the ``Development`` environment. My integration tests automatically benefit from this as long as they set the environment to ``Development``. I don't have to worry about resetting the database, since the InMemoryDatabase is reset each time the app restarts.

The ``Startup`` class:

.. literalinclude:: testing/sample/TestingControllersSample/src/TestingControllersSample/Startup.cs
  :language: c#
  :emphasize-lines: 18-21,40-41,49,57

You'll see the ``GetTestSession`` method used frequently in the integration tests below.

Accessing Views
^^^^^^^^^^^^^^^

Each integration test class configures the ``TestServer`` that will run the ASP.NET Core app. By default, ``TestServer`` hosts the web app in the folder where it's running - in this case, the test project folder. Thus, when you attempt to test controller actions that return ``ViewResult``, you may see this error:

.. code-block:: none

  The view 'Index' was not found. The following locations were searched:
  (list of locations)

To correct this issue, you need to configure the server to use the ``ApplicationBasePath`` and ``ApplicationName`` of the web project. This is done in the call to ``UseServices`` in the integration test class shown:

.. literalinclude:: testing/sample/TestingControllersSample/tests/TestingControllersSample.Tests/IntegrationTests/HomeControllerTests.cs
  :language: c#
  :emphasize-lines: 20,22-32,36-37,42

In the test above, the ``responseString`` gets the actual rendered HTML from the View, which can be inspected to confirm it contains expected results.

API Methods
^^^^^^^^^^^

If your app exposes web APIs, it's a good idea to have automated tests confirm they execute as expected. The built-in ``TestServer`` makes it easy to test web APIs. If your API methods are using model binding, you should always check ``ModelState.IsValid``, and integration tests are the right place to confirm that your model validation is working properly. 

The following set of tests target the ``Create`` method in the :ref:`IdeasController <ideas-controller>` class shown above:

.. literalinclude:: testing/sample/TestingControllersSample/tests/TestingControllersSample.Tests/IntegrationTests/ApiIdeasControllerTests.cs
  :language: c#
  :lines: 37-142

Unlike integration tests of actions that returns HTML views, web API methods that return results can usually be deserialized as strongly typed objects, as the last test above shows. In this case, the test deserializes the result to a ``BrainstormSession`` instance, and confirms that the idea was correctly added to its collection of ideas.

You'll find additional examples of integration tests in this article's `sample project <https://github.com/aspnet/Docs/tree/1.0.0-rc1/aspnet/mvc/controllers/testing/sample>`_.
