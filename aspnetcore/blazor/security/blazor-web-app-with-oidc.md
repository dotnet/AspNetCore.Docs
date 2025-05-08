---
title: Secure an ASP.NET Core Blazor Web App with OpenID Connect (OIDC)
author: guardrex
description: Learn how to secure a Blazor Web App with OpenID Connect (OIDC).
monikerRange: '>= aspnetcore-8.0'
ms.author: riande
ms.custom: mvc
ms.date: 04/29/2025
uid: blazor/security/blazor-web-app-oidc
zone_pivot_groups: blazor-web-app-oidc-specification
---
# Secure an ASP.NET Core Blazor Web App with OpenID Connect (OIDC)

[!INCLUDE[](~/includes/not-latest-version-without-not-supported-content.md)]

This article describes how to secure a Blazor Web App with [OpenID Connect (OIDC)](https://openid.net/developers/how-connect-works/) using a sample app in the [`dotnet/blazor-samples` GitHub repository (.NET 8 or later)](https://github.com/dotnet/blazor-samples) ([how to download](xref:blazor/fundamentals/index#sample-apps)).

:::moniker-range=">= aspnetcore-9.0"

For Microsoft Entra ID or Azure AD B2C, you can use <xref:Microsoft.Identity.Web.AppBuilderExtension.AddMicrosoftIdentityWebApp%2A> from [Microsoft Identity Web](/entra/msal/dotnet/microsoft-identity-web/) ([`Microsoft.Identity.Web` NuGet package](https://www.nuget.org/packages/Microsoft.Identity.Web), [API documentation](<xref:Microsoft.Identity.Web?displayProperty=fullName>)), which adds both the OIDC and Cookie authentication handlers with the appropriate defaults. The sample app and the guidance in this article don't use Microsoft Identity Web. The guidance demonstrates how to configure the OIDC handler *manually* for any OIDC provider. For more information on implementing Microsoft Identity Web, see <xref:blazor/security/blazor-web-app-entra>.

:::moniker-end

:::zone pivot="non-bff-pattern"

This version of the article covers implementing OIDC without adopting the [Backend for Frontend (BFF) pattern](/azure/architecture/patterns/backends-for-frontends) with an app that adopts global Interactive Auto rendering (server and `.Client` projects). The BFF pattern is useful for making authenticated requests to external services. Change the article version selector to **BFF pattern** if the app's specification calls for adopting the BFF pattern.

The following specification is adopted:

* The Blazor Web App uses [the Auto render mode with global interactivity](xref:blazor/components/render-modes).
* Custom auth state provider services are used by the server and client apps to capture the user's authentication state and flow it between the server and client.
* This app is a starting point for any OIDC authentication flow. OIDC is configured manually in the app and doesn't rely upon [Microsoft Entra ID](https://www.microsoft.com/security/business/microsoft-entra) or [Microsoft Identity Web](/entra/msal/dotnet/microsoft-identity-web/) packages, nor does the sample app require [Microsoft Azure](https://azure.microsoft.com/) hosting. However, the sample app can be used with Entra, Microsoft Identity Web, and hosted in Azure.
* Automatic non-interactive token refresh.
* A separate web API project demonstrates a secure web API call for weather data.

For an alternative experience using [Microsoft Authentication Library for .NET](/entra/msal/dotnet/), [Microsoft Identity Web](/entra/msal/dotnet/microsoft-identity-web/), and [Microsoft Entra ID](https://www.microsoft.com/security/business/identity-access/microsoft-entra-id), see <xref:blazor/security/blazor-web-app-entra>.

## Sample solution

The sample app consists of the following projects:

* `BlazorWebAppOidc`: Server-side project of the Blazor Web App, containing an example [Minimal API](xref:fundamentals/minimal-apis) endpoint for weather data.
* `BlazorWebAppOidc.Client`: Client-side project of the Blazor Web App.
* `MinimalApiJwt`: Backend web API with a [Minimal API](xref:fundamentals/minimal-apis) endpoint for weather data.

Access the sample through the latest version folder in the Blazor samples repository with the following link. The sample is in the `BlazorWebAppOidc` folder for .NET 8 or later.

[View or download sample code](https://github.com/dotnet/blazor-samples) ([how to download](xref:blazor/fundamentals/index#sample-apps))

Sample solution features:

* Automatic non-interactive token refresh with the help of a custom cookie refresher (`CookieOidcRefresher.cs`).

* Weather data is handled by a Minimal API endpoint (`/weather-forecast`) in the `Program` file (`Program.cs`) of the `MinimalApiJwt` project. The endpoint requires authorization by calling <xref:Microsoft.AspNetCore.Builder.AuthorizationEndpointConventionBuilderExtensions.RequireAuthorization%2A>. For any controllers that you add to the project, add the [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) to the controller or action. For more information on requiring authorization across the app via an [authorization policy](xref:security/authorization/policies) and opting out of authorization at a subset of public endpoints, see the [Razor Pages OIDC guidance](xref:security/authentication/configure-oidc-web-authentication#force-authorization).

* The app securely calls a web API for weather data:

  * When rendering the `Weather` component on the server, the component uses the `ServerWeatherForecaster` on the server to obtain weather data from the web API in the `MinimalApiJwt` project using a <xref:System.Net.Http.DelegatingHandler> (`TokenHandler`) that attaches the access token from  the <xref:Microsoft.AspNetCore.Http.HttpContext> to the request.
  * When the component is rendered on the client, the component uses the `ClientWeatherForecaster` service implementation, which uses a preconfigured <xref:System.Net.Http.HttpClient> (in the client project's `Program` file) to make the web API call from the server project's `ServerWeatherForecaster`.

:::moniker range=">= aspnetcore-9.0"

* The server project calls <xref:Microsoft.Extensions.DependencyInjection.WebAssemblyRazorComponentsBuilderExtensions.AddAuthenticationStateSerialization%2A> to add a server-side authentication state provider that uses <xref:Microsoft.AspNetCore.Components.PersistentComponentState> to flow the authentication state to the client. The client calls <xref:Microsoft.Extensions.DependencyInjection.WebAssemblyAuthenticationServiceCollectionExtensions.AddAuthenticationStateDeserialization%2A> to deserialize and use the authentication state passed by the server. The authentication state is fixed for the lifetime of the WebAssembly application.

:::moniker-end

:::moniker range="< aspnetcore-9.0"

* The `PersistingAuthenticationStateProvider` class (`PersistingAuthenticationStateProvider.cs`) is a server-side <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> that uses <xref:Microsoft.AspNetCore.Components.PersistentComponentState> to flow the authentication state to the client, which is then fixed for the lifetime of the WebAssembly application.

:::moniker-end

For more information on (web) API calls using a service abstractions in Blazor Web Apps, see <xref:blazor/call-web-api#service-abstractions-for-web-api-calls>.

## Microsoft Entra ID app registrations

We recommend using separate registrations for apps and web APIs, even when the apps and web APIs are in the same solution. The following guidance is for the `BlazorWebAppOidc` app and `MinimalApiJwt` web API of the sample solution, but the same guidance applies generally to any Entra-based registrations for apps and web APIs.

Register the web API (`MinimalApiJwt`) first so that you can then grant access to the web API when registering the app. The web API's tenant ID and client ID are used to configure the web API in its `Program` file. After registering the web API, expose the web API in **App registrations** > **Expose an API** with a scope name of `Weather.Get`. Record the App ID URI for use in the app's configuration.

Next, register the app (`BlazorWebAppOidc`/`BlazorWebApOidc.Client`) with a **Web** platform configuration and a **Redirect URI** of `https://localhost/signin-oidc` (a port isn't required). The app's tenant ID and client ID, along with the web API's base address, App ID URI, and weather scope name, are used to configure the app in its `Program` file. Grant API permission to access the web API in **App registrations** > **API permissions**. If the app's security specification calls for it, you can grant admin consent for the organization to access the web API. Authorized users and groups are assigned to the app's registration in **App registrations** > **Enterprise applications**.

In the Entra or Azure portal's **Implicit grant and hybrid flows** app registration configuration, don't select either checkbox for the authorization endpoint to return **Access tokens** or **ID tokens**. The OpenID Connect handler automatically requests the appropriate tokens using the code returned from the authorization endpoint.

Create a client secret in the app's registration in the Entra or Azure portal (**Manage** > **Certificates & secrets** > **New client secret**). Hold on to the client secret **Value** for use the next section.

Additional Entra configuration guidance for specific settings is provided later in this article.

## Establish the client secret

*This section only applies to the server project of the Blazor Web App (`BlazorWebAppOidc` project).*

[!INCLUDE[](~/blazor/security/includes/secure-authentication-flows.md)]

For local development testing, use the [Secret Manager tool](xref:security/app-secrets) to store the Blazor server project's client secret under the configuration key `Authentication:Schemes:MicrosoftOidc:ClientSecret`.

The Blazor server project hasn't been initialized for the Secret Manager tool. Use a command shell, such as the Developer PowerShell command shell in Visual Studio, to execute the following command. Before executing the command, change the directory with the `cd` command to the server project's directory. The command establishes a user secrets identifier (`<UserSecretsId>` in the server app's project file):

```dotnetcli
dotnet user-secrets init
```

Execute the following command to set the client secret. The `{SECRET}` placeholder is the client secret obtained from the app's registration:

```dotnetcli
dotnet user-secrets set "Authentication:Schemes:MicrosoftOidc:ClientSecret" "{SECRET}"
```

If using Visual Studio, you can confirm the secret is set by right-clicking the server project in **Solution Explorer** and selecting **Manage User Secrets**.

## `MinimalApiJwt` project

The `MinimalApiJwt` project is a backend web API for multiple frontend projects. The project configures a [Minimal API](xref:fundamentals/minimal-apis) endpoint for weather data.

The `MinimalApiJwt.http` file can be used for testing the weather data request. Note that the `MinimalApiJwt` project must be running to test the endpoint, and the endpoint is hardcoded into the file. For more information, see <xref:test/http-files>.

The project includes packages and configuration to produce [OpenAPI documents](xref:fundamentals/openapi/overview) and the [Swagger UI](https://swagger.io/api-hub/) in the Development environment. For more information, see <xref:fundamentals/openapi/using-openapi-documents#use-swagger-ui-for-local-ad-hoc-testing>.

The project creates a [Minimal API](xref:fundamentals/minimal-apis) endpoint for weather data:

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

Configure the project in the <xref:Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerOptions> of the <xref:Microsoft.Extensions.DependencyInjection.JwtBearerExtensions.AddJwtBearer%2A> call in the project's `Program` file.

The <xref:Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerOptions.Authority%2A> sets the Authority for making OIDC calls. We recommend using a separate app registration for the `MinimalApiJwt` project. The authority matches the issurer (`iss`) of the JWT returned by the identity provider.

```csharp
jwtOptions.Authority = "{AUTHORITY}";
```

The format of the Authority depends on the type of tenant in use. The following examples for Microsoft Entra ID use a Tenant ID of `aaaabbbb-0000-cccc-1111-dddd2222eeee`.

ME-ID tenant Authority example:

```csharp
jwtOptions.Authority = "https://sts.windows.net/aaaabbbb-0000-cccc-1111-dddd2222eeee/";
```

AAD B2C tenant Authority example:

```csharp
jwtOptions.Authority = "https://login.microsoftonline.com/aaaabbbb-0000-cccc-1111-dddd2222eeee/v2.0/";
```

The <xref:Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerOptions.Audience%2A> sets the Audience for any received OIDC token. 

```csharp
jwtOptions.Audience = "{APP ID URI}";
```

> [!NOTE]
> When using Microsoft Entra ID, match the value to just the path of the **Application ID URI** configured when adding the `Weather.Get` scope under **Expose an API** in the Entra or Azure portal. Don't include the scope name, "`Weather.Get`," in the value.

The format of the Audience depends on the type of tenant in use. The following examples for Microsoft Entra ID use a Tenant ID of `contoso` and a Client ID of `11112222-bbbb-3333-cccc-4444dddd5555`.

ME-ID tenant App ID URI example:

```csharp
jwtOptions.Audience = "api://11112222-bbbb-3333-cccc-4444dddd5555";
```

AAD B2C tenant App ID URI example:

```csharp
jwtOptions.Audience = "https://contoso.onmicrosoft.com/11112222-bbbb-3333-cccc-4444dddd5555";
```

## Blazor Web App server project (`BlazorWebAppOidc`)

The `BlazorWebAppOidc` project is the server-side project of the Blazor Web App.

A <xref:System.Net.Http.DelegatingHandler> (`TokenHandler`) manages attaching a user's access token to outgoing requests. The token handler only executes during static server-side rendering (static SSR), so using <xref:Microsoft.AspNetCore.Http.HttpContext> is safe in this scenario. For more information, see <xref:blazor/components/httpcontext> and <xref:blazor/security/additional-scenarios#use-a-token-handler-for-web-api-calls>.

`TokenHandler.cs`:

```csharp
public class TokenHandler(IHttpContextAccessor httpContextAccessor) : 
    DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var accessToken = httpContextAccessor.HttpContext?
            .GetTokenAsync("access_token").Result ?? 
            throw new Exception("No access token");

        request.Headers.Authorization =
            new AuthenticationHeaderValue("Bearer", accessToken);

        return await base.SendAsync(request, cancellationToken);
    }
}
```

In the project's `Program` file, the token handler (`TokenHandler`) is registered as a service and specified as the message handler with <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.AddHttpMessageHandler%2A> for making secure requests to the backend `MinimalApiJwt` web API using a [named HTTP client](xref:blazor/call-web-api#named-httpclient-with-ihttpclientfactory) ("`ExternalApi`").

```csharp
builder.Services.AddScoped<TokenHandler>();

builder.Services.AddHttpClient("ExternalApi",
      client => client.BaseAddress = new Uri(builder.Configuration["ExternalApiUri"] ?? 
          throw new Exception("Missing base address!")))
      .AddHttpMessageHandler<TokenHandler>();
```

In the project's `appsettings.json` file, configure the external API URI:

```json
"ExternalApiUri": "{BASE ADDRESS}"
```

Example:

```json
"ExternalApiUri": "https://localhost:7277"
```

The following <xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions> configuration is found in the project's `Program` file on the call to <xref:Microsoft.Extensions.DependencyInjection.OpenIdConnectExtensions.AddOpenIdConnect%2A>:

:::moniker range=">= aspnetcore-9.0"

<xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.PushedAuthorizationBehavior%2A>: Controls [Pushed Authorization Requests (PAR) support](xref:aspnetcore-9#openidconnecthandler-adds-support-for-pushed-authorization-requests-par). By default, the setting is to use PAR if the identity provider's discovery document (usually found at `.well-known/openid-configuration`) advertises support for PAR. If you wish to require PAR support for the app, you can assign a value of [`PushedAuthorizationBehavior.Require`](xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.PushedAuthorizationBehavior). PAR isn't supported by Microsoft Entra, and there are no plans for Entra to ever support it in the future.

```csharp
oidcOptions.PushedAuthorizationBehavior = PushedAuthorizationBehavior.UseIfAvailable;
```

:::moniker-end

<xref:Microsoft.AspNetCore.Builder.RemoteAuthenticationOptions.SignInScheme%2A>: Sets the authentication scheme corresponding to the middleware responsible of persisting user's identity after a successful authentication. The OIDC handler needs to use a sign-in scheme that's capable of persisting user credentials across requests. The following line is present merely for demonstration purposes. If omitted, <xref:Microsoft.AspNetCore.Authentication.AuthenticationOptions.DefaultSignInScheme%2A> is used as a fallback value.

```csharp
oidcOptions.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
```

Scopes for `openid` and `profile` (<xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.Scope%2A>) (Optional): The `openid` and `profile` scopes are also configured by default because they're required for the OIDC handler to work, but these may need to be re-added if scopes are included in the `Authentication:Schemes:MicrosoftOidc:Scope` configuration. For general configuration guidance, see <xref:fundamentals/configuration/index> and <xref:blazor/fundamentals/configuration>.

```csharp
oidcOptions.Scope.Add(OpenIdConnectScope.OpenIdProfile);
```

<xref:Microsoft.AspNetCore.Authentication.RemoteAuthenticationOptions.SaveTokens%2A>: Defines whether access and refresh tokens should be stored in the <xref:Microsoft.AspNetCore.Authentication.AuthenticationProperties> after a successful authorization. This property is set to `true` so the refresh token gets stored for non-interactive token refresh.

```csharp
oidcOptions.SaveTokens = true;
```

Scope for offline access (<xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.Scope%2A>): The `offline_access` scope is required for the refresh token.

```csharp
oidcOptions.Scope.Add(OpenIdConnectScope.OfflineAccess);
```

<xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.Authority%2A> and <xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.ClientId%2A>: Sets the Authority and Client ID for OIDC calls.

```csharp
oidcOptions.Authority = "{AUTHORITY}";
oidcOptions.ClientId = "{CLIENT ID}";
```

The following example uses a Tenant ID of `aaaabbbb-0000-cccc-1111-dddd2222eeee` and a Client ID of `00001111-aaaa-2222-bbbb-3333cccc4444`:

```csharp
oidcOptions.Authority = "https://login.microsoftonline.com/aaaabbbb-0000-cccc-1111-dddd2222eeee/v2.0/";
oidcOptions.ClientId = "00001111-aaaa-2222-bbbb-3333cccc4444";
```

For multi-tenant apps, the "common" authority should be used. You can also use the "common" authority for single-tenant apps, but a custom <xref:Microsoft.IdentityModel.Tokens.TokenValidationParameters.IssuerValidator%2A> is required, as shown later in this section.

```csharp
oidcOptions.Authority = "https://login.microsoftonline.com/common/v2.0/";
```

<xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.ResponseType%2A>: Configures the OIDC handler to only perform authorization code flow. Implicit grants and hybrid flows are unnecessary in this mode. The OIDC handler automatically requests the appropriate tokens using the code returned from the authorization endpoint.

```csharp
oidcOptions.ResponseType = OpenIdConnectResponseType.Code;
```

<xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.MapInboundClaims%2A> and configuration of <xref:Microsoft.IdentityModel.Tokens.TokenValidationParameters.NameClaimType%2A> and <xref:Microsoft.IdentityModel.Tokens.TokenValidationParameters.RoleClaimType%2A>: Many OIDC servers use "`name`" and "`role`" rather than the SOAP/WS-Fed defaults in <xref:System.Security.Claims.ClaimTypes>. When <xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.MapInboundClaims%2A> is set to `false`, the handler doesn't perform claims mappings, and the claim names from the JWT are used directly by the app. The following example sets the role claim type to "`roles`," which is appropriate for [Microsoft Entra ID (ME-ID)](https://www.microsoft.com/security/business/microsoft-entra). Consult your identity provider's documentation for more information.

> [!NOTE]
> <xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.MapInboundClaims%2A> must be set to `false` for most OIDC providers, which prevents renaming claims.

```csharp
oidcOptions.MapInboundClaims = false;
oidcOptions.TokenValidationParameters.NameClaimType = "name";
oidcOptions.TokenValidationParameters.RoleClaimType = "roles";
```

Path configuration: Paths must match the redirect URI (login callback path) and post logout redirect (signed-out callback path) paths configured when registering the application with the OIDC provider. In the Azure portal, paths are configured in the **Authentication** blade of the app's registration. Both the sign-in and sign-out paths must be registered as redirect URIs. The default values are `/signin-oidc` and `/signout-callback-oidc`.

<xref:Microsoft.AspNetCore.Builder.RemoteAuthenticationOptions.CallbackPath>: The request path within the app's base path where the user-agent is returned.

Configure the signed-out callback path in the app's OIDC provider registration. In the following example, the `{PORT}` placeholder is the app's port:

> :::no-loc text="https://localhost:{PORT}/signin-oidc":::

> [!NOTE]
> A port isn't required for `localhost` addresses when using Microsoft Entra ID. Most other OIDC providers require the correct port.

<xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.SignedOutCallbackPath%2A> (configuration key: "`SignedOutCallbackPath`"): The request path within the app's base path intercepted by the OIDC handler where the user agent is first returned after signing out from the identity provider. The sample app doesn't set a value for the path because the default value of "`/signout-callback-oidc`" is used. After intercepting the request, the OIDC handler redirects to the <xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.SignedOutRedirectUri%2A> or <xref:Microsoft.AspNetCore.Authentication.AuthenticationProperties.RedirectUri%2A>, if specified.

Configure the signed-out callback path in the app's OIDC provider registration. In the following example, the `{PORT}` placeholder is the app's port:

> :::no-loc text="https://localhost:{PORT}/signout-callback-oidc":::

> [!NOTE]
> When using Microsoft Entra ID, set the path in the **Web** platform configuration's **Redirect URI** entries in the Entra or Azure portal. A port isn't required for `localhost` addresses when using Entra. Most other OIDC providers require the correct port. If you don't add the signed-out callback path URI to the app's registration in Entra, Entra refuses to redirect the user back to the app and merely asks them to close their browser window.

<xref:Microsoft.AspNetCore.Builder.OpenIdConnectOptions.RemoteSignOutPath%2A>: Requests received on this path cause the handler to invoke sign-out using the sign-out scheme.

In the following example, the `{PORT}` placeholder is the app's port:

> :::no-loc text="https://localhost/signout-oidc":::

> [!NOTE]
> When using Microsoft Entra ID, set the **Front-channel logout URL** in the Entra or Azure portal. A port isn't required for `localhost` addresses when using Entra. Most other OIDC providers require the correct port.

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

(*Microsoft Azure only with the "common" endpoint*) <xref:Microsoft.IdentityModel.Tokens.TokenValidationParameters.IssuerValidator%2A?displayProperty=nameWithType>: Many OIDC providers work with the default issuer validator, but we need to account for the issuer parameterized with the Tenant ID (`{TENANT ID}`) returned by `https://login.microsoftonline.com/common/v2.0/.well-known/openid-configuration`. For more information, see [SecurityTokenInvalidIssuerException with OpenID Connect and the Azure AD "common" endpoint (`AzureAD/azure-activedirectory-identitymodel-extensions-for-dotnet` #1731)](https://github.com/AzureAD/azure-activedirectory-identitymodel-extensions-for-dotnet/issues/1731).

Only for apps using Microsoft Entra ID or Azure AD B2C with the "common" endpoint:

```csharp
var microsoftIssuerValidator = AadIssuerValidator.GetAadIssuerValidator(oidcOptions.Authority);
oidcOptions.TokenValidationParameters.IssuerValidator = microsoftIssuerValidator.Validate;
```

## Blazor Web App client project (`BlazorWebAppOidc.Client`)

The `BlazorWebAppOidc.Client` project is the client-side project of the Blazor Web App.

:::moniker range=">= aspnetcore-9.0"

The client calls <xref:Microsoft.Extensions.DependencyInjection.WebAssemblyAuthenticationServiceCollectionExtensions.AddAuthenticationStateDeserialization%2A> to deserialize and use the authentication state passed by the server. The authentication state is fixed for the lifetime of the WebAssembly application.

:::moniker-end

:::moniker range="< aspnetcore-9.0"

The `PersistentAuthenticationStateProvider` class (`PersistentAuthenticationStateProvider.cs`) is a client-side <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> that determines the user's authentication state by looking for data persisted in the page when it was rendered on the server. The authentication state is fixed for the lifetime of the WebAssembly application.

:::moniker-end

If the user needs to log in or out, a full page reload is required.

The sample app only provides a user name and email for display purposes.

:::zone-end

:::zone pivot="non-bff-pattern-server"

This version of the article covers implementing OIDC without adopting the [Backend for Frontend (BFF) pattern](/azure/architecture/patterns/backends-for-frontends) with an app that adopts global Interactive Server rendering (single project). The BFF pattern is useful for making authenticated requests to external services. Change the article version selector to **BFF pattern** if the app's specification calls for adopting the BFF pattern with global Interactive Auto rendering.

The following specification is adopted:

* The Blazor Web App uses [the Server render mode with global interactivity](xref:blazor/components/render-modes).
* This app is a starting point for any OIDC authentication flow. OIDC is configured manually in the app and doesn't rely upon [Microsoft Entra ID](https://www.microsoft.com/security/business/microsoft-entra) or [Microsoft Identity Web](/entra/msal/dotnet/microsoft-identity-web/) packages, nor does the sample app require [Microsoft Azure](https://azure.microsoft.com/) hosting. However, the sample app can be used with Entra, Microsoft Identity Web, and hosted in Azure.
* Automatic non-interactive token refresh.
* A separate web API project demonstrates a secure web API call for weather data.

For an alternative experience using [Microsoft Authentication Library for .NET](/entra/msal/dotnet/), [Microsoft Identity Web](/entra/msal/dotnet/microsoft-identity-web/), and [Microsoft Entra ID](https://www.microsoft.com/security/business/identity-access/microsoft-entra-id), see <xref:blazor/security/blazor-web-app-entra>.

## Sample solution

The sample app consists of the following projects:

* `BlazorWebAppOidcServer`: Blazor Web App server-side project (global Interactive Server rendering).
* `MinimalApiJwt`: Backend web API with a [Minimal API](xref:fundamentals/minimal-apis) endpoint for weather data.

Access the sample through the latest version folder in the Blazor samples repository with the following link. The sample is in the `BlazorWebAppOidcServer` folder for .NET 8 or later.

[View or download sample code](https://github.com/dotnet/blazor-samples) ([how to download](xref:blazor/fundamentals/index#sample-apps))

## Microsoft Entra ID app registrations

We recommend using separate registrations for apps and web APIs, even when the apps and web APIs are in the same solution. The following guidance is for the `BlazorWebAppOidcServer` app and `MinimalApiJwt` web API of the sample solution, but the same guidance applies generally to any Entra-based registrations for apps and web APIs.

Register the web API (`MinimalApiJwt`) first so that you can then grant access to the web API when registering the app. The web API's tenant ID and client ID are used to configure the web API in its `Program` file. After registering the web API, expose the web API in **App registrations** > **Expose an API** with a scope name of `Weather.Get`. Record the App ID URI for use in the app's configuration.

Next, register the app (`BlazorWebAppOidcServer`) with a **Web** platform configuration and a **Redirect URI** of `https://localhost/signin-oidc` (a port isn't required). The app's tenant ID and client ID, along with the web API's base address, App ID URI, and weather scope name, are used to configure the app in its `Program` file. Grant API permission to access the web API in **App registrations** > **API permissions**. If the app's security specification calls for it, you can grant admin consent for the organization to access the web API. Authorized users and groups are assigned to the app's registration in **App registrations** > **Enterprise applications**.

In the Entra or Azure portal's **Implicit grant and hybrid flows** app registration configuration, don't select either checkbox for the authorization endpoint to return **Access tokens** or **ID tokens**. The OpenID Connect handler automatically requests the appropriate tokens using the code returned from the authorization endpoint.

Create a client secret in the app's registration in the Entra or Azure portal (**Manage** > **Certificates & secrets** > **New client secret**). Hold on to the client secret **Value** for use the next section.

Additional Entra configuration guidance for specific settings is provided later in this article.

## Establish the client secret

*This section only applies to the server project of the Blazor Web App (`BlazorWebAppOidcServer` project).*

[!INCLUDE[](~/blazor/security/includes/secure-authentication-flows.md)]

For local development testing, use the [Secret Manager tool](xref:security/app-secrets) to store the Blazor server project's client secret under the configuration key `Authentication:Schemes:MicrosoftOidc:ClientSecret`.

The Blazor server project hasn't been initialized for the Secret Manager tool. Use a command shell, such as the Developer PowerShell command shell in Visual Studio, to execute the following command. Before executing the command, change the directory with the `cd` command to the server project's directory. The command establishes a user secrets identifier (`<UserSecretsId>` in the app's project file):

```dotnetcli
dotnet user-secrets init
```

Execute the following command to set the client secret. The `{SECRET}` placeholder is the client secret obtained from the app's registration:

```dotnetcli
dotnet user-secrets set "Authentication:Schemes:MicrosoftOidc:ClientSecret" "{SECRET}"
```

If using Visual Studio, you can confirm the secret is set by right-clicking the project in **Solution Explorer** and selecting **Manage User Secrets**.

## `MinimalApiJwt` project

The `MinimalApiJwt` project is a backend web API for multiple frontend projects. The project configures a [Minimal API](xref:fundamentals/minimal-apis) endpoint for weather data.

The `MinimalApiJwt.http` file can be used for testing the weather data request. Note that the `MinimalApiJwt` project must be running to test the endpoint, and the endpoint is hardcoded into the file. For more information, see <xref:test/http-files>.

The project includes packages and configuration to produce [OpenAPI documents](xref:fundamentals/openapi/overview) and the [Swagger UI](https://swagger.io/api-hub/) in the Development environment. For more information, see <xref:fundamentals/openapi/using-openapi-documents#use-swagger-ui-for-local-ad-hoc-testing>.

The project creates a [Minimal API](xref:fundamentals/minimal-apis) endpoint for weather data:

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

Configure the project in the <xref:Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerOptions> of the <xref:Microsoft.Extensions.DependencyInjection.JwtBearerExtensions.AddJwtBearer%2A> call in the project's `Program` file.

The <xref:Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerOptions.Authority%2A> sets the Authority for making OIDC calls. We recommend using a separate app registration for the `MinimalApiJwt` project. The authority matches the issurer (`iss`) of the JWT returned by the identity provider.

```csharp
jwtOptions.Authority = "{AUTHORITY}";
```

The format of the Authority depends on the type of tenant in use. The following examples for Microsoft Entra ID use a Tenant ID of `aaaabbbb-0000-cccc-1111-dddd2222eeee`.

ME-ID tenant Authority example:

```csharp
jwtOptions.Authority = "https://sts.windows.net/aaaabbbb-0000-cccc-1111-dddd2222eeee/";
```

AAD B2C tenant Authority example:

```csharp
jwtOptions.Authority = "https://login.microsoftonline.com/aaaabbbb-0000-cccc-1111-dddd2222eeee/v2.0/";
```

The <xref:Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerOptions.Audience%2A> sets the Audience for any received OIDC token. 

```csharp
jwtOptions.Audience = "{APP ID URI}";
```

> [!NOTE]
> When using Microsoft Entra ID, match the value to just the path of the **Application ID URI** configured when adding the `Weather.Get` scope under **Expose an API** in the Entra or Azure portal. Don't include the scope name, "`Weather.Get`," in the value.

The format of the Audience depends on the type of tenant in use. The following examples for Microsoft Entra ID use a Tenant ID of `contoso` and a Client ID of `11112222-bbbb-3333-cccc-4444dddd5555`.

ME-ID tenant App ID URI example:

```csharp
jwtOptions.Audience = "api://11112222-bbbb-3333-cccc-4444dddd5555";
```

AAD B2C tenant App ID URI example:

```csharp
jwtOptions.Audience = "https://contoso.onmicrosoft.com/11112222-bbbb-3333-cccc-4444dddd5555";
```

## `BlazorWebAppOidcServer` project

Automatic non-interactive token refresh is managed by a custom cookie refresher (`CookieOidcRefresher.cs`).

A <xref:System.Net.Http.DelegatingHandler> (`TokenHandler`) manages attaching a user's access token to outgoing requests. The token handler only executes during static server-side rendering (static SSR), so using <xref:Microsoft.AspNetCore.Http.HttpContext> is safe in this scenario. For more information, see <xref:blazor/components/httpcontext> and <xref:blazor/security/additional-scenarios#use-a-token-handler-for-web-api-calls>.

`TokenHandler.cs`:

```csharp
public class TokenHandler(IHttpContextAccessor httpContextAccessor) : 
    DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var accessToken = httpContextAccessor.HttpContext?
            .GetTokenAsync("access_token").Result ?? 
            throw new Exception("No access token");

        request.Headers.Authorization =
            new AuthenticationHeaderValue("Bearer", accessToken);

        return await base.SendAsync(request, cancellationToken);
    }
}
```

In the project's `Program` file, the token handler (`TokenHandler`) is registered as a service and specified as the message handler with <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.AddHttpMessageHandler%2A> for making secure requests to the backend `MinimalApiJwt` web API using a [named HTTP client](xref:blazor/call-web-api#named-httpclient-with-ihttpclientfactory) ("`ExternalApi`").

```csharp
builder.Services.AddScoped<TokenHandler>();

builder.Services.AddHttpClient("ExternalApi",
      client => client.BaseAddress = new Uri(builder.Configuration["ExternalApiUri"] ?? 
          throw new Exception("Missing base address!")))
      .AddHttpMessageHandler<TokenHandler>();
```

The `Weather` component uses the [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) to prevent unauthorized access. For more information on requiring authorization across the app via an [authorization policy](xref:security/authorization/policies) and opting out of authorization at a subset of public endpoints, see the [Razor Pages OIDC guidance](xref:security/authentication/configure-oidc-web-authentication#force-authorization).

The `ExternalApi` HTTP client is used to make a request for weather data to the secure web API. In the [`OnInitializedAsync` lifecycle event](xref:blazor/components/lifecycle#component-initialization-oninitializedasync) of `Weather.razor`:

```csharp
var request = new HttpRequestMessage(HttpMethod.Get, "/weather-forecast");
var client = ClientFactory.CreateClient("ExternalApi");

var response = await client.SendAsync(request);

response.EnsureSuccessStatusCode();

forecasts = await response.Content.ReadFromJsonAsync<WeatherForecast[]>() ??
    throw new IOException("No weather forecast!");
```

In the project's `appsettings.json` file, configure the external API URI:

```json
"ExternalApiUri": "{BASE ADDRESS}"
```

Example:

```json
"ExternalApiUri": "https://localhost:7277"
```

The following <xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions> configuration is found in the project's `Program` file on the call to <xref:Microsoft.Extensions.DependencyInjection.OpenIdConnectExtensions.AddOpenIdConnect%2A>:

:::moniker range=">= aspnetcore-9.0"

<xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.PushedAuthorizationBehavior%2A>: Controls [Pushed Authorization Requests (PAR) support](xref:aspnetcore-9#openidconnecthandler-adds-support-for-pushed-authorization-requests-par). By default, the setting is to use PAR if the identity provider's discovery document (usually found at `.well-known/openid-configuration`) advertises support for PAR. If you wish to require PAR support for the app, you can assign a value of [`PushedAuthorizationBehavior.Require`](xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.PushedAuthorizationBehavior). PAR isn't supported by Microsoft Entra, and there are no plans for Entra to ever support it in the future.

```csharp
oidcOptions.PushedAuthorizationBehavior = PushedAuthorizationBehavior.UseIfAvailable;
```

:::moniker-end

<xref:Microsoft.AspNetCore.Builder.RemoteAuthenticationOptions.SignInScheme%2A>: Sets the authentication scheme corresponding to the middleware responsible of persisting user's identity after a successful authentication. The OIDC handler needs to use a sign-in scheme that's capable of persisting user credentials across requests. The following line is present merely for demonstration purposes. If omitted, <xref:Microsoft.AspNetCore.Authentication.AuthenticationOptions.DefaultSignInScheme%2A> is used as a fallback value.

```csharp
oidcOptions.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
```

Scopes for `openid` and `profile` (<xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.Scope%2A>) (Optional): The `openid` and `profile` scopes are also configured by default because they're required for the OIDC handler to work, but these may need to be re-added if scopes are included in the `Authentication:Schemes:MicrosoftOidc:Scope` configuration. For general configuration guidance, see <xref:fundamentals/configuration/index> and <xref:blazor/fundamentals/configuration>.

```csharp
oidcOptions.Scope.Add(OpenIdConnectScope.OpenIdProfile);
```

Configure the `Weather.Get` scope for accessing the external web API for weather data. The following example is based on using Entra ID in an ME-ID tenant domain. In the following example, the `{APP ID URI}` placeholder is found in the Entra or Azure portal where the web API is exposed. For any other identity provider, use the appropriate scope.

```csharp
oidcOptions.Scope.Add("{APP ID URI}/Weather.Get");
```

The format of the scope depends on the type of tenant in use. In the following examples, the Tenant Domain is `contoso.onmicrosoft.com`, and the Client ID is `11112222-bbbb-3333-cccc-4444dddd5555`.

ME-ID tenant App ID URI example:

```csharp
oidcOptions.Scope.Add("api://11112222-bbbb-3333-cccc-4444dddd5555/Weather.Get");
```

AAD B2C tenant App ID URI example:

```csharp
oidcOptions.Scope.Add("https://contoso.onmicrosoft.com/11112222-bbbb-3333-cccc-4444dddd5555/Weather.Get");
```

<xref:Microsoft.AspNetCore.Authentication.RemoteAuthenticationOptions.SaveTokens%2A>: Defines whether access and refresh tokens should be stored in the <xref:Microsoft.AspNetCore.Authentication.AuthenticationProperties> after a successful authorization. This property is set to `true` so the refresh token gets stored for non-interactive token refresh.

```csharp
oidcOptions.SaveTokens = true;
```

Scope for offline access (<xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.Scope%2A>): The `offline_access` scope is required for the refresh token.

```csharp
oidcOptions.Scope.Add(OpenIdConnectScope.OfflineAccess);
```

<xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.Authority%2A> and <xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.ClientId%2A>: Sets the Authority and Client ID for OIDC calls.

```csharp
oidcOptions.Authority = "{AUTHORITY}";
oidcOptions.ClientId = "{CLIENT ID}";
```

The following example uses a Tenant ID of `aaaabbbb-0000-cccc-1111-dddd2222eeee` and a Client ID of `00001111-aaaa-2222-bbbb-3333cccc4444`:

```csharp
oidcOptions.Authority = "https://login.microsoftonline.com/aaaabbbb-0000-cccc-1111-dddd2222eeee/v2.0/";
oidcOptions.ClientId = "00001111-aaaa-2222-bbbb-3333cccc4444";
```

For multi-tenant apps, the "common" authority should be used. You can also use the "common" authority for single-tenant apps, but a custom <xref:Microsoft.IdentityModel.Tokens.TokenValidationParameters.IssuerValidator%2A> is required, as shown later in this section.

```csharp
oidcOptions.Authority = "https://login.microsoftonline.com/common/v2.0/";
```

<xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.ResponseType%2A>: Configures the OIDC handler to only perform authorization code flow. Implicit grants and hybrid flows are unnecessary in this mode. The OIDC handler automatically requests the appropriate tokens using the code returned from the authorization endpoint.

```csharp
oidcOptions.ResponseType = OpenIdConnectResponseType.Code;
```

<xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.MapInboundClaims%2A> and configuration of <xref:Microsoft.IdentityModel.Tokens.TokenValidationParameters.NameClaimType%2A> and <xref:Microsoft.IdentityModel.Tokens.TokenValidationParameters.RoleClaimType%2A>: Many OIDC servers use "`name`" and "`role`" rather than the SOAP/WS-Fed defaults in <xref:System.Security.Claims.ClaimTypes>. When <xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.MapInboundClaims%2A> is set to `false`, the handler doesn't perform claims mappings, and the claim names from the JWT are used directly by the app. The following example sets the role claim type to "`roles`," which is appropriate for [Microsoft Entra ID (ME-ID)](https://www.microsoft.com/security/business/microsoft-entra). Consult your identity provider's documentation for more information.

> [!NOTE]
> <xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.MapInboundClaims%2A> must be set to `false` for most OIDC providers, which prevents renaming claims.

```csharp
oidcOptions.MapInboundClaims = false;
oidcOptions.TokenValidationParameters.NameClaimType = "name";
oidcOptions.TokenValidationParameters.RoleClaimType = "roles";
```

Path configuration: Paths must match the redirect URI (login callback path) and post logout redirect (signed-out callback path) paths configured when registering the application with the OIDC provider. In the Azure portal, paths are configured in the **Authentication** blade of the app's registration. Both the sign-in and sign-out paths must be registered as redirect URIs. The default values are `/signin-oidc` and `/signout-callback-oidc`.

<xref:Microsoft.AspNetCore.Builder.RemoteAuthenticationOptions.CallbackPath>: The request path within the app's base path where the user-agent is returned.

Configure the signed-out callback path in the app's OIDC provider registration. In the following example, the `{PORT}` placeholder is the app's port:

> :::no-loc text="https://localhost:{PORT}/signin-oidc":::

> [!NOTE]
> A port isn't required for `localhost` addresses when using Microsoft Entra ID. Most other OIDC providers require the correct port.

<xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.SignedOutCallbackPath%2A> (configuration key: "`SignedOutCallbackPath`"): The request path within the app's base path intercepted by the OIDC handler where the user agent is first returned after signing out from the identity provider. The sample app doesn't set a value for the path because the default value of "`/signout-callback-oidc`" is used. After intercepting the request, the OIDC handler redirects to the <xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.SignedOutRedirectUri%2A> or <xref:Microsoft.AspNetCore.Authentication.AuthenticationProperties.RedirectUri%2A>, if specified.

Configure the signed-out callback path in the app's OIDC provider registration. In the following example, the `{PORT}` placeholder is the app's port:

> :::no-loc text="https://localhost:{PORT}/signout-callback-oidc":::

> [!NOTE]
> When using Microsoft Entra ID, set the path in the **Web** platform configuration's **Redirect URI** entries in the Entra or Azure portal. A port isn't required for `localhost` addresses when using Entra. Most other OIDC providers require the correct port. If you don't add the signed-out callback path URI to the app's registration in Entra, Entra refuses to redirect the user back to the app and merely asks them to close their browser window.
  
<xref:Microsoft.AspNetCore.Builder.OpenIdConnectOptions.RemoteSignOutPath%2A>: Requests received on this path cause the handler to invoke sign-out using the sign-out scheme.

In the following example, the `{PORT}` placeholder is the app's port:

> :::no-loc text="https://localhost/signout-oidc":::

> [!NOTE]
> When using Microsoft Entra ID, set the **Front-channel logout URL** in the Entra or Azure portal. A port isn't required for `localhost` addresses when using Entra. Most other OIDC providers require the correct port.

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

(*Microsoft Azure only with the "common" endpoint*) <xref:Microsoft.IdentityModel.Tokens.TokenValidationParameters.IssuerValidator%2A?displayProperty=nameWithType>: Many OIDC providers work with the default issuer validator, but we need to account for the issuer parameterized with the Tenant ID (`{TENANT ID}`) returned by `https://login.microsoftonline.com/common/v2.0/.well-known/openid-configuration`. For more information, see [SecurityTokenInvalidIssuerException with OpenID Connect and the Azure AD "common" endpoint (`AzureAD/azure-activedirectory-identitymodel-extensions-for-dotnet` #1731)](https://github.com/AzureAD/azure-activedirectory-identitymodel-extensions-for-dotnet/issues/1731).

Only for apps using Microsoft Entra ID or Azure AD B2C with the "common" endpoint:

```csharp
var microsoftIssuerValidator = AadIssuerValidator.GetAadIssuerValidator(oidcOptions.Authority);
oidcOptions.TokenValidationParameters.IssuerValidator = microsoftIssuerValidator.Validate;
```

:::zone-end

:::zone pivot="bff-pattern"

This version of the article covers implementing OIDC with the [Backend for Frontend (BFF) pattern](/azure/architecture/patterns/backends-for-frontends). If the app's specification doesn't call for adopting the BFF pattern, change the article version selector to **Non-BFF pattern (Interactive Auto)** (Interactive Auto rendering) or **Non-BFF pattern (Interactive Server)** (Interactive Server rendering).

## Prerequisites

[.NET Aspire](/dotnet/aspire/get-started/aspire-overview) requires [Visual Studio](https://visualstudio.microsoft.com/) version 17.10 or later.

Also, see the *Prerequisites* section of [Quickstart: Build your first .NET Aspire app](/dotnet/aspire/get-started/build-your-first-aspire-app?tabs=visual-studio#prerequisites).

## Sample solution

The sample app consists of the following projects:

* .NET Aspire:
  * `Aspire.AppHost`: Used to manage the high-level orchestration concerns of the app.
  * `Aspire.ServiceDefaults`: Contains default .NET Aspire app configurations that can be extended and customized as needed.
* `MinimalApiJwt`: Backend web API, containing an example [Minimal API](xref:fundamentals/minimal-apis) endpoint for weather data.
* `BlazorWebAppOidc`: Server-side project of the Blazor Web App. The project uses [YARP](https://dotnet.github.io/yarp/) to proxy requests to a weather forecast endpoint in the backend web API project (`MinimalApiJwt`) with the `access_token` stored in the authentication cookie.
* `BlazorWebAppOidc.Client`: Client-side project of the Blazor Web App.

Access the sample through the latest version folder in the Blazor samples repository with the following link. The sample is in the `BlazorWebAppOidcBff` folder for .NET 8 or later.

[View or download sample code](https://github.com/dotnet/blazor-samples) ([how to download](xref:blazor/fundamentals/index#sample-apps))

The Blazor Web App uses [the Auto render mode with global interactivity](xref:blazor/components/render-modes).

:::moniker range=">= aspnetcore-9.0"

The server project calls <xref:Microsoft.Extensions.DependencyInjection.WebAssemblyRazorComponentsBuilderExtensions.AddAuthenticationStateSerialization%2A> to add a server-side authentication state provider that uses <xref:Microsoft.AspNetCore.Components.PersistentComponentState> to flow the authentication state to the client. The client calls <xref:Microsoft.Extensions.DependencyInjection.WebAssemblyAuthenticationServiceCollectionExtensions.AddAuthenticationStateDeserialization%2A> to deserialize and use the authentication state passed by the server. The authentication state is fixed for the lifetime of the WebAssembly application.

:::moniker-end

:::moniker range="< aspnetcore-9.0"

The `PersistingAuthenticationStateProvider` class (`PersistingAuthenticationStateProvider.cs`) is a server-side <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> that uses <xref:Microsoft.AspNetCore.Components.PersistentComponentState> to flow the authentication state to the client, which is then fixed for the lifetime of the WebAssembly application.

:::moniker-end

This app is a starting point for any OIDC authentication flow. OIDC is configured manually in the app and doesn't rely upon [Microsoft Entra ID](https://www.microsoft.com/security/business/microsoft-entra) or [Microsoft Identity Web](/entra/msal/dotnet/microsoft-identity-web/) packages, nor does the sample app require [Microsoft Azure](https://azure.microsoft.com/) hosting. However, the sample app can be used with Entra, Microsoft Identity Web, and hosted in Azure.

Automatic non-interactive token refresh with the help of a custom cookie refresher (`CookieOidcRefresher.cs`).

The [Backend for Frontend (BFF) pattern](/azure/architecture/patterns/backends-for-frontends) is adopted using [.NET Aspire](/dotnet/aspire/get-started/aspire-overview) for service discovery and [YARP](https://dotnet.github.io/yarp/) for proxying requests to a weather forecast endpoint on the backend app.

The backend web API (`MinimalApiJwt`) uses JWT-bearer authentication to validate JWT tokens saved by the Blazor Web App in the sign-in cookie.

Aspire improves the experience of building .NET cloud-native apps. It provides a consistent, opinionated set of tools and patterns for building and running distributed apps.

YARP (Yet Another Reverse Proxy) is a library used to create a reverse proxy server. `MapForwarder` in the `Program` file of the server project adds direct forwarding of HTTP requests that match the specified pattern to a specific destination using default configuration for the outgoing request, customized transforms, and default HTTP client:

* When rendering the `Weather` component on the server, the component uses the `ServerWeatherForecaster` class to proxy the request for weather data with the user's access token. <xref:Microsoft.AspNetCore.Http.IHttpContextAccessor.HttpContext?displayProperty=nameWithType> determines if an <xref:Microsoft.AspNetCore.Http.HttpContext> is available for use by the `GetWeatherForecastAsync` method. For more information, see <xref:blazor/components/index#ihttpcontextaccessorhttpcontext>.
* When the component is rendered on the client, the component uses the `ClientWeatherForecaster` service implementation, which uses a preconfigured <xref:System.Net.Http.HttpClient> (in the client project's `Program` file) to make a web API call to the server project. A Minimal API endpoint (`/weather-forecast`) defined in the server project's `Program` file transforms the request with the user's access token to obtain the weather data.

<!-- UPDATE 10.0 Remove at 10.0 -->

For more information on .NET Aspire, see [General Availability of .NET Aspire: Simplifying .NET Cloud-Native Development (May, 2024)](https://devblogs.microsoft.com/dotnet/dotnet-aspire-general-availability/).

For more information on (web) API calls using a service abstractions in Blazor Web Apps, see <xref:blazor/call-web-api#service-abstractions-for-web-api-calls>.

## Microsoft Entra ID app registrations

We recommend using separate registrations for apps and web APIs, even when the apps and web APIs are in the same solution. The following guidance is for the `BlazorWebAppOidc` app and `MinimalApiJwt` web API of the sample solution, but the same guidance applies generally to any Entra-based registrations for apps and web APIs.

Register the web API (`MinimalApiJwt`) first so that you can then grant access to the web API when registering the app. The web API's tenant ID and client ID are used to configure the web API in its `Program` file. After registering the web API, expose the web API in **App registrations** > **Expose an API** with a scope name of `Weather.Get`. Record the App ID URI for use in the app's configuration.

Next, register the app (`BlazorWebAppOidc`/`BlazorWebApOidc.Client`) with a **Web** platform configuration and a **Redirect URI** of `https://localhost/signin-oidc` (a port isn't required). The app's tenant ID and client ID, along with the web API's base address, App ID URI, and weather scope name, are used to configure the app in its `Program` file. Grant API permission to access the web API in **App registrations** > **API permissions**. If the app's security specification calls for it, you can grant admin consent for the organization to access the web API. Authorized users and groups are assigned to the app's registration in **App registrations** > **Enterprise applications**.

In the Entra or Azure portal's **Implicit grant and hybrid flows** app registration configuration, don't select either checkbox for the authorization endpoint to return **Access tokens** or **ID tokens**. The OpenID Connect handler automatically requests the appropriate tokens using the code returned from the authorization endpoint.

Create a client secret in the app's registration in the Entra or Azure portal (**Manage** > **Certificates & secrets** > **New client secret**). Hold on to the client secret **Value** for use the next section.

Additional Entra configuration guidance for specific settings is provided later in this article.

## Establish the client secret

*This section only applies to the server project of the Blazor Web App (`BlazorWebAppOidc` project).*

[!INCLUDE[](~/blazor/security/includes/secure-authentication-flows.md)]

For local development testing, use the [Secret Manager tool](xref:security/app-secrets) to store the Blazor server project's client secret under the configuration key `Authentication:Schemes:MicrosoftOidc:ClientSecret`.

The Blazor server project hasn't been initialized for the Secret Manager tool. Use a command shell, such as the Developer PowerShell command shell in Visual Studio, to execute the following command. Before executing the command, change the directory with the `cd` command to the server project's directory. The command establishes a user secrets identifier (`<UserSecretsId>` in the server app's project file):

```dotnetcli
dotnet user-secrets init
```

Execute the following command to set the client secret. The `{SECRET}` placeholder is the client secret obtained from the app's registration:

```dotnetcli
dotnet user-secrets set "Authentication:Schemes:MicrosoftOidc:ClientSecret" "{SECRET}"
```

If using Visual Studio, you can confirm the secret is set by right-clicking the server project in **Solution Explorer** and selecting **Manage User Secrets**.

## .NET Aspire projects

For more information on using .NET Aspire and details on the `.AppHost` and `.ServiceDefaults` projects of the sample app, see the [.NET Aspire documentation](/dotnet/aspire/).

Confirm that you've met the prerequisites for .NET Aspire. For more information, see the *Prerequisites* section of [Quickstart: Build your first .NET Aspire app](/dotnet/aspire/get-started/build-your-first-aspire-app?tabs=visual-studio#prerequisites).

The sample app only configures an insecure HTTP launch profile (`http`) for use during development testing. For more information, including an example of insecure and secure launch settings profiles, see [Allow unsecure transport in .NET Aspire (.NET Aspire documentation)](/dotnet/aspire/troubleshooting/allow-unsecure-transport).

## `MinimalApiJwt` project

The `MinimalApiJwt` project is a backend web API for multiple frontend projects. The project configures a [Minimal API](xref:fundamentals/minimal-apis) endpoint for weather data. Requests from the Blazor Web App server-side project (`BlazorWebAppOidc`) are proxied to the `MinimalApiJwt` project.

The `MinimalApiJwt.http` file can be used for testing the weather data request. Note that the `MinimalApiJwt` project must be running to test the endpoint, and the endpoint is hardcoded into the file. For more information, see <xref:test/http-files>.

The project includes packages and configuration to produce [OpenAPI documents](xref:fundamentals/openapi/overview) and the [Swagger UI](https://swagger.io/api-hub/) in the Development environment. For more information, see <xref:fundamentals/openapi/using-openapi-documents#use-swagger-ui-for-local-ad-hoc-testing>.

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

Configure the project in the <xref:Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerOptions> of the <xref:Microsoft.Extensions.DependencyInjection.JwtBearerExtensions.AddJwtBearer%2A> call in the project's `Program` file.

The <xref:Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerOptions.Authority%2A> sets the Authority for making OIDC calls. We recommend using a separate app registration for the `MinimalApiJwt` project. The authority matches the issurer (`iss`) of the JWT returned by the identity provider.

```csharp
jwtOptions.Authority = "{AUTHORITY}";
```

The format of the Authority depends on the type of tenant in use. The following examples for Microsoft Entra ID use a Tenant ID of `aaaabbbb-0000-cccc-1111-dddd2222eeee`.

ME-ID tenant Authority example:

```csharp
jwtOptions.Authority = "https://sts.windows.net/aaaabbbb-0000-cccc-1111-dddd2222eeee/";
```

AAD B2C tenant Authority example:

```csharp
jwtOptions.Authority = "https://login.microsoftonline.com/aaaabbbb-0000-cccc-1111-dddd2222eeee/v2.0/";
```

The <xref:Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerOptions.Audience%2A> sets the Audience for any received OIDC token. 

```csharp
jwtOptions.Audience = "{APP ID URI}";
```

> [!NOTE]
> When using Microsoft Entra ID, match the value to just the path of the **Application ID URI** configured when adding the `Weather.Get` scope under **Expose an API** in the Entra or Azure portal. Don't include the scope name, "`Weather.Get`," in the value.

The format of the Audience depends on the type of tenant in use. The following examples for Microsoft Entra ID use a Tenant ID of `contoso` and a Client ID of `11112222-bbbb-3333-cccc-4444dddd5555`.

ME-ID tenant App ID URI example:

```csharp
jwtOptions.Audience = "api://11112222-bbbb-3333-cccc-4444dddd5555";
```

AAD B2C tenant App ID URI example:

```csharp
jwtOptions.Audience = "https://contoso.onmicrosoft.com/11112222-bbbb-3333-cccc-4444dddd5555";
```

## Server-side Blazor Web App project (`BlazorWebAppOidc`)

This section explains how to configure the server-side Blazor project.

The following <xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions> configuration is found in the project's `Program` file on the call to <xref:Microsoft.Extensions.DependencyInjection.OpenIdConnectExtensions.AddOpenIdConnect%2A>.

:::moniker range=">= aspnetcore-9.0"

<xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.PushedAuthorizationBehavior%2A>: Controls [Pushed Authorization Requests (PAR) support](xref:aspnetcore-9#openidconnecthandler-adds-support-for-pushed-authorization-requests-par). By default, the setting is to use PAR if the identity provider's discovery document (usually found at `.well-known/openid-configuration`) advertises support for PAR. If you wish to require PAR support for the app, you can assign a value of [`PushedAuthorizationBehavior.Require`](xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.PushedAuthorizationBehavior). PAR isn't supported by Microsoft Entra, and there are no plans for Entra to ever support it in the future.

```csharp
oidcOptions.PushedAuthorizationBehavior = PushedAuthorizationBehavior.UseIfAvailable;
```

:::moniker-end

<xref:Microsoft.AspNetCore.Builder.RemoteAuthenticationOptions.SignInScheme%2A>: Sets the authentication scheme corresponding to the middleware responsible of persisting user's identity after a successful authentication. The OIDC handler needs to use a sign-in scheme that's capable of persisting user credentials across requests. The following line is present merely for demonstration purposes. If omitted, <xref:Microsoft.AspNetCore.Authentication.AuthenticationOptions.DefaultSignInScheme%2A> is used as a fallback value.

```csharp
oidcOptions.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
```

Scopes for `openid` and `profile` (<xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.Scope%2A>) (Optional): The `openid` and `profile` scopes are also configured by default because they're required for the OIDC handler to work, but these may need to be re-added if scopes are included in the `Authentication:Schemes:MicrosoftOidc:Scope` configuration. For general configuration guidance, see <xref:fundamentals/configuration/index> and <xref:blazor/fundamentals/configuration>.

```csharp
oidcOptions.Scope.Add(OpenIdConnectScope.OpenIdProfile);
```

<xref:Microsoft.AspNetCore.Authentication.RemoteAuthenticationOptions.SaveTokens%2A>: Defines whether access and refresh tokens should be stored in the <xref:Microsoft.AspNetCore.Authentication.AuthenticationProperties> after a successful authorization. The value is set to `true` to authenticate requests for weather data from the backend web API project (`MinimalApiJwt`).

```csharp
oidcOptions.SaveTokens = true;
```

Scope for offline access (<xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.Scope%2A>): The `offline_access` scope is required for the refresh token.

```csharp
oidcOptions.Scope.Add(OpenIdConnectScope.OfflineAccess);
```

Scopes for obtaining weather data from the web API (<xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.Scope%2A>): Configure the `Weather.Get` scope for accessing the external web API for weather data. In the following example, the `{APP ID URI}` placeholder is found in the Entra or Azure portal where the web API is exposed. For any other identity provider, use the appropriate scope.

```csharp
oidcOptions.Scope.Add("{APP ID URI}/Weather.Get");
```

The format of the scope depends on the type of tenant in use. In the following examples, the Tenant Domain is `contoso.onmicrosoft.com`, and the Client ID is `11112222-bbbb-3333-cccc-4444dddd5555`.

ME-ID tenant App ID URI example:

```csharp
oidcOptions.Scope.Add("api://11112222-bbbb-3333-cccc-4444dddd5555/Weather.Get");
```

AAD B2C tenant App ID URI example:

```csharp
oidcOptions.Scope.Add("https://contoso.onmicrosoft.com/11112222-bbbb-3333-cccc-4444dddd5555/Weather.Get");
```

<xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.Authority%2A> and <xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.ClientId%2A>: Sets the Authority and Client ID for OIDC calls.

```csharp
oidcOptions.Authority = "{AUTHORITY}";
oidcOptions.ClientId = "{CLIENT ID}";
```

The following example uses a Tenant ID of `aaaabbbb-0000-cccc-1111-dddd2222eeee` and a Client ID of `00001111-aaaa-2222-bbbb-3333cccc4444`:

```csharp
oidcOptions.Authority = "https://login.microsoftonline.com/aaaabbbb-0000-cccc-1111-dddd2222eeee/v2.0/";
oidcOptions.ClientId = "00001111-aaaa-2222-bbbb-3333cccc4444";
```

For multi-tenant apps, the "common" authority should be used. You can also use the "common" authority for single-tenant apps, but a custom <xref:Microsoft.IdentityModel.Tokens.TokenValidationParameters.IssuerValidator%2A> is required, as shown later in this section.

```csharp
oidcOptions.Authority = "https://login.microsoftonline.com/common/v2.0/";
```

<xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.ResponseType%2A>: Configures the OIDC handler to only perform authorization code flow. Implicit grants and hybrid flows are unnecessary in this mode. The OIDC handler automatically requests the appropriate tokens using the code returned from the authorization endpoint.

```csharp
oidcOptions.ResponseType = OpenIdConnectResponseType.Code;
```

<xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.MapInboundClaims%2A> and configuration of <xref:Microsoft.IdentityModel.Tokens.TokenValidationParameters.NameClaimType%2A> and <xref:Microsoft.IdentityModel.Tokens.TokenValidationParameters.RoleClaimType%2A>: Many OIDC servers use "`name`" and "`role`" rather than the SOAP/WS-Fed defaults in <xref:System.Security.Claims.ClaimTypes>. When <xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.MapInboundClaims%2A> is set to `false`, the handler doesn't perform claims mappings and the claim names from the JWT are used directly by the app. The following example sets the role claim type to "`roles`," which is appropriate for [Microsoft Entra ID (ME-ID)](https://www.microsoft.com/security/business/microsoft-entra). Consult your identity provider's documentation for more information.

> [!NOTE]
> <xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.MapInboundClaims%2A> must be set to `false` for most OIDC providers, which prevents renaming claims.

```csharp
oidcOptions.MapInboundClaims = false;
oidcOptions.TokenValidationParameters.NameClaimType = "name";
oidcOptions.TokenValidationParameters.RoleClaimType = "roles";
```

Path configuration: Paths must match the redirect URI (login callback path) and post logout redirect (signed-out callback path) paths configured when registering the application with the OIDC provider. In the Azure portal, paths are configured in the **Authentication** blade of the app's registration. Both the sign-in and sign-out paths must be registered as redirect URIs. The default values are `/signin-oidc` and `/signout-callback-oidc`.

Configure the signed-out callback path in the app's OIDC provider registration. In the following example, the `{PORT}` placeholder is the app's port:

> :::no-loc text="https://localhost:{PORT}/signin-oidc":::

> [!NOTE]
> A port isn't required for `localhost` addresses when using Microsoft Entra ID. Most other OIDC providers require the correct port.

<xref:Microsoft.AspNetCore.Builder.OpenIdConnectOptions.SignedOutCallbackPath%2A> (configuration key: "`SignedOutCallbackPath`"): The request path within the app's base path intercepted by the OIDC handler where the user agent is first returned after signing out from the identity provider. The sample app doesn't set a value for the path because the default value of "`/signout-callback-oidc`" is used. After intercepting the request, the OIDC handler redirects to the <xref:Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectOptions.SignedOutRedirectUri%2A> or <xref:Microsoft.AspNetCore.Authentication.AuthenticationProperties.RedirectUri%2A>, if specified.

Configure the signed-out callback path in the app's OIDC provider registration. In the following example, the `{PORT}` placeholder is the app's port:

> :::no-loc text="https://localhost:{PORT}/signout-callback-oidc":::

> [!NOTE]
> When using Microsoft Entra ID, set the path in the **Web** platform configuration's **Redirect URI** entries in the Entra or Azure portal. A port isn't required for `localhost` addresses when using Entra. Most other OIDC providers require the correct port. If you don't add the signed-out callback path URI to the app's registration in Entra, Entra refuses to redirect the user back to the app and merely asks them to close their browser window.

<xref:Microsoft.AspNetCore.Builder.OpenIdConnectOptions.RemoteSignOutPath%2A>: Requests received on this path cause the handler to invoke sign-out using the sign-out scheme.

In the following example, the `{PORT}` placeholder is the app's port:

> :::no-loc text="https://localhost/signout-oidc":::

> [!NOTE]
> When using Microsoft Entra ID, set the **Front-channel logout URL** in the Entra or Azure portal. A port isn't required for `localhost` addresses when using Entra. Most other OIDC providers require the correct port.

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

(*Microsoft Azure only with the "common" endpoint*) <xref:Microsoft.IdentityModel.Tokens.TokenValidationParameters.IssuerValidator%2A?displayProperty=nameWithType>: Many OIDC providers work with the default issuer validator, but we need to account for the issuer parameterized with the Tenant ID (`{TENANT ID}`) returned by `https://login.microsoftonline.com/common/v2.0/.well-known/openid-configuration`. For more information, see [SecurityTokenInvalidIssuerException with OpenID Connect and the Azure AD "common" endpoint (`AzureAD/azure-activedirectory-identitymodel-extensions-for-dotnet` #1731)](https://github.com/AzureAD/azure-activedirectory-identitymodel-extensions-for-dotnet/issues/1731).

Only for apps using Microsoft Entra ID or Azure AD B2C with the "common" endpoint:

```csharp
var microsoftIssuerValidator = AadIssuerValidator.GetAadIssuerValidator(oidcOptions.Authority);
oidcOptions.TokenValidationParameters.IssuerValidator = microsoftIssuerValidator.Validate;
```

## Client-side Blazor Web App project (`BlazorWebAppOidc.Client`)

The `BlazorWebAppOidc.Client` project is the client-side project of the Blazor Web App.

:::moniker range=">= aspnetcore-9.0"

The client calls <xref:Microsoft.Extensions.DependencyInjection.WebAssemblyAuthenticationServiceCollectionExtensions.AddAuthenticationStateDeserialization%2A> to deserialize and use the authentication state passed by the server. The authentication state is fixed for the lifetime of the WebAssembly application.

:::moniker-end

:::moniker range="< aspnetcore-9.0"

The `PersistentAuthenticationStateProvider` class (`PersistentAuthenticationStateProvider.cs`) is a client-side <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> that determines the user's authentication state by looking for data persisted in the page when it was rendered on the server. The authentication state is fixed for the lifetime of the WebAssembly application.

:::moniker-end

If the user needs to log in or out, a full page reload is required.

The sample app only provides a user name and email for display purposes.

:::zone-end

:::moniker range=">= aspnetcore-9.0"

## Only serialize the name and role claims

*This section only applies to the non-BFF pattern (Interactive Auto) and BFF pattern (Interactive Auto) and their sample apps.*

In the `Program` file, all claims are serialized by setting <xref:Microsoft.AspNetCore.Components.WebAssembly.Server.AuthenticationStateSerializationOptions.SerializeAllClaims%2A> to `true`. If you only want the name and role claims serialized for CSR, remove the option or set it to `false`.

:::moniker-end

## Supply configuration with the JSON configuration provider (app settings)

The [sample solution projects](#sample-solution) configure OIDC and JWT bearer authentication in their `Program` files in order to make configuration settings discoverable using C# autocompletion. Professional apps usually use a *configuration provider* to configure OIDC options, such as the default [JSON configuration provider](xref:fundamentals/configuration/index). The JSON configuration provider loads configuration from app settings files `appsettings.json`/`appsettings.{ENVIRONMENT}.json`, where the `{ENVIRONMENT}` placeholder is the app's [runtime environment](xref:fundamentals/environments). Follow the guidance in this section to use app settings files for configuration.

In the app settings file (`appsettings.json`) of the `BlazorWebAppOidc` or `BlazorWebAppOidcServer` project, add the following JSON configuration:

```json
"Authentication": {
  "Schemes": {
    "MicrosoftOidc": {
      "Authority": "https://login.microsoftonline.com/{TENANT ID (BLAZOR APP)}/v2.0/",
      "ClientId": "{CLIENT ID (BLAZOR APP)}",
      "CallbackPath": "/signin-oidc",
      "SignedOutCallbackPath": "/signout-callback-oidc",
      "RemoteSignOutPath": "/signout-oidc",
      "SignedOutRedirectUri": "/",
      "Scope": [
        "openid",
        "profile",
        "offline_access",
        "{APP ID URI (WEB API)}/Weather.Get"
      ]
    }
  }
},
```

Update the placeholders in the preceding configuration to match the values that the app uses in the `Program` file:

* `{TENANT ID (BLAZOR APP)}`: The Tenant Id of the Blazor app.
* `{CLIENT ID (BLAZOR APP)}`: The Client Id of the Blazor app.
* `{APP ID URI (WEB API)}`: The App ID URI of the web API.

The "common" Authority (`https://login.microsoftonline.com/common/v2.0/`) should be used for multi-tenant apps. To use the "common" Authority for single-tenant apps, see the [Use the "common" Authority for single-tenant apps](#use-the-common-authority-for-single-tenant-apps) section.

Update any other values in the preceding configuration to match custom/non-default values used in the `Program` file.

The configuration is automatically picked up by the authentication builder.

Remove the following lines from the `Program` file:

```diff
- oidcOptions.Scope.Add(OpenIdConnectScope.OpenIdProfile);
- oidcOptions.Scope.Add("...");
- oidcOptions.CallbackPath = new PathString("...");
- oidcOptions.SignedOutCallbackPath = new PathString("...");
- oidcOptions.RemoteSignOutPath = new PathString("...");
- oidcOptions.Authority = "...";
- oidcOptions.ClientId = "...";
```

In the `ConfigureCookieOidc` method of `CookieOidcServiceCollectionExtensions.cs`, remove the following line:

```diff
- oidcOptions.Scope.Add(OpenIdConnectScope.OfflineAccess);
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

## Use the "common" Authority for single-tenant apps

You can use the "common" Authority for single-tenant apps, but you must take the following steps to implement a custom issuer validator.

Add the [`Microsoft.IdentityModel.Validators` NuGet package](https://www.nuget.org/packages/Microsoft.IdentityModel.Validators) to the `BlazorWebAppOidc`, `BlazorWebAppOidcServer`, or `BlazorWebAppOidcBff` project.

[!INCLUDE[](~/includes/package-reference.md)]

At the top of the `Program` file, make the <xref:Microsoft.IdentityModel.Validators?displayProperty=fullName> namespace available:

```csharp
using Microsoft.IdentityModel.Validators;
```

Use the following code in the `Program` file where OIDC options are configured:

```csharp
var microsoftIssuerValidator = 
    AadIssuerValidator.GetAadIssuerValidator(oidcOptions.Authority);
oidcOptions.TokenValidationParameters.IssuerValidator = 
    microsoftIssuerValidator.Validate;
```

For more information, see [SecurityTokenInvalidIssuerException with OpenID Connect and the Azure AD "common" endpoint (`AzureAD/azure-activedirectory-identitymodel-extensions-for-dotnet` #1731)](https://github.com/AzureAD/azure-activedirectory-identitymodel-extensions-for-dotnet/issues/1731).

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

:::moniker range="< aspnetcore-10.0"

## Token refresh

<!-- UPDATE 10.0 - Check the PU issue for 10.0 work to resolve both issues.
                   The docs issue is https://github.com/dotnet/AspNetCore.Docs/issues/34235. -->

The custom cookie refresher (`CookieOidcRefresher.cs`) implementation updates the user's claims automatically when they expire. The current implementation expects to receive an ID token from the token endpoint in exchange for the refresh token. The claims in this ID token are then used to overwrite the user's claims.

The sample implementation doesn't include code for requesting claims from the [UserInfo endpoint](https://openid.net/specs/openid-connect-core-1_0.html#UserInfo) on token refresh. For more information, see [`BlazorWebAppOidc AddOpenIdConnect with GetClaimsFromUserInfoEndpoint = true doesn't propogate [sic] role claims to client` (`dotnet/aspnetcore` #58826)](https://github.com/dotnet/aspnetcore/issues/58826#issuecomment-2492738142).

> [!NOTE]
> Some identity providers [only return an access token when using a refresh token](https://openid.net/specs/openid-connect-core-1_0.html#RefreshTokenResponse). The `CookieOidcRefresher` can be updated with additional logic to continue to use the prior set of claims stored in the authentication cookie or use the access token to request claims from the UserInfo endpoint.

:::moniker-end

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

The approach described in this section configures ME-ID to send groups and roles in the authentication cookie header. When users are only a member of a few security groups and roles, the following approach should work for most hosting platforms without running into a problem where headers are too long, for example with IIS hosting that has a default header length limit of 16 KB (`MaxRequestBytes`). If header length is a problem due to high group or role membership, we recommend not following the guidance in this section in favor of implementing [Microsoft Graph](/graph/sdks/sdks-overview) to obtain a user's groups and roles from ME-ID separately, an approach that doesn't inflate the size of the authentication cookie. For more information, see [Bad Request - Request Too Long - IIS Server (`dotnet/aspnetcore` #57545)](https://github.com/dotnet/aspnetcore/issues/57545).

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
* [Manage authentication state in Blazor Web Apps](xref:blazor/security/index#manage-authentication-state-in-blazor-web-apps)
* [Refresh token during http request in Blazor Interactive Server with OIDC (`dotnet/aspnetcore` #55213)](https://github.com/dotnet/aspnetcore/issues/55213)
* [Secure data in Blazor Web Apps with Interactive Auto rendering](xref:blazor/security/index#secure-data-in-blazor-web-apps-with-interactive-auto-rendering)
