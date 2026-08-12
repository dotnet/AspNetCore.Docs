---
title: Authorize with a specific scheme in ASP.NET Core
ai-usage: ai-assisted
author: wadepickett
description: This article explains how to limit identity to a specific scheme when working with multiple authentication methods.
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.date: 08/11/2026
uid: security/authorization/authorize-with-a-specific-scheme
---
# Authorize with a specific scheme in ASP.NET Core

<!-- DOC AUTHOR NOTE: "Bearer," "Cookie," "Cookies," and "JWT bearer" aren't localized globally per the DocFX file. -->

For an introduction to authentication schemes, see [Overview of ASP.NET Core Authentication: Authentication scheme](xref:security/authentication/index#authentication-scheme).

In some scenarios, such as Single Page Applications (SPAs), it's common to use multiple authentication methods. For example, the app may use cookie-based authentication to sign a user into an app and establish their identity and Bearer authentication (often relying on JWTs) for JavaScript-based requests to web API endpoints. In some cases, the app may have multiple instances of an authentication handler. For example, an app has two cookie handlers, where one contains a basic identity and one is created when a multi-factor authentication (MFA) is triggered. MFA may be triggered because the user requested an operation that requires extra security.

For the following <xref:Microsoft.Extensions.DependencyInjection.AuthenticationServiceCollectionExtensions.AddAuthentication%2A> call without a default authentication scheme specified, two authentication handlers are added to the app using their default authentication scheme names:

* Cookie (scheme name: "Cookies"): <xref:Microsoft.Extensions.DependencyInjection.CookieExtensions.AddCookie%2A>
* JWT bearer (scheme name: "Bearer"): <xref:Microsoft.Extensions.DependencyInjection.JwtBearerExtensions.AddJwtBearer%2A>

:::moniker range=">= aspnetcore-6.0"

```csharp
builder.Services.AddAuthentication()
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Unauthorized/";
        options.AccessDeniedPath = "/Account/Forbidden/";
    })
    .AddJwtBearer(options =>
    {
        options.Audience = "http://localhost:5001/";
        options.Authority = "http://localhost:5000/";
    });
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

```csharp
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

:::moniker-end

Specifying the default scheme when calling <xref:Microsoft.Extensions.DependencyInjection.AuthenticationServiceCollectionExtensions.AddAuthentication%2A> results in setting the <xref:Microsoft.AspNetCore.Http.HttpContext.User%2A?displayProperty=nameWithType> property to a <xref:System.Security.Claims.ClaimsPrincipal> that relies on that identity. If this behavior isn't desired, invoke the parameterless form of <xref:Microsoft.Extensions.DependencyInjection.AuthenticationServiceCollectionExtensions.AddAuthentication%2A>, as shown in the preceding example.

## JWT bearer NuGet package

Several examples in this article rely on API in the [`Microsoft.AspNetCore.Authentication.JwtBearer` NuGet package](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.JwtBearer). The package provides middleware that facilitates JSON Web Token (JWT) authentication, enabling secure authentication for APIs and web services.

## Select a scheme with an `[Authorize]` attribute

An app can specify an authentication handler for Razor components, Minimal API endpoints, controllers, action methods, Razor Pages, and <xref:Microsoft.AspNetCore.Mvc.RazorPages.PageModel>s by passing a comma-delimited list of authentication schemes to the [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute). The attribute specifies the authentication schemes regardless of whether or not a default scheme is configured. In the following example, the Cookies (<xref:Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme%2A?displayProperty=nameWithType>) and Bearer (<xref:Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme%2A?displayProperty=nameWithType>) authentication schemes are set.

> [!NOTE]
> The following examples require the following namespaces: <xref:Microsoft.AspNetCore.Authorization?displayProperty=fullName>, <xref:Microsoft.AspNetCore.Authentication.Cookies?displayProperty=fullName>, and <xref:Microsoft.AspNetCore.Authentication.JwtBearer?displayProperty=fullName>.

For a Razor component:

```razor
@attribute [Authorize(AuthenticationSchemes = 
    CookieAuthenticationDefaults.AuthenticationScheme + "," + 
    JwtBearerDefaults.AuthenticationScheme)]
```

For a Minimal API endpoint, decorate the constructor with an <xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute> to set the schemes:

```csharp
app.MapGet("/api/data", [Authorize(AuthenticationSchemes = 
    CookieAuthenticationDefaults.AuthenticationScheme + "," + 
    JwtBearerDefaults.AuthenticationScheme)] () =>
{
    ...
});
```

Alternatively, you can pass the schemes via a custom policy:

```csharp
app.MapGet("/api/data", () =>
{
    ...
})
.RequireAuthorization(policy => 
    policy.AddAuthenticationSchemes(
        CookieAuthenticationDefaults.AuthenticationScheme + "," + 
        JwtBearerDefaults.AuthenticationScheme));
```

For an MVC controller:

```csharp
[Authorize(AuthenticationSchemes = AuthSchemes)]
public class MixedAuthSchemesController : Controller
{
    private const string AuthSchemes = 
    CookieAuthenticationDefaults.AuthenticationScheme + "," + 
    JwtBearerDefaults.AuthenticationScheme;

    ...
}
```

For a <xref:Microsoft.AspNetCore.Mvc.RazorPages.PageModel> class:

```csharp
[Authorize(AuthenticationSchemes = 
    CookieAuthenticationDefaults.AuthenticationScheme + "," + 
    JwtBearerDefaults.AuthenticationScheme)]
public class MixedAuthSchemesModel : PageModel
{
    ...
}
```

Authorization middleware approves access with any of the specified schemes in the order listed. If both schemes authenticate the user (a valid cookie and a valid bearer token are present), authorization middleware merges the identities into a single <xref:System.Security.Claims.ClaimsPrincipal> context.

By specifying a single scheme, the corresponding handler runs. In the following example, only the handler with the Bearer scheme runs, and any cookie-based identities are ignored for the endpoint:

```razor
@using Microsoft.AspNetCore.Authorization
@using Microsoft.AspNetCore.Authentication.JwtBearer
@attribute [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
```

## Select the scheme with an authorization policy

If you prefer to specify the desired schemes in a [policy](xref:security/authorization/policies), set the <xref:Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.AuthenticationSchemes%2A> collection when adding the policy.

In the following example, the `Over18` policy only runs against the identity created by the JWT bearer handler (<xref:Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme%2A?displayProperty=nameWithType>). For an example of the `MinimumAgeRequirement` class used in the following example, see <xref:security/authorization/policies>. The <xref:Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.RequireAuthenticatedUser%2A> method enforces user authentication to endpoints where the policy is applied.

> [!NOTE]
> The following example requires the <xref:Microsoft.AspNetCore.Authentication.JwtBearer?displayProperty=fullName> namespace.

:::moniker range=">= aspnetcore-7.0"

```csharp
builder.Services.AddAuthorizationBuilder()
    .AddPolicy("Over18", policy =>
    {
        policy.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
        policy.RequireAuthenticatedUser();
        policy.Requirements.Add(new MinimumAgeRequirement(18));
    });
```

:::moniker-end

:::moniker range="= aspnetcore-6.0"

```csharp
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Over18", policy =>
    {
        policy.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
        policy.RequireAuthenticatedUser();
        policy.Requirements.Add(new MinimumAgeRequirement(18));
    });
});
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

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

:::moniker-end

Use the policy by setting <xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute.Policy%2A?displayProperty=nameWithType>.

For a Razor component:

```razor
@using Microsoft.AspNetCore.Authorization
@attribute [Authorize(Policy = "Over18")]
```

For a Minimal API endpoint, call <xref:Microsoft.AspNetCore.Builder.AuthorizationEndpointConventionBuilderExtensions.RequireAuthorization%2A> with the policy name:

```csharp
app.MapGet("/api/data", () => 
{
    ...
})
.RequireAuthorization("Over18");
```

For a MVC controller:

```csharp
[Authorize(Policy = "Over18")]
public class RegistrationController : Controller
```

For a <xref:Microsoft.AspNetCore.Mvc.RazorPages.PageModel> class:

```csharp
[Authorize(Policy = "Over18")]
public class MixedAuthSchemesModel : PageModel
{
    ...
}
```

## `[Authorize]` attribute scheme and policy scheme interaction

The authorization schemes for an endpoint with one or more [`Authorize` attributes](#select-a-scheme-with-an-authorize-attribute) and one or more [policy-based schemes](#select-the-scheme-with-an-authorization-policy) are *combined* to set the final set of permitted schemes for the endpoint. This forms a union, and any listed scheme may authenticate the request. An attribute adding cookies to a policy restricted to Bearer authentication allows a cookie-only request, assuming the cookie creates a <xref:System.Security.Claims.ClaimsPrincipal> meeting the policy requirements.

## Use multiple authentication schemes

Some apps require support for multiple methods of authentication. A typical scenario involves accepting bearer JWTs issued by several identity providers.

Only one JWT bearer handler is registered with the default authentication scheme <xref:Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme%2A?displayProperty=nameWithType>. Register additional JWT bearer schemes for additional identity providers with unique authentication scheme names. The following example names the second scheme "`MEID`" for the ME-ID issuer.

> [!NOTE]
> The following examples require the <xref:Microsoft.AspNetCore.Authorization?displayProperty=fullName> and <xref:Microsoft.AspNetCore.Authentication.JwtBearer?displayProperty=fullName> namespaces.

:::moniker range=">= aspnetcore-6.0"

```csharp
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Audience = "https://localhost:5000/";
        options.Authority = "https://localhost:5000/identity/";
    })
    .AddJwtBearer("MEID", options =>
    {
        options.Audience = "https://localhost:5000/";
        options.Authority = 
            "https://sts.windows.net/00001111-aaaa-2222-bbbb-3333cccc4444/";
    });
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

