---
title: Role-based authorization in ASP.NET Core
ai-usage: ai-assisted
author: wadepickett
description: Learn how to restrict ASP.NET Core Blazor Razor component access with the AuthorizeView component and by passing roles to the Authorize attribute.
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.date: 04/07/2026
uid: security/authorization/roles
---
# Role-based authorization in ASP.NET Core

When a user's identity is created after authentication, the user may belong to one or more *roles*, reflecting various authorizations that the user has to access data and perform operations. For example, Tracy may belong to the "Administrator" and "User" roles with access to administrative web pages in the app, while Scott may only belong to the "User" role and not have access to administrative data or operations. How these roles are created and managed depends on the backing store of the authorization process. Roles are exposed to the developer through <xref:System.Security.Claims.ClaimsPrincipal.IsInRole%2A?displayProperty=nameWithType>. <xref:Microsoft.AspNetCore.Identity.IdentityBuilder.AddRoles%2A> must be called to add Role services when setting up the app's identity system.

While roles are claims, not all claims are roles. Depending on the identity issuer, a role may be a collection of users that may apply claims for group members, as well as an actual claim on an identity. However, claims are meant to be information about an individual user. Using roles to add claims to a user can confuse the boundary between the user and their individual claims. This confusion is why the single-page application (SPA) templates aren't designed around roles. In addition, for organizations migrating from an on-premises legacy system, the proliferation of roles over the years can mean a role claim may be too large to be contained within a token usable by a SPA. To secure SPAs, see <xref:security/authentication/identity/spa>.

