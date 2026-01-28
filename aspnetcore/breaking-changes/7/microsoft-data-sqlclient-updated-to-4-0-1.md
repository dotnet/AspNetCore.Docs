---
title: "Breaking change: Microsoft.Data.SqlClient updated to 4.0.1"
description: Learn about the breaking change in ASP.NET Core 7.0 where Microsoft.Data.SqlClient has been updated to 4.0.1.
ms.date: 03/07/2022
ms.custom: https://github.com/aspnet/Announcements/issues/481
---

# Microsoft.Data.SqlClient updated to 4.0.1

The `Microsoft.Data.SqlClient` package has been updated to 4.0.1.

## Version introduced

ASP.NET Core 7.0

## Previous behavior

The previous version of the package was `1.0.19249.1`.

## New behavior

The new version of the `Microsoft.Data.SqlClient` package is `4.0.1`. You can see breaking changes in the 4.0 band in the [Microsoft.Data.SqlClient 4.0.0 Release Notes](https://github.com/dotnet/SqlClient/blob/main/release-notes/4.0/4.0.0.md#breaking-changes).

By default, `Encrypt` now equals `true`. For more information, see [Encrypt default value set to true](https://github.com/dotnet/SqlClient/blob/main/release-notes/4.0/4.0.0.md#encrypt-default-value-set-to-true).

## Type of breaking change

This change affects [source compatibility](/dotnet/core/compatibility/categories#source-compatibility).

## Reason for change

For improvements in the underlying libraries.

## Recommended action

The ASP.NET Core team didn't have to react to any public API changes from this change. However, it's possible that there are breaking changes in the packages themselves that you'll need to react to.

## Affected APIs

* <xref:Microsoft.Extensions.Caching.SqlServer?displayProperty=fullName>
