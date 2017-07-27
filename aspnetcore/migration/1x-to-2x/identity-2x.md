---
title: Migrating Auth and Identity to ASP.NET Core 2.x
author: scottaddie
description: A reference for migrating the various authentication and Identity components from ASP.NET Core 1.x to ASP.NET Core 2.x.
keywords: ASP.NET Core,Identity,authentication
ms.author: scaddie
manager: wpickett
ms.date: 07/24/2017
ms.topic: article
ms.technology: aspnet
ms.prod: asp.net-core
uid: migration/identity-2x
---

# Migrating Authentication and Identity to ASP.NET Core 2.x

<a name="migration-identity"></a>

By [Scott Addie](https://github.com/scottaddie) and [Hao Kung](https://github.com/HaoK)

This article outlines the authentication and Identity changes to keep in mind when migrating from ASP.NET Core 1.x to ASP.NET Core 2.x.

The 1.x authentication stack becomes obsolete in 2.x. All authentication-related functionality must be migrated to the 2.x stack. Any interoperability between old and new must reside in side-by-side applications, as opposed to mixing 1.x authentication code with 2.x authentication code in the same application. Cookie authentication is interoperable, so 1.x cookies and 2.x cookies are valid in both applications when configured appropriately.

The 2.x changes introduce a more flexible, service-based `IAuthenticationService` implementation. The old middleware / `IAuthenticationManager` design, which carried over from `Microsoft.Owin`, is gone.





<!-- START CONTENT FROM MIGRATION DOC -->
With the release of ASP.NET Core 2.0, the most impacted area of the framework is authentication. The 1.x authentication stack is obsolete and **must** be migrated to the 2.0 stack. The required changes are shown in the following sections.

<a name="obsolete-interface"></a>

### IAuthenticationManager (HttpContext.Authentication) is obsolete
The `IAuthenticationManager` interface was the main entry point into the 1.x authentication system. It has been replaced with a new set of `HttpContext` extension methods in the `Microsoft.AspNetCore.Authentication` namespace.

For example, 1.x projects reference an `Authentication` property:

[!code-csharp[Main](../1x-to-2x/samples/AspNetCoreDotNetCore1.1App/AspNetCoreDotNetCore1.1App/Controllers/AccountController.cs?name=snippet_AuthenticationProperty)]

In 2.x projects, import the `Microsoft.AspNetCore.Authentication` namespace, and delete the `Authentication` property references:

[!code-csharp[Main](../1x-to-2x/samples/AspNetCoreDotNetCore2.0App/AspNetCoreDotNetCore2.0App/Controllers/AccountController.cs?name=snippet_AuthenticationProperty)]

<a name="auth-middleware"></a>

### Authentication Middleware
The `UseIdentity` extension method, which typically appeared in the `Configure` method of *Startup.cs* in 1.x projects, is obsolete and will be removed in a future release:

[!code-csharp[Main](../1x-to-2x/samples/AspNetCoreDotNetCore1.1App/AspNetCoreDotNetCore1.1App/Startup.cs?range=76)]

Feature parity is maintained in 2.x projects when this method call is replaced with `UseAuthentication`:

[!code-csharp[Main](../1x-to-2x/samples/AspNetCoreDotNetCore2.0App/AspNetCoreDotNetCore2.0App/Startup.cs?range=76)]

<a name="identity-cookie-options"></a>

### IdentityCookieOptions Instances
A side effect of the 2.x changes is the switch to using named options instead of cookie options instances. The ability to customize the Identity cookie scheme names is removed.

For example, 1.x projects use [constructor injection](xref:mvc/controllers/dependency-injection#constructor-injection) to pass an `IdentityCookieOptions` parameter into *AccountController.cs*. The external cookie authentication scheme is accessed from the provided instance:

[!code-csharp[Main](../1x-to-2x/samples/AspNetCoreDotNetCore1.1App/AspNetCoreDotNetCore1.1App/Controllers/AccountController.cs?name=snippet_AccountControllerConstructor&highlight=4,11)]

The constructor injection becomes unnecessary in 2.x projects, and the `_externalCookieScheme` field can be deleted:

[!code-csharp[Main](../1x-to-2x/samples/AspNetCoreDotNetCore2.0App/AspNetCoreDotNetCore2.0App/Controllers/AccountController.cs?name=snippet_AccountControllerConstructor)]

The `IdentityConstants.ExternalScheme` constant can be used directly:

[!code-csharp[Main](../1x-to-2x/samples/AspNetCoreDotNetCore2.0App/AspNetCoreDotNetCore2.0App/Controllers/AccountController.cs?name=snippet_AuthenticationProperty)]

<a name="navigation-properties"></a>

### IdentityUser POCO Navigation Properties
The Entity Framework Core navigation properties of the base `IdentityUser` POCO (Plain Old CLR Object) have been removed. If the 1.x project used these properties, manually add them back to the 2.x project:

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

### Removal of GetExternalAuthenticationSchemes
The synchronous method `GetExternalAuthenticationSchemes` was removed in favor of an asynchronous version. 1.x projects have the following code in *ManageController.cs*:

[!code-csharp[Main](../1x-to-2x/samples/AspNetCoreDotNetCore1.1App/AspNetCoreDotNetCore1.1App/Controllers/ManageController.cs?name=snippet_ManageLogins&highlight=16)]

In 2.x projects, use the asynchronous version of the method:

[!code-csharp[Main](../1x-to-2x/samples/AspNetCoreDotNetCore2.0App/AspNetCoreDotNetCore2.0App/Controllers/ManageController.cs?name=snippet_ManageLogins&highlight=16-17)]

1.x projects reference `GetExternalAuthenticationSchemes` in *Login.cshtml*:

[!code-cshtml[Main](../1x-to-2x/samples/AspNetCoreDotNetCore1.1App/AspNetCoreDotNetCore1.1App/Views/Account/Login.cshtml?range=62,75-84)]

In 2.x projects, the asynchronous version of the method is called instead. Switching to this new method means the `AuthenticationScheme` property accessed in the `foreach` loop changes to `Name`.

[!code-cshtml[Main](../1x-to-2x/samples/AspNetCoreDotNetCore2.0App/AspNetCoreDotNetCore2.0App/Views/Account/Login.cshtml?range=62,75-84)]

<a name="property-change"></a>

### ManageLoginsViewModel Property Change
A `ManageLoginsViewModel` object is used in the `ManageLogins` action of *ManageController.cs*. In 1.x projects, the object's `OtherLogins` property return type is `IList<AuthenticationDescription>`. This return type requires an import of `Microsoft.AspNetCore.Http.Authentication`:

[!code-csharp[Main](../1x-to-2x/samples/AspNetCoreDotNetCore1.1App/AspNetCoreDotNetCore1.1App/Models/ManageViewModels/ManageLoginsViewModel.cs?name=snippet_ManageLoginsViewModel&highlight=2,11)]

In 2.x projects, the return type changes to `IList<AuthenticationScheme>`. This new return type requires replacing the `Microsoft.AspNetCore.Http.Authentication` import  with a `Microsoft.AspNetCore.Authentication` import.

[!code-csharp[Main](../1x-to-2x/samples/AspNetCoreDotNetCore2.0App/AspNetCoreDotNetCore2.0App/Models/ManageViewModels/ManageLoginsViewModel.cs?name=snippet_ManageLoginsViewModel&highlight=2,11)]
<!-- END CONTENT FROM MIGRATION DOC -->




## IAuthenticationManager (HttpContext.Authentication) is obsolete

<!-- TODO: add link to this section in 2.x migration doc -->
<!--See [](xref:).-->

## Configure(): UseXyzAuthentication has been replaced by ConfigureService(): AddXyz()

In 1.x, every authentication scheme has its own middleware. The *Startup.cs* file's `Configure` method looks something like this:

```csharp
public void Configure(IApplicationBuilder app, ILoggerFactory loggerfactory) {
    app.UseIdentity();
    app.UseCookieAuthentication(new CookieAuthenticationOptions
       { LoginPath = new PathString("/login") });
    app.UseFacebookAuthentication(new FacebookOptions
       { AppId = Configuration["facebook:appid"],  AppSecret = Configuration["facebook:appsecret"] });
}
```

In 2.x, there is a single authentication middleware component. As depicted in the following code snippet, each authentication scheme is registered in the *Startup.cs* file's `ConfigureServices` method. The `UseIdentity` extension method is no longer required.

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

## New Packages: Microsoft.AspNetCore.Authentication.Core / Abstractions

The 1.x authentication namespaces in the [HttpAbstractions](https://github.com/aspnet/HttpAbstractions) repository have been deprecated. The 2.x authentication stack lives in two new NuGet packages inside HttpAbstractions: [Microsoft.AspNetCore.Authentication.Core](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.Core) and [Microsoft.AspNetCore.Authentication.Abstractions](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.Abstractions).

Brief overview:
- `IAuthenticationService` is used by the `HttpContext` extension methods to expose the five main operations:
    1. `Authenticate`
    2. `Challenge`
    3. `Forbid`
    4. `SignIn`
    5. `SignOut`
- `IAuthenticationHandler` defines the required operations for all handlers:
    - `Authenticate`
    - `Challenge`
    - `Forbid`
- `IAuthenticationSignInHandler` and `IAuthenticationSignOutHandler` are implemented to add the `SignIn` and `SignOut` methods, respectively.
- `IAuthenticationRequestHandler` is implemented by handlers that need to participate in request handler (for example, remote authentication schemes like OAuth / OIDC that need to process third-party authentication responses).
- `AuthenticationScheme` represents a logical, named authentication scheme to target for any given `IAuthenticationService` method. It binds the scheme name (and optional display name) to an `IAuthenticationHandler`, which implements the scheme-specific logic.
- `IAuthenticationSchemeProvider` is responsible for managing which schemes are supported and what the defaults are for each operation (the default implementation just reads from the `AuthenticationOptions`).
- `IAuthenticationHandlerProvider` is responsible for returning the correct handler instance for a given scheme and request.
- `IAuthenticationFeature` is used to capture the original request path/path base so redirects can be computed properly after an `app.Map()`.

The following types moved to new namespaces and are largely unchanged:
- `AuthenticationProperties`: metadata for authentication operations.
- `AuthenticationTicket`: used to store a claims principal (user) and authentication properties
- `AuthenticateResult`: return value for `AuthenticateAsync`, contains either a ticket, or a failure

## Security repo: Microsoft.AspNetCore.Authentication / AuthenticationHandler changes

All of the core abstractions and services for authentication live in the HttpAbstractions repository, but there's an additional layer of base classes and functionality targeted towards `AuthenticationHandler` implementations. This is where the `AuthenticationMiddleware` lives. The handlers themselves, for the various implementations, aren't drastically different, but there were a fair amount of changes.

## Microsoft.AspNetCore.Authentication

Overview:
- `AuthenticationMiddleware`: `UseAuthentication()` adds this middleware which does two things:
    - By default, it automatically authenticates using `AuthenticationOptions.DefaultAuthenticateScheme` to set `HttpContext.User`, if specified.
    - It gives any `IAuthenticationRequestHandler` instance a chance to handle the request.
- `AuthenticationSchemeOptions`: Base class for options used with the `AuthenticationHandler` base class. It defines two common properties in `Events` and `ClaimsIssuer`, as well as a virtual `Validate` method which is invoked on every request by the handler.
- `AuthenticationHandler<TOptions>`: Abstract base class for handlers who must implement `HandleAuthenticateAsync`. The rest of `IAuthenticationHandler` is implemented with some reasonable defaults, Challenge(401)/Forbid(403), and logic to handle per request initialization using `IOptionsMonitor<TOptions>.Get(authenticationScheme.Name)` to resolve the handler's options.
- `RemoteAuthenticationHandler<TOptions>`: Adds the abstract `HandleRemoteAuthenticateAsync` and implements `HandleAuthenticateAsync` to call this method. This is meant to be used for third-party authentication (for example, OAuth / OIDC). It adds an additional constraint to `TOptions` which requires them to be `RemoteAuthenticationOptions` which adds a bunch of settings like `CallbackPath`, `CorrelationCookie`, `Backchannel` which are needed to talk to a remote authentication provider.
- `AuthenticationBuilder`: is a new class used to group all of the `AddXyz` authentication methods. This is returned by `services.AddAuthentication()` and is where specific authentication methods are expected to add themselves as extension methods (for example, `AddCookie`, `AddGoogle`, `AddFacebook`).

## Event changes overview

We've refactored and renamed some things to improve the events experience. At a high level, there are three major types of events:

1. `BaseContext` events are the simplest and just expose properties with no real control flow.
1. `ResultContext` events revolve around producing `AuthenticateResult`s which expose:
    - `Success`: used to indicate that authentication was successful and to use the Principal/Properties in the event to construct the result.
    - `NoResult`: used to indicate no authentication result is to be returned.
    - `Fail`: used to return a failure.
1. `HandleRequestContext` events are used in the `IAuthenticationRequestHandler` / `HandleRemoteAuthenticate` methods and add two more methods:
    - `HandleResponse`: used to indicate that the response was generated and the AuthenticationMiddleware should not invoke the rest of the middleware components in the pipeline after it.
    - `SkipHandler`: used to indicate that this handler is done with the request, but subsequent handlers are called, as well as any other middleware in the pipeline if none of those handlers handle the request.

### AutomaticAuthentication / Challenge have been replaced by Default[Authenticate/Challenge]Scheme

`AutomaticAuthentication` / `AutomaticChallenge` were intended to only be set on one authentication scheme, but there was no good way to enforce this in 1.x. These have been removed as flags on the individual `AuthenticationOptions`. They have moved into the base `AuthenticationOptions`, which can be configured in the call to `AddAuthentication(authenticationOptions => authenticationOptions.DefaultScheme = "Cookies")`.

There are now overloads that use the default schemes for each method in `IAuthenticationService`:
    - `DefaultScheme`: if specified, all the other defaults revert to this value
    - `DefaultAuthenticateScheme`: if specified, `AuthenticateAsync()` uses this scheme, and the
    - `AuthenticationMiddleware` added by `UseAuthentication()` uses this scheme to set `context.User` automatically. (Corresponds to `AutomaticAuthentication`)
    - `DefaultChallengeScheme`: if specified, `ChallengeAsync()` uses this scheme, `[Authorize]` with policies that don't specify schemes use this
    - `DefaultSignInScheme` is used by `SignInAsync()` and by all of the remote authentication schemes like Google, Facebook, OIDC, and OAuth. Typically, this would be set to a cookie.
    - `DefaultSignOutScheme` is used by `SignOutAsync()` falls back to `DefaultSignInScheme`.
    - `DefaultForbidScheme` is used by `ForbidAsync()`, falls back to `DefaultChallengeScheme`.

## "Windows" Authentication(HttpSys/IISIntegration)

The host behavior hasn't changed too much, but now they each register a single "Windows" authentication scheme. IISIntegration now conditionally registers the handler only if Windows authentication is enabled in IIS (if you have the latest version of the [ASP.NET Core Module](xref:fundamentals/servers/aspnet-core-module), otherwise it's always registered as before).

## Authorization changes

### IAuthorizationService.AuthorizeAsync now returns AuthorizationResult instead of bool

In order to enable scenarios around authorization failures, `IAuthorizationService` now returns a result object which allows access to the reasons why `AuthorizeAsync` failed (either `context.Fail()` or a list of failed requirements).

### Removal of ChallengeBehavior => new PolicyEvaluator

In 1.x, there was a ChallengeBehavior enum that was used to specify either Automatic/Unauthorized/Forbid behaviors to signal to the auth middleware what behavior the caller wanted. Automatic was the default and would go down the Forbid(403) code path if the middleware already had an authentication ticket, otherwise would result in Unauthorized(401).

In 2.x, this behavior has been moved into a new `Authorization.Policy` package, which introduces the `IPolicyEvaluator` which uses both `IAuthenticationService` (when requested via `policy.AuthenticationSchemes`), and `IAuthorizationService` to decide whether to return a tri-state `PolicyAuthorizationResult` (Succeeded/Challenged/Forbidden).

### Overview of [Authorize]

The `[Authorize]` attribute hasn't changed much, but some implementation details have changed significantly in MVC's `AuthorizeFilter`. Here's an overview of how things work: AuthorizeFilter source

An effective policy is computed by combining all of the requested policies / requirements from all relevant `[Authorize]` attributes at the various method, controller, and global levels.
`IPolicyEvaluator.AuthenticateAsync(policy, httpContext)` is called, by default. If `policy.AuthenticationSchemes` is specified, `AuthenticateAsync` is invoked on each scheme, and each resulting `ClaimsPrincipal` is merged into a single `ClaimsPrincipal` set on `context.User`. If no schemes were specified, the evaluator attempts to use `context.User` if it contains an authenticated user. This is usually the normal code path, as DefaultScheme/DefaultAuthenticateScheme is set to the main application cookie, and the AuthenticationMiddleware has already set `context.User` using this scheme's `AuthenticateAsync()`.
Authenticate logic

If `AllowAnonymous` was specified, authorization is skipped, and the filter logic short-circuits and is done.
Finally, `IPolicyEvaluator.AuthenticateAsync(policy, authenticationResult, httpContext)` is called with the result from step 2. This just basically turns into a call to `IAuthorizationService.AuthorizeAsync`, and the result is used to determine the appropriate Challenge/ForbidResult if needed.

## Claims Transformation

A simpler `IClaimsTransformation` service was added with a single method: `Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)`.

Invoke this on any successful `AuthenticateAsync` call:

```csharp
services.AddSingleton<IClaimsTransformation, ClaimsTransformer>();

private class ClaimsTransformer : IClaimsTransformation {
    // Can consume services from DI as needed, including scoped DbContexts
    public ClaimsTransformer(IHttpContextAccessor httpAccessor) { }
    public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal p) {
        p.AddIdentity(new ClaimsIdentity());
        return Task.FromResult(p);
    }
}
```

## Known issues/breaking changes:

In 1.x, it was possible to configure different authentication middleware with branching. This is no longer possible with a single middleware and shared services across all branches. A workaround could be to use different schemes/options for each branch.