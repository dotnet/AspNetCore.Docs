---
title: Configure Identity
uid: security/authentication/identity-configuration
---

# Configure Identity

ASP.NET Core Identity has some default behaviors that you can override easily in your application's `Startup` class.

## Passwords policy

By default, Identity requires that passwords contain an uppercase character, lowercase character, and digits. There are also some other restrictions. If you want to simplify password restrictions, you can do that in the `Startup` class of your application.

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

ASP.NET Core 2 added the `RequiredUniqueChars` options.  Otherwise, the options are the same from ASP.NET Core 1.x.

[!code-csharp[Main](identity/sample/src/ASPNETv2-IdentityDemo-Configuration/Startup.cs?name=snippet_identityoptions&highlight=4-9)]

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

[!code-csharp[Main](identity/sample/src/ASPET-IdentityDemo-PrimaryKeysConfig/Startup.cs?range=60-65)]

---


## User's lockout

[!code-csharp[Main](identity/sample/src/ASPNETv2-IdentityDemo-Configuration/Startup.cs?name=snippet_identityoptions&highlight=11-14)]


## Sign in settings

[!code-csharp[Main](identity/sample/src/ASPNETv2-IdentityDemo-Configuration/Startup.cs?name=snippet_identityoptions&highlight=16-18)]


## User validation settings

[!code-csharp[Main](identity/sample/src/ASPNETv2-IdentityDemo-Configuration/Startup.cs?name=snippet_identityoptions&highlight=20-21)]


## Application's cookie settings

Like the passwords policy, all the settings of the application's cookie can be changed in the `Startup` class.

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

Under `ConfigureServices` in the `Startup` class, you can configure the application's cookie.

[!code-csharp[Main](identity/sample/src/ASPNETv2-IdentityDemo-Configuration/Startup.cs?name=snippet_configurecookie)]

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

[!code-csharp[Main](identity/sample/src/ASPET-IdentityDemo-PrimaryKeysConfig/Startup.cs?highlight=2&range=72-80)]

--- 


