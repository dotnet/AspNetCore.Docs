---
title: Configure ASP.NET Core Identity
author: AdrienTorris
description: Understand the ASP.NET Core Identity default values, and configure the various Identity properties to use custom values.
keywords: ASP.NET Core,Identity,authentication,security
ms.author: scaddie
manager: wpickett
ms.date: 01/11/2018
ms.topic: article
ms.technology: aspnet
ms.prod: asp.net-core
uid: security/authentication/identity-configuration
---

# Configure Identity

ASP.NET Core Identity has common behaviors in applications such as password policy, lockout time, and cookie settings that you can override easily in your application's `Startup` class.

## Passwords policy

By default, Identity requires that passwords contain an uppercase character, lowercase character, a digit, and a non-alphanumeric character. There are also some other restrictions. To simplify password restrictions, modify the `ConfigureServices` method of the `Startup` class of your application.

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

ASP.NET Core 2.0 added the `RequiredUniqueChars` property. Otherwise, the options are the same from ASP.NET Core 1.x.

[!code-csharp[Main](identity/sample/src/ASPNETv2-IdentityDemo-Configuration/Startup.cs?range=29-37,50-52)]

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

[!code-csharp[Main](identity/sample/src/ASPNET-IdentityDemo-PrimaryKeysConfig/Startup.cs?range=58-65,84)]

---

`IdentityOptions.Password` has the following properties:

| Property                | Description                       | Default |
| ----------------------- | --------------------------------- | ------- |
| `RequireDigit`          | Requires a number between 0-9 in the password. | true |
| `RequiredLength`        | The minimum length of the password. | 6 |
| `RequireNonAlphanumeric`| Requires a non-alphanumeric character in the password. | true |
| `RequireUppercase`      | Requires an upper case character in the password. | true |
| `RequireLowercase`      | Requires a lower case character in the password. | true |
| `RequiredUniqueChars`   | Requires the number of distinct characters in the password. | 1 |


## User's lockout

[!code-csharp[Main](identity/sample/src/ASPNETv2-IdentityDemo-Configuration/Startup.cs?range=29-30,39-42,50-52)]

`IdentityOptions.Lockout` has the following properties:

| Property                | Description                       | Default |
| ----------------------- | --------------------------------- | ------- |
| `DefaultLockoutTimeSpan` | The amount of time a user is locked out when a lockout occurs.  | 5 minutes  |
| `MaxFailedAccessAttempts` | The number of failed access attempts until a user is locked out, if lockout is enabled.  | 5 |
| `AllowedForNewUsers` | Determines if a new user can be locked out.  | true |

## Sign in settings

[!code-csharp[Main](identity/sample/src/ASPNETv2-IdentityDemo-Configuration/Startup.cs?range=29-30,44-46,50-52)]

`IdentityOptions.SignIn` has the following properties:

| Property                | Description                       | Default |
| ----------------------- | --------------------------------- | ------- |
| `RequireConfirmedEmail` | Requires a confirmed email to sign in. | false  |
| `RequireConfirmedPhoneNumber` |  Requires a confirmed phone number to sign in. | false  |

## User validation settings

[!code-csharp[Main](identity/sample/src/ASPNETv2-IdentityDemo-Configuration/Startup.cs?range=29-30,48-52)]

`IdentityOptions.User` has the following properties:

| Property                | Description                       | Default |
| ----------------------- | --------------------------------- | ------- |
| `RequireUniqueEmail`  | Requires each User to have a unique email. | false  |
| `AllowedUserNameCharacters`  | Allowed characters in the username. | abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+ |


## Application's cookie settings

Like the passwords policy, all the settings of the application's cookie can be changed in the `Startup` class.

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

Under `ConfigureServices` in the `Startup` class, you can configure the application's cookie.

[!code-csharp[Main](identity/sample/src/ASPNETv2-IdentityDemo-Configuration/Startup.cs?name=snippet_configurecookie)]

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

[!code-csharp[Main](identity/sample/src/ASPNET-IdentityDemo-PrimaryKeysConfig/Startup.cs?range=58-59,72-80,84)]

---

`CookieAuthenticationOptions` has the following properties:

| Property                | Description                       | Default |
| ----------------------- | --------------------------------- | ------- |
| `Cookie.Name`  | The name of the cookie.  | .AspNetCore.Cookies.  |
| `Cookie.HttpOnly`  | When true, the cookie is not accessible from client-side scripts.  |  true |
| `ExpireTimeSpan`  | Controls how much time the authentication ticket stored in the cookie will remain valid from the point it is created.  | 14 days  |
| `LoginPath`  | When a user is unauthorized, they will be redirected to this path to login. | /Account/Login  |
| `LogoutPath`  | When a user is logged out, they will be redirected to this path.  | /Account/Logout  |
| `AccessDeniedPath`  | When a user fails an authorization check, they will be redirected to this path.  |   |
| `SlidingExpiration`  | When true, a new cookie will be issued with a new expiration time when the current cookie is more than halfway through the expiration window.  | /Account/AccessDenied |
| `ReturnUrlParameter`  | Determines the name of the query string parameter which is appended by the middleware when a 401 Unauthorized status code is changed to a 302 redirect onto the login path.  |  true |
| `AuthenticationScheme`  | This is only relevant for ASP.NET Core 1.x. The logical name for a particular authentication scheme. |  |
| `AutomaticAuthenticate`  | This flag is only relevant for ASP.NET Core 1.x. When true, cookie authentication should run on every request and attempt to validate and reconstruct any serialized principal it created.  |  |