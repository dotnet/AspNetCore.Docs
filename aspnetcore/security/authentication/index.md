---
title: Overview of ASP.NET Core Authentication
author: mjrousos
description: Learn about authentication in ASP.NET Core.
ms.author: riande
ms.custom: mvc
ms.date: 11/22/2019
uid: security/authentication/index
---
# Overview of ASP.NET Core authentication

By [Mike Rousos](https://github.com/mjrousos)

Authentication is the process of determining a user's identity. [Authorization](xref:security/authorization/introduction) is the process of determining whether a user has access to certain resources. In ASP.NET Core, authentication is handled by authentication [middleware](xref:fundamentals/middleware/index). The authentication middleware uses registered authentication handlers to complete authentication-related actions. Examples of authentication-related actions include:

* Authenticating a user.
* Responding when an unauthenticated user tries to access a restricted resource.

The registered authentication handlers and their configuration options, are called "schemes".

Authentication schemes are specified by registering authentication services in `Startup.ConfigureServices`. This is done by:

* Calling [AuthenticationBuilder.AddScheme]((xref:Microsoft.AspNetCore.Authentication.AuthenticationBuilder.AddScheme*)
* Calling a scheme-specific extension methods that call `AddScheme` automatically with appropriate settings. This approach is more command than calling `AuthenticationBuilder.AddScheme`.

For example, the following code registers authentication services including handlers for both cookie and JWT bearer authentication schemes:

```csharp
services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => Configuration.Bind("JwtSettings", options))
    .AddCookie(options => Configuration.Bind("CookieSettings", options));
```

The `AddAuthentication` parameter is the name of the scheme to use by default if a specific one isn't requested. In the preceding code, JWT bearer authentication is used by default.

In some cases, the call to `AddAuthentication` is automatically made by other extension methods. For example, when using [ASP.NET Core Identity](xref:security/authentication/identity)),`AddAuthentication` is called. If multiple schemes are used, authorization policies (or authorization attributes) can [specify the authentication scheme (or schemes)](xref:security/authorization/limitingidentitybyscheme) they depend on to authenticate the user.

Authentication middleware is added in `Startup.Configure` by calling the <xref:Microsoft.AspNetCore.Builder.AuthAppBuilderExtensions.UseAuthentication*> extension method on the app's `IApplicationBuilder`. This registers the  middleware which uses the previously registered authentication schemes. Call `UseAuthentication` before any middleware that depends on users being authenticated. When using endpoint routing, the call to `UseAuthentication` should go:

* After `UseRouting`, so that route information is available for authentication decisions.
* Before `UseEndpoints`, so that users are authenticated before accessing the endpoints.

## Authentication Concepts

### Authentication scheme

An authentication scheme is:

* A way of authenticating a user.
* How the app responds if a user isn't authenticated.

In ASP.NET Core, an authentication scheme consists of:

* An authentication handler.
* Options for configuring that specific instance of the handler.

Authentication schemes have names so that they can be referenced in the app. For example, an authorization policy that specifies which authorization scheme (or schemes) should be used to authenticate the user. When configuring authentication, it's common to specify the default authentication scheme. The default scheme is used unless a resource request a specific scheme. It's also possible to:

* Specify different default schemes to use for authenticate, challenge, and forbid actions.
* Combine multiple schemes into one using [policy schemes](xref:security/authentication/policyschemes).

### Authentication handler

An authentication handler:

* Is a type that implements the behavior of a scheme.
* Is derived from <xref:Microsoft.AspNetCore.Authentication.IAuthenticationHandler>.
* Has the primary responsibility to authenticate users.

Based on the authentication scheme's configuration and the incoming request context, authentication handlers:

* Construct <xref:Microsoft.AspNetCore.Authentication.AuthenticationTicket> objects representing the user's identity if authentication is successful.
* Return 'no result' or 'failure' if authentication is unsuccessful.
* Have methods for challenge and forbid actions for when users attempt to access resources:
  * They are unauthorized to access.
  * When they are unauthenticated.

### Challenge

An authentication challenge is the action an authentication scheme takes when an unauthenticated user requests an endpoint that requires authentication. For example, to access a restricted resource. Authentication challenge examples include:

* Cookie authentication scheme redirecting the user to a login page.
* The JWT bearer scheme returning a 401 result.

A challenge action should let the user know that they need to be authenticated to access a requested resource.

### Forbid

An authentication handler's forbid action is used when an authenticated user attempts to access a resource they are not permitted to access. A forbid action usually returns a 403 result. In some custom authentication schemes, forbid could result in a redirect to a page where the user can request access to the resource in question from an admin or something like that. A forbid action should let the user know:

* They are authenticated.
* They aren't permitted to access the requested resource.

See the following links for differences between challenge and forbid:

* [Challenge and forbid with an operational resource handler](xref:security/authorization/resourcebased#challenge-and-forbid-with-an-operational-resource-handler).
* [Differences between challenge and forbid](xref:security/authorization/secure-data#challenge).
