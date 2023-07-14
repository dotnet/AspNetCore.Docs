---
title: Role-based authorization in ASP.NET Core
author: rick-anderson
description: Learn how to restrict ASP.NET Core controller and action access by passing roles to the Authorize attribute.
ms.author: riande
monikerRange: '>= aspnetcore-3.1'
ms.date: 10/14/2016
uid: security/authorization/roles
---
# Role-based authorization in ASP.NET Core

:::moniker range=">= aspnetcore-6.0"

<a name="security-authorization-role-based"></a>

When an identity is created it may belong to one or more roles. For example, Tracy may belong to the `Administrator` and `User` roles while Scott may only belong to the `User` role. How these roles are created and managed depends on the backing store of the authorization process. Roles are exposed to the developer through the <xref:System.Security.Principal.GenericPrincipal.IsInRole%2A> method on the <xref:System.Security.Claims.ClaimsPrincipal> class. <xref:Microsoft.AspNetCore.Identity.IdentityBuilder.AddRoles%2A> must be added to Role services.

While roles are claims, not all claims are roles. Depending on the identity issuer a role may be a collection of users that may apply claims for group members, as well as an actual claim on an identity. However, claims are meant to be information about an individual user. Using roles to add claims to a user can confuse the boundary between the user and their individual claims. This confusion is why the SPA templates are not designed around roles. In addition, for organizations migrating from an on-premises legacy system the proliferation of roles over the years can mean a role claim may be too large to be contained within a token usable by SPAs. To secure SPAs, see <xref:security/authentication/identity/spa>.

## Add Role services to Identity

Register role-based authorization services in `Program.cs` by calling <xref:Microsoft.AspNetCore.Identity.IdentityBuilder.AddRoles%2A> with the role type in the app's Identity configuration. The role type in the following example is `IdentityRole`:

```csharp
builder.Services.AddDefaultIdentity<IdentityUser>( ... )
    .AddRoles<IdentityRole>()
    ...
```

## Adding role checks

Role based authorization checks:

* Are declarative and specify roles which the current user must be a member of to access the requested resource.
* Are applied to Razor Pages, controllers, or actions within a controller.
* Can ***not*** be applied at the Razor Page handler level, they must be applied to the Page.

For example, the following code limits access to any actions on the `AdministrationController` to users who are a member of the `Administrator` role:

[!code-csharp[](~/security/authorization/roles/samples/6_0/WebAll/Controllers/AdministrationController.cs?name=snippet&highlight=1)]

Multiple roles can be specified as a comma separated list:

[!code-csharp[](~/security/authorization/roles/samples/6_0/WebAll/Controllers/SalaryController.cs?name=snippet&highlight=1)]

The `SalaryController` is only accessible by users who are members of the `HRManager` role ***or*** the `Finance` role.

When multiple attributes are applied, an accessing user must be a member of ***all*** the roles specified. The following sample requires that a user must be a member of ***both*** the `PowerUser` ***and*** `ControlPanelUser` role:

[!code-csharp[](~/security/authorization/roles/samples/6_0/WebAll/Controllers/ControlPanelController.cs?name=snippet&highlight=1-2)]

Access to an action can be limited by applying additional role authorization attributes at the action level:

[!code-csharp[](~/security/authorization/roles/samples/6_0/WebAll/Controllers/ControlAllPanelController.cs?name=snippet&highlight=1-2,7)]

In the preceding `ControlAllPanelController` controller:

* Members of the `Administrator` role or the `PowerUser` role can access the controller and the `SetTime` action.
* Only members of the `Administrator` role can access the `ShutDown` action.

A controller can be locked down but allow anonymous, unauthenticated access to individual actions:

[!code-csharp[](~/security/authorization/roles/samples/6_0/WebAll/Controllers/Control3PanelController.cs?name=snippet&highlight=1,7)]

For Razor Pages, [`[Authorize]`](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) can be applied by either:

