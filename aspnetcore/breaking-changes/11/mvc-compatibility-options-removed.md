---
title: "Breaking change: MVC compatibility options removed"
ai-usage: ai-assisted
description: "Learn about the breaking change in ASP.NET Core 11 where the MVC compatibility version APIs, including CompatibilityVersion and SetCompatibilityVersion, are removed."
ms.date: 08/05/2026
---
# MVC compatibility options removed

The MVC compatibility version APIs, such as `CompatibilityVersion` and `SetCompatibilityVersion`, are removed in ASP.NET Core 11. These APIs were no-ops since ASP.NET Core 3.0 and have been marked obsolete since ASP.NET Core 6.

## Version introduced

.NET 11 Preview 7

## Previous behavior

Previously, the compatibility version APIs existed and could be called, but they produced an obsoletion warning at build time and had no effect at runtime:

```csharp
services.AddMvc()
    .SetCompatibilityVersion(CompatibilityVersion.Latest);
```

## New behavior

Starting in ASP.NET Core 11, these APIs no longer exist. Code that calls them fails to compile, and existing binaries that reference them fail at runtime with a <xref:System.MissingMethodException> or <xref:System.TypeLoadException>.

## Type of breaking change

This change can affect [source compatibility](/dotnet/core/compatibility/categories#source-compatibility) and [binary compatibility](/dotnet/core/compatibility/categories#binary-compatibility).

## Reason for change

The APIs have been marked obsolete since ASP.NET Core 6 and did nothing since ASP.NET Core 3.0, so they served no value. For more information, see [dotnet/aspnetcore#67077](https://github.com/dotnet/aspnetcore/pull/67077).

## Recommended action

Remove any usages of these APIs. For example, change the following code:

```csharp
services.AddMvc()
    .SetCompatibilityVersion(CompatibilityVersion.Latest);
```

To:

```csharp
services.AddMvc();
```

## Affected APIs

- `Microsoft.Extensions.DependencyInjection.MvcCoreMvcBuilderExtensions.SetCompatibilityVersion`
- `Microsoft.Extensions.DependencyInjection.MvcCoreMvcCoreBuilderExtensions.SetCompatibilityVersion`
- `Microsoft.AspNetCore.Mvc.Infrastructure.ConfigureCompatibilityOptions<TOptions>`
- `Microsoft.AspNetCore.Mvc.MvcCompatibilityOptions`
- `Microsoft.AspNetCore.Mvc.CompatibilityVersion`
