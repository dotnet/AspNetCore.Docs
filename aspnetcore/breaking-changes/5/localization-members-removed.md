---
title: "Breaking change: Localization: ResourceManagerWithCultureStringLocalizer class and WithCulture interface member removed"
description: "Learn about the breaking change in ASP.NET Core 5.0 titled Localization: ResourceManagerWithCultureStringLocalizer class and WithCulture interface member removed"
ms.author: scaddie
ms.date: 10/01/2020
ms.custom: https://github.com/aspnet/Announcements/issues/346
---
# Localization: ResourceManagerWithCultureStringLocalizer class and WithCulture interface member removed

The `Microsoft.Extensions.Localization.ResourceManagerWithCultureStringLocalizer` class and `Microsoft.Extensions.Localization.ResourceManagerStringLocalizer.WithCulture` method were removed in .NET 5.

For context, see [aspnet/Announcements#346](https://github.com/aspnet/Announcements/issues/346) and [dotnet/aspnetcore#3324](https://github.com/dotnet/aspnetcore/issues/3324). For discussion on this change, see [dotnet/aspnetcore#7756](https://github.com/dotnet/aspnetcore/issues/7756).

## Version introduced

5.0

## Old behavior

The `ResourceManagerWithCultureStringLocalizer` class and the `ResourceManagerStringLocalizer.WithCulture` method are [obsolete in .NET Core 3.0 and later](/dotnet/core/compatibility/3.0#localization-resourcemanagerwithculturestringlocalizer-and-withculture-marked-obsolete).

## New behavior

The `ResourceManagerWithCultureStringLocalizer` class and the `ResourceManagerStringLocalizer.WithCulture` method have been removed in .NET 5. For an inventory of the changes made, see the pull request at [dotnet/extensions#2562](https://github.com/dotnet/extensions/pull/2562/files).

## Reason for change

The `ResourceManagerWithCultureStringLocalizer` class and `ResourceManagerStringLocalizer.WithCulture` method were often sources of confusion for users of localization. The confusion was especially high when creating a custom <xref:Microsoft.Extensions.Localization.IStringLocalizer> implementation. This class and method give consumers the impression that an `IStringLocalizer` instance is expected to be "per-language, per-resource". In reality, the instance should only be "per-resource". At runtime, the <xref:System.Globalization.CultureInfo.CurrentUICulture%2A?displayProperty=nameWithType> property determines the language to be used.

## Recommended action

Stop using the `ResourceManagerWithCultureStringLocalizer` class and the `ResourceManagerStringLocalizer.WithCulture` method.

## Affected APIs

- `Microsoft.Extensions.Localization.ResourceManagerWithCultureStringLocalizer`
- `Microsoft.Extensions.Localization.ResourceManagerStringLocalizer.WithCulture`
