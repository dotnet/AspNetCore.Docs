---
title: Server-side ASP.NET Core Blazor additional security scenarios
author: guardrex
description: Learn how to configure server-side Blazor for additional security scenarios.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/14/2023
uid: blazor/security/server/additional-scenarios
---
# Server-side ASP.NET Core Blazor additional security scenarios

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how to configure server-side Blazor for additional security scenarios, including how to pass tokens to a Blazor app.

[!INCLUDE[](~/blazor/includes/location-client-and-server-pre-net8.md)]

> [!NOTE]
> The code examples in this article adopt [nullable reference types (NRTs) and .NET compiler null-state static analysis](xref:migration/50-to-60#nullable-reference-types-nrts-and-net-compiler-null-state-static-analysis), which are supported in ASP.NET Core 6.0 or later. When targeting ASP.NET Core 5.0 or earlier, remove the null type designation (`?`) from the `string?`, `TodoItem[]?`, `WeatherForecast[]?`, and `IEnumerable<GitHubBranch>?` types in the article's examples.

## Pass tokens to a server-side Blazor app

:::moniker range=">= aspnetcore-8.0"

<!-- UPDATE 8.0 Halter touched on this at ...
     https://github.com/dotnet/aspnetcore/issues/52390#issuecomment-1856949854
     Let's get a review of this section.
-->

Tokens available outside of the Razor components in a server-side Blazor app can be passed to components with the approach described in this section. The example in this section focuses on passing access and refresh tokens, but the approach is valid for other HTTP context state provided by <xref:Microsoft.AspNetCore.Http.HttpContext>.

> [!NOTE]
> Passing the [anti-request forgery (CSRF/XSRF) token](xref:security/anti-request-forgery) to Razor components is useful in scenarios where components POST to Identity or other endpoints that require validation. However, don't follow the guidance in this section for processing form POST requests or web API requests with XSRF support. The Blazor framework provides built-in antiforgery support for forms and calling web APIs. For more information, see the following resources:
>
> * General support for antiforgery: <xref:blazor/security/index#antiforgery-support>
> * Antiforgery support for forms: <xref:blazor/forms/index#antiforgery-support>
> * Antiforgery support for web API: <xref:blazor/call-web-api#antiforgery-support>

Authenticate the app as you would with a regular Razor Pages or MVC app. Provision and save the tokens to the authentication cookie.

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

    options.Scope.Add("offline_access");
});
```

> [!NOTE]
> <xref:Microsoft.AspNetCore.Authentication.OpenIdConnect?displayProperty=fullName> and <xref:Microsoft.IdentityModel.Protocols.OpenIdConnect?displayProperty=fullName> API is provided by the [`Microsoft.AspNetCore.Authentication.OpenIdConnect`](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.OpenIdConnect) NuGet package.
>
> [!INCLUDE[](~/includes/package-reference.md)]

Optionally, additional scopes are added with `options.Scope.Add("{SCOPE}");`, where the placeholder `{SCOPE}` is the additional scope to add.

Define a token provider service that can be used within the Blazor app to resolve the tokens from [dependency injection (DI)](xref:blazor/fundamentals/dependency-injection).

`TokenProvider.cs`:

```csharp
public class TokenProvider
{
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }
}
```

In the `Program` file, add services for:

* <xref:System.Net.Http.IHttpClientFactory>: Used in service classes to obtain data from a server API with an access token. The example in this section is a weather forecast data service (`WeatherForecastService`) that requires an access token.
* `TokenProvider`: Holds the access and refresh tokens. Register the token provider service as a ***scoped*** service.

```csharp
builder.Services.AddHttpClient();
builder.Services.AddScoped<TokenProvider>();
```

In the `App` component (`Components/App.razor`), resolve the service and initialize it with the data from [`HttpContext` as a cascaded parameter](xref:blazor/security/index#avoid-ihttpcontextaccessorhttpcontext-in-razor-components):

```razor
@inject TokenProvider TokenProvider

...

