---
title: ASP.NET Core Blazor Server additional security scenarios
author: guardrex
description: Learn how to configure Blazor Server for additional security scenarios.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 05/19/2020
no-loc: [Blazor, "Identity", "Let's Encrypt", Razor, SignalR]
uid: security/blazor/server/additional-scenarios
---
# ASP.NET Core Blazor Server additional security scenarios

By [Javier Calvarro Nelson](https://github.com/javiercn)

## Pass tokens to a Blazor Server app

Tokens available outside of the Razor components in a Blazor Server app can be passed to components with the approach described in this section. For sample code, including a complete `Startup.ConfigureServices` example, see the [Passing tokens to a server-side Blazor application](https://github.com/javiercn/blazor-server-aad-sample).

Authenticate the Blazor Server app as you would with a regular Razor Pages or MVC app. Provision and save the tokens to the authentication cookie. For example:

```csharp
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

...

services.Configure<OpenIdConnectOptions>(AzureADDefaults.OpenIdScheme, options =>
{
    options.ResponseType = "code";
    options.SaveTokens = true;

    options.Scope.Add("offline_access");
    options.Scope.Add("{SCOPE}");
    options.Resource = "{RESOURCE}";
});
```

Define a class to pass in the initial app state with the access and refresh tokens:

```csharp
public class InitialApplicationState
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}
```

Define a **scoped** token provider service that can be used within the Blazor app to resolve the tokens from [dependency injection (DI)](xref:blazor/dependency-injection):

```csharp
public class TokenProvider
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}
```

In `Startup.ConfigureServices`, add services for:

* `IHttpClientFactory`
* `TokenProvider`

```csharp
services.AddHttpClient();
services.AddScoped<TokenProvider>();
```

In the *_Host.cshtml* file, create and instance of `InitialApplicationState` and pass it as a parameter to the app:

```cshtml
@using Microsoft.AspNetCore.Authentication

...

@{
    var tokens = new InitialApplicationState
    {
        AccessToken = await HttpContext.GetTokenAsync("access_token"),
        RefreshToken = await HttpContext.GetTokenAsync("refresh_token")
    };
}

<app>
    <component type="typeof(App)" param-InitialState="tokens" 
        render-mode="ServerPrerendered" />
</app>
```

In the `App` component (*App.razor*), resolve the service and initialize it with the data from the parameter:

```razor
@inject TokenProvider TokenProvider

...

@code {
    [Parameter]
    public InitialApplicationState InitialState { get; set; }

    protected override Task OnInitializedAsync()
    {
        TokenProvider.AccessToken = InitialState.AccessToken;
        TokenProvider.RefreshToken = InitialState.RefreshToken;

        return base.OnInitializedAsync();
    }
}
```

In the service that makes a secure API request, inject the token provider and retrieve the token to call the API:

```csharp
public class WeatherForecastService
{
    private readonly TokenProvider _store;

    public WeatherForecastService(IHttpClientFactory clientFactory, 
        TokenProvider tokenProvider)
    {
        Client = clientFactory.CreateClient();
        _store = tokenProvider;
    }

    public HttpClient Client { get; }

    public async Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
    {
        var token = _store.AccessToken;
        var request = new HttpRequestMessage(HttpMethod.Get, 
            "https://localhost:5003/WeatherForecast");
        request.Headers.Add("Authorization", $"Bearer {token}");
        var response = await Client.SendAsync(request);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsAsync<WeatherForecast[]>();
    }
}
```

## Use Open ID Connect (OIDC) v2.0 endpoints

The authentication library and Blazor templates use Open ID Connect (OIDC) v1.0 endpoints. To use a v2.0 endpoint, configure the <xref:Microsoft.AspNetCore.Builder.OpenIdConnectOptions.Authority?displayProperty=nameWithType> option in the <xref:Microsoft.AspNetCore.Builder.OpenIdConnectOptions>:

```csharp
services.Configure<OpenIdConnectOptions>(AzureADDefaults.OpenIdScheme, 
    options =>
    {
        options.Authority += "/v2.0";
    }
```

Alternatively, the setting can be made in the app settings (*appsettings.json*) file:

```json
{
  "AzureAd": {
    "Authority": "https://login.microsoftonline.com/common/oauth2/v2.0/",
    ...
  }
}
```

If tacking on a segment to the authority isn't appropriate for the app's OIDC provider, such as with non-AAD providers, set the <xref:Microsoft.AspNetCore.Builder.OpenIdConnectOptions.Authority> property directly. Either set the property in <xref:Microsoft.AspNetCore.Builder.OpenIdConnectOptions> or in the app settings file with the <xref:Microsoft.AspNetCore.Builder.OpenIdConnectOptions.Authority> key.

### Code changes

* The list of claims in the ID token changes for v2.0 endpoints. For more information, see [Why update to Microsoft identity platform (v2.0)?](/azure/active-directory/azuread-dev/azure-ad-endpoint-comparison) in the Azure documentation.
* Since resources are specified in scope URIs for v2.0 endpoints, remove the the <xref:Microsoft.AspNetCore.Builder.OpenIdConnectOptions.Resource?displayProperty=nameWithType> property setting in <xref:Microsoft.AspNetCore.Builder.OpenIdConnectOptions>:

  ```csharp
  services.Configure<OpenIdConnectOptions>(AzureADDefaults.OpenIdScheme, options => 
      {
          ...
          options.Resource = "...";    // REMOVE THIS LINE
          ...
      }
      ```

  For more information, see [Scopes, not resources](/azure/active-directory/azuread-dev/azure-ad-endpoint-comparison#scopes-not-resources) in the Azure documentation.

### App ID URI

* When using v2.0 endpoints, APIs define an *App ID URI*, which is meant to represent a unique identifier for the API.
* All scopes include the App ID URI as a prefix, and v2.0 endpoints emit access tokens with the App ID URI as the audience.
* When using V2.0 endpoints, the client ID configured in the Server API changes from the API Application ID (Client ID) to the App ID URI.

*appsettings.json*:

```json
{
  "AzureAd": {
    ...
    "ClientId": "https://{TENANT}.onmicrosoft.com/{APP NAME}"
    ...
  }
}
```

You can find the App ID URI to use in the OIDC provider app registration description.
