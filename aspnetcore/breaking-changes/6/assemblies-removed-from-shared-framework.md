---
title: "Breaking change: Assemblies removed from Microsoft.AspNetCore.App shared framework"
description: "Learn about the breaking change in ASP.NET Core 6.0 where some assemblies where removed from the Microsoft.AspNetCore.App shared framework."
ms.date: 04/02/2021
ms.custom: https://github.com/aspnet/Announcements/issues/456
---
# Assemblies removed from Microsoft.AspNetCore.App shared framework

The following two assemblies were removed from the ASP.NET Core targeting pack:

- System.Security.Permissions
- System.Windows.Extensions

In addition, the following assemblies were removed from the ASP.NET Core runtime pack:

- Microsoft.Win32.SystemEvents
- System.Drawing.Common
- System.Security.Permissions
- System.Windows.Extensions

## Version introduced

ASP.NET Core 6.0

## Old behavior

Applications could use APIs provided by these libraries by referencing the [Microsoft.AspNetCore.App](/aspnet/core/fundamentals/metapackage-app) shared framework.

## New behavior

If you use APIs from the affected assemblies without having a [PackageReference](../../../project-sdk/msbuild-props.md#packagereference) in your project file, you might see runtime errors. For example, an application that uses reflection to access APIs from one of these assemblies without adding an explicit reference to the package will have runtime errors. The `PackageReference` ensures that the assemblies are present as part of the application output.

For discussion, see <https://github.com/dotnet/aspnetcore/issues/31007>.

## Reason for change

This change was introduced to reduce the size of the ASP.NET Core shared framework.

## Recommended action

To continue using these APIs in your project, add a [PackageReference](../../../project-sdk/msbuild-props.md#packagereference). For example:

```xml
<PackageReference Include="System.Security.Permissions" Version="6.0.0" />
```

## Affected APIs

- <xref:System.Security.Permissions?displayProperty=fullName>
- <xref:System.Media?displayProperty=fullName>
- <xref:System.Security.Cryptography.X509Certificates.X509Certificate2UI?displayProperty=fullName>
- <xref:System.Xaml.Permissions.XamlAccessLevel?displayProperty=fullName>

<!--

## Category

ASP.NET Core

## Affected APIs

- `N:System.Security.Permissions`
- `N:System.Media`
- `N:System.Security.Cryptography.X509Certificates.X509Certificate2UI`
- `N:System.Xaml.Permissions.XamlAccessLevel`

-->
