---
title: ASP.NET Core server-side and Blazor Web App additional security scenarios
author: guardrex
description: Learn how to configure server-side Blazor and Blazor Web Apps for additional security scenarios.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/12/2024
uid: blazor/security/additional-scenarios
---
# ASP.NET Core server-side and Blazor Web App additional security scenarios

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how to configure server-side Blazor for additional security scenarios, including how to pass tokens to a Blazor app.

> [!NOTE]
> The code examples in this article adopt [nullable reference types (NRTs) and .NET compiler null-state static analysis](xref:migration/50-to-60#nullable-reference-types-nrts-and-net-compiler-null-state-static-analysis), which are supported in ASP.NET Core in .NET 6 or later. When targeting ASP.NET Core 5.0 or earlier, remove the null type designation (`?`) from the `string?`, `TodoItem[]?`, `WeatherForecast[]?`, and `IEnumerable<GitHubBranch>?` types in the article's examples.

## Pass tokens to a server-side Blazor app

:::moniker range=">= aspnetcore-8.0"

*This section applies to Blazor Web Apps. For Blazor Server, view the [7.0 version of this article section](xref:blazor/security/additional-scenarios?view=aspnetcore-7.0&preserve-view=true#pass-tokens-to-a-server-side-blazor-app).*

Tokens available outside of a Blazor Web App's Razor components can be passed to interactive components with the approaches described in this section. The examples in this section focus on passing JWT access tokens for secure web API access, but the approaches are valid for other HTTP context state provided by <xref:Microsoft.AspNetCore.Http.HttpContext>.

### Sample app demonstration

For a demonstration of the guidance in this section, see the `BlazorWebAppOidcServer` sample app (.NET 8 or later) in the [Blazor samples](https://github.com/dotnet/blazor-samples) repository. The sample is a Blazor Web App with global Interactive Server interactivity that uses OIDC authentication with Microsoft Entra without using Entra-specific packages. The sample demonstrates how to pass a JWT access token to call a secure web API.

### Reading tokens from `HttpContext`

Reading tokens from the <xref:Microsoft.AspNetCore.Http.HttpContext> using <xref:Microsoft.AspNetCore.Http.IHttpContextAccessor> is a reasonable approach for obtaining tokens for use during interactive server rendering if the tokens are obtained during static server-side rendering (static SSR) or prerendering. However, tokens aren't updated if the user authenticates after the circuit is established, since the <xref:Microsoft.AspNetCore.Http.HttpContext> is captured at the start of the SignalR connection. Also, the use of <xref:System.Threading.AsyncLocal%601> by <xref:Microsoft.AspNetCore.Http.IHttpContextAccessor> means that you must be careful not to lose the execution context before reading the <xref:Microsoft.AspNetCore.Http.HttpContext>.

Note that <xref:Microsoft.AspNetCore.Http.HttpContext> used as a [cascading parameter](xref:Microsoft.AspNetCore.Components.CascadingParameterAttribute) is only populated in statically-rendered root components or during static SSR/prerendering, which limits the usefulness of supplying <xref:Microsoft.AspNetCore.Http.HttpContext> as a cascading parameter when trying to pass tokens and other properties in Razor component code.

For more information, see <xref:blazor/components/httpcontext>.

### Token handler example for web API calls

The following approach is aimed at attaching a user's access token to outgoing requests, specifically to make web API calls to external web API apps. The approach is shown for a Blazor Web App that adopts global Interactive Server rendering, but the same general approach applies to Blazor Web Apps that adopt the global Interactive Auto render mode. The important concept to keep in mind is that accessing the <xref:Microsoft.AspNetCore.Http.HttpContext> using <xref:Microsoft.AspNetCore.Http.IHttpContextAccessor> is only performed during static SSR.

> [!NOTE]
> [Microsoft identity platform](/entra/identity-platform/)/[Microsoft Identity Web packages](/entra/msal/dotnet/microsoft-identity-web/) for [Microsoft Entra ID](https://www.microsoft.com/security/business/microsoft-entra) provides a simple API to call web APIs from Blazor Web Apps with automatic token management and renewal. For more information, see <xref:blazor/security/blazor-web-app-entra> and the `BlazorWebAppEntra` and `BlazorWebAppEntraBff` sample apps (.NET 9 or later) in the [Blazor samples GitHub repository](https://github.com/dotnet/blazor-samples).

Subclass <xref:System.Net.Http.DelegatingHandler> to attach a user's access token to outgoing requests. The token handler only executes during static SSR/prerendering, so using <xref:Microsoft.AspNetCore.Http.HttpContext> is safe.

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
        var accessToken = httpContextAccessor.HttpContext?
            .GetTokenAsync("access_token").Result ?? 
            throw new Exception("No access token");

        request.Headers.Authorization =
            new AuthenticationHeaderValue("Bearer", accessToken);

        return await base.SendAsync(request, cancellationToken);
    }
}
```

In the project's `Program` file, the token handler (`TokenHandler`) is registered as a scoped service and specified as a [named HTTP client's](xref:blazor/call-web-api#named-httpclient-with-ihttpclientfactory) message handler with <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.AddHttpMessageHandler%2A>.

In the following example, the `{HTTP CLIENT NAME}` placeholder is the name of the <xref:System.Net.Http.HttpClient>, and the `{BASE ADDRESS}` placeholder is the web API's base address URI.

In `Program.cs`:

```csharp
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
var request = new HttpRequestMessage(HttpMethod.Get, "{REQUEST URI}");
var client = ClientFactory.CreateClient("{HTTP CLIENT NAME}");
var response = await client.SendAsync(request);
```

Example:

```csharp
var request = new HttpRequestMessage(HttpMethod.Get, "/weather-forecast");
var client = ClientFactory.CreateClient("ExternalApi");
var response = await client.SendAsync(request);
```

Additional features are planned for Blazor, which are tracked by [Access `AuthenticationStateProvider` in outgoing request middleware (`dotnet/aspnetcore` #52379)](https://github.com/dotnet/aspnetcore/issues/52379). [Problem providing Access Token to HttpClient in Interactive Server mode (`dotnet/aspnetcore` #52390)](https://github.com/dotnet/aspnetcore/issues/52390) is a closed issue that contains helpful discussion and potential workaround strategies for advanced use cases.

### Root-level cascading values with notifications 

Tokens can be passed via [root-level cascading values](xref:blazor/components/cascading-values-and-parameters#root-level-cascading-values) with a <xref:Microsoft.AspNetCore.Components.CascadingValueSource%601> with subscriber notifications. This general approach works well when you need to interact with tokens outside of calling a web API.

The following `CascadingStateServiceCollectionExtensions` creates a <xref:Microsoft.AspNetCore.Components.CascadingValueSource%601> from a type that implements <xref:System.ComponentModel.INotifyPropertyChanged>.

> [!NOTE]
> For Blazor Web App solutions consisting of server and client (`.Client`) projects, place the following `CascadingStateServiceCollectionExtensions.cs` file into the `.Client` project.

`CascadingStateServiceCollectionExtensions.cs`:

```csharp
using Microsoft.AspNetCore.Components;
using System.ComponentModel;

namespace Microsoft.Extensions.DependencyInjection;

public static class CascadingStateServiceCollectionExtensions
{
    public static IServiceCollection AddNotifyingCascadingValue<T>(
        this IServiceCollection services, T state, bool isFixed = false)
        where T : INotifyPropertyChanged
    {
        return services.AddCascadingValue<T>(sp =>
        {
            return new CascadingStateValueSource<T>(state, isFixed);
        });
    }

    private sealed class CascadingStateValueSource<T>
        : CascadingValueSource<T>, IDisposable where T : INotifyPropertyChanged
    {
        private readonly T state;
        private readonly CascadingValueSource<T> source;

        public CascadingStateValueSource(T state, bool isFixed = false)
            : base(state, isFixed = false)
        {
            this.state = state;
            source = new CascadingValueSource<T>(state, isFixed);
            this.state.PropertyChanged += HandlePropertyChanged;
        }

        private void HandlePropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            _ = NotifyChangedAsync();
        }

        public void Dispose()
        {
            state.PropertyChanged -= HandlePropertyChanged;
        }
    }
}
```

Create a class to manage the token state. The following `NotifyingState` example tracks state for access and refresh tokens.

> [!NOTE]
> For Blazor Web App solutions consisting of server and client (`.Client`) projects, place the following `NotifyingState.cs` file into the `.Client` project.

`NotifyingState.cs`:

```csharp
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BlazorWebAppOidcServer;

public class NotifyingState : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    private string accessToken = string.Empty;
    private string refreshToken = string.Empty;

    public string AccessToken
    {
        get => accessToken;
        set
        {
            if (accessToken != value)
            {
                accessToken = value;
                OnPropertyChanged();
            }
        }
    }

    public string RefreshToken
    {
        get => refreshToken;
        set
        {
            if (refreshToken != value)
            {
                refreshToken = value;
                OnPropertyChanged();
            }
        }
    }

    protected virtual void OnPropertyChanged(
        [CallerMemberName] string? propertyName = default)
            => PropertyChanged?.Invoke(this, new(propertyName));
}
```

In the `Program` file&dagger;, `NotifyingState` is passed to create a <xref:Microsoft.AspNetCore.Components.CascadingValueSource%601>:

```csharp
builder.Services.AddNotifyingCascadingValue(new NotifyingState());
```

> [!NOTE]
> &dagger;For Blazor Web App solutions consisting of server and client (`.Client`) projects, place the preceding code into each project's `Program` file.

The `Program` file of the server project must also register <xref:Microsoft.AspNetCore.Http.IHttpContextAccessor>:

```csharp
builder.Services.AddHttpContextAccessor();
```

At the top of the `App` component (`App.razor`), add an [`@using`](xref:mvc/views/razor#using) directive for <xref:Microsoft.AspNetCore.Authentication?displayProperty=fullName>:

```razor
@using Microsoft.AspNetCore.Authentication
```

Under the markup of the `App` component, add the following `@code` block to set the `AccessToken` and `RefreshToken` properties from the cascaded <xref:Microsoft.AspNetCore.Http.HttpContext>. The following example is suitable when using an OIDC identity provider, an example for Microsoft Entra ID with Microsoft Identity Web packages follows this example.

```razor
@code {
    [CascadingParameter]
    public HttpContext? HttpContext { get; set; }

    [CascadingParameter]
    public NotifyingState? State { get; set; }

    protected override void OnInitialized()
    {
        if (State is not null)
        {
            State.AccessToken = HttpContext?.GetTokenAsync("access_token").Result ?? string.Empty;
            State.RefreshToken = HttpContext?.GetTokenAsync("refresh_token").Result ?? string.Empty;
        }
    }
}
```

For app's that rely upon Entra with Microsoft Identity Web, the following approach can obtain the access token:

```razor
@using Microsoft.AspNetCore.Components.Authorization
@using Microsoft.Identity.Web;
@inject ITokenAcquisition TokenAcquisition
@inject AuthenticationStateProvider AuthState

