---
title: Secure an ASP.NET Core Blazor Web App with OpenID Connect (OIDC)
author: guardrex
description: Learn how to secure a Blazor WebAssembly App with OpenID Connect (OIDC).
monikerRange: '>= aspnetcore-8.0'
ms.author: riande
ms.custom: mvc
ms.date: 05/28/2024
uid: blazor/security/blazor-web-app-oidc
zone_pivot_groups: blazor-web-app-oidc-specification
---
# Secure an ASP.NET Core Blazor Web App with OpenID Connect (OIDC)

<!-- UPDATE 9.0 Activate after release and INCLUDE is updated

[!INCLUDE[](~/includes/not-latest-version.md)]

-->

This article describes how to secure a Blazor Web App with [OpenID Connect (OIDC)](https://openid.net/developers/how-connect-works/) using a sample app in the [`dotnet/blazor-samples` GitHub repository (.NET 8 or later)](https://github.com/dotnet/blazor-samples) ([how to download](xref:blazor/fundamentals/index#sample-apps)).

:::zone pivot="without-bff-pattern"

This version of the article covers implementing OIDC without adopting the [Backend for Frontend (BFF) pattern](/azure/architecture/patterns/backends-for-frontends). The BFF pattern is useful for making authenticated requests to external services. Change the article version selector to **OIDC with BFF pattern** if the app's specification calls for adopting the BFF pattern.

The following specification is covered:

* The Blazor Web App uses [the Auto render mode with global interactivity](xref:blazor/components/render-modes).
* Custom auth state provider services are used by the server and client apps to capture the user's authentication state and flow it between the server and client.
* This app is a starting point for any OIDC authentication flow. OIDC is configured manually in the app and doesn't rely upon [Microsoft Entra ID](https://www.microsoft.com/security/business/microsoft-entra) or [Microsoft Identity Web](/entra/msal/dotnet/microsoft-identity-web/) packages, nor does the sample app require [Microsoft Azure](https://azure.microsoft.com/) hosting. However, the sample app can be used with Entra, Microsoft Identity Web, and hosted in Azure.
* Automatic non-interactive token refresh.
* Securely calls a (web) API in the server project for data.

## Sample app

The sample app consists of two projects:

* `BlazorWebAppOidc`: Server-side project of the Blazor Web App, containing an example [Minimal API](xref:fundamentals/minimal-apis) endpoint for weather data.
* `BlazorWebAppOidc.Client`: Client-side project of the Blazor Web App.

Access the sample apps through the latest version folder from the repository's root with the following link. The projects are in the `BlazorWebAppOidc` folder for .NET 8 or later.

[View or download sample code](https://github.com/dotnet/blazor-samples) ([how to download](xref:blazor/fundamentals/index#sample-apps))

## Server-side Blazor Web App project (`BlazorWebAppOidc`)

The `BlazorWebAppOidc` project is the server-side project of the Blazor Web App.

The `BlazorWebAppOidc.http` file can be used for testing the weather data request. Note that the `BlazorWebAppOidc` project must be running to test the endpoint, and the endpoint is hardcoded into the file. For more information, see <xref:test/http-files>.

> [!NOTE]
> The server project uses <xref:Microsoft.AspNetCore.Http.IHttpContextAccessor>/<xref:Microsoft.AspNetCore.Http.HttpContext>, but never for interactively-rendered components. For more information, see <xref:blazor/security/server/interactive-server-side-rendering#ihttpcontextaccessorhttpcontext-in-razor-components>.

### Configuration

This section explains how to configure the sample app.

> [!NOTE]
> For Microsoft Entra ID and Azure AD B2C, you can use <xref:Microsoft.Identity.Web.AppBuilderExtension.AddMicrosoftIdentityWebApp%2A> from [Microsoft Identity Web](/entra/msal/dotnet/microsoft-identity-web/) ([`Microsoft.Identity.Web` NuGet package](https://www.nuget.org/packages/Microsoft.Identity.Web), [API documentation](<xref:Microsoft.Identity.Web?displayProperty=fullName>)), which adds both the OIDC and Cookie authentication handlers with the appropriate defaults. The sample app and the guidance in this section doesn't use Microsoft Identity Web. The guidance demonstrates how to configure the OIDC handler *manually* for any OIDC provider. For more information on implementing Microsoft Identity Web, see the linked resources.

The following <xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions> configuration is found in the project's `Program` file on the call to <xref:Microsoft.Extensions.DependencyInjection.OpenIdConnectExtensions.AddOpenIdConnect%2A>:

* <xref:Microsoft.AspNetCore.Builder.RemoteAuthenticationOptions.SignInScheme%2A>: Sets the authentication scheme corresponding to the middleware responsible of persisting user's identity after a successful authentication. The OIDC handler needs to use a sign-in scheme that's capable of persisting user credentials across requests. The following line is present merely for demonstration purposes. If omitted, <xref:Microsoft.AspNetCore.Authentication.AuthenticationOptions.DefaultSignInScheme%2A> is used as a fallback value.

  ```csharp
  oidcOptions.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
  ```

* Scopes for `openid` and `profile` (<xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.Scope%2A>) (Optional): The `openid` and `profile` scopes are also configured by default because they're required for the OIDC handler to work, but these may need to be re-added if scopes are included in the `Authentication:Schemes:MicrosoftOidc:Scope` configuration. For general configuration guidance, see <xref:fundamentals/configuration/index> and <xref:blazor/fundamentals/configuration>.

  ```csharp
  oidcOptions.Scope.Add(OpenIdConnectScope.OpenIdProfile);
  ```

* <xref:Microsoft.AspNetCore.Authentication.RemoteAuthenticationOptions.SaveTokens%2A>: Defines whether access and refresh tokens should be stored in the <xref:Microsoft.AspNetCore.Authentication.AuthenticationProperties> after a successful authorization. This property is set to `false` by default to reduce the size of the final authentication cookie.

  ```csharp
  oidcOptions.SaveTokens = false;
  ```

* Scope for offline access (<xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.Scope%2A>): The `offline_access` scope is required for the refresh token.

  ```csharp
  oidcOptions.Scope.Add(OpenIdConnectScope.OfflineAccess);
  ```

* <xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.Authority%2A> and <xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.ClientId%2A>: Sets the Authority and Client ID for OIDC calls.

  ```csharp
  oidcOptions.Authority = "{AUTHORITY}";
  oidcOptions.ClientId = "{CLIENT ID}";
  ```

  Example:

  * Authority (`{AUTHORITY}`): `https://login.microsoftonline.com/a3942615-d115-4eb7-bc84-9974abcf5064/v2.0/` (uses Tenant ID `a3942615-d115-4eb7-bc84-9974abcf5064`)
  * Client Id (`{CLIENT ID}`): `4ba4de56-9cef-45d9-83fa-a4c18f9f5f0f`

  ```csharp
  oidcOptions.Authority = "https://login.microsoftonline.com/a3942615-d115-4eb7-bc84-9974abcf5064/v2.0/";
  oidcOptions.ClientId = "4ba4de56-9cef-45d9-83fa-a4c18f9f5f0f";
  ```

  Example for Microsoft Azure "common" authority:
  
  The "common" authority should be used for multi-tenant apps. You can also use the "common" authority for single-tenant apps, but a custom <xref:Microsoft.IdentityModel.Tokens.TokenValidationParameters.IssuerValidator%2A> is required, as shown later in this section.

  ```csharp
  oidcOptions.Authority = "https://login.microsoftonline.com/common/v2.0/";
  ```

* <xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.ClientSecret%2A>: The OIDC client secret.

  **The following example is only for testing and demonstration purposes. Don't store the client secret in the app's assembly or check the secret into source control.**  Store the client secret in [User Secrets](xref:security/app-secrets), [Azure Key Vault](xref:security/key-vault-configuration), or an [environment variable](xref:fundamentals/configuration/index#non-prefixed-environment-variables).
  
  Authentication scheme configuration is automatically read from `builder.Configuration["Authentication:Schemes:{SCHEME NAME}:{PropertyName}"]`, where the `{SCHEME NAME}` placeholder is the scheme, which is `MicrosoftOidc` by default. Because configuration is preconfigured, a client secret can automatically be read via the `Authentication:Schemes:MicrosoftOidc:ClientSecret` configuration key. On the server using environment variables, name the environment variable `Authentication__Schemes__MicrosoftOidc__ClientSecret`:

  ```dotnetcli
  set Authentication__Schemes__MicrosoftOidc__ClientSecret={CLIENT SECRET}
  ```
  
  **For demonstration and testing only**, the <xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.ClientSecret%2A> can be set directly. Don't set the value directly for deployed production apps. For slightly improved security, [conditionally compile](/dotnet/csharp/language-reference/preprocessor-directives#conditional-compilation) the line with the `DEBUG` symbol:

  ```csharp
  #if DEBUG
  oidcOptions.ClientSecret = "{CLIENT SECRET}";
  #endif
  ```

  Example:

  Client secret (`{CLIENT SECRET}`): `463471c8c4...f90d674bc9` (shortened for display)

  ```csharp
  #if DEBUG
  oidcOptions.ClientSecret = "463471c8c4...137f90d674bc9";
  #endif
  ```

* <xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.ResponseType%2A>: Configures the OIDC handler to only perform authorization code flow. Implicit grants and hybrid flows are unnecessary in this mode.

  In the Entra or Azure portal's **Implicit grant and hybrid flows** app registration configuration, do **not** select either checkbox for the authorization endpoint to return **Access tokens** or **ID tokens**. The OIDC handler automatically requests the appropriate tokens using the code returned from the authorization endpoint.

  ```csharp
  oidcOptions.ResponseType = OpenIdConnectResponseType.Code;
  ```

* <xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.MapInboundClaims%2A> and configuration of <xref:Microsoft.IdentityModel.Tokens.TokenValidationParameters.NameClaimType%2A> and <xref:Microsoft.IdentityModel.Tokens.TokenValidationParameters.RoleClaimType%2A>: Many OIDC servers use "`name`" and "`role`" rather than the SOAP/WS-Fed defaults in <xref:System.Security.Claims.ClaimTypes>. When <xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.MapInboundClaims%2A> is set to `false`, the handler doesn't perform claims mappings, and the claim names from the JWT are used directly by the app. The following example sets the role claim type to "`roles`," which is appropriate for [Microsoft Entra ID (ME-ID)](https://www.microsoft.com/security/business/microsoft-entra). Consult your identity provider's documentation for more information.

> [!NOTE]
> <xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.MapInboundClaims%2A> must be set to `false` for most OIDC providers, which prevents renaming claims.

  ```csharp
  oidcOptions.MapInboundClaims = false;
  oidcOptions.TokenValidationParameters.NameClaimType = JwtRegisteredClaimNames.Name;
  oidcOptions.TokenValidationParameters.RoleClaimType = "roles";
  ```

* Path configuration: Paths must match the redirect URI (login callback path) and post logout redirect (signed-out callback path) paths configured when registering the application with the OIDC provider. In the Azure portal, paths are configured in the **Authentication** blade of the app's registration. Both the sign-in and sign-out paths must be registered as redirect URIs. The default values are `/signin-oidc` and `/signout-callback-oidc`.

  * <xref:Microsoft.AspNetCore.Builder.RemoteAuthenticationOptions.CallbackPath>: The request path within the app's base path where the user-agent is returned.
  
    In the Entra or Azure portal, set the path in the **Web** platform configuration's **Redirect URI**:

    > :::no-loc text="https://localhost/signin-oidc":::

    > [!NOTE]
    > A port isn't required for `localhost` addresses when using Microsoft Entra ID. Most other OIDC providers require a correct port.

  * <xref:Microsoft.AspNetCore.Builder.OpenIdConnectOptions.SignedOutCallbackPath%2A>: The request path within the app's base path where the user agent is returned after sign out from the identity provider.

    In the Entra or Azure portal, set the path in the **Web** platform configuration's **Redirect URI**:

    > :::no-loc text="https://localhost/signout-callback-oidc":::

    > [!NOTE]
    > A port isn't required for `localhost` addresses when using Microsoft Entra ID. Most other OIDC providers require a correct port.
  
    > [!NOTE]
    > If using Microsoft Identity Web, the provider currently only redirects back to the <xref:Microsoft.AspNetCore.Builder.OpenIdConnectOptions.SignedOutCallbackPath%2A> if the `microsoftonline.com` Authority (`https://login.microsoftonline.com/{TENANT ID}/v2.0/`) is used. This limitation doesn't exist if you can use the "common" Authority with Microsoft Identity Web. For more information, see [postLogoutRedirectUri not working when authority url contains a tenant ID (`AzureAD/microsoft-authentication-library-for-js` #5783)](https://github.com/AzureAD/microsoft-authentication-library-for-js/issues/5783).
  
  * <xref:Microsoft.AspNetCore.Builder.OpenIdConnectOptions.RemoteSignOutPath%2A>: Requests received on this path cause the handler to invoke sign-out using the sign-out scheme.

    In the Entra or Azure portal, set the **Front-channel logout URL**:

    > :::no-loc text="https://localhost/signout-oidc":::

    > [!NOTE]
    > A port isn't required for `localhost` addresses when using Microsoft Entra ID. Most other OIDC providers require a correct port.

  ```csharp
  oidcOptions.CallbackPath = new PathString("{PATH}");
  oidcOptions.SignedOutCallbackPath = new PathString("{PATH}");
  oidcOptions.RemoteSignOutPath = new PathString("{PATH}");
  ```

  Examples (default values):

  ```csharp
  oidcOptions.CallbackPath = new PathString("/signin-oidc");
  oidcOptions.SignedOutCallbackPath = new PathString("/signout-callback-oidc");
  oidcOptions.RemoteSignOutPath = new PathString("/signout-oidc");
  ```

* (*Microsoft Azure only with the "common" endpoint*) <xref:Microsoft.IdentityModel.Tokens.TokenValidationParameters.IssuerValidator%2A?displayProperty=nameWithType>: Many OIDC providers work with the default issuer validator, but we need to account for the issuer parameterized with the Tenant ID (`{TENANT ID}`) returned by `https://login.microsoftonline.com/common/v2.0/.well-known/openid-configuration`. For more information, see [SecurityTokenInvalidIssuerException with OpenID Connect and the Azure AD "common" endpoint (`AzureAD/azure-activedirectory-identitymodel-extensions-for-dotnet` #1731)](https://github.com/AzureAD/azure-activedirectory-identitymodel-extensions-for-dotnet/issues/1731).

  Only for apps using Microsoft Entra ID or Azure AD B2C with the "common" endpoint:

  ```csharp
  var microsoftIssuerValidator = AadIssuerValidator.GetAadIssuerValidator(oidcOptions.Authority);
  oidcOptions.TokenValidationParameters.IssuerValidator = microsoftIssuerValidator.Validate;
  ```

### Sample app code

Inspect the sample app for the following features:

* Automatic non-interactive token refresh with the help of a custom cookie refresher (`CookieOidcRefresher.cs`).
* The `PersistingAuthenticationStateProvider` class (`PersistingAuthenticationStateProvider.cs`) is a server-side <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> that uses <xref:Microsoft.AspNetCore.Components.PersistentComponentState> to flow the authentication state to the client, which is then fixed for the lifetime of the WebAssembly application.
* An example requests to the Blazor Web App for weather data is handled by a Minimal API endpoint (`/weather-forecast`) in the `Program` file (`Program.cs`). The endpoint requires authorization by calling <xref:Microsoft.AspNetCore.Builder.AuthorizationEndpointConventionBuilderExtensions.RequireAuthorization%2A>. For any controllers that you add to the project, add the [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) to the controller or action.
* The app securely calls a (web) API in the server project for weather data:
  * When rendering the `Weather` component on the server, the component uses the `ServerWeatherForecaster` on the server to obtain weather data directly (not via a web API call).
  * When the component is rendered on the client, the component uses the `ClientWeatherForecaster` service implementation, which uses a preconfigured <xref:System.Net.Http.HttpClient> (in the client project's `Program` file) to make a web API call to the server project. A Minimal API endpoint (`/weather-forecast`) defined in the server project's `Program` file obtains the weather data from the `ServerWeatherForecaster` and returns the data to the client.

For more information on (web) API calls using a service abstractions in Blazor Web Apps, see <xref:blazor/call-web-api#service-abstractions-for-web-api-calls>.

## Client-side Blazor Web App project (`BlazorWebAppOidc.Client`)

The `BlazorWebAppOidc.Client` project is the client-side project of the Blazor Web App.

The `PersistentAuthenticationStateProvider` class (`PersistentAuthenticationStateProvider.cs`) is a client-side <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> that determines the user's authentication state by looking for data persisted in the page when it was rendered on the server. The authentication state is fixed for the lifetime of the WebAssembly application.

If the user needs to log in or out, a full page reload is required.

The sample app only provides a user name and email for display purposes. It doesn't include tokens that authenticate to the server when making subsequent requests, which works separately using a cookie that's included on <xref:System.Net.Http.HttpClient> requests to the server.

:::zone-end

:::zone pivot="with-bff-pattern"

This version of the article covers implementing OIDC with the [Backend for Frontend (BFF) pattern](/azure/architecture/patterns/backends-for-frontends). Change the article version selector to **OIDC without BFF pattern** if the app's specification doesn't call for adopting the BFF pattern.

The following specification is covered:

* The Blazor Web App uses [the Auto render mode with global interactivity](xref:blazor/components/render-modes).
* Custom auth state provider services are used by the server and client apps to capture the user's authentication state and flow it between the server and client.
* This app is a starting point for any OIDC authentication flow. OIDC is configured manually in the app and doesn't rely upon [Microsoft Entra ID](https://www.microsoft.com/security/business/microsoft-entra) or [Microsoft Identity Web](/entra/msal/dotnet/microsoft-identity-web/) packages, nor does the sample app require [Microsoft Azure](https://azure.microsoft.com/) hosting. However, the sample app can be used with Entra, Microsoft Identity Web, and hosted in Azure.
* Automatic non-interactive token refresh.
* The [Backend for Frontend (BFF) pattern](/azure/architecture/patterns/backends-for-frontends) is adopted using [.NET Aspire](/dotnet/aspire/get-started/aspire-overview) for service discovery and [YARP](https://microsoft.github.io/reverse-proxy/) for proxying requests to a weather forecast endpoint on the backend app.
  * A backend web API uses JWT-bearer authentication to validate JWT tokens saved by the Blazor Web App in the sign-in cookie.
  * Aspire improves the experience of building .NET cloud-native apps. It provides a consistent, opinionated set of tools and patterns for building and running distributed apps.
  * YARP (Yet Another Reverse Proxy) is a library used to create a reverse proxy server.

<!-- UPDATE 9.0 Remove the following line at either 9.0 or 10.0 ... -->

For more information on .NET Aspire, see [General Availability of .NET Aspire: Simplifying .NET Cloud-Native Development (May, 2024)](https://devblogs.microsoft.com/dotnet/dotnet-aspire-general-availability/).

## Prerequisite

[.NET Aspire](/dotnet/aspire/get-started/aspire-overview) requires [Visual Studio](https://visualstudio.microsoft.com/) version 17.10 or later.

## Sample app

The sample app consists of five projects:

* .NET Aspire:
  * `Aspire.AppHost`: Used to manage the high level orchestration concerns of the app.
  * `Aspire.ServiceDefaults`: Contains default .NET Aspire app configurations that can be extended and customized as needed.
* `MinimalApiJwt`: Backend web API, containing an example [Minimal API](xref:fundamentals/minimal-apis) endpoint for weather data.
* `BlazorWebAppOidc`: Server-side project of the Blazor Web App.
* `BlazorWebAppOidc.Client`: Client-side project of the Blazor Web App.

Access the sample apps through the latest version folder from the repository's root with the following link. The projects are in the `BlazorWebAppOidcBff` folder for .NET 8 or later.

[View or download sample code](https://github.com/dotnet/blazor-samples) ([how to download](xref:blazor/fundamentals/index#sample-apps))

## .NET Aspire projects

For more information on using .NET Aspire and details on the `.AppHost` and `.ServiceDefaults` projects of the sample app, see the [.NET Aspire documentation](/dotnet/aspire/).

Confirm that you've met the prerequisites for .NET Aspire. For more information, see the *Prerequisites* section of [Quickstart: Build your first .NET Aspire app](/dotnet/aspire/get-started/build-your-first-aspire-app?tabs=visual-studio#prerequisites).

The sample app only configures an insecure HTTP launch profile (`http`) for use during development testing. For more information, including an example of insecure and secure launch settings profiles, see [Allow unsecure transport in .NET Aspire (.NET Aspire documentation)](/dotnet/aspire/troubleshooting/allow-unsecure-transport).

## Server-side Blazor Web App project (`BlazorWebAppOidc`)

The `BlazorWebAppOidc` project is the server-side project of the Blazor Web App. The project uses [YARP](https://microsoft.github.io/reverse-proxy/) to proxy requests to a weather forecast endpoint in the backend web API project (`MinimalApiJwt`) with the `access_token` stored in the authentication cookie.

The `BlazorWebAppOidc.http` file can be used for testing the weather data request. Note that the `BlazorWebAppOidc` project must be running to test the endpoint, and the endpoint is hardcoded into the file. For more information, see <xref:test/http-files>.

> [!NOTE]
> The server project uses <xref:Microsoft.AspNetCore.Http.IHttpContextAccessor>/<xref:Microsoft.AspNetCore.Http.HttpContext>, but never for interactively-rendered components. For more information, see <xref:blazor/security/server/interactive-server-side-rendering#ihttpcontextaccessorhttpcontext-in-razor-components>.

### Configuration

This section explains how to configure the sample app.

> [!NOTE]
> For Microsoft Entra ID and Azure AD B2C, you can use <xref:Microsoft.Identity.Web.AppBuilderExtension.AddMicrosoftIdentityWebApp%2A> from [Microsoft Identity Web](/entra/msal/dotnet/microsoft-identity-web/) ([`Microsoft.Identity.Web` NuGet package](https://www.nuget.org/packages/Microsoft.Identity.Web), [API documentation](<xref:Microsoft.Identity.Web?displayProperty=fullName>)), which adds both the OIDC and Cookie authentication handlers with the appropriate defaults. The sample app and the guidance in this section doesn't use Microsoft Identity Web. The guidance demonstrates how to configure the OIDC handler *manually* for any OIDC provider. For more information on implementing Microsoft Identity Web, see the linked resources.

The following <xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions> configuration is found in the project's `Program` file on the call to <xref:Microsoft.Extensions.DependencyInjection.OpenIdConnectExtensions.AddOpenIdConnect%2A>:

* <xref:Microsoft.AspNetCore.Builder.RemoteAuthenticationOptions.SignInScheme%2A>: Sets the authentication scheme corresponding to the middleware responsible of persisting user's identity after a successful authentication. The OIDC handler needs to use a sign-in scheme that's capable of persisting user credentials across requests. The following line is present merely for demonstration purposes. If omitted, <xref:Microsoft.AspNetCore.Authentication.AuthenticationOptions.DefaultSignInScheme%2A> is used as a fallback value.

  ```csharp
  oidcOptions.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
  ```

* Scopes for `openid` and `profile` (<xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.Scope%2A>) (Optional): The `openid` and `profile` scopes are also configured by default because they're required for the OIDC handler to work, but these may need to be re-added if scopes are included in the `Authentication:Schemes:MicrosoftOidc:Scope` configuration. For general configuration guidance, see <xref:fundamentals/configuration/index> and <xref:blazor/fundamentals/configuration>.

  ```csharp
  oidcOptions.Scope.Add(OpenIdConnectScope.OpenIdProfile);
  ```

* <xref:Microsoft.AspNetCore.Authentication.RemoteAuthenticationOptions.SaveTokens%2A>: Defines whether access and refresh tokens should be stored in the <xref:Microsoft.AspNetCore.Authentication.AuthenticationProperties> after a successful authorization. The value is set to `true` to authenticate requests for weather data from the backend web API project (`MinimalApiJwt`).

  ```csharp
  oidcOptions.SaveTokens = true;
  ```

* Scope for offline access (<xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.Scope%2A>): The `offline_access` scope is required for the refresh token.

  ```csharp
  oidcOptions.Scope.Add(OpenIdConnectScope.OfflineAccess);
  ```

* Scopes for obtaining weather data from the web API (<xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.Scope%2A>): The `Weather.Get` scope is configured in the Azure or Entra portal under **Expose an API**. This is necessary for backend web API project (`MinimalApiJwt`) to validate the access token with bearer JWT.

  ```csharp
  oidcOptions.Scope.Add("{APP ID URI}/{API NAME}");
  ```

  Example:

  * App ID URI (`{APP ID URI}`): `https://{DIRECTORY NAME}.onmicrosoft.com/{CLIENT ID}`
    * Directory Name (`{DIRECTORY NAME}`): `contoso`
    * Application (Client) Id (`{CLIENT ID}`): `4ba4de56-9cef-45d9-83fa-a4c18f9f5f0f`
  * Scope configured for weather data from `MinimalApiJwt` (`{API NAME}`): `Weather.Get`

  ```csharp
  oidcOptions.Scope.Add("https://contoso.onmicrosoft.com/4ba4de56-9cef-45d9-83fa-a4c18f9f5f0f/Weather.Get");
  ```

  The preceding example pertains to an app registered in a tenant with an AAD B2C tenant type. If the app is registered in an ME-ID tenant, the App ID URI is different, thus the scope is different.

  Example:

  * App ID URI (`{APP ID URI}`): `api://{CLIENT ID}` with Application (Client) Id (`{CLIENT ID}`): `4ba4de56-9cef-45d9-83fa-a4c18f9f5f0f`
  * Scope configured for weather data from `MinimalApiJwt` (`{API NAME}`): `Weather.Get`

  ```csharp
  oidcOptions.Scope.Add("api://4ba4de56-9cef-45d9-83fa-a4c18f9f5f0f/Weather.Get");
  ```

* <xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.Authority%2A> and <xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.ClientId%2A>: Sets the Authority and Client ID for OIDC calls.

  ```csharp
  oidcOptions.Authority = "{AUTHORITY}";
  oidcOptions.ClientId = "{CLIENT ID}";
  ```

  Example:

  * Authority (`{AUTHORITY}`): `https://login.microsoftonline.com/a3942615-d115-4eb7-bc84-9974abcf5064/v2.0/` (uses Tenant ID `a3942615-d115-4eb7-bc84-9974abcf5064`)
  * Client Id (`{CLIENT ID}`): `4ba4de56-9cef-45d9-83fa-a4c18f9f5f0f`

  ```csharp
  oidcOptions.Authority = "https://login.microsoftonline.com/a3942615-d115-4eb7-bc84-9974abcf5064/v2.0/";
  oidcOptions.ClientId = "4ba4de56-9cef-45d9-83fa-a4c18f9f5f0f";
  ```

  Example for Microsoft Azure "common" authority:
  
  The "common" authority should be used for multi-tenant apps. You can also use the "common" authority for single-tenant apps, but a custom <xref:Microsoft.IdentityModel.Tokens.TokenValidationParameters.IssuerValidator%2A> is required, as shown later in this section.

  ```csharp
  oidcOptions.Authority = "https://login.microsoftonline.com/common/v2.0/";
  ```

* <xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.ClientSecret%2A>: The OIDC client secret.

  **The following example is only for testing and demonstration purposes. Don't store the client secret in the app's assembly or check the secret into source control.**  Store the client secret in [User Secrets](xref:security/app-secrets), [Azure Key Vault](xref:security/key-vault-configuration), or an [environment variable](xref:fundamentals/configuration/index#non-prefixed-environment-variables).
  
  Authentication scheme configuration is automatically read from `builder.Configuration["Authentication:Schemes:{SCHEME NAME}:{PropertyName}"]`, where the `{SCHEME NAME}` placeholder is the scheme, which is `MicrosoftOidc` by default. Because configuration is preconfigured, a client secret can automatically be read via the `Authentication:Schemes:MicrosoftOidc:ClientSecret` configuration key. On the server using environment variables, name the environment variable `Authentication__Schemes__MicrosoftOidc__ClientSecret`:

  ```dotnetcli
  set Authentication__Schemes__MicrosoftOidc__ClientSecret={CLIENT SECRET}
  ```
  
  **For demonstration and testing only**, the <xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.ClientSecret%2A> can be set directly. Don't set the value directly for deployed production apps. For slightly improved security, [conditionally compile](/dotnet/csharp/language-reference/preprocessor-directives#conditional-compilation) the line with the `DEBUG` symbol:

  ```csharp
  #if DEBUG
  oidcOptions.ClientSecret = "{CLIENT SECRET}";
  #endif
  ```

  Example:

  Client secret (`{CLIENT SECRET}`): `463471c8c4...f90d674bc9` (shortened for display)

  ```csharp
  #if DEBUG
  oidcOptions.ClientSecret = "463471c8c4...137f90d674bc9";
  #endif
  ```

* <xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.ResponseType%2A>: Configures the OIDC handler to only perform authorization code flow. Implicit grants and hybrid flows are unnecessary in this mode.

  In the Entra or Azure portal's **Implicit grant and hybrid flows** app registration configuration, do **not** select either checkbox for the authorization endpoint to return **Access tokens** or **ID tokens**. The OIDC handler automatically requests the appropriate tokens using the code returned from the authorization endpoint.

  ```csharp
  oidcOptions.ResponseType = OpenIdConnectResponseType.Code;
  ```

* <xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.MapInboundClaims%2A> and configuration of <xref:Microsoft.IdentityModel.Tokens.TokenValidationParameters.NameClaimType%2A> and <xref:Microsoft.IdentityModel.Tokens.TokenValidationParameters.RoleClaimType%2A>: Many OIDC servers use "`name`" and "`role`" rather than the SOAP/WS-Fed defaults in <xref:System.Security.Claims.ClaimTypes>. When <xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.MapInboundClaims%2A> is set to `false`, the handler doesn't perform claims mappings and the claim names from the JWT are used directly by the app. The following example sets the role claim type to "`roles`," which is appropriate for [Microsoft Entra ID (ME-ID)](https://www.microsoft.com/security/business/microsoft-entra). Consult your identity provider's documentation for more information.

> [!NOTE]
> <xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.MapInboundClaims%2A> must be set to `false` for most OIDC providers, which prevents renaming claims.
  
  ```csharp
  oidcOptions.MapInboundClaims = false;
  oidcOptions.TokenValidationParameters.NameClaimType = JwtRegisteredClaimNames.Name;
  oidcOptions.TokenValidationParameters.RoleClaimType = "roles";
  ```

* Path configuration: Paths must match the redirect URI (login callback path) and post logout redirect (signed-out callback path) paths configured when registering the application with the OIDC provider. In the Azure portal, paths are configured in the **Authentication** blade of the app's registration. Both the sign-in and sign-out paths must be registered as redirect URIs. The default values are `/signin-oidc` and `/signout-callback-oidc`.

  * <xref:Microsoft.AspNetCore.Builder.RemoteAuthenticationOptions.CallbackPath>: The request path within the app's base path where the user-agent is returned.
  
    In the Entra or Azure portal, set the path in the **Web** platform configuration's **Redirect URI**:

    > :::no-loc text="https://localhost/signin-oidc":::

    > [!NOTE]
    > A port isn't required for `localhost` addresses.

  * <xref:Microsoft.AspNetCore.Builder.OpenIdConnectOptions.SignedOutCallbackPath%2A>: The request path within the app's base path where the user agent is returned after sign out from the identity provider.

    In the Entra or Azure portal, set the path in the **Web** platform configuration's **Redirect URI**:

    > :::no-loc text="https://localhost/signout-callback-oidc":::

    > [!NOTE]
    > A port isn't required for `localhost` addresses.
  
    > [!NOTE]
    > If using Microsoft Identity Web, the provider currently only redirects back to the <xref:Microsoft.AspNetCore.Builder.OpenIdConnectOptions.SignedOutCallbackPath%2A> if the `microsoftonline.com` Authority (`https://login.microsoftonline.com/{TENANT ID}/v2.0/`) is used. This limitation doesn't exist if you can use the "common" Authority with Microsoft Identity Web. For more information, see [postLogoutRedirectUri not working when authority url contains a tenant ID (`AzureAD/microsoft-authentication-library-for-js` #5783)](https://github.com/AzureAD/microsoft-authentication-library-for-js/issues/5783).
  
  * <xref:Microsoft.AspNetCore.Builder.OpenIdConnectOptions.RemoteSignOutPath%2A>: Requests received on this path cause the handler to invoke sign-out using the sign-out scheme.

    In the Entra or Azure portal, set the **Front-channel logout URL**:

    > :::no-loc text="https://localhost/signout-oidc":::

    > [!NOTE]
    > A port isn't required for `localhost` addresses.

  ```csharp
  oidcOptions.CallbackPath = new PathString("{PATH}");
  oidcOptions.SignedOutCallbackPath = new PathString("{PATH}");
  oidcOptions.RemoteSignOutPath = new PathString("{PATH}");
  ```

  Examples (default values):

  ```csharp
  oidcOptions.CallbackPath = new PathString("/signin-oidc");
  oidcOptions.SignedOutCallbackPath = new PathString("/signout-callback-oidc");
  oidcOptions.RemoteSignOutPath = new PathString("/signout-oidc");
  ```

* (*Microsoft Azure only with the "common" endpoint*) <xref:Microsoft.IdentityModel.Tokens.TokenValidationParameters.IssuerValidator%2A?displayProperty=nameWithType>: Many OIDC providers work with the default issuer validator, but we need to account for the issuer parameterized with the Tenant ID (`{TENANT ID}`) returned by `https://login.microsoftonline.com/common/v2.0/.well-known/openid-configuration`. For more information, see [SecurityTokenInvalidIssuerException with OpenID Connect and the Azure AD "common" endpoint (`AzureAD/azure-activedirectory-identitymodel-extensions-for-dotnet` #1731)](https://github.com/AzureAD/azure-activedirectory-identitymodel-extensions-for-dotnet/issues/1731).

  Only for apps using Microsoft Entra ID or Azure AD B2C with the "common" endpoint:

  ```csharp
  var microsoftIssuerValidator = AadIssuerValidator.GetAadIssuerValidator(oidcOptions.Authority);
  oidcOptions.TokenValidationParameters.IssuerValidator = microsoftIssuerValidator.Validate;
  ```

### Sample app code

Inspect the sample app for the following features:

* Automatic non-interactive token refresh with the help of a custom cookie refresher (`CookieOidcRefresher.cs`).
* The `PersistingAuthenticationStateProvider` class (`PersistingAuthenticationStateProvider.cs`) is a server-side <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> that uses <xref:Microsoft.AspNetCore.Components.PersistentComponentState> to flow the authentication state to the client, which is then fixed for the lifetime of the WebAssembly application.
* Requests to the Blazor Web App are proxied to the backend web API project (`MinimalApiJwt`). `MapForwarder` in the `Program` file adds direct forwarding of HTTP requests that match the specified pattern to a specific destination using default configuration for the outgoing request, customized transforms, and default HTTP client:
  * When rendering the `Weather` component on the server, the component uses the `ServerWeatherForecaster` to proxy the request for weather data with the user's access token.
  * When the component is rendered on the client, the component uses the `ClientWeatherForecaster` service implementation, which uses a preconfigured <xref:System.Net.Http.HttpClient> (in the client project's `Program` file) to make a web API call to the server project. A Minimal API endpoint (`/weather-forecast`) defined in the server project's `Program` file transforms the request with the user's access token to obtain the weather data.

For more information on (web) API calls using a service abstractions in Blazor Web Apps, see <xref:blazor/call-web-api#service-abstractions-for-web-api-calls>.

## Client-side Blazor Web App project (`BlazorWebAppOidc.Client`)

The `BlazorWebAppOidc.Client` project is the client-side project of the Blazor Web App.

The `PersistentAuthenticationStateProvider` class (`PersistentAuthenticationStateProvider.cs`) is a client-side <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> that determines the user's authentication state by looking for data persisted in the page when it was rendered on the server. The authentication state is fixed for the lifetime of the WebAssembly application.

If the user needs to log in or out, a full page reload is required.

The sample app only provides a user name and email for display purposes. It doesn't include tokens that authenticate to the server when making subsequent requests, which works separately using a cookie that's included on <xref:System.Net.Http.HttpClient> requests to the server.

## Backend web API project (`MinimalApiJwt`)

The `MinimalApiJwt` project is a backend web API for multiple frontend projects. The project configures a [Minimal API](xref:fundamentals/minimal-apis) endpoint for weather data. Requests from the Blazor Web App server-side project (`BlazorWebAppOidc`) are proxied to the `MinimalApiJwt` project.

### Configuration

Configure the project in the <xref:Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerOptions> of the <xref:Microsoft.Extensions.DependencyInjection.JwtBearerExtensions.AddJwtBearer%2A> call in the project's `Program` file:

* <xref:Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerOptions.Audience%2A>: Sets the Audience for any received OpenID Connect token. 

  In the Azure or Entra portal: Match the value to just the path of the **Application ID URI** configured when adding the `Weather.Get` scope under **Expose an API**:

  ```csharp
  jwtOptions.Audience = "{APP ID URI}";
  ```

  Example:

  App ID URI (`{APP ID URI}`): `https://{DIRECTORY NAME}.onmicrosoft.com/{CLIENT ID}`:
  
  * Directory Name (`{DIRECTORY NAME}`): `contoso`
  * Application (Client) Id (`{CLIENT ID}`): `4ba4de56-9cef-45d9-83fa-a4c18f9f5f0f`

  ```csharp
  jwtOptions.Audience = "https://contoso.onmicrosoft.com/4ba4de56-9cef-45d9-83fa-a4c18f9f5f0f";
  ```

  The preceding example pertains to an app registered in a tenant with an AAD B2C tenant type. If the app is registered in an ME-ID tenant, the App ID URI is different, thus the audience is different.

  Example:

  App ID URI (`{APP ID URI}`): `api://{CLIENT ID}` with Application (Client) Id (`{CLIENT ID}`): `4ba4de56-9cef-45d9-83fa-a4c18f9f5f0f`

  ```csharp
  jwtOptions.Audience = "api://4ba4de56-9cef-45d9-83fa-a4c18f9f5f0f";
  ```

* <xref:Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerOptions.Authority%2A>: Sets the Authority for making OpenID Connect calls. Match the value to the Authority configured for the OIDC handler in `BlazorWebAppOidc/Program.cs`:

  ```csharp
  jwtOptions.Authority = "{AUTHORITY}";
  ```

  Example:

  Authority (`{AUTHORITY}`): `https://login.microsoftonline.com/a3942615-d115-4eb7-bc84-9974abcf5064/v2.0/` (uses Tenant ID `a3942615-d115-4eb7-bc84-9974abcf5064`)

  ```csharp
  jwtOptions.Authority = "https://login.microsoftonline.com/a3942615-d115-4eb7-bc84-9974abcf5064/v2.0/";
  ```

  The preceding example pertains to an app registered in a tenant with an AAD B2C tenant type. If the app is registered in an ME-ID tenant, the authority should match the issurer (`iss`) of the JWT returned by the identity provider:

  ```csharp
  jwtOptions.Authority = "https://sts.windows.net/a3942615-d115-4eb7-bc84-9974abcf5064/";
  ```

### Minimal API for weather data

Secure weather forecast data endpoint in the project's `Program` file:

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

:::zone-end

## Adding components that adopt interactive server-side rendering

Because the app uses global Interactive Auto rendering via the `Routes` component, individual components that specify interactive server-side rendering (interactive SSR, `@rendermode InteractiveServer`) in their component definition file (`.razor`) are *placed in the `.Client` project's `Pages` folder*.

Placing interactive SSR components in the `.Client` project is counter-intuitive because such components are only rendered on the server.

If you place an interactive SSR component in the server project's `Components/Pages` folder, the component is prerendered normally and briefly displayed in the user's browser. However, the client-side router isn't able to find the component, ultimately resulting in a *404 - Not Found* in the browser.

Therefore, place interactive SSR components in the `.Client` project's `Pages` folder.

## Redirect to the home page on signout

When a user navigates around the app, the `LogInOrOut` component (`Layout/LogInOrOut.razor`) sets a hidden field for the return URL (`ReturnUrl`) to the value of the current URL (`currentURL`). When the user signs out of the app, the identity provider returns them to the page from which they signed out.

If the user signs out from a secure page, they're returned back to the same secure page after signing out only to be sent back through the authentication process. This behavior is fine when users need to switch accounts frequently. However, a alternative app specification may call for the user to be returned to the app's home page or some other page after signout. The following example shows how to set the app's home page as the return URL for signout operations.

The important changes to the `LogInOrOut` component are demonstrated in the following example. The `value` of the hidden field for the `ReturnUrl` is set to the home page at `/`. <xref:System.IDisposable> is no longer implemented. The <xref:Microsoft.AspNetCore.Components.NavigationManager> is no longer injected. The entire `@code` block is removed.

`Layout/LogInOrOut.razor`:

```razor
@using Microsoft.AspNetCore.Authorization

<div class="nav-item px-3">
    <AuthorizeView>
        <Authorized>
            <form action="authentication/logout" method="post">
                <AntiforgeryToken />
                <input type="hidden" name="ReturnUrl" value="/" />
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

## Cryptographic nonce

A *nonce* is a string value that associates a client's session with an ID token to mitigate [replay attacks](https://developer.mozilla.org/docs/Glossary/Replay_attack).

If you receive a nonce error during authentication development and testing, use a new InPrivate/incognito browser session for each test run, no matter how small the change made to the app or test user because stale cookie data can lead to a nonce error. For more information, see the [Cookies and site data](#cookies-and-site-data) section.

A nonce isn't required or used when a refresh token is exchanged for a new access token. In the sample app, the `CookieOidcRefresher` (`CookieOidcRefresher.cs`) deliberately sets <xref:Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectProtocolValidator.RequireNonce?displayProperty=nameWithType> to `false`.

## Application roles for apps not registered with Microsoft Entra (ME-ID)

*This section pertains to apps that don't use [Microsoft Entra ID (ME-ID)](https://www.microsoft.com/security/business/microsoft-entra) as the identity provider. For apps registered with ME-ID, see the [Application roles for apps registered with Microsoft Entra (ME-ID)](#application-roles-for-apps-registered-with-microsoft-entra-me-id) section.*

Configure the role claim type (<xref:Microsoft.IdentityModel.Tokens.TokenValidationParameters.RoleClaimType?displayProperty=nameWithType>) in the <xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions> of `Program.cs`:

```csharp
oidcOptions.TokenValidationParameters.RoleClaimType = "{ROLE CLAIM TYPE}";
```

For many OIDC identity providers, the role claim type is `role`. Check your identity provider's documentation for the correct value.

Replace the `UserInfo` class in the `BlazorWebAppOidc.Client` project with the following class.

`UserInfo.cs`:

```csharp
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.Security.Claims;

namespace BlazorWebAppOidc.Client;

// Add properties to this class and update the server and client 
// AuthenticationStateProviders to expose more information about 
// the authenticated user to the client.
public sealed class UserInfo
{
    public required string UserId { get; init; }
    public required string Name { get; init; }
    public required string[] Roles { get; init; }

    public const string UserIdClaimType = "sub";
    public const string NameClaimType = "name";
    private const string RoleClaimType = "role";

    public static UserInfo FromClaimsPrincipal(ClaimsPrincipal principal) =>
        new()
        {
            UserId = GetRequiredClaim(principal, UserIdClaimType),
            Name = GetRequiredClaim(principal, NameClaimType),
            Roles = principal.FindAll(RoleClaimType).Select(c => c.Value)
                .ToArray(),
        };

    public ClaimsPrincipal ToClaimsPrincipal() =>
        new(new ClaimsIdentity(
            Roles.Select(role => new Claim(RoleClaimType, role))
                .Concat([
                    new Claim(UserIdClaimType, UserId),
                    new Claim(NameClaimType, Name),
                ]),
            authenticationType: nameof(UserInfo),
            nameType: NameClaimType,
            roleType: RoleClaimType));

    private static string GetRequiredClaim(ClaimsPrincipal principal,
        string claimType) =>
            principal.FindFirst(claimType)?.Value ??
            throw new InvalidOperationException(
                $"Could not find required '{claimType}' claim.");
}
```

At this point, Razor components can adopt [role-based and policy-based authorization](xref:blazor/security/index#role-based-and-policy-based-authorization). Application roles appear in `role` claims, one claim per role.

## Application roles for apps registered with Microsoft Entra (ME-ID)

Use the guidance in this section to implement application roles, ME-ID security groups, and ME-ID built-in administrator roles for apps using [Microsoft Entra ID (ME-ID)](https://www.microsoft.com/security/business/microsoft-entra).

Configure the role claim type (<xref:Microsoft.IdentityModel.Tokens.TokenValidationParameters.RoleClaimType?displayProperty=nameWithType>) in <xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions> of `Program.cs`. Set the value to `roles`:

```csharp
oidcOptions.TokenValidationParameters.RoleClaimType = "roles";
```

Although you can't [assign roles to groups](/entra/identity/role-based-access-control/groups-concept) without an ME-ID Premium account, you can assign roles to users and receive role claims for users with a standard Azure account. The guidance in this section doesn't require an ME-ID Premium account.

When working with the default directory, follow the guidance in [Add app roles to your application and receive them in the token (ME-ID documentation)](/entra/identity-platform/howto-add-app-roles-in-apps) to configure and assign roles. If you aren't working with the default directory, edit the app's manifest in the Azure portal to establish the app's roles manually in the `appRoles` entry of the manifest file. For more information, see [Configure the role claim (ME-ID documentation)](/entra/identity-platform/enterprise-app-role-management).

A user's Azure security groups arrive in `groups` claims, and a user's built-in ME-ID administrator role assignments arrive in [well-known IDs (`wids`) claims](/entra/identity-platform/access-tokens#payload-claims). Values for both claim types are GUIDs. When received by the app, these claims can be used to establish [role and policy authorization in Razor components](xref:blazor/security/index#role-based-and-policy-based-authorization).

In the app's manifest in the Azure portal, set the [`groupMembershipClaims` attribute](/entra/identity-platform/reference-app-manifest#groupmembershipclaims-attribute) to `All`. A value of `All` results in ME-ID sending all of the security/distribution groups (`groups` claims) and roles (`wids` claims) of the signed-in user. To set the `groupMembershipClaims` attribute:

1. Open the app's registration in the Azure portal.
1. Select **Manage** > **Manifest** in the sidebar.
1. Find the `groupMembershipClaims` attribute.
1. Set the value to `All` (`"groupMembershipClaims": "All"`).
1. Select the **Save** button.

Replace the `UserInfo` class in the `BlazorWebAppOidc.Client` project with the following class.

`UserInfo.cs`:

```csharp
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.Security.Claims;

namespace BlazorWebAppOidc.Client;

// Add properties to this class and update the server and client 
// AuthenticationStateProviders to expose more information about 
// the authenticated user to the client.
public sealed class UserInfo
{
    public required string UserId { get; init; }
    public required string Name { get; init; }
    public required string[] Roles { get; init; }
    public required string[] Groups { get; init; }
    public required string[] Wids { get; init; }

    public const string UserIdClaimType = "sub";
    public const string NameClaimType = "name";
    private const string RoleClaimType = "roles";
    private const string GroupsClaimType = "groups";
    private const string WidsClaimType = "wids";

    public static UserInfo FromClaimsPrincipal(ClaimsPrincipal principal) =>
        new()
        {
            UserId = GetRequiredClaim(principal, UserIdClaimType),
            Name = GetRequiredClaim(principal, NameClaimType),
            Roles = principal.FindAll(RoleClaimType).Select(c => c.Value)
                .ToArray(),
            Groups = principal.FindAll(GroupsClaimType).Select(c => c.Value)
                .ToArray(),
            Wids = principal.FindAll(WidsClaimType).Select(c => c.Value)
                .ToArray(),
        };

    public ClaimsPrincipal ToClaimsPrincipal() =>
        new(new ClaimsIdentity(
            Roles.Select(role => new Claim(RoleClaimType, role))
                .Concat(Groups.Select(role => new Claim(GroupsClaimType, role)))
                .Concat(Wids.Select(role => new Claim(WidsClaimType, role)))
                .Concat([
                    new Claim(UserIdClaimType, UserId),
                    new Claim(NameClaimType, Name),
                ]),
            authenticationType: nameof(UserInfo),
            nameType: NameClaimType,
            roleType: RoleClaimType));

    private static string GetRequiredClaim(ClaimsPrincipal principal,
        string claimType) =>
            principal.FindFirst(claimType)?.Value ??
            throw new InvalidOperationException(
                $"Could not find required '{claimType}' claim.");
}
```

At this point, Razor components can adopt [role-based and policy-based authorization](xref:blazor/security/index#role-based-and-policy-based-authorization):

* Application roles appear in `roles` claims, one claim per role.
* Security groups appear in `groups` claims, one claim per group. The security group GUIDs appear in the Azure portal when you create a security group and are listed when selecting **Identity** > **Overview** > **Groups** > **View**.
* Built-in ME-ID administrator roles appear in `wids` claims, one claim per role. The `wids` claim with a value of `b79fbf4d-3ef9-4689-8143-76b194e85509` is always sent by ME-ID for non-guest accounts of the tenant and doesn't refer to an administrator role. Administrator role GUIDs (*role template IDs*) appear in the Azure portal when selecting **Roles & admins**, followed by the ellipsis (**&hellip;**) > **Description** for the listed role. The role template IDs are also listed in [Microsoft Entra built-in roles (Entra documentation)](/entra/identity/role-based-access-control/permissions-reference).

## Troubleshoot

[!INCLUDE[](~/blazor/security/includes/troubleshoot-server.md)]

## Additional resources

<!-- UPDATE 10.0 The PU has scheduled dotnet/aspnetcore #55213
                 for investigation/resolution at .NET 10 -->

* [`AzureAD/microsoft-identity-web` GitHub repository](https://github.com/AzureAD/microsoft-identity-web/wiki): Helpful guidance on implementing Microsoft Identity Web for Microsoft Entra ID and Azure Active Directory B2C for ASP.NET Core apps, including links to sample apps and related Azure documentation. Currently, Blazor Web Apps aren't explicitly addressed by the Azure documentation, but the setup and configuration of a Blazor Web App for ME-ID and Azure hosting is the same as it is for any ASP.NET Core web app.
* [`AuthenticationStateProvider` service](xref:blazor/security/index#authenticationstateprovider-service)
* [Manage authentication state in Blazor Web Apps](xref:blazor/security/server/index#manage-authentication-state-in-blazor-web-apps)
* [Refresh token during http request in Blazor Interactive Server with OIDC (`dotnet/aspnetcore` #55213)](https://github.com/dotnet/aspnetcore/issues/55213)
