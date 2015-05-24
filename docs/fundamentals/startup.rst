Application Startup
===================

By `Steve Smith`_

ASP.NET 5 provides complete control of how individual requests are handled by your application. The ``Startup`` class is the entry point to the application, setting up configuration and wiring up services the application will use. Developers configure a request pipeline in the ``Startup`` class that is used to handle all requests made to the application.

In this article:
	- `The Startup class`_
	- `Understanding request delegates`_
	- `Implementing middleware in its own class`_
	- `Setting up your request pipeline`_
	- `Run, Map, and Use`_
	
`Browse or download samples on GitHub <https://github.com/aspnet/Docs/tree/master/docs/fundamentals/startup/sample>`_.

The Startup class
-----------------

In ASP.NET 5, the ``Startup`` class provides the entry point for an application. It's possible to have :doc:`environment-specific startup files and methods <environments>`, but regardless, one ``Startup`` class will serve as the entry point for the application. This ``Startup`` class can optionally accept dependencies in its constructor, such as an instance of ``IHostingEnvironment`` which can be used to customize the behavior of the class based on the environment in which it is running. Typically, the way an application will be configured is defined within its Startup class's constructor (learn more about :doc:`configuration`). The Startup class must define a ``Configure()`` method, and may optionally also define a ``ConfigureServices()`` method, which will be called by the server hosting the application when it is started.

Configure()
^^^^^^^^^^^

The ``Configure()`` method is used to specify how the ASP.NET application will respond to individual HTTP requests. At its simplest, you can configure every request to receive the same response. However, most real-world applications require more functionality than this. The ASP.NET team recommends that more complex sets of pipeline configuration be encapsulated in extension methods on ``IApplicationBuilder``, to keep the ``Configure()`` method concise and easy to follow. In this example from the default web site template, you can see several extension methods are used to configure the pipeline with support for BrowserLink, error pages, static files, ASP.NET MVC, and Identity.

.. literalinclude:: ../../samples/WebApplication1/src/WebApplication1/Startup.cs
	:language: c#
	:linenos:
	:lines: 88-134
	:dedent: 8
	:emphasize-lines: 12-14,20,24,27,37

You can see what each of these extensions does by examining the source. For instance, the ``UseMvc()`` extension method is defined in `BuilderExtensions <https://github.com/aspnet/Mvc/blob/dev/src/Microsoft.AspNet.Mvc/BuilderExtensions.cs>`_, available on GitHub. Its primary responsibility is to ensure MVC was added as a service (in ``ConfigureServices()``) and to correctly set up routing for an ASP.NET MVC application. We'll examine the specifics of how to configure your application's request pipeline later in this article.

ConfigureServices()
^^^^^^^^^^^^^^^^^^^

Your `Startup` class can optionally include a ``ConfigureServices()`` method, which is called before ``Configure()``. This is important, because some features like ASP.NET MVC require certain services to be added in ``ConfigureServices()`` before they can be wired up to the request pipeline.

Just as with ``Configure()``, it is recommended that features that require substantial setup within ``ConfigureServices()`` be wrapped up in extension methods on ``IApplicationBuilder``. You can see in this example from the default web site template that several ``Add[Something]`` extension methods are used to configure the app to use Entity Framework, Identity, and MVC:

.. literalinclude:: ../../samples/WebApplication1/src/WebApplication1/Startup.cs
	:language: c#
	:linenos:
	:lines: 48-87
	:dedent: 8
	:emphasize-lines: 8,14,34

Adding services to the services container makes them available within your application via :doc:`dependency-injection`. Just as the ``Startup`` class is able to specify dependencies its methods require as parameters, rather than hard-coding to a specific implementation, so too can your controllers and other classes in your application.

The ``ConfigureServices()`` method is also where you should add configuration option classes, like ``AppSettings`` in the example above, that you would like to have available in your application (:doc:`learn more <configuration>`).

Understanding request delegates
-------------------------------

