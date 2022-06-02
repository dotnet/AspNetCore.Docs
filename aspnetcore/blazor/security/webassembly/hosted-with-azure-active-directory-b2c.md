---
title: Secure a hosted ASP.NET Core Blazor WebAssembly app with Azure Active Directory B2C
author: guardrex
description: Learn how to secure a hosted ASP.NET Core Blazor WebAssembly app with Azure Active Directory B2C.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/09/2021
uid: blazor/security/webassembly/hosted-with-azure-active-directory-b2c
---
# Secure a hosted ASP.NET Core Blazor WebAssembly app with Azure Active Directory B2C

This article explains how to create a [hosted Blazor WebAssembly solution](xref:blazor/hosting-models#blazor-webassembly) that uses [Azure Active Directory (AAD) B2C](/azure/active-directory-b2c/overview) for authentication.

For more information on *solutions*, see <xref:blazor/tooling#visual-studio-solution-file-sln>.

:::moniker range=">= aspnetcore-6.0"

## Register apps in AAD B2C and create solution

### Create a tenant

Follow the guidance in [Tutorial: Create an Azure Active Directory B2C tenant](/azure/active-directory-b2c/tutorial-create-tenant) to create an AAD B2C tenant. Return to this article immediately after creating or identifying a tenant to use.

Record the AAD B2C instance (for example, `https://contoso.b2clogin.com/`, which includes the trailing slash). The instance is the scheme and host of an Azure B2C app registration, which can be found by opening the **Endpoints** window from the **App registrations** page in the Azure portal.

### Register a server API app

Register an AAD B2C app for the *Server API app*:

1. Navigate to **Azure Active Directory** in the Azure portal. Select **App registrations** in the sidebar. Select the **New registration** button.
1. Provide a **Name** for the app (for example, **Blazor Server AAD B2C**).
1. For **Supported account types**, select the multi-tenant option: **Accounts in any identity provider or organizational directory (for authenticating users with user flows)**
1. The *Server API app* doesn't require a **Redirect URI** in this scenario, so leave the drop down set to **Web** and don't enter a redirect URI.
1. If you're using an [unverified publisher domain](/azure/active-directory/develop/howto-configure-publisher-domain), confirm that **Permissions** > **Grant admin consent to openid and offline_access permissions** is selected. If the publisher domain is verified, this checkbox isn't present.
1. Select **Register**.

Record the following information:

* *Server API app* Application (client) ID (for example, `41451fa7-82d9-4673-8fa5-69eff5a761fd`)
* AAD Primary/Publisher/Tenant domain (for example, `contoso.onmicrosoft.com`): The domain is available as the **Publisher domain** in the **Branding** blade of the Azure portal for the registered app.

In **Expose an API**:

1. Select **Add a scope**.
1. Select **Save and continue**.
1. Provide a **Scope name** (for example, `API.Access`).
1. Provide an **Admin consent display name** (for example, `Access API`).
1. Provide an **Admin consent description** (for example, `Allows the app to access server app API endpoints.`).
1. Confirm that the **State** is set to **Enabled**.
1. Select **Add scope**.

Record the following information:

* App ID URI (for example, `api://41451fa7-82d9-4673-8fa5-69eff5a761fd`, `https://contoso.onmicrosoft.com/41451fa7-82d9-4673-8fa5-69eff5a761fd`, or the custom value that you provided)
* Scope name (for example, `API.Access`)

### Register a client app

Register an AAD B2C app for the *Client app*:

1. Navigate to **Azure Active Directory** in the Azure portal. Select **App registrations** in the sidebar. Select the **New registration** button.
1. Provide a **Name** for the app (for example, **Blazor Client AAD B2C**).
1. For **Supported account types**, select the multi-tenant option: **Accounts in any identity provider or organizational directory (for authenticating users with user flows)**
1. Set the **Redirect URI** drop down to **Single-page application (SPA)** and provide the following redirect URI: `https://localhost:{PORT}/authentication/login-callback`. The default port for an app running on Kestrel is 5001. If the app is run on a different Kestrel port, use the app's port. For IIS Express, the randomly generated port for the app can be found in the **`Server`** app's properties in the **Debug** panel. Since the app doesn't exist at this point and the IIS Express port isn't known, return to this step after the app is created and update the redirect URI. A remark appears in the [Create the app](#create-the-app) section to remind IIS Express users to update the redirect URI.
1. If you're using an [unverified publisher domain](/azure/active-directory/develop/howto-configure-publisher-domain), confirm that **Permissions** > **Grant admin consent to openid and offline_access permissions** is selected. If the publisher domain is verified, this checkbox isn't present.
1. Select **Register**.

1. Record the Application (client) ID (for example, `4369008b-21fa-427c-abaa-9b53bf58e538`).

In **Authentication** > **Platform configurations** > **Single-page application (SPA)**:

1. Confirm the **Redirect URI** of `https://localhost:{PORT}/authentication/login-callback` is present.
1. In the **Implicit grant** section, ensure that the checkboxes for **Access tokens** and **ID tokens** are **not** selected.
1. The remaining defaults for the app are acceptable for this experience.
1. Select the **Save** button.

In **API permissions**:

1. Select **Add a permission** followed by **My APIs**.
1. Select the *Server API app* from the **Name** column (for example, **Blazor Server AAD B2C**).
1. Open the **API** list.
1. Enable access to the API (for example, `API.Access`).
1. Select **Add permissions**.
1. Select the **Grant admin consent for {TENANT NAME}** button. Select **Yes** to confirm.

[!INCLUDE[](~/blazor/security/includes/authorize-client-app.md)]

In **Home** > **Azure AD B2C** > **User flows**:

[Create a sign-up and sign-in user flow](/azure/active-directory-b2c/tutorial-create-user-flows)

At a minimum, select the **Application claims** > **Display Name** user attribute to populate the `context.User.Identity.Name` in the `LoginDisplay` component (`Shared/LoginDisplay.razor`).

Record the sign-up and sign-in user flow name created for the app (for example, `B2C_1_signupsignin`).

### Create the app

Replace the placeholders in the following command with the information recorded earlier and execute the command in a command shell:

```dotnetcli
dotnet new blazorwasm -au IndividualB2C --aad-b2c-instance "{AAD B2C INSTANCE}" --api-client-id "{SERVER API APP CLIENT ID}" --app-id-uri "{SERVER API APP ID URI}" --client-id "{CLIENT APP CLIENT ID}" --default-scope "{DEFAULT SCOPE}" --domain "{TENANT DOMAIN}" -ho -o {APP NAME} -ssp "{SIGN UP OR SIGN IN POLICY}"
```

> [!WARNING]
> **Avoid using dashes (`-`) in the app name `{APP NAME}` that break the formation of the OIDC app identifier.** Logic in the Blazor WebAssembly project template uses the project name for an OIDC app identifier in the solution's configuration. Pascal case (`BlazorSample`) or underscores (`Blazor_Sample`) are acceptable alternatives. For more information, see [Dashes in a hosted Blazor WebAssembly project name break OIDC security (dotnet/aspnetcore #35337)](https://github.com/dotnet/aspnetcore/issues/35337).

| Placeholder                   | Azure portal name                                     | Example                                                       |
| ----------------------------- | ----------------------------------------------------- | ------------------------------------------------------------- |
| `{AAD B2C INSTANCE}`          | Instance                                              | `https://contoso.b2clogin.com/` (includes the trailing slash) |
| `{APP NAME}`                  | &mdash;                                               | `BlazorSample`                                                |
| `{CLIENT APP CLIENT ID}`      | Application (client) ID for the **`Client`** app      | `4369008b-21fa-427c-abaa-9b53bf58e538`                        |
| `{DEFAULT SCOPE}`             | Scope name                                            | `API.Access`                                                  |
| `{SERVER API APP CLIENT ID}`  | Application (client) ID for the *Server API app*      | `41451fa7-82d9-4673-8fa5-69eff5a761fd`                        |
| `{SERVER API APP ID URI}`     | Application ID URI&dagger;                            | `41451fa7-82d9-4673-8fa5-69eff5a761fd`&dagger;                |
| `{SIGN UP OR SIGN IN POLICY}` | Sign-up/sign-in user flow                             | `B2C_1_signupsignin1`                                         |
| `{TENANT DOMAIN}`             | Primary/Publisher/Tenant domain                       | `contoso.onmicrosoft.com`                                     |

&dagger;The Blazor WebAssembly template automatically adds a scheme of `api://` to the App ID URI argument passed in the `dotnet new` command. When providing the App ID URI for the `{SERVER API APP ID URI}` placeholder and if the scheme is `api://`, remove the scheme (`api://`) from the argument, as the example value in the preceding table shows. If the App ID URI is a custom value or has some other scheme (for example, `https://` for an [unverified publisher domain](/azure/active-directory/develop/howto-configure-publisher-domain) similar to `https://contoso.onmicrosoft.com/41451fa7-82d9-4673-8fa5-69eff5a761fd`), you must manually update the default scope URI and remove the `api://` scheme after the **`Client`** app is created by the template. For more information, see the note in the [Access token scopes](#access-token-scopes) section. The Blazor WebAssembly template might be changed in a future release of ASP.NET Core to address these scenarios. For more information, see [Double scheme for App ID URI with Blazor WASM template (hosted, single org) (dotnet/aspnetcore #27417)](https://github.com/dotnet/aspnetcore/issues/27417).

The output location specified with the `-o|--output` option creates a project folder if it doesn't exist and becomes part of the app's name. **Avoid using dashes (`-`) in the app name that break the formation of the OIDC app identifier (see the earlier WARNING).**

> [!NOTE]
> The scope set up in a hosted Blazor WebAssembly solution by the [Blazor WebAssembly project template](xref:blazor/project-structure) might have the App ID URI host repeated. Confirm that the scope configured for the `DefaultAccessTokenScopes` collection is correct in `Program.cs` of the **`Client`** app.

> [!NOTE]
> In the Azure portal, the **`Client`** app's platform configuration **Redirect URI** is configured for port 5001 for apps that run on the Kestrel server with default settings.
>
> If the **`Client`** app is run on a random IIS Express port, the port for the app can be found in the *Server API app's* properties in the **Debug** panel.
>
> If the port wasn't configured earlier with the **`Client`** app's known port, return to the **`Client`** app's registration in the Azure portal and update the redirect URI with the correct port.

## **`Server`** app configuration

*This section pertains to the solution's **`Server`** app.*

### Authentication package

The support for authenticating and authorizing calls to ASP.NET Core web APIs with the Microsoft Identity Platform is provided by the [`Microsoft.Identity.Web`](https://www.nuget.org/packages/Microsoft.Identity.Web) package.

[!INCLUDE[](~/includes/package-reference.md)]

The **`Server`** app of a hosted Blazor solution created from the Blazor WebAssembly template includes the [`Microsoft.Identity.Web.UI`](https://www.nuget.org/packages/Microsoft.Identity.Web) package by default. The package adds UI for user authentication in web apps and isn't used by the Blazor framework. If the **`Server`** app will never be used to authenticate users directly, it's safe to remove the package reference from the **`Server`** app's project file.

### Authentication service support

The `AddAuthentication` method sets up authentication services within the app and configures the JWT Bearer handler as the default authentication method. The <xref:Microsoft.Identity.Web.MicrosoftIdentityWebApiAuthenticationBuilderExtensions.AddMicrosoftIdentityWebApi%2A> method configures services to protect the web API with Microsoft Identity Platform v2.0. This method expects an `AzureAdB2C` section in the app's configuration with the necessary settings to initialize authentication options.

```csharp
services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(Configuration.GetSection("AzureAdB2C"));
```

<xref:Microsoft.AspNetCore.Builder.AuthAppBuilderExtensions.UseAuthentication%2A> and <xref:Microsoft.AspNetCore.Builder.AuthorizationAppBuilderExtensions.UseAuthorization%2A> ensure that:

* The app attempts to parse and validate tokens on incoming requests.
* Any request attempting to access a protected resource without proper credentials fails.

```csharp
app.UseAuthentication();
app.UseAuthorization();
```

### User.Identity.Name

By default, the `User.Identity.Name` isn't populated.

To configure the app to receive the value from the `name` claim type:

* Add a namespace for <xref:Microsoft.AspNetCore.Authentication.JwtBearer?displayProperty=fullName> to `Program.cs`:

  ```csharp
  using Microsoft.AspNetCore.Authentication.JwtBearer;
  ```

* Configure the <xref:Microsoft.IdentityModel.Tokens.TokenValidationParameters.NameClaimType?displayProperty=nameWithType> of the <xref:Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerOptions> in `Program.cs`:

  ```csharp
  builder.Services.Configure<JwtBearerOptions>(
      JwtBearerDefaults.AuthenticationScheme, options =>
      {
          options.TokenValidationParameters.NameClaimType = "name";
      });
  ```

### App settings

The `appsettings.json` file contains the options to configure the JWT bearer handler used to validate access tokens.

```json
{
  "AzureAdB2C": {
    "Instance": "https://{TENANT}.b2clogin.com/",
    "ClientId": "{SERVER API APP CLIENT ID}",
    "Domain": "{TENANT DOMAIN}",
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
    "SignUpSignInPolicyId": "B2C_1_signupsignin1",
  }
}
```

### WeatherForecast controller

The WeatherForecast controller (`Controllers/WeatherForecastController.cs`) exposes a protected API with the [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) applied to the controller. It's **important** to understand that:

* The [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) in this API controller is the only thing that protect this API from unauthorized access.
* The [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) used in the Blazor WebAssembly app only serves as a hint to the app that the user should be authorized for the app to work correctly.

```csharp
[Authorize]
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
        ...
    }
}
```

## **`Client`** app configuration

*This section pertains to the solution's **`Client`** app.*

### Authentication package

When an app is created to use an Individual B2C Account (`IndividualB2C`), the app automatically receives a package reference for the [Microsoft Authentication Library](/azure/active-directory/develop/msal-overview) ([`Microsoft.Authentication.WebAssembly.Msal`](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal)). The package provides a set of primitives that help the app authenticate users and obtain tokens to call protected APIs.

If adding authentication to an app, manually add the [`Microsoft.Authentication.WebAssembly.Msal`](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal) package to the app.

[!INCLUDE[](~/includes/package-reference.md)]

The [`Microsoft.Authentication.WebAssembly.Msal`](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal) package transitively adds the [`Microsoft.AspNetCore.Components.WebAssembly.Authentication`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Authentication) package to the app.

### Authentication service support

Support for <xref:System.Net.Http.HttpClient> instances is added that include access tokens when making requests to the server project.

`Program.cs`:

```csharp
builder.Services.AddHttpClient("{APP ASSEMBLY}.ServerAPI", client => 
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>()
    .CreateClient("{APP ASSEMBLY}.ServerAPI"));
```

The placeholder `{APP ASSEMBLY}` is the app's assembly name (for example, `BlazorSample.Client`).

Support for authenticating users is registered in the service container with the <xref:Microsoft.Extensions.DependencyInjection.MsalWebAssemblyServiceCollectionExtensions.AddMsalAuthentication%2A> extension method provided by the [`Microsoft.Authentication.WebAssembly.Msal`](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal) package. This method sets up the services required for the app to interact with the Identity Provider (IP).

`Program.cs`:

```csharp
builder.Services.AddMsalAuthentication(options =>
{
    builder.Configuration.Bind("AzureAdB2C", options.ProviderOptions.Authentication);
    options.ProviderOptions.DefaultAccessTokenScopes.Add("{SCOPE URI}");
});
```

The <xref:Microsoft.Extensions.DependencyInjection.MsalWebAssemblyServiceCollectionExtensions.AddMsalAuthentication%2A> method accepts a callback to configure the parameters required to authenticate an app. The values required for configuring the app can be obtained from the Azure Portal AAD configuration when you register the app.

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

### Access token scopes

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

> [!NOTE]
> The Blazor WebAssembly template automatically adds a scheme of `api://` to the App ID URI argument passed in the `dotnet new` command. When generating an app from the [Blazor project template](xref:blazor/project-structure), confirm that the value of the default access token scope uses either the correct custom App ID URI value that you provided in the Azure portal or a value with **one** of the following formats:
>
> * When the publisher domain of the directory is **trusted**, the default access token scope is typically a value similar to the following example, where `API.Access` is the default scope name:
>
>   ```csharp
>   options.ProviderOptions.DefaultAccessTokenScopes.Add(
>       "api://41451fa7-82d9-4673-8fa5-69eff5a761fd/API.Access");
>   ```
>
>   Inspect the value for a double scheme (`api://api://...`). If a double scheme is present, remove the first `api://` scheme from the value.
>
> * When the publisher domain of the directory is **untrusted**, the default access token scope is typically a value similar to the following example, where `API.Access` is the default scope name:
>
>   ```csharp
>   options.ProviderOptions.DefaultAccessTokenScopes.Add(
>       "https://contoso.onmicrosoft.com/41451fa7-82d9-4673-8fa5-69eff5a761fd/API.Access");
>   ```
>
>   Inspect the value for an extra `api://` scheme (`api://https://contoso.onmicrosoft.com/...`). If an extra `api://` scheme is present, remove the `api://` scheme from the value.
>
> The Blazor WebAssembly template might be changed in a future release of ASP.NET Core to address these scenarios. For more information, see [Double scheme for App ID URI with Blazor WASM template (hosted, single org) (dotnet/aspnetcore #27417)](https://github.com/dotnet/aspnetcore/issues/27417).

Specify additional scopes with `AdditionalScopesToConsent`:

```csharp
options.ProviderOptions.AdditionalScopesToConsent.Add("{ADDITIONAL SCOPE URI}");
```

For more information, see the following sections of the *Additional scenarios* article:

* [Request additional access tokens](xref:blazor/security/webassembly/additional-scenarios#request-additional-access-tokens)
* [Attach tokens to outgoing requests](xref:blazor/security/webassembly/additional-scenarios#attach-tokens-to-outgoing-requests)

### Login mode

[!INCLUDE[](~/blazor/security/includes/msal-login-mode.md)]

### Imports file

[!INCLUDE[](~/blazor/security/includes/imports-file-hosted.md)]

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

### FetchData component

[!INCLUDE[](~/blazor/security/includes/fetchdata-component.md)]

## Run the app

Run the app from the Server project. When using Visual Studio, either:

* Set the **Startup Projects** drop down list in the toolbar to the *Server API app* and select the **Run** button.
* Select the Server project in **Solution Explorer** and select the **Run** button in the toolbar or start the app from the **Debug** menu.

<!-- HOLD
[!INCLUDE[](~/blazor/security/includes/usermanager-signinmanager.md)]
-->

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

## Register apps in AAD B2C and create solution

### Create a tenant

Follow the guidance in [Tutorial: Create an Azure Active Directory B2C tenant](/azure/active-directory-b2c/tutorial-create-tenant) to create an AAD B2C tenant. Return to this article immediately after creating or identifying a tenant to use.

Record the AAD B2C instance (for example, `https://contoso.b2clogin.com/`, which includes the trailing slash). The instance is the scheme and host of an Azure B2C app registration, which can be found by opening the **Endpoints** window from the **App registrations** page in the Azure portal.

### Register a server API app

Register an AAD B2C app for the *Server API app*:

1. Navigate to **Azure Active Directory** in the Azure portal. Select **App registrations** in the sidebar. Select the **New registration** button.
1. Provide a **Name** for the app (for example, **Blazor Server AAD B2C**).
1. For **Supported account types**, select the multi-tenant option: **Accounts in any identity provider or organizational directory (for authenticating users with user flows)**
1. The *Server API app* doesn't require a **Redirect URI** in this scenario, so leave the drop down set to **Web** and don't enter a redirect URI.
1. If you're using an [unverified publisher domain](/azure/active-directory/develop/howto-configure-publisher-domain), confirm that **Permissions** > **Grant admin consent to openid and offline_access permissions** is selected. If the publisher domain is verified, this checkbox isn't present.
1. Select **Register**.

Record the following information:

* *Server API app* Application (client) ID (for example, `41451fa7-82d9-4673-8fa5-69eff5a761fd`)
* AAD Primary/Publisher/Tenant domain (for example, `contoso.onmicrosoft.com`): The domain is available as the **Publisher domain** in the **Branding** blade of the Azure portal for the registered app.

In **Expose an API**:

1. Select **Add a scope**.
1. Select **Save and continue**.
1. Provide a **Scope name** (for example, `API.Access`).
1. Provide an **Admin consent display name** (for example, `Access API`).
1. Provide an **Admin consent description** (for example, `Allows the app to access server app API endpoints.`).
1. Confirm that the **State** is set to **Enabled**.
1. Select **Add scope**.

Record the following information:

* App ID URI (for example, `api://41451fa7-82d9-4673-8fa5-69eff5a761fd`, `https://contoso.onmicrosoft.com/41451fa7-82d9-4673-8fa5-69eff5a761fd`, or the custom value that you provided)
* Scope name (for example, `API.Access`)

### Register a client app

Register an AAD B2C app for the *Client app*:

1. Navigate to **Azure Active Directory** in the Azure portal. Select **App registrations** in the sidebar. Select the **New registration** button.
1. Provide a **Name** for the app (for example, **Blazor Client AAD B2C**).
1. For **Supported account types**, select the multi-tenant option: **Accounts in any identity provider or organizational directory (for authenticating users with user flows)**
1. Set the **Redirect URI** drop down to **Single-page application (SPA)** and provide the following redirect URI: `https://localhost:{PORT}/authentication/login-callback`. The default port for an app running on Kestrel is 5001. If the app is run on a different Kestrel port, use the app's port. For IIS Express, the randomly generated port for the app can be found in the **`Server`** app's properties in the **Debug** panel. Since the app doesn't exist at this point and the IIS Express port isn't known, return to this step after the app is created and update the redirect URI. A remark appears in the [Create the app](#create-the-app) section to remind IIS Express users to update the redirect URI.
1. If you're using an [unverified publisher domain](/azure/active-directory/develop/howto-configure-publisher-domain), confirm that **Permissions** > **Grant admin consent to openid and offline_access permissions** is selected. If the publisher domain is verified, this checkbox isn't present.
1. Select **Register**.

1. Record the Application (client) ID (for example, `4369008b-21fa-427c-abaa-9b53bf58e538`).

In **Authentication** > **Platform configurations** > **Single-page application (SPA)**:

1. Confirm the **Redirect URI** of `https://localhost:{PORT}/authentication/login-callback` is present.
1. In the **Implicit grant** section, ensure that the checkboxes for **Access tokens** and **ID tokens** are **not** selected.
1. The remaining defaults for the app are acceptable for this experience.
1. Select the **Save** button.

In **API permissions**:

1. Select **Add a permission** followed by **My APIs**.
1. Select the *Server API app* from the **Name** column (for example, **Blazor Server AAD B2C**).
1. Open the **API** list.
1. Enable access to the API (for example, `API.Access`).
1. Select **Add permissions**.
1. Select the **Grant admin consent for {TENANT NAME}** button. Select **Yes** to confirm.

[!INCLUDE[](~/blazor/security/includes/authorize-client-app.md)]

In **Home** > **Azure AD B2C** > **User flows**:

[Create a sign-up and sign-in user flow](/azure/active-directory-b2c/tutorial-create-user-flows)

At a minimum, select the **Application claims** > **Display Name** user attribute to populate the `context.User.Identity.Name` in the `LoginDisplay` component (`Shared/LoginDisplay.razor`).

Record the sign-up and sign-in user flow name created for the app (for example, `B2C_1_signupsignin`).

### Create the app

Replace the placeholders in the following command with the information recorded earlier and execute the command in a command shell:

```dotnetcli
dotnet new blazorwasm -au IndividualB2C --aad-b2c-instance "{AAD B2C INSTANCE}" --api-client-id "{SERVER API APP CLIENT ID}" --app-id-uri "{SERVER API APP ID URI}" --client-id "{CLIENT APP CLIENT ID}" --default-scope "{DEFAULT SCOPE}" --domain "{TENANT DOMAIN}" -ho -o {APP NAME} -ssp "{SIGN UP OR SIGN IN POLICY}"
```

> [!WARNING]
> **Avoid using dashes (`-`) in the app name `{APP NAME}` that break the formation of the OIDC app identifier.** Logic in the Blazor WebAssembly project template uses the project name for an OIDC app identifier in the solution's configuration. Pascal case (`BlazorSample`) or underscores (`Blazor_Sample`) are acceptable alternatives. For more information, see [Dashes in a hosted Blazor WebAssembly project name break OIDC security (dotnet/aspnetcore #35337)](https://github.com/dotnet/aspnetcore/issues/35337).

| Placeholder                   | Azure portal name                                     | Example                                        |
| ----------------------------- | ----------------------------------------------------- | ---------------------------------------------- |
| `{AAD B2C INSTANCE}`          | Instance                                              | `https://contoso.b2clogin.com/`                |
| `{APP NAME}`                  | &mdash;                                               | `BlazorSample`                                 |
| `{CLIENT APP CLIENT ID}`      | Application (client) ID for the **`Client`** app      | `4369008b-21fa-427c-abaa-9b53bf58e538`         |
| `{DEFAULT SCOPE}`             | Scope name                                            | `API.Access`                                   |
| `{SERVER API APP CLIENT ID}`  | Application (client) ID for the *Server API app*      | `41451fa7-82d9-4673-8fa5-69eff5a761fd`         |
| `{SERVER API APP ID URI}`     | Application ID URI&dagger;                            | `41451fa7-82d9-4673-8fa5-69eff5a761fd`&dagger; |
| `{SIGN UP OR SIGN IN POLICY}` | Sign-up/sign-in user flow                             | `B2C_1_signupsignin1`                          |
| `{TENANT DOMAIN}`             | Primary/Publisher/Tenant domain                       | `contoso.onmicrosoft.com`                      |

&dagger;The Blazor WebAssembly template automatically adds a scheme of `api://` to the App ID URI argument passed in the `dotnet new` command. When providing the App ID URI for the `{SERVER API APP ID URI}` placeholder and if the scheme is `api://`, remove the scheme (`api://`) from the argument, as the example value in the preceding table shows. If the App ID URI is a custom value or has some other scheme (for example, `https://` for an [unverified publisher domain](/azure/active-directory/develop/howto-configure-publisher-domain) similar to `https://contoso.onmicrosoft.com/41451fa7-82d9-4673-8fa5-69eff5a761fd`), you must manually update the default scope URI and remove the `api://` scheme after the **`Client`** app is created by the template. For more information, see the note in the [Access token scopes](#access-token-scopes) section. The Blazor WebAssembly template might be changed in a future release of ASP.NET Core to address these scenarios. For more information, see [Double scheme for App ID URI with Blazor WASM template (hosted, single org) (dotnet/aspnetcore #27417)](https://github.com/dotnet/aspnetcore/issues/27417).

The output location specified with the `-o|--output` option creates a project folder if it doesn't exist and becomes part of the app's name. **Avoid using dashes (`-`) in the app name that break the formation of the OIDC app identifier (see the earlier WARNING).**

> [!NOTE]
> The scope set up in a hosted Blazor WebAssembly solution by the [Blazor WebAssembly project template](xref:blazor/project-structure) might have the App ID URI host repeated. Confirm that the scope configured for the `DefaultAccessTokenScopes` collection is correct in `Program.cs` of the **`Client`** app.

> [!NOTE]
> In the Azure portal, the **`Client`** app's platform configuration **Redirect URI** is configured for port 5001 for apps that run on the Kestrel server with default settings.
>
> If the **`Client`** app is run on a random IIS Express port, the port for the app can be found in the *Server API app's* properties in the **Debug** panel.
>
> If the port wasn't configured earlier with the **`Client`** app's known port, return to the **`Client`** app's registration in the Azure portal and update the redirect URI with the correct port.

## **`Server`** app configuration

*This section pertains to the solution's **`Server`** app.*

### Authentication package

The support for authenticating and authorizing calls to ASP.NET Core web APIs with the Microsoft Identity Platform is provided by the [`Microsoft.Identity.Web`](https://www.nuget.org/packages/Microsoft.Identity.Web) package.

[!INCLUDE[](~/includes/package-reference.md)]

The **`Server`** app of a hosted Blazor solution created from the Blazor WebAssembly template includes the [`Microsoft.Identity.Web.UI`](https://www.nuget.org/packages/Microsoft.Identity.Web) package by default. The package adds UI for user authentication in web apps and isn't used by the Blazor framework. If the **`Server`** app will never be used to authenticate users directly, it's safe to remove the package reference from the **`Server`** app's project file.

### Authentication service support

The `AddAuthentication` method sets up authentication services within the app and configures the JWT Bearer handler as the default authentication method. The <xref:Microsoft.Identity.Web.MicrosoftIdentityWebApiAuthenticationBuilderExtensions.AddMicrosoftIdentityWebApi%2A> method configures services to protect the web API with Microsoft Identity Platform v2.0. This method expects an `AzureAdB2C` section in the app's configuration with the necessary settings to initialize authentication options.

```csharp
services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(Configuration.GetSection("AzureAdB2C"));
```

<xref:Microsoft.AspNetCore.Builder.AuthAppBuilderExtensions.UseAuthentication%2A> and <xref:Microsoft.AspNetCore.Builder.AuthorizationAppBuilderExtensions.UseAuthorization%2A> ensure that:

* The app attempts to parse and validate tokens on incoming requests.
* Any request attempting to access a protected resource without proper credentials fails.

```csharp
app.UseAuthentication();
app.UseAuthorization();
```

### User.Identity.Name

By default, the `User.Identity.Name` isn't populated.

To configure the app to receive the value from the `name` claim type:

* Add a namespace for <xref:Microsoft.AspNetCore.Authentication.JwtBearer?displayProperty=fullName> to `Startup.cs`:

  ```csharp
  using Microsoft.AspNetCore.Authentication.JwtBearer;
  ```

* Configure the <xref:Microsoft.IdentityModel.Tokens.TokenValidationParameters.NameClaimType?displayProperty=nameWithType> of the <xref:Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerOptions> in `Startup.ConfigureServices`:

  ```csharp
  services.Configure<JwtBearerOptions>(
      JwtBearerDefaults.AuthenticationScheme, options =>
      {
          options.TokenValidationParameters.NameClaimType = "name";
      });
  ```

### App settings

The `appsettings.json` file contains the options to configure the JWT bearer handler used to validate access tokens.

```json
{
  "AzureAdB2C": {
    "Instance": "https://{TENANT}.b2clogin.com/",
    "ClientId": "{SERVER API APP CLIENT ID}",
    "Domain": "{TENANT DOMAIN}",
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
    "SignUpSignInPolicyId": "B2C_1_signupsignin1",
  }
}
```

### WeatherForecast controller

The WeatherForecast controller (`Controllers/WeatherForecastController.cs`) exposes a protected API with the [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) applied to the controller. It's **important** to understand that:

* The [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) in this API controller is the only thing that protect this API from unauthorized access.
* The [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) used in the Blazor WebAssembly app only serves as a hint to the app that the user should be authorized for the app to work correctly.

```csharp
[Authorize]
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
        ...
    }
}
```

## **`Client`** app configuration

*This section pertains to the solution's **`Client`** app.*

### Authentication package

When an app is created to use an Individual B2C Account (`IndividualB2C`), the app automatically receives a package reference for the [Microsoft Authentication Library](/azure/active-directory/develop/msal-overview) ([`Microsoft.Authentication.WebAssembly.Msal`](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal)). The package provides a set of primitives that help the app authenticate users and obtain tokens to call protected APIs.

If adding authentication to an app, manually add the [`Microsoft.Authentication.WebAssembly.Msal`](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal) package to the app.

[!INCLUDE[](~/includes/package-reference.md)]

The [`Microsoft.Authentication.WebAssembly.Msal`](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal) package transitively adds the [`Microsoft.AspNetCore.Components.WebAssembly.Authentication`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Authentication) package to the app.

### Authentication service support

Support for <xref:System.Net.Http.HttpClient> instances is added that include access tokens when making requests to the server project.

`Program.cs`:

```csharp
builder.Services.AddHttpClient("{APP ASSEMBLY}.ServerAPI", client => 
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>()
    .CreateClient("{APP ASSEMBLY}.ServerAPI"));
```

The placeholder `{APP ASSEMBLY}` is the app's assembly name (for example, `BlazorSample.Client`).

Support for authenticating users is registered in the service container with the <xref:Microsoft.Extensions.DependencyInjection.MsalWebAssemblyServiceCollectionExtensions.AddMsalAuthentication%2A> extension method provided by the [`Microsoft.Authentication.WebAssembly.Msal`](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal) package. This method sets up the services required for the app to interact with the Identity Provider (IP).

`Program.cs`:

```csharp
builder.Services.AddMsalAuthentication(options =>
{
    builder.Configuration.Bind("AzureAdB2C", options.ProviderOptions.Authentication);
    options.ProviderOptions.DefaultAccessTokenScopes.Add("{SCOPE URI}");
});
```

The <xref:Microsoft.Extensions.DependencyInjection.MsalWebAssemblyServiceCollectionExtensions.AddMsalAuthentication%2A> method accepts a callback to configure the parameters required to authenticate an app. The values required for configuring the app can be obtained from the Azure Portal AAD configuration when you register the app.

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

### Access token scopes

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

> [!NOTE]
> The Blazor WebAssembly template automatically adds a scheme of `api://` to the App ID URI argument passed in the `dotnet new` command. When generating an app from the [Blazor project template](xref:blazor/project-structure), confirm that the value of the default access token scope uses either the correct custom App ID URI value that you provided in the Azure portal or a value with **one** of the following formats:
>
> * When the publisher domain of the directory is **trusted**, the default access token scope is typically a value similar to the following example, where `API.Access` is the default scope name:
>
>   ```csharp
>   options.ProviderOptions.DefaultAccessTokenScopes.Add(
>       "api://41451fa7-82d9-4673-8fa5-69eff5a761fd/API.Access");
>   ```
>
>   Inspect the value for a double scheme (`api://api://...`). If a double scheme is present, remove the first `api://` scheme from the value.
>
> * When the publisher domain of the directory is **untrusted**, the default access token scope is typically a value similar to the following example, where `API.Access` is the default scope name:
>
>   ```csharp
>   options.ProviderOptions.DefaultAccessTokenScopes.Add(
>       "https://contoso.onmicrosoft.com/41451fa7-82d9-4673-8fa5-69eff5a761fd/API.Access");
>   ```
>
>   Inspect the value for an extra `api://` scheme (`api://https://contoso.onmicrosoft.com/...`). If an extra `api://` scheme is present, remove the `api://` scheme from the value.
>
> The Blazor WebAssembly template might be changed in a future release of ASP.NET Core to address these scenarios. For more information, see [Double scheme for App ID URI with Blazor WASM template (hosted, single org) (dotnet/aspnetcore #27417)](https://github.com/dotnet/aspnetcore/issues/27417).

Specify additional scopes with `AdditionalScopesToConsent`:

```csharp
options.ProviderOptions.AdditionalScopesToConsent.Add("{ADDITIONAL SCOPE URI}");
```

For more information, see the following sections of the *Additional scenarios* article:

* [Request additional access tokens](xref:blazor/security/webassembly/additional-scenarios#request-additional-access-tokens)
* [Attach tokens to outgoing requests](xref:blazor/security/webassembly/additional-scenarios#attach-tokens-to-outgoing-requests)

### Login mode

[!INCLUDE[](~/blazor/security/includes/msal-login-mode.md)]

### Imports file

[!INCLUDE[](~/blazor/security/includes/imports-file-hosted.md)]

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

### FetchData component

[!INCLUDE[](~/blazor/security/includes/fetchdata-component.md)]

## Run the app

Run the app from the Server project. When using Visual Studio, either:

* Set the **Startup Projects** drop down list in the toolbar to the *Server API app* and select the **Run** button.
* Select the Server project in **Solution Explorer** and select the **Run** button in the toolbar or start the app from the **Debug** menu.

<!-- HOLD
[!INCLUDE[](~/blazor/security/includes/usermanager-signinmanager.md)]
-->

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

## Register apps in AAD B2C and create solution

### Create a tenant

Follow the guidance in [Tutorial: Create an Azure Active Directory B2C tenant](/azure/active-directory-b2c/tutorial-create-tenant) to create an AAD B2C tenant. Return to this article immediately after creating or identifying a tenant to use.

Record the AAD B2C instance (for example, `https://contoso.b2clogin.com/`, which includes the trailing slash). The instance is the scheme and host of an Azure B2C app registration, which can be found by opening the **Endpoints** window from the **App registrations** page in the Azure portal.

### Register a server API app

Register an AAD B2C app for the *Server API app*:

1. Navigate to **Azure Active Directory** in the Azure portal. Select **App registrations** in the sidebar. Select the **New registration** button.
1. Provide a **Name** for the app (for example, **Blazor Server AAD B2C**).
1. For **Supported account types**, select the multi-tenant option: **Accounts in any identity provider or organizational directory (for authenticating users with user flows)**
1. The *Server API app* doesn't require a **Redirect URI** in this scenario, so leave the drop down set to **Web** and don't enter a redirect URI.
1. If you're using an [unverified publisher domain](/azure/active-directory/develop/howto-configure-publisher-domain), confirm that **Permissions** > **Grant admin consent to openid and offline_access permissions** is selected. If the publisher domain is verified, this checkbox isn't present.
1. Select **Register**.

Record the following information:

* *Server API app* Application (client) ID (for example, `41451fa7-82d9-4673-8fa5-69eff5a761fd`)
* AAD Primary/Publisher/Tenant domain (for example, `contoso.onmicrosoft.com`): The domain is available as the **Publisher domain** in the **Branding** blade of the Azure portal for the registered app.

In **Expose an API**:

1. Select **Add a scope**.
1. Select **Save and continue**.
1. Provide a **Scope name** (for example, `API.Access`).
1. Provide an **Admin consent display name** (for example, `Access API`).
1. Provide an **Admin consent description** (for example, `Allows the app to access server app API endpoints.`).
1. Confirm that the **State** is set to **Enabled**.
1. Select **Add scope**.

Record the following information:

* App ID URI (for example, `api://41451fa7-82d9-4673-8fa5-69eff5a761fd`, `https://contoso.onmicrosoft.com/41451fa7-82d9-4673-8fa5-69eff5a761fd`, or the custom value that you provided)
* Scope name (for example, `API.Access`)

### Register a client app

Register an AAD B2C app for the *Client app*:

1. Navigate to **Azure Active Directory** in the Azure portal. Select **App registrations** in the sidebar. Select the **New registration** button.
1. Provide a **Name** for the app (for example, **Blazor Client AAD B2C**).
1. For **Supported account types**, select the multi-tenant option: **Accounts in any identity provider or organizational directory (for authenticating users with user flows)**
1. Leave the **Redirect URI** drop down set to **Web** and provide the following redirect URI: `https://localhost:{PORT}/authentication/login-callback`. The default port for an app running on Kestrel is 5001. If the app is run on a different Kestrel port, use the app's port. For IIS Express, the randomly generated port for the app can be found in the **`Server`** app's properties in the **Debug** panel. Since the app doesn't exist at this point and the IIS Express port isn't known, return to this step after the app is created and update the redirect URI. A remark appears in the [Create the app](#create-the-app) section to remind IIS Express users to update the redirect URI.
1. If you're using an [unverified publisher domain](/azure/active-directory/develop/howto-configure-publisher-domain), confirm that **Permissions** > **Grant admin consent to openid and offline_access permissions** is selected. If the publisher domain is verified, this checkbox isn't present.
1. Select **Register**.

Record the Application (client) ID (for example, `4369008b-21fa-427c-abaa-9b53bf58e538`).

In **Authentication** > **Platform configurations** > **Web**:

1. Confirm the **Redirect URI** of `https://localhost:{PORT}/authentication/login-callback` is present.
1. In the **Implicit grant** section, select the checkboxes for **Access tokens** and **ID tokens**.
1. The remaining defaults for the app are acceptable for this experience.
1. Select the **Save** button.

In **API permissions**:

1. Select **Add a permission** followed by **My APIs**.
1. Select the *Server API app* from the **Name** column (for example, **Blazor Server AAD B2C**).
1. Open the **API** list.
1. Enable access to the API (for example, `API.Access`).
1. Select **Add permissions**.
1. Select the **Grant admin consent for {TENANT NAME}** button. Select **Yes** to confirm.

[!INCLUDE[](~/blazor/security/includes/authorize-client-app.md)]

In **Home** > **Azure AD B2C** > **User flows**:

[Create a sign-up and sign-in user flow](/azure/active-directory-b2c/tutorial-create-user-flows)

At a minimum, select the **Application claims** > **Display Name** user attribute to populate the `context.User.Identity.Name` in the `LoginDisplay` component (`Shared/LoginDisplay.razor`).

Record the sign-up and sign-in user flow name created for the app (for example, `B2C_1_signupsignin`).

### Create the app

Replace the placeholders in the following command with the information recorded earlier and execute the command in a command shell:

```dotnetcli
dotnet new blazorwasm -au IndividualB2C --aad-b2c-instance "{AAD B2C INSTANCE}" --api-client-id "{SERVER API APP CLIENT ID}" --app-id-uri "{SERVER API APP ID URI}" --client-id "{CLIENT APP CLIENT ID}" --default-scope "{DEFAULT SCOPE}" --domain "{TENANT DOMAIN}" -ho -o {APP NAME} -ssp "{SIGN UP OR SIGN IN POLICY}"
```

> [!WARNING]
> **Avoid using dashes (`-`) in the app name `{APP NAME}` that break the formation of the OIDC app identifier.** Logic in the Blazor WebAssembly project template uses the project name for an OIDC app identifier in the solution's configuration. Pascal case (`BlazorSample`) or underscores (`Blazor_Sample`) are acceptable alternatives. For more information, see [Dashes in a hosted Blazor WebAssembly project name break OIDC security (dotnet/aspnetcore #35337)](https://github.com/dotnet/aspnetcore/issues/35337).

| Placeholder                   | Azure portal name                                     | Example                                        |
| ----------------------------- | ----------------------------------------------------- | ---------------------------------------------- |
| `{AAD B2C INSTANCE}`          | Instance                                              | `https://contoso.b2clogin.com/`                |
| `{APP NAME}`                  | &mdash;                                               | `BlazorSample`                                 |
| `{CLIENT APP CLIENT ID}`      | Application (client) ID for the **`Client`** app      | `4369008b-21fa-427c-abaa-9b53bf58e538`         |
| `{DEFAULT SCOPE}`             | Scope name                                            | `API.Access`                                   |
| `{SERVER API APP CLIENT ID}`  | Application (client) ID for the *Server API app*      | `41451fa7-82d9-4673-8fa5-69eff5a761fd`         |
| `{SERVER API APP ID URI}`     | Application ID URI&dagger;                            | `41451fa7-82d9-4673-8fa5-69eff5a761fd`&dagger; |
| `{SIGN UP OR SIGN IN POLICY}` | Sign-up/sign-in user flow                             | `B2C_1_signupsignin1`                          |
| `{TENANT DOMAIN}`             | Primary/Publisher/Tenant domain                       | `contoso.onmicrosoft.com`                      |

&dagger;The Blazor WebAssembly template automatically adds a scheme of `api://` to the App ID URI argument passed in the `dotnet new` command. When providing the App ID URI for the `{SERVER API APP ID URI}` placeholder and if the scheme is `api://`, remove the scheme (`api://`) from the argument, as the example value in the preceding table shows. If the App ID URI is a custom value or has some other scheme (for example, `https://` for an [unverified publisher domain](/azure/active-directory/develop/howto-configure-publisher-domain) similar to `https://contoso.onmicrosoft.com/41451fa7-82d9-4673-8fa5-69eff5a761fd`), you must manually update the default scope URI and remove the `api://` scheme after the **`Client`** app is created by the template. For more information, see the note in the [Access token scopes](#access-token-scopes) section. The Blazor WebAssembly template might be changed in a future release of ASP.NET Core to address these scenarios. For more information, see [Double scheme for App ID URI with Blazor WASM template (hosted, single org) (dotnet/aspnetcore #27417)](https://github.com/dotnet/aspnetcore/issues/27417).

The output location specified with the `-o|--output` option creates a project folder if it doesn't exist and becomes part of the app's name. **Avoid using dashes (`-`) in the app name that break the formation of the OIDC app identifier (see the earlier WARNING).**

> [!NOTE]
> The scope set up in a hosted Blazor WebAssembly solution by the [Blazor WebAssembly project template](xref:blazor/project-structure) might have the App ID URI host repeated. Confirm that the scope configured for the `DefaultAccessTokenScopes` collection is correct in `Program.cs` of the **`Client`** app.

> [!NOTE]
> In the Azure portal, the **`Client`** app's platform configuration **Redirect URI** is configured for port 5001 for apps that run on the Kestrel server with default settings.
>
> If the **`Client`** app is run on a random IIS Express port, the port for the app can be found in the *Server API app's* properties in the **Debug** panel.
>
> If the port wasn't configured earlier with the **`Client`** app's known port, return to the **`Client`** app's registration in the Azure portal and update the redirect URI with the correct port.

## **`Server`** app configuration

*This section pertains to the solution's **`Server`** app.*

### Authentication package

The support for authenticating and authorizing calls to ASP.NET Core Web APIs is provided by the [`Microsoft.AspNetCore.Authentication.AzureADB2C.UI`](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.AzureADB2C.UI) package.

[!INCLUDE[](~/includes/package-reference.md)]

### Authentication service support

The `AddAuthentication` method sets up authentication services within the app and configures the JWT Bearer handler as the default authentication method. The <xref:Microsoft.AspNetCore.Authentication.AzureADB2CAuthenticationBuilderExtensions.AddAzureADB2CBearer%2A> method sets up the specific parameters in the JWT Bearer handler required to validate tokens emitted by the Azure Active Directory B2C:

```csharp
services.AddAuthentication(AzureADB2CDefaults.BearerAuthenticationScheme)
    .AddAzureADB2CBearer(options => Configuration.Bind("AzureAdB2C", options));
```

<xref:Microsoft.AspNetCore.Builder.AuthAppBuilderExtensions.UseAuthentication%2A> and <xref:Microsoft.AspNetCore.Builder.AuthorizationAppBuilderExtensions.UseAuthorization%2A> ensure that:

* The app attempts to parse and validate tokens on incoming requests.
* Any request attempting to access a protected resource without proper credentials fails.

```csharp
app.UseAuthentication();
app.UseAuthorization();
```

### User.Identity.Name

By default, the `User.Identity.Name` isn't populated.

To configure the app to receive the value from the `name` claim type:

* Add a namespace for <xref:Microsoft.AspNetCore.Authentication.JwtBearer?displayProperty=fullName> to `Startup.cs`:

  ```csharp
  using Microsoft.AspNetCore.Authentication.JwtBearer;
  ```

* Configure the <xref:Microsoft.IdentityModel.Tokens.TokenValidationParameters.NameClaimType?displayProperty=nameWithType> of the <xref:Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerOptions> in `Startup.ConfigureServices`:

  ```csharp
  services.Configure<JwtBearerOptions>(
      AzureADB2CDefaults.JwtBearerAuthenticationScheme, options =>
      {
          options.TokenValidationParameters.NameClaimType = "name";
      });
  ```

### App settings

The `appsettings.json` file contains the options to configure the JWT bearer handler used to validate access tokens.

```json
{
  "AzureAdB2C": {
    "Instance": "https://{TENANT}.b2clogin.com/",
    "ClientId": "{SERVER API APP CLIENT ID}",
    "Domain": "{TENANT DOMAIN}",
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
    "SignUpSignInPolicyId": "B2C_1_signupsignin1",
  }
}
```

### WeatherForecast controller

The WeatherForecast controller (`Controllers/WeatherForecastController.cs`) exposes a protected API with the [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) applied to the controller. It's **important** to understand that:

* The [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) in this API controller is the only thing that protect this API from unauthorized access.
* The [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) used in the Blazor WebAssembly app only serves as a hint to the app that the user should be authorized for the app to work correctly.

```csharp
[Authorize]
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
        ...
    }
}
```

## **`Client`** app configuration

*This section pertains to the solution's **`Client`** app.*

### Authentication package

When an app is created to use an Individual B2C Account (`IndividualB2C`), the app automatically receives a package reference for the [Microsoft Authentication Library](/azure/active-directory/develop/msal-overview) ([`Microsoft.Authentication.WebAssembly.Msal`](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal)). The package provides a set of primitives that help the app authenticate users and obtain tokens to call protected APIs.

If adding authentication to an app, manually add the [`Microsoft.Authentication.WebAssembly.Msal`](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal) package to the app.

[!INCLUDE[](~/includes/package-reference.md)]

The [`Microsoft.Authentication.WebAssembly.Msal`](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal) package transitively adds the [`Microsoft.AspNetCore.Components.WebAssembly.Authentication`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Authentication) package to the app.

### Authentication service support

Support for <xref:System.Net.Http.HttpClient> instances is added that include access tokens when making requests to the server project.

`Program.cs`:

```csharp
builder.Services.AddHttpClient("{APP ASSEMBLY}.ServerAPI", client => 
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>()
    .CreateClient("{APP ASSEMBLY}.ServerAPI"));
```

The placeholder `{APP ASSEMBLY}` is the app's assembly name (for example, `BlazorSample.Client`).

Support for authenticating users is registered in the service container with the <xref:Microsoft.Extensions.DependencyInjection.MsalWebAssemblyServiceCollectionExtensions.AddMsalAuthentication%2A> extension method provided by the [`Microsoft.Authentication.WebAssembly.Msal`](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal) package. This method sets up the services required for the app to interact with the Identity Provider (IP).

`Program.cs`:

```csharp
builder.Services.AddMsalAuthentication(options =>
{
    builder.Configuration.Bind("AzureAdB2C", options.ProviderOptions.Authentication);
    options.ProviderOptions.DefaultAccessTokenScopes.Add("{SCOPE URI}");
});
```

The <xref:Microsoft.Extensions.DependencyInjection.MsalWebAssemblyServiceCollectionExtensions.AddMsalAuthentication%2A> method accepts a callback to configure the parameters required to authenticate an app. The values required for configuring the app can be obtained from the Azure Portal AAD configuration when you register the app.

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

### Access token scopes

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

> [!NOTE]
> The Blazor WebAssembly template automatically adds a scheme of `api://` to the App ID URI argument passed in the `dotnet new` command. When generating an app from the [Blazor project template](xref:blazor/project-structure), confirm that the value of the default access token scope uses either the correct custom App ID URI value that you provided in the Azure portal or a value with **one** of the following formats:
>
> * When the publisher domain of the directory is **trusted**, the default access token scope is typically a value similar to the following example, where `API.Access` is the default scope name:
>
>   ```csharp
>   options.ProviderOptions.DefaultAccessTokenScopes.Add(
>       "api://41451fa7-82d9-4673-8fa5-69eff5a761fd/API.Access");
>   ```
>
>   Inspect the value for a double scheme (`api://api://...`). If a double scheme is present, remove the first `api://` scheme from the value.
>
> * When the publisher domain of the directory is **untrusted**, the default access token scope is typically a value similar to the following example, where `API.Access` is the default scope name:
>
>   ```csharp
>   options.ProviderOptions.DefaultAccessTokenScopes.Add(
>       "https://contoso.onmicrosoft.com/41451fa7-82d9-4673-8fa5-69eff5a761fd/API.Access");
>   ```
>
>   Inspect the value for an extra `api://` scheme (`api://https://contoso.onmicrosoft.com/...`). If an extra `api://` scheme is present, remove the `api://` scheme from the value.
>
> The Blazor WebAssembly template might be changed in a future release of ASP.NET Core to address these scenarios. For more information, see [Double scheme for App ID URI with Blazor WASM template (hosted, single org) (dotnet/aspnetcore #27417)](https://github.com/dotnet/aspnetcore/issues/27417).

Specify additional scopes with `AdditionalScopesToConsent`:

```csharp
options.ProviderOptions.AdditionalScopesToConsent.Add("{ADDITIONAL SCOPE URI}");
```

For more information, see the following sections of the *Additional scenarios* article:

* [Request additional access tokens](xref:blazor/security/webassembly/additional-scenarios#request-additional-access-tokens)
* [Attach tokens to outgoing requests](xref:blazor/security/webassembly/additional-scenarios#attach-tokens-to-outgoing-requests)

### Imports file

[!INCLUDE[](~/blazor/security/includes/imports-file-hosted.md)]

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

### FetchData component

[!INCLUDE[](~/blazor/security/includes/fetchdata-component.md)]

## Run the app

Run the app from the Server project. When using Visual Studio, either:

* Set the **Startup Projects** drop down list in the toolbar to the *Server API app* and select the **Run** button.
* Select the Server project in **Solution Explorer** and select the **Run** button in the toolbar or start the app from the **Debug** menu.

<!-- HOLD
[!INCLUDE[](~/blazor/security/includes/usermanager-signinmanager.md)]
-->

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