```csharp
services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Audience = "https://localhost:5000/";
        options.Authority = "https://localhost:5000/identity/";
    })
    .AddJwtBearer("MEID", options =>
    {
        options.Audience = "https://localhost:5000/";
        options.Authority = 
            "https://sts.windows.net/00001111-aaaa-2222-bbbb-3333cccc4444/";
    });
```

:::moniker-end

Update the default authorization policy to accept both authentication schemes:

:::moniker range=">= aspnetcore-7.0"

```csharp
var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder(
    JwtBearerDefaults.AuthenticationScheme, "MEID");

defaultAuthorizationPolicyBuilder =
    defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();

builder.Services.AddAuthorizationBuilder()
    .SetDefaultPolicy(defaultAuthorizationPolicyBuilder.Build());
```

:::moniker-end

:::moniker range="= aspnetcore-6.0"

```csharp
builder.Services.AddAuthorization(options =>
{
    var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder(
        JwtBearerDefaults.AuthenticationScheme, "MEID");

    defaultAuthorizationPolicyBuilder =
        defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();

    options.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();
});
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

```csharp
services.AddAuthorization(options =>
{
    var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder(
        JwtBearerDefaults.AuthenticationScheme, "MEID");

    defaultAuthorizationPolicyBuilder = 
        defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();

    options.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();
});
```

:::moniker-end

The preceding code configures default authorization with support for multiple authentication schemes:

1. A new <xref:Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder> initializes a policy builder that accepts authentication from two schemes:

   * <xref:Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme%2A?displayProperty=nameWithType> (JWT bearer tokens)
   * "MEID" (the custom authentication scheme for ME-ID, defined earlier)

   This means users can authenticate using either JWT tokens or the MEID scheme

2. <xref:Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.RequireAuthenticatedUser%2A> is called to require authenticated users for access to protected endpoints.

3. <xref:Microsoft.AspNetCore.Authorization.AuthorizationBuilder.SetDefaultPolicy%2A> chained to <xref:Microsoft.Extensions.DependencyInjection.PolicyServiceCollectionExtensions.AddAuthorizationBuilder%2A>:

   * Registers authorization services.
   * Sets this policy as the default for all `[Authorize]` attributes that don't specify a custom policy. Any endpoint marked with `[Authorize]` automatically uses this policy

The result of using the preceding API is that protected endpoints in the app require authentication via either JWT bearer tokens or the MEID scheme, providing flexibility in how users authenticate.

## Select a policy scheme based on the `Authorization` header

For guidance on how to use the <xref:Microsoft.AspNetCore.Authentication.AuthenticationBuilder.AddPolicyScheme%2A> method with the <xref:Microsoft.AspNetCore.Authentication.AuthenticationSchemeOptions.ForwardDefaultSelector> property to dynamically select an authentication scheme for each request, see <xref:security/authentication/policyschemes>.

## Additional resources

* <xref:security/authentication/mfa>
* [Protect section with MFA (`dotnet/AspNetCore.Docs` #15791)](https://github.com/dotnet/AspNetCore.Docs/issues/15791#issuecomment-580464195)
* [Multiple jwt authentication schemes can't validate signature key (`dotnet/aspnetcore` #26002)](https://github.com/dotnet/aspnetcore/issues/26002)
