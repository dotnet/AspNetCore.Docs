---
title: Limiting identity by scheme - ASP.NET Core
author: rick-anderson
description: This article explains how to limit identity to a specific schema when working with multiple authentication methods.
keywords: ASP.NET Core,identity,authentication scheme
ms.author: riande
manager: wpickett
ms.date: 10/10/2017
ms.topic: article
ms.assetid: d3d6ca1b-b4b5-4bf7-898e-dcd90ec1bf8c
ms.technology: aspnet
ms.prod: asp.net-core
uid: security/authorization/limitingidentitybyscheme
---
# Limiting identity by scheme

In some scenarios, such as Single Page Applications (SPAs), it's common to use multiple authentication methods. For example, the application may use cookie-based authentication to log in and JWT bearer authentication for JavaScript requests. In some cases, the app may have multiple instances of an authentication middleware. For example, two cookie middlewares where one contains a basic identity and one is created when a multi-factor authentication (MFA) has been triggered. MFA may be triggered because the user requested an operation that requires extra security.

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

An authentication scheme is named when the authentication service is configured during authentication. For example:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    // Code omitted for brevity

    services.AddAuthentication()
        .AddCookie(options => {
            options.LoginPath = "/Account/Unauthorized/";
            options.AccessDeniedPath = "/Account/Forbidden/";
        })
        .AddJwtBearer(options => {
            options.Audience = "http://localhost:5001/";
            options.Authority = "http://localhost:5000/";
        });
```

In the preceding code, two authentication services have been added: one for cookies and one for bearer.

>[!NOTE]
>When adding multiple authentication middlewares, ensure that no middleware is configured to run automatically. Invoking `AddAuthentication` with no arguments ensures that no middleware is configured to run automatically. If the app does **not** 
 invoke `AddAuthentication` with no arguments, filtering by scheme doesn't work. For example, calling
 `AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)` makes cookies run automatically.

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

Authentication schemes are named when authentication middlewares are configured during authentication. For example:

```csharp
public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
{
    // Code omitted for brevity

    app.UseCookieAuthentication(new CookieAuthenticationOptions()
    {
        AuthenticationScheme = "Cookie",
        LoginPath = "/Account/Unauthorized/",
        AccessDeniedPath = "/Account/Forbidden/",
        AutomaticAuthenticate = false
    });
    
    app.UseJwtBearerAuthentication(new JwtBearerOptions()
    {
        AuthenticationScheme = "Bearer",
        AutomaticAuthenticate = false,
        Audience = "http://localhost:5001/",
        Authority = "http://localhost:5000/"
    });
```

In the preceding code, two authentication middlewares have been added: one for cookies and one for bearer.

>[!NOTE]
>When adding multiple authentication middlewares, ensure that no middleware is configured to run automatically. An app ensures that no middleware is configured to run automatically by setting the `AuthenticationOptions.AutomaticAuthenticate` property to false. If the app fails to  set`AuthenticationOptions.AutomaticAuthenticate` to false, filtering by scheme doesn't work.

---

## Selecting the scheme with the Authorize attribute

At the point of authorization, the app indicates the middleware to be used. The simplest way to select the middleware with which the app will authorize:
<!-- I don't like single lists, but the sentence is too long for translation -- maybe there is a better way to split it up -->
*  Pass a comma-delimited list of authentication schemes to the `[Authorize]` attribute. 

The `[Authorize]` attribute specifies the authentication scheme or schemes to use regardless of whether a default is configured. For example:

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

```csharp
[Authorize(AuthenticationSchemes = "Cookie,Bearer")]
public class MixedController : Controller
```

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

```csharp
[Authorize(ActiveAuthenticationSchemes = "Cookie,Bearer")]
public class MixedController : Controller
```

---

In the preceding example, both the cookie and bearer middlewares run and have a chance to create and append an identity for the current user. By specifying a single scheme only, the specified middleware runs.

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

```csharp
[Authorize(AuthenticationSchemes = "Bearer")]
public class MixedController : Controller
```

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

```csharp
[Authorize(ActiveAuthenticationSchemes = "Bearer")]
public class MixedController : Controller
```

---

<!-- check my change -->
In the preceding code , only the middleware with the "Bearer" scheme runs. Any cookie-based identities are ignored.

## Selecting the scheme with policies

If you prefer to specify the desired schemes in [policy](xref:security/authorization/policies#security-authorization-policies-based), you can set the `AuthenticationSchemes` collection when adding your policy:

```csharp
services.AddAuthorization(options =>
{
    options.AddPolicy("Over18", policy =>
    {
        policy.AuthenticationSchemes.Add("Bearer");
        policy.RequireAuthenticatedUser();
        policy.Requirements.Add(new Over18Requirement());
    });
});
```

In the preceding  example, the "Over18" policy only runs against the identity created by the "Bearer" middleware.
