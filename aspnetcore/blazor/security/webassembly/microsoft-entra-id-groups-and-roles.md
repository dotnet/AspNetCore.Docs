---
title: ASP.NET Core Blazor WebAssembly with Microsoft Entra ID groups and roles
author: guardrex
description: Learn how to configure Blazor WebAssembly to use Microsoft Entra ID groups and roles.
monikerRange: '>= aspnetcore-8.0'
ms.author: riande
ms.custom: "devx-track-csharp, mvc"
ms.date: 08/20/2024
uid: blazor/security/webassembly/meid-groups-roles
---
# Microsoft Entra (ME-ID) groups, Administrator Roles, and App Roles

<!-- UPDATE 9.0 Activate at 9.0 GA.

[!INCLUDE[](~/includes/not-latest-version.md)]

-->

This article explains how to configure Blazor WebAssembly to use Microsoft Entra ID (ME-ID) groups and roles.

ME-ID provides several authorization approaches that can be combined with ASP.NET Core Identity:

* Groups
  * Security
  * Microsoft 365
  * Distribution
* Roles
  * ME-ID built-in Administrator Roles
  * App Roles

The guidance in this article applies to the Blazor WebAssembly ME-ID deployment scenarios described in the following articles:

* [Standalone with Microsoft Accounts](xref:blazor/security/webassembly/standalone-with-microsoft-accounts)
* [Standalone with ME-ID](xref:blazor/security/webassembly/standalone-with-microsoft-entra-id)

The examples in this article take advantage of new .NET/C# features. When using the examples with .NET 7 or earlier, minor modifications are required. However, the text and code examples that pertain to interacting with ME-ID and Microsoft Graph are the same for all versions of ASP.NET Core.

## Sample app

Access the sample app, named `BlazorWebAssemblyEntraGroupsAndRoles`, through the latest version folder from the repository's root with the following link. The sample is provided for .NET 8 or later. See the sample app's `README` file for steps on how to run the app.

The sample app includes a `UserClaims` component for displaying a user's claims. The `UserData` component displays the user's basic account properties.

