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
# Azure Active Directory with ASP.NET Core

The web templates for ASP.NET Core MVC, Razor Pages, and Server-Side Blazor include support for authenticating users with [Azure Active Directory](/azure/active-directory/authentication/overview-authentication) (AAD). Support for AAD is provided by the [Microsoft.AspNetCore.Authentication.AzureAD.UI](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.AzureAD.UI) NuGet package. This package contains helper methods and a basic UI that supports authenticating with AAD.

Authentication is setup in the following lines in startup:
```csharp
services.AddAuthentication(AzureADDefaults.AuthenticationScheme)
    .AddAzureAD(options => Configuration.Bind("AzureAd", options));
```

[!code-csharp[](aad-ui/samples/WebAAD6/Startup.cs?name=snippet&highlight=9,10)]

The preceding code sets up a policy scheme that delegates authentication tasks to an underlying Open ID Connect authentication handler and sign-in tasks to a cookie authentication handler.

When an unauthenticated user tries to visit a protected page, the application emits a challenge to the policy scheme (which is setup as the default scheme) and that delegates to the underlying Open ID Connect scheme that redirects the user to the authorize endpoint.

When the process is successful, the application comes back to the `signin-oidc` endpoint and the sign-in process continues by validating the response and emitting a cookie with the results.

The authentication package is merely a wrapper around the underlying Open ID Connect concepts and those are still available to customize any detail or extend the current functionality in the ways provided by the Open ID Connect handler.

## Customizing the sign-in and sign-out processes

By default the template is setup with a login and logout buttons that call a controller provided in the package to start the authentication operations.

You can create your own controller or razor page to begin the login/logout processes and start the proccess there by calling the appropriate method on the HttpContext. For example:

```csharp
[HttpPost]
[ValidateAntiforgeryToken]
public IActionResult SignOut()
{
    // This is done in this order to ensue that we log out locally even if the remote logout fails.
    return SignOut(AzureADDefaults.CookieSchemeName, AzureADDefaults.OpenIdConnectSchemeName);
}
```

## Configuring the underlying OIDC middleware

This can be achieved by calling Configure after `AddAzureAD` and perfoming any desired customization

```csharp
services.AddAuthentication(AzureADDefaults.AuthenticationScheme)
    .AddAzureAD(options => Configuration.Bind("AzureAd", options));

services.Configure<OpenIdConnectOptions>(AzureADDefaults.OpenIdScheme, options => {

});
```

## Requesting an access token

The Open ID Connect authentication handler can be configured to request an access token from Azure Active Directory.

Given a registered application, you can configure the Open ID Connect middlware as follows:

```csharp
options.ResponseType = "code";
options.Scope.Add("offline_access");
options.Scope.Add("<<scope>>");
options.Resource = "<<api-client-id>>";
```

* The response type `code` changes the authentication flow to `code` the default is `id_token`.
* The `offline_access` scope allows the application to request refresh tokens from the app that it can use to refresh access_tokens without user interaction.
* The `<<scope>>` parameter is the scope for the API you want to call, this typically has the form of `api://<<api-app-id-uri>>/scope-name`
* The resource is the client id for the Resource (API) you want to get an access token for. This value will appear in the audience (aud) claim of the provisioned access token so it must match what the Server API has configured as the client ID.

## Updating your application to use V2.0 endpoints
Our packages use the V1.0 endpoints of Azure Active Directory and Visual Studio provisions a V1 endpoint, that means that if you create a new application from the portal you will have to adjust the configuration of the API/Web App to match the endpoint expected by the registered apps.

For APIs you can do so configuring the JWT Bearer options as follows:

```csharp
services.Configure<JwtBearerOptions>(AzureADDefaults.JwtBearerAuthenticationScheme, options =>
{
    options.Authority += "/v2.0";
});
```

For web applications you can do so by configuring the Open ID Connect options as follows:

```csharp
services.Configure<OpenIdConnectOptions>(AzureADDefaults.OpenIdScheme, options =>
{
    options.Authority += "/v2.0";
}
```

### Code changes when you upgrade to V2.0
* The list of claims in the ID token changes. check [here](https://docs.microsoft.com/en-us/azure/active-directory/azuread-dev/azure-ad-endpoint-comparison) for details on the differences.
* You don't need to specify the resource property anymore when requesting an access token. The snippet below can be removed
```csharp
services.Configure<OpenIdConnectOptions>(AzureADDefaults.OpenIdScheme, options =>
{
    ...
    options.Resource = "....";
    ...
}
```

### Considerations with the App ID URI
* When using v2.0 endpoints APIs define an "App ID URI" which is meant to represent a unique identifier for the API.
* All scopes include that as a prefix and v2.0 endpoints will emit access tokens with the App ID URI as the audience.
* That means that if you are using V2.0 endpoints the client ID configured in your server API will have to change from the API Application (client) Id to the App ID URI. For example:

```json
{
  "AzureAd": {
    ...
    "ClientId": "https://<<tenant>>.onmicrosoft.com/<<app-name>>"
  }
}
```
You can check the specific App ID Uri to use in the application registration description for your app.

## Retrieving an using access tokens and refresh tokens

You can configure the Open ID Connect authentication handler to save the tokens it provisions as part of the authorization process by setting `SaveTokens = true` in the Open ID Connect options:
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