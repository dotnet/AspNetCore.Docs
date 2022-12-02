---
title: Incremental ASP.NET to ASP.NET Core Migration
description: Incremental ASP.NET to ASP.NET Core Migration
author: rick-anderson
ms.author: riande
monikerRange: '>= aspnetcore-6.0'
ms.date: 11/9/2022
ms.topic: article
ms.prod: aspnet-core
uid: migration/inc/overview
---

<!-- see mermaid.txt to change diagrams -->

# Incremental ASP.NET to ASP.NET Core migration

Migrating an app from ASP.NET Framework to ASP.NET Core is non-trivial for the majority of production apps. These apps often incorporate new technologies as they become available and are often composed of many legacy decisions. This article provides guidance and links to tools for migrating ASP.NET Framework apps to ASP.NET Core with as little change as possible.

One of the larger challenges is the pervasive use of <xref:System.Web.HttpContext> throughout a code base. Without the incremental approach and tools, a large scale rewrite is required to remove the `System.Web.HttpContext` dependency. The adapters in [dotnet/systemweb-adapters](https://github.com/dotnet/systemweb-adapters) provide a set of runtime helpers to access the types used in the ASP.NET Framework app in a way that works in ASP.NET Core with minimal changes.

A complete migration may take considerable effort depending on the size of the app, dependencies, and non-portable APIs used. In order to keep deploying an app to production while working on migrating, the best pattern is to follow is the [Strangler Fig pattern](/azure/architecture/patterns/strangler-fig). The *Strangler Fig pattern* allows for continual development on the old system with an incremental approach to replacing specific pieces of functionality with new services. This document describes how to apply the Strangler Fig pattern to an ASP.NET app migrating towards ASP.NET Core.

If you'd like to skip this overview article and get started, see [Get started](xref:migration/inc/start).

## App migration to ASP.NET Core

Before starting the migration, the app targets ASP.NET Framework and runs on Windows with its supporting libraries:

![Before starting the migration](~/migration/inc/overview/static/1.png)

Migration starts by introducing a new app based on ASP.NET Core that becomes the entry point. Incoming requests go to the ASP.NET Core app, which either handles the request or proxies the request to the .NET Framework app via [YARP](https://microsoft.github.io/reverse-proxy/). At first, the majority of code providing responses is in the .NET Framework app, but the ASP.NET Core app is now set up to start migrating routes:

![start migrating routes](~/migration/inc/overview/static/nop.png)

To migrate business logic that relies on `HttpContext`, the libraries need to be built with `Microsoft.AspNetCore.SystemWebAdapters`. Building the libraries with `Microsoft.AspNetCore.SystemWebAdapters` allows:

* The libraries to be built against .NET Framework, .NET Core, or .NET Standard 2.0.
* Ensures that the libraries are using APIs that are available on both ASP.NET Framework and ASP.NET Core.

![Microsoft.AspNetCore.SystemWebAdapters](~/migration/inc/overview/static/sys_adapt.png)

Once the ASP.NET Core app using YARP is set up, you can start migrating routes from ASP.NET Framework to ASP.NET Core. For example, WebAPI or MVC controller action methods,handlers, or some other implementation of a route. If the route is available in the ASP.NET Core app, it's matched and served.

During the migration process, additional services and infrastructure are identified that must be migrated to run on .NET Core. Options listed in order of maintainability include:

1. Move the code to shared libraries
1. Link the code in the new project
1. Duplicate the code

Eventually, the ASP.NET Core app handles more of the routes than the .NET Framework app:

![the ASP.NET Core app handles more of the routes](~/migration/inc/overview/static/sys_adapt.png)

Once the ASP.NET Framework app is no longer needed and deleted:

* The app is running on the ASP.NET Core app stack, but is still using the adapters.
* The remaining migration work is removing the use of adapters.

![final pic](~/migration/inc/overview/static/final.png)

[Microsoft Project Migrations](https://marketplace.visualstudio.com/items?itemName=WebToolsTeam.aspnetprojectmigrations) is an experimental [Visual Studio extension](/visualstudio/ide/finding-and-using-visual-studio-extensions) that can assist in incremental migration from ASP.NET Framework to ASP.NET Core.

## System.Web Adapters

The `Microsoft.AspNetCore.SystemWebAdapters` is a collection of runtime helpers that facilitate using code written against `System.Web` while moving to ASP.NET Core.

The heart of the library is support for `System.Web.HttpContext`. The adapters attempt to provide compatible behavior for what is found running on ASP.NET Framework to expedite moving to ASP.NET Core. There are a number of behaviors that ASP.NET Framework provided that incur a performance cost if enabled on ASP.NET Core; these behaviors must be opted into.

For examples of scenarios where this is useful, see [the adapters article](xref:migration/inc/adapters).

For guidance around usage, see the [usage guidance article](xref:migration/inc/usage_guidance).

## Additional Resources

* [Video:Tooling for Incremental ASP.NET Core Migrations](https://www.youtube.com/watch?v=P96l0pDNVpM)
