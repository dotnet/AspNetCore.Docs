---
title: Overview of ASP.NET Core Authentication
ai-usage: ai-assisted
description: Learn about authentication in ASP.NET Core.
ms.date: 10/27/2026
---
# Overview of ASP.NET Core authentication

:::moniker range=">= aspnetcore-7.0"

By [Mike Rousos](https://github.com/mjrousos)

Authentication is the process of determining a user's identity. [Authorization](../authorization/introduction.md) is the process of determining whether a user has access to a resource. In ASP.NET Core, authentication is handled by the authentication service, <xref:Microsoft.AspNetCore.Authentication.IAuthenticationService>, which is used by authentication [middleware](xref:fundamentals/middleware/index). The authentication service uses registered authentication handlers to complete authentication-related actions. Examples of authentication-related actions include:

* Authenticating a user.
* Responding when an unauthenticated user tries to access a restricted resource.

Configuring authentication doesn't automatically restrict access to endpoints. To [require authenticated users by default](../authorization/policies.md#require-global-user-authentication) in a server-side app, configure a fallback authorization policy.

The registered authentication handlers and their configuration options are called "schemes".

Authentication schemes are specified by registering authentication services in `Program.cs`:

* By calling a scheme-specific extension method after a call to <xref:Microsoft.Extensions.DependencyInjection.AuthenticationServiceCollectionExtensions.AddAuthentication*>, such as <xref:Microsoft.Extensions.DependencyInjection.JwtBearerExtensions.AddJwtBearer*> or <xref:Microsoft.Extensions.DependencyInjection.CookieExtensions.AddCookie*>. These extension methods use <xref:Microsoft.AspNetCore.Authentication.AuthenticationBuilder.AddScheme*?displayProperty=nameWithType> to register schemes with appropriate settings.
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

If multiple schemes are used, authorization policies (or authorization attributes) can [specify the authentication scheme (or schemes)](../authorization/authorize-with-a-specific-scheme.md) they depend on to authenticate the user. In the example above, the cookie authentication scheme could be used by specifying its name (<xref:Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme?displayProperty=nameWithType> by default, though a different name could be provided when calling `AddCookie`).

In some cases, the call to `AddAuthentication` is automatically made by other extension methods. For example, when using [ASP.NET Core Identity](identity.md), `AddAuthentication` is called internally.

## Multiple calls to `AddAuthentication`

If `AddAuthentication` is called multiple times (for example, once directly in application startup and once internally by ASP.NET Core Identity):

* **Options configuration:** Overloads of `AddAuthentication` that take a default scheme name or an `Action<AuthenticationOptions>` delegate register options configuration actions that execute in registration order. The parameterless `AddAuthentication()` overload does not register a configuration delegate. Each configuration delegate overwrites only the specific properties it assigns. For example, when ASP.NET Core Identity configures specific scheme properties (such as `DefaultAuthenticateScheme` and `DefaultChallengeScheme`), a subsequent call to `AddAuthentication(JwtBearerDefaults.AuthenticationScheme)` only sets `DefaultScheme` and leaves Identity's `DefaultAuthenticateScheme` and `DefaultChallengeScheme` in effect. To override defaults set by an earlier registration like Identity, explicitly configure the corresponding properties (for example, by setting `options.DefaultAuthenticateScheme` and `options.DefaultChallengeScheme` in `AddAuthentication(options => ...)`).
* **Service registration:** Core authentication services (such as <xref:Microsoft.AspNetCore.Authentication.IAuthenticationService> and <xref:Microsoft.AspNetCore.Authentication.IAuthenticationHandlerProvider>) are registered using `TryAdd`, so subsequent calls do not duplicate or replace existing service registrations.
* **Scheme registration:** Calling scheme registration methods like <xref:Microsoft.Extensions.DependencyInjection.CookieExtensions.AddCookie*> or <xref:Microsoft.Extensions.DependencyInjection.JwtBearerExtensions.AddJwtBearer*> adds named schemes to the authentication builder. Attempting to register the same scheme name twice throws an `InvalidOperationException` stating that the scheme already exists. However, additional options configuration delegates for an existing scheme can be registered using `builder.Services.Configure<CookieAuthenticationOptions>(schemeName, ...)` to modify properties on an already-registered scheme.

The Authentication middleware is added in `Program.cs` by calling <xref:Microsoft.AspNetCore.Builder.AuthAppBuilderExtensions.UseAuthentication*>. Calling `UseAuthentication` registers the middleware that uses the previously registered authentication schemes. Call `UseAuthentication` before any middleware that depends on users being authenticated.

## Authentication concepts

Authentication is responsible for providing the <xref:System.Security.Claims.ClaimsPrincipal> for authorization to make permission decisions against. There are multiple authentication scheme approaches to select which authentication handler is responsible for generating the correct set of claims:

* [Authentication scheme](#authentication-scheme)
* The default authentication scheme, discussed in the next two sections.
* Directly set <xref:Microsoft.AspNetCore.Http.HttpContext.User?displayProperty=nameWithType>.

When there is only a single authentication scheme registered, it becomes the default scheme. If multiple schemes are registered and the default scheme isn't specified, a scheme must be specified in the authorize attribute, otherwise, the following error is thrown:

> InvalidOperationException: No authenticationScheme was specified, and there was no DefaultAuthenticateScheme found. The default schemes can be set using either AddAuthentication(string defaultScheme) or AddAuthentication(Action\<AuthenticationOptions> configureOptions).

### `DefaultScheme`

When there is only a single authentication scheme registered, the single authentication scheme:

* Is automatically used as the <xref:Microsoft.AspNetCore.Authentication.AuthenticationOptions.DefaultScheme>.
* Eliminates the need to specify the `DefaultScheme` in <xref:Microsoft.Extensions.DependencyInjection.AuthenticationServiceCollectionExtensions.AddAuthentication(Microsoft.Extensions.DependencyInjection.IServiceCollection)> or <xref:Microsoft.Extensions.DependencyInjection.AuthenticationCoreServiceCollectionExtensions.AddAuthenticationCore(Microsoft.Extensions.DependencyInjection.IServiceCollection)>.

To disable automatically using the single authentication scheme as the `DefaultScheme`, call `AppContext.SetSwitch("Microsoft.AspNetCore.Authentication.SuppressAutoDefaultScheme")`.

### Authentication scheme

The [authentication scheme](../authorization/authorize-with-a-specific-scheme.md) can select which authentication handler is responsible for generating the correct set of claims. For more information, see [Authorize with a specific scheme](../authorization/authorize-with-a-specific-scheme.md).

An authentication scheme is a name that corresponds to:

* An authentication handler.
* Options for configuring that specific instance of the handler.

Schemes are useful as a mechanism for referring to the authentication, challenge, and forbid behaviors of the associated handler. For example, an authorization policy can use scheme names to specify which authentication scheme (or schemes) should be used to authenticate the user. When configuring authentication, it's common to specify the default authentication scheme. The default scheme is used unless a resource requests a specific scheme. It's also possible to:

* Specify different default schemes to use for authenticate, challenge, and forbid actions.
* Combine multiple schemes into one using [policy schemes](policyschemes.md).

### Authentication handler

An authentication handler:

* Is a type that implements the behavior of a scheme.
* Is derived from <xref:Microsoft.AspNetCore.Authentication.IAuthenticationHandler> or <xref:Microsoft.AspNetCore.Authentication.AuthenticationHandler`1>.
* Has the primary responsibility to authenticate users.

Based on the authentication scheme's configuration and the incoming request context, authentication handlers:

* Construct <xref:Microsoft.AspNetCore.Authentication.AuthenticationTicket> objects representing the user's identity if authentication is successful.
* Return 'no result' or 'failure' if authentication is unsuccessful.
* Have methods for challenge and forbid actions for when users attempt to access resources:
  * They're unauthorized to access (forbid).
  * When they're unauthenticated (challenge).

### `RemoteAuthenticationHandler<TOptions>` vs `AuthenticationHandler<TOptions>`

<xref:Microsoft.AspNetCore.Authentication.RemoteAuthenticationHandler`1> is the class for authentication that requires a remote authentication step. When the remote authentication step is finished, the handler calls back to the `CallbackPath` set by the handler. The handler finishes the authentication step using the information passed to the <xref:Microsoft.AspNetCore.Authentication.Twitter.TwitterHandler.HandleRemoteAuthenticateAsync*> callback path. [OAuth 2.0](https://oauth.net/2/) and [OIDC](https://openid.net/developers/how-connect-works/) both use this pattern. JWT and cookies don't since they can directly use the bearer header and cookie to authenticate. The remotely hosted provider in this case:

* Is the authentication provider.
* Examples include [Facebook](social/facebook-logins.md), [Twitter](social/twitter-logins.md), [Google](social/google-logins.md), [Microsoft](social/microsoft-logins.md), and any other OIDC provider that handles authenticating users using the handlers mechanism.

### Authenticate

An authentication scheme's authenticate action is responsible for constructing the user's identity based on request context. It returns an <xref:Microsoft.AspNetCore.Authentication.AuthenticateResult> indicating whether authentication was successful and, if so, the user's identity in an authentication ticket. See <xref:Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.AuthenticateAsync*>. Authenticate examples include:

* A cookie authentication scheme constructing the user's identity from cookies.
* A JWT bearer scheme deserializing and validating a JWT bearer token to construct the user's identity.

### Challenge

An authentication challenge is invoked by Authorization when an unauthenticated user requests an endpoint that requires authentication. An authentication challenge is issued, for example, when an anonymous user requests a restricted resource or follows a login link. Authorization invokes a challenge using the specified authentication schemes, or the default if none is specified. See <xref:Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.ChallengeAsync*>. Authentication challenge examples include:

* A cookie authentication scheme redirecting the user to a login page.
* A JWT bearer scheme returning a 401 result with a `www-authenticate: bearer` header.

A challenge action should let the user know what authentication mechanism to use to access the requested resource.

### Forbid

An authentication scheme's forbid action is called by Authorization when an authenticated user attempts to access a resource they're not permitted to access. See <xref:Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.ForbidAsync*>. Authentication forbid examples include:

* A cookie authentication scheme redirecting the user to a page indicating access was forbidden.
* A JWT bearer scheme returning a 403 result.
* A custom authentication scheme redirecting to a page where the user can request access to the resource.

A forbid action can let the user know:

* They're authenticated.
* They're not permitted to access the requested resource.

See the following links for differences between challenge and forbid:

* [Resource-based authorization](../authorization/resource-based.md).
* [Differences between challenge and forbid](../authorization/secure-data.md#challenge).

## Authentication providers per tenant

ASP.NET Core doesn't have a built-in solution for multi-tenant authentication. While it's possible for customers to write one using the built-in features, we recommend customers consider [Orchard Core](https://www.orchardcore.net/), [ABP Framework](https://abp.io/), or [Finbuckle.MultiTenant](https://www.finbuckle.com/multitenant) for multi-tenant authentication.

Orchard Core is:

* An open-source, modular, and multi-tenant app framework built with ASP.NET Core.
* A content management system (CMS) built on top of that app framework.

See the [Orchard Core](https://github.com/OrchardCMS/OrchardCore) source for an example of authentication providers per tenant.

[ABP Framework](https://abp.io/) supports various architectural patterns including modularity, microservices, domain driven design, and multi-tenancy. See [ABP Framework source on GitHub](https://github.com/abpframework/abp).

Finbuckle.MultiTenant:

* Open source
* Provides tenant resolution
* Lightweight
* Provides data isolation
* Configure app behavior uniquely for each tenant

## Additional resources

* [Authorize with a specific scheme in ASP.NET Core](../authorization/authorize-with-a-specific-scheme.md)
* [Policy schemes in ASP.NET Core](policyschemes.md)
* [Create an ASP.NET Core app with user data protected by authorization](../authorization/secure-data.md)
* [Globally require authenticated users](../authorization/policies.md#require-global-user-authentication)
* [GitHub issue on using multiple authentication schemes](https://github.com/dotnet/aspnetcore/issues/26002)

:::moniker-end

:::moniker range="= aspnetcore-6.0"

By [Mike Rousos](https://github.com/mjrousos)

Authentication is the process of determining a user's identity. [Authorization](../authorization/introduction.md) is the process of determining whether a user has access to a resource. In ASP.NET Core, authentication is handled by the authentication service, <xref:Microsoft.AspNetCore.Authentication.IAuthenticationService>, which is used by authentication [middleware](xref:fundamentals/middleware/index). The authentication service uses registered authentication handlers to complete authentication-related actions. Examples of authentication-related actions include:

* Authenticating a user.
* Responding when an unauthenticated user tries to access a restricted resource.

Configuring authentication doesn't automatically restrict access to endpoints. To [require authenticated users by default](../authorization/policies.md#require-global-user-authentication) in a server-side app, configure a fallback authorization policy.

The registered authentication handlers and their configuration options are called "schemes".

Authentication schemes are specified by registering authentication services in `Program.cs`:

* By calling a scheme-specific extension method after a call to <xref:Microsoft.Extensions.DependencyInjection.AuthenticationServiceCollectionExtensions.AddAuthentication*>, such as <xref:Microsoft.Extensions.DependencyInjection.JwtBearerExtensions.AddJwtBearer*> or <xref:Microsoft.Extensions.DependencyInjection.CookieExtensions.AddCookie*>. These extension methods use <xref:Microsoft.AspNetCore.Authentication.AuthenticationBuilder.AddScheme*?displayProperty=nameWithType> to register schemes with appropriate settings.
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

If multiple schemes are used, authorization policies (or authorization attributes) can [specify the authentication scheme (or schemes)](../authorization/authorize-with-a-specific-scheme.md) they depend on to authenticate the user. In the example above, the cookie authentication scheme could be used by specifying its name (<xref:Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme?displayProperty=nameWithType> by default, though a different name could be provided when calling `AddCookie`).

In some cases, the call to `AddAuthentication` is automatically made by other extension methods. For example, when using [ASP.NET Core Identity](identity.md), `AddAuthentication` is called internally.

The Authentication middleware is added in `Program.cs` by calling <xref:Microsoft.AspNetCore.Builder.AuthAppBuilderExtensions.UseAuthentication*>. Calling `UseAuthentication` registers the middleware that uses the previously registered authentication schemes. Call `UseAuthentication` before any middleware that depends on users being authenticated.

## Authentication concepts

Authentication is responsible for providing the <xref:System.Security.Claims.ClaimsPrincipal> for authorization to make permission decisions against. There are multiple authentication scheme approaches to select which authentication handler is responsible for generating the correct set of claims:

* [Authentication scheme](#authentication-scheme)
* The default authentication scheme, discussed in the next section.
* Directly set <xref:Microsoft.AspNetCore.Http.HttpContext.User?displayProperty=nameWithType>.

There's no automatic probing of schemes. If the default scheme isn't specified, the scheme must be specified in the authorize attribute, otherwise, the following error is thrown:

> InvalidOperationException: No authenticationScheme was specified, and there was no DefaultAuthenticateScheme found. The default schemes can be set using either AddAuthentication(string defaultScheme) or AddAuthentication(Action\<AuthenticationOptions> configureOptions).

### Authentication scheme

The [authentication scheme](../authorization/authorize-with-a-specific-scheme.md) can select which authentication handler is responsible for generating the correct set of claims. For more information, see [Authorize with a specific scheme](../authorization/authorize-with-a-specific-scheme.md).

An authentication scheme is a name that corresponds to:

* An authentication handler.
* Options for configuring that specific instance of the handler.

Schemes are useful as a mechanism for referring to the authentication, challenge, and forbid behaviors of the associated handler. For example, an authorization policy can use scheme names to specify which authentication scheme (or schemes) should be used to authenticate the user. When configuring authentication, it's common to specify the default authentication scheme. The default scheme is used unless a resource requests a specific scheme. It's also possible to:

* Specify different default schemes to use for authenticate, challenge, and forbid actions.
* Combine multiple schemes into one using [policy schemes](policyschemes.md).

### Authentication handler

An authentication handler:

* Is a type that implements the behavior of a scheme.
* Is derived from <xref:Microsoft.AspNetCore.Authentication.IAuthenticationHandler> or <xref:Microsoft.AspNetCore.Authentication.AuthenticationHandler`1>.
* Has the primary responsibility to authenticate users.

Based on the authentication scheme's configuration and the incoming request context, authentication handlers:

* Construct <xref:Microsoft.AspNetCore.Authentication.AuthenticationTicket> objects representing the user's identity if authentication is successful.
* Return 'no result' or 'failure' if authentication is unsuccessful.
* Have methods for challenge and forbid actions for when users attempt to access resources:
  * They're unauthorized to access (forbid).
  * When they're unauthenticated (challenge).

### `RemoteAuthenticationHandler<TOptions>` vs `AuthenticationHandler<TOptions>`

<xref:Microsoft.AspNetCore.Authentication.RemoteAuthenticationHandler`1> is the class for authentication that requires a remote authentication step. When the remote authentication step is finished, the handler calls back to the `CallbackPath` set by the handler. The handler finishes the authentication step using the information passed to the <xref:Microsoft.AspNetCore.Authentication.Twitter.TwitterHandler.HandleRemoteAuthenticateAsync*> callback path. [OAuth 2.0](https://oauth.net/2/) and [OIDC](https://openid.net/developers/how-connect-works/) both use this pattern. JWT and cookies don't since they can directly use the bearer header and cookie to authenticate. The remotely hosted provider in this case:

* Is the authentication provider.
* Examples include [Facebook](social/facebook-logins.md), [Twitter](social/twitter-logins.md), [Google](social/google-logins.md), [Microsoft](social/microsoft-logins.md), and any other OIDC provider that handles authenticating users using the handlers mechanism.

### Authenticate

An authentication scheme's authenticate action is responsible for constructing the user's identity based on request context. It returns an <xref:Microsoft.AspNetCore.Authentication.AuthenticateResult> indicating whether authentication was successful and, if so, the user's identity in an authentication ticket. See <xref:Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.AuthenticateAsync*>. Authenticate examples include:

* A cookie authentication scheme constructing the user's identity from cookies.
* A JWT bearer scheme deserializing and validating a JWT bearer token to construct the user's identity.

### Challenge

An authentication challenge is invoked by Authorization when an unauthenticated user requests an endpoint that requires authentication. An authentication challenge is issued, for example, when an anonymous user requests a restricted resource or follows a login link. Authorization invokes a challenge using the specified authentication schemes, or the default if none is specified. See <xref:Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.ChallengeAsync*>. Authentication challenge examples include:

* A cookie authentication scheme redirecting the user to a login page.
* A JWT bearer scheme returning a 401 result with a `www-authenticate: bearer` header.

A challenge action should let the user know what authentication mechanism to use to access the requested resource.

### Forbid

An authentication scheme's forbid action is called by Authorization when an authenticated user attempts to access a resource they're not permitted to access. See <xref:Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.ForbidAsync*>. Authentication forbid examples include:

* A cookie authentication scheme redirecting the user to a page indicating access was forbidden.
* A JWT bearer scheme returning a 403 result.
* A custom authentication scheme redirecting to a page where the user can request access to the resource.

A forbid action can let the user know:

* They're authenticated.
* They're not permitted to access the requested resource.

See the following links for differences between challenge and forbid:

* [Challenge and forbid with an operational resource handler](xref:razor-pages/security/authorization/resource-based#challenge-and-forbid-with-an-operational-resource-handler).
* [Differences between challenge and forbid](../authorization/secure-data.md#challenge).

## Authentication providers per tenant

ASP.NET Core doesn't have a built-in solution for multi-tenant authentication. While it's possible for customers to write one using the built-in features, we recommend customers consider [Orchard Core](https://www.orchardcore.net/) or [ABP Framework](https://abp.io/) for multi-tenant authentication.

Orchard Core is:

* An open-source, modular, and multi-tenant app framework built with ASP.NET Core.
* A content management system (CMS) built on top of that app framework.

See the [Orchard Core](https://github.com/OrchardCMS/OrchardCore) source for an example of authentication providers per tenant.

[ABP Framework](https://abp.io/) supports various architectural patterns including modularity, microservices, domain driven design, and multi-tenancy. See [ABP Framework source on GitHub](https://github.com/abpframework/abp).

## Additional resources

* [Authorize with a specific scheme in ASP.NET Core](../authorization/authorize-with-a-specific-scheme.md)
* [Policy schemes in ASP.NET Core](policyschemes.md)
* [Create an ASP.NET Core app with user data protected by authorization](../authorization/secure-data.md)
* [Globally require authenticated users](../authorization/policies.md#require-global-user-authentication)
* [GitHub issue on using multiple authentication schemes](https://github.com/dotnet/aspnetcore/issues/26002)

:::moniker-end

:::moniker range="< aspnetcore-6.0"

By [Mike Rousos](https://github.com/mjrousos)

Authentication is the process of determining a user's identity. [Authorization](../authorization/introduction.md) is the process of determining whether a user has access to a resource. In ASP.NET Core, authentication is handled by the authentication service, <xref:Microsoft.AspNetCore.Authentication.IAuthenticationService>, which is used by authentication [middleware](xref:fundamentals/middleware/index). The authentication service uses registered authentication handlers to complete authentication-related actions. Examples of authentication-related actions include:

* Authenticating a user.
* Responding when an unauthenticated user tries to access a restricted resource.

Configuring authentication doesn't automatically restrict access to endpoints. To [require authenticated users by default](../authorization/policies.md#require-global-user-authentication) in a server-side app, configure a fallback authorization policy.

The registered authentication handlers and their configuration options are called "schemes".

Authentication schemes are specified by registering authentication services in `Startup.ConfigureServices`:

* By calling a scheme-specific extension method after a call to <xref:Microsoft.Extensions.DependencyInjection.AuthenticationServiceCollectionExtensions.AddAuthentication*> (such as <xref:Microsoft.Extensions.DependencyInjection.JwtBearerExtensions.AddJwtBearer*> or <xref:Microsoft.Extensions.DependencyInjection.CookieExtensions.AddCookie*>, for example). These extension methods use <xref:Microsoft.AspNetCore.Authentication.AuthenticationBuilder.AddScheme*?displayProperty=nameWithType> to register schemes with appropriate settings.
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

If multiple schemes are used, authorization policies (or authorization attributes) can [specify the authentication scheme (or schemes)](../authorization/authorize-with-a-specific-scheme.md) they depend on to authenticate the user. In the example above, the cookie authentication scheme could be used by specifying its name (<xref:Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme?displayProperty=nameWithType> by default, though a different name could be provided when calling `AddCookie`).

In some cases, the call to `AddAuthentication` is automatically made by other extension methods. For example, when using [ASP.NET Core Identity](identity.md), `AddAuthentication` is called internally.

The Authentication middleware is added in `Startup.Configure` by calling <xref:Microsoft.AspNetCore.Builder.AuthAppBuilderExtensions.UseAuthentication*>. Calling `UseAuthentication` registers the middleware that uses the previously registered authentication schemes. Call `UseAuthentication` before any middleware that depends on users being authenticated. When using endpoint routing, the call to `UseAuthentication` must go:

* After <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseRouting*>, so that route information is available for authentication decisions.
* Before <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseEndpoints*>, so that users are authenticated before accessing the endpoints.

## Authentication concepts

Authentication is responsible for providing the <xref:System.Security.Claims.ClaimsPrincipal> for authorization to make permission decisions against. There are multiple authentication scheme approaches to select which authentication handler is responsible for generating the correct set of claims:

* [Authentication scheme](#authentication-scheme)
* The default authentication scheme, discussed in the next section.
* Directly set <xref:Microsoft.AspNetCore.Http.HttpContext.User?displayProperty=nameWithType>.

There's no automatic probing of schemes. If the default scheme isn't specified, the scheme must be specified in the authorize attribute, otherwise, the following error is thrown:

> InvalidOperationException: No authenticationScheme was specified, and there was no DefaultAuthenticateScheme found. The default schemes can be set using either AddAuthentication(string defaultScheme) or AddAuthentication(Action\<AuthenticationOptions> configureOptions).

### Authentication scheme

The [authentication scheme](../authorization/authorize-with-a-specific-scheme.md) can select which authentication handler is responsible for generating the correct set of claims. For more information, see [Authorize with a specific scheme](../authorization/authorize-with-a-specific-scheme.md).

An authentication scheme is a name that corresponds to:

* An authentication handler.
* Options for configuring that specific instance of the handler.

Schemes are useful as a mechanism for referring to the authentication, challenge, and forbid behaviors of the associated handler. For example, an authorization policy can use scheme names to specify which authentication scheme (or schemes) should be used to authenticate the user. When configuring authentication, it's common to specify the default authentication scheme. The default scheme is used unless a resource requests a specific scheme. It's also possible to:

* Specify different default schemes to use for authenticate, challenge, and forbid actions.
* Combine multiple schemes into one using [policy schemes](policyschemes.md).

### Authentication handler

An authentication handler:

* Is a type that implements the behavior of a scheme.
* Is derived from <xref:Microsoft.AspNetCore.Authentication.IAuthenticationHandler> or <xref:Microsoft.AspNetCore.Authentication.AuthenticationHandler`1>.
* Has the primary responsibility to authenticate users.

Based on the authentication scheme's configuration and the incoming request context, authentication handlers:

* Construct <xref:Microsoft.AspNetCore.Authentication.AuthenticationTicket> objects representing the user's identity if authentication is successful.
* Return 'no result' or 'failure' if authentication is unsuccessful.
* Have methods for challenge and forbid actions for when users attempt to access resources:
  * They're unauthorized to access (forbid).
  * When they're unauthenticated (challenge).

### `RemoteAuthenticationHandler<TOptions>` vs `AuthenticationHandler<TOptions>`

<xref:Microsoft.AspNetCore.Authentication.RemoteAuthenticationHandler`1> is the class for authentication that requires a remote authentication step. When the remote authentication step is finished, the handler calls back to the `CallbackPath` set by the handler. The handler finishes the authentication step using the information passed to the <xref:Microsoft.AspNetCore.Authentication.Twitter.TwitterHandler.HandleRemoteAuthenticateAsync*> callback path. [OAuth 2.0](https://oauth.net/2/) and [OIDC](https://openid.net/developers/how-connect-works/) both use this pattern. JWT and cookies don't since they can directly use the bearer header and cookie to authenticate. The remotely hosted provider in this case:

* Is the authentication provider.
* Examples include [Facebook](social/facebook-logins.md), [Twitter](social/twitter-logins.md), [Google](social/google-logins.md), [Microsoft](social/microsoft-logins.md), and any other OIDC provider that handles authenticating users using the handlers mechanism.

### Authenticate

An authentication scheme's authenticate action is responsible for constructing the user's identity based on request context. It returns an <xref:Microsoft.AspNetCore.Authentication.AuthenticateResult> indicating whether authentication was successful and, if so, the user's identity in an authentication ticket. See <xref:Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.AuthenticateAsync*>. Authenticate examples include:

* A cookie authentication scheme constructing the user's identity from cookies.
* A JWT bearer scheme deserializing and validating a JWT bearer token to construct the user's identity.

### Challenge

An authentication challenge is invoked by Authorization when an unauthenticated user requests an endpoint that requires authentication. An authentication challenge is issued, for example, when an anonymous user requests a restricted resource or follows a login link. Authorization invokes a challenge using the specified authentication schemes, or the default if none is specified. See <xref:Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.ChallengeAsync*>. Authentication challenge examples include:

* A cookie authentication scheme redirecting the user to a login page.
* A JWT bearer scheme returning a 401 result with a `www-authenticate: bearer` header.

A challenge action should let the user know what authentication mechanism to use to access the requested resource.

### Forbid

An authentication scheme's forbid action is called by Authorization when an authenticated user attempts to access a resource they're not permitted to access. See <xref:Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.ForbidAsync*>. Authentication forbid examples include:

* A cookie authentication scheme redirecting the user to a page indicating access was forbidden.
* A JWT bearer scheme returning a 403 result.
* A custom authentication scheme redirecting to a page where the user can request access to the resource.

A forbid action can let the user know:

* They're authenticated.
* They're not permitted to access the requested resource.

See the following links for differences between challenge and forbid:

* [Resource-based authorization](../authorization/resource-based.md).
* [Differences between challenge and forbid](../authorization/secure-data.md#challenge).

## Authentication providers per tenant

ASP.NET Core framework doesn't have a built-in solution for multi-tenant authentication. While it's possible for customers to write an app with multi-tenant authentication, we recommend using one of the following ASP.NET Core application frameworks that support multi-tenant authentication.

[Orchard Core](https://www.orchardcore.net/) is an open-source, modular, and multi-tenant app framework built with ASP.NET Core that also provides a content management system (CMS). See the [Orchard Core](https://github.com/OrchardCMS/OrchardCore) source for an example of authentication providers per tenant.

[ABP Framework](https://abp.io/) supports various architectural patterns including modularity, microservices, domain-driven design, and multi-tenancy. See [ABP Framework source on GitHub](https://github.com/abpframework/abp).

## Additional resources

* [Authorize with a specific scheme in ASP.NET Core](../authorization/authorize-with-a-specific-scheme.md)
* [Policy schemes in ASP.NET Core](policyschemes.md)
* [Create an ASP.NET Core app with user data protected by authorization](../authorization/secure-data.md)
* [Globally require authenticated users](../authorization/policies.md#require-global-user-authentication)
* [GitHub issue on using multiple authentication schemes](https://github.com/dotnet/aspnetcore/issues/26002)

:::moniker-end
