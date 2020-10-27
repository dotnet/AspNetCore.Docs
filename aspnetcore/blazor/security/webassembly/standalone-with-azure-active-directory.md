---
title: Secure an ASP.NET Core Blazor WebAssembly standalone app with Azure Active Directory
author: guardrex
description: Learn how to secure an ASP.NET Core Blazor WebAssembly standalone app with Azure Active Directory.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: "devx-track-csharp, mvc"
ms.date: 10/27/2020
no-loc: [appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/security/webassembly/standalone-with-azure-active-directory
---
# Secure an ASP.NET Core Blazor WebAssembly standalone app with Azure Active Directory

By [Javier Calvarro Nelson](https://github.com/javiercn) and [Luke Latham](https://github.com/guardrex)

This article covers how to secure an ASP.NET Core Blazor WebAssembly standalone app with Azure Active Directory (AAD).

::: moniker range=">= aspnetcore-5.0"

> [!NOTE]
> For Blazor WebAssembly apps created in Visual Studio that are configured to support accounts in an AAD organizational directory, Visual Studio doesn't configure the app correctly on project generation. This will be addressed in a future release of Visual Studio. This article shows how to create the app with the .NET Core CLI's `dotnet new` command. If you prefer to create the app with Visual Studio before the IDE is updated for the latest Blazor templates in ASP.NET Core 5.0, refer to each section of this article and confirm or update the app's configuration after Visual Studio creates the app.

::: moniker-end

To create a [standalone Blazor WebAssembly app](xref:blazor/hosting-models#blazor-webassembly) that uses [Azure Active Directory (AAD)](https://azure.microsoft.com/services/active-directory/) for authentication:

[Create an AAD tenant and web application](/azure/active-directory/develop/v2-overview):

Register a AAD app in the **Azure Active Directory** > **App registrations** area of the Azure portal:

::: moniker range=">= aspnetcore-5.0"

1. Provide a **Name** for the app (for example, **Blazor Standalone AAD**).
1. Choose a **Supported account types**. You may select **Accounts in this organizational directory only** for this experience.
1. Set the **Redirect URI** drop down to **Single-page application (SPA)** and provide the following redirect URI: `https://localhost:{PORT}/authentication/login-callback`. The default port for an app running on Kestrel is 5001. If the app is run on a different Kestrel port, use the app's port. For IIS Express, the randomly generated port for the app can be found in the app's properties in the **Debug** panel. Since the app doesn't exist at this point and the IIS Express port isn't known, return to this step after the app is created and update the redirect URI. A remark appears later in this topic to remind IIS Express users to update the redirect URI.
1. Clear the **Permissions** > **Grant admin consent to openid and offline_access permissions** check box.
1. Select **Register**.

Record the following information:

* Application (client) ID (for example, `41451fa7-82d9-4673-8fa5-69eff5a761fd`)
* Directory (tenant) ID (for example, `e86c78e2-8bb4-4c41-aefd-918e0565a45e`)

In **Authentication** > **Platform configurations** > **Single-page application (SPA)**:

1. Confirm the **Redirect URI** of `https://localhost:{PORT}/authentication/login-callback` is present.
1. For **Implicit grant**, ensure that the check boxes for **Access tokens** and **ID tokens** are **not** selected.
1. The remaining defaults for the app are acceptable for this experience.
1. Select the **Save** button.

::: moniker-end

::: moniker range="< aspnetcore-5.0"

1. Provide a **Name** for the app (for example, **Blazor Standalone AAD**).
1. Choose a **Supported account types**. You may select **Accounts in this organizational directory only** for this experience.
1. Leave the **Redirect URI** drop down set to **Web** and provide the following redirect URI: `https://localhost:{PORT}/authentication/login-callback`. The default port for an app running on Kestrel is 5001. If the app is run on a different Kestrel port, use the app's port. For IIS Express, the randomly generated port for the app can be found in the app's properties in the **Debug** panel. Since the app doesn't exist at this point and the IIS Express port isn't known, return to this step after the app is created and update the redirect URI. A remark appears later in this topic to remind IIS Express users to update the redirect URI.
1. Clear the **Permissions** > **Grant admin consent to openid and offline_access permissions** check box.
1. Select **Register**.

Record the following information:

* Application (client) ID (for example, `41451fa7-82d9-4673-8fa5-69eff5a761fd`)
* Directory (tenant) ID (for example, `e86c78e2-8bb4-4c41-aefd-918e0565a45e`)

In **Authentication** > **Platform configurations** > **Web**:

1. Confirm the **Redirect URI** of `https://localhost:{PORT}/authentication/login-callback` is present.
1. For **Implicit grant**, select the check boxes for **Access tokens** and **ID tokens**.
1. The remaining defaults for the app are acceptable for this experience.
1. Select the **Save** button.

::: moniker-end

Create the app in an empty folder. Replace the placeholders in the following command with the information recorded earlier and execute the command in a command shell:

```dotnetcli
dotnet new blazorwasm -au SingleOrg --client-id "{CLIENT ID}" -o {APP NAME} --tenant-id "{TENANT ID}"
```

| Placeholder   | Azure portal name       | Example                                |
| ------------- | ----------------------- | -------------------------------------- |
| `{APP NAME}`  | &mdash;                 | `BlazorSample`                         |
| `{CLIENT ID}` | Application (client) ID | `41451fa7-82d9-4673-8fa5-69eff5a761fd` |
| `{TENANT ID}` | Directory (tenant) ID   | `e86c78e2-8bb4-4c41-aefd-918e0565a45e` |

The output location specified with the `-o|--output` option creates a project folder if it doesn't exist and becomes part of the app's name.

> [!NOTE]
> In the Azure portal, the app's platform configuration **Redirect URI** is configured for port 5001 for apps that run on the Kestrel server with default settings.
>
> If the app is run on a random IIS Express port, the port for the app can be found in the app's properties in the **Debug** panel.
>
> If the port wasn't configured earlier with the app's known port, return to the app's registration in the Azure portal and update the redirect URI with the correct port.

::: moniker range=">= aspnetcore-5.0"

[!INCLUDE[](~/includes/blazor-security/additional-scopes-standalone-AAD.md)]

::: moniker-end

After creating the app, you should be able to:

* Log into the app using an AAD user account.
* Request access tokens for Microsoft APIs. For more information, see:
  * [Access token scopes](#access-token-scopes)
  * [Quickstart: Configure an application to expose web APIs](/azure/active-directory/develop/quickstart-configure-app-expose-web-apis).

## Authentication package

When an app is created to use Work or School Accounts (`SingleOrg`), the app automatically receives a package reference for the [Microsoft Authentication Library](/azure/active-directory/develop/msal-overview) ([`Microsoft.Authentication.WebAssembly.Msal`](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal)). The package provides a set of primitives that help the app authenticate users and obtain tokens to call protected APIs.

If adding authentication to an app, manually add the package to the app's project file:

```xml
<PackageReference Include="Microsoft.Authentication.WebAssembly.Msal" 
  Version="{VERSION}" />
```

For the placeholder `{VERSION}`, the latest stable version of the package that matches the app's shared framework version can be found in the package's **Version History** at [NuGet.org](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal).

The [`Microsoft.Authentication.WebAssembly.Msal`](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal) package transitively adds the [`Microsoft.AspNetCore.Components.WebAssembly.Authentication`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Authentication) package to the app.

## Authentication service support

Support for authenticating users is registered in the service container with the <xref:Microsoft.Extensions.DependencyInjection.MsalWebAssemblyServiceCollectionExtensions.AddMsalAuthentication%2A> extension method provided by the [`Microsoft.Authentication.WebAssembly.Msal`](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal) package. This method sets up the services required for the app to interact with the Identity Provider (IP).

`Program.cs`:

```csharp
builder.Services.AddMsalAuthentication(options =>
{
    builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
});
```

The <xref:Microsoft.Extensions.DependencyInjection.MsalWebAssemblyServiceCollectionExtensions.AddMsalAuthentication%2A> method accepts a callback to configure the parameters required to authenticate an app. The values required for configuring the app can be obtained from the AAD configuration when you register the app.

Configuration is supplied by the `wwwroot/appsettings.json` file:

```json
{
  "AzureAd": {
    "Authority": "https://login.microsoftonline.com/{TENANT ID}",
    "ClientId": "{CLIENT ID}",
    "ValidateAuthority": true
  }
}
```

Example:

```json
{
  "AzureAd": {
    "Authority": "https://login.microsoftonline.com/e86c78e2-...-918e0565a45e",
    "ClientId": "41451fa7-82d9-4673-8fa5-69eff5a761fd",
    "ValidateAuthority": true
  }
}
```

## Access token scopes

The Blazor WebAssembly template doesn't automatically configure the app to request an access token for a secure API. To provision an access token as part of the sign-in flow, add the scope to the default access token scopes of the <xref:Microsoft.Authentication.WebAssembly.Msal.Models.MsalProviderOptions>:

```csharp
builder.Services.AddMsalAuthentication(options =>
{
    ...
    options.ProviderOptions.DefaultAccessTokenScopes.Add("{SCOPE URI}");
});
```

Specify additional scopes with `AdditionalScopesToConsent`:

```csharp
options.ProviderOptions.AdditionalScopesToConsent.Add("{ADDITIONAL SCOPE URI}");
```

::: moniker range="< aspnetcore-5.0"

[!INCLUDE[](~/includes/blazor-security/azure-scope-3x.md)]

::: moniker-end

For more information, see the following sections of the *Additional scenarios* article:

* [Request additional access tokens](xref:blazor/security/webassembly/additional-scenarios#request-additional-access-tokens)
* [Attach tokens to outgoing requests](xref:blazor/security/webassembly/additional-scenarios#attach-tokens-to-outgoing-requests)

::: moniker range=">= aspnetcore-5.0"

## Login mode

[!INCLUDE[](~/includes/blazor-security/msal-login-mode.md)]

::: moniker-end

## Imports file

[!INCLUDE[](~/includes/blazor-security/imports-file-standalone.md)]

## Index page

[!INCLUDE[](~/includes/blazor-security/index-page-msal.md)]

## App component

[!INCLUDE[](~/includes/blazor-security/app-component.md)]

## RedirectToLogin component

[!INCLUDE[](~/includes/blazor-security/redirecttologin-component.md)]

## LoginDisplay component

[!INCLUDE[](~/includes/blazor-security/logindisplay-component.md)]

## Authentication component

[!INCLUDE[](~/includes/blazor-security/authentication-component.md)]

[!INCLUDE[](~/includes/blazor-security/troubleshoot.md)]

## Additional resources

* <xref:blazor/security/webassembly/additional-scenarios>
* [Unauthenticated or unauthorized web API requests in an app with a secure default client](xref:blazor/security/webassembly/additional-scenarios#unauthenticated-or-unauthorized-web-api-requests-in-an-app-with-a-secure-default-client)
* <xref:blazor/security/webassembly/aad-groups-roles>
* <xref:security/authentication/azure-active-directory/index>
* [Microsoft identity platform documentation](/azure/active-directory/develop/)
