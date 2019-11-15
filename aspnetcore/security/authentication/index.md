---
title: Overview of ASP.NET Core Authentication
author: mjrousos
description: Learn about authentication in ASP.NET Core.
ms.author: 
ms.custom: mvc
ms.date: 11/15/2019
uid: security/authentication/index
---
# Overview of ASP.NET Core authentication

Authentication is the process of determining a user's identity (as opposed to [authorization](xref:security/authorization/introduction), which is the process of determining whether a user has access to certain resources). In ASP.NET Core, authentication is handled by authentication [middleware](xref:fundamentals/middleware/index). The authentication middleware uses registered authentication handlers (which, along with their configuration options, are called "schemes") to complete authentication-related actions (like authenticating a user or responding when an unauthenticated user tries to access a restricted resource).

Authentication schemes are specified when registering authentication services in the startup file's `ConfigureServices` method. This is done by calling `AuthenticationBuilder.AddScheme` or, more commonly, with scheme-specific extension methods that call `AddScheme` automatically with appropriate settings. For example, this code registers authentication services including handlers for both cookie and JWT bearer authentication schemes:

```CSharp
// AddAuthentication's parameter is the name of the scheme to use by default
// (if a specific one isn't requested)
services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => Configuration.Bind("JwtSettings", options))
    .AddCookie(options => Configuration.Bind("CookieSettings", options));
```

In some cases (such as when using [ASP.NET Core Identity](xref:security/authentication/identity)), the call to `AddAuthentication` is automatically made by other extension methods. Note that if multiple schemes are used, authorization policies (or authorization attributes) can [specify the authentication scheme (or schemes)](xref:security/authorization/limitingidentitybyscheme) they depend on to authenticate the user.

Authentication middleware is added in the startup file's `Configure` method by calling the `UseAuthentication` extension method on the app's `IApplicationBuilder`. This registers the  middleware which uses the previously-registered authentication schemes. Be sure to call `UseAuthentication` before any middleware that depends on users being authenticated. When using endpoint routing, the call to `UseAuthentication` should go after `UseRouting` (so that route information is available for authentication decisions) and before `UseEndpoints` (so that users are authenticated before accessing the endpoints).

## Authentication Concepts

### Authentication scheme

An authentication scheme is a way of authenticating a user (and how to proceed if a user isn't authenticated). In ASP.NET Core, an authentication scheme consists of an authentication handler and options for configuring that specific instance of the handler. Authentication schemes have names so that they can be easily referenced elsewhere (for example, by an authorization policy that wants to specify which authorization scheme (or schemes) should be used to authenticate the user). When configuring authentication, it's common to specify the default authentication scheme to use (if a particular resource doesn't request a specific scheme). It's also possible to specify different default schemes to use for authenticate, challenge, and forbid actions, or to combine multiple schemes into one using [policy schemes](xref:security/authentication/policyschemes).

### Authentication handler

An authentication handler is a type (derived from `IAuthenticationHandler`) that implements the behavior of a scheme. An authentication handler's primary responsibility is to authenticate users. Based on the authentication scheme's configuration and the incoming request context, authentication handlers construct `AuthenticationTicket` objects representing the user's identity. Alternatively, authentication handlers can return 'no result' or 'failure' if authentication is unsuccessful.

In addition to authenticating, authentication handlers have methods for challenge and forbid actions for when users attempt to access resources they are unauthenticated or unauthorized to access.

### Challenge

An authentication challenge is the action an authentication scheme takes when an unauthenticated user requires authentication (to access a restricted resource, for example). Some examples of this would be the cookie authentication scheme redirecting the user to a login page or the JWT bearer scheme returning a 401 result. A challenge action should let the user know that they need to be authenticated to access a given resource.

### Forbid

An authentication handler's forbid action is used when an authenticated user attempts to access a resource they are not permitted to access. A forbid action usually returns a 403 result. In some custom authentication schemes, though, forbid could result in a redirect to a page where the user can request access to the resource in question from an admin or something like that. A forbid action should let the user know that although they are authenticated, the currently authenticated user is not permitted to access a particular resource.
