---
title: Secure an ASP.NET Core Blazor WebAssembly standalone app with the Authentication library
author: guardrex
description: Learn how to secure an ASP.NET Core Blazor WebAssembly standalone app with the Blazor WebAssembly Authentication library.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/09/2021
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/security/webassembly/standalone-with-authentication-library
---
# Secure an ASP.NET Core Blazor WebAssembly standalone app with the Authentication library

This article explains how to secure an ASP.NET Core Blazor WebAssembly standalone app with the Blazor WebAssembly Authentication library.

:::moniker range=">= aspnetcore-6.0"

*For Azure Active Directory (AAD) and Azure Active Directory B2C (AAD B2C), don't follow the guidance in this topic. See the AAD and AAD B2C topics in this table of contents node.*

To create a [standalone Blazor WebAssembly app](xref:blazor/hosting-models#blazor-webassembly) that uses [`Microsoft.AspNetCore.Components.WebAssembly.Authentication`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Authentication) library, follow the guidance for your choice of tooling. If adding support for authentication, see the following sections of this article for guidance on setting up and configuring the app.

> [!NOTE]
> The Identity Provider (IP) must use [OpenID Connect (OIDC)](https://openid.net/connect/). For example, Facebook's IP isn't an OIDC-compliant provider, so the guidance in this topic doesn't work with the Facebook IP. For more information, see <xref:blazor/security/webassembly/index#authentication-library>.

# [Visual Studio](#tab/visual-studio)

To create a new Blazor WebAssembly project with an authentication mechanism:

1. After choosing the **Blazor WebAssembly App** template in the **Create a new ASP.NET Core Web Application** dialog, select **Change** under **Authentication**.

1. Select **Individual User Accounts** to use ASP.NET Core's [Identity](xref:security/authentication/identity) system. This selection adds authentication support and doesn't result in storing users in a database. The following sections of this article provide further details.

# [Visual Studio Code / .NET Core CLI](#tab/visual-studio-code+netcore-cli)

Create a new Blazor WebAssembly project with an authentication mechanism in an empty folder. Specify the `Individual` authentication mechanism with the `-au|--auth` option to use ASP.NET Core's [Identity](xref:security/authentication/identity) system. This selection adds authentication support and doesn't result in storing users in a database. The following sections of this article provide further details.

```dotnetcli
dotnet new blazorwasm -au Individual -o {APP NAME}
```

| Placeholder  | Example        |
| ------------ | -------------- |
| `{APP NAME}` | `BlazorSample` |

The output location specified with the `-o|--output` option creates a project folder if it doesn't exist and becomes part of the app's name.

For more information, see the [`dotnet new`](/dotnet/core/tools/dotnet-new) command in the .NET Core Guide.

# [Visual Studio for Mac](#tab/visual-studio-mac)

To create a new Blazor WebAssembly project with an authentication mechanism:

1. On the **Configure your new Blazor WebAssembly App** step, select **Individual Authentication (in-app)** from the **Authentication** drop down.

1. The app is created to use ASP.NET Core [Identity](xref:security/authentication/identity) and doesn't result in storing users in a database. The following sections of this article provide further details.

---

## Authentication package

When an app is created to use Individual User Accounts, the app automatically receives a package reference for the [`Microsoft.AspNetCore.Components.WebAssembly.Authentication`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Authentication) package. The package provides a set of primitives that help the app authenticate users and obtain tokens to call protected APIs.

If adding authentication to an app, manually add the [`Microsoft.AspNetCore.Components.WebAssembly.Authentication`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Authentication) package to the app.

[!INCLUDE[](~/includes/package-reference.md)]

## Authentication service support

Support for authenticating users is registered in the service container with the <xref:Microsoft.Extensions.DependencyInjection.WebAssemblyAuthenticationServiceCollectionExtensions.AddOidcAuthentication%2A> extension method provided by the [`Microsoft.AspNetCore.Components.WebAssembly.Authentication`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Authentication) package. This method sets up the services required for the app to interact with the Identity Provider (IP).

For a new app, provide values for the `{AUTHORITY}` and `{CLIENT ID}` placeholders in the following configuration. Provide other configuration values that are required for use with the app's IP. The example is for Google, which requires `PostLogoutRedirectUri`, `RedirectUri`, and `ResponseType`. If adding authentication to an app, manually add the following code and configuration to the app with values for the placeholders and other configuration values.

`Program.cs`:

```csharp
builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("Local", options.ProviderOptions);
});
```

Configuration is supplied by the `wwwroot/appsettings.json` file:

```json
{
  "Local": {
    "Authority": "{AUTHORITY}",
    "ClientId": "{CLIENT ID}"
  }
}
```

Google OAuth 2.0 OIDC example:

```json
{
  "Local": {
    "Authority": "https://accounts.google.com/",
    "ClientId": "2.......7-e.....................q.apps.googleusercontent.com",
    "PostLogoutRedirectUri": "https://localhost:5001/authentication/logout-callback",
    "RedirectUri": "https://localhost:5001/authentication/login-callback",
    "ResponseType": "id_token"
  }
}
```

The redirect URI (`https://localhost:5001/authentication/login-callback`) is registered in the [Google APIs console](https://console.developers.google.com/apis/dashboard) in **Credentials** > **`{NAME}`** > **Authorized redirect URIs**, where `{NAME}` is the app's client name in the **OAuth 2.0 Client IDs** app list of the Google APIs console.

Authentication support for standalone apps is offered using OpenID Connect (OIDC). The <xref:Microsoft.Extensions.DependencyInjection.WebAssemblyAuthenticationServiceCollectionExtensions.AddOidcAuthentication%2A> method accepts a callback to configure the parameters required to authenticate an app using OIDC. The values required for configuring the app can be obtained from the OIDC-compliant IP. Obtain the values when you register the app, which typically occurs in their online portal.

## Access token scopes

The Blazor WebAssembly template automatically configures default scopes for `openid` and `profile`.

The Blazor WebAssembly template doesn't automatically configure the app to request an access token for a secure API. To provision an access token as part of the sign-in flow, add the scope to the default token scopes of the <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.OidcProviderOptions>. If adding authentication to an app, manually add the following code and configure the scope URI.

`Program.cs`:

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

## Imports file

[!INCLUDE[](~/blazor/security/includes/imports-file-standalone.md)]

## Index page

[!INCLUDE[](~/blazor/security/includes/index-page-authentication.md)]

## App component

[!INCLUDE[](~/blazor/security/includes/app-component.md)]

## RedirectToLogin component

[!INCLUDE[](~/blazor/security/includes/redirecttologin-component.md)]

## LoginDisplay component

The `LoginDisplay` component (`Shared/LoginDisplay.razor`) is rendered in the `MainLayout` component (`Shared/MainLayout.razor`) and manages the following behaviors:

* For authenticated users:
  * Displays the current username.
  * Offers a button to log out of the app.
* For anonymous users, offers the option to log in.

```razor
@using Microsoft.AspNetCore.Components.Authorization
@using Microsoft.AspNetCore.Components.WebAssembly.Authentication
@inject NavigationManager Navigation
@inject SignOutSessionStateManager SignOutManager

<AuthorizeView>
    <Authorized>
        Hello, @context.User.Identity.Name!
        <button class="nav-link btn btn-link" @onclick="BeginSignOut">
            Log out
        </button>
    </Authorized>
    <NotAuthorized>
        <a href="authentication/login">Log in</a>
    </NotAuthorized>
</AuthorizeView>

@code {
    private async Task BeginSignOut(MouseEventArgs args)
    {
        await SignOutManager.SetSignOutState();
        Navigation.NavigateTo("authentication/logout");
    }
}
```

## Authentication component

[!INCLUDE[](~/blazor/security/includes/authentication-component.md)]

[!INCLUDE[](~/blazor/security/includes/troubleshoot.md)]

## Additional resources

* <xref:blazor/security/webassembly/additional-scenarios>
* [Unauthenticated or unauthorized web API requests in an app with a secure default client](xref:blazor/security/webassembly/additional-scenarios#unauthenticated-or-unauthorized-web-api-requests-in-an-app-with-a-secure-default-client)
* <xref:host-and-deploy/proxy-load-balancer>: Includes guidance on:
  * Using Forwarded Headers Middleware to preserve HTTPS scheme information across proxy servers and internal networks.
  * Additional scenarios and use cases, including manual scheme configuration, request path changes for correct request routing, and forwarding the request scheme for Linux and non-IIS reverse proxies.

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

*For Azure Active Directory (AAD) and Azure Active Directory B2C (AAD B2C), don't follow the guidance in this topic. See the AAD and AAD B2C topics in this table of contents node.*

To create a [standalone Blazor WebAssembly app](xref:blazor/hosting-models#blazor-webassembly) that uses [`Microsoft.AspNetCore.Components.WebAssembly.Authentication`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Authentication) library, follow the guidance for your choice of tooling. If adding support for authentication, see the following sections of this article for guidance on setting up and configuring the app.

> [!NOTE]
> The Identity Provider (IP) must use [OpenID Connect (OIDC)](https://openid.net/connect/). For example, Facebook's IP isn't an OIDC-compliant provider, so the guidance in this topic doesn't work with the Facebook IP. For more information, see <xref:blazor/security/webassembly/index#authentication-library>.

# [Visual Studio](#tab/visual-studio)

To create a new Blazor WebAssembly project with an authentication mechanism:

1. After choosing the **Blazor WebAssembly App** template in the **Create a new ASP.NET Core Web Application** dialog, select **Change** under **Authentication**.

1. Select **Individual User Accounts** to use ASP.NET Core's [Identity](xref:security/authentication/identity) system. This selection adds authentication support and doesn't result in storing users in a database. The following sections of this article provide further details.

# [Visual Studio Code / .NET Core CLI](#tab/visual-studio-code+netcore-cli)

Create a new Blazor WebAssembly project with an authentication mechanism in an empty folder. Specify the `Individual` authentication mechanism with the `-au|--auth` option to use ASP.NET Core's [Identity](xref:security/authentication/identity) system. This selection adds authentication support and doesn't result in storing users in a database. The following sections of this article provide further details.

```dotnetcli
dotnet new blazorwasm -au Individual -o {APP NAME}
```

| Placeholder  | Example        |
| ------------ | -------------- |
| `{APP NAME}` | `BlazorSample` |

The output location specified with the `-o|--output` option creates a project folder if it doesn't exist and becomes part of the app's name.

For more information, see the [`dotnet new`](/dotnet/core/tools/dotnet-new) command in the .NET Core Guide.

# [Visual Studio for Mac](#tab/visual-studio-mac)

To create a new Blazor WebAssembly project with an authentication mechanism:

1. On the **Configure your new Blazor WebAssembly App** step, select **Individual Authentication (in-app)** from the **Authentication** drop down.

1. The app is created to use ASP.NET Core [Identity](xref:security/authentication/identity) and doesn't result in storing users in a database. The following sections of this article provide further details.

---

## Authentication package

When an app is created to use Individual User Accounts, the app automatically receives a package reference for the [`Microsoft.AspNetCore.Components.WebAssembly.Authentication`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Authentication) package. The package provides a set of primitives that help the app authenticate users and obtain tokens to call protected APIs.

If adding authentication to an app, manually add the [`Microsoft.AspNetCore.Components.WebAssembly.Authentication`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Authentication) package to the app.

[!INCLUDE[](~/includes/package-reference.md)]

## Authentication service support

Support for authenticating users is registered in the service container with the <xref:Microsoft.Extensions.DependencyInjection.WebAssemblyAuthenticationServiceCollectionExtensions.AddOidcAuthentication%2A> extension method provided by the [`Microsoft.AspNetCore.Components.WebAssembly.Authentication`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Authentication) package. This method sets up the services required for the app to interact with the Identity Provider (IP).

For a new app, provide values for the `{AUTHORITY}` and `{CLIENT ID}` placeholders in the following configuration. Provide other configuration values that are required for use with the app's IP. The example is for Google, which requires `PostLogoutRedirectUri`, `RedirectUri`, and `ResponseType`. If adding authentication to an app, manually add the following code and configuration to the app with values for the placeholders and other configuration values.

`Program.cs`:

```csharp
builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("Local", options.ProviderOptions);
});
```

Configuration is supplied by the `wwwroot/appsettings.json` file:

```json
{
  "Local": {
    "Authority": "{AUTHORITY}",
    "ClientId": "{CLIENT ID}"
  }
}
```

Google OAuth 2.0 OIDC example:

```json
{
  "Local": {
    "Authority": "https://accounts.google.com/",
    "ClientId": "2.......7-e.....................q.apps.googleusercontent.com",
    "PostLogoutRedirectUri": "https://localhost:5001/authentication/logout-callback",
    "RedirectUri": "https://localhost:5001/authentication/login-callback",
    "ResponseType": "id_token"
  }
}
```

The redirect URI (`https://localhost:5001/authentication/login-callback`) is registered in the [Google APIs console](https://console.developers.google.com/apis/dashboard) in **Credentials** > **`{NAME}`** > **Authorized redirect URIs**, where `{NAME}` is the app's client name in the **OAuth 2.0 Client IDs** app list of the Google APIs console.

Authentication support for standalone apps is offered using OpenID Connect (OIDC). The <xref:Microsoft.Extensions.DependencyInjection.WebAssemblyAuthenticationServiceCollectionExtensions.AddOidcAuthentication%2A> method accepts a callback to configure the parameters required to authenticate an app using OIDC. The values required for configuring the app can be obtained from the OIDC-compliant IP. Obtain the values when you register the app, which typically occurs in their online portal.

## Access token scopes

The Blazor WebAssembly template automatically configures default scopes for `openid` and `profile`.

The Blazor WebAssembly template doesn't automatically configure the app to request an access token for a secure API. To provision an access token as part of the sign-in flow, add the scope to the default token scopes of the <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.OidcProviderOptions>. If adding authentication to an app, manually add the following code and configure the scope URI.

`Program.cs`:

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

## Imports file

[!INCLUDE[](~/blazor/security/includes/imports-file-standalone.md)]

## Index page

[!INCLUDE[](~/blazor/security/includes/index-page-authentication.md)]

## App component

[!INCLUDE[](~/blazor/security/includes/app-component.md)]

## RedirectToLogin component

[!INCLUDE[](~/blazor/security/includes/redirecttologin-component.md)]

## LoginDisplay component

The `LoginDisplay` component (`Shared/LoginDisplay.razor`) is rendered in the `MainLayout` component (`Shared/MainLayout.razor`) and manages the following behaviors:

* For authenticated users:
  * Displays the current username.
  * Offers a button to log out of the app.
* For anonymous users, offers the option to log in.

```razor
@using Microsoft.AspNetCore.Components.Authorization
@using Microsoft.AspNetCore.Components.WebAssembly.Authentication
@inject NavigationManager Navigation
@inject SignOutSessionStateManager SignOutManager

<AuthorizeView>
    <Authorized>
        Hello, @context.User.Identity.Name!
        <button class="nav-link btn btn-link" @onclick="BeginSignOut">
            Log out
        </button>
    </Authorized>
    <NotAuthorized>
        <a href="authentication/login">Log in</a>
    </NotAuthorized>
</AuthorizeView>

@code {
    private async Task BeginSignOut(MouseEventArgs args)
    {
        await SignOutManager.SetSignOutState();
        Navigation.NavigateTo("authentication/logout");
    }
}
```

## Authentication component

[!INCLUDE[](~/blazor/security/includes/authentication-component.md)]

[!INCLUDE[](~/blazor/security/includes/troubleshoot.md)]

## Additional resources

* <xref:blazor/security/webassembly/additional-scenarios>
* [Unauthenticated or unauthorized web API requests in an app with a secure default client](xref:blazor/security/webassembly/additional-scenarios#unauthenticated-or-unauthorized-web-api-requests-in-an-app-with-a-secure-default-client)
* <xref:host-and-deploy/proxy-load-balancer>: Includes guidance on:
  * Using Forwarded Headers Middleware to preserve HTTPS scheme information across proxy servers and internal networks.
  * Additional scenarios and use cases, including manual scheme configuration, request path changes for correct request routing, and forwarding the request scheme for Linux and non-IIS reverse proxies.

:::moniker-end

:::moniker range="< aspnetcore-5.0"

*For Azure Active Directory (AAD) and Azure Active Directory B2C (AAD B2C), don't follow the guidance in this topic. See the AAD and AAD B2C topics in this table of contents node.*

To create a [standalone Blazor WebAssembly app](xref:blazor/hosting-models#blazor-webassembly) that uses [`Microsoft.AspNetCore.Components.WebAssembly.Authentication`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Authentication) library, follow the guidance for your choice of tooling. If adding support for authentication, see the following sections of this article for guidance on setting up and configuring the app.

> [!NOTE]
> The Identity Provider (IP) must use [OpenID Connect (OIDC)](https://openid.net/connect/). For example, Facebook's IP isn't an OIDC-compliant provider, so the guidance in this topic doesn't work with the Facebook IP. For more information, see <xref:blazor/security/webassembly/index#authentication-library>.

# [Visual Studio](#tab/visual-studio)

To create a new Blazor WebAssembly project with an authentication mechanism:

1. After choosing the **Blazor WebAssembly App** template in the **Create a new ASP.NET Core Web Application** dialog, select **Change** under **Authentication**.

1. Select **Individual User Accounts** to use ASP.NET Core's [Identity](xref:security/authentication/identity) system. This selection adds authentication support and doesn't result in storing users in a database. The following sections of this article provide further details.

# [Visual Studio Code / .NET Core CLI](#tab/visual-studio-code+netcore-cli)

Create a new Blazor WebAssembly project with an authentication mechanism in an empty folder. Specify the `Individual` authentication mechanism with the `-au|--auth` option to use ASP.NET Core's [Identity](xref:security/authentication/identity) system. This selection adds authentication support and doesn't result in storing users in a database. The following sections of this article provide further details.

```dotnetcli
dotnet new blazorwasm -au Individual -o {APP NAME}
```

| Placeholder  | Example        |
| ------------ | -------------- |
| `{APP NAME}` | `BlazorSample` |

The output location specified with the `-o|--output` option creates a project folder if it doesn't exist and becomes part of the app's name.

For more information, see the [`dotnet new`](/dotnet/core/tools/dotnet-new) command in the .NET Core Guide.

# [Visual Studio for Mac](#tab/visual-studio-mac)

To create a new Blazor WebAssembly project with an authentication mechanism:

1. On the **Configure your new Blazor WebAssembly App** step, select **Individual Authentication (in-app)** from the **Authentication** drop down.

1. The app is created to use ASP.NET Core [Identity](xref:security/authentication/identity) and doesn't result in storing users in a database. The following sections of this article provide further details.

---

## Authentication package

When an app is created to use Individual User Accounts, the app automatically receives a package reference for the [`Microsoft.AspNetCore.Components.WebAssembly.Authentication`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Authentication) package. The package provides a set of primitives that help the app authenticate users and obtain tokens to call protected APIs.

If adding authentication to an app, manually add the [`Microsoft.AspNetCore.Components.WebAssembly.Authentication`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Authentication) package to the app.

[!INCLUDE[](~/includes/package-reference.md)]

## Authentication service support

Support for authenticating users is registered in the service container with the <xref:Microsoft.Extensions.DependencyInjection.WebAssemblyAuthenticationServiceCollectionExtensions.AddOidcAuthentication%2A> extension method provided by the [`Microsoft.AspNetCore.Components.WebAssembly.Authentication`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Authentication) package. This method sets up the services required for the app to interact with the Identity Provider (IP).

For a new app, provide values for the `{AUTHORITY}` and `{CLIENT ID}` placeholders in the following configuration. Provide other configuration values that are required for use with the app's IP. The example is for Google, which requires `PostLogoutRedirectUri`, `RedirectUri`, and `ResponseType`. If adding authentication to an app, manually add the following code and configuration to the app with values for the placeholders and other configuration values.

`Program.cs`:

```csharp
builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("Local", options.ProviderOptions);
});
```

Configuration is supplied by the `wwwroot/appsettings.json` file:

```json
{
  "Local": {
    "Authority": "{AUTHORITY}",
    "ClientId": "{CLIENT ID}"
  }
}
```

Google OAuth 2.0 OIDC example:

```json
{
  "Local": {
    "Authority": "https://accounts.google.com/",
    "ClientId": "2.......7-e.....................q.apps.googleusercontent.com",
    "PostLogoutRedirectUri": "https://localhost:5001/authentication/logout-callback",
    "RedirectUri": "https://localhost:5001/authentication/login-callback",
    "ResponseType": "id_token"
  }
}
```

The redirect URI (`https://localhost:5001/authentication/login-callback`) is registered in the [Google APIs console](https://console.developers.google.com/apis/dashboard) in **Credentials** > **`{NAME}`** > **Authorized redirect URIs**, where `{NAME}` is the app's client name in the **OAuth 2.0 Client IDs** app list of the Google APIs console.

Authentication support for standalone apps is offered using OpenID Connect (OIDC). The <xref:Microsoft.Extensions.DependencyInjection.WebAssemblyAuthenticationServiceCollectionExtensions.AddOidcAuthentication%2A> method accepts a callback to configure the parameters required to authenticate an app using OIDC. The values required for configuring the app can be obtained from the OIDC-compliant IP. Obtain the values when you register the app, which typically occurs in their online portal.

## Access token scopes

The Blazor WebAssembly template automatically configures default scopes for `openid` and `profile`.

The Blazor WebAssembly template doesn't automatically configure the app to request an access token for a secure API. To provision an access token as part of the sign-in flow, add the scope to the default token scopes of the <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.OidcProviderOptions>. If adding authentication to an app, manually add the following code and configure the scope URI.

`Program.cs`:

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

## Imports file

[!INCLUDE[](~/blazor/security/includes/imports-file-standalone.md)]

## Index page

[!INCLUDE[](~/blazor/security/includes/index-page-authentication.md)]

## App component

[!INCLUDE[](~/blazor/security/includes/app-component.md)]

## RedirectToLogin component

[!INCLUDE[](~/blazor/security/includes/redirecttologin-component.md)]

## LoginDisplay component

The `LoginDisplay` component (`Shared/LoginDisplay.razor`) is rendered in the `MainLayout` component (`Shared/MainLayout.razor`) and manages the following behaviors:

* For authenticated users:
  * Displays the current username.
  * Offers a button to log out of the app.
* For anonymous users, offers the option to log in.

```razor
@using Microsoft.AspNetCore.Components.Authorization
@using Microsoft.AspNetCore.Components.WebAssembly.Authentication
@inject NavigationManager Navigation
@inject SignOutSessionStateManager SignOutManager

<AuthorizeView>
    <Authorized>
        Hello, @context.User.Identity.Name!
        <button class="nav-link btn btn-link" @onclick="BeginSignOut">
            Log out
        </button>
    </Authorized>
    <NotAuthorized>
        <a href="authentication/login">Log in</a>
    </NotAuthorized>
</AuthorizeView>

@code {
    private async Task BeginSignOut(MouseEventArgs args)
    {
        await SignOutManager.SetSignOutState();
        Navigation.NavigateTo("authentication/logout");
    }
}
```

## Authentication component

[!INCLUDE[](~/blazor/security/includes/authentication-component.md)]

[!INCLUDE[](~/blazor/security/includes/troubleshoot.md)]

## Additional resources

* <xref:blazor/security/webassembly/additional-scenarios>
* [Unauthenticated or unauthorized web API requests in an app with a secure default client](xref:blazor/security/webassembly/additional-scenarios#unauthenticated-or-unauthorized-web-api-requests-in-an-app-with-a-secure-default-client)
* <xref:host-and-deploy/proxy-load-balancer>: Includes guidance on:
  * Using Forwarded Headers Middleware to preserve HTTPS scheme information across proxy servers and internal networks.
  * Additional scenarios and use cases, including manual scheme configuration, request path changes for correct request routing, and forwarding the request scheme for Linux and non-IIS reverse proxies.

:::moniker-end