ASP.NET 5 implements the Open Web Interface for .NET (OWIN). OWIN provides a standardized way for web applications to communicate with web servers, and specifies request delegates that respond to web requests. Request delegates are used to build the :ref:`request pipeline <request-pipeline>` that will be used to handle each incoming HTTP request to your application. Request delegates are configured using `Run, Map, and Use`_ extension methods on the ``IApplicationBuilder`` type that is passed into the ``Configure()`` method in the ``Startup`` class. Request delegates, also known as :doc:`middleware`,  can be specified in-line as anonymous methods, or they can be defined in reusable classes.

The simplest possible ASP.NET application sets up a single request delegate that handles all requests. In this case, there isn't really a request "pipeline", so much as a single anonymous function that is called in response to every HTTP request.

.. literalinclude:: startup/sample/StartupDemo/src/StartupDemo/Startup.cs
	:language: c#
	:linenos:
	:lines: 22-25
	:dedent: 12

It's important to realize that request delegate, as written here, will terminate the pipeline, regardless of other calls to ``App.Run`` that you may include. In the following example, only the first delegate ("Hello, World!") will be executed and displayed.

.. literalinclude:: startup/sample/StartupDemo/src/StartupDemo/Startup.cs
	:language: c#
	:linenos:
	:lines: 20-31
	:emphasize-lines: 5
	:dedent: 8

You chain multiple request delegates together making a different call, with a ``next`` parameter representing the next delegate in the pipeline. Note that just because you're calling it "next" doesn't mean you can't perform actions both before and after the next delegate, as this example demonstrates:

.. literalinclude:: startup/sample/StartupDemo/src/StartupDemo/Startup.cs
	:language: c#
	:linenos:
	:lines: 34-49
	:emphasize-lines: 5,8,14
	:dedent: 8

.. note:: This ``ConfigureLogInline()`` method is called when the application is run with an environment set to ``LogInline``. Learn more about :doc:`environments`. We will be using variations of ``Configure[Environment]`` to show different options in the rest of this article.

In the above example, the call to ``await next.Invoke()`` will call into the delegate on line 14. The client will receive the expected response ("Hello from LogInline"), and the console output includes both the before and after messages, as you can see here:

.. image:: startup/_static/console-loginline.png

Implementing middleware in its own class
----------------------------------------

For more complex request handling functionality, the ASP.NET team recommends implementing the middleware in its own class, and exposing an ``IApplicationBuilder`` extension method that can be called from the ``Configure()`` method. The simple logging middleware shown in the previous example can be converted into a middleware class that takes in the next ``RequestDelegate`` in its constructor and supports an ``Invoke()`` method as shown:

.. literalinclude:: startup/sample/StartupDemo/src/StartupDemo/RequestLoggerMiddleware.cs
	:language: c#
	:caption: RequestLoggerMiddleware.cs
	:linenos:
	:emphasize-lines: 14, 19

The middleware follows the `Explicit Dependencies Principle <http://deviq.com/explicit-dependencies-principle/>`_ and exposes all of its dependencies in its constructor. The extension method is responsible for providing the required dependencies. You can create overloads of the extension methods that allow dependencies to be passed in from the ``Configure()`` method, as well. The complete class containing the ``UseRequestLogger()`` extension method is shown below:

.. literalinclude:: startup/sample/StartupDemo/src/StartupDemo/RequestLoggerExtensions.cs
	:language: c#
	:caption: RequestLoggerExtensions.cs
	:linenos:
	:emphasize-lines: 16

Using the extension method and associated middleware class, the ``Configure()`` method becomes much simpler and more readable.

.. literalinclude:: startup/sample/StartupDemo/src/StartupDemo/Startup.cs
	:language: c#
	:linenos:
	:lines: 51-62
	:emphasize-lines: 4
	:dedent: 8

.. _request-pipeline:

Setting up your request pipeline
--------------------------------

The ASP.NET request pipeline consists of a sequence of request delegates, called one after the next, as this diagram shows:

.. image:: startup/_static/request-delegate-pipeline.png

Each delegate has the opportunity to perform operations before and after the next delegate. Any delegate can choose to stop passing the request on to the next delegate, and instead handle the request itself. For example, an authorization middleware function might only call the next delegate in the pipeline if the request is authenticated, otherwise it could return some form of "Not Authorized" response. Exception handling delegates need to be called early on in the pipeline, so they are able to catch exceptions that occur in later calls within the call chain.