This article uses Razor component examples and focuses on Blazor authorization scenarios. For additional Blazor guidance, see the [Additional resources](#additional-resources) section. For Razor Pages and MVC guidance, see the following resources:

* <xref:razor-pages/security/authorization/roles>
* <xref:mvc/security/authorization/roles>

:::moniker range="< aspnetcore-6.0"

Identity configuration changed with the release of .NET 6. Examples in this article demonstrate approaches that configure Identity services in the app's `Program` file. For .NET apps prior to the release of .NET 6 (and before Blazor Web Apps were released with .NET 8), services are configured in `Startup.ConfigureServices` of the `Startup.cs` file. The syntax for Identity configuration is shown in the companion [Razor Pages roles-based authorization article](xref:razor-pages/security/authorization/roles) and the [MVC roles-based authorization article](xref:mvc/security/authorization/roles). See the preceding resources and set the article version selector to the version of .NET that your app targets.

:::moniker-end

## Sample app

The Blazor Web App sample for this article is the [`BlazorWebAppAuthorization` sample app (`dotnet/AspNetCore.Docs.Samples` GitHub repository)](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/security/authorization/BlazorWebAppAuthorization) ([how to download](xref:index#how-to-download-a-sample)). The sample app uses seeded accounts with preconfigured roles to demonstrate most of the examples in this article. For more information, see the sample's README file (`README.md`).

> [!CAUTION]
> This sample app uses an in-memory database to store user information, which isn't suitable for production scenarios. The sample app is intended for demonstration purposes only and shouldn't be used as a starting point for production apps.

## Add Role services to Identity

:::moniker range=">= aspnetcore-6.0"

Register role-based authorization services in the `Program` file by calling <xref:Microsoft.AspNetCore.Identity.IdentityBuilder.AddRoles%2A> with the role type in the app's Identity configuration. The role type in the following example is `IdentityRole`:

```csharp
builder.Services.AddDefaultIdentity<IdentityUser>( ... )
    .AddRoles<IdentityRole>()
    ...
```

The preceding code requires the [`Microsoft.AspNetCore.Identity.UI` NuGet package](https://www.nuget.org/packages/Microsoft.AspNetCore.Identity.UI) and a `using` directive for <xref:Microsoft.AspNetCore.Identity?displayProperty=fullName>.

In cases where the app takes granular control to build Identity manually, call <xref:Microsoft.AspNetCore.Identity.IdentityBuilder.AddRoles%2A> on <xref:Microsoft.Extensions.DependencyInjection.IdentityServiceCollectionExtensions.AddIdentityCore%2A>:

```csharp
builder.Services.AddIdentityCore<IdentityUser>()
    .AddRoles<IdentityRole>()
    ...
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

Register role-based authorization services in `Startup.ConfigureServices` (`Startup.cs`) by calling <xref:Microsoft.AspNetCore.Identity.IdentityBuilder.AddRoles%2A> with the role type in the app's Identity configuration. The role type in the following example is `IdentityRole`:

```csharp
services.AddDefaultIdentity<IdentityUser>()
    .AddRoles<IdentityRole>()
    ...
```

The preceding code requires the [`Microsoft.AspNetCore.Identity.UI` NuGet package](https://www.nuget.org/packages/Microsoft.AspNetCore.Identity.UI) and a `using` directive for <xref:Microsoft.AspNetCore.Identity?displayProperty=fullName>.

In cases where the app takes granular control to build Identity manually, call <xref:Microsoft.AspNetCore.Identity.IdentityBuilder.AddRoles%2A> on <xref:Microsoft.Extensions.DependencyInjection.IdentityServiceCollectionExtensions.AddIdentityCore%2A>:

```csharp
services.AddIdentityCore<IdentityUser>()
    .AddRoles<IdentityRole>()
    ...
```

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

In Blazor Web Apps (.NET 8 or later), calling <xref:Microsoft.AspNetCore.Builder.AuthorizationAppBuilderExtensions.UseAuthorization%2A> in the `Program` file isn't required.

In Blazor Server apps, call <xref:Microsoft.AspNetCore.Builder.AuthorizationAppBuilderExtensions.UseAuthorization%2A> in the `Program` file after the line that calls <xref:Microsoft.AspNetCore.Builder.AuthAppBuilderExtensions.UseAuthentication%2A> (if present):

```csharp
app.UseAuthentication(); // Only present if not called internally
app.UseAuthorization();
```

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

In Blazor Server apps (not Blazor Web Apps), call <xref:Microsoft.AspNetCore.Builder.AuthorizationAppBuilderExtensions.UseAuthorization%2A> in the `Program` file after the line that calls <xref:Microsoft.AspNetCore.Builder.AuthAppBuilderExtensions.UseAuthentication%2A> (if present):

```csharp
app.UseAuthentication(); // Only present if not called internally
app.UseAuthorization();
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

In Blazor Server apps (not Blazor Web Apps), call <xref:Microsoft.AspNetCore.Builder.AuthorizationAppBuilderExtensions.UseAuthorization%2A> in `Startup.Configure` (`Startup.cs`) after the line that calls <xref:Microsoft.AspNetCore.Builder.AuthAppBuilderExtensions.UseAuthentication%2A> (if present):

```csharp
app.UseAuthentication(); // Only present if not called internally
app.UseAuthorization();
```

:::moniker-end

:::moniker range=">= aspnetcore-5.0"

Blazor WebAssembly apps call <xref:Microsoft.Extensions.DependencyInjection.AuthorizationServiceCollectionExtensions.AddAuthorizationCore%2A> in the `Program` file to add authorization services:

```csharp
builder.Services.AddAuthorizationCore();
```

:::moniker-end

## Role-based authorization checks

Role-based authorization checks:

* Are declarative and specify roles that the current user must be a member of to access the requested resource.
* Are applied to Razor components (examples in this article), [Razor Pages](xref:razor-pages/security/authorization/roles), or [MVC controllers or actions within a controller](xref:mvc/security/authorization/roles).

The <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> component ([`AuthorizeView` component in Blazor documentation](xref:blazor/security/index#authorizeview-component)) supports *role-based* authorization. This section covers basic concepts. For complete coverage, see <xref:blazor/security/index>.

For role-based authorization of content in Razor components, use the <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView.Roles?displayProperty=nameWithType> parameter.

In the following example:

* The user must have a role claim for either the `Admin` or `SuperUser` roles to see the content of the first <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> component.
* To require both `Admin` and `SuperUser` role claims, the second example nests <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> components.

`Pages/RoleChecksWithAuthorizeView.razor`:

```razor
@page "/role-checks-with-authorizeview"

<h3>Role Checks with AuthorizeView</h3>

<AuthorizeView Roles="Admin, SuperUser">
    <p>User: @context.User.Identity?.Name</p>
    <p>You have an 'Admin' or 'SuperUser' role claim.</p>
</AuthorizeView>

<AuthorizeView Roles="Admin">
    <p>User: @context.User.Identity?.Name</p>
    <p>You have the 'Admin' role claim.</p>
    <AuthorizeView Roles="SuperUser" Context="innerContext">
        <p>User: @innerContext.User.Identity?.Name</p>
        <p>You have both 'Admin' and 'SuperUser' role claims.</p>
    </AuthorizeView>
</AuthorizeView>
```

The preceding code establishes a `Context` for the inner <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> component to prevent an <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationState> context collision. The <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationState> context is accessed in the outer <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> with the standard approach for accessing the context (`@context.User`). The context is accessed in the inner <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> with the named `innerContext` context (`@innerContext.User`).

The [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) supports role-based authorization for entire Razor components. Use the <xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute.Roles?displayProperty=nameWithType> parameter. The following code limits component access to users who are a member of the `Admin` role.

`Pages/RequireAdminRoleWithAuthorizeAttribute.razor`:

```razor
@page "/require-admin-role-with-authorize-attribute"
@using Microsoft.AspNetCore.Authorization
@attribute [Authorize(Roles = "Admin")]

<h1>Require 'Admin' role with [Authorize] attribute</h1>

<p>You can only see this if you're in the 'Admin' role.</p>
```

Multiple roles can be specified as a comma separated list. In the following example, access is limited to users who are members of the `Admin` role *or* the `SuperUser` role.

`Pages/RequireAdminOrSuperUserRoleWithAuthorizeAttribute.razor`:

```razor
@page "/require-admin-or-superuser-role-with-authorize-attribute"
@using Microsoft.AspNetCore.Authorization
@attribute [Authorize(Roles = "Admin, SuperUser")]

<h1>Require 'Admin' or 'SuperUser' role with [Authorize] attribute</h1>

<p>
    You can only see this if you're in the 'Admin' role or the 'SuperUser' role.
</p>
```

When multiple attributes are applied, the user must be a member of *all* of the roles specified. The following example requires *both* `Admin` *and* `SuperUser` roles.

`Pages/RequireAdminAndSuperUserRolesWithAuthorizeAttributes.razor`:

```razor
@page "/require-admin-and-superuser-roles-with-authorize-attributes"
@using Microsoft.AspNetCore.Authorization
@attribute [Authorize(Roles = "Admin")]
@attribute [Authorize(Roles = "SuperUser")]

<h1>Require 'Admin' and 'SuperUser' roles with [Authorize] attributes</h1>

<p>
    You can only see this if you're in both the 'Admin' role 
    and the 'SuperUser' role.
</p>
```

Role matching is typically case-sensitive because role names are stored and compared using .NET string comparisons. For example, `Admin` (uppercase `A`) isn't treated as the same role as `admin` (lowercase `a`). For more information, see <xref:security/authorization/claims#claim-case-sensitivity>.

## Policy-based authorization checks

Role requirements can be expressed using policy syntax, where the app registers a policy at startup as part of the Authorization service configuration.

In the following example:

* The `RequireAdminRole` policy specifies that users must be in the `Admin` role.
* The `RequireSuperUserRole` policy specifies that users must be in the `SuperUser` role.

:::moniker range=">= aspnetcore-7.0"

```csharp
builder.Services.AddAuthorizationBuilder()
    .AddPolicy("RequireAdminRole",
         policy => policy.RequireRole("Admin"))
    .AddPolicy("RequireSuperUserRole",
         policy => policy.RequireRole("SuperUser"));
```

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

```csharp
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdminRole",
        policy => policy.RequireRole("Admin"));
    options.AddPolicy("RequireSuperUserRole",
        policy => policy.RequireRole("SuperUser"));
});
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

```csharp
services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdminRole",
        policy => policy.RequireRole("Admin"));
    options.AddPolicy("RequireSuperUserRole",
        policy => policy.RequireRole("SuperUser"));
});
```

:::moniker-end

For policy-based authorization using an <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> component, use the <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView.Policy?displayProperty=nameWithType> parameter with a single policy name.

`Pages/PassRequireAdminRolePolicy.razor`:

```razor
@page "/pass-requireadminrole-policy-with-authorizeview"

<h1>Pass 'RequireAdminRole' policy with AuthorizeView</h1>

<AuthorizeView Policy="RequireAdminRole">
    <p>You satisfy the 'RequireAdminRole' policy.</p>
</AuthorizeView>
```

To handle the case where the user should satisfy one of several policies, create a policy that confirms that the user satisfies other policies.

To handle the case where the user must satisfy several policies simultaneously, take *either* of the following approaches:

* Create a policy for <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> that confirms that the user satisfies several other policies.

* Nest the policies in multiple <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> components.

  `Pages/PassRequireAdminRoleAndRequireSuperUserRolePoliciesWithAuthorizeViews.razor`:

  ```razor
  @page "/pass-requireadminrole-and-requiresuperuserrole-policies-with-authorizeviews"

  <h1>
      Pass 'RequireAdminRole' and 'RequireSuperUserRole' policies with AuthorizeViews
  </h1>

  <AuthorizeView Policy="RequireAdminRole">
      <AuthorizeView Policy="RequireSuperUserRole" Context="innerContext">
          <p>
              You satisfy the 'RequireAdminRole' and 
              'RequireSuperUserRole' policies.
          </p>
      </AuthorizeView>
  </AuthorizeView>
  ```

If both <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView.Roles> and <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView.Policy> are set, authorization succeeds only when both conditions are satisfied. That is, the user must belong to at least one of the specified roles *and* meet the requirements defined by the policy.

If neither <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView.Roles> nor <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView.Policy> is specified, <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> uses the default policy:

* Authenticated (signed-in) users are authorized.
* Unauthenticated (signed-out) users are unauthorized.

In contrast to role matching, which is typically case-sensitive, ASP.NET Core policy name lookup is typically case-insensitive, so `RequireAdminRole` and `requireadminrole` refer to the same policy.

Policies are applied to an entire Razor component using the <xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute.Policy> property on the [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute).

`Pages/PassRequireAdminRolePolicyWithAuthorizeAttribute.razor`:

```razor
@page "/pass-requireadminrole-policy-with-authorize-attribute"
@using Microsoft.AspNetCore.Authorization
@attribute [Authorize(Policy = "RequireAdminRole")]

<h1>Pass RequireAdminRole policy with [Authorize] attribute</h1>

<p>You can only see this if the 'RequireAdminRole' policy is satisfied.</p>
```

To specify multiple allowed roles in a requirement, specify the roles as parameters to the <xref:Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.RequireRole%2A> method. In the following example, users are authorized if they belong to the `Admin` *or* `SuperUser` roles:

:::moniker range=">= aspnetcore-7.0"

```csharp
builder.Services.AddAuthorizationBuilder()
    .AddPolicy("ElevatedRights", policy =>
        policy.RequireRole("Admin", "SuperUser"));
```

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

```csharp
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ElevatedRights", policy =>
        policy.RequireRole("Admin", "SuperUser"));
});
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

