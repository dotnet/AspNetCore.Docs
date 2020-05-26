---
title: Secure ASP.NET Core Blazor WebAssembly
author: guardrex
description: Learn how to secure Blazor WebAssemlby apps as Single Page Applications (SPAs).
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 05/19/2020
no-loc: [Blazor, "Identity", "Let's Encrypt", Razor, SignalR]
uid: security/blazor/webassembly/index
---
# Secure ASP.NET Core Blazor WebAssembly

By [Javier Calvarro Nelson](https://github.com/javiercn)

Blazor WebAssembly apps are secured in the same manner as Single Page Applications (SPAs). There are several approaches for authenticating users to SPAs, but the most common and comprehensive approach is to use an implementation based on the [OAuth 2.0 protocol](https://oauth.net/), such as [Open ID Connect (OIDC)](https://openid.net/connect/).

## Authentication library

Blazor WebAssembly supports authenticating and authorizing apps using OIDC via the [Microsoft.AspNetCore.Components.WebAssembly.Authentication](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Authentication/) library. The library provides a set of primitives for seamlessly authenticating against ASP.NET Core backends. The library integrates ASP.NET Core Identity with API authorization support built on top of [Identity Server](https://identityserver.io/). The library can authenticate against any third-party Identity Provider (IP) that supports OIDC, which are called OpenID Providers (OP).

The authentication support in Blazor WebAssembly is built on top of the *oidc-client.js* library, which is used to handle the underlying authentication protocol details.

Other options for authenticating SPAs exist, such as the use of SameSite cookies. However, the engineering design of Blazor WebAssembly is settled on OAuth and OIDC as the best option for authentication in Blazor WebAssembly apps. [Token-based authentication](xref:security/anti-request-forgery#token-based-authentication) based on [JSON Web Tokens (JWTs)](https://self-issued.info/docs/draft-ietf-oauth-json-web-token.html) was chosen over [cookie-based authentication](xref:security/anti-request-forgery#cookie-based-authentication) for functional and security reasons:

* Using a token-based protocol offers a smaller attack surface area, as the tokens aren't sent in all requests.
* Server endpoints don't require protection against [Cross-Site Request Forgery (CSRF)](xref:security/anti-request-forgery) because the tokens are sent explicitly. This allows you to host Blazor WebAssembly apps alongside MVC or Razor pages apps.
* Tokens have narrower permissions than cookies. For example, tokens can't be used to manage the user account or change a user's password unless such functionality is explicitly implemented.
* Tokens have a short lifetime, one hour by default, which limits the attack window. Tokens can also be revoked at any time.
* Self-contained JWTs offer guarantees to the client and server about the authentication process. For example, a client has the means to detect and validate that the tokens it receives are legitimate and were emitted as part of a given authentication process. If a third party attempts to switch a token in the middle of the authentication process, the client can detect the switched token and avoid using it.
* Tokens with OAuth and OIDC don't rely on the user agent behaving correctly to ensure that the app is secure.
* Token-based protocols, such as OAuth and OIDC, allow for authenticating and authorizing hosted and standalone apps with the same set of security characteristics.

## Authentication process with OIDC

The [Microsoft.AspNetCore.Components.WebAssembly.Authentication](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Authentication/) library offers several primitives to implement authentication and authorization using OIDC. In broad terms, authentication works as follows:

* When an anonymous user selects the login button or requests a page with the [`[Authorize]`](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) attribute applied, the user is redirected to the app's login page (`/authentication/login`).
* In the login page, the authentication library prepares for a redirect to the authorization endpoint. The authorization endpoint is outside of the Blazor WebAssembly app and can be hosted at a separate origin. The endpoint is responsible for determining whether the user is authenticated and for issuing one or more tokens in response. The authentication library provides a login callback to receive the authentication response.
  * If the user isn't authenticated, the user is redirected to the underlying authentication system, which is usually ASP.NET Core Identity.
  * If the user was already authenticated, the authorization endpoint generates the appropriate tokens and redirects the browser back to the login callback endpoint (`/authentication/login-callback`).
* When the Blazor WebAssembly app loads the login callback endpoint (`/authentication/login-callback`), the authentication response is processed.
  * If the authentication process completes successfully, the user is authenticated and optionally sent back to the original protected URL that the user requested.
  * If the authentication process fails for any reason, the user is sent to the login failed page (`/authentication/login-failed`), and an error is displayed.
  
## Implementation guidance

Articles under this *Overview* provide information on authenticating users in Blazor WebAssembly apps against specific providers.

Standalone Blazor WebAssembly apps:

* [General guidance for OIDC providers and the WebAssembly Authentication Library](xref:security/blazor/webassembly/standalone-with-authentication-library)
* [Microsoft Accounts](xref:security/blazor/webassembly/standalone-with-microsoft-accounts)
* [Azure Active Directory (AAD)](xref:security/blazor/webassembly/standalone-with-azure-active-directory)
* [Azure Active Directory (AAD) B2C](xref:security/blazor/webassembly/standalone-with-azure-active-directory-b2c)

Hosted Blazor WebAssembly apps:

* [Azure Active Directory (AAD)](xref:security/blazor/webassembly/hosted-with-azure-active-directory)
* [Azure Active Directory (AAD) B2C](xref:security/blazor/webassembly/hosted-with-azure-active-directory-b2c)
* [Identity Server](xref:security/blazor/webassembly/hosted-with-identity-server)

For further guidance on configuration, see <xref:security/blazor/webassembly/additional-scenarios>.
