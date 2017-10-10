---
title: Limiting identity by scheme
author: rick-anderson
description: 
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

<a name=security-authorization-limiting-by-scheme></a>

In some scenarios, such as Single Page Applications, it's common to use multiple authentication methods. For example, your application may use cookie-based authentication to log in and JWT bearer authentication for JavaScript requests. In some cases, you may have multiple instances of an authentication middleware. For example, two cookie middlewares where one contains a basic identity and one is created when a multi-factor authentication has triggered (because the user requested an operation that requires extra security).

Authentication schemes are named when authentication middlewares or services are configured during authentication. For example:

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

```csharp
public void ConfigureServices(IServiceCollection services)
{
    // Code omitted for brevity

    services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options => {
            options.LoginPath = "/Account/Unauthorized/";
            options.AccessDeniedPath = "/Account/Forbidden/";
        })
        .AddJwtBearer();
```

In the preceding code, two authentication services have been added: one for cookies and one for bearer.

>[!NOTE]
>When adding multiple authentication middlewares, ensure that no middleware is configured to run automatically. You do this by setting the `AuthenticationOptions.AutomaticAuthenticate` property to false. If you fail to do this, filtering by scheme will not work.

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

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
        AutomaticAuthenticate = false
    });
```

In the preceding code, two authentication middlewares have been added: one for cookies and one for bearer.

>[!NOTE]
>When adding multiple authentication middlewares, ensure that no middleware is configured to run automatically. You do this by setting the `AuthenticationOptions.AutomaticAuthenticate` property to false. If you fail to do this, filtering by scheme will not work.

---

## Selecting the scheme with the Authorize attribute

No authentication middleware is configured to automatically run and create an identity. At the point of authorization, you choose which middleware will be used. The simplest way to select the middleware with which you wish to authorize is to use the `ActiveAuthenticationSchemes` property. This property accepts a comma-delimited list of authentication schemes to use. For example:

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

In the example above, both the cookie and bearer middlewares run and have a chance to create and append an identity for the current user. By specifying a single scheme only, the specified middleware runs.

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

```csharp
[Authorize(AuthenticationSchemes = "Bearer")]
```

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

```csharp
[Authorize(ActiveAuthenticationSchemes = "Bearer")]
```

---

In this case, only the middleware with the "Bearer" scheme runs. Any cookie-based identities are ignored.

## Selecting the scheme with policies

If you prefer to specify the desired schemes in [policy](policies.md#security-authorization-policies-based), you can set the `AuthenticationSchemes` collection when adding your policy:

```csharp
options.AddPolicy("Over18", policy =>
{
    policy.AuthenticationSchemes.Add("Bearer");
    policy.RequireAuthenticatedUser();
    policy.Requirements.Add(new Over18Requirement());
});
```

In this example, the "Over18" policy only runs against the identity created by the "Bearer" middleware.
