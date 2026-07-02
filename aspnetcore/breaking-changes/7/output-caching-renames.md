---
title: "Breaking change: Output caching API changes"
description: Learn about the breaking change in ASP.NET Core 7.0 where changes were made to some output caching APIs.
ms.date: 10/10/2022
ms.custom: https://github.com/aspnet/Announcements/issues/492
---
# Output caching API changes

Some APIs in the <xref:Microsoft.AspNetCore.OutputCaching?displayProperty=fullName> namespace have changed to better represent their intent.

The following APIs were removed:

- `OutputCachePolicyBuilder.#ctor`
- `OutputCachePolicyBuilder.Clear`

The following APIs were renamed:

| Previous name | New name |
| - | - |
| `AllowLocking(System.Boolean)` | <xref:Microsoft.AspNetCore.OutputCaching.OutputCachePolicyBuilder.SetLocking(System.Boolean)> |
| `VaryByRouteValue(System.String[])` | <xref:Microsoft.AspNetCore.OutputCaching.OutputCachePolicyBuilder.SetVaryByRouteValue(System.String[])> |
| `VaryByQuery(System.String[])` | <xref:Microsoft.AspNetCore.OutputCaching.OutputCachePolicyBuilder.SetVaryByQuery(System.String[])> |
| `VaryByHeader(System.String[])` | <xref:Microsoft.AspNetCore.OutputCaching.OutputCachePolicyBuilder.SetVaryByHeader(System.String[])> |

The following APIs were added:

- <xref:Microsoft.AspNetCore.OutputCaching.CacheVaryByRules.VaryByHost?displayProperty=nameWithType>
- <xref:Microsoft.AspNetCore.OutputCaching.OutputCacheOptions.AddPolicy(System.String,System.Action{Microsoft.AspNetCore.OutputCaching.OutputCachePolicyBuilder},System.Boolean)?displayProperty=nameWithType>
- <xref:Microsoft.AspNetCore.OutputCaching.OutputCacheOptions.AddBasePolicy(System.Action{Microsoft.AspNetCore.OutputCaching.OutputCachePolicyBuilder},System.Boolean)?displayProperty=nameWithType>
- <xref:Microsoft.Extensions.DependencyInjection.OutputCacheConventionBuilderExtensions.CacheOutput%60%601(%60%600,System.Action{Microsoft.AspNetCore.OutputCaching.OutputCachePolicyBuilder},System.Boolean)?displayProperty=fullName>

## Version introduced

ASP.NET Core 7.0 RC 2

## Previous behavior

`OutputCachePolicyBuilder.VaryByQuery(System.String[])` was additive: every call added more query string keys.

## New behavior

The `OutputCachePolicyBuilder.VaryByQuery(System.String[])` method is now named <xref:Microsoft.AspNetCore.OutputCaching.OutputCachePolicyBuilder.SetVaryByQuery(System.String[])?displayProperty=nameWithType>, and each call replaces existing query string keys.

For other changes, see the first section of this article.

## Type of breaking change

This change affects [source compatibility](/dotnet/core/compatibility/categories#source-compatibility) and [binary compatibility](/dotnet/core/compatibility/categories#binary-compatibility).

## Reason for change

This change was made to improve the consistency of method names and to remove ambiguity in their behavior.

## Recommended action

Recompile any projects built with an earlier SDK. If you referenced any of these method names directly, update the source to reflect the new names.

## Affected APIs

- `Microsoft.AspNetCore.OutputCaching.OutputCachePolicyBuilder.#ctor`
- `Microsoft.AspNetCore.OutputCaching.OutputCachePolicyBuilder.Clear`
- `Microsoft.AspNetCore.OutputCaching.OutputCachePolicyBuilder.AllowLocking(System.Boolean)`
- `Microsoft.AspNetCore.OutputCaching.OutputCachePolicyBuilder.VaryByRouteValue(System.String[])`
- `Microsoft.AspNetCore.OutputCaching.OutputCachePolicyBuilder.VaryByQuery(System.String[])`
- `Microsoft.AspNetCore.OutputCaching.OutputCachePolicyBuilder.VaryByHeader(System.String[])`
