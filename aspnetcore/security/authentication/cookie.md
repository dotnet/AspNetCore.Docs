---
title: Using Cookie Authentication without ASP.NET Core Identity
author: rick-anderson
description: An explanation of using cookie authentication without ASP.NET Core Identity
keywords: ASP.NET Core,cookies
ms.author: riande
manager: wpickett
ms.date: 08/14/2017
ms.topic: article
ms.assetid: 2bdcbf95-8d9d-4537-a4a0-a5ee439dcb62
ms.technology: aspnet
ms.prod: asp.net-core
uid: security/authentication/cookie
---
# Using Cookie Authentication without ASP.NET Core Identity

<a name="security-authentication-cookie-middleware"></a>

ASP.NET Core 1.x provides cookie [middleware](../../fundamentals/middleware.md#fundamentals-middleware) which serializes a user principal into an encrypted cookie and then, on subsequent requests, validates the cookie, recreates the principal, and assigns it to the `HttpContext.User` property. If you want to provide your own login screens and user databases, you can use the cookie middleware as a standalone feature.

A major change in ASP.NET Core 2.x is that the cookie middleware is absent. Instead, the `UseAuthentication` method invocation in the `Configure` method of *Startup.cs* adds the AuthenticationMiddleware which sets the `HttpContext.User` property.

<a name="security-authentication-cookie-middleware-configuring"></a>

## Adding and configuring

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

Complete the following steps:

- If not using the `Microsoft.AspNetCore.All` [metapackage](xref:fundamentals/metapackage), install version 2.0+ of the `Microsoft.AspNetCore.Authentication.Cookies` NuGet package in your project.

- Invoke the `UseAuthentication` method in the `Configure` method of the *Startup.cs* file:

    ```csharp
    app.UseAuthentication();
    ```

- Invoke the `AddAuthentication` and `AddCookie` methods in the `ConfigureServices` method of the *Startup.cs* file:

    ```csharp
    services.AddAuthentication("MyCookieAuthenticationScheme")
            .AddCookie(options => {
                options.AccessDeniedPath = "/Account/Forbidden/";
                options.LoginPath = "/Account/Unauthorized/";
            });
    ```

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

Complete the following steps:

- Install the `Microsoft.AspNetCore.Authentication.Cookies` NuGet package in your project. This package contains the cookie middleware.

- Add the following lines to the `Configure` method in your *Startup.cs* file before the `app.UseMvc()` statement:

    ```csharp
    app.UseCookieAuthentication(new CookieAuthenticationOptions()
    {
        AccessDeniedPath = "/Account/Forbidden/",
        AuthenticationScheme = "MyCookieAuthenticationScheme",
        AutomaticAuthenticate = true,
        AutomaticChallenge = true,
        LoginPath = "/Account/Unauthorized/"
    });
    ```

---

The code snippets above configure some or all of the following options:

* `AccessDeniedPath` - This is the relative path to which requests redirect when a user attempts to access a resource but does not pass any [authorization policies](xref:security/authorization/policies#security-authorization-policies-based) for that resource.

* `AuthenticationScheme` - This is a value by which a particular cookie authentication scheme is known. This is useful when there are multiple instances of cookie authentication and you want to [limit authorization to one instance](xref:security/authorization/limitingidentitybyscheme#security-authorization-limiting-by-scheme).

* `AutomaticAuthenticate` - This flag is relevant only for ASP.NET Core 1.x. It indicates that the cookie authentication should run on every request and attempt to validate and reconstruct any serialized principal it created.

* `AutomaticChallenge` - This flag is relevant only for ASP.NET Core 1.x. It indicates that the 1.x cookie authentication should redirect the browser to the `LoginPath` or `AccessDeniedPath` when authorization fails.

* `LoginPath` - This is the relative path to which requests redirect when a user attempts to access a resource but has not been authenticated.

[Other options](xref:security/authentication/cookie#security-authentication-cookie-options) include the ability to set the issuer for any claims the cookie authentication creates, the name of the cookie the authentication drops, the domain for the cookie and various security properties on the cookie. By default, the cookie authentication uses appropriate security options for any cookies it creates, such as:
- Setting the HttpOnly flag to prevent cookie access in client-side JavaScript
- Limiting the cookie to HTTPS if a request has traveled over HTTPS

<a name="security-authentication-cookie-middleware-creating-a-cookie"></a>

## Creating an Identity cookie

To create a cookie holding your user information, you must construct a [ClaimsPrincipal](https://docs.microsoft.com/dotnet/api/system.security.claims.claimsprincipal) holding the information you wish to be serialized in the cookie. Once you have a suitable `ClaimsPrincipal` object, call the following inside your controller method:

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

```csharp
await HttpContext.SignInAsync("MyCookieAuthenticationScheme", principal);
```

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

```csharp
await HttpContext.Authentication.SignInAsync("MyCookieAuthenticationScheme", principal);
```

---

This creates an encrypted cookie and adds it to the current response. The `AuthenticationScheme` specified during [configuration](xref:security/authentication/cookie#security-authentication-cookie-middleware-configuring) must be used when calling `SignInAsync`.

Under the covers, the encryption used is ASP.NET Core's [Data Protection](xref:security/data-protection/using-data-protection#security-data-protection-getting-started) system. If you are hosting on multiple machines, load balancing, or using a web farm, then you need to [configure data protection](xref:security/data-protection/configuration/overview#data-protection-configuring) to use the same key ring and application identifier.

## Signing out

To sign out the current user and delete their cookie, call the following inside your controller:

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

```csharp
await HttpContext.SignOutAsync("MyCookieAuthenticationScheme");
```

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

```csharp
await HttpContext.Authentication.SignOutAsync("MyCookieAuthenticationScheme");
```

---

## Reacting to back-end changes

>[!WARNING]
> Once a principal cookie has been created, it becomes the single source of identity. Even if you disable a user in your back-end systems, the cookie authentication has no knowledge of this, and a user stays logged in as long as their cookie is valid.

The cookie authentication provides a series of events in its option class. The `ValidateAsync()` event can be used to intercept and override validation of the cookie identity.

Consider a back-end user database that may have a "LastChanged" column. In order to invalidate a cookie when the database changes, you should first, when [creating the cookie](xref:security/authentication/cookie#security-authentication-cookie-middleware-creating-a-cookie), add a "LastChanged" claim containing the current value. When the database changes, the "LastChanged" value should be updated.

To implement an override for the `ValidateAsync()` event, you must write a method with the following signature:

```csharp
Task ValidateAsync(CookieValidatePrincipalContext context);
```

ASP.NET Core Identity implements this check as part of its `SecurityStampValidator`. An example looks like the following:

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

```csharp
public static class LastChangedValidator
{
    public static async Task ValidateAsync(CookieValidatePrincipalContext context)
    {
        // Pull database from registered DI services.
        var userRepository = context.HttpContext.RequestServices.GetRequiredService<IUserRepository>();
        var userPrincipal = context.Principal;

        // Look for the last changed claim.
        string lastChanged;
        lastChanged = (from c in userPrincipal.Claims
                        where c.Type == "LastUpdated"
                        select c.Value).FirstOrDefault();

        if (string.IsNullOrEmpty(lastChanged) ||
            !userRepository.ValidateLastChanged(userPrincipal, lastChanged))
        {
            context.RejectPrincipal();
            await context.HttpContext.SignOutAsync("MyCookieAuthenticationScheme");
        }
    }
}
```

This would then be wired up during cookie service registration in the `ConfigureServices` method of *Startup.cs*:

```csharp
services.AddAuthentication("MyCookieAuthenticationScheme")
        .AddCookie(options =>
        {
            options.Events = new CookieAuthenticationEvents
            {
                OnValidatePrincipal = LastChangedValidator.ValidateAsync
            };
        });
```

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

```csharp
public static class LastChangedValidator
{
    public static async Task ValidateAsync(CookieValidatePrincipalContext context)
    {
        // Pull database from registered DI services.
        var userRepository = context.HttpContext.RequestServices.GetRequiredService<IUserRepository>();
        var userPrincipal = context.Principal;

        // Look for the last changed claim.
        string lastChanged;
        lastChanged = (from c in userPrincipal.Claims
                        where c.Type == "LastUpdated"
                        select c.Value).FirstOrDefault();

        if (string.IsNullOrEmpty(lastChanged) ||
            !userRepository.ValidateLastChanged(userPrincipal, lastChanged))
        {
            context.RejectPrincipal();
            await context.HttpContext.Authentication.SignOutAsync("MyCookieAuthenticationScheme");
        }
    }
}
```

This would then be wired up during cookie authentication configuration in the `Configure` method of *Startup.cs*:

```csharp
app.UseCookieAuthentication(new CookieAuthenticationOptions
{
    Events = new CookieAuthenticationEvents
    {
        OnValidatePrincipal = LastChangedValidator.ValidateAsync
    }
});
```

---

Consider the example in which their name has been updated &mdash; a decision which doesn't affect security in any way. If you want to non-destructively update the user principal, you can call `context.ReplacePrincipal()` and set the `context.ShouldRenew` property to `true`.

<a name="security-authentication-cookie-options"></a>

## Controlling cookie options

The [CookieAuthenticationOptions](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.builder.cookieauthenticationoptions) class comes with various configuration options to fine-tune the cookies being created.

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

ASP.NET Core 2.x unifies the APIs used for configuring cookies. The 1.x APIs have been marked as obsolete, and a new `Cookie` property of type `CookieBuilder` has been introduced in the `CookieAuthenticationOptions` class. It's recommended that you migrate to the 2.x APIs.

* `ClaimsIssuer` is the issuer to be used for the [Issuer](https://docs.microsoft.com/dotnet/api/system.security.claims.claim.issuer) property on any claims created by the cookie authentication.

* `CookieBuilder.Domain` is the domain name to which the cookie is served. By default, this is the host name the request was sent to. The browser only serves the cookie to a matching host name. You may wish to adjust this to have cookies available to any host in your domain. For example, setting the cookie domain to `.contoso.com` makes it available to `contoso.com`, `www.contoso.com`, `staging.www.contoso.com`, etc.

* `CookieBuilder.HttpOnly` is a flag indicating if the cookie should be accessible only to servers. This defaults to `true`. Changing this value may open your application to cookie theft should your application have a Cross-Site Scripting bug.

* `CookieBuilder.Path` can be used to isolate applications running on the same host name. If you have an app running in `/app1` and want to limit the cookies issued to just be sent to that application, then you should set the `CookiePath` property to `/app1`. By doing so, the cookie is only available to requests to `/app1` or anything underneath it.

* `CookieBuilder.SameSite` indicates whether the browser should allow the cookie to be attached to same-site or cross-site requests. This defaults to `SameSiteMode.Lax`.

* `CookieBuilder.SecurePolicy` is a flag indicating if the cookie created should be limited to HTTPS, HTTP or HTTPS, or the same protocol as the request. This defaults to `SameAsRequest`.

* `ExpireTimeSpan` is the `TimeSpan` after which the cookie expires. It's added to the current date and time to create the expiry date for the cookie.

* `SlidingExpiration` is a flag indicating whether the cookie expiration date resets when more than half of the `ExpireTimeSpan` interval has passed. The new expiry date is moved forward to be the current date plus the `ExpireTimespan`. An [absolute expiry time](xref:security/authentication/cookie#security-authentication-absolute-expiry) can be set by using the `AuthenticationProperties` class when calling `SignInAsync`. An absolute expiry can improve the security of your application by limiting the amount of time for which the authentication cookie is valid.

An example of using `CookieAuthenticationOptions` in the `ConfigureServices` method of *Startup.cs* follows:

```csharp
services.AddAuthentication()
        .AddCookie(options =>
        {
            options.Cookie.Name = "AuthCookie";
            options.Cookie.Domain = "contoso.com";
            options.Cookie.Path = "/";
            options.Cookie.HttpOnly = true;
            options.Cookie.SameSite = SameSiteMode.Lax;
            options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        });
```

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

* `ClaimsIssuer` is the issuer to be used for the [Issuer](https://docs.microsoft.com/dotnet/api/system.security.claims.claim.issuer) property on any claims created by the middleware.

* `CookieDomain` is the domain name to which the cookie is served. By default, this is the host name the request was sent to. The browser only serves the cookie to a matching host name. You may wish to adjust this to have cookies available to any host in your domain. For example, setting the cookie domain to `.contoso.com` makes it available to `contoso.com`, `www.contoso.com`, `staging.www.contoso.com`, etc.

* `CookieHttpOnly` is a flag indicating if the cookie should be accessible only to servers. This defaults to `true`. Changing this value may open your application to cookie theft should your application have a Cross-Site Scripting bug.

* `CookiePath` can be used to isolate applications running on the same host name. If you have an app running in `/app1` and want to limit the cookies issued to just be sent to that application, then you should set the `CookiePath` property to `/app1`. By doing so, the cookie is only available to requests to `/app1` or anything underneath it.

* `CookieSecure` is a flag indicating if the cookie created should be limited to HTTPS, HTTP or HTTPS, or the same protocol as the request. This defaults to `SameAsRequest`.

* `ExpireTimeSpan` is the `TimeSpan` after which the cookie expires. It's added to the current date and time to create the expiry date for the cookie.

* `SlidingExpiration` is a flag indicating whether the cookie expiration date resets when more than half of the `ExpireTimeSpan` interval has passed. The new expiry date is moved forward to be the current date plus the `ExpireTimespan`. An [absolute expiry time](xref:security/authentication/cookie#security-authentication-absolute-expiry) can be set by using the `AuthenticationProperties` class when calling `SignInAsync`. An absolute expiry can improve the security of your application by limiting the amount of time for which the authentication cookie is valid.

An example of using `CookieAuthenticationOptions` in the `Configure` method of *Startup.cs* follows:

```csharp
app.UseCookieAuthentication(new CookieAuthenticationOptions
{
    CookieName = "AuthCookie",
    CookieDomain = "contoso.com",
    CookiePath = "/",
    CookieHttpOnly = true,
    CookieSecure = CookieSecurePolicy.Always
});
```

---

## Persistent cookies and absolute expiry times

You may want the cookie expiry to persist across browser sessions and want an absolute expiry to the identity and the cookie transporting it. This persistence should only be enabled with explicit user consent, via a "Remember Me" checkbox on login or a similar mechanism. You can do these things by using the `AuthenticationProperties` parameter on the `SignInAsync` method called when [signing in an identity and creating the cookie](xref:security/authentication/cookie#security-authentication-cookie-middleware-creating-a-cookie). For example:

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

```csharp
await HttpContext.SignInAsync(
    "MyCookieAuthenticationScheme",
    principal,
    new AuthenticationProperties
    {
        IsPersistent = true
    });
```

The `AuthenticationProperties` class, used in the preceding code snippet, resides in the `Microsoft.AspNetCore.Authentication` namespace.

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

```csharp
await HttpContext.Authentication.SignInAsync(
    "MyCookieAuthenticationScheme",
    principal,
    new AuthenticationProperties
    {
        IsPersistent = true
    });
```

The `AuthenticationProperties` class, used in the preceding code snippet, resides in the `Microsoft.AspNetCore.Http.Authentication` namespace.

---

The preceding code snippet creates an identity and corresponding cookie which survives through browser closures. Any sliding expiration settings previously configured via [cookie options](xref:security/authentication/cookie#security-authentication-cookie-options) are still honored. If the cookie expires whilst the browser is closed, the browser clears it once it is restarted.

<a name="security-authentication-absolute-expiry"></a>

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

```csharp
await HttpContext.SignInAsync(
    "MyCookieAuthenticationScheme",
    principal,
    new AuthenticationProperties
    {
        ExpiresUtc = DateTime.UtcNow.AddMinutes(20)
    });
```

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

```csharp
await HttpContext.Authentication.SignInAsync(
    "MyCookieAuthenticationScheme",
    principal,
    new AuthenticationProperties
    {
        ExpiresUtc = DateTime.UtcNow.AddMinutes(20)
    });
```

---

The preceding code snippet creates an identity and corresponding cookie which lasts for 20 minutes. This ignores any sliding expiration settings previously configured via [cookie options](xref:security/authentication/cookie#security-authentication-cookie-options).

The `ExpiresUtc` and `IsPersistent` properties are mutually exclusive.