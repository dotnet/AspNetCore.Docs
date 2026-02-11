---
title: "Breaking change: Default version of Bootstrap used with Identity now 5"
description: "Learn about the breaking change in ASP.NET Core 6.0 where the default version of Bootstrap used with Identity changes from 4 to 5."
ms.date: 02/15/2022
---
# Identity: Default Bootstrap version of UI changed

Starting in ASP.NET Core 6.0, Identity UI defaults to using [version 5 of Bootstrap](https://getbootstrap.com/docs/5.0/getting-started/introduction/). ASP.NET Core 3.0 to 5.0 used version 4 of Bootstrap.

## Version introduced

ASP.NET Core 6.0

## Behavior

<xref:Microsoft.Extensions.DependencyInjection.IdentityServiceCollectionUIExtensions.AddDefaultIdentity%60%601(Microsoft.Extensions.DependencyInjection.IServiceCollection)> calls the internal private method [TryResolveUIFramework](https://github.com/dotnet/aspnetcore/blob/v6.0.2/src/Identity/UI/src/IdentityBuilderUIExtensions.cs#L82-L102). `TryResolveUIFramework` reads the <xref:Microsoft.AspNetCore.Identity.UI.UIFramework> from the application assembly. The `UIFramework` version defaults to:

* Bootstrap 5 for the .NET 6 SDK
* Bootstrap 4 for the .NET Core 3.1 and .NET 5 SDK

Template-created ASP.NET Core 3.1 and 5.0 apps contain Bootstrap 4 in *wwwroot\lib\bootstrap*. Template-created ASP.NET Core 6 apps use Bootstrap 5. When an ASP.NET Core 3.1 or 5.0 app is migrated to .NET 6, the application detects `UIFramework` version 5, while *wwwroot\lib\bootstrap* contains version 4. This version mismatch renders the Identity templates incorrectly.

## Reason for change

Bootstrap 5 was released during the ASP.NET Core 6.0 timeframe.

## Recommended action

Apps that are impacted by this change use the default Identity UI and have added it in `Startup.ConfigureServices` as shown in the following code:

```csharp
services.AddDefaultIdentity<IdentityUser>()
```

Take one of the following actions:

* Add the MSBuild property `IdentityUIFrameworkVersion` in the project file and specify Bootstrap 4:

  ```xml
  <PropertyGroup>
    <TargetFramework>net6.0</TargetFramework>
    <IdentityUIFrameworkVersion>Bootstrap4</IdentityUIFrameworkVersion>
  </PropertyGroup>
  ```

  The preceding markup sets the `UIFramework` version to Bootstrap 4, the same Bootstrap version as used in ASP.NET Core 3.1 and 5.0.

* Rename or delete the *wwwroot\lib\bootstrap* folder and replace it with the *wwwroot\lib\bootstrap* folder from an ASP.NET Core 6 template-generated app. The Identity templates work with this change but apps using Bootstrap may need to refer to the [Bootstrap 5 migration guide](https://getbootstrap.com/docs/5.0/migration/).

## Affected APIs

<xref:Microsoft.Extensions.DependencyInjection.IdentityServiceCollectionUIExtensions.AddDefaultIdentity%60%601(Microsoft.Extensions.DependencyInjection.IServiceCollection)>
