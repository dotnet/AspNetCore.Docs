---
title: Simple authorization in ASP.NET Core
author: rick-anderson
description: Learn how to use the Authorize attribute to restrict access to ASP.NET Core controllers and actions.
ms.author: riande
ms.date: 10/14/2016
no-loc: [Blazor, "Identity", "Let's Encrypt", Razor, SignalR]
uid: security/authorization/simple
---
# Simple authorization in ASP.NET Core

<a name="security-authorization-simple"></a>

Authorization in MVC is controlled through the `AuthorizeAttribute` attribute and its various parameters. At its simplest, applying the `AuthorizeAttribute` attribute to a controller or action limits access to the controller or action to any authenticated user.

For example, the following code limits access to the `AccountController` to any authenticated user.

```csharp
[Authorize]
public class AccountController : Controller
{
    public ActionResult Login()
    {
    }

    public ActionResult Logout()
    {
    }
}
```

If you want to apply authorization to an action rather than the controller, apply the `AuthorizeAttribute` attribute to the action itself:

```csharp
public class AccountController : Controller
{
   public ActionResult Login()
   {
   }

   [Authorize]
   public ActionResult Logout()
   {
   }
}
```

Now only authenticated users can access the `Logout` function.

You can also use the `AllowAnonymous` attribute to allow access by non-authenticated users to individual actions. For example:

```csharp
[Authorize]
public class AccountController : Controller
{
    [AllowAnonymous]
    public ActionResult Login()
    {
    }

    public ActionResult Logout()
    {
    }
}
```

This would allow only authenticated users to the `AccountController`, except for the `Login` action, which is accessible by everyone, regardless of their authenticated or unauthenticated / anonymous status.

> [!WARNING]
> `[AllowAnonymous]` bypasses all authorization statements. If you combine `[AllowAnonymous]` and any `[Authorize]` attribute, the `[Authorize]` attributes are ignored. For example if you apply `[AllowAnonymous]` at the controller level, any `[Authorize]` attributes on the same controller (or on any action within it) is ignored.
