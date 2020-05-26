---
title: ASP.NET Core Blazor WebAssembly with Azure Active Directory groups and roles
author: guardrex
description: Learn how to configure Blazor WebAssembly to use Azure Active Directory groups and roles.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 05/19/2020
no-loc: [Blazor, "Identity", "Let's Encrypt", Razor, SignalR]
uid: security/blazor/webassembly/aad-groups-roles
---
# Azure AD Groups, Administrative Roles, and user-defined roles

By [Luke Latham](https://github.com/guardrex) and [Javier Calvarro Nelson](https://github.com/javiercn)

Azure Active Directory (AAD) provides several authorization approaches that can be combined with ASP.NET Core Identity:

* User-defined groups
  * Security
  * O365
  * Distribution
* Roles
  * Built-in Administrative Roles
  * User-defined roles

The guidance in this article applies to the Blazor WebAssembly AAD deployment scenarios described in the following topics:

* [Standalone with Microsoft Accounts](xref:security/blazor/webassembly/standalone-with-microsoft-accounts)
* [Standalone with AAD](xref:security/blazor/webassembly/standalone-with-azure-active-directory)
* [Hosted with AAD](xref:security/blazor/webassembly/hosted-with-azure-active-directory)

### User-defined groups and built-in Administrative Roles

To configure the app in the Azure portal to provide a `groups` membership claim, see the following Azure articles. Assign users to user-defined AAD groups and built-in Administrative Roles.

* [Roles using Azure AD security groups](/azure/architecture/multitenant-identity/app-roles#roles-using-azure-ad-security-groups)
* [groupMembershipClaims attribute](/azure/active-directory/develop/reference-app-manifest#groupmembershipclaims-attribute)

The following examples assume that a user is assigned to the AAD built-in *Billing Administrator* role.

The single `groups` claim sent by AAD presents the user's groups and roles as Object IDs (GUIDs) in a JSON array. The app must convert the JSON array of groups and roles into individual `group` claims that the app can build [policies](xref:security/authorization/policies) against.

Extend <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.RemoteUserAccount> to include array properties for groups and roles.

*CustomUserAccount.cs*:

```csharp
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

public class CustomUserAccount : RemoteUserAccount
{
    [JsonPropertyName("groups")]
    public string[] Groups { get; set; }

    [JsonPropertyName("roles")]
    public string[] Roles { get; set; }
}
```

Create a custom user factory in the standalone app or Client app of a Hosted solution. The following factory is also configured to handle `roles` claim arrays, which are covered in the [User-defined roles](#user-defined-roles) section:

```csharp
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;

public class CustomUserFactory
    : AccountClaimsPrincipalFactory<CustomUserAccount>
{
    public CustomUserFactory(NavigationManager navigationManager,
        IAccessTokenProviderAccessor accessor)
        : base(accessor)
    {
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

            foreach (var group in account.Groups)
            {
                userIdentity.AddClaim(new Claim("group", group));
            }
        }

        return initialUser;
    }
}
```

There's no need to provide code to remove the original `groups` claim because it's automatically removed by the framework.

Register the factory in `Program.Main` (*Program.cs*) of the standalone app or Client app of a Hosted solution:

```csharp
builder.Services.AddMsalAuthentication<RemoteAuthenticationState, 
    CustomUserAccount>(options =>
{
    builder.Configuration.Bind("AzureAd", 
        options.ProviderOptions.Authentication);
    options.ProviderOptions.DefaultAccessTokenScopes.Add("...");
    
    ...
})
.AddAccountClaimsPrincipalFactory<RemoteAuthenticationState, CustomUserAccount, 
    CustomUserFactory>();
```

Create a [policy](xref:security/authorization/policies) for each group or role in `Program.Main`. The following example creates a policy for the AAD built-in *Billing Administrator* role:

```csharp
builder.Services.AddAuthorizationCore(options =>
{
    options.AddPolicy("BillingAdministrator", policy => 
        policy.RequireClaim("group", "69ff516a-b57d-4697-a429-9de4af7b5609"));
});
```

For the complete list of AAD role Object IDs, see the [AAD Adminstrative Role Group IDs](#aad-adminstrative-role-group-ids) section.

In the following examples, the app uses the preceding policy to authorize the user.

The [AuthorizeView component](xref:security/blazor/index#authorizeview-component) works with the policy:

```razor
<AuthorizeView Policy="BillingAdministrator">
    <Authorized>
        <p>
            The user is in the 'Billing Administrator' AAD Administrative Role
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

Access to an entire component can be based on the policy using [`[Authorize]`] attribute directive](xref:security/blazor/index#authorize-attribute) (<xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute>):

```razor
@page "/"
@using Microsoft.AspNetCore.Authorization
@attribute [Authorize(Policy = "BillingAdministrator")]
```

If the user isn't logged in, they're redirected to the AAD sign-in page and then back to the component after they sign in.

A policy check can also be [performed in code with procedural logic](xref:security/blazor/index#procedural-logic):

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

### User-defined roles

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

The `CustomUserFactory` shown in the [User-defined groups and AAD built-in Administrative Roles](#user-defined-groups-and-built-in-administrative-roles) section is set up to act on a `roles` claim with a JSON array value. Add and register the `CustomUserFactory` in the standalone app or Client app of a Hosted solution as shown in the [User-defined groups and AAD built-in Administrative Roles](#user-defined-groups-and-built-in-administrative-roles) section. There's no need to provide code to remove the original `roles` claim because it's automatically removed by the framework.

In `Program.Main` of the standalone app or Client app of a Hosted solution, specify the claim named "`role`" as the role claim:

```csharp
builder.Services.AddMsalAuthentication(options =>
{
    ...

    options.UserOptions.RoleClaim = "role";
});
```

Component authorization approaches are functional at this point. Any of the authorization mechanisms in components can use the `admin` role to authorize the user:

* [AuthorizeView component](xref:security/blazor/index#authorizeview-component) (Example: `<AuthorizeView Roles="admin">`)
* [`[Authorize]`] attribute directive](xref:security/blazor/index#authorize-attribute) (<xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute>) (Example: `@attribute [Authorize(Roles = "admin")]`)
* [Procedural logic](xref:security/blazor/index#procedural-logic) (Example: `if (user.IsInRole("admin")) { ... }`)

  Multiple role tests are supported:

  ```csharp
  if (user.IsInRole("admin") && user.IsInRole("developer"))
  {
      ...
  }
  ```

## AAD Adminstrative Role Group IDs

The Object IDs presented in the following table are used to create [policies](xref:security/authorization/policies) for `group` claims. Policies permit an app to authorize users for various activities in an app. For more information, see the [User-defined groups and AAD built-in Administrative Roles](#user-defined-groups-and-built-in-administrative-roles) section.

AAD Administrative Role | Object ID
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
* <xref:security/blazor/index>
