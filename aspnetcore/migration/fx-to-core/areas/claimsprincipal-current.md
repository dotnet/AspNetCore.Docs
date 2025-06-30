---
title: Migrate from ClaimsPrincipal.Current
author: mjrousos
description: Learn how to migrate away from ClaimsPrincipal.Current to retrieve the current authenticated user's identity and claims in ASP.NET Core.
ms.author: wpickett
ms.custom: mvc
ms.date: 06/30/2025
uid: migration/fx-to-core/areas/claimsprincipal-current
---
# Migrate from ClaimsPrincipal.Current

The current ClaimsPrincipal is a fundamental component of authenticated web applications, providing access to the current user's identity and claims. When migrating from ASP.NET Framework to ASP.NET Core, accessing this presents unique challenges because the two frameworks have different approaches to user context management.

## Why ClaimsPrincipal migration is complex

ASP.NET Framework and ASP.NET Core have fundamentally different approaches to accessing the current user:

* **ASP.NET Framework** uses static properties like <xref:System.Security.Claims.ClaimsPrincipal.Current?displayProperty=nameWithType> and <xref:System.Threading.Thread.CurrentPrincipal> with automatic context management. These properties are interchangeable and both provide access to the current user's identity.
* **ASP.NET Core** stores the current user in <xref:Microsoft.AspNetCore.Http.HttpContext.User?displayProperty=nameWithType> and avoids static state.

These differences mean you can't simply continue using static principal properties (<xref:System.Security.Claims.ClaimsPrincipal.Current?displayProperty=nameWithType> or <xref:System.Threading.Thread.CurrentPrincipal?displayProperty=nameWithType>) in ASP.NET Core without changes. By default, the static properties aren't set, and code depending on them needs to be updated to get the current authenticated user's identity through different means.

## Migration strategies overview

You have two main approaches for handling static principal access during migration:

1. **Complete rewrite** - Rewrite all static principal access code to use ASP.NET Core's native patterns
2. **System.Web adapters** - Use adapters to enable static access patterns during incremental migration

For most applications, migrating to ASP.NET Core's native ClaimsPrincipal access provides the best performance and maintainability. However, larger applications or those with extensive static principal usage may benefit from using System.Web adapters during incremental migration.

## Choose your migration approach

You have two main options for migrating static principal access from ASP.NET Framework to ASP.NET Core. Your choice depends on your migration timeline, whether you need to run both applications simultaneously, and how much code you're willing to rewrite.

### Quick decision guide

**Answer these questions to choose your approach:**

