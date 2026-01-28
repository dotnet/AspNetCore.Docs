---
title: "Breaking change: AddDataAnnotationsValidation method obsoleted"
description: "Learn about the breaking change in ASP.NET Core 6.0 where the AddDataAnnotationsValidation method is replaced with EnableDataAnnotationsValidation."
ms.date: 04/21/2021
ms.custom: https://github.com/aspnet/Announcements/issues/458
---
# AddDataAnnotationsValidation method made obsolete

The extension method <xref:Microsoft.AspNetCore.Components.Forms.EditContextDataAnnotationsExtensions.AddDataAnnotationsValidation(Microsoft.AspNetCore.Components.Forms.EditContext)?displayProperty=nameWithType> is marked as obsolete starting in ASP.NET Core 6. Developers should use the new extension method `EditContextDataAnnotationsExtensions.EnableDataAnnotationsValidation` instead.

The only difference between these two APIs is their return value:

```csharp
EditContext AddDataAnnotationsValidation(this EditContext editContext) { ... }

IDisposable EnableDataAnnotationsValidation(this EditContext editContext) { ... }
```

## Version introduced

ASP.NET Core 6.0

## Old behavior

The older API, <xref:Microsoft.AspNetCore.Components.Forms.EditContextDataAnnotationsExtensions.AddDataAnnotationsValidation(Microsoft.AspNetCore.Components.Forms.EditContext)>, returns its `EditContext` (as a kind of fluent API).

## New behavior

The new API, `EnableDataAnnotationsValidation`, returns an <xref:System.IDisposable> whose disposal can be used to remove the data-annotations validation support from the `EditContext`.

## Reason for change

There are cases where it's desirable to remove the data-annotations validation support after adding it. This was not possible with the older API because there was no place to store the internal event subscriptions. The new API returns an object that holds the state necessary to remove data-annotations validation support on disposal.

## Recommended action

Most applications don't need to be changed. The direct use of these extension methods is a rare and advanced case. If your app uses the `<DataAnnotationsValidator>` component instead of calling this method directly, it doesn't need to be changed.

However, if you do call `editContext.AddDataAnnotationsValidation()`, then replace that call with `editContext.EnableDataAnnotationsValidation()`. Optionally, capture the new returned `IDisposable` object and dispose it later if you want to undo the effects of the call.

## Affected APIs

- <xref:Microsoft.AspNetCore.Components.Forms.EditContextDataAnnotationsExtensions.AddDataAnnotationsValidation(Microsoft.AspNetCore.Components.Forms.EditContext)?displayProperty=fullName>

<!--

## Category

ASP.NET Core

## Affected APIs

- `M:Microsoft.AspNetCore.Components.Forms.EditContextDataAnnotationsExtensions.AddDataAnnotationsValidation(Microsoft.AspNetCore.Components.Forms.EditContext)`

-->
