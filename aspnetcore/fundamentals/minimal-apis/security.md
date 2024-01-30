---
title: Authentication and authorization in minimal APIs
author: captainsafia
description: Learn how to configure authentication and authorization in minimal API apps
ms.author: safia
content_well_notification: AI-contribution
monikerRange: '>= aspnetcore-7.0'
ms.date: 9/17/2023
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

:::code language="csharp" source="~/fundamentals/minimal-apis/security/7.0-samples/MinApiAuth/MinApiAuth/Program.cs" id="snippet_1" highlight="2":::

Typically, a specific authentication strategy is used. In the following sample, the app is configured with support for JWT bearer-based authentication. This example makes use of the APIs available in the [`Microsoft.AspNetCore.Authentication.JwtBearer`](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.JwtBearer) NuGet package.

:::code language="csharp" source="~/fundamentals/minimal-apis/security/7.0-samples/MinApiAuth/MinApiAuth/Program.cs" id="snippet_jwt1" highlight="2-3":::

By default, the [`WebApplication`](/dotnet/api/microsoft.aspnetcore.builder.webapplication) automatically registers the authentication and authorization middlewares if certain authentication and authorization services are enabled. In the following sample, it's not necessary to invoke [`UseAuthentication`](/dotnet/api/microsoft.aspnetcore.builder.authappbuilderextensions.useauthentication) or [`UseAuthorization`](/dotnet/api/microsoft.aspnetcore.builder.authorizationappbuilderextensions.useauthorization) to register the middlewares because [`WebApplication`](/dotnet/api/microsoft.aspnetcore.builder.webapplication) does this automatically after `AddAuthentication` or `AddAuthorization` are called.

:::code language="csharp" source="~/fundamentals/minimal-apis/security/7.0-samples/MinApiAuth/MinApiAuth/Program.cs" id="snippet_jwt2":::

In some cases, such as controlling middleware order, it's necessary to explicitly register authentication and authorization. In the following sample, the authentication middleware runs _after_ the CORS middleware has run. For more information on middlewares and this automatic behavior, see [Middleware in Minimal API apps](/aspnet/core/fundamentals/minimal-apis/middleware).

:::code language="csharp" source="~/fundamentals/minimal-apis/security/7.0-samples/MinApiAuth/MinApiAuth/Program.cs" id="snippet_after" highlight="9-11":::

### Configuring authentication strategy

Authentication strategies typically support a variety of configurations that are loaded via options. Minimal apps support loading options from configuration for the following authentication strategies:

- [JWT bearer-based](https://jwt.io/introduction)
- [OpenID Connection-based](https://openid.net/connect/)

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

In `Program.cs`, two JWT bearer-based authentication strategies are registered, with the:

* "Bearer" scheme name.
* "LocalAuthIssuer" scheme name.

"Bearer" is the typical default scheme in JWT-bearer based enabled apps, but the default scheme can be overridden by setting the `DefaultScheme` property as in the preceding example.

The scheme name is used to uniquely identify an authentication strategy and is used as the lookup key when resolving authentication options from config, as shown in the following example:

:::code language="csharp" source="~/fundamentals/minimal-apis/security/7.0-samples/MinApiAuth/MinApiAuth/Program.cs" id="snippet_local" highlight="5":::

## Configuring authorization policies in minimal apps

Authentication is used to identify and validate the identity of users against an API. Authorization is used to validate and verify access to resources in an API and is facilitated by the `IAuthorizationService` registered by the `AddAuthorization` extension method. In the following scenario, a `/hello` resource is added that requires a user to present an `admin` role claim with a `greetings_api` scope claim.

Configuring authorization requirements on a resource is a two-step process that requires:

1. Configuring the authorization requirements in a policy globally.
2. Applying individual policies to resources.

In the following code, <xref:Microsoft.Extensions.DependencyInjection.PolicyServiceCollectionExtensions.AddAuthorizationBuilder%2A> is invoked which:

- Adds authorization-related services to the DI container.
- Returns an <xref:Microsoft.AspNetCore.Authorization.AuthorizationBuilder> that can be used to directly register authorization policies.

The code creates a new authorization policy, named `admin_greetings`, that encapsulates two authorization requirements:

- A role-based requirement via <xref:Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.RequireRole%2A> for users with an `admin` role.
- A claim-based requirement via <xref:Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.RequireClaim%2A> that the user must provide a `greetings_api` scope claim.

The `admin_greetings` policy is provided as a required policy to the `/hello` endpoint.

:::code language="csharp" source="~/fundamentals/minimal-apis/security/7.0-samples/MinApiAuth/MinApiAuth/Program.cs" id="snippet_greet" highlight="5-9,13-14":::

## Use `dotnet user-jwts` for development testing

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
