---
title: ASP.NET Core Blazor WebAssembly with Azure Active Directory groups and roles
author: guardrex
description: Learn how to configure Blazor WebAssembly to use Azure Active Directory groups and roles.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: "devx-track-csharp, mvc"
ms.date: 10/27/2020
no-loc: [appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/security/webassembly/aad-groups-roles
---
# Azure Active Directory (AAD) groups, Administrator Roles, and user-defined roles

By [Luke Latham](https://github.com/guardrex) and [Javier Calvarro Nelson](https://github.com/javiercn)

Azure Active Directory (AAD) provides several authorization approaches that can be combined with ASP.NET Core Identity:

* User-defined groups
  * Security
  * Microsoft 365
  * Distribution
* Roles
  * AAD Administrator Roles
  * User-defined roles

The guidance in this article applies to the Blazor WebAssembly AAD deployment scenarios described in the following topics:

* [Standalone with Microsoft Accounts](xref:blazor/security/webassembly/standalone-with-microsoft-accounts)
* [Standalone with AAD](xref:blazor/security/webassembly/standalone-with-azure-active-directory)
* [Hosted with AAD](xref:blazor/security/webassembly/hosted-with-azure-active-directory)

## Scopes

A [Microsoft Graph API](/graph/use-the-api) call is required for any app user with more than five AAD Administrator role and security group memberships.

To permit Graph API calls, give the standalone or *`Client`* app of a hosted Blazor solution any of the following [Graph API permissions (scopes)](/graph/permissions-reference) in the Azure portal:

* `Directory.Read.All`
* `Directory.ReadWrite.All`
* `Directory.AccessAsUser.All`

`Directory.Read.All` is the least-privileged scope and is the scope used for the example described in this article.

## User-defined groups and Administrator Roles

To configure the app in the Azure portal to provide a `groups` membership claim, see the following Azure articles. Assign users to user-defined AAD groups and AAD Administrator Roles.

* [Roles using Azure AD security groups](/azure/architecture/multitenant-identity/app-roles#roles-using-azure-ad-security-groups)
* [`groupMembershipClaims` attribute](/azure/active-directory/develop/reference-app-manifest#groupmembershipclaims-attribute)

The following examples assume that a user is assigned to the AAD *Billing Administrator* role.

The single `groups` claim sent by AAD presents the user's groups and roles as Object IDs (GUIDs) in a JSON array. The app must convert the JSON array of groups and roles into individual `group` claims that the app can build [policies](xref:security/authorization/policies) against.

When the number of assigned AAD Administrator Roles and user-defined groups exceeds five, AAD sends a `hasgroups` claim with a `true` value instead of sending a `groups` claim. Any app that may have more than five roles and groups assigned to its users must make a separate Graph API call to obtain a user's roles and groups. The example implementation provided in this article addresses this scenario. For more information, see the `groups` and `hasgroups` claims information in [Microsoft identity platform access tokens: Payload claims](/azure/active-directory/develop/access-tokens#payload-claims) article.

Extend <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.RemoteUserAccount> to include array properties for groups and roles. Assign an empty array to each property so that checking for `null` isn't required when these properties are used in `foreach` loops later.

`CustomUserAccount.cs`:

```csharp
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

public class CustomUserAccount : RemoteUserAccount
{
    [JsonPropertyName("groups")]
    public string[] Groups { get; set; } = new string[] { };

    [JsonPropertyName("roles")]
    public string[] Roles { get; set; } = new string[] { };
}
```

::: moniker range=">= aspnetcore-5.0"

Use **either** of the following approaches to create claims for AAD groups and roles:

* [Use the Graph SDK](#use-the-graph-sdk)
* [Use a named `HttpClient`](#use-a-named-httpclient)

### Use the Graph SDK

Add a package reference to the standalone app or *`Client`* app of a hosted Blazor solution for [`Microsoft.Graph`](https://www.nuget.org/packages/Microsoft.Graph).

Add the Graph SDK utility classes and configuration in the *Graph SDK* section of the <xref:blazor/security/webassembly/graph-api#graph-sdk> article.

Add the following custom user account factory to the standalone appo or *`Client`* app of a hosted Blazor solution (`CustomAccountFactory.cs`). The custom user factory is used to process roles and groups claims. The `roles` claim array is covered in the [User-defined roles](#user-defined-roles) section. If the `hasgroups` claim is present, the Graph SDK is used to make an authorized request to Graph API to obtain the user's roles and groups:

```csharp
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Graph;

public class CustomAccountFactory
    : AccountClaimsPrincipalFactory<CustomUserAccount>
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

    public async override ValueTask<ClaimsPrincipal> CreateUserAsync(
        CustomUserAccount account,
        RemoteAuthenticationUserOptions options)
    {
        var initialUser = await base.CreateUserAsync(account, options);

        if (initialUser.Identity.IsAuthenticated)
        {
            var userIdentity = (ClaimsIdentity)initialUser.Identity;

            foreach (var role in account.Roles)
            {
                userIdentity.AddClaim(new Claim("role", role));
            }

            if (userIdentity.HasClaim(c => c.Type == "hasgroups"))
            {
                IUserMemberOfCollectionWithReferencesPage groupsAndAzureRoles = 
                    null;

                try
                {
                    var graphClient = ActivatorUtilities
                        .CreateInstance<GraphServiceClient>(serviceProvider);
                    var oid = userIdentity.Claims.FirstOrDefault(x => x.Type == "oid")?
                        .Value;

                    if (!string.IsNullOrEmpty(oid))
                    {
                        groupsAndAzureRoles = await graphClient.Users[oid].MemberOf
                            .Request().GetAsync();
                    }
                }
                catch (ServiceException serviceException)
                {
                    // Optional: Log the error
                }

                if (groupsAndAzureRoles != null)
                {
                    foreach (var entry in groupsAndAzureRoles)
                    {
                        userIdentity.AddClaim(new Claim("group", entry.Id));
                    }
                }

                var claim = userIdentity.Claims.FirstOrDefault(
                    c => c.Type == "hasgroups");

                userIdentity.RemoveClaim(claim);
            }
            else
            {
                foreach (var group in account.Groups)
                {
                    userIdentity.AddClaim(new Claim("group", group));
                }
            }
        }

        return initialUser;
    }
}
```

The preceding code doesn't include transitive memberships. If the app requires direct and transitive group membership claims:

* Change the `IUserMemberOfCollectionWithReferencesPage` type for `groupsAndAzureRoles` to `IUserTransitiveMemberOfCollectionWithReferencesPage`.
* When requesting the user's groups and roles, replace the `MemberOf` property with `TransitiveMemberOf`.

In `Program.Main` (`Program.cs`), configure the MSAL authentication to use the custom user account factory: If the app uses a custom user account class that extends <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.RemoteUserAccount>, swap the custom user account class for <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.RemoteUserAccount> in the following code:

```csharp
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Extensions.Configuration;

...

builder.Services.AddMsalAuthentication<RemoteAuthenticationState, 
    CustomUserAccount>(options =>
{
    builder.Configuration.Bind("AzureAd", 
        options.ProviderOptions.Authentication);
    options.ProviderOptions.DefaultAccessTokenScopes.Add("...");

    options.ProviderOptions.AdditionalScopesToConsent.Add(
        "https://graph.microsoft.com/Directory.Read.All");
})
.AddAccountClaimsPrincipalFactory<RemoteAuthenticationState, CustomUserAccount, 
    CustomUserFactory>();
```

### Use a named `HttpClient`

::: moniker-end

In the standalone app or the *`Client`* app of a hosted Blazor solution, create a custom <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.AuthorizationMessageHandler> class. Use the correct scope for Graph API calls that obtain role and group information.

`GraphAPIAuthorizationMessageHandler.cs`:

```csharp
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

public class GraphAPIAuthorizationMessageHandler : AuthorizationMessageHandler
{
    public GraphAPIAuthorizationMessageHandler(IAccessTokenProvider provider,
        NavigationManager navigationManager)
        : base(provider, navigationManager)
    {
        ConfigureHandler(
            authorizedUrls: new[] { "https://graph.microsoft.com" },
            scopes: new[] { "https://graph.microsoft.com/Directory.Read.All" });
    }
}
```

In `Program.Main` (`Program.cs`), add the <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.AuthorizationMessageHandler> implementation service and add a named <xref:System.Net.Http.HttpClient> for making Graph API requests. The following example names the client `GraphAPI`:

```csharp
builder.Services.AddScoped<GraphAPIAuthorizationMessageHandler>();

builder.Services.AddHttpClient("GraphAPI",
        client => client.BaseAddress = new Uri("https://graph.microsoft.com"))
    .AddHttpMessageHandler<GraphAPIAuthorizationMessageHandler>();
```

Create AAD directory objects classes to receive the Open Data Protocol (OData) roles and groups from a Graph API call. The OData arrives in JSON format, and a call to <xref:System.Net.Http.Json.HttpContentJsonExtensions.ReadFromJsonAsync%2A> populates an instance of the `DirectoryObjects` class.

`DirectoryObjects.cs`:

```csharp
using System.Collections.Generic;
using System.Text.Json.Serialization;

public class DirectoryObjects
{
    [JsonPropertyName("@odata.context")]
    public string Context { get; set; }

    [JsonPropertyName("value")]
    public List<Value> Values { get; set; }
}

public class Value
{
    [JsonPropertyName("@odata.type")]
    public string Type { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; }
}
```

Create a custom user factory to process roles and groups claims. The following example implementation also handles the `roles` claim array, which is covered in the [User-defined roles](#user-defined-roles) section. If the `hasgroups` claim is present, the named <xref:System.Net.Http.HttpClient> is used to make an authorized request to Graph API to obtain the user's roles and groups. This implementation uses the Microsoft Identity Platform v1.0 endpoint `https://graph.microsoft.com/v1.0/me/memberOf` ([API documentation](/graph/api/user-list-memberof)).

`CustomAccountFactory.cs`:

```csharp
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;
using Microsoft.Extensions.Logging;

public class CustomUserFactory
    : AccountClaimsPrincipalFactory<CustomUserAccount>
{
    private readonly ILogger<CustomUserFactory> logger;
    private readonly IHttpClientFactory clientFactory;

    public CustomUserFactory(IAccessTokenProviderAccessor accessor, 
        IHttpClientFactory clientFactory, 
        ILogger<CustomUserFactory> logger)
        : base(accessor)
    {
        this.clientFactory = clientFactory;
        this.logger = logger;
    }

    public async override ValueTask<ClaimsPrincipal> CreateUserAsync(
        CustomUserAccount account,
        RemoteAuthenticationUserOptions options)
    {
        var initialUser = await base.CreateUserAsync(account, options);

        if (initialUser.Identity.IsAuthenticated)
        {
            var userIdentity = (ClaimsIdentity)initialUser.Identity;

            foreach (var role in account.Roles)
            {
                userIdentity.AddClaim(new Claim("role", role));
            }

            if (userIdentity.HasClaim(c => c.Type == "hasgroups"))
            {
                try
                {
                    var client = clientFactory.CreateClient("GraphAPI");

                    var response = await client.GetAsync("v1.0/me/memberOf");

                    if (response.IsSuccessStatusCode)
                    {
                        var userObjects = await response.Content
                            .ReadFromJsonAsync<DirectoryObjects>();

                        foreach (var obj in userObjects?.Values)
                        {
                            userIdentity.AddClaim(new Claim("group", obj.Id));
                        }

                        var claim = userIdentity.Claims.FirstOrDefault(
                            c => c.Type == "hasgroups");

                        userIdentity.RemoveClaim(claim);
                    }
                    else
                    {
                        logger.LogError("Graph API request failure: {REASON}", 
                            response.ReasonPhrase);
                    }
                }
                catch (AccessTokenNotAvailableException exception)
                {
                    logger.LogError("Graph API access token failure: {Message}", 
                        exception.Message);
                }
            }
            else
            {
                foreach (var group in account.Groups)
                {
                    userIdentity.AddClaim(new Claim("group", group));
                }
            }
        }

        return initialUser;
    }
}
```

There's no need to provide code to remove the original `groups` claim, if present, because it's automatically removed by the framework.

> [!NOTE]
> The approach in this example:
>
> * Adds a custom <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.AuthorizationMessageHandler> class to attach access tokens to outgoing requests.
> * Adds a named <xref:System.Net.Http.HttpClient> for making web API requests to a secure, external web API endpoint.
> * Uses the named <xref:System.Net.Http.HttpClient> to make authorized requests.
>
> General coverage for this approach is found in the <xref:blazor/security/webassembly/additional-scenarios#custom-authorizationmessagehandler-class> article.

Register the factory in `Program.Main` (`Program.cs`) of the standalone app or *`Client`* app of a hosted Blazor solution. Consent to the `Directory.Read.All` scope as an additional scope for the app:

```csharp
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Extensions.Configuration;

...

builder.Services.AddMsalAuthentication<RemoteAuthenticationState, 
    CustomUserAccount>(options =>
{
    builder.Configuration.Bind("AzureAd", 
        options.ProviderOptions.Authentication);
    options.ProviderOptions.DefaultAccessTokenScopes.Add("...");

    options.ProviderOptions.AdditionalScopesToConsent.Add(
        "https://graph.microsoft.com/Directory.Read.All");
})
.AddAccountClaimsPrincipalFactory<RemoteAuthenticationState, CustomUserAccount, 
    CustomUserFactory>();
```

## Authorization configuration

Create a [policy](xref:security/authorization/policies) for each group or role in `Program.Main`. The following example creates a policy for the AAD *Billing Administrator* role:

```csharp
builder.Services.AddAuthorizationCore(options =>
{
    options.AddPolicy("BillingAdministrator", policy => 
        policy.RequireClaim("group", "69ff516a-b57d-4697-a429-9de4af7b5609"));
});
```

For the complete list of AAD role Object IDs, see the [AAD Administrator Role Object IDs](#aad-administrator-role-object-ids) section.

In the following examples, the app uses the preceding policy to authorize the user.

The [`AuthorizeView` component](xref:blazor/security/index#authorizeview-component) works with the policy:

```razor
<AuthorizeView Policy="BillingAdministrator">
    <Authorized>
        <p>
            The user is in the 'Billing Administrator' AAD Administrator Role
            and can see this content.
        </p>
    </Authorized>
    <NotAuthorized>
        <p>
            The user is NOT in the 'Billing Administrator' role and sees this
            content.
        </p>
    </NotAuthorized>
</AuthorizeView>
```

Access to an entire component can be based on the policy using [`[Authorize]` attribute directive](xref:blazor/security/index#authorize-attribute) (<xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute>):

```razor
@page "/"
@using Microsoft.AspNetCore.Authorization
@attribute [Authorize(Policy = "BillingAdministrator")]
```

If the user isn't logged in, they're redirected to the AAD sign-in page and then back to the component after they sign in.

A policy check can also be [performed in code with procedural logic](xref:blazor/security/index#procedural-logic):

```razor
@page "/checkpolicy"
@using Microsoft.AspNetCore.Authorization
@inject IAuthorizationService AuthorizationService

<h1>Check Policy</h1>

<p>This component checks a policy in code.</p>

<button @onclick="CheckPolicy">Check 'BillingAdministrator' policy</button>

<p>Policy Message: @policyMessage</p>

@code {
    private string policyMessage = "Check hasn't been made yet.";

    [CascadingParameter]
    private Task<AuthenticationState> authenticationStateTask { get; set; }

    private async void CheckPolicy()
    {
        var user = (await authenticationStateTask).User;

        if ((await AuthorizationService.AuthorizeAsync(user, 
            "BillingAdministrator")).Succeeded)
        {
            policyMessage = "Yes! The 'BillingAdministrator' policy is met.";
        }
        else
        {
            policyMessage = "No! 'BillingAdministrator' policy is NOT met.";
        }
    }
}
```

## Authorize server API access for user-defined groups and Administrator Roles

In addition to authorizing users in the client-side WebAssembly app to access pages and resources, the server API can authorize users for access to secure API endpoints. After the *Server* app validates the user's access token:

* The server API app uses the user's immutable [object identifier claim (`oid`)](/azure/active-directory/develop/id-tokens#payload-claims) from their access token to obtain an access token for Graph API.
* A Graph API call obtains the user's Azure user-defined security group and Administrator Role memberships by calling [`memberOf`](/graph/api/user-list-memberof) on the user.
* Memberships are used to establish `group` claims.
* [Authorization policies](xref:security/authorization/policies) can be used to limit user access to server API endpoints throughout the app.

> [!NOTE]
> This guidance doesn't currently include authorizing users on the basis of their [AAD user-defined roles](#user-defined-roles).

The guidance in this section configures the server API app as a [*daemon app*](/azure/active-directory/develop/scenario-daemon-overview) for the Microsoft Graph API call. This approach does **not**:

* Require the the `access_as_user` scope.
* Access Graph API on behalf of the user/client making the API request.

The call to Graph API by the server API app only requires a server API app **Application** Graph API scope for `Directory.Read.All` in the Azure portal. This approach absolutely prevents the client app from accessing directory data that the server API doesn't explicitly permit. The client app is only able to access the server API app's controller endpoints.

### Azure configuration

* Confirm that the *Server* app registration is given **Application** (not **Delegated**) Graph API scope for `Directory.Read.All`, which is the least-privileged access level for security groups. Confirm that admin consent is applied to the scope after making the scope assignment.
* Assign a new client secret to the *Server* app. Note the secret for the app's configuration in the [App settings](#app-settings) section.

### App settings

In the app settings file (`appsettings.json` or `appsettings.Production.json`), create a `ClientSecret` entry with the *Server* app's client secret from the Azure portal:

```json
"AzureAd": {
  "Instance": "https://login.microsoftonline.com/",
  "Domain": "XXXXXXXXXXXX.onmicrosoft.com",
  "TenantId": "{GUID}",
  "ClientId": "{GUID}",
  "ClientSecret": "{CLIENT SECRET}"
},
```

For example:

```json
"AzureAd": {
  "Instance": "https://login.microsoftonline.com/",
  "Domain": "contoso.onmicrosoft.com",
  "TenantId": "34bf0ec1-7aeb-4b5d-ba42-82b059b3abe8",
  "ClientId": "05d198e0-38c6-4efc-a67c-8ee87ed9bd3d",
  "ClientSecret": "54uE~9a.-wW91fe8cRR25ag~-I5gEq_92~"
},
```

::: moniker range=">= aspnetcore-5.0"

> [!NOTE]
> If the tenant publisher domain isn't verified, the server API scope for user/client access uses an `https://`-based URI. In this scenario, the server API app requires `Audience` configuration in the `appsettings.json` file. In the following configuration, the end of the `Audience` value does **not** include the default scope `/{DEFAULT SCOPE}`, where the placeholder `{DEFAULT SCOPE}` is the default scope:
>
> ```json
> {
>   "AzureAd": {
>     ...
>
>     "Audience": "https://{TENANT}.onmicrosoft.com/{SERVER API APP CLIENT ID OR CUSTOM VALUE}"
>   }
> }
>
> In the preceding configuration, the placeholder `{TENANT}` is the app's tenant, and the placeholder `{SERVER API APP CLIENT ID OR CUSTOM VALUE}` is the server API app's `ClientId` or custom value provided in the Azure portal's app registration.
>
> Example:
>
> ```json
> {
>   "AzureAd": {
>     ...
>
>     "Audience": "https://contoso.onmicrosoft.com/41451fa7-82d9-4673-8fa5-69eff5a761fd"
>   }
> }
> ```
>
> In the preceding example configuration:
>
> * The tenant domain is `contoso.onmicrosoft.com`.
> * The server API app `ClientId` is `41451fa7-82d9-4673-8fa5-69eff5a761fd`.
>
> > [!NOTE]
> > Configuring an `Audience` explicitly usually is **not** required for app's with a verified publisher domain that has an `api://`-based API scope.
>
> For more information, see <xref:blazor/security/webassembly/hosted-with-azure-active-directory#app-settings>.

::: moniker-end

### Authorization policies

Create [authorization policies](xref:security/authorization/policies) for AAD security groups and AAD Administrator Roles in the *Server* app's `Startup.ConfigureServices` (`Startup.cs`) based on group object IDs and [AAD Administrator Role object IDs](#aad-administrator-role-object-ids).

For example, an Azure Billing Administrator Role policy has the following configuration:

```csharp
services.AddAuthorization(options =>
{
    options.AddPolicy("BillingAdmin", policy => 
        policy.RequireClaim("group", "69ff516a-b57d-4697-a429-9de4af7b5609"));
});
```

For more information, see <xref:security/authorization/policies>.

### Controller access

Require policies on the *Server* app's controllers.

The following example limits access to billing data from the `BillingDataController` to Azure Billing Administrators with a policy name of `BillingAdmin`, as configured in the [Authorization policies](#authorization-policies) section:

```csharp
[Authorize(Policy = "BillingAdmin")]
[ApiController]
[Route("[controller]")]
public class BillingDataController : ControllerBase
{
    ...
}
```

::: moniker range=">= aspnetcore-5.0"

### Packages

Add package references to the *Server* app for the following packages:

* [Microsoft.Graph](https://www.nuget.org/packages/Microsoft.Graph)
* [Microsoft.Identity.Client](https://www.nuget.org/packages/Microsoft.Identity.Client)

### Services

In the *Server* app's `Startup.ConfigureServices` method, additional namespaces are required for the code in the `Startup` class of the *Server* app. Add the following namespaces to `Startup.cs`:

```csharp
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Logging;
```

When configuring <xref:Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerEvents>:

* Optionally include processing for <xref:Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerEvents.OnAuthenticationFailed?displayProperty=nameWithType>. For example, the app can log failed authentication.
* In <xref:Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerEvents.OnTokenValidated?displayProperty=nameWithType>, make a Graph API call to obtain the user's groups and roles.

> [!WARNING]
> <xref:Microsoft.IdentityModel.Logging.IdentityModelEventSource.ShowPII?displayProperty=nameWithType> provides Personally Identifiable Information (PII) in logging messages. Only activate PII for debugging with test user accounts.

In `Startup.ConfigureServices`:

```csharp
JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

#if DEBUG
IdentityModelEventSource.ShowPII = true;
#endif

var scopes = new string[] { "https://graph.microsoft.com/.default" };

var app = ConfidentialClientApplicationBuilder.Create(Configuration["AzureAd:ClientId"])
   .WithClientSecret(Configuration["AzureAd:ClientSecret"])
   .WithAuthority(new Uri(Configuration["AzureAd:Instance"] + Configuration["AzureAd:Domain"]))
   .Build();

services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(options =>
{
    Configuration.Bind("AzureAd", options);

    options.Events = new JwtBearerEvents()
    {
        OnTokenValidated = async context =>
        {
            var accessToken = context.SecurityToken as JwtSecurityToken;

            var oid = accessToken.Claims.FirstOrDefault(x => x.Type == "oid")?
                .Value;

            if (!string.IsNullOrEmpty(oid))
            {
                var userIdentity = (ClaimsIdentity)context.Principal.Identity;

                AuthenticationResult authResult = null;

                try
                {
                    authResult = await app.AcquireTokenForClient(scopes)
                        .ExecuteAsync();
                }
                catch (MsalUiRequiredException ex)
                {
                    // Optional: Log the exception
                }
                catch (MsalServiceException ex)
                {
                    // Optional: Log the exception
                }

                var graphClient = new GraphServiceClient(
                    new DelegateAuthenticationProvider(async requestMessage => {
                        requestMessage.Headers.Authorization =
                            new AuthenticationHeaderValue("Bearer", authResult.AccessToken);

                        await Task.CompletedTask;
                    }));

                IUserMemberOfCollectionWithReferencesPage groupsAndAzureRoles = 
                    null;

                try
                {
                    groupsAndAzureRoles = await graphClient.Users[oid].MemberOf.Request()
                        .GetAsync();
                }
                catch (ServiceException serviceException)
                {
                    // Optional: Log the exception
                }

                if (groupsAndAzureRoles != null)
                {
                    foreach (var entry in groupsAndAzureRoles)
                    {
                        userIdentity.AddClaim(new Claim("group", entry.Id));
                    }
                }
            }

            await Task.FromResult(0);
        }
    };
}, 
options =>
{
    Configuration.Bind("AzureAd", options);
});
```

In the preceding code, handling the following token errors is optional:

* `MsalUiRequiredException`: The app doesn't have sufficient permissions (scopes).
  * Determine if the server API app scopes in the Azure portal include an **Application** permission for `Directory.Read.All`.
  * Confirm that the tenant administrator has granted permissions to the app.
* `MsalServiceException` (`AADSTS70011`): Confirm that the scope is `https://graph.microsoft.com/.default`.

::: moniker-end

::: moniker range="< aspnetcore-5.0"

### Packages

Add package references to the *Server* app for the following packages:

* [Microsoft.Graph](https://www.nuget.org/packages/Microsoft.Graph)
* [Microsoft.IdentityModel.Clients.ActiveDirectory](https://www.nuget.org/packages?q=Microsoft.IdentityModel.Clients.ActiveDirectory)

### Service configuration

In the *Server* app's `Startup.ConfigureServices` method add logic to make the Graph API call and establish user `group` claims for the user's security groups and roles.

> [!NOTE]
> The example code in this section uses the Active Directory Authentication Library (ADAL), which is based on Microsoft Identity Platform v1.0.

Additional namespaces are required for the code in the `Startup` class of the *Server* app. The following set of `using` statements includes the required namespaces for the code that follows in this section:

```csharp
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Graph;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.IdentityModel.Logging;
```

When configuring <xref:Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerEvents>:

* Optionally include processing for <xref:Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerEvents.OnAuthenticationFailed?displayProperty=nameWithType>. For example, the app can log failed authentication.
* In <xref:Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerEvents.OnTokenValidated?displayProperty=nameWithType>, make a Graph API call to obtain the user's groups and roles.

> [!WARNING]
> <xref:Microsoft.IdentityModel.Logging.IdentityModelEventSource.ShowPII?displayProperty=nameWithType> provides Personally Identifiable Information (PII) in logging messages. Only activate PII for debugging with test user accounts.

In `Startup.ConfigureServices`:

```csharp
#if DEBUG
IdentityModelEventSource.ShowPII = true;
#endif

services.AddAuthentication(AzureADDefaults.BearerAuthenticationScheme)
    .AddAzureADBearer(options => Configuration.Bind("AzureAd", options));

services.Configure<JwtBearerOptions>(AzureADDefaults.JwtBearerAuthenticationScheme, 
    options =>
{
    options.Events = new JwtBearerEvents()
    {
        OnTokenValidated = async context =>
        {
            var accessToken = context.SecurityToken as JwtSecurityToken;
            var oid = accessToken.Claims.FirstOrDefault(x => x.Type == "oid")?
                .Value;

            if (!string.IsNullOrEmpty(oid))
            {
                var authContext = new AuthenticationContext(
                    Configuration["AzureAd:Instance"] +
                    Configuration["AzureAd:TenantId"]);
                AuthenticationResult authResult = null;

                try
                {
                    authResult = await authContext.AcquireTokenSilentAsync(
                        "https://graph.microsoft.com", 
                        Configuration["AzureAd:ClientId"]);
                }
                catch (AdalException adalException)
                {
                    if (adalException.ErrorCode == 
                        AdalError.FailedToAcquireTokenSilently || 
                        adalException.ErrorCode == 
                        AdalError.UserInteractionRequired)
                    {
                        var userAssertion = new UserAssertion(accessToken.RawData,
                            "urn:ietf:params:oauth:grant-type:jwt-bearer", oid);
                        var clientCredential = new ClientCredential(
                            Configuration["AzureAd:ClientId"],
                            Configuration["AzureAd:ClientSecret"]);
                        authResult = await authContext.AcquireTokenAsync(
                            "https://graph.microsoft.com", clientCredential, 
                            userAssertion);
                    }
                }

                var graphClient = new GraphServiceClient(
                    new DelegateAuthenticationProvider(async requestMessage => {
                        requestMessage.Headers.Authorization =
                            new AuthenticationHeaderValue("Bearer", 
                                authResult.AccessToken);

                        await Task.CompletedTask;
                    }));

                var userIdentity = (ClaimsIdentity)context.Principal.Identity;

                IUserMemberOfCollectionWithReferencesPage groupsAndAzureRoles = 
                    null;

                try
                {
                    groupsAndAzureRoles = await graphClient.Users[oid].MemberOf
                        .Request().GetAsync();
                }
                catch (ServiceException serviceException)
                {
                    // Optional: Log the error
                }

                if (groupsAndAzureRoles != null)
                {
                    foreach (var entry in groupsAndAzureRoles)
                    {
                        userIdentity.AddClaim(new Claim("group", entry.Id));
                    }
                }
            }

            await Task.FromResult(0);
        }
    };
});
```

In the preceding example:

* Silent token acquisition (<xref:Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationContext.AcquireTokenSilentAsync%2A>) is attempted first because the access token may have already been stored in the ADAL token cache. It's faster to obtain the token from cache than to request a new token.
* If the access token isn't acquired from cache (<xref:Microsoft.IdentityModel.Clients.ActiveDirectory.AdalError.FailedToAcquireTokenSilently?displayProperty=nameWithType> or <xref:Microsoft.IdentityModel.Clients.ActiveDirectory.AdalError.UserInteractionRequired?displayProperty=nameWithType> is thrown), a user assertion (<xref:Microsoft.IdentityModel.Clients.ActiveDirectory.UserAssertion>) is made with the client credential (<xref:Microsoft.IdentityModel.Clients.ActiveDirectory.ClientCredential>) to obtain the token on behalf of the user (<xref:Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationContext.AcquireTokenAsync%2A>). Next, the `Microsoft.Graph.GraphServiceClient` can proceed to use the token to make the Graph API call. The token is placed into the ADAL token cache. For future Graph API calls for the same user, the token is acquired from cache silently with <xref:Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationContext.AcquireTokenSilentAsync%2A>.

::: moniker-end

The code in <xref:Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerEvents.OnTokenValidated> doesn't obtain transitive memberships. To change the code to obtain direct and transitive memberships:

* For the code line:

  ```csharp
  IUserMemberOfCollectionWithReferencesPage groupsAndAzureRoles = null;
  ```

  Replace the preceding line with:

  ```csharp
  IUserTransitiveMemberOfCollectionWithReferencesPage groupsAndAzureRoles = null;
  ```

* For the code line:

  ```csharp
  groupsAndAzureRoles = await graphClient.Users[oid].MemberOf.Request().GetAsync();
  ```

  Replace the preceding line with:

  ```csharp
  groupsAndAzureRoles = await graphClient.Users[oid].TransitiveMemberOf.Request()
      .GetAsync();
  ```

The code in <xref:Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerEvents.OnTokenValidated> doesn't distinguish between AAD security groups and AAD Administrator Roles when creating claims. For the app to distinguish between groups and roles, check the `entry.ODataType` when iterating through the groups and roles. To create separate security group and role claims, use code similar to the following:

```csharp
foreach (var entry in groupsAndAzureRoles)
{
    if (entry.ODataType == "#microsoft.graph.group")
    {
        userIdentity.AddClaim(new Claim("group", entry.Id));
    }
    else
    {
        // entry.ODataType == "#microsoft.graph.directoryRole"
        userIdentity.AddClaim(new Claim("role", entry.Id));
    }
}
```

## User-defined roles

An AAD-registered app can also be configured to use user-defined roles.

To configure the app in the Azure portal to provide a `roles` membership claim, see [How to: Add app roles in your application and receive them in the token](/azure/active-directory/develop/howto-add-app-roles-in-azure-ad-apps) in the Azure documentation.

The following example assumes that an app is configured with two roles:

* `admin`
* `developer`

> [!NOTE]
> Although you can't assign roles to security groups without an Azure AD Premium account, you can assign users to roles and receive a `roles` claim for users with a standard Azure account. The guidance in this section doesn't require an Azure AD Premium account.
>
> Multiple roles are assigned in the Azure portal by **_re-adding a user_** for each additional role assignment.

The single `roles` claim sent by AAD presents the user-defined roles as the `appRoles`'s `value`s in a JSON array. The app must convert the JSON array of roles into individual `role` claims.

The `CustomUserFactory` shown in the [User-defined groups and AAD Administrator Roles](#user-defined-groups-and-administrator-roles) section is set up to act on a `roles` claim with a JSON array value. Add and register the `CustomUserFactory` in the standalone app or *`Client`* app of a hosted Blazor solution as shown in the [User-defined groups and AAD Administrator Roles](#user-defined-groups-and-administrator-roles) section. There's no need to provide code to remove the original `roles` claim because it's automatically removed by the framework.

In `Program.Main` of the standalone app or *`Client`* app of a hosted Blazor solution, specify the claim named "`role`" as the role claim:

```csharp
builder.Services.AddMsalAuthentication(options =>
{
    ...

    options.UserOptions.RoleClaim = "role";
});
```

Component authorization approaches are functional at this point. Any of the authorization mechanisms in components can use the `admin` role to authorize the user:

* [`AuthorizeView` component](xref:blazor/security/index#authorizeview-component) (Example: `<AuthorizeView Roles="admin">`)
* [`[Authorize]` attribute directive](xref:blazor/security/index#authorize-attribute) (<xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute>) (Example: `@attribute [Authorize(Roles = "admin")]`)
* [Procedural logic](xref:blazor/security/index#procedural-logic) (Example: `if (user.IsInRole("admin")) { ... }`)

  Multiple role tests are supported:

  ```csharp
  if (user.IsInRole("admin") && user.IsInRole("developer"))
  {
      ...
  }
  ```

## AAD Administrator Role Object IDs

The Object IDs presented in the following table are used to create [policies](xref:security/authorization/policies) for `group` claims. Policies permit an app to authorize users for various activities in an app. For more information, see the [User-defined groups and AAD Administrator Roles](#user-defined-groups-and-administrator-roles) section.

AAD Administrator Role | Object ID
--- | ---
Application administrator | fa11557b-4f15-4ddd-85d5-313c7cd74047
Application developer | 68adcbb8-9504-44f6-89f2-5cd48dc74a2c
Authentication administrator | 02d110a1-96b1-419e-af87-746461b60ed7
Azure DevOps administrator | a5311ace-ca41-44cd-b833-8d22caa0b34f
Azure Information Protection administrator | 18632dce-f9b5-4f01-abb5-37051f06860e
B2C IEF Keyset administrator | 0c2e87e5-94f9-4adb-ae8c-bcafe11bd368
B2C IEF Policy administrator | bfcab36c-10c6-4b13-b63c-4d8b62c0c44e
B2C user flow administrator | baa531b7-8cf0-44ad-8f98-eded88dae827
B2C user flow attribute administrator | dd0baca0-a535-48c1-b871-8431abe16452
Billing administrator | 69ff516a-b57d-4697-a429-9de4af7b5609
Cloud application administrator | 250b5fe3-b553-458d-9a53-b782c13c34bf
Cloud device administrator | 26cd4b44-2636-4ddb-bdfa-27feae66f86d
Compliance administrator | 9d6e1dd0-c9f8-45f8-b558-b134f700116c
Compliance data administrator | 4c0ca3a2-231e-416c-9411-4abe57d5cb9d
Conditional Access administrator | 8f71a611-137d-49af-87ad-e97f1fd5da76
Customer LockBox access approver | c18d54a8-b13e-4954-a1a4-7deaf2e4f184
Desktop Analytics administrator | c62c4ac5-e4c6-4096-8a2f-1ee3cbaaae15
Directory readers | e1fc84a6-7762-4b9b-8e29-518b4adbc23b
Dynamics 365 administrator | f20a9cfa-9fdf-49a8-a977-1afe446a1d6e
Exchange administrator | b2ec2cc0-d5c9-4864-ad9b-38dd9dba2652
External Identity Provider administrator | febfaeb4-e478-407a-b4b3-f4d9716618a2
Global administrator | a45ba61b-44db-462c-924b-3b2719152588
Global reader | f6903b21-6aba-4124-b44c-76671796b9d5
Groups administrator | 158b3e5a-d89d-460b-92b5-3b34985f0197
Guest inviter | 4c730a1d-cc22-44af-8f9f-4eec635c7502
Helpdesk administrator | 108678c8-6628-44e1-8d01-caf598a6a5f5
Intune administrator | 79950741-23fa-4189-b2cb-46640601c497
Kaizala administrator | d6322af2-48e7-42e0-8c68-0bbe31af3412
License administrator | 3355458a-e423-44bf-8b98-4ac5e572cea5
Message center privacy reader | 6395db95-9fb8-42b9-b1ed-30a2405eee6f
Message center reader | fd5d37b8-4e24-434b-9e63-70ed3b759a16
Office apps administrator | 5f3870cd-b042-4f93-86d7-c9d77c664dc7
Password administrator | 466e48b7-5d66-4ae5-8911-1a118de74941
Power BI administrator | 984e83b8-8337-4255-91a1-acb663175ab4
Power platform administrator | 76d6f95e-9a15-4d7d-8d21-00de00faf9fd
Privileged authentication administrator | 0829f731-b46d-419f-9742-aeb122367d11
Privileged role administrator | f20a725a-d1c8-4107-83ea-1171c97d00c7
Reports reader | 54635450-e8ed-4f2d-9632-07db2517b4de
Search administrator | c770a2f1-c9ba-4e60-9176-9f52b1eb1a31
Search editor | 6a6858c6-5f0d-44ac-87c7-0190fbedd271
Security administrator | 20fa50e3-6531-44d8-bd39-b251420568ad
Security operator | 43aae017-8e51-4188-91ab-e6debd572800
Security reader | 45035cd3-fd97-4250-8197-3a53d3562d9b
Service support administrator | 2c92cf45-c914-48f8-9bf9-fc14b28818ab
SharePoint administrator | e1c32229-875e-461d-ae24-3cb99116e86c
Skype for Business administrator | 0a8cee12-e21d-43ef-abd9-f1ea85710e30
Teams Communications Administrator | 2393e455-6e13-4743-9f52-63fcec2b6a9c
Teams Communications Support Engineer | 802dd94e-d717-46f6-af98-b9167071e9fc
Teams Communications Specialist | ef547281-cf46-4cc6-bcaa-f5eac3f030c9
Teams Service Administrator | 8846a0be-197b-443a-b13c-11192691fa24
User administrator | 1f6eed58-7dd3-460b-a298-666f975427a1

## Additional resources

* <xref:security/authorization/claims>
* <xref:blazor/security/index>
