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

In discussions of integration tests, the tested project is frequently called the ***System Under Test***, or "**SUT**" for short. "SUT" is used throughout this article to refer to the ASP.NET Core app being tested.

***Don't write integration tests for every permutation*** of data and file access with databases and file systems. Regardless of how many places across an app interact with databases and file systems, a focused set of read, write, update, and delete integration tests are usually capable of adequately testing database and file system components. Use unit tests for routine tests of method logic that interact with these components. In unit tests, the use of infrastructure fakes or mocks result in faster test execution.

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

**Separate unit tests from integration tests into different projects**. Separating the tests:

* Helps ensure that infrastructure testing components aren't accidentally included in the unit tests.
* Allows control over which set of tests are run.
