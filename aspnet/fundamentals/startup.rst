Application Startup
===================

By `Steve Smith`_

ASP.NET 5 provides complete control of how individual requests are handled by your application. The ``Startup`` class is the entry point to the application, setting up configuration and wiring up services the application will use. Developers configure a request pipeline in the ``Startup`` class that is used to handle all requests made to the application.

In this article:
	- `The Startup class`_
	- `The Configure method`_
	- `The ConfigureServices method`_

The Startup class
-----------------

In ASP.NET 5, the ``Startup`` class provides the entry point for an application. It's possible to have environment-specific startup classes and methods (see :doc:`environments`), but regardless, one ``Startup`` class will serve as the entry point for the application. ASP.NET searches the primary assembly for a class named ``Startup`` (in any namespace). You can specify a different assembly to search using the `Hosting:Application` configuration key. It doesn't matter whether the class is defined as ``public``; ASP.NET will still load it if it conforms to the naming convention. If there are multiple ``Startup`` classes, this will not trigger an exception. ASP.NET will select one based on its namespace (matching the project's root namespace first, otherwise using the class in the alphabetically first namespace).

The ``Startup`` class can optionally accept dependencies in its constructor that are provided through :doc:`dependency injection <dependency-injection>`.  Typically, the way an application will be configured is defined within its Startup class's constructor (see :doc:`configuration`). The Startup class must define a ``Configure`` method, and may optionally also define a ``ConfigureServices`` method, which will be called when the application is started.

The Configure method
--------------------

The ``Configure`` method is used to specify how the ASP.NET application will respond to individual HTTP requests. At its simplest, you can configure every request to receive the same response. However, most real-world applications require more functionality than this. More complex sets of pipeline configuration can be encapsulated in :doc:`middleware <middleware>` and added using extension methods on ``IApplicationBuilder``.

Your ``Configure`` method must accept an ``IApplicationBuilder`` parameter. Additional services, like ``IHostingEnvironment`` and ``ILoggerFactory`` may also be specified, in which case these services will be :doc:`injected <dependency-injection>` by the server if they are available. In the following example from the default web site template, you can see several extension methods are used to configure the pipeline with support for `BrowserLink <http://www.asp.net/visual-studio/overview/2013/using-browser-link>`_, error pages, static files, ASP.NET MVC, and Identity.

.. literalinclude:: /../common/samples/WebApplication1/src/WebApplication1/Startup.cs
	:language: c#
	:linenos:
	:lines: 91-137
	:dedent: 8
	:emphasize-lines: 12-14,20,24,27,37

You can see what each of these extensions does by examining the source. For instance, the ``UseMvc`` extension method is defined in ``BuilderExtensions`` available on `GitHub <https://github.com/aspnet/Mvc/blob/6.0.0-beta4/src/Microsoft.AspNet.Mvc/BuilderExtensions.cs>`_. Its primary responsibility is to ensure MVC was added as a service (in ``ConfigureServices``) and to correctly set up routing for an ASP.NET MVC application. 

You can learn all about middleware and using ``IApplicationBuilder`` to define your request pipeline in the :doc:`middleware` topic.

The ConfigureServices method
----------------------------

Your ``Startup`` class can optionally include a ``ConfigureServices`` method for configuring services that are used by your application. The ``ConfigureServices`` method is a public method on your ``Startup`` class that take a ``IServiceCollection`` as a parameter and optionally returns an ``IServiceProvider``. The ``ConfigureServices`` method is called before ``Configure``. This is important, because some features like ASP.NET MVC require certain services to be added in ``ConfigureServices`` before they can be wired up to the request pipeline.

Just as with ``Configure``, it is recommended that features that require substantial setup within ``ConfigureServices`` be wrapped up in extension methods on ``IServiceCollection``. You can see in this example from the default web site template that several ``Add[Something]`` extension methods are used to configure the app to use services from Entity Framework, Identity, and MVC:

.. literalinclude:: /../common/samples/WebApplication1/src/WebApplication1/Startup.cs
	:language: c#
	:linenos:
	:lines: 50-89
	:dedent: 8
	:emphasize-lines: 5,11,31

Adding services to the services container makes them available within your application via :doc:`dependency injection <dependency-injection>`. Just as the ``Startup`` class is able to specify dependencies its methods require as parameters, rather than hard-coding to a specific implementation, so too can your middleware, MVC controllers and other classes in your application.

The ``ConfigureServices`` method is also where you should add configuration option classes, like ``AppSettings`` in the example above, that you would like to have available in your application. See the :doc:`configuration` topic to learn more about configuring options.

Summary
-------

In ASP.NET 5, the ``Startup`` class is responsible for setting up the application, including its configuration, the services it will use, and how it will process requests. 

Additional Resources
--------------------

- :doc:`environments`
- :doc:`middleware`
- :doc:`owin`
