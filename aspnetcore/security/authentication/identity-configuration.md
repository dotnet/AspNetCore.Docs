---
title: Configure Identity | Microsoft Docs
uid: security/authentication/identity-configuration
---
# Configure Identity

ASP.NET Core Identity has some default behaviors that you can override easily in your application's startup class.

## Password's policy

By default, Identity requires very secure passwords who have to contains uppercase character, lowercase character, digits and some others restrictions that you sometimes need to simplify. It's very simple to do that, all the configuration is accessible in the startup class of your application.

[!code-csharp[Main](identity/sample/src/ASPET-IdentityDemo-PrimaryKeysConfig/Startup.cs?highlight=2&range=60-65)]

## Application's cookie settings

With the same philosophy of the password's policy, all the settings about the application's cookie can be change in the startup class.

[!code-csharp[Main](identity/sample/src/ASPET-IdentityDemo-PrimaryKeysConfig/Startup.cs?highlight=2&range=72-80)]

## User's lockout

[!code-csharp[Main](identity/sample/src/ASPET-IdentityDemo-PrimaryKeysConfig/Startup.cs?highlight=2&range=67-70)]