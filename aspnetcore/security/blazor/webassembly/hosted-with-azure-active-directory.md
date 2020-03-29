---
title: Secure an ASP.NET Core Blazor WebAssembly hosted app with Azure Active Directory
author: guardrex
description: 
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 03/16/2020
no-loc: [Blazor, SignalR]
uid: security/blazor/webassembly/hosted-with-azure-active-directory
---
# Secure an ASP.NET Core Blazor WebAssembly hosted app with Azure Active Directory

By [Javier Calvarro Nelson](https://github.com/javiercn) and [Luke Latham](https://github.com/guardrex)

[!INCLUDE[](~/includes/blazorwasm-preview-notice.md)]

[!INCLUDE[](~/includes/blazorwasm-3.2-template-article-notice.md)]



This article describes how to create a [Blazor WebAssembly hosted app](xref:blazor/hosting-models#blazor-webassembly) that uses [Azure Active Directory (AAD)](https://azure.microsoft.com/services/active-directory/) for authentication.

## Register apps in AAD B2C and create solution

### Create a tenant

Follow the guidance in [Quickstart: Set up a tenant](/azure/active-directory/develop/quickstart-create-new-tenant) to create a tenant in AAD.

### Register a server API app

Follow the guidance in [Quickstart: Register an application with the Microsoft identity platform](/azure/active-directory/develop/quickstart-register-app) and subsequent Azure AAD topics to register an AAD app for the *Server API app* in the **Azure Active Directory** > **App registrations** area of the Azure portal:

1. Select **New registration**.
1. Provide a **Name** for the app (for example, **Blazor Server AAD**).
1. Choose a **Supported account types**. You may select **Accounts in this organizational directory only** (single tenant) for this experience.
1. The *Server API app* doesn't require a **Redirect URI** in this scenario, so leave the drop down set to **Web** and don't enter a redirect URI.
1. Disable the **Permissions** > **Grant admin concent to openid and offline_access permissions** check box.
1. Select **Register**.

In **API permissions**, remove the **Microsoft Graph** > **User.Read** permission, as the app doesn't require sign in or uer profile access.

In **Expose an API**:

1. Select **Add a scope**.
1. Select **Save and continue**.
1. Provide a **Scope name** (for example, `API.Access`).
1. Provide an **Admin consent display name** (for example, `Access API`).
1. Provide an **Admin consent description** (for example, `Allows the app to access server app API endpoints.`).
1. Confirm that the **State** is set to **Enabled**.
1. Select **Add scope**.

Record the following information:

* *Server API app* Application ID (Client ID) (for example, `11111111-1111-1111-1111-111111111111`)
* Directory ID (Tenant ID) (for example, `222222222-2222-2222-2222-222222222222`)
* AAD Tenant domain (for example, `contoso.onmicrosoft.com`)
* Default scope (for example, `API.Access`)

### Register a client app

Follow the guidance in [Quickstart: Register an application with the Microsoft identity platform](/azure/active-directory/develop/quickstart-register-app) and subsequent Azure AAD topics to register a AAD app for the *Client app* in the **Azure Active Directory** > **App registrations** area of the Azure portal:

1. Select **New registration**.
1. Provide a **Name** for the app (for example, **Blazor Client AAD**).
1. Choose a **Supported account types**. You may select **Accounts in this organizational directory only** (single tenant) for this experience.
1. Leave the **Redirect URI** drop down set to **Web**, and provide a redirect URI of `https://localhost:5001/authentication/login-callback`.
1. Disable the **Permissions** > **Grant admin concent to openid and offline_access permissions** check box.
1. Select **Register**.

In **Authentication** > **Platform configurations** > **Web**:

1. Confirm the **Redirect URI** of `https://localhost:5001/authentication/login-callback` is present.
1. For **Implicit grant**, select the check boxes for **Access tokens** and **ID tokens**.
1. The remaining defaults for the app are acceptable for this experience.
1. Select the **Save** button.

In **API permissions**:

1. Confirm that the app has **Microsoft Graph** > **User.Read** permission.
1. Select **Add a permission** followed by **My APIs**.
1. Select the *Server API app* from the **Name** column (for example, **Blazor Server AAD**).
1. Open the **API** list.
1. Enable access to the API (for example, `API.Access`).
1. Select **Add permissions**.
1. Select the **Grant admin content for {TENANT NAME}** button. Select **Yes** to confirm.

Record the *Client app* Application ID (Client ID) (for example, `33333333-3333-3333-3333-333333333333`).

### Create the app

Replace the placeholders in the following command with the information recorded earlier and execute the command in a command shell:

```dotnetcli
dotnet new blazorwasm -au SingleOrg --api-client-id "{SERVER API APP CLIENT ID}" --app-id-uri "{SERVER API APP CLIENT ID}" --client-id "{CLIENT APP CLIENT ID}" --default-scope "{DEFAULT SCOPE}" --domain "{DOMAIN}" -ho --tenant-id "{TENANT ID}"
```

To specify the output location, which creates a project folder if it doesn't exist, include the output option in the command with a path (for example, `-o BlazorSample`). The folder name also becomes part of the project's name.

> [!NOTE]
> See the [Authentication service support](#Authentication service support) section for an important configuration change to the default access token scope. The value provided by the Blazor WebAssembly template must be manually changed after the *Client app* is created from the template.

## Server app configuration

*This section pertains to the solution's **Server** app.*

### Authentication package

The support for authenticating and authorizing calls to ASP.NET Core Web APIs is provided by the `Microsoft.AspNetCore.Authentication.AzureAD.UI`:

```xml
<PackageReference Include="Microsoft.AspNetCore.Authentication.AzureAD.UI" 
    Version="3.1.0" />
```

### Authentication service support

The `AddAuthentication` method sets up authentication services within the app and configures the JWT Bearer handler as the default authentication method. The `AddAzureADBearer` method sets up the specific parameters in the JWT Bearer handler required to validate tokens emitted by the Azure Active Directory:

```csharp
services.AddAuthentication(AzureADDefaults.BearerAuthenticationScheme)
    .AddAzureADBearer(options => Configuration.Bind("AzureAd", options));
```

`UseAuthentication` and `UseAuthorization` ensure that:

* The app attempts to parse and validate tokens on incoming requests.
* Any request attempting to access a protected resource without proper credentials fails.

```csharp
app.UseAuthentication();
app.UseAuthorization();
```

### App settings

The *appsettings.json* file contains the options to configure the JWT bearer handler used to validate access tokens.

```json
{
  "AzureAd": {
    "Instance": "https://login.microsoftonline.com/",
    "Domain": "{DOMAIN}",
    "TenantId": "{TENANT ID}",
    "ClientId": "{API CLIENT ID}",
  }
}
```

### WeatherForecast controller

The WeatherForecast controller (*Controllers/WeatherForecastController.cs*) exposes a protected API with the `[Authorize]` attribute applied to the controller. It's **important** to understand that:

* The `[Authorize]` attribute in this API controller is the only thing that protect this API from unauthorized access.
* The `[Authorize]` attribute used in the Blazor WebAssembly app only serves as a hint to the app that the user should be authorized for the app to work correctly.

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

## Client app configuration

*This section pertains to the solution's **Client** app.*

### Authentication package

When an app is created to use Work or School Accounts (`SingleOrg`), the app automatically receives a package reference for the [Microsoft Authentication Library](/azure/active-directory/develop/msal-overview) (`Microsoft.Authentication.WebAssembly.Msal`). The package provides a set of primitives that help the app authenticate users and obtain tokens to call protected APIs.

If adding authentication to an app, manually add the package to the app's project file:

```xml
<PackageReference Include="Microsoft.Authentication.WebAssembly.Msal" 
    Version="{VERSION}" />
```

Replace `{VERSION}` in the preceding package reference with the version of the `Microsoft.AspNetCore.Blazor.Templates` package shown in the <xref:blazor/get-started> article.

The `Microsoft.Authentication.WebAssembly.Msal` package transitively adds the `Microsoft.AspNetCore.Components.WebAssembly.Authentication` package to the app.

### Authentication service support

Support for authenticating users is registered in the service container with the `AddMsalAuthentication` extension method provided by the `Microsoft.Authentication.WebAssembly.Msal` package. This method sets up all of the services required for the app to interact with the Identity Provider (IP).

*Program.cs*:

When the *Client app* is generated, the default access token scope is of the format `api://{SERVER API APP CLIENT ID}/{DEFAULT SCOPE}`. **Remove the `api://` portion of the scope value.** This issue will be addressed in a future preview release.

```csharp
builder.Services.AddMsalAuthentication(options =>
{
    var authentication = options.ProviderOptions.Authentication;
    authentication.Authority = "https://login.microsoftonline.com/{TENANT ID}";
    authentication.ClientId = "{CLIENT ID}";
    options.ProviderOptions.DefaultAccessTokenScopes.Add(
        "{SERVER API APP CLIENT ID}/{DEFAULT SCOPE}");
});
```

> [!NOTE]
> The default access token scope must be in the format `{SERVER API APP CLIENT ID}/{DEFAULT SCOPE}` (for example, `11111111-1111-1111-1111-111111111111/API.Access`). If a scheme or scheme and host is provided to the scope setting (as shown in the Azure Portal), the *Client app* throws an unhandled exception when it receives a *401 Unauthorized* response from the *Server API app*.

The `AddMsalAuthentication` method accepts a callback to configure the parameters required to authenticate an app. The values required for configuring the app can be obtained from the Azure Portal AAD configuration when you register the app.

The default access token scopes represent the list of access token scopes that are:

* Included by default in the sign in request.
* Used to provision an access token immediately after authentication.

All scopes must belong to the same app per Azure Active Directory rules. Additional scopes can be added for additional API apps as needed:

```csharp
builder.Services.AddMsalAuthentication(options =>
{
    ...
    options.ProviderOptions.DefaultAccessTokenScopes.Add(
        "{SERVER API APP CLIENT ID}/{SCOPE}");
});
```

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

Run the app from the Server project. When using Visual Studio, select the Server project in **Solution Explorer** and select the **Run** button in the toolbar or start the app from the **Debug** menu.

[!INCLUDE[](~/includes/blazor-security/troubleshoot.md)]

## Additional resources

* <xref:security/authentication/azure-active-directory/index>
