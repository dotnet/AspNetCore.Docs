---
title: "Breaking change: Minimal API renames in RC 2"
description: Learn about the breaking change in ASP.NET Core 6.0 RC 2 where some minimal APIs were renamed.
ms.date: 10/25/2021
ms.custom: https://github.com/aspnet/Announcements/issues/474
---
# Minimal API renames in RC 2

To improve the consistency of type names, two classes were renamed, and one class was removed and its methods merged into the existing <xref:Microsoft.AspNetCore.Builder.EndpointRouteBuilderExtensions> class.

## Version introduced

ASP.NET Core 6.0 RC 2

## Old and new behavior

- The `Microsoft.AspNetCore.Builder.DelegateEndpointConventionBuilder` class was renamed to <xref:Microsoft.AspNetCore.Builder.RouteHandlerBuilder?displayProperty=fullName>.
- The `Microsoft.AspNetCore.Http.OpenApiDelegateEndpointConventionBuilderExtensions` class was renamed to <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions?displayProperty=fullName>.
- The `Microsoft.AspNetCore.Builder.DelegateEndpointRouteBuilderExtensions` class was removed and all of its methods were merged into the existing <xref:Microsoft.AspNetCore.Builder.EndpointRouteBuilderExtensions?displayProperty=fullName> class.

## Change category

This change affects [binary compatibility](../../categories.md#binary-compatibility) and [source compatibility](../../categories.md#source-compatibility).

## Reason for change

This change was made to improve the consistency of type names. Now that there is a new <xref:Microsoft.AspNetCore.Routing.RouteHandlerOptions> class, we wanted to replace `DelegateEndpoint` with `RouteHandler`.

## Recommended action

Recompile any projects built with an earlier SDK. For most projects, this should be all that's necessary.

If your code references any of these type names directly by name, updated the code to reflect the new names.

## Affected APIs

- `Microsoft.AspNetCore.Builder.DelegateEndpointConventionBuilder`
- `Microsoft.AspNetCore.Http.OpenApiDelegateEndpointConventionBuilderExtensions`
- `Microsoft.AspNetCore.Builder.DelegateEndpointRouteBuilderExtensions`
