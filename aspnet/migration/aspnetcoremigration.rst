Migrating from ASP.NET to ASP.NET Core
======================================

In this article:

.. contents:: Sections
  :local:
  :depth: 1  

Overview
--------

This migration guide will cover the essentials on how to migrate projects from ASP.NET to ASP.NET Core. 

For information on migrating from DNX to .NET CLI, see the `DNX RC1->RC2 migration guide <http://placeholder>`_. 

For information regarding a complete list of breaking changes in RC2 for ASP.NET, see the `ASP.NET Announcements page <https://github.com/aspnet/announcements/issues?q=is%3Aopen+is%3Aissue+milestone%3A1.0.0-rc2>`_

Implement main with WebHostBuilder logic
----------------------------------------

Since ASP.NET core apps are just console apps, you must explicitly call ``Main`` to build up the host and tell it to start listening.

.. code-block:: c#

  public class Program
  {
    public static void Main(string[] args) 
      => WebApplication.Run<Startup>(args);
  }

Configure the webroot and port in the ``hosting.json`` file.
webroot definition moved from project.json to hosting.json

WebHostBuilder API updates
--------------------------

All classes prefixed with WebApplication have been renamed to WebHost. This includes:

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

In the ``project.json`` file, ``web`` no longer exists as a command in the ``commands`` section. Use ``run`` or ``dotnet <dllname>`` instead  

.. code-block:: JavaScript

  "commands": {
    "web": "Microsoft.AspNet.Server.Kestrel",
    "ef": "EntityFramework.Commands"
  },

IHostingEnvironment changes 
---------------------------

All environment variables are now prefixed with the ``ASPNETCORE_`` prefix.

======================  =========================    
Old prefix              New prefix                           
======================  =========================  
ASPNET_WEBROOT          ASPNETCORE_WEBROOT
ASPNET_SERVER           ASPNETCORE_SERVER
ASPNET_APP              ASPNETCORE_APP
ASPNET_ENVIRONMENT      ASPNETCORE_ENVIRONMENT
ASPNET_DETAILEDERRORS   ASPNETCORE_DETAILEDERRORS
======================  =========================  

The hosting configuration keys are now consistent with the command line, environment variables, and ``hosting.json`` values. The ``Microsoft.AspNet.Hosting.json`` configuration file was renamed to ``hosting.json``.

Namespace and package name changes
---------------------------------- 

All Microsoft.AspNet.* namespaces are renamed to Microsoft.AspNetCore.*. 
The EntityFramework.* packages and namespaces are changing to Microsoft.EntityFrameworkCore.*.
The version numbers of the above are being reset to 1.0.0-*.

Working with IIS
----------------

Middleware is now setup using ``WebHostBuilder`` and no longer called in the ``Configure`` method of the ``Startup`` class.

Breaking changes in the ``publish-iis`` tool: 

The name of the package that contains the publish-iis tool was changed to ``Microsoft.AspNetCore.Server.IISIntegration.Tools``. This requires changing your project.json file to inlude the "Microsoft.AspNetCore.Server.IISIntegration.Tools" package instead of the "dotnet-publish-iis" package.

The tool needs now to distinguish portable apps from standalone apps to be able to write the ``web.config`` file correctly depending on the application type that is being published. This required adding a new, mandatory parameter ``--framework`` that tells the tool what framework the application was published for.

since HttpPlatformModule was replaced with AspNetCoreModule
the web.config created by the publish-iis tool now configures IIS to use AspNetCoreModule instead of HttpPlatformHandler to forward requests to Kestrel

The code snippet below shows how to configure the new publish-iis tool in project.json file

.. code-block:: JavaScript

"tools": {
  "Microsoft.AspNetCore.Server.IISIntegration.Tools": {
    "version": "1.0.0-*",
    "imports": "portable-net45+wp80+win8+wpa81+dnxcore50"
  }
},
"scripts": {
  "postpublish": "dotnet publish-iis --publish-folder %publish:OutputPath% --framework %publish:FullTargetFramework%"
}

Additionally, you must turn on server garbage collection in ``project.json`` or ``app.config`` when on full .NET framework.

Changes in MVC
--------------

- Set option in ``project.json`` to preserve the compilation context if you are doing views.
- You no longer need to reference the Tag Helper package, it's now referenced by ``Razor`` by default.

There are changes that simplify controller discovery:
There is a new ``Controller`` attribute that can be used to mark a class and their descendants as controllers.
Classes whose name doesn't end in ``Controller`` and derive from a base class that ends in ``Controller`` are no longer considered controllers. In this scenario the ``[Controller]`` attribute must be applied to the ``Controller`` class itself or to the base class.

We now consider a type to be a controller if all of the following rules apply:
- The type is a public, concrete, non open generic class.
- [NonController] is not applied to any type of the hierarchy.
- The type name ends with ``Controller``, or if the ``[Controller]`` attribute is applied to the type or to one of its ancestors.
- It's important to note that if [NonController] is applied anywhere in the type hierarchy the discovery conventions will never consider that type or its descendants to be a controller. ``[NonController]`` takes precedence over ``[Controller]``.


ViewComponents changes
----------------------

-The Sync APIs have been removed.
-``InvokeAsync`` takes an anonynmous object instead of params.
-``web`` is no longer a thing, use dotnetrun or ``dotnet <dll name>`` at the command prompt instead.

Mapping commands to tools
-------------------------

The following commands are now tools: Secret manager, watch, sqlcache. You can configure these in the ``tools`` section in the ``project.json`` file found in the root of your project. 

Configuration
-------------

``IConfigurationSource`` has been introduced to represent the settings/configuration which is used to Build() an IConfigurationProvider. It is no longer possible to access the provider instances from IConfigurationBuilder only the sources. This is intentional, but may cause loss of functionality as you can longer do things like explicitly call Load() on the provider instances.

FileConfigurationProvider base class has been introduced as a common root for Json/Xml/Ini providers. This allows the ability to specify an IFileProvider on the source which will be used to read the file instead of explicitly using File.Open. The side effect of this change is that absolute paths are no longer supported, the file path must be relative to the base path of the IConfigurationBuilder's basepath or the IFileProvider if specified.

Example of configuring sources:

.. code-block:: c#

  new ConfigurationBuilder()
    .SetBasePath(@"C:\SomeOtherDirectory")
      .AddIni("baz.ini")
      .AddIni("whoops.ini", optional: true)
      .AddJson(source => {
          source.Path = "foo.json";
          source.Optional = true;
          source.ReloadOnChanged = false;
       }).AddXml(source => {
          source.Path = "bar.xml";
          source.Optional = true;
          source.ReloadOnChanged = false;
       }).Build();

	   
Entity Framework
----------------

Link to separate EF Core Migration topic here.

Logging
-------

Logging extensions have been simplified and clarified. ``Trace`` is now considered more ``Verbose`` than ``Debug`` and ``Verbose`` has been removed.

``Verbose`` has been renamed to Trace and has had its severity reduced to below ``Debug``. As a comparison before and after the change, the values of ``LogLevel`` are listed here with the most severe level at the top:

=============  =============
Old Levels	   New Levels
=============  =============
Critical	   Critical
Error	       Error
Warning	       Warning
Information	   Information
Verbose	       Debug
Debug	       Trace
=============  =============