...

@code {
    [CascadingParameter]
    public HttpContext? HttpContext { get; set; }

    [CascadingParameter]
    public NotifyingState? State { get; set; }

    protected override async Task OnInitializedAsync()
    {
        if (State is not null)
        {
            var authState = await AuthState.GetAuthenticationStateAsync();

            if (authState.User.Identity is not null && authState.User.Identity.IsAuthenticated)
            {
                State.AccessToken = await TokenAcquisition.GetAccessTokenForUserAsync([ "{SCOPE}" ]);
            }
        }
    }
}
```

The app, including within components, can now obtain the access and refresh tokens, keeping in mind that the values are set for the life of the circuit unless developer code updates them. The following approach is effective in server-side scenarios, and an example follows that's useful in Blazor Web Apps that adopt Interactive Auto rendering.

```csharp
private string? accessToken;
private string? refreshToken;

[CascadingParameter]
public NotifyingState? State { get; set; }

protected override async Task OnInitializedAsync()
{
    accessToken = State?.AccessToken;
    refreshToken = State?.RefreshToken;
}
```

The following example demonstrates the concept in an app that adopts Interactive Auto rendering with server and `.Client` projects, where the tokens must be persisted from the server during prerendering:

```razor
@implements IDisposable
@inject PersistentComponentState ApplicationState

