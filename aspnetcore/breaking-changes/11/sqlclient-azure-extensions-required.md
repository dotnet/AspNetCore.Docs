---
title: "Breaking change: SqlClient Active Directory authentication moved to a separate package"
ai-usage: ai-assisted
description: "Learn about the breaking change in ASP.NET Core 11 where Microsoft.Data.SqlClient 7.x extracts Active Directory authentication providers into the Microsoft.Data.SqlClient.Extensions.Azure package."
ms.date: 06/04/2026
---

# SqlClient Active Directory authentication moved to a separate package

ASP.NET Core 11 transitively brings in `Microsoft.Data.SqlClient` 7.x (up from 5.x in .NET 10). Starting in `Microsoft.Data.SqlClient` 6.0, the Microsoft Entra ID (formerly Azure Active Directory) authentication providers are no longer in the main `Microsoft.Data.SqlClient` package; they ship in a separate [`Microsoft.Data.SqlClient.Extensions.Azure`](https://www.nuget.org/packages/Microsoft.Data.SqlClient.Extensions.Azure) package. Apps that use an Entra ID `Authentication=` value in their SQL connection string must add a reference to this package.

## Version introduced

.NET 11 Preview 3

## Previous behavior

Previously, the `Microsoft.Data.SqlClient` 5.x package included the Entra ID authentication providers. A connection string such as `Server=...;Database=...;Authentication=Active Directory Default` worked out of the box for any ASP.NET Core app that transitively pulled in `Microsoft.Data.SqlClient` (for example, through `Microsoft.Extensions.Caching.SqlServer` or an Entity Framework Core SQL Server provider).

## New behavior

Starting in ASP.NET Core 11, the transitive `Microsoft.Data.SqlClient` version is 7.x, which no longer ships the Entra ID authentication providers. If your connection string uses one of the `Active Directory *` `Authentication=` values and you haven't added the `Microsoft.Data.SqlClient.Extensions.Azure` package, you get a runtime error similar to:

```output
Cannot find an authentication provider for 'ActiveDirectoryDefault'.
Install the 'Microsoft.Data.SqlClient.Extensions.Azure' NuGet package to use Active Directory (Entra ID) authentication methods.
```

This affects apps that use `Microsoft.Extensions.Caching.SqlServer` (`DistributedSqlServerCache`), apps that use the EF Core SQL Server provider, and any other code path that transitively brings in `Microsoft.Data.SqlClient` and uses Entra ID authentication.

## Type of breaking change

This change is a [behavioral change](/dotnet/core/compatibility/categories#behavioral-change).

## Reason for change

The change to move Microsoft Entra ID authentication out of `Microsoft.Data.SqlClient` was made in the upstream `Microsoft.Data.SqlClient` 6.0 release. ASP.NET Core 11 picks up that change by upgrading the SqlClient version it depends on transitively. For more information, see [dotnet/aspnetcore#66179](https://github.com/dotnet/aspnetcore/pull/66179).

## Recommended action

If your app uses a SQL connection string with any `Active Directory *` `Authentication=` value, add a `PackageReference` to `Microsoft.Data.SqlClient.Extensions.Azure`:

```xml
<ItemGroup>
  <PackageReference Include="Microsoft.Data.SqlClient.Extensions.Azure" Version="1.0.0" />
</ItemGroup>
```

The ASP.NET Core "Individual Accounts" project templates were updated to add this reference for the Azure SQL configurations they support. New projects don't require any manual change.

## Affected APIs

None. The break is a transitive runtime requirement to install a NuGet package. No types in `Microsoft.AspNetCore.*` are affected.
