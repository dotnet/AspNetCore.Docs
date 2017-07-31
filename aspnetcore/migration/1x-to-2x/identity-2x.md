---
title: Migrating Auth and Identity to ASP.NET Core 2.0
author: scottaddie
description: This article outlines the most common steps for migrating ASP.NET Core 1.x authentication and Identity to ASP.NET Core 2.0.
keywords: ASP.NET Core,Identity,authentication
ms.author: scaddie
manager: wpickett
ms.date: 07/31/2017
ms.topic: article
ms.technology: aspnet
ms.prod: asp.net-core
uid: migration/identity-2x
---

# Migrating Authentication and Identity to ASP.NET Core 2.0

<a name="migration-identity"></a>

By [Scott Addie](https://github.com/scottaddie) and [Hao Kung](https://github.com/HaoK)

ASP.NET Core 2.0 has a new model for authentication and Identity that simplifies configuration by using services. ASP.NET Core 1.x applications that use authentication and Identity need to be updated to use the new model as outlined below.

<a name="auth-middleware"></a>

## Authentication Middleware and Services
In 1.x projects, authentication is configured via middleware. 2.x projects use services to configure authentication.

When using ASP.NET Core Identity for cookie-based authentication in 2.x, the `AddIdentity` extension method adds cookie authentication services which are detected by the middleware:

[!code-csharp[Main](../1x-to-2x/samples/AspNetCoreDotNetCore2.0App/AspNetCoreDotNetCore2.0App/Startup.cs?range=46-48)]

In 1.x, a middleware method was invoked for each authentication scheme you wanted to support. For example, invoking the `UseCookieAuthentication` or `UseFacebookAuthentication` methods in the `Configure` method of *Startup.cs* would have enabled cookie-based authentication or Facebook authentication, respectively:

```csharp
public void Configure(IApplicationBuilder app, ILoggerFactory loggerfactory) {
    app.UseIdentity();
    app.UseCookieAuthentication(new CookieAuthenticationOptions
       { LoginPath = new PathString("/login") });
    app.UseFacebookAuthentication(new FacebookOptions
       { AppId = Configuration["facebook:appid"],  AppSecret = Configuration["facebook:appsecret"] });
} 
```

In 2.x, each authentication scheme is registered in the `ConfigureServices` method of *Startup.cs*. The `UseIdentity` method is replaced with `UseAuthentication`:

```csharp
public void ConfigureServices(IServiceCollection services) {
    services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores();
    services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(o => o.LoginPath = new PathString("/login"))
                .AddFacebook(o =>
                {
                    o.AppId = Configuration["facebook:appid"];
                    o.AppSecret = Configuration["facebook:appsecret"];
                });
}

public void Configure(IApplicationBuilder app, ILoggerFactory loggerfactory) {
    app.UseAuthentication();
}
```

The `UseAuthentication` method discovers the services being used, from [dependency injection](xref:fundamentals/dependency-injection), to determine the authentication schemes you want to use.

<a name="obsolete-interface"></a>

## Use HttpContext Authentication Extensions
The `IAuthenticationManager` interface was the main entry point into the 1.x authentication system. It has been replaced with a new set of `HttpContext` extension methods in the `Microsoft.AspNetCore.Authentication` namespace.

For example, 1.x projects reference an `Authentication` property:

[!code-csharp[Main](../1x-to-2x/samples/AspNetCoreDotNetCore1.1App/AspNetCoreDotNetCore1.1App/Controllers/AccountController.cs?name=snippet_AuthenticationProperty)]

In 2.0 projects, import the `Microsoft.AspNetCore.Authentication` namespace, and delete the `Authentication` property references:

[!code-csharp[Main](../1x-to-2x/samples/AspNetCoreDotNetCore2.0App/AspNetCoreDotNetCore2.0App/Controllers/AccountController.cs?name=snippet_AuthenticationProperty)]

<a name="identity-cookie-options"></a>

## IdentityCookieOptions Instances
A side effect of the 2.0 changes is the switch to using named options instead of cookie options instances. The ability to customize the Identity cookie scheme names is removed.

For example, 1.x projects use [constructor injection](xref:mvc/controllers/dependency-injection#constructor-injection) to pass an `IdentityCookieOptions` parameter into *AccountController.cs*. The external cookie authentication scheme is accessed from the provided instance:

[!code-csharp[Main](../1x-to-2x/samples/AspNetCoreDotNetCore1.1App/AspNetCoreDotNetCore1.1App/Controllers/AccountController.cs?name=snippet_AccountControllerConstructor&highlight=4,11)]

The constructor injection becomes unnecessary in 2.0 projects, and the `_externalCookieScheme` field can be deleted:

[!code-csharp[Main](../1x-to-2x/samples/AspNetCoreDotNetCore2.0App/AspNetCoreDotNetCore2.0App/Controllers/AccountController.cs?name=snippet_AccountControllerConstructor)]

The `IdentityConstants.ExternalScheme` constant can be used directly:

[!code-csharp[Main](../1x-to-2x/samples/AspNetCoreDotNetCore2.0App/AspNetCoreDotNetCore2.0App/Controllers/AccountController.cs?name=snippet_AuthenticationProperty)]

<a name="navigation-properties"></a>

## IdentityUser POCO Navigation Properties
The Entity Framework Core navigation properties of the base `IdentityUser` POCO (Plain Old CLR Object) have been removed. If the 1.x project used these properties, manually add them back to the 2.0 project:

```csharp
/// <summary>
/// Navigation property for the roles this user belongs to.
/// </summary>
public virtual ICollection<TUserRole> Roles { get; } = new List<TUserRole>();

/// <summary>
/// Navigation property for the claims this user possesses.
/// </summary>
public virtual ICollection<TUserClaim> Claims { get; } = new List<TUserClaim>();

/// <summary>
/// Navigation property for this users login accounts.
/// </summary>
public virtual ICollection<TUserLogin> Logins { get; } = new List<TUserLogin>();
```

<a name="synchronous-method-removal"></a>

## Removal of GetExternalAuthenticationSchemes
The synchronous method `GetExternalAuthenticationSchemes` was removed in favor of an asynchronous version. 1.x projects have the following code in *ManageController.cs*:

[!code-csharp[Main](../1x-to-2x/samples/AspNetCoreDotNetCore1.1App/AspNetCoreDotNetCore1.1App/Controllers/ManageController.cs?name=snippet_GetExternalAuthenticationSchemes)]

This method appears in *Login.cshtml* too:

[!code-cshtml[Main](../1x-to-2x/samples/AspNetCoreDotNetCore1.1App/AspNetCoreDotNetCore1.1App/Views/Account/Login.cshtml?range=62,75-84)]

In 2.0 projects, use the `GetExternalAuthenticationSchemesAsync` method:

[!code-csharp[Main](../1x-to-2x/samples/AspNetCoreDotNetCore2.0App/AspNetCoreDotNetCore2.0App/Controllers/ManageController.cs?name=snippet_GetExternalAuthenticationSchemesAsync)]

In *Login.cshtml*, the `AuthenticationScheme` property accessed in the `foreach` loop changes to `Name`:

[!code-cshtml[Main](../1x-to-2x/samples/AspNetCoreDotNetCore2.0App/AspNetCoreDotNetCore2.0App/Views/Account/Login.cshtml?range=62,75-84)]

<a name="property-change"></a>

## ManageLoginsViewModel Property Change
A `ManageLoginsViewModel` object is used in the `ManageLogins` action of *ManageController.cs*. In 1.x projects, the object's `OtherLogins` property return type is `IList<AuthenticationDescription>`. This return type requires an import of `Microsoft.AspNetCore.Http.Authentication`:

[!code-csharp[Main](../1x-to-2x/samples/AspNetCoreDotNetCore1.1App/AspNetCoreDotNetCore1.1App/Models/ManageViewModels/ManageLoginsViewModel.cs?name=snippet_ManageLoginsViewModel&highlight=2,11)]

In 2.0 projects, the return type changes to `IList<AuthenticationScheme>`. This new return type requires replacing the `Microsoft.AspNetCore.Http.Authentication` import with a `Microsoft.AspNetCore.Authentication` import.

[!code-csharp[Main](../1x-to-2x/samples/AspNetCoreDotNetCore2.0App/AspNetCoreDotNetCore2.0App/Models/ManageViewModels/ManageLoginsViewModel.cs?name=snippet_ManageLoginsViewModel&highlight=2,11)]