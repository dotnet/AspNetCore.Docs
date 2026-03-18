---
title: Role-based authorization in ASP.NET Core Razor Pages
ai-usage: ai-assisted
author: wadepickett
description: Learn how to restrict ASP.NET Core Razor Pages page access by passing roles to the Authorize attribute.
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.date: 03/18/2026
uid: razor-pages/security/authorization/roles
---
# Role-based authorization in ASP.NET Core Razor Pages

When a user's identity is created after authentication, the user may belong to one or more *roles*, reflecting various authorizations that the user has to access data and perform operations. For example, Tracy may belong to the "Administrator" and "User" roles with access to administrative web pages in the app, while Scott may only belong to the "User" role and not have access to administrative data or operations. How these roles are created and managed depends on the backing store of the authorization process. Roles are exposed to the developer through the <xref:System.Security.Principal.GenericPrincipal.IsInRole%2A> method on the <xref:System.Security.Claims.ClaimsPrincipal> class. <xref:Microsoft.AspNetCore.Identity.IdentityBuilder.AddRoles%2A> must be called to add Role services when setting up the app's identity system.

While roles are claims, not all claims are roles. Depending on the identity issuer, a role may be a collection of users that may apply claims for group members, as well as an actual claim on an identity. However, claims are meant to be information about an individual user. Using roles to add claims to a user can confuse the boundary between the user and their individual claims. This confusion is why the single-page application (SPA) templates aren't designed around roles. In addition, for organizations migrating from an on-premises legacy system, the proliferation of roles over the years can mean a role claim may be too large to be contained within a token usable by a SPA. To secure SPAs, see <xref:security/authentication/identity/spa>.

This article uses Razor Pages examples and focuses on Razor Pages authorization scenarios. For Blazor and MVC guidance, see the following resources:

* <xref:security/authorization/roles>
* <xref:mvc/security/authorization/roles>

Examples throughout this article apply role-based authorization via one or more [`[Authorize]` attributes](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) on `PageModel` classes. Alternatively, role-based authorization can be applied using *conventions*. For more information, see <xref:razor-pages/razor-pages-conventions#page-model-action-conventions>.

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

## Role-based authorization checks

Role-based authorization checks:

* Are declarative and specify roles which the current user must be a member of to access the requested resource.
* Are applied to Razor Pages `PageModel` classes.
* Can't be applied at the Razor Page handler level. They must be applied to the entire `PageModel` class.

For example, the following code limits access to any `PageModel` handlers to users who are a member of the `Administrator` role:

```csharp
[Authorize(Roles = "Administrator")]
public class AdministrationModel : PageModel
{
    ...
}
```

Multiple roles can be specified as a comma separated list. In the following example, access is limited to users who are members of the `HRManager` role *or* the `Finance` role:

```csharp
[Authorize(Roles = "HRManager, Finance")]
public class SalaryModel : PageModel
{
    ...
}
```

When multiple attributes are applied, the user must be a member of *all* of the roles specified. The following example requires *both* `PowerUser` *and* `ControlPanelUser` roles to call the `SetTime` and `Shutdown` handlers:

```csharp
[Authorize(Roles = "PowerUser")]
[Authorize(Roles = "ControlPanelUser")]
public class ControlPanelModel : PageModel
{
    public IActionResult SetTime() { ... }
    public IActionResult ShutDown() { ... }
}
```

<!--
Access to an action can be limited by applying additional role authorization attributes at the action level:

```csharp
[Authorize(Roles = "Administrator, PowerUser")]
public class ControlPanelController : Controller
{
    public IActionResult SetTime() { ... }

    [Authorize(Roles = "Administrator")]
    public IActionResult ShutDown() { ... }
}
```

In the preceding controller:

* Members of the `Administrator` role or the `PowerUser` role can access the controller and the `SetTime` action.
* Only members of the `Administrator` role can access the `ShutDown` action.

A controller can be secured but still allow anonymous, unauthenticated access to individual actions with the [`[AllowAnonymous]` attribute](xref:Microsoft.AspNetCore.Authorization.AllowAnonymousAttribute):

```csharp
[Authorize]
public class Control3PanelController : Controller
{
    public IActionResult SetTime() { ... }

    [AllowAnonymous]
    public IActionResult Login() { ... }
}
```

-->

> [!IMPORTANT]
> Filter attributes, including the [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute), can only be applied to the entire `PageModel` class and can't be applied to specific page handler methods.

## Policy-based authorization checks

:::moniker range=">= aspnetcore-7.0"

Role requirements can be expressed using policy syntax, where the app registers a policy at startup as part of the Authorization service configuration. In the following example, the `RequireAdministratorRole` policy specifies that all users must be in the `Administrator` role:

