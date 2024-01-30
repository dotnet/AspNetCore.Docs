---
title: Secure an ASP.NET Core Blazor WebAssembly standalone app with the Authentication library
author: guardrex
description: Learn how to secure an ASP.NET Core Blazor WebAssembly standalone app with the Blazor WebAssembly Authentication library.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/14/2023
uid: blazor/security/webassembly/standalone-with-authentication-library
---
# Secure an ASP.NET Core Blazor WebAssembly standalone app with the Authentication library

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how to secure an ASP.NET Core Blazor WebAssembly standalone app with the Blazor WebAssembly Authentication library.

The Blazor WebAssembly Authentication library (`Authentication.js`) only supports the Proof Key for Code Exchange (PKCE) authorization code flow via the [Microsoft Authentication Library (MSAL, `msal.js`)](/entra/identity-platform/msal-overview). To implement other grant flows, access the MSAL guidance to implement MSAL directly, but we don't support or recommend the use of grant flows other than PKCE for Blazor apps.

*For Microsoft Entra (ME-ID) and Azure Active Directory B2C (AAD B2C) guidance, don't follow the guidance in this topic. See <xref:blazor/security/webassembly/standalone-with-microsoft-entra-id> or <xref:blazor/security/webassembly/standalone-with-azure-active-directory-b2c>.*

For additional security scenario coverage after reading this article, see <xref:blazor/security/webassembly/additional-scenarios>.

## Walkthrough

The subsections of the walkthrough explain how to:

* Register an app
* Create the Blazor app
* Run the app

### Register an app

