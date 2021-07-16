---
title: Azure Active Directory with ASP.NET Core
author: rick-anderson
description: Learn how to use Azure Active Directory in an ASP.NET Core app.
ms.author: jacalvar
ms.date: 09/22/2018
ms.custom: "mvc, seodec18"
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: security/authentication/aad-ui
---
# Azure Active Directory UI with ASP.NET Core

The web templates for ASP.NET Core MVC, Razor Pages, and Server-Side Blazor include support for authenticating users with [Azure Active Directory](/azure/active-directory/authentication/overview-authentication) (AAD). Support for AAD is provided by the [Microsoft.AspNetCore.Authentication.AzureAD.UI](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.AzureAD.UI) NuGet package. This package contains helper methods and a basic UI that supports authenticating with AAD.

Authentication is enabled with the following highlighted lines in `Startup`:

[!code-csharp[](aad-ui/samples/WebAAD6/Startup.cs?name=snippet&highlight=9,10)]

The preceding code sets up a policy scheme that delegates authentication tasks to an underlying [OpenID Connect](https://openid.net/connect/) (**OIDC**) authentication handler and sign-in tasks to a cookie authentication handler.

When an unauthenticated user tries to visit a protected page:

* The app emits a challenge to the policy scheme, which is setup as the default scheme.
* The challenge delegates to the underlying OIDC scheme.
* OIDC redirects the user to the authorize endpoint.

When the process is successful:

* The app returns to the `signin-oidc` endpoint.
* The sign-in process continues by validating the response and emitting a cookie with the results.

The authentication package is just a wrapper around the underlying OIDC API. The OIDC API is available to customize any detail or extend the current functionality.

## Customize the sign-in and sign-out processes

By default the template is setup with a login and logout buttons that call a controller provided in the package to start the authentication operations.

A controller or razor page can be created to begin sign-in and sign-out by calling the appropriate method on the `HttpContext`, for example:

[!code-csharp[](aad-ui/samples/WebAAD6/Areas/Identity/Pages/Account/SignOut.cshtml.cs?name=snippet)]

The preceding sign-out code ensures the app is signed out locally even if remote sign-out fails.

## Configure the underlying OIDC middleware

Configuring the underlying OIDC middleware can be achieved by calling Configure after `AddAzureAD` and performing any desired customization, as shown in the following highlighted code:

[!code-csharp[](aad-ui/samples/WebAAD6/Startup2.cs?name=snippet&highlight=12-14)]

## Request an access token

The OIDC authentication handler can be configured to request an access token from Azure Active Directory.

Given a registered app, the OIDC middlware can be configured as shown in the following highlighted code:

[!code-csharp[](aad-ui/samples/WebAAD6/Startup3.cs?name=snippet&highlight=12-17)]

* `options.ResponseType = "code"` changes the authentication flow to `code`. The default authentication flow is `id_token`.
* The `offline_access` scope allows the app to request refresh tokens from the app that it can use to refresh `access_tokens` without user interaction.
* The `<<scope>>` parameter is the scope for the API to be called, this typically has the form of `api://<<api-app-id-uri>>/scope-name`
* `Resource` is the client id for the Resource (API) you want to get an access token for. This value will appear in the audience (aud) claim of the provisioned access token so it must match what the Server API has configured as the client ID.

## Update an app to use V2.0 endpoints

Both the `Microsoft.AspNetCore.Authentication.AzureAD.UI` NuGet package and the ASP.NET Core web templates provisions a V1 endpoints. If you create a new app from the portal you will have to adjust the configuration of the API or web app to match the endpoint expected by the registered apps.

For APIs you can do so configuring the JWT Bearer options as follows:

```csharp
services.Configure<JwtBearerOptions>(AzureADDefaults.JwtBearerAuthenticationScheme, options =>
{
    options.Authority += "/v2.0";
});
```

For web apps you can do so by configuring the OIDC options as shown in the following highlighted code:

[!code-csharp[](aad-ui/samples/WebAAD6/Startup4.cs?name=snippet&highlight=12-15)]

### Code changes when upgrading to V2.0

* The list of claims in the ID token changes. See [Why update to Microsoft identity platform (v2.0)](/azure/active-directory/azuread-dev/azure-ad-endpoint-comparison) for details on the differences.
* The resource property doesn't need to be specified when requesting an access token. The following code can be removed:

```csharp
services.Configure<OpenIdConnectOptions>(AzureADDefaults.OpenIdScheme, options =>
{
    ...
    options.Resource = "....";
    ...
}
```

### Considerations with the App ID URI

* When using v2.0 endpoints APIs define an `App ID URI` which is meant to represent a unique identifier for the API.
* All scopes include that as a prefix and v2.0 endpoints will emit access tokens with the `App ID URI` as the audience.
* That means that if you are using V2.0 endpoints the client ID configured in your server API will have to change from the API Application (client) Id to the `App ID URI`. For example:

```json
{
  "AzureAd": {
    ...
    "ClientId": "https://<<tenant>>.onmicrosoft.com/<<app-name>>"
  }
}
```

You can check the specific App ID Uri to use in the app registration description for your app.

## Retrieve and use access tokens and refresh tokens

The OIDC authentication handler can be configured to save the tokens it provisions as part of the authorization process by setting `SaveTokens = true` in the OIDC options:
```csharp
services.Configure<OpenIdConnectOptions>(AzureADDefaults.OpenIdScheme, options =>
{
    ...
    options.SaveTokens = true;
    ...
}
```

This will save the tokens into the cookie that gets generated as part of the sign in process. To retrieve the tokens you can call the GetTokenAsync extension methods on the HttpContext as shown below:
```csharp
var accessToken = await HttpContext.GetTokenAsync("access_token");
var refreshToken = await HttpContext.GetTokenAsync("refresh_token");
```

This assumes that the AzureAd scheme is setup to be your default scheme, but if that is not the case you can pass in the scheme explicitly to the `GetTokenAsync` method.

Alternatively, if you don't want to store the tokens in the authentication cookie (it will make the cookie significantly bigger) you can access the tokens and save them after they have been validated as follows by signing-up to the appropriate:
```csharp
options.Events.OnTokenValidated = async (TokenValidatedContext validation) =>
{
    if (validation.Result.Succeeded)
    {
        var store = validation.HttpContext.RequestServices.GetRequiredService<TokenStore>();
        var accesToken = validation.TokenEndpointResponse.AccessToken;
        var refreshToken = validation.TokenEndpointResponse.RefreshToken;

        await store.SaveTokensAsync(validation.Principal, accesToken, refreshToken);
    }
};
```

You can use the `ClaimTypes.NameIdentifier` to get the ID of the user and use that as a key to store your other tokens.

TokenStore is the class you created to save the tokens to your underlying storage system.

Then on code, you can inject the TokenStore and call a method on it to get the access token and add it to an API. For example:
```csharp
public class WeatherForecastService
{
    private readonly TokenStore _store;
    ...
    public HttpClient Client { get; }

    public async Task<WeatherForecast[]> GetForecastAsync(ClaimsPrincipal user)
    {
        var token = _store.GetTokenAsync(user);
        var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:5003/WeatherForecast");
        request.Headers.Add("Authorization", $"Bearer {token}");
        var response = await Client.SendAsync(request);
        ...
    }
}
```