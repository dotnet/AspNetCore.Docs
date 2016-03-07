Integration Testing
===================
By `Steve Smith`_

Integration testing ensures that an application's components function correctly when assembled together. ASP.NET 5 supports integration testing using unit test frameworks and a built-in test web host that can be used to handle requests without network overhead.

In this article:
  - `Introduction to Integration Testing`_
  - `Integration Testing ASP.NET`_
  - `Refactoring to use Middleware`_


`Download sample from GitHub <https://github.com/aspnet/docs/tree/master/aspnet/testing/integration-testing/sample>`_. 

Introduction to Integration Testing
-----------------------------------
Integration tests verify that different parts of an application work correctly together. Unlike :doc:`unit-testing`, integration tests frequently involve application infrastructure concerns, such as a database, file system, network resources, or web requests and responses. Unit tests use fakes or mock objects in place of these concerns, but the purpose of integration tests is to confirm that the system works as expected with these systems.

Integration tests, because they exercise larger segments of code and because they rely on infrastructure elements, tend to be orders of magnitude slower than unit tests. Thus, it's a good idea to limit how many integration tests you write, especially if you can test the same behavior with a unit test.

.. tip:: If some behavior can be tested using either a unit test or an integration test, prefer the unit test, since it will be almost always be faster. You might have dozens or hundreds of unit tests with many different inputs, but just a handful of integration tests covering the most important scenarios.

Testing the logic within your own methods is usually the domain of unit tests. Testing how your application works within its framework (e.g. ASP.NET) or with a database is where integration tests come into play. It doesn't take too many integration tests to confirm that you're able to write a row to and then read a row from the database. You don't need to test every possible permutation of your data access code - you only need to test enough to give you confidence that your application is working properly.

Integration Testing ASP.NET
---------------------------
To get set up to run integration tests, you'll need to create a test project, refer to your ASP.NET web project, and install a test runner. This process is described in the :doc:`unit-testing` documentation, along with more detailed instructions on running tests and recommendations for naming your tests and test classes.

.. tip:: Separate your unit tests and your integration tests using different projects. This helps ensure you don't accidentally introduce infrastructure concerns into your unit tests, and lets you easily choose to run all tests, or just one set or the other.

The Test Host
^^^^^^^^^^^^^
ASP.NET includes a test host that can be added to integration test projects and used to host ASP.NET applications, serving test requests without the need for a real web host. The provided sample includes an integration test project which has been configured to use `xUnit`_ and the Test Host, as you can see from this excerpt from its ``project.json`` file:

.. literalinclude:: integration-testing/sample/test/PrimeWeb.IntegrationTests/project.json
  :linenos:
  :language: javascript
  :lines: 21-26
  :dedent: 2
  :emphasize-lines: 5

Once the Microsoft.AspNet.TestHost package is included in the project, you will be able to create and configure a TestServer in your tests. The following test shows how to verify that a request made to the root of a site returns "Hello World!" and should run successfully against the default ASP.NET Empty Web template created by Visual Studio.

.. literalinclude:: integration-testing/sample/test/PrimeWeb.IntegrationTests/PrimeWebDefaultRequestShould.cs
  :linenos:
  :language: c#
  :lines: 10-32
  :dedent: 8
  :emphasize-lines: 6-7

These tests are using the Arrange-Act-Assert pattern, but in this case all of the Arrange step is done in the constructor, which creates an instance of ``TestServer``. There are several different ways to configure a ``TestServer`` when you create it; in this example we are passing in the ``Configure`` method from our system under test (SUT)'s ``Startup`` class. This method will be used to configure the request pipeline of the ``TestServer`` identically to how the SUT server would be configured.

In the Act portion of the test, a request is made to the ``TestServer`` instance for the "/" path, and the response is read back into a string. This string is then compared with the expected string of "Hello World!". If they match, the test passes, otherwise it fails.

Now we can add a few additional integration tests to confirm that the prime checking functionality works via the web application:

.. literalinclude:: integration-testing/sample/test/PrimeWeb.IntegrationTests/PrimeWebCheckPrimeShould.cs
  :linenos:
  :language: c#
  :lines: 10-68
  :dedent: 4
  :emphasize-lines: 8-9

Note that we're not really trying to test the correctness of our prime number checker with these tests, but rather that the web application is doing what we expect. We already have unit test coverage that gives us confidence in ``PrimeService``, as you can see here:

.. image:: integration-testing/_static/test-explorer.png

