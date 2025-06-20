---
title: Incremental migration of IHttpModules
description: Describes how to use the System.Web adapters to incrementally migrate HTTP modules.
author: twsouthwick
ms.author: tasou
monikerRange: '>= aspnetcore-6.0'
ms.date: 3/11/2024
ms.topic: article
uid: migration/inc/http-modules
---

---
title: Incremental HTTP modules migration using System.Web adapters
description: Preserve existing HTTP modules during ASP.NET Framework to ASP.NET Core migration using System.Web adapters for gradual modernization.
author: twsouthwick
ms.author: tasou
monikerRange: '>= aspnetcore-6.0'
ms.date: 6/20/2025
ms.topic: article
uid: migration/inc/http-modules
---

# Incremental HTTP modules migration using System.Web adapters

System.Web adapters enable you to preserve existing HTTP modules during ASP.NET Framework to ASP.NET Core migration. This approach provides immediate migration capability while allowing gradual conversion to native ASP.NET Core middleware patterns.

## When to use incremental HTTP modules migration

**Ideal for applications with:**
- Security modules that cannot tolerate interruption during migration
- Complex custom modules with business-critical functionality
- Authentication modules integrated with external systems
- Legacy modules that require extensive rewriting to convert to middleware

**Business benefits:**
- Maintain existing security and audit functionality during migration
- Reduce migration risk by preserving tested module behavior
- Enable gradual learning of ASP.NET Core middleware patterns
- Minimize initial code changes required for migration

## Implementation approach

### Basic HTTP module integration

System.Web adapters require an instance of `HttpApplication` to host existing modules. If your application doesn't use a custom `HttpApplication`, the system provides a default implementation.

**ASP.NET Core configuration:**

```csharp
var builder = WebApplication.CreateBuilder(args);

// Enable System.Web adapters with HTTP module support
builder.Services.AddSystemWebAdapters()
    .AddHttpApplication(options =>
    {
        // Configure existing HTTP modules
        options.RegisterModule<CustomSecurityModule>();
        options.RegisterModule<AuditingModule>();
    });

var app = builder.Build();

// Configure middleware pipeline
app.UseSystemWebAdapters();
app.MapGet("/", () => "Hello World!");

app.Run();
```

### Migrating Global.asax functionality

Applications using `Global.asax` can preserve this functionality during migration:

**Example Global.asax conversion:**

```csharp
// Original Global.asax.cs
public class Global : System.Web.HttpApplication
{
    protected void Application_Start()
    {
        // Application initialization logic
        InitializeApplication();
    }
    
    protected void Application_BeginRequest()
    {
        // Request processing logic
        LogRequest();
    }
}
```

**ASP.NET Core integration:**

```csharp
builder.Services.AddSystemWebAdapters()
    .AddHttpApplication<Global>();
```

This approach preserves existing application lifecycle events while enabling gradual migration to ASP.NET Core patterns.

### Authentication and authorization integration

HTTP modules often handle authentication and authorization. Proper integration requires careful middleware ordering:

**Recommended configuration:**

```csharp
var app = builder.Build();

app.UseRouting();
app.UseAuthentication();    // Before adapters for proper event timing
app.UseAuthorization();
app.UseSystemWebAdapters(); // After auth middleware

app.MapControllers();
app.Run();
```

**Important**: Place authentication and authorization middleware before System.Web adapters to ensure proper event execution timing.

## Performance optimization

### HTTP module pooling

HTTP modules can be expensive to instantiate for each request. System.Web adapters provide object pooling to optimize performance:

**Custom pooling configuration:**

```csharp
builder.Services.AddSystemWebAdapters()
    .AddHttpApplication(options =>
    {
        options.RegisterModule<ExpensiveModule>();
    })
    .ConfigurePool(poolOptions =>
    {
        poolOptions.MaximumRetained = 10; // Adjust based on load
    });
```

**Benefits of pooling:**
- Reduces object allocation overhead
- Improves response times under load
- Maintains existing module behavior while optimizing performance

### Memory management considerations

**Best practices:**
- Monitor memory usage during migration to identify pooling requirements
- Configure appropriate pool sizes based on application load patterns
- Consider gradual conversion to middleware for performance-critical modules

## Migration strategy and timeline

### Phase 1: Immediate migration (Weeks 1-2)
- [ ] Configure System.Web adapters with existing modules
- [ ] Validate module functionality in ASP.NET Core environment
- [ ] Establish monitoring for performance and functionality

### Phase 2: Selective optimization (Weeks 3-8)
- [ ] Identify modules suitable for middleware conversion
- [ ] Convert simple modules to native middleware
- [ ] Maintain complex modules using adapters

### Phase 3: Complete modernization (Weeks 9-12)
- [ ] Convert remaining modules to middleware where feasible
- [ ] Optimize performance for production deployment
- [ ] Remove adapter dependencies where possible

## Testing and validation

### Functional testing approach
- **Module behavior verification**: Ensure existing module functionality remains intact
- **Integration testing**: Validate module interaction with ASP.NET Core pipeline
- **Performance testing**: Compare response times with original ASP.NET Framework application

### Security validation
- **Authentication flow testing**: Verify security module behavior under various scenarios
- **Authorization verification**: Ensure access control modules function correctly
- **Audit trail validation**: Confirm logging and monitoring modules capture required information

## Common implementation patterns

### Security module preservation

```csharp
// Existing security module continues to function
public class CustomSecurityModule : IHttpModule
{
    public void Init(HttpApplication context)
    {
        context.BeginRequest += (sender, e) =>
        {
            // Existing security logic preserved
            ValidateRequest(HttpContext.Current);
        };
    }
    
    private void ValidateRequest(HttpContext context)
    {
        // Business-critical security validation
        // Preserved during migration
    }
}
```

### Gradual middleware conversion

As your team gains ASP.NET Core expertise, convert modules to middleware:

```csharp
// Convert simple modules to middleware over time
public class AuditingMiddleware
{
    private readonly RequestDelegate _next;
    
    public AuditingMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    
    public async Task InvokeAsync(HttpContext context)
    {
        // Modern middleware implementation
        LogRequest(context);
        await _next(context);
    }
}
```

## Best practices and recommendations

### Implementation guidelines
- **Start with critical modules**: Preserve security and audit modules first
- **Test thoroughly**: Validate module behavior in ASP.NET Core environment
- **Monitor performance**: Track response times and resource usage
- **Plan conversion**: Gradually convert modules to middleware as team expertise grows

### Troubleshooting common issues
- **Module initialization failures**: Verify proper HttpApplication configuration
- **Event timing issues**: Ensure correct middleware pipeline ordering
- **Performance degradation**: Optimize pooling configuration and consider middleware conversion

## Next steps

### Continue your incremental migration
- [Session state migration](xref:migration/inc/session): Preserve session functionality during migration
- [Authentication migration](xref:migration/inc/remote-authentication): Share authentication between Framework and Core
- [Complete migration guide](xref:migration/inc/start): Overall incremental migration strategy

### Alternative approaches
- [Complete HTTP modules to middleware migration](xref:migration/http-modules): Full conversion to ASP.NET Core patterns
- [Migration planning guide](xref:migration/proper-to-2x/index): Choose the right approach for your application

### Additional resources
- [HTTP modules overview](../http-modules.md): Complete guide to HTTP modules migration
- [Middleware fundamentals](xref:fundamentals/middleware/index): Learn ASP.NET Core middleware patterns
- [Migration troubleshooting](xref:migration/reference/troubleshooting): Common issues and solutions