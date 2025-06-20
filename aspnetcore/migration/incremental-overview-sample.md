---
title: Incremental ASP.NET Framework to ASP.NET Core Migration
description: Learn how to migrate ASP.NET Framework applications to ASP.NET Core incrementally using YARP and System.Web adapters
author: rick-anderson
ms.author: riande
monikerRange: '>= aspnetcore-6.0'
ms.date: 6/20/2025
uid: migration/incremental/overview
---

# Incremental ASP.NET Framework to ASP.NET Core Migration

The incremental migration approach allows you to migrate your ASP.NET Framework application to ASP.NET Core piece by piece, maintaining production deployments throughout the process. This approach is ideal for large, complex applications that cannot afford extended downtime.

## When to Use Incremental Migration

✅ **Recommended for:**
- Large applications with extensive business logic
- Production applications with tight uptime requirements
- Applications heavily dependent on `System.Web` APIs
- Teams learning ASP.NET Core while migrating
- Applications with complex authentication or session requirements

❌ **Consider full migration for:**
- Small to medium applications
- Applications with minimal ASP.NET Framework dependencies
- Green-field rewrites where you want to modernize architecture
- Long maintenance windows available

## How Incremental Migration Works

The incremental approach uses the [Strangler Fig pattern](/azure/architecture/patterns/strangler-fig) to gradually replace functionality:

