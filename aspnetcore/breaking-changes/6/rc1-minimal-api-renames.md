---
title: "Breaking change: Minimal API renames in RC 1"
description: Learn about the breaking change in ASP.NET Core 6.0 RC 1 where some minimal APIs were renamed.
ms.date: 10/25/2021
ms.custom: https://github.com/aspnet/Announcements/issues/474
---
# Minimal API renames in RC 1

Some APIs were renamed to improve the consistency of type names and to remove "minimal" and "action" from the API names.

## Version introduced

ASP.NET Core 6.0 RC 1

## Old and new behavior

- The `Microsoft.AspNetCore.Builder.MinimalActionEndpointConventionBuilder` class was renamed to `Microsoft.AspNetCore.Builder.DelegateEndpointConventionBuilder`.

  > [!NOTE]
  > This class was renamed again in RC 2 to <xref:Microsoft.AspNetCore.Builder.RouteHandlerBuilder?displayProperty=fullName>.

- The `Microsoft.AspNetCore.Builder.MinimalActionEndpointRouteBuilderExtensions` class was renamed to `Microsoft.AspNetCore.Builder.DelegateEndpointRouteBuilderExtensions`.

  > [!NOTE]
  > This class was merged with <xref:Microsoft.AspNetCore.Builder.EndpointRouteBuilderExtensions?displayProperty=fullName> in RC 2.

- The <xref:Microsoft.AspNetCore.Http.RequestDelegate> parameter to `Map`, `MapGet`, `MapPost`, `MapPut`, `MapDelete`, `MapMethod`, `MapFallback`, and <xref:Microsoft.AspNetCore.Http.RequestDelegateFactory.Create(System.Delegate,Microsoft.AspNetCore.Http.RequestDelegateFactoryOptions)?displayProperty=nameWithType> was renamed from `action` to `handler`.

## Change category

This change affects [binary compatibility](/dotnet/core/compatibility/categories#binary-compatibility) and [source compatibility](/dotnet/core/compatibility/categories#source-compatibility).

## Reason for change

This change was made to improve the consistency of type names and to remove "minimal" and "action" from the API names.

## Recommended action

Recompile any projects built with an earlier SDK. For most projects, this should be all that's necessary.

If your code references any of these type or parameter names directly by name, updated the code to reflect the new names.

## Affected APIs

- `Microsoft.AspNetCore.Builder.MinimalActionEndpointConventionBuilder`
- `Microsoft.AspNetCore.Builder.MinimalActionEndpointRouteBuilderExtensions`
- `Microsoft.AspNetCore.Builder.MinimalActionEndpointRouteBuilderExtensions.Map()`
- `Microsoft.AspNetCore.Builder.MinimalActionEndpointRouteBuilderExtensions.MapGet()`
- `Microsoft.AspNetCore.Builder.MinimalActionEndpointRouteBuilderExtensions.MapPost()`
- `Microsoft.AspNetCore.Builder.MinimalActionEndpointRouteBuilderExtensions.MapPut()`
- `Microsoft.AspNetCore.Builder.MinimalActionEndpointRouteBuilderExtensions.MapDelete()`
- `Microsoft.AspNetCore.Builder.MinimalActionEndpointRouteBuilderExtensions.MapMethod()`
- `Microsoft.AspNetCore.Builder.MinimalActionEndpointRouteBuilderExtensions.MapFallback()`
- `Microsoft.AspNetCore.Http.RequestDelegateFactory.Create(Delegate action, RequestDelegateFactoryOptions? options = null)`
