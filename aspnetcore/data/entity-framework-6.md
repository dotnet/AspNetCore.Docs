---
title: Getting Started with ASP.NET Core and Entity Framework 6 | Microsoft Docs
author: rick-anderson
ms.author: riande
manager: wpickett
ms.date: 10/14/2016
ms.topic: article
ms.assetid: 016cc836-4c43-45a4-b9a7-9efaf53350df
ms.technology: aspnet
ms.prod: aspnet-core
uid: data/entity-framework-6
---
# Getting Started with ASP.NET Core and Entity Framework 6

By [Paweł Grudzień](https://github.com/pgrudzien12), [Damien Pontifex](https://github.com/DamienPontifex), and [Tom Dykstra](https://github.com/tdykstra)

This article will show you how to use Entity Framework 6 inside an ASP.NET Core application.

## Overview

To use Entity Framework 6, your project has to compile against the full .NET Framework, as Entity Framework 6 does not support .NET Core. If you need cross-platform features you will need to upgrade to [Entity Framework Core](https://docs.efproject.net).

The recommended way to use Entity Framework 6 in an ASP.NET Core 1.0 application is to put the EF6 context and model classes in a class library project (*.csproj* project file) that targets the full framework. Add a reference to the class library from the ASP.NET Core project. See the sample [Visual Studio solution with EF6 and ASP.NET Core projects](https://github.com/aspnet/Docs/tree/master/aspnetcore/data/entity-framework-6/sample/).

It's not feasible to put an EF6 context in an ASP.NET Core 1.0 project because *.xproj*-based projects don't support all of the functionality that EF6 commands such as *Enable-Migrations* require. In a future release of ASP.NET Core, Core projects will be based on *.csproj* files, and at that time you'll be able to include an EF6 context directly in an ASP.NET Core project.

Regardless of project type in which you locate your EF6 context, only EF6 command-line tools work with an EF6 context. For example, `Scaffold-DbContext` is only available in Entity Framework Core. If you need to do reverse engineering of a database into an EF6 model, see [Code First to an Existing Database](https://msdn.microsoft.com/en-us/jj200620).

## Reference full framework and EF6 in the ASP.NET Core project

Your ASP.NET Core project has to reference the full .NET framework and EF6. For example, *project.json* will look similar to the following example (only relevant parts of the file are shown).

<!-- literal_block {"ids": [], "names": [], "highlight_args": {"hl_lines": [3, 29], "linenostart": 1}, "backrefs": [], "dupnames": [], "linenos": false, "classes": [], "xml:space": "preserve", "language": "javascript", "source": "/Users/shirhatti/src/Docs/aspnet/data/entity-framework-6/sample/MVCCore/project.json"} -->

````javascript
{
  "dependencies": {
    "EntityFramework": "6.1.3",
    "Microsoft.AspNetCore.Diagnostics": "1.0.0",
    "Microsoft.AspNetCore.Mvc": "1.0.0",
    "Microsoft.AspNetCore.Razor.Tools": {
      "version": "1.0.0-preview2-final",
      "type": "build"
    },
    "Microsoft.AspNetCore.Server.IISIntegration": "1.0.0",
    "Microsoft.AspNetCore.Server.Kestrel": "1.0.0",
    "Microsoft.AspNetCore.StaticFiles": "1.0.0",
    "Microsoft.Extensions.Configuration.EnvironmentVariables": "1.0.0",
    "Microsoft.Extensions.Configuration.Json": "1.0.0",
    "Microsoft.Extensions.Logging": "1.0.0",
    "Microsoft.Extensions.Logging.Console": "1.0.0",
    "Microsoft.Extensions.Logging.Debug": "1.0.0",
    "Microsoft.Extensions.Options.ConfigurationExtensions": "1.0.0",
    "Microsoft.VisualStudio.Web.BrowserLink.Loader": "14.0.0"
  },

  "tools": {
    "BundlerMinifier.Core": "2.0.238",
    "Microsoft.AspNetCore.Razor.Tools": "1.0.0-preview2-final",
    "Microsoft.AspNetCore.Server.IISIntegration.Tools": "1.0.0-preview2-final"
  },

  "frameworks": {
    "net452": {
      "dependencies": {
        "EF6": {
          "target": "project"
        }
      }
    }
  },
````

If you’re creating a new project, use the **ASP.NET Core Web Application (.NET Framework)** template.

## Handle connection strings

The EF6 command-line tools that you'll use in the EF6 class library project require a default constructor so they can instantiate the context. But you'll probably want to specify the connection string to use in the ASP.NET Core project, in which case your context constructor must have a parameter that lets you pass in the connection string. Here's an example.

<!-- literal_block {"ids": [], "names": [], "highlight_args": {"linenostart": 1}, "backrefs": [], "dupnames": [], "linenos": false, "classes": [], "xml:space": "preserve", "language": "c#", "source": "/Users/shirhatti/src/Docs/aspnet/data/entity-framework-6/sample/EF6/SchoolContext.cs"} -->

````csharp

public class SchoolContext : DbContext
{
    public SchoolContext(string connString) : base(connString)
    {
    }
````

Since your EF6 context doesn't have a parameterless constructor, your EF6 project has to provide an implementation of [IDbContextFactory](https://msdn.microsoft.com/library/hh506876). The EF6 command-line tools will find and use that implementation so they can instantiate the context. Here's an example.

<!-- literal_block {"ids": [], "names": [], "highlight_args": {"linenostart": 1}, "backrefs": [], "dupnames": [], "linenos": false, "classes": [], "xml:space": "preserve", "language": "c#", "source": "/Users/shirhatti/src/Docs/aspnet/data/entity-framework-6/sample/EF6/SchoolContextFactory.cs"} -->

````csharp

public class SchoolContextFactory : IDbContextFactory<SchoolContext>
{
    public SchoolContext Create()
    {
        return new EF6.SchoolContext("Server=(localdb)\\mssqllocaldb;Database=EF6MVCCore;Trusted_Connection=True;MultipleActiveResultSets=true");
    }
}
````

In this sample code, the `IDbContextFactory` implementation passes in a hard-coded connection string. This is the connection string that the command-line tools will use. You'll want to implement a strategy to ensure that the class library uses the same connection string that the calling application uses. For example, you could get the value from an environment variable in both projects.

## Set up dependency injection in the ASP.NET Core project

In the Core project's *Startup.cs* file, set up the EF6 context for dependency injection (DI) in `ConfigureServices`. EF context objects should be scoped for a per-request lifetime.

<!-- literal_block {"ids": [], "names": [], "highlight_args": {"linenostart": 1}, "backrefs": [], "dupnames": [], "linenos": false, "classes": [], "xml:space": "preserve", "language": "c#", "source": "/Users/shirhatti/src/Docs/aspnet/data/entity-framework-6/sample/MVCCore/Startup.cs"} -->

````csharp
public void ConfigureServices(IServiceCollection services)
{
    // Add framework services.
    services.AddMvc();
    services.AddScoped<SchoolContext>(_ => new SchoolContext(Configuration.GetConnectionString("DefaultConnection")));
}
````

You can then get an instance of the context in your controllers by using DI. The code is similar to what you'd write for an EF Core context:

<!-- literal_block {"ids": [], "names": [], "highlight_args": {"linenostart": 1}, "backrefs": [], "dupnames": [], "linenos": false, "classes": [], "xml:space": "preserve", "language": "c#", "source": "/Users/shirhatti/src/Docs/aspnet/data/entity-framework-6/sample/MVCCore/Controllers/StudentsController.cs"} -->

````csharp
public class StudentsController : Controller
{
    private readonly SchoolContext _context;

    public StudentsController(SchoolContext context)
    {
        _context = context;
    }
````

## Sample application

For a working sample application, see the [sample Visual Studio solution](https://github.com/aspnet/Docs/tree/master/aspnetcore/data/entity-framework-6/sample/) that accompanies this article.

This sample can be created from scratch by the following steps in Visual Studio:

* Create a solution.

* **Add New Project > Web > ASP.NET Core Web Application (.NET Framework)**

* **Add New Project > Windows > Class Library**

* In **Package Manager Console** (PMC) for both projects, run the command `Install-Package Entityframework`.

* In the class library project, create data model classes and a context class, and an implementation of `IDbContextFactory`.

* In PMC for the class library project, run the commands `Enable-Migrations` and `Add-Migration Initial`. If you have set the ASP.NET Core project as the startup project, add `-StartupProjectName EF6` to these commands.

* In the Core project, add a project reference to the class library project.

* In the Core project, in *Startup.cs*, register the context for DI.

* In the Core project, add a controller and view(s) to verify that you can read and write data. (Note that ASP.NET Core MVC scaffolding won't work with the EF6 context referenced from the class library.)

## Summary

This article has provided basic guidance for using Entity Framework 6 in an ASP.NET Core application.

## Additional Resources

* [Entity Framework - Code-Based Configuration](https://msdn.microsoft.com/en-us/data/jj680699.aspx)