...

@code {
    private PersistingComponentStateSubscription persistingSubscription;
    private string? accessToken;
    private string? refreshToken;

    [CascadingParameter]
    public NotifyingState? State { get; set; }

    protected override async Task OnInitializedAsync()
    {
        if (!ApplicationState.TryTakeFromJson<string>(nameof(accessToken), out var restoredAccessToken))
        {
            accessToken = State?.AccessToken;
        }
        else
        {
            accessToken = restoredAccessToken!;
        }

        if (!ApplicationState.TryTakeFromJson<string>(nameof(refreshToken), out var restoredRefreshToken))
        {
            refreshToken = State?.RefreshToken;
        }
        else
        {
            refreshToken = restoredRefreshToken!;
        }

        persistingSubscription = ApplicationState.RegisterOnPersisting(PersistData);
    }

    private Task PersistData()
    {
        ApplicationState.PersistAsJson(nameof(accessToken), accessToken);
        ApplicationState.PersistAsJson(nameof(refreshToken), refreshToken);

        return Task.CompletedTask;
    }

    void IDisposable.Dispose() => persistingSubscription.Dispose();
}
```

### Passing the anti-request forgery (CSRF/XSRF) token

Passing the [anti-request forgery (CSRF/XSRF) token](xref:security/anti-request-forgery) to Razor components is useful in scenarios where components POST to Identity or other endpoints that require validation. However, don't follow the guidance in this section for processing form POST requests or web API requests with XSRF support. The Blazor framework provides built-in antiforgery support for forms and calling web APIs. For more information, see the following resources:

* General support for antiforgery: <xref:blazor/security/index#antiforgery-support>
* Antiforgery support for forms: <xref:blazor/forms/index#antiforgery-support>
* Antiforgery support for web API: <xref:blazor/call-web-api#antiforgery-support>

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
public class AuthenticationStateHandler(
    CircuitServicesAccessor circuitServicesAccessor) 
    : DelegatingHandler
{
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
