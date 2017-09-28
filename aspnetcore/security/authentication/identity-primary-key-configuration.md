---
title: Configure Identity primary keys data type
author: AdrienTorris
description: This article outlines the steps for configuring the desired data type used for the ASP.NET Core Identity primary keys.
keywords: ASP.NET Core,Identity,primary key
ms.author: scaddie
manager: wpickett
ms.date: 09/28/2017
ms.topic: article
ms.technology: aspnet
ms.prod: asp.net-core
uid: security/authentication/identity-primary-key-configuration
---
# Configure the ASP.NET Core Identity primary key data type

ASP.NET Core Identity allows you to configure the data type used to represent a primary key. Identity uses the `string` data type by default. You can override this behavior.

## Customize the primary key data type

1. Create a custom implementation of the [IdentityUser](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.identity.entityframeworkcore.identityuser-1) class. It represents the type to be used for creating user objects. In the following example, the default `string` type is replaced with `Guid`.

    [!code-csharp[Main](identity/sample/src/ASPNET-IdentityDemo-PrimaryKeysConfig/Models/ApplicationUser.cs?highlight=4-6&range=7-13)]

1. Create a custom implementation of the [IdentityRole](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.identity.entityframeworkcore.identityrole-1) class. It represents the type to be used for creating role objects. In the following example, the default `string` type is replaced with `Guid`.
    
    [!code-csharp[Main](identity/sample/src/ASPNET-IdentityDemo-PrimaryKeysConfig/Models/ApplicationRole.cs?highlight=3-5&range=7-12)]
	
1. Create a custom database context class. It inherits from the Entity Framework database context class used for Identity. The `TUser` and `TRole` arguments reference the custom user and role classes created in the previous step, respectively. The `Guid` data type is defined for the primary key.

    [!code-csharp[Main](identity/sample/src/ASPNET-IdentityDemo-PrimaryKeysConfig/Data/ApplicationDbContext.cs?highlight=3&range=9-26)]
	
1. Register your custom database context class when adding the Identity service in the app's startup class.

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

The `AddEntityFrameworkStores` method doesn't accept a `TKey` argument as it did in ASP.NET Core 1.x. The primary key's data type is inferred by analyzing the `DbContext` object.

[!code-csharp[Main](identity/sample/src/ASPNETv2-IdentityDemo-PrimaryKeysConfig/Startup.cs?highlight=6-8&range=25-37)]

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

The `AddEntityFrameworkStores` method accepts a `TKey` argument indicating the primary key's data type.

[!code-csharp[Main](identity/sample/src/ASPNET-IdentityDemo-PrimaryKeysConfig/Startup.cs?highlight=9-11&range=39-55)]

---

## Test the changes

Upon completion of the configuration changes, the property representing the primary key reflects the new data type:

[!code-csharp[Main](identity/sample/src/ASPNET-IdentityDemo-PrimaryKeysConfig/Controllers/AccountController.cs?name=snippet_GetCurrentUserId&highlight=6)]