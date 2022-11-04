---
title: Authentication and authorization in minimal APIs
author: captainsafia
description: Learn how to configure authentication and authorization in minimal API apps
ms.author: safia
monikerRange: '>= aspnetcore-7.0'
ms.date: 10/17/2022
uid: fundamentals/minimal-apis/security
---

# Authentication and authorization in minimal APIs

Minimal APIs support all the authentication and authorization options available in ASP.NET Core and provide some additional functionality to improve the experience working with authentication.

## Key concepts in authentication and authorization

Authentication is the process of determining a user's identity. Authorization is the process of determining whether a user has access to a resource. Both authentication and authorization scenarios share similar implementation semantics in ASP.NET Core. Authentication is handled by the authentication service, [IAuthenticationService](/dotnet/api/microsoft.aspnetcore.authentication.iauthenticationservice), which is used by authentication [middleware](/aspnet/core/fundamentals/middleware). Authorization is handled by the authorization service, [IAuthorizationService](/dotnet/api/microsoft.aspnetcore.authorization.iauthorizationservice), which is used by the authorization middleware.

The authentication service uses registered authentication handlers to complete authentication-related actions. For example, an authentication-related action is authenticating a user or signing out a user. Authentication schemes are names that are used to uniquely identify an authentication handler and its configuration options. Authentication handlers are responsible for implementing the strategies for authentication and generating a user's claims given a particular authentication strategy, such as OAuth or OIDC. The configuration options are unique to the strategy as well and provide the handler with configuration that affects authentication behavior, such as redirect URIs.

There are two strategies for determining user access to resources in the authorization layer:

* Role-based strategies determine a user's access based on the role they are assigned, such as `Administrator` or `User`. For more information on role-based authorization, see [role-based authorization documentation](/aspnet/core/security/authorization/roles).
* Claim-based strategies determine a user's access based on claims that are issued by a central authority. For more information on claim-based authorization, see [claim-based authorization documentation](/aspnet/core/security/authorization/claims).

In ASP.NET Core, both strategies are captured into an authorization requirement. The authorization service leverages authorization handlers to determine whether or not a particular user meets the authorization requirements applied onto a resource. 

## Enabling authentication in minimal apps

To enable authentication, call [`AddAuthentication`](/dotnet/api/microsoft.extensions.dependencyinjection.authenticationservicecollectionextensions.addauthentication) to register the required authentication services on the app's service provider.

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication();

var app = builder.Build();

app.Run();
```

Typically, a specific authentication strategy is used. In the following sample, the app is configured with support for JWT bearer-based authentication.

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication().AddJwtBearer();

var app = builder.Build();

app.Run();
```

By default, the [`WebApplication`](/dotnet/api/microsoft.aspnetcore.builder.webapplication) automatically registers the authentication and authorization middlewares if certain authentication and authorization services are enabled. In the following sample, it's not necessary to invoke [`UseAuthentication`](/dotnet/api/microsoft.aspnetcore.builder.authappbuilderextensions.useauthentication) or [`UseAuthorization`](/dotnet/api/microsoft.aspnetcore.builder.authorizationappbuilderextensions.useauthorization) to register the middlewares because [`WebApplication`](/dotnet/api/microsoft.aspnetcore.builder.webapplication) does this automatically after `AddAuthentication` or `AddAuthorization` are called.

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthorization();

var app = builder.Build();

app.Run();
```

In some cases, such as controlling middleware order, it's necessary to explicitly register authentication and authorization. In the following sample, the authentication middleware runs _after_ the CORS middleware has run. For more information on middlewares and this automatic behavior, see [Middleware in Minimal API apps](/aspnet/core/fundamentals/minimal-apis/middleware).

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.Run();
```

### Configuring authentication strategy

Authentication strategies typically support a variety of configurations that are loaded via options. Minimal app's support loading options from configuration for the following authentication strategies:

- JWT bearer-based
- OpenID Connection-based

