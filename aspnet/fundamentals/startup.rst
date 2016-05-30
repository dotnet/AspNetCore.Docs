.. _application-startup:

Application Startup
===================

By `Steve Smith`_

ASP.NET Core provides complete control of how individual requests are handled by your application. The ``Startup`` class is the entry point to the application, setting up configuration and wiring up services the application will use. Developers configure a request pipeline in the ``Startup`` class that is used to handle all requests made to the application.

.. contents:: Sections:
  :local:
  :depth: 1

The Startup class
-----------------

In ASP.NET Core, the ``Startup`` class provides the entry point for an application, and is required for all applications. It's possible to have environment-specific startup classes and methods (see :doc:`environments`), but regardless, one ``Startup`` class will serve as the entry point for the application. ASP.NET searches the primary assembly for a class named ``Startup`` (in any namespace). You can specify a different assembly to search using the `Hosting:Application` configuration key. It doesn't matter whether the class is defined as ``public``; ASP.NET will still load it if it conforms to the naming convention. If there are multiple ``Startup`` classes, this will not trigger an exception. ASP.NET will select one based on its namespace (matching the project's root namespace first, otherwise using the class in the alphabetically first namespace).

The ``Startup`` class can optionally accept dependencies in its constructor that are provided through :doc:`dependency injection <dependency-injection>`.  Typically, the way an application will be configured is defined within its Startup class's constructor (see :doc:`configuration`). The Startup class must define a ``Configure`` method, and may optionally also define a ``ConfigureServices`` method, which will be called when the application is started.

The Configure method
--------------------

The ``Configure`` method is used to specify how the ASP.NET application will respond to individual HTTP requests. At its simplest, you can configure every request to receive the same response. However, most real-world applications require more functionality than this. More complex sets of pipeline configuration can be encapsulated in :doc:`middleware <middleware>` and added using extension methods on IApplicationBuilder_.

Your ``Configure`` method must accept an IApplicationBuilder_ parameter. Additional services, like ``IHostingEnvironment`` and ``ILoggerFactory`` may also be specified, in which case these services will be :doc:`injected <dependency-injection>` by the server if they are available. In the following example from the default web site template, you can see several extension methods are used to configure the pipeline with support for `BrowserLink <http://www.asp.net/visual-studio/overview/2013/using-browser-link>`_, error pages, static files, ASP.NET MVC, and Identity.

.. literalinclude:: /../common/samples/WebApplication1/src/WebApplication1/Startup.cs
  :language: c#
  :linenos:
  :lines: 58-86
  :dedent: 8
  :emphasize-lines: 8-10,14,17,19,23

Each ``Use`` extension method adds :doc:`middleware <middleware>` to the request pipeline. For instance, the ``UseMvc`` extension method adds the :doc:`routing <routing>` middleware to the request pipeline and configures :doc:`MVC </mvc/index>` as the default handler.

You can learn all about middleware and using IApplicationBuilder_ to define your request pipeline in the :doc:`middleware` topic.

The ConfigureServices method
----------------------------

Your ``Startup`` class can optionally include a ``ConfigureServices`` method for configuring services that are used by your application. The ``ConfigureServices`` method is a public method on your ``Startup`` class that takes an IServiceCollection_ instance as a parameter and optionally returns an ``IServiceProvider``. The ``ConfigureServices`` method is called before ``Configure``. This is important, because some features like ASP.NET MVC require certain services to be added in ``ConfigureServices`` before they can be wired up to the request pipeline.

Just as with ``Configure``, it is recommended that features that require substantial setup within ``ConfigureServices`` be wrapped up in extension methods on IServiceCollection_. You can see in this example from the default web site template that several ``Add[Something]`` extension methods are used to configure the app to use services from Entity Framework, Identity, and MVC:

.. literalinclude:: /../common/samples/WebApplication1/src/WebApplication1/Startup.cs
  :language: c#
  :linenos:
  :lines: 40-55
  :dedent: 8
  :emphasize-lines: 4,7,11

Adding services to the services container makes them available within your application via :doc:`dependency injection <dependency-injection>`. Just as the ``Startup`` class is able to specify dependencies its methods require as parameters, rather than hard-coding to a specific implementation, so too can your middleware, MVC controllers and other classes in your application.

The ``ConfigureServices`` method is also where you should add configuration option classes, like ``AppSettings`` in the example above, that you would like to have available in your application. See the :doc:`configuration` topic to learn more about configuring options.

Services Available in Startup
-----------------------------
ASP.NET Core provides certain application services and objects during your application's startup. You can request certain sets of these services by simply including the appropriate interface as a parameter on your ``Startup`` class's constructor or one of its ``Configure`` or ``ConfigureServices`` methods. The services available to each method in the ``Startup`` class are described below. The framework services and objects include:

IApplicationBuilder
  Used to build the application request pipeline. Available only to the ``Configure`` method in ``Startup``. Learn more about :doc:`request-features`.

IApplicationEnvironment
  Provides access to the application properties, such as ``ApplicationName``, ``ApplicationVersion``, and ``ApplicationBasePath``. Available to the ``Startup`` constructor and ``Configure`` method.

IHostingEnvironment
  Provides the current ``EnvironmentName``, ``WebRootPath``, and web root file provider. Available to the ``Startup`` constructor and ``Configure`` method.

ILoggerFactory
  Provides a mechanism for creating loggers. Available to the ``Startup`` constructor and ``Configure`` method. Learn more about :doc:`logging`.

IServiceCollection
  The current set of services configured in the container. Available only to the ``ConfigureServices`` method, and used by that method to configure the services available to an application.

Looking at each method in the ``Startup`` class in the order in which they are called, the following services may be requested as parameters:

Startup Constructor
- ``IApplicationEnvironment``
- ``IHostingEnvironment``
- ``ILoggerFactory``

ConfigureServices
- ``IServiceCollection``

Configure
- ``IApplicationBuilder``
- ``IApplicationEnvironment``
- ``IHostingEnvironment``
- ``ILoggerFactory``

.. note:: Although ``ILoggerFactory`` is available in the constructor, it is typically configured in the ``Configure`` method. Learn more about :doc:`logging`.

Additional Resources
--------------------

- :doc:`environments`
- :doc:`middleware`
- :doc:`owin`

.. _IApplicationBuilder: https://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/AspNetCore/Builder/IApplicationBuilder/index.html
.. _IServiceCollection: https://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/Extensions/DependencyInjection/IServiceCollection/index.html
