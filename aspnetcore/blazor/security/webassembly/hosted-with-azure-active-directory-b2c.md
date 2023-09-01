---
title: Secure a hosted ASP.NET Core Blazor WebAssembly app with Azure Active Directory B2C
author: guardrex
description: Learn how to secure a hosted ASP.NET Core Blazor WebAssembly app with Azure Active Directory B2C.
monikerRange: '>= aspnetcore-3.1 < aspnetcore-8.0'
ms.author: riande
ms.custom: mvc
ms.date: 04/25/2023
uid: blazor/security/webassembly/hosted-with-azure-active-directory-b2c
---
# Secure a hosted ASP.NET Core Blazor WebAssembly app with Azure Active Directory B2C

This article explains how to create a [hosted Blazor WebAssembly solution](xref:blazor/hosting-models#blazor-webassembly) that uses [Azure Active Directory (AAD) B2C](/azure/active-directory-b2c/overview) for authentication.

For additional security scenario coverage after reading this article, see <xref:blazor/security/webassembly/additional-scenarios>.

## Walkthrough

The subsections of the walkthrough explain how to:

* Create a tenant in Azure
* Register a server API app in Azure
* Register a client app in Azure
* Create the Blazor app
* Modify the default access token scope scheme
* Run the app

### Create a tenant in Azure

Follow the guidance in [Tutorial: Create an Azure Active Directory B2C tenant](/azure/active-directory-b2c/tutorial-create-tenant) to create an AAD B2C tenant.

Before proceeding with this article's guidance, confirm that you've [selected the correct directory for the AAD B2C tenant](/azure/active-directory-b2c/tutorial-create-tenant#select-your-b2c-tenant-directory).

### Register a server API app in Azure

Register an AAD B2C app for the *Server API app*:

1. Navigate to **Azure AD B2C** in the Azure portal. Select **App registrations** in the sidebar. Select the **New registration** button.
1. Provide a **Name** for the app (for example, **Blazor Server AAD B2C**).
1. For **Supported account types**, select the multi-tenant option: **Accounts in any identity provider or organizational directory (for authenticating users with user flows)**
1. The *Server API app* doesn't require a **Redirect URI** in this scenario, so leave the **Select a platform** dropdown list unselected and don't enter a redirect URI.
1. Confirm that **Permissions** > **Grant admin consent to openid and offline_access permissions** is selected.
1. Select **Register**.

Record the following information:

* *Server API app* Application (client) ID (for example, `41451fa7-82d9-4673-8fa5-69eff5a761fd`)
* AAD B2C instance (for example, `https://contoso.b2clogin.com/`, which includes the trailing slash). The instance is the scheme and host of an Azure B2C app registration, which can be found by opening the **Endpoints** window from the **App registrations** page in the Azure portal.
* Primary/Publisher/Tenant domain (for example, `contoso.onmicrosoft.com`): The domain is available as the **Publisher domain** in the **Branding** blade of the Azure portal for the registered app.

Select **Expose an API** from the sidebar and follow these steps:

1. Select **Add a scope**.
1. Select **Save and continue**.
1. Provide a **Scope name** (for example, `API.Access`).
1. Provide an **Admin consent display name** (for example, `Access API`).
1. Provide an **Admin consent description** (for example, `Allows the app to access server app API endpoints.`).
1. Confirm that the **State** is set to **Enabled**.
1. Select **Add scope**.

Record the following information:

* App ID URI GUID (for example, record `41451fa7-82d9-4673-8fa5-69eff5a761fd` from `https://contoso.onmicrosoft.com/41451fa7-82d9-4673-8fa5-69eff5a761fd`)
* Scope name (for example, `API.Access`)

### Register a client app in Azure

Register an AAD B2C app for the *Client app*:

1. Navigate to **Azure AD B2C** in the Azure portal. Select **App registrations** in the sidebar. Select the **New registration** button.
1. Provide a **Name** for the app (for example, **Blazor Client AAD B2C**).
1. For **Supported account types**, select the multi-tenant option: **Accounts in any identity provider or organizational directory (for authenticating users with user flows)**
1. Set the **Redirect URI** dropdown list to **Single-page application (SPA)** and provide a redirect URI value of `https://localhost/authentication/login-callback`. If you know the production redirect URI for the Azure default host (for example, `azurewebsites.net`) or the custom domain host (for example, `contoso.com`), you can also add the production redirect URI at the same time that you're providing the `localhost` redirect URI. Be sure to include the port number for non-`:443` ports in any production redirect URIs that you add.
1. Confirm that **Permissions** > **Grant admin consent to openid and offline_access permissions** is selected.
1. Select **Register**.

> [!NOTE]
> Supplying the port number for a `localhost` AAD B2C redirect URI isn't required. For more information, see [Redirect URI (reply URL) restrictions and limitations: Localhost exceptions (Azure documentation)](/azure/active-directory/develop/reply-url#localhost-exceptions).

Record the *Client app* Application (client) ID (for example, `4369008b-21fa-427c-abaa-9b53bf58e538`).

In **Authentication** > **Platform configurations** > **Single-page application**:

1. Confirm the redirect URI of `https://localhost/authentication/login-callback` is present.
1. In the **Implicit grant** section, ensure that the checkboxes for **Access tokens** and **ID tokens** aren't selected. **Implicit grant isn't recommended for Blazor apps using MSAL v2.0 or later.** For more information, see <xref:blazor/security/webassembly/index#use-the-authorization-code-flow-with-pkce>.
1. The remaining defaults for the app are acceptable for this experience.
1. Select the **Save** button if you made changes.

In **API permissions** from the sidebar:

1. Select **Add a permission** followed by **My APIs**.
1. Select the *Server API app* from the **Name** column (for example, **Blazor Server AAD B2C**).
1. Open the **API** list if it isn't already open.
1. Enable access to the API (for example, `API.Access`) with the checkbox.
1. Select **Add permissions**.
1. Select the **Grant admin consent for {TENANT NAME}** button. Select **Yes** to confirm.

[!INCLUDE[](~/blazor/security/includes/authorize-client-app.md)]

Return to **Azure AD B2C** in the Azure portal. Select **User flows** and use the following guidance: [Create a sign-up and sign-in user flow](/azure/active-directory-b2c/tutorial-create-user-flows). At a minimum, select **Application claims** for the sign-up/sign-in user flow and then the **Display Name** user attribute checkbox to populate the `context.User.Identity?.Name`/`context.User.Identity.Name` in the `LoginDisplay` component (`Shared/LoginDisplay.razor`).

Record the sign-up and sign-in user flow name created for the app (for example, `B2C_1_signupsignin1`).

### Create the Blazor app

Replace the placeholders in the following command with the information recorded earlier and execute the command in a command shell:

```dotnetcli
dotnet new blazorwasm -au IndividualB2C --aad-b2c-instance "{AAD B2C INSTANCE}" --api-client-id "{SERVER API APP CLIENT ID}" --app-id-uri "{SERVER API APP ID URI GUID}" --client-id "{CLIENT APP CLIENT ID}" --default-scope "{DEFAULT SCOPE}" --domain "{TENANT DOMAIN}" -ho -o {PROJECT NAME} -ssp "{SIGN UP OR SIGN IN POLICY}"
```

> [!WARNING]
> **Avoid using dashes (`-`) in the app name `{PROJECT NAME}` that break the formation of the OIDC app identifier.** Logic in the Blazor WebAssembly project template uses the project name for an OIDC app identifier in the solution's configuration. Pascal case (`BlazorSample`) or underscores (`Blazor_Sample`) are acceptable alternatives. For more information, see [Dashes in a hosted Blazor WebAssembly project name break OIDC security (dotnet/aspnetcore #35337)](https://github.com/dotnet/aspnetcore/issues/35337).

| Placeholder | Azure portal name | Example |
| --- | --- | --- |
| `{AAD B2C INSTANCE}` | Instance | `https://contoso.b2clogin.com/` (includes the trailing slash) |
| `{PROJECT NAME}` | &mdash; | `BlazorSample` |
| `{CLIENT APP CLIENT ID}` | Application (client) ID for the **:::no-loc text="Client":::** app | `4369008b-21fa-427c-abaa-9b53bf58e538` |
| `{DEFAULT SCOPE}` | Scope name | `API.Access` |
| `{SERVER API APP CLIENT ID}` | Application (client) ID for the **:::no-loc text="Server":::** app | `41451fa7-82d9-4673-8fa5-69eff5a761fd` |
| `{SERVER API APP ID URI GUID}` | Application ID URI GUID | `41451fa7-82d9-4673-8fa5-69eff5a761fd` (GUID ONLY, by default matches the `{SERVER API APP CLIENT ID}`) |
| `{SIGN UP OR SIGN IN POLICY}` | Sign-up/sign-in user flow | `B2C_1_signupsignin1` |
| `{TENANT DOMAIN}` | Primary/Publisher/Tenant domain | `contoso.onmicrosoft.com` |

The output location specified with the `-o|--output` option creates a project folder if it doesn't exist and becomes part of the project's name. **Avoid using dashes (`-`) in the app name that break the formation of the OIDC app identifier (see the earlier WARNING).**

### Run the app

[!INCLUDE[](~/blazor/security/includes/run-the-app.md)]

## Custom policies

[!INCLUDE[](~/blazor/security/includes/wasm-aad-b2c-custom-policies.md)]

## Configure `User.Identity.Name`

*The guidance in this section covers optionally populating `User.Identity.Name` with the value from the `name` claim.*

By default, the **:::no-loc text="Server":::** app API populates `User.Identity.Name` with the value from the `http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name` claim type (for example, `2d64b3da-d9d5-42c6-9352-53d8df33d770@contoso.onmicrosoft.com`).

To configure the app to receive the value from the `name` claim type:

* Add a namespace for <xref:Microsoft.AspNetCore.Authentication.JwtBearer?displayProperty=fullName> to the `Program` file:

  ```csharp
  using Microsoft.AspNetCore.Authentication.JwtBearer;
  ```

* Configure the <xref:Microsoft.IdentityModel.Tokens.TokenValidationParameters.NameClaimType?displayProperty=nameWithType> of the <xref:Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerOptions> in the `Program` file:

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

The `appsettings.json` file contains the options to configure the JWT bearer handler used to validate access tokens:

```json
{
  "AzureAdB2C": {
    "Instance": "https://{TENANT}.b2clogin.com/",
    "ClientId": "{SERVER API APP CLIENT ID}",
    "Domain": "{TENANT DOMAIN}",
    "Scopes": "{DEFAULT SCOPE}",
    "SignUpSignInPolicyId": "{SIGN UP OR SIGN IN POLICY}"
  }
}
```

Example:

```json
{
  "AzureAdB2C": {
    "Instance": "https://contoso.b2clogin.com/",
    "ClientId": "41451fa7-82d9-4673-8fa5-69eff5a761fd",
    "Domain": "contoso.onmicrosoft.com",
    "Scopes": "API.Access",
    "SignUpSignInPolicyId": "B2C_1_signupsignin1",
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

The `AddAuthentication` method sets up authentication services within the app and configures the JWT Bearer handler as the default authentication method. The <xref:Microsoft.Identity.Web.MicrosoftIdentityWebApiAuthenticationBuilderExtensions.AddMicrosoftIdentityWebApi%2A> method configures services to protect the web API with Microsoft Identity Platform v2.0. This method expects an `AzureAdB2C` section in the app's configuration with the necessary settings to initialize authentication options.

```csharp
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(Configuration.GetSection("AzureAdB2C"));
```

[!INCLUDE[](~/blazor/includes/default-scheme.md)]

<xref:Microsoft.AspNetCore.Builder.AuthAppBuilderExtensions.UseAuthentication%2A> and <xref:Microsoft.AspNetCore.Builder.AuthorizationAppBuilderExtensions.UseAuthorization%2A> ensure that:

* The app attempts to parse and validate tokens on incoming requests.
* Any request attempting to access a protected resource without proper credentials fails.

```csharp
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
[RequiredScope(RequiredScopesConfigurationKey = "AzureAdB2C:Scopes")]
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
  "AzureAdB2C": {
    "Authority": "{AAD B2C INSTANCE}{TENANT DOMAIN}/{SIGN UP OR SIGN IN POLICY}",
    "ClientId": "{CLIENT APP CLIENT ID}",
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
    "ClientId": "4369008b-21fa-427c-abaa-9b53bf58e538",
    "ValidateAuthority": false
  }
}
```

### Authentication package

*This section pertains to the solution's **:::no-loc text="Client":::** app.*

When an app is created to use an Individual B2C Account (`IndividualB2C`), the app automatically receives a package reference for the [Microsoft Authentication Library](/azure/active-directory/develop/msal-overview) ([`Microsoft.Authentication.WebAssembly.Msal`](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal)). The package provides a set of primitives that help the app authenticate users and obtain tokens to call protected APIs.

If adding authentication to an app, manually add the [`Microsoft.Authentication.WebAssembly.Msal`](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal) package to the app.

[!INCLUDE[](~/includes/package-reference.md)]

The [`Microsoft.Authentication.WebAssembly.Msal`](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal) package transitively adds the [`Microsoft.AspNetCore.Components.WebAssembly.Authentication`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Authentication) package to the app.

### Authentication service support

*This section pertains to the solution's **:::no-loc text="Client":::** app.*

Support for <xref:System.Net.Http.HttpClient> instances is added that include access tokens when making requests to the server project.

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
    builder.Configuration.Bind("AzureAdB2C", options.ProviderOptions.Authentication);
    options.ProviderOptions.DefaultAccessTokenScopes.Add("{SCOPE URI}");
});
```

The `{SCOPE URI}` is the default access token scope (for example, `https://contoso.onmicrosoft.com/41451fa7-82d9-4673-8fa5-69eff5a761fd/API.Access` or the custom URI that you configured in the Azure portal).

The <xref:Microsoft.Extensions.DependencyInjection.MsalWebAssemblyServiceCollectionExtensions.AddMsalAuthentication%2A> method accepts a callback to configure the parameters required to authenticate an app. The values required for configuring the app can be obtained from the Azure Portal AAD configuration when you register the app.

### Access token scopes

*This section pertains to the solution's **:::no-loc text="Client":::** app.*

The default access token scopes represent the list of access token scopes that are:

* Included by default in the sign in request.
* Used to provision an access token immediately after authentication.

All scopes must belong to the same app per Microsoft Entra ID rules. Additional scopes can be added for additional API apps as needed:

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
    "https://contoso.onmicrosoft.com/41451fa7-82d9-4673-8fa5-69eff5a761fd/API.Access");
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

* [Configure an app's publisher domain](/azure/active-directory/develop/howto-configure-publisher-domain)
* [Microsoft Entra ID app manifest: identifierUris attribute](/azure/active-directory/develop/reference-app-manifest#identifieruris-attribute)
* <xref:blazor/security/webassembly/additional-scenarios>
* [Build a custom version of the Authentication.MSAL JavaScript library](xref:blazor/security/webassembly/additional-scenarios#build-a-custom-version-of-the-authenticationmsal-javascript-library)
* [Unauthenticated or unauthorized web API requests in an app with a secure default client](xref:blazor/security/webassembly/additional-scenarios#unauthenticated-or-unauthorized-web-api-requests-in-an-app-with-a-secure-default-client)
* <xref:security/authentication/azure-ad-b2c>
* [Tutorial: Create an Azure Active Directory B2C tenant](/azure/active-directory-b2c/tutorial-create-tenant)
* [Tutorial: Register an application in Azure Active Directory B2C](/azure/active-directory-b2c/tutorial-register-applications)
* [Microsoft identity platform documentation](/azure/active-directory/develop/)