```csharp
builder.Services.AddAuthorizationBuilder()
    .AddPolicy("RequireAdministratorRole",
         policy => policy.RequireRole("Administrator"));
```

Policies are applied using the <xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute.Policy> property on the [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute):

```csharp
[Authorize(Policy = "RequireAdministratorRole")]
public class AdministrationModel : PageModel
{
    ...
}
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

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore.7.0"

Role requirements can be expressed using policy syntax, where the app registers a policy at startup as part of the Authorization service configuration. In the following example, the `RequireAdministratorRole` policy specifies that all users must be in the `Administrator` role:

```csharp
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdministratorRole",
        policy => policy.RequireRole("Administrator"));
});
```

Policies are applied using the <xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute.Policy> property on the [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute):

```csharp
[Authorize(Policy = "RequireAdministratorRole")]
public class AdministrationModel : PageModel
{
    ...
}
```

To specify multiple allowed roles in a requirement, specify the roles as parameters to the <xref:Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.RequireRole%2A> method. In the following example, users are authorized if they belong to the `Administrator`, `PowerUser`, *or* `BackupAdministrator` roles:

```csharp
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ElevatedRights", policy =>
          policy.RequireRole("Administrator", "PowerUser", "BackupAdministrator"));
});
```

If you want the policy to require all of the preceding roles, either chain the roles to the policy builder or specify them to the policy builder individually in a [statement lambda](/dotnet/csharp/language-reference/operators/lambda-expressions#statement-lambdas).

Chained to the policy builder:

```csharp
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ElevatedRights", policy => 
        policy
            .RequireRole("Administrator")
            .RequireRole("PowerUser")
            .RequireRole("BackupAdministrator"));
});
```

Alternatively, use a statement lambda:

```csharp
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ElevatedRights",
        policy =>
        {
            policy.RequireRole("Administrator");
            policy.RequireRole("PowerUser");
            policy.RequireRole("BackupAdministrator");
        });
});
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

Role requirements can be expressed using policy syntax, where the app registers a policy at startup as part of the Authorization service configuration. In the following example, the `RequireAdministratorRole` policy specifies that all users must be in the `Administrator` role:

```csharp
services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdministratorRole",
        policy => policy.RequireRole("Administrator"));
});
```

Policies are applied using the <xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute.Policy> property on the [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute):

```csharp
[Authorize(Policy = "RequireAdministratorRole")]
public class AdministrationModel : PageModel
{
    ...
}
```

To specify multiple allowed roles in a requirement, specify the roles as parameters to the <xref:Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.RequireRole%2A> method. In the following example, users are authorized if they belong to the `Administrator`, `PowerUser`, *or* `BackupAdministrator` roles:

```csharp
services.AddAuthorization(options =>
{
    options.AddPolicy("ElevatedRights", policy =>
          policy.RequireRole("Administrator", "PowerUser", "BackupAdministrator"));
});
```

If you want the policy to require all of the preceding roles, either chain the roles to the policy builder or specify them to the policy builder individually in a [statement lambda](/dotnet/csharp/language-reference/operators/lambda-expressions#statement-lambdas).

Chained to the policy builder:

```csharp
services.AddAuthorization(options =>
{
    options.AddPolicy("ElevatedRights", policy => 
        policy
            .RequireRole("Administrator")
            .RequireRole("PowerUser")
            .RequireRole("BackupAdministrator"));
});
```

Alternatively, use a statement lambda:

```csharp
services.AddAuthorization(options =>
{
    options.AddPolicy("ElevatedRights",
        policy =>
        {
            policy.RequireRole("Administrator");
            policy.RequireRole("PowerUser");
            policy.RequireRole("BackupAdministrator");
        });
});
```

:::moniker-end

## Windows Authentication security groups as app roles

After the app is [configured for Windows Authentication](xref:security/authentication/windowsauth) ([Blazor-specific guidance](xref:blazor/security/blazor-web-app-with-windows-authentication)) with the client and server machines part of the same Windows domain, user security groups are automatically included as claims in the user's <xref:System.Security.Claims.ClaimsPrincipal>.

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

For a demonstration of related code that translates SID group claims into human-readable values, see the `UserClaims` component in <xref:blazor/security/blazor-web-app-with-windows-authentication>. Such an approach to retrieving SID group claims can be combined with [adding claims with an `IClaimsTransformation`](xref:security/authentication/claims#extend-or-add-custom-claims-using-iclaimstransformation) to create custom role claims when a user authenticates to the app.

## Additional resources

* <xref:blazor/security/index>
* <xref:blazor/security/webassembly/meid-groups-roles>
* <xref:razor-pages/security/authorization/roles>
* <xref:mvc/security/authorization/roles>
* [Extend or add custom claims, including role claims, using `IClaimsTransformation`](xref:security/authentication/claims#extend-or-add-custom-claims-using-iclaimstransformation)
