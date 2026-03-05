---
title: Simple authorization in ASP.NET Core
ai-usage: ai-assisted
author: tdykstra
description: Learn how to use the [Authorize] attribute to restrict access in ASP.NET Core apps.
ms.author: tdykstra
ms.date: 03/05/2026
uid: security/authorization/simple
---
# Simple authorization in ASP.NET Core

Authorization in ASP.NET Core is controlled with the [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) and its various parameters. In its most basic form, applying the `[Authorize]` attribute to a Razor component, controller, action, or Razor Page, limits access to that component to authenticated users.

This article uses Blazor Razor component examples and focuses on Blazor authorization scenarios. For Razor Pages and MVC guidance, see the following resources after reading this article:

* <xref:razor-pages/security/authorization/simple>
* <xref:mvc/security/authorization/simple>

## `[Authorize]` attribute

In Blazor apps, specify the [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) at the top of a Razor component file (`.razor`). In the following example, only authenticated users can access the page:

```razor
@page "/"
@using Microsoft.AspNetCore.Authorization
@attribute [Authorize]

You can only see this if you're signed in.
```

> [!IMPORTANT]
> Only use the [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) on `@page` components reached via the Blazor router. Authorization is only performed as an aspect of routing and *not* for child components rendered within a page. To authorize the display of specific parts within a page, use an <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> component instead, which is described in <xref:blazor/security/index#authorizeview-component>.

The [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) can also be applied to all of the Razor components in a Blazor app or a subset of Razor components in a folder using an `_Imports` file (`_Imports.razor`). Add an [`@using`](xref:mvc/views/razor#using) directive for the <xref:Microsoft.AspNetCore.Authorization?displayProperty=fullName> namespace with an [`@attribute`](xref:mvc/views/razor#attribute) directive for the [`[Authorize]` attribute](xref:blazor/security/index#authorize-attribute):

```razor
@using Microsoft.AspNetCore.Authorization
@attribute [Authorize]
```

The [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) also supports role-based or policy-based authorization. For role-based authorization, use the <xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute.Roles> parameter. In the following example, the user can only access the page if they're in the `Admin` or `Superuser` role:

```razor
@page "/"
@attribute [Authorize(Roles = "Admin, Superuser")]

<p>You can only see this if you're in the 'Admin' or 'Superuser' role.</p>
```

For policy-based authorization, use the <xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute.Policy> parameter. In the following example, the user can only access the page if they satisfy the requirements of the `Over21` [authorization policy](xref:security/authorization/policies):

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

For more information on Blazor authentication and authorization, see <xref:blazor/security/index>.

Use the [`[AllowAnonymous]` attribute](xref:Microsoft.AspNetCore.Authorization.AllowAnonymousAttribute) to allow access by non-authenticated users to individual actions:

```razor
@using Microsoft.AspNetCore.Authorization
@attribute [AllowAnonymous]
```

For information on how to require authentication for all app users, see <xref:security/authorization/secure-data#require-authenticated-users>.

## Additional resources

* <xref:razor-pages/security/authorization/simple>
* <xref:mvc/security/authorization/simple>
