---
title: Migrate from ASP.NET Framework to ASP.NET Core
author: isaacrlevin
description: Your complete guide to migrating ASP.NET Framework applications to ASP.NET Core, with practical approaches and step-by-step guidance.
ms.author: riande
ms.date: 06/20/2025
uid: migration/fx-to-core/index
---
# Migrate from ASP.NET Framework to ASP.NET Core

:::moniker range=">= aspnetcore-6.0"

## Start here: Choose your migration path

Your ASP.NET Framework application can successfully move to ASP.NET Core. The key is choosing the right approach for your specific situation.

### Quick decision guide

**For most production applications:** Use the [**incremental migration approach**](xref:migration/fx-to-core/inc/overview) - it's safer, faster to start, and keeps your app running in production throughout the process.

**For smaller applications or greenfield rewrites:** Consider the complete migration approach using our specialized guides.

## The incremental approach: Best for most teams

Most non-trivial ASP.NET Framework applications should use incremental migration. This approach:

- **Keeps your current app running** while you migrate piece by piece
- **Reduces risk** by moving functionality gradually
- **Delivers value faster** with immediate deployment of migrated components
- **Uses proven tools** like YARP proxy and System.Web adapters

**→ [Start your incremental migration](xref:migration/fx-to-core/inc/overview)**

## Migration tools and resources

### Automated assistance
- **[.NET Upgrade Assistant](https://dotnet.microsoft.com/platform/upgrade-assistant)** - Command-line tool for initial project conversion
- **[Visual Studio Extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.upgradeassistant)** - GUI-based upgrade assistance

### Comprehensive guides
- **[Porting ASP.NET Apps eBook](https://aka.ms/aspnet-porting-ebook)** - Complete reference guide
- **[eShop Migration Example](/dotnet/architecture/porting-existing-aspnet-apps/example-migration-eshop)** - Real-world case study

## Key benefits of ASP.NET Core

Understanding these advantages will help justify your migration effort:

- **Performance**: Up to 10x faster than ASP.NET Framework
- **Cross-platform**: Deploy on Windows, Linux, or macOS
- **Modern features**: Built-in dependency injection, configuration, and logging
- **Cloud-ready**: Optimized for containers and microservices
- **Future-proof**: Regular updates and long-term support

## Changes to technology areas

Before you begin, review the [technical differences between ASP.NET Framework and ASP.NET Core](xref:migration/fx-to-core/areas) to understand key changes that may affect your migration.

## What's next?

1. **[Review incremental migration](xref:migration/fx-to-core/inc/overview)** - Recommended for most teams
2. **Choose your application-specific guide** from the table above

:::moniker-end