[View or download sample code](https://github.com/dotnet/blazor-samples) ([how to download](xref:blazor/fundamentals/index#sample-apps))

## Prerequisite

The guidance in this article implements the Microsoft Graph API per the *Graph SDK* guidance in <xref:blazor/security/webassembly/graph-api?pivots=graph-sdk>. Follow the *Graph SDK* implementation guidance to configure the app and test it to confirm that the app can obtain Graph API data for a test user account. Additionally, see the [Graph API article's security article cross-links](xref:blazor/security/webassembly/graph-api#security-guidance) to review Microsoft Graph security concepts.

When testing with the Graph SDK locally, we recommend using a new in-private/incognito browser session for each test to prevent lingering cookies from interfering with tests. For more information, see <xref:blazor/security/webassembly/standalone-with-microsoft-entra-id#troubleshoot>.

## ME-ID app registration online tools

This article refers to the [Azure portal](/azure/azure-portal/azure-portal-overview) throughout when prompting you to configure the app's ME-ID app registration, but the [Microsoft Entra Admin Center](/entra/fundamentals/entra-admin-center) is also a viable option for managing ME-ID app registrations. Either interface can be used, but the guidance in this article specifically covers gestures for the Azure portal.

## Scopes

> [!NOTE]
> The words "permission" and "scope" are used interchangeably in the Azure portal and in various Microsoft and external documentation sets. This article uses the word "scope" throughout for the permissions assigned to an app in the Azure portal.

To permit [Microsoft Graph API](/graph/use-the-api) calls for user profile, role assignment, and group membership data, the app is configured with the ***delegated*** `User.Read` scope (`https://graph.microsoft.com/User.Read`) in the Azure portal because access to read user data is determined by the scopes granted (delegated) to individual users. This scope is required in addition to the scopes required in ME-ID deployment scenarios described by the articles listed earlier (*Standalone with Microsoft Accounts* or *Standalone with ME-ID*).

Additional required scopes include:

* ***Delegated*** [`RoleManagement.Read.Directory`](/graph/permissions-reference#rolemanagementreaddirectory) scope (`https://graph.microsoft.com/RoleManagement.Read.Directory`): Allows the app to read the role-based access control (RBAC) settings for your company's directory, on behalf of the signed-in user. This includes reading directory role templates, directory roles, and memberships. Directory role memberships are used to create `directoryRole` claims in the app for ME-ID built-in Administrator Roles. Admin consent is required.
* ***Delegated*** [`AdministrativeUnit.Read.All`](/graph/permissions-reference#administrativeunitreadall) scope (`https://graph.microsoft.com/AdministrativeUnit.Read.All`): Allows the app to read administrative units and administrative unit membership on behalf of the signed-in user. These memberships are used to create `administrativeUnit` claims in the app. Admin consent is required.

For more information, see [Overview of permissions and consent in the Microsoft identity platform](/entra/identity-platform/permissions-consent-overview) and [Overview of Microsoft Graph permissions](/graph/permissions-overview).

## Custom user account

Assign users to ME-ID security groups and ME-ID Administrator Roles in the Azure portal.

The examples in this article:

* Assume that a user is assigned to the ME-ID *Billing Administrator* role in the Azure portal ME-ID tenant for authorization to access server API data.
* Use [authorization policies](xref:security/authorization/policies) to control access within the app.

Extend <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.RemoteUserAccount> to include properties for:

* `Roles`: ME-ID App Roles array (covered in the [App Roles](#app-roles) section)
* `Oid`: Immutable [object identifier claim (`oid`)](/entra/identity-platform/id-tokens#payload-claims) (uniquely identifies a user within and across tenants)

`CustomUserAccount.cs`:

:::code language="csharp" source="~/../blazor-samples/8.0/BlazorWebAssemblyEntraGroupsAndRoles/CustomUserAccount.cs":::

Add a package reference to app for [`Microsoft.Graph`](https://www.nuget.org/packages/Microsoft.Graph).

[!INCLUDE[](~/includes/package-reference.md)]

Add the Graph SDK utility classes and configuration in the *Graph SDK* guidance of the <xref:blazor/security/webassembly/graph-api?pivots=graph-sdk> article. Specify the `User.Read`, `RoleManagement.Read.Directory`, and `AdministrativeUnit.Read.All` scopes for the access token as the article shows in its example `wwwroot/appsettings.json` file.

Add the following custom user account factory to the app. The custom user factory is used to establish:

* App Role claims (`role`) (covered in the [App Roles](#app-roles) section).

* Example user profile data claims for the user's mobile phone number (`mobilePhone`) and office location (`officeLocation`).
* ME-ID Administrator Role claims (`directoryRole`).
* ME-ID Administrative Unit claims (`administrativeUnit`).
* ME-ID Group claims (`directoryGroup`).
* An <xref:Microsoft.Extensions.Logging.ILogger> (`logger`) for convenience in case you wish to log information or errors.

`CustomAccountFactory.cs`:

:::code language="csharp" source="~/../blazor-samples/8.0/BlazorWebAssemblyEntraGroupsAndRoles/CustomAccountFactory.cs":::

The preceding code:

* Doesn't include transitive memberships. If the app requires direct and transitive group membership claims, replace the `MemberOf` property (`IUserMemberOfCollectionWithReferencesRequestBuilder`) with `TransitiveMemberOf` (`IUserTransitiveMemberOfCollectionWithReferencesRequestBuilder`).
* Sets GUID values in `directoryRole` claims are ME-ID Administrator Role [*Template IDs*](/entra/identity/role-based-access-control/permissions-reference) (`Microsoft.Graph.Models.DirectoryRole.RoleTemplateId`). Template IDs are stable identifiers for creating user authorization policies in apps, which is covered later in this article. Do ***not*** use `entry.Id` for directory role claim values, as they aren't stable across tenants.

Next, configure the MSAL authentication to use the custom user account factory.

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
        options.UserOptions.RoleClaim = "role";
    })
    .AddAccountClaimsPrincipalFactory<RemoteAuthenticationState, CustomUserAccount,
        CustomAccountFactory>();
```

Confirm the presence of the *Graph SDK* code in the `Program` file described by the <xref:blazor/security/webassembly/graph-api?pivots=graph-sdk> article:

```csharp
var baseUrl = string.Join("/", 
    builder.Configuration.GetSection("MicrosoftGraph")["BaseUrl"], 
    builder.Configuration.GetSection("MicrosoftGraph")["Version"]);
var scopes = builder.Configuration.GetSection("MicrosoftGraph:Scopes")
    .Get<List<string>>();

builder.Services.AddGraphClient(baseUrl, scopes);
```

> [!IMPORTANT]
> Confirm in the app's registration in the Azure portal that the following permissions are granted:
>
> * `User.Read`
> * `RoleManagement.Read.Directory` (Requires admin consent)
> * `AdministrativeUnit.Read.All` (Requires admin consent)

Confirm that the `wwwroot/appsettings.json` configuration is correct per the *Graph SDK* guidance.

`wwwroot/appsettings.json`:

:::code language="json" source="~/../blazor-samples/8.0/BlazorWebAssemblyEntraGroupsAndRoles/wwwroot/appsettings.json":::

Provide values for the following placeholders from the app's ME-ID registration in the Azure portal:

* `{TENANT ID}`: The Directory (Tenant) Id GUID value.
* `{CLIENT ID}`: The Application (Client) Id GUID value.

## Authorization configuration

Create a [policy](xref:security/authorization/policies) for each [App Role](#app-roles) (by role name), ME-ID built-in Administrator Role (by Role Template Id/GUID), or security group (by Object Id/GUID) in the `Program` file. The following example creates a policy for the ME-ID built-in *Billing Administrator* role:

```csharp
builder.Services.AddAuthorizationCore(options =>
{
    options.AddPolicy("BillingAdministrator", policy => 
        policy.RequireClaim("directoryRole", 
            "b0f54661-2d74-4c50-afa3-1ec803f12efe"));
});
```

For the complete list of IDs (GUIDs) for ME-ID Administrator Roles, see [Role template IDs](/entra/identity/role-based-access-control/permissions-reference) in the ME-ID documentation. For an Azure security or O365 group ID (GUID), see the **Object Id** for the group in the Azure portal **Groups** pane of the app's registration. For more information on authorization policies, see <xref:security/authorization/policies>.

In the following examples, the app uses the preceding policy to authorize the user.

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

Using the preceding approaches, you can also create policy-based access for security groups, where the GUID used for the policy matches the 

## App Roles

To configure the app in the Azure portal to provide App Roles membership claims, see [Add app roles to your application and receive them in the token](/entra/identity-platform/howto-add-app-roles-in-apps) in the ME-ID documentation.

The following example assumes that the app is configured with two roles, and the roles are assigned to a test user:

* `Admin`
* `Developer`

Although you can't [assign roles to groups](/entra/identity/role-based-access-control/groups-concept) without an ME-ID Premium account, you can assign roles to users and receive role claims for users with a standard Azure account. The guidance in this section doesn't require an ME-ID Premium account.

Take either of the following approaches add app roles in ME-ID:

* When working with the ***default directory***, follow the guidance in [Add app roles to your application and receive them in the token](/entra/identity-platform/howto-add-app-roles-in-apps) to create ME-ID roles.

* If you ***aren't working with the default directory***, edit the app's manifest in the Azure portal to establish the app's roles manually in the `appRoles` entry of the manifest file. The following is an example `appRoles` entry that creates `Admin` and `Developer` roles. These example roles are used later at the component level to implement access restrictions:

  > [!IMPORTANT]
  > The following approach is only recommended for apps that aren't registered in the Azure account's default directory. For apps registered in the default directory, see the preceding bullet of this list.

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

1. Navigate to **Enterprise applications** in the ME-ID area of the [Azure portal](https://portal.azure.com/).
1. Select the app. Select **Manage** > **Users and groups** from the sidebar.
1. Select the checkbox for one or more user accounts.
1. From the menu above the list of users, select **Edit assignment**.
1. For the **Select a role** entry, select **None selected**.
1. Choose a role from the list and use the **Select** button to select it.
1. Use the **Assign** button at the bottom of the screen to assign the role.

Multiple roles are assigned in the Azure portal by ***re-adding a user*** for each additional role assignment. Use the **Add user/group** button at the top of the list of users to re-add a user. Use the preceding steps to assign another role to the user. You can repeat this process as many times as needed to add additional roles to a user (or group).

The `CustomAccountFactory` shown in the [Custom user account](#custom-user-account) section is set up to act on a `role` claim with a JSON array value. Add and register the `CustomAccountFactory` in the app as shown in the [Custom user account](#custom-user-account) section. There's no need to provide code to remove the original `role` claim because it's automatically removed by the framework.

In the `Program` file, add or confirm the claim named "`role`" as the role claim for <xref:System.Security.Claims.ClaimsPrincipal.IsInRole%2A?displayProperty=nameWithType> checks:

```csharp
builder.Services.AddMsalAuthentication(options =>
{
    ...

    options.UserOptions.RoleClaim = "role";
});
```

> [!NOTE]
> If you prefer to use the `directoryRoles` claim (ME-ID Administrator Roles), assign "`directoryRoles`" to the <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.RemoteAuthenticationUserOptions.RoleClaim?displayProperty=nameWithType>.

After you've completed the preceding steps to create and assign roles to users (or groups if you have a Premium tier Azure account) and implemented the `CustomAccountFactory` with the Graph SDK, as explained earlier in this article and in <xref:blazor/security/webassembly/graph-api?pivots=graph-sdk>, you should see an `role` claim for each assigned role that a signed-in user is assigned (or roles assigned to groups that they are members of). Run the app with a test user to confirm the claims are present as expected. When testing with the Graph SDK locally, we recommend using a new in-private/incognito browser session for each test to prevent lingering cookies from interfering with tests. For more information, see <xref:blazor/security/webassembly/standalone-with-microsoft-entra-id#troubleshoot>.

Component authorization approaches are functional at this point. Any of the authorization mechanisms in components of the app can use the `Admin` role to authorize the user:

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

* [Role template IDs (ME-ID documentation)](/entra/identity/role-based-access-control/permissions-reference)
* [`groupMembershipClaims` attribute (ME-ID documentation)](/entra/identity-platform/reference-app-manifest#groupmembershipclaims-attribute)
* [Add app roles to your application and receive them in the token (ME-ID documentation)](/entra/identity-platform/howto-add-app-roles-in-apps)
* [Application roles (Azure documentation)](/azure/architecture/guide/multitenant/considerations/identity)
* <xref:security/authorization/claims>
* <xref:security/authorization/roles>
* <xref:blazor/security/index>
