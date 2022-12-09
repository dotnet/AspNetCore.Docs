---
title: Use Graph API with ASP.NET Core Blazor WebAssembly
author: guardrex
description: Learn how to use the Microsoft Graph SDK/API with Blazor WebAssembly apps.
monikerRange: '>= aspnetcore-5.0'
ms.author: riande
ms.custom: mvc
ms.date: 12/09/2022
uid: blazor/security/webassembly/graph-api
zone_pivot_groups: blazor-graph-api
---
# Use Graph API with ASP.NET Core Blazor WebAssembly

This article explains how to use [Microsoft Graph API](/graph/use-the-api) in Blazor WebAssembly apps, which is a RESTful web API that enables apps to access Microsoft Cloud service resources.

> [!WARNING]
> The guidance in this article isn't meant to replace the primary [Microsoft Graph documentation](/graph/) and additional Azure security guidance in other Microsoft documentation sets. Assess the security guidance in the [Additional resources](#additional-resources) section of this article before implementing Microsoft Graph in a production environment. Follow all of Microsoft's best practices guidance to limit the attack surface area of your apps.

The examples in this article pertain to using the Graph SDK or a named `HttpClient` with Graph API directly from a standalone Blazor WebAssembly app or directly from the **:::no-loc text="Client":::** app of a hosted Blazor WebAssembly [solution](xref:blazor/tooling#visual-studio-solution-file-sln). An additional scenario that isn't covered by this article is for a **:::no-loc text="Client":::** app of a hosted solution to call the **:::no-loc text="Server":::** app of a hosted solution via web API, and then the the **:::no-loc text="Server":::** app uses the Graph SDK or Graph API to call Microsoft Graph and return data to the **:::no-loc text="Client":::** app. This is a viable and supported approach, but it isn't covered by this article. If you wish to adopt this approach:

* Follow the guidance in <xref:blazor/call-web-api> for the web API aspects on issuing requests to the **:::no-loc text="Server":::** app from the **:::no-loc text="Client":::** app and returning data to the **:::no-loc text="Client":::** app.
* Follow the guidance in the primary [Microsoft Graph documentation](/graph/) to use the Graph SDK with a typical ASP.NET Core app, which in this scenario is the **:::no-loc text="Server":::** app of the solution. If you use the Blazor WebAssembly project template to the create the hosted Blazor WebAssembly solution (**ASP.NET Core Hosted**/`-h|--hosted`) with organizational authorization (single organization/`SingleOrg` or multiple organization/`MultiOrg`) and the Microsoft Graph option (**Microsoft identity platform** > **Connected Services** > **Add Microsoft Graph permissions**/`--calls-graph`), the **:::no-loc text="Server":::** app of the solution is configured to use the Graph SDK.

> [!NOTE]
> The scenarios described in this article apply to using Azure Active Directory (AAD) as the identity provider, not AAD B2C.

Two approaches are available for directly interacting with Microsoft Graph in Blazor apps:

* [Microsoft Graph SDKs](/graph/sdks/sdks-overview) are designed to simplify building high-quality, efficient, and resilient applications that access Microsoft Graph. Select the **Graph SDK** button to adopt this approach.
* A named <xref:System.Net.Http.HttpClient> can issue web API requests to directly to Graph API. For more information on named `HttpClient`s, see <xref:blazor/call-web-api>. Select the **Named HttpClient with Graph API** button to adopt this approach.

:::zone pivot="graph-sdk"

The Graph SDK examples require the following package references in the standalone Blazor WebAssembly app or the **:::no-loc text="Client":::** app of a hosted Blazor WebAssembly solution:

* [`Microsoft.Extensions.Http`](https://www.nuget.org/packages/Microsoft.Extensions.Http)
* [`Microsoft.Graph`](https://www.nuget.org/packages/Microsoft.Graph)

[!INCLUDE[](~/includes/package-reference.md)]

After adding the Microsoft Graph API scopes in the AAD area of the Azure portal, add the following app settings configuration to the `wwwroot/appsettings.json`. In the following example, the `User.Read` scope is specified to match the examples in later sections of this article.

```json
"MicrosoftGraph": {
  "BaseUrl": "https://graph.microsoft.com",
  "Version: "v1.0",
  "Scopes": [
    "user.read"
  ]
}
```

Add the following `GraphClientExtensions` class to the standalone app or **:::no-loc text="Client":::** app of a hosted Blazor WebAssembly [solution](xref:blazor/tooling#visual-studio-solution-file-sln). The scopes are provided to the <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.AccessTokenRequestOptions.Scopes> property of the <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.AccessTokenRequestOptions> in the `AuthenticateRequestAsync` method. The <xref:Microsoft.Graph.IHttpProvider.OverallTimeout?displayProperty=nameWithType> is extended from the default value of 100 seconds to 300 seconds to give the `HttpClient` more time to receive a response from Microsoft Graph.

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
        services.Configure<RemoteAuthenticationOptions<MsalProviderOptions>>(
            options =>
            {
                scopes?.ForEach((scope) =>
                {
                    options.ProviderOptions.AdditionalScopesToConsent.Add(scope);
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

In `Program.cs`, add the Graph client services and configuration with the `AddGraphClient` extension method:

```csharp
var baseUrl = string.Join("/", 
    builder.Configuration.GetSection("MicrosoftGraph")["BaseUrl"], 
    builder.Configuration.GetSection("MicrosoftGraph")["Version"]);
var scopes = builder.Configuration.GetSection("MicrosoftGraph:Scopes")
    .Get<List<string>>();

builder.Services.AddGraphClient(baseUrl, scopes);
```

## Call Graph API from a component using the Graph SDK

The following `GraphExample` component uses an injected `GraphServiceClient` to obtain the user's AAD profile data and display their mobile phone number.

`Pages/GraphExample.razor`:

```razor
@page "/graph-example"
@using Microsoft.AspNetCore.Authorization
@using Microsoft.Graph
@attribute [Authorize]
@inject GraphServiceClient Client

<h1>Microsoft Graph Component Example</h1>

@if (user is not null && !string.IsNullOrEmpty(user.MobilePhone))
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

When testing with the Graph SDK locally, we recommend using a new in-private/incognito browser session for each test to prevent lingering cookies from interfering. For more information, see <xref:blazor/security/webassembly/standalone-with-azure-active-directory#troubleshoot>.

## Customize user claims with the Graph SDK

In the following example, the app creates mobile phone number and office location claims for a user from their AAD user profile's data. The app must have the `User.Read` Graph API scope configured in AAD.

In the following custom user account factory:

* An <xref:Microsoft.Extensions.Logging.ILogger> (`logger`) is included for convenience in case you wish to log information or errors in the `CreateUserAsync` method.
* In the event that an <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.AccessTokenNotAvailableException> is thrown, the user is redirected to the identity provider to sign into their account. Additional or different actions can be taken when requesting an access token fails. For example, the app can log the <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.AccessTokenNotAvailableException> and create a support ticket for further investigation.
* The framework's <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.RemoteUserAccount> represents the user's account. If the app requires a custom user account class that extends <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.RemoteUserAccount>, swap the custom user account class for <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.RemoteUserAccount> in the following code.

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

Next, configure the MSAL authentication to use the custom user account factory. Confirm that the `Program.cs` file uses the <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication?displayProperty=fullName> namespace:

```csharp
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
```

The example in this section builds on the approach of reading the base URL and Microsoft Graph scopes from app configuration via the `MicrosoftGraph:Scopes` key in `wwwroot/appsettings.json`. The following lines should already be present in `Program.cs` from following the guidance earlier in this article:

```csharp
var baseUrl = string.Join("/", 
    builder.Configuration.GetSection("MicrosoftGraph")["BaseUrl"], 
    builder.Configuration.GetSection("MicrosoftGraph")["Version"]);
var scopes = builder.Configuration.GetSection("MicrosoftGraph:Scopes")
    .Get<List<string>>();

builder.Services.AddGraphClient(baseUrl, scopes);
```

In `Program.cs`, find the call to the <xref:Microsoft.Extensions.DependencyInjection.MsalWebAssemblyServiceCollectionExtensions.AddMsalAuthentication%2A> extension method. Update the code to the following, which includes a call to <xref:Microsoft.Extensions.DependencyInjection.RemoteAuthenticationBuilderExtensions.AddAccountClaimsPrincipalFactory%2A> that adds an account claims principal factory with the `CustomAccountFactory`:

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

> [!NOTE]
> If the app uses a custom user account class that extends <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.RemoteUserAccount>, swap the custom user account class for <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.RemoteUserAccount> in the preceding code.

You can use the following `UserClaims` component to study the user's claims after the user authenticates with AAD:

`Pages/UserClaims.razor`:

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

        if (user.Identity is not null && user.Identity.IsAuthenticated)
        {
            claims = user.Claims;
        }
    }
}
```

When testing with the Graph SDK locally, we recommend using a new in-private/incognito browser session for each test to prevent lingering cookies from interfering. For more information, see <xref:blazor/security/webassembly/standalone-with-azure-active-directory#troubleshoot>.

:::zone-end

:::zone pivot="named-client-graph-api"

The following examples use a named <xref:System.Net.Http.HttpClient> for Graph API calls to obtain a user's mobile phone number to process a call or to customize a user's claims to include a mobile phone number claim and an office location claim.

The examples require a package reference for [`Microsoft.Extensions.Http`](https://www.nuget.org/packages/Microsoft.Extensions.Http) for the standalone Blazor WebAssembly app or the **:::no-loc text="Client":::** app of a hosted Blazor WebAssembly solution.

[!INCLUDE[](~/includes/package-reference.md)]

After adding the Microsoft Graph API scopes in the AAD area of the Azure portal, add the following app settings configuration to the `wwwroot/appsettings.json`. In the following example, the `User.Read` scope is specified to match the examples in later sections of this article.

```json
"MicrosoftGraph": {
  "BaseUrl": "https://graph.microsoft.com",
  "Version: "v1.0",
  "Scopes": [
    "user.read"
  ]
}
```

Create the following `GraphAuthorizationMessageHandler` class and project configuration in `Program.cs` for working with Graph API.

`GraphAuthorizationMessageHandler.cs`:

```csharp
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

public class GraphAPIAuthorizationMessageHandler : AuthorizationMessageHandler
{
    public GraphAPIAuthorizationMessageHandler(IAccessTokenProvider provider,
        NavigationManager navigation, IConfiguration config)
        : base(provider, navigation)
    {
        ConfigureHandler(
            authorizedUrls: new[] { config.GetSection("MicrosoftGraph")["BaseUrl"] },
            scopes: config.GetSection("MicrosoftGraph:Scopes").Get<List<string>>());
    }
}
```

In `Program.cs`, configure the named <xref:System.Net.Http.HttpClient> for Graph API:

```csharp
builder.Services.AddTransient<GraphAPIAuthorizationMessageHandler>();

builder.Services.AddHttpClient("GraphAPI",
        client => client.BaseAddress = new Uri(
            builder.Configuration.GetSection("MicrosoftGraph")["BaseUrl"]))
    .AddHttpMessageHandler<GraphAPIAuthorizationMessageHandler>();
```

> [!NOTE]
> In the preceding example, the `GraphAPIAuthorizationMessageHandler` <xref:System.Net.Http.DelegatingHandler> is registered as a transient service for <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.AddHttpMessageHandler%2A>. Transient registration is recommended for <xref:System.Net.Http.IHttpClientFactory>, which manages its own DI scopes. For more information, see the following resources:
>
> * [Utility base component classes to manage a DI scope](xref:blazor/fundamentals/dependency-injection#utility-base-component-classes-to-manage-a-di-scope)
> * [Detect transient disposables in Blazor WebAssembly apps](xref:blazor/fundamentals/dependency-injection#detect-transient-disposables-in-blazor-webassembly-apps)

## Call Graph API from a component with a named `HttpClient`

The `UserInfo.cs` class designates the required user profile properties with the <xref:System.Text.Json.Serialization.JsonPropertyNameAttribute> attribute and the JSON name used by AAD. The following example sets up properties for the user's mobile phone number and office location.

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

In the following `GraphExample` component, an <xref:System.Net.Http.HttpClient> is created for Graph API to issue a request for the user's profile data.

`Pages/GraphExample.razor`:

```razor
@page "/graph-example"
@using Microsoft.AspNetCore.Authorization
@using Microsoft.AspNetCore.Components.WebAssembly.Authentication
@inject IConfiguration Config
@inject IHttpClientFactory ClientFactory
@attribute [Authorize]

<h1>Microsoft Graph Component Example</h1>

@if (!string.IsNullOrEmpty(mobilePhone))
{
    <p>Mobile Phone: @mobilePhone</p>
}

@code {
    private string? mobilePhone;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            var client = ClientFactory.CreateClient("GraphAPI");

            var userInfo = await client.GetFromJsonAsync<UserInfo>(
                $"{Config.GetSection("MicrosoftGraph")["Version"]}/me");

            if (userInfo is not null && !string.IsNullOrEmpty(userInfo.MobilePhone))
            {
                mobilePhone = userInfo.MobilePhone;
            }
        }
        catch (AccessTokenNotAvailableException exception)
        {
            exception.Redirect();
        }
    }
}
```

When testing with the Graph API locally, we recommend using a new in-private/incognito browser session for each test to prevent lingering cookies from interfering. For more information, see <xref:blazor/security/webassembly/standalone-with-azure-active-directory#troubleshoot>.

## Customize user claims using a named `HttpClient`

In the following example, the app creates mobile phone number and office location claims for the user from their AAD user profile's data. The app must have the `User.Read` Graph API scope configured in AAD.

If you haven't already added the `UserInfo` class to the app by following the guidance earlier in this article, add the following class and designate the required user profile properties with the <xref:System.Text.Json.Serialization.JsonPropertyNameAttribute> attribute and the JSON name used by AAD. The following example sets up properties for the user's mobile phone number and office location.

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
    private readonly IConfiguration config;

    public CustomAccountFactory(IAccessTokenProviderAccessor accessor,
        IHttpClientFactory clientFactory,
        ILogger<CustomAccountFactory> logger,
        IConfiguration config)
        : base(accessor)
    {
        this.clientFactory = clientFactory;
        this.logger = logger;
        this.config = config;
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

                    var userInfo = await client.GetFromJsonAsync<UserInfo>(
                        $"{config.GetSection("MicrosoftGraph")["Version"]}/me");

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

Next, the MSAL authentication is configured to use the custom user account factory. Start by confirming that the `Program.cs` file uses the <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication?displayProperty=fullName> namespace:

```csharp
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
```

In `Program.cs`, find the call to the <xref:Microsoft.Extensions.DependencyInjection.MsalWebAssemblyServiceCollectionExtensions.AddMsalAuthentication%2A> extension method. Update the code to the following, which includes a call to <xref:Microsoft.Extensions.DependencyInjection.RemoteAuthenticationBuilderExtensions.AddAccountClaimsPrincipalFactory%2A> that adds an account claims principal factory with the `CustomAccountFactory`:

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

> [!NOTE]
> If the app uses a custom user account class that extends <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.RemoteUserAccount>, swap your app's custom user account class for <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.RemoteUserAccount> in the preceding code.

The preceding example is for an app that uses AAD authentication with MSAL. Similar patterns exist for OIDC and API authentication. For more information, see the examples in the [Customize the user with a payload claim](xref:blazor/security/webassembly/additional-scenarios#customize-the-user-with-a-payload-claim) section of the <xref:xref:blazor/security/webassembly/additional-scenarios> article.

You can use the following `UserClaims` component to study the user's claims after the user authenticates with AAD:

`Pages/UserClaims.razor`:

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

        if (user.Identity is not null && user.Identity.IsAuthenticated)
        {
            claims = user.Claims;
        }
    }
}
```

When testing with the Graph API locally, we recommend using a new in-private/incognito browser session for each test to prevent lingering cookies from interfering. For more information, see <xref:blazor/security/webassembly/standalone-with-azure-active-directory#troubleshoot>.

:::zone-end

## Additional resources

### General guidance

* [Microsoft Graph documentation](/graph/)
* [Microsoft Graph sample ASP.NET Core app](https://github.com/microsoftgraph/msgraph-sample-aspnet-core/tree/main/): Most appropriate for ***hosted*** Blazor WebAssembly solutions, where the **:::no-loc text="Server":::** app is configured to access Microsoft Graph as a typical ASP.NET Core app on behalf of the **:::no-loc text="Client":::** app. The **:::no-loc text="Client":::** app uses web API to make requests to the **:::no-loc text="Server":::** app for Graph data. However, the Graph coding practices in the linked Microsoft Graph sample app are relevant for standalone Blazor WebAssembly apps and should be consulted for general best practices.

### Security guidance

* [Microsoft Graph auth overview](/graph/auth/)
* [Overview of Microsoft Graph permissions](https://learn.microsoft.com/en-us/graph/permissions-overview)
* [Microsoft Graph permissions reference](/graph/permissions-reference)
* [Enhance security with the principle of least privilege](/azure/active-directory/develop/secure-least-privileged-access)
* [Microsoft Security Best Practices: Securing privileged access](/security/compass/overview)
* [Azure privilege escalation articles on the Internet (Google search result)](https://www.google.com/search?q=%22Azure+Privilege+Escalation%22)