Register an app with an [OpenID Connect (OIDC)](https://openid.net/connect/) Identity Provider (IP) following the guidance provided by the maintainer of the IP.

Record the following information:

* Authority (for example, `https://accounts.google.com/`).
* Application (client) ID (for example, `2...7-e...q.apps.googleusercontent.com`).
* Additional IP configuration (see the IP's documentation).

> [!NOTE]
> The IP must use OIDC. For example, Facebook's IP isn't an OIDC-compliant provider, so the guidance in this topic doesn't work with the Facebook IP. For more information, see <xref:blazor/security/webassembly/index#authentication-library>.

### Create the Blazor app

To create a [standalone Blazor WebAssembly app](xref:blazor/hosting-models#blazor-webassembly) that uses the [`Microsoft.AspNetCore.Components.WebAssembly.Authentication`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Authentication) library, follow the guidance for your choice of tooling. If adding support for authentication, see the [Parts of the app](#parts-of-the-app) section of this article for guidance on setting up and configuring the app.

# [Visual Studio](#tab/visual-studio)

To create a new Blazor WebAssembly project with an authentication mechanism:

:::moniker range=">= aspnetcore-8.0"

After choosing the **Blazor WebAssembly App** template, set the **Authentication type** to **Individual Accounts**.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

After choosing the **Blazor WebAssembly App** template, set the **Authentication type** to **Individual Accounts**. Confirm that the **ASP.NET Core Hosted** checkbox is ***not*** selected.

:::moniker-end

The **Individual Accounts** selection uses ASP.NET Core's [Identity](xref:security/authentication/identity) system. This selection adds authentication support and doesn't result in storing users in a database. The following sections of this article provide further details.

# [Visual Studio Code / .NET Core CLI](#tab/visual-studio-code+netcore-cli)

Create a new Blazor WebAssembly project with an authentication mechanism in an empty folder. Specify the `Individual` authentication mechanism with the `-au|--auth` option to use ASP.NET Core's [Identity](xref:security/authentication/identity) system. This selection adds authentication support and doesn't result in storing users in a database. The following sections of this article provide further details.

```dotnetcli
dotnet new blazorwasm -au Individual -o {PROJECT NAME}
```

| Placeholder      | Example        |
| ---------------- | -------------- |
| `{PROJECT NAME}` | `BlazorSample` |

The output location specified with the `-o|--output` option creates a project folder if it doesn't exist and becomes part of the project's name.

For more information, see the [`dotnet new`](/dotnet/core/tools/dotnet-new) command in the .NET Core Guide.

---

### Configure the app

Configure the app following the IP's guidance. At a minimum, the app requires the `Local:Authority` and `Local:ClientId` configuration settings in the app's `wwwroot/appsettings.json` file:

```json
{
  "Local": {
    "Authority": "{AUTHORITY}",
    "ClientId": "{CLIENT ID}"
  }
}
```

Google OAuth 2.0 OIDC example for an app that runs on the `localhost` address at port 5001:

```json
{
  "Local": {
    "Authority": "https://accounts.google.com/",
    "ClientId": "2...7-e...q.apps.googleusercontent.com",
    "PostLogoutRedirectUri": "https://localhost:5001/authentication/logout-callback",
    "RedirectUri": "https://localhost:5001/authentication/login-callback",
    "ResponseType": "id_token"
  }
}
```

The redirect URI (`https://localhost:5001/authentication/login-callback`) is registered in the [Google APIs console](https://console.developers.google.com/apis/dashboard) in **Credentials** > **`{NAME}`** > **Authorized redirect URIs**, where `{NAME}` is the app's client name in the **OAuth 2.0 Client IDs** app list of the Google APIs console.

> [!NOTE]
> Supplying the port number for a `localhost` redirect URI isn't required for some OIDC IPs per the [OAuth 2.0 specification](https://datatracker.ietf.org/doc/html/rfc8252#section-7.3). Some IPs permit the redirect URI for loopback addresses to omit the port. Others allow the use of a wildcard for the port number (for example, `*`). For additional information, see the IP's documentation.

### Run the app

Use one of the following approaches to run the app:

* Visual Studio
  * Select the **Run** button.
  * Use **Debug** > **Start Debugging** from the menu.
  * Press <kbd>F5</kbd>.
* .NET CLI command shell: Execute the `dotnet run` command from the app's folder.

## Parts of the app

This section describes the parts of an app generated from the Blazor WebAssembly project template and how the app is configured. There's no specific guidance to follow in this section for a basic working application if you created the app using the guidance in the [Walkthrough](#walkthrough) section. The guidance in this section is helpful for updating an app to authenticate and authorize users. However, an alternative approach to updating an app is to create a new app from the guidance in the [Walkthrough](#walkthrough) section and moving the app's components, classes, and resources to the new app.

### Authentication package

When an app is created to use Individual User Accounts, the app automatically receives a package reference for the [`Microsoft.AspNetCore.Components.WebAssembly.Authentication`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Authentication) package. The package provides a set of primitives that help the app authenticate users and obtain tokens to call protected APIs.

If adding authentication to an app, manually add the [`Microsoft.AspNetCore.Components.WebAssembly.Authentication`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Authentication) package to the app.

[!INCLUDE[](~/includes/package-reference.md)]

### Authentication service support

Support for authenticating users using OpenID Connect (OIDC) is registered in the service container with the <xref:Microsoft.Extensions.DependencyInjection.WebAssemblyAuthenticationServiceCollectionExtensions.AddOidcAuthentication%2A> extension method provided by the [`Microsoft.AspNetCore.Components.WebAssembly.Authentication`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Authentication) package. 

The <xref:Microsoft.Extensions.DependencyInjection.WebAssemblyAuthenticationServiceCollectionExtensions.AddOidcAuthentication%2A> method accepts a callback to configure the parameters required to authenticate an app using OIDC. The values required for configuring the app can be obtained from the OIDC-compliant IP. Obtain the values when you register the app, which typically occurs in their online portal.

For a new app, provide values for the `{AUTHORITY}` and `{CLIENT ID}` placeholders in the following configuration. Provide other configuration values that are required for use with the app's IP. The example is for Google, which requires `PostLogoutRedirectUri`, `RedirectUri`, and `ResponseType`. If adding authentication to an app, manually add the following code and configuration to the app with values for the placeholders and other configuration values.

In the `Program` file:

```csharp
builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("Local", options.ProviderOptions);
});
```

### `wwwroot/appsettings.json` configuration

Configuration is supplied by the `wwwroot/appsettings.json` file:

```json
{
  "Local": {
    "Authority": "{AUTHORITY}",
    "ClientId": "{CLIENT ID}"
  }
}
```

### Access token scopes

The Blazor WebAssembly template automatically configures default scopes for `openid` and `profile`.

The Blazor WebAssembly template doesn't automatically configure the app to request an access token for a secure API. To provision an access token as part of the sign-in flow, add the scope to the default token scopes of the <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.OidcProviderOptions>. If adding authentication to an app, manually add the following code and configure the scope URI.

In the `Program` file:

```csharp
builder.Services.AddOidcAuthentication(options =>
{
    ...
    options.ProviderOptions.DefaultScopes.Add("{SCOPE URI}");
});
```

For more information, see the following sections of the *Additional scenarios* article:

* [Request additional access tokens](xref:blazor/security/webassembly/additional-scenarios#request-additional-access-tokens)
* [Attach tokens to outgoing requests](xref:blazor/security/webassembly/additional-scenarios#attach-tokens-to-outgoing-requests)

### Imports file

[!INCLUDE[](~/blazor/security/includes/imports-file-standalone.md)]

### Index page

[!INCLUDE[](~/blazor/security/includes/index-page-authentication.md)]

### App component

[!INCLUDE[](~/blazor/security/includes/app-component.md)]

### RedirectToLogin component

[!INCLUDE[](~/blazor/security/includes/redirecttologin-component.md)]

### LoginDisplay component

[!INCLUDE[](~/blazor/security/includes/logindisplay-component.md)]

### Authentication component

[!INCLUDE[](~/blazor/security/includes/authentication-component.md)]

## Troubleshoot

[!INCLUDE[](~/blazor/security/includes/troubleshoot.md)]

## Additional resources

* <xref:blazor/security/webassembly/additional-scenarios>
* [Unauthenticated or unauthorized web API requests in an app with a secure default client](xref:blazor/security/webassembly/additional-scenarios#unauthenticated-or-unauthorized-web-api-requests-in-an-app-with-a-secure-default-client)
* <xref:host-and-deploy/proxy-load-balancer>: Includes guidance on:
  * Using Forwarded Headers Middleware to preserve HTTPS scheme information across proxy servers and internal networks.
  * Additional scenarios and use cases, including manual scheme configuration, request path changes for correct request routing, and forwarding the request scheme for Linux and non-IIS reverse proxies.