1. **Are you doing a complete rewrite or incremental migration?**
   * Complete rewrite → [Complete rewrite to ASP.NET Core patterns](#complete-rewrite-to-aspnet-core-patterns)
   * Incremental migration → Continue to question 2

2. **Do you have extensive static principal usage (<xref:System.Security.Claims.ClaimsPrincipal.Current?displayProperty=nameWithType> or <xref:System.Threading.Thread.CurrentPrincipal?displayProperty=nameWithType>) across shared libraries?**
   * Yes, lots of shared code → [System.Web adapters](#systemweb-adapters)
   * No, isolated static principal usage → [Complete rewrite to ASP.NET Core patterns](#complete-rewrite-to-aspnet-core-patterns)

### Migration approaches comparison

| Approach | Code Changes | Performance | Shared Libraries | When to Use |
|----------|-------------|-------------|------------------|-------------|
| **[Complete rewrite](#complete-rewrite-to-aspnet-core-patterns)** | High - Rewrite all static principal access | Best | Requires updates | Complete rewrites, performance-critical apps |
| **[System.Web adapters](#systemweb-adapters)** | Low - Keep existing patterns | Good | Works with existing code | Incremental migrations, extensive static access |

## Complete rewrite to ASP.NET Core patterns

Choose this approach when you're performing a complete migration or want the best performance and maintainability.

ASP.NET Core provides several options for retrieving the current authenticated user's <xref:System.Security.Claims.ClaimsPrincipal> without relying on static properties. This approach requires rewriting static principal access code but offers the most benefits in the long term.

### Complete rewrite pros and cons

| Pros | Cons |
|------|------|
| Best performance | Requires rewriting all static principal access code |
| More testable (dependency injection) | No automatic migration path |
| No static dependencies | Learning curve for new patterns |
| Native ASP.NET Core implementation | Breaking change from Framework patterns |
| Thread-safe by design | Potential refactoring across shared libraries |

### ASP.NET Core ClaimsPrincipal access patterns

There are several options for retrieving the current authenticated user's <xref:System.Security.Claims.ClaimsPrincipal> in ASP.NET Core in place of <xref:System.Security.Claims.ClaimsPrincipal.Current?displayProperty=nameWithType>:

* **<xref:Microsoft.AspNetCore.Mvc.ControllerBase.User?displayProperty=nameWithType>**
* **<xref:Microsoft.AspNetCore.Http.HttpContext.User?displayProperty=nameWithType>**
* **Passed in from caller**. Libraries without access to the current <xref:Microsoft.AspNetCore.Http.HttpContext> are often called from controllers or middleware components and can have the current user's identity passed as an argument.
* **<xref:Microsoft.AspNetCore.Http.IHttpContextAccessor>**. The project being migrated to ASP.NET Core may be too large to easily pass the current user's identity to all necessary locations. In such cases, <xref:Microsoft.AspNetCore.Http.IHttpContextAccessor> can be used as a workaround. This is not ideal as it uses a static accessor behind the scenes. Prefer a more direct option if possible.

### Code examples

Here are examples of migrating common static principal usage patterns:

**ASP.NET Framework (before):**
```csharp
public class UserService
{
    public string GetCurrentUserId()
    {
        // Both ClaimsPrincipal.Current and Thread.CurrentPrincipal work interchangeably
        return ClaimsPrincipal.Current?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        // or: return Thread.CurrentPrincipal?.Identity?.Name;
    }
}
```

**ASP.NET Core (after) - Pass ClaimsPrincipal as parameter:**
```csharp
public class UserService
{
    public string GetCurrentUserId(ClaimsPrincipal user)
    {
        return user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    }
}

// Usage in controller
public class HomeController : Controller
{
    private readonly UserService _userService;
    
    public HomeController(UserService userService)
    {
        _userService = userService;
    }
    
    public IActionResult Index()
    {
        var userId = _userService.GetCurrentUserId(User);
        return View();
    }
}
```

**ASP.NET Core (after) - Dependency Injection:**
```csharp
public class UserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    
    public UserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    
    public string GetCurrentUserId()
    {
        return _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    }
}
```

### When to choose this approach

* You can afford to rewrite static principal access code
* Performance is a top priority (in this case, prefer passing the identity as a parameter over DI)
* You want to eliminate static dependencies
* You're not sharing code with legacy applications
* You want the most testable and maintainable solution

## System.Web adapters

[!INCLUDE[](~/migration/fx-to-core/includes/uses-systemweb-adapters.md)]

Choose this approach when you need to maintain existing static principal usage patterns during incremental migration, or when you have extensive shared libraries that would be difficult to update.

The System.Web adapters can enable both <xref:System.Security.Claims.ClaimsPrincipal.Current?displayProperty=nameWithType> and <xref:System.Threading.Thread.CurrentPrincipal?displayProperty=nameWithType> support in ASP.NET Core, allowing you to keep existing code patterns while migrating incrementally. Both properties work interchangeably once adapters are configured.

### System.Web adapters pros and cons

| Pros | Cons |
|------|------|
| Minimal code changes required | Performance overhead |
| Works with existing shared libraries | Not thread-safe in all scenarios |
| Enables incremental migration | Requires System.Web adapters dependency |
| Maintains familiar patterns | Should be temporary solution |
| Good for large codebases | Less testable than DI patterns |

### Setting up static principal support

To enable static principal support (<xref:System.Security.Claims.ClaimsPrincipal.Current?displayProperty=nameWithType> and <xref:System.Threading.Thread.CurrentPrincipal?displayProperty=nameWithType>) with System.Web adapters, endpoints must be annotated with the `SetThreadCurrentPrincipalAttribute` metadata:

```csharp
// Add to controller or action
[SetThreadCurrentPrincipal]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        // Both ClaimsPrincipal.Current and Thread.CurrentPrincipal are now available
        var user1 = ClaimsPrincipal.Current;
        var user2 = Thread.CurrentPrincipal;
        return View();
    }
}
```

### When to use System.Web adapters

* You have extensive static principal usage across shared libraries
* You're doing an incremental migration
* You can't afford to rewrite all static principal access code immediately
* You need to maintain compatibility with existing ASP.NET Framework code
* You understand the performance and threading implications

## Migration considerations

### Performance implications

* **Native ASP.NET Core patterns** provide the best performance with no overhead
* **System.Web adapters** introduce some performance overhead but enable gradual migration
* **Static variables** should be avoided as they can cause memory leaks and threading issues
