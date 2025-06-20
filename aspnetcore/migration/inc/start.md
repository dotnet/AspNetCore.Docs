---
title: Get started with incremental ASP.NET to ASP.NET Core migration
description: Get started with incremental ASP.NET to ASP.NET Core migration
author: rick-anderson
ms.author: riande
monikerRange: '>= aspnetcore-6.0'
ms.date: 11/9/2022
ms.topic: article
uid: migration/inc/start
---

---
title: Get started with incremental ASP.NET Framework to ASP.NET Core migration
description: Step-by-step guide for implementing incremental migration from ASP.NET Framework to ASP.NET Core using YARP proxy and System.Web adapters.
author: rick-anderson
ms.author: riande
monikerRange: '>= aspnetcore-6.0'
ms.date: 6/20/2025
ms.topic: article
uid: migration/inc/start
---

# Get started with incremental ASP.NET Framework to ASP.NET Core migration

Incremental migration enables you to modernize your ASP.NET Framework application systematically while maintaining production availability. This approach creates an ASP.NET Core application that initially proxies requests to your existing Framework application, then gradually migrates functionality piece by piece.

![Incremental migration proxy architecture](~/migration/inc/overview/static/nop.png)

This guide provides the essential steps to establish your incremental migration foundation. For comprehensive background information, see [Incremental ASP.NET to ASP.NET Core migration overview](xref:migration/inc/overview).

## Create your ASP.NET Core proxy application

The first step establishes the proxy architecture that enables gradual migration:

**For MVC and Web API applications:**
Follow the detailed setup process in [MVC/Web API incremental migration](xref:migration/mvc)

**For Web Forms applications:**
Follow the Web Forms-specific guidance in [Web Forms incremental migration](xref:migration/web_forms)

Both approaches create an ASP.NET Core application configured with YARP reverse proxy that initially routes all requests to your existing Framework application.

## Prepare supporting libraries for shared usage

Supporting libraries require preparation to function across both Framework and Core applications during migration:

### Assessment and upgrading strategy

**Optimal approach**: Upgrade libraries to .NET Standard 2.0 for maximum compatibility across both platforms.

**Alternative approach**: Multi-target libraries to support both .NET Framework and .NET 6+ if .NET Standard 2.0 is insufficient.

### Implementation steps

1. **Remove System.Web dependencies**: Replace direct `System.Web` references in library projects
2. **Add System.Web adapters package**: Install `Microsoft.AspNetCore.SystemWebAdapters` to enable `HttpContext` compatibility
3. **Configure multi-targeting**: Update project files to support both Framework and Core targets
4. **Validate compatibility**: Ensure libraries function correctly in both environments

**Example library project configuration:**

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFrameworks>netstandard2.0;net48</TargetFrameworks>
  </PropertyGroup>
  
  <ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.SystemWebAdapters" Version="1.3.0" />
  </ItemGroup>
  
  <!-- Remove System.Web references -->
  <ItemGroup Condition="'$(TargetFramework)' == 'net48'">
    <!-- Framework-specific dependencies if needed -->
  </ItemGroup>
</Project>
```

### Migration tools and assistance

**Automated support**: The [.NET Upgrade Assistant](https://github.com/dotnet/upgrade-assistant) provides automated analysis and migration assistance for library projects.

**Benefits**: Identifies projects requiring changes and automates many conversion steps, reducing manual effort and potential errors.

## Configure session state sharing

Session state requires special handling during incremental migration to maintain user experience:

### Business impact of session continuity

**User experience preservation**: Users maintain their session data when navigating between migrated and non-migrated portions of your application.

**Gradual feature migration**: Session-dependent features can be migrated incrementally without forcing complete session architecture changes.

### Implementation approach

**ASP.NET Core configuration:**
```csharp
builder.Services.AddSystemWebAdapters()
    .AddRemoteAppSession(isDefault: true)
    .AddJsonSessionSerializer(options =>
    {
        // Register types stored in session for serialization
        options.RegisterKey<UserProfile>("UserProfile");
        options.RegisterKey<ShoppingCart>("Cart");
    });
