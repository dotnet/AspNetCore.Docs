---
title: Secure an ASP.NET Core Blazor WebAssembly standalone app with Microsoft Entra ID
author: guardrex
description: Learn how to secure an ASP.NET Core Blazor WebAssembly standalone app with Microsoft Entra ID.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: "devx-track-csharp, mvc"
ms.date: 11/14/2023
uid: blazor/security/webassembly/standalone-with-microsoft-entra-id
---
# Secure an ASP.NET Core Blazor WebAssembly standalone app with Microsoft Entra ID

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how to create a [standalone Blazor WebAssembly app](xref:blazor/hosting-models#blazor-webassembly) that uses [Microsoft Entra ID (ME-ID)](https://azure.microsoft.com/services/active-directory/) for authentication.

For additional security scenario coverage after reading this article, see <xref:blazor/security/webassembly/additional-scenarios>.

## Walkthrough

The subsections of the walkthrough explain how to:

* Create a tenant in Azure
* Register an app in Azure
* Create the Blazor app
* Run the app

### Create a tenant in Azure

Follow the guidance in [Quickstart: Set up a tenant](/entra/identity-platform/quickstart-create-new-tenant) to create a tenant in ME-ID.

### Register an app in Azure

Register an ME-ID app:

1. Navigate to [**Microsoft Entra ID** in the Azure portal](https://entra.microsoft.com/#home). Select **Applications** > **App registrations** in the sidebar. Select the **New registration** button.
1. Provide a **Name** for the app (for example, **Blazor Standalone ME-ID**).
1. Choose a **Supported account types**. You may select **Accounts in this organizational directory only** for this experience.
1. Set the **Redirect URI** dropdown list to **Single-page application (SPA)** and provide the following redirect URI: `https://localhost/authentication/login-callback`. If you know the production redirect URI for the Azure default host (for example, `azurewebsites.net`) or the custom domain host (for example, `contoso.com`), you can also add the production redirect URI at the same time that you're providing the `localhost` redirect URI. Be sure to include the port number for non-`:443` ports in any production redirect URIs that you add.
1. If you're using an [unverified publisher domain](/entra/identity-platform/howto-configure-publisher-domain), clear the **Permissions** > **Grant admin consent to openid and offline_access permissions** checkbox. If the publisher domain is verified, this checkbox isn't present.
1. Select **Register**.

> [!NOTE]
> Supplying the port number for a `localhost` ME-ID redirect URI isn't required. For more information, see [Redirect URI (reply URL) restrictions and limitations: Localhost exceptions (Entra documentation)](/entra/identity-platform/reply-url#localhost-exceptions).

Record the following information:

* Application (client) ID (for example, `41451fa7-82d9-4673-8fa5-69eff5a761fd`)
* Directory (tenant) ID (for example, `e86c78e2-8bb4-4c41-aefd-918e0565a45e`)

In **Authentication** > **Platform configurations** > **Single-page application**:

1. Confirm the redirect URI of `https://localhost/authentication/login-callback` is present.
1. In the **Implicit grant** section, ensure that the checkboxes for **Access tokens** and **ID tokens** aren't selected. **Implicit grant isn't recommended for Blazor apps using MSAL v2.0 or later.** For more information, see <xref:blazor/security/webassembly/index#use-the-authorization-code-flow-with-pkce>.
1. The remaining defaults for the app are acceptable for this experience.
1. Select the **Save** button if you made changes.

### Create the Blazor app

Create the app in an empty folder. Replace the placeholders in the following command with the information recorded earlier and execute the command in a command shell:

```dotnetcli
dotnet new blazorwasm -au SingleOrg --client-id "{CLIENT ID}" -o {PROJECT NAME} --tenant-id "{TENANT ID}"
```

| Placeholder      | Azure portal name       | Example                                |
| ---------------- | ----------------------- | -------------------------------------- |
| `{PROJECT NAME}` | &mdash;                 | `BlazorSample`                         |
| `{CLIENT ID}`    | Application (client) ID | `41451fa7-82d9-4673-8fa5-69eff5a761fd` |
| `{TENANT ID}`    | Directory (tenant) ID   | `e86c78e2-8bb4-4c41-aefd-918e0565a45e` |

The output location specified with the `-o|--output` option creates a project folder if it doesn't exist and becomes part of the project's name.

[!INCLUDE[](~/blazor/security/includes/additional-scopes-standalone-MEID.md)]

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

When an app is created to use Work or School Accounts (`SingleOrg`), the app automatically receives a package reference for the [Microsoft Authentication Library](/entra/identity-platform/msal-overview) ([`Microsoft.Authentication.WebAssembly.Msal`](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal)). The package provides a set of primitives that help the app authenticate users and obtain tokens to call protected APIs.

If adding authentication to an app, manually add the [`Microsoft.Authentication.WebAssembly.Msal`](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal) package to the app.

[!INCLUDE[](~/includes/package-reference.md)]

The [`Microsoft.Authentication.WebAssembly.Msal`](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal) package transitively adds the [`Microsoft.AspNetCore.Components.WebAssembly.Authentication`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Authentication) package to the app.

### Authentication service support

Support for authenticating users is registered in the service container with the <xref:Microsoft.Extensions.DependencyInjection.MsalWebAssemblyServiceCollectionExtensions.AddMsalAuthentication%2A> extension method provided by the [`Microsoft.Authentication.WebAssembly.Msal`](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal) package. This method sets up the services required for the app to interact with the Identity Provider (IP).

In the `Program` file:

```csharp
builder.Services.AddMsalAuthentication(options =>
{
    builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
});
```

The <xref:Microsoft.Extensions.DependencyInjection.MsalWebAssemblyServiceCollectionExtensions.AddMsalAuthentication%2A> method accepts a callback to configure the parameters required to authenticate an app. The values required for configuring the app can be obtained from the ME-ID configuration when you register the app.

### `wwwroot/appsettings.json` configuration

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

### Access token scopes

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

For more information, see the following resources:

* [Request additional access tokens](xref:blazor/security/webassembly/additional-scenarios#request-additional-access-tokens)
* [Attach tokens to outgoing requests](xref:blazor/security/webassembly/additional-scenarios#attach-tokens-to-outgoing-requests)
* [Quickstart: Configure an application to expose web APIs](/entra/identity-platform/quickstart-configure-app-expose-web-apis)
* [Access token scopes for Microsoft Graph API](xref:blazor/security/webassembly/graph-api)

### Login mode

[!INCLUDE[](~/blazor/security/includes/msal-login-mode.md)]

### Imports file

[!INCLUDE[](~/blazor/security/includes/imports-file-standalone.md)]

### Index page

[!INCLUDE[](~/blazor/security/includes/index-page-msal.md)]

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
* [Build a custom version of the Authentication.MSAL JavaScript library](xref:blazor/security/webassembly/additional-scenarios#build-a-custom-version-of-the-authenticationmsal-javascript-library)
* [Unauthenticated or unauthorized web API requests in an app with a secure default client](xref:blazor/security/webassembly/additional-scenarios#unauthenticated-or-unauthorized-web-api-requests-in-an-app-with-a-secure-default-client)
* <xref:blazor/security/webassembly/meid-groups-roles>
* <xref:security/authentication/azure-active-directory/index>
* [Microsoft identity platform documentation](/entra/identity-platform/)
* [Security best practices for application properties in Microsoft Entra ID](/entra/identity-platform/security-best-practices-for-app-registration)
