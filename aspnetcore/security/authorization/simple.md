---
title: Simple authorization in ASP.NET Core
author: tdykstra
description: Learn how to use the Authorize attribute to restrict access to ASP.NET Core controllers and actions.
ms.author: tdykstra
ms.date: 05/01/2024
uid: security/authorization/simple
---
# Simple authorization in ASP.NET Core

<a name="security-authorization-simple"></a>

Authorization in ASP.NET Core is controlled with the [`[Authorize]`](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) attribute and its various parameters. In its most basic form, applying the `[Authorize]` attribute to a controller, action, or Razor Page, limits access to that component to authenticated users.

## Prerequisites

This article assumes that you have a basic understanding of ASP.NET Core Razor Pages and MVC. If you're new to ASP.NET Core, see the following resources:

* <xref:razor-pages/index>
* <xref:mvc/overview>
* <xref:tutorials/razor-pages/razor-pages-start>
* <xref:security/authentication/identity>

## Use the `[Authorize]` attribute

The following code limits access to the `AccountController` to authenticated users:

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
> `[AllowAnonymous]` bypasses authorization statements. If you combine `[AllowAnonymous]` and an `[Authorize]` attribute, the `[Authorize]` attributes are ignored. For example if you apply `[AllowAnonymous]` at the controller level:
> * Any authorization requirements from `[Authorize]` attributes on the same controller or action methods on the controller are ignored.
> * Authentication middleware is not short-circuited but doesn't need to succeed.

The following code limits access to the `LogoutModel` Razor Page to authenticated users:

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

[!INCLUDE[](~/includes/requireAuth.md)]

<a name="aarp"></a>

## Authorize attribute and Razor Pages

The <xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute> can ***not*** be applied to Razor Page handlers. For example, `[Authorize]` can't be applied to `OnGet`, `OnPost`, or any other page handler. Consider using an ASP.NET Core MVC controller for pages with different authorization requirements for different handlers. Using an MVC controller when different authorization requirements are required:

* Is the least complex approach.
* Is the approach recommended by Microsoft.

If you decide not to use an MVC controller, the following two approaches can be used to apply authorization to Razor Page handler methods:

* Use separate pages for page handlers requiring different authorization. Move shared content into one or more [partial views](xref:mvc/views/partial). When possible, this is the recommended approach.
* For content that must share a common page, write a filter that performs authorization as part of [IAsyncPageFilter.OnPageHandlerSelectionAsync](xref:Microsoft.AspNetCore.Mvc.Filters.IAsyncPageFilter.OnPageHandlerSelectionAsync%2A). The [PageHandlerAuth](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/security/authorization/simple/samples/3.1/PageHandlerAuth) GitHub project demonstrates this approach:
  * The [AuthorizeIndexPageHandlerFilter](https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/security/authorization/simple/samples/3.1/PageHandlerAuth/AuthorizeIndexPageHandlerFilter.cs) implements the authorization filter:
  [!code-csharp[](~/security/authorization/simple/samples/3.1/PageHandlerAuth/Pages/Index.cshtml.cs?name=snippet&highlight=21)]

  * The [[AuthorizePageHandler]](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/security/authorization/simple/samples/3.1/PageHandlerAuth/Pages/Index.cshtml.cs#L28) attribute is applied to the `OnPostAuthorized` page handler:
  [!code-csharp[](~/security/authorization/simple/samples/3.1/PageHandlerAuth/AuthorizeIndexPageHandlerFilter.cs?name=snippet)]

> [!WARNING]
> The [PageHandlerAuth](https://github.com/pranavkm/PageHandlerAuth) sample approach does ***not***:
> * Compose with authorization attributes applied to the page, page model, or globally. Composing authorization attributes results in authentication and authorization executing multiple times when you have one more `AuthorizeAttribute` or `AuthorizeFilter` instances also applied to the page.
> * Work in conjunction with the rest of ASP.NET Core authentication and authorization system. You must verify using this approach works correctly for your application.

There are no plans to support the `AuthorizeAttribute` on Razor Page handlers.
