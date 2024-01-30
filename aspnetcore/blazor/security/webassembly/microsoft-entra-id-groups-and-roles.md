---
title: ASP.NET Core Blazor WebAssembly with Microsoft Entra ID groups and roles
author: guardrex
description: Learn how to configure Blazor WebAssembly to use Microsoft Entra ID groups and roles.
monikerRange: '>= aspnetcore-5.0'
ms.author: riande
ms.custom: "devx-track-csharp, mvc"
ms.date: 01/30/2024
uid: blazor/security/webassembly/meid-groups-roles
zone_pivot_groups: blazor-groups-and-roles
---
# Microsoft Entra (ME-ID) groups, Administrator Roles, and App Roles

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how to configure Blazor WebAssembly to use Microsoft Entra ID groups and roles.

Microsoft Entra (ME-ID) provides several authorization approaches that can be combined with ASP.NET Core Identity:

* Groups
  * Security
  * Microsoft 365
  * Distribution
* Roles
  * ME-ID Administrator Roles
  * App Roles

The guidance in this article applies to the Blazor WebAssembly ME-ID deployment scenarios described in the following topics:

:::moniker range=">= aspnetcore-8.0"

* [Standalone with Microsoft Accounts](xref:blazor/security/webassembly/standalone-with-microsoft-accounts)
* [Standalone with ME-ID](xref:blazor/security/webassembly/standalone-with-microsoft-entra-id)

:::moniker-end

:::moniker range="< aspnetcore-8.0"

* [Standalone with Microsoft Accounts](xref:blazor/security/webassembly/standalone-with-microsoft-accounts)
* [Standalone with ME-ID](xref:blazor/security/webassembly/standalone-with-microsoft-entra-id)
* [Hosted with ME-ID](xref:blazor/security/webassembly/hosted-with-microsoft-entra-id)

:::moniker-end

The article's guidance provides instructions for client and server apps:

:::moniker range=">= aspnetcore-8.0"

* **CLIENT**: Standalone Blazor WebAssembly apps.
* **SERVER**: ASP.NET Core server API/web API apps. You can ignore the **SERVER** guidance throughout the article for a standalone Blazor WebAssembly app.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

