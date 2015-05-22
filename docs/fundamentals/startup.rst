Application Startup
===================

By :ref:`Steve Smith <startup-author>` | Originally Published: 20 May 2015 

ASP.NET 5 provides complete control of how individual requests are handled by your application. The ``Startup`` class is the entry point to the application, setting up configuration and wiring up services the application will use. Developers configure a request pipeline in the ``Startup`` class that is used to handle all requests made to the application.

In this article:
	- `The Startup class`_
	- `Understanding request delegates`_
	- `Setting up your request pipeline`_
	- `Run, Map, and Use`_
	
`Browse or download samples on GitHub <https://github.com/aspnet/Docs/tree/master/docs/fundamentals/startup/sample>`_.

The Startup class
-----------------

In ASP.NET 5, the ``Startup`` class provides the entry point for an application. It's possible to have :doc:`environment-specific startup files and methods <environments>`, but regardless, one ``Startup`` class will serve as the entry point for the application. This ``Startup`` class can optionally accept dependencies in its constructor, such as an instance of ``IHostingEnvironment`` which can be used to customize the behavior of the class based on the environment in which it is running. Typically, the way an application will be configured is defined within its Startup class's constructor (learn more about :doc:`configuration`). The Startup class must define a ``Configure()`` method, and may optionally also define a ``ConfigureServices()`` method, which will be called by the server hosting the application when it is started.

Configure()
^^^^^^^^^^^

The ``Configure()`` method is used to specify how the ASP.NET application will respond to individual HTTP requests. At its simplest, you can configure every request to receive the same response. However, most real-world applications require more functionality than this. The ASP.NET team recommends that more complex sets of pipeline configuration be encapsulated in extension methods on ``IApplicationBuilder``, to keep the ``Configure()`` method concise and easy to follow. In this example from the default web site template, you can see several extensions methods are used to configure the pipeline with support for BrowserLink, error pages, static files, ASP.NET MVC, and Identity.

.. literalinclude:: ../../samples/WebApplication1/src/WebApplication1/Startup.cs
	:language: c#
	:linenos:
	:lines: 88-134
	:dedent: 8
	:emphasize-lines: 12-14,20,24,27,37

You can see what each of these extensions does by examining the source. For instance, the ``UseMvc()`` extension method is defined in `BuilderExtensions <https://github.com/aspnet/Mvc/blob/dev/src/Microsoft.AspNet.Mvc/BuilderExtensions.cs>`_, available on GitHub. Its primary responsibility is to ensure MVC was added as a service (in ``ConfigureServices()``) and to correctly set up routing for an ASP.NET MVC application. We'll examine the specifics of how to configure your application's request pipeline later in this article.

ConfigureServices()
^^^^^^^^^^^^^^^^^^^

Your `Startup` class can optionally include a ``ConfigureServices()`` method, which is called before ``Configure()``. This is important, because some features like ASP.NET MVC require certain services to be added in ``ConfigureServices()`` before they can wired up to the request pipeline. In ``ConfigureServices``

Just as with ``Configure()``, it is recommended that features that require substantial setup within ``ConfigureServices()`` be wrapped up in extension methods on ``IApplicationBuilder``. You can see in this example from the default web site template that several ``Add[Something]`` extensions methods are used to configure the app to use Entity Framework, Identity, and MVC:

.. literalinclude:: ../../samples/WebApplication1/src/WebApplication1/Startup.cs
	:language: c#
	:linenos:
	:lines: 48-87
	:dedent: 8
	:emphasize-lines: 8,14,34

Adding services to the services container makes them available within your application via dependency injection. Just as the ``Startup`` class is able to specify dependencies its methods require as parameters, rather than hard-coding to a specific implementation, so too can your controllers and other classes in your application. :doc:`Learn more about dependency injection <dependency-injection>`.

The ``ConfigureServices()`` method is also where you should add configuration option classes, like ``AppSettings`` in the example above, that you would like to have available in your application (:doc:`learn more <configuration>`).

Understanding request delegates
-------------------------------

ASP.NET 5 implements the Open Web Interface for .NET (OWIN). OWIN provides a standardized way for web applications to communicate with web servers, and specifies request delegates that respond to web requests.


Setting up your request pipeline
--------------------------------

Run, Map, and Use
-----------------


Summary
-------

In ASP.NET 5, you can easily add error pages, view diagnostic information, or respond to requests with a simple welcome page by adding just one line to your app's ``Startup.cs`` class.

Additional Resources
--------------------

- :ref:`Using Application Insights <application-insights>` Collect detailed usage and diagnostic data for your application.

.. _startup-author:

.. include:: /_authors/steve-smith.txt
