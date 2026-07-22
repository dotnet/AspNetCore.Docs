---
title: View-based authorization in ASP.NET Core MVC
author: wadepickett
description: This document demonstrates how to inject and utilize the authorization service inside of an ASP.NET Core Razor view.
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.date: 07/22/2026
uid: mvc/security/authorization/views
---
# View-based authorization in ASP.NET Core MVC

A developer often wants to show, hide, or otherwise modify a UI based on the current user identity. You can access the authorization service within MVC views via [dependency injection](xref:fundamentals/dependency-injection). To inject the authorization service (<xref:Microsoft.AspNetCore.Authorization.IAuthorizationService>) into a Razor view, use the `@inject` directive:

```razor
@using Microsoft.AspNetCore.Authorization
@inject IAuthorizationService AuthService
```

To implement the authorization service in every view, place the `@inject` directive into the `Views/_ViewImports.cshtml` file. For more information, see <xref:mvc/views/dependency-injection>.

Use the injected authorization service to invoke <xref:Microsoft.AspNetCore.Authorization.IAuthorizationService.AuthorizeAsync%2A?displayProperty=nameWithType> in exactly the same way an app would check authorization during [resource-based authorization](xref:security/authorization/resource-based#use-imperative-authorization):

```razor
@if ((await AuthService.AuthorizeAsync(User, "PolicyName")).Succeeded)
{
    <p>This paragraph is displayed because you fulfilled PolicyName.</p>
}
```

In some cases, the resource is the view model. Invoke <xref:Microsoft.AspNetCore.Authorization.IAuthorizationService.AuthorizeAsync%2A> in exactly the same way the app would check authorization during [resource-based authorization](xref:security/authorization/resource-based#use-imperative-authorization). The model is passed as a resource for the policy's evaluation:

```razor
@if ((await AuthService.AuthorizeAsync(User, Model, Operations.Edit)).Succeeded)
{
    <p><a class="btn btn-default" role="button"
        href="@Url.Action("Edit", "Document", new { id = Model.Id })">Edit</a></p>
}
```

> [!WARNING]
> Don't rely on toggling the visibility of the app's UI elements as the sole authorization check. Hiding a UI element may not completely prevent access to its associated controller action. For example, consider the button in the preceding code snippet. A user can invoke the `Edit` action method if they know the relative resource URL is `/Document/Edit/1`. For this reason, the `Edit` action method should perform its own authorization check.
