---
title: Migrate from ASP.NET Framework to ASP.NET Core
ai-usage: ai-assisted
author: wadepickett
description: Your complete guide to migrating ASP.NET Framework applications to ASP.NET Core, with practical approaches and step-by-step guidance.
ms.author: wpickett
ms.date: 07/03/2026
uid: migration/fx-to-core/index
---
# Migrate from ASP.NET Framework to ASP.NET Core

<!-- see mermaid.txt to change diagrams -->

Updating an app from ASP.NET Framework to ASP.NET Core is non-trivial for the majority of production apps. These apps often incorporate new technologies as they become available and are often composed of many legacy decisions. This guide provides practical approaches and tools for updating ASP.NET Framework apps to ASP.NET Core with as little change as possible.

## Why migration is challenging

Migrating from ASP.NET Framework to ASP.NET Core involves several complex challenges that make a complete rewrite difficult and risky for most production applications:

### Technical debt accumulation

Production applications often accumulate technical debt over years of development:

* **System.Web dependencies** - The pervasive use of <xref:System.Web.HttpContext> and associated types throughout a code base.
* **Outdated package dependencies** that might not have modern compatible equivalents.
* **Legacy build tools and project configurations** that aren't compatible with modern .NET.
* **Deprecated API usage** that needs to be replaced with modern alternatives.
* **Compiler warnings and code quality issues** that complicate migration.

### Cross-cutting concerns

Many applications have cross-cutting concerns that span multiple layers and need careful coordination during migration:

* **Session state management** - ASP.NET Framework and ASP.NET Core have fundamentally different session APIs and behaviors.
* **Authentication and authorization** - Different authentication models and APIs between frameworks.
* **Logging and monitoring** - Need to maintain consistent logging across both applications during migration.
* **Caching strategies** - In-memory, distributed, or output caching needs to be maintained consistently.
* **Error handling** - Establishing consistent error handling patterns across both applications.
* **Configuration management** - Managing settings that need to be shared or synchronized between applications.
* **Dependency injection** - Migrating from various DI containers to ASP.NET Core's built-in container.

The generic host pattern can help address several of these concerns by bringing modern .NET infrastructure to ASP.NET Framework applications. For details, see <xref:migration/fx-to-core/areas/hosting>.

### Library dependency chains

Supporting libraries often have complex dependency relationships that require careful upgrade ordering:

* **Dependency tree complexity** - You must upgrade libraries in postorder depth-first search ordering.
* **Multi-targeting requirements** - Libraries need to support all framework versions targeted by the app.
* **API compatibility** - Ensuring libraries work with both framework versions during the migration period.
* **Testing complexity** - Each library upgrade requires thorough testing to ensure compatibility.

### Application architecture differences

The fundamental differences between ASP.NET Framework and ASP.NET Core create extra challenges:

* **Hosting models** - Different approaches to application hosting and lifecycle management
* **Middleware pipeline** - Moving from HTTP modules and handlers to middleware
* **Request processing** - Different request processing models and contexts
* **Performance characteristics** - Different memory usage patterns and performance profiles

These challenges make incremental migration the preferred approach for most production applications. This approach allows teams to address these issues gradually while maintaining a working application in production.

For documentation around important areas that changed, see the associated topics available at <xref:migration/fx-to-core/areas>.

## Start here: Choose your migration path

You can successfully move your ASP.NET Framework application to ASP.NET Core. The key is choosing the right approach for your specific situation.

> [!TIP]
> Regardless of the path you choose, the [GitHub Copilot app modernization agent](/dotnet/core/porting/github-copilot-app-modernization/overview) can assess your solution, generate an upgrade plan, and automate many of the migration steps. For more information, see <xref:migration/fx-to-core/tooling>.

### Quick decision guide

**Answer these questions to choose your approach:**

1. **What's your timeline and risk tolerance?**
   * Need to stay in production during migration → [Incremental migration](#incremental-migration)
   * Can afford a complete rewrite → [In place migration](#in-place-migration)

1. **How large is your application?**
   * Small to medium apps → [In place migration](#in-place-migration)
   * Large production apps → [Incremental migration](#incremental-migration) is safer

1. **Do you have complex dependencies?**
   * Unknown or out-of-date dependencies → [Incremental migration](#incremental-migration)
   * Heavy use of System.Web → [Incremental migration](#incremental-migration)
   * Minimal dependencies → [In place migration](#in-place-migration)


## Incremental migration

Incremental migration is an implementation of the Strangler Fig pattern. It's best for larger projects or projects that need to continue to stay in production throughout a migration. To get started migrating an application incrementally, see <xref:migration/fx-to-core/start>.

## In place migration

In place migration can work for sufficiently small applications. If possible, this approach allows for a quick replacement of the application. However, small issues can compound if you decide to do an in place migration. For information on migration tooling options, see <xref:migration/fx-to-core/tooling>.
