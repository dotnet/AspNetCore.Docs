---
title: Secure an ASP.NET Core Blazor WebAssembly hosted app with Azure Active Directory
author: guardrex
description: Learn how to secure an ASP.NET Core Blazor WebAssembly hosted app with Azure Active Directory.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: "devx-track-csharp, mvc"
ms.date: 10/27/2020
no-loc: [appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/security/webassembly/hosted-with-azure-active-directory
---
# Secure an ASP.NET Core Blazor WebAssembly hosted app with Azure Active Directory

By [Javier Calvarro Nelson](https://github.com/javiercn) and [Luke Latham](https://github.com/guardrex)

This article describes how to create a [hosted Blazor WebAssembly app](xref:blazor/hosting-models#blazor-webassembly) that uses [Azure Active Directory (AAD)](https://azure.microsoft.com/services/active-directory/) for authentication.

::: moniker range=">= aspnetcore-5.0"

> [!NOTE]
> For Blazor WebAssembly apps created in Visual Studio that are configured to support accounts in an AAD organizational directory, Visual Studio doesn't configure the app correctly on project generation. This will be addressed in a future release of Visual Studio. This article shows how to create the app with the .NET Core CLI's `dotnet new` command. If you prefer to create the app with Visual Studio before the IDE is updated for the latest Blazor templates in ASP.NET Core 5.0, refer to each section of this article and confirm or update the app's configuration after Visual Studio creates the app.

::: moniker-end

## Register apps in AAD and create solution

### Create a tenant

Follow the guidance in [Quickstart: Set up a tenant](/azure/active-directory/develop/quickstart-create-new-tenant) to create a tenant in AAD.

### Register a server API app

Follow the guidance in [Quickstart: Register an application with the Microsoft identity platform](/azure/active-directory/develop/quickstart-register-app) and subsequent Azure AAD topics to register an AAD app for the *Server API app* and then do the following:

1. In **Azure Active Directory** > **App registrations**, select **New registration**.
1. Provide a **Name** for the app (for example, **Blazor Server AAD**).
1. Choose a **Supported account types**. You may select **Accounts in this organizational directory only** (single tenant) for this experience.
1. The *Server API app* doesn't require a **Redirect URI** in this scenario, so leave the drop down set to **Web** and don't enter a redirect URI.
1. Clear the **Permissions** > **Grant admin consent to openid and offline_access permissions** check box.
1. Select **Register**.

Record the following information:

* *Server API app* Application (client) ID (for example, `41451fa7-82d9-4673-8fa5-69eff5a761fd`)
* Directory (tenant) ID (for example, `e86c78e2-8bb4-4c41-aefd-918e0565a45e`)
* AAD Primary/Publisher/Tenant domain (for example, `contoso.onmicrosoft.com`): The domain is available as the **Publisher domain** in the **Branding** blade of the Azure portal for the registered app.

In **API permissions**, remove the **Microsoft Graph** > **User.Read** permission, as the app doesn't require sign in or user profile access.

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

### Register a client app

Follow the guidance in [Quickstart: Register an application with the Microsoft identity platform](/azure/active-directory/develop/quickstart-register-app) and subsequent Azure AAD topics to register a AAD app for the *`Client`* app and then do the following:

::: moniker range=">= aspnetcore-5.0"

1. In **Azure Active Directory** > **App registrations**, select **New registration**.
1. Provide a **Name** for the app (for example, **Blazor Client AAD**).
1. Choose a **Supported account types**. You may select **Accounts in this organizational directory only** (single tenant) for this experience.
1. Set the **Redirect URI** drop down to **Single-page application (SPA)** and provide the following redirect URI: `https://localhost:{PORT}/authentication/login-callback`. The default port for an app running on Kestrel is 5001. If the app is run on a different Kestrel port, use the app's port. For IIS Express, the randomly generated port for the app can be found in the *`Server`* app's properties in the **Debug** panel. Since the app doesn't exist at this point and the IIS Express port isn't known, return to this step after the app is created and update the redirect URI. A remark appears in the [Create the app](#create-the-app) section to remind IIS Express users to update the redirect URI.
1. Clear the **Permissions** > **Grant admin consent to openid and offline_access permissions** check box.
1. Select **Register**.

Record the *`Client`* app Application (client) ID (for example, `4369008b-21fa-427c-abaa-9b53bf58e538`).

In **Authentication** > **Platform configurations** > **Single-page application (SPA)**:

1. Confirm the **Redirect URI** of `https://localhost:{PORT}/authentication/login-callback` is present.
1. For **Implicit grant**, ensure that the check boxes for **Access tokens** and **ID tokens** are **not** selected.
1. The remaining defaults for the app are acceptable for this experience.
1. Select the **Save** button.

::: moniker-end

::: moniker range="< aspnetcore-5.0"

1. In **Azure Active Directory** > **App registrations**, select **New registration**.
1. Provide a **Name** for the app (for example, **Blazor Client AAD**).
1. Choose a **Supported account types**. You may select **Accounts in this organizational directory only** (single tenant) for this experience.
1. Leave the **Redirect URI** drop down set to **Web** and provide the following redirect URI: `https://localhost:{PORT}/authentication/login-callback`. The default port for an app running on Kestrel is 5001. If the app is run on a different Kestrel port, use the app's port. For IIS Express, the randomly generated port for the app can be found in the *`Server`* app's properties in the **Debug** panel. Since the app doesn't exist at this point and the IIS Express port isn't known, return to this step after the app is created and update the redirect URI. A remark appears in the [Create the app](#create-the-app) section to remind IIS Express users to update the redirect URI.
1. Clear the **Permissions** > **Grant admin consent to openid and offline_access permissions** check box.
1. Select **Register**.

Record the *`Client`* app Application (client) ID (for example, `4369008b-21fa-427c-abaa-9b53bf58e538`).

In **Authentication** > **Platform configurations** > **Web**:

1. Confirm the **Redirect URI** of `https://localhost:{PORT}/authentication/login-callback` is present.
1. For **Implicit grant**, select the check boxes for **Access tokens** and **ID tokens**.
1. The remaining defaults for the app are acceptable for this experience.
1. Select the **Save** button.

::: moniker-end

In **API permissions**:

1. Confirm that the app has **Microsoft Graph** > **User.Read** permission.
1. Select **Add a permission** followed by **My APIs**.
1. Select the *Server API app* from the **Name** column (for example, **Blazor Server AAD**).
1. Open the **API** list.
1. Enable access to the API (for example, `API.Access`).
1. Select **Add permissions**.
1. Select the **Grant admin consent for {TENANT NAME}** button. Select **Yes** to confirm.

### Create the app

In an empty folder, replace the placeholders in the following command with the information recorded earlier and execute the command in a command shell:

```dotnetcli
dotnet new blazorwasm -au SingleOrg --api-client-id "{SERVER API APP CLIENT ID}" --app-id-uri "{SERVER API APP ID URI}" --client-id "{CLIENT APP CLIENT ID}" --default-scope "{DEFAULT SCOPE}" --domain "{TENANT DOMAIN}" -ho -o {APP NAME} --tenant-id "{TENANT ID}"
```

| Placeholder                  | Azure portal name                                     | Example                                      |
| ---------------------------- | ----------------------------------------------------- | -------------------------------------------- |
| `{APP NAME}`                 | &mdash;                                               | `BlazorSample`                               |
| `{CLIENT APP CLIENT ID}`     | Application (client) ID for the *`Client`* app        | `4369008b-21fa-427c-abaa-9b53bf58e538`       |
| `{DEFAULT SCOPE}`            | Scope name                                            | `API.Access`                                 |
| `{SERVER API APP CLIENT ID}` | Application (client) ID for the *Server API app*      | `41451fa7-82d9-4673-8fa5-69eff5a761fd`       |
| `{SERVER API APP ID URI}`    | Application ID URI                                    | `api://41451fa7-82d9-4673-8fa5-69eff5a761fd` |
| `{TENANT DOMAIN}`            | Primary/Publisher/Tenant domain                       | `contoso.onmicrosoft.com`                    |
| `{TENANT ID}`                | Directory (tenant) ID                                 | `e86c78e2-8bb4-4c41-aefd-918e0565a45e`       |

The output location specified with the `-o|--output` option creates a project folder if it doesn't exist and becomes part of the app's name.

::: moniker range=">= aspnetcore-5.0"

> [!NOTE]
> A configuration change might be required when using an Azure tenant with an unverified publisher domain, which is described in the [App settings](#app-settings) section.

::: moniker-end

::: moniker range="< aspnetcore-5.0"

> [!NOTE]
> A configuration change might be required when using an Azure tenant with an unverified publisher domain, which is described in the [Access token scopes](#access-token-scopes) section.

::: moniker-end

> [!NOTE]
> In the Azure portal, the *`Client`* app's platform configuration **Redirect URI** is configured for port 5001 for apps that run on the Kestrel server with default settings.
>
> If the *`Client`* app is run on a random IIS Express port, the port for the app can be found in the *Server API app's* properties in the **Debug** panel.
>
> If the port wasn't configured earlier with the *`Client`* app's known port, return to the *`Client`* app's registration in the Azure portal and update the redirect URI with the correct port.

## *`Server`* app configuration

*This section pertains to the solution's **`Server`** app.*

### Authentication package

::: moniker range=">= aspnetcore-5.0"

The support for authenticating and authorizing calls to ASP.NET Core Web APIs with the Microsoft Identity Platform is provided by the following packages:

* [`Microsoft.Identity.Web`](https://www.nuget.org/packages/Microsoft.Identity.Web)
* [`Microsoft.Identity.Web.UI`](https://www.nuget.org/packages/Microsoft.Identity.Web.UI)

```xml
<PackageReference Include="Microsoft.Identity.Web" Version="{VERSION}" />
<PackageReference Include="Microsoft.Identity.Web.UI" Version="{VERSION}" />
```

For the placeholder `{VERSION}`, the latest stable version of the package that matches the app's shared framework version can be found in the package's **Version History** at NuGet.org.

::: moniker-end

::: moniker range="< aspnetcore-5.0"

The support for authenticating and authorizing calls to ASP.NET Core Web APIs is provided by the [`Microsoft.AspNetCore.Authentication.AzureAD.UI`](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.AzureAD.UI) package:

```xml
<PackageReference Include="Microsoft.AspNetCore.Authentication.AzureAD.UI" 
  Version="{VERSION}" />
```

For the placeholder `{VERSION}`, the latest stable version of the package that matches the app's shared framework version can be found in the package's **Version History** at [NuGet.org](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.AzureAD.UI).

::: moniker-end

### Authentication service support

::: moniker range=">= aspnetcore-5.0"

The `AddAuthentication` method sets up authentication services within the app and configures the JWT Bearer handler as the default authentication method. The <xref:Microsoft.Identity.Web.MicrosoftIdentityWebApiAuthenticationBuilderExtensions.AddMicrosoftIdentityWebApi%2A> method configures services to protect the web API with Microsoft Identity Platform v2.0. This method expects an `AzureAd` section in the app's configuration with the necessary settings to initialize authentication options.

```csharp
services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(Configuration.GetSection("AzureAd"));
```

::: moniker-end

::: moniker range="< aspnetcore-5.0"

The `AddAuthentication` method sets up authentication services within the app and configures the JWT Bearer handler as the default authentication method. The <xref:Microsoft.AspNetCore.Authentication.AzureADAuthenticationBuilderExtensions.AddAzureADBearer%2A> method sets up the specific parameters in the JWT Bearer handler required to validate tokens emitted by the Azure Active Directory:

```csharp
services.AddAuthentication(AzureADDefaults.BearerAuthenticationScheme)
    .AddAzureADBearer(options => Configuration.Bind("AzureAd", options));
```

::: moniker-end

<xref:Microsoft.AspNetCore.Builder.AuthAppBuilderExtensions.UseAuthentication%2A> and <xref:Microsoft.AspNetCore.Builder.AuthorizationAppBuilderExtensions.UseAuthorization%2A> ensure that:

* The app attempts to parse and validate tokens on incoming requests.
* Any request attempting to access a protected resource without proper credentials fails.

```csharp
app.UseAuthentication();
app.UseAuthorization();
```

### User.Identity.Name

By default, the *`Server`* app API populates `User.Identity.Name` with the value from the `http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name` claim type (for example, `2d64b3da-d9d5-42c6-9352-53d8df33d770@contoso.onmicrosoft.com`).

To configure the app to receive the value from the `name` claim type, configure the <xref:Microsoft.IdentityModel.Tokens.TokenValidationParameters.NameClaimType?displayProperty=nameWithType> of the <xref:Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerOptions> in `Startup.ConfigureServices`:

```csharp
using Microsoft.AspNetCore.Authentication.JwtBearer;

...

services.Configure<JwtBearerOptions>(
    AzureADDefaults.JwtBearerAuthenticationScheme, options =>
    {
        options.TokenValidationParameters.NameClaimType = "name";
    });
```

### App settings

::: moniker range=">= aspnetcore-5.0"

The `appsettings.json` file contains the options to configure the JWT bearer handler used to validate access tokens:

```json
{
  "AzureAd": {
    "Instance": "https://login.microsoftonline.com/",
    "Domain": "{DOMAIN}",
    "TenantId": "{TENANT ID}",
    "ClientId": "{SERVER API APP CLIENT ID}",
    "CallbackPath": "/signin-oidc"
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
    "CallbackPath": "/signin-oidc"
  }
}
```

[!INCLUDE[](~/includes/blazor-security/azure-scope-5x.md)]

::: moniker-end

::: moniker range="< aspnetcore-5.0"

The `appsettings.json` file contains the options to configure the JWT bearer handler used to validate access tokens:

```json
{
  "AzureAd": {
    "Instance": "https://login.microsoftonline.com/",
    "Domain": "{DOMAIN}",
    "TenantId": "{TENANT ID}",
    "ClientId": "{SERVER API APP CLIENT ID}",
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
  }
}
```

::: moniker-end

### WeatherForecast controller

The WeatherForecast controller (*Controllers/WeatherForecastController.cs*) exposes a protected API with the [`[Authorize]`](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) attribute applied to the controller. It's **important** to understand that:

* The [`[Authorize]`](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) attribute in this API controller is the only thing that protect this API from unauthorized access.
* The [`[Authorize]`](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) attribute used in the Blazor WebAssembly app only serves as a hint to the app that the user should be authorized for the app to work correctly.

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

## *`Client`* app configuration

*This section pertains to the solution's **`Client`** app.*

### Authentication package

When an app is created to use Work or School Accounts (`SingleOrg`), the app automatically receives a package reference for the [Microsoft Authentication Library](/azure/active-directory/develop/msal-overview) ([`Microsoft.Authentication.WebAssembly.Msal`](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal)). The package provides a set of primitives that help the app authenticate users and obtain tokens to call protected APIs.

If adding authentication to an app, manually add the package to the app's project file:

```xml
<PackageReference Include="Microsoft.Authentication.WebAssembly.Msal" 
  Version="{VERSION}" />
```

For the placeholder `{VERSION}`, the latest stable version of the package that matches the app's shared framework version can be found in the package's **Version History** at [NuGet.org](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal).

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

The placeholder `{APP ASSEMBLY}` is the app's assembly name (for example, `BlazorSample.ServerAPI`).

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

### Login mode

[!INCLUDE[](~/includes/blazor-security/msal-login-mode.md)]

::: moniker-end

### Imports file

[!INCLUDE[](~/includes/blazor-security/imports-file-hosted.md)]

### Index page

[!INCLUDE[](~/includes/blazor-security/index-page-msal.md)]

### App component

[!INCLUDE[](~/includes/blazor-security/app-component.md)]

### RedirectToLogin component

[!INCLUDE[](~/includes/blazor-security/redirecttologin-component.md)]

### LoginDisplay component

[!INCLUDE[](~/includes/blazor-security/logindisplay-component.md)]

### Authentication component

[!INCLUDE[](~/includes/blazor-security/authentication-component.md)]

### FetchData component

[!INCLUDE[](~/includes/blazor-security/fetchdata-component.md)]

## Run the app

Run the app from the Server project. When using Visual Studio, either:

* Set the **Startup Projects** drop down list in the toolbar to the *Server API app* and select the **Run** button.
* Select the Server project in **Solution Explorer** and select the **Run** button in the toolbar or start the app from the **Debug** menu.

<!-- HOLD
[!INCLUDE[](~/includes/blazor-security/usermanager-signinmanager.md)]
-->

[!INCLUDE[](~/includes/blazor-security/troubleshoot.md)]

## Additional resources

* <xref:blazor/security/webassembly/additional-scenarios>
* [Unauthenticated or unauthorized web API requests in an app with a secure default client](xref:blazor/security/webassembly/additional-scenarios#unauthenticated-or-unauthorized-web-api-requests-in-an-app-with-a-secure-default-client)
* <xref:blazor/security/webassembly/aad-groups-roles>
* <xref:security/authentication/azure-active-directory/index>
* [Microsoft identity platform documentation](/azure/active-directory/develop/)
