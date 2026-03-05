---
title: Simple authorization in ASP.NET Core MVC
ai-usage: ai-assisted
author: tdykstra
description: Learn how to use the [Authorize] attribute to restrict access in ASP.NET Core MVC apps.
ms.author: tdykstra
ms.date: 03/05/2026
uid: mvc/security/authorization/simple
---
# Simple authorization in ASP.NET Core MVC

Authorization in ASP.NET Core is controlled with the [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) and its various parameters. In its most basic form, applying the `[Authorize]` attribute to a Razor component, controller, action, or Razor Page, limits access to that component to authenticated users.

This article covers scenarios that pertain to MVC apps. For the primary coverage on this subject, see <xref:security/authorization/simple>.

## `[Authorize]` attribute

The following example limits access to authenticated users by specifying the [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute):

```csharp
[Authorize]
public class AccountController : Controller
{
    public ActionResult Login() { ... }
    public ActionResult Logout() { ... }
}
```

The [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) also supports role-based or policy-based authorization. For role-based authorization, use the <xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute.Roles> parameter. In the following example, the user can only access the page if they're in the `Admin` or `Superuser` role:

```csharp
[Authorize(Roles = "Admin, Superuser")]
public class OrderController : Controller
{
    ...
}
```

For policy-based authorization, use the <xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute.Policy> parameter. In the following example, the user can only access the page if they satisfy the requirements of the `Over21` [authorization policy](xref:security/authorization/policies):

```csharp
[Authorize(Policy = "Over21")]
public class LicenseApplicationController : Controller
{
    ...
}
```

If neither <xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute.Roles> nor <xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute.Policy> is specified, [`[Authorize]`](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) uses the default policy:

* Authenticated (signed-in) users are authorized.
* Unauthenticated (signed-out) users are unauthorized.

To apply authorization to an action rather than the controller, apply the [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) to the action. In the following example, only authenticated users can trigger a logout (call the `Logout` method):

```csharp
public class AccountController : Controller
{
   public ActionResult Login() { ... }

   [Authorize]
   public ActionResult Logout() { ... }
}
```

Use the [`[AllowAnonymous]` attribute](xref:Microsoft.AspNetCore.Authorization.AllowAnonymousAttribute) to allow access by non-authenticated users to individual actions:

```csharp
[AllowAnonymous]
```

> [!WARNING]
> For MVC controllers, the [`[AllowAnonymous]` attribute](xref:Microsoft.AspNetCore.Authorization.AllowAnonymousAttribute) bypasses authorization statements. If you combine `[AllowAnonymous]` and one or more `[Authorize]` attributes, the `[Authorize]` attributes are ignored. If you apply `[AllowAnonymous]` at the controller level:
>
> * Any authorization requirements from `[Authorize]` attributes on the same controller or action methods on the controller are ignored.
> * Authentication middleware isn't short-circuited but doesn't need to succeed.

For information on how to require authentication for all app users, see <xref:security/authorization/secure-data#require-authenticated-users>.

## Additional resources

* <xref:security/authorization/simple>
* <xref:razor-pages/security/authorization/simple>
