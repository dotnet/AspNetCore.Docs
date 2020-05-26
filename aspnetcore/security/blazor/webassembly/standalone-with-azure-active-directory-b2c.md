---
title: Secure an ASP.NET Core Blazor WebAssembly standalone app with Azure Active Directory B2C
author: guardrex
description: 
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 05/19/2020
no-loc: [Blazor, "Identity", "Let's Encrypt", Razor, SignalR]
uid: security/blazor/webassembly/standalone-with-azure-active-directory-b2c
---
# Secure an ASP.NET Core Blazor WebAssembly standalone app with Azure Active Directory B2C

By [Javier Calvarro Nelson](https://github.com/javiercn) and [Luke Latham](https://github.com/guardrex)

To create a Blazor WebAssembly standalone app that uses [Azure Active Directory (AAD) B2C](/azure/active-directory-b2c/overview) for authentication:

Follow the guidance in the following topics to create a tenant and register a web app in the Azure Portal:

[Create an AAD B2C tenant](/azure/active-directory-b2c/tutorial-create-tenant)

Record the following information:

* AAD B2C instance (for example, `https://contoso.b2clogin.com/`, which includes the trailing slash).
* AAD B2C Tenant domain (for example, `contoso.onmicrosoft.com`).

Follow the guidance in [Tutorial: Register an application in Azure Active Directory B2C](/azure/active-directory-b2c/tutorial-register-applications) again to register an AAD app for the *Client app*:

1. In **Azure Active Directory** > **App registrations**, select **New registration**.
1. Provide a **Name** for the app (for example, **Blazor Standalone AAD B2C**).
1. For **Supported account types**, select the multi-tenant option: **Accounts in any organizational directory or any identity provider. For authenticating users with Azure AD B2C.**
1. Leave the **Redirect URI** drop down set to **Web** and provide the following redirect URI: `https://localhost:{PORT}/authentication/login-callback`. The default port for an app running on Kestrel is 5001. If the app is run on a different Kestrel port, use the app's port. For IIS Express, the randomly generated port for the app can be found in the app's properties in the **Debug** panel. Since the app doesn't exist at this point and the IIS Express port isn't known, return to this step after the app is created and update the redirect URI. A remark appears later in this topic to remind IIS Express users to update the redirect URI.
1. Confirm that **Permissions** > **Grant admin concent to openid and offline_access permissions** is enabled.
1. Select **Register**.

Record the Application ID (Client ID) (for example, `11111111-1111-1111-1111-111111111111`).

In **Authentication** > **Platform configurations** > **Web**:

1. Confirm the **Redirect URI** of `https://localhost:{PORT}/authentication/login-callback` is present.
1. For **Implicit grant**, select the check boxes for **Access tokens** and **ID tokens**.
1. The remaining defaults for the app are acceptable for this experience.
1. Select the **Save** button.

In **Home** > **Azure AD B2C** > **User flows**:

[Create a sign-up and sign-in user flow](/azure/active-directory-b2c/tutorial-create-user-flows)

At a minimum, select the **Application claims** > **Display Name** user attribute to populate the `context.User.Identity.Name` in the `LoginDisplay` component (*Shared/LoginDisplay.razor*).

Record the sign-up and sign-in user flow name created for the app (for example, `B2C_1_signupsignin`).

Replace the placeholders in the following command with the information recorded earlier and execute the command in a command shell:

```dotnetcli
dotnet new blazorwasm -au IndividualB2C --aad-b2c-instance "{AAD B2C INSTANCE}" --client-id "{CLIENT ID}" --domain "{TENANT DOMAIN}" -ssp "{SIGN UP OR SIGN IN POLICY}"
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

When an app is created to use an Individual B2C Account (`IndividualB2C`), the app automatically receives a package reference for the [Microsoft Authentication Library](/azure/active-directory/develop/msal-overview) ([Microsoft.Authentication.WebAssembly.Msal](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal/)). The package provides a set of primitives that help the app authenticate users and obtain tokens to call protected APIs.

If adding authentication to an app, manually add the package to the app's project file:

```xml
<PackageReference Include="Microsoft.Authentication.WebAssembly.Msal" 
  Version="3.2.0" />
```

The [Microsoft.Authentication.WebAssembly.Msal](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal/) package transitively adds the [Microsoft.AspNetCore.Components.WebAssembly.Authentication](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Authentication/) package to the app.

## Authentication service support

Support for authenticating users is registered in the service container with the <xref:Microsoft.Extensions.DependencyInjection.MsalWebAssemblyServiceCollectionExtensions.AddMsalAuthentication%2A> extension method provided by the [Microsoft.Authentication.WebAssembly.Msal](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal/) package. This method sets up all of the services required for the app to interact with the Identity Provider (IP).

*Program.cs*:

```csharp
builder.Services.AddMsalAuthentication(options =>
{
    builder.Configuration.Bind("AzureAdB2C", options.ProviderOptions.Authentication);
});
```

The <xref:Microsoft.Extensions.DependencyInjection.MsalWebAssemblyServiceCollectionExtensions.AddMsalAuthentication%2A> method accepts a callback to configure the parameters required to authenticate an app. The values required for configuring the app can be obtained from the AAD configuration when you register the app.

Configuration is supplied by the *wwwroot/appsettings.json* file:

```json
{
  "AzureAdB2C": {
    "Authority": "{AAD B2C INSTANCE}{DOMAIN}/{SIGN UP OR SIGN IN POLICY}",
    "ClientId": "{CLIENT ID}",
    "ValidateAuthority": false
  }
}
```

Example:

```json
{
  "AzureAdB2C": {
    "Authority": "https://contoso.b2clogin.com/contoso.onmicrosoft.com/B2C_1_signupsignin1",
    "ClientId": "41451fa7-82d9-4673-8fa5-69eff5a761fd",
    "ValidateAuthority": false
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

[!INCLUDE[](~/includes/blazor-security/wasm-aad-b2c-userflows.md)]

[!INCLUDE[](~/includes/blazor-security/troubleshoot.md)]

## Additional resources

* <xref:security/blazor/webassembly/additional-scenarios>
* [Unauthenticated or unauthorized web API requests in an app with a secure default client](xref:security/blazor/webassembly/additional-scenarios#unauthenticated-or-unauthorized-web-api-requests-in-an-app-with-a-secure-default-client)
* <xref:security/authentication/azure-ad-b2c>
* [Tutorial: Create an Azure Active Directory B2C tenant](/azure/active-directory-b2c/tutorial-create-tenant)
* [Microsoft identity platform documentation](/azure/active-directory/develop/)
