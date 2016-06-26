Migrating from ASP.NET 5 RC1 to ASP.NET Core 1.0
================================================

By `Cesar Blum Silveira`_, `Rachel Appel`_, `Rick Anderson`_ 

.. contents:: Sections:
  :local:
  :depth: 1


ASP.NET 5 RC1 apps were based on the .NET Execution Environment (DNX) and made use of DNX specific features. ASP.NET Core 1.0 is based on .NET Core, so you must first migrate your application to the new .NET Core project model. See `migrating from DNX to .NET Core CLI <http://dotnet.github.io/docs/core-concepts/dnx-migration.html>`_ for more information.

See the following resources for a list of some of the most significant changes, announcements and migrations information:

- `ASP.NET Core RC2 significant changes <https://github.com/aspnet/announcements/issues?q=is%3Aopen+is%3Aissue+milestone%3A1.0.0-rc2>`_ 
- `ASP.NET Core 1.0 significant changes <https://github.com/aspnet/announcements/issues?q=is%3Aopen+is%3Aissue+milestone%3A1.0.0>`_
- `Upgrading from Entity Framework RC1 to RTM <https://docs.efproject.net/en/latest/miscellaneous/rc2-rtm-upgrade.html>`_
- :doc:`/migration/rc2-to-rtm`

Update Target Framework Monikers (TFMs)
---------------------------------------

If your app targeted ``dnx451`` or  ``dnxcore50`` in the ``frameworks`` section of *project.json*, you must make the following changes:

==================================== ====================================
DNX                                  .NET Core
==================================== ====================================
``dnx451``                           ``net451``
``dnxcore50``                        ``netcoreapp1.0``
==================================== ====================================

.NET Core apps must add a dependency to the ``Microsoft.NETCore.App`` package:

