---
title: Secure an ASP.NET Core Blazor Web App with Microsoft Entra ID
author: guardrex
description: Learn how to secure a Blazor WebAssembly App with Microsoft Entra ID.
monikerRange: '>= aspnetcore-9.0'
ms.author: riande
ms.custom: mvc
ms.date: 10/07/2024
uid: blazor/security/blazor-web-app-entra
---
# Secure an ASP.NET Core Blazor Web App with Microsoft Entra ID

<!-- UPDATE 10.0 Activate after release and INCLUDE is updated

[!INCLUDE[](~/includes/not-latest-version.md)]

-->

This article describes how to secure a Blazor Web App with [Microsoft identity platform](/entra/identity-platform/)/[Microsoft Identity Web packages](/entra/msal/dotnet/microsoft-identity-web/) for [Microsoft Entra ID](https://www.microsoft.com/security/business/microsoft-entra) using a sample app.

The following specification is covered:

* The Blazor Web App uses the [Auto render mode with global interactivity (`InteractiveAuto`)](xref:blazor/components/render-modes).
* The server project calls <xref:Microsoft.Extensions.DependencyInjection.WebAssemblyRazorComponentsBuilderExtensions.AddAuthenticationStateSerialization%2A> to add a server-side authentication state provider that uses <xref:Microsoft.AspNetCore.Components.PersistentComponentState> to flow the authentication state to the client. The client calls <xref:Microsoft.Extensions.DependencyInjection.WebAssemblyAuthenticationServiceCollectionExtensions.AddAuthenticationStateDeserialization%2A> to deserialize and use the authentication state passed by the server. The authentication state is fixed for the lifetime of the WebAssembly application.
* The app uses [Microsoft Entra ID](https://www.microsoft.com/security/business/microsoft-entra), based on [Microsoft Identity Web](/entra/msal/dotnet/microsoft-identity-web/) packages.
* Automatic non-interactive token refresh is managed by the framework.
* The app uses server-side and client-side service abstractions to display generated weather data:
  * When rendering the `Weather` component on the server to display weather data, the component uses the `ServerWeatherForecaster` on the server to directly obtain weather data (not via a web API call).
  * When the `Weather` component is rendered on the client, the component uses the `ClientWeatherForecaster` service implementation, which uses a preconfigured <xref:System.Net.Http.HttpClient> (in the client project's `Program` file) to make a web API call to the server project's Minimal API (`/weather-forecast`) for weather data. The Minimal API endpoint obtains the weather data from the `ServerWeatherForecaster` class and returns it to the client for rendering by the component.

## Sample app

The sample app consists of two projects:

* `BlazorWebAppEntra`: Server-side project of the Blazor Web App, containing an example [Minimal API](xref:fundamentals/minimal-apis) endpoint for weather data.
* `BlazorWebAppEntra.Client`: Client-side project of the Blazor Web App.

Access sample apps through the latest version folder from the repository's root with the following link. The projects are in the `BlazorWebAppEntra` folder for .NET 9 or later.

[View or download sample code](https://github.com/dotnet/blazor-samples) ([how to download](xref:blazor/fundamentals/index#sample-apps))

## Server-side Blazor Web App project (`BlazorWebAppEntra`)

The `BlazorWebAppEntra` project is the server-side project of the Blazor Web App.

The `BlazorWebAppEntra.http` file can be used for testing the weather data request. Note that the `BlazorWebAppEntra` project must be running to test the endpoint, and the endpoint is hardcoded into the file. For more information, see <xref:test/http-files>.

## Client-side Blazor Web App project (`BlazorWebAppEntra.Client`)

The `BlazorWebAppEntra.Client` project is the client-side project of the Blazor Web App.

If the user needs to log in or out during client-side rendering, a full page reload is initiated.

## Configuration

This section explains how to configure the sample app.

<xref:Microsoft.Identity.Web.AppBuilderExtension.AddMicrosoftIdentityWebApp%2A> from [Microsoft Identity Web](/entra/msal/dotnet/microsoft-identity-web/) ([`Microsoft.Identity.Web` NuGet package](https://www.nuget.org/packages/Microsoft.Identity.Web), [API documentation](<xref:Microsoft.Identity.Web?displayProperty=fullName>)) is configured by the `AzureAd` section of the server project's `appsettings.json` file.

In the app's registration in the Entra or Azure portal, use a **Web** platform configuration with a **Redirect URI** of `https://localhost/signin-oidc` (a port isn't required). Confirm that **ID tokens** and access tokens under **Implicit grant and hybrid flows** are **not** selected. The OpenID Connect handler automatically requests the appropriate tokens using the code returned from the authorization endpoint.

### Establish the client secret

Use the [Secret Manager tool](xref:security/app-secrets) to store the server app's client secret under the configuration key `AzureAd:ClientSecret`.

Create a client secret in the app's Entra ID registration in the Entra or Azure portal (**Manage** > **Certificates & secrets** > **New client secret**). Use the **Value** of the new secret in the following guidance.

Execute the following command in a command shell from the server project's directory, such as the Developer PowerShell command shell in Visual Studio. The `{SECRET}` placeholder is the client secret obtained from the app's registration:

```dotnetcli
dotnet user-secrets set "AzureAd:ClientSecret" "{SECRET}"
```

If using Visual Studio, you can confirm the secret is set by right-clicking the server project in **Solution Explorer** and selecting **Manage User Secrets**.

### Configure the app

In the server project's app settings file (`appsettings.json`), provide the app's `AzureAd` section configuration. Obtain the application (client) ID, tenant (publisher) domain, and directory (tenant) ID from the app's registration in the Entra or Azure portal:

```json
"AzureAd": {
  "CallbackPath": "/signin-oidc",
  "ClientId": "{CLIENT ID}",
  "Domain": "{DOMAIN}",
  "Instance": "https://login.microsoftonline.com/",
  "ResponseType": "code",
  "TenantId": "{TENANT ID}"
},
```

Placeholders in the preceding example:

* `{CLIENT ID}`: The application (client) ID.
* `{DOMAIN}`: The tenant (publisher) domain.
* `{TENANT ID}`: The directory (tenant) ID.

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
```

The callback path (`CallbackPath`) must match the redirect URI (login callback path) configured when registering the application in the Entra or Azure portal. Paths are configured in the **Authentication** blade of the app's registration. The default value of `CallbackPath` is `/signin-oidc` for a registered redirect URI of `https://localhost/signin-oidc` (a port isn't required).

[!INCLUDE[](~/blazor/security/includes/secure-authentication-flows.md)]

## Redirect to the home page on sign out

When a user navigates around the app, the `LogInOrOut` component (`Layout/LogInOrOut.razor`) sets a hidden field for the return URL (`ReturnUrl`) to the value of the current URL (`currentURL`). When the user signs out of the app, the identity provider returns them to the page from which they signed out.

If the user signs out from a secure page, they're returned back to the same secure page after signing out only to be sent back through the authentication process. This behavior is fine when users need to switch accounts frequently. However, a alternative app specification may call for the user to be returned to the app's home page or some other page after signing out. The following example shows how to set the app's home page as the return URL for sign-out operations.

The important changes to the `LogInOrOut` component are demonstrated in the following example. There's no need to provide a hidden field for the `ReturnUrl` set to the home page at `/` because that's the default path. <xref:System.IDisposable> is no longer implemented. The <xref:Microsoft.AspNetCore.Components.NavigationManager> is no longer injected. The entire `@code` block is removed.

`Layout/LogInOrOut.razor`:

```razor
@using Microsoft.AspNetCore.Authorization

<div class="nav-item px-3">
    <AuthorizeView>
        <Authorized>
            <form action="authentication/logout" method="post">
                <AntiforgeryToken />
                <button type="submit" class="nav-link">
                    <span class="bi bi-arrow-bar-left-nav-menu" aria-hidden="true">
                    </span> Logout @context.User.Identity?.Name
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

## Troubleshoot

[!INCLUDE[](~/blazor/security/includes/troubleshoot-server.md)]

## Additional resources

* [Microsoft identity platform documentation](/entra/identity-platform/)
* [`AzureAD/microsoft-identity-web` GitHub repository](https://github.com/AzureAD/microsoft-identity-web/wiki): Helpful guidance on implementing Microsoft Identity Web for Microsoft Entra ID and Azure Active Directory B2C for ASP.NET Core apps, including links to sample apps and related Azure documentation. Currently, Blazor Web Apps aren't explicitly addressed by the Azure documentation, but the setup and configuration of a Blazor Web App for ME-ID and Azure hosting is the same as it is for any ASP.NET Core web app.
* [`AuthenticationStateProvider` service](xref:blazor/security/index#authenticationstateprovider-service)
* [Manage authentication state in Blazor Web Apps](xref:blazor/security/server/index#manage-authentication-state-in-blazor-web-apps)
* [Service abstractions in Blazor Web Apps](xref:blazor/call-web-api#service-abstractions-for-web-api-calls)
