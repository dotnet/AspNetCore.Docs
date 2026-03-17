---
title: Role-based authorization in ASP.NET Core
ai-usage: ai-assisted
author: wadepickett
description: Learn how to restrict ASP.NET Core controller and action access by passing roles to the Authorize attribute.
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.date: 03/17/2026
uid: security/authorization/roles
---
# Role-based authorization in ASP.NET Core

When a user's identity is created after authentication, the user may belong to one or more *roles*, reflecting various authorizations that the user has to access data and perform operations. For example, Tracy may belong to the "Administrator" and "User" roles with access to administrative web pages in the app, while Scott may only belong to the "User" role and not have access to administrative data or operations. How these roles are created and managed depends on the backing store of the authorization process. Roles are exposed to the developer through the <xref:System.Security.Principal.GenericPrincipal.IsInRole%2A> method on the <xref:System.Security.Claims.ClaimsPrincipal> class. <xref:Microsoft.AspNetCore.Identity.IdentityBuilder.AddRoles%2A> must be called to add Role services when setting up the app's identity system.

While roles are claims, not all claims are roles. Depending on the identity issuer, a role may be a collection of users that may apply claims for group members, as well as an actual claim on an identity. However, claims are meant to be information about an individual user. Using roles to add claims to a user can confuse the boundary between the user and their individual claims. This confusion is why the single-page application (SPA) templates aren't designed around roles. In addition, for organizations migrating from an on-premises legacy system, the proliferation of roles over the years can mean a role claim may be too large to be contained within a token usable by a SPA. To secure SPAs, see <xref:security/authentication/identity/spa>.

This article uses Blazor Razor component examples and focuses on Blazor authorization scenarios for ASP.NET Core 8.0 or later. For additional Blazor guidance, see the following resources:

* <xref:blazor/security/index>
* <xref:blazor/security/webassembly/meid-groups-roles>

For Razor Pages and MVC guidance, which applies to all release versions of ASP.NET Core, see the following resources:

* <xref:razor-pages/security/authorization/roles>
* <xref:mvc/security/authorization/roles>

:::moniker range="< aspnetcore-6.0"

Identity configuration changed with the release of .NET 6. Examples in this article demonstrate approaches that configure Identity services in the app's `Program` file. For .NET apps prior to the release of .NET 6 (and before Blazor was released with .NET 8), services are configured in `Startup.ConfigureServices` of the `Startup.cs` file. The syntax for Identity configuration is similar and shown in the companion [Razor Pages roles-based article](xref:razor-pages/security/authorization/roles) and the [MVC roles-based article](xref:mvc/security/authorization/roles). See those resources after reading this article and set the article version selector to the version of .NET that your app targets.

:::moniker-end

## Add Role services to Identity

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

## Role-based authorization checks

Role-based authorization checks:

* Are declarative and specify roles which the current user must be a member of to access the requested resource.
* Are applied to Razor components (examples in this article), [Razor Pages](xref:razor-pages/security/authorization/roles), or [MVC controllers or actions within a controller](xref:mvc/security/authorization/roles).

The <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> component supports *role-based* authorization. This section covers basic concepts. For complete coverage, see <xref:blazor/security/index>.

For role-based authorization for content in Razor components, use the <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView.Roles?displayProperty=nameWithType> parameter. In the following example, the user must have a role claim for either the `Admin` or `Superuser` roles:

```razor
<AuthorizeView Roles="Admin, Superuser">
    <p>You have an 'Admin' or 'Superuser' role claim.</p>
</AuthorizeView>
```

To require a user have both `Admin` and `Superuser` role claims, nest <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> components:

```razor
<AuthorizeView Roles="Admin">
    <p>User: @context.User</p>
    <p>You have the 'Admin' role claim.</p>
    <AuthorizeView Roles="Superuser" Context="innerContext">
        <p>User: @innerContext.User</p>
        <p>You have both 'Admin' and 'Superuser' role claims.</p>
    </AuthorizeView>
</AuthorizeView>
```

The preceding code establishes a `Context` for the inner <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> component to prevent an <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationState> context collision. The <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationState> context is accessed in the outer <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> with the standard approach for accessing the context (`@context.User`). The context is accessed in the inner <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> with the named `innerContext` context (`@innerContext.User`).

The [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) supports role-based authorization for entire Razor components. Use the <xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute.Roles?displayProperty=nameWithType> parameter. The following code limits component access to users who are a member of the `Administrator` role:

```razor
@page "/"
@attribute [Authorize(Roles = "Administrator")]

<p>You can only see this if you're in the 'Administrator' role.</p>
```

Multiple roles can be specified as a comma separated list. In the following example, access is limited to users who are members of the `HRManager` role *or* the `Finance` role:

```razor
@page "/"
@attribute [Authorize(Roles = "HRManager, Finance")]

<p>
    You can only see this if you're in the 'HRManager' role or the 'Finance' role.
</p>
```

When multiple attributes are applied, the user must be a member of *all* of the roles specified. The following example requires *both* `PowerUser` *and* `ControlPanelUser` roles:

```razor
@page "/"
@attribute [Authorize(Roles = "PowerUser")]
@attribute [Authorize(Roles = "ControlPanelUser")]

<p>
    You can only see this if you're in both the 'PowerUser' role 
    and the 'ControlPanelUser' role.
</p>
```

## Policy-based authorization checks

Role requirements can be expressed using policy syntax, where the app registers a policy at startup as part of the Authorization service configuration. In the following example, the `RequireAdministratorRole` policy specifies that all users must be in the `Administrator` role:

```csharp
builder.Services.AddAuthorizationBuilder()
    .AddPolicy("RequireAdministratorRole",
         policy => policy.RequireRole("Administrator"));
```

For policy-based authorization using an <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> component, use the <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView.Policy?displayProperty=nameWithType> parameter with a single policy name:

```razor
<AuthorizeView Policy="RequireAdministratorRole">
    <p>You satisfy the 'RequireAdministratorRole' policy.</p>
</AuthorizeView>
```

To handle the case where the user should satisfy one of several policies, create a policy that confirms that the user satisfies other policies.

To handle the case where the user must satisfy several policies simultaneously, take *either* of the following approaches:

* Create a policy for <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> that confirms that the user satisfies several other policies.
* Nest the policies in multiple <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> components:

  ```razor
  <AuthorizeView Policy="RequireAdministratorRole">
      <AuthorizeView Policy="RequireAccountingRole">
          <p>
              You satisfy the 'RequireAdministratorRole' and 
              'RequireAccountingRole' policies.
          </p>
      </AuthorizeView>
  </AuthorizeView>
  ```

If both <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView.Roles> and <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView.Policy> are set, authorization succeeds only when both conditions are satisfied. That is, the user must belong to at least one of the specified roles *and* meet the requirements defined by the policy.

If neither <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView.Roles> nor <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView.Policy> is specified, <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> uses the default policy:

* Authenticated (signed-in) users are authorized.
* Unauthenticated (signed-out) users are unauthorized.

Because .NET string comparisons are case-sensitive, matching role and policy names is also case-sensitive. For example, `Admin` (uppercase `A`) is not treated as the same role as `admin` (lowercase `a`).

Pascal case is typically used for role and policy names (for example, `BillingAdministrator`), but the use of Pascal case isn't a strict requirement. Different casing schemes, such as camel case, kebab case, and snake case, are permitted. Using spaces in role and policy names is unusual but permitted by the framework. For example, `billing administrator` is an unusual role or policy name format in .NET apps, but it's a valid role or policy name.

Policies are applied to an entire Razor component using the <xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute.Policy> property on the [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute):

```razor
@page "/"
@attribute [Authorize(Policy = "RequireAdministratorRole")]

<p>You can only see this if the 'RequireAdministratorRole' policy is satisfied.</p>
```

To specify multiple allowed roles in a requirement, specify the roles as parameters to the <xref:Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.RequireRole%2A> method. In the following example, users are authorized if they belong to the `Administrator`, `PowerUser`, *or* `BackupAdministrator` roles:

```csharp
builder.Services.AddAuthorizationBuilder()
    .AddPolicy("ElevatedRights", policy =>
          policy.RequireRole("Administrator", "PowerUser", "BackupAdministrator"));
```

If you want the policy to require all of the preceding roles, either chain the roles to the policy builder or specify them to the policy builder individually in a [statement lambda](/dotnet/csharp/language-reference/operators/lambda-expressions#statement-lambdas).

Chained to the policy builder:

```csharp
builder.Services.AddAuthorizationBuilder()
    .AddPolicy("ElevatedRights", policy => 
        policy
            .RequireRole("Administrator")
            .RequireRole("PowerUser")
            .RequireRole("BackupAdministrator"));
```

Alternatively, use a statement lambda:

```csharp
builder.Services.AddAuthorizationBuilder()
    .AddPolicy("ElevatedRights",
        policy =>
        {
            policy.RequireRole("Administrator");
            policy.RequireRole("PowerUser");
            policy.RequireRole("BackupAdministrator");
        });
```

## Additional resources

* <xref:blazor/security/index>
* <xref:blazor/security/webassembly/meid-groups-roles>
* <xref:razor-pages/security/authorization/roles>
* <xref:mvc/security/authorization/roles>
