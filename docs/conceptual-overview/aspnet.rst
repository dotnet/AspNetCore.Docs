Introduction to ASP.NET 5
=========================
By :ref:`Daniel Roth <aspnet-author>` | Updated : 28 April 2015

ASP.NET 5 is a significant redesign of ASP.NET. This topic introduces the new concepts in ASP.NET 5 and explains how they help you develop modern web apps.

What is ASP.NET 5?
------------------

ASP.NET 5 is a new open-source and cross-platform framework for building modern cloud-based Web applications using .NET. We built it from the ground up to provide an optimized development framework for apps that are either deployed to the cloud or run on-premises. It consists of modular components with minimal overhead, so you retain flexibility while constructing your solutions. You can develop and run your ASP.NET 5 applications cross-platform on Windows, Mac and Linux. ASP.NET 5 is fully open source on `GitHub <https://github.com/aspnet/home>`_.

Why build ASP.NET 5?
--------------------

The first preview release of ASP.NET 1.0 came out almost 15 years ago.  Since then millions of developers have used it to build and run great web applications, and over the years we have added and evolved many, many capabilities to it.

With ASP.NET 5 we are making a number of architectural changes that make the core web framework much leaner and more modular. ASP.NET 5 is no longer based on System.Web.dll, but is instead based on a set of granular and well factored NuGet packages allowing you to optimize your app to have just what you need. You can reduce the surface area of your application to improve security, reduce your servicing burden and also to improve performance in a true pay-for-what-you-use model.

ASP.NET 5 is built with the needs of modern Web applications in mind, including a unified story for building Web UI and Web APIs that integrate with today's modern client-side frameworks and development workflows. ASP.NET 5 is also built to be cloud-ready by introducing environment-based configuration and by providing built-in dependency injection support.

To appeal to a broader audience of developers, ASP.NET 5 supports cross-platform development on Windows, Mac and Linux. The entire ASP.NET 5 stack is open source and encourages community contributions and engagement. ASP.NET 5  comes with a new, agile project system in Visual Studio while also providing a complete command-line interface so that you can develop using the tools of your choice.

In summary, with ASP.NET 5 you gain the following foundational improvements:

- New light-weight and modular HTTP request pipeline
- Ability to host on IIS or self-host in your own process
- Built on .NET Core, which supports true side-by-side app versioning
- Ships entirely as NuGet packages
- Integrated support for creating and using NuGet packages
- Single aligned web stack for Web UI and Web APIs
- Cloud-ready environment-based configuration
- Built-in support for dependency injection
- New tooling that simplifies modern Web development
- Build and run cross-platform ASP.NET apps on Windows, Mac and Linux
- Open source and community focused

Application anatomy
-------------------

ASP.NET 5 applications are built and run using the new :doc:`.NET Execution Environment (DNX) <dnx>`. Every ASP.NET 5 project is a :doc:`DNX project </dnx/projects>`. ASP.NET 5 integrates with DNX through the `ASP.NET Application Hosting <https://nuget.org/packages/Microsoft.AspNet.Hosting>`_ package.

ASP.NET 5 applications are defined using a public ``Startup`` class:

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

The ``ConfigureServices`` method defines the services used by your application and the ``Configure`` method is used to define what middleware makes up your request pipeline. See :doc:`understanding-aspnet5-apps` for more details.

Services
--------

A service is a component that is intended for common consumption in an application. Services are made available through dependency injection. ASP.NET 5 includes a simple built-in inversion of control (IoC) container that supports constructor injection by default, but can be easily replaced with your IoC container of choice. See :doc:`/runtime/dependency-injection` for more details.

Services in ASP.NET 5 come in three varieties: singleton, scoped and transient. Transient services are created each time they’re requested from the container. Scoped services are created only if they don’t already exist in the current scope. For Web applications, a container scope is created for each request, so you can think of scoped services as per request. Singleton services are only ever created once.

Middleware
----------

In ASP.NET 5 you compose your request pipeline using middleware. ASP.NET 5 middleware perform asynchronous logic on an ``HttpContext`` and then optionally  invoke the next middleware in the sequence or terminate the request directly. You generally "Use" middleware by invoking a corresponding extension method on the ``IApplicationBuilder`` in your ``Configure`` method.

ASP.NET 5 comes with a rich set of prebuilt middleware:

- :doc:`/runtime/static-files`
- :doc:`/runtime/routing`
- :doc:`/runtime/diagnostics`
- :doc:`Authentication </security/index>`

You can also author your own :doc:`custom middleware </extensibility/middleware>`.

You can use any `OWIN <http://owin.org>`_-based middleware with ASP.NET 5. See :doc:`/runtime/owin` for details.

Servers
-------

The ASP.NET Application Hosting model does not directly listen for requests, but instead relies on an HTTP server implementation to surface the request to the application as a set of feature interfaces that can be composed into an HttpContext.

ASP.NET 5 includes server support for running on IIS or self-hosting in your own process. On Windows you can host your application outside of IIS using the `WebListener <https://nuget.org/packages/Microsoft.AspNet.Server.WebListener>`_ server, which is based on HTTP.sys. You can also host your application on a non-Windows environment using the cross-platform `Kestrel <https://nuget.org/packages/Kestrel>`_ web server.

Web root
--------

The Web root of your application is the root location in your project from which HTTP requests are handled (ex. handling of static file requests). The Web root of an ASP.NET 5 application is configured using the "webroot" property in your project.json file.

Configuration
-------------

ASP.NET 5 uses a new configuration model for handling of simple name-value pairs that is not based on System.Configuration or web.config. This new configuration model pulls from an ordered set of configuration providers. The built-it configuration providers support a variety of file formats (XML, JSON, INI) and also environment variables to enable environment-based configuration. You can also write your own custom configuration providers. Environments, like Development and Production, are a first-class notion in ASP.NET 5 and can also be set up using environment variables:

.. code-block:: c#

    // Setup configuration sources.
    var configuration = new Configuration()
        .AddJsonFile("config.json")
        .AddJsonFile($"config.{env.EnvironmentName}.json", optional: true);

    if (env.IsEnvironment("Development"))
    {
        // This reads the configuration keys from the secret store.
        // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
        configuration.AddUserSecrets();
    }
    configuration.AddEnvironmentVariables();
    Configuration = configuration;

See :doc:`/runtime/configuration` for more details on the new configuration system and :doc:`/runtime/environments` for details on how to work with environments in ASP.NET 5.

Client-side development
-----------------------

ASP.NET 5 is designed to integrate seamlessly with a variety of client-side frameworks, including `AngularJS <https://angularjs.org/>`_, `KnockoutJS <http://knockoutjs.com>`_ and `Bootstrap <http://getbootstrap.com/>`_. See :doc:`/client-side/index` for more details.

.. _aspnet-author:

.. include:: /_authors/daniel-roth.txt