.. original - 
  {  
     "frameworks": {  
       "netcoreapp1.0": {  
         "dependencies": {  
           "Microsoft.NETCore.App": {  
             "version": "1.0.0",  
             "type": "platform"  
           }  
         }  

.. code-block:: none
  
  "dependencies": {
    "Microsoft.NETCore.App": {
      "version": "1.0.0",
      "type": "platform"
    },

Namespace and package ID changes
--------------------------------

- ASP.NET 5 has been renamed to ASP.NET Core 1.0
- ASP.NET MVC and Identity are now part of ASP.NET Core
- ASP.NET MVC 6 is now ASP.NET Core MVC
- ASP.NET Identity 3 is now ASP.NET Core Identity
- ASP.NET Core 1.0 package versions are ``1.0.0``
- ASP.NET Core 1.0 tool package versions are ``1.0.0-preview2-final``

Namespace and package name changes:

==========================================    ===================================================
ASP.NET 5 RC1                                 ASP.NET Core 1.0
==========================================    ===================================================
``Microsoft.AspNet.*``                        ``Microsoft.AspNetCore.*``
``EntityFramework.*``                         ``Microsoft.EntityFrameworkCore.*``
``Microsoft.Data.Entity.*``                   ``Microsoft.EntityFrameworkCore.*``
==========================================    ===================================================

The ``EntityFramework.Commands`` package is no longer available. The ``ef`` command is now available as a tool in the ``Microsoft.EntityFrameworkCore.Tools`` package.

The following packages have been renamed:

==========================================    ===================================================
ASP.NET 5 RC1                                 ASP.NET Core 1.0
==========================================    ===================================================
EntityFramework.MicrosoftSqlServer            Microsoft.EntityFrameworkCore.SqlServer
Microsoft.AspNet.Diagnostics.Entity           Microsoft.AspNetCore.Dianostics.EntityFrameworkCore
Microsoft.AspNet.Identity.EntityFramework     Microsoft.AspNetCore.Identity.EntityFrameworkCore
Microsoft.AspNet.Tooling.Razor                Microsoft.AspNetCore.Razor.Tools
==========================================    ===================================================

Commands and tools
------------------

The ``commands`` section of  the *project.json* file is no longer supported. Use ``dotnet run`` or ``dotnet <DLL name>`` instead.

.NET Core CLI has introduced the concept of tools. *project.json* now supports a ``tools`` section where packages containing tools can be specified. Some important functionality for ASP.NET Core 1.0 applications has been moved to tools.

See `.NET Core CLI extensibility model <https://dotnet.github.io/docs/core-concepts/core-sdk/cli/extensibility.html>`_ for more information on .NET Core CLI tools.

Publishing to IIS
^^^^^^^^^^^^^^^^^

IIS publishing is now provided by the ``publish-iis`` tool in the ``Microsoft.AspNetCore.Server.IISIntegration.Tools`` package. If you intend to run your app behind IIS, add the ``publish-iis`` tool to your *project.json*:

.. code-block:: json

  {
    "tools": {
      "Microsoft.AspNetCore.Server.IISIntegration.Tools": "1.0.0-preview2-final"
    }
  }

The ``publish-iis`` tool is commonly used in the ``postpublish`` script in *project.json*:

.. code-block:: json

  {
    "postpublish": [ "dotnet publish-iis --publish-folder %publish:OutputPath% --framework %publish:FullTargetFramework%" ]
  }

Entity Framework commands
^^^^^^^^^^^^^^^^^^^^^^^^^

The ``ef`` tool is now provided in the ``Microsoft.EntityFrameworkCore.Tools`` package:

.. code-block:: json

  {
    "tools": {
      "Microsoft.EntityFrameworkCore.Tools": "1.0.0-preview2-final"
    }
  }

For more information, see `.NET Core CLI <https://docs.efproject.net/en/latest/cli/dotnet.html>`_.

Razor tools
^^^^^^^^^^^

Razor tooling is now provided in the ``Microsoft.AspNetCore.Razor.Tools`` package:

.. code-block:: json

  {
    "tools": {
      "Microsoft.AspNetCore.Razor.Tools": "1.0.0-preview2-final"
    }
  }

SQL cache tool
^^^^^^^^^^^^^^

The ``sqlservercache`` command, formerly provided by the ``Microsoft.Extensions.Caching.SqlConfig`` package, has been replaced by the ``sql-cache`` tool, available through the ``Microsoft.Extensions.Caching.SqlConfig.Tools`` package:

.. code-block:: json

  {
    "tools": {
      "Microsoft.Extensions.Caching.SqlConfig.Tools": "1.0.0-preview2-final"
    }
  }

User secrets manager
^^^^^^^^^^^^^^^^^^^^

The ``user-secret`` command, formerly provided by the ``Microsoft.Extensions.SecretManager`` package, has been replaced by the ``user-secrets`` tool, available through the ``Microsoft.Extensions.SecretManager.Tools`` package:

.. code-block:: json

  {
    "tools": {
      "Microsoft.Extensions.SecretManager.Tools": "1.0.0-preview2-final"
    }
  }

File watcher
^^^^^^^^^^^^

The ``watch`` command, formerly provided by the ``Microsoft.Dnx.Watcher`` package, has been replaced by the ``watch`` tool, available through the ``Microsoft.DotNet.Watcher.Tools`` package:

.. code-block:: json

  {
    "tools": {
      "Microsoft.DotNet.Watcher.Tools": "1.0.0-preview2-final"
    }
  }

For more information on the file watcher, see **Dotnet watch** in  :doc:`/tutorials/index`.

Hosting
-------

Creating the web application host
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

ASP.NET Core 1.0 apps are console apps; you must define an entry point for your app that sets up a web host and runs it. Below is an example from the startup code for one of the Web Application templates in Visual Studio:

.. code-block:: c#

  public class Program
  {
      public static void Main(string[] args)
      {
          var host = new WebHostBuilder()
              .UseKestrel()
              .UseContentRoot(Directory.GetCurrentDirectory())
              .UseIISIntegration()
              .UseStartup<Startup>()
              .Build();

          host.Run();
      }
  }

You must add the ``emitEntryPoint`` to the ``buildOptions`` section of your application's *project.json*:

.. code-block:: json

  {
    "buildOptions": {
      "emitEntryPoint": true
    }
  }

Class and interface renames
^^^^^^^^^^^^^^^^^^^^^^^^^^^

All classes and interfaces prefixed with ``WebApplication`` have been renamed to start with ``WebHost``:

===========================    =========================
ASP.NET 5 RC1                  ASP.NET Core 1.0
===========================    =========================
IWebApplicationBuilder         IWebHostBuilder
WebApplicationBuilder          WebHostBuilder
IWebApplication                IWebHost
WebApplication                 WebHost
WebApplicationOptions          WebHostOptions
WebApplicationDefaults         WebHostDefaults
WebApplicationService          WebHostService
WebApplicationConfiguration    WebHostConfiguration
===========================    =========================

Content root and web root
^^^^^^^^^^^^^^^^^^^^^^^^^

The application base path is now called the content root.

The web root of your application is no longer specified in your *project.json* file. It is defined when setting up the web host and defaults to ``wwwroot``. Call the :dn:method:`~Microsoft.AspNetCore.Hosting.HostingAbstractionsWebHostBuilderExtensions.UseWebRoot` extension method to specify a different web root folder. Alternatively, you can specify the web root folder in configuration and call the :dn:method:`~Microsoft.AspNetCore.Hosting.HostingAbstractionsWebHostBuilderExtensions.UseConfiguration` extension method.

Server address binding
^^^^^^^^^^^^^^^^^^^^^^

The server addresses that your application listens on can be specified using the :dn:method:`~Microsoft.AspNetCore.Hosting.HostingAbstractionsWebHostBuilderExtensions.UseUrls` extension method or through configuration.

Specifying only a port number as a binding address is no longer supported. The default binding address is \http://localhost:5000

Hosting configuration
^^^^^^^^^^^^^^^^^^^^^

The ``UseDefaultHostingConfiguration`` method is no longer available. The only configuration values read by default by :dn:class:`~Microsoft.AspNetCore.Hosting.WebHostBuilder` are those specified in environment variables prefixed with ``ASPNETCORE_*``. All other configuration sources must now be added explicitly to an :dn:iface:`~Microsoft.Extensions.Configuration.IConfigurationBuilder` instance. See :doc:`/fundamentals/configuration` for more information.

The environment key is set with the ``ASPNETCORE_ENVIRONMENT`` environment variable. ``ASPNET_ENV`` and ``Hosting:Environment`` are still supported, but generate a deprecated message warning.

Hosting service changes
^^^^^^^^^^^^^^^^^^^^^^^

Dependency injection code that uses ``IApplicationEnvironment`` must now use :dn:iface:`~Microsoft.AspNetCore.Hosting.IHostingEnvironment`. For example, in your ``Startup`` class, change:

.. code-block:: c#

  public Startup(IApplicationEnvironment applicationEnvironment)

To:

.. code-block:: c#

  public Startup(IHostingEnvironment hostingEnvironment)

Kestrel
-------

Kestrel configuration has changed. `This GitHub announcement <https://github.com/aspnet/Announcements/issues/168>`_ outlines the changes you must make to configure Kestrel if you are not using default settings.

Controller and action results renamed
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

The following :dn:class:`~Microsoft.AspNetCore.Mvc.Controller` methods have been renamed and moved to :dn:class:`~Microsoft.AspNetCore.Mvc.ControllerBase`:

==================================  ==================
ASP.NET 5 RC1                       ASP.NET Core 1.0
==================================  ==================
HttpUnauthorized                    Unauthorized
HttpNotFound (and its overloads)    NotFound
HttpBadRequest (and its overloads)  BadRequest
==================================  ==================

The following action result types have also been renamed:

=============================================  =============================================
ASP.NET 5 RC1                                        ASP.NET Core 1.0
=============================================  =============================================
Microsoft.AspNet.Mvc.HttpOkObjectResult        Microsoft.AspNetCore.Mvc.OkObjectResult
Microsoft.AspNet.Mvc.HttpOkResult              Microsoft.AspNetCore.Mvc.OkResult
Microsoft.AspNet.Mvc.HttpNotFoundObjectResult  Microsoft.AspNetCore.Mvc.NotFoundObjectResult
Microsoft.AspNet.Mvc.HttpNotFoundResult        Microsoft.AspNetCore.Mvc.NotFoundResult
Microsoft.AspNet.Mvc.HttpStatusCodeResult      Microsoft.AspNetCore.Mvc.StatusCodeResult
Microsoft.AspNet.Mvc.HttpUnauthorizedResult    Microsoft.AspNetCore.Mvc.UnauthorizedResult
=============================================  =============================================

ASP.NET 5 MVC compile views
---------------------------

To compile views, set the ``preserveCompilationContext`` option in *project.json* to preserve the compilation context, as shown here:

.. code-block:: json

  {
    "buildOptions": {
      "preserveCompilationContext": true
    }
  }

Changes in views
^^^^^^^^^^^^^^^^

Views now support relative paths.

The Validation Summary Tag Helper ``asp-validation-summary`` attribute value has changed. Change:

.. code-block:: html

  <div asp-validation-summary="ValidationSummary.All"></div>

To:

.. code-block:: html

  <div asp-validation-summary="All"></div>

Changes in ViewComponents
^^^^^^^^^^^^^^^^^^^^^^^^^

- The sync APIs have been removed
- ``Component.Render()``, ``Component.RenderAsync()``, and ``Component.Invoke()`` have been removed
- To reduce ambiguity in View Component method selection, we've modified the selection to only allow exactly one ``Invoke()`` or ``InvokeAsync()`` per View Component
- ``InvokeAsync()`` now takes an anonymous object instead of separate parameters
- To use a view component, call ``@Component.InvokeAsync("Name of view component", <parameters>)`` from a view. The parameters will be passed to the ``InvokeAsync()`` method. The following example demonstrates the ``InvokeAsync()`` method call with two parameters:

ASP.NET 5 RC1:

.. code-block:: c#

  @Component.InvokeAsync("Test", "MyName", 15)

ASP.NET Core 1.0:

.. code-block:: c#

  @Component.InvokeAsync("Test", new { name = "MyName", age = 15 })
  @Component.InvokeAsync("Test", new Dictionary<string, object> { 
                         ["name"] = "MyName", ["age"] = 15 })
  @Component.InvokeAsync<TestViewComponent>(new { name = "MyName", age = 15})

Updated controller discovery rules
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

There are changes that simplify controller discovery:

The new :dn:class:`~Microsoft.AspNetCore.Mvc.ControllerAttribute` can be used to mark a class (and it's subclasses) as a controller. A class whose name doesn't end in ``Controller`` and derives from a base class that ends in ``Controller`` is no longer considered a controller. In this scenario, :dn:class:`~Microsoft.AspNetCore.Mvc.ControllerAttribute` must be applied to the derived class itself or to the base class.

A type is considered a controller if **all** the following conditions are met:

- The type is a public, concrete, non-open generic class
- :dn:class:`~Microsoft.AspNetCore.Mvc.NonControllerAttribute` is **not** applied to any type in its hierarchy
- The type name ends with ``Controller``, or :dn:class:`~Microsoft.AspNetCore.Mvc.ControllerAttribute` is applied to the type or one of its ancestors.

.. note:: If :dn:class:`~Microsoft.AspNetCore.Mvc.NonControllerAttribute` is applied anywhere in the type hierarchy, the discovery conventions will never consider that type or its descendants to be a controller. In other words, :dn:class:`~Microsoft.AspNetCore.Mvc.NonControllerAttribute` takes precedence over :dn:class:`~Microsoft.AspNetCore.Mvc.ControllerAttribute`.

Configuration
-------------

The :dn:iface:`~Microsoft.Extensions.Configuration.IConfigurationSource` interface has been introduced to represent the configuration used to build an :dn:iface:`~Microsoft.Extensions.Configuration.IConfigurationProvider`. It is no longer possible to access the provider instances from :dn:iface:`~Microsoft.Extensions.Configuration.IConfigurationBuilder`, only the sources. This is intentional, and may cause loss of functionality as you can no longer do things like call ``Load`` on the provider instances.

File-based configuration providers support both relative and absolute paths to configuration files. If you want to specify file paths relative to your application's content root, you must call the :dn:method:`~Microsoft.Extensions.Configuration.FileConfigurationExtensions.SetBasePath` extension method on :dn:iface:`~Microsoft.Extensions.Configuration.IConfigurationBuilder`:

.. code-block:: c#
  :emphasize-lines: 4

  public Startup(IHostingEnvironment env)
  {
      var builder = new ConfigurationBuilder()
          .SetBasePath(env.ContentRootPath)
          .AddJsonFile("appsettings.json");
  }

Automatic reload on change
^^^^^^^^^^^^^^^^^^^^^^^^^^

The ``IConfigurationRoot.ReloadOnChanged`` extension method is no longer available. File-based configuration providers now provide extension methods to :dn:iface:`~Microsoft.Extensions.Configuration.IConfigurationBuilder` that allow you to specify whether configuration from those providers should be reloaded when there are changes in their files. See :dn:method:`~Microsoft.Extensions.Configuration.JsonConfigurationExtensions.AddJsonFile`, :dn:method:`~Microsoft.Extensions.Configuration.XmlConfigurationExtensions.AddXmlFile` and :dn:method:`~Microsoft.Extensions.Configuration.IniConfigurationExtensions.AddIniFile` for details.

Logging
-------

``LogLevel.Verbose`` has been renamed to :dn:field:`~Microsoft.Extensions.Logging.LogLevel.Trace` and is now considered less severe than :dn:field:`~Microsoft.Extensions.Logging.LogLevel.Debug`.

The ``MinimumLevel`` property has been removed from :dn:iface:`~Microsoft.Extensions.Logging.ILoggerFactory`. Each logging provider now provides extension methods to :dn:iface:`~Microsoft.Extensions.Logging.ILoggerFactory` that allow specifying a minimum logging level. See :dn:method:`~Microsoft.Extensions.Logging.ConsoleLoggerExtensions.AddConsole`, :dn:method:`~Microsoft.Extensions.Logging.DebugLoggerFactoryExtensions.AddDebug`, and :dn:method:`~Microsoft.Extensions.Logging.EventLoggerFactoryExtensions.AddEventLog` for details.

Identity
--------

The signatures for the following methods or properties have changed:

===============================================================  ===========================================
ASP.NET 5 RC1                                                    ASP.NET Core 1.0
===============================================================  ===========================================
ExternalLoginInfo.ExternalPrincipal                              ExternalLoginInfo.Principal
User.IsSignedIn()                                                SignInManager.IsSignedIn(User)
UserManager.FindByIdAsync(HttpContext.User.GetUserId())          UserManager.GetUserAsync(HttpContext.User)
User.GetUserId()                                                 UserManager.GetUserId(User)
===============================================================  ===========================================

To use Identity in a view, add the following:

.. code-block:: c#

  @using Microsoft.AspNetCore.Identity
  @inject SignInManager<TUser> SignInManager
  @inject UserManager<TUser> UserManager

Working with IIS
----------------

The package ``Microsoft.AspNetCore.IISPlatformHandler`` has been replaced by ``Microsoft.AspNetCore.Server.IISIntegration``.

HttpPlatformHandler has been replaced by the :doc:`ASP.NET Core Module (ANCM) </hosting/aspnet-core-module>`. The *web.config* file created by the *Publish to IIS tool* now configures IIS to the ANCM instead of HttpPlatformHandler to reverse-proxy requests.

The ASP.NET Core Module must be configured in *web.config*:

.. code-block:: xml

  <configuration>
    <system.webServer>
      <handlers>
        <add name="aspNetCore" path="*" verb="*" modules="AspNetCoreModule" resourceType="Unspecified"/>
      </handlers>
      <aspNetCore processPath="%LAUNCHER_PATH%" arguments="%LAUNCHER_ARGS%"
                  stdoutLogEnabled="false" stdoutLogFile=".\logs\stdout"
                  forwardWindowsAuthToken="false"/>
    </system.webServer>
  </configuration>

The *Publish to IIS tool* generates a correct *web.config*. See :doc:`/publishing/iis` for more details.

IIS integration middleware is now configured when creating the :dn:class:`Microsoft.AspNetCore.Hosting.WebHostBuilder`, and is no longer called in the ``Configure`` method of the ``Startup`` class:

.. code-block:: c#

  var host = new WebHostBuilder()
      .UseIISIntegration()
      .Build();

Web Deploy changes
^^^^^^^^^^^^^^^^^^

.. original -Delete ``<app name> - Web Deploy-publish.ps1``. This is a script generated by Visual Studio for web deploy. There is a version for ASP.NET 5 RC1 projects (which are DNX based) and a different script for ASP.NET Core 1.0 projects (which are dotnet based), and those are incompatible with each other. As such, when migrating to ASP.NET Core 1.0, you need to delete the old script and let Visual Studio generate a new one to ensure web deploy works for the migrated project.  

Delete any *<app name> - Web Deploy-publish.ps1* scripts created with Visual Studio web deploy using ASP.NET 5 RC1. The ASP.NET 5 RC1 scripts (which are DNX based) are not compatible with dotnet based scripts. Use Visual Studio to generate new web deploy scripts. 

applicationhost.config changes
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

.. original -If ``applicationhost.config`` was created with ASP.NET 5 RC1 or an earlier release, in ASP.NET Core it will point to the wrong application folder. The ``applicationhost.config`` file will read ``wwwroot`` as the application folder and this is where IIS will look for the ``web.config`` file. But since the ``web.config`` file now goes in the ``approot``, IIS won't find the file and the user may not be able to start the appliation with IIS. 

An *applicationhost.config* file created with ASP.NET 5 RC1 will point ASP.NET Core to an invalid :ref:`content root <content-root-lbl>` location. With such a *applicationhost.config* file, ASP.NET Core will be configured with :ref:`content root <content-root-lbl>`/:ref:`web root <web-root-lbl>` as the :ref:`content root <content-root-lbl>` folder and therefore look for *web.config* in ``Content root/wwwroot``. The *web.config* file must be in the :ref:`content root <content-root-lbl>` folder. When configured like this, the app will terminate with an HTTP 500 error.

Updating Launch Settings in Visual Studio
-----------------------------------------

Update ``launchSettings.json`` to remove the web target and add the following:

.. code-block:: json

  {
    "WebApplication1": {
      "commandName": "Project",
      "launchBrowser": true,
      "launchUrl": "http://localhost:5000",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }

Server garbage collection (GC)
------------------------------

You must turn on server garbage collection in *project.json* or *app.config* when running ASP.NET projects on the full .NET Framework:

.. code-block:: json
 :emphasize-lines: 4

  {
    "runtimeOptions": {
      "configProperties": {
        "System.GC.Server": true
      }
    }
  }
