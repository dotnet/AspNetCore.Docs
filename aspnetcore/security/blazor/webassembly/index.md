---
title: Secure ASP.NET Core Blazor WebAssembly
author: guardrex
description: Learn how to secure Blazor WebAssemlby apps as Single Page Applications (SPAs).
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 03/12/2020
no-loc: [Blazor, SignalR]
uid: security/blazor/webassembly/index
---
# Secure ASP.NET Core Blazor WebAssembly

By [Javier Calvarro Nelson](https://github.com/javiercn)

[!INCLUDE[](~/includes/blazorwasm-preview-notice.md)]

[!INCLUDE[](~/includes/blazorwasm-3.2-template-article-notice.md)]

Blazor WebAssembly apps are secured in the same manner as Single Page Applications (SPAs). There are several approaches for authenticating users to SPAs, but the most common and comprehensive approach is to use an implementation based on the [oAuth 2.0 protocol](https://oauth.net/), such as [Open ID Connect (OIDC)](https://openid.net/connect/).

## Authentication library

Blazor WebAssembly supports authenticating and authorizing apps using OIDC via the `Microsoft.AspNetCore.Components.WebAssembly.Authentication` library. The library provides a set of primitives for seamlessly authenticating against ASP.NET Core backends. The library integrates ASP.NET Core Identity with API authorization support built on top of [Identity Server](https://identityserver.io/). The library can authenticate against any third-party Identity Provider (IP) that supports OIDC, which are called OpenID Providers (OP).

The authentication support in Blazor WebAssembly is built on top of the *oidc-client.js* library, which is used to handle the underlying authentication protocol details.

Other options for authenticating SPAs exist, such as the use of SameSite cookies. However, the engineering design of Blazor WebAssembly is settled on oAuth and OIDC as the best option for authentication in Blazor WebAssembly apps. [Token-based authentication](xref:security/anti-request-forgery#token-based-authentication) based on [JSON Web Tokens (JWTs)](https://self-issued.info/docs/draft-ietf-oauth-json-web-token.html) was chosen over [cookie-based authentication](xref:security/anti-request-forgery#cookie-based-authentication) for functional and security reasons:

* Using a token-based protocol offers a smaller attack surface area, as the tokens aren't sent in all requests.
* Server endpoints don't require protection against [Cross-Site Request Forgery (CSRF)](xref:security/anti-request-forgery) because the tokens are sent explicitly. This allows you to host Blazor WebAssembly apps alongside MVC or Razor pages apps.
* Tokens have narrower permissions than cookies. For example, tokens can't be used to manage the user account or change a user's password unless such functionality is explicitly implemented.
* Tokens have a short lifetime, one hour by default, which limits the attack window. Tokens can also be revoked at any time.
* Self-contained JWTs offer guarantees to the client and server about the authentication process. For example, a client has the means to detect and validate that the tokens it receives are legitimate and were emitted as part of a given authentication process. If a third party attempts to switch a token in the middle of the authentication process, the client can detect the switched token and avoid using it.
* Tokens with oAuth and OIDC don't rely on the user agent behaving correctly to ensure that the app is secure.
* Token-based protocols, such as oAuth and OIDC, allow for authenticating and authorizing hosted and standalone apps with the same set of security characteristics.

## Authentication process with OIDC

The `Microsoft.AspNetCore.Components.WebAssembly.Authentication` library offers several primitives to implement authentication and authorization using OIDC. In broad terms, authentication works as follows:

* When an anonymous user selects the login button or requests a page with the [`[Authorize]`](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) attribute applied, the user is redirected to the app's login page (`/authentication/login`).
* In the login page, the authentication library prepares for a redirect to the authorization endpoint. The authorization endpoint is outside of the Blazor WebAssembly app and can be hosted at a separate origin. The endpoint is responsible for determining whether the user is authenticated and for issuing one or more tokens in response. The authentication library provides a login callback to receive the authentication response.
  * If the user isn't authenticated, the user is redirected to the underlying authentication system, which is usually ASP.NET Core Identity.
  * If the user was already authenticated, the authorization endpoint generates the appropriate tokens and redirects the browser back to the login callback endpoint (`/authentication/login-callback`).
* When the Blazor WebAssembly app loads the login callback endpoint (`/authentication/login-callback`), the authentication response is processed.
  * If the authentication process completes successfully, the user is authenticated and optionally sent back to the original protected URL that the user requested.
  * If the authentication process fails for any reason, the user is sent to the login failed page (`/authentication/login-failed`), and an error is displayed.
  
## Options for hosted apps and third-party login providers

When authenticating and authorizing a hosted Blazor WebAssembly app with a third-party provider, there are several options available for authenticating the user. Which one you choose depends on your scenario.

For more information, see <xref:security/authentication/social/additional-claims>.

### Authenticate users to only call protected third party APIs

Authenticate the user with a client-side oAuth flow against the third-party API provider:

 ```csharp
 builder.services.AddOidcAuthentication(options => { ... });
 ```
 
 In this scenario:

* The server hosting the app doesn't play a role.
* APIs on the server can't be protected.
* The app can only call protected third-party APIs.

### Authenticate users with a third-party provider and call protected APIs on the host server and the third party

Configure Identity with a third-party login provider. Obtain the tokens required for third-party API access and store them.

When a user logs in, Identity collects access and refresh tokens as part of the authentication process. At that point, there are a couple of approaches available for making API calls to third-party APIs.

#### Use a server access token to retrieve the third-party access token

Use the access token generated on the server to retrieve the third-party access token from a server API endpoint. From there, use the third-party access token to call third-party API resources directly from Identity on the client.

We don't recommend this approach. This approach requires treating the third-party access token as if it were generated for a public client. In oAuth terms, the public app doesn't have a client secret because it can't be trusted to store secrets safely, and the access token is produced for a confidential client. A confidential client is a client that has a client secret and is assumed to be able to safely store secrets.

* The third-party access token might be granted additional scopes to perform sensitive operations based on the fact that the third-party emitted the token for a more trusted client.
* Similarly, refresh tokens shouldn't be issued to a client that isn't trusted, as doing so gives the client unlimited access unless other restrictions are put into place.

#### Make API calls from the client to the server API in order to call third-party APIs

Make an API call from the client to the server API. From the server, retrieve the access token for the third-party API resource and issue whatever call is necessary.

While this approach requires an extra network hop through the server to call a third-party API, it ultimately results in a safer experience:

* The server can store refresh tokens and ensure that the app doesn't lose access to third-party resources.
* The app can't leak access tokens from the server that might contain more sensitive permissions.
