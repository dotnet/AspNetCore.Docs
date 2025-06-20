---
title: Incremental ASP.NET to ASP.NET Core update
description: Incremental ASP.NET to ASP.NET Core migration
author: rick-anderson
ms.author: riande
monikerRange: '>= aspnetcore-6.0'
ms.date: 11/9/2022
ms.topic: article
uid: migration/inc/overview
---

<!-- see mermaid.txt to change diagrams -->

---
title: Incremental ASP.NET Framework to ASP.NET Core migration
description: Migrate ASP.NET Framework applications to ASP.NET Core gradually while maintaining production availability using YARP proxy and System.Web adapters.
author: rick-anderson
ms.author: riande
monikerRange: '>= aspnetcore-6.0'
ms.date: 6/20/2025
ms.topic: article
uid: migration/inc/overview
---

<!-- see mermaid.txt to change diagrams -->

# Incremental ASP.NET Framework to ASP.NET Core migration

Incremental migration enables you to modernize ASP.NET Framework applications systematically while maintaining production availability. This approach minimizes business disruption and reduces migration risk by updating functionality piece by piece rather than requiring a complete rewrite.

## Business case for incremental migration

### When incremental migration delivers maximum value

**Production-critical applications**: Maintain business continuity during migration without extended downtime windows.

**Complex business logic**: Preserve existing functionality while gradually adopting ASP.NET Core patterns and capabilities.

**Team learning curve**: Allow development teams to master ASP.NET Core incrementally rather than requiring comprehensive knowledge upfront.

**Risk mitigation**: Reduce deployment risk through gradual rollout with immediate rollback capability.

## How incremental migration works

Incremental migration follows the [Strangler Fig pattern](/azure/architecture/patterns/strangler-fig), gradually replacing legacy functionality with modern implementations. This approach enables continuous deployment and immediate benefits realization.

### Migration architecture overview

The migration process transforms your application architecture through four distinct phases:

