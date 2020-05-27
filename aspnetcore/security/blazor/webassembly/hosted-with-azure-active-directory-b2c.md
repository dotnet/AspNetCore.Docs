---
title: Secure an ASP.NET Core Blazor WebAssembly hosted app with Azure Active Directory B2C
author: guardrex
description: 
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 05/19/2020
no-loc: [Blazor, "Identity", "Let's Encrypt", Razor, SignalR]
uid: security/blazor/webassembly/hosted-with-azure-active-directory-b2c
---
# Secure an ASP.NET Core Blazor WebAssembly hosted app with Azure Active Directory B2C

By [Javier Calvarro Nelson](https://github.com/javiercn) and [Luke Latham](https://github.com/guardrex)

This article describes how to create a Blazor WebAssembly standalone app that uses [Azure Active Directory (AAD) B2C](/azure/active-directory-b2c/overview) for authentication.

## Register apps in AAD B2C and create solution

### Create a tenant

Follow the guidance in [Tutorial: Create an Azure Active Directory B2C tenant](/azure/active-directory-b2c/tutorial-create-tenant) to create an AAD B2C tenant.

Record the following information:

* AAD B2C instance (for example, `https://contoso.b2clogin.com/`, which includes the trailing slash)
* AAD B2C Tenant domain (for example, `contoso.onmicrosoft.com`)

### Register a server API app

Follow the guidance in [Tutorial: Register an application in Azure Active Directory B2C](/azure/active-directory-b2c/tutorial-register-applications) to register an AAD app for the *Server API app*:

1. In **Azure Active Directory** > **App registrations**, select **New registration**.
1. Provide a **Name** for the app (for example, **Blazor Server AAD B2C**).
1. For **Supported account types**, select the multi-tenant option: **Accounts in any organizational directory or any identity provider. For authenticating users with Azure AD B2C.**
1. The *Server API app* doesn't require a **Redirect URI** in this scenario, so leave the drop down set to **Web** and don't enter a redirect URI.
1. Confirm that **Permissions** > **Grant admin concent to openid and offline_access permissions** is enabled.
1. Select **Register**.

Record the following information:

* *Server API app* Application ID (Client ID) (for example, `11111111-1111-1111-1111-111111111111`)
* Directory ID (Tenant ID) (for example, `222222222-2222-2222-2222-222222222222`)
* AAD Tenant domain (for example, `contoso.onmicrosoft.com`): The domain is available as the **Publisher domain** in the **Branding** blade of the Azure portal for the registered app.

In **Expose an API**:

1. Select **Add a scope**.
1. Select **Save and continue**.
1. Provide a **Scope name** (for example, `API.Access`).
1. Provide an **Admin consent display name** (for example, `Access API`).
1. Provide an **Admin consent description** (for example, `Allows the app to access server app API endpoints.`).
1. Confirm that the **State** is set to **Enabled**.
1. Select **Add scope**.

Record the following information:

* App ID URI (for example, `https://contoso.onmicrosoft.com/11111111-1111-1111-1111-111111111111`, `api://11111111-1111-1111-1111-111111111111`, or the custom value that you provided)
* Default scope (for example, `API.Access`)

### Register a client app

Follow the guidance in [Tutorial: Register an application in Azure Active Directory B2C](/azure/active-directory-b2c/tutorial-register-applications) again to register an AAD app for the *Client app*:

1. In **Azure Active Directory** > **App registrations**, select **New registration**.
1. Provide a **Name** for the app (for example, **Blazor Client AAD B2C**).
1. For **Supported account types**, select the multi-tenant option: **Accounts in any organizational directory or any identity provider. For authenticating users with Azure AD B2C.**
1. Leave the **Redirect URI** drop down set to **Web** and provide the following redirect URI: `https://localhost:{PORT}/authentication/login-callback`. The default port for an app running on Kestrel is 5001. If the app is run on a different Kestrel port, use the app's port. For IIS Express, the randomly generated port for the app can be found in the Server app's properties in the **Debug** panel. Since the app doesn't exist at this point and the IIS Express port isn't known, return to this step after the app is created and update the redirect URI. A remark appears in the [Create the app](#create-the-app) section to remind IIS Express users to update the redirect URI.
1. Confirm that **Permissions** > **Grant admin concent to openid and offline_access permissions** is enabled.
1. Select **Register**.

Record the Application ID (Client ID) (for example, `11111111-1111-1111-1111-111111111111`).

In **Authentication** > **Platform configurations** > **Web**:

1. Confirm the **Redirect URI** of `https://localhost:{PORT}/authentication/login-callback` is present.
1. For **Implicit grant**, select the check boxes for **Access tokens** and **ID tokens**.
1. The remaining defaults for the app are acceptable for this experience.
1. Select the **Save** button.

In **API permissions**:

1. Select **Add a permission** followed by **My APIs**.
1. Select the *Server API app* from the **Name** column (for example, **Blazor Server AAD B2C**).
1. Open the **API** list.
1. Enable access to the API (for example, `API.Access`).
1. Select **Add permissions**.
1. Select the **Grant admin content for {TENANT NAME}** button. Select **Yes** to confirm.

In **Home** > **Azure AD B2C** > **User flows**:

[Create a sign-up and sign-in user flow](/azure/active-directory-b2c/tutorial-create-user-flows)

At a minimum, select the **Application claims** > **Display Name** user attribute to populate the `context.User.Identity.Name` in the `LoginDisplay` component (*Shared/LoginDisplay.razor*).

Record the sign-up and sign-in user flow name created for the app (for example, `B2C_1_signupsignin`).

### Create the app

Replace the placeholders in the following command with the information recorded earlier and execute the command in a command shell:

```dotnetcli
dotnet new blazorwasm -au IndividualB2C --aad-b2c-instance "{AAD B2C INSTANCE}" --api-client-id "{SERVER API APP CLIENT ID}" --app-id-uri "{SERVER API APP ID URI}" --client-id "{CLIENT APP CLIENT ID}" --default-scope "{DEFAULT SCOPE}" --domain "{TENANT DOMAIN}" -ho -ssp "{SIGN UP OR SIGN IN POLICY}" --tenant-id "{TENANT ID}"
```

To specify the output location, which creates a project folder if it doesn't exist, include the output option in the command with a path (for example, `-o BlazorSample`). The folder name also becomes part of the project's name.

> [!NOTE]
> Pass the App ID URI to the `app-id-uri` option, but note a configuration change might be required in the client app, which is described in the [Access token scopes](#access-token-scopes) section.
>
> Additionally, the scope set up by the Hosted Blazor template might have the App ID URI host repeated. Confirm that the scope configured for the `DefaultAccessTokenScopes` collection is correct in `Program.Main` (*Program.cs*) of the *Client app*.

> [!NOTE]
> In the Azure portal, the *Client app's* **Authentication** > **Platform configurations** > **Web** > **Redirect URI** is configured for port 5001 for apps that run on the Kestrel server with default settings.
>
> If the *Client app* is run on a random IIS Express port, the port for the app can be found in the *Server app's* properties in the **Debug** panel.
>
> If the port wasn't configured earlier with the *Client app's* known port, return to the *Client app's* registration in the Azure portal and update the redirect URI with the correct port.

## Server app configuration

*This section pertains to the solution's **Server** app.*

### Authentication package

The support for authenticating and authorizing calls to ASP.NET Core Web APIs is provided by the [Microsoft.AspNetCore.Authentication.AzureADB2C.UI](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.AzureADB2C.UI/) package:

```xml
<PackageReference Include="Microsoft.AspNetCore.Authentication.AzureADB2C.UI" 
  Version="3.1.4" />
```

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

To configure the app to receive the value from the `name` claim type, configure the [TokenValidationParameters.NameClaimType](xref:Microsoft.IdentityModel.Tokens.TokenValidationParameters.NameClaimType) of the <xref:Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerOptions> in `Startup.ConfigureServices`:

```csharp
using Microsoft.AspNetCore.Authentication.JwtBearer;

...

services.Configure<JwtBearerOptions>(
    AzureADB2CDefaults.JwtBearerAuthenticationScheme, options =>
    {
        options.TokenValidationParameters.NameClaimType = "name";
    });
```

### App settings

The *appsettings.json* file contains the options to configure the JWT bearer handler used to validate access tokens.

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

## Client app configuration

*This section pertains to the solution's **Client** app.*

### Authentication package

When an app is created to use an Individual B2C Account (`IndividualB2C`), the app automatically receives a package reference for the [Microsoft Authentication Library](/azure/active-directory/develop/msal-overview) ([Microsoft.Authentication.WebAssembly.Msal](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal/)). The package provides a set of primitives that help the app authenticate users and obtain tokens to call protected APIs.

If adding authentication to an app, manually add the package to the app's project file:

```xml
<PackageReference Include="Microsoft.Authentication.WebAssembly.Msal" 
  Version="3.2.0" />
```

The [Microsoft.Authentication.WebAssembly.Msal](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal/) package transitively adds the [Microsoft.AspNetCore.Components.WebAssembly.Authentication](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Authentication/) package to the app.

### Authentication service support

Support for <xref:System.Net.Http.HttpClient> instances is added that include access tokens when making requests to the server project.

*Program.cs*:

```csharp
builder.Services.AddHttpClient("{APP ASSEMBLY}.ServerAPI", client => 
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

builder.Services.AddTransient(sp => sp.GetRequiredService<IHttpClientFactory>()
    .CreateClient("{APP ASSEMBLY}.ServerAPI"));
```

Support for authenticating users is registered in the service container with the <xref:Microsoft.Extensions.DependencyInjection.MsalWebAssemblyServiceCollectionExtensions.AddMsalAuthentication%2A> extension method provided by the [Microsoft.Authentication.WebAssembly.Msal](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal/) package. This method sets up the services required for the app to interact with the Identity Provider (IP).

*Program.cs*:

```csharp
builder.Services.AddMsalAuthentication(options =>
{
    builder.Configuration.Bind("AzureAdB2C", options.ProviderOptions.Authentication);
    options.ProviderOptions.DefaultAccessTokenScopes.Add("{SCOPE URI}");
});
```

The <xref:Microsoft.Extensions.DependencyInjection.MsalWebAssemblyServiceCollectionExtensions.AddMsalAuthentication%2A> method accepts a callback to configure the parameters required to authenticate an app. The values required for configuring the app can be obtained from the Azure Portal AAD configuration when you register the app.

Configuration is supplied by the *wwwroot/appsettings.json* file:

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

[!INCLUDE[](~/includes/blazor-security/azure-scope.md)]

For more information, see the following sections of the *Additional scenarios* article:

* [Request additional access tokens](xref:security/blazor/webassembly/additional-scenarios#request-additional-access-tokens)
* [Attach tokens to outgoing requests](xref:security/blazor/webassembly/additional-scenarios#attach-tokens-to-outgoing-requests)


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

[!INCLUDE[](~/includes/blazor-security/wasm-aad-b2c-userflows.md)]

[!INCLUDE[](~/includes/blazor-security/troubleshoot.md)]

## Additional resources

* <xref:security/blazor/webassembly/additional-scenarios>
* [Unauthenticated or unauthorized web API requests in an app with a secure default client](xref:security/blazor/webassembly/additional-scenarios#unauthenticated-or-unauthorized-web-api-requests-in-an-app-with-a-secure-default-client)
* <xref:security/authentication/azure-ad-b2c>
* [Tutorial: Create an Azure Active Directory B2C tenant](/azure/active-directory-b2c/tutorial-create-tenant)
* [Microsoft identity platform documentation](/azure/active-directory/develop/)
