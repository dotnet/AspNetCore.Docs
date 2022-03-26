---
title: ASP.NET Core and Entity Framework 6
author: rick-anderson
description: Entity Framework 6.3 and later works with ASP.NET Core 3.1 and later.
ms.author: riande
ms.custom: mvc
ms.date: 7/14/2020
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Identity", "Let's Encrypt", Razor, SignalR]
uid: data/entity-framework-6
---
# ASP.NET Core and Entity Framework 6

:::moniker range=">= aspnetcore-3.0"

By [Patrick Goode](https://github.com/attrib75)

## Using Entity Framework 6 with ASP.NET Core

[Entity Framework Core](/ef/) should be used for new development. The [download sample](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/data/entity-framework-6/3.xsample) uses [Entity Framework 6 (EF6)](/ef/ef6), which can be used to migrate existing apps to ASP.NET Core.

## Additional resources

* [Entity Framework - Code-Based Configuration](/ef/ef6/fundamentals/configuring/code-based)

:::moniker-end

:::moniker range="< aspnetcore-3.0"

By [Paweł Grudzień](https://github.com/pgrudzien12) and [Damien Pontifex](https://github.com/DamienPontifex)

This article shows how to use Entity Framework 6 in an ASP.NET Core application.

## Overview

To use Entity Framework 6, your project has to compile against .NET Framework, as Entity Framework 6 doesn't support .NET Core. If you need cross-platform features you will need to upgrade to [Entity Framework Core](/ef/).

The recommended way to use Entity Framework 6 in an ASP.NET Core application is to put the EF6 context and model classes in a class library project that targets .NET Framework. Add a reference to the class library from the ASP.NET Core project. See the sample [Visual Studio solution with EF6 and ASP.NET Core projects](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/data/entity-framework-6/sample/).

You can't put an EF6 context in an ASP.NET Core project because .NET Core projects don't support all of the functionality that EF6 commands such as *Enable-Migrations* require.

Regardless of project type in which you locate your EF6 context, only EF6 command-line tools work with an EF6 context. For example, `Scaffold-DbContext` is only available in Entity Framework Core. If you need to do reverse engineering of a database into an EF6 model, see [Code First to an Existing Database](/ef/ef6/modeling/code-first/workflows/existing-database).

## Reference full framework and EF6 in the ASP.NET Core project

Your ASP.NET Core project needs to target .NET Framework and reference EF6. For example, the `.csproj` file of your ASP.NET Core project will look similar to the following example (only relevant parts of the file are shown).

[!code-xml[](entity-framework-6/sample/MVCCore/MVCCore.csproj?range=3-9&highlight=2)]

When creating a new project, use the **ASP.NET Core Web Application (.NET Framework)** template.

## Handle connection strings

The EF6 command-line tools that you'll use in the EF6 class library project require a default constructor so they can instantiate the context. But you'll probably want to specify the connection string to use in the ASP.NET Core project, in which case your context constructor must have a parameter that lets you pass in the connection string. Here's an example.

[!code-csharp[](entity-framework-6/sample/EF6/SchoolContext.cs?name=snippet_Constructor)]

Since your EF6 context doesn't have a parameterless constructor, your EF6 project has to provide an implementation of <xref:System.Data.Entity.Infrastructure.IDbContextFactory%601>. The EF6 command-line tools will find and use that implementation so they can instantiate the context. Here's an example.

[!code-csharp[](entity-framework-6/sample/EF6/SchoolContextFactory.cs?name=snippet_IDbContextFactory)]

In this sample code, the `IDbContextFactory` implementation passes in a hard-coded connection string. This is the connection string that the command-line tools will use. You'll want to implement a strategy to ensure that the class library uses the same connection string that the calling application uses. For example, you could get the value from an environment variable in both projects.

## Set up dependency injection in the ASP.NET Core project

In the Core project's `Startup.cs` file, set up the EF6 context for dependency injection (DI) in `ConfigureServices`. EF context objects should be scoped for a per-request lifetime.

[!code-csharp[](entity-framework-6/sample/MVCCore/Startup.cs?name=snippet_ConfigureServices&highlight=5)]

You can then get an instance of the context in your controllers by using DI. The code is similar to what you'd write for an EF Core context:

[!code-csharp[](entity-framework-6/sample/MVCCore/Controllers/StudentsController.cs?name=snippet_ContextInController)]

## Sample application

For a working sample application, see the [sample Visual Studio solution](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/data/entity-framework-6/sample/) that accompanies this article.

This sample can be created from scratch by the following steps in Visual Studio:

* Create a solution.

* **Add** > **New Project** > **Web** > **ASP.NET Core Web Application**
  * In project template selection dialog, select API and .NET Framework in dropdown

* **Add** > **New Project** > **Windows Desktop** > **Class Library (.NET Framework)**

* In **Package Manager Console** (PMC) for both projects, run the command `Install-Package Entityframework`.

* In the class library project, create data model classes and a context class, and an implementation of `IDbContextFactory`.

* In PMC for the class library project, run the commands `Enable-Migrations` and `Add-Migration Initial`. If you have set the ASP.NET Core project as the startup project, add `-StartupProjectName EF6` to these commands.

* In the Core project, add a project reference to the class library project.

* In the Core project, in `Startup.cs`, register the context for DI.

* In the Core project, in `appsettings.json`, add the connection string.

* In the Core project, add a controller and view(s) to verify that you can read and write data. (Note that ASP.NET Core MVC scaffolding won't work with the EF6 context referenced from the class library.)

:::moniker-end
