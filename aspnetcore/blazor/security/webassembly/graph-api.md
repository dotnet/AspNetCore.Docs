---
title: Use Graph API with ASP.NET Core Blazor WebAssembly
author: guardrex
description: Learn how to use the Microsoft Graph SDK/API with Blazor WebAssembly apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 02/09/2024
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
> The scenarios described in this article apply to using Microsoft Entra (ME-ID) as the identity provider, not AAD B2C. Using Microsoft Graph with a client-side Blazor WebAssembly app and the AAD B2C identity provider isn't supported at this time because the app would require a client secret, which can't be secured in the client-side Blazor app. For an AAD B2C standalone Blazor WebAssembly app use Graph API, create a backend server (web) API to access Graph API on behalf of users. The client-side app authenticates and authorizes users to [call the web API](xref:blazor/call-web-api) to securely access Microsoft Graph and return data to the client-side Blazor app. The client secret is safely maintained in the server-based web API, not in the Blazor app on the client. **Never store a client secret in a client-side Blazor app.**

:::moniker range="< aspnetcore-8.0"

Using a hosted Blazor WebAssembly app is supported, where the **:::no-loc text="Server":::** app uses the Graph SDK/API to provide Graph data to the **:::no-loc text="Client":::** app via web API. For more information, see the [Hosted Blazor WebAssembly solutions](#hosted-blazor-webassembly-solutions) section of this article.

:::moniker-end

The examples in this article take advantage of new .NET/C# features. When using the examples with .NET 7 or earlier, minor modifications are required. However, the text and code examples that pertain to interacting with Microsoft Graph are the same for all versions of ASP.NET Core.

:::zone pivot="graph-sdk-5"

*The following guidance applies to Microsoft Graph v5.*

The Microsoft Graph SDK for use in Blazor apps is called the *Microsoft Graph .NET Client Library*.

:::moniker range=">= aspnetcore-8.0"

The Graph SDK examples require the following package references in the standalone Blazor WebAssembly app. The first two packages are already referenced if the app has been enabled for MSAL authentication, for example when creating the app by following the guidance in <xref:blazor/security/webassembly/standalone-with-microsoft-entra-id>.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

The Graph SDK examples require the following package references in the standalone Blazor WebAssembly app or the **:::no-loc text="Client":::** app of a hosted Blazor WebAssembly solution. The first two packages are already referenced if the app has been enabled for MSAL authentication, for example when creating the app by following the guidance in <xref:blazor/security/webassembly/standalone-with-microsoft-entra-id>.

:::moniker-end

* [`Microsoft.AspNetCore.Components.WebAssembly.Authentication`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Authentication)
* [`Microsoft.Authentication.WebAssembly.Msal`](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal)
* [`Microsoft.Extensions.Http`](https://www.nuget.org/packages/Microsoft.Extensions.Http)
* [`Microsoft.Graph`](https://www.nuget.org/packages/Microsoft.Graph)

[!INCLUDE[](~/includes/package-reference.md)]

In the Azure portal, grant delegated permissions (scopes)&dagger; for Microsoft Graph data that the app should be able to access on behalf of a user. For the example in this article, the app's registration should include delegated permission to read user data (`Microsoft.Graph` > `User.Read` scope in **API permissions**, Type: Delegated). The `User.Read` scope allows users to sign in to the app and allows the app to read the profile and company information of signed-in users. For more information, see [Overview of permissions and consent in the Microsoft identity platform](/entra/identity-platform/permissions-consent-overview) and [Overview of Microsoft Graph permissions](/graph/permissions-overview).

> [!NOTE]
> &dagger;*Permissions* and *scopes* mean the same thing and are used interchangeably in security documentation and the Azure portal. This article uses *scope*/*scopes* when referring to Graph API permissions.

After adding the Microsoft Graph API scopes to the app's registration in the Azure portal, add the following app settings configuration to the `wwwroot/appsettings.json` file in the app, which includes the Graph base URL with the Microsoft Graph version and scopes. In the following example, the `User.Read` scope is specified for the examples in later sections of this article. Scopes aren't case sensitive.

```json
"MicrosoftGraph": {
  "BaseUrl": "https://graph.microsoft.com/{VERSION}/",
  "Scopes": [
    "user.read"
  ]
}
```

In the preceding example, the `{VERSION}` placeholder is the version of the Microsoft Graph API (for example: `v1.0`). The trailing slash is ***required***.

The following is an example of a complete `wwwroot/appsettings.json` configuration file for an app that uses ME-ID as its identity provider, where reading user data (`user.read` scope) is specified for Microsoft Graph:

```json
{
  "AzureAd": {
    "Authority": "https://login.microsoftonline.com/{TENANT ID}",
    "ClientId": "{CLIENT ID}",
    "ValidateAuthority": true
  },
  "MicrosoftGraph": {
    "BaseUrl": "https://graph.microsoft.com/v1.0/",
    "Scopes": [
      "user.read"
    ]
  }
}
```

In the preceding example, the `{TENANT ID}` placeholder is the Directory (tenant) ID, and the `{CLIENT ID}` placeholder is the Application (client) ID. For more information, see <xref:blazor/security/webassembly/standalone-with-microsoft-entra-id>.

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

namespace BlazorSample;

internal static class GraphClientExtensions
{
    public static IServiceCollection AddGraphClient(
            this IServiceCollection services, string? baseUrl, List<string>? scopes)
    {
        if (string.IsNullOrEmpty(baseUrl) || scopes?.Count == 0)
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

    private class GraphAuthenticationProvider(IAccessTokenProvider tokenProvider, 
        IConfiguration config) : IAuthenticationProvider
    {
        private readonly IConfiguration config = config;

        public IAccessTokenProvider TokenProvider { get; } = tokenProvider;

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

> [!IMPORTANT]
> See the [`DefaultAccessTokenScopes` versus `AdditionalScopesToConsent`](#defaultaccesstokenscopes-versus-additionalscopestoconsent) section for an explanation on why the preceding code uses <xref:Microsoft.Authentication.WebAssembly.Msal.Models.MsalProviderOptions.DefaultAccessTokenScopes%2A> to add the scopes rather than <xref:Microsoft.Authentication.WebAssembly.Msal.Models.MsalProviderOptions.AdditionalScopesToConsent%2A>.

In the `Program` file, add the Graph client services and configuration with the `AddGraphClient` extension method:

```csharp
var baseUrl = builder.Configuration.GetSection("MicrosoftGraph")["BaseUrl"];
var scopes = builder.Configuration.GetSection("MicrosoftGraph:Scopes")
    .Get<List<string>>();

builder.Services.AddGraphClient(baseUrl, scopes);
```

## Call Graph API from a component using the Graph SDK

The following `UserData` component uses an injected `GraphServiceClient` to obtain the user's ME-ID profile data and display their mobile phone number.

For any test user that you create in ME-ID, make sure that you give the user's ME-ID profile a mobile phone number in the Azure portal.

`UserData.razor`:

```razor
@page "/user-data"
@using Microsoft.AspNetCore.Authorization
@using Microsoft.Graph
@attribute [Authorize]
@inject GraphServiceClient Client

<PageTitle>User Data</PageTitle>

<h1>Microsoft Graph User Data</h1>

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

Add a link to the component's page in the `NavMenu` component (`Layout/NavMenu.razor`):

```razor
<div class="nav-item px-3">
    <NavLink class="nav-link" href="user-data">
        <span class="bi bi-list-nested-nav-menu" aria-hidden="true"></span> User Data
    </NavLink>
</div>
```

> [!TIP]
> To add users to an app, see the [Assign users to an app registration with or without app roles](#assign-users-to-an-app-registration-with-or-without-app-roles) section.

When testing with the Graph SDK locally, we recommend using a new InPrivate/incognito browser session for each test to prevent lingering cookies from interfering with tests. For more information, see <xref:blazor/security/webassembly/standalone-with-microsoft-entra-id#cookies-and-site-data>.

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

namespace BlazorSample;

public class CustomAccountFactory(IAccessTokenProviderAccessor accessor,
        IServiceProvider serviceProvider, ILogger<CustomAccountFactory> logger,
        IConfiguration config) 
    : AccountClaimsPrincipalFactory<RemoteUserAccount>(accessor)
{
    private readonly ILogger<CustomAccountFactory> logger = logger;
    private readonly IServiceProvider serviceProvider = serviceProvider;
    private readonly string? baseUrl = 
        config.GetSection("MicrosoftGraph")["BaseUrl"];

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

Confirm that the `Program` file uses the <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication?displayProperty=fullName> namespace:

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
@attribute [Authorize]
@inject AuthenticationStateProvider AuthenticationStateProvider

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

Add a link to the component's page in the `NavMenu` component (`Layout/NavMenu.razor`):

```razor
<div class="nav-item px-3">
    <NavLink class="nav-link" href="user-claims">
        <span class="bi bi-list-nested-nav-menu" aria-hidden="true"></span> User Claims
    </NavLink>
</div>
```

When testing with the Graph SDK locally, we recommend using a new InPrivate/incognito browser session for each test to prevent lingering cookies from interfering with tests. For more information, see <xref:blazor/security/webassembly/standalone-with-microsoft-entra-id#cookies-and-site-data>.

:::zone-end

:::zone pivot="graph-sdk-4"

*The following guidance applies to Microsoft Graph v4. If you're upgrading an app from SDK v4 to v5, see the [Microsoft Graph .NET SDK v5 changelog and upgrade guide](https://github.com/microsoftgraph/msgraph-sdk-dotnet/blob/dev/docs/upgrade-to-v5.md).*

The Microsoft Graph SDK for use in Blazor apps is called the *Microsoft Graph .NET Client Library*.

:::moniker range=">= aspnetcore-8.0"

The Graph SDK examples require the following package references in the standalone Blazor WebAssembly app. The first two packages are already referenced if the app has been enabled for MSAL authentication, for example when creating the app by following the guidance in <xref:blazor/security/webassembly/standalone-with-microsoft-entra-id>.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

The Graph SDK examples require the following package references in the standalone Blazor WebAssembly app or the **:::no-loc text="Client":::** app of a hosted Blazor WebAssembly solution. The first two packages are already referenced if the app has been enabled for MSAL authentication, for example when creating the app by following the guidance in <xref:blazor/security/webassembly/standalone-with-microsoft-entra-id>.

:::moniker-end

* [`Microsoft.AspNetCore.Components.WebAssembly.Authentication`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Authentication)
* [`Microsoft.Authentication.WebAssembly.Msal`](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal)
* [`Microsoft.Extensions.Http`](https://www.nuget.org/packages/Microsoft.Extensions.Http)
* [`Microsoft.Graph`](https://www.nuget.org/packages/Microsoft.Graph)

[!INCLUDE[](~/includes/package-reference.md)]

In the Azure portal, grant delegated permissions (scopes)&dagger; for Microsoft Graph data that the app should be able to access on behalf of a user. For the example in this article, the app's registration should include delegated permission to read user data (`Microsoft.Graph` > `User.Read` scope in **API permissions**, Type: Delegated). The `User.Read` scope allows users to sign in to the app and allows the app to read the profile and company information of signed-in users. For more information, see [Overview of permissions and consent in the Microsoft identity platform](/entra/identity-platform/permissions-consent-overview) and [Overview of Microsoft Graph permissions](/graph/permissions-overview).

> [!NOTE]
> &dagger;*Permissions* and *scopes* mean the same thing and are used interchangeably in security documentation and the Azure portal. This article uses *scope*/*scopes* when referring to Graph API permissions.

After adding the Microsoft Graph API scopes to the app's registration in the Azure portal, add the following app settings configuration to the `wwwroot/appsettings.json` file in the app, which includes the Graph base URL with the Microsoft Graph version and scopes. In the following example, the `User.Read` scope is specified for the examples in later sections of this article. Scopes aren't case sensitive.

```json
"MicrosoftGraph": {
  "BaseUrl": "https://graph.microsoft.com/{VERSION}/",
  "Scopes": [
    "user.read"
  ]
}
```

In the preceding example, the `{VERSION}` placeholder is the version of the Microsoft Graph API (for example: `v1.0`). The trailing slash is ***required***.

The following is an example of a complete `wwwroot/appsettings.json` configuration file for an app that uses ME-ID as its identity provider, where reading user data (`user.read` scope) is specified for Microsoft Graph:

```json
{
  "AzureAd": {
    "Authority": "https://login.microsoftonline.com/{TENANT ID}",
    "ClientId": "{CLIENT ID}",
    "ValidateAuthority": true
  },
  "MicrosoftGraph": {
    "BaseUrl": "https://graph.microsoft.com/v1.0/",
    "Scopes": [
      "user.read"
    ]
  }
}
```

In the preceding example, the `{TENANT ID}` placeholder is the Directory (tenant) ID, and the `{CLIENT ID}` placeholder is the Application (client) ID. For more information, see <xref:blazor/security/webassembly/standalone-with-microsoft-entra-id>.

:::moniker range=">= aspnetcore-8.0"

Add the following `GraphClientExtensions` class to the standalone app. The scopes are provided to the <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.AccessTokenRequestOptions.Scopes> property of the <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.AccessTokenRequestOptions> in the `AuthenticateRequestAsync` method. The <xref:Microsoft.Graph.IHttpProvider.OverallTimeout?displayProperty=nameWithType> is extended from the default value of 100 seconds to 300 seconds to give the <xref:System.Net.Http.HttpClient> more time to receive a response from Microsoft Graph.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

Add the following `GraphClientExtensions` class to the standalone app or **:::no-loc text="Client":::** app of a hosted Blazor WebAssembly [solution](xref:blazor/tooling#visual-studio-solution-file-sln). The scopes are provided to the <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.AccessTokenRequestOptions.Scopes> property of the <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.AccessTokenRequestOptions> in the `AuthenticateRequestAsync` method. The <xref:Microsoft.Graph.IHttpProvider.OverallTimeout?displayProperty=nameWithType> is extended from the default value of 100 seconds to 300 seconds to give the <xref:System.Net.Http.HttpClient> more time to receive a response from Microsoft Graph.

:::moniker-end

When an access token isn't obtained, the following code doesn't set a Bearer authorization header for Graph requests. 

`GraphClientExtensions.cs`:

```csharp
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Authentication.WebAssembly.Msal.Models;
using Microsoft.Graph;

namespace BlazorSample;

internal static class GraphClientExtensions
{
    public static IServiceCollection AddGraphClient(
        this IServiceCollection services, string? baseUrl, List<string>? scopes)
    {
        if (string.IsNullOrEmpty(baseUrl) || scopes?.Count == 0)
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

    private class GraphAuthenticationProvider(IAccessTokenProvider tokenProvider, 
        IConfiguration config) : IAuthenticationProvider
    {
        private readonly IConfiguration config = config;

        public IAccessTokenProvider TokenProvider { get; } = tokenProvider;

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

    private class HttpClientHttpProvider(HttpClient client) : IHttpProvider
    {
        private readonly HttpClient client = client;

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

> [!IMPORTANT]
> See the [`DefaultAccessTokenScopes` versus `AdditionalScopesToConsent`](#defaultaccesstokenscopes-versus-additionalscopestoconsent) section for an explanation on why the preceding code uses <xref:Microsoft.Authentication.WebAssembly.Msal.Models.MsalProviderOptions.DefaultAccessTokenScopes%2A> to add the scopes rather than <xref:Microsoft.Authentication.WebAssembly.Msal.Models.MsalProviderOptions.AdditionalScopesToConsent%2A>.

In the `Program` file, add the Graph client services and configuration with the `AddGraphClient` extension method:

```csharp
var baseUrl = builder.Configuration
    .GetSection("MicrosoftGraph")["BaseUrl"];
var scopes = builder.Configuration.GetSection("MicrosoftGraph:Scopes")
    .Get<List<string>>();

builder.Services.AddGraphClient(baseUrl, scopes);
```

## Call Graph API from a component using the Graph SDK

The following `UserData` component uses an injected `GraphServiceClient` to obtain the user's ME-ID profile data and display their mobile phone number. For any test user that you create in ME-ID, make sure that you give the user's ME-ID profile a mobile phone number in the Azure portal.

`UserData.razor`:

```razor
@page "/user-data"
@using Microsoft.AspNetCore.Authorization
@using Microsoft.Graph
@attribute [Authorize]
@inject GraphServiceClient Client

<PageTitle>User Data</PageTitle>

<h1>Microsoft Graph User Data</h1>

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

Add a link to the component's page in the `NavMenu` component (`Layout/NavMenu.razor`):

```razor
<div class="nav-item px-3">
    <NavLink class="nav-link" href="user-data">
        <span class="bi bi-list-nested-nav-menu" aria-hidden="true"></span> User Data
    </NavLink>
</div>
```

> [!TIP]
> To add users to an app, see the [Assign users to an app registration with or without app roles](#assign-users-to-an-app-registration-with-or-without-app-roles) section.

When testing with the Graph SDK locally, we recommend using a new InPrivate/incognito browser session for each test to prevent lingering cookies from interfering with tests. For more information, see <xref:blazor/security/webassembly/standalone-with-microsoft-entra-id#cookies-and-site-data>.

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

namespace BlazorSample;

public class CustomAccountFactory(IAccessTokenProviderAccessor accessor, 
        IServiceProvider serviceProvider, ILogger<CustomAccountFactory> logger)
    : AccountClaimsPrincipalFactory<RemoteUserAccount>(accessor)
{
    private readonly ILogger<CustomAccountFactory> logger = logger;
    private readonly IServiceProvider serviceProvider = serviceProvider;

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

Confirm that the `Program` file uses the <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication?displayProperty=fullName> namespace:

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
@attribute [Authorize]
@inject AuthenticationStateProvider AuthenticationStateProvider

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

Add a link to the component's page in the `NavMenu` component (`Layout/NavMenu.razor`):

```razor
<div class="nav-item px-3">
    <NavLink class="nav-link" href="user-claims">
        <span class="bi bi-list-nested-nav-menu" aria-hidden="true"></span> User Claims
    </NavLink>
</div>
```

When testing with the Graph SDK locally, we recommend using a new InPrivate/incognito browser session for each test to prevent lingering cookies from interfering with tests. For more information, see <xref:blazor/security/webassembly/standalone-with-microsoft-entra-id#cookies-and-site-data>.

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

In the Azure portal, grant delegated permissions (scopes)&dagger; for Microsoft Graph data that the app should be able to access on behalf of a user. For the example in this article, the app's registration should include delegated permission to read user data (`Microsoft.Graph` > `User.Read` scope in **API permissions**, Type: Delegated). The `User.Read` scope allows users to sign in to the app and allows the app to read the profile and company information of signed-in users. For more information, see [Overview of permissions and consent in the Microsoft identity platform](/entra/identity-platform/permissions-consent-overview) and [Overview of Microsoft Graph permissions](/graph/permissions-overview).

> [!NOTE]
> &dagger;*Permissions* and *scopes* mean the same thing and are used interchangeably in security documentation and the Azure portal. This article uses *scope*/*scopes* when referring to Graph API permissions.

After adding the Microsoft Graph API scopes to the app's registration in the Azure portal, add the following app settings configuration to the `wwwroot/appsettings.json` file in the app, which includes the Graph base URL with the Microsoft Graph version and scopes. In the following example, the `User.Read` scope is specified for the examples in later sections of this article. Scopes aren't case sensitive.

```json
"MicrosoftGraph": {
  "BaseUrl": "https://graph.microsoft.com/{VERSION}/",
  "Scopes": [
    "user.read"
  ]
}
```

In the preceding example, the `{VERSION}` placeholder is the version of the Microsoft Graph API (for example: `v1.0`). The trailing slash is ***required***.

The following is an example of a complete `wwwroot/appsettings.json` configuration file for an app that uses ME-ID as its identity provider, where reading user data (`user.read` scope) is specified for Microsoft Graph:

```json
{
  "AzureAd": {
    "Authority": "https://login.microsoftonline.com/{TENANT ID}",
    "ClientId": "{CLIENT ID}",
    "ValidateAuthority": true
  },
  "MicrosoftGraph": {
    "BaseUrl": "https://graph.microsoft.com/v1.0/",
    "Scopes": [
      "user.read"
    ]
  }
}
```

In the preceding example, the `{TENANT ID}` placeholder is the Directory (tenant) ID, and the `{CLIENT ID}` placeholder is the Application (client) ID. For more information, see <xref:blazor/security/webassembly/standalone-with-microsoft-entra-id>.

Create the following `GraphAuthorizationMessageHandler` class and project configuration in the `Program` file for working with Graph API. The base URL and scopes are provided to the handler from configuration.

`GraphAuthorizationMessageHandler.cs`:

```csharp
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace BlazorSample;

public class GraphAuthorizationMessageHandler : AuthorizationMessageHandler
{
    public GraphAuthorizationMessageHandler(IAccessTokenProvider provider,
        NavigationManager navigation, IConfiguration config)
        : base(provider, navigation)
    {
        ConfigureHandler(
            authorizedUrls: [ config.GetSection("MicrosoftGraph")["BaseUrl"] ?? 
                string.Empty ],
            scopes: config.GetSection("MicrosoftGraph:Scopes").Get<List<string>>());
    }
}
```

In the `Program` file, configure the named <xref:System.Net.Http.HttpClient> for Graph API:

```csharp
builder.Services.AddTransient<GraphAuthorizationMessageHandler>();

builder.Services.AddHttpClient("GraphAPI",
        client => client.BaseAddress = new Uri(
            builder.Configuration.GetSection("MicrosoftGraph")["BaseUrl"] ?? 
                string.Empty))
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

namespace BlazorSample;

public class UserInfo
{
    [JsonPropertyName("mobilePhone")]
    public string? MobilePhone { get; set; }

    [JsonPropertyName("officeLocation")]
    public string? OfficeLocation { get; set; }
}
```

In the following `UserData` component, an <xref:System.Net.Http.HttpClient> is created for Graph API to issue a request for the user's profile data. The `me` resource (`me`) are added to the base URL with version for the Graph API request. JSON data returned by Graph is deserialized into the `UserInfo` class properties. In the following example, the mobile phone number is obtained. You can add similar code to include the user's ME-ID profile office location if you wish (`userInfo.OfficeLocation`). If the access token request fails, the user is redirected to sign into the app for a new access token.

`UserData.razor`:

```razor
@page "/user-data"
@using Microsoft.AspNetCore.Authorization
@using Microsoft.AspNetCore.Components.WebAssembly.Authentication
@attribute [Authorize]
@inject IConfiguration Config
@inject IHttpClientFactory ClientFactory

<PageTitle>User Data</PageTitle>

<h1>Microsoft Graph User Data</h1>

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

            userInfo = await client.GetFromJsonAsync<UserInfo>("me");
        }
        catch (AccessTokenNotAvailableException exception)
        {
            exception.Redirect();
        }
    }
}
```

Add a link to the component's page in the `NavMenu` component (`Layout/NavMenu.razor`):

```razor
<div class="nav-item px-3">
    <NavLink class="nav-link" href="user-data">
        <span class="bi bi-list-nested-nav-menu" aria-hidden="true"></span> User Data
    </NavLink>
</div>
```

> [!TIP]
> To add users to an app, see the [Assign users to an app registration with or without app roles](#assign-users-to-an-app-registration-with-or-without-app-roles) section.

The following sequence describes the new user flow for Graph API scopes:

1. The new user signs into the app for the first time.
1. The user consents to using the app in the Azure consent UI.
1. The user accesses a component page that requests Graph API data for the first time.
1. The user is redirected to the Azure consent UI to consent to Graph API scopes.
1. Graph API user data is returned.

If you prefer that scope provisioning (consent for Graph API scopes) take place on the initial sign in, supply the scopes to MSAL authentication as default access token scopes in the `Program` file:

```diff
+ var scopes = builder.Configuration.GetSection("MicrosoftGraph:Scopes")
+     .Get<List<string>>() ?? [];

builder.Services.AddMsalAuthentication(options =>
{
    builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);

+   foreach (var scope in scopes)
+   {
+       options.ProviderOptions.DefaultAccessTokenScopes.Add(scope);
+   }
});
```

> [!IMPORTANT]
> See the [`DefaultAccessTokenScopes` versus `AdditionalScopesToConsent`](#defaultaccesstokenscopes-versus-additionalscopestoconsent) section for an explanation on why the preceding code uses <xref:Microsoft.Authentication.WebAssembly.Msal.Models.MsalProviderOptions.DefaultAccessTokenScopes%2A> to add the scopes rather than <xref:Microsoft.Authentication.WebAssembly.Msal.Models.MsalProviderOptions.AdditionalScopesToConsent%2A>.

When the preceding changes are made to the app, the user flow adopts the following sequence:

1. The new user signs into the app for the first time.
1. The user consents to using the app and Graph API scopes in the Azure consent UI.
1. The user accesses a component page that requests Graph API data for the first time.
1. Graph API user data is returned.

When testing with the Graph API locally, we recommend using a new InPrivate/incognito browser session for each test to prevent lingering cookies from interfering with testing. For more information, see <xref:blazor/security/webassembly/standalone-with-microsoft-entra-id#troubleshoot>.

## Customize user claims using a named `HttpClient`

In the following example, the app creates mobile phone number and office location claims for the user from their ME-ID user profile's data. The app must have the `User.Read` Graph API scope configured in ME-ID. Test user accounts in ME-ID require an entry for the mobile phone number and office location, which can be added via the Azure portal to their user profiles.

If you haven't already added the `UserInfo` class to the app by following the guidance earlier in this article, add the following class and designate the required user profile properties with the <xref:System.Text.Json.Serialization.JsonPropertyNameAttribute> attribute and the JSON name used by ME-ID. The following example sets up properties for the user's mobile phone number and office location.

`UserInfo.cs`:

```csharp
using System.Text.Json.Serialization;

namespace BlazorSample;

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

namespace BlazorSample;

public class CustomAccountFactory(IAccessTokenProviderAccessor accessor,
        IHttpClientFactory clientFactory,
        ILogger<CustomAccountFactory> logger)
    : AccountClaimsPrincipalFactory<RemoteUserAccount>(accessor)
{
    private readonly ILogger<CustomAccountFactory> logger = logger;
    private readonly IHttpClientFactory clientFactory = clientFactory;

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

                    var userInfo = await client.GetFromJsonAsync<UserInfo>("me");

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

The MSAL authentication is configured to use the custom user account factory. Start by confirming that the `Program` file uses the <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication?displayProperty=fullName> namespace:

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
@attribute [Authorize]
@inject AuthenticationStateProvider AuthenticationStateProvider

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

Add a link to the component's page in the `NavMenu` component (`Layout/NavMenu.razor`):

```razor
<div class="nav-item px-3">
    <NavLink class="nav-link" href="user-claims">
        <span class="bi bi-list-nested-nav-menu" aria-hidden="true"></span> User Claims
    </NavLink>
</div>
```

When testing with the Graph API locally, we recommend using a new InPrivate/incognito browser session for each test to prevent lingering cookies from interfering with testing. For more information, see <xref:blazor/security/webassembly/standalone-with-microsoft-entra-id#troubleshoot>.

:::zone-end

## Assign users to an app registration with or without app roles

You can add users to an app registration and assign roles to users with the following steps in the Azure portal.

To add a user, select **Users** from the ME-ID area of the Azure portal:

1. Select **New user** > **Create new user**.
1. Use the **Create user** template.
1. Supply the user's information in the **Identity** area.
1. You can generate an initial password or assign an initial password that the user changes when they sign in for the first time. If you use the password generated by the portal, make a note of it now.
1. Select **Create** to create the user. When **Create new user** interface closes, select **Refresh** to update the user list and show the new user.
1. For the examples in this article, assign a mobile phone number to the new user by selecting their name from the users list, selecting **Properties**, and editing the contact information to provide a mobile phone number.

To assign users to the app *without app roles*:

1. In the ME-ID area of the Azure portal, open **Enterprise applications**.
1. Select the app from the list.
1. Select **Users and groups**.
1. Select **Add user/group**.
1. Select a user.
1. Select the **Assign** button.

To assign users to the app *with app roles*:

1. Add roles to the app's registration in the Azure portal following the guidance in <xref:blazor/security/webassembly/meid-groups-roles#app-roles>.
1. In the ME-ID area of the Azure portal, open **Enterprise applications**.
1. Select the app from the list.
1. Select **Users and groups**.
1. Select **Add user/group**.
1. Select a user and select their role for accessing the app. Multiple roles are assigned to a user by repeating the process of adding the user to the app until all of the roles for a user are assigned. Users with multiple roles are listed once for each assigned role in the **Users and groups** list of users for the app.
1. Select the **Assign** button.

## `DefaultAccessTokenScopes` versus `AdditionalScopesToConsent`

The examples in this article provision Graph API scopes with <xref:Microsoft.Authentication.WebAssembly.Msal.Models.MsalProviderOptions.DefaultAccessTokenScopes%2A>, not <xref:Microsoft.Authentication.WebAssembly.Msal.Models.MsalProviderOptions.AdditionalScopesToConsent%2A>. 

<xref:Microsoft.Authentication.WebAssembly.Msal.Models.MsalProviderOptions.AdditionalScopesToConsent%2A> isn't used because it's unable to provision Graph API scopes for users when they sign in to the app for the first time with MSAL via the Azure consent UI. When the user attempts to access Graph API for the first time with the Graph SDK, they're confronted with an exception:

> :::no-loc text="Microsoft.Graph.Models.ODataErrors.ODataError: Access token is empty.":::

After a user provisions Graph API scopes provided via <xref:Microsoft.Authentication.WebAssembly.Msal.Models.MsalProviderOptions.DefaultAccessTokenScopes%2A>, the app can use <xref:Microsoft.Authentication.WebAssembly.Msal.Models.MsalProviderOptions.AdditionalScopesToConsent%2A> for a subsequent user sign in. However, changing app code makes no sense for a production app that requires the periodic addition of new users with delegated Graph scopes or adding new delegated Graph API scopes to the app.

The preceding discussion of how to provision scopes for Graph API access when the user first signs into the app only applies to:

* Apps that adopt the Graph SDK.
* Apps that use a named <xref:System.Net.Http.HttpClient> for Graph API access that asks users to consent to Graph scopes on their first sign in to the app.

When using a named <xref:System.Net.Http.HttpClient> that doesn't ask users to consent to Graph scopes on their first sign in, users are redirected to the Azure consent UI for Graph API scopes consent *when they first request access to Graph API* via the <xref:System.Net.Http.DelegatingHandler> of the preconfigured, named <xref:System.Net.Http.HttpClient>. When Graph scopes aren't consented initially with the named <xref:System.Net.Http.HttpClient> approach, neither <xref:Microsoft.Authentication.WebAssembly.Msal.Models.MsalProviderOptions.DefaultAccessTokenScopes%2A> nor <xref:Microsoft.Authentication.WebAssembly.Msal.Models.MsalProviderOptions.AdditionalScopesToConsent%2A> are called by the app. For more information, see the [named `HttpClient` coverage in this article](?pivots=named-client-graph-api).

:::moniker range="< aspnetcore-8.0"

## Hosted Blazor WebAssembly solutions

The examples in this article pertain to using the Graph SDK or a named <xref:System.Net.Http.HttpClient> with Graph API directly from a standalone Blazor WebAssembly app or directly from the **:::no-loc text="Client":::** app of a hosted Blazor WebAssembly [solution](xref:blazor/tooling#visual-studio-solution-file-sln). An additional scenario that isn't covered by this article is for a **:::no-loc text="Client":::** app of a hosted solution to call the **:::no-loc text="Server":::** app of the solution via web API, and then the **:::no-loc text="Server":::** app uses the Graph SDK/API to call Microsoft Graph and return data to the **:::no-loc text="Client":::** app. Although this is a supported approach, it isn't covered by this article. If you wish to adopt this approach:

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
* [Overview of permissions and consent in the Microsoft identity platform](/entra/identity-platform/permissions-consent-overview)
* [Enhance security with the principle of least privilege](/entra/identity-platform/secure-least-privileged-access)
* [Azure privilege escalation articles on the Internet (Google search result)](https://www.google.com/search?q=%22Azure+Privilege+Escalation%22)
* [Microsoft Security Best Practices: Securing privileged access](/security/privileged-access-workstations/overview)
