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

ASP.NET Core Identity has some default behaviors that you can override easily in your application's `Startup` class.

## Passwords policy

By default, Identity requires that passwords contain an uppercase character, lowercase character, a digit, and a non-alphanumeric character. There are also some other restrictions. If you want to simplify password restrictions, you can do that in the `Startup` class of your application.

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

ASP.NET Core 2.0 added the `RequiredUniqueChars` property. Otherwise, the options are the same from ASP.NET Core 1.x.

[!code-csharp[Main](identity/sample/src/ASPNETv2-IdentityDemo-Configuration/Startup.cs?range=29-37,50-52)]

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

[!code-csharp[Main](identity/sample/src/ASPNET-IdentityDemo-PrimaryKeysConfig/Startup.cs?range=58-65,84)]

---

`IdentityOptions.Password` has the following properties:
* `RequireDigit`: Requires a number between 0-9 in the password. Defaults to true.
* `RequiredLength`: The minimum length of the password. Defaults to 6.
* `RequireNonAlphanumeric`: Requires a non-alphanumeric character in the password. Defaults to true.
* `RequireUppercase`: Requires an upper case character in the password. Defaults to true.
* `RequireLowercase`: Requires a lower case character in the password. Defaults to true.
* `RequiredUniqueChars`: Requires the number of distinct characters in the password. Defaults to 1.


## User's lockout

[!code-csharp[Main](identity/sample/src/ASPNETv2-IdentityDemo-Configuration/Startup.cs?range=29-30,39-42,50-52)]

`IdentityOptions.Lockout` has the following properties:
* `DefaultLockoutTimeSpan`: The amount of time a user is locked out when a lockout occurs. Defaults to 5 minutes.
* `MaxFailedAccessAttempts`: The number of failed access attempts until a user is locked out, if lockout is enabled. Defaults to 5.
* `AllowedForNewUsers`: Determines if a new user can be locked out. Defaults to true.


## Sign in settings

[!code-csharp[Main](identity/sample/src/ASPNETv2-IdentityDemo-Configuration/Startup.cs?range=29-30,44-46,50-52)]

`IdentityOptions.SignIn` has the following properties:
* `RequireConfirmedEmail`: Requires a confirmed email to sign in. Defaults to false.
* `RequireConfirmedPhoneNumber`: Requires a confirmed phone number to sign in. Defaults to false.


## User validation settings

[!code-csharp[Main](identity/sample/src/ASPNETv2-IdentityDemo-Configuration/Startup.cs?range=29-30,48-52)]

`IdentityOptions.User` has the following properties:
* `RequireUniqueEmail`: Requires each User to have a unique email. Defaults to false.
* `AllowedUserNameCharacters`: Allowed characters in the username. Defaults to abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+.

## Application's cookie settings

Like the passwords policy, all the settings of the application's cookie can be changed in the `Startup` class.

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

Under `ConfigureServices` in the `Startup` class, you can configure the application's cookie.

[!code-csharp[Main](identity/sample/src/ASPNETv2-IdentityDemo-Configuration/Startup.cs?name=snippet_configurecookie)]

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

[!code-csharp[Main](identity/sample/src/ASPNET-IdentityDemo-PrimaryKeysConfig/Startup.cs?range=58-59,72-80,84)]

--- 

`CookieAuthenticationOptions` has the following properties:
* `Cookie.Name`: The name of the cookie. Defaults to .AspNetCore.Cookies.
* `Cookie.HttpOnly`: When true, the cookie is not accessible from client-side scripts. Defaults to true.
* `ExpireTimeSpan`: Controls how much time the authentication ticket stored in the cookie will remain valid from the point it is created. Defaults to 14 days.
* `LoginPath`: When a user is unauthorized, they will be redirected to this path to login. Defaults to /Account/Login.
* `LogoutPath`: When a user is logged out, they will be redirected to this path. Defaults to /Account/Logout.
* `AccessDeniedPath`: When a user fails an authorization check, they will be redirected to this path. Defaults to /Account/AccessDenied.
* `SlidingExpiration`: When true, a new cookie will be issued with a new expiration time when the current cookie is more than halfway through the expiration window. Defaults to true.
* `ReturnUrlParameter`: The ReturnUrlParameter determines the name of the query string parameter which is appended by the middleware when a 401 Unauthorized status code is changed to a 302 redirect onto the login path.
* `AuthenticationScheme`: This is only relevant for ASP.NET Core 1.x. The logical name for a particular authentication scheme.
* `AutomaticAuthenticate`: This flag is only relevant for ASP.NET Core 1.x. When true, cookie authentication should run on every request and attempt to validate and reconstruct any serialized principal it created.