You can see an example of setting up a request pipeline, using a variety of request delegates, in the default web site template that ships with Visual Studio 2015. Its ``Configure()`` method, shown below, first wires up error pages (in development) or the site's production error handler, then builds out the pipeline with support for static files, ASP.NET Identity authentication, and finally, ASP.NET MVC.

.. literalinclude:: ../../samples/WebApplication1/src/WebApplication1/Startup.cs
	:language: c#
	:linenos:
	:lines: 89-134
	:dedent: 8
	:emphasize-lines: 11-13,19,23,26,36

Because of the order in which this pipeline was constructed, ``UseErrorHandler()`` will catch any exceptions that occur in later calls (in non-development environments). Also, in this example a design decision has been made that static files will not be protected by any authentication. This is a tradeoff that improves performance when handling static files since no other middleware (such as authentication middleware) needs to be called when handling these requests. If the request is not for a static file, it will flow to the next piece of middleware defined in the pipeline (in this case, Identity). `View the source of the StaticFileMiddleware <https://github.com/aspnet/StaticFiles/blob/dd3bb685cb5a7e5bc203274da86f0517ea3454d0/src/Microsoft.AspNet.StaticFiles/StaticFileMiddleware.cs#L51-L94>`_.

.. note:: **Remember:** the order in which you arrange your ``Use[Middleware]()`` statements in your application's ``Configure()`` method is very important. Be sure you have a good understanding of how your application's request pipeline will behave in various scenarios.

Run, Map, and Use
-----------------

You configure the HTTP pipeline using the `extensions <https://github.com/aspnet/HttpAbstractions/tree/dev/src/Microsoft.AspNet.Http.Abstractions/Extensions>`_ ``Run``, ``Map``, and ``Use``. The ``Run`` method is simply a shorthand way of adding middleware to the pipeline that doesn't call any other middleware (that is, it will not call a ``next`` request delegate). The following two examples are equivalent to one another, since the second one doesn't use its ``next`` parameter:

.. literalinclude:: startup/sample/StartupDemo/src/StartupDemo/Startup.cs
	:language: c#
	:linenos:
	:lines: 65-79
	:emphasize-lines: 11
	:dedent: 8

.. note:: The ``IApplicationBuilder`` `interface <https://github.com/aspnet/HttpAbstractions/blob/8703e2d7f21d09b50d20cc764e11d6bb0268aad2/src/Microsoft.AspNet.Http.Abstractions/IApplicationBuilder.cs#L17>`_ itself exposes a single ``Use`` method, so technically they're not all *extension* methods.

We've already seen several examples of how to build a request pipeline with ``Use``. The ``Map`` extension method is used to match request delegates based on a request's path. ``Map`` simply accepts a path and a function that configures a separate middleware pipeline. In this example, any request with the base path of ``/maptest`` will be handled by the pipeline configured in the ``HandleMapTest`` method.

.. literalinclude:: startup/sample/StartupDemo/src/StartupDemo/Startup.cs
	:language: c#
	:linenos:
	:lines: 81-97
	:emphasize-lines: 11
	:dedent: 8

In addition to path-based mapping, the ``MapWhen`` method supports predicate-based middleware branching, allowing separate pipelines to be constructed in a very flexible fashion. Any predicate of type ``Func<HttpContext, bool>`` can be used to map requests to a new branch of the pipeline. In the following example, a simple predicate is used to detect the presence of a querystring variable ``branch``:

.. literalinclude:: startup/sample/StartupDemo/src/StartupDemo/Startup.cs
	:language: c#
	:linenos:
	:lines: 95-113
	:emphasize-lines: 11-13
	:dedent: 8

Using the configuration shown above, any request that includes a querystring value for ``branch`` will use the pipeline defined in the ``HandleBranch`` method (in this case, a response of "Branch used.").

Summary
-------

In ASP.NET 5, the ``Startup`` class is responsible for setting up the application, including its configuration, the services it will use, and how it will process requests. Request pipelines can be as simple as a single line, or they can include rich behavior consisting of multiple levels of middleware and pipeline branches based on request properties.

Additional Resources
--------------------

- :doc:`owin`
- :doc:`middleware`
- :doc:`environments`

