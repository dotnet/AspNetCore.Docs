---
title: Configure Identity primary key data type in ASP.NET Core
author: AdrienTorris
description: Learn about the steps for configuring the data type used for storing the ASP.NET Core Identity primary key.
ms.author: scaddie
ms.date: 09/20/2018
uid: security/authentication/identity-primary-key-configuration
---
# Configure Identity primary key data type in ASP.NET Core

By [Scott Addie](https://twitter.com/Scott_Addie)

ASP.NET Core Identity allows you to configure the data type used to represent a primary key. Identity uses the `string` data type by default. You can override this behavior.

[View or download the sample code.](https://github.com/aspnet/Docs/tree/master/aspnetcore/security/authentication/identity-primary-key-configuration/samples) [(How to download)](xref:tutorials/index#how-to-download-a-sample)

## Customize the primary key data type

::: moniker range="<= aspnetcore-1.1"

1. Create a custom implementation of the <xref:Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser`1> class. The class represents a user in the Identity system. In the following example, the default `string` type is replaced with `Guid`:

  [!code-csharp[](identity-primary-key-configuration/samples/1.1/MvcSampleApp/Models/ApplicationUser.cs?highlight=6)]

1. Create a custom implementation of the <xref:Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole`1> class. The class represents a role in the Identity system. In the following example, the default `string` type is replaced with `Guid`:

  [!code-csharp[](identity-primary-key-configuration/samples/1.1/MvcSampleApp/Models/ApplicationRole.cs?highlight=6)]

1. Create a custom database context class deriving from <xref:Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext`3>&mdash;the Entity Framework Core database context class used for Identity. The `TUser` and `TRole` types reference the custom `ApplicationUser` and `ApplicationRole` classes created in the previous step, respectively. The `Guid` data type is defined for the primary key.

  [!code-csharp[](identity-primary-key-configuration/samples/1.1/MvcSampleApp/Data/ApplicationDbContext.cs?highlight=7-8)]

1. Register the custom database context class when adding the Identity service in `Startup.ConfigureServices`. The <xref:Microsoft.Extensions.DependencyInjection.IdentityEntityFrameworkBuilderExtensions.AddEntityFrameworkStores*> method accepts a `TKey` type indicating the primary key's data type.

  [!code-csharp[](identity-primary-key-configuration/samples/1.1/MvcSampleApp/Startup.cs?name=snippet_ConfigureServices&highlight=7-9)]

::: moniker-end

::: moniker range="= aspnetcore-2.0"

1. Create a custom implementation of the <xref:Microsoft.AspNetCore.Identity.IdentityUser`1> class. The class represents a user in the Identity system. In the following example, the default `string` type is replaced with `Guid`:

  [!code-csharp[](identity-primary-key-configuration/samples/2.0/RazorPagesSampleApp/Data/ApplicationUser.cs?highlight=6)]

1. Create a custom implementation of the <xref:Microsoft.AspNetCore.Identity.IdentityRole`1> class. The class represents a role in the Identity system. In the following example, the default `string` type is replaced with `Guid`:

  [!code-csharp[](identity-primary-key-configuration/samples/2.0/RazorPagesSampleApp/Data/ApplicationRole.cs?highlight=6)]

1. Create a custom database context class deriving from <xref:Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext`3>&mdash;the Entity Framework Core database context class used for Identity. The `TUser` and `TRole` types reference the custom `ApplicationUser` and `ApplicationRole` classes created in the previous step, respectively. The `Guid` data type is defined for the primary key.

  [!code-csharp[](identity-primary-key-configuration/samples/2.0/RazorPagesSampleApp/Data/ApplicationDbContext.cs?highlight=7-8)]

1. Register the custom database context class when adding the Identity service in `Startup.ConfigureServices`. The <xref:Microsoft.Extensions.DependencyInjection.IdentityEntityFrameworkBuilderExtensions.AddEntityFrameworkStores*> method doesn't accept a `TKey` type as it did in ASP.NET Core 1.x. The primary key's data type is inferred by analyzing the <xref:Microsoft.EntityFrameworkCore.DbContext> object.

  [!code-csharp[](identity-primary-key-configuration/samples/2.0/RazorPagesSampleApp/Startup.cs?name=snippet_ConfigureServices&highlight=7-9)]

::: moniker-end

::: moniker range=">= aspnetcore-2.1"

1. Create a custom implementation of the <xref:Microsoft.AspNetCore.Identity.IdentityUser`1> class. The class represents a user in the Identity system. In the following example, the default `string` type is replaced with `Guid`:

  [!code-csharp[](identity-primary-key-configuration/samples/2.1/RazorPagesSampleApp/Data/ApplicationUser.cs?highlight=6)]

1. Create a custom implementation of the <xref:Microsoft.AspNetCore.Identity.IdentityRole`1> class. The class represents a role in the Identity system. In the following example, the default `string` type is replaced with `Guid`:

  [!code-csharp[](identity-primary-key-configuration/samples/2.1/RazorPagesSampleApp/Data/ApplicationRole.cs?highlight=6)]

1. Create a custom database context class deriving from <xref:Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext`3>&mdash;the Entity Framework Core database context class used for Identity. The `TUser` and `TRole` types reference the custom `ApplicationUser` and `ApplicationRole` classes created in the previous step, respectively. The `Guid` data type is defined for the primary key.

  [!code-csharp[](identity-primary-key-configuration/samples/2.1/RazorPagesSampleApp/Data/ApplicationDbContext.cs?highlight=7-8)]

1. Register the custom database context class when adding the Identity service in `Startup.ConfigureServices`. The <xref:Microsoft.Extensions.DependencyInjection.IdentityEntityFrameworkBuilderExtensions.AddEntityFrameworkStores*> method doesn't accept a `TKey` type as it did in ASP.NET Core 1.x. The primary key's data type is inferred by analyzing the <xref:Microsoft.EntityFrameworkCore.DbContext> object.

  [!code-csharp[](identity-primary-key-configuration/samples/2.1/RazorPagesSampleApp/Startup.cs?name=snippet_ConfigureServices&highlight=13-16)]

In ASP.NET Core 2.1 or later, ASP.NET Core Identity is provided as a Razor Class Library. For more information, see <xref:security/authentication/scaffold-identity>. Consequently, the preceding code requires a call to <xref:Microsoft.AspNetCore.Identity.IdentityBuilderUIExtensions.AddDefaultUI*>. If the Identity scaffolder was run to add Identity files to the project, remove the call to `AddDefaultUI`.

::: moniker-end

## Test the changes

After completing the configuration changes, the property corresponding to the primary key uses the new data type.

::: moniker range="<= aspnetcore-1.1"

The following example demonstrates accessing the property in an MVC controller:

::: moniker-end

::: moniker range=">= aspnetcore-2.0"

The following example demonstrates accessing the property in a Razor Pages Page Model or an MVC controller:

::: moniker-end

[!code-csharp[](identity-primary-key-configuration/samples/2.0/RazorPagesSampleApp/Controllers/AccountController.cs?name=snippet_GetCurrentUserId&highlight=9)]

In the preceding code, `_userManager` is an instance of `UserManager<ApplicationUser>` that is injected into the Page Model or controller constructor.

## Additional resources

* <xref:security/authentication/scaffold-identity>
