---
title: Incremental ASP.NET to ASP.NET Core Migration
description: Incremental ASP.NET to ASP.NET Core Migration
author: rick-anderson
ms.author: riande
monikerRange: '>= aspnetcore-1.0'
ms.date: 11/9/2022
ms.topic: article
ms.prod: aspnet-core
uid: migration/inc/overview
---

# Incremental ASP.NET to ASP.NET Core migration

Migrating an app from ASP.NET Framework to ASP.NET Core is a non-trivial for the majority of large production apps. These apps have often grown organically over time, incorporating new technologies as they become available and are often composed of many legacy decisions. This article provide guidance and links to tools for migrating ASP.NET Framework apps to ASP.NET Core with as little change as possible.

One of the larger challenges is the pervasive use of <xref:System.Web.HttpContext> throughout a code base. Without the incremental approach and tools, a large scale rewrite was required to remove the `System.Web.HttpContext` dependency. The adapters in [dotnet/systemweb-adapters](https://github.com/dotnet/systemweb-adapters)
] provide a set of runtime helpers to access the types ASP.NET Framework code is expecting but in a way that works using ASP.NET Core with minimal changes.

A complete migration may take considerable effort depending on the size of the app. In order to continue deploying an app to production while working on migrating, the best pattern is to follow is the [Strangler Fig pattern](/azure/architecture/patterns/strangler-fig). The Strangler Fig pattern allows for continual development on the old system with an incremental approach to moving forward. This document describes how to apply the Strangler Fig pattern to an ASP.NET app migrating towards ASP.NET Core.

To jump into the process, please see the `[Getting Started](getting_started.md)` guide.

## App migration to ASP.NET Core

Before starting the migration, the app targets ASP.NET Framework and runs on Windows with its supporting libraries:

![Before starting the migration](~/migration/inc/overview/static/1.png)

Migration starts by introducing a new app based on ASP.NET Core that becomes the entry point. Incoming requests go to the ASP.NET Core app, which either handles the request or proxies the request to the .NET Framework app via [YARP](https://microsoft.github.io/reverse-proxy/). At first, the majority of code providing responses is the .NET Framework app, but the ASP.NET Core app is now set up to start migrating routes:

![start migrating routes](~/migration/inc/overview/static/nop.png)

To start moving business logic that relies on `HttpContext` to ???, the libraries need to be built with `Microsoft.AspNetCore.SystemWebAdapters`. Building the libraries with `Microsoft.AspNetCore.SystemWebAdapters` allows:

* The libraries to be built against .NET Framework, .NET Core, or .NET Standard 2.0.
* Ensures that the libraries are using APIs that are available on both ASP.NET and ASP.NET Core.

![Microsoft.AspNetCore.SystemWebAdapters](~/migration/inc/overview/static/sys_adapt.png)

<!-- Review: Why does this need to be serialized? Can't one team migrate WebAPI, another specific controllers, another, ASPX pages, etc -->
At this point, the migration process migrates routes <!--over one at a time-->. For example, WebAPI or MVC controller action methods, ASPX pages, handlers, or some other implementation of a route. If the route is available in the ASP.NET Core app, it's matched and served.

During migration process, additional services and infrastructure are identified that must be migrated to run on .NET Core. Options include listed in order of maintainability:

1. Duplicate the code
2. Link the code in the new project
3. Move the code to shared libraries

Eventually, the ASP.NET Core app handles more of the routes than the .NET Framework app

![the ASP.NET Core app handles more of the routes](~/migration/inc/overview/static/sys_adapt.png)

During migration, the same route may be available in both the ASP.NET Core and the ASP.NET Framework apps. Duplicate routes allows performing A/B testing to ensure functionality is as expected.

<!-- I think customers can figure this out
Once the .NET Framework Application is no longer needed, it may be removed: -->

Once the ASP.NET Framework app is deleted:

* The app is running on the ASP.NET Core app stack, but is still using the adapters.
* The remaining migration work is to remove the use of the adapters.

![final pic](~/migration/inc/overview/static/final.png)

## System.Web Adapters

The `Microsoft.AspNetCore.SystemWebAdapters` is a collection of runtime helpers that facilitate using old core <!-- Review: What's old core? --> written against `System.Web` while moving to ASP.NET Core.

The heart of the library is support for `System.Web.HttpContext`. The adaptors attempt to provide compatible behavior for what is found running on ASP.NET to expedite moving To ASP.NET Core. There are a number of behaviors that ASP.NET provided that incur a performance cost if enabled on ASP.NET Core, these behaviors must be opted into.
<!--
For examples of scenarios where this is useful, see [here](adapters.md).

For guidance around usage, please see [here](usage_guidance.md).
-->