* Using a [convention](xref:razor-pages/razor-pages-conventions#page-model-action-conventions), or
* Applying the [`[Authorize]`](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) to the `PageModel` instance:

[!code-csharp[](~/security/authorization/roles/samples/6_0/WebAll/Pages/X/Update.cshtml.cs?name=snippet&highlight=1)]

> [!IMPORTANT]
> Filter attributes, including `AuthorizeAttribute`, can only be applied to PageModel and cannot be applied to specific page handler methods.

<a name="security-authorization-role-policy"></a>

## Policy based role checks

Role requirements can also be expressed using the Policy syntax, where a developer registers a policy at application startup as part of the Authorization service configuration. This typically occurs in the `Program.cs` file:

[!code-csharp[](~/security/authorization/roles/samples/6_0/WebAll/Program.cs?name=snippet&highlight=6-10)]

Policies are applied using the <xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute.Policy> property on the [`[Authorize]`](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) attribute:

[!code-csharp[](~/security/authorization/roles/samples/6_0/WebAll/Controllers/Home2Controller.cs?name=snippet&highlight=1)]

To specify multiple allowed roles in a requirement, specify them as parameters to the <xref:Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.RequireRole%2A> method:

[!code-csharp[](~/security/authorization/roles/samples/6_0/WebAll/Program.cs?name=snippet2&highlight=6-10)]

The preceding code authorizes users who belong to the `Administrator`, `PowerUser` or `BackupAdministrator` roles.

:::moniker-end

:::moniker range="< aspnetcore-6.0"

<a name="security-authorization-role-based"></a>

When an identity is created it may belong to one or more roles. For example, Tracy may belong to the Administrator and User roles whilst Scott may only belong to the User role. How these roles are created and managed depends on the backing store of the authorization process. Roles are exposed to the developer through the <xref:System.Security.Principal.GenericPrincipal.IsInRole%2A> method on the <xref:System.Security.Claims.ClaimsPrincipal> class.

We recommend not using Roles as claims, but rather using a [claims](xref:security/authorization/claims). When using Single Page Apps (SPAs), see <xref:security/authentication/identity/spa>.

## Adding role checks

Role based authorization checks:

* Are declarative.
* Are applied to Razor Pages, controllers, or actions within a controller.
* Can ***not*** be applied at the Razor Page handler level, they must be applied to the Page.

Role-based authorization checks specify which roles which the current user must be a member of to access the requested resource.

For example, the following code limits access to any actions on the `AdministrationController` to users who are a member of the `Administrator` role:

[!code-csharp[](~/security/authorization/roles/samples/6_0/WebAll/Controllers/AdministrationController.cs?name=snippet&highlight=1)]

Multiple roles can be specified as a comma separated list:

[!code-csharp[](~/security/authorization/roles/samples/6_0/WebAll/Controllers/SalaryController.cs?name=snippet&highlight=1)]

The controller `SalaryController` is only accessible by users who are members of the `HRManager` role ***or*** the `Finance` role.

If you apply multiple attributes then an accessing user must be a member of all the roles specified. The following sample requires that a user must be a member of both the `PowerUser` and `ControlPanelUser` role:

[!code-csharp[](~/security/authorization/roles/samples/6_0/WebAll/Controllers/ControlPanelController.cs?name=snippet&highlight=1-2)]

You can further limit access by applying additional role authorization attributes at the action level:

[!code-csharp[](~/security/authorization/roles/samples/6_0/WebAll/Controllers/ControlAllPanelController.cs?name=snippet&highlight=1-2)]

If multiple attributes are applied at the controller and action levels, ***all*** attributes must pass before access is granted:

[!code-csharp[](~/security/authorization/roles/samples/6_0/WebAll/Controllers/ControlAllPanelController2.cs?name=snippet&highlight=1,7)]

In the preceding `ControlAllPanelController` controller:

* Members of the `Administrator` role or the `PowerUser` role can access the controller and the `SetTime` action.
* Only members of the `Administrator` role can access the `ShutDown` action.

You can also lock down a controller but allow anonymous, unauthenticated access to individual actions.

[!code-csharp[](~/security/authorization/roles/samples/6_0/WebAll/Controllers/Control3PanelController.cs?name=snippet&highlight=1,9)]

For Razor Pages, the [`[Authorize]`](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) can be applied by either:

* Using a [convention](xref:razor-pages/razor-pages-conventions#page-model-action-conventions), or
* Applying the [`[Authorize]`](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute)to the `PageModel` instance:

```csharp
[Authorize(Policy = "RequireAdministratorRole")]
public class UpdateModel : PageModel
{
    public ActionResult OnPost()
    {
    }
}
```

> [!IMPORTANT]
> Filter attributes, including `AuthorizeAttribute`, can only be applied to PageModel and cannot be applied to specific page handler methods.

<a name="security-authorization-role-policy"></a>

## Policy based role checks

Role requirements can also be expressed using the new Policy syntax, where a developer registers a policy at startup as part of the Authorization service configuration. This normally occurs in `ConfigureServices()` in your `Startup.cs` file.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddControllersWithViews();
    services.AddRazorPages();

    services.AddAuthorization(options =>
    {
        options.AddPolicy("RequireAdministratorRole",
             policy => policy.RequireRole("Administrator"));
    });
}
```

Policies are applied using the `Policy` property on the [`[Authorize]`](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute)attribute:

```csharp
[Authorize(Policy = "RequireAdministratorRole")]
public IActionResult Shutdown()
{
    return View();
}
```

If you want to specify multiple allowed roles in a requirement then you can specify them as parameters to the `RequireRole` method:

```csharp
options.AddPolicy("ElevatedRights", policy =>
                  policy.RequireRole("Administrator", "PowerUser", "BackupAdministrator"));
```

This example authorizes users who belong to the `Administrator`, `PowerUser` or `BackupAdministrator` roles.

### Add Role services to Identity

Append <xref:Microsoft.AspNetCore.Identity.IdentityBuilder.AddRoles%2A> to add Role services:

[!code-csharp[](roles/samples/3_0/Startup.cs?name=snippet&highlight=7)]
:::moniker-end