**Phase 1: Establish proxy foundation**
Create an ASP.NET Core application that serves as the entry point for all requests. Initially, this application proxies all traffic to your existing ASP.NET Framework application through [YARP](https://dotnet.github.io/yarp/).

![Initial proxy setup](~/migration/inc/overview/static/nop.png)

**Phase 2: Enable code sharing**
Upgrade supporting libraries to use `Microsoft.AspNetCore.SystemWebAdapters`, enabling seamless operation across both ASP.NET Framework and ASP.NET Core environments.

![System.Web adapters integration](~/migration/inc/overview/static/sys_adapt.png)

**Phase 3: Migrate functionality incrementally**
Transfer routes, controllers, and business logic from Framework to Core applications systematically. The ASP.NET Core application handles migrated functionality while proxying remaining requests to the Framework application.

**Phase 4: Complete modernization**
Remove the ASP.NET Framework application once all functionality migrates to ASP.NET Core. Gradually eliminate adapter dependencies to fully leverage ASP.NET Core capabilities.

![Completed migration](~/migration/inc/overview/static/final.png)

## Core migration components

### YARP (Yet Another Reverse Proxy)

[YARP](https://dotnet.github.io/yarp/) provides intelligent request routing between ASP.NET Core and ASP.NET Framework applications. This enables seamless user experience during migration while maintaining production performance.

**Key capabilities:**
- Load balancing between Framework and Core applications
- Header forwarding for authentication continuity
- Health check integration for reliability
- Performance monitoring and logging

### System.Web Adapters

The `Microsoft.AspNetCore.SystemWebAdapters` package collection provides compatibility APIs that enable `System.Web`-dependent code to function in ASP.NET Core with minimal modification.

#### Package components

**Microsoft.AspNetCore.SystemWebAdapters**
Core compatibility layer for shared libraries. Targets .NET Standard 2.0, .NET Framework 4.5+, and .NET 5+ for maximum compatibility across migration phases.

**Microsoft.AspNetCore.SystemWebAdapters.CoreServices**
ASP.NET Core-specific services for configuring `System.Web` API behavior and migration features. Targets .NET 6+ applications.

**Microsoft.AspNetCore.SystemWebAdapters.FrameworkServices**
ASP.NET Framework-specific services for incremental migration support. Enables Framework applications to participate in shared authentication and session state.

**Microsoft.AspNetCore.SystemWebAdapters.Abstractions**
Shared abstractions for services used by both Framework and Core applications, including session state serialization interfaces.

## Migration strategy by application type

### ASP.NET MVC and Web API applications

MVC and Web API applications typically achieve excellent results with incremental migration:

**Migration advantages:**
- Controller-by-controller migration with immediate testing
- Preserve existing routing and URL structures
- Maintain dependency injection patterns during transition
- Share authentication and authorization across applications

**Optimal migration sequence:**
1. Simple controllers with minimal dependencies
2. Complex business logic controllers
3. Authentication and authorization components
4. Custom filters and middleware components

**Get started:** [MVC/Web API incremental migration](xref:migration/inc/start)

### ASP.NET Web Forms applications

Web Forms applications benefit from incremental migration when:

**Business logic preservation**: Complex code-behind logic requires gradual extraction and modernization rather than complete rewrite.

**User control migration**: Custom user controls can be migrated systematically to Razor components or partial views.

**Authentication integration**: Existing authentication providers and user management systems require continuity during transition.

**Get started:** [Web Forms incremental migration](xref:migration/web_forms)

## Critical migration scenarios

### Shared authentication and authorization

> [!IMPORTANT]
> **Business continuity benefit**: Users maintain authentication state when navigating between migrated and non-migrated application areas, eliminating re-authentication requirements and preserving user experience.

**Implementation approach:**
- Configure authentication sharing between Framework and Core applications
- Maintain existing authentication providers during migration
- Gradually migrate authentication logic while preserving user sessions

[Detailed authentication migration guide](xref:migration/inc/remote-authentication)

### Session state management

> [!IMPORTANT]
> **Data continuity benefit**: Session data persists across Framework and Core applications, enabling gradual migration of session-dependent features without user impact.

**Implementation approach:**
- Configure session state sharing between applications
- Serialize complex session objects for cross-platform compatibility
- Gradually migrate session-dependent functionality

[Comprehensive session state migration guide](xref:migration/inc/session)

### HTTP modules and handlers

> [!IMPORTANT]
> **Functionality preservation benefit**: Continue using existing security modules, logging components, and request processing logic while gradually adopting ASP.NET Core middleware patterns.

**Implementation approach:**
- Maintain existing HTTP modules during initial migration phases
- Gradually convert modules to ASP.NET Core middleware
- Preserve security and auditing functionality throughout migration

[HTTP modules migration guide](xref:migration/inc/http-modules)

## Migration planning and execution

### Assessment phase

**Application complexity evaluation:**
- Identify `System.Web` dependencies and usage patterns
- Catalog custom HTTP modules and handlers
- Assess authentication and session state requirements
- Evaluate third-party component compatibility

**Business impact analysis:**
- Determine acceptable downtime windows
- Identify critical functionality that cannot be interrupted
- Assess team ASP.NET Core expertise and training needs
- Plan testing and validation strategies

### Implementation phases

#### Foundation establishment (Weeks 1-2)
- [ ] Create ASP.NET Core proxy application
- [ ] Configure YARP for request routing
- [ ] Implement System.Web adapters
- [ ] Validate proxy functionality with existing application

#### Infrastructure migration (Weeks 3-6)
- [ ] Upgrade supporting libraries to .NET Standard 2.0
- [ ] Configure shared authentication between applications
- [ ] Implement shared session state management
- [ ] Migrate critical HTTP modules if required

#### Incremental functionality migration (Weeks 7-20)
- [ ] Begin with simple routes and controllers
- [ ] Progress to complex business logic components
- [ ] Migrate authentication and authorization features
- [ ] Complete all application functionality migration

#### Optimization and modernization (Weeks 21-24)
- [ ] Remove ASP.NET Framework application
- [ ] Eliminate System.Web adapter dependencies
- [ ] Optimize ASP.NET Core-specific features
- [ ] Implement performance improvements

### Success metrics and monitoring

**Migration progress indicators:**
- Percentage of routes handled by ASP.NET Core application
- Performance metrics for both Framework and Core components
- Error rates and user experience impact
- Team productivity and learning curve progress

**Quality assurance metrics:**
- Test coverage for migrated functionality
- User acceptance testing results
- Performance benchmarking comparisons
- Security audit compliance

## Risk management and mitigation

### Technical risk factors

**Performance impact**: Monitor proxy overhead and optimize routing configuration for production workloads.

**Compatibility issues**: Test adapter functionality thoroughly with existing dependencies and third-party components.

**Data consistency**: Validate session state and authentication sharing across application boundaries.

### Business risk mitigation

**Rollback capability**: Maintain ability to route traffic back to Framework application if issues arise during migration.

**Incremental validation**: Test each migrated component thoroughly before proceeding to the next migration phase.

**User communication**: Plan communication strategy for any temporary functionality changes or performance impacts.

## Implementation best practices

### Technical excellence
- Start with simple functionality and progress to complex components systematically
- Maintain comprehensive automated testing throughout migration process
- Use adapters strategically for initial migration, then eliminate them for optimal performance
- Monitor application performance and user experience continuously

### Project management
- Establish clear migration phases with defined success criteria
- Maintain regular stakeholder communication about progress and any issues
- Plan for team training and knowledge transfer throughout the process
- Document migration decisions and architectural changes for future reference

## Expected outcomes and benefits

### Immediate benefits
- **Production continuity**: Maintain business operations throughout migration process
- **Risk reduction**: Minimize deployment risk through gradual rollout approach
- **Team development**: Build ASP.NET Core expertise incrementally rather than requiring complete knowledge upfront

### Long-term value
- **Modern platform capabilities**: Access to cross-platform deployment, improved performance, and latest development features
- **Reduced technical debt**: Systematic modernization of legacy code patterns and dependencies
- **Enhanced maintainability**: Improved code organization and modern development practices

## Getting started

Ready to begin your incremental migration? Choose your technology-specific starting point:

**For MVC and Web API applications:**
[MVC/Web API incremental migration setup](xref:migration/inc/start)

**For Web Forms applications:**
[Web Forms incremental migration setup](xref:migration/web_forms)

**For detailed migration planning:**
[Comprehensive migration planning guide](xref:migration/inc/start)

## Additional resources

### Migration examples and case studies
- [eShop migration case study](/dotnet/architecture/porting-existing-aspnet-apps/example-migration-eshop): Complete enterprise application migration example
- [Incremental migration video guide](https://www.youtube.com/watch?v=P96l0pDNVpM): Visual walkthrough of migration process

### Advanced migration topics
- [A/B testing during migration](xref:migration/inc/ab-testing): Test migrated functionality gradually
- [Unit testing migration strategies](xref:migration/inc/unit-testing): Maintain test coverage throughout migration
- [Migration usage guidance](xref:migration/inc/usage_guidance): Best practices and common pitfalls
