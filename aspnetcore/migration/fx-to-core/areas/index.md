---
title: Complex migration scenarios - Deep dive areas
description: Detailed guidance for complex ASP.NET Framework to ASP.NET Core migration scenarios
author: twsouthwick
ms.author: tasou
ms.date: 6/20/2025
uid: migration/fx-to-core/areas
---
# Complex migration scenarios - Deep dive areas

This section provides detailed guidance for migrating complex ASP.NET Framework features and scenarios that require careful consideration and specialized knowledge when moving to ASP.NET Core.

## Overview

While many ASP.NET Framework applications can be migrated to ASP.NET Core following standard patterns, certain areas present unique challenges due to fundamental architectural differences between the frameworks. This section focuses on the most complex migration scenarios that developers commonly encounter.

These deep dive guides address areas where:

* The ASP.NET Core equivalent requires significant architectural changes
* Multiple interconnected components need to be migrated together
* Legacy patterns need to be completely reimagined for modern development practices
* Platform-specific knowledge is required for successful migration

## Complex migration areas

The following guides provide comprehensive coverage of the most challenging migration scenarios:

### [HTTP Modules and Handlers Migration](http-modules.md)

HTTP modules and handlers represent one of the most complex migration scenarios due to fundamental differences in request processing architecture.

**Key challenges:**
* Understanding the shift from IIS-integrated pipeline to middleware pipeline
* Migrating complex module interactions and dependencies
* Handling order-dependent processing logic
* Converting Web.config-based configuration to code-based setup

**What you'll learn:**
* [Migrating HTTP Modules](http-modules.md) - Convert IHttpModule implementations to middleware
* [Migrating HTTP Handlers](http-handlers.md) - Transform IHttpHandler logic for ASP.NET Core
* [HttpContext Migration](http-context.md) - Adapt to the new HttpContext API surface

### Authentication and Authorization Patterns

Complex authentication scenarios often involve custom implementations that don't map directly to ASP.NET Core's identity system.

**Key challenges:**
* Migrating custom authentication modules
* Converting complex authorization logic
* Handling legacy session management patterns
* Integrating with existing identity providers

### Legacy Data Access and ORM Migration

Applications with complex data access patterns require careful migration planning.

**Key challenges:**
* Migrating from Entity Framework 6.x to Entity Framework Core
* Converting LINQ to SQL implementations
* Handling connection string management changes
* Migrating custom data access abstractions

### Configuration and Dependency Injection

ASP.NET Core's configuration and DI systems require significant changes to legacy patterns.

**Key challenges:**
* Migrating from Web.config to the new configuration system
* Converting to built-in dependency injection
* Handling complex service lifetime scenarios
* Migrating custom configuration providers

## Migration strategy recommendations

When tackling complex migration scenarios:

1. **Start with isolated components** - Begin with self-contained features that have minimal dependencies
2. **Plan for architectural changes** - Accept that direct port may not be the best approach
3. **Leverage modern patterns** - Use migration as an opportunity to adopt better practices
4. **Test thoroughly** - Complex migrations require comprehensive testing strategies
5. **Consider incremental migration** - Break large migrations into manageable phases

## Getting help

For complex migration scenarios not covered in these guides:

* Review the [ASP.NET Core migration overview](xref:migration/fx-to-core/index)
* Consult the [ASP.NET Core fundamentals documentation](xref:fundamentals/index)
* Engage with the community through [GitHub discussions](https://github.com/dotnet/aspnetcore/discussions)
* Consider professional migration services for mission-critical applications
