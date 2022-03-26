---
title: Overview of ASP.NET Core Authentication
author: mjrousos
description: Learn about authentication in ASP.NET Core.
ms.author: riande
ms.custom: mvc
ms.date: 03/21/2022
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: security/authentication/index
---
# Overview of ASP.NET Core authentication

:::moniker range=">= aspnetcore-6.0"

By [Mike Rousos](https://github.com/mjrousos)

Authentication is the process of determining a user's identity. [Authorization](xref:security/authorization/introduction) is the process of determining whether a user has access to a resource. In ASP.NET Core, authentication is handled by the authentication service, <xref:Microsoft.AspNetCore.Authentication.IAuthenticationService>, which is used by authentication [middleware](xref:fundamentals/middleware/index). The authentication service uses registered authentication handlers to complete authentication-related actions. Examples of authentication-related actions include:

* Authenticating a user.
* Responding when an unauthenticated user tries to access a restricted resource.

The registered authentication handlers and their configuration options are called "schemes".

Authentication schemes are specified by registering authentication services in `Program.cs`:

* By calling a scheme-specific extension method after a call to <xref:Microsoft.Extensions.DependencyInjection.AuthenticationServiceCollectionExtensions.AddAuthentication%2A>, such as <xref:Microsoft.Extensions.DependencyInjection.JwtBearerExtensions.AddJwtBearer%2A> or <xref:Microsoft.Extensions.DependencyInjection.CookieExtensions.AddCookie%2A>. These extension methods use <xref:Microsoft.AspNetCore.Authentication.AuthenticationBuilder.AddScheme%2A?displayProperty=nameWithType> to register schemes with appropriate settings.
* Less commonly, by calling `AuthenticationBuilder.AddScheme` directly.

For example, the following code registers authentication services and handlers for cookie and JWT bearer authentication schemes:

```csharp
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,
        options => builder.Configuration.Bind("JwtSettings", options))
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
        options => builder.Configuration.Bind("CookieSettings", options));
```

The `AddAuthentication` parameter <xref:Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme?displayProperty=nameWithType> is the name of the scheme to use by default when a specific scheme isn't requested.

If multiple schemes are used, authorization policies (or authorization attributes) can [specify the authentication scheme (or schemes)](xref:security/authorization/limitingidentitybyscheme) they depend on to authenticate the user. In the example above, the cookie authentication scheme could be used by specifying its name (<xref:Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme?displayProperty=nameWithType> by default, though a different name could be provided when calling `AddCookie`).

In some cases, the call to `AddAuthentication` is automatically made by other extension methods. For example, when using [ASP.NET Core Identity](xref:security/authentication/identity), `AddAuthentication` is called internally.

The Authentication middleware is added in `Program.cs` by calling <xref:Microsoft.AspNetCore.Builder.AuthAppBuilderExtensions.UseAuthentication%2A>. Calling `UseAuthentication` registers the middleware that uses the previously registered authentication schemes. Call `UseAuthentication` before any middleware that depends on users being authenticated.

## Authentication concepts

Authentication is responsible for providing the <xref:System.Security.Claims.ClaimsPrincipal> for authorization to make permission decisions against. There are multiple authentication scheme approaches to select which authentication handler is responsible for generating the correct set of claims:

* [Authentication scheme](#authentication-scheme)
* The default authentication scheme, discussed in the next section.
* Directly set <xref:Microsoft.AspNetCore.Http.HttpContext.User?displayProperty=nameWithType>.

There's no automatic probing of schemes. If the default scheme isn't specified, the scheme must be specified in the authorize attribute, otherwise, the following error is thrown:

> InvalidOperationException: No authenticationScheme was specified, and there was no DefaultAuthenticateScheme found. The default schemes can be set using either AddAuthentication(string defaultScheme) or AddAuthentication(Action\<AuthenticationOptions> configureOptions).

### Authentication scheme

The [authentication scheme](xref:security/authorization/limitingidentitybyscheme) can select which authentication handler is responsible for generating the correct set of claims. For more information, see [Authorize with a specific scheme](xref:security/authorization/limitingidentitybyscheme).

An authentication scheme is a name that corresponds to:

* An authentication handler.
* Options for configuring that specific instance of the handler.

Schemes are useful as a mechanism for referring to the authentication, challenge, and forbid behaviors of the associated handler. For example, an authorization policy can use scheme names to specify which authentication scheme (or schemes) should be used to authenticate the user. When configuring authentication, it's common to specify the default authentication scheme. The default scheme is used unless a resource requests a specific scheme. It's also possible to:

* Specify different default schemes to use for authenticate, challenge, and forbid actions.
* Combine multiple schemes into one using [policy schemes](xref:security/authentication/policyschemes).

### Authentication handler

An authentication handler:

* Is a type that implements the behavior of a scheme.
* Is derived from <xref:Microsoft.AspNetCore.Authentication.IAuthenticationHandler> or <xref:Microsoft.AspNetCore.Authentication.AuthenticationHandler%601>.
* Has the primary responsibility to authenticate users.

Based on the authentication scheme's configuration and the incoming request context, authentication handlers:

* Construct <xref:Microsoft.AspNetCore.Authentication.AuthenticationTicket> objects representing the user's identity if authentication is successful.
* Return 'no result' or 'failure' if authentication is unsuccessful.
* Have methods for challenge and forbid actions for when users attempt to access resources:
  * They're unauthorized to access (forbid).
  * When they're unauthenticated (challenge).

### `RemoteAuthenticationHandler<TOptions>` vs `AuthenticationHandler<TOptions>`

<xref:Microsoft.AspNetCore.Authentication.RemoteAuthenticationHandler%601> is the class for authentication that requires a remote authentication step. When the remote authentication step is finished, the handler calls back to the `CallbackPath` set by the handler. The handler finishes the authentication step using the information passed to the <xref:Microsoft.AspNetCore.Authentication.Twitter.TwitterHandler.HandleRemoteAuthenticateAsync%2A> callback path. [OAuth 2.0](https://oauth.net/2/) and [OIDC](https://openid.net/connect/) both use this pattern. JWT and cookies don't since they can directly use the bearer header and cookie to authenticate. The remotely hosted provider in this case:

* Is the authentication provider.
* Examples include [Facebook](xref:security/authentication/facebook-logins), [Twitter](xref:security/authentication/twitter-logins), [Google](xref:security/authentication/google-logins), [Microsoft](xref:security/authentication/microsoft-logins), and any other OIDC provider that handles authenticating users using the handlers mechanism.

### Authenticate

An authentication scheme's authenticate action is responsible for constructing the user's identity based on request context. It returns an <xref:Microsoft.AspNetCore.Authentication.AuthenticateResult> indicating whether authentication was successful and, if so, the user's identity in an authentication ticket. See <xref:Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.AuthenticateAsync%2A>. Authenticate examples include:

* A cookie authentication scheme constructing the user's identity from cookies.
* A JWT bearer scheme deserializing and validating a JWT bearer token to construct the user's identity.

### Challenge

An authentication challenge is invoked by Authorization when an unauthenticated user requests an endpoint that requires authentication. An authentication challenge is issued, for example, when an anonymous user requests a restricted resource or follows a login link. Authorization invokes a challenge using the specified authentication scheme(s), or the default if none is specified. See <xref:Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.ChallengeAsync%2A>. Authentication challenge examples include:

* A cookie authentication scheme redirecting the user to a login page.
* A JWT bearer scheme returning a 401 result with a `www-authenticate: bearer` header.

A challenge action should let the user know what authentication mechanism to use to access the requested resource.

### Forbid

An authentication scheme's forbid action is called by Authorization when an authenticated user attempts to access a resource they're not permitted to access. See <xref:Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.ForbidAsync%2A>. Authentication forbid examples include:

* A cookie authentication scheme redirecting the user to a page indicating access was forbidden.
* A JWT bearer scheme returning a 403 result.
* A custom authentication scheme redirecting to a page where the user can request access to the resource.

A forbid action can let the user know:

* They're authenticated.
* They're not permitted to access the requested resource.

See the following links for differences between challenge and forbid:

* [Challenge and forbid with an operational resource handler](xref:security/authorization/resourcebased#challenge-and-forbid-with-an-operational-resource-handler).
* [Differences between challenge and forbid](xref:security/authorization/secure-data#challenge).

## Authentication providers per tenant

ASP.NET Core doesn't have a built-in solution for multi-tenant authentication. While it's possible for customers to write one using the built-in features, we recommend customers to consider [Orchard Core](https://www.orchardcore.net/) for this purpose.

Orchard Core is:

* An open-source, modular, and multi-tenant app framework built with ASP.NET Core.
* A content management system (CMS) built on top of that app framework.

See the [Orchard Core](https://github.com/OrchardCMS/OrchardCore) source for an example of authentication providers per tenant.

## Additional resources

* <xref:security/authorization/limitingidentitybyscheme>
* <xref:security/authentication/policyschemes>
* <xref:security/authorization/secure-data>
* [Globally require authenticated users](xref:security/authorization/secure-data#rau)
* [GitHub issue on using multiple authentication schemes](https://github.com/dotnet/aspnetcore/issues/26002)
    
:::moniker-end

:::moniker range="< aspnetcore-6.0"

By [Mike Rousos](https://github.com/mjrousos)

Authentication is the process of determining a user's identity. [Authorization](xref:security/authorization/introduction) is the process of determining whether a user has access to a resource. In ASP.NET Core, authentication is handled by the authentication service, <xref:Microsoft.AspNetCore.Authentication.IAuthenticationService>, which is used by authentication [middleware](xref:fundamentals/middleware/index). The authentication service uses registered authentication handlers to complete authentication-related actions. Examples of authentication-related actions include:

* Authenticating a user.
* Responding when an unauthenticated user tries to access a restricted resource.

The registered authentication handlers and their configuration options are called "schemes".

Authentication schemes are specified by registering authentication services in `Startup.ConfigureServices`:

* By calling a scheme-specific extension method after a call to <xref:Microsoft.Extensions.DependencyInjection.AuthenticationServiceCollectionExtensions.AddAuthentication%2A> (such as <xref:Microsoft.Extensions.DependencyInjection.JwtBearerExtensions.AddJwtBearer%2A> or <xref:Microsoft.Extensions.DependencyInjection.CookieExtensions.AddCookie%2A>, for example). These extension methods use <xref:Microsoft.AspNetCore.Authentication.AuthenticationBuilder.AddScheme%2A?displayProperty=nameWithType> to register schemes with appropriate settings.
* Less commonly, by calling `AuthenticationBuilder.AddScheme` directly.

For example, the following code registers authentication services and handlers for cookie and JWT bearer authentication schemes:

```csharp
services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,
        options => Configuration.Bind("JwtSettings", options))
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
        options => Configuration.Bind("CookieSettings", options));
```

The `AddAuthentication` parameter <xref:Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme?displayProperty=nameWithType> is the name of the scheme to use by default when a specific scheme isn't requested.

If multiple schemes are used, authorization policies (or authorization attributes) can [specify the authentication scheme (or schemes)](xref:security/authorization/limitingidentitybyscheme) they depend on to authenticate the user. In the example above, the cookie authentication scheme could be used by specifying its name (<xref:Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme?displayProperty=nameWithType> by default, though a different name could be provided when calling `AddCookie`).

In some cases, the call to `AddAuthentication` is automatically made by other extension methods. For example, when using [ASP.NET Core Identity](xref:security/authentication/identity), `AddAuthentication` is called internally.

The Authentication middleware is added in `Startup.Configure` by calling <xref:Microsoft.AspNetCore.Builder.AuthAppBuilderExtensions.UseAuthentication%2A>. Calling `UseAuthentication` registers the middleware that uses the previously registered authentication schemes. Call `UseAuthentication` before any middleware that depends on users being authenticated. When using endpoint routing, the call to `UseAuthentication` must go:

* After <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseRouting%2A>, so that route information is available for authentication decisions.
* Before <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseEndpoints%2A>, so that users are authenticated before accessing the endpoints.

## Authentication concepts

Authentication is responsible for providing the <xref:System.Security.Claims.ClaimsPrincipal> for authorization to make permission decisions against. There are multiple authentication scheme approaches to select which authentication handler is responsible for generating the correct set of claims:

* [Authentication scheme](#authentication-scheme)
* The default authentication scheme, discussed in the next section.
* Directly set <xref:Microsoft.AspNetCore.Http.HttpContext.User?displayProperty=nameWithType>.

There's no automatic probing of schemes. If the default scheme isn't specified, the scheme must be specified in the authorize attribute, otherwise, the following error is thrown:

> InvalidOperationException: No authenticationScheme was specified, and there was no DefaultAuthenticateScheme found. The default schemes can be set using either AddAuthentication(string defaultScheme) or AddAuthentication(Action\<AuthenticationOptions> configureOptions).

### Authentication scheme

The [authentication scheme](xref:security/authorization/limitingidentitybyscheme) can select which authentication handler is responsible for generating the correct set of claims. For more information, see [Authorize with a specific scheme](xref:security/authorization/limitingidentitybyscheme).

An authentication scheme is a name that corresponds to:

* An authentication handler.
* Options for configuring that specific instance of the handler.

Schemes are useful as a mechanism for referring to the authentication, challenge, and forbid behaviors of the associated handler. For example, an authorization policy can use scheme names to specify which authentication scheme (or schemes) should be used to authenticate the user. When configuring authentication, it's common to specify the default authentication scheme. The default scheme is used unless a resource requests a specific scheme. It's also possible to:

* Specify different default schemes to use for authenticate, challenge, and forbid actions.
* Combine multiple schemes into one using [policy schemes](xref:security/authentication/policyschemes).

### Authentication handler

An authentication handler:

* Is a type that implements the behavior of a scheme.
* Is derived from <xref:Microsoft.AspNetCore.Authentication.IAuthenticationHandler> or <xref:Microsoft.AspNetCore.Authentication.AuthenticationHandler%601>.
* Has the primary responsibility to authenticate users.

Based on the authentication scheme's configuration and the incoming request context, authentication handlers:

* Construct <xref:Microsoft.AspNetCore.Authentication.AuthenticationTicket> objects representing the user's identity if authentication is successful.
* Return 'no result' or 'failure' if authentication is unsuccessful.
* Have methods for challenge and forbid actions for when users attempt to access resources:
  * They're unauthorized to access (forbid).
  * When they're unauthenticated (challenge).

### `RemoteAuthenticationHandler<TOptions>` vs `AuthenticationHandler<TOptions>`

<xref:Microsoft.AspNetCore.Authentication.RemoteAuthenticationHandler%601> is the class for authentication that requires a remote authentication step. When the remote authentication step is finished, the handler calls back to the `CallbackPath` set by the handler. The handler finishes the authentication step using the information passed to the <xref:Microsoft.AspNetCore.Authentication.Twitter.TwitterHandler.HandleRemoteAuthenticateAsync%2A> callback path. [OAuth 2.0](https://oauth.net/2/) and [OIDC](https://openid.net/connect/) both use this pattern. JWT and cookies don't since they can directly use the bearer header and cookie to authenticate. The remotely hosted provider in this case:

* Is the authentication provider.
* Examples include [Facebook](xref:security/authentication/facebook-logins), [Twitter](xref:security/authentication/twitter-logins), [Google](xref:security/authentication/google-logins), [Microsoft](xref:security/authentication/microsoft-logins), and any other OIDC provider that handles authenticating users using the handlers mechanism.

### Authenticate

An authentication scheme's authenticate action is responsible for constructing the user's identity based on request context. It returns an <xref:Microsoft.AspNetCore.Authentication.AuthenticateResult> indicating whether authentication was successful and, if so, the user's identity in an authentication ticket. See <xref:Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.AuthenticateAsync%2A>. Authenticate examples include:

* A cookie authentication scheme constructing the user's identity from cookies.
* A JWT bearer scheme deserializing and validating a JWT bearer token to construct the user's identity.

### Challenge

An authentication challenge is invoked by Authorization when an unauthenticated user requests an endpoint that requires authentication. An authentication challenge is issued, for example, when an anonymous user requests a restricted resource or follows a login link. Authorization invokes a challenge using the specified authentication scheme(s), or the default if none is specified. See <xref:Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.ChallengeAsync%2A>. Authentication challenge examples include:

* A cookie authentication scheme redirecting the user to a login page.
* A JWT bearer scheme returning a 401 result with a `www-authenticate: bearer` header.

A challenge action should let the user know what authentication mechanism to use to access the requested resource.

### Forbid

An authentication scheme's forbid action is called by Authorization when an authenticated user attempts to access a resource they're not permitted to access. See <xref:Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.ForbidAsync%2A>. Authentication forbid examples include:

* A cookie authentication scheme redirecting the user to a page indicating access was forbidden.
* A JWT bearer scheme returning a 403 result.
* A custom authentication scheme redirecting to a page where the user can request access to the resource.

A forbid action can let the user know:

* They're authenticated.
* They're not permitted to access the requested resource.

See the following links for differences between challenge and forbid:

* [Challenge and forbid with an operational resource handler](xref:security/authorization/resourcebased#challenge-and-forbid-with-an-operational-resource-handler).
* [Differences between challenge and forbid](xref:security/authorization/secure-data#challenge).

## Authentication providers per tenant

ASP.NET Core framework doesn't have a built-in solution for multi-tenant authentication.
While it's possible for customers to write one, using the built-in features, we recommend customers to look into [Orchard Core](https://www.orchardcore.net/) for this purpose.

Orchard Core is:

* An open-source modular and multi-tenant app framework built with ASP.NET Core.
* A content management system (CMS) built on top of that app framework.

See the [Orchard Core](https://github.com/OrchardCMS/OrchardCore) source for an example of authentication providers per tenant.

## Additional resources

* <xref:security/authorization/limitingidentitybyscheme>
* <xref:security/authentication/policyschemes>
* <xref:security/authorization/secure-data>
* [Globally require authenticated users](xref:security/authorization/secure-data#rau)
* [GitHub issue on using multiple authentication schemes](https://github.com/dotnet/aspnetcore/issues/26002)

:::moniker-end
