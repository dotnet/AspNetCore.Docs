---
title: ASP.NET Core server-side and Blazor Web App additional security scenarios
author: guardrex
description: Learn how to configure server-side Blazor and Blazor Web Apps for additional security scenarios.
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.custom: mvc
ms.date: 11/11/2025
uid: blazor/security/additional-scenarios
---
# ASP.NET Core server-side and Blazor Web App additional security scenarios

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how to configure server-side Blazor for additional security scenarios, including how to pass tokens to a Blazor app.

> [!NOTE]
> The code examples in this article adopt [nullable reference types (NRTs) and .NET compiler null-state static analysis](xref:migration/50-to-60#nullable-reference-types-nrts-and-net-compiler-null-state-static-analysis), which are supported in ASP.NET Core in .NET 6 or later. When targeting .NET 5 or earlier, remove the null type designation (`?`) from the `string?`, `TodoItem[]?`, `WeatherForecast[]?`, and `IEnumerable<GitHubBranch>?` types in the article's examples.

## Pass tokens to a server-side Blazor app

:::moniker range=">= aspnetcore-8.0"

*This section applies to Blazor Web Apps. For Blazor Server, view the [.NET 7 version of this article section](xref:blazor/security/additional-scenarios?view=aspnetcore-7.0&preserve-view=true#pass-tokens-to-a-server-side-blazor-app).*

If you merely want to use access tokens to make web API calls from a Blazor Web App with a [named HTTP client](xref:blazor/call-web-api#named-httpclient-with-ihttpclientfactory), see the [Use a token handler for web API calls](#use-a-token-handler-for-web-api-calls) section, which explains how to use a <xref:System.Net.Http.DelegatingHandler> implementation to attach a user's access token to outgoing requests. The following guidance in this section is for developers who need access tokens, refresh tokens, and other authentication properties server-side for other purposes.

> [!NOTE]
> For more information on <xref:System.Net.Http.DelegatingHandler> instances, see <xref:fundamentals/http-requests#outgoing-request-middleware>.

To save tokens and other authentication properties for server-side use in Blazor Web Apps, we recommend using [`IHttpContextAccessor`/`HttpContext`](xref:blazor/components/httpcontext) (<xref:Microsoft.AspNetCore.Http.IHttpContextAccessor>, <xref:Microsoft.AspNetCore.Http.HttpContext>). Reading tokens from <xref:Microsoft.AspNetCore.Http.HttpContext>, including as a [cascading parameter](xref:Microsoft.AspNetCore.Components.CascadingParameterAttribute), using <xref:Microsoft.AspNetCore.Http.IHttpContextAccessor> is supported for obtaining tokens for use during interactive server rendering if the tokens are obtained during static server-side rendering (static SSR) or prerendering. However, tokens aren't updated if the user authenticates after the circuit is established, since the <xref:Microsoft.AspNetCore.Http.HttpContext> is captured at the start of the SignalR connection. Also, the use of <xref:System.Threading.AsyncLocal%601> by <xref:Microsoft.AspNetCore.Http.IHttpContextAccessor> means that you must be careful not to lose the execution context before reading the <xref:Microsoft.AspNetCore.Http.HttpContext>. For more information, see <xref:blazor/components/httpcontext>.

In a service class, obtain access to the members of the namespace <xref:Microsoft.AspNetCore.Authentication?displayProperty=fullName> to surface the <xref:Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.GetTokenAsync%2A> method on <xref:Microsoft.AspNetCore.Http.HttpContext>. An alternative approach, which is commented out in the following example, is to call <xref:Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.AuthenticateAsync%2A> on <xref:Microsoft.AspNetCore.Http.HttpContext>. For the returned <xref:Microsoft.AspNetCore.Authentication.AuthenticateResult.Properties%2A?displayProperty=nameWithType>, call <xref:Microsoft.AspNetCore.Authentication.AuthenticationTokenExtensions.GetTokenValue%2A>.

```csharp
using Microsoft.AspNetCore.Authentication;

public class AuthenticationProcessor(IHttpContextAccessor httpContextAccessor)
{
    public async Task<string?> GetAccessToken()
    {
        if (httpContextAccessor.HttpContext is null)
        {
            throw new Exception("HttpContext not available");
        }

        // Approach 1: Call 'GetTokenAsync'
        var accessToken = await httpContextAccessor.HttpContext
            .GetTokenAsync("access_token");

        // Approach 2: Authenticate the user and call 'GetTokenValue'
        /*
        var authResult = await httpContextAccessor.HttpContext.AuthenticateAsync();
        var accessToken = authResult?.Properties?.GetTokenValue("access_token");
        */

        return accessToken;
    }
}
```

The service is registered in the server project's `Program` file:

```csharp
builder.Services.AddScoped<AuthenticationProcessor>();
```

`AuthenticationProcessor` can be injected into server-side services, for example in a <xref:System.Net.Http.DelegatingHandler> for a preconfigured <xref:System.Net.Http.HttpClient>. The following example is only for demonstration purposes or in case you need to perform special processing in the `AuthenticationProcessor` service because you can just inject <xref:Microsoft.AspNetCore.Http.IHttpContextAccessor> and obtain the token directly for calling external web APIs (for more information on using <xref:Microsoft.AspNetCore.Http.IHttpContextAccessor> directly to call web APIs, see the [Use a token handler for web API calls](#use-a-token-handler-for-web-api-calls) section). 

```csharp
using System.Net.Http.Headers;

public class TokenHandler(AuthenticationProcessor authProcessor) : 
    DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var accessToken = authProcessor.GetAccessToken();

        request.Headers.Authorization =
            new AuthenticationHeaderValue("Bearer", accessToken);

        return await base.SendAsync(request, cancellationToken);
    }
}
```

The token handler is registered and acts as the delegating handler for a named HTTP client in the `Program` file:

```csharp
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<TokenHandler>();

builder.Services.AddHttpClient("ExternalApi",
      client => client.BaseAddress = new Uri(builder.Configuration["ExternalApiUri"] ?? 
          throw new Exception("Missing base address!")))
      .AddHttpMessageHandler<TokenHandler>();
```

> [!CAUTION]
> Ensure that tokens are never transmitted and handled by the client (the `.Client` project), for example, in a component that adopts Interactive Auto rendering and is rendered on the client or by a client-side service. Always have the client call the server (project) to process requests with tokens. **Tokens and other authentication data should never leave the server.**
>
> For Interactive Auto components, see <xref:blazor/security/index#secure-data-in-blazor-web-apps-with-interactive-auto-rendering>, which demonstrates how to leave access tokens and other authentication properties on the server. Also, consider adopting the Backend-for-Frontend (BFF) pattern, which adopts a similar call structure and is described in <xref:blazor/security/blazor-web-app-oidc> for OIDC providers and <xref:blazor/security/blazor-web-app-entra> for Microsoft Identity Web with Entra.

## Use a token handler for web API calls

The following approach is aimed at attaching a user's access token to outgoing requests, specifically to make web API calls to external web API apps. The approach is shown for a Blazor Web App that adopts global Interactive Server rendering, but the same general approach applies to Blazor Web Apps that adopt the global Interactive Auto render mode. The important concept to keep in mind is that accessing the <xref:Microsoft.AspNetCore.Http.HttpContext> using <xref:Microsoft.AspNetCore.Http.IHttpContextAccessor> is only performed on the server.

For a demonstration of the guidance in this section, see the `BlazorWebAppOidc` and `BlazorWebAppOidcServer` sample apps (.NET 8 or later) in the [Blazor samples GitHub repository](https://github.com/dotnet/blazor-samples). The samples adopt a global interactive render mode and OIDC authentication with Microsoft Entra without using Entra-specific packages. The samples demonstrate how to pass a JWT access token to call a secure web API.

[Microsoft identity platform](/entra/identity-platform/) with [Microsoft Identity Web packages](/entra/msal/dotnet/microsoft-identity-web/) for [Microsoft Entra ID](https://www.microsoft.com/security/business/microsoft-entra) provides a API to call web APIs from Blazor Web Apps with automatic token management and renewal. For more information, see <xref:blazor/security/blazor-web-app-entra> and the `BlazorWebAppEntra` and `BlazorWebAppEntraBff` sample apps (.NET 9 or later) in the [Blazor samples GitHub repository](https://github.com/dotnet/blazor-samples).

Subclass <xref:System.Net.Http.DelegatingHandler> to attach a user's access token to outgoing requests. The token handler only executes on the server, so using <xref:Microsoft.AspNetCore.Http.HttpContext> is safe.

`TokenHandler.cs`:

```csharp
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication;

public class TokenHandler(IHttpContextAccessor httpContextAccessor) : 
    DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (httpContextAccessor.HttpContext is null)
        {
            throw new Exception("HttpContext not available");
        }

        var accessToken = await httpContextAccessor.HttpContext.GetTokenAsync("access_token");

        if (accessToken is null)
        {
            throw new Exception("No access token");
        }

        request.Headers.Authorization =
            new AuthenticationHeaderValue("Bearer", accessToken);

        return await base.SendAsync(request, cancellationToken);
    }
}
```

> [!NOTE]
> For guidance on how to access an `AuthenticationStateProvider` from a `DelegatingHandler`, see the [Access `AuthenticationStateProvider` in outgoing request middleware](#access-authenticationstateprovider-in-outgoing-request-middleware) section.

In the project's `Program` file, the token handler (`TokenHandler`) is registered as a scoped service and specified as a [named HTTP client's](xref:blazor/call-web-api#named-httpclient-with-ihttpclientfactory) message handler with <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.AddHttpMessageHandler%2A>.

In the following example, the `{HTTP CLIENT NAME}` placeholder is the name of the <xref:System.Net.Http.HttpClient>, and the `{BASE ADDRESS}` placeholder is the web API's base address URI. For more information on <xref:Microsoft.Extensions.DependencyInjection.HttpServiceCollectionExtensions.AddHttpContextAccessor%2A>, see <xref:blazor/components/httpcontext>.

In `Program.cs`:

```csharp
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<TokenHandler>();

builder.Services.AddHttpClient("{HTTP CLIENT NAME}",
      client => client.BaseAddress = new Uri("{BASE ADDRESS}"))
      .AddHttpMessageHandler<TokenHandler>();
```

Example:

```csharp
builder.Services.AddScoped<TokenHandler>();

builder.Services.AddHttpClient("ExternalApi",
      client => client.BaseAddress = new Uri("https://localhost:7277"))
      .AddHttpMessageHandler<TokenHandler>();
```

You can supply the HTTP client base address from [configuration](xref:blazor/fundamentals/configuration) with `builder.Configuration["{CONFIGURATION KEY}"]`, where the `{CONFIGURATION KEY}` placeholder is the configuration key:

```csharp
new Uri(builder.Configuration["ExternalApiUri"] ?? throw new IOException("No URI!"))
```

In `appsettings.json`, specify the `ExternalApiUri`. The following example sets the value to the localhost address of the external web API to `https://localhost:7277`:

```json
"ExternalApiUri": "https://localhost:7277"
```

At this point, an <xref:System.Net.Http.HttpClient> created by a component can make secure web API requests. In the following example, the `{REQUEST URI}` is the relative request URI, and the `{HTTP CLIENT NAME}` placeholder is the name of the <xref:System.Net.Http.HttpClient>:

```csharp
using var request = new HttpRequestMessage(HttpMethod.Get, "{REQUEST URI}");
var client = ClientFactory.CreateClient("{HTTP CLIENT NAME}");
using var response = await client.SendAsync(request);
```

Example:

```csharp
using var request = new HttpRequestMessage(HttpMethod.Get, "/weather-forecast");
var client = ClientFactory.CreateClient("ExternalApi");
using var response = await client.SendAsync(request);
```

<!-- UPDATE 11.0 - Scheduled for features in .NET 11 -->

Additional features are planned for Blazor, which are tracked by [Access `AuthenticationStateProvider` in outgoing request middleware (`dotnet/aspnetcore` #52379)](https://github.com/dotnet/aspnetcore/issues/52379). [Problem providing Access Token to HttpClient in Interactive Server mode (`dotnet/aspnetcore` #52390)](https://github.com/dotnet/aspnetcore/issues/52390) is a closed issue that contains helpful discussion and potential workaround strategies for advanced use cases.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

Tokens available outside of the Razor components in a server-side Blazor app can be passed to components with the approach described in this section. The example in this section focuses on passing access, refresh, and [anti-request forgery (XSRF) token](xref:security/anti-request-forgery) tokens to the Blazor app, but the approach is valid for other HTTP context state.

> [!NOTE]
> Passing the XSRF token to Razor components is useful in scenarios where components POST to Identity or other endpoints that require validation. If your app only requires access and refresh tokens, you can remove the XSRF token code from the following example.

Authenticate the app as you would with a regular Razor Pages or MVC app. Provision and save the tokens to the authentication cookie.

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

In the `Program` file:

```csharp
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

...

builder.Services.Configure<OpenIdConnectOptions>(
    OpenIdConnectDefaults.AuthenticationScheme, options =>
{
    options.ResponseType = OpenIdConnectResponseType.Code;
    options.SaveTokens = true;
    options.Scope.Add(OpenIdConnectScope.OfflineAccess);
});
```

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

In `Startup.cs`:

```csharp
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

...

services.Configure<OpenIdConnectOptions>(
    OpenIdConnectDefaults.AuthenticationScheme, options =>
{
    options.ResponseType = OpenIdConnectResponseType.Code;
    options.SaveTokens = true;
    options.Scope.Add(OpenIdConnectScope.OfflineAccess);
});
```

:::moniker-end

:::moniker range="< aspnetcore-5.0"

In `Startup.cs`:

```csharp
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

...

services.Configure<OpenIdConnectOptions>(AzureADDefaults.OpenIdScheme, options =>
{
    options.ResponseType = OpenIdConnectResponseType.Code;
    options.SaveTokens = true;
    options.Scope.Add(OpenIdConnectScope.OfflineAccess);
});
```

:::moniker-end

:::moniker range="< aspnetcore-8.0"

Optionally, additional scopes are added with `options.Scope.Add("{SCOPE}");`, where the `{SCOPE}` placeholder is the additional scope to add.

Define a **scoped** token provider service that can be used within the Blazor app to resolve the tokens from [dependency injection (DI)](xref:blazor/fundamentals/dependency-injection).

`TokenProvider.cs`:

```csharp
public class TokenProvider
{
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }
    public string? XsrfToken { get; set; }
}
```

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

In the `Program` file, add services for:

* <xref:System.Net.Http.IHttpClientFactory>: Used in a `WeatherForecastService` class that obtains weather data from a server API with an access token.
* `TokenProvider`: Holds the access and refresh tokens.

```csharp
builder.Services.AddHttpClient();
builder.Services.AddScoped<TokenProvider>();
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

In `Startup.ConfigureServices` of `Startup.cs`, add services for:

* <xref:System.Net.Http.IHttpClientFactory>: Used in a `WeatherForecastService` class that obtains weather data from a server API with an access token.
* `TokenProvider`: Holds the access and refresh tokens.

```csharp
services.AddHttpClient();
services.AddScoped<TokenProvider>();
```

:::moniker-end

:::moniker range="< aspnetcore-8.0"

Define a class to pass in the initial app state with the access and refresh tokens.

`InitialApplicationState.cs`:

```csharp
public class InitialApplicationState
{
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }
    public string? XsrfToken { get; set; }
}
```

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

In the `Pages/_Host.cshtml` file, create and instance of `InitialApplicationState` and pass it as a parameter to the app:

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

In the `Pages/_Layout.cshtml` file, create and instance of `InitialApplicationState` and pass it as a parameter to the app:

:::moniker-end

:::moniker range="< aspnetcore-6.0"

In the `Pages/_Host.cshtml` file, create and instance of `InitialApplicationState` and pass it as a parameter to the app:

:::moniker-end

:::moniker range="< aspnetcore-8.0"

```cshtml
@using Microsoft.AspNetCore.Authentication
@inject Microsoft.AspNetCore.Antiforgery.IAntiforgery Xsrf

...

@{
    var tokens = new InitialApplicationState
    {
        AccessToken = await HttpContext.GetTokenAsync("access_token"),
        RefreshToken = await HttpContext.GetTokenAsync("refresh_token"),
        XsrfToken = Xsrf.GetAndStoreTokens(HttpContext).RequestToken
    };
}

<component ... param-InitialState="tokens" ... />
```

In the `App` component (`App.razor`), resolve the service and initialize it with the data from the parameter:

```razor
@inject TokenProvider TokenProvider

...

@code {
    [Parameter]
    public InitialApplicationState? InitialState { get; set; }

    protected override Task OnInitializedAsync()
    {
        TokenProvider.AccessToken = InitialState?.AccessToken;
        TokenProvider.RefreshToken = InitialState?.RefreshToken;
        TokenProvider.XsrfToken = InitialState?.XsrfToken;

        return base.OnInitializedAsync();
    }
}
```

> [!NOTE]
> An alternative to assigning the initial state to the `TokenProvider` in the preceding example is to copy the data into a scoped service within <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A> for use across the app.

Add a package reference to the app for the [`Microsoft.AspNet.WebApi.Client`](https://www.nuget.org/packages/Microsoft.AspNet.WebApi.Client) NuGet package.

[!INCLUDE[](~/includes/package-reference.md)]

In the service that makes a secure API request, inject the token provider and retrieve the token for the API request:

`WeatherForecastService.cs`:

```csharp
using System;
using System.Net.Http;
using System.Threading.Tasks;

public class WeatherForecastService
{
    private readonly HttpClient http;
    private readonly TokenProvider tokenProvider;

    public WeatherForecastService(IHttpClientFactory clientFactory, 
        TokenProvider tokenProvider)
    {
        http = clientFactory.CreateClient();
        this.tokenProvider = tokenProvider;
    }

    public async Task<WeatherForecast[]> GetForecastAsync()
    {
        var token = tokenProvider.AccessToken;
        using var request = new HttpRequestMessage(HttpMethod.Get, 
            "https://localhost:5003/WeatherForecast");
        request.Headers.Add("Authorization", $"Bearer {token}");
        using var response = await http.SendAsync(request);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<WeatherForecast[]>() ?? 
            Array.Empty<WeatherForecast>();
    }
}
```

For an XSRF token passed to a component, inject the `TokenProvider` and add the XSRF token to the POST request. The following example adds the token to a logout endpoint POST. The scenario for the following example is that the logout endpoint (`Areas/Identity/Pages/Account/Logout.cshtml`, [scaffolded into the app](xref:security/authentication/scaffold-identity#scaffold-identity-into-a-server-side-blazor-app)) doesn't specify an <xref:Microsoft.AspNetCore.Mvc.IgnoreAntiforgeryTokenAttribute> (`@attribute [IgnoreAntiforgeryToken]`) because it performs some action in addition to a normal logout operation that must be protected. The endpoint requires a valid XSRF token to successfully process the request.

In a component that presents a **Logout** button to authorized users:

```razor
@inject TokenProvider TokenProvider

...

<AuthorizeView>
    <Authorized>
        <form action="/Identity/Account/Logout?returnUrl=%2F" method="post">
            <button class="nav-link btn btn-link" type="submit">Logout</button>
            <input name="__RequestVerificationToken" type="hidden" 
                value="@TokenProvider.XsrfToken">
        </form>
    </Authorized>
    <NotAuthorized>
        ...
    </NotAuthorized>
</AuthorizeView>
```

:::moniker-end

## Set the authentication scheme

:::moniker range=">= aspnetcore-6.0"

For an app that uses more than one Authentication Middleware and thus has more than one authentication scheme, the scheme that Blazor uses can be explicitly set in the endpoint configuration of the `Program` file. The following example sets the OpenID Connect (OIDC) scheme:

:::moniker-end

:::moniker range="< aspnetcore-6.0"

For an app that uses more than one Authentication Middleware and thus has more than one authentication scheme, the scheme that Blazor uses can be explicitly set in the endpoint configuration of `Startup.cs`. The following example sets the OpenID Connect (OIDC) scheme:

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

```csharp
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

...

app.MapRazorComponents<App>().RequireAuthorization(
    new AuthorizeAttribute
    {
        AuthenticationSchemes = OpenIdConnectDefaults.AuthenticationScheme
    })
    .AddInteractiveServerRenderMode();
```

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-8.0"

```csharp
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

...

app.MapBlazorHub().RequireAuthorization(
    new AuthorizeAttribute 
    {
        AuthenticationSchemes = OpenIdConnectDefaults.AuthenticationScheme
    });
```

:::moniker-end

:::moniker range="< aspnetcore-5.0"

For an app that uses more than one Authentication Middleware and thus has more than one authentication scheme, the scheme that Blazor uses can be explicitly set in the endpoint configuration of `Startup.Configure`. The following example sets the Microsoft Entra ID scheme:

```csharp
endpoints.MapBlazorHub().RequireAuthorization(
    new AuthorizeAttribute 
    {
        AuthenticationSchemes = AzureADDefaults.AuthenticationScheme
    });
```

:::moniker-end

:::moniker range="< aspnetcore-5.0"

## Use OpenID Connect (OIDC) v2.0 endpoints

In versions of ASP.NET Core prior to .NET 5, the authentication library and Blazor templates use OpenID Connect (OIDC) v1.0 endpoints. To use a v2.0 endpoint with versions of ASP.NET Core prior to .NET 5, configure the <xref:Microsoft.AspNetCore.Builder.OpenIdConnectOptions.Authority?displayProperty=nameWithType> option in the <xref:Microsoft.AspNetCore.Builder.OpenIdConnectOptions>:

```csharp
services.Configure<OpenIdConnectOptions>(AzureADDefaults.OpenIdScheme, 
    options =>
    {
        options.Authority += "/v2.0";
    }
```

Alternatively, the setting can be made in the app settings (`appsettings.json`) file:

```json
{
  "AzureAd": {
    "Authority": "https://login.microsoftonline.com/common/oauth2/v2.0",
    ...
  }
}
```

If tacking on a segment to the authority isn't appropriate for the app's OIDC provider, such as with non-ME-ID providers, set the <xref:Microsoft.AspNetCore.Builder.OpenIdConnectOptions.Authority> property directly. Either set the property in <xref:Microsoft.AspNetCore.Builder.OpenIdConnectOptions> or in the app settings file with the <xref:Microsoft.AspNetCore.Builder.OpenIdConnectOptions.Authority> key.

### Code changes

* The list of claims in the ID token changes for v2.0 endpoints. Microsoft documentation on the changes has been retired, but guidance on the claims in an ID token is available in the [ID token claims reference](/entra/identity-platform/id-token-claims-reference).
* Since resources are specified in scope URIs for v2.0 endpoints, remove the <xref:Microsoft.AspNetCore.Builder.OpenIdConnectOptions.Resource?displayProperty=nameWithType> property setting in <xref:Microsoft.AspNetCore.Builder.OpenIdConnectOptions>:

  ```csharp
  services.Configure<OpenIdConnectOptions>(AzureADDefaults.OpenIdScheme, options => 
      {
          ...
          options.Resource = "...";    // REMOVE THIS LINE
          ...
      }
  ```

### App ID URI

* When using v2.0 endpoints, APIs define an *`App ID URI`*, which is meant to represent a unique identifier for the API.
* All scopes include the App ID URI as a prefix, and v2.0 endpoints emit access tokens with the App ID URI as the audience.
* When using V2.0 endpoints, the client ID configured in the Server API changes from the API Application ID (Client ID) to the App ID URI.

`appsettings.json`:

```json
{
  "AzureAd": {
    ...
    "ClientId": "https://{TENANT}.onmicrosoft.com/{PROJECT NAME}"
    ...
  }
}
```

You can find the App ID URI to use in the OIDC provider app registration description.

:::moniker-end

## Circuit handler to capture users for custom services

Use a <xref:Microsoft.AspNetCore.Components.Server.Circuits.CircuitHandler> to capture a user from the <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> and set the user in a service. If you want to update the user, register a callback to <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider.AuthenticationStateChanged> and enqueue a <xref:System.Threading.Tasks.Task> to obtain the new user and update the service. The following example demonstrates the approach.

In the following example:

* <xref:Microsoft.AspNetCore.Components.Server.Circuits.CircuitHandler.OnConnectionUpAsync%2A> is called every time the circuit reconnects, setting the user for the lifetime of the connection. Only the <xref:Microsoft.AspNetCore.Components.Server.Circuits.CircuitHandler.OnConnectionUpAsync%2A> method is required unless you implement updates via a handler for authentication changes (`AuthenticationChanged` in the following example).
* <xref:Microsoft.AspNetCore.Components.Server.Circuits.CircuitHandler.OnCircuitOpenedAsync%2A> is called to attach the authentication changed handler, `AuthenticationChanged`, to update the user. 
* The `catch` block of the `UpdateAuthentication` task takes no action on exceptions because there's no way to report the exceptions at this point in code execution. If an exception is thrown from the task, the exception is reported elsewhere in app.

`UserService.cs`:

:::moniker range=">= aspnetcore-5.0"

```csharp
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.Circuits;

public class UserService
{
    private ClaimsPrincipal currentUser = new(new ClaimsIdentity());

    public ClaimsPrincipal GetUser() => currentUser;

    internal void SetUser(ClaimsPrincipal user)
    {
        if (currentUser != user)
        {
            currentUser = user;
        }
    }
}

internal sealed class UserCircuitHandler(
        AuthenticationStateProvider authenticationStateProvider,
        UserService userService) 
        : CircuitHandler, IDisposable
{
    public override Task OnCircuitOpenedAsync(Circuit circuit, 
        CancellationToken cancellationToken)
    {
        authenticationStateProvider.AuthenticationStateChanged += 
            AuthenticationChanged;

        return base.OnCircuitOpenedAsync(circuit, cancellationToken);
    }

    private void AuthenticationChanged(Task<AuthenticationState> task)
    {
        _ = UpdateAuthentication(task);

        async Task UpdateAuthentication(Task<AuthenticationState> task)
        {
            try
            {
                var state = await task;
                userService.SetUser(state.User);
            }
            catch
            {
            }
        }
    }

    public override async Task OnConnectionUpAsync(Circuit circuit, 
        CancellationToken cancellationToken)
    {
        var state = await authenticationStateProvider.GetAuthenticationStateAsync();
        userService.SetUser(state.User);
    }

    public void Dispose()
    {
        authenticationStateProvider.AuthenticationStateChanged -= 
            AuthenticationChanged;
    }
}
```

:::moniker-end

:::moniker range="< aspnetcore-5.0"

```csharp
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.Circuits;

public class UserService
{
    private ClaimsPrincipal currentUser = new ClaimsPrincipal(new ClaimsIdentity());

    public ClaimsPrincipal GetUser()
    {
        return currentUser;
    }

    internal void SetUser(ClaimsPrincipal user)
    {
        if (currentUser != user)
        {
            currentUser = user;
        }
    }
}

internal sealed class UserCircuitHandler : CircuitHandler, IDisposable
{
    private readonly AuthenticationStateProvider authenticationStateProvider;
    private readonly UserService userService;

    public UserCircuitHandler(
        AuthenticationStateProvider authenticationStateProvider,
        UserService userService)
    {
        this.authenticationStateProvider = authenticationStateProvider;
        this.userService = userService;
    }

    public override Task OnCircuitOpenedAsync(Circuit circuit, 
        CancellationToken cancellationToken)
    {
        authenticationStateProvider.AuthenticationStateChanged += 
            AuthenticationChanged;

        return base.OnCircuitOpenedAsync(circuit, cancellationToken);
    }

    private void AuthenticationChanged(Task<AuthenticationState> task)
    {
        _ = UpdateAuthentication(task);

        async Task UpdateAuthentication(Task<AuthenticationState> task)
        {
            try
            {
                var state = await task;
                userService.SetUser(state.User);
            }
            catch
            {
            }
        }
    }

    public override async Task OnConnectionUpAsync(Circuit circuit, 
        CancellationToken cancellationToken)
    {
        var state = await authenticationStateProvider.GetAuthenticationStateAsync();
        userService.SetUser(state.User);
    }

    public void Dispose()
    {
        authenticationStateProvider.AuthenticationStateChanged -= 
            AuthenticationChanged;
    }
}
```

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

In the `Program` file:

```csharp
using Microsoft.AspNetCore.Components.Server.Circuits;
using Microsoft.Extensions.DependencyInjection.Extensions;

...

builder.Services.AddScoped<UserService>();
builder.Services.TryAddEnumerable(
    ServiceDescriptor.Scoped<CircuitHandler, UserCircuitHandler>());
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

In `Startup.ConfigureServices` of `Startup.cs`:

```csharp
using Microsoft.AspNetCore.Components.Server.Circuits;
using Microsoft.Extensions.DependencyInjection.Extensions;

...

services.AddScoped<UserService>();
services.TryAddEnumerable(
    ServiceDescriptor.Scoped<CircuitHandler, UserCircuitHandler>());
```

:::moniker-end

Use the service in a component to obtain the user:

```razor
@inject UserService UserService

<h1>Hello, @(UserService.GetUser().Identity?.Name ?? "world")!</h1>
```

To set the user in middleware for MVC, Razor Pages, and in other ASP.NET Core scenarios, call `SetUser` on the `UserService` in custom middleware after the Authentication Middleware runs, or set the user with an <xref:Microsoft.AspNetCore.Authentication.IClaimsTransformation> implementation. The following example adopts the middleware approach.

`UserServiceMiddleware.cs`:

```csharp
public class UserServiceMiddleware
{
    private readonly RequestDelegate next;

    public UserServiceMiddleware(RequestDelegate next)
    {
        this.next = next ?? throw new ArgumentNullException(nameof(next));
    }

    public async Task InvokeAsync(HttpContext context, UserService service)
    {
        service.SetUser(context.User);
        await next(context);
    }
}
```

:::moniker range=">= aspnetcore-8.0"

Immediately before the call to `app.MapRazorComponents<App>()` in the `Program` file, call the middleware:

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

Immediately before the call to `app.MapBlazorHub()` in the `Program` file, call the middleware:

:::moniker-end

:::moniker range="< aspnetcore-6.0"

Immediately before the call to `app.MapBlazorHub()` in `Startup.Configure` of `Startup.cs`, call the middleware:

:::moniker-end

```csharp
app.UseMiddleware<UserServiceMiddleware>();
```

:::moniker range=">= aspnetcore-8.0"

## Access `AuthenticationStateProvider` in outgoing request middleware

<xref:System.Net.Http.IHttpClientFactory> creates <xref:System.Net.Http.DelegatingHandler> instances in a separate dependency injection (DI) scope from the app. If you inject <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> into a derived <xref:System.Net.Http.DelegatingHandler> type, the handler doesn't have access to the current user's authentication state from the Blazor circuit.

Use either of the following approaches to address this scenario:

* [Application scope handler](#application-scope-handler-recommended) (*Recommended*)
* [Circuit activity handler](#circuit-activity-handler)

> [!NOTE]
> For general guidance on defining delegating handlers for HTTP requests by <xref:System.Net.Http.HttpClient> instances created using <xref:System.Net.Http.IHttpClientFactory>, see the following sections of <xref:fundamentals/http-requests>:
>
> * [Outgoing request middleware](xref:fundamentals/http-requests#outgoing-request-middleware)
> * [Use DI in outgoing request middleware](xref:fundamentals/http-requests#use-di-in-outgoing-request-middleware)

The examples in the following subsections attach a custom user name header for authenticated users to outgoing requests.

### Application scope handler (*Recommended*)

The approach in this section uses a [keyed service](xref:fundamentals/dependency-injection#keyed-services) to register a custom <xref:System.Net.Http.HttpClient> that wraps the base client with an application scope handler resolved from the current application scope to access <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider>.

Overview of the approach:

* Base client configuration: <xref:Microsoft.Extensions.DependencyInjection.HttpClientFactoryServiceCollectionExtensions.AddHttpClient%2A> is called to register a [named client](xref:blazor/call-web-api#named-httpclient-with-ihttpclientfactory) with <xref:System.Net.Http.IHttpClientFactory>.
* Keyed registration: A custom `AddApplicationScopeHandler` extension method registers a keyed <xref:System.Net.Http.HttpClient> with the same client name.
* Scope-aware handler: The application scope handler is resolved from the current scope, giving it access to <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider>.
* Handler caching: The application scope handler uses <xref:System.Net.Http.IHttpMessageHandlerFactory> to get the cached <xref:System.Net.Http.HttpMessageHandler>, which preserves connection pooling.
* Configuration reuse: The application scope handler applies the same <xref:Microsoft.Extensions.Http.HttpClientFactoryOptions> configuration to its <xref:System.Net.Http.HttpClient> as the base client.

Create the following methods and classes:

* `AddApplicationScopeHandler`: An extension method to add the application scope handler and a keyed <xref:System.Net.Http.HttpClient> service to the DI container.
* `ApplicationScopeHandler`: The application scope handler class.
* `AuthenticationStateHandler`: A <xref:System.Net.Http.DelegatingHandler> that attaches a custom user name header for authenticated users to outgoing requests.

`Services/ApplicationScopeHttpClientExtensions.cs`:

```csharp
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Http;
using Microsoft.Extensions.Options;

namespace BlazorSample.Services;

public static class ApplicationScopeHttpClientExtensions
{
    public static readonly HttpRequestOptionsKey<IServiceProvider> ScopeKey = 
        new("ApplicationScope");

    public static IHttpClientBuilder AddApplicationScopeHandler(
        this IHttpClientBuilder builder)
    {
        var name = builder.Name;

        builder.Services.AddTransient<ApplicationScopeHandler>();

        builder.Services.AddKeyedScoped<HttpClient>(name, (sp, key) =>
        {
            var handler = sp.GetRequiredService<ApplicationScopeHandler>();
            handler.InnerHandler = 
                sp.GetRequiredService<IHttpMessageHandlerFactory>()
                .CreateHandler(name);

            var client = new HttpClient(handler, disposeHandler: false);

            var options = 
                sp.GetRequiredService<IOptionsMonitor<HttpClientFactoryOptions>>()
                .Get(name);

            foreach (var action in options.HttpClientActions)
            {
                action(client);
            }

            return client;
        });

        return builder;
    }
}

public class ApplicationScopeHandler(IServiceProvider serviceProvider) 
    : DelegatingHandler
{
    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        request.Options.Set(ApplicationScopeHttpClientExtensions.ScopeKey, 
            serviceProvider);
        return base.SendAsync(request, cancellationToken);
    }
}

public class AuthenticationStateHandler : DelegatingHandler
{
    private ClaimsPrincipal? user;

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        if (user is null)
        {
            if (request.Options.TryGetValue(
                ApplicationScopeHttpClientExtensions.ScopeKey, out var sp))
            {
                var authStateProvider = sp.GetService<AuthenticationStateProvider>();

                if (authStateProvider is not null)
                {
                    user = (await authStateProvider.GetAuthenticationStateAsync())
                        .User;
                }
            }
        }

        if (user?.Identity?.IsAuthenticated)
        {
            request.Headers.TryAddWithoutValidation("X-USER-IDENTITY-NAME", 
                user.Identity.Name);
        }

        return await base.SendAsync(request, cancellationToken);
    }
}
```

The `AuthenticationStateHandler` in the preceding example caches the user for the lifetime of the <xref:System.Net.Http.DelegatingHandler>. To fetch the user's current authentication state for each request, remove the `null` conditional check on the user.

Register the named client in the `Program` file, calling `AddApplicationScopeHandler` to add the application scope handler:

```csharp
builder.Services.AddHttpClient("ExternalApi", client =>
{
    client.BaseAddress = new Uri("{REQUEST URI}");
})
.AddApplicationScopeHandler()
.AddHttpMessageHandler<AuthenticationStateHandler>();
```

The `{REQUEST URI}` placeholder in the preceding example is the request URI (localhost example: `http://localhost:5209`).

Inject the client into components using the keyed service:

```razor
@using Microsoft.Extensions.DependencyInjection

@code {
    [Inject(Key = "ExternalApi")]
    public HttpClient Http { get; set; } = default!;

    private async Task CallApiAsync()
    {
        var response = await Http.GetAsync("/api/endpoint");
    }
}
```

### Circuit activity handler

The approach in this section uses a [circuit activity handler](xref:blazor/fundamentals/signalr#monitor-circuit-activity-blazor-server) to access the <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider>, which is an alternative to the recommended [application scope handler approach](#application-scope-handler-recommended) in the preceding section.

First, implement the `CircuitServicesAccessor` class in the following section of the Blazor dependency injection (DI) article:

[Access server-side Blazor services from a different DI scope](xref:blazor/fundamentals/dependency-injection#access-server-side-blazor-services-from-a-different-di-scope)

Use the `CircuitServicesAccessor` to access the <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> in the <xref:System.Net.Http.DelegatingHandler> implementation.

`AuthenticationStateHandler.cs`:

```csharp
using Microsoft.AspNetCore.Components.Authorization;

public class AuthenticationStateHandler(
    CircuitServicesAccessor circuitServicesAccessor) 
    : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var authStateProvider = circuitServicesAccessor.Services?
            .GetRequiredService<AuthenticationStateProvider>();

        if (authStateProvider is null)
        {
            throw new Exception("AuthenticationStateProvider not available");
        }

        var authState = await authStateProvider.GetAuthenticationStateAsync();

        var user = authState?.User;

        if (user?.Identity is not null && user.Identity.IsAuthenticated)
        {
            request.Headers.Add("X-USER-IDENTITY-NAME", user.Identity.Name);
        }

        return await base.SendAsync(request, cancellationToken);
    }
}
```

In the `Program` file, register the `AuthenticationStateHandler` and add the handler to the <xref:System.Net.Http.IHttpClientFactory> that creates <xref:System.Net.Http.HttpClient> instances:

```csharp
builder.Services.AddTransient<AuthenticationStateHandler>();

builder.Services.AddHttpClient("HttpMessageHandler")
    .AddHttpMessageHandler<AuthenticationStateHandler>();
```

:::moniker-end

## Opaque (reference) access token support

The guidance in this section explains how to implement opaque (reference) access token support, which offers the following advantages over JSON Web Tokens (JWTs):

* Strict revocation: Invalidate access tokens at any time before they naturally expire.
* Token size limits: Store a large number of user claims in the token to avoid a prohibitively large JWT.
* Security: Prevent API consumers or third parties from reading access token claims.

> [!NOTE]
> The following guidance requires an authentication server that supports opaque (reference) access tokens. Currently, Microsoft Entra doesn't support opaque access token validation. [Keycloak](https://www.keycloak.org/) and [Okta](https://developer.okta.com/code/) issue JWT access tokens by default. The opaque token handler in this section still works against Keycloak and Okta because it relies only on RFC 7662 introspection. "Opaque" in this section describes how the client treats the token rather than how the server mints it. Alternatively, [Duende IdentityServer](https://duendesoftware.com/products/identityserver) can be configured to only issue opaque tokens.
>
> When testing this pattern against Keycloak, the API's introspection client must be a different OIDC client than the one that issued the user's access token. Introspecting a token using the client that minted it returns `{"active": false}` with "`Access token JWT check failed`" in the server's log. This doesn't happen naturally for the following scenario because the Blazor Web App and the Minimal API (`MinimalApiJwt`) are separate clients.

<xref:Microsoft.Extensions.DependencyInjection.OpenIdConnectExtensions.AddOpenIdConnect%2A> supports opaque tokens because it doesn't perform access token validation when configured for Proof Key for Code Exchange (PKCE) authorization code flow. It relies on the ASP.NET Core server's HTTPS backchannel to the OIDC authentication service to obtain the ID token using the authorization code received when the user redirects back to the ASP.NET Core app after signing in. If the app is only required to log a user in with OIDC to get a valid authentication cookie, opaque access tokens are supported without modifying the app.

A failure occurs only when the opaque token acquired by <xref:Microsoft.Extensions.DependencyInjection.OpenIdConnectExtensions.AddOpenIdConnect%2A> is passed to another service that attempts to validate it with <xref:Microsoft.Extensions.DependencyInjection.JwtBearerExtensions.AddJwtBearer%2A>. Unlike self-contained JWTs, opaque tokens require a request to an authorization server to validate the status and to retrieve the claims. To work around this limitation, either use a third-party API, such as the [Duende Introspection Authentication Handler](https://docs.duendesoftware.com/introspection/), or create a [custom `AuthenticationHandler`](xref:security/authentication/index#authentication-handler) to validate the token.

> [!IMPORTANT]
> [Duende Software](https://duendesoftware.com/) and [Okta](https://www.okta.com) aren't owned or controlled by Microsoft and might require you to pay a license fee for production use of their services and libraries.

The following <xref:Microsoft.AspNetCore.Authentication.AuthenticationHandler%601> and associated configuration and helper code is provided as a general approach, which might require further development to suit a specific authorization server's requirements. The following handler extracts the opaque token from the `Authorization` header for an HTTP call to an authorization server's introspection endpoint and creates an <xref:Microsoft.AspNetCore.Authentication.AuthenticationTicket> containing the user's claims.

Calling an authorization server's introspection endpoint requires authentication. The following example relies on setting the client secret for authentication in the request's Authorization header (base64 encoded credentials) using the [Secret Manager tool](xref:security/app-secrets) for local development and testing.

[!INCLUDE[](~/blazor/security/includes/secure-authentication-flows.md)]

In the following handler, the authorization server's introspection endpoint client secret uses the configuration key `Authentication:Schemes:OpaqueTokenAuthentication:ClientSecret`. For production apps, consider using *client assertions*. For more information, see [Confidential client assertions (Microsoft Entra documentation)](/entra/msal/dotnet/acquiring-tokens/web-apps-apis/confidential-client-assertions).

If the Blazor server project hasn't been initialized for the Secret Manager tool, use a command shell, such as the Developer PowerShell command shell in Visual Studio, to execute the following command. Before executing the command, change the directory with the `cd` command to the server project's directory. The command establishes a user secrets identifier (`<UserSecretsId>` in the server app's project file):

```dotnetcli
dotnet user-secrets init
```

Execute the following command to set the client secret for the authorization server. The `{SECRET}` placeholder is the client secret:

```dotnetcli
dotnet user-secrets set "Authentication:Schemes:OpaqueTokenAuthentication:ClientSecret" "{SECRET}"
```

If using Visual Studio, you can confirm the secret is set by right-clicking the server project in **Solution Explorer** and selecting **Manage User Secrets**.

`Extensions/HttpRequestExtensions.cs`:

```csharp
namespace MinimalApiJwt.Extensions;

public static class HttpRequestExtensions
{
    public static string? ExtractBearerToken(this HttpRequest request)
    {
        var authorizationHeader = request.Headers.Authorization.ToString();

        if (!string.IsNullOrEmpty(authorizationHeader) && 
            authorizationHeader.StartsWith("Bearer ", 
            StringComparison.OrdinalIgnoreCase))
        {
            var token = authorizationHeader["Bearer ".Length..].Trim();

            if (!string.IsNullOrEmpty(token))
            {
                return token;
            }
        }

        return null;
    }
}
```

`Authentication/OpaqueTokenAuthenticationOptions.cs`:

```csharp
using Microsoft.AspNetCore.Authentication;

namespace MinimalApiJwt.Authentication;

public class OpaqueTokenAuthenticationOptions : AuthenticationSchemeOptions
{
    public const string DefaultScheme = "OpaqueTokenAuthentication";
    public string? IntrospectionEndpoint { get; set; }
    public string? ClientId { get; set; }
    public string? ClientSecret { get; set; }
}
```

The following handler attempts to validate an opaque (reference) access token. An HTTP call is made to the authorization server's introspection endpoint with the token and the API's credentials. The response is processed to determine if the token is valid:

* If the token is valid, an <xref:Microsoft.AspNetCore.Authentication.AuthenticationTicket> is created containing the user's claims.
* If the token is invalid, a failed authorization result is returned.

The handler's options (`Options`) is an instance of `OpaqueTokenAuthenticationOptions` provided by the <xref:Microsoft.AspNetCore.Authentication.AuthenticationHandler%601> base type, which is configured in the app's `Program` file with the authorization server's introspection endpoint and the API's client ID. The API's client secret is provided by the Secret Manager tool during development.

`IOptionsMonitor<OpaqueTokenAuthenticationOptions>` (`optionsMonitor`) isn't used directly by the handler, but it could be used to support dynamic configuration changes at runtime.

For the request's content in <xref:System.Net.Http.FormUrlEncodedContent>, some servers require a token type hint (`token_type_hint`). For example, the required value might be `access_token`. See your authentication server's documentation for details.

`Authentication/OpaqueTokenAuthenticationHandler.cs`:

```csharp
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using MinimalApiJwt.Extensions;

namespace MinimalApiJwt.Authentication;

public class OpaqueTokenAuthenticationHandler(
    IOptionsMonitor<OpaqueTokenAuthenticationOptions> optionsMonitor,
    ILoggerFactory logger,
    UrlEncoder encoder,
    IHttpClientFactory httpClientFactory)
    : AuthenticationHandler<OpaqueTokenAuthenticationOptions>(optionsMonitor, 
        logger, encoder)
{
    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var opaqueToken = Request.ExtractBearerToken();

        if (opaqueToken is null)
        {
            var failedResult = AuthenticateResult.Fail(
                "Bearer token not found in Authorization header.");
            return failedResult;
        }

        var introspectionUri = Options.IntrospectionEndpoint;
        var clientId = Options.ClientId;
        var clientSecret = Options.ClientSecret;

        if (string.IsNullOrWhiteSpace(introspectionUri) ||
            string.IsNullOrWhiteSpace(clientId) ||
            string.IsNullOrWhiteSpace(clientSecret))
        {
            var failedResult = AuthenticateResult.Fail(
                "Opaque token authentication isn't fully configured.");
            return failedResult;
        }

        using var client = httpClientFactory.CreateClient();

        // Set the Authorization header (base64 encoded credentials)
        var authString = Convert.ToBase64String(
            System.Text.Encoding.ASCII.GetBytes($"{clientId}:{clientSecret}"));
        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Basic", authString);

        // Prepare the form-encoded body containing the token
        var content = new FormUrlEncodedContent(
        [
            new KeyValuePair<string, string>("token", opaqueToken)
        ]);

        // Post to the introspection endpoint
        var response = await client.PostAsync(introspectionUri, content);

        if (!response.IsSuccessStatusCode)
        {
            var failedResult = AuthenticateResult.Fail(
                "Introspection endpoint failure.");

            return failedResult;
        }

        // Parse the JSON response
        var responseString = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(responseString);

        // The 'active' property determines if the token is valid and not expired
        var tokenIsValid = 
            doc.RootElement.TryGetProperty("active", out var activeProperty) &&
            activeProperty.ValueKind == JsonValueKind.True;

        if (tokenIsValid)
        {
            // Map standard introspection response fields onto claims.
            // Field names below match what Keycloak, Duende IdentityServer,
            // Auth0, and Okta return; adjust the role source for your provider.
            var claims = new List<Claim>();

            string? Get(string name) =>
                doc.RootElement.TryGetProperty(name, out var v) &&
                v.ValueKind == JsonValueKind.String ? v.GetString() : null;

            var sub = Get("sub");
            var username = Get("preferred_username") ?? Get("username") ?? sub;

            if (sub is not null) claims.Add(new Claim(ClaimTypes.NameIdentifier, sub));
            if (username is not null) claims.Add(new Claim(ClaimTypes.Name, username));
            if (Get("email") is { } email) claims.Add(new Claim(ClaimTypes.Email, email));
            if ((Get("client_id") ?? Get("azp")) is { } cid)
                claims.Add(new Claim("client_id", cid));
            if (Get("scope") is { } scope)
                foreach (var s in scope.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                    claims.Add(new Claim("scope", s));

            // Keycloak surfaces realm roles under realm_access.roles.
            // Duende/IdentityServer uses a flat "role" claim; Auth0 uses a
            // configurable custom claim. Adjust for your authorization server.
            if (doc.RootElement.TryGetProperty("realm_access", out var ra) &&
                ra.ValueKind == JsonValueKind.Object &&
                ra.TryGetProperty("roles", out var roles) &&
                roles.ValueKind == JsonValueKind.Array)
            {
                foreach (var r in roles.EnumerateArray())
                    if (r.ValueKind == JsonValueKind.String)
                        claims.Add(new Claim(ClaimTypes.Role, r.GetString()!));
            }

            var identity = new ClaimsIdentity(claims,
                OpaqueTokenAuthenticationOptions.DefaultScheme,
                nameType: ClaimTypes.Name,
                roleType: ClaimTypes.Role);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal,
                OpaqueTokenAuthenticationOptions.DefaultScheme);

            var result = AuthenticateResult.Success(ticket);

            return result;
        }
        else
        {
            var failedResult = AuthenticateResult.Fail("Bearer token invalid.");

            return failedResult;
        }
    }
}
```

> [!NOTE]
> The preceding approach can be further improved by using the OpenID Connect discovery endpoint and adding a cache for the client's <xref:System.Net.Http.HttpClient> introspection requests.

In the `Program` file:

```csharp
using MinimalApiJwt.Authentication;

...

builder.Services.AddHttpClient();
builder.Services.AddAuthentication()
    .AddScheme<OpaqueTokenAuthenticationOptions, OpaqueTokenAuthenticationHandler>(
        OpaqueTokenAuthenticationOptions.DefaultScheme,
        options =>
        {
            options.IntrospectionEndpoint = "{AUTH SERVER INTROSPECTION URI}";
            options.ClientId = "{API CLIENT ID}";
            options.ClientSecret = 
                builder.Configuration[
                    "Authentication:Schemes:OpaqueTokenAuthentication:ClientSecret"];
        });
```

The preceding example's placeholders:

* `{AUTH SERVER INTROSPECTION URI}`: Authentication server's introspection URI
* `{API CLIENT ID}`: API client ID

Values for the authentication server introspection URI (`{AUTH SERVER INTROSPECTION URI}`) and the API client ID (`{API CLIENT ID}`) can be supplied from app settings or any other configuration source.

Tokens are typically invalidated on a logout event using the revocation endpoint. The following example is a starting point for further development:

```csharp
app.MapPost("/logout", 
    async ([FromForm] string? returnUrl, HttpContext context, 
    IHttpClientFactory httpClientFactory) =>
{
    var accessToken = await context.GetTokenAsync("access_token");

    if (!string.IsNullOrEmpty(accessToken))
    {
        // Prepare the revocation request (RFC 7009)
        var content = 
            new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "token", accessToken },
                { "token_type_hint", "access_token" },
                { "client_id", "{API CLIENT ID}" },
                { "client_secret", "{CLIENT SECRET}" }
            });

        // POST to the revocation endpoint
        using var client = httpClientFactory.CreateClient();
        await client.PostAsync("{AUTH SERVER TOKEN REVOCATION URI}", content);
    }

    return TypedResults.SignOut(new AuthenticationProperties { RedirectUri = "{REDIRECT URI}" }, 
        [CookieAuthenticationDefaults.AuthenticationScheme]);
});
```

The preceding example's placeholders:

* `{AUTH SERVER TOKEN REVOCATION URI}`: The authentication server's token revocation URI.
* `{API CLIENT ID}`: The API client ID.
* `{CLIENT SECRET}`: The client secret obtained securely.
* `{REDIRECT URI}`: The redirect URI.

In [Duende IdentityServer](https://duendesoftware.com/products/identityserver), tokens are revoked automatically by setting the `CoordinateLifetimeWithUserSession` client configuration property to `true`, which automatically cleans up associated tokens when a session ends. For more information, see [Session Cleanup and Logout (Duende documentation)](https://docs.duendesoftware.com/identityserver/ui/logout/session-cleanup/).

Built-in opaque access token support is under consideration for a future release of .NET. For more information, see [Opaque - reference token validation (`dotnet/aspnetcore` #46026)](https://github.com/dotnet/aspnetcore/issues/46026).