@code {
    [CascadingParameter]
    public HttpContext? HttpContext { get; set; }

    protected override Task OnInitializedAsync()
    {
        TokenProvider.AccessToken = await HttpContext.GetTokenAsync("access_token");
        TokenProvider.RefreshToken = await HttpContext.GetTokenAsync("refresh_token");

        return base.OnInitializedAsync();
    }
}
```

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
        var request = new HttpRequestMessage(HttpMethod.Get, 
            "https://localhost:5003/WeatherForecast");
        request.Headers.Add("Authorization", $"Bearer {token}");
        var response = await http.SendAsync(request);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<WeatherForecast[]>() ?? 
            Array.Empty<WeatherForecast>();
    }
}
```

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

    options.Scope.Add("offline_access");
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

    options.Scope.Add("offline_access");
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

    options.Scope.Add("offline_access");
});
```

:::moniker-end

:::moniker range="< aspnetcore-8.0"

Optionally, additional scopes are added with `options.Scope.Add("{SCOPE}");`, where the placeholder `{SCOPE}` is the additional scope to add.

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
        var request = new HttpRequestMessage(HttpMethod.Get, 
            "https://localhost:5003/WeatherForecast");
        request.Headers.Add("Authorization", $"Bearer {token}");
        var response = await http.SendAsync(request);
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

In versions of ASP.NET Core prior to 5.0, the authentication library and Blazor templates use OpenID Connect (OIDC) v1.0 endpoints. To use a v2.0 endpoint with versions of ASP.NET Core prior to 5.0, configure the <xref:Microsoft.AspNetCore.Builder.OpenIdConnectOptions.Authority?displayProperty=nameWithType> option in the <xref:Microsoft.AspNetCore.Builder.OpenIdConnectOptions>:

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
    "Authority": "https://login.microsoftonline.com/common/oauth2/v2.0/",
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

Use a <xref:Microsoft.AspNetCore.Components.Server.Circuits.CircuitHandler> to capture a user from the <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> and set the user in a service. If you want to update the user, register a callback to <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider.AuthenticationStateChanged> and queue a <xref:System.Threading.Tasks.Task> to obtain the new user and update the service. The following example demonstrates the approach.

In the following example:

* <xref:Microsoft.AspNetCore.Components.Server.Circuits.CircuitHandler.OnConnectionUpAsync%2A> is called every time the circuit reconnects, setting the user for the lifetime of the connection. Only the <xref:Microsoft.AspNetCore.Components.Server.Circuits.CircuitHandler.OnConnectionUpAsync%2A> method is required unless you implement updates via a handler for authentication changes (`AuthenticationChanged` in the following example).
* <xref:Microsoft.AspNetCore.Components.Server.Circuits.CircuitHandler.OnCircuitOpenedAsync%2A> is called to attach the authentication changed handler, `AuthenticationChanged`, to update the user. 
* The `catch` block of the `UpdateAuthentication` task takes no action on exceptions because there's no way to report them at this point in code execution. If an exception is thrown from the task, the exception is reported elsewhere in app.

`UserService.cs`:

:::moniker range=">= aspnetcore-5.0"

```csharp
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.Circuits;

public class UserService
{
    private ClaimsPrincipal currentUser = new(new ClaimsIdentity());

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

The <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> from a <xref:System.Net.Http.DelegatingHandler> for <xref:System.Net.Http.HttpClient> created with <xref:System.Net.Http.IHttpClientFactory> can be accessed in outgoing request middleware using a [circuit activity handler](xref:blazor/fundamentals/signalr#monitor-circuit-activity-blazor-server).

> [!NOTE]
> For general guidance on defining delegating handlers for HTTP requests by <xref:System.Net.Http.HttpClient> instances created using <xref:System.Net.Http.IHttpClientFactory> in ASP.NET Core apps, see the following sections of <xref:fundamentals/http-requests>:
>
> * [Outgoing request middleware](xref:fundamentals/http-requests#outgoing-request-middleware)
> * [Use DI in outgoing request middleware](xref:fundamentals/http-requests#use-di-in-outgoing-request-middleware)

The following example uses <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> to attach a custom user name header for authenticated users to outgoing requests.

First, implement the `CircuitServicesAccessor` class in the following section of the Blazor dependency injection (DI) article:

[Access server-side Blazor services from a different DI scope](xref:blazor/fundamentals/dependency-injection#access-server-side-blazor-services-from-a-different-di-scope)

Use the `CircuitServicesAccessor` to access the <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> in the <xref:System.Net.Http.DelegatingHandler> implementation.

`AuthenticationStateHandler.cs`:

```csharp
public class AuthenticationStateHandler : DelegatingHandler
{
    readonly CircuitServicesAccessor circuitServicesAccessor;

    public AuthenticationStateHandler(
        CircuitServicesAccessor circuitServicesAccessor)
    {
        this.circuitServicesAccessor = circuitServicesAccessor;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var authStateProvider = circuitServicesAccessor.Services
            .GetRequiredService<AuthenticationStateProvider>();
        var authState = await authStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        if (user.Identity is not null && user.Identity.IsAuthenticated)
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
