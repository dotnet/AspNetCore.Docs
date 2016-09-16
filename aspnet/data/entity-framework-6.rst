Getting Started with ASP.NET Core and Entity Framework 6
===========================================================

By `Paweł Grudzień`_, `Damien Pontifex`_, and `Tom Dykstra`_

This article will show you how to use Entity Framework 6 inside an ASP.NET Core application.

.. contents:: Sections:
  :local:
  :depth: 1
    
Overview
--------

To use Entity Framework 6, your project has to compile against the full .NET Framework, as Entity Framework 6 does not support .NET Core. If you need cross-platform features you will need to upgrade to `Entity Framework Core`_.  

The recommended way to use Entity Framework 6 in an ASP.NET Core 1.0 application is to put the EF6 context and model classes in a class library project (*.csproj* project file) that targets the full framework. Add a reference to the class library from the ASP.NET Core project. See the sample `Visual Studio solution with EF6 and ASP.NET Core projects <https://github.com/aspnet/Docs/tree/master/aspnet/data/entity-framework-6/sample/>`__.

It's not feasible to put an EF6 context in an ASP.NET Core 1.0 project because *.xproj*-based projects don't support all of the functionality that EF6 commands such as `Enable-Migrations` require. In a future release of ASP.NET Core, Core projects will be based on *.csproj* files, and at that time you'll be able to include an EF6 context directly in an ASP.NET Core project. 

Regardless of project type in which you locate your EF6 context, only EF6 command-line tools work with an EF6 context. For example, ``Scaffold-DbContext`` is only available in Entity Framework Core. If you need to do reverse engineering of a database into an EF6 model, see `Code First to an Existing Database <https://msdn.microsoft.com/en-us/jj200620>`__. 

Reference full framework and EF6 in the ASP.NET Core project
-------------------------------------------------------------

Your ASP.NET Core project has to reference the full .NET framework and EF6. For example, *project.json* will look similar to the following example (only relevant parts of the file are shown).

.. literalinclude::  entity-framework-6/sample/MVCCore/project.json
  :language: javascript
  :end-before:  buildOptions
  :emphasize-lines: 3,29

If you’re creating a new project, use the **ASP.NET Core Web Application (.NET Framework)** template. 

Handle connection strings
-------------------------

The EF6 command-line tools that you'll use in the EF6 class library project require a default constructor so they can instantiate the context. But you'll probably want to specify the connection string to use in the ASP.NET Core project, in which case your context constructor must have a parameter that lets you pass in the connection string. Here's an example.

.. literalinclude::  entity-framework-6/sample/EF6/SchoolContext.cs
  :language: c#
  :start-after: snippet_Constructor
  :end-before:  #endregion
  :dedent: 4

Since your EF6 context doesn't have a parameterless constructor, your EF6 project has to provide an implementation of `IDbContextFactory <https://msdn.microsoft.com/library/hh506876>`__. The EF6 command-line tools will find and use that implementation so they can instantiate the context. Here's an example.

.. literalinclude::  entity-framework-6/sample/EF6/SchoolContextFactory.cs
  :language: c#
  :start-after: snippet_IDbContextFactory
  :end-before:  #endregion
  :dedent: 4

In this sample code, the ``IDbContextFactory`` implementation passes in a hard-coded connection string. This is the connection string that the command-line tools will use. You'll want to implement a strategy to ensure that the class library uses the same connection string that the calling application uses. For example, you could get the value from an environment variable in both projects.
   
Set up dependency injection in the ASP.NET Core project
-------------------------------------------------------

In the Core project's *Startup.cs* file, set up the EF6 context for dependency injection (DI) in ``ConfigureServices``. EF context objects should be scoped for a per-request lifetime.

.. literalinclude::  entity-framework-6/sample/MVCCore/Startup.cs
  :language: c#
  :start-after: snippet_ConfigureServices
  :end-before:  #endregion
  :dedent: 8

You can then get an instance of the context in your controllers by using DI. The code is similar to what you'd write for an EF Core context:

.. literalinclude::  entity-framework-6/sample/MVCCore/Controllers/StudentsController.cs
  :language: c#
  :start-after: snippet_ContextInController
  :end-before:  #endregion
  :dedent: 4

Sample application
------------------

For a working sample application, see the `sample Visual Studio solution <https://github.com/aspnet/Docs/tree/master/aspnet/data/entity-framework-6/sample/>`__ that accompanies this article.

This sample can be created from scratch by the following steps in Visual Studio:

* Create a solution.
* **Add New Project > Web > ASP.NET Core Web Application (.NET Framework)**
* **Add New Project > Windows > Class Library**
* In **Package Manager Console** (PMC) for both projects, run the command ``Install-Package Entityframework``.
* In the class library project, create data model classes and a context class, and an implementation of ``IDbContextFactory``.
* In PMC for the class library project, run the commands ``Enable-Migrations`` and ``Add-Migration Initial``. If you have set the ASP.NET Core project as the startup project, add ``-StartupProjectName EF6`` to these commands.
* In the Core project, add a project reference to the class library project.
* In the Core project, in *Startup.cs*, register the context for DI.
* In the Core project, add a controller and view(s) to verify that you can read and write data. (Note that ASP.NET Core MVC scaffolding won't work with the EF6 context referenced from the class library.)

Summary
-------
This article has provided basic guidance for using Entity Framework 6 in an ASP.NET Core application. 

Additional Resources
--------------------

- `Entity Framework - Code-Based Configuration <https://msdn.microsoft.com/en-us/data/jj680699.aspx>`_
