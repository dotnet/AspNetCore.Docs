---
title: Secure a hosted ASP.NET Core Blazor WebAssembly app with Azure Active Directory
author: guardrex
description: Learn how to secure a hosted ASP.NET Core Blazor WebAssembly app with Azure Active Directory.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: "devx-track-csharp, mvc"
ms.date: 03/07/2023
uid: blazor/security/webassembly/hosted-with-azure-active-directory
---
# Secure a hosted ASP.NET Core Blazor WebAssembly app with Azure Active Directory

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how to create a [hosted Blazor WebAssembly solution](xref:blazor/hosting-models#blazor-webassembly) that uses [Azure Active Directory (AAD)](https://azure.microsoft.com/services/active-directory/) for authentication. This article focuses on a single tenant app with a single tenant Azure app registration.

This article doesn't cover a *multi-tenant Azure Active Directory registration*. For more information, see [Making your application multi-tenant](/azure/active-directory/develop/howto-convert-app-to-be-multi-tenant).

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

Follow the guidance in [Quickstart: Set up a tenant](/azure/active-directory/develop/quickstart-create-new-tenant) to create a tenant in AAD.

### Register a server API app in Azure

Register an AAD app for the *Server API app*:

1. Navigate to **Azure Active Directory** in the Azure portal. Select **App registrations** in the sidebar. Select the **New registration** button.
1. Provide a **Name** for the app (for example, **Blazor Server AAD**).
1. Choose a **Supported account types**. You may select **Accounts in this organizational directory only** (single tenant) for this experience.
1. The *Server API app* doesn't require a **Redirect URI** in this scenario, so leave the dropdown list set to **Web** and don't enter a redirect URI.
1. If you're using an [unverified publisher domain](/azure/active-directory/develop/howto-configure-publisher-domain), clear the **Permissions** > **Grant admin consent to openid and offline_access permissions** checkbox. If the publisher domain is verified, this checkbox isn't present.
1. Select **Register**.

Record the following information:

* *Server API app* Application (client) ID (for example, `41451fa7-82d9-4673-8fa5-69eff5a761fd`)
* Directory (tenant) ID (for example, `e86c78e2-8bb4-4c41-aefd-918e0565a45e`)
* AAD Primary/Publisher/Tenant domain (for example, `contoso.onmicrosoft.com`): The domain is available as the **Publisher domain** in the **Branding** blade of the Azure portal for the registered app.

In **API permissions**, remove the **Microsoft Graph** > **User.Read** permission, as the server API app doesn't require additional API access for merely signing in users and calling server API endpoints.

In **Expose an API**:

1. Select **Add a scope**.
1. Select **Save and continue**.
1. Provide a **Scope name** (for example, `API.Access`).
1. Provide an **Admin consent display name** (for example, `Access API`).
1. Provide an **Admin consent description** (for example, `Allows the app to access server app API endpoints.`).
1. Confirm that the **State** is set to **Enabled**.
1. Select **Add scope**.

Record the following information:

* App ID URI (for example, `api://41451fa7-82d9-4673-8fa5-69eff5a761fd`, `https://contoso.onmicrosoft.com/41451fa7-82d9-4673-8fa5-69eff5a761fd`, or the custom value that you provide)
* Scope name (for example, `API.Access`)

### Register a client app in Azure

Register an AAD app for the *Client app*:

1. Navigate to **Azure Active Directory** in the Azure portal. Select **App registrations** in the sidebar. Select the **New registration** button.
1. Provide a **Name** for the app (for example, **Blazor Client AAD**).
1. Choose a **Supported account types**. You may select **Accounts in this organizational directory only** (single tenant) for this experience.
1. Set the **Redirect URI** dropdown list to **Single-page application (SPA)** and provide the following redirect URI: `https://localhost/authentication/login-callback`. If you know the production redirect URI for the Azure default host (for example, `azurewebsites.net`) or the custom domain host (for example, `contoso.com`), you can also add the production redirect URI at the same time that you're providing the `localhost` redirect URI. Be sure to include the port number for non-`:443` ports in any production redirect URIs that you add.
1. If you're using an [unverified publisher domain](/azure/active-directory/develop/howto-configure-publisher-domain), clear the **Permissions** > **Grant admin consent to openid and offline_access permissions** checkbox. If the publisher domain is verified, this checkbox isn't present.
1. Select **Register**.

> [!NOTE]
> Supplying the port number for a `localhost` AAD redirect URI isn't required. For more information, see [Redirect URI (reply URL) restrictions and limitations: Localhost exceptions (Azure documentation)](/azure/active-directory/develop/reply-url#localhost-exceptions).

Record the **:::no-loc text="Client":::** app Application (client) ID (for example, `4369008b-21fa-427c-abaa-9b53bf58e538`).

In **Authentication** > **Platform configurations** > **Single-page application**:

1. Confirm the redirect URI of `https://localhost/authentication/login-callback` is present.
1. In the **Implicit grant** section, ensure that the checkboxes for **Access tokens** and **ID tokens** are **not** selected.
1. The remaining defaults for the app are acceptable for this experience.
1. Select the **Save** button if you made changes.

In **API permissions**:

1. Confirm that the app has **Microsoft Graph** > **User.Read** permission.
1. Select **Add a permission** followed by **My APIs**.
1. Select the *Server API app* from the **Name** column (for example, **Blazor Server AAD**).
1. Open the **API** list.
1. Enable access to the API (for example, `API.Access`).
1. Select **Add permissions**.
1. Select the **Grant admin consent for {TENANT NAME}** button. Select **Yes** to confirm.

[!INCLUDE[](~/blazor/security/includes/authorize-client-app.md)]

### Create the Blazor app

In an empty folder, replace the placeholders in the following command with the information recorded earlier and execute the command in a command shell:

```dotnetcli
dotnet new blazorwasm -au SingleOrg --api-client-id "{SERVER API APP CLIENT ID}" --app-id-uri "{SERVER API APP ID URI}" --client-id "{CLIENT APP CLIENT ID}" --default-scope "{DEFAULT SCOPE}" --domain "{TENANT DOMAIN}" -ho -o {PROJECT NAME} --tenant-id "{TENANT ID}"
```

> [!WARNING]
> **Avoid using dashes (`-`) in the app name `{PROJECT NAME}` that break the formation of the OIDC app identifier.** Logic in the Blazor WebAssembly project template uses the project name for an OIDC app identifier in the solution's configuration. Pascal case (`BlazorSample`) or underscores (`Blazor_Sample`) are acceptable alternatives. For more information, see [Dashes in a hosted Blazor WebAssembly project name break OIDC security (dotnet/aspnetcore #35337)](https://github.com/dotnet/aspnetcore/issues/35337).

| Placeholder                  | Azure portal name                                     | Example                                        |
| ---------------------------- | ----------------------------------------------------- | ---------------------------------------------- |
| `{PROJECT NAME}`             | &mdash;                                               | `BlazorSample`                                 |
| `{CLIENT APP CLIENT ID}`     | Application (client) ID for the **:::no-loc text="Client":::** app      | `4369008b-21fa-427c-abaa-9b53bf58e538`         |
| `{DEFAULT SCOPE}`            | Scope name                                            | `API.Access`                                   |
| `{SERVER API APP CLIENT ID}` | Application (client) ID for the *Server API app*      | `41451fa7-82d9-4673-8fa5-69eff5a761fd`         |
| `{SERVER API APP ID URI}`    | Application ID URI&dagger;                            | `41451fa7-82d9-4673-8fa5-69eff5a761fd`&dagger; |
| `{TENANT DOMAIN}`            | Primary/Publisher/Tenant domain                       | `contoso.onmicrosoft.com`                      |
| `{TENANT ID}`                | Directory (tenant) ID                                 | `e86c78e2-8bb4-4c41-aefd-918e0565a45e`         |

&dagger;The Blazor WebAssembly template automatically adds a scheme of `api://` to the App ID URI argument passed in the `dotnet new` command. When providing the App ID URI for the `{SERVER API APP ID URI}` placeholder and if the scheme is `api://`, remove the scheme (`api://`) from the argument, as the example value in the preceding table shows. If the App ID URI is a custom value or has some other scheme (for example, `https://` for an [unverified publisher domain](/azure/active-directory/develop/howto-configure-publisher-domain) similar to `https://contoso.onmicrosoft.com/41451fa7-82d9-4673-8fa5-69eff5a761fd`), you must manually update the default scope URI and remove the `api://` scheme after the **:::no-loc text="Client":::** app is created by the template. For more information, see the note in the [Access token scopes](#access-token-scopes) section. The Blazor WebAssembly template might be changed in a future release of ASP.NET Core to address these scenarios. For more information, see [Double scheme for App ID URI with Blazor WASM template (hosted, single org) (dotnet/aspnetcore #27417)](https://github.com/dotnet/aspnetcore/issues/27417).

The output location specified with the `-o|--output` option creates a project folder if it doesn't exist and becomes part of the app's name. **Avoid using dashes (`-`) in the app name that break the formation of the OIDC app identifier (see the earlier WARNING).**

### Modify the **:::no-loc text="Server":::** `appsettings.json` configuration

In the `appsettings.json` file of **:::no-loc text="Server":::** app, add the following audience entry to the `AzureAd` configuration:

```json
"Audience": "https://{TENANT DOMAIN}/{SERVER API APP CLIENT ID}"
```

A complete example of `AzureAd` configuration follows, where:

* The tenant domain (`{TENANT DOMAIN}`) is `contoso.onmicrosoft.com`.
* The server API app client ID (`{SERVER API APP CLIENT ID}`) is `41451fa7-82d9-4673-8fa5-69eff5a761fd`.

```json
{
  "AzureAd": {
    "Instance": "https://login.microsoftonline.com/",
    "Domain": "contoso.onmicrosoft.com",
    "TenantId": "e86c78e2-8bb4-4c41-aefd-918e0565a45e",
    "ClientId": "41451fa7-82d9-4673-8fa5-69eff5a761fd",
    "CallbackPath": "/signin-oidc",
    "Scopes": "API.Access",
    "Audience": "https://contoso.onmicrosoft.com/41451fa7-82d9-4673-8fa5-69eff5a761fd"
  }
}
```

### Modify the default access token scope scheme

*This section pertains to the solution's **:::no-loc text="Client":::** app.*

The Blazor WebAssembly template automatically adds a scheme of `api://` to the App ID URI argument passed in the `dotnet new` command. 

When generating an app from the [Blazor project template](xref:blazor/project-structure), confirm that the value of the default access token scope in `Program.cs` of the **:::no-loc text="Client":::** app uses either the correct custom App ID URI value that you provided in the Azure portal or a value with **one** of the following formats:

* When the publisher domain of the directory is **trusted**, the default access token scope is typically a value similar to the following example, where `API.Access` is the default scope name:

  ```csharp
  options.ProviderOptions.DefaultAccessTokenScopes.Add(
      "api://41451fa7-82d9-4673-8fa5-69eff5a761fd/API.Access");
  ```

  ```diff
  - "api://api://..."
  + "api://..."
  ```

  **Inspect the value for a double scheme (`api://api://...`). If a double scheme is present, remove the first `api://` scheme from the value.**

* When the publisher domain of the directory is **untrusted**, the default access token scope is typically a value similar to the following example, where `API.Access` is the default scope name:

  ```csharp
  options.ProviderOptions.DefaultAccessTokenScopes.Add(
      "https://contoso.onmicrosoft.com/41451fa7-82d9-4673-8fa5-69eff5a761fd/API.Access");
  ```

  **Inspect the value for a double scheme (`api://https://...`). If a double scheme is present, remove the first `api://` scheme from the value.**

  ```diff
  - "api://https://..."
  + "https://..."
  ```

The double-added scheme produced by the Blazor project template might be addressed in a future release. For more information, see [Double scheme for App ID URI with Blazor WASM template (hosted, single org) (dotnet/aspnetcore #27417)](https://github.com/dotnet/aspnetcore/issues/27417).

### Run the app

[!INCLUDE[](~/blazor/security/includes/run-the-app.md)]

## Configure `User.Identity.Name`

*The guidance in this section covers optionally populating `User.Identity.Name` with the value from the `name` claim.*

By default, the **:::no-loc text="Server":::** app API populates `User.Identity.Name` with the value from the `http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name` claim type (for example, `2d64b3da-d9d5-42c6-9352-53d8df33d770@contoso.onmicrosoft.com`).

To configure the app to receive the value from the `name` claim type:

* Add a namespace for <xref:Microsoft.AspNetCore.Authentication.JwtBearer?displayProperty=fullName> to `Program.cs`:

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

The `appsettings.json` file contains the options to configure the JWT bearer handler used to validate access tokens. Add the following audience entry to the `AzureAd` configuration:

```json
{
  "AzureAd": {
    "Instance": "https://login.microsoftonline.com/",
    "Domain": "{TENANT DOMAIN}",
    "TenantId": "{TENANT ID}",
    "ClientId": "{SERVER API APP CLIENT ID}",
    "CallbackPath": "/signin-oidc",
    "Scopes": "{SCOPES}",
    "Audience": "https://{TENANT DOMAIN}/{SERVER API APP CLIENT ID}"
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
    "Scopes": "API.Access",
    "Audience": "https://contoso.onmicrosoft.com/41451fa7-82d9-4673-8fa5-69eff5a761fd"
  }
}
```

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

When an app is created to use Work or School Accounts (`SingleOrg`), the app automatically receives a package reference for the [Microsoft Authentication Library](/azure/active-directory/develop/msal-overview) ([`Microsoft.Authentication.WebAssembly.Msal`](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal)). The package provides a set of primitives that help the app authenticate users and obtain tokens to call protected APIs.

If adding authentication to an app, manually add the [`Microsoft.Authentication.WebAssembly.Msal`](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal) package to the app.

[!INCLUDE[](~/includes/package-reference.md)]

The [`Microsoft.Authentication.WebAssembly.Msal`](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal) package transitively adds the [`Microsoft.AspNetCore.Components.WebAssembly.Authentication`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Authentication) package to the app.

### Authentication service support

*This section pertains to the solution's **:::no-loc text="Client":::** app.*

Support for <xref:System.Net.Http.HttpClient> instances is added that include access tokens when making requests to the **:::no-loc text="Server":::** app.

`Program.cs`:

```csharp
builder.Services.AddHttpClient("{PROJECT NAME}.ServerAPI", client => 
        client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>()
    .CreateClient("{PROJECT NAME}.ServerAPI"));
```

The placeholder `{PROJECT NAME}` is the project name at solution creation. For example, providing a project name of `BlazorSample` produces a named <xref:System.Net.Http.HttpClient> of `BlazorSample.ServerAPI`.

Support for authenticating users is registered in the service container with the <xref:Microsoft.Extensions.DependencyInjection.MsalWebAssemblyServiceCollectionExtensions.AddMsalAuthentication%2A> extension method provided by the [`Microsoft.Authentication.WebAssembly.Msal`](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal) package. This method sets up the services required for the app to interact with the Identity Provider (IP).

`Program.cs`:

```csharp
builder.Services.AddMsalAuthentication(options =>
{
    builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
    options.ProviderOptions.DefaultAccessTokenScopes.Add("{SCOPE URI}");
});
```

The <xref:Microsoft.Extensions.DependencyInjection.MsalWebAssemblyServiceCollectionExtensions.AddMsalAuthentication%2A> method accepts a callback to configure the parameters required to authenticate an app. The values required for configuring the app can be obtained from the Azure Portal AAD configuration when you register the app.

### Access token scopes

*This section pertains to the solution's **:::no-loc text="Client":::** app.*

The default access token scopes represent the list of access token scopes that are:

* Included by default in the sign in request.
* Used to provision an access token immediately after authentication.

All scopes must belong to the same app per Azure Active Directory rules. Additional scopes can be added for additional API apps as needed:

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

[!INCLUDE[](~/blazor/security/includes/app-component.md)]

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

## Troubleshoot

[!INCLUDE[](~/blazor/security/includes/troubleshoot.md)]

## Additional resources

* <xref:blazor/security/webassembly/additional-scenarios>
* [Build a custom version of the Authentication.MSAL JavaScript library](xref:blazor/security/webassembly/additional-scenarios#build-a-custom-version-of-the-authenticationmsal-javascript-library)
* [Unauthenticated or unauthorized web API requests in an app with a secure default client](xref:blazor/security/webassembly/additional-scenarios#unauthenticated-or-unauthorized-web-api-requests-in-an-app-with-a-secure-default-client)
* <xref:blazor/security/webassembly/aad-groups-roles>
* <xref:security/authentication/azure-active-directory/index>
* [Microsoft identity platform documentation](/azure/active-directory/develop/)
* [Quickstart: Register an application with the Microsoft identity platform](/azure/active-directory/develop/quickstart-register-app)
* [Security best practices for application properties in Azure Active Directory](/azure/active-directory/develop/security-best-practices-for-app-registration)
