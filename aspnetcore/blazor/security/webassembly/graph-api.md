---
title: Use Graph API with ASP.NET Core Blazor WebAssembly
author: guardrex
description: Learn how to use the Microsoft Graph SDK/API with Blazor WebAssembly apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 03/22/2023
uid: blazor/security/webassembly/graph-api
zone_pivot_groups: blazor-graph-api
---
# Use Graph API with ASP.NET Core Blazor WebAssembly

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how to use [Microsoft Graph API](/graph/use-the-api) in Blazor WebAssembly apps, which is a RESTful web API that enables apps to access Microsoft Cloud service resources.

Two approaches are available for directly interacting with Microsoft Graph in Blazor apps:

* **Graph SDK**: The [Microsoft Graph SDKs](/graph/sdks/sdks-overview) are designed to simplify building high-quality, efficient, and resilient applications that access Microsoft Graph. Select the **Graph SDK** button at the top of this article to adopt this approach.

* **Named HttpClient with Graph API**: A [named `HttpClient`](xref:blazor/call-web-api#named-httpclient-with-ihttpclientfactory) can issue web API requests to directly to Graph API. Select the **Named HttpClient with Graph API** button at the top of this article to adopt this approach.

The guidance in this article isn't meant to replace the primary [Microsoft Graph documentation](/graph/) and additional Azure security guidance in other Microsoft documentation sets. Assess the security guidance in the [Additional resources](#additional-resources) section of this article before implementing Microsoft Graph in a production environment. Follow all of Microsoft's best practices to limit the attack surface area of your apps.

> [!IMPORTANT]
> The scenarios described in this article apply to using Microsoft Entra (ME-ID) as the identity provider, not AAD B2C. Using Microsoft Graph with a client-side Blazor WebAssembly app and the AAD B2C identity provider isn't supported at this time.

:::moniker range="< aspnetcore-8.0"

Using a hosted Blazor WebAssembly app is supported, where the **:::no-loc text="Server":::** app uses the Graph SDK/API to provide Graph data to the **:::no-loc text="Client":::** app via web API. For more information, see the [Hosted Blazor WebAssembly solutions](#hosted-blazor-webassembly-solutions) section of this article.

:::moniker-end

The examples in this article take advantage of recent .NET features released with ASP.NET Core 6.0 or later. When using the examples in ASP.NET Core 5.0 or earlier, minor modifications are required. However, the text and code examples that pertain to interacting with Microsoft Graph are the same for all versions of ASP.NET Core.

:::zone pivot="graph-sdk-5"

*The following guidance applies to Microsoft Graph v5.*

The Microsoft Graph SDK for use in Blazor apps is called the *Microsoft Graph .NET Client Library*.

:::moniker range=">= aspnetcore-8.0"

The Graph SDK examples require the following package references in the standalone Blazor WebAssembly app:

:::moniker-end

:::moniker range="< aspnetcore-8.0"

The Graph SDK examples require the following package references in the standalone Blazor WebAssembly app or the **:::no-loc text="Client":::** app of a hosted Blazor WebAssembly solution:

:::moniker-end

* [`Microsoft.Extensions.Http`](https://www.nuget.org/packages/Microsoft.Extensions.Http)
* [`Microsoft.Graph`](https://www.nuget.org/packages/Microsoft.Graph)

[!INCLUDE[](~/includes/package-reference.md)]

After adding the Microsoft Graph API scopes in the ME-ID area of the Azure portal, add the following app settings configuration to the `wwwroot/appsettings.json` file, which includes the Graph base URL with Graph version and scopes. In the following example, the `User.Read` scope is specified for the examples in later sections of this article.

```json
"MicrosoftGraph": {
  "BaseUrl": "https://graph.microsoft.com/{VERSION}",
  "Scopes": [
    "user.read"
  ]
}
```

In the preceding example, the `{VERSION}` placeholder is the version of the MS Graph API (for example: `v1.0`).

:::moniker range=">= aspnetcore-8.0"

Add the following `GraphClientExtensions` class to the standalone app. The scopes are provided to the <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.AccessTokenRequestOptions.Scopes> property of the <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.AccessTokenRequestOptions> in the `AuthenticateRequestAsync` method.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

Add the following `GraphClientExtensions` class to the standalone app or **:::no-loc text="Client":::** app of a hosted Blazor WebAssembly [solution](xref:blazor/tooling#visual-studio-solution-file-sln). The scopes are provided to the <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.AccessTokenRequestOptions.Scopes> property of the <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.AccessTokenRequestOptions> in the `AuthenticateRequestAsync` method.

:::moniker-end

When an access token isn't obtained, the following code doesn't set a Bearer authorization header for Graph requests. 

`GraphClientExtensions.cs`:

```csharp
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Authentication.WebAssembly.Msal.Models;
using Microsoft.Graph;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Authentication;
using IAccessTokenProvider = 
    Microsoft.AspNetCore.Components.WebAssembly.Authentication.IAccessTokenProvider;

internal static class GraphClientExtensions
{
    public static IServiceCollection AddGraphClient(
            this IServiceCollection services, string? baseUrl, List<string>? scopes)
    {
        if (string.IsNullOrEmpty(baseUrl) || scopes.IsNullOrEmpty())
        {
            return services;
        }

        services.Configure<RemoteAuthenticationOptions<MsalProviderOptions>>(
            options =>
            {
                scopes?.ForEach((scope) =>
                {
                    options.ProviderOptions.DefaultAccessTokenScopes.Add(scope);
                });
            });

        services.AddScoped<IAuthenticationProvider, GraphAuthenticationProvider>();

        services.AddScoped(sp =>
        {
            return new GraphServiceClient(
                new HttpClient(),
                sp.GetRequiredService<IAuthenticationProvider>(),
                baseUrl);
        });

        return services;
    }

    private class GraphAuthenticationProvider : IAuthenticationProvider
    {
        private readonly IConfiguration config;

        public GraphAuthenticationProvider(IAccessTokenProvider tokenProvider,
            IConfiguration config)
        {
            TokenProvider = tokenProvider;
            this.config = config;
        }

        public IAccessTokenProvider TokenProvider { get; }

        public async Task AuthenticateRequestAsync(RequestInformation request, 
            Dictionary<string, object>? additionalAuthenticationContext = null, 
            CancellationToken cancellationToken = default)
        {
            var result = await TokenProvider.RequestAccessToken(
                new AccessTokenRequestOptions()
                {
                    Scopes = 
                        config.GetSection("MicrosoftGraph:Scopes").Get<string[]>()
                });

            if (result.TryGetToken(out var token))
            {
                request.Headers.Add("Authorization", 
                    $"{CoreConstants.Headers.Bearer} {token.Value}");
            }
        }
    }
}
```

In the `Program` file, add the Graph client services and configuration with the `AddGraphClient` extension method:

```csharp
var baseUrl = builder.Configuration.GetSection("MicrosoftGraph")["BaseUrl"];
var scopes = builder.Configuration.GetSection("MicrosoftGraph:Scopes")
    .Get<List<string>>();

builder.Services.AddGraphClient(baseUrl, scopes);
```

## Call Graph API from a component using the Graph SDK

The following `GraphExample` component uses an injected `GraphServiceClient` to obtain the user's ME-ID profile data and display their mobile phone number. For any test user that you create in ME-ID, make sure that you give the user's ME-ID profile a mobile phone number in the Azure portal.

`GraphExample.razor`:

```razor
@page "/graph-example"
@using Microsoft.AspNetCore.Authorization
@using Microsoft.Graph
@attribute [Authorize]
@inject GraphServiceClient Client

<h1>Microsoft Graph Component Example</h1>

@if (!string.IsNullOrEmpty(user?.MobilePhone))
{
    <p>Mobile Phone: @user.MobilePhone</p>
}

@code {
    private Microsoft.Graph.Models.User? user;

    protected override async Task OnInitializedAsync()
    {
        user = await Client.Me.GetAsync();
    }
}
```

When testing with the Graph SDK locally, we recommend using a new in-private/incognito browser session for each test to prevent lingering cookies from interfering with tests. For more information, see <xref:blazor/security/webassembly/standalone-with-microsoft-entra-id#troubleshoot>.

## Customize user claims using the Graph SDK

In the following example, the app creates mobile phone number and office location claims for a user from their ME-ID user profile's data. The app must have the `User.Read` Graph API scope configured in ME-ID. Any test users for this scenario must have a mobile phone number and office location in their ME-ID profile, which can be added via the Azure portal.

In the following custom user account factory:

* An <xref:Microsoft.Extensions.Logging.ILogger> (`logger`) is included for convenience in case you wish to log information or errors in the `CreateUserAsync` method.
* In the event that an <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.AccessTokenNotAvailableException> is thrown, the user is redirected to the identity provider to sign into their account. Additional or different actions can be taken when requesting an access token fails. For example, the app can log the <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.AccessTokenNotAvailableException> and create a support ticket for further investigation.
* The framework's <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.RemoteUserAccount> represents the user's account. If the app requires a custom user account class that extends <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.RemoteUserAccount>, swap your custom user account class for <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.RemoteUserAccount> in the following code.

`CustomAccountFactory.cs`:

```csharp
using System.Security.Claims;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;
using Microsoft.Graph;
using Microsoft.Kiota.Abstractions.Authentication;

public class CustomAccountFactory
    : AccountClaimsPrincipalFactory<RemoteUserAccount>
{
    private readonly ILogger<CustomAccountFactory> logger;
    private readonly IServiceProvider serviceProvider;
    private readonly string? baseUrl;

    public CustomAccountFactory(IAccessTokenProviderAccessor accessor,
        IServiceProvider serviceProvider,
        ILogger<CustomAccountFactory> logger,
        IConfiguration config)
        : base(accessor)
    {
        this.serviceProvider = serviceProvider;
        this.logger = logger;
        baseUrl = config.GetSection("MicrosoftGraph")["BaseUrl"];
    }

    public override async ValueTask<ClaimsPrincipal> CreateUserAsync(
        RemoteUserAccount account,
        RemoteAuthenticationUserOptions options)
    {
        var initialUser = await base.CreateUserAsync(account, options);

        if (initialUser.Identity is not null &&
            initialUser.Identity.IsAuthenticated)
        {
            var userIdentity = initialUser.Identity as ClaimsIdentity;

            if (userIdentity is not null && !string.IsNullOrEmpty(baseUrl))
            {
                try
                {
                    var client = new GraphServiceClient(
                        new HttpClient(),
                        serviceProvider
                            .GetRequiredService<IAuthenticationProvider>(),
                        baseUrl);

                    var user = await client.Me.GetAsync();
              
                    if (user is not null)
                    {
                        userIdentity.AddClaim(new Claim("mobilephone",
                            user.MobilePhone ?? "(000) 000-0000"));
                        userIdentity.AddClaim(new Claim("officelocation",
                            user.OfficeLocation ?? "Not set"));
                    }
                }
                catch (AccessTokenNotAvailableException exception)
                {
                    exception.Redirect();
                }
            }
        }

        return initialUser;
    }
}
```

Configure the MSAL authentication to use the custom user account factory.

Confirm that the the `Program` file file uses the <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication?displayProperty=fullName> namespace:

```csharp
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
```

The example in this section builds on the approach of reading the base URL with version and scopes from app configuration via the `MicrosoftGraph` section in `wwwroot/appsettings.json` file. The following lines should already be present in the `Program` file from following the guidance earlier in this article:

```csharp
var baseUrl = builder.Configuration.GetSection("MicrosoftGraph")["BaseUrl"];
var scopes = builder.Configuration.GetSection("MicrosoftGraph:Scopes")
    .Get<List<string>>();

builder.Services.AddGraphClient(baseUrl, scopes);
```

In the `Program` file, find the call to the <xref:Microsoft.Extensions.DependencyInjection.MsalWebAssemblyServiceCollectionExtensions.AddMsalAuthentication%2A> extension method. Update the code to the following, which includes a call to <xref:Microsoft.Extensions.DependencyInjection.RemoteAuthenticationBuilderExtensions.AddAccountClaimsPrincipalFactory%2A> that adds an account claims principal factory with the `CustomAccountFactory`.

If the app uses a custom user account class that extends <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.RemoteUserAccount>, swap the custom user account class for <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.RemoteUserAccount> in the following code.

```csharp
builder.Services.AddMsalAuthentication<RemoteAuthenticationState,
    RemoteUserAccount>(options =>
    {
        builder.Configuration.Bind("AzureAd", 
            options.ProviderOptions.Authentication);
    })
    .AddAccountClaimsPrincipalFactory<RemoteAuthenticationState, RemoteUserAccount,
        CustomAccountFactory>();
```

You can use the following `UserClaims` component to study the user's claims after the user authenticates with ME-ID:

`UserClaims.razor`:

```razor
@page "/user-claims"
@using System.Security.Claims
@using Microsoft.AspNetCore.Authorization
@inject AuthenticationStateProvider AuthenticationStateProvider
@attribute [Authorize]

<h1>User Claims</h1>

@if (claims.Any())
{
    <ul>
        @foreach (var claim in claims)
        {
            <li>@claim.Type: @claim.Value</li>
        }
    </ul>
}
else
{
    <p>No claims found.</p>
}

@code {
    private IEnumerable<Claim> claims = Enumerable.Empty<Claim>();

    protected override async Task OnInitializedAsync()
    {
        var authState = await AuthenticationStateProvider
            .GetAuthenticationStateAsync();
        var user = authState.User;

        claims = user.Claims;
    }
}
```

When testing with the Graph SDK locally, we recommend using a new in-private/incognito browser session for each test to prevent lingering cookies from interfering with tests. For more information, see <xref:blazor/security/webassembly/standalone-with-microsoft-entra-id#troubleshoot>.

:::zone-end

:::zone pivot="graph-sdk-4"

*The following guidance applies to Microsoft Graph v4. If you're upgrading an app from SDK v4 to v5, see the [Microsoft Graph .NET SDK v5 changelog and upgrade guide](https://github.com/microsoftgraph/msgraph-sdk-dotnet/blob/dev/docs/upgrade-to-v5.md).*

The Microsoft Graph SDK for use in Blazor apps is called the *Microsoft Graph .NET Client Library*.

:::moniker range=">= aspnetcore-8.0"

The Graph SDK examples require the following package references in the standalone Blazor WebAssembly app:

:::moniker-end

:::moniker range="< aspnetcore-8.0"

The Graph SDK examples require the following package references in the standalone Blazor WebAssembly app or the **:::no-loc text="Client":::** app of a hosted Blazor WebAssembly solution:

:::moniker-end

* [`Microsoft.Extensions.Http`](https://www.nuget.org/packages/Microsoft.Extensions.Http)
* [`Microsoft.Graph`](https://www.nuget.org/packages/Microsoft.Graph)

[!INCLUDE[](~/includes/package-reference.md)]

After adding the Microsoft Graph API scopes in the ME-ID area of the Azure portal, add the following app settings configuration to the `wwwroot/appsettings.json` file, which includes the Graph base URL with Graph version and scopes. In the following example, the `User.Read` scope is specified for the examples in later sections of this article.

```json
"MicrosoftGraph": {
  "BaseUrl": "https://graph.microsoft.com/{VERSION}",
  "Scopes": [
    "user.read"
  ]
}
```

In the preceding example, the `{VERSION}` placeholder is the version of the MS Graph API (for example: `v1.0`).

:::moniker range=">= aspnetcore-8.0"

Add the following `GraphClientExtensions` class to the standalone app. The scopes are provided to the <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.AccessTokenRequestOptions.Scopes> property of the <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.AccessTokenRequestOptions> in the `AuthenticateRequestAsync` method. The <xref:Microsoft.Graph.IHttpProvider.OverallTimeout?displayProperty=nameWithType> is extended from the default value of 100 seconds to 300 seconds to give the `HttpClient` more time to receive a response from Microsoft Graph.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

Add the following `GraphClientExtensions` class to the standalone app or **:::no-loc text="Client":::** app of a hosted Blazor WebAssembly [solution](xref:blazor/tooling#visual-studio-solution-file-sln). The scopes are provided to the <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.AccessTokenRequestOptions.Scopes> property of the <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.AccessTokenRequestOptions> in the `AuthenticateRequestAsync` method. The <xref:Microsoft.Graph.IHttpProvider.OverallTimeout?displayProperty=nameWithType> is extended from the default value of 100 seconds to 300 seconds to give the `HttpClient` more time to receive a response from Microsoft Graph.

:::moniker-end

When an access token isn't obtained, the following code doesn't set a Bearer authorization header for Graph requests. 

`GraphClientExtensions.cs`:

```csharp
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Authentication.WebAssembly.Msal.Models;
using Microsoft.Graph;

internal static class GraphClientExtensions
{
    public static IServiceCollection AddGraphClient(
        this IServiceCollection services, string? baseUrl, List<string>? scopes)
    {
        if (string.IsNullOrEmpty(baseUrl) || scopes.IsNullOrEmpty())
        {
            return services;
        }

        services.Configure<RemoteAuthenticationOptions<MsalProviderOptions>>(
            options =>
            {
                scopes?.ForEach((scope) =>
                {
                    options.ProviderOptions.DefaultAccessTokenScopes.Add(scope);
                });
            });

        services.AddScoped<IAuthenticationProvider, GraphAuthenticationProvider>();

        services.AddScoped<IHttpProvider, HttpClientHttpProvider>(sp =>
            new HttpClientHttpProvider(new HttpClient()));

        services.AddScoped(sp =>
        {
            return new GraphServiceClient(
                baseUrl,
                sp.GetRequiredService<IAuthenticationProvider>(),
                sp.GetRequiredService<IHttpProvider>());
        });

        return services;
    }

    private class GraphAuthenticationProvider : IAuthenticationProvider
    {
        private readonly IConfiguration config;

        public GraphAuthenticationProvider(IAccessTokenProvider tokenProvider, 
            IConfiguration config)
        {
            TokenProvider = tokenProvider;
            this.config = config;
        }

        public IAccessTokenProvider TokenProvider { get; }

        public async Task AuthenticateRequestAsync(HttpRequestMessage request)
        {
            var result = await TokenProvider.RequestAccessToken(
                new AccessTokenRequestOptions()
                { 
                    Scopes = config.GetSection("MicrosoftGraph:Scopes").Get<string[]>()
                });

            if (result.TryGetToken(out var token))
            {
                request.Headers.Authorization ??= new AuthenticationHeaderValue(
                    "Bearer", token.Value);
            }
        }
    }

    private class HttpClientHttpProvider : IHttpProvider
    {
        private readonly HttpClient client;

        public HttpClientHttpProvider(HttpClient client)
        {
            this.client = client;
        }

        public ISerializer Serializer { get; } = new Serializer();

        public TimeSpan OverallTimeout { get; set; } = TimeSpan.FromSeconds(300);

        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            return client.SendAsync(request);
        }

        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            HttpCompletionOption completionOption,
            CancellationToken cancellationToken)
        {
            return client.SendAsync(request, completionOption, cancellationToken);
        }

        public void Dispose()
        {
        }
    }
}
```

In the `Program` file, add the Graph client services and configuration with the `AddGraphClient` extension method:

```csharp
var baseUrl = builder.Configuration
    .GetSection("MicrosoftGraph")["BaseUrl"];
var scopes = builder.Configuration.GetSection("MicrosoftGraph:Scopes")
    .Get<List<string>>();

builder.Services.AddGraphClient(baseUrl, scopes);
```

## Call Graph API from a component using the Graph SDK

The following `GraphExample` component uses an injected `GraphServiceClient` to obtain the user's ME-ID profile data and display their mobile phone number. For any test user that you create in ME-ID, make sure that you give the user's ME-ID profile a mobile phone number in the Azure portal.

`GraphExample.razor`:

```razor
@page "/graph-example"
@using Microsoft.AspNetCore.Authorization
@using Microsoft.Graph
@attribute [Authorize]
@inject GraphServiceClient Client

<h1>Microsoft Graph Component Example</h1>

@if (!string.IsNullOrEmpty(user?.MobilePhone))
{
    <p>Mobile Phone: @user.MobilePhone</p>
}

@code {
    private Microsoft.Graph.User? user;

    protected override async Task OnInitializedAsync()
    {
        var request = Client.Me.Request();
        user = await request.GetAsync();
    }
}
```

When testing with the Graph SDK locally, we recommend using a new in-private/incognito browser session for each test to prevent lingering cookies from interfering with tests. For more information, see <xref:blazor/security/webassembly/standalone-with-microsoft-entra-id#troubleshoot>.

## Customize user claims using the Graph SDK

In the following example, the app creates mobile phone number and office location claims for a user from their ME-ID user profile's data. The app must have the `User.Read` Graph API scope configured in ME-ID. Any test users for this scenario must have a mobile phone number and office location in their ME-ID profile, which can be added via the Azure portal.

In the following custom user account factory:

* An <xref:Microsoft.Extensions.Logging.ILogger> (`logger`) is included for convenience in case you wish to log information or errors in the `CreateUserAsync` method.
* In the event that an <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.AccessTokenNotAvailableException> is thrown, the user is redirected to the identity provider to sign into their account. Additional or different actions can be taken when requesting an access token fails. For example, the app can log the <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.AccessTokenNotAvailableException> and create a support ticket for further investigation.
* The framework's <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.RemoteUserAccount> represents the user's account. If the app requires a custom user account class that extends <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.RemoteUserAccount>, swap your custom user account class for <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.RemoteUserAccount> in the following code.

`CustomAccountFactory.cs`:

```csharp
using System.Security.Claims;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;
using Microsoft.Graph;

public class CustomAccountFactory
    : AccountClaimsPrincipalFactory<RemoteUserAccount>
{
    private readonly ILogger<CustomAccountFactory> logger;
    private readonly IServiceProvider serviceProvider;

    public CustomAccountFactory(IAccessTokenProviderAccessor accessor, 
        IServiceProvider serviceProvider,
        ILogger<CustomAccountFactory> logger)
        : base(accessor)
    {
        this.serviceProvider = serviceProvider;
        this.logger = logger;
    }

    public override async ValueTask<ClaimsPrincipal> CreateUserAsync(
        RemoteUserAccount account,
        RemoteAuthenticationUserOptions options)
    {
        var initialUser = await base.CreateUserAsync(account, options);

        if (initialUser.Identity is not null && 
            initialUser.Identity.IsAuthenticated)
        {
            var userIdentity = initialUser.Identity as ClaimsIdentity;

            if (userIdentity is not null)
            {
                try
                {
                    var client = ActivatorUtilities
                        .CreateInstance<GraphServiceClient>(serviceProvider);
                    var request = client.Me.Request();
                    var user = await request.GetAsync();

                    if (user is not null)
                    {
                        userIdentity.AddClaim(new Claim("mobilephone",
                            user.MobilePhone ?? "(000) 000-0000"));
                        userIdentity.AddClaim(new Claim("officelocation",
                            user.OfficeLocation ?? "Not set"));
                    }
                }
                catch (AccessTokenNotAvailableException exception)
                {
                    exception.Redirect();
                }
            }
        }

        return initialUser;
    }
}
```

Configure the MSAL authentication to use the custom user account factory.

Confirm that the the `Program` file file uses the <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication?displayProperty=fullName> namespace:

```csharp
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
```

The example in this section builds on the approach of reading the base URL with version and scopes from app configuration via the `MicrosoftGraph` section in `wwwroot/appsettings.json` file. The following lines should already be present in the `Program` file from following the guidance earlier in this article:

```csharp
var baseUrl = string.Join("/", 
    builder.Configuration.GetSection("MicrosoftGraph")["BaseUrl"];
var scopes = builder.Configuration.GetSection("MicrosoftGraph:Scopes")
    .Get<List<string>>();

builder.Services.AddGraphClient(baseUrl, scopes);
```

In the `Program` file, find the call to the <xref:Microsoft.Extensions.DependencyInjection.MsalWebAssemblyServiceCollectionExtensions.AddMsalAuthentication%2A> extension method. Update the code to the following, which includes a call to <xref:Microsoft.Extensions.DependencyInjection.RemoteAuthenticationBuilderExtensions.AddAccountClaimsPrincipalFactory%2A> that adds an account claims principal factory with the `CustomAccountFactory`.

If the app uses a custom user account class that extends <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.RemoteUserAccount>, swap the custom user account class for <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.RemoteUserAccount> in the following code.

```csharp
builder.Services.AddMsalAuthentication<RemoteAuthenticationState,
    RemoteUserAccount>(options =>
    {
        builder.Configuration.Bind("AzureAd", 
            options.ProviderOptions.Authentication);
    })
    .AddAccountClaimsPrincipalFactory<RemoteAuthenticationState, RemoteUserAccount,
        CustomAccountFactory>();
```

You can use the following `UserClaims` component to study the user's claims after the user authenticates with ME-ID:

`UserClaims.razor`:

```razor
@page "/user-claims"
@using System.Security.Claims
@using Microsoft.AspNetCore.Authorization
@inject AuthenticationStateProvider AuthenticationStateProvider
@attribute [Authorize]

<h1>User Claims</h1>

@if (claims.Any())
{
    <ul>
        @foreach (var claim in claims)
        {
            <li>@claim.Type: @claim.Value</li>
        }
    </ul>
}
else
{
    <p>No claims found.</p>
}

@code {
    private IEnumerable<Claim> claims = Enumerable.Empty<Claim>();

    protected override async Task OnInitializedAsync()
    {
        var authState = await AuthenticationStateProvider
            .GetAuthenticationStateAsync();
        var user = authState.User;

        claims = user.Claims;
    }
}
```

When testing with the Graph SDK locally, we recommend using a new in-private/incognito browser session for each test to prevent lingering cookies from interfering with tests. For more information, see <xref:blazor/security/webassembly/standalone-with-microsoft-entra-id#troubleshoot>.

:::zone-end

:::zone pivot="named-client-graph-api"

The following examples use a named <xref:System.Net.Http.HttpClient> for Graph API calls to obtain a user's mobile phone number to process a call or to customize a user's claims to include a mobile phone number claim and an office location claim.

:::moniker range=">= aspnetcore-8.0"

The examples require a package reference for [`Microsoft.Extensions.Http`](https://www.nuget.org/packages/Microsoft.Extensions.Http) for the standalone Blazor WebAssembly app.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

The examples require a package reference for [`Microsoft.Extensions.Http`](https://www.nuget.org/packages/Microsoft.Extensions.Http) for the standalone Blazor WebAssembly app or the **:::no-loc text="Client":::** app of a hosted Blazor WebAssembly solution.

:::moniker-end

[!INCLUDE[](~/includes/package-reference.md)]

After adding the Microsoft Graph API scopes in the ME-ID area of the Azure portal, add the following app settings configuration to the `wwwroot/appsettings.json` file. In the following example, the `User.Read` scope is specified to match the examples in later sections of this article.

```json
"MicrosoftGraph": {
  "BaseUrl": "https://graph.microsoft.com/{VERSION}",
  "Scopes": [
    "user.read"
  ]
}
```

In the preceding example, the `{VERSION}` placeholder is the version of the MS Graph API (for example: `v1.0`).

Create the following `GraphAuthorizationMessageHandler` class and project configuration in the `Program` file for working with Graph API. The base URL and scopes are provided to the handler from configuration.

`GraphAuthorizationMessageHandler.cs`:

```csharp
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

public class GraphAuthorizationMessageHandler : AuthorizationMessageHandler
{
    public GraphAuthorizationMessageHandler(IAccessTokenProvider provider,
        NavigationManager navigation, IConfiguration config)
        : base(provider, navigation)
    {
        ConfigureHandler(
            authorizedUrls: new[] { config.GetSection("MicrosoftGraph")["BaseUrl"] },
            scopes: config.GetSection("MicrosoftGraph:Scopes").Get<List<string>>());
    }
}
```

In the `Program` file, configure the named <xref:System.Net.Http.HttpClient> for Graph API:

```csharp
builder.Services.AddTransient<GraphAuthorizationMessageHandler>();

builder.Services.AddHttpClient("GraphAPI",
        client => client.BaseAddress = new Uri(
            builder.Configuration.GetSection("MicrosoftGraph")["BaseUrl"]))
    .AddHttpMessageHandler<GraphAuthorizationMessageHandler>();
```

In the preceding example, the `GraphAuthorizationMessageHandler` <xref:System.Net.Http.DelegatingHandler> is registered as a transient service for <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.AddHttpMessageHandler%2A>. Transient registration is recommended for <xref:System.Net.Http.IHttpClientFactory>, which manages its own DI scopes. For more information, see the following resources:

* [Utility base component classes to manage a DI scope](xref:blazor/fundamentals/dependency-injection#utility-base-component-classes-to-manage-a-di-scope)
* [Detect client-side transient disposables](xref:blazor/fundamentals/dependency-injection#detect-client-side-transient-disposables)

## Call Graph API from a component using a named `HttpClient`

The `UserInfo.cs` class designates the required user profile properties with the <xref:System.Text.Json.Serialization.JsonPropertyNameAttribute> attribute and the JSON name used by ME-ID. The following example sets up properties for the user's mobile phone number and office location.

`UserInfo.cs`:

```csharp
using System.Text.Json.Serialization;

public class UserInfo
{
    [JsonPropertyName("mobilePhone")]
    public string? MobilePhone { get; set; }

    [JsonPropertyName("officeLocation")]
    public string? OfficeLocation { get; set; }
}
```

In the following `GraphExample` component, an <xref:System.Net.Http.HttpClient> is created for Graph API to issue a request for the user's profile data. The `me` resource (`/me`) are added to the base URL with version for the Graph API request. JSON data returned by Graph is deserialized into the `UserInfo` class properties. In the following example, the mobile phone number is obtained. You can add similar code to include the user's ME-ID profile office location if you wish (`userInfo.OfficeLocation`). If the access token request fails, the user is redirected to sign into the app for a new access token.

`GraphExample.razor`:

```razor
@page "/graph-example"
@using Microsoft.AspNetCore.Authorization
@using Microsoft.AspNetCore.Components.WebAssembly.Authentication
@inject IConfiguration Config
@inject IHttpClientFactory ClientFactory
@attribute [Authorize]

<h1>Microsoft Graph Component Example</h1>

@if (!string.IsNullOrEmpty(userInfo?.MobilePhone))
{
    <p>Mobile Phone: @userInfo.MobilePhone</p>
}

@code {
    private UserInfo? userInfo;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            var client = ClientFactory.CreateClient("GraphAPI");

            userInfo = await client.GetFromJsonAsync<UserInfo>("/me");
        }
        catch (AccessTokenNotAvailableException exception)
        {
            exception.Redirect();
        }
    }
}
```

When testing with the Graph API locally, we recommend using a new in-private/incognito browser session for each test to prevent lingering cookies from interfering with testing. For more information, see <xref:blazor/security/webassembly/standalone-with-microsoft-entra-id#troubleshoot>.

## Customize user claims using a named `HttpClient`

In the following example, the app creates mobile phone number and office location claims for the user from their ME-ID user profile's data. The app must have the `User.Read` Graph API scope configured in ME-ID. Test user accounts in ME-ID require an entry for the mobile phone number and office location, which can be added via the Azure portal to their user profiles.

If you haven't already added the `UserInfo` class to the app by following the guidance earlier in this article, add the following class and designate the required user profile properties with the <xref:System.Text.Json.Serialization.JsonPropertyNameAttribute> attribute and the JSON name used by ME-ID. The following example sets up properties for the user's mobile phone number and office location.

`UserInfo.cs`:

```csharp
using System.Text.Json.Serialization;

public class UserInfo
{
    [JsonPropertyName("mobilePhone")]
    public string? MobilePhone { get; set; }

    [JsonPropertyName("officeLocation")]
    public string? OfficeLocation { get; set; }
}
```

In the following custom user account factory:

* An <xref:Microsoft.Extensions.Logging.ILogger> (`logger`) is included for convenience in case you wish to log information or errors in the `CreateUserAsync` method.
* In the event that an <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.AccessTokenNotAvailableException> is thrown, the user is redirected to the identity provider to sign into their account. Additional or different actions can be taken when requesting an access token fails. For example, the app can log the <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.AccessTokenNotAvailableException> and create a support ticket for further investigation.
* The framework's <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.RemoteUserAccount> represents the user's account. If the app requires a custom user account class that extends <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.RemoteUserAccount>, swap the custom user account class for <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.RemoteUserAccount> in the following code.

`CustomAccountFactory.cs`:

```csharp
using System.Net.Http.Json;
using System.Security.Claims;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;

public class CustomAccountFactory
    : AccountClaimsPrincipalFactory<RemoteUserAccount>
{
    private readonly ILogger<CustomAccountFactory> logger;
    private readonly IHttpClientFactory clientFactory;

    public CustomAccountFactory(IAccessTokenProviderAccessor accessor,
        IHttpClientFactory clientFactory,
        ILogger<CustomAccountFactory> logger)
        : base(accessor)
    {
        this.clientFactory = clientFactory;
        this.logger = logger;
    }

    public override async ValueTask<ClaimsPrincipal> CreateUserAsync(
        RemoteUserAccount account,
        RemoteAuthenticationUserOptions options)
    {
        var initialUser = await base.CreateUserAsync(account, options);

        if (initialUser.Identity is not null && 
            initialUser.Identity.IsAuthenticated)
        {
            var userIdentity = initialUser.Identity as ClaimsIdentity;

            if (userIdentity is not null)
            {
                try
                {
                    var client = clientFactory.CreateClient("GraphAPI");

                    var userInfo = await client.GetFromJsonAsync<UserInfo>("/me");

                    if (userInfo is not null)
                    {
                        userIdentity.AddClaim(new Claim("mobilephone",
                            userInfo.MobilePhone ?? "(000) 000-0000"));
                        userIdentity.AddClaim(new Claim("officelocation",
                            userInfo.OfficeLocation ?? "Not set"));
                    }
                }
                catch (AccessTokenNotAvailableException exception)
                {
                    exception.Redirect();
                }
            }
        }

        return initialUser;
    }
}
```

The MSAL authentication is configured to use the custom user account factory. Start by confirming that the the `Program` file file uses the <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication?displayProperty=fullName> namespace:

```csharp
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
```

In the `Program` file, find the call to the <xref:Microsoft.Extensions.DependencyInjection.MsalWebAssemblyServiceCollectionExtensions.AddMsalAuthentication%2A> extension method. Update the code to the following, which includes a call to <xref:Microsoft.Extensions.DependencyInjection.RemoteAuthenticationBuilderExtensions.AddAccountClaimsPrincipalFactory%2A> that adds an account claims principal factory with the `CustomAccountFactory`.

If the app uses a custom user account class that extends <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.RemoteUserAccount>, swap your app's custom user account class for <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.RemoteUserAccount> in the following code.

```csharp
builder.Services.AddMsalAuthentication<RemoteAuthenticationState, 
    RemoteUserAccount>(options =>
    {
        builder.Configuration.Bind("AzureAd", 
            options.ProviderOptions.Authentication);
    })
    .AddAccountClaimsPrincipalFactory<RemoteAuthenticationState, RemoteUserAccount, 
        CustomAccountFactory>();
```

The preceding example is for an app that uses ME-ID authentication with MSAL. Similar patterns exist for OIDC and API authentication. For more information, see the examples in the [Customize the user with a payload claim](xref:blazor/security/webassembly/additional-scenarios#customize-the-user-with-a-payload-claim) section of the <xref:blazor/security/webassembly/additional-scenarios> article.

You can use the following `UserClaims` component to study the user's claims after the user authenticates with ME-ID:

`UserClaims.razor`:

```razor
@page "/user-claims"
@using System.Security.Claims
@using Microsoft.AspNetCore.Authorization
@inject AuthenticationStateProvider AuthenticationStateProvider
@attribute [Authorize]

<h1>User Claims</h1>

@if (claims.Any())
{
    <ul>
        @foreach (var claim in claims)
        {
            <li>@claim.Type: @claim.Value</li>
        }
    </ul>
}
else
{
    <p>No claims found.</p>
}

@code {
    private IEnumerable<Claim> claims = Enumerable.Empty<Claim>();

    protected override async Task OnInitializedAsync()
    {
        var authState = await AuthenticationStateProvider
            .GetAuthenticationStateAsync();
        var user = authState.User;

        claims = user.Claims;
    }
}
```

When testing with the Graph API locally, we recommend using a new in-private/incognito browser session for each test to prevent lingering cookies from interfering with testing. For more information, see <xref:blazor/security/webassembly/standalone-with-microsoft-entra-id#troubleshoot>.

:::zone-end

:::moniker range="< aspnetcore-8.0"

## Hosted Blazor WebAssembly solutions

The examples in this article pertain to using the Graph SDK or a named `HttpClient` with Graph API directly from a standalone Blazor WebAssembly app or directly from the **:::no-loc text="Client":::** app of a hosted Blazor WebAssembly [solution](xref:blazor/tooling#visual-studio-solution-file-sln). An additional scenario that isn't covered by this article is for a **:::no-loc text="Client":::** app of a hosted solution to call the **:::no-loc text="Server":::** app of the solution via web API, and then the the **:::no-loc text="Server":::** app uses the Graph SDK/API to call Microsoft Graph and return data to the **:::no-loc text="Client":::** app. Although this is a supported approach, it isn't covered by this article. If you wish to adopt this approach:

* Follow the guidance in <xref:blazor/call-web-api> for the web API aspects on issuing requests to the **:::no-loc text="Server":::** app from the **:::no-loc text="Client":::** app and returning data to the **:::no-loc text="Client":::** app.
* Follow the guidance in the primary [Microsoft Graph documentation](/graph/) to use the Graph SDK with a typical ASP.NET Core app, which in this scenario is the **:::no-loc text="Server":::** app of the solution. If you use the Blazor WebAssembly project template to the create the hosted Blazor WebAssembly solution (**ASP.NET Core Hosted**/`-h|--hosted`) with organizational authorization (single organization/`SingleOrg` or multiple organization/`MultiOrg`) and the Microsoft Graph option (**Microsoft identity platform** > **Connected Services** > **Add Microsoft Graph permissions** in Visual Studio or the `--calls-graph` option with the .NET CLI `dotnet new` command), the **:::no-loc text="Server":::** app of the solution is configured to use the Graph SDK when the solution is created from the project template.

:::moniker-end

## Additional resources

### General guidance

:::moniker range=">= aspnetcore-8.0"

* [Microsoft Graph documentation](/graph/)
* [Microsoft Graph sample Blazor WebAssembly app](https://github.com/microsoftgraph/msgraph-sample-blazor-clientside): This sample demonstrates how to use the Microsoft Graph .NET SDK to access data in Office 365 from Blazor WebAssembly apps.
* [Build .NET apps with Microsoft Graph tutorial](/graph/tutorials/dotnet?tabs=aad) and [Microsoft Graph sample ASP.NET Core app](https://github.com/microsoftgraph/msgraph-sample-aspnet-core/tree/main/): Although these resources don't directly apply to calling Graph from *client-side* Blazor WebAssembly apps, the ME-ID app configuration and Microsoft Graph coding practices in the linked resources are relevant for standalone Blazor WebAssembly apps and should be consulted for general best practices.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

* [Microsoft Graph documentation](/graph/)
* [Microsoft Graph sample Blazor WebAssembly app](https://github.com/microsoftgraph/msgraph-sample-blazor-clientside): This sample demonstrates how to use the Microsoft Graph .NET SDK to access data in Office 365 from Blazor WebAssembly apps.
* [Build .NET apps with Microsoft Graph tutorial](/graph/tutorials/dotnet?tabs=aad) and [Microsoft Graph sample ASP.NET Core app](https://github.com/microsoftgraph/msgraph-sample-aspnet-core/tree/main/): These resources are most appropriate for ***hosted*** Blazor WebAssembly solutions, where the **:::no-loc text="Server":::** app is configured to access Microsoft Graph as a typical ASP.NET Core app on behalf of the **:::no-loc text="Client":::** app. The **:::no-loc text="Client":::** app uses web API to make requests to the **:::no-loc text="Server":::** app for Graph data. Although these resources don't directly apply to calling Graph from *client-side* Blazor WebAssembly apps, the ME-ID app configuration and Microsoft Graph coding practices in the linked resources are relevant for standalone Blazor WebAssembly apps and should be consulted for general best practices.

:::moniker-end

### Security guidance

* [Microsoft Graph auth overview](/graph/auth/)
* [Overview of Microsoft Graph permissions](/graph/permissions-overview)
* [Microsoft Graph permissions reference](/graph/permissions-reference)
* [Enhance security with the principle of least privilege](/azure/active-directory/develop/secure-least-privileged-access)
* [Microsoft Security Best Practices: Securing privileged access](/security/compass/overview)
* [Azure privilege escalation articles on the Internet (Google search result)](https://www.google.com/search?q=%22Azure+Privilege+Escalation%22)
