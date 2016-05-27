Introduction to ASP.NET Core
============================

By `Daniel Roth`_

ASP.NET Core is a significant redesign of ASP.NET. This topic introduces the new concepts in ASP.NET Core and explains how they help you develop modern web apps.

.. contents:: Sections:
  :local:
  :depth: 1
  
What is ASP.NET Core?
---------------------

ASP.NET Core is a new open-source and cross-platform framework for building modern cloud-based Web applications using .NET. We built it from the ground up to provide an optimized development framework for apps that are either deployed to the cloud or run on-premises. It consists of modular components with minimal overhead, so you retain flexibility while constructing your solutions. You can develop and run your ASP.NET Core applications cross-platform on Windows, Mac and Linux. ASP.NET Core is fully open source on `GitHub <https://github.com/aspnet/home>`_.

Why build ASP.NET Core?
-----------------------

The first preview release of ASP.NET came out almost 15 years ago as part of the .NET Framework.  Since then millions of developers have used it to build and run great web applications, and over the years we have added and evolved many, many capabilities to it.

With ASP.NET Core we are making a number of architectural changes that make the core web framework much leaner and more modular. ASP.NET Core is no longer based on System.Web.dll, but is instead based on a set of granular and well factored NuGet packages allowing you to optimize your app to have just what you need. You can reduce the surface area of your application to improve security, reduce your servicing burden and also to improve performance in a true pay-for-what-you-use model.

ASP.NET Core is built with the needs of modern Web applications in mind, including a unified story for building Web UI and Web APIs that integrate with today's modern client-side frameworks and development workflows. ASP.NET Core is also built to be cloud-ready by introducing environment-based configuration and by providing built-in dependency injection support.

To appeal to a broader audience of developers, ASP.NET Core supports cross-platform development on Windows, Mac and Linux. The entire ASP.NET Core stack is open source and encourages community contributions and engagement. ASP.NET Core comes with a new, agile project system in Visual Studio while also providing a complete command-line interface so that you can develop using the tools of your choice.

In summary, with ASP.NET Core you gain the following foundational improvements:

- New light-weight and modular HTTP request pipeline
- Ability to host on IIS or self-host in your own process
- Built on `.NET Core`_, which supports true side-by-side app versioning
- Ships entirely as NuGet packages
- Integrated support for creating and using NuGet packages
- Single aligned web stack for Web UI and Web APIs
- Cloud-ready environment-based configuration
- Built-in support for dependency injection
- New tooling that simplifies modern web development
- Build and run cross-platform ASP.NET apps on Windows, Mac and Linux
- Open source and community focused

Application anatomy
-------------------

ASP.NET Core applications are defined using a public ``Startup`` class:

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

The ``ConfigureServices`` method defines the services used by your application and the ``Configure`` method is used to define what middleware makes up your request pipeline. See :doc:`/fundamentals/startup` for more details.

Services
--------

A service is a component that is intended for common consumption in an application. Services are made available through dependency injection. ASP.NET Core includes a simple built-in inversion of control (IoC) container that supports constructor injection by default, but can be easily replaced with your IoC container of choice. See :doc:`/fundamentals/dependency-injection` for more details.

Services in ASP.NET Core come in three varieties: singleton, scoped and transient. Transient services are created each time they’re requested from the container. Scoped services are created only if they don’t already exist in the current scope. For Web applications, a container scope is created for each request, so you can think of scoped services as per request. Singleton services are only ever created once.

Middleware
----------

In ASP.NET Core you compose your request pipeline using :doc:`/fundamentals/middleware`. ASP.NET Core middleware perform asynchronous logic on an ``HttpContext`` and then optionally  invoke the next middleware in the sequence or terminate the request directly. You generally "Use" middleware by invoking a corresponding extension method on the ``IApplicationBuilder`` in your ``Configure`` method.

ASP.NET Core comes with a rich set of prebuilt middleware:

- :doc:`/fundamentals/static-files`
- :doc:`/fundamentals/routing`
- :doc:`/fundamentals/diagnostics`
- :doc:`/security/authentication/index`

You can also author your own :doc:`custom middleware </fundamentals/middleware>`.

You can use any `OWIN <http://owin.org>`_-based middleware with ASP.NET Core. See :doc:`/fundamentals/owin` for details.

Servers
-------

The ASP.NET Core hosting model does not directly listen for requests, but instead relies on an HTTP :doc:`server </fundamentals/servers>` implementation to surface the request to the application as a set of feature interfaces that can be composed into an HttpContext. ASP.NET Core includes a managed cross-platform web server, called :ref:`Kestrel <kestrel>`, that you would typically run behind a production web server like `IIS <https://iis.net>`__ or `nginx <http://nginx.org>`__.

Web root
--------

The Web root of your application is the root location in your project from which HTTP requests are handled (ex. handling of static file requests). The Web root of an ASP.NET Core application is configured using the "webroot" property in your project.json file.

Configuration
-------------

ASP.NET Core uses a new configuration model for handling of simple name-value pairs that is not based on System.Configuration or web.config. This new configuration model pulls from an ordered set of configuration providers. The built-in configuration providers support a variety of file formats (XML, JSON, INI) and also environment variables to enable environment-based configuration. You can also write your own custom configuration providers. Environments, like Development and Production, are a first-class notion in ASP.NET Core and can also be set up using environment variables:

.. literalinclude:: /../common/samples/WebApplication1/src/WebApplication1/Startup.cs
  :language: none
  :lines: 22-34
  :dedent: 12

See :doc:`/fundamentals/configuration` for more details on the new configuration system and :doc:`/fundamentals/environments` for details on how to work with environments in ASP.NET Core.

Client-side development
-----------------------

ASP.NET Core is designed to integrate seamlessly with a variety of client-side frameworks, including :doc:`AngularJS </client-side/angular>`, :doc:`KnockoutJS </client-side/knockout>` and :doc:`Bootstrap </client-side/bootstrap>`. See :doc:`/client-side/index` for more details.

