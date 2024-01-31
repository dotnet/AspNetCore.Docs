---
title: Secure a hosted ASP.NET Core Blazor WebAssembly app with Microsoft Entra ID
author: guardrex
description: Learn how to secure a hosted ASP.NET Core Blazor WebAssembly app with Microsoft Entra ID.
monikerRange: '>= aspnetcore-3.1 < aspnetcore-8.0'
ms.author: riande
ms.custom: "devx-track-csharp, mvc"
ms.date: 11/14/2023
uid: blazor/security/webassembly/hosted-with-microsoft-entra-id
---
# Secure a hosted ASP.NET Core Blazor WebAssembly app with Microsoft Entra ID

This article explains how to create a [hosted Blazor WebAssembly solution](xref:blazor/hosting-models#blazor-webassembly) that uses [Microsoft Entra ID (ME-ID)](https://azure.microsoft.com/services/active-directory/) for authentication. This article focuses on a single tenant app with a single tenant Azure app registration.

This article doesn't cover a *multi-tenant ME-ID registration*. For more information, see [Making your application multi-tenant](/entra/identity-platform/howto-convert-app-to-be-multi-tenant).

This article focuses on the use of a **Microsoft Entra** tenant, as described in [Quickstart: Set up a tenant](/entra/identity-platform/quickstart-create-new-tenant). If the app is registered in an **Azure Active Directory B2C** tenant, as described in [Tutorial: Create an Azure Active Directory B2C tenant](/azure/active-directory-b2c/tutorial-create-tenant) but follows the guidance in this article, the App ID URI is managed differently by ME-ID. For more information, see the [Use of an Azure Active Directory B2C tenant](#use-of-an-azure-active-directory-b2c-tenant) section of this article.

For additional security scenario coverage after reading this article, see <xref:blazor/security/webassembly/additional-scenarios>.

## Walkthrough

The subsections of the walkthrough explain how to:

* Create a tenant in Azure
* Register a server API app in Azure
* Register a client app in Azure
* Create the Blazor app
* Modify the **:::no-loc text="Server":::** `appsettings.json` configuration
* Modify the default access token scope scheme
* Run the app

### Create a tenant in Azure

Follow the guidance in [Quickstart: Set up a tenant](/entra/identity-platform/quickstart-create-new-tenant) to create a tenant in ME-ID.

### Register a server API app in Azure

Register an ME-ID app for the *Server API app*:

1. Navigate to [**Microsoft Entra ID** in the Azure portal](https://entra.microsoft.com/#home). Select **Applications** > **App registrations** in the sidebar. Select the **New registration** button.
1. Provide a **Name** for the app (for example, **Blazor Server ME-ID**).
1. Choose a **Supported account types**. You may select **Accounts in this organizational directory only** (single tenant) for this experience.
1. The *Server API app* doesn't require a **Redirect URI** in this scenario, so leave the **Select a platform** dropdown list unselected and don't enter a redirect URI.
1. This article assumes the app is registered in a **Microsoft Entra** tenant. If the app is registered in an **Azure Active Directory B2C** tenant, the **Permissions** > **Grant admin consent to openid and offline_access permissions** checkbox is present and selected. Deselect the checkbox to disable the setting. When using an **Active Azure Directory** tenant, the checkbox isn't present.
1. Select **Register**.

Record the following information:

* *Server API app* Application (client) ID (for example, `41451fa7-82d9-4673-8fa5-69eff5a761fd`)
* Directory (tenant) ID (for example, `e86c78e2-8bb4-4c41-aefd-918e0565a45e`)
* ME-ID Primary/Publisher/Tenant domain (for example, `contoso.onmicrosoft.com`): The domain is available as the **Publisher domain** in the **Branding** blade of the Azure portal for the registered app.

In **API permissions**, remove the **Microsoft Graph** > **User.Read** permission, as the server API app doesn't require additional API access for merely signing in users and calling server API endpoints.

In **Expose an API**:

1. Confirm or add the **App ID URI** in the format `api://{SERVER API APP CLIENT ID}`.
1. Select **Add a scope**.
1. Select **Save and continue**.
1. Provide a **Scope name** (for example, `API.Access`).
1. Provide an **Admin consent display name** (for example, `Access API`).
1. Provide an **Admin consent description** (for example, `Allows the app to access server app API endpoints.`).
1. Confirm that the **State** is set to **Enabled**.
1. Select **Add scope**.

Record the following information:

* App ID URI GUID (for example, record `41451fa7-82d9-4673-8fa5-69eff5a761fd` from the App ID URI of `api://41451fa7-82d9-4673-8fa5-69eff5a761fd`)
* Scope name (for example, `API.Access`)

> [!IMPORTANT]
> If a custom value is used for the App ID URI, configuration changes are required to both the **:::no-loc text="Server":::** and **:::no-loc text="Client":::** apps after the apps are created from the Blazor WebAssembly project template. For more information, see the [Use of a custom App ID URI](#use-of-a-custom-app-id-uri) section.

### Register a client app in Azure

Register an ME-ID app for the *Client app*:

1. Navigate to **Microsoft Entra ID** in the Azure portal. Select **App registrations** in the sidebar. Select the **New registration** button.
1. Provide a **Name** for the app (for example, **Blazor Client ME-ID**).
1. Choose a **Supported account types**. You may select **Accounts in this organizational directory only** (single tenant) for this experience.
1. Set the **Redirect URI** dropdown list to **Single-page application (SPA)** and provide the following redirect URI: `https://localhost/authentication/login-callback`. If you know the production redirect URI for the Azure default host (for example, `azurewebsites.net`) or the custom domain host (for example, `contoso.com`), you can also add the production redirect URI at the same time that you're providing the `localhost` redirect URI. Be sure to include the port number for non-`:443` ports in any production redirect URIs that you add.
1. This article assumes the app is registered in a **Microsoft Entra** tenant. If the app is registered in an **Azure Active Directory B2C** tenant, the **Permissions** > **Grant admin consent to openid and offline_access permissions** checkbox is present and selected. Deselect the checkbox to disable the setting. When using an **Active Azure Directory** tenant, the checkbox isn't present.
1. Select **Register**.

> [!NOTE]
> Supplying the port number for a `localhost` ME-ID redirect URI isn't required. For more information, see [Redirect URI (reply URL) restrictions and limitations: Localhost exceptions (Entra documentation)](/entra/identity-platform/reply-url#localhost-exceptions).

Record the **:::no-loc text="Client":::** app Application (client) ID (for example, `4369008b-21fa-427c-abaa-9b53bf58e538`).

In **Authentication** > **Platform configurations** > **Single-page application**:

1. Confirm the redirect URI of `https://localhost/authentication/login-callback` is present.
1. In the **Implicit grant** section, ensure that the checkboxes for **Access tokens** and **ID tokens** aren't selected. **Implicit grant isn't recommended for Blazor apps using MSAL v2.0 or later.** For more information, see <xref:blazor/security/webassembly/index#use-the-authorization-code-flow-with-pkce>.
1. The remaining defaults for the app are acceptable for this experience.
1. Select the **Save** button if you made changes.

In **API permissions**:

1. Confirm that the app has **Microsoft Graph** > **User.Read** permission.
1. Select **Add a permission** followed by **My APIs**.
1. Select the *Server API app* from the **Name** column (for example, **Blazor Server ME-ID**).
1. Open the **API** list.
1. Enable access to the API (for example, `API.Access`).
1. Select **Add permissions**.
1. Select the **Grant admin consent for {TENANT NAME}** button. Select **Yes** to confirm.

[!INCLUDE[](~/blazor/security/includes/authorize-client-app.md)]

### Create the Blazor app

In an empty folder, replace the placeholders in the following command with the information recorded earlier and execute the command in a command shell:

```dotnetcli
dotnet new blazorwasm -au SingleOrg --api-client-id "{SERVER API APP CLIENT ID}" --app-id-uri "{SERVER API APP ID URI GUID}" --client-id "{CLIENT APP CLIENT ID}" --default-scope "{DEFAULT SCOPE}" --domain "{TENANT DOMAIN}" -ho -o {PROJECT NAME} --tenant-id "{TENANT ID}"
```

> [!WARNING]
> **Avoid using dashes (`-`) in the app name `{PROJECT NAME}` that break the formation of the OIDC app identifier.** Logic in the Blazor WebAssembly project template uses the project name for an OIDC app identifier in the solution's configuration. Pascal case (`BlazorSample`) or underscores (`Blazor_Sample`) are acceptable alternatives. For more information, see [Dashes in a hosted Blazor WebAssembly project name break OIDC security (dotnet/aspnetcore #35337)](https://github.com/dotnet/aspnetcore/issues/35337).

| Placeholder | Azure portal name | Example |
| --- | --- | --- |
| `{PROJECT NAME}` | &mdash; | `BlazorSample` |
| `{CLIENT APP CLIENT ID}` | Application (client) ID for the **:::no-loc text="Client":::** app | `4369008b-21fa-427c-abaa-9b53bf58e538` |
| `{DEFAULT SCOPE}` | Scope name | `API.Access` |
| `{SERVER API APP CLIENT ID}` | Application (client) ID for the *Server API app* | `41451fa7-82d9-4673-8fa5-69eff5a761fd` |
| `{SERVER API APP ID URI GUID}` | Application ID URI GUID | `41451fa7-82d9-4673-8fa5-69eff5a761fd` (GUID ONLY, by default matches the `{SERVER API APP CLIENT ID}`) |
| `{TENANT DOMAIN}` | Primary/Publisher/Tenant domain | `contoso.onmicrosoft.com` |
| `{TENANT ID}` | Directory (tenant) ID | `e86c78e2-8bb4-4c41-aefd-918e0565a45e` |

The output location specified with the `-o|--output` option creates a project folder if it doesn't exist and becomes part of the project's name. **Avoid using dashes (`-`) in the app name that break the formation of the OIDC app identifier (see the earlier WARNING).**

> [!IMPORTANT]
> If a custom value is used for the App ID URI, configuration changes are required to both the **:::no-loc text="Server":::** and **:::no-loc text="Client":::** apps after the apps are created from the Blazor WebAssembly project template. For more information, see the [Use of a custom App ID URI](#use-of-a-custom-app-id-uri) section.

### Run the app

[!INCLUDE[](~/blazor/security/includes/run-the-app.md)]

## Configure `User.Identity.Name`

*The guidance in this section covers optionally populating `User.Identity.Name` with the value from the `name` claim.*

By default, the **:::no-loc text="Server":::** app API populates `User.Identity.Name` with the value from the `http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name` claim type (for example, `2d64b3da-d9d5-42c6-9352-53d8df33d770@contoso.onmicrosoft.com`).

To configure the app to receive the value from the `name` claim type:

* Add a namespace for <xref:Microsoft.AspNetCore.Authentication.JwtBearer?displayProperty=fullName> to the `Program` file:

  ```csharp
  using Microsoft.AspNetCore.Authentication.JwtBearer;
  ```

* Configure the <xref:Microsoft.IdentityModel.Tokens.TokenValidationParameters.NameClaimType?displayProperty=nameWithType> of the <xref:Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerOptions>.

  ```csharp
  builder.Services.Configure<JwtBearerOptions>(
      JwtBearerDefaults.AuthenticationScheme, options =>
      {
          options.TokenValidationParameters.NameClaimType = "name";
      });
  ```

## Parts of the solution

This section describes the parts of a solution generated from the Blazor WebAssembly project template and describes how the solution's **:::no-loc text="Client":::** and **:::no-loc text="Server":::** projects are configured for reference. There's no specific guidance to follow in this section for a basic working application if you created the app using the guidance in the [Walkthrough](#walkthrough) section. The guidance in this section is helpful for updating an app to authenticate and authorize users. However, an alternative approach to updating an app is to create a new app from the guidance in the [Walkthrough](#walkthrough) section and moving the app's components, classes, and resources to the new app.

### `appsettings.json` configuration

*This section pertains to the solution's **:::no-loc text="Server":::** app.*

The `appsettings.json` file contains the options to configure the JWT bearer handler used to validate access tokens. Add the following `AzureAd` configuration section:

```json
{
  "AzureAd": {
    "Instance": "https://login.microsoftonline.com/",
    "Domain": "{TENANT DOMAIN}",
    "TenantId": "{TENANT ID}",
    "ClientId": "{SERVER API APP CLIENT ID}",
    "CallbackPath": "/signin-oidc",
    "Scopes": "{SCOPES}"
  }
}
```

Example:

```json
{
  "AzureAd": {
    "Instance": "https://login.microsoftonline.com/",
    "Domain": "contoso.onmicrosoft.com",
    "TenantId": "e86c78e2-8bb4-4c41-aefd-918e0565a45e",
    "ClientId": "41451fa7-82d9-4673-8fa5-69eff5a761fd",
    "CallbackPath": "/signin-oidc",
    "Scopes": "API.Access"
  }
}
```

> [!IMPORTANT]
> If the **:::no-loc text="Server":::** app is registered to use a custom App ID URI in ME-ID (not in the default format `api://{SERVER API APP CLIENT ID}`), see the [Use of a custom App ID URI](#use-of-a-custom-app-id-uri) section. Changes are required in both the **:::no-loc text="Server":::** and **:::no-loc text="Client":::** apps.

### Authentication package

*This section pertains to the solution's **:::no-loc text="Server":::** app.*

The support for authenticating and authorizing calls to ASP.NET Core web APIs with the Microsoft Identity Platform is provided by the [`Microsoft.Identity.Web`](https://www.nuget.org/packages/Microsoft.Identity.Web) package.

[!INCLUDE[](~/includes/package-reference.md)]

The **:::no-loc text="Server":::** app of a hosted Blazor solution created from the Blazor WebAssembly template includes the [`Microsoft.Identity.Web.UI`](https://www.nuget.org/packages/Microsoft.Identity.Web) package by default. The package adds UI for user authentication in web apps and isn't used by the Blazor framework. If the **:::no-loc text="Server":::** app won't be used to authenticate users directly, it's safe to remove the package reference from the **:::no-loc text="Server":::** app's project file.

### Authentication service support

*This section pertains to the solution's **:::no-loc text="Server":::** app.*

The `AddAuthentication` method sets up authentication services within the app and configures the JWT Bearer handler as the default authentication method. The <xref:Microsoft.Identity.Web.MicrosoftIdentityWebApiAuthenticationBuilderExtensions.AddMicrosoftIdentityWebApi%2A> method configures services to protect the web API with Microsoft Identity Platform v2.0. This method expects an `AzureAd` section in the app's configuration with the necessary settings to initialize authentication options.

```csharp
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(Configuration.GetSection("AzureAd"));
```

[!INCLUDE[](~/blazor/includes/default-scheme.md)]

<xref:Microsoft.AspNetCore.Builder.AuthAppBuilderExtensions.UseAuthentication%2A> and <xref:Microsoft.AspNetCore.Builder.AuthorizationAppBuilderExtensions.UseAuthorization%2A> ensure that:

* The app attempts to parse and validate tokens on incoming requests.
* Any request attempting to access a protected resource without proper credentials fails.

```csharp
app.UseAuthentication();
app.UseAuthorization();
```

### :::no-loc text="WeatherForecast"::: controller

*This section pertains to the solution's **:::no-loc text="Server":::** app.*

The `WeatherForecast` controller (`Controllers/WeatherForecastController.cs`) exposes a protected API with the [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) applied to the controller. It's **important** to understand that:

* The [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) in this API controller is the only thing that protects this API from unauthorized access.
* The [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) used in the Blazor WebAssembly app only serves as a hint to the app that the user should be authorized for the app to work correctly.

```csharp
[Authorize]
[ApiController]
[Route("[controller]")]
[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
public class WeatherForecastController : ControllerBase
{
    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
        ...
    }
}
```

### `wwwroot/appsettings.json` configuration

*This section pertains to the solution's **:::no-loc text="Client":::** app.*

Configuration is supplied by the `wwwroot/appsettings.json` file:

```json
{
  "AzureAd": {
    "Authority": "https://login.microsoftonline.com/{TENANT ID}",
    "ClientId": "{CLIENT APP CLIENT ID}",
    "ValidateAuthority": true
  }
}
```

Example:

```json
{
  "AzureAd": {
    "Authority": "https://login.microsoftonline.com/e86c78e2-...-918e0565a45e",
    "ClientId": "4369008b-21fa-427c-abaa-9b53bf58e538",
    "ValidateAuthority": true
  }
}
```

### Authentication package

*This section pertains to the solution's **:::no-loc text="Client":::** app.*

When an app is created to use Work or School Accounts (`SingleOrg`), the app automatically receives a package reference for the [Microsoft Authentication Library](/entra/identity-platform/msal-overview) ([`Microsoft.Authentication.WebAssembly.Msal`](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal)). The package provides a set of primitives that help the app authenticate users and obtain tokens to call protected APIs.

If adding authentication to an app, manually add the [`Microsoft.Authentication.WebAssembly.Msal`](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal) package to the app.

[!INCLUDE[](~/includes/package-reference.md)]

The [`Microsoft.Authentication.WebAssembly.Msal`](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal) package transitively adds the [`Microsoft.AspNetCore.Components.WebAssembly.Authentication`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Authentication) package to the app.

### Authentication service support

*This section pertains to the solution's **:::no-loc text="Client":::** app.*

Support for <xref:System.Net.Http.HttpClient> instances is added that include access tokens when making requests to the **:::no-loc text="Server":::** app.

In the `Program` file:

```csharp
builder.Services.AddHttpClient("{PROJECT NAME}.ServerAPI", client => 
        client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>()
    .CreateClient("{PROJECT NAME}.ServerAPI"));
```

The placeholder `{PROJECT NAME}` is the project name at solution creation. For example, providing a project name of `BlazorSample` produces a named <xref:System.Net.Http.HttpClient> of `BlazorSample.ServerAPI`.

Support for authenticating users is registered in the service container with the <xref:Microsoft.Extensions.DependencyInjection.MsalWebAssemblyServiceCollectionExtensions.AddMsalAuthentication%2A> extension method provided by the [`Microsoft.Authentication.WebAssembly.Msal`](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal) package. This method sets up the services required for the app to interact with the Identity Provider (IP).

In the `Program` file:

```csharp
builder.Services.AddMsalAuthentication(options =>
{
    builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
    options.ProviderOptions.DefaultAccessTokenScopes.Add("{SCOPE URI}");
});
```

The <xref:Microsoft.Extensions.DependencyInjection.MsalWebAssemblyServiceCollectionExtensions.AddMsalAuthentication%2A> method accepts a callback to configure the parameters required to authenticate an app. The values required for configuring the app can be obtained from the Azure Portal ME-ID configuration when you register the app.

### Access token scopes

*This section pertains to the solution's **:::no-loc text="Client":::** app.*

The default access token scopes represent the list of access token scopes that are:

* Included by default in the sign in request.
* Used to provision an access token immediately after authentication.

Additional scopes can be added as needed in the `Program` file:

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

Example default access token scope:

```csharp
options.ProviderOptions.DefaultAccessTokenScopes.Add(
    "api://41451fa7-82d9-4673-8fa5-69eff5a761fd/API.Access");
```

For more information, see the following sections of the *Additional scenarios* article:

* [Request additional access tokens](xref:blazor/security/webassembly/additional-scenarios#request-additional-access-tokens)
* [Attach tokens to outgoing requests](xref:blazor/security/webassembly/additional-scenarios#attach-tokens-to-outgoing-requests)

### Login mode

*This section pertains to the solution's **:::no-loc text="Client":::** app.*

[!INCLUDE[](~/blazor/security/includes/msal-login-mode.md)]

### Imports file

*This section pertains to the solution's **:::no-loc text="Client":::** app.*

[!INCLUDE[](~/blazor/security/includes/imports-file-hosted.md)]

### Index page

*This section pertains to the solution's **:::no-loc text="Client":::** app.*

[!INCLUDE[](~/blazor/security/includes/index-page-msal.md)]

### App component

*This section pertains to the solution's **:::no-loc text="Client":::** app.*

The `App` component (`App.razor`) is similar to the `App` component found in Blazor Server apps:

* The <xref:Microsoft.AspNetCore.Components.Authorization.CascadingAuthenticationState> component manages exposing the <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationState> to the rest of the app.
* The <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeRouteView> component makes sure that the current user is authorized to access a given page or otherwise renders the `RedirectToLogin` component.
* The `RedirectToLogin` component manages redirecting unauthorized users to the login page.

Due to changes in the framework across releases of ASP.NET Core, Razor markup for the `App` component (`App.razor`) isn't shown in this section. To inspect the markup of the component for a given release, use ***either*** of the following approaches:

* Create an app provisioned for authentication from the default Blazor WebAssembly project template for the version of ASP.NET Core that you intend to use. Inspect the `App` component (`App.razor`) in the generated app.
* Inspect the `App` component (`App.razor`) in [reference source](https://github.com/dotnet/aspnetcore). Select the version from the branch selector, and search for the component in the `ProjectTemplates` folder of the repository because it has moved over the years.

  [!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

### RedirectToLogin component

*This section pertains to the solution's **:::no-loc text="Client":::** app.*

[!INCLUDE[](~/blazor/security/includes/redirecttologin-component.md)]

### LoginDisplay component

*This section pertains to the solution's **:::no-loc text="Client":::** app.*

[!INCLUDE[](~/blazor/security/includes/logindisplay-component.md)]

### Authentication component

*This section pertains to the solution's **:::no-loc text="Client":::** app.*

[!INCLUDE[](~/blazor/security/includes/authentication-component.md)]

### FetchData component

*This section pertains to the solution's **:::no-loc text="Client":::** app.*

[!INCLUDE[](~/blazor/security/includes/fetchdata-component.md)]

## Use of an Azure Active Directory B2C tenant

If the app is registered in an **Azure Active Directory B2C** tenant, as described in [Tutorial: Create an Azure Active Directory B2C tenant](/azure/active-directory-b2c/tutorial-create-tenant) but follows the guidance in this article, the App ID URI is managed differently by ME-ID.

You can check the tenant type of an existing tenant by selecting the **Manage tenants** link at the top of the ME-ID organization **Overview**. Examine the **Tenant type** column value for the organization. This section pertains to apps that follow the guidance in this article but that are registered in an **Azure Active Directory B2C** tenant.

Instead of the App ID URI matching the format `api://{SERVER API APP CLIENT ID OR CUSTOM VALUE}`, the App ID URI has the format `https://{TENANT}.onmicrosoft.com/{SERVER API APP CLIENT ID OR CUSTOM VALUE}`. This difference affects **:::no-loc text="Client":::** and **:::no-loc text="Server":::** app configurations:

* For the server API app, set the `Audience` in the app settings file (`appsettings.json`) to match the app's audience (App ID URI) provided by the Azure portal with no trailing slash:

  ```json
  "Audience": "https://{TENANT}.onmicrosoft.com/{SERVER API APP CLIENT ID OR CUSTOM VALUE}"
  ```

  Example:

  ```json
  "Audience": "https://contoso.onmicrosoft.com/41451fa7-82d9-4673-8fa5-69eff5a761fd"
  ```

* In the `Program` file of the **`Client`** app, set the audience of the scope (App ID URI) to match the server API app's audience:

  ```csharp
  options.ProviderOptions.DefaultAccessTokenScopes
      .Add("https://{TENANT}.onmicrosoft.com/{SERVER API APP CLIENT ID OR CUSTOM VALUE}/{DEFAULT SCOPE}");
  ```

  In the preceding scope, the App ID URI/audience is the `https://{TENANT}.onmicrosoft.com/{SERVER API APP CLIENT ID OR CUSTOM VALUE}` portion of the value, which doesn't include a trailing slash (`/`) and doesn't include the scope name (`{DEFAULT SCOPE}`).

  Example:

  ```csharp
  options.ProviderOptions.DefaultAccessTokenScopes
      .Add("https://contoso.onmicrosoft.com/41451fa7-82d9-4673-8fa5-69eff5a761fd/API.Access");
  ```

  In the preceding scope, the App ID URI/audience is the `https://contoso.onmicrosoft.com/41451fa7-82d9-4673-8fa5-69eff5a761fd` portion of the value, which doesn't include a trailing slash (`/`) and doesn't include the scope name (`API.Access`).

## Use of a custom App ID URI

If the App ID URI is a custom value, you must manually update the default access token scope URI in the **:::no-loc text="Client":::** app and add the audience to the **:::no-loc text="Server":::** app's ME-ID configuration.

> [!IMPORTANT]
> The following configuration is ***not*** required when using the default App ID URI of `api://{SERVER API APP CLIENT ID}`.

Example App ID URI of `urn://custom-app-id-uri` and a scope name of `API.Access`:

* In the `Program` file of the **:::no-loc text="Client":::** app:

  ```csharp
  options.ProviderOptions.DefaultAccessTokenScopes.Add(
      "urn://custom-app-id-uri/API.Access");
  ```

* In `appsettings.json` of the **:::no-loc text="Server":::** app, add an `Audience` entry with **only** the App ID URI and no trailing slash:

  ```json
  "Audience": "urn://custom-app-id-uri"
  ```

## Troubleshoot

[!INCLUDE[](~/blazor/security/includes/troubleshoot.md)]

## Additional resources

* [Configure an app's publisher domain](/entra/identity-platform/howto-configure-publisher-domain)
* [Microsoft Entra ID app manifest: identifierUris attribute](/entra/identity-platform/reference-app-manifest#identifieruris-attribute)
* <xref:blazor/security/webassembly/additional-scenarios>
* [Build a custom version of the Authentication.MSAL JavaScript library](xref:blazor/security/webassembly/additional-scenarios#build-a-custom-version-of-the-authenticationmsal-javascript-library)
* [Unauthenticated or unauthorized web API requests in an app with a secure default client](xref:blazor/security/webassembly/additional-scenarios#unauthenticated-or-unauthorized-web-api-requests-in-an-app-with-a-secure-default-client)
* <xref:blazor/security/webassembly/meid-groups-roles>
* <xref:security/authentication/azure-active-directory/index>
* [Microsoft identity platform documentation](/entra/identity-platform/)
* [Quickstart: Register an application with the Microsoft identity platform](/entra/identity-platform/quickstart-register-app)
* [Security best practices for application properties in Microsoft Entra ID](/entra/identity-platform/security-best-practices-for-app-registration)
