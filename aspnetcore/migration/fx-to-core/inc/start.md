---
title: Get started with incremental ASP.NET to ASP.NET Core migration
description: Get started with incremental ASP.NET to ASP.NET Core migration
author: rick-anderson
ms.author: riande
monikerRange: '>= aspnetcore-6.0'
ms.date: 11/9/2022
ms.topic: article
uid: migration/fx-to-core/inc/start
---

# Get started with incremental ASP.NET to ASP.NET Core migration

> [!IMPORTANT]
> **Before you begin**: This article assumes you have read the [Incremental ASP.NET to ASP.NET Core migration overview](xref:migration/fx-to-core/inc/overview). If you haven't read it yet, please start there to understand the concepts, approach, and benefits of incremental migration.

For a large migration, we recommend setting up a ASP.NET Core app that proxies to the original .NET Framework app. The new proxy enabled app is shown in the following image:

![start migrating routes](~/migration/fx-to-core/inc/overview/static/nop.png)

This article provides the practical steps to proceed with an incremental migration after you understand the approach.

## Prerequisites

Before starting your incremental migration, ensure you have:

1. **Read the overview**: [Incremental ASP.NET to ASP.NET Core migration](xref:migration/fx-to-core/inc/overview)
2. **A working ASP.NET Framework application** that you want to migrate
3. **Visual Studio 2022** with the latest updates
4. **.NET 8 or later SDK** installed
5. **Understanding of your application's dependencies** and third-party libraries

## Migration Steps Overview

The incremental migration process follows these key steps:

1. [Set up ASP.NET Core Project](#set-up-aspnet-core-project)
2. [Remediate Technical Debt](#remediate-technical-debt)
3. [Identify and address cross-cutting concerns](#identify-and-address-cross-cutting-concerns)
4. [Upgrade supporting libraries](#upgrade-supporting-libraries)

## Set up ASP.NET Core Project

The first step is to create the new ASP.NET Core application that will serve as your proxy.

**What you'll do:**
* Create a new ASP.NET Core project alongside your existing ASP.NET Framework app
* Configure it to proxy requests to your original application using YARP (Yet Another Reverse Proxy)
* Set up the basic infrastructure for incremental migration

**Detailed instructions:**
* See <xref:migration/fx-to-core/inc/remote-app-setup> to understand how to set up an application for incremental migration.
* See <xref:migration/fx-to-core/tooling> for help in setting up projects required for incremental migration using Visual Studio tooling.

## Remediate Technical Debt

**When to do this step:** Before upgrading any supporting libraries, address technical debt that could complicate the migration process.

Before you begin upgrading your supporting libraries, it's important to clean up technical debt that could interfere with the migration process. This step should be completed first to ensure a smoother upgrade experience.

### Update Package Dependencies

Review and update your NuGet packages to their latest compatible versions:

1. **Audit existing packages**: Use Visual Studio's NuGet Package Manager as the `dotnet` CLI does not work for ASP.NET Framework applications
2. **Update packages incrementally**: Update packages one at a time to avoid compatibility issues
3. **Test after each update**: Ensure your application still functions correctly after each package update
4. **Address breaking changes**: Some package updates may introduce breaking changes that need to be addressed

### Modernize Build Tools

Update your build tools and project configuration:

1. **Update tools**: Ensure you're using a recent version of MSBuild/Visual Studio
2. **Migrate to SDK-style project files**: Convert your existing project files to the modern SDK-style format. This is essential for .NET Core/.NET 5+ compatibility and provides better tooling support
3. **Review project files**: Consider migrating from `packages.config` to `PackageReference` format if you haven't already in the Web application project
4. **Update build scripts**: Review and update any custom build scripts or CI/CD configurations
5. **Clean up unused references**: Remove any unused assembly references or NuGet packages

### Address Code Quality Issues

Fix known code quality issues that could complicate migration:

1. **Run static analysis**: Use tools like CodeQL or Visual Studio's built-in analyzers
2. **Fix compiler warnings**: Address any compiler warnings, especially those related to deprecated APIs
3. **Remove dead code**: Clean up unused classes, methods, and other code elements
4. **Update deprecated API usage**: Replace usage of deprecated APIs with their modern equivalents where possible

This preparation work will make the library upgrade process much smoother and reduce the likelihood of encountering complex issues during migration.

## Identify and address cross-cutting concerns

**When to do this step:** While remediating technical debt but before upgrading supporting libraries, identify and configure cross-cutting concerns that affect your entire application.

Cross-cutting concerns are aspects of your application that span multiple layers or components, such as authentication, session management, logging, and caching. These need to be addressed early in the migration process because they affect how your ASP.NET Framework and ASP.NET Core applications communicate and share state during the incremental migration.

The following sections cover the most common cross-cutting concerns. Configure only the ones that apply to your application:

### Session Support Configuration

**Configure this if:** Your ASP.NET Framework application uses session state.

See the general [session migration documentation](xref:migration/fx-to-core/areas/session#remote-app-session state) for guidance here.

Session is a commonly used feature of ASP.NET that shares the name with a feature in ASP.NET Core, but the APIs are much different. When upgrading libraries that use session state, you'll need to configure session support. See the documentation on [remote session support](xref:migration/fx-to-core/areas/session) for detailed guidance on how to enable session state sharing between your applications.

### Authentication Configuration

**Configure this if:** Your ASP.NET Framework application uses authentication and you want to share authentication state between the old and new applications.

See the general [authentication migration documentation](xref:migration/fx-to-core/areas/authentication) for guidance here.

It is possible to share authentication between the original ASP.NET app and the new ASP.NET Core app by using the System.Web adapters remote authentication feature. This feature allows the ASP.NET Core app to defer authentication to the ASP.NET app. See the documentation on [remote authentication](xref:migration/fx-to-core/areas/authentication#remote-authentication) for more details.

### Other Cross-Cutting Concerns to Consider

Depending on your application, you may also need to address:

* **Logging**: Ensure consistent logging across both applications. Consider using a shared logging provider or ensuring logs are aggregated properly.
* **Caching**: If your application uses caching (in-memory, distributed, or output caching), plan how to maintain cache consistency between applications.
* **Error Handling**: Establish consistent error handling and reporting across both the ASP.NET Framework and ASP.NET Core applications.
* **Configuration Management**: Plan how configuration settings will be shared or managed between the two applications.
* **Health Monitoring**: Set up monitoring and health checks for both applications during the migration process.
* **Dependency Injection**: If using a DI container in your ASP.NET Framework app, plan the migration to ASP.NET Core's built-in DI container.

## Upgrade supporting libraries

**When to do this step:** Only when you need to migrate specific routes that depend on class libraries containing business logic you'll need to share between the old and new applications.

> [!NOTE]
> **Incremental approach**: With the incremental migration process, you don't need to upgrade all your supporting libraries at once. You only need to upgrade the libraries that are required for the specific routes you're currently migrating. This allows you to tackle the migration in smaller, more manageable pieces.

### Library Upgrade Process

> [!IMPORTANT]
> Supporting libraries must be upgraded in a **postorder depth-first search ordering**. This means:
>
> 1. **Start with leaf dependencies**: Begin with libraries that have no dependencies on other libraries in your solution
> 2. **Work upward through the dependency tree**: Only upgrade a library after all of its dependencies have been successfully upgraded
> 3. **End with the main application**: The main ASP.NET Framework application should be the last item to be modified
>
>This ordering is essential because:
> * It ensures that when you upgrade a library, all of its dependencies are already compatible
> * It prevents circular dependency issues during the upgrade process
> * It allows you to test each library independently before moving to its dependents
>
> **NOTE**: You only need to follow this ordering for the subset of libraries required by the routes you're currently migrating, not your entire solution.

**Upgrade process for each library:**

If you have supporting libraries in your solution that you will need to use for the routes you're migrating, they should be upgraded to .NET Standard 2.0, if possible. [Upgrade Assistant](https://github.com/dotnet/upgrade-assistant) is a great tool for this. If libraries are unable to target .NET Standard, you can target .NET 8 or later either along with the .NET Framework target in the original project or in a new project alongside the original.

The [System.Web adapters](xref:migration/fx-to-core/inc/usage_guidance) can be used in these libraries to enable support for <xref:System.Web.HttpContext> usage in class libraries. In order to enable <xref:System.Web.HttpContext> usage in a library:

1. Remove reference to `System.Web` in the project file
2. Add the `Microsoft.AspNetCore.SystemWebAdapters` package
3. Enable multi-targeting and add a .NET 8 target or later, or convert the project to .NET Standard 2.0.
4. Ensure the target framework supports .NET Core. Multi-targeting can be used if .NET Standard 2.0 is not sufficient

This step may require a number of projects to change depending on your solution structure and which routes you're migrating. Upgrade Assistant can help you identify which ones need to change and automate a number of steps in the process.


## Next Steps

Once you've completed the setup and library upgrade steps above:

1. **Start small**: Begin by migrating simple, stateless endpoints first
2. **Test thoroughly**: Ensure each migrated component works correctly in both environments
3. **Monitor performance**: Watch for any performance impacts from the proxy setup
4. **Iterate**: Continue migrating components incrementally until the migration is complete

For ongoing support and advanced scenarios, refer to the [usage guidance](xref:migration/fx-to-core/inc/usage_guidance) documentation.
