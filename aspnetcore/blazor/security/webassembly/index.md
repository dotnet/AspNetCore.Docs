---
title: Secure ASP.NET Core Blazor WebAssembly
author: guardrex
description: Learn how to secure Blazor WebAssembly apps as single-page applications (SPAs).
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/14/2023
uid: blazor/security/webassembly/index
---
# Secure ASP.NET Core Blazor WebAssembly

[!INCLUDE[](~/includes/not-latest-version.md)]

Blazor WebAssembly apps are secured in the same manner as single-page applications (SPAs). There are several approaches for authenticating users to SPAs, but the most common and comprehensive approach is to use an implementation based on the [OAuth 2.0 protocol](https://oauth.net/), such as [OpenID Connect (OIDC)](https://openid.net/connect/).

The Blazor WebAssembly security documentation primarily focuses on how to accomplish user authentication and authorization tasks. For OAuth 2.0/OIDC general concept coverage, see the resources in the [main overview article's *Additional resources* section](xref:blazor/security/index#additional-resources).

## Client-side/SPA security

A Blazor WebAssembly app's .NET/C# codebase is served to clients, and the app's code can't be protected from inspection and tampering by users. Never place anything of a secret nature into a Blazor WebAssembly app, such as private .NET/C# code, security keys, passwords, or any other type of sensitive information.

To protect .NET/C# code and use [ASP.NET Core Data Protection](xref:security/data-protection/introduction) features to secure data, use a server-side ASP.NET Core web API. Have the client-side Blazor WebAssembly app call the server-side web API for secure app features and data processing. For more information, see <xref:blazor/call-web-api?pivots=webassembly> and the articles in this node.

## Authentication library

Blazor WebAssembly supports authenticating and authorizing apps using OIDC via the [`Microsoft.AspNetCore.Components.WebAssembly.Authentication`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Authentication) library using the [Microsoft Identity Platform](/entra/identity-platform/). The library provides a set of primitives for seamlessly authenticating against ASP.NET Core backends. The library can authenticate against any third-party Identity Provider (IP) that supports OIDC, which are called OpenID Providers (OP).

The authentication support in the Blazor WebAssembly Library (`Authentication.js`) is built on top of the [Microsoft Authentication Library (MSAL, `msal.js`)](/entra/identity-platform/msal-overview), which is used to handle the underlying authentication protocol details. The Blazor WebAssembly Library only supports the Proof Key for Code Exchange (PKCE) authorization code flow. Implicit grant isn't supported.

Other options for authenticating SPAs exist, such as the use of SameSite cookies. However, the engineering design of Blazor WebAssembly uses OAuth and OIDC as the best option for authentication in Blazor WebAssembly apps. [Token-based authentication](xref:security/anti-request-forgery#token-based-authentication) based on [JSON Web Tokens (JWTs)](https://datatracker.ietf.org/doc/html/rfc7519) was chosen over [cookie-based authentication](xref:security/anti-request-forgery#cookie-based-authentication) for functional and security reasons:

:::moniker range=">= aspnetcore-8.0"

* Using a token-based protocol offers a smaller attack surface area, as the tokens aren't sent in all requests.
* Server endpoints don't require protection against [Cross-Site Request Forgery (CSRF)](xref:security/anti-request-forgery) because the tokens are sent explicitly. This allows you to host Blazor WebAssembly apps alongside MVC or Razor pages apps.
* Tokens have narrower permissions than cookies. For example, tokens can't be used to manage the user account or change a user's password unless such functionality is explicitly implemented.
* Tokens have a short lifetime, one hour by default, which limits the attack window. Tokens can also be revoked at any time.
* Self-contained JWTs offer guarantees to the client and server about the authentication process. For example, a client has the means to detect and validate that the tokens it receives are legitimate and were emitted as part of a given authentication process. If a third party attempts to switch a token in the middle of the authentication process, the client can detect the switched token and avoid using it.
* Tokens with OAuth and OIDC don't rely on the user agent behaving correctly to ensure that the app is secure.
* Token-based protocols, such as OAuth and OIDC, allow for authenticating and authorizing users in standalone Blazor Webassembly apps with the same set of security characteristics.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

* Using a token-based protocol offers a smaller attack surface area, as the tokens aren't sent in all requests.
* Server endpoints don't require protection against [Cross-Site Request Forgery (CSRF)](xref:security/anti-request-forgery) because the tokens are sent explicitly. This allows you to host Blazor WebAssembly apps alongside MVC or Razor pages apps.
* Tokens have narrower permissions than cookies. For example, tokens can't be used to manage the user account or change a user's password unless such functionality is explicitly implemented.
* Tokens have a short lifetime, one hour by default, which limits the attack window. Tokens can also be revoked at any time.
* Self-contained JWTs offer guarantees to the client and server about the authentication process. For example, a client has the means to detect and validate that the tokens it receives are legitimate and were emitted as part of a given authentication process. If a third party attempts to switch a token in the middle of the authentication process, the client can detect the switched token and avoid using it.
* Tokens with OAuth and OIDC don't rely on the user agent behaving correctly to ensure that the app is secure.
* Token-based protocols, such as OAuth and OIDC, allow for authenticating and authorizing users of hosted Blazor WebAssembly solution clients and standalone Blazor Webassembly apps with the same set of security characteristics.

:::moniker-end

> [!IMPORTANT]
> For versions of ASP.NET Core that adopt Duende Identity Server in Blazor project templates, [Duende Software](https://duendesoftware.com/) might require you to pay a license fee for production use of Duende Identity Server. For more information, see <xref:migration/50-to-60#project-templates-use-duende-identity-server>.

## Authentication process with OIDC

The [`Microsoft.AspNetCore.Components.WebAssembly.Authentication`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Authentication) library offers several primitives to implement authentication and authorization using OIDC. In broad terms, authentication works as follows:

* When an anonymous user selects the login button or requests a Razor component or page with the [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) applied, the user is redirected to the app's login page (`/authentication/login`).
* In the login page, the authentication library prepares for a redirect to the authorization endpoint. The authorization endpoint is outside of the Blazor WebAssembly app and can be hosted at a separate origin. The endpoint is responsible for determining whether the user is authenticated and for issuing one or more tokens in response. The authentication library provides a login callback to receive the authentication response.
  * If the user isn't authenticated, the user is redirected to the underlying authentication system, which is usually ASP.NET Core Identity.
  * If the user was already authenticated, the authorization endpoint generates the appropriate tokens and redirects the browser back to the login callback endpoint (`/authentication/login-callback`).
* When the Blazor WebAssembly app loads the login callback endpoint (`/authentication/login-callback`), the authentication response is processed.
  * If the authentication process completes successfully, the user is authenticated and optionally sent back to the original protected URL that the user requested.
  * If the authentication process fails for any reason, the user is sent to the login failed page (`/authentication/login-failed`), where an error is displayed.

## `Authentication` component

The `Authentication` component (`Authentication.razor`) handles remote authentication operations and permits the app to:

* Configure app routes for authentication states.
* Set UI content for authentication states.
* Manage authentication state.

Authentication actions, such as registering or signing in a user, are passed to the Blazor framework's <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.RemoteAuthenticatorViewCore%601> component, which persists and controls state across authentication operations.

For more information and examples, see <xref:blazor/security/webassembly/additional-scenarios>.

## Authorization

In Blazor WebAssembly apps, authorization checks can be bypassed because all client-side code can be modified by users. The same is true for all client-side app technologies, including JavaScript SPA frameworks or native apps for any operating system.

**Always perform authorization checks on the server within any API endpoints accessed by your client-side app.**

:::moniker range=">= aspnetcore-7.0"

## Customize authentication

Blazor WebAssembly provides methods to add and retrieve additional parameters for the underlying Authentication library to conduct remote authentication operations with external identity providers.

To pass additional parameters, <xref:Microsoft.AspNetCore.Components.NavigationManager> supports passing and retrieving history entry state when performing external location changes. For more information, see the following resources:

* Blazor *Fundamentals* > *Routing and navigation* article
  * [Navigation history state](xref:blazor/fundamentals/routing#navigation-history-state)
  * [Navigation options](xref:blazor/fundamentals/routing#navigation-options)
* MDN documentation: [History API](https://developer.mozilla.org/docs/Web/API/History_API)

The state stored by the History API provides the following benefits for remote authentication:

* The state passed to the secured app endpoint is tied to the navigation performed to authenticate the user at the `authentication/login` endpoint.
* Extra work encoding and decoding data is avoided.
* The attack surface area is reduced. Unlike using the query string to store navigation state, a top-level navigation or influence from a different origin can't set the state stored by the History API.
* The history entry is replaced upon successful authentication, so the state attached to the history entry is removed and doesn't require clean up.

<xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.InteractiveRequestOptions> represents the request to the identity provider for logging in or provisioning an access token.

<xref:Microsoft.AspNetCore.Components.NavigationManagerExtensions> provides the <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.NavigationManagerExtensions.NavigateToLogin%2A> method for a login operation and <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.NavigationManagerExtensions.NavigateToLogout%2A> for a logout operation. The methods call <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A?displayProperty=nameWithType>, setting the history entry state with a passed <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.InteractiveRequestOptions> or a new <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.InteractiveRequestOptions> instance created by the method for:

* A user signing in (<xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.InteractionType.SignIn?displayProperty=nameWithType>) with the current URI for the return URL.
* A user signing out (<xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.InteractionType.SignOut?displayProperty=nameWithType>) with the return URL.

The following authentication scenarios are covered in the <xref:blazor/security/webassembly/additional-scenarios#custom-authentication-request-scenarios> article:

* Customize the login process
* Logout with a custom return URL
* Customize options before obtaining a token interactively
* Customize options when using an <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.IAccessTokenProvider>
* Obtain the login path from authentication options

:::moniker-end

## Require authorization for the entire app

Apply the [`[Authorize]` attribute](xref:blazor/security/index#authorize-attribute) ([API documentation](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute)) to each Razor component of the app using ***one*** of the following approaches:

* In the app's Imports file, add an [`@using`](xref:mvc/views/razor#using) directive for the <xref:Microsoft.AspNetCore.Authorization?displayProperty=fullName> namespace with an [`@attribute`](xref:mvc/views/razor#attribute) directive for the [`[Authorize]` attribute](xref:blazor/security/index#authorize-attribute).

  `_Imports.razor`:

  ```razor
  @using Microsoft.AspNetCore.Authorization
  @attribute [Authorize]
  ```
  
  Allow anonymous access to the `Authentication` component to permit redirection to the identity provider. Add the following Razor code to the `Authentication` component under its [`@page`](xref:mvc/views/razor#page) directive.
  
  `Authentication.razor`:
  
  ```razor
  @using Microsoft.AspNetCore.Components.WebAssembly.Authentication
  @attribute [AllowAnonymous]
  ```

* Add the attribute to each Razor component under the [`@page`](xref:mvc/views/razor#page) directive:

  ```razor
  @using Microsoft.AspNetCore.Authorization
  @attribute [Authorize]
  ```

> [!NOTE]
> Setting an <xref:Microsoft.AspNetCore.Authorization.AuthorizationOptions.FallbackPolicy?displayProperty=nameWithType> to a policy with <xref:Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.RequireAuthenticatedUser%2A> is **not** supported.

## Use one identity provider app registration per app

:::moniker range=">= aspnetcore-8.0"

Some of the articles under this *Overview* pertain to Blazor hosting scenarios that involve two or more apps. A standalone Blazor WebAssembly app uses web API with authenticated users to access server resources and data provided by a server app.

When this scenario is implemented in documentation examples, ***two*** identity provider registrations are used, one for the client app and one for the server app. Using separate registrations, for example in Microsoft Entra ID, isn't strictly required. However, using two registrations is a security best practice because it isolates the registrations by app. Using separate registrations also allows independent configuration of the client and server registrations.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

Some of the articles under this *Overview* pertain to either of the following Blazor hosting scenarios that involve two or more apps:

* A hosted Blazor WebAssembly solution, which is composed of two apps: a client-side Blazor WebAssembly app and a server-side ASP.NET Core host app. Authenticated users to the client app access server resources and data provided by the server app.
* A standalone Blazor WebAssembly app that uses web API with authenticated users to access server resources and data provided by a server app. This scenario is similar to using a hosted Blazor WebAssembly solution; but in this case, the client app isn't hosted by the server app.

When these scenarios are implemented in documentation examples, ***two*** identity provider registrations are used, one for the client app and one for the server app. Using separate registrations, for example in Microsoft Entra ID, isn't strictly required. However, using two registrations is a security best practice because it isolates the registrations by app. Using separate registrations also allows independent configuration of the client and server registrations.

:::moniker-end

## Refresh tokens

Although refresh tokens can't be secured in Blazor WebAssembly apps, they can be used if you implement them with appropriate security strategies.

For standalone Blazor WebAssembly apps in ASP.NET Core 6.0 or later, we recommend using:

* The [OAuth 2.0 Authorization Code flow (Code) with Proof Key for Code Exchange (PKCE)](https://oauth.net/2/pkce/).
* A refresh token that has a short expiration.
* A [rotated](https://auth0.com/docs/secure/tokens/refresh-tokens/refresh-token-rotation) refresh token.
* A refresh token with an expiration after which a new interactive authorization flow is required to refresh the user's credentials. 

:::moniker range="< aspnetcore-8.0"

For hosted Blazor WebAssembly solutions, refresh tokens can be maintained and used by the server-side app in order to access third-party APIs. For more information, see <xref:blazor/security/webassembly/additional-scenarios#authenticate-users-with-a-third-party-provider-and-call-protected-apis-on-the-host-server-and-the-third-party>.

:::moniker-end

For more information, see the following resources:

* [Microsoft identity platform refresh tokens: Refresh token lifetime](/entra/identity-platform/refresh-tokens#refresh-token-lifetime)
* [OAuth 2.0 for Browser-Based Apps (IETF specification)](https://datatracker.ietf.org/doc/html/draft-ietf-oauth-browser-based-apps-11#section-4)

## Establish claims for users

Apps often require claims for users based on a web API call to a server. For example, claims are frequently used to [establish authorization](xref:blazor/security/index#authorization) in an app. In these scenarios, the app requests an access token to access the service and uses the token to obtain user data for creating claims.

For examples, see the following resources:

* [Additional scenarios: Customize the user](xref:blazor/security/webassembly/additional-scenarios#customize-the-user)
* <xref:blazor/security/webassembly/meid-groups-roles>

## Prerendering support

:::moniker range=">= aspnetcore-8.0"

[Prerendering](xref:blazor/components/prerender) isn't supported for authentication endpoints (`/authentication/` path segment).

:::moniker-end

:::moniker range="< aspnetcore-8.0"

[Prerendering](xref:blazor/components/prerendering-and-integration) isn't supported for authentication endpoints (`/authentication/` path segment).

:::moniker-end

For more information, see <xref:blazor/security/webassembly/additional-scenarios#prerendering-with-authentication>.

## Azure App Service on Linux with Identity Server

Specify the issuer explicitly when deploying to Azure App Service on Linux with Identity Server.

For more information, see <xref:security/authentication/identity/spa#azure-app-service-on-linux>.

## Windows Authentication

We don't recommend using Windows Authentication with Blazor Webassembly or with any other SPA framework. We recommend using token-based protocols instead of Windows Authentication, such as OIDC with Active Directory Federation Services (ADFS).

If Windows Authentication is used with Blazor Webassembly or with any other SPA framework, additional measures are required to protect the app from cross-site request forgery (CSRF) tokens. The same concerns that apply to cookies apply to Windows Authentication with the addition that Windows Authentication doesn't offer a mechanism to prevent sharing of the authentication context across origins. Apps using Windows Authentication without additional protection from CSRF should at least be restricted to an organization's intranet and not be used on the open Internet.

For more information, see <xref:security/anti-request-forgery>.

:::moniker range="< aspnetcore-8.0"

<!-- UPDATE 8.0 Versioning out because this applies
     directly to hosted WASM. Check with the PU
     to confirm no replacement guidance in the 
     BWA/WebAssembly world -->

## Secure a SignalR hub

To secure a SignalR hub:

* In the **:::no-loc text="Server":::** project, apply the [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) to the hub class or to methods of the hub class.

* In the **:::no-loc text="Client":::** project's component, supply an access token to the hub connection:

  ```razor
  @using Microsoft.AspNetCore.Components.WebAssembly.Authentication
  @inject IAccessTokenProvider TokenProvider
  @inject NavigationManager Navigation

  ...

  var tokenResult = await TokenProvider.RequestAccessToken();

  if (tokenResult.TryGetToken(out var token))
  {
      hubConnection = new HubConnectionBuilder()
          .WithUrl(Navigation.ToAbsoluteUri("/chathub"), 
              options => { options.AccessTokenProvider = () => Task.FromResult(token?.Value); })
          .Build();

    ...
  }
  ```

For more information, see <xref:signalr/authn-and-authz#bearer-token-authentication>.

:::moniker-end

## Logging

*This section applies to Blazor WebAssembly apps in ASP.NET Core 7.0 or later.*

To enable debug or trace logging, see the *Authentication logging (Blazor WebAssembly)* section in a 7.0 or later version of the <xref:blazor/fundamentals/logging> article.

## The WebAssembly sandbox

The WebAssembly *sandbox* restricts access to the environment of the system executing WebAssembly code, including access to I/O subsystems, system storage and resources, and the operating system. The isolation between WebAssembly code and the system that executes the code makes WebAssembly a safe coding framework for systems. However, WebAssembly is vulnerable to side-channel attacks at the hardware level. Normal precautions and due diligence in sourcing hardware and placing limitations on accessing hardware apply.

*WebAssembly isn't owned or maintained by Microsoft.*

For more information, see the following W3C resources:

* [WebAssembly: Security](https://webassembly.org/docs/security/)
* [WebAssembly Specification: Security Considerations](https://webassembly.github.io/spec/core/intro/introduction.html#security-considerations)
* [W3C WebAssembly Community Group: Feedback and issues](https://webassembly.org/community/feedback/): The W3C WebAssembly Community Group link is only provided for reference, making it clear that WebAssembly security vulnerabilities and bugs are patched on an ongoing basis, often reported and addressed by browser. ***Don't send feedback or bug reports on Blazor to the W3C WebAssembly Community Group.*** Blazor feedback should be reported to the [Microsoft ASP.NET Core product unit](https://github.com/dotnet/aspnetcore/issues). If the Microsoft product unit determines that an underlying problem with WebAssembly exists, they take the appropriate steps to report the problem to the W3C WebAssembly Community Group.

## Implementation guidance

Articles under this *Overview* provide information on authenticating users in Blazor WebAssembly apps against specific providers.

Standalone Blazor WebAssembly apps:

* [General guidance for OIDC providers and the WebAssembly Authentication Library](xref:blazor/security/webassembly/standalone-with-authentication-library)
* [Microsoft Accounts](xref:blazor/security/webassembly/standalone-with-microsoft-accounts)
* [Microsoft Entra ID (ME-ID)](xref:blazor/security/webassembly/standalone-with-microsoft-entra-id)
* [Azure Active Directory (AAD) B2C](xref:blazor/security/webassembly/standalone-with-azure-active-directory-b2c)

:::moniker range="< aspnetcore-8.0"

Hosted Blazor WebAssembly apps:

* [Microsoft Entra ID (ME-ID)](xref:blazor/security/webassembly/hosted-with-microsoft-entra-id)
* [Azure Active Directory (AAD) B2C](xref:blazor/security/webassembly/hosted-with-azure-active-directory-b2c)
* [Identity Server](xref:blazor/security/webassembly/hosted-with-identity-server)

:::moniker-end

Further configuration guidance is found in the following articles:

* <xref:blazor/security/webassembly/additional-scenarios>
* <xref:blazor/security/webassembly/graph-api>

## Use the Authorization Code flow with PKCE

Microsoft identity platform's [Microsoft Authentication Library for JavaScript (MSAL)](/entra/identity-platform/msal-overview) v2.0 or later provides support for the [Authorization Code flow](/entra/identity-platform/v2-oauth2-auth-code-flow) with [Proof Key for Code Exchange (PKCE)](https://oauth.net/2/pkce/) and [Cross-Origin Resource Sharing (CORS)](xref:security/cors) for single-page applications, including Blazor. 

**Microsoft doesn't recommend using Implicit grant.**

For more information, see the following resources:

* [Authentication flow support in MSAL: Implicit grant](/entra/identity-platform/msal-authentication-flows#implicit-grant)
* [Microsoft identity platform and implicit grant flow: Prefer the auth code flow](/entra/identity-platform/v2-oauth2-implicit-grant-flow#prefer-the-auth-code-flow)
* [Microsoft identity platform and OAuth 2.0 authorization code flow](/entra/identity-platform/v2-oauth2-auth-code-flow)

## Additional resources

* Microsoft identity platform documentation
  * [General documentation](/entra/identity-platform/)
  * [Access tokens](/entra/identity-platform/access-tokens)
* <xref:host-and-deploy/proxy-load-balancer>
  * Using Forwarded Headers Middleware to preserve HTTPS scheme information across proxy servers and internal networks.
  * Additional scenarios and use cases, including manual scheme configuration, request path changes for correct request routing, and forwarding the request scheme for Linux and non-IIS reverse proxies.
* [Prerendering with authentication](xref:blazor/security/webassembly/additional-scenarios#prerendering-with-authentication)
* [WebAssembly: Security](https://webassembly.org/docs/security/)
* [WebAssembly Specification: Security Considerations](https://webassembly.github.io/spec/core/intro/introduction.html#security-considerations)
