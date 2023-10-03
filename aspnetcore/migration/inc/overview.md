---
title: Incremental ASP.NET to ASP.NET Core update
description: Incremental ASP.NET to ASP.NET Core migration
author: rick-anderson
ms.author: riande
monikerRange: '>= aspnetcore-6.0'
ms.date: 11/9/2022
ms.topic: article
ms.prod: aspnet-core
uid: migration/inc/overview
---

<!-- see mermaid.txt to change diagrams -->

# Incremental ASP.NET to ASP.NET Core update

Updating an app from ASP.NET Framework to ASP.NET Core is non-trivial for the majority of production apps. These apps often incorporate new technologies as they become available and are often composed of many legacy decisions. This article provides guidance and links to tools for updating ASP.NET Framework apps to ASP.NET Core with as little change as possible.

One of the larger challenges is the pervasive use of <xref:System.Web.HttpContext> throughout a code base. Without the incremental approach and tools, a large scale rewrite is required to remove the <xref:System.Web.HttpContext> dependency. The adapters in [dotnet/systemweb-adapters](https://github.com/dotnet/systemweb-adapters) provide a set of runtime helpers to access the types used in the ASP.NET Framework app in a way that works in ASP.NET Core with minimal changes.

A complete migration may take considerable effort depending on the size of the app, dependencies, and non-portable APIs used. In order to keep deploying an app to production while working on updating, the best pattern is to follow is the [Strangler Fig pattern](/azure/architecture/patterns/strangler-fig). The *Strangler Fig pattern* allows for continual development on the old system with an incremental approach to replacing specific pieces of functionality with new services. This document describes how to apply the Strangler Fig pattern to an ASP.NET app updating towards ASP.NET Core.

If you'd like to skip this overview article and get started, see [Get started](xref:migration/inc/start).

## App migration to ASP.NET Core

Before starting the migration, the app targets ASP.NET Framework and runs on Windows with its supporting libraries:

![Before starting the migration](~/migration/inc/overview/static/1.png)

Migration starts by introducing a new app based on ASP.NET Core that becomes the entry point. Incoming requests go to the ASP.NET Core app, which either handles the request or proxies the request to the .NET Framework app via [YARP](https://microsoft.github.io/reverse-proxy/). At first, the majority of code providing responses is in the .NET Framework app, but the ASP.NET Core app is now set up to start migrating routes:

![start updating routes](~/migration/inc/overview/static/nop.png)

To migrate business logic that relies on `HttpContext`, the libraries need to be built with `Microsoft.AspNetCore.SystemWebAdapters`. Building the libraries with `SystemWebAdapters` allows:

* The libraries to be built against .NET Framework, .NET Core, or .NET Standard 2.0.
* Ensures that the libraries are using APIs that are available on both ASP.NET Framework and ASP.NET Core.

![Microsoft.AspNetCore.SystemWebAdapters](~/migration/inc/overview/static/sys_adapt.png)

Once the ASP.NET Core app using YARP is set up, you can start updating routes from ASP.NET Framework to ASP.NET Core. For example, WebAPI or MVC controller action methods,handlers, or some other implementation of a route. If the route is available in the ASP.NET Core app, it's matched and served.

During the migration process, additional services and infrastructure are identified that must be updated to run on .NET Core. Options listed in order of maintainability include:

1. Move the code to shared libraries
1. Link the code in the new project
1. Duplicate the code

Eventually, the ASP.NET Core app handles more of the routes than the .NET Framework app:

![the ASP.NET Core app handles more of the routes](~/migration/inc/overview/static/sys_adapt.png)

Once the ASP.NET Framework app is no longer needed and deleted:

* The app is running on the ASP.NET Core app stack, but is still using the adapters.
* The remaining migration work is removing the use of adapters.

![final pic](~/migration/inc/overview/static/final.png)

The Visual Studio extension [.NET Upgrade Assistant](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.upgradeassistant) can help upgrade ASP.NET Framework web apps to ASP.NET Core. For more information see the blog post [Upgrading your .NET projects with Visual Studio](https://devblogs.microsoft.com/dotnet/upgrade-assistant-now-in-visual-studio/).

## System.Web Adapters

The `Microsoft.AspNetCore.SystemWebAdapters` namespace is a collection of runtime helpers that facilitate using code written against `System.Web` while moving to ASP.NET Core. There are a few packages that may be used to use features from these adapters:

- `Microsoft.AspNetCore.SystemWebAdapters`: This package is used in supporting libraries and provide the System.Web APIs you may have taken a dependency on, such as `HttpContext` and others. This package targets .NET Standard 2.0, .NET 4.5+, and .NET 6+.
- `Microsoft.AspNetCore.SystemWebAdapters.FrameworkServices`: This package only targets .NET Framework and is intended to provide services to ASP.NET Framework applications that may need to provide incremental migrations. This is generally not expected to be referenced from libraries, but rather from the applications themselves.
- `Microsoft.AspNetCore.SystemWebAdapters.CoreServices`: This package only targets .NET 6+ and is intended to provide services to ASP.NET Core applications to configure behavior of `System.Web` APIs as well as opting into any behaviors for incremental migration. This is generally not expected to be referenced from libraries, but rather from the applications themselves.
- `Microsoft.AspNetCore.SystemWebAdapters.Abstractions`: This package is a supporting package that provides abstractions for services used by both the ASP.NET Core and ASP.NET Framework application such as session state serialization.

For examples of scenarios where this is useful, see [the adapters article](xref:migration/inc/adapters).

For guidance around usage, see the [usage guidance article](xref:migration/inc/usage_guidance).

## Additional Resources

* [Example migration of eShop to ASP.NET Core](/dotnet/architecture/porting-existing-aspnet-apps/example-migration-eshop)
* [Video:Tooling for Incremental ASP.NET Core Migrations](https://www.youtube.com/watch?v=P96l0pDNVpM)
* <xref:migration/inc/unit-testing>
