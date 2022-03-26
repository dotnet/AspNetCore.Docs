---
title: Authorize with a specific scheme in ASP.NET Core
author: rick-anderson
description: This article explains how to limit identity to a specific scheme when working with multiple authentication methods.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.date: 1/11/2022
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: security/authorization/limitingidentitybyscheme
---
# Authorize with a specific scheme in ASP.NET Core

:::moniker range=">= aspnetcore-6.0"

For an introduction to authentication schemes in ASP.NET Core, see [Authentication scheme](xref:security/authentication/index#authentication-scheme).

In some scenarios, such as Single Page Applications (SPAs), it's common to use multiple authentication methods. For example, the app may use cookie-based authentication to log in and JWT bearer authentication for JavaScript requests. In some cases, the app may have multiple instances of an authentication handler. For example, two cookie handlers where one contains a basic identity and one is created when a multi-factor authentication (MFA) has been triggered. MFA may be triggered because the user requested an operation that requires extra security. For more information on enforcing MFA when a user requests a resource that requires MFA, see the GitHub issue [Protect section with MFA](https://github.com/dotnet/AspNetCore.Docs/issues/15791#issuecomment-580464195).

An authentication scheme is named when the authentication service is configured during authentication. For example:

[!code-csharp[](~/security/authorization/limitingidentitybyscheme/samples/AuthScheme/Program.cs?name=snippet&highlight=5-15)]

In the preceding code, two authentication handlers have been added: one for cookies and one for bearer.

>[!NOTE]
>Specifying the default scheme results in the `HttpContext.User` property being set to that identity. If that behavior isn't desired, disable it by invoking the parameterless form of `AddAuthentication`.

## Selecting the scheme with the Authorize attribute

At the point of authorization, the app indicates the handler to be used. Select the handler with which the app will authorize by passing a comma-delimited list of authentication schemes to `[Authorize]`. The [`[Authorize]`](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) attribute specifies the authentication scheme or schemes to use regardless of whether a default is configured. For example:

[!code-csharp[](~/security/authorization/limitingidentitybyscheme/samples/AuthScheme/Controllers/MixedController.cs?name=snippet&highlight=8,11-13)]

In the preceding example, both the cookie and bearer handlers run and have a chance to create and append an identity for the current user. By specifying a single scheme only, the corresponding handler runs:

[!code-csharp[](~/security/authorization/limitingidentitybyscheme/samples/AuthScheme/Controllers/MixedController.cs?name=snippet2&highlight=1)]

In the preceding code, only the handler with the "Bearer" scheme runs. Any cookie-based identities are ignored.

## Selecting the scheme with policies

If you prefer to specify the desired schemes in [policy](xref:security/authorization/policies), you can set the <xref:Microsoft.Net.Http.Server.AuthenticationSchemes> collection when adding a policy:

[!code-csharp[](~/security/authorization/limitingidentitybyscheme/samples/AuthScheme/Program.cs?name=snippet2&highlight=6-15)]

In the preceding example, the "Over18" policy only runs against the identity created by the "Bearer" handler. Use the policy by setting the `[Authorize]` attribute's `Policy` property:

[!code-csharp[](~/security/authorization/limitingidentitybyscheme/samples/AuthScheme/Controllers/RegistrationController.cs?name=snippet&highlight=5)]

## Use multiple authentication schemes

Some apps may need to support multiple types of authentication. For example, your app might authenticate users from Azure Active Directory and from a users database. Another example is an app that authenticates users from both Active Directory Federation Services and Azure Active Directory B2C. In this case, the app should accept a JWT bearer token from several issuers.

Add all authentication schemes you'd like to accept. For example, the following code adds two JWT bearer authentication schemes with different issuers:

[!code-csharp[](~/security/authorization/limitingidentitybyscheme/samples/AuthScheme/Program.cs?name=snippet_ma&highlight=7-18)]

> [!NOTE]
> Only one JWT bearer authentication is registered with the default authentication scheme `JwtBearerDefaults.AuthenticationScheme`. Additional authentication has to be registered with a unique authentication scheme.

Update the default authorization policy to accept both authentication schemes. For example:

[!code-csharp[](~/security/authorization/limitingidentitybyscheme/samples/AuthScheme/Program.cs?name=snippet_ma&highlight=20-29)]

As the default authorization policy is overridden, it's possible to use the `[Authorize]` attribute in controllers. The controller then accepts requests with JWT issued by the first or second issuer.

See [this GitHub issue](https://github.com/dotnet/aspnetcore/issues/26002) on using multiple authentication schemes.

The following example uses [Azure Active Directory B2C](/azure/active-directory-b2c/overview) and another [Azure Active Directory](/azure/active-directory/authentication/overview-authentication) tenant:

[!code-csharp[](~/security/authorization/limitingidentitybyscheme/samples/AuthScheme/Program.cs?name=snippet_ma2&highlight=9-49)]

In the preceding code, <xref:Microsoft.AspNetCore.Authentication.AuthenticationSchemeOptions.ForwardDefaultSelector> is used to select a default scheme for the current request that authentication handlers should forward all authentication operations to by default. The default forwarding logic checks the most specific <xref:Microsoft.AspNetCore.Authentication.AuthenticationSchemeOptions.ForwardAuthenticate>, <xref:Microsoft.AspNetCore.Authentication.AuthenticationSchemeOptions.ForwardChallenge>, <xref:Microsoft.AspNetCore.Authentication.AuthenticationSchemeOptions.ForwardForbid>, <xref:Microsoft.AspNetCore.Authentication.AuthenticationSchemeOptions.ForwardSignIn>, and <xref:Microsoft.AspNetCore.Authentication.AuthenticationSchemeOptions.ForwardSignOut> setting first, followed by checking the <xref:Microsoft.AspNetCore.Authentication.AuthenticationSchemeOptions.ForwardDefaultSelector>, followed by <xref:Microsoft.AspNetCore.Authentication.AuthenticationSchemeOptions.ForwardDefault>. The first non null result is used as the target scheme to forward to. For more information, see <xref:security/authentication/policyschemes>.

:::moniker-end

:::moniker range="< aspnetcore-6.0"

For an introduction to authentication schemes in ASP.NET Core, see [Authentication scheme](xref:security/authentication/index#authentication-scheme).

In some scenarios, such as Single Page Applications (SPAs), it's common to use multiple authentication methods. For example, the app may use cookie-based authentication to log in and JWT bearer authentication for JavaScript requests. In some cases, the app may have multiple instances of an authentication handler. For example, two cookie handlers where one contains a basic identity and one is created when a multi-factor authentication (MFA) has been triggered. MFA may be triggered because the user requested an operation that requires extra security. For more information on enforcing MFA when a user requests a resource that requires MFA, see the GitHub issue [Protect section with MFA](https://github.com/dotnet/AspNetCore.Docs/issues/15791#issuecomment-580464195).

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

In the preceding code, two authentication handlers have been added: one for cookies and one for bearer.

>[!NOTE]
>Specifying the default scheme results in the `HttpContext.User` property being set to that identity. If that behavior isn't desired, disable it by invoking the parameterless form of `AddAuthentication`.

## Selecting the scheme with the Authorize attribute

At the point of authorization, the app indicates the handler to be used. Select the handler with which the app will authorize by passing a comma-delimited list of authentication schemes to `[Authorize]`. The `[Authorize]` attribute specifies the authentication scheme or schemes to use regardless of whether a default is configured. For example:

```csharp
[Authorize(AuthenticationSchemes = AuthSchemes)]
public class MixedController : Controller
    // Requires the following imports:
    // using Microsoft.AspNetCore.Authentication.Cookies;
    // using Microsoft.AspNetCore.Authentication.JwtBearer;
    private const string AuthSchemes =
        CookieAuthenticationDefaults.AuthenticationScheme + "," +
        JwtBearerDefaults.AuthenticationScheme;
```

In the preceding example, both the cookie and bearer handlers run and have a chance to create and append an identity for the current user. By specifying a single scheme only, the corresponding handler runs.

```csharp
[Authorize(AuthenticationSchemes = 
    JwtBearerDefaults.AuthenticationScheme)]
public class MixedController : Controller
```

In the preceding code, only the handler with the "Bearer" scheme runs. Any cookie-based identities are ignored.

## Selecting the scheme with policies

If you prefer to specify the desired schemes in [policy](xref:security/authorization/policies), you can set the `AuthenticationSchemes` collection when adding your policy:

```csharp
services.AddAuthorization(options =>
{
    options.AddPolicy("Over18", policy =>
    {
        policy.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
        policy.RequireAuthenticatedUser();
        policy.Requirements.Add(new MinimumAgeRequirement());
    });
});
```

In the preceding example, the "Over18" policy only runs against the identity created by the "Bearer" handler. Use the policy by setting the `[Authorize]` attribute's `Policy` property:

```csharp
[Authorize(Policy = "Over18")]
public class RegistrationController : Controller
```

## Use multiple authentication schemes

Some apps may need to support multiple types of authentication. For example, your app might authenticate users from Azure Active Directory and from a users database. Another example is an app that authenticates users from both Active Directory Federation Services and Azure Active Directory B2C. In this case, the app should accept a JWT bearer token from several issuers.

Add all authentication schemes you'd like to accept. For example, the following code in `Startup.ConfigureServices` adds two JWT bearer authentication schemes with different issuers:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    // Code omitted for brevity

    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.Audience = "https://localhost:5000/";
            options.Authority = "https://localhost:5000/identity/";
        })
        .AddJwtBearer("AzureAD", options =>
        {
            options.Audience = "https://localhost:5000/";
            options.Authority = "https://login.microsoftonline.com/eb971100-6f99-4bdc-8611-1bc8edd7f436/";
        });
}
```

> [!NOTE]
> Only one JWT bearer authentication is registered with the default authentication scheme `JwtBearerDefaults.AuthenticationScheme`. Additional authentication has to be registered with a unique authentication scheme.

The next step is to update the default authorization policy to accept both authentication schemes. For example:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    // Code omitted for brevity

    services.AddAuthorization(options =>
    {
        var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder(
            JwtBearerDefaults.AuthenticationScheme,
            "AzureAD");
        defaultAuthorizationPolicyBuilder = 
            defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();
        options.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();
    });
}
```

As the default authorization policy is overridden, it's possible to use the `[Authorize]` attribute in controllers. The controller then accepts requests with JWT issued by the first or second issuer.

See [this GitHub issue](https://github.com/dotnet/aspnetcore/issues/26002) on using multiple authentication schemes.
:::moniker-end
