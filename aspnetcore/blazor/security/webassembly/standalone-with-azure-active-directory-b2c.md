---
title: Secure an ASP.NET Core Blazor WebAssembly standalone app with Azure Active Directory B2C
author: guardrex
description: Learn how to secure an ASP.NET Core Blazor WebAssembly standalone app with Azure Active Directory B2C.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/09/2021
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/security/webassembly/standalone-with-azure-active-directory-b2c
---
# Secure an ASP.NET Core Blazor WebAssembly standalone app with Azure Active Directory B2C

This article explains how to create a [standalone Blazor WebAssembly app](xref:blazor/hosting-models#blazor-webassembly) that uses [Azure Active Directory (AAD) B2C](/azure/active-directory-b2c/overview) for authentication.

:::moniker range=">= aspnetcore-6.0"

Create a tenant or identify an existing B2C tenant for the app to use in the Azure portal by following the guidance in the [Create an AAD B2C tenant (Azure documentation)](/azure/active-directory-b2c/tutorial-create-tenant) article. Return to this article immediately after creating or identifying a tenant to use.

Record the following information:

* AAD B2C instance (for example, `https://contoso.b2clogin.com/`, which includes the trailing slash): The instance is the scheme and host of an Azure B2C app registration, which can be found by opening the **Endpoints** window from the **App registrations** page in the Azure portal.
* AAD B2C Primary/Publisher/Tenant domain (for example, `contoso.onmicrosoft.com`): The domain is available as the **Publisher domain** in the **Branding** blade of the Azure portal for the registered app.

Register an AAD B2C app:

1. Navigate to **Azure Active Directory** in the Azure portal. Select **App registrations** in the sidebar. Select the **New registration** button.
1. Provide a **Name** for the app (for example, **Blazor Standalone AAD B2C**).
1. For **Supported account types**, select the multi-tenant option: **Accounts in any organizational directory or any identity provider. For authenticating users with Azure AD B2C.**
1. Set the **Redirect URI** drop down to **Single-page application (SPA)** and provide the following redirect URI: `https://localhost:{PORT}/authentication/login-callback`. The default port for an app running on Kestrel is 5001. If the app is run on a different Kestrel port, use the app's port. For IIS Express, the randomly generated port for the app can be found in the app's properties in the **Debug** panel. Since the app doesn't exist at this point and the IIS Express port isn't known, return to this step after the app is created and update the redirect URI. A remark appears later in this topic to remind IIS Express users to update the redirect URI.
1. If you're using an [unverified publisher domain](/azure/active-directory/develop/howto-configure-publisher-domain), confirm that **Permissions** > **Grant admin consent to openid and offline_access permissions** is selected. If the publisher domain is verified, this checkbox isn't present.
1. Select **Register**.

Record the Application (client) ID (for example, `41451fa7-82d9-4673-8fa5-69eff5a761fd`).

In **Authentication** > **Platform configurations** > **Single-page application (SPA)**:

1. Confirm the **Redirect URI** of `https://localhost:{PORT}/authentication/login-callback` is present.
1. In the **Implicit grant** section, ensure that the checkboxes for **Access tokens** and **ID tokens** are **not** selected.
1. The remaining defaults for the app are acceptable for this experience.
1. Select the **Save** button.

In **Home** > **Azure AD B2C** > **User flows**:

[Create a sign-up and sign-in user flow](/azure/active-directory-b2c/tutorial-create-user-flows)

At a minimum, select the **Application claims** > **Display Name** user attribute to populate the `context.User.Identity.Name` in the `LoginDisplay` component (`Shared/LoginDisplay.razor`).

Record the sign-up and sign-in user flow name created for the app (for example, `B2C_1_signupsignin`).

In an empty folder, replace the placeholders in the following command with the information recorded earlier and execute the command in a command shell:

```dotnetcli
dotnet new blazorwasm -au IndividualB2C --aad-b2c-instance "{AAD B2C INSTANCE}" --client-id "{CLIENT ID}" --domain "{TENANT DOMAIN}" -o {APP NAME} -ssp "{SIGN UP OR SIGN IN POLICY}"
```

| Placeholder                   | Azure portal name               | Example                                                       |
| ----------------------------- | ------------------------------- | ------------------------------------------------------------- |
| `{AAD B2C INSTANCE}`          | Instance                        | `https://contoso.b2clogin.com/` (includes the trailing slash) |
| `{APP NAME}`                  | &mdash;                         | `BlazorSample`                                                |
| `{CLIENT ID}`                 | Application (client) ID         | `41451fa7-82d9-4673-8fa5-69eff5a761fd`                        |
| `{SIGN UP OR SIGN IN POLICY}` | Sign-up/sign-in user flow       | `B2C_1_signupsignin1`                                         |
| `{TENANT DOMAIN}`             | Primary/Publisher/Tenant domain | `contoso.onmicrosoft.com`                                     |

The output location specified with the `-o|--output` option creates a project folder if it doesn't exist and becomes part of the app's name.

> [!NOTE]
> In the Azure portal, the app's platform configuration **Redirect URI** is configured for port 5001 for apps that run on the Kestrel server with default settings.
>
> If the app is run on a random IIS Express port, the port for the app can be found in the app's properties in the **Debug** panel.
>
> If the port wasn't configured earlier with the app's known port, return to the app's registration in the Azure portal and update the redirect URI with the correct port.

[!INCLUDE[](~/blazor/security/includes/additional-scopes-standalone-nonAAD.md)]

After creating the app, you should be able to:

* Log into the app using an AAD user account.
* Request access tokens for Microsoft APIs. For more information, see:
  * [Access token scopes](#access-token-scopes)
  * [Quickstart: Configure an application to expose web APIs](/azure/active-directory/develop/quickstart-configure-app-expose-web-apis).

## Authentication package

When an app is created to use an Individual B2C Account (`IndividualB2C`), the app automatically receives a package reference for the [Microsoft Authentication Library](/azure/active-directory/develop/msal-overview) ([`Microsoft.Authentication.WebAssembly.Msal`](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal)). The package provides a set of primitives that help the app authenticate users and obtain tokens to call protected APIs.

If adding authentication to an app, manually add the [`Microsoft.Authentication.WebAssembly.Msal`](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal) package to the app.

[!INCLUDE[](~/includes/package-reference.md)]

The [`Microsoft.Authentication.WebAssembly.Msal`](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal) package transitively adds the [`Microsoft.AspNetCore.Components.WebAssembly.Authentication`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Authentication) package to the app.

## Authentication service support

Support for authenticating users is registered in the service container with the <xref:Microsoft.Extensions.DependencyInjection.MsalWebAssemblyServiceCollectionExtensions.AddMsalAuthentication%2A> extension method provided by the [`Microsoft.Authentication.WebAssembly.Msal`](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal) package. This method sets up all of the services required for the app to interact with the Identity Provider (IP).

`Program.cs`:

```csharp
builder.Services.AddMsalAuthentication(options =>
{
    builder.Configuration.Bind("AzureAdB2C", options.ProviderOptions.Authentication);
});
```

The <xref:Microsoft.Extensions.DependencyInjection.MsalWebAssemblyServiceCollectionExtensions.AddMsalAuthentication%2A> method accepts a callback to configure the parameters required to authenticate an app. The values required for configuring the app can be obtained from the AAD configuration when you register the app.

Configuration is supplied by the `wwwroot/appsettings.json` file:

```json
{
  "AzureAdB2C": {
    "Authority": "{AAD B2C INSTANCE}{DOMAIN}/{SIGN UP OR SIGN IN POLICY}",
    "ClientId": "{CLIENT ID}",
    "ValidateAuthority": false
  }
}
```

In the preceding configuration, the `{AAD B2C INSTANCE}` includes a trailing slash.

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

Specify additional scopes with `AdditionalScopesToConsent`:

```csharp
options.ProviderOptions.AdditionalScopesToConsent.Add("{ADDITIONAL SCOPE URI}");
```

For more information, see the following sections of the *Additional scenarios* article:

* [Request additional access tokens](xref:blazor/security/webassembly/additional-scenarios#request-additional-access-tokens)
* [Attach tokens to outgoing requests](xref:blazor/security/webassembly/additional-scenarios#attach-tokens-to-outgoing-requests)

## Login mode

[!INCLUDE[](~/blazor/security/includes/msal-login-mode.md)]

## Imports file

[!INCLUDE[](~/blazor/security/includes/imports-file-standalone.md)]

## Index page

[!INCLUDE[](~/blazor/security/includes/index-page-msal.md)]

## App component

[!INCLUDE[](~/blazor/security/includes/app-component.md)]

## RedirectToLogin component

[!INCLUDE[](~/blazor/security/includes/redirecttologin-component.md)]

## LoginDisplay component

[!INCLUDE[](~/blazor/security/includes/logindisplay-component.md)]

## Authentication component

[!INCLUDE[](~/blazor/security/includes/authentication-component.md)]

[!INCLUDE[](~/blazor/security/includes/wasm-aad-b2c-userflows.md)]

[!INCLUDE[](~/blazor/security/includes/troubleshoot.md)]

## Additional resources

* <xref:blazor/security/webassembly/additional-scenarios>
* [Build a custom version of the Authentication.MSAL JavaScript library](xref:blazor/security/webassembly/additional-scenarios#build-a-custom-version-of-the-authenticationmsal-javascript-library)
* [Unauthenticated or unauthorized web API requests in an app with a secure default client](xref:blazor/security/webassembly/additional-scenarios#unauthenticated-or-unauthorized-web-api-requests-in-an-app-with-a-secure-default-client)
* <xref:security/authentication/azure-ad-b2c>
* [Tutorial: Create an Azure Active Directory B2C tenant](/azure/active-directory-b2c/tutorial-create-tenant)
* [Tutorial: Register an application in Azure Active Directory B2C](/azure/active-directory-b2c/tutorial-register-applications)
* [Microsoft identity platform documentation](/azure/active-directory/develop/)

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

Create a tenant or identify an existing B2C tenant for the app to use in the Azure portal by following the guidance in the [Create an AAD B2C tenant (Azure documentation)](/azure/active-directory-b2c/tutorial-create-tenant) article. Return to this article immediately after creating or identifying a tenant to use.

Record the following information:

* AAD B2C instance (for example, `https://contoso.b2clogin.com/`, which includes the trailing slash): The instance is the scheme and host of an Azure B2C app registration, which can be found by opening the **Endpoints** window from the **App registrations** page in the Azure portal.
* AAD B2C Primary/Publisher/Tenant domain (for example, `contoso.onmicrosoft.com`): The domain is available as the **Publisher domain** in the **Branding** blade of the Azure portal for the registered app.

Register an AAD B2C app:

1. Navigate to **Azure Active Directory** in the Azure portal. Select **App registrations** in the sidebar. Select the **New registration** button.
1. Provide a **Name** for the app (for example, **Blazor Standalone AAD B2C**).
1. For **Supported account types**, select the multi-tenant option: **Accounts in any organizational directory or any identity provider. For authenticating users with Azure AD B2C.**
1. Set the **Redirect URI** drop down to **Single-page application (SPA)** and provide the following redirect URI: `https://localhost:{PORT}/authentication/login-callback`. The default port for an app running on Kestrel is 5001. If the app is run on a different Kestrel port, use the app's port. For IIS Express, the randomly generated port for the app can be found in the app's properties in the **Debug** panel. Since the app doesn't exist at this point and the IIS Express port isn't known, return to this step after the app is created and update the redirect URI. A remark appears later in this topic to remind IIS Express users to update the redirect URI.
1. If you're using an [unverified publisher domain](/azure/active-directory/develop/howto-configure-publisher-domain), confirm that **Permissions** > **Grant admin consent to openid and offline_access permissions** is selected. If the publisher domain is verified, this checkbox isn't present.
1. Select **Register**.

Record the Application (client) ID (for example, `41451fa7-82d9-4673-8fa5-69eff5a761fd`).

In **Authentication** > **Platform configurations** > **Single-page application (SPA)**:

1. Confirm the **Redirect URI** of `https://localhost:{PORT}/authentication/login-callback` is present.
1. In the **Implicit grant** section, ensure that the checkboxes for **Access tokens** and **ID tokens** are **not** selected.
1. The remaining defaults for the app are acceptable for this experience.
1. Select the **Save** button.

In **Home** > **Azure AD B2C** > **User flows**:

[Create a sign-up and sign-in user flow](/azure/active-directory-b2c/tutorial-create-user-flows)

At a minimum, select the **Application claims** > **Display Name** user attribute to populate the `context.User.Identity.Name` in the `LoginDisplay` component (`Shared/LoginDisplay.razor`).

Record the sign-up and sign-in user flow name created for the app (for example, `B2C_1_signupsignin`).

In an empty folder, replace the placeholders in the following command with the information recorded earlier and execute the command in a command shell:

```dotnetcli
dotnet new blazorwasm -au IndividualB2C --aad-b2c-instance "{AAD B2C INSTANCE}" --client-id "{CLIENT ID}" --domain "{TENANT DOMAIN}" -o {APP NAME} -ssp "{SIGN UP OR SIGN IN POLICY}"
```

| Placeholder                   | Azure portal name               | Example                                |
| ----------------------------- | ------------------------------- | -------------------------------------- |
| `{AAD B2C INSTANCE}`          | Instance                        | `https://contoso.b2clogin.com/`        |
| `{APP NAME}`                  | &mdash;                         | `BlazorSample`                         |
| `{CLIENT ID}`                 | Application (client) ID         | `41451fa7-82d9-4673-8fa5-69eff5a761fd` |
| `{SIGN UP OR SIGN IN POLICY}` | Sign-up/sign-in user flow       | `B2C_1_signupsignin1`                  |
| `{TENANT DOMAIN}`             | Primary/Publisher/Tenant domain | `contoso.onmicrosoft.com`              |

The output location specified with the `-o|--output` option creates a project folder if it doesn't exist and becomes part of the app's name.

> [!NOTE]
> In the Azure portal, the app's platform configuration **Redirect URI** is configured for port 5001 for apps that run on the Kestrel server with default settings.
>
> If the app is run on a random IIS Express port, the port for the app can be found in the app's properties in the **Debug** panel.
>
> If the port wasn't configured earlier with the app's known port, return to the app's registration in the Azure portal and update the redirect URI with the correct port.

[!INCLUDE[](~/blazor/security/includes/additional-scopes-standalone-nonAAD.md)]

After creating the app, you should be able to:

* Log into the app using an AAD user account.
* Request access tokens for Microsoft APIs. For more information, see:
  * [Access token scopes](#access-token-scopes)
  * [Quickstart: Configure an application to expose web APIs](/azure/active-directory/develop/quickstart-configure-app-expose-web-apis).

## Authentication package

When an app is created to use an Individual B2C Account (`IndividualB2C`), the app automatically receives a package reference for the [Microsoft Authentication Library](/azure/active-directory/develop/msal-overview) ([`Microsoft.Authentication.WebAssembly.Msal`](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal)). The package provides a set of primitives that help the app authenticate users and obtain tokens to call protected APIs.

If adding authentication to an app, manually add the [`Microsoft.Authentication.WebAssembly.Msal`](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal) package to the app.

[!INCLUDE[](~/includes/package-reference.md)]

The [`Microsoft.Authentication.WebAssembly.Msal`](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal) package transitively adds the [`Microsoft.AspNetCore.Components.WebAssembly.Authentication`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Authentication) package to the app.

## Authentication service support

Support for authenticating users is registered in the service container with the <xref:Microsoft.Extensions.DependencyInjection.MsalWebAssemblyServiceCollectionExtensions.AddMsalAuthentication%2A> extension method provided by the [`Microsoft.Authentication.WebAssembly.Msal`](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal) package. This method sets up all of the services required for the app to interact with the Identity Provider (IP).

`Program.cs`:

```csharp
builder.Services.AddMsalAuthentication(options =>
{
    builder.Configuration.Bind("AzureAdB2C", options.ProviderOptions.Authentication);
});
```

The <xref:Microsoft.Extensions.DependencyInjection.MsalWebAssemblyServiceCollectionExtensions.AddMsalAuthentication%2A> method accepts a callback to configure the parameters required to authenticate an app. The values required for configuring the app can be obtained from the AAD configuration when you register the app.

Configuration is supplied by the `wwwroot/appsettings.json` file:

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

Specify additional scopes with `AdditionalScopesToConsent`:

```csharp
options.ProviderOptions.AdditionalScopesToConsent.Add("{ADDITIONAL SCOPE URI}");
```

For more information, see the following sections of the *Additional scenarios* article:

* [Request additional access tokens](xref:blazor/security/webassembly/additional-scenarios#request-additional-access-tokens)
* [Attach tokens to outgoing requests](xref:blazor/security/webassembly/additional-scenarios#attach-tokens-to-outgoing-requests)

## Login mode

[!INCLUDE[](~/blazor/security/includes/msal-login-mode.md)]

## Imports file

[!INCLUDE[](~/blazor/security/includes/imports-file-standalone.md)]

## Index page

[!INCLUDE[](~/blazor/security/includes/index-page-msal.md)]

## App component

[!INCLUDE[](~/blazor/security/includes/app-component.md)]

## RedirectToLogin component

[!INCLUDE[](~/blazor/security/includes/redirecttologin-component.md)]

## LoginDisplay component

[!INCLUDE[](~/blazor/security/includes/logindisplay-component.md)]

## Authentication component

[!INCLUDE[](~/blazor/security/includes/authentication-component.md)]

[!INCLUDE[](~/blazor/security/includes/wasm-aad-b2c-userflows.md)]

[!INCLUDE[](~/blazor/security/includes/troubleshoot.md)]

## Additional resources

* <xref:blazor/security/webassembly/additional-scenarios>
* [Build a custom version of the Authentication.MSAL JavaScript library](xref:blazor/security/webassembly/additional-scenarios#build-a-custom-version-of-the-authenticationmsal-javascript-library)
* [Unauthenticated or unauthorized web API requests in an app with a secure default client](xref:blazor/security/webassembly/additional-scenarios#unauthenticated-or-unauthorized-web-api-requests-in-an-app-with-a-secure-default-client)
* <xref:security/authentication/azure-ad-b2c>
* [Tutorial: Create an Azure Active Directory B2C tenant](/azure/active-directory-b2c/tutorial-create-tenant)
* [Tutorial: Register an application in Azure Active Directory B2C](/azure/active-directory-b2c/tutorial-register-applications)
* [Microsoft identity platform documentation](/azure/active-directory/develop/)

:::moniker-end

:::moniker range="< aspnetcore-5.0"

Create a tenant or identify an existing B2C tenant for the app to use in the Azure portal by following the guidance in the [Create an AAD B2C tenant (Azure documentation)](/azure/active-directory-b2c/tutorial-create-tenant) article. Return to this article immediately after creating or identifying a tenant to use.

Record the following information:

* AAD B2C instance (for example, `https://contoso.b2clogin.com/`, which includes the trailing slash): The instance is the scheme and host of an Azure B2C app registration, which can be found by opening the **Endpoints** window from the **App registrations** page in the Azure portal.
* AAD B2C Primary/Publisher/Tenant domain (for example, `contoso.onmicrosoft.com`): The domain is available as the **Publisher domain** in the **Branding** blade of the Azure portal for the registered app.

Register an AAD B2C app:

1. Navigate to **Azure Active Directory** in the Azure portal. Select **App registrations** in the sidebar. Select the **New registration** button.
1. Provide a **Name** for the app (for example, **Blazor Standalone AAD B2C**).
1. For **Supported account types**, select the multi-tenant option: **Accounts in any organizational directory or any identity provider. For authenticating users with Azure AD B2C.**
1. Leave the **Redirect URI** drop down set to **Web** and provide the following redirect URI: `https://localhost:{PORT}/authentication/login-callback`. The default port for an app running on Kestrel is 5001. If the app is run on a different Kestrel port, use the app's port. For IIS Express, the randomly generated port for the app can be found in the app's properties in the **Debug** panel. Since the app doesn't exist at this point and the IIS Express port isn't known, return to this step after the app is created and update the redirect URI. A remark appears later in this topic to remind IIS Express users to update the redirect URI.
1. If you're using an [unverified publisher domain](/azure/active-directory/develop/howto-configure-publisher-domain), confirm that **Permissions** > **Grant admin consent to openid and offline_access permissions** is selected. If the publisher domain is verified, this checkbox isn't present.
1. Select **Register**.

Record the Application (client) ID (for example, `41451fa7-82d9-4673-8fa5-69eff5a761fd`).

In **Authentication** > **Platform configurations** > **Web**:

1. Confirm the **Redirect URI** of `https://localhost:{PORT}/authentication/login-callback` is present.
1. In the **Implicit grant** section, select the checkboxes for **Access tokens** and **ID tokens**.
1. The remaining defaults for the app are acceptable for this experience.
1. Select the **Save** button.

In **Home** > **Azure AD B2C** > **User flows**:

[Create a sign-up and sign-in user flow](/azure/active-directory-b2c/tutorial-create-user-flows)

At a minimum, select the **Application claims** > **Display Name** user attribute to populate the `context.User.Identity.Name` in the `LoginDisplay` component (`Shared/LoginDisplay.razor`).

Record the sign-up and sign-in user flow name created for the app (for example, `B2C_1_signupsignin`).

In an empty folder, replace the placeholders in the following command with the information recorded earlier and execute the command in a command shell:

```dotnetcli
dotnet new blazorwasm -au IndividualB2C --aad-b2c-instance "{AAD B2C INSTANCE}" --client-id "{CLIENT ID}" --domain "{TENANT DOMAIN}" -o {APP NAME} -ssp "{SIGN UP OR SIGN IN POLICY}"
```

| Placeholder                   | Azure portal name               | Example                                |
| ----------------------------- | ------------------------------- | -------------------------------------- |
| `{AAD B2C INSTANCE}`          | Instance                        | `https://contoso.b2clogin.com/`        |
| `{APP NAME}`                  | &mdash;                         | `BlazorSample`                         |
| `{CLIENT ID}`                 | Application (client) ID         | `41451fa7-82d9-4673-8fa5-69eff5a761fd` |
| `{SIGN UP OR SIGN IN POLICY}` | Sign-up/sign-in user flow       | `B2C_1_signupsignin1`                  |
| `{TENANT DOMAIN}`             | Primary/Publisher/Tenant domain | `contoso.onmicrosoft.com`              |

The output location specified with the `-o|--output` option creates a project folder if it doesn't exist and becomes part of the app's name.

> [!NOTE]
> In the Azure portal, the app's platform configuration **Redirect URI** is configured for port 5001 for apps that run on the Kestrel server with default settings.
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

When an app is created to use an Individual B2C Account (`IndividualB2C`), the app automatically receives a package reference for the [Microsoft Authentication Library](/azure/active-directory/develop/msal-overview) ([`Microsoft.Authentication.WebAssembly.Msal`](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal)). The package provides a set of primitives that help the app authenticate users and obtain tokens to call protected APIs.

If adding authentication to an app, manually add the [`Microsoft.Authentication.WebAssembly.Msal`](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal) package to the app.

[!INCLUDE[](~/includes/package-reference.md)]

The [`Microsoft.Authentication.WebAssembly.Msal`](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal) package transitively adds the [`Microsoft.AspNetCore.Components.WebAssembly.Authentication`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Authentication) package to the app.

## Authentication service support

Support for authenticating users is registered in the service container with the <xref:Microsoft.Extensions.DependencyInjection.MsalWebAssemblyServiceCollectionExtensions.AddMsalAuthentication%2A> extension method provided by the [`Microsoft.Authentication.WebAssembly.Msal`](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal) package. This method sets up all of the services required for the app to interact with the Identity Provider (IP).

`Program.cs`:

```csharp
builder.Services.AddMsalAuthentication(options =>
{
    builder.Configuration.Bind("AzureAdB2C", options.ProviderOptions.Authentication);
});
```

The <xref:Microsoft.Extensions.DependencyInjection.MsalWebAssemblyServiceCollectionExtensions.AddMsalAuthentication%2A> method accepts a callback to configure the parameters required to authenticate an app. The values required for configuring the app can be obtained from the AAD configuration when you register the app.

Configuration is supplied by the `wwwroot/appsettings.json` file:

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

Specify additional scopes with `AdditionalScopesToConsent`:

```csharp
options.ProviderOptions.AdditionalScopesToConsent.Add("{ADDITIONAL SCOPE URI}");
```

For more information, see the following sections of the *Additional scenarios* article:

* [Request additional access tokens](xref:blazor/security/webassembly/additional-scenarios#request-additional-access-tokens)
* [Attach tokens to outgoing requests](xref:blazor/security/webassembly/additional-scenarios#attach-tokens-to-outgoing-requests)

## Imports file

[!INCLUDE[](~/blazor/security/includes/imports-file-standalone.md)]

## Index page

[!INCLUDE[](~/blazor/security/includes/index-page-msal.md)]

## App component

[!INCLUDE[](~/blazor/security/includes/app-component.md)]

## RedirectToLogin component

[!INCLUDE[](~/blazor/security/includes/redirecttologin-component.md)]

## LoginDisplay component

[!INCLUDE[](~/blazor/security/includes/logindisplay-component.md)]

## Authentication component

[!INCLUDE[](~/blazor/security/includes/authentication-component.md)]

[!INCLUDE[](~/blazor/security/includes/wasm-aad-b2c-userflows.md)]

[!INCLUDE[](~/blazor/security/includes/troubleshoot.md)]

## Additional resources

* <xref:blazor/security/webassembly/additional-scenarios>
* [Build a custom version of the Authentication.MSAL JavaScript library](xref:blazor/security/webassembly/additional-scenarios#build-a-custom-version-of-the-authenticationmsal-javascript-library)
* [Unauthenticated or unauthorized web API requests in an app with a secure default client](xref:blazor/security/webassembly/additional-scenarios#unauthenticated-or-unauthorized-web-api-requests-in-an-app-with-a-secure-default-client)
* <xref:security/authentication/azure-ad-b2c>
* [Tutorial: Create an Azure Active Directory B2C tenant](/azure/active-directory-b2c/tutorial-create-tenant)
* [Tutorial: Register an application in Azure Active Directory B2C](/azure/active-directory-b2c/tutorial-register-applications)
* [Microsoft identity platform documentation](/azure/active-directory/develop/)

:::moniker-end