### Phase 1: Setup Proxy Architecture
Create an ASP.NET Core application that acts as a proxy to your existing ASP.NET Framework app using [YARP](https://dotnet.github.io/yarp/).

![Initial setup with YARP proxy](~/migration/inc/overview/static/nop.png)

### Phase 2: Prepare Shared Libraries
Upgrade supporting libraries to use `Microsoft.AspNetCore.SystemWebAdapters`, enabling them to work with both ASP.NET Framework and ASP.NET Core.

![System.Web adapters enable shared libraries](~/migration/inc/overview/static/sys_adapt.png)

### Phase 3: Migrate Routes Incrementally
Gradually move routes from ASP.NET Framework to ASP.NET Core. The ASP.NET Core app handles migrated routes while proxying remaining requests to the Framework app.

### Phase 4: Complete Migration
Once all routes are migrated, remove the ASP.NET Framework app and gradually remove adapter dependencies.

![Final ASP.NET Core application](~/migration/inc/overview/static/final.png)

## Key Components

### YARP (Yet Another Reverse Proxy)
[YARP](https://dotnet.github.io/yarp/) handles request routing between ASP.NET Core and ASP.NET Framework applications during migration.

### System.Web Adapters
The `Microsoft.AspNetCore.SystemWebAdapters` packages provide compatibility APIs that allow code written for `System.Web` to work in ASP.NET Core with minimal changes.

#### Available Packages:
- **Microsoft.AspNetCore.SystemWebAdapters**: Core adapters for shared libraries (.NET Standard 2.0, .NET Framework 4.5+, .NET 5+)
- **Microsoft.AspNetCore.SystemWebAdapters.CoreServices**: ASP.NET Core-specific services (.NET 6+)
- **Microsoft.AspNetCore.SystemWebAdapters.FrameworkServices**: ASP.NET Framework-specific services
- **Microsoft.AspNetCore.SystemWebAdapters.Abstractions**: Shared abstractions for both platforms

## Technology-Specific Guidance

### ASP.NET MVC and Web API
MVC and Web API applications are excellent candidates for incremental migration:

- **Controllers**: Migrate individual controllers and actions
- **Filters**: Use adapters to share custom filters during transition
- **Dependency Injection**: Gradually migrate to ASP.NET Core DI patterns
- **Routing**: Maintain URL compatibility while migrating

**Get started:** [MVC/Web API Incremental Migration](xref:migration/incremental/mvc-webapi)

### ASP.NET Web Forms
Web Forms applications can benefit from incremental migration when:

- Complex business logic is embedded in code-behind
- Custom user controls need gradual migration
- Authentication and session state must be preserved

**Get started:** [Web Forms Incremental Migration](xref:migration/incremental/web-forms)

## Common Incremental Migration Scenarios

### Shared Authentication
> [!TIP]
> **Incremental Advantage**: Share authentication cookies between ASP.NET Framework and ASP.NET Core applications, allowing users to seamlessly navigate between migrated and non-migrated parts of your application.

**Key benefits:**
- No user re-authentication required
- Gradual migration of authentication logic
- Maintain existing authentication providers

[Learn more about shared authentication](xref:migration/incremental/authentication)

### Session State Migration
> [!TIP]  
> **Incremental Advantage**: Share session state between Framework and Core applications, maintaining user experience during migration.

**Key benefits:**
- Preserve user sessions across migration
- Gradual migration of session-dependent features
- Support for complex session objects

[Learn more about session state migration](xref:migration/incremental/session-state)

### HTTP Modules and Handlers
> [!TIP]
> **Incremental Advantage**: Continue using existing HTTP modules while gradually migrating to ASP.NET Core middleware.

**Key benefits:**
- Preserve existing security modules
- Gradual migration to middleware patterns
- Maintain request processing logic

[Learn more about HTTP modules migration](xref:migration/incremental/http-modules)

## Migration Planning and Tools

### Assessment Tools
Before starting incremental migration:

1. **[.NET Upgrade Assistant](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.upgradeassistant)**: Automated migration assistance
2. **[.NET Portability Analyzer](https://docs.microsoft.com/dotnet/standard/analyzers/portability-analyzer)**: Assess API compatibility
3. **Custom assessment**: Identify `System.Web` dependencies

### Migration Phases

#### Phase 1: Foundation Setup
- [ ] Create ASP.NET Core proxy application
- [ ] Configure YARP for request routing
- [ ] Set up System.Web adapters
- [ ] Verify proxy functionality

[Detailed setup guide](xref:migration/incremental/setup)

#### Phase 2: Shared Infrastructure
- [ ] Upgrade supporting libraries to .NET Standard 2.0
- [ ] Configure shared authentication
- [ ] Set up shared session state
- [ ] Migrate HTTP modules if needed

#### Phase 3: Incremental Route Migration
- [ ] Start with simple routes/controllers
- [ ] Migrate complex business logic gradually
- [ ] Test each migration thoroughly
- [ ] Monitor application performance

#### Phase 4: Final Migration
- [ ] Complete all route migrations
- [ ] Remove ASP.NET Framework application
- [ ] Gradually remove adapter dependencies
- [ ] Optimize ASP.NET Core-specific features

## Testing During Migration

### A/B Testing Support
The incremental approach supports A/B testing of migrated endpoints:

```csharp
// Enable conditional routing for testing
services.AddSystemWebAdapters()
    .AddProxySupport(options => options.UseForwardedHeaders = true)
    .AddConditionalEndpointRouting();
```

[Learn more about A/B testing](xref:migration/incremental/testing)

### Monitoring and Observability
- Monitor both ASP.NET Framework and Core applications
- Track request routing and performance
- Identify migration bottlenecks early

## Best Practices

### ✅ Do
- Start with simple routes and gradually increase complexity
- Maintain comprehensive testing throughout migration
- Use adapters to minimize code changes initially
- Plan for gradual adapter removal after migration
- Monitor application performance during migration

### ❌ Don't
- Migrate all routes at once without testing
- Rely on adapters permanently after migration completion
- Skip testing of shared authentication and session state
- Ignore performance implications of proxy architecture
- Rush the migration process

## Success Metrics

Track these metrics to ensure successful incremental migration:

- **Route Migration Progress**: Percentage of routes migrated to ASP.NET Core
- **Application Performance**: Response times for both Framework and Core routes
- **Error Rates**: Monitor errors during transition
- **User Experience**: Session continuity and authentication seamlessness

## Example Migration Timeline

| Phase | Duration | Key Activities |
|-------|----------|----------------|
| Setup | 1-2 weeks | YARP configuration, adapter setup |
| Infrastructure | 2-4 weeks | Authentication, session, shared libraries |
| Route Migration | 4-12 weeks | Gradual route migration (varies by app size) |
| Optimization | 2-4 weeks | Remove adapters, optimize Core features |

## Next Steps

Ready to start your incremental migration?

1. **Technology-specific setup:**
   - [MVC/Web API Setup](xref:migration/incremental/mvc-webapi)
   - [Web Forms Setup](xref:migration/incremental/web-forms)

2. **Core infrastructure:**
   - [Initial Setup Guide](xref:migration/incremental/setup)
   - [Authentication Migration](xref:migration/incremental/authentication)
   - [Session State Migration](xref:migration/incremental/session-state)

3. **Additional resources:**
   - [Usage Guidance](xref:migration/incremental/usage-guidance)
   - [Troubleshooting Guide](xref:migration/reference/troubleshooting)

---

## Alternative Approaches

Not sure if incremental migration is right for your application?

- **[Full Migration Overview](xref:migration/full-migration/overview)**: Complete rewrite approach
- **[Migration Decision Guide](xref:migration/planning/choosing-approach)**: Help choosing the right approach
- **[Migration Assessment](xref:migration/planning/assessment)**: Evaluate your application for migration