.. note:: You can learn more about the unit tests in the :doc:`unit-testing` article.

Now that we have a set of passing tests, it's a good time to think about whether we're happy with the current way in which we've designed our application. If we see any `code smells <http://deviq.com/code-smells/>`_, now may be a good time to refactor the application to improve its design.

Refactoring to use Middleware
-----------------------------
Refactoring is the process of changing an application's code to improve its design without changing its behavior. It should ideally be done when there is a suite of passing tests, since these help ensure the system's behavior remains the same before and after the changes. Looking at the way in which the prime checking logic is implemented in our web application, we see:

.. code-block:: c#
  :linenos:
  :emphasize-lines: 13-33

    public void Configure(IApplicationBuilder app,
        IHostingEnvironment env)
    {
        // Add the platform handler to the request pipeline.
        app.UseIISPlatformHandler();
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
                    numberToCheck = int.Parse(context.Request.QueryString.Value.Replace("?",""));
                    var primeService = new PrimeService();
                    if (primeService.IsPrime(numberToCheck))
                    {
                        await context.Response.WriteAsync(numberToCheck + " is prime!");
                    }
                    else
                    {
                        await context.Response.WriteAsync(numberToCheck + " is NOT prime!");
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

This code works, but it's far from how we would like to implement this kind of functionality in an ASP.NET application, even as simple a one as this is. Imagine what the ``Configure`` method would look like if we needed to add this much code to it every time we added another URL endpoint! 

One option we can consider is adding `MVC <http://docs.asp.net/projects/mvc>`_ to the application, and creating a controller to handle the prime checking. However, assuming we don't currently need any other MVC functionality, that's a bit overkill. 

We can, however, take advantage of ASP.NET's :doc:`/fundamentals/middleware` support, which will help us encapsulate the prime checking logic in its own class and achieve better `separation of concerns <http://deviq.com/separation-of-concerns/>`_ within the ``Configure`` method.

.. tip:: This scenario is perfectly suited to using middleware. Learn more about :doc:`/fundamentals/middleware` and how to plug it into your application's request pipeline.

Since our middleware is simply going to respond to a particular path, we can model it after the `Microsoft.AspNet.Diagnostics.WelcomePage <https://github.com/aspnet/Diagnostics/tree/1.0.0-beta8/src/Microsoft.AspNet.Diagnostics/WelcomePage>`_ middleware, which has similar behavior. We want to allow the path the middleware uses to be specified as a parameter, so the middleware class expects a ``RequestDelegate`` and a ``PrimeCheckerOptions`` instance in its constructor. If the path of the request doesn't match what this middleware is configured to expect, we simply call the next middleware in the chain and do nothing further. The rest of the implementation code that was in ``Configure`` is now in the ``Invoke`` method.

.. note:: Since our middleware depends on the ``PrimeService`` service, we are also requesting an instance of this service via the constructor. The framework will provide this service via :doc:`/fundamentals/dependency-injection`, assuming it has been configured (e.g. in ``ConfigureServices``).

.. literalinclude:: integration-testing/sample/src/PrimeWeb/Middleware/PrimeCheckerMiddleware.cs
  :linenos:
  :language: c#
  :emphasize-lines: 39-62

.. note:: Since this middleware acts as an endpoint in the request delegate chain when its path matches, there is no call to ``_next.Invoke`` in the case where this middleware handles the request.

With this middleware in place and some helpful extension methods created to make configuring it easier, the refactored ``Configure`` method looks like this:

.. literalinclude:: integration-testing/sample/src/PrimeWeb/Startup.cs
  :linenos:
  :language: c#
  :lines: 18-34
  :dedent: 8
  :emphasize-lines: 11

Following this refactoring, we are confident that the web application still works as before, since our integration tests are all passing.

.. tip:: It's a good idea to commit your changes to source control after you complete a refactoring and your tests all pass. If you're practicing Test Driven Development, `consider adding Commit to your Red-Green-Refactor cycle <http://ardalis.com/rgrc-is-the-new-red-green-refactor-for-test-first-development>`_.

Summary
-------
Integration testing provides a higher level of verification than unit testing. It tests application infrastructure and how different parts of an application work together. ASP.NET 5 is very testable, and ships with a ``TestServer`` that makes wiring up integration tests for web server endpoints very easy.

Additional Resources
--------------------
- :doc:`unit-testing`
- :doc:`/fundamentals/middleware`