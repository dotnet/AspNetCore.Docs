.. _fundamentals-middleware:

Middleware
==========
By `Steve Smith`_

Small application components that can be incorporated into an HTTP request pipeline are known collectively as middleware. ASP.NET 5 has integrated support for middleware, which are wired up in an application's ``Configure`` method during :doc:`startup`.

In this article:
	- `What is middleware`_
	- `Creating a middleware pipeline with IApplicationBuilder`_
	- `Built-in middleware`_
	- `Writing middleware`_

`Download sample from GitHub <https://github.com/aspnet/Docs/tree/master/aspnet/fundamentals/middleware/sample>`_.

What is middleware
------------------

Middleware are components that are assembled into an application pipeline to handle requests and responses. Each component can choose whether to pass the request on to the next component in the pipeline, and can perform certain actions before and after the next component in the pipeline. Request delegates are used to build this request pipeline, which are then used to handle each HTTP request to your application. 

Request delegates are configured using ``Run``, ``Map``, and ``Use`` extension methods on the ``IApplicationBuilder`` type that is passed into the ``Configure`` method in the ``Startup`` class. An individual request delegate can be specified in-line as an anonymous method, or it can be defined in a reusable class. These reusable classes  are `middleware`, or `middleware components`. Each middleware component in the request pipeline is responsible for invoking the next component in the chain, or choosing to short-circuit the chain if appropriate.

Creating a middleware pipeline with IApplicationBuilder
-------------------------------------------------------

The ASP.NET request pipeline consists of a sequence of request delegates, called one after the next, as this diagram shows (the thread of execution follows the black arrows):

.. image:: middleware/_static/request-delegate-pipeline.png

Each delegate has the opportunity to perform operations before and after the next delegate. Any delegate can choose to stop passing the request on to the next delegate, and instead handle the request itself. This is referred to as short-circuiting the request pipeline, and is desirable because it allows unnecessary work to be avoided. For example, an authorization middleware function might only call the next delegate in the pipeline if the request is authenticated, otherwise it could short-circuit the pipeline and simply return some form of "Not Authorized" response. Exception handling delegates need to be called early on in the pipeline, so they are able to catch exceptions that occur in later calls within the call chain.

You can see an example of setting up a request pipeline, using a variety of request delegates, in the default web site template that ships with Visual Studio 2015. Its ``Configure`` method, shown below, first wires up error pages (in development) or the site's production error handler, then builds out the pipeline with support for static files, ASP.NET Identity authentication, and finally, ASP.NET MVC.

.. literalinclude:: /../common/samples/WebApplication1/src/WebApplication1/Startup.cs
	:language: c#
	:linenos:
	:lines: 59-72,85-101
	:dedent: 8
	:emphasize-lines: 8-10,14,19,21,25

Because of the order in which this pipeline was constructed, the middleware configured by the ``UseExceptionHandler`` method will catch any exceptions that occur in later calls (in non-development environments). Also, in this example a design decision has been made that static files will not be protected by any authentication. This is a tradeoff that improves performance when handling static files since no other middleware (such as authentication middleware) needs to be called when handling these requests (ASP.NET 5 uses a specific ``wwwroot`` folder for all files that should be accessible by default, so there is typically no need to perform authentication before sending these files). If the request is not for a static file, it will flow to the next piece of middleware defined in the pipeline (in this case, Identity). Learn more about :doc:`static-files`.

.. note:: **Remember:** the order in which you arrange your ``Use[Middleware]`` statements in your application's ``Configure`` method is very important. Be sure you have a good understanding of how your application's request pipeline will behave in various scenarios.

The simplest possible ASP.NET application sets up a single request delegate that handles all requests. In this case, there isn't really a request "pipeline", so much as a single anonymous function that is called in response to every HTTP request.

.. literalinclude:: middleware/sample/src/MiddlewareSample/Startup.cs
	:language: c#
	:linenos:
	:lines: 23-26
	:dedent: 12

It's important to realize that request delegate, as written here, will terminate the pipeline, regardless of other calls to ``App.Run`` that you may include. In the following example, only the first delegate ("Hello, World!") will be executed and displayed.

.. literalinclude:: middleware/sample/src/MiddlewareSample/Startup.cs
	:language: c#
	:linenos:
	:lines: 20-31
	:emphasize-lines: 5
	:dedent: 8

You chain multiple request delegates together making a different call, with a ``next`` parameter representing the next delegate in the pipeline. Note that just because you're calling it "next" doesn't mean you can't perform actions both before and after the next delegate, as this example demonstrates:

.. literalinclude:: middleware/sample/src/MiddlewareSample/Startup.cs
	:language: c#
	:linenos:
	:lines: 34-49
	:emphasize-lines: 5,8,14
	:dedent: 8

.. warning:: Be wary of modifying ``HttpResponse`` after invoking next, since one of the components further down the pipeline may have written to the response, causing it to be sent to the client.

.. note:: This ``ConfigureLogInline`` method is called when the application is run with an environment set to ``LogInline``. Learn more about :doc:`environments`. We will be using variations of ``Configure[Environment]`` to show different options in the rest of this article. The easiest way to run the samples in Visual Studio is with the ``web`` command, which is configured in ``project.json``. See also :doc:`startup`.

In the above example, the call to ``await next.Invoke()`` will call into the delegate on line 14. The client will receive the expected response ("Hello from LogInline"), and the server's console output includes both the before and after messages, as you can see here:

.. image:: middleware/_static/console-loginline.png

..  _middleware-run-map-use:

Run, Map, and Use
^^^^^^^^^^^^^^^^^

You configure the HTTP pipeline using the `extensions <https://github.com/aspnet/HttpAbstractions/tree/dev/src/Microsoft.AspNet.Http.Abstractions/Extensions>`_ ``Run``, ``Map``, and ``Use``. By convention, the ``Run`` method is simply a shorthand way of adding middleware to the pipeline that doesn't call any other middleware (that is, it will not call a ``next`` request delegate). Thus, ``Run`` should only be called at the end of your pipeline. ``Run`` is a convention, and some middleware components may expose their own Run[Middleware] methods that should only run at the end of the pipeline. The following two examples (one using ``Run`` and the other ``Use``) are equivalent to one another, since the second one doesn't use its ``next`` parameter:

.. literalinclude:: middleware/sample/src/MiddlewareSample/Startup.cs
	:language: c#
	:linenos:
	:lines: 65-79
	:emphasize-lines: 3,11
	:dedent: 8

.. note:: The `IApplicationBuilder interface <https://github.com/aspnet/HttpAbstractions/blob/1.0.0-beta5/src/Microsoft.AspNet.Http.Abstractions/IApplicationBuilder.cs#L17>`_ itself exposes a single ``Use`` method, so technically they're not all *extension* methods.

We've already seen several examples of how to build a request pipeline with ``Use``. ``Map*`` extensions are used as a convention for branching the pipeline. The current implementation supports branching based on the request's path, or using a predicate. The ``Map`` extension method is used to match request delegates based on a request's path. ``Map`` simply accepts a path and a function that configures a separate middleware pipeline. In the following example, any request with the base path of ``/maptest`` will be handled by the pipeline configured in the ``HandleMapTest`` method.

.. literalinclude:: middleware/sample/src/MiddlewareSample/Startup.cs
	:language: c#
	:linenos:
	:lines: 81-93
	:emphasize-lines: 11
	:dedent: 8

.. note:: When ``Map`` is used, the matched path segment(s) are removed from ``HttpRequest.Path`` and appended to ``HttpRequest.PathBase`` for each request.

In addition to path-based mapping, the ``MapWhen`` method supports predicate-based middleware branching, allowing separate pipelines to be constructed in a very flexible fashion. Any predicate of type ``Func<HttpContext, bool>`` can be used to map requests to a new branch of the pipeline. In the following example, a simple predicate is used to detect the presence of a querystring variable ``branch``:

.. literalinclude:: middleware/sample/src/MiddlewareSample/Startup.cs
	:language: c#
	:linenos:
	:lines: 95-113
	:emphasize-lines: 5,11-13
	:dedent: 8

Using the configuration shown above, any request that includes a querystring value for ``branch`` will use the pipeline defined in the ``HandleBranch`` method (in this case, a response of "Branch used."). All other requests (that do not define a querystring value for ``branch``) will be handled by the delegate defined on line 17.