```

**ASP.NET Framework configuration:**
```csharp
// In Global.asax.cs
protected void Application_Start()
{
    SystemWebAdapterConfiguration.AddSystemWebAdapters(this)
        .AddSession();
}
```

**Detailed implementation**: See [comprehensive session state migration guide](xref:migration/inc/session) for complete configuration options and troubleshooting.

## Enable shared authentication between applications

Authentication sharing eliminates user re-authentication requirements during migration:

### Business benefits

**Seamless user experience**: Users remain authenticated when accessing both migrated and non-migrated application areas.

**Gradual authentication migration**: Authentication logic can be migrated systematically without disrupting user access.

### Configuration approach

**ASP.NET Core setup:**
```csharp
builder.Services.AddSystemWebAdapters()
    .AddRemoteAppAuthentication(isDefault: true);
```

**ASP.NET Framework setup:**
```csharp
// In Global.asax.cs  
protected void Application_Start()
{
    SystemWebAdapterConfiguration.AddSystemWebAdapters(this)
        .AddAuthentication();
}
```

### Advanced authentication scenarios

**Remote application connection**: For complex authentication setups, establish dedicated connections between applications using [remote app connection guide](xref:migration/inc/remote-app-setup).

**Custom authentication providers**: Preserve existing authentication integrations while enabling gradual modernization through [remote authentication documentation](xref:migration/inc/remote-authentication).

## Implementation best practices and guidance

### Feature compatibility considerations

System.Web adapters provide extensive compatibility, but some features require careful consideration:

**Performance impact**: Some adapter features incur performance costs that may require opt-in configuration for production environments.

**Behavioral differences**: Certain ASP.NET Framework behaviors cannot be perfectly replicated in ASP.NET Core due to fundamental architectural differences.

**Migration planning**: Review [comprehensive usage guidance](xref:migration/inc/usage_guidance) to understand limitations and optimization opportunities.

### Migration phases and timeline

**Phase 1 - Foundation (Weeks 1-2)**:
- [ ] Establish proxy architecture
- [ ] Configure System.Web adapters
- [ ] Validate basic functionality

**Phase 2 - Infrastructure (Weeks 3-4)**:
- [ ] Implement session state sharing
- [ ] Configure authentication sharing
- [ ] Upgrade supporting libraries

**Phase 3 - Incremental migration (Weeks 5+)**:
- [ ] Begin migrating simple routes/pages
- [ ] Progress to complex business logic
- [ ] Complete all functionality migration

**Phase 4 - Optimization (Final weeks)**:
- [ ] Remove Framework application
- [ ] Eliminate adapter dependencies
- [ ] Optimize ASP.NET Core features

## Monitoring and validation

### Success metrics

**Technical indicators**:
- Successful proxy routing between applications
- Preserved user authentication across application boundaries
- Maintained session state continuity
- Performance within acceptable parameters

**Business indicators**:
- No user experience degradation
- Maintained application functionality
- Successful deployment and rollback capability

### Troubleshooting resources

**Common issues**: Authentication synchronization problems, session serialization errors, routing conflicts
**Resolution guidance**: [Migration troubleshooting guide](xref:migration/reference/troubleshooting) provides detailed problem-solving approaches

## Next steps in your migration journey

### Technology-specific guidance
- **MVC/Web API applications**: [Advanced MVC migration techniques](xref:migration/mvc)
- **Web Forms applications**: [Web Forms modernization strategies](xref:migration/web_forms)

### Specialized migration scenarios
- **HTTP modules preservation**: [Incremental HTTP modules migration](xref:migration/inc/http-modules)
- **Complex authentication**: [Advanced authentication migration](xref:migration/inc/remote-authentication)
- **A/B testing**: [Testing migrated functionality](xref:migration/inc/ab-testing)

### Migration optimization
- **Performance tuning**: Monitor and optimize proxy performance for production workloads
- **Gradual modernization**: Plan systematic removal of adapter dependencies as migration progresses
- **Team development**: Provide ASP.NET Core training to support ongoing migration efforts
