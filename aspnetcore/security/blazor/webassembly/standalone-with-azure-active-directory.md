---
title: Secure an ASP.NET Core Blazor WebAssembly standalone app with Azure Active Directory
author: guardrex
description: 
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 05/19/2020
no-loc: [Blazor, "Identity", "Let's Encrypt", Razor, SignalR]
uid: security/blazor/webassembly/standalone-with-azure-active-directory
---
# Secure an ASP.NET Core Blazor WebAssembly standalone app with Azure Active Directory

By [Javier Calvarro Nelson](https://github.com/javiercn) and [Luke Latham](https://github.com/guardrex)

To create a Blazor WebAssembly standalone app that uses [Azure Active Directory (AAD)](https://azure.microsoft.com/services/active-directory/) for authentication:

[Create an AAD tenant and web application](/azure/active-directory/develop/v2-overview):

Register a AAD app in the **Azure Active Directory** > **App registrations** area of the Azure portal:

1. Provide a **Name** for the app (for example, **Blazor Standalone AAD**).
1. Choose a **Supported account types**. You may select **Accounts in this organizational directory only** for this experience.
1. Leave the **Redirect URI** drop down set to **Web** and provide the following redirect URI: `https://localhost:{PORT}/authentication/login-callback`. The default port for an app running on Kestrel is 5001. If the app is run on a different Kestrel port, use the app's port. For IIS Express, the randomly generated port for the app can be found in the app's properties in the **Debug** panel. Since the app doesn't exist at this point and the IIS Express port isn't known, return to this step after the app is created and update the redirect URI. A remark appears later in this topic to remind IIS Express users to update the redirect URI.
1. Disable the **Permissions** > **Grant admin concent to openid and offline_access permissions** check box.
1. Select **Register**.

Record the following information:

* Application ID (Client ID) (for example, `11111111-1111-1111-1111-111111111111`)
* Directory ID (Tenant ID) (for example, `22222222-2222-2222-2222-222222222222`)

In **Authentication** > **Platform configurations** > **Web**:

1. Confirm the **Redirect URI** of `https://localhost:{PORT}/authentication/login-callback` is present.
1. For **Implicit grant**, select the check boxes for **Access tokens** and **ID tokens**.
1. The remaining defaults for the app are acceptable for this experience.
1. Select the **Save** button.

Create the app. Replace the placeholders in the following command with the information recorded earlier and execute the command in a command shell:

```dotnetcli
dotnet new blazorwasm -au SingleOrg --client-id "{CLIENT ID}" --tenant-id "{TENANT ID}"
```

To specify the output location, which creates a project folder if it doesn't exist, include the output option in the command with a path (for example, `-o BlazorSample`). The folder name also becomes part of the project's name.

> [!NOTE]
> In the Azure portal, the app's **Authentication** > **Platform configurations** > **Web** > **Redirect URI** is configured for port 5001 for apps that run on the Kestrel server with default settings.
>
> If the app is run on a random IIS Express port, the port for the app can be found in the app's properties in the **Debug** panel.
>
> If the port wasn't configured earlier with the app's known port, return to the app's registration in the Azure portal and update the redirect URI with the correct port.

After creating the app, you should be able to:

* Log into the app using an AAD user account.
* Request access tokens for Microsoft APIs. For more information, see:
  * [Access token scopes](#access-token-scopes)
  * [Quickstart: Configure an application to expose web APIs](/azure/active-directory/develop/quickstart-configure-app-expose-web-apis).

## Authentication package

When an app is created to use Work or School Accounts (`SingleOrg`), the app automatically receives a package reference for the [Microsoft Authentication Library](/azure/active-directory/develop/msal-overview) ([Microsoft.Authentication.WebAssembly.Msal](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal/)). The package provides a set of primitives that help the app authenticate users and obtain tokens to call protected APIs.

If adding authentication to an app, manually add the package to the app's project file:

```xml
<PackageReference Include="Microsoft.Authentication.WebAssembly.Msal" 
  Version="3.2.0" />
```

The [Microsoft.Authentication.WebAssembly.Msal](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal/) package transitively adds the [Microsoft.AspNetCore.Components.WebAssembly.Authentication](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Authentication/) package to the app.

## Authentication service support

Support for authenticating users is registered in the service container with the <xref:Microsoft.Extensions.DependencyInjection.MsalWebAssemblyServiceCollectionExtensions.AddMsalAuthentication%2A> extension method provided by the [Microsoft.Authentication.WebAssembly.Msal](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal/) package. This method sets up the services required for the app to interact with the Identity Provider (IP).

*Program.cs*:

```csharp
builder.Services.AddMsalAuthentication(options =>
{
    builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
});
```

The <xref:Microsoft.Extensions.DependencyInjection.MsalWebAssemblyServiceCollectionExtensions.AddMsalAuthentication%2A> method accepts a callback to configure the parameters required to authenticate an app. The values required for configuring the app can be obtained from the AAD configuration when you register the app.

Configuration is supplied by the *wwwroot/appsettings.json* file:

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

[!INCLUDE[](~/includes/blazor-security/azure-scope.md)]

For more information, see the following sections of the *Additional scenarios* article:

* [Request additional access tokens](xref:security/blazor/webassembly/additional-scenarios#request-additional-access-tokens)
* [Attach tokens to outgoing requests](xref:security/blazor/webassembly/additional-scenarios#attach-tokens-to-outgoing-requests)

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

* <xref:security/blazor/webassembly/additional-scenarios>
* [Unauthenticated or unauthorized web API requests in an app with a secure default client](xref:security/blazor/webassembly/additional-scenarios#unauthenticated-or-unauthorized-web-api-requests-in-an-app-with-a-secure-default-client)
* <xref:security/blazor/webassembly/aad-groups-roles>
* <xref:security/authentication/azure-active-directory/index>
* [Microsoft identity platform documentation](/azure/active-directory/develop/)
