---
title: Migrate from ASP.NET Framework to ASP.NET Core
author: isaacrlevin
description: Your complete guide to migrating ASP.NET Framework applications to ASP.NET Core, with practical approaches and step-by-step guidance.
ms.author: riande
ms.date: 07/17/2025
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
* **Outdated package dependencies** that may not have modern compatible equivalents
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
* **Multi-targeting requirements** - Libraries need to support all framework versions targeted by the app.
* **API compatibility** - Ensuring libraries work with both framework versions during the migration period
* **Testing complexity** - Each library upgrade requires thorough testing to ensure compatibility

### Application Architecture Differences

The fundamental differences between ASP.NET Framework and ASP.NET Core create additional challenges:

* **Hosting models** - Different approaches to application hosting and lifecycle management
* **Middleware pipeline** - Moving from HTTP modules and handlers to middleware
* **Request processing** - Different request processing models and contexts
* **Performance characteristics** - Different memory usage patterns and performance profiles

These challenges make incremental migration the preferred approach for most production applications, as it allows teams to address these issues gradually while maintaining a working application in production.

For documentation around important areas that have changed, see the associated topics  available at <xref:migration/fx-to-core/areas>

## Start here: Choose your migration path

Your ASP.NET Framework application can successfully move to ASP.NET Core. The key is choosing the right approach for your specific situation.

### Quick decision guide

**Answer these questions to choose your approach:**

1. **What's your timeline and risk tolerance?**
   * Need to stay in production during migration → [Incremental migration](#incremental-migration)
   * Can afford a complete rewrite → [In place migration](#in-place-migration)

2. **How large is your application?**
   * Small to medium apps → [In place migration](#in-place-migration)
   * Large production apps → [Incremental migration](#incremental-migration) is safer

3. **Do you have complex dependencies?**
   * Unknown or out of date dependencies → [Incremental migration](#incremental-migration)
   * Heavy use of System.Web → [Incremental migration](#incremental-migration)
   * Minimal dependencies → [In place migration](#in-place-migration)


## Incremental Migration

Incremental migration is an implementation of the Strangler Fig pattern and is best for larger projects or projects that need to continue to stay in production throughout a migration. See <xref:migration/fx-to-core/start> to get started migrating an application incrementally.

## In place migration

In place migration can work for sufficiently small applications. If possible, this allows for a quick replacement of the application. However, small issues may be compounded if you decide to do an in place migration. See <xref:migration/fx-to-core/tooling> to learn how Upgrade Assistant can help with an in place migration.
