---
title: Configure ASP.NET Core Identity
author: AdrienTorris
description: Understand the ASP.NET Core Identity default values, and configure the various Identity properties to use custom values.
keywords: ASP.NET Core,Identity,authentication,security
ms.author: scaddie
manager: wpickett
ms.date: 09/18/2017
ms.topic: article
ms.technology: aspnet
ms.prod: asp.net-core
uid: security/authentication/identity-configuration
---
# Configure Identity

ASP.NET Core Identity has some default behaviors that you can override easily in your application's startup class.

## Passwords policy

By default, Identity requires that passwords contain an uppercase character, lowercase character, and digits. There are also some other restrictions. If you want to simplify password restrictions, you can do that in the startup class of your application.

[!code-csharp[Main](identity/sample/src/ASPET-IdentityDemo-PrimaryKeysConfig/Startup.cs?highlight=2&range=60-65)]

## Application's cookie settings

Like the passwords policy, all the settings of the application's cookie can be changed in the startup class.

[!code-csharp[Main](identity/sample/src/ASPET-IdentityDemo-PrimaryKeysConfig/Startup.cs?highlight=2&range=72-80)]

## User's lockout

[!code-csharp[Main](identity/sample/src/ASPET-IdentityDemo-PrimaryKeysConfig/Startup.cs?highlight=2&range=67-70)]
