---
title: Secure an ASP.NET Core Blazor Web App with Microsoft Entra ID
author: guardrex
description: Learn how to secure a Blazor Web App with Microsoft Entra ID.
monikerRange: '>= aspnetcore-9.0'
ms.author: riande
ms.custom: mvc
ms.date: 04/29/2025
uid: blazor/security/blazor-web-app-entra
zone_pivot_groups: blazor-web-app-entra-specification
---
# Secure an ASP.NET Core Blazor Web App with Microsoft Entra ID

<!-- UPDATE 10.0 Activate after release and INCLUDE is updated

[!INCLUDE[](~/includes/not-latest-version.md)]

-->

This article describes how to secure a Blazor Web App with [Microsoft identity platform](/entra/identity-platform/)/[Microsoft Identity Web packages](/entra/msal/dotnet/microsoft-identity-web/) for [Microsoft Entra ID](https://www.microsoft.com/security/business/microsoft-entra) using a sample app.

:::zone pivot="non-bff-pattern"

This version of the article covers implementing Entra without adopting the [Backend for Frontend (BFF) pattern](/azure/architecture/patterns/backends-for-frontends). The BFF pattern is useful for making authenticated requests to external services. Change the article version selector to **BFF pattern** if the app's specification calls for adopting the BFF pattern.

The following specification is covered:

* The Blazor Web App uses the [Auto render mode with global interactivity (`InteractiveAuto`)](xref:blazor/components/render-modes).
* The server project calls <xref:Microsoft.Extensions.DependencyInjection.WebAssemblyRazorComponentsBuilderExtensions.AddAuthenticationStateSerialization%2A> to add a server-side authentication state provider that uses <xref:Microsoft.AspNetCore.Components.PersistentComponentState> to flow the authentication state to the client. The client calls <xref:Microsoft.Extensions.DependencyInjection.WebAssemblyAuthenticationServiceCollectionExtensions.AddAuthenticationStateDeserialization%2A> to deserialize and use the authentication state passed by the server. The authentication state is fixed for the lifetime of the WebAssembly application.
* The app uses [Microsoft Entra ID](https://www.microsoft.com/security/business/microsoft-entra), based on [Microsoft Identity Web](/entra/msal/dotnet/microsoft-identity-web/) packages.
* Automatic non-interactive token refresh is managed by the framework.
* The app uses server-side and client-side service abstractions to display generated weather data:
  * When rendering the `Weather` component on the server to display weather data, the component uses the `ServerWeatherForecaster` on the server to obtain weather data.
  * When the `Weather` component is rendered on the client, the component uses the `ClientWeatherForecaster` service implementation, which uses a preconfigured <xref:System.Net.Http.HttpClient> (in the client project's `Program` file) to make a web API call to the server project's Minimal API (`/weather-forecast`) for weather data. The Minimal API endpoint obtains the weather data from the `ServerWeatherForecaster` class and returns it to the client for rendering by the component.

## Sample solution

The sample solution consists of the following projects:

* `BlazorWebAppEntra`: Server-side project of the Blazor Web App, containing an example [Minimal API](xref:fundamentals/minimal-apis) endpoint for weather data.
* `BlazorWebAppEntra.Client`: Client-side project of the Blazor Web App.
* `MinimalApiJwt`: Backend web API, containing an example [Minimal API](xref:fundamentals/minimal-apis) endpoint for weather data.

Access the sample through the latest version folder in the Blazor samples repository with the following link. The sample is in the `BlazorWebAppEntra` folder for .NET 9 or later.

[View or download sample code](https://github.com/dotnet/blazor-samples) ([how to download](xref:blazor/fundamentals/index#sample-apps))

## Microsoft Entra ID app registrations

We recommend using separate registrations for apps and web APIs, even when the apps and web APIs are in the same solution. The following guidance is for the `BlazorWebAppEntra` app and `MinimalApiJwt` web API of the sample solution, but the same guidance applies generally to any Entra-based registrations for apps and web APIs.

Register the web API (`MinimalApiJwt`) first so that you can then grant access to the web API when registering the app. The web API's tenant ID and client ID are used to configure the web API in its `Program` file. After registering the web API, expose the web API in **App registrations** > **Expose an API** with a scope name of `Weather.Get`. Record the App ID URI for use in the app's configuration.

Next, register the app (`BlazorWebAppEntra`) with a **Web** platform configuration and a **Redirect URI** of `https://localhost/signin-oidc` (a port isn't required). The app's tenant ID, tenant domain, and client ID, along with the web API's base address, App ID URI, and weather scope name, are used to configure the app in its `appsettings.json` file. Grant API permission to access the web API in **App registrations** > **API permissions**. If the app's security specification calls for it, you can grant admin consent for the organization to access the web API. Authorized users and groups are assigned to the app's registration in **App registrations** > **Enterprise applications**.

In the Entra or Azure portal's **Implicit grant and hybrid flows** app registration configuration, don't select either checkbox for the authorization endpoint to return **Access tokens** or **ID tokens**. The OpenID Connect handler automatically requests the appropriate tokens using the code returned from the authorization endpoint.

Create a client secret in the app's registration in the Entra or Azure portal (**Manage** > **Certificates & secrets** > **New client secret**). Hold on to the client secret **Value** for use the next section.

Additional Entra configuration guidance for specific settings is provided later in this article.

## Server-side Blazor Web App project (`BlazorWebAppEntra`)

The `BlazorWebAppEntra` project is the server-side project of the Blazor Web App.

## Client-side Blazor Web App project (`BlazorWebAppEntra.Client`)

The `BlazorWebAppEntra.Client` project is the client-side project of the Blazor Web App.

If the user needs to log in or out during client-side rendering, a full page reload is initiated.

## Backend web API project (`MinimalApiJwt`)

The `MinimalApiJwt` project is a backend web API for multiple frontend projects. The project configures a [Minimal API](xref:fundamentals/minimal-apis) endpoint for weather data.

The `MinimalApiJwt.http` file can be used for testing the weather data request. Note that the `MinimalApiJwt` project must be running to test the endpoint, and the endpoint is hardcoded into the file. For more information, see <xref:test/http-files>.

A secure weather forecast data endpoint is in the project's `Program` file:

```csharp
app.MapGet("/weather-forecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
}).RequireAuthorization();
```

The <xref:Microsoft.AspNetCore.Builder.AuthorizationEndpointConventionBuilderExtensions.RequireAuthorization%2A> extension method requires authorization for the route definition. For any controllers that you add to the project, add the [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) to the controller or action.

## Configure the backend web API project (`MinimalApiJwt`)

Configure the project in the <xref:Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerOptions> of the <xref:Microsoft.Extensions.DependencyInjection.JwtBearerExtensions.AddJwtBearer%2A> call in the `MinimalApiJwt` project's `Program` file.

For the web API app's registration, the `Weather.Get` scope is configured in the Entra or Azure portal in **Expose an API**.

<xref:Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerOptions.Authority%2A> sets the Authority for making OIDC calls.

```csharp
jwtOptions.Authority = "{AUTHORITY}";
```

The following examples use a Tenant ID of `aaaabbbb-0000-cccc-1111-dddd2222eeee`.

If the app is registered in an ME-ID tenant, the authority should match the issurer (`iss`) of the JWT returned by the identity provider:

```csharp
jwtOptions.Authority = "https://sts.windows.net/aaaabbbb-0000-cccc-1111-dddd2222eeee/";
```

If the app is registered in an AAD B2C tenant:

```csharp
jwtOptions.Authority = "https://login.microsoftonline.com/aaaabbbb-0000-cccc-1111-dddd2222eeee/v2.0/";
```

<xref:Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerOptions.Audience%2A> sets the Audience for any received JWT access token. 

```csharp
jwtOptions.Audience = "{AUDIENCE}";
```

Match the value to just the path of the **Application ID URI** configured when adding the `Weather.Get` scope under **Expose an API** in the Entra or Azure portal. Don't include the scope name, "`Weather.Get`," in the value.

The following examples use an Application (Client) Id of `11112222-bbbb-3333-cccc-4444dddd5555`. The second example uses a tenant domain of `contoso.onmicrosoft.com`.

ME-ID tenant example:

```csharp
jwtOptions.Audience = "api://11112222-bbbb-3333-cccc-4444dddd5555";
```

AAD B2C tenant example:

```csharp
jwtOptions.Audience = "https://contoso.onmicrosoft.com/11112222-bbbb-3333-cccc-4444dddd5555";
```

## Configure the server project (`BlazorWebAppEntra`)

<xref:Microsoft.Identity.Web.AppBuilderExtension.AddMicrosoftIdentityWebApp%2A> from [Microsoft Identity Web](/entra/msal/dotnet/microsoft-identity-web/) ([`Microsoft.Identity.Web` NuGet package](https://www.nuget.org/packages/Microsoft.Identity.Web), [API documentation](<xref:Microsoft.Identity.Web?displayProperty=fullName>)) is configured in the `BlazorWebAppEntra` project's `Program` file.

Obtain the application (client) ID, tenant (publisher) domain, and directory (tenant) ID from the app's registration in the Entra or Azure portal. The App ID URI is obtained for the `Weather.Get` scope from the web API's registration. Don't include the scope name when taking the App ID URI from the portal.

In the `BlazorWebAppEntra` project's `Program` file, provide the values for the following placeholders in Microsoft Identity Web configuration:

```csharp
builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(msIdentityOptions =>
    {
        msIdentityOptions.CallbackPath = "/signin-oidc";
        msIdentityOptions.ClientId = "{CLIENT ID (BLAZOR APP)}";
        msIdentityOptions.Domain = "{DIRECTORY NAME}.onmicrosoft.com";
        msIdentityOptions.Instance = "https://login.microsoftonline.com/";
        msIdentityOptions.ResponseType = "code";
        msIdentityOptions.TenantId = "{TENANT ID}";
    })
    .EnableTokenAcquisitionToCallDownstreamApi()
    .AddDownstreamApi("DownstreamApi", configOptions =>
    {
        configOptions.BaseUrl = "{BASE ADDRESS}";
        configOptions.Scopes = [ "{APP ID URI}/Weather.Get" ];
    })
    .AddInMemoryTokenCaches();
```

Placeholders in the preceding configuration:

* `{CLIENT ID (BLAZOR APP)}`: The application (client) ID.
* `{DIRECTORY NAME}`: The directory name of the tenant (publisher) domain.
* `{TENANT ID}`: The directory (tenant) ID.
* `{BASE ADDRESS}`: The web API's base address.
* `{APP ID URI}`: The App ID URI for web API scopes. Either of the following formats are used, where the `{CLIENT ID (WEB API)}` placeholder is the Client Id of the web API's Entra registration, and the `{DIRECTORY NAME}` placeholder is the directory name of the tenant (publishers) domain (example: `contoso`).
  * ME-ID tenant format: `api://{CLIENT ID (WEB API)}`
  * B2C tenant format: `https://{DIRECTORY NAME}.onmicrosoft.com/{CLIENT ID (WEB API)}`

Example:

```csharp
builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(msIdentityOptions =>
    {
        msIdentityOptions.CallbackPath = "/signin-oidc";
        msIdentityOptions.ClientId = "00001111-aaaa-2222-bbbb-3333cccc4444";
        msIdentityOptions.Domain = "contoso.onmicrosoft.com";
        msIdentityOptions.Instance = "https://login.microsoftonline.com/";
        msIdentityOptions.ResponseType = "code";
        msIdentityOptions.TenantId = "aaaabbbb-0000-cccc-1111-dddd2222eeee";
    })
    .EnableTokenAcquisitionToCallDownstreamApi()
    .AddDownstreamApi("DownstreamApi", configOptions =>
    {
        configOptions.BaseUrl = "https://localhost:7277";
        configOptions.Scopes = [ "api://11112222-bbbb-3333-cccc-4444dddd5555/Weather.Get" ];
    })
    .AddInMemoryTokenCaches();
```

:::zone-end

:::zone pivot="bff-pattern"

This version of the article covers implementing Entra with the [Backend for Frontend (BFF) pattern](/azure/architecture/patterns/backends-for-frontends). Change the article version selector to **Non-BFF pattern** if the app's specification doesn't call for adopting the BFF pattern.

The following specification is covered:

* The Blazor Web App uses the [Auto render mode with global interactivity (`InteractiveAuto`)](xref:blazor/components/render-modes).
* The server project calls <xref:Microsoft.Extensions.DependencyInjection.WebAssemblyRazorComponentsBuilderExtensions.AddAuthenticationStateSerialization%2A> to add a server-side authentication state provider that uses <xref:Microsoft.AspNetCore.Components.PersistentComponentState> to flow the authentication state to the client. The client calls <xref:Microsoft.Extensions.DependencyInjection.WebAssemblyAuthenticationServiceCollectionExtensions.AddAuthenticationStateDeserialization%2A> to deserialize and use the authentication state passed by the server. The authentication state is fixed for the lifetime of the WebAssembly application.
* The app uses [Microsoft Entra ID](https://www.microsoft.com/security/business/microsoft-entra), based on [Microsoft Identity Web](/entra/msal/dotnet/microsoft-identity-web/) packages.
* Automatic non-interactive token refresh is managed by the framework.
* The app uses server-side and client-side service abstractions to display generated weather data.
* The [Backend for Frontend (BFF) pattern](/azure/architecture/patterns/backends-for-frontends) is adopted using [.NET Aspire](/dotnet/aspire/get-started/aspire-overview) for service discovery and [YARP](https://dotnet.github.io/yarp/) for proxying requests to a weather forecast endpoint on the backend app.
  * A backend web API uses JWT-bearer authentication to validate JWT tokens saved by the Blazor Web App in the sign-in cookie.
  * Aspire improves the experience of building .NET cloud-native apps. It provides a consistent, opinionated set of tools and patterns for building and running distributed apps.
  * YARP (Yet Another Reverse Proxy) is a library used to create a reverse proxy server.

<!-- UPDATE 10.0 Remove at 10.0 -->

For more information on .NET Aspire, see [General Availability of .NET Aspire: Simplifying .NET Cloud-Native Development (May, 2024)](https://devblogs.microsoft.com/dotnet/dotnet-aspire-general-availability/).

## Prerequisites

[.NET Aspire](/dotnet/aspire/get-started/aspire-overview) requires [Visual Studio](https://visualstudio.microsoft.com/) version 17.10 or later.

Also, see the *Prerequisites* section of [Quickstart: Build your first .NET Aspire app](/dotnet/aspire/get-started/build-your-first-aspire-app?tabs=visual-studio#prerequisites).

## Sample solution

The sample solution consists of the following projects:

* .NET Aspire:
  * `Aspire.AppHost`: Used to manage the high-level orchestration concerns of the app.
  * `Aspire.ServiceDefaults`: Contains default .NET Aspire app configurations that can be extended and customized as needed.
* `MinimalApiJwt`: Backend web API, containing an example [Minimal API](xref:fundamentals/minimal-apis) endpoint for weather data.
* `BlazorWebAppEntra`: Server-side project of the Blazor Web App.
* `BlazorWebAppEntra.Client`: Client-side project of the Blazor Web App.

Access the sample through the latest version folder in the Blazor samples repository with the following link. The sample is in the `BlazorWebAppEntraBff` folder for .NET 9 or later.

[View or download sample code](https://github.com/dotnet/blazor-samples) ([how to download](xref:blazor/fundamentals/index#sample-apps))

## Microsoft Entra ID app registrations

We recommend using separate registrations for apps and web APIs, even when the apps and web APIs are in the same solution. The following guidance is for the `BlazorWebAppEntra` app and `MinimalApiJwt` web API of the sample solution, but the same guidance applies generally to any Entra-based registrations for apps and web APIs.

Register the web API (`MinimalApiJwt`) first so that you can then grant access to the web API when registering the app. The web API's tenant ID and client ID are used to configure the web API in its `Program` file. After registering the web API, expose the web API in **App registrations** > **Expose an API** with a scope name of `Weather.Get`. Record the App ID URI for use in the app's configuration.

Next, register the app (`BlazorWebAppEntra`) with a **Web** platform configuration and a **Redirect URI** of `https://localhost/signin-oidc` (a port isn't required). The app's tenant ID, tenant domain, and client ID, along with the web API's base address, App ID URI, and weather scope name, are used to configure the app in its `appsettings.json` file. Grant API permission to access the web API in **App registrations** > **API permissions**. If the app's security specification calls for it, you can grant admin consent for the organization to access the web API. Authorized users and groups are assigned to the app's registration in **App registrations** > **Enterprise applications**.

In the Entra or Azure portal's **Implicit grant and hybrid flows** app registration configuration, don't select either checkbox for the authorization endpoint to return **Access tokens** or **ID tokens**. The OpenID Connect handler automatically requests the appropriate tokens using the code returned from the authorization endpoint.

Create a client secret in the app's registration in the Entra or Azure portal (**Manage** > **Certificates & secrets** > **New client secret**). Hold on to the client secret **Value** for use the next section.

Additional Entra configuration guidance for specific settings is provided later in this article.

## .NET Aspire projects

For more information on using .NET Aspire and details on the `.AppHost` and `.ServiceDefaults` projects of the sample app, see the [.NET Aspire documentation](/dotnet/aspire/).

Confirm that you've met the prerequisites for .NET Aspire. For more information, see the *Prerequisites* section of [Quickstart: Build your first .NET Aspire app](/dotnet/aspire/get-started/build-your-first-aspire-app?tabs=visual-studio#prerequisites).

The sample app only configures an insecure HTTP launch profile (`http`) for use during development testing. For more information, including an example of insecure and secure launch settings profiles, see [Allow unsecure transport in .NET Aspire (.NET Aspire documentation)](/dotnet/aspire/troubleshooting/allow-unsecure-transport).

## Server-side Blazor Web App project (`BlazorWebAppEntra`)

The `BlazorWebAppEntra` project is the server-side project of the Blazor Web App.

## Client-side Blazor Web App project (`BlazorWebAppEntra.Client`)

The `BlazorWebAppEntra.Client` project is the client-side project of the Blazor Web App.

If the user needs to log in or out during client-side rendering, a full page reload is initiated.

## Backend web API project (`MinimalApiJwt`)

The `MinimalApiJwt` project is a backend web API for multiple frontend projects. The project configures a [Minimal API](xref:fundamentals/minimal-apis) endpoint for weather data. Requests from the Blazor Web App server-side project (`BlazorWebAppEntra`) are proxied to the `MinimalApiJwt` project.

The `MinimalApiJwt.http` file can be used for testing the weather data request. Note that the `MinimalApiJwt` project must be running to test the endpoint, and the endpoint is hardcoded into the file. For more information, see <xref:test/http-files>.

A secure weather forecast data endpoint is in the project's `Program` file:

```csharp
app.MapGet("/weather-forecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
}).RequireAuthorization();
```

The <xref:Microsoft.AspNetCore.Builder.AuthorizationEndpointConventionBuilderExtensions.RequireAuthorization%2A> extension method requires authorization for the route definition. For any controllers that you add to the project, add the [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) to the controller or action.

## Configure the backend web API project (`MinimalApiJwt`)

Configure the `MinimalApiJwt` project in the <xref:Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerOptions> of the <xref:Microsoft.Extensions.DependencyInjection.JwtBearerExtensions.AddJwtBearer%2A> call in the project's `Program` file.

For the web API app's registration, the `Weather.Get` scope is configured in the Entra or Azure portal in **Expose an API**.

<xref:Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerOptions.Authority%2A> sets the Authority for making OIDC calls.

```csharp
jwtOptions.Authority = "{AUTHORITY}";
```

The following examples use a Tenant ID of `aaaabbbb-0000-cccc-1111-dddd2222eeee`.

If the app is registered in an ME-ID tenant, the authority should match the issurer (`iss`) of the JWT returned by the identity provider:

```csharp
jwtOptions.Authority = "https://sts.windows.net/aaaabbbb-0000-cccc-1111-dddd2222eeee/";
```

If the app is registered in an AAD B2C tenant:

```csharp
jwtOptions.Authority = "https://login.microsoftonline.com/aaaabbbb-0000-cccc-1111-dddd2222eeee/v2.0/";
```

<xref:Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerOptions.Audience%2A> sets the Audience for any received JWT access token. 

```csharp
jwtOptions.Audience = "{AUDIENCE}";
```

Match the value to just the path of the **Application ID URI** configured when adding the `Weather.Get` scope under **Expose an API** in the Entra or Azure portal. Don't include the scope name, "`Weather.Get`," in the value.

The following examples use an Application (Client) Id of `11112222-bbbb-3333-cccc-4444dddd5555`. The second example uses a tenant domain of `contoso.onmicrosoft.com`.

ME-ID tenant example:

```csharp
jwtOptions.Audience = "api://11112222-bbbb-3333-cccc-4444dddd5555";
```

AAD B2C tenant example:

```csharp
jwtOptions.Audience = "https://contoso.onmicrosoft.com/11112222-bbbb-3333-cccc-4444dddd5555";
```

## Configure the server project (`BlazorWebAppEntra`)

<xref:Microsoft.Identity.Web.AppBuilderExtension.AddMicrosoftIdentityWebApp%2A> from [Microsoft Identity Web](/entra/msal/dotnet/microsoft-identity-web/) ([`Microsoft.Identity.Web` NuGet package](https://www.nuget.org/packages/Microsoft.Identity.Web), [API documentation](<xref:Microsoft.Identity.Web?displayProperty=fullName>)) is configured in the `BlazorWebAppEntra` project's `Program` file.

Obtain the application (client) ID, tenant (publisher) domain, and directory (tenant) ID from the app's registration in the Entra or Azure portal. The App ID URI is obtained for the `Weather.Get` scope from the web API's registration. Don't include the scope name when taking the App ID URI from the portal.

In the `BlazorWebAppEntra` project's `Program` file, provide the values for the following placeholders in Microsoft Identity Web configuration:

```csharp
builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(msIdentityOptions =>
    {
        msIdentityOptions.CallbackPath = "/signin-oidc";
        msIdentityOptions.ClientId = "{CLIENT ID (BLAZOR APP)}";
        msIdentityOptions.Domain = "{DIRECTORY NAME}.onmicrosoft.com";
        msIdentityOptions.Instance = "https://login.microsoftonline.com/";
        msIdentityOptions.ResponseType = "code";
        msIdentityOptions.TenantId = "{TENANT ID}";
    })
    .EnableTokenAcquisitionToCallDownstreamApi()
    .AddDownstreamApi("DownstreamApi", configOptions =>
    {
        configOptions.BaseUrl = "{BASE ADDRESS}";
        configOptions.Scopes = [ "{APP ID URI}/Weather.Get" ];
    })
    .AddInMemoryTokenCaches();
```

Placeholders in the preceding configuration:

* `{CLIENT ID (BLAZOR APP)}`: The application (client) ID.
* `{DIRECTORY NAME}`: The directory name of the tenant (publisher) domain.
* `{TENANT ID}`: The directory (tenant) ID.
* `{BASE ADDRESS}`: The web API's base address.
* `{APP ID URI}`: The App ID URI for web API scopes. Either of the following formats are used, where the `{CLIENT ID (WEB API)}` placeholder is the Client Id of the web API's Entra registration, and the `{DIRECTORY NAME}` placeholder is the directory name of the tenant (publishers) domain (example: `contoso`).
  * ME-ID tenant format: `api://{CLIENT ID (WEB API)}`
  * B2C tenant format: `https://{DIRECTORY NAME}.onmicrosoft.com/{CLIENT ID (WEB API)}`

Example:

```csharp
builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(msIdentityOptions =>
    {
        msIdentityOptions.CallbackPath = "/signin-oidc";
        msIdentityOptions.ClientId = "00001111-aaaa-2222-bbbb-3333cccc4444";
        msIdentityOptions.Domain = "contoso.onmicrosoft.com";
        msIdentityOptions.Instance = "https://login.microsoftonline.com/";
        msIdentityOptions.ResponseType = "code";
        msIdentityOptions.TenantId = "aaaabbbb-0000-cccc-1111-dddd2222eeee";
    })
    .EnableTokenAcquisitionToCallDownstreamApi()
    .AddDownstreamApi("DownstreamApi", configOptions =>
    {
        configOptions.BaseUrl = "https://localhost:7277";
        configOptions.Scopes = [ "api://11112222-bbbb-3333-cccc-4444dddd5555/Weather.Get" ];
    })
    .AddInMemoryTokenCaches();
```

:::zone-end

The callback path (`CallbackPath`) must match the redirect URI (login callback path) configured when registering the application in the Entra or Azure portal. Paths are configured in the **Authentication** blade of the app's registration. The default value of `CallbackPath` is `/signin-oidc` for a registered redirect URI of `https://localhost/signin-oidc` (a port isn't required).

The <xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.SignedOutCallbackPath%2A> is the request path within the app's base path intercepted by the OpenID Connect handler where the user agent is first returned after signing out from Entra. The sample app doesn't set a value for the path because the default value of "`/signout-callback-oidc`" is used. After intercepting the request, the OpenID Connect handler redirects to the <xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.SignedOutRedirectUri%2A> or <xref:Microsoft.AspNetCore.Authentication.AuthenticationProperties.RedirectUri%2A>, if specified.

Configure the signed-out callback path in the app's Entra registration. In the Entra or Azure portal, set the path in the **Web** platform configuration's **Redirect URI** entries:

> :::no-loc text="https://localhost/signout-callback-oidc":::

> [!NOTE]
> A port isn't required for `localhost` addresses when using Entra.

If you don't add the signed-out callback path URI to the app's registration in Entra, Entra refuses to redirect the user back to the app and merely asks them to close their browser window.

<!-- UPDATE 10.0 Keep an eye on this NOTE for removal or updates.
                 The remark on this subject is in the Program file of the
                 Entra sample app (Blazor samples repo). -->

> [!NOTE]
> Entra doesn't redirect a primary admin user (root account) or external user back to the Blazor application. Instead, Entra logs the user out of the app and recommends that they close all of their browser windows. For more information, see [postLogoutRedirectUri not working when authority url contains a tenant ID (`AzureAD/microsoft-authentication-library-for-js` #5783)](https://github.com/AzureAD/microsoft-authentication-library-for-js/issues/5783#issuecomment-1465217522).

[!INCLUDE[](~/blazor/security/includes/secure-authentication-flows.md)]
                
### Establish the client secret

*This section only applies to the server project of the Blazor Web App.*

Use either or both of the following approaches to supply the client secret to the app:

* **Secret Manager tool**: The Secret Manager tool stores private data on the local machine and is only used during local development.
* **Azure Key Vault**: You can store the client secret in a key vault for use in any environment, including for the Development environment when working locally. Some developers prefer to use key vaults for staging and production deployments and use the Secret Manager tool for local development.

We strongly recommend that you avoid storing client secrets in project code or configuration files. Use secure authentication flows, such as either or both of the approaches in this section.

### Secret Manager tool

The [Secret Manager tool](xref:security/app-secrets) can store the server app's client secret under the configuration key `AzureAd:ClientSecret`.

The Blazor server app hasn't been initialized for the Secret Manager tool. Use a command shell, such as the Developer PowerShell command shell in Visual Studio, to execute the following command. Before executing the command, change the directory with the `cd` command to the server project's directory. The command establishes a user secrets identifier (`<UserSecretsId>`) in the server app's project file, which is used internally by the tooling to track secrets for the app:

```dotnetcli
dotnet user-secrets init
```

Execute the following command to set the client secret. The `{SECRET}` placeholder is the client secret obtained from the app's Entra registration:

```dotnetcli
dotnet user-secrets set "AzureAd:ClientSecret" "{SECRET}"
```

If using Visual Studio, you can confirm that the secret is set by right-clicking the server project in **Solution Explorer** and selecting **Manage User Secrets**.

### Azure Key Vault

[Azure Key Vault](https://azure.microsoft.com/products/key-vault/) provides a safe approach for providing the app's client secret to the app.

To create a key vault and set a client secret, see [About Azure Key Vault secrets (Azure documentation)](/azure/key-vault/secrets/about-secrets), which cross-links resources to get started with Azure Key Vault. To implement the code in this section, record the key vault URI and the secret name from Azure when you create the key vault and secret. When you set the access policy for the secret in the **Access policies** panel:

* Only the **Get** secret permission is required.
* Select the application as the **Principal** for the secret.

> [!IMPORTANT]
> A key vault secret is created with an expiration date. Be sure to track when a key vault secret is going to expire and create a new secret for the app prior to that date passing.

Add the following `AzureHelper` class to the server project. The `GetKeyVaultSecret` method retrieves a secret from a key vault. Adjust the namespace (`BlazorSample.Helpers`) to match your project namespace scheme.

`Helpers/AzureHelper.cs`:

```csharp
using Azure;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace BlazorWebAppEntra.Helpers;

public static class AzureHelper
{
    public static string GetKeyVaultSecret(string tenantId, string vaultUri, string secretName)
    {
        DefaultAzureCredentialOptions options = new()
        {
            // Specify the tenant ID to use the dev credentials when running the app locally
            // in Visual Studio.
            VisualStudioTenantId = tenantId,
            SharedTokenCacheTenantId = tenantId
        };

        var client = new SecretClient(new Uri(vaultUri), new DefaultAzureCredential(options));
        var secret = client.GetSecretAsync(secretName).Result;

        return secret.Value.Value;
    }
}
```

Where services are registered in the server project's `Program` file, obtain and apply the client secret using the following code:

```csharp
var tenantId = builder.Configuration.GetValue<string>("AzureAd:TenantId")!;
var vaultUri = builder.Configuration.GetValue<string>("AzureAd:VaultUri")!;
var secretName = builder.Configuration.GetValue<string>("AzureAd:SecretName")!;

builder.Services.Configure<MicrosoftIdentityOptions>(
    OpenIdConnectDefaults.AuthenticationScheme,
    options =>
    {
        options.ClientSecret = 
            AzureHelper.GetKeyVaultSecret(tenantId, vaultUri, secretName);
    });
```

If you wish to control the environment where the preceding code operates, for example to avoid running the code locally because you've opted to use the Secret Manager tool for local development, you can wrap the preceding code in a conditional statement that checks the environment:

```csharp
if (!context.HostingEnvironment.IsDevelopment())
{
    ...
}
```

In the `AzureAd` section of `appsettings.json`, add the following `VaultUri` and `SecretName` configuration keys and values:

```json
"VaultUri": "{VAULT URI}",
"SecretName": "{SECRET NAME}"
```

In the preceding example:

* The `{VAULT URI}` placeholder is the key vault URI. Include the trailing slash on the URI.
* The `{SECRET NAME}` placeholder is the secret name.

Example:

```json
"VaultUri": "https://contoso.vault.azure.net/",
"SecretName": "BlazorWebAppEntra"
```

Configuration is used to facilitate supplying dedicated key vaults and secret names based on the app's environmental configuration files. For example, you can supply different configuration values for `appsettings.Development.json` in development, `appsettings.Staging.json` when staging, and `appsettings.Production.json` for the production deployment. For more information, see <xref:blazor/fundamentals/configuration>.

:::moniker range=">= aspnetcore-9.0"

## Only serialize the name and role claims

In the `Program` file, all claims are serialized by setting <xref:Microsoft.AspNetCore.Components.WebAssembly.Server.AuthenticationStateSerializationOptions.SerializeAllClaims%2A> to `true`. If you only want the name and role claims serialized for CSR, remove the option or set it to `false`.

:::moniker-end

## Supply configuration with the JSON configuration provider (app settings)

The [sample solution projects](#sample-solution) configure Microsoft Identity Web and JWT bearer authentication in their `Program` files in order to make configuration settings discoverable using C# autocompletion. Professional apps usually use a *configuration provider* to configure OIDC options, such as the default [JSON configuration provider](xref:fundamentals/configuration/index). The JSON configuration provider loads configuration from app settings files `appsettings.json`/`appsettings.{ENVIRONMENT}.json`, where the `{ENVIRONMENT}` placeholder is the app's [runtime environment](xref:fundamentals/environments). Follow the guidance in this section to use app settings files for configuration.

In the app settings file (`appsettings.json`) of the `BlazorWebAppEntra` project, add the following JSON configuration:

```json
{
  "AzureAd": {
    "CallbackPath": "/signin-oidc",
    "ClientId": "{CLIENT ID (BLAZOR APP)}",
    "Domain": "{DIRECTORY NAME}.onmicrosoft.com",
    "Instance": "https://login.microsoftonline.com/",
    "ResponseType": "code",
    "TenantId": "{TENANT ID}"
  },
  "DownstreamApi": {
    "BaseUrl": "{BASE ADDRESS}",
    "Scopes": [ "{APP ID URI}/Weather.Get" ]
  }
}
```

Update the placeholders in the preceding configuration to match the values that the app uses in the `Program` file:

* `{CLIENT ID (BLAZOR APP)}`: The application (client) ID.
* `{DIRECTORY NAME}`: The directory name of the tenant (publisher) domain.
* `{TENANT ID}`: The directory (tenant) ID.
* `{BASE ADDRESS}`: The web API's base address.
* `{APP ID URI}`: The App ID URI for web API scopes. Either of the following formats are used, where the `{CLIENT ID (WEB API)}` placeholder is the Client Id of the web API's Entra registration, and the `{DIRECTORY NAME}` placeholder is the directory name of the tenant (publishers) domain (example: `contoso`).
  * ME-ID tenant format: `api://{CLIENT ID (WEB API)}`
  * B2C tenant format: `https://{DIRECTORY NAME}.onmicrosoft.com/{CLIENT ID (WEB API)}`

Example:

```json
"AzureAd": {
  "CallbackPath": "/signin-oidc",
  "ClientId": "00001111-aaaa-2222-bbbb-3333cccc4444",
  "Domain": "contoso.onmicrosoft.com",
  "Instance": "https://login.microsoftonline.com/",
  "ResponseType": "code",
  "TenantId": "aaaabbbb-0000-cccc-1111-dddd2222eeee"
},
...
"DownstreamApi": {
  "BaseUrl": "https://localhost:7277",
  "Scopes": [ "api://11112222-bbbb-3333-cccc-4444dddd5555/Weather.Get" ]
}
```

Update any other values in the preceding configuration to match custom/non-default values used in the `Program` file.

The configuration is automatically picked up by the authentication builder.

Make the following changes in the `Program` file:

```diff
builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
-   .AddMicrosoftIdentityWebApp(msIdentityOptions =>
-   {
-       msIdentityOptions.CallbackPath = "...";
-       msIdentityOptions.ClientId = "...";
-       msIdentityOptions.Domain = "...";
-       msIdentityOptions.Instance = "...";
-       msIdentityOptions.ResponseType = "...";
-       msIdentityOptions.TenantId = "...";
-   })
+   .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"))
    .EnableTokenAcquisitionToCallDownstreamApi()
-   .AddDownstreamApi("DownstreamApi", configOptions =>
-   {
-       configOptions.BaseUrl = "...";
-       configOptions.Scopes = [ "..." ];
-   })
+   .AddDownstreamApi("DownstreamApi", builder.Configuration.GetSection("DownstreamApi"))
    .AddInMemoryTokenCaches();
```

In the `MinimalApiJwt` project, add the following app settings configuration to the `appsettings.json` file:

```json
"Authentication": {
  "Schemes": {
    "Bearer": {
      "Authority": "https://sts.windows.net/{TENANT ID (WEB API)}/",
      "ValidAudiences": [ "{APP ID URI (WEB API)}" ]
    }
  }
},
```

Update the placeholders in the preceding configuration to match the values that the app uses in the `Program` file:

* `{TENANT ID (WEB API)}`: The Tenant Id of the web API.
* `{APP ID URI (WEB API)}`: The App ID URI of the web API.

Authority formats adopt the following patterns:

* ME-ID tenant type: `https://sts.windows.net/{TENANT ID}/`
* B2C tenant type: `https://login.microsoftonline.com/{TENANT ID}/v2.0/`

Audience formats adopt the following patterns (`{CLIENT ID}` is the Client Id of the web API; `{DIRECTORY NAME}` is the directory name, for example, `contoso`):

* ME-ID tenant type: `api://{CLIENT ID}`
* B2C tenant type: `https://{DIRECTORY NAME}.onmicrosoft.com/{CLIENT ID}`

The configuration is automatically picked up by the JWT bearer authentication builder.

Remove the following lines from the `Program` file:

```diff
- jwtOptions.Authority = "...";
- jwtOptions.Audience = "...";
```

For more information on configuration, see the following resources:

* <xref:fundamentals/configuration/index>
* <xref:blazor/fundamentals/configuration>

## Redirect to the home page on logout

The `LogInOrOut` component (`Layout/LogInOrOut.razor`) sets a hidden field for the return URL (`ReturnUrl`) to the current URL (`currentURL`). When the user signs out of the app, the identity provider returns the user to the page from which they logged out. If the user logs out from a secure page, they're returned to the same secure page and sent back through the authentication process. This authentication flow is reasonable when users need to change accounts regularly.

Alternatively, use the following `LogInOrOut` component, which doesn't supply a return URL when logging out.

`Layout/LogInOrOut.razor`:

```razor
<div class="nav-item px-3">
    <AuthorizeView>
        <Authorized>
            <form action="authentication/logout" method="post">
                <AntiforgeryToken />
                <button type="submit" class="nav-link">
                    <span class="bi bi-arrow-bar-left-nav-menu" aria-hidden="true">
                    </span> Logout
                </button>
            </form>
        </Authorized>
        <NotAuthorized>
            <a class="nav-link" href="authentication/login">
                <span class="bi bi-person-badge-nav-menu" aria-hidden="true"></span>
                Login
            </a>
        </NotAuthorized>
    </AuthorizeView>
</div>
```

## Weather data security

For more information on how this app secures its weather data, see [Secure data in Blazor Web Apps with Interactive Auto rendering](xref:blazor/security/index#secure-data-in-blazor-web-apps-with-interactive-auto-rendering).

## Troubleshoot

[!INCLUDE[](~/blazor/security/includes/troubleshoot-server.md)]

## Additional resources

* [Microsoft identity platform documentation](/entra/identity-platform/)
* [`AzureAD/microsoft-identity-web` GitHub repository](https://github.com/AzureAD/microsoft-identity-web/wiki): Helpful guidance on implementing Microsoft Identity Web for Microsoft Entra ID and Azure Active Directory B2C for ASP.NET Core apps, including links to sample apps and related Azure documentation. Currently, Blazor Web Apps aren't explicitly addressed by the Azure documentation, but the setup and configuration of a Blazor Web App for ME-ID and Azure hosting is the same as it is for any ASP.NET Core web app.
* [`AuthenticationStateProvider` service](xref:blazor/security/index#authenticationstateprovider-service)
* [Manage authentication state in Blazor Web Apps](xref:blazor/security/index#manage-authentication-state-in-blazor-web-apps)
* [Service abstractions in Blazor Web Apps](xref:blazor/call-web-api#service-abstractions-for-web-api-calls)
