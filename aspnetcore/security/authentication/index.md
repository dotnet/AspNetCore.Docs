---
title: Overview of ASP.NET Core Authentication
author: mjrousos
description: Learn about authentication in ASP.NET Core.
ms.author: riande
ms.custom: mvc
ms.date: 03/03/2020
no-loc: [appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: security/authentication/index
---
# Overview of ASP.NET Core authentication

By [Mike Rousos](https://github.com/mjrousos)

Authentication is the process of determining a user's identity. [Authorization](xref:security/authorization/introduction) is the process of determining whether a user has access to a resource. In ASP.NET Core, authentication is handled by the `IAuthenticationService`, which is used by authentication [middleware](xref:fundamentals/middleware/index). The authentication service uses registered authentication handlers to complete authentication-related actions. Examples of authentication-related actions include:

* Authenticating a user.
* Responding when an unauthenticated user tries to access a restricted resource.

The registered authentication handlers and their configuration options are called "schemes".

Authentication schemes are specified by registering authentication services in `Startup.ConfigureServices`:

* By calling a scheme-specific extension method after a call to `services.AddAuthentication` (such as `AddJwtBearer` or `AddCookie`, for example). These extension methods use [AuthenticationBuilder.AddScheme](xref:Microsoft.AspNetCore.Authentication.AuthenticationBuilder.AddScheme*) to register schemes with appropriate settings.
* Less commonly, by calling [AuthenticationBuilder.AddScheme](xref:Microsoft.AspNetCore.Authentication.AuthenticationBuilder.AddScheme*) directly.

For example, the following code registers authentication services and handlers for cookie and JWT bearer authentication schemes:

```csharp
services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options => Configuration.Bind("JwtSettings", options))
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options => Configuration.Bind("CookieSettings", options));
```

The `AddAuthentication` parameter `JwtBearerDefaults.AuthenticationScheme` is the name of the scheme to use by default when a specific scheme isn't requested.

If multiple schemes are used, authorization policies (or authorization attributes) can [specify the authentication scheme (or schemes)](xref:security/authorization/limitingidentitybyscheme) they depend on to authenticate the user. In the example above, the cookie authentication scheme could be used by specifying its name (`CookieAuthenticationDefaults.AuthenticationScheme` by default, though a different name could be provided when calling `AddCookie`).

In some cases, the call to `AddAuthentication` is automatically made by other extension methods. For example, when using [ASP.NET Core Identity](xref:security/authentication/identity), `AddAuthentication` is called internally.

The Authentication middleware is added in `Startup.Configure` by calling the <xref:Microsoft.AspNetCore.Builder.AuthAppBuilderExtensions.UseAuthentication*> extension method on the app's `IApplicationBuilder`. Calling `UseAuthentication` registers the middleware which uses the previously registered authentication schemes. Call `UseAuthentication` before any middleware that depends on users being authenticated. When using endpoint routing, the call to `UseAuthentication` must go:

* After `UseRouting`, so that route information is available for authentication decisions.
* Before `UseEndpoints`, so that users are authenticated before accessing the endpoints.

## Authentication Concepts

### Authentication scheme

An authentication scheme is a name which corresponds to:

* An authentication handler.
* Options for configuring that specific instance of the handler.

Schemes are useful as a mechanism for referring to the authentication, challenge, and forbid behaviors of the associated handler. For example, an authorization policy can use scheme names to specify which authentication scheme (or schemes) should be used to authenticate the user. When configuring authentication, it's common to specify the default authentication scheme. The default scheme is used unless a resource requests a specific scheme. It's also possible to:

* Specify different default schemes to use for authenticate, challenge, and forbid actions.
* Combine multiple schemes into one using [policy schemes](xref:security/authentication/policyschemes).

### Authentication handler

An authentication handler:

* Is a type that implements the behavior of a scheme.
* Is derived from <xref:Microsoft.AspNetCore.Authentication.IAuthenticationHandler> or <xref:Microsoft.AspNetCore.Authentication.AuthenticationHandler`1>.
* Has the primary responsibility to authenticate users.

Based on the authentication scheme's configuration and the incoming request context, authentication handlers:

* Construct <xref:Microsoft.AspNetCore.Authentication.AuthenticationTicket> objects representing the user's identity if authentication is successful.
* Return 'no result' or 'failure' if authentication is unsuccessful.
* Have methods for challenge and forbid actions for when users attempt to access resources:
  * They are unauthorized to access (forbid).
  * When they are unauthenticated (challenge).

### Authenticate

An authentication scheme's authenticate action is responsible for constructing the user's identity based on request context. It returns an <xref:Microsoft.AspNetCore.Authentication.AuthenticateResult> indicating whether authentication was successful and, if so, the user's identity in an authentication ticket. See <xref:Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.AuthenticateAsync%2A>. Authenticate examples include:

* A cookie authentication scheme constructing the user's identity from cookies.
* A JWT bearer scheme deserializing and validating a JWT bearer token to construct the user's identity.

### Challenge

An authentication challenge is invoked by Authorization when an unauthenticated user requests an endpoint that requires authentication. An authentication challenge is issued, for example, when an anonymous user requests a restricted resource or clicks on a login link. Authorization invokes a challenge using the specified authentication scheme(s), or the default if none is specified. See <xref:Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.ChallengeAsync%2A>. Authentication challenge examples include:

* A cookie authentication scheme redirecting the user to a login page.
* A JWT bearer scheme returning a 401 result with a `www-authenticate: bearer` header.

A challenge action should let the user know what authentication mechanism to use to access the requested resource.

### Forbid

An authentication scheme's forbid action is called by Authorization when an authenticated user attempts to access a resource they are not permitted to access. See <xref:Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.ForbidAsync%2A>. Authentication forbid examples include:
* A cookie authentication scheme redirecting the user to a page indicating access was forbidden.
* A JWT bearer scheme returning a 403 result.
* A custom authentication scheme redirecting to a page where the user can request access to the resource.

A forbid action can let the user know:

* They are authenticated.
* They aren't permitted to access the requested resource.

See the following links for differences between challenge and forbid:

* [Challenge and forbid with an operational resource handler](xref:security/authorization/resourcebased#challenge-and-forbid-with-an-operational-resource-handler).
* [Differences between challenge and forbid](xref:security/authorization/secure-data#challenge).

## Authentication providers per tenant

ASP.NET Core framework does not have a built-in solution for multi-tenant authentication.
While it's certainly possible for customers to write one, using the built-in features, we recommend customers to look into [Orchard Core](https://www.orchardcore.net/) for this purpose.

Orchard Core is:

* An open-source modular and multi-tenant app framework built with ASP.NET Core.
* A content management system (CMS) built on top of that app framework.

See the [Orchard Core](https://github.com/OrchardCMS/OrchardCore) source for an example of authentication providers per tenant.

## Additional resources

* <xref:security/authorization/limitingidentitybyscheme>
* <xref:security/authentication/policyschemes>
* <xref:security/authorization/secure-data>
* [Globally require authenticated users](xref:security/authorization/secure-data#rau)