Built-in middleware
-------------------

ASP.NET ships with the following middleware components:


.. list-table:: Middleware
	:header-rows: 1

	*  - Middleware
	   - Description
	*  - :ref:`Authentication <security-authentication-social-logins>`
	   - Provides authentication support.
	*  - `CORS <https://github.com/aspnet/CORS/tree/1.0.0-beta6>`_
	   - Configures Cross-Origin Resource Sharing.
	*  - :doc:`diagnostics`
	   - Includes support for error pages and runtime information.
	*  - :doc:`routing`
	   - Define and constrain request routes.
	*  - `Session <https://github.com/aspnet/Session>`_
	   - Provides support for managing user sessions.
	*  - :doc:`Static Files <static-files>`
	   - Provides support for serving static files, and directory browsing.

.. _middleware-writing-middleware:

Writing middleware
------------------

For more complex request handling functionality, the ASP.NET team recommends implementing the middleware in its own class, and exposing an ``IApplicationBuilder`` extension method that can be called from the ``Configure`` method. The simple logging middleware shown in the previous example can be converted into a middleware class that takes in the next ``RequestDelegate`` in its constructor and supports an ``Invoke`` method as shown:

.. literalinclude:: middleware/sample/src/MiddlewareSample/RequestLoggerMiddleware.cs
	:language: c#
	:caption: RequestLoggerMiddleware.cs
	:linenos:
	:emphasize-lines: 13, 19

The middleware follows the `Explicit Dependencies Principle <http://deviq.com/explicit-dependencies-principle/>`_ and exposes all of its dependencies in its constructor. Middleware can take advantage of the `UseMiddleware<T> <https://github.com/aspnet/HttpAbstractions/blob/1.0.0-beta6/src/Microsoft.AspNet.Http.Abstractions/Extensions/UseMiddlewareExtensions.cs>`_ extension to inject services directly into their constructors, as shown in the example below. Dependency injected services are automatically filled, and the extension takes a ``params`` array of arguments to be used for non-injected parameters.

.. literalinclude:: middleware/sample/src/MiddlewareSample/RequestLoggerExtensions.cs
	:language: c#
	:caption: RequestLoggerExtensions.cs
	:linenos:
	:lines: 5-11
	:emphasize-lines: 5
	:dedent: 4

Using the extension method and associated middleware class, the ``Configure`` method becomes very simple and readable.

.. literalinclude:: middleware/sample/src/MiddlewareSample/Startup.cs
	:language: c#
	:linenos:
	:lines: 51-62
	:emphasize-lines: 6
	:dedent: 8

Although ``RequestLoggerMiddleware`` requires an ``ILoggerFactory`` parameter in its constructor, neither the ``Startup`` class nor the ``UseRequestLogger`` extension method need to explicitly supply it. Instead, it is automatically provided through dependency injection performed within ``UseMiddleware<T>``.

Testing the middleware (by setting the ``Hosting:Environment`` environment variable to ``LogMiddleware``) should result in output like the following (when using WebListener):

.. image:: middleware/_static/console-logmiddleware.png

.. note:: You can see another example of ``UseMiddleware<T>`` in action in the `UseStaticFiles <https://github.com/aspnet/StaticFiles/blob/1.0.0-beta6/src/Microsoft.AspNet.StaticFiles/StaticFileExtensions.cs#L44>`_ extension method, which is used to create the `StaticFileMiddleware <https://github.com/aspnet/StaticFiles/blob/1.0.0-beta6/src/Microsoft.AspNet.StaticFiles/StaticFileMiddleware.cs#L30>`_ with its required constructor parameters. In this case, the ``StaticFileOptions`` parameter is passed in, but other constructor parameters are supplied by ``UseMiddleware<T>`` and dependency injection.

Summary
-------

Middleware provide simple components for adding features to individual web requests. Applications configure their request pipelines in accordance with the features they need to support, and thus have fine-grained control over the functionality each request uses. Developers can easily create their own middleware to provide additional functionality to ASP.NET applications.

Additional Resources
--------------------

- :doc:`startup`
- :doc:`request-features`