* **CLIENT**: Standalone Blazor WebAssembly apps or the **:::no-loc text="Client":::** app of a hosted Blazor [solution](xref:blazor/tooling#visual-studio-solution-file-sln).
* **SERVER**: ASP.NET Core server API/web API apps or the **:::no-loc text="Server":::** app of a hosted Blazor solution. You can ignore the **SERVER** guidance throughout the article for a standalone Blazor WebAssembly app.

:::moniker-end

The examples in this article take advantage of new .NET/C# features. When using the examples with .NET 7 or earlier, minor modifications are required. However, the text and code examples that pertain to interacting with ME-ID and Microsoft Graph are the same for all versions of ASP.NET Core.

## Prerequisite

The guidance in this article implements the Microsoft Graph API per the *Graph SDK* guidance in <xref:blazor/security/webassembly/graph-api?pivots=graph-sdk>. Follow the *Graph SDK* implementation guidance to configure the app and test it to confirm that the app can obtain Graph API data for a test user account. Additionally, see the [Graph API article's security article cross-links](xref:blazor/security/webassembly/graph-api#security-guidance) to review Microsoft Graph security concepts.

When testing with the Graph SDK locally, we recommend using a new in-private/incognito browser session for each test to prevent lingering cookies from interfering with tests. For more information, see <xref:blazor/security/webassembly/standalone-with-microsoft-entra-id#troubleshoot>.

## Scopes

To permit [Microsoft Graph API](/graph/use-the-api) calls for user profile, role assignment, and group membership data:

* A **CLIENT** app is configured with the `User.Read` scope (`https://graph.microsoft.com/User.Read`) in the Azure portal.
* A **SERVER** app is configured with the `GroupMember.Read.All` scope (`https://graph.microsoft.com/GroupMember.Read.All`) in the Azure portal.

:::moniker range=">= aspnetcore-8.0"

The preceding scopes are required in addition to the scopes required in ME-ID deployment scenarios described by the topics listed earlier (*Standalone with Microsoft Accounts* or *Standalone with ME-ID*).

:::moniker-end

:::moniker range="< aspnetcore-8.0"

The preceding scopes are required in addition to the scopes required in ME-ID deployment scenarios described by the topics listed earlier (*Standalone with Microsoft Accounts*, *Standalone with ME-ID*, and *Hosted with ME-ID*).

:::moniker-end

For more information, see the [Microsoft Graph permissions reference](/graph/permissions-reference).

> [!NOTE]
> The words "permission" and "scope" are used interchangeably in the Azure portal and in various Microsoft and external documentation sets. This article uses the word "scope" throughout for the permissions assigned to an app in the Azure portal.

## Group Membership Claims attribute

In the app's manifest in the Azure portal for **CLIENT** and **SERVER** apps, set the [`groupMembershipClaims` attribute](/entra/identity-platform/reference-app-manifest#groupmembershipclaims-attribute) to `All`. A value of `All` results in ME-ID sending all of the security groups, distribution groups, and roles of the signed-in user in the [well-known IDs claim (`wids`)](/entra/identity-platform/access-tokens#payload-claims):

1. Open the app's Azure portal registration.
1. Select **Manage** > **Manifest** in the sidebar.
1. Find the `groupMembershipClaims` attribute.
1. Set the value to `All` (`"groupMembershipClaims": "All"`).
1. Select the **Save** button if you made changes.

## Custom user account

Assign users to ME-ID security groups and ME-ID Administrator Roles in the Azure portal.

The examples in this article:

* Assume that a user is assigned to the ME-ID *Billing Administrator* role in the Azure portal ME-ID tenant for authorization to access server API data.
* Use [authorization policies](xref:security/authorization/policies) to control access within the **CLIENT** and **SERVER** apps.

In the **CLIENT** app, extend <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.RemoteUserAccount> to include properties for:

* `Roles`: ME-ID App Roles array (covered in the [App Roles](#app-roles) section)
* `Wids`: ME-ID Administrator Roles in [well-known IDs claim (`wids`)](/entra/identity-platform/access-tokens#payload-claims)
* `Oid`: Immutable [object identifier claim (`oid`)](/entra/identity-platform/id-tokens#payload-claims) (uniquely identifies a user within and across tenants)

`CustomUserAccount.cs`:

```csharp
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace BlazorSample;

public class CustomUserAccount : RemoteUserAccount
{
    [JsonPropertyName("roles")]
    public List<string>? Roles { get; set; }

    [JsonPropertyName("wids")]
    public List<string>? Wids { get; set; }

    [JsonPropertyName("oid")]
    public string? Oid { get; set; }
}
```

Add a package reference to the **CLIENT** app for [`Microsoft.Graph`](https://www.nuget.org/packages/Microsoft.Graph).

[!INCLUDE[](~/includes/package-reference.md)]

Add the Graph SDK utility classes and configuration in the *Graph SDK* guidance of the <xref:blazor/security/webassembly/graph-api?pivots=graph-sdk> article. Specify the `User.Read` scope for the access token as the article shows in its example `wwwroot/appsettings.json` file.

Add the following custom user account factory to the **CLIENT** app. The custom user factory is used to establish:

* App Role claims (`appRole`) (covered in the [App Roles](#app-roles) section).
* ME-ID Administrator Role claims (`directoryRole`).
* Example user profile data claims for the user's mobile phone number (`mobilePhone`) and office location (`officeLocation`).
* ME-ID Group claims (`directoryGroup`).
* An <xref:Microsoft.Extensions.Logging.ILogger> (`logger`) for convenience in case you wish to log information or errors.

`CustomAccountFactory.cs`:

:::zone pivot="graph-sdk-5"

The following example assumes that the project's app settings file includes an entry for the base URL:

```json
{
  "MicrosoftGraph": {
    "BaseUrl": "https://graph.microsoft.com/{VERSION}",
    ...
  }
}
```

In the preceding example, the `{VERSION}` placeholder is the version of the MS Graph API (for example: `v1.0`).

```csharp
using System.Security.Claims;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;
using Microsoft.Graph;
using Microsoft.Kiota.Abstractions.Authentication;

namespace BlazorSample;

public class CustomAccountFactory(IAccessTokenProviderAccessor accessor,
        IServiceProvider serviceProvider,
        ILogger<CustomAccountFactory> logger,
        IConfiguration config)
    : AccountClaimsPrincipalFactory<CustomUserAccount>(accessor)
{
    private readonly ILogger<CustomAccountFactory> logger = logger;
    private readonly IServiceProvider serviceProvider = serviceProvider;
    private readonly string? baseUrl = 
        config.GetSection("MicrosoftGraph")["BaseUrl"];

    public override async ValueTask<ClaimsPrincipal> CreateUserAsync(
        CustomUserAccount account,
        RemoteAuthenticationUserOptions options)
    {
        var initialUser = await base.CreateUserAsync(account, options);

        if (initialUser.Identity is not null &&
            initialUser.Identity.IsAuthenticated)
        {
            var userIdentity = initialUser.Identity as ClaimsIdentity;

            if (userIdentity is not null && !string.IsNullOrEmpty(baseUrl))
            {
                account?.Roles?.ForEach((role) =>
                {
                    userIdentity.AddClaim(new Claim("appRole", role));
                });

                account?.Wids?.ForEach((wid) =>
                {
                    userIdentity.AddClaim(new Claim("directoryRole", wid));
                });

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

                    var requestMemberOf = client.Users[account?.Oid].MemberOf;
                    var memberships = await requestMemberOf.Request().GetAsync();

                    if (memberships is not null)
                    {
                        foreach (var entry in memberships)
                        {
                            if (entry.ODataType == "#microsoft.graph.group")
                            {
                                userIdentity.AddClaim(
                                    new Claim("directoryGroup", entry.Id));
                            }
                        }
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

:::zone-end

:::zone pivot="graph-sdk-4"

```csharp
using System.Security.Claims;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;
using Microsoft.Graph;

namespace BlazorSample;

public class CustomAccountFactory(IAccessTokenProviderAccessor accessor,
        IServiceProvider serviceProvider,
        ILogger<CustomAccountFactory> logger)
    : AccountClaimsPrincipalFactory<CustomUserAccount>(accessor)
{
    private readonly ILogger<CustomAccountFactory> logger = logger;
    private readonly IServiceProvider serviceProvider = serviceProvider;

    public override async ValueTask<ClaimsPrincipal> CreateUserAsync(
        CustomUserAccount account,
        RemoteAuthenticationUserOptions options)
    {
        var initialUser = await base.CreateUserAsync(account, options);

        if (initialUser.Identity is not null &&
            initialUser.Identity.IsAuthenticated)
        {
            var userIdentity = initialUser.Identity as ClaimsIdentity;

            if (userIdentity is not null)
            {
                account?.Roles?.ForEach((role) =>
                {
                    userIdentity.AddClaim(new Claim("appRole", role));
                });

                account?.Wids?.ForEach((wid) =>
                {
                    userIdentity.AddClaim(new Claim("directoryRole", wid));
                });

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

                    var requestMemberOf = client.Users[account?.Oid].MemberOf;
                    var memberships = await requestMemberOf.Request().GetAsync();

                    if (memberships is not null)
                    {
                        foreach (var entry in memberships)
                        {
                            if (entry.ODataType == "#microsoft.graph.group")
                            {
                                userIdentity.AddClaim(
                                    new Claim("directoryGroup", entry.Id));
                            }
                        }
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

:::zone-end

The preceding code doesn't include transitive memberships. If the app requires direct and transitive group membership claims, replace the `MemberOf` property (`IUserMemberOfCollectionWithReferencesRequestBuilder`) with `TransitiveMemberOf` (`IUserTransitiveMemberOfCollectionWithReferencesRequestBuilder`).

The preceding code ignores group membership claims (`groups`) that are ME-ID Administrator Roles (`#microsoft.graph.directoryRole` type) because the GUID values returned by the Microsoft identity platform are ME-ID Administrator Role **entity IDs** and not [**Role Template IDs**](/entra/identity/role-based-access-control/permissions-reference). Entity IDs aren't stable across tenants in Microsoft identity platform and shouldn't be used to create authorization policies for users in apps. Always use **Role Template IDs** for ME-ID Administrator Roles **provided by `wids` claims**.

In the **CLIENT** app, configure the MSAL authentication to use the custom user account factory.

Confirm that the `Program` file uses the <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication?displayProperty=fullName> namespace:

```csharp
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
```

Update the <xref:Microsoft.Extensions.DependencyInjection.MsalWebAssemblyServiceCollectionExtensions.AddMsalAuthentication%2A> call to the following. Note that the Blazor framework's <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.RemoteUserAccount> is replaced by the app's `CustomUserAccount` for the MSAL authentication and account claims principal factory:

```csharp
builder.Services.AddMsalAuthentication<RemoteAuthenticationState,
    CustomUserAccount>(options =>
    {
        builder.Configuration.Bind("AzureAd",
            options.ProviderOptions.Authentication);
    })
    .AddAccountClaimsPrincipalFactory<RemoteAuthenticationState, CustomUserAccount,
        CustomAccountFactory>();
```

Confirm the presence of the *Graph SDK* code described by the <xref:blazor/security/webassembly/graph-api?pivots=graph-sdk> article and that the `wwwroot/appsettings.json` configuration is correct per the *Graph SDK* guidance:

```csharp
var baseUrl = string.Join("/", 
    builder.Configuration.GetSection("MicrosoftGraph")["BaseUrl"], 
    builder.Configuration.GetSection("MicrosoftGraph")["Version"]);
var scopes = builder.Configuration.GetSection("MicrosoftGraph:Scopes")
    .Get<List<string>>();

builder.Services.AddGraphClient(baseUrl, scopes);
```

`wwwroot/appsettings.json`:

```json
{
  "MicrosoftGraph": {
    "BaseUrl": "https://graph.microsoft.com",
    "Version: "v1.0",
    "Scopes": [
      "user.read"
    ]
  }
}
```

## Authorization configuration

In the **CLIENT** app, create a [policy](xref:security/authorization/policies) for each [App Role](#app-roles), ME-ID Administrator Role, or security group in the `Program` file. The following example creates a policy for the ME-ID *Billing Administrator* role:

```csharp
builder.Services.AddAuthorizationCore(options =>
{
    options.AddPolicy("BillingAdministrator", policy => 
        policy.RequireClaim("directoryRole", 
            "b0f54661-2d74-4c50-afa3-1ec803f12efe"));
});
```

For the complete list of IDs for ME-ID Administrator Roles, see [Role template IDs](/entra/identity/role-based-access-control/permissions-reference) in the Entra documentation. For more information on authorization policies, see <xref:security/authorization/policies>.

In the following examples, the **CLIENT** app uses the preceding policy to authorize the user.

The [`AuthorizeView` component](xref:blazor/security/index#authorizeview-component) works with the policy:

```razor
<AuthorizeView Policy="BillingAdministrator">
    <Authorized>
        <p>
            The user is in the 'Billing Administrator' ME-ID Administrator Role
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

Access to an entire component can be based on the policy using an [`[Authorize]` attribute directive](xref:blazor/security/index#authorize-attribute) (<xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute>):

```razor
@page "/"
@using Microsoft.AspNetCore.Authorization
@attribute [Authorize(Policy = "BillingAdministrator")]
```

If the user isn't authorized, they're redirected to the ME-ID sign-in page.

A policy check can also be [performed in code with procedural logic](xref:blazor/security/index#procedural-logic).

`CheckPolicy.razor`:

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

    private async Task CheckPolicy()
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

## Authorize server API/web API access

A **SERVER** API app can authorize users to access secure API endpoints with [authorization policies](xref:security/authorization/policies) for security groups, ME-ID Administrator Roles, and App Roles when an access token contains `groups`, `wids`, and `role` claims. The following example creates a policy for the ME-ID *Billing Administrator* role in the `Program` file using the `wids` (well-known IDs/Role Template IDs) claims:

```csharp
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("BillingAdministrator", policy => 
        policy.RequireClaim("wids", "b0f54661-2d74-4c50-afa3-1ec803f12efe"));
});
```

For the complete list of IDs for ME-ID Administrator Roles, see [Role template IDs](/entra/identity/role-based-access-control/permissions-reference) in the Azure documentation. For more information on authorization policies, see <xref:security/authorization/policies>.

Access to a controller in the **SERVER** app can be based on using an [`[Authorize]` attribute](xref:security/authorization/simple) with the name of the policy (API documentation: <xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute>).

The following example limits access to billing data from the `BillingDataController` to Azure Billing Administrators with a policy name of `BillingAdministrator`:

```csharp
using Microsoft.AspNetCore.Authorization;
```

```csharp
[Authorize(Policy = "BillingAdministrator")]
[ApiController]
[Route("[controller]")]
public class BillingDataController : ControllerBase
{
    ...
}
```

For more information, see <xref:security/authorization/policies>.

## App Roles

To configure the app in the Azure portal to provide App Roles membership claims, see [Add app roles to your application and receive them in the token](/entra/identity-platform/howto-add-app-roles-in-apps) in the Entra documentation.

The following example assumes that the **CLIENT** and **SERVER** apps are configured with two roles, and the roles are assigned to a test user:

* `Admin`
* `Developer`

:::moniker range=">= aspnetcore-8.0"

> [!NOTE]
> When developing a client-server pair of standalone apps (a standalone Blazor WebAssembly app and an ASP.NET Core server API/web API app), the `appRoles` manifest property of both the client and the server Azure portal app registrations must include the same configured roles. After establishing the roles in the client app's manifest, copy them in their entirety to the server app's manifest. If you don't mirror the manifest `appRoles` between the client and server app registrations, role claims aren't established for authenticated users of the server API/web API, even if their access token has the correct entries in the `role` claims.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

> [!NOTE]
> When developing a hosted Blazor WebAssembly app or a client-server pair of standalone apps (a standalone Blazor WebAssembly app and an ASP.NET Core server API/web API app), the `appRoles` manifest property of both the client and the server Azure portal app registrations must include the same configured roles. After establishing the roles in the client app's manifest, copy them in their entirety to the server app's manifest. If you don't mirror the manifest `appRoles` between the client and server app registrations, role claims aren't established for authenticated users of the server API/web API, even if their access token has the correct entries in the `role` claims.

:::moniker-end

Although you can't assign roles to groups without an Microsoft Entra ID Premium account, you can assign roles to users and receive a `role` claim for users with a standard Azure account. The guidance in this section doesn't require an ME-ID Premium account.

If you have a Premium tier Azure account, **Manage** > **App roles** appears in the Azure portal app registration sidebar. Follow the guidance in [Add app roles to your application and receive them in the token](/entra/identity-platform/howto-add-app-roles-in-apps) to configure the app's roles.

If you don't have a Premium tier Azure account, edit the app's manifest in the Azure portal. Follow the guidance in [Application roles: Implementation](/azure/architecture/guide/multitenant/considerations/identity#implementation) to establish the app's roles manually in the `appRoles` entry of the manifest file. Save the changes to the file.

The following is an example `appRoles` entry that creates `Admin` and `Developer` roles. These example roles are used later in this section's example at the component level to implement access restrictions:

```json
"appRoles": [
  {
    "allowedMemberTypes": [
      "User"
    ],
    "description": "Administrators manage developers.",
    "displayName": "Admin",
    "id": "584e483a-7101-404b-9bb1-83bf9463e335",
    "isEnabled": true,
    "lang": null,
    "origin": "Application",
    "value": "Admin"
  },
  {
    "allowedMemberTypes": [
      "User"
    ],
    "description": "Developers write code.",
    "displayName": "Developer",
    "id": "82770d35-2a93-4182-b3f5-3d7bfe9dfe46",
    "isEnabled": true,
    "lang": null,
    "origin": "Application",
    "value": "Developer"
  }
],
```

> [!NOTE]
> You can generate GUIDs with an [online GUID generator program (Google search result for "guid generator")](https://www.google.com/search?q=guid+generator). 

To assign a role to a user (or group if you have a Premium tier Azure account):

1. Navigate to **Enterprise applications** in the ME-ID area of the Azure portal.
1. Select the app. Select **Manage** > **Users and groups** from the sidebar.
1. Select the checkbox for one or more user accounts.
1. From the menu above the list of users, select **Edit assignment**.
1. For the **Select a role** entry, select **None selected**.
1. Choose a role from the list and use the **Select** button to select it.
1. Use the **Assign** button at the bottom of the screen to assign the role.

Multiple roles are assigned in the Azure portal by ***re-adding a user*** for each additional role assignment. Use the **Add user/group** button at the top of the list of users to re-add a user. Use the preceding steps to assign another role to the user. You can repeat this process as many times as needed to add additional roles to a user (or group).

The `CustomAccountFactory` shown in the [Custom user account](#custom-user-account) section is set up to act on a `role` claim with a JSON array value. Add and register the `CustomAccountFactory` in the **CLIENT** app as shown in the [Custom user account](#custom-user-account) section. There's no need to provide code to remove the original `role` claim because it's automatically removed by the framework.

In the `Program` file of a **CLIENT** app, specify the claim named "`appRole`" as the role claim for <xref:System.Security.Claims.ClaimsPrincipal.IsInRole%2A?displayProperty=nameWithType> checks:

```csharp
builder.Services.AddMsalAuthentication(options =>
{
    ...

    options.UserOptions.RoleClaim = "appRole";
});
```

> [!NOTE]
> If you prefer to use the `directoryRoles` claim (ADD Administrator Roles), assign "`directoryRoles`" to the <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.RemoteAuthenticationUserOptions.RoleClaim?displayProperty=nameWithType>.

In the `Program` file of a **SERVER** app, specify the claim named "`http://schemas.microsoft.com/ws/2008/06/identity/claims/role`" as the role claim for <xref:System.Security.Claims.ClaimsPrincipal.IsInRole%2A?displayProperty=nameWithType> checks:

```csharp
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(options =>
    {
        Configuration.Bind("AzureAd", options);
        options.TokenValidationParameters.RoleClaimType = 
            "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";
    },
    options => { Configuration.Bind("AzureAd", options); });
```

[!INCLUDE[](~/blazor/includes/default-scheme.md)]

> [!NOTE]
> If you prefer to use the `wids` claim (ADD Administrator Roles), assign "`wids`" to the <xref:Microsoft.IdentityModel.Tokens.TokenValidationParameters.RoleClaimType?displayProperty=nameWithType>.

After you've completed the preceding steps to create and assign roles to users (or groups if you have a Premium tier Azure account) and implemented the `CustomAccountFactory` with the Graph SDK, as explained earlier in this article and in <xref:blazor/security/webassembly/graph-api?pivots=graph-sdk>, you should see an `appRole` claim for each assigned role that a signed-in user is assigned (or roles assigned to groups that they are members of). Run the app with a test user to confirm the claim(s) are present as expected. When testing with the Graph SDK locally, we recommend using a new in-private/incognito browser session for each test to prevent lingering cookies from interfering with tests. For more information, see <xref:blazor/security/webassembly/standalone-with-microsoft-entra-id#troubleshoot>.

Component authorization approaches are functional at this point. Any of the authorization mechanisms in components of the **CLIENT** app can use the `Admin` role to authorize the user:

* [`AuthorizeView` component](xref:blazor/security/index#authorizeview-component)

  ```razor
  <AuthorizeView Roles="Admin">
  ```

* [`[Authorize]` attribute directive](xref:blazor/security/index#authorize-attribute) (<xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute>)

  ```razor
  @attribute [Authorize(Roles = "Admin")]
  ```

* [Procedural logic](xref:blazor/security/index#procedural-logic)

  ```csharp
  var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
  var user = authState.User;

  if (user.IsInRole("Admin")) { ... }
  ```

Multiple role tests are supported:

* Require that the user be in **either** the `Admin` **or** `Developer` role with the `AuthorizeView` component:

  ```razor
  <AuthorizeView Roles="Admin, Developer">
      ...
  </AuthorizeView>
  ```

* Require that the user be in **both** the `Admin` **and** `Developer` roles with the `AuthorizeView` component:

  ```razor
  <AuthorizeView Roles="Admin">
      <AuthorizeView Roles="Developer" Context="innerContext">
          ...
      </AuthorizeView>
  </AuthorizeView>
  ```

  For more information on the `Context` for the inner <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView>, see <xref:blazor/security/index#role-based-and-policy-based-authorization>.

* Require that the user be in **either** the `Admin` **or** `Developer` role with the `[Authorize]` attribute:

  ```razor
  @attribute [Authorize(Roles = "Admin, Developer")]
  ```

* Require that the user be in **both** the `Admin` **and** `Developer` roles with the `[Authorize]` attribute:

  ```razor
  @attribute [Authorize(Roles = "Admin")]
  @attribute [Authorize(Roles = "Developer")]
  ```

* Require that the user be in **either** the `Admin` **or** `Developer` role with procedural code:

  ```razor
  @code {
      private async Task DoSomething()
      {
          var authState = await AuthenticationStateProvider
              .GetAuthenticationStateAsync();
          var user = authState.User;

          if (user.IsInRole("Admin") || user.IsInRole("Developer"))
          {
              ...
          }
          else
          {
              ...
          }
      }
  }
  ```

* Require that the user be in **both** the `Admin` **and** `Developer` roles with procedural code by changing the [conditional OR (`||`)](/dotnet/csharp/language-reference/operators/boolean-logical-operators) to a [conditional AND (`&&`)](/dotnet/csharp/language-reference/operators/boolean-logical-operators) in the preceding example:

  ```csharp
  if (user.IsInRole("Admin") && user.IsInRole("Developer"))
  ```

Any of the authorization mechanisms in controllers of the **SERVER** app can use the `Admin` role to authorize the user:

* [`[Authorize]` attribute directive](xref:blazor/security/index#authorize-attribute) (<xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute>)

  ```csharp
  [Authorize(Roles = "Admin")]
  ```

* [Procedural logic](xref:blazor/security/index#procedural-logic)

  ```csharp
  if (User.IsInRole("Admin")) { ... }
  ```

Multiple role tests are supported:

* Require that the user be in **either** the `Admin` **or** `Developer` role with the `[Authorize]` attribute:

  ```csharp
  [Authorize(Roles = "Admin, Developer")]
  ```

* Require that the user be in **both** the `Admin` **and** `Developer` roles with the `[Authorize]` attribute:

  ```csharp
  [Authorize(Roles = "Admin")]
  [Authorize(Roles = "Developer")]
  ```

* Require that the user be in **either** the `Admin` **or** `Developer` role with procedural code:

  ```csharp
  static readonly string[] scopeRequiredByApi = new string[] { "API.Access" };

  ...

  [HttpGet]
  public IEnumerable<ReturnType> Get()
  {
      HttpContext.VerifyUserHasAnyAcceptedScope(scopeRequiredByApi);

      if (User.IsInRole("Admin") || User.IsInRole("Developer"))
      {
          ...
      }
      else
      {
          ...
      }

      return ...
  }
  ```

* Require that the user be in **both** the `Admin` **and** `Developer` roles with procedural code by changing the [conditional OR (`||`)](/dotnet/csharp/language-reference/operators/boolean-logical-operators) to a [conditional AND (`&&`)](/dotnet/csharp/language-reference/operators/boolean-logical-operators) in the preceding example:

  ```csharp
  if (User.IsInRole("Admin") && User.IsInRole("Developer"))
  ```

Because .NET string comparisons are case-sensitive by default, matching role names is also case-sensitive. For example, `Admin` (uppercase `A`) is not treated as the same role as `admin` (lowercase `a`).

Pascal case is typically used for role names (for example, `BillingAdministrator`), but the use of Pascal case isn't a strict requirement. Different casing schemes, such as camel case, kebab case, and snake case, are permitted. Using spaces in role names is also unusual but permitted. For example, `billing administrator` is an unusual role name format in .NET apps but valid.

## Additional resources

* [Role template IDs (Entra documentation)](/entra/identity/role-based-access-control/permissions-reference)
* [`groupMembershipClaims` attribute (Entra documentation)](/entra/identity-platform/reference-app-manifest#groupmembershipclaims-attribute)
* [Add app roles to your application and receive them in the token (Entra documentation)](/entra/identity-platform/howto-add-app-roles-in-apps)
* [Application roles (Azure documentation)](/azure/architecture/guide/multitenant/considerations/identity)
* <xref:security/authorization/claims>
* <xref:security/authorization/roles>
* <xref:blazor/security/index>
