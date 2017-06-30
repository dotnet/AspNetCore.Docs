---
title: Configure Identity
uid: security/authentication/identity-configuration
---
# Configure Identity

ASP.NET Core Identity has some default behaviors that you can override easily in your application's startup class.

## Passwords policy

By default, Identity requires very secure passwords who have to contain an uppercase character, lowercase character, digits and some other restrictions that you sometimes need to simplify. It's very simple to do that, all the configuration is accessible in the startup class of your application.

[!code-csharp[Main](identity/sample/src/ASPET-IdentityDemo-PrimaryKeysConfig/Startup.cs?highlight=2&range=60-65)]

## Application's cookie settings

With the same philosophy of the passwords policy, all the settings about the application's cookie can be changed in the startup class.

[!code-csharp[Main](identity/sample/src/ASPET-IdentityDemo-PrimaryKeysConfig/Startup.cs?highlight=2&range=72-80)]

## User's lockout

[!code-csharp[Main](identity/sample/src/ASPET-IdentityDemo-PrimaryKeysConfig/Startup.cs?highlight=2&range=67-70)]
