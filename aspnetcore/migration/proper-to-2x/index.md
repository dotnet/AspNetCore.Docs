---
title: Migrate from ASP.NET Framework to ASP.NET Core
author: rick-anderson
description: Choose the right approach for migrating your ASP.NET Framework application to ASP.NET Core based on complexity, timeline, and business requirements.
ms.author: riande
ms.date: 6/20/2025
uid: migration/proper-to-2x/index
---
# Migrate from ASP.NET Framework to ASP.NET Core

 :::moniker range=">= aspnetcore-7.0"

ASP.NET Core delivers improved performance, cross-platform capabilities, and modern development features. This guide helps you choose the most effective migration approach for your ASP.NET Framework application.

## Choose your migration strategy

Your migration success depends on selecting the right approach for your specific situation:

### Incremental migration (recommended for most applications)

**Use incremental migration when:**
- Your application has complex business logic or extensive `System.Web` dependencies
- You cannot afford extended production downtime
- Your team needs to learn ASP.NET Core while migrating
- You want to minimize initial code changes

The incremental approach uses a proxy architecture to gradually migrate functionality while maintaining production availability. Most non-trivial ASP.NET Framework applications benefit from this strategy.

**Get started:** [Incremental ASP.NET to ASP.NET Core migration](xref:migration/inc/overview)

### Full migration

**Use full migration when:**
- Your application has limited complexity and dependencies
- You can allocate dedicated migration time
- You want to modernize your architecture completely
- You prefer a clean slate approach

**Technology-specific guidance:**
- **MVC and Web API:** [Migrate ASP.NET MVC and Web API](xref:migration/mvc)
- **Web Forms:** [Migrate ASP.NET Web Forms](xref:migration/web_forms)

## Planning your migration

Before choosing an approach, assess your application's complexity and requirements:

### Application assessment
- **Business logic complexity**: Applications with extensive custom business logic benefit from incremental migration
- **System.Web dependencies**: Heavy use of `HttpContext`, session state, or custom modules favors incremental approach
- **Third-party integrations**: Evaluate compatibility with ASP.NET Core
- **Team expertise**: Consider your team's ASP.NET Core experience

### Timeline considerations
- **Incremental migration**: Longer overall timeline but maintains production availability
- **Full migration**: Shorter concentrated effort but requires dedicated migration window

### Risk factors
- **Production constraints**: Incremental migration reduces deployment risk
- **Business continuity**: Assess impact of potential downtime
- **Rollback strategy**: Plan for both approaches

## Migration tools and resources

### Assessment tools
- [.NET Upgrade Assistant](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.upgradeassistant): Automated migration assistance
- [.NET Portability Analyzer](/dotnet/standard/analyzers/portability-analyzer): Evaluate API compatibility

### Migration examples
- [eShop migration example](/dotnet/architecture/porting-existing-aspnet-apps/example-migration-eshop): Complete migration case study
- [Incremental migration video guide](https://www.youtube.com/watch?v=P96l0pDNVpM): Visual walkthrough of incremental approach

## Common migration challenges

### Authentication and authorization
Both migration approaches must handle authentication. The incremental approach allows you to share authentication between Framework and Core applications during transition.

### Session state management
Session state requires careful planning. Incremental migration can preserve session continuity across both applications.

### Configuration management
Migrate from Web.config to appsettings.json systematically. The incremental approach allows gradual configuration migration.

## Success factors

### Technical preparation
- Upgrade supporting libraries to .NET Standard 2.0 when possible
- Identify and plan for breaking changes
- Establish testing strategies for both approaches

### Team readiness
- Provide ASP.NET Core training for development teams
- Establish migration guidelines and coding standards
- Plan for knowledge transfer and documentation


## URI decoding differences between ASP.NET to ASP.NET Core

ASP.NET Core has the following URI decoding differences with ASP.NET Framework:

| ASCII   | Encoded | ASP.NET Core | ASP.NET Framework |
| ------------- | ------------- | ------------- | ------------- |
| `\` | `%5C`  |  `\` |  `/` |
| `/` | `%2F`  |  `%2F` |  `/` |

When decoding `%2F` on ASP.NET Core:

* The entire path gets unescaped except `%2F` because converting it to `/` would change the path structure. It can’t be decoded until the path is split into segments.

To generate the value for `HttpRequest.Url`, use `new Uri(this.AspNetCoreHttpRequest.GetEncodedUrl());` to avoid `Uri` misinterpreting the values.

## Migrating User Secrets from ASP.NET Framework to ASP.NET Core

See [this GitHub issue](https://github.com/dotnet/AspNetCore.Docs/issues/27611).

<!-- remove these comments when the following overview topic is updated
## Additional resources

- [Overview of porting from .NET Framework to .NET](/dotnet/core/porting/libraries)
-->
:::moniker-end

[!INCLUDE[](~/migration/proper-to-2x/includes/index5.md)]