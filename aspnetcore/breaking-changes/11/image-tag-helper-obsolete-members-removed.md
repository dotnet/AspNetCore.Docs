---
title: "Breaking change: Obsolete ImageTagHelper members removed"
description: "Learn about the breaking change in ASP.NET Core 11 where obsolete ImageTagHelper members have been removed."
ms.date: 08/05/2026
ai-usage: ai-assisted
---
# Obsolete ImageTagHelper members removed

A constructor overload and two properties of `ImageTagHelper` that were marked obsolete since ASP.NET Core 3.0 Preview 4 have been removed in ASP.NET Core 11.

## Version introduced

.NET 11 Preview 7

## Previous behavior

Previously, the affected members existed but produced an obsolete warning when used.

## New behavior

Starting in .NET 11, the following `ImageTagHelper` members no longer exist:

* The constructor overload `ImageTagHelper(IWebHostEnvironment, TagHelperMemoryCacheProvider, IFileVersionProvider, HtmlEncoder, IUrlHelperFactory)`.
* The `HostingEnvironment` property.
* The `Cache` property.

## Type of breaking change

This change can affect [source compatibility](/dotnet/core/compatibility/categories#source-compatibility) and/or [binary compatibility](/dotnet/core/compatibility/categories#source-compatibility).

## Reason for change

These APIs were marked obsolete since ASP.NET Core 3.0. For more information, see [dotnet/aspnetcore#67077](https://github.com/dotnet/aspnetcore/pull/67077).

## Recommended action

Remove usages of these APIs. The `HostingEnvironment` and `Cache` properties had no effect, so the corresponding constructor was removed as well.

## Affected APIs

- `Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper.ImageTagHelper(Microsoft.AspNetCore.Hosting.IWebHostEnvironment, Microsoft.AspNetCore.Mvc.TagHelpers.Cache.TagHelperMemoryCacheProvider, Microsoft.AspNetCore.Mvc.ViewFeatures.IFileVersionProvider, System.Text.Encodings.Web.HtmlEncoder, Microsoft.AspNetCore.Mvc.Routing.IUrlHelperFactory)`
- `Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper.HostingEnvironment`
- `Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper.Cache`