```csharp
services.AddAuthorization(options =>
{
    options.AddPolicy("ElevatedRights", policy =>
        policy.RequireRole("Admin", "SuperUser"));
});
```

:::moniker-end

If you want the policy to require all of the preceding roles, either chain the roles to the policy builder or specify them to the policy builder individually in a [statement lambda](/dotnet/csharp/language-reference/operators/lambda-expressions#statement-lambdas).

Chained to the policy builder:

:::moniker range=">= aspnetcore-7.0"

```csharp
builder.Services.AddAuthorizationBuilder()
    .AddPolicy("ElevatedRights", policy => 
        policy
            .RequireRole("Admin")
            .RequireRole("SuperUser"));
```

Alternatively, use a statement lambda:

```csharp
builder.Services.AddAuthorizationBuilder()
    .AddPolicy("ElevatedRights",
        policy =>
        {
            policy.RequireRole("Admin");
            policy.RequireRole("SuperUser");
        });
```

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

```csharp
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ElevatedRights", policy => 
        policy
            .RequireRole("Admin")
            .RequireRole("SuperUser"));
});
```

Alternatively, use a statement lambda:

```csharp
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ElevatedRights",
        policy =>
        {
            policy.RequireRole("Admin");
            policy.RequireRole("SuperUser");
        });
});
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

```csharp
services.AddAuthorization(options =>
{
    options.AddPolicy("ElevatedRights", policy => 
        policy
            .RequireRole("Admin")
            .RequireRole("SuperUser"));
});
```

Alternatively, use a statement lambda:

```csharp
services.AddAuthorization(options =>
{
    options.AddPolicy("ElevatedRights",
        policy =>
        {
            policy.RequireRole("Admin");
            policy.RequireRole("SuperUser");
        });
});
```

:::moniker-end

## Windows Authentication security groups as app roles

:::moniker range=">= aspnetcore-9.0"

After the app is [configured for Windows Authentication](xref:security/authentication/windowsauth) ([Blazor-specific guidance](xref:blazor/security/blazor-web-app-windows-authentication)) with the client and server machines part of the same Windows domain, user security groups are automatically included as claims in the user's <xref:System.Security.Claims.ClaimsPrincipal>.

:::moniker-end

:::moniker range="< aspnetcore-9.0"

After the app is [configured for Windows Authentication](xref:security/authentication/windowsauth) with the client and server machines part of the same Windows domain, user security groups are automatically included as claims in the user's <xref:System.Security.Claims.ClaimsPrincipal>.

:::moniker-end

The `User.Identity` is typically a <xref:System.Security.Principal.WindowsIdentity> when using Windows Authentication, and you can retrieve the SID group claims or check if a user is in a role with the following code, where the `{DOMAIN}` placeholder is the domain and the `{SID GROUP NAME}` is the SID group name:

```csharp
if (User.Identity is WindowsIdentity windowsIdentity)
{
    var groups = windowsIdentity.Groups;

    // If needed, obtain a list of the SID groups
    var securityGroups = 
        groups.Select(g => g.Translate(typeof(NTAccount)).ToString()).ToList();

    // If needed, obtain the user's Windows identity name
    var windowsIdentityName = windowsIdentity.Name;

    // Check if the user is in a specific SID group
    if (User.IsInRole(@"{DOMAIN}\{SID GROUP NAME}"))
    {
        // User is in the specified group
    }
    else
    {
        // User isn't in the specified group
    }
}
else
{
    // The user isn't authenticated with Windows Authentication
}
```

:::moniker range=">= aspnetcore-9.0"

For a demonstration of related code that translates SID group claims into human-readable values in a Blazor app, see the `UserClaims` component in <xref:blazor/security/blazor-web-app-windows-authentication>. Such an approach to retrieving SID group claims can be combined with [adding claims with an `IClaimsTransformation`](xref:security/authentication/claims#extend-or-add-custom-claims-using-iclaimstransformation) to create custom role claims when a user is authenticated.

:::moniker-end

:::moniker range="< aspnetcore-9.0"

An approach similar to the preceding example for retrieving SID group claims can be combined with [adding claims with an `IClaimsTransformation`](xref:security/authentication/claims#extend-or-add-custom-claims-using-iclaimstransformation) to create custom role claims when a user is authenticated.

:::moniker-end

## Additional resources

* <xref:blazor/security/index>
* <xref:blazor/security/webassembly/meid-groups-roles>
* <xref:razor-pages/security/authorization/roles>
* <xref:mvc/security/authorization/roles>
* [Extend or add custom claims, including role claims, using `IClaimsTransformation`](xref:security/authentication/claims#extend-or-add-custom-claims-using-iclaimstransformation)
