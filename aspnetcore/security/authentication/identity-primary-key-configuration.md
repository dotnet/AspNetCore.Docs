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
# Configure ASP.NET Core Identity primary keys data type

ASP.NET Core Identity allows you to easily configure the data type you want for the primary keys. By default, Identity uses the `string` data type. You can override this behavior.

## How to

1. Implement the Identity's model, and override the `string` type with the data type you want.

    [!code-csharp[Main](identity/sample/src/ASPNET-IdentityDemo-PrimaryKeysConfig/Models/ApplicationUser.cs?highlight=4-6&range=7-13)]

    [!code-csharp[Main](identity/sample/src/ASPNET-IdentityDemo-PrimaryKeysConfig/Models/ApplicationRole.cs?highlight=3-5&range=7-12)]
	
2. Implement the database context of Identity with your models and the data type you want for primary keys.

    [!code-csharp[Main](identity/sample/src/ASPNET-IdentityDemo-PrimaryKeysConfig/Data/ApplicationDbContext.cs?highlight=3&range=9-26)]
	
3. Use your models and the data type you want for primary keys when you declare the Identity service in your application's startup class.

    [!code-csharp[Main](identity/sample/src/ASPNET-IdentityDemo-PrimaryKeysConfig/Startup.cs?highlight=9-11&range=39-79)]
