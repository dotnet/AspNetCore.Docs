Introduction to ASP.NET Core
============================

By `Daniel Roth`_, `Rick Anderson`_ and `Shaun Luttin <https://twitter.com/dicshaunary>`__

ASP.NET Core is a significant redesign of ASP.NET. This topic introduces the new concepts in ASP.NET Core and explains how they help you develop modern web apps.

.. contents:: Sections:
  :local:
  :depth: 1

What is ASP.NET Core?
---------------------

ASP.NET Core is a new open-source and cross-platform framework for building modern cloud based internet connected applications, such as web apps, IoT apps and mobile backends. ASP.NET Core apps can run on `.NET Core <https://www.microsoft.com/net/core/platform>`__ or on the full .NET Framework. It was architected to provide an optimized development framework for apps that are deployed to the cloud or run on-premises. It consists of modular components with minimal overhead, so you retain flexibility while constructing your solutions. You can develop and run your ASP.NET Core apps cross-platform on Windows, Mac and Linux. ASP.NET Core is open source at `GitHub <https://github.com/aspnet/home>`_.

Why build ASP.NET Core?
-----------------------

The first preview release of ASP.NET came out almost 15 years ago as part of the .NET Framework.  Since then millions of developers have used it to build and run great web apps, and over the years we have added and evolved many capabilities to it.

ASP.NET Core has a number of architectural changes that result in a much leaner and modular framework.  ASP.NET Core is no longer based on *System.Web.dll*. It is based on a set of granular and well factored `NuGet <http://www.nuget.org/>`__ packages. This allows you to optimize your app to include just the NuGet packages you need. The benefits of a smaller app surface area include tighter security, reduced servicing, improved performance, and decreased costs in a pay-for-what-you-use model.

With ASP.NET Core you gain the following foundational improvements:

- A unified story for building web UI and web APIs
- Integration of :doc:`modern client-side frameworks </client-side/index>` and development workflows
- A cloud-ready environment-based :doc:`configuration system </fundamentals/configuration>`
- Built-in :doc:`dependency injection </fundamentals/dependency-injection>`
- New light-weight and modular HTTP request pipeline
- Ability to host on IIS or self-host in your own process
- Built on `.NET Core`_, which supports true side-by-side app versioning
- Ships entirely as `NuGet`_  packages
- New tooling that simplifies modern web development
- Build and run cross-platform ASP.NET apps on Windows, Mac and Linux
- Open source and community focused

Application anatomy
-------------------

.. comment In RC1, The work of the WebHostBuilder was hidden in dnx.exe

An ASP.NET Core app is simply a console app that creates a web server in its ``Main`` method:

.. literalinclude:: /getting-started/sample/aspnetcoreapp/Program.cs
    :language: c#

``Main`` uses :dn:cls:`~Microsoft.AspNetCore.Hosting.WebHostBuilder`, which follows the builder pattern, to create a web application host. The builder has methods that define the web server (for example ``UseKestrel``) and the startup class (``UseStartup``). In the example above, the Kestrel web server is used, but other web servers can be specified. We'll show more about ``UseStartup`` in the next section. ``WebHostBuilder`` provides many optional methods including ``UseIISIntegration`` for hosting in IIS and IIS Express and ``UseContentRoot`` for specifying the root content directory. The ``Build`` and ``Run`` methods build the ``IWebHost`` that will host the app and start it listening for incoming HTTP requests.


Startup
---------------------------
The ``UseStartup`` method on ``WebHostBuilder`` specifies the ``Startup`` class for your app.

.. literalinclude:: /getting-started/sample/aspnetcoreapp/Program.cs
    :language: c#
    :lines: 6-17
    :dedent: 4
    :emphasize-lines: 7

The ``Startup`` class is where the you define the request handling pipeline and where any services needed by the app are configured. The ``Startup`` class must be public and contain the following methods:

.. code-block:: c#

  public class Startup
  {
      public void ConfigureServices(IServiceCollection services)
      {
      }

      public void Configure(IApplicationBuilder app)
      {
      }
  }

- ``ConfigureServices`` defines the services (see Services_ below) used by your app (such as the ASP.NET MVC Core framework, Entity Framework Core, Identity, etc.)
- ``Configure`` defines the :doc:`middleware </fundamentals/middleware>` in the request pipeline
- See :doc:`/fundamentals/startup` for more details

Services
--------

A service is a component that is intended for common consumption in an application. Services are made available through dependency injection. ASP.NET Core includes a simple built-in inversion of control (IoC) container that supports constructor injection by default, but can be easily replaced with your IoC container of choice. In addition to its loose coupling benefit, DI makes services available throughout your app. For example, :doc:`Logging </fundamentals/logging>` is available throughout your app. See :doc:`/fundamentals/dependency-injection` for more details.

Middleware
----------

In ASP.NET Core you compose your request pipeline using :doc:`/fundamentals/middleware`. ASP.NET Core middleware performs asynchronous logic on an ``HttpContext`` and then either invokes the next middleware in the sequence or terminates the request directly. You generally "Use" middleware by invoking a corresponding ``UseXYZ`` extension method on the ``IApplicationBuilder`` in the ``Configure`` method.

ASP.NET Core comes with a rich set of prebuilt middleware:

- :doc:`Static files </fundamentals/static-files>`
- :doc:`/fundamentals/routing`
- :doc:`/security/authentication/index`

You can also author your own :doc:`custom middleware </fundamentals/middleware>`.

You can use any `OWIN <http://owin.org>`_-based middleware with ASP.NET Core. See :doc:`/fundamentals/owin` for details. 

Servers
-------

The ASP.NET Core hosting model does not directly listen for requests; rather it relies on an HTTP :doc:`server </fundamentals/servers>` implementation to forward the request to the application. The forwarded request is wrapped as a set of feature interfaces that the application then composes into an ``HttpContext``.  ASP.NET Core includes a managed cross-platform web server, called :ref:`Kestrel <kestrel>`, that you would typically run behind a production web server like `IIS <https://iis.net>`__ or `nginx <http://nginx.org>`__.

Content root
------------

The content root is the base path to any content used by the app, such as its views and web content. By default the content root is the same as application base path for the executable hosting the app; an alternative location can be specified with `WebHostBuilder`.

Web root
--------

The web root of your app is the directory in your project for public, static resources like css, js, and image files. The static files middleware will only serve files from the web root directory (and sub-directories) by default. The web root path defaults to `<content root>/wwwroot`, but you can specify a different location using the `WebHostBuilder`.

Configuration
-------------

ASP.NET Core uses a new configuration model for handling simple name-value pairs. The new configuration model is not based on ``System.Configuration`` or *web.config*; rather, it pulls from an ordered set of configuration providers. The built-in configuration providers support a variety of file formats (XML, JSON, INI) and environment variables to enable environment-based configuration. You can also write your own custom configuration providers.

See :doc:`/fundamentals/configuration` for more information.

Environments
---------------------

Environments, like "Development" and "Production", are a first-class notion in ASP.NET Core and can  be set using environment variables. See :doc:`/fundamentals/environments` for more information.

Build web UI and web APIs using ASP.NET Core MVC
------------------------------------------------

- You can create well-factored and testable web apps that follow the Model-View-Controller (MVC) pattern. See :doc:`/mvc/index` and :doc:`/testing/index`.
- You can build HTTP services that support multiple formats and have full support for content negotiation. See :doc:`/mvc/models/formatting`
- `Razor <http://www.asp.net/web-pages/overview/getting-started/introducing-razor-syntax-c>`__ provides a productive language to create :doc:`Views </mvc/views/index>`
- :doc:`Tag Helpers </mvc/views/tag-helpers/intro>` enable server-side code to participate in creating and rendering HTML elements in Razor files
- You can create HTTP services with full support for content negotiation using custom or built-in formatters (JSON, XML)
- :doc:`/mvc/models/model-binding` automatically maps data from HTTP requests to action method parameters
- :doc:`/mvc/models/validation` automatically performs client and server side validation

Client-side development
-----------------------

ASP.NET Core is designed to integrate seamlessly with a variety of client-side frameworks, including :doc:`AngularJS </client-side/angular>`, :doc:`KnockoutJS </client-side/knockout>` and :doc:`Bootstrap </client-side/bootstrap>`. See :doc:`/client-side/index` for more details.

Next steps
----------

- :doc:`/tutorials/first-mvc-app/index`
- :doc:`/tutorials/your-first-mac-aspnet`
- :doc:`/tutorials/first-web-api`
- :doc:`/fundamentals/index`
