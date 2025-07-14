---
title: Migrate from ASP.NET Framework to ASP.NET Core
author: isaacrlevin
description: Your complete guide to migrating ASP.NET Framework applications to ASP.NET Core, with practical approaches and step-by-step guidance.
ms.author: riande
ms.date: 06/20/2025
uid: migration/fx-to-core/index
---
# Migrate from ASP.NET Framework to ASP.NET Core

<!-- see mermaid.txt to change diagrams -->

Updating an app from ASP.NET Framework to ASP.NET Core is non-trivial for the majority of production apps. These apps often incorporate new technologies as they become available and are often composed of many legacy decisions. This guide provides practical approaches and tools for updating ASP.NET Framework apps to ASP.NET Core with as little change as possible.

## Why migration is challenging

Migrating from ASP.NET Framework to ASP.NET Core involves several complex challenges that make a complete rewrite difficult and risky for most production applications:

### Technical Debt Accumulation

Production applications often have accumulated technical debt over years of development:

* **System.Web dependencies** - The pervasive use of <xref:System.Web.HttpContext> and associated types throughout a code base.
* **Outdated package dependencies** that may not have .NET Core equivalents
* **Legacy build tools and project configurations** that aren't compatible with modern .NET
* **Deprecated API usage** that needs to be replaced with modern alternatives
* **Compiler warnings and code quality issues** that complicate migration

### Cross-Cutting Concerns

Many applications have cross-cutting concerns that span multiple layers and need careful coordination during migration:

* **Session state management** - ASP.NET Framework and ASP.NET Core have fundamentally different session APIs and behaviors
* **Authentication and authorization** - Different authentication models and APIs between frameworks
* **Logging and monitoring** - Need to maintain consistent logging across both applications during migration
* **Caching strategies** - In-memory, distributed, or output caching needs to be maintained consistently
* **Error handling** - Establishing consistent error handling patterns across both applications
* **Configuration management** - Managing settings that need to be shared or synchronized between applications
* **Dependency injection** - Migrating from various DI containers to ASP.NET Core's built-in container

### Library Dependency Chains

Supporting libraries often have complex dependency relationships that require careful upgrade ordering:

* **Dependency tree complexity** - Libraries must be upgraded in postorder depth-first search ordering
* **Multi-targeting requirements** - Libraries need to support both .NET Framework and .NET Core/.NET Standard
* **API compatibility** - Ensuring libraries work with both framework versions during the migration period
* **Testing complexity** - Each library upgrade requires thorough testing to ensure compatibility

### Application Architecture Differences

The fundamental differences between ASP.NET Framework and ASP.NET Core create additional challenges:

* **Hosting models** - Different approaches to application hosting and lifecycle management
* **Middleware pipeline** - Moving from HTTP modules and handlers to middleware
* **Request processing** - Different request processing models and contexts
* **Performance characteristics** - Different memory usage patterns and performance profiles

These challenges make incremental migration the preferred approach for most production applications, as it allows teams to address these issues gradually while maintaining a working application in production.

## Start here: Choose your migration path

Your ASP.NET Framework application can successfully move to ASP.NET Core. The key is choosing the right approach for your specific situation.

### Quick decision guide

**Answer these questions to choose your approach:**

1. **What's your timeline and risk tolerance?**
   * Need to stay in production during migration → [Incremental migration](#incremental-migration-best-for-most-teams)
   * Can afford a complete rewrite → [Complete rewrite with tooling](#migration-tools-and-resources)

2. **How large is your application?**
   * Small to medium apps → [Upgrade Assistant](xref:migration/fx-to-core/tooling) can help
   * Large production apps → [Incremental migration](#incremental-migration-best-for-most-teams) is safer

3. **Do you have complex dependencies?**
   * Heavy use of System.Web → [Incremental migration](#incremental-migration-best-for-most-teams)
   * Minimal dependencies → Either approach works

## Incremental migration: Best for most teams

Most non-trivial ASP.NET Framework applications should use incremental migration using the [Strangler Fig pattern](/azure/architecture/patterns/strangler-fig). This approach allows for continual development on the old system with an incremental approach to replacing specific pieces of functionality with new services.

### Benefits of incremental migration

* **Keeps your current app running** while you migrate piece by piece
* **Reduces risk** by moving functionality gradually
* **Delivers value faster** with immediate deployment of migrated components
* **Uses proven tools** like YARP proxy and System.Web adapters

### How incremental migration works

Before starting the migration, the app targets ASP.NET Framework and runs on Windows with its supporting libraries:

![Before starting the migration](~/migration/fx-to-core/inc/overview/static/1.png)

Migration starts by introducing a new app based on ASP.NET Core that becomes the entry point. Incoming requests go to the ASP.NET Core app, which either handles the request or proxies the request to the .NET Framework app via [YARP](https://dotnet.github.io/yarp/). At first, the majority of code providing responses is in the .NET Framework app, but the ASP.NET Core app is now set up to start migrating routes:

![start updating routes](~/migration/fx-to-core/inc/overview/static/nop.png)

To migrate business logic that relies on `HttpContext`, the libraries need to be built with `Microsoft.AspNetCore.SystemWebAdapters`. Building the libraries with `SystemWebAdapters` allows:

* The libraries to be built against .NET Framework, .NET Core, or .NET Standard 2.0.
* Ensures that the libraries are using APIs that are available on both ASP.NET Framework and ASP.NET Core.

![Microsoft.AspNetCore.SystemWebAdapters](~/migration/fx-to-core/inc/overview/static/sys_adapt.png)

Once the ASP.NET Core app using YARP is set up, you can start updating routes from ASP.NET Framework to ASP.NET Core. For example, WebAPI or MVC controller action methods, handlers, or some other implementation of a route. If the route is available in the ASP.NET Core app, it's matched and served.

During the migration process, additional services and infrastructure are identified that must be updated to run on .NET Core. Options listed in order of maintainability include:

1. Move the code to shared libraries
1. Link the code in the new project from the old project manually
    ```xml
    <Compile Include="[Path to original file]" Link="[Filename in current project]" />
    ```
1. Duplicate the code

Eventually, the ASP.NET Core app handles more of the routes than the .NET Framework app:

![the ASP.NET Core app handles more of the routes](~/migration/fx-to-core/inc/overview/static/sys_adapt.png)

Once the ASP.NET Framework app is no longer needed and deleted:

* The app is running on the ASP.NET Core app stack, but is still using the adapters.
* The remaining migration work is removing the use of adapters.

![final pic](~/migration/fx-to-core/inc/overview/static/final.png)

**→ [Start your incremental migration](xref:migration/fx-to-core/start)**

## Migration tools and resources

### Automated assistance

* **[.NET Upgrade Assistant](https://dotnet.microsoft.com/platform/upgrade-assistant)** - Command-line tool for initial project conversion
* **[Visual Studio Extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.upgradeassistant)** - GUI-based upgrade assistance

### Comprehensive guides

* **[Porting ASP.NET Apps eBook](https://aka.ms/aspnet-porting-ebook)** - Complete reference guide
* **[eShop Migration Example](/dotnet/architecture/porting-existing-aspnet-apps/example-migration-eshop)** - Real-world case study
* **[Migration Tooling](~/migration/fx-to-core/tooling.md)** - Detailed tooling guide

## Changes to technology areas

Before you begin, review the [technical differences between ASP.NET Framework and ASP.NET Core](xref:migration/fx-to-core/areas) to understand key changes that may affect your migration.
