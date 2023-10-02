---
title: ASP.NET Core Blazor WebAssembly additional security scenarios
author: guardrex
description: Learn how to configure Blazor WebAssembly for additional security scenarios.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 04/04/2023
uid: blazor/security/webassembly/additional-scenarios
---
# ASP.NET Core Blazor WebAssembly additional security scenarios

[!INCLUDE[](~/includes/not-latest-version.md)]

This article describes additional security scenarios for Blazor WebAssembly apps.

## Attach tokens to outgoing requests

<xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.AuthorizationMessageHandler> is a <xref:System.Net.Http.DelegatingHandler> used to process access tokens. Tokens are acquired using the <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.IAccessTokenProvider> service, which is registered by the framework. If a token can't be acquired, an <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.AccessTokenNotAvailableException> is thrown. <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.AccessTokenNotAvailableException> has a <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.AccessTokenNotAvailableException.Redirect%2A> method that navigates to `AccessTokenResult.InteractiveRequestUrl` using the given `AccessTokenResult.InteractionOptions` to allow refreshing the access token.

For convenience, the framework provides the <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.BaseAddressAuthorizationMessageHandler> preconfigured with the app's base address as an authorized URL. **Access tokens are only added when the request URI is within the app's base URI.** When outgoing request URIs aren't within the app's base URI, use a [custom `AuthorizationMessageHandler` class (*recommended*)](#custom-authorizationmessagehandler-class) or [configure the `AuthorizationMessageHandler`](#configure-authorizationmessagehandler).

> [!NOTE]
> In addition to the client app configuration for server API access, the server API must also allow cross-origin requests (CORS) when the client and the server don't reside at the same base address. For more information on server-side CORS configuration, see the [Cross-Origin Resource Sharing (CORS)](#cross-origin-resource-sharing-cors) section later in this article.

In the following example:

* <xref:Microsoft.Extensions.DependencyInjection.HttpClientFactoryServiceCollectionExtensions.AddHttpClient%2A> adds <xref:System.Net.Http.IHttpClientFactory> and related services to the service collection and configures a named <xref:System.Net.Http.HttpClient> (`WebAPI`). <xref:System.Net.Http.HttpClient.BaseAddress?displayProperty=nameWithType> is the base address of the resource URI when sending requests. <xref:System.Net.Http.IHttpClientFactory> is provided by the [`Microsoft.Extensions.Http`](https://www.nuget.org/packages/Microsoft.Extensions.Http) NuGet package.
* <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.BaseAddressAuthorizationMessageHandler> is the <xref:System.Net.Http.DelegatingHandler> used to process access tokens. Access tokens are only added when the request URI is within the app's base URI.
* <xref:System.Net.Http.IHttpClientFactory.CreateClient%2A?displayProperty=nameWithType> creates and configures an <xref:System.Net.Http.HttpClient> instance for outgoing requests using the configuration that corresponds to the named <xref:System.Net.Http.HttpClient> (`WebAPI`).

In the following example, <xref:Microsoft.Extensions.DependencyInjection.HttpClientFactoryServiceCollectionExtensions.AddHttpClient%2A?displayProperty=nameWithType> is an extension in <xref:Microsoft.Extensions.Http?displayProperty=fullName>. Add the package to an app that doesn't already reference it.

[!INCLUDE[](~/includes/package-reference.md)]

```csharp
using System.Net.Http;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

...

builder.Services.AddHttpClient("WebAPI", 
        client => client.BaseAddress = new Uri("https://www.example.com/base"))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>()
    .CreateClient("WebAPI"));
```

:::moniker range="< aspnetcore-8.0"

For a hosted Blazor [solution](xref:blazor/tooling#visual-studio-solution-file-sln) based on the [Blazor WebAssembly project template](xref:blazor/project-structure), request URIs are within the app's base URI by default. Therefore, <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.IWebAssemblyHostEnvironment.BaseAddress?displayProperty=nameWithType> (`new Uri(builder.HostEnvironment.BaseAddress)`) is assigned to the <xref:System.Net.Http.HttpClient.BaseAddress?displayProperty=nameWithType> in an app generated from the project template.

:::moniker-end

The configured <xref:System.Net.Http.HttpClient> is used to make authorized requests using the [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) pattern:

```razor
@using Microsoft.AspNetCore.Components.WebAssembly.Authentication
@inject HttpClient Http

...

protected override async Task OnInitializedAsync()
{
    try
    {
        var examples = 
            await Http.GetFromJsonAsync<ExampleType[]>("ExampleAPIMethod");

        ...
    }
    catch (AccessTokenNotAvailableException exception)
    {
        exception.Redirect();
    }
}
```

## Custom authentication request scenarios

The following scenarios demonstrate how to customize authentication requests and how to obtain the login path from authentication options.

:::moniker range=">= aspnetcore-7.0"

### Customize the login process

Manage additional parameters to a login request with the following methods one or more times on a new instance of <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.InteractiveRequestOptions>:

* <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.InteractiveRequestOptions.TryAddAdditionalParameter%2A>
* <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.InteractiveRequestOptions.TryRemoveAdditionalParameter%2A>
* <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.InteractiveRequestOptions.TryGetAdditionalParameter%2A>

In the following `LoginDisplay` component example, additional parameters are added to the login request:

* `prompt` is set to `login`: Forces the user to enter their credentials on that request, negating single sign on.
* `loginHint` is set to `peter@contoso.com`: Pre-fills the username/email address field of the sign-in page for the user to `peter@contoso.com`. Apps often use this parameter during re-authentication, having already extracted the username from a previous sign in using the `preferred_username` claim.

`Shared/LoginDisplay.razor`:

```csharp
@using Microsoft.AspNetCore.Components.Authorization
@using Microsoft.AspNetCore.Components.WebAssembly.Authentication
@inject NavigationManager Navigation

<AuthorizeView>
    <Authorized>
        Hello, @context.User.Identity?.Name!
        <button @onclick="BeginLogOut">Log out</button>
    </Authorized>
    <NotAuthorized>
        <button @onclick="BeginLogIn">Log in</button>
    </NotAuthorized>
</AuthorizeView>

@code{
    public void BeginLogOut()
    {
        Navigation.NavigateToLogout("authentication/logout");
    }

    public void BeginLogIn()
    {
        InteractiveRequestOptions requestOptions =
            new()
            {
                Interaction = InteractionType.SignIn,
                ReturnUrl = Navigation.Uri,
            };

        requestOptions.TryAddAdditionalParameter("prompt", "login");
        requestOptions.TryAddAdditionalParameter("loginHint", "peter@contoso.com");

        Navigation.NavigateToLogin("authentication/login", requestOptions);
    }
}
```

For more information, see the following resources:

* <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.InteractiveRequestOptions>
* [Popup request parameter list](https://azuread.github.io/microsoft-authentication-library-for-js/ref/modules/_azure_msal_browser.html#popuprequest)

### Customize options before obtaining a token interactively

If an <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.AccessTokenNotAvailableException> occurs, manage additional parameters for a new identity provider access token request with the following methods one or more times on a new instance of <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.InteractiveRequestOptions>:

* <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.InteractiveRequestOptions.TryAddAdditionalParameter%2A>
* <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.InteractiveRequestOptions.TryRemoveAdditionalParameter%2A>
* <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.InteractiveRequestOptions.TryGetAdditionalParameter%2A>

In the following example that obtains JSON data via web API, additional parameters are added to the redirect request if an access token isn't available (<xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.AccessTokenNotAvailableException> is thrown):

* `prompt` is set to `login`: Forces the user to enter their credentials on that request, negating single sign on.
* `loginHint` is set to `peter@contoso.com`: Pre-fills the username/email address field of the sign-in page for the user to `peter@contoso.com`. Apps often use this parameter during re-authentication, having already extracted the username from a previous sign in using the `preferred_username` claim.

```csharp
try
{
    var examples = await Http.GetFromJsonAsync<ExampleType[]>("ExampleAPIMethod");

    ...
}
catch (AccessTokenNotAvailableException ex)
{
    ex.Redirect(requestOptions => {
        requestOptions.TryAddAdditionalParameter("prompt", "login");
        requestOptions.TryAddAdditionalParameter("loginHint", "peter@contoso.com");
    });
}
```

The preceding example assumes that:

* The presence of an `@using`/`using` statement for API in the <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication?displayProperty=fullName> namespace.
* `HttpClient` injected as `Http`.

For more information, see the following resources:

* <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.InteractiveRequestOptions>
* [Redirect request parameter list](https://azuread.github.io/microsoft-authentication-library-for-js/ref/modules/_azure_msal_browser.html#redirectrequest)

### Customize options when using an `IAccessTokenProvider`

If obtaining a token fails when using an <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.IAccessTokenProvider>, manage additional parameters for a new identity provider access token request with the following methods one or more times on a new instance of <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.InteractiveRequestOptions>:

* <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.InteractiveRequestOptions.TryAddAdditionalParameter%2A>
* <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.InteractiveRequestOptions.TryRemoveAdditionalParameter%2A>
* <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.InteractiveRequestOptions.TryGetAdditionalParameter%2A>

In the following example that attempts to obtain an access token for the user, additional parameters are added to the login request if the attempt to obtain a token fails when <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.AccessTokenResult.TryGetToken%2A> is called:

* `prompt` is set to `login`: Forces the user to enter their credentials on that request, negating single sign on.
* `loginHint` is set to `peter@contoso.com`: Pre-fills the username/email address field of the sign-in page for the user to `peter@contoso.com`. Apps often use this parameter during re-authentication, having already extracted the username from a previous sign in using the `preferred_username` claim.

```csharp
var tokenResult = await TokenProvider.RequestAccessToken(
    new AccessTokenRequestOptions
    {
        Scopes = new[] { ... }
    });

if (!tokenResult.TryGetToken(out var token))
{
    tokenResult.InteractionOptions.TryAddAdditionalParameter("prompt", "login");
    tokenResult.InteractionOptions.TryAddAdditionalParameter("loginHint", 
        "peter@contoso.com");

    Navigation.NavigateToLogin(accessTokenResult.InteractiveRequestUrl, 
        accessTokenResult.InteractionOptions);
}
```

The preceding example assumes:

* The presence of an `@using`/`using` statement for API in the <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication?displayProperty=fullName> namespace.
* <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.IAccessTokenProvider> injected as `TokenProvider`.

For more information, see the following resources:

* <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.InteractiveRequestOptions>
* [Popup request parameter list](https://azuread.github.io/microsoft-authentication-library-for-js/ref/modules/_azure_msal_browser.html#popuprequest)

### Logout with a custom return URL

The following example logs out the user and returns the user to the `/goodbye` endpoint:

```csharp
Navigation.NavigateToLogout("authentication/logout", "goodbye");
```

### Obtain the login path from authentication options

Obtain the configured login path from <xref:Microsoft.AspNetCore.Builder.RemoteAuthenticationOptions>:

```csharp
var loginPath = 
    RemoteAuthOptions.Get(Options.DefaultName).AuthenticationPaths.LogInPath;
```

The preceding example assumes:

* The presence of an `@using`/`using` statement for API in the following namespaces:
  * <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication?displayProperty=fullName>
  * <xref:Microsoft.Extensions.Options?displayProperty=fullName>
* `IOptionsSnapshot<RemoteAuthenticationOptions<ApiAuthorizationProviderOptions>>` injected as `RemoteAuthOptions`.

:::moniker-end

### Custom `AuthorizationMessageHandler` class

*This guidance in this section is recommended for client apps that make outgoing requests to URIs that aren't within the app's base URI.*

In the following example, a custom class extends <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.AuthorizationMessageHandler> for use as the <xref:System.Net.Http.DelegatingHandler> for an <xref:System.Net.Http.HttpClient>. <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.AuthorizationMessageHandler.ConfigureHandler%2A> configures this handler to authorize outbound HTTP requests using an access token. The access token is only attached if at least one of the authorized URLs is a base of the request URI (<xref:System.Net.Http.HttpRequestMessage.RequestUri?displayProperty=nameWithType>).

```csharp
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

public class CustomAuthorizationMessageHandler : AuthorizationMessageHandler
{
    public CustomAuthorizationMessageHandler(IAccessTokenProvider provider, 
        NavigationManager navigation)
        : base(provider, navigation)
    {
        ConfigureHandler(
            authorizedUrls: new[] { "https://www.example.com/base" },
            scopes: new[] { "example.read", "example.write" });
    }
}
```

In the preceding code, the scopes `example.read` and `example.write` are generic examples not meant to reflect valid scopes for any particular provider.

In the `Program` file, `CustomAuthorizationMessageHandler` is registered as a transient service and is configured as the <xref:System.Net.Http.DelegatingHandler> for outgoing <xref:System.Net.Http.HttpResponseMessage> instances made by a named <xref:System.Net.Http.HttpClient>.

In the following example, <xref:Microsoft.Extensions.DependencyInjection.HttpClientFactoryServiceCollectionExtensions.AddHttpClient%2A?displayProperty=nameWithType> is an extension in <xref:Microsoft.Extensions.Http?displayProperty=fullName>. Add the package to an app that doesn't already reference it.

[!INCLUDE[](~/includes/package-reference.md)]

```csharp
builder.Services.AddTransient<CustomAuthorizationMessageHandler>();

builder.Services.AddHttpClient("WebAPI",
        client => client.BaseAddress = new Uri("https://www.example.com/base"))
    .AddHttpMessageHandler<CustomAuthorizationMessageHandler>();
```

> [!NOTE]
> In the preceding example, the `CustomAuthorizationMessageHandler` <xref:System.Net.Http.DelegatingHandler> is registered as a transient service for <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.AddHttpMessageHandler%2A>. Transient registration is recommended for <xref:System.Net.Http.IHttpClientFactory>, which manages its own DI scopes. For more information, see the following resources:
>
> * [Utility base component classes to manage a DI scope](xref:blazor/fundamentals/dependency-injection#utility-base-component-classes-to-manage-a-di-scope)
> * [Detect client-side transient disposables](xref:blazor/fundamentals/dependency-injection#detect-client-side-transient-disposables)

:::moniker range="< aspnetcore-8.0"

For a hosted Blazor solution based on the [Blazor WebAssembly project template](xref:blazor/project-structure), <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.IWebAssemblyHostEnvironment.BaseAddress?displayProperty=nameWithType> (`new Uri(builder.HostEnvironment.BaseAddress)`) is assigned to the <xref:System.Net.Http.HttpClient.BaseAddress?displayProperty=nameWithType> by default.

:::moniker-end

The configured <xref:System.Net.Http.HttpClient> is used to make authorized requests using the [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) pattern. Where the client is created with <xref:System.Net.Http.IHttpClientFactory.CreateClient%2A> ([`Microsoft.Extensions.Http`](https://www.nuget.org/packages/Microsoft.Extensions.Http) package), the <xref:System.Net.Http.HttpClient> is supplied instances that include access tokens when making requests to the server API. If the request URI is a relative URI, as it is in the following example (`ExampleAPIMethod`), it's combined with the <xref:System.Net.Http.HttpClient.BaseAddress> when the client app makes the request:

```razor
@inject IHttpClientFactory ClientFactory

...

@code {
    protected override async Task OnInitializedAsync()
    {
        try
        {
            var client = ClientFactory.CreateClient("WebAPI");

            var examples = 
                await client.GetFromJsonAsync<ExampleType[]>("ExampleAPIMethod");

            ...
        }
        catch (AccessTokenNotAvailableException exception)
        {
            exception.Redirect();
        }
    }
}
```

### Configure `AuthorizationMessageHandler`

<xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.AuthorizationMessageHandler> can be configured with authorized URLs, scopes, and a return URL using the <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.AuthorizationMessageHandler.ConfigureHandler%2A> method. <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.AuthorizationMessageHandler.ConfigureHandler%2A> configures the handler to authorize outbound HTTP requests using an access token. The access token is only attached if at least one of the authorized URLs is a base of the request URI (<xref:System.Net.Http.HttpRequestMessage.RequestUri?displayProperty=nameWithType>). If the request URI is a relative URI, it's combined with the <xref:System.Net.Http.HttpClient.BaseAddress>.

In the following example, <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.AuthorizationMessageHandler> configures an <xref:System.Net.Http.HttpClient> in the `Program` file:

```csharp
using System.Net.Http;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

...

builder.Services.AddScoped(sp => new HttpClient(
    sp.GetRequiredService<AuthorizationMessageHandler>()
    .ConfigureHandler(
        authorizedUrls: new[] { "https://www.example.com/base" },
        scopes: new[] { "example.read", "example.write" }))
    {
        BaseAddress = new Uri("https://www.example.com/base")
    });
```

In the preceding code, the scopes `example.read` and `example.write` are generic examples not meant to reflect valid scopes for any particular provider.

:::moniker range="< aspnetcore-8.0"

For a hosted Blazor solution based on the [Blazor WebAssembly project template](xref:blazor/project-structure), <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.IWebAssemblyHostEnvironment.BaseAddress?displayProperty=nameWithType> is assigned to the following by default:

* The <xref:System.Net.Http.HttpClient.BaseAddress?displayProperty=nameWithType> (`new Uri(builder.HostEnvironment.BaseAddress)`).
* A URL of the `authorizedUrls` array.

:::moniker-end

## Typed `HttpClient`

A typed client can be defined that handles all of the HTTP and token acquisition concerns within a single class.

`WeatherForecastClient.cs`:

:::moniker range=">= aspnetcore-6.0"

```csharp
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using static {ASSEMBLY NAME}.Data;

public class WeatherForecastClient
{
    private readonly HttpClient http;
    private WeatherForecast[]? forecasts;

    public WeatherForecastClient(HttpClient http)
    {
        this.http = http;
    }

    public async Task<WeatherForecast[]> GetForecastAsync()
    {
        try
        {
            forecasts = await http.GetFromJsonAsync<WeatherForecast[]>(
                "WeatherForecast");
        }
        catch (AccessTokenNotAvailableException exception)
        {
            exception.Redirect();
        }

        return forecasts ?? Array.Empty<WeatherForecast>();
    }
}
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

```csharp
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using static {ASSEMBLY NAME}.Data;

public class WeatherForecastClient
{
    private readonly HttpClient http;
    private WeatherForecast[] forecasts;
 
    public WeatherForecastClient(HttpClient http)
    {
        this.http = http;
    }
 
    public async Task<WeatherForecast[]> GetForecastAsync()
    {
        try
        {
            forecasts = await http.GetFromJsonAsync<WeatherForecast[]>(
                "WeatherForecast");
        }
        catch (AccessTokenNotAvailableException exception)
        {
            exception.Redirect();
        }

        return forecasts ?? Array.Empty<WeatherForecast>();
    }
}
```

:::moniker-end

In the preceding example, the `WeatherForecast` type is a static class that holds weather forecast data. The placeholder `{ASSEMBLY NAME}` is the app's assembly name (for example, `using static BlazorSample.Data;`).

In the following example, <xref:Microsoft.Extensions.DependencyInjection.HttpClientFactoryServiceCollectionExtensions.AddHttpClient%2A?displayProperty=nameWithType> is an extension in <xref:Microsoft.Extensions.Http?displayProperty=fullName>. Add the package to an app that doesn't already reference it.

[!INCLUDE[](~/includes/package-reference.md)]

In the `Program` file:

```csharp
using System.Net.Http;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

...

builder.Services.AddHttpClient<WeatherForecastClient>(
        client => client.BaseAddress = new Uri("https://www.example.com/base"))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
```

:::moniker range="< aspnetcore-8.0"

For a hosted Blazor solution based on the [Blazor WebAssembly project template](xref:blazor/project-structure), <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.IWebAssemblyHostEnvironment.BaseAddress?displayProperty=nameWithType> (`new Uri(builder.HostEnvironment.BaseAddress)`) is assigned to the <xref:System.Net.Http.HttpClient.BaseAddress?displayProperty=nameWithType> by default.

:::moniker-end

In a component that fetches weather data:

```razor
@inject WeatherForecastClient Client

...

protected override async Task OnInitializedAsync()
{
    forecasts = await Client.GetForecastAsync();
}
```

## Configure the `HttpClient` handler

The handler can be further configured with <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.AuthorizationMessageHandler.ConfigureHandler%2A> for outbound HTTP requests.

In the following example, <xref:Microsoft.Extensions.DependencyInjection.HttpClientFactoryServiceCollectionExtensions.AddHttpClient%2A?displayProperty=nameWithType> is an extension in <xref:Microsoft.Extensions.Http?displayProperty=fullName>. Add the package to an app that doesn't already reference it.

[!INCLUDE[](~/includes/package-reference.md)]

In the `Program` file:

```csharp
builder.Services.AddHttpClient<WeatherForecastClient>(
        client => client.BaseAddress = new Uri("https://www.example.com/base"))
    .AddHttpMessageHandler(sp => sp.GetRequiredService<AuthorizationMessageHandler>()
    .ConfigureHandler(
        authorizedUrls: new [] { "https://www.example.com/base" },
        scopes: new[] { "example.read", "example.write" }));
```

In the preceding code, the scopes `example.read` and `example.write` are generic examples not meant to reflect valid scopes for any particular provider.

:::moniker range="< aspnetcore-8.0"

For a hosted Blazor solution based on the [Blazor WebAssembly project template](xref:blazor/project-structure), <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.IWebAssemblyHostEnvironment.BaseAddress?displayProperty=nameWithType> is assigned to the following by default:

* The <xref:System.Net.Http.HttpClient.BaseAddress?displayProperty=nameWithType> (`new Uri(builder.HostEnvironment.BaseAddress)`).
* A URL of the `authorizedUrls` array.

:::moniker-end

## Unauthenticated or unauthorized web API requests in an app with a secure default client

An app that ordinarily uses a secure default <xref:System.Net.Http.HttpClient> can also make unauthenticated or unauthorized web API requests by configuring a named <xref:System.Net.Http.HttpClient>.

In the following example, <xref:Microsoft.Extensions.DependencyInjection.HttpClientFactoryServiceCollectionExtensions.AddHttpClient%2A?displayProperty=nameWithType> is an extension in <xref:Microsoft.Extensions.Http?displayProperty=fullName>. Add the package to an app that doesn't already reference it.

[!INCLUDE[](~/includes/package-reference.md)]

In the `Program` file:

```csharp
builder.Services.AddHttpClient("WebAPI.NoAuthenticationClient", 
    client => client.BaseAddress = new Uri("https://www.example.com/base"));
```

:::moniker range="< aspnetcore-8.0"

For a hosted Blazor solution based on the [Blazor WebAssembly project template](xref:blazor/project-structure), <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.IWebAssemblyHostEnvironment.BaseAddress?displayProperty=nameWithType> (`new Uri(builder.HostEnvironment.BaseAddress)`) is assigned to the <xref:System.Net.Http.HttpClient.BaseAddress?displayProperty=nameWithType> by default.

:::moniker-end

The preceding registration is in addition to the existing secure default <xref:System.Net.Http.HttpClient> registration.

A component creates the <xref:System.Net.Http.HttpClient> from the <xref:System.Net.Http.IHttpClientFactory> ([`Microsoft.Extensions.Http`](https://www.nuget.org/packages/Microsoft.Extensions.Http) package) to make unauthenticated or unauthorized requests:

```razor
@inject IHttpClientFactory ClientFactory

...

@code {
    protected override async Task OnInitializedAsync()
    {
        var client = ClientFactory.CreateClient("WebAPI.NoAuthenticationClient");

        var examples = await client.GetFromJsonAsync<ExampleType[]>(
            "ExampleNoAuthentication");

        ...
    }
}
```

> [!NOTE]
> The controller in the server API, `ExampleNoAuthenticationController` for the preceding example, isn't marked with the [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute).

The decision whether to use a secure client or an insecure client as the default <xref:System.Net.Http.HttpClient> instance is up to the developer. One way to make this decision is to consider the number of authenticated versus unauthenticated endpoints that the app contacts. If the majority of the app's requests are to secure API endpoints, use the authenticated <xref:System.Net.Http.HttpClient> instance as the default. Otherwise, register the unauthenticated <xref:System.Net.Http.HttpClient> instance as the default.

An alternative approach to using the <xref:System.Net.Http.IHttpClientFactory> is to create a [typed client](#typed-httpclient) for unauthenticated access to anonymous endpoints.

## Request additional access tokens

Access tokens can be manually obtained by calling <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.IAccessTokenProvider.RequestAccessToken%2A?displayProperty=nameWithType>. In the following example, an additional scope is required by an app for the default <xref:System.Net.Http.HttpClient>. The Microsoft Authentication Library (MSAL) example configures the scope with `MsalProviderOptions`:

In the `Program` file:

```csharp
builder.Services.AddMsalAuthentication(options =>
{
    ...

    options.ProviderOptions.AdditionalScopesToConsent.Add("{CUSTOM SCOPE 1}");
    options.ProviderOptions.AdditionalScopesToConsent.Add("{CUSTOM SCOPE 2}");
}
```

The `{CUSTOM SCOPE 1}` and `{CUSTOM SCOPE 2}` placeholders in the preceding example are custom scopes.

The <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.IAccessTokenProvider.RequestAccessToken%2A?displayProperty=nameWithType> method provides an overload that allows an app to provision an access token with a given set of scopes.

In a Razor component:

```razor
@using Microsoft.AspNetCore.Components.WebAssembly.Authentication
@inject IAccessTokenProvider TokenProvider

...

var tokenResult = await TokenProvider.RequestAccessToken(
    new AccessTokenRequestOptions
    {
        Scopes = new[] { "{CUSTOM SCOPE 1}", "{CUSTOM SCOPE 2}" }
    });

if (tokenResult.TryGetToken(out var token))
{
    ...
}
```

The `{CUSTOM SCOPE 1}` and `{CUSTOM SCOPE 2}` placeholders in the preceding example are custom scopes.

<xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.AccessTokenResult.TryGetToken%2A?displayProperty=nameWithType> returns:

* `true` with the `token` for use.
* `false` if the token isn't retrieved.

## Cross-Origin Resource Sharing (CORS)

When sending credentials (authorization cookies/headers) on CORS requests, the `Authorization` header must be allowed by the CORS policy.

The following policy includes configuration for:

* Request origins (`http://localhost:5000`, `https://localhost:5001`).
* Any method (verb).
* `Content-Type` and `Authorization` headers. To allow a custom header (for example, `x-custom-header`), list the header when calling <xref:Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder.WithHeaders%2A>.
* Credentials set by client-side JavaScript code (`credentials` property set to `include`).

```csharp
app.UseCors(policy => 
    policy.WithOrigins("http://localhost:5000", "https://localhost:5001")
        .AllowAnyMethod()
        .WithHeaders(HeaderNames.ContentType, HeaderNames.Authorization, 
            "x-custom-header")
        .AllowCredentials());
```

:::moniker range="< aspnetcore-8.0"

A hosted Blazor solution based on the [Blazor WebAssembly project template](xref:blazor/project-structure) uses the same base address for the client and server apps. The client app's <xref:System.Net.Http.HttpClient.BaseAddress?displayProperty=nameWithType> is set to a URI of `builder.HostEnvironment.BaseAddress` by default. CORS configuration is ***not*** required in the default configuration of a hosted Blazor solution. Additional client apps that aren't hosted by the server project and don't share the server app's base address ***do*** require CORS configuration in the server project.

:::moniker-end

For more information, see <xref:security/cors> and the sample app's HTTP Request Tester component (`Components/HTTPRequestTester.razor`).

## Handle token request errors

When a single-page application (SPA) authenticates a user using OpenID Connect (OIDC), the authentication state is maintained locally within the SPA and in the Identity Provider (IP) in the form of a session cookie that's set as a result of the user providing their credentials.

The tokens that the IP emits for the user typically are valid for short periods of time, about one hour normally, so the client app must regularly fetch new tokens. Otherwise, the user would be logged-out after the granted tokens expire. In most cases, OIDC clients are able to provision new tokens without requiring the user to authenticate again thanks to the authentication state or "session" that is kept within the IP.

There are some cases in which the client can't get a token without user interaction, for example, when for some reason the user explicitly logs out from the IP. This scenario occurs if a user visits `https://login.microsoftonline.com` and logs out. In these scenarios, the app doesn't know immediately that the user has logged out. Any token that the client holds might no longer be valid. Also, the client isn't able to provision a new token without user interaction after the current token expires.

These scenarios aren't specific to token-based authentication. They are part of the nature of SPAs. An SPA using cookies also fails to call a server API if the authentication cookie is removed.

When an app performs API calls to protected resources, you must be aware of the following:

* To provision a new access token to call the API, the user might be required to authenticate again.
* Even if the client has a token that seems to be valid, the call to the server might fail because the token was revoked by the user.

When the app requests a token, there are two possible outcomes:

* The request succeeds, and the app has a valid token.
* The request fails, and the app must authenticate the user again to obtain a new token.

When a token request fails, you need to decide whether you want to save any current state before you perform a redirection. Several approaches exist to store state with increasing levels of complexity:

* Store the current page state in session storage. During the [`OnInitializedAsync` lifecycle method](xref:blazor/components/lifecycle#component-initialization-oninitializedasync) (<xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A>), check if state can be restored before continuing.
* Add a query string parameter and use that as a way to signal the app that it needs to re-hydrate the previously saved state.
* Add a query string parameter with a unique identifier to store data in session storage without risking collisions with other items.

## Save app state before an authentication operation with session storage

The following example shows how to:

* Preserve state before redirecting to the login page.
* Recover the previous state after authentication using a query string parameter.

:::moniker range=">= aspnetcore-6.0"

```razor
...
@using Microsoft.AspNetCore.Components.WebAssembly.Authentication
@inject IAccessTokenProvider TokenProvider
@inject IJSRuntime JS
@inject NavigationManager Navigation

<EditForm Model="User" @onsubmit="OnSaveAsync">
    <label>User
        <InputText @bind-Value="User.Name" />
    </label>
    <label>Last name
        <InputText @bind-Value="User.LastName" />
    </label>
</EditForm>

@code {
    public class Profile
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
    }

    public Profile User { get; set; } = new Profile();

    protected override async Task OnInitializedAsync()
    {
        var currentQuery = new Uri(Navigation.Uri).Query;

        if (currentQuery.Contains("state=resumeSavingProfile"))
        {
            User = await JS.InvokeAsync<Profile>("sessionStorage.getItem", 
                "resumeSavingProfile");
        }
    }

    public async Task OnSaveAsync()
    {
        var http = new HttpClient();
        http.BaseAddress = new Uri(Navigation.BaseUri);

        var resumeUri = Navigation.Uri + $"?state=resumeSavingProfile";

        var tokenResult = await TokenProvider.RequestAccessToken(
            new AccessTokenRequestOptions
            {
                ReturnUrl = resumeUri
            });

        if (tokenResult.TryGetToken(out var token))
        {
            http.DefaultRequestHeaders.Add("Authorization", 
                $"Bearer {token.Value}");
            await http.PostAsJsonAsync("Save", User);
        }
        else
        {
            await JS.InvokeVoidAsync("sessionStorage.setItem", 
                "resumeSavingProfile", User);
            Navigation.NavigateTo(tokenResult.InteractiveRequestUrl);
        }
    }
}
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

```razor
...
@using Microsoft.AspNetCore.Components.WebAssembly.Authentication
@inject IAccessTokenProvider TokenProvider
@inject IJSRuntime JS
@inject NavigationManager Navigation

<EditForm Model="User" @onsubmit="OnSaveAsync">
    <label>User
        <InputText @bind-Value="User.Name" />
    </label>
    <label>Last name
        <InputText @bind-Value="User.LastName" />
    </label>
</EditForm>

@code {
    public class Profile
    {
        public string Name { get; set; }
        public string LastName { get; set; }
    }

    public Profile User { get; set; } = new Profile();

    protected override async Task OnInitializedAsync()
    {
        var currentQuery = new Uri(Navigation.Uri).Query;

        if (currentQuery.Contains("state=resumeSavingProfile"))
        {
            User = await JS.InvokeAsync<Profile>("sessionStorage.getItem", 
                "resumeSavingProfile");
        }
    }

    public async Task OnSaveAsync()
    {
        var http = new HttpClient();
        http.BaseAddress = new Uri(Navigation.BaseUri);

        var resumeUri = Navigation.Uri + $"?state=resumeSavingProfile";

        var tokenResult = await TokenProvider.RequestAccessToken(
            new AccessTokenRequestOptions
            {
                ReturnUrl = resumeUri
            });

        if (tokenResult.TryGetToken(out var token))
        {
            http.DefaultRequestHeaders.Add("Authorization", 
                $"Bearer {token.Value}");
            await http.PostAsJsonAsync("Save", User);
        }
        else
        {
            await JS.InvokeVoidAsync("sessionStorage.setItem", 
                "resumeSavingProfile", User);
            Navigation.NavigateTo(tokenResult.InteractiveRequestUrl);
        }
    }
}
```

:::moniker-end

## Save app state before an authentication operation with session storage and a state container

During an authentication operation, there are cases where you want to save the app state before the browser is redirected to the IP. This can be the case when you're using a state container and want to restore the state after the authentication succeeds. You can use a custom authentication state object to preserve app-specific state or a reference to it and restore that state after the authentication operation successfully completes. The following example demonstrates the approach.

A state container class is created in the app with properties to hold the app's state values. In the following example, the container is used to maintain the counter value of the default [Blazor project template's](xref:blazor/project-structure) `Counter` component (`Counter.razor`). Methods for serializing and deserializing the container are based on <xref:System.Text.Json>.

```csharp
using System.Text.Json;

public class StateContainer
{
    public int CounterValue { get; set; }

    public string GetStateForLocalStorage()
    {
        return JsonSerializer.Serialize(this);
    }

    public void SetStateFromLocalStorage(string locallyStoredState)
    {
        var deserializedState = 
            JsonSerializer.Deserialize<StateContainer>(locallyStoredState);

        CounterValue = deserializedState.CounterValue;
    }
}
```

The `Counter` component uses the state container to maintain the `currentCount` value outside of the component:

```razor
@page "/counter"
@inject StateContainer State

<h1>Counter</h1>

<p>Current count: @currentCount</p>

<button class="btn btn-primary" @onclick="IncrementCount">Click me</button>

@code {
    private int currentCount = 0;

    protected override void OnInitialized()
    {
        if (State.CounterValue > 0)
        {
            currentCount = State.CounterValue;
        }
    }

    private void IncrementCount()
    {
        currentCount++;
        State.CounterValue = currentCount;
    }
}
```

Create an `ApplicationAuthenticationState` from <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.RemoteAuthenticationState>. Provide an `Id` property, which serves as an identifier for the locally-stored state.

`ApplicationAuthenticationState.cs`:

:::moniker range=">= aspnetcore-6.0"

```csharp
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

public class ApplicationAuthenticationState : RemoteAuthenticationState
{
    public string? Id { get; set; }
}
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

```csharp
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

public class ApplicationAuthenticationState : RemoteAuthenticationState
{
    public string Id { get; set; }
}
```

:::moniker-end

The `Authentication` component (`Authentication.razor`) saves and restores the app's state using local session storage with the `StateContainer` serialization and deserialization methods, `GetStateForLocalStorage` and `SetStateFromLocalStorage`:

:::moniker range=">= aspnetcore-6.0"

```razor
@page "/authentication/{action}"
@inject IJSRuntime JS
@inject StateContainer State
@using Microsoft.AspNetCore.Components.WebAssembly.Authentication

<RemoteAuthenticatorViewCore Action="@Action"
                             TAuthenticationState="ApplicationAuthenticationState"
                             AuthenticationState="AuthenticationState"
                             OnLogInSucceeded="RestoreState"
                             OnLogOutSucceeded="RestoreState" />

@code {
    [Parameter]
    public string? Action { get; set; }

    public ApplicationAuthenticationState AuthenticationState { get; set; } =
        new ApplicationAuthenticationState();

    protected override async Task OnInitializedAsync()
    {
        if (RemoteAuthenticationActions.IsAction(RemoteAuthenticationActions.LogIn,
            Action) ||
            RemoteAuthenticationActions.IsAction(RemoteAuthenticationActions.LogOut,
            Action))
        {
            AuthenticationState.Id = Guid.NewGuid().ToString();

            await JS.InvokeVoidAsync("sessionStorage.setItem",
                AuthenticationState.Id, State.GetStateForLocalStorage());
        }
    }

    private async Task RestoreState(ApplicationAuthenticationState state)
    {
        if (state.Id != null)
        {
            var locallyStoredState = await JS.InvokeAsync<string>(
                "sessionStorage.getItem", state.Id);

            if (locallyStoredState != null)
            {
                State.SetStateFromLocalStorage(locallyStoredState);
                await JS.InvokeVoidAsync("sessionStorage.removeItem", state.Id);
            }
        }
    }
}
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

```razor
@page "/authentication/{action}"
@inject IJSRuntime JS
@inject StateContainer State
@using Microsoft.AspNetCore.Components.WebAssembly.Authentication

<RemoteAuthenticatorViewCore Action="@Action"
                             TAuthenticationState="ApplicationAuthenticationState"
                             AuthenticationState="AuthenticationState"
                             OnLogInSucceeded="RestoreState"
                             OnLogOutSucceeded="RestoreState" />

@code {
    [Parameter]
    public string Action { get; set; }

    public ApplicationAuthenticationState AuthenticationState { get; set; } =
        new ApplicationAuthenticationState();

    protected override async Task OnInitializedAsync()
    {
        if (RemoteAuthenticationActions.IsAction(RemoteAuthenticationActions.LogIn,
            Action) ||
            RemoteAuthenticationActions.IsAction(RemoteAuthenticationActions.LogOut,
            Action))
        {
            AuthenticationState.Id = Guid.NewGuid().ToString();

            await JS.InvokeVoidAsync("sessionStorage.setItem",
                AuthenticationState.Id, State.GetStateForLocalStorage());
        }
    }

    private async Task RestoreState(ApplicationAuthenticationState state)
    {
        if (state.Id != null)
        {
            var locallyStoredState = await JS.InvokeAsync<string>(
                "sessionStorage.getItem", state.Id);

            if (locallyStoredState != null)
            {
                State.SetStateFromLocalStorage(locallyStoredState);
                await JS.InvokeVoidAsync("sessionStorage.removeItem", state.Id);
            }
        }
    }
}
```

:::moniker-end

This example uses Microsoft Entra (ME-ID) for authentication. In the `Program` file:

* The `ApplicationAuthenticationState` is configured as the Microsoft Authentication Library (MSAL) `RemoteAuthenticationState` type.
* The state container is registered in the service container.

```csharp
builder.Services.AddMsalAuthentication<ApplicationAuthenticationState>(options =>
{
    builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
});

builder.Services.AddSingleton<StateContainer>();
```

## Customize app routes

By default, the [`Microsoft.AspNetCore.Components.WebAssembly.Authentication`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Authentication) library uses the routes shown in the following table for representing different authentication states.

| Route                            | Purpose |
| -------------------------------- | ------- |
| `authentication/login`           | Triggers a sign-in operation. |
| `authentication/login-callback`  | Handles the result of any sign-in operation. |
| `authentication/login-failed`    | Displays error messages when the sign-in operation fails for some reason. |
| `authentication/logout`          | Triggers a sign-out operation. |
| `authentication/logout-callback` | Handles the result of a sign-out operation. |
| `authentication/logout-failed`   | Displays error messages when the sign-out operation fails for some reason. |
| `authentication/logged-out`      | Indicates that the user has successfully logout. |
| `authentication/profile`         | Triggers an operation to edit the user profile. |
| `authentication/register`        | Triggers an operation to register a new user. |

The routes shown in the preceding table are configurable via <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.RemoteAuthenticationOptions%601.AuthenticationPaths%2A?displayProperty=nameWithType>. When setting options to provide custom routes, confirm that the app has a route that handles each path.

In the following example, all of the paths are prefixed with `/security`.

`Authentication` component (`Authentication.razor`):

:::moniker range=">= aspnetcore-6.0"

```razor
@page "/security/{action}"
@using Microsoft.AspNetCore.Components.WebAssembly.Authentication

<RemoteAuthenticatorView Action="@Action" />

@code{
    [Parameter]
    public string? Action { get; set; }
}
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

```razor
@page "/security/{action}"
@using Microsoft.AspNetCore.Components.WebAssembly.Authentication

<RemoteAuthenticatorView Action="@Action" />

@code{
    [Parameter]
    public string Action { get; set; }
}
```

:::moniker-end

In the `Program` file:

```csharp
builder.Services.AddApiAuthorization(options => { 
    options.AuthenticationPaths.LogInPath = "security/login";
    options.AuthenticationPaths.LogInCallbackPath = "security/login-callback";
    options.AuthenticationPaths.LogInFailedPath = "security/login-failed";
    options.AuthenticationPaths.LogOutPath = "security/logout";
    options.AuthenticationPaths.LogOutCallbackPath = "security/logout-callback";
    options.AuthenticationPaths.LogOutFailedPath = "security/logout-failed";
    options.AuthenticationPaths.LogOutSucceededPath = "security/logged-out";
    options.AuthenticationPaths.ProfilePath = "security/profile";
    options.AuthenticationPaths.RegisterPath = "security/register";
});
```

If the requirement calls for completely different paths, set the routes as described previously and render the <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.RemoteAuthenticatorView> with an explicit action parameter:

```razor
@page "/register"

<RemoteAuthenticatorView Action="@RemoteAuthenticationActions.Register" />
```

You're allowed to break the UI into different pages if you choose to do so.

## Customize the authentication user interface

<xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.RemoteAuthenticatorView> includes a default set of UI fragments for each authentication state. Each state can be customized by passing in a custom <xref:Microsoft.AspNetCore.Components.RenderFragment>. To customize the displayed text during the initial login process, can change the <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.RemoteAuthenticatorView> as follows.

`Authentication` component (`Authentication.razor`):

:::moniker range=">= aspnetcore-6.0"

```razor
@page "/security/{action}"
@using Microsoft.AspNetCore.Components.WebAssembly.Authentication

<RemoteAuthenticatorView Action="@Action">
    <LoggingIn>
        You are about to be redirected to https://login.microsoftonline.com.
    </LoggingIn>
</RemoteAuthenticatorView>

@code{
    [Parameter]
    public string? Action { get; set; }
}
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

```razor
@page "/security/{action}"
@using Microsoft.AspNetCore.Components.WebAssembly.Authentication

<RemoteAuthenticatorView Action="@Action">
    <LoggingIn>
        You are about to be redirected to https://login.microsoftonline.com.
    </LoggingIn>
</RemoteAuthenticatorView>

@code{
    [Parameter]
    public string Action { get; set; }
}
```

:::moniker-end

The <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.RemoteAuthenticatorView> has one fragment that can be used per authentication route shown in the following table.

| Route                            | Fragment                |
| -------------------------------- | ----------------------- |
| `authentication/login`           | `<LoggingIn>`           |
| `authentication/login-callback`  | `<CompletingLoggingIn>` |
| `authentication/login-failed`    | `<LogInFailed>`         |
| `authentication/logout`          | `<LogOut>`              |
| `authentication/logout-callback` | `<CompletingLogOut>`    |
| `authentication/logout-failed`   | `<LogOutFailed>`        |
| `authentication/logged-out`      | `<LogOutSucceeded>`     |
| `authentication/profile`         | `<UserProfile>`         |
| `authentication/register`        | `<Registering>`         |

## Customize the user

Users bound to the app can be customized.

### Customize the user with a payload claim

In the following example, the app's authenticated users receive an `amr` claim for each of the user's authentication methods. The `amr` claim identifies how the subject of the token was authenticated in Microsoft Identity Platform v1.0 [payload claims](/azure/active-directory/develop/access-tokens#amr-claim). The example uses a custom user account class based on <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.RemoteUserAccount>.

Create a class that extends the <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.RemoteUserAccount> class. The following example sets the `AuthenticationMethod` property to the user's array of `amr` JSON property values. `AuthenticationMethod` is populated automatically by the framework when the user is authenticated.

:::moniker range=">= aspnetcore-6.0"

```csharp
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

public class CustomUserAccount : RemoteUserAccount
{
    [JsonPropertyName("amr")]
    public string[]? AuthenticationMethod { get; set; }
}
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

```csharp
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

public class CustomUserAccount : RemoteUserAccount
{
    [JsonPropertyName("amr")]
    public string[] AuthenticationMethod { get; set; }
}
```

:::moniker-end

Create a factory that extends <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.AccountClaimsPrincipalFactory%601> to create claims from the user's authentication methods stored in `CustomUserAccount.AuthenticationMethod`:

:::moniker range=">= aspnetcore-6.0"

```csharp
using System.Security.Claims;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;

public class CustomAccountFactory 
    : AccountClaimsPrincipalFactory<CustomUserAccount>
{
    public CustomAccountFactory(NavigationManager navigation, 
        IAccessTokenProviderAccessor accessor) : base(accessor)
    {
    }
  
    public override async ValueTask<ClaimsPrincipal> CreateUserAsync(
        CustomUserAccount account, RemoteAuthenticationUserOptions options)
    {
        var initialUser = await base.CreateUserAsync(account, options);

        if (initialUser.Identity != null && initialUser.Identity.IsAuthenticated)
        {
            var userIdentity = (ClaimsIdentity)initialUser.Identity;

            if (account.AuthenticationMethod is not null)
            {
                foreach (var value in account.AuthenticationMethod)
                {
                    userIdentity.AddClaim(new Claim("amr", value));
                }
            }
        }

        return initialUser;
    }
}
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

```csharp
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;

public class CustomAccountFactory 
    : AccountClaimsPrincipalFactory<CustomUserAccount>
{
    public CustomAccountFactory(NavigationManager navigation, 
        IAccessTokenProviderAccessor accessor) : base(accessor)
    {
    }
  
    public override async ValueTask<ClaimsPrincipal> CreateUserAsync(
        CustomUserAccount account, RemoteAuthenticationUserOptions options)
    {
        var initialUser = await base.CreateUserAsync(account, options);

        if (initialUser.Identity != null && initialUser.Identity.IsAuthenticated)
        {
            var userIdentity = (ClaimsIdentity)initialUser.Identity;

            foreach (var value in account.AuthenticationMethod)
            {
                userIdentity.AddClaim(new Claim("amr", value));
            }
        }

        return initialUser;
    }
}
```

:::moniker-end

Register the `CustomAccountFactory` for the authentication provider in use. Any of the following registrations are valid:

* <xref:Microsoft.Extensions.DependencyInjection.WebAssemblyAuthenticationServiceCollectionExtensions.AddOidcAuthentication%2A>:

  ```csharp
  using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

  ...

  builder.Services.AddOidcAuthentication<RemoteAuthenticationState, 
      CustomUserAccount>(options =>
      {
          ...
      })
      .AddAccountClaimsPrincipalFactory<RemoteAuthenticationState, 
          CustomUserAccount, CustomAccountFactory>();
  ```

* <xref:Microsoft.Extensions.DependencyInjection.MsalWebAssemblyServiceCollectionExtensions.AddMsalAuthentication%2A>:

  ```csharp
  using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

  ...

  builder.Services.AddMsalAuthentication<RemoteAuthenticationState, 
      CustomUserAccount>(options =>
      {
          ...
      })
      .AddAccountClaimsPrincipalFactory<RemoteAuthenticationState, 
          CustomUserAccount, CustomAccountFactory>();
  ```
  
* <xref:Microsoft.Extensions.DependencyInjection.WebAssemblyAuthenticationServiceCollectionExtensions.AddApiAuthorization%2A>:

  ```csharp
  using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

  ...

  builder.Services.AddApiAuthorization<RemoteAuthenticationState, 
      CustomUserAccount>(options =>
      {
          ...
      })
      .AddAccountClaimsPrincipalFactory<RemoteAuthenticationState, 
          CustomUserAccount, CustomAccountFactory>();
  ```

### ME-ID security groups and roles with a custom user account class

For an additional example that works with ME-ID security groups and ME-ID Administrator Roles and a custom user account class, see <xref:blazor/security/webassembly/meid-groups-roles>.

<!-- UPDATE 8.0 This entire scenario is based on hosted WASM.
                A similar approach might need to be created
                for WebAssembly rendering in BWAs -->

:::moniker range="< aspnetcore-8.0"

## Prerendering with authentication

Prerendering content that requires authentication and authorization isn't currently supported. After following the guidance in one of the Blazor WebAssembly security app topics, use the following instructions to create an app that:

* Prerenders paths for which authorization isn't required.
* Doesn't prerender paths for which authorization is required.

For the **:::no-loc text="Client":::** project's the `Program` file file, factor common service registrations into a separate method (for example, create a `ConfigureCommonServices` method in the **:::no-loc text="Client":::** project). Common services are those that the developer registers for use by both the client and server projects.

```csharp
public static void ConfigureCommonServices(IServiceCollection services)
{
    services.Add...;
}
```

In the `Program` file:

```csharp
var builder = WebAssemblyHostBuilder.CreateDefault(args);
...

builder.Services.AddScoped( ... );

ConfigureCommonServices(builder.Services);

await builder.Build().RunAsync();
```

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

In the **:::no-loc text="Server":::** project's the `Program` file file, register the following additional services and call `ConfigureCommonServices`:

```csharp
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

...

builder.Services.AddRazorPages();
builder.Services.TryAddScoped<AuthenticationStateProvider, 
    ServerAuthenticationStateProvider>();

Client.Program.ConfigureCommonServices(services);
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

In the **:::no-loc text="Server":::** project's `Startup.ConfigureServices` method, register the following additional services and call `ConfigureCommonServices`:

```csharp
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

public void ConfigureServices(IServiceCollection services)
{
    ...

    services.AddRazorPages();
    services.AddScoped<AuthenticationStateProvider, 
        ServerAuthenticationStateProvider>();
    services.AddScoped<SignOutSessionStateManager>();

    Client.Program.ConfigureCommonServices(services);
}
```

:::moniker-end

:::moniker range="< aspnetcore-8.0"

For more information on the Blazor framework server authentication provider (`ServerAuthenticationStateProvider`), see <xref:blazor/security/index#authenticationstateprovider>.

In the **:::no-loc text="Server":::** project's `Pages/_Host.cshtml` file, replace the `Component` Tag Helper (`<component ... />`) with the following:

```cshtml
<div id="app">
    @if (HttpContext.Request.Path.StartsWithSegments("/authentication"))
    {
        <component type="typeof({CLIENT APP ASSEMBLY NAME}.App)" 
            render-mode="WebAssembly" />
    }
    else
    {
        <component type="typeof({CLIENT APP ASSEMBLY NAME}.App)" 
            render-mode="WebAssemblyPrerendered" />
    }
</div>
```

In the preceding example:

* The placeholder `{CLIENT APP ASSEMBLY NAME}` is the client app's assembly name (for example `BlazorSample.Client`).
* The conditional check for the `/authentication` path segment:
  * Avoids prerendering (`render-mode="WebAssembly"`) for authentication paths.
  * Prerenders (`render-mode="WebAssemblyPrerendered"`) for non-authentication paths.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

## Options for hosted apps and third-party login providers

When authenticating and authorizing a hosted Blazor WebAssembly app with a third-party provider, there are several options available for authenticating the user. Which one you choose depends on your scenario.

For more information, see <xref:security/authentication/social/additional-claims>.

:::moniker-end

### Authenticate users to only call protected third party APIs

Authenticate the user with a client-side OAuth flow against the third-party API provider:

 ```csharp
 builder.services.AddOidcAuthentication(options => { ... });
 ```
 
 In this scenario:

* The server hosting the app doesn't play a role.
* APIs on the server can't be protected.
* The app can only call protected third-party APIs.

### Authenticate users with a third-party provider and call protected APIs on the host server and the third party

Configure Identity with a third-party login provider. Obtain the tokens required for third-party API access and store them.

When a user logs in, Identity collects access and refresh tokens as part of the authentication process. At that point, there are a couple of approaches available for making API calls to third-party APIs.

#### Use a server access token to retrieve the third-party access token

Use the access token generated on the server to retrieve the third-party access token from a server API endpoint. From there, use the third-party access token to call third-party API resources directly from Identity on the client.

***We don't recommend this approach.*** This approach requires treating the third-party access token as if it were generated for a public client. In OAuth terms, the public app doesn't have a client secret because it can't be trusted to store secrets safely, and the access token is produced for a confidential client. A confidential client is a client that has a client secret and is assumed to be able to safely store secrets.

* The third-party access token might be granted additional scopes to perform sensitive operations based on the fact that the third-party emitted the token for a more trusted client.
* Similarly, refresh tokens shouldn't be issued to a client that isn't trusted, as doing so gives the client unlimited access unless other restrictions are put into place.

#### Make API calls from the client to the server API in order to call third-party APIs

Make an API call from the client to the server API. From the server, retrieve the access token for the third-party API resource and issue whatever call is necessary.

***We recommend this approach.*** While this approach requires an extra network hop through the server to call a third-party API, it ultimately results in a safer experience:

* The server can store refresh tokens and ensure that the app doesn't lose access to third-party resources.
* The app can't leak access tokens from the server that might contain more sensitive permissions.

## Use OpenID Connect (OIDC) v2.0 endpoints

The authentication library and [Blazor project templates](xref:blazor/project-structure) use OpenID Connect (OIDC) v1.0 endpoints. To use a v2.0 endpoint, configure the JWT Bearer <xref:Microsoft.AspNetCore.Builder.JwtBearerOptions.Authority?displayProperty=nameWithType> option. In the following example, ME-ID is configured for v2.0 by appending a `v2.0` segment to the <xref:Microsoft.AspNetCore.Builder.JwtBearerOptions.Authority> property:

```csharp
using Microsoft.AspNetCore.Authentication.JwtBearer;

...

builder.Services.Configure<JwtBearerOptions>(
    JwtBearerDefaults.AuthenticationScheme, 
    options =>
    {
        options.Authority += "/v2.0";
    });
```

Alternatively, the setting can be made in the app settings (`appsettings.json`) file:

```json
{
  "Local": {
    "Authority": "https://login.microsoftonline.com/common/oauth2/v2.0/",
    ...
  }
}
```

If tacking on a segment to the authority isn't appropriate for the app's OIDC provider, such as with non-ME-ID providers, set the <xref:Microsoft.AspNetCore.Builder.OpenIdConnectOptions.Authority> property directly. Either set the property in <xref:Microsoft.AspNetCore.Builder.JwtBearerOptions> or in the app settings file (`appsettings.json`) with the `Authority` key.

The list of claims in the ID token changes for v2.0 endpoints. For more information, see [Why update to Microsoft identity platform (v2.0)?](/azure/active-directory/azuread-dev/azure-ad-endpoint-comparison).

:::moniker range="< aspnetcore-8.0"

<!-- UPDATE 8.0 This section was written for hosted WASM.
     Check with PU to see if we'll maintain it with mods
     in the BWA/WebAssembly world. -->

## Configure and use gRPC in components

To configure a Blazor WebAssembly app to use the [ASP.NET Core gRPC framework](xref:grpc/index):

* Enable gRPC-Web on the server. For more information, see <xref:grpc/grpcweb>.
* Register gRPC services for the app's message handler. The following example configures the app's authorization message handler to use the [`GreeterClient` service from the gRPC tutorial](xref:tutorials/grpc/grpc-start#create-a-grpc-service) (the `Program` file):

```csharp
using System.Net.Http;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using {ASSEMBLY NAME}.Shared;

...

builder.Services.AddScoped(sp =>
{
    var baseAddressMessageHandler = 
        sp.GetRequiredService<BaseAddressAuthorizationMessageHandler>();
    baseAddressMessageHandler.InnerHandler = new HttpClientHandler();
    var grpcWebHandler = 
        new GrpcWebHandler(GrpcWebMode.GrpcWeb, baseAddressMessageHandler);
    var channel = GrpcChannel.ForAddress(builder.HostEnvironment.BaseAddress, 
        new GrpcChannelOptions { HttpHandler = grpcWebHandler });

    return new Greeter.GreeterClient(channel);
});
```

The placeholder `{ASSEMBLY NAME}` is the app's assembly name (for example, `BlazorSample`). Place the `.proto` file in the `Shared` project of the hosted Blazor solution.

A component in the client app can make gRPC calls using the gRPC client (`Grpc.razor`):

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

```razor
@page "/grpc"
@using Microsoft.AspNetCore.Authorization
@using {ASSEMBLY NAME}.Shared
@attribute [Authorize]
@inject Greeter.GreeterClient GreeterClient

<h1>Invoke gRPC service</h1>

<p>
    <input @bind="name" placeholder="Type your name" />
    <button @onclick="GetGreeting" class="btn btn-primary">Call gRPC service</button>
</p>

Server response: <strong>@serverResponse</strong>

@code {
    private string name = "Bert";
    private string? serverResponse;

    private async Task GetGreeting()
    {
        try
        {
            var request = new HelloRequest { Name = name };
            var reply = await GreeterClient.SayHelloAsync(request);
            serverResponse = reply.Message;
        }
        catch (Grpc.Core.RpcException ex)
            when (ex.Status.DebugException is 
                AccessTokenNotAvailableException tokenEx)
        {
            tokenEx.Redirect();
        }
    }
}
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

```razor
@page "/grpc"
@using Microsoft.AspNetCore.Authorization
@using {ASSEMBLY NAME}.Shared
@attribute [Authorize]
@inject Greeter.GreeterClient GreeterClient

<h1>Invoke gRPC service</h1>

<p>
    <input @bind="name" placeholder="Type your name" />
    <button @onclick="GetGreeting" class="btn btn-primary">Call gRPC service</button>
</p>

Server response: <strong>@serverResponse</strong>

@code {
    private string name = "Bert";
    private string serverResponse;

    private async Task GetGreeting()
    {
        try
        {
            var request = new HelloRequest { Name = name };
            var reply = await GreeterClient.SayHelloAsync(request);
            serverResponse = reply.Message;
        }
        catch (Grpc.Core.RpcException ex)
            when (ex.Status.DebugException is 
                AccessTokenNotAvailableException tokenEx)
        {
            tokenEx.Redirect();
        }
    }
}
```

:::moniker-end

:::moniker range="< aspnetcore-8.0"

The placeholder `{ASSEMBLY NAME}` is the app's assembly name (for example, `BlazorSample`). To use the `Status.DebugException` property, use [`Grpc.Net.Client`](https://www.nuget.org/packages/Grpc.Net.Client) version 2.30.0 or later.

For more information, see <xref:grpc/grpcweb>.

:::moniker-end

## Replace the `AuthenticationService` implementation

The following subsections explain how to replace:

* Any JavaScript `AuthenticationService` implementation.
* The Microsoft Authentication Library for JavaScript (`MSAL.js`).

### Replace any JavaScript `AuthenticationService` implementation

Create a JavaScript library to handle your custom authentication details.

> [!WARNING]
> The guidance in this section is an implementation detail of the default <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.RemoteAuthenticationService%603>. The TypeScript code in this section applies specifically to ASP.NET Core 7.0 and is subject to change without notice in upcoming releases of ASP.NET Core.

```typescript
// .NET makes calls to an AuthenticationService object in the Window.
declare global {
  interface Window { AuthenticationService: AuthenticationService }
}

export interface AuthenticationService {
  // Init is called to initialize the AuthenticationService.
  public static init(settings: UserManagerSettings & AuthorizeServiceSettings, logger: any) : Promise<void>;

  // Gets the currently authenticated user.
  public static getUser() : Promise<{[key: string] : string }>;

  // Tries to get an access token silently.
  public static getAccessToken(options: AccessTokenRequestOptions) : Promise<AccessTokenResult>;

  // Tries to sign in the user or get an access token interactively.
  public static signIn(context: AuthenticationContext) : Promise<AuthenticationResult>;

  // Handles the sign-in process when a redirect is used.
  public static async completeSignIn(url: string) : Promise<AuthenticationResult>;

  // Signs the user out.
  public static signOut(context: AuthenticationContext) : Promise<AuthenticationResult>;

  // Handles the signout callback when a redirect is used.
  public static async completeSignOut(url: string) : Promise<AuthenticationResult>;
}

// The rest of these interfaces match their C# definitions.

export interface AccessTokenRequestOptions {
  scopes: string[];
  returnUrl: string;
}

export interface AccessTokenResult {
  status: AccessTokenResultStatus;
  token?: AccessToken;
}

export interface AccessToken {
  value: string;
  expires: Date;
  grantedScopes: string[];
}

export enum AccessTokenResultStatus {
  Success = 'Success',
  RequiresRedirect = 'RequiresRedirect'
}

export enum AuthenticationResultStatus {
  Redirect = 'Redirect',
  Success = 'Success',
  Failure = 'Failure',
  OperationCompleted = 'OperationCompleted'
};

export interface AuthenticationResult {
  status: AuthenticationResultStatus;
  state?: unknown;
  message?: string;
}

export interface AuthenticationContext {
  state?: unknown;
  interactiveRequest: InteractiveAuthenticationRequest;
}

export interface InteractiveAuthenticationRequest {
  scopes?: string[];
  additionalRequestParameters?: { [key: string]: any };
};
```

You can import the library by removing the original `<script>` tag and adding a `<script>` tag that loads the custom library. The following example demonstrates replacing the default `<script>` tag with one that loads a library named `CustomAuthenticationService.js` from the `wwwroot/js` folder.

In `wwwroot/index.html` before the Blazor script (`_framework/blazor.webassembly.js`) inside the closing `</body>` tag:

```diff
- <script src="_content/Microsoft.Authentication.WebAssembly.Msal/AuthenticationService.js"></script>
+ <script src="js/CustomAuthenticationService.js"></script>
```

For more information, see [`AuthenticationService.ts` in the `dotnet/aspnetcore` GitHub repository](https://github.com/dotnet/aspnetcore/blob/main/src/Components/WebAssembly/WebAssembly.Authentication/src/Interop/AuthenticationService.ts).

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

### Replace the Microsoft Authentication Library for JavaScript (`MSAL.js`)

If an app requires a custom version of the [Microsoft Authentication Library for JavaScript (`MSAL.js`)](https://www.npmjs.com/package/@azure/msal-browser), perform the following steps:

1. Confirm the system has the latest developer .NET SDK or obtain and install the latest developer SDK from [.NET Core SDK: Installers and Binaries](https://github.com/dotnet/installer#installers-and-binaries). Configuration of internal NuGet feeds isn't required for this scenario.
1. Set up the `dotnet/aspnetcore` GitHub repository for development following the documentation at [Build ASP.NET Core from Source](https://github.com/dotnet/aspnetcore/blob/main/docs/BuildFromSource.md). Fork and clone or download a ZIP archive of the [`dotnet/aspnetcore` GitHub repository](https://github.com/dotnet/aspnetcore).
1. Open the `src/Components/WebAssembly/Authentication.Msal/src/Interop/package.json` file and set the desired version of `@azure/msal-browser`. For a list of released versions, visit the [`@azure/msal-browser` npm website](https://www.npmjs.com/package/@azure/msal-browser) and select the **Versions** tab.
1. Build the `Authentication.Msal` project in the `src/Components/WebAssembly/Authentication.Msal/src` folder with the `yarn build` command in a command shell.
1. If the app uses [compressed assets (Brotli/Gzip)](xref:blazor/host-and-deploy/webassembly#compression), compress the `Interop/dist/Release/AuthenticationService.js` file.
1. Copy the `AuthenticationService.js` file and compressed versions (`.br`/`.gz`) of the file, if produced, from the `Interop/dist/Release` folder into the app's `publish/wwwroot/_content/Microsoft.Authentication.WebAssembly.Msal` folder in the app's published assets.

## Pass custom provider options

Define a class for passing the data to the underlying JavaScript library. 

> [!IMPORTANT]
> The class's structure must match what the library expects when the JSON is serialized with <xref:System.Text.Json?displayProperty=fullName>.

The following example demonstrates a `ProviderOptions` class with [`JsonPropertyName` attributes](xref:System.Text.Json.Serialization.JsonPropertyNameAttribute) matching a hypothetical custom provider library's expectations:

:::moniker range=">= aspnetcore-6.0"

```csharp
public class ProviderOptions
{
    public string? Authority { get; set; }
    public string? MetadataUrl { get; set; }
    
    [JsonPropertyName("client_id")]
    public string? ClientId { get; set; }
    
    public IList<string> DefaultScopes { get; } = 
        new List<string> { "openid", "profile" };
        
    [JsonPropertyName("redirect_uri")]
    public string? RedirectUri { get; set; }
    
    [JsonPropertyName("post_logout_redirect_uri")]
    public string? PostLogoutRedirectUri { get; set; }
    
    [JsonPropertyName("response_type")]
    public string? ResponseType { get; set; }
    
    [JsonPropertyName("response_mode")]
    public string? ResponseMode { get; set; }
}
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

```csharp
public class ProviderOptions
{
    public string Authority { get; set; }
    public string MetadataUrl { get; set; }
    
    [JsonPropertyName("client_id")]
    public string ClientId { get; set; }
    
    public IList<string> DefaultScopes { get; } = 
        new List<string> { "openid", "profile" };
        
    [JsonPropertyName("redirect_uri")]
    public string RedirectUri { get; set; }
    
    [JsonPropertyName("post_logout_redirect_uri")]
    public string PostLogoutRedirectUri { get; set; }
    
    [JsonPropertyName("response_type")]
    public string ResponseType { get; set; }
    
    [JsonPropertyName("response_mode")]
    public string ResponseMode { get; set; }
}
```

:::moniker-end

Register the provider options within the DI system and configure the appropriate values:

```csharp
builder.Services.AddRemoteAuthentication<RemoteAuthenticationState, RemoteUserAccount,
    ProviderOptions>(options => {
        options.Authority = "...";
        options.MetadataUrl = "...";
        options.ClientId = "...";
        options.DefaultScopes = new List<string> { "openid", "profile", "myApi" };
        options.RedirectUri = "https://localhost:5001/authentication/login-callback";
        options.PostLogoutRedirectUri = "https://localhost:5001/authentication/logout-callback";
        options.ResponseType = "...";
        options.ResponseMode = "...";
    });
```

The preceding example sets redirect URIs with regular string literals. The following alternatives are available:

* <xref:System.Uri.TryCreate%2A> using <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.IWebAssemblyHostEnvironment.BaseAddress?displayProperty=nameWithType>:

  ```csharp
  Uri.TryCreate(
      $"{builder.HostEnvironment.BaseAddress}authentication/login-callback", 
      UriKind.Absolute, out var redirectUri);
  options.RedirectUri = redirectUri;
  ```
  
* [Host builder configuration](xref:blazor/fundamentals/configuration#host-builder-configuration):

  ```csharp
  options.RedirectUri = builder.Configuration["RedirectUri"];
  ```
  
  `wwwroot/appsettings.json`:
  
  ```json
  {
    "RedirectUri": "https://localhost:5001/authentication/login-callback"
  }
  ```

## Additional resources

* <xref:blazor/security/webassembly/graph-api>
* [`HttpClient` and `HttpRequestMessage` with Fetch API request options](xref:blazor/call-web-api#httpclient-and-httprequestmessage-with-fetch-api-request-options)
