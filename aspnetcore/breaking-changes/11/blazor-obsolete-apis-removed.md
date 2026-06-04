---
title: "Breaking change: Obsolete Blazor APIs removed"
ai-usage: ai-assisted
description: "Learn about the breaking change in ASP.NET Core 11 where APIs that were marked obsolete in earlier Blazor releases have been removed."
ms.date: 06/04/2026
---

# Obsolete Blazor APIs removed

A set of APIs across the Blazor Components assemblies that were previously marked obsolete have been removed in ASP.NET Core 11. Most of these APIs were marked obsolete several releases ago and have working replacements that have been recommended for years.

## Version introduced

.NET 11

## Previous behavior

Previously, the affected APIs compiled with an obsolete warning. Most of the warnings pointed at a replacement API. For example, calling `EditContext.AddDataAnnotationsValidation()` produced an obsolete warning recommending `EnableDataAnnotationsValidation`.

## New behavior

In ASP.NET Core 11, the following APIs are removed and no longer compile.

### Microsoft.AspNetCore.Components

- `Router.PreferExactMatches` property. The property has had no effect since exact-match routing became the default in .NET 6.
- `ResourceAsset(string url)` constructor overload.

### Microsoft.AspNetCore.Components.Forms

- `EditContextDataAnnotationsExtensions.AddDataAnnotationsValidation(EditContext)` extension method.
- `EditContextDataAnnotationsExtensions.EnableDataAnnotationsValidation(EditContext)` overload (the overload without an `IServiceProvider` parameter).
- `RemoteBrowserFileStreamOptions` class.

### Microsoft.AspNetCore.Components.Web

- `WebEventCallbackFactoryEventArgsExtensions` class and all of its extension methods.
- The `init` accessor on `WebRenderer.RendererId`. The property is now set only via constructor.

### Microsoft.AspNetCore.Components.WebAssembly

- `JSInteropMethods.NotifyLocationChanged(string, bool)` method.

### Microsoft.AspNetCore.Components.WebAssembly.Authentication

- `SignOutSessionStateManager` class. The class has been a no-op since .NET 7.
- `RemoteAuthenticationService` constructor overload that doesn't take a logger.
- `AccessTokenResult` constructor and the `RedirectUrl` property.
- `AccessTokenNotAvailableException` now uses `InteractiveRequestUrl` in place of the removed `RedirectUrl`.

## Type of breaking change

This change can affect [source compatibility](/dotnet/core/compatibility/categories#source-compatibility).

## Reason for change

These APIs were marked obsolete in earlier releases (most between .NET 5 and .NET 8). Each had a documented replacement, and continuing to ship the obsolete surface area increased maintenance cost and surface area for Blazor without benefit. For more information, see [dotnet/aspnetcore#62755](https://github.com/dotnet/aspnetcore/pull/62755).

## Recommended action

Update your code to use the replacement APIs as listed in the following table.

| Removed API | Replacement |
|-------------|-------------|
| `Router.PreferExactMatches` | Remove the assignment. Exact matching has been the default since .NET 6. |
| `ResourceAsset(string url)` | `ResourceAsset(string url, IReadOnlyList<ResourceAssetProperty>? properties)` |
| `EditContextDataAnnotationsExtensions.AddDataAnnotationsValidation(EditContext)` | `EditContextDataAnnotationsExtensions.EnableDataAnnotationsValidation(EditContext, IServiceProvider)` |
| `EditContextDataAnnotationsExtensions.EnableDataAnnotationsValidation(EditContext)` | `EditContextDataAnnotationsExtensions.EnableDataAnnotationsValidation(EditContext, IServiceProvider)` |
| `RemoteBrowserFileStreamOptions` | `BrowserFileStreamOptions` |
| `WebEventCallbackFactoryEventArgsExtensions` | Use `EventCallbackFactory` directly. |
| `WebRenderer.RendererId.init` accessor | Pass `RendererId` via the `WebRenderer` constructor. |
| `JSInteropMethods.NotifyLocationChanged(string, bool)` | `JSInteropMethods.NotifyLocationChanged(string uri, string? state, bool isInterceptedLink)` (added in .NET 7). This method is for framework use only. |
| `SignOutSessionStateManager` | Delete usages. The class has been a no-op since .NET 7. |
| `RemoteAuthenticationService` (constructor without logger) | The remaining constructor takes an `ILogger<RemoteAuthenticationService<...>>` parameter. |
| `AccessTokenResult` constructor and `RedirectUrl` property | Use the remaining constructor and `InteractiveRequestUrl`. |

## Affected APIs

- <xref:Microsoft.AspNetCore.Components.Routing.Router.PreferExactMatches?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.Components.Forms.EditContextDataAnnotationsExtensions.AddDataAnnotationsValidation*?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.Components.Forms.EditContextDataAnnotationsExtensions.EnableDataAnnotationsValidation*?displayProperty=fullName>
- `Microsoft.AspNetCore.Components.Forms.RemoteBrowserFileStreamOptions`
- `Microsoft.AspNetCore.Components.Web.WebEventCallbackFactoryEventArgsExtensions`
- `Microsoft.AspNetCore.Components.RenderTree.WebRenderer.RendererId` (init accessor)
- `Microsoft.AspNetCore.Components.WebAssembly.Infrastructure.JSInteropMethods.NotifyLocationChanged(System.String, System.Boolean)`
- `Microsoft.AspNetCore.Components.WebAssembly.Authentication.SignOutSessionStateManager`
- `Microsoft.AspNetCore.Components.WebAssembly.Authentication.RemoteAuthenticationService<TRemoteAuthenticationState, TAccount, TProviderOptions>` (constructor overload without logger)
- `Microsoft.AspNetCore.Components.WebAssembly.Authentication.AccessTokenResult` (legacy constructor and `RedirectUrl` property)
- `Microsoft.AspNetCore.Components.ResourceAsset` (constructor overload without `properties`)
