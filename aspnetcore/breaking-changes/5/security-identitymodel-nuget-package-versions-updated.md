---
title: "Breaking change: Security: IdentityModel NuGet package versions updated"
description: "Learn about the breaking change in ASP.NET Core 5.0 titled Security: IdentityModel NuGet package versions updated"
ms.author: scaddie
ms.date: 10/01/2020
ms.custom: https://github.com/aspnet/Announcements/issues/428
---
# Security: IdentityModel NuGet package versions updated

The following packages were updated to version 6.6.0:

- [Microsoft.IdentityModel.Logging](https://www.nuget.org/packages/Microsoft.IdentityModel.Logging)
- [Microsoft.IdentityModel.Protocols.OpenIdConnect](https://www.nuget.org/packages/Microsoft.IdentityModel.Protocols.OpenIdConnect)
- [Microsoft.IdentityModel.Protocols.WsFederation](https://www.nuget.org/packages/Microsoft.IdentityModel.Protocols.WsFederation)
- [System.IdentityModel.Tokens.Jwt](https://www.nuget.org/packages/System.IdentityModel.Tokens.Jwt)

## Version introduced

5.0 Preview 7

## Old behavior

The package version used is 5.5.0.

## New behavior

For details about changes between package versions, see the [6.6.0 release notes](https://github.com/AzureAD/azure-activedirectory-identitymodel-extensions-for-dotnet/releases/tag/6.6.0).

## Reason for change

The packages were updated to take advantage of improvements in the underlying libraries.

## Recommended action

The package updates don't introduce public API changes to ASP.NET Core. However, it's possible there are breaking changes in the packages themselves.

## Affected APIs

None

<!--

### Category

ASP.NET Core

### Affected APIs

Not detectable via API analysis

-->
