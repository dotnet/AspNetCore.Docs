---
title: Simple authorization in ASP.NET Core
author: tdykstra
description: Learn how to use the Authorize attribute to restrict access in ASP.NET Core apps.
ms.author: tdykstra
ms.date: 01/20/2026
uid: security/authorization/simple
---
# Simple authorization in ASP.NET Core

Authorization in ASP.NET Core is controlled with the [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) and its various parameters. In its most basic form, applying the `[Authorize]` attribute to a Razor component, controller, action, or Razor Page, limits access to that component to authenticated users.

## `[Authorize]` attribute

Specify the [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) at the top of a Razor component file (`.razor`). In the following example, only authenticated users can access the page:

```razor
@page "/"
@attribute [Authorize]

You can only see this if you're signed in.
```

> [!IMPORTANT]
> Only use the [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) on `@page` components reached via the Blazor router. Authorization is only performed as an aspect of routing and *not* for child components rendered within a page. To authorize the display of specific parts within a page, use an <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> component instead, which is described in <xref:blazor/security/index#authorizeview-component>.

The [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) also supports role-based or policy-based authorization. For role-based authorization, use the <xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute.Roles> parameter. In the following example, the user can only access the page if they're in the `Admin` or `Superuser` role:

```razor
@page "/"
@attribute [Authorize(Roles = "Admin, Superuser")]

<p>You can only see this if you're in the 'Admin' or 'Superuser' role.</p>
```

For policy-based authorization, use the <xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute.Policy> parameter. In the following example, the user can only access the page if satisfy the requirements of the `Over21` [authorization policy](xref:security/authorization/policies):

```razor
@page "/"
@attribute [Authorize(Policy = "Over21")]

<p>You can only see this if you satisfy the 'Over21' policy.</p>
```

If neither <xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute.Roles> nor <xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute.Policy> is specified, [`[Authorize]`](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) uses the default policy:

* Authenticated (signed-in) users are authorized.
* Unauthenticated (signed-out) users are unauthorized.

When the user isn't authorized and if the app doesn't [customize unauthorized content with the `Router` component](xref:blazor/security/index#customize-unauthorized-content-with-the-router-component), the framework automatically displays the following fallback message:

```html
Not authorized.
```

For an MVC controller, the following example limits access to authenticated users:

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

To apply authorization to an action rather than the controller, apply the [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) to the action. In the following example, only authenticated users can trigger a logout (call the `Logout` method):

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

In a Razor Pages app, apply the [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) to the page model class that derives from <xref:Microsoft.AspNetCore.Mvc.RazorPages.PageModel>. In the following example, only authenticated users can reach the `LogoutModel` page:

```csharp
[Authorize]
public class LogoutModel : PageModel
{
    public async Task OnGetAsync()
    {

    }

    public async Task<IActionResult> OnPostAsync()
    {

    }
}
```

Use the [`[AllowAnonymous]` attribute](xref:Microsoft.AspNetCore.Authorization.AllowAnonymousAttribute) to allow access by non-authenticated users to individual actions. In the following example, only authenticated users are allowed to access to the `AccountController`, except for the `Login` action, which is accessible by everyone, regardless of their authentication status:

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

> [!WARNING]
> The [`[AllowAnonymous]` attribute](xref:Microsoft.AspNetCore.Authorization.AllowAnonymousAttribute) bypasses authorization statements. If you combine `[AllowAnonymous]` and one or more `[Authorize]` attributes, the `[Authorize]` attributes are ignored. If you apply `[AllowAnonymous]` at the controller level:
>
> * Any authorization requirements from `[Authorize]` attributes on the same controller or action methods on the controller are ignored.
> * Authentication middleware isn't short-circuited but doesn't need to succeed.

For information on how to require authentication for all app users, see <xref:security/authorization/secure-data#require-authenticated-users>.

## `[Authorize]` attribute and Razor Pages

The <xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute> can ***not*** be applied to Razor Page handlers. For example, the [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) can't be applied to `OnGet`, `OnPost`, or any other page handler. In a Razor Pages app, consider using an ASP.NET Core MVC controller for pages with different authorization requirements for different handlers. Using an MVC controller when different authorization requirements are required is the least complex approach recommended by Microsoft.

If you decide not to use an MVC controller, the following two approaches can be used to apply authorization to Razor Page handler methods:

* Use separate pages for page handlers requiring different authorization. Move shared content into one or more [partial views](xref:mvc/views/partial). When possible, this is the recommended approach.
* For content that must share a common page, write a filter that performs authorization as part of [IAsyncPageFilter.OnPageHandlerSelectionAsync](xref:Microsoft.AspNetCore.Mvc.Filters.IAsyncPageFilter.OnPageHandlerSelectionAsync%2A). The [PageHandlerAuth](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/security/authorization/simple/samples/3.1/PageHandlerAuth) GitHub project demonstrates this approach:
  * The [AuthorizeIndexPageHandlerFilter](https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/security/authorization/simple/samples/3.1/PageHandlerAuth/AuthorizeIndexPageHandlerFilter.cs) implements the authorization filter:
  [!code-csharp[](~/security/authorization/simple/samples/3.1/PageHandlerAuth/Pages/Index.cshtml.cs?name=snippet&highlight=21)]

  * The [[AuthorizePageHandler]](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/security/authorization/simple/samples/3.1/PageHandlerAuth/Pages/Index.cshtml.cs#L28) attribute is applied to the `OnPostAuthorized` page handler:
  [!code-csharp[](~/security/authorization/simple/samples/3.1/PageHandlerAuth/AuthorizeIndexPageHandlerFilter.cs?name=snippet)]

> [!WARNING]
> The [PageHandlerAuth](https://github.com/pranavkm/PageHandlerAuth) sample approach does ***not***:
> * Compose with authorization attributes applied to the page, page model, or globally. Composing authorization attributes results in authentication and authorization executing multiple times when you have one more [`[Authorize]` attributes](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) or `AuthorizeFilter` instances also applied to the page.
> * Work in conjunction with the rest of ASP.NET Core authentication and authorization system. You must verify using this approach works correctly for your application.

There are no plans to support the [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) on Razor Page handlers.

## Additional resources

* <xref:blazor/security/index>
* xxx