The ASP.NET Core framework expects to find these options under the `Authentication:Schemes:{SchemeName}` section in [configuration](/aspnet/core/fundamentals/configuration). In the following sample, two different schemes, `Bearer` and `LocalAuthIssuer`, are defined with their respective options. The `Authentication:DefaultScheme` option can be used to configure the default authentication strategy that's used.

```json
{
  "Authentication": {
    "DefaultScheme":  "LocalAuthIssuer",
    "Schemes": {
      "Bearer": {
        "ValidAudiences": [
          "https://localhost:7259",
          "http://localhost:5259"
        ],
        "ValidIssuer": "dotnet-user-jwts"
      },
      "LocalAuthIssuer": {
        "ValidAudiences": [
          "https://localhost:7259",
          "http://localhost:5259"
        ],
        "ValidIssuer": "local-auth"
      }
    }
  }
}
```

In `Program.cs`, we register two JWT bearer-based authentication strategies: one with the the "Bearer" scheme name and one with the "LocalAuthIssuer" scheme name. "Bearer" is the typical default scheme in JWT-bearer based enabled applications, but the default scheme can be overridden by setting the `DefaultScheme` property as in the preceding example.

The scheme name is used to uniquely identify an authentication strategy and is used as the lookup key when resolving authentication options from config, as shown in the following example:

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication()
  .AddJwtBearer()
  .AddJwtBearer("LocalAuthIssuer");
  
var app = builder.Build();

app.Run();
```

## Configuring authorization policies in minimal apps

Authentication is used to identify and validate the identity of users against an API. Authorization is used to validate and verify access to resources in an API and is facilitated by the `IAuthorizationService` registered by the `AddAuthorization` extension method. In the following scenario, a `/hello` resource is added that requires a user to present an `is_admin` claim with a `greetings_api` scope.

Configuring authorization requirements on a resource is a two-step process that requires:

1. Configuring the authorization requirements in a policy globally.
2. Applying individual policies to resources.

In the following code, the  `AddAuthorizationBuilder` is invoked which:

- Adds authorization-related services to the DI container.
- Returns an `AuthorizationBuilder` that can be used to directly register authentication policies.

The code creates a new authorization policy, named `policy_greetings`, that encapsulate two authorization requirements:

- A role-based requirement that the user fall under the `admin` role.
- A claim-based requirement that the user provide a `greetings_api` scope.

The `admin_greetings` policy is provided as a required policy to the `/hello` endpoint.

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorizationBuilder()
  .AddPolicy("admin_greetings", policy => 
		policy
			.RequireRole("admin")
			.RequireScope("greetings_api"))

var app = builder.Build();

app.MapGet("/hello", () => "Hello world!")
  .RequireAuthorization("admin_greetings");

app.Run();
```

## Using `dotnet user-jwts` to improve development time testing

Throughout this article, an app configured with JWT-bearer based authentication is used. JWT bearer-based authentication requires that clients present a token in the request header to validate their identity and claims. Typically, these tokens are issued by a central authority, such as an identity server.

When developing on the local machine, the [`dotnet user-jwts`](/aspnet/core/security/authentication/jwt-authn) tool can be used to create bearer tokens.

```dotnetcli
dotnet user-jwts create
```

> [!NOTE]
> When invoked on a project, the tool automatically adds the authentication options matching the generated token to `appsettings.json`.

Tokens can be configured with a variety of customizations. For example, to create a token for the `admin` role and `greetings_api` scope expected by the authorization policy in the preceding code:

```dotnetcli
dotnet user-jwts create --scope "greetings_api" --role "admin"
```

The generated token can then be sent as part of the header in the testing tool of choice. For example, with curl:

```dotnetcli
curl -i -H "Authorization: Bearer {token}" https://localhost:{port}/hello
```

For more information on the `dotnet user-jwts` tool, read the [complete documentation](/aspnet/core/security/authentication/jwt-authn).
