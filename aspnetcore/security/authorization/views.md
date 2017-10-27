---
title: View-based authorization in ASP.NET Core MVC
author: rick-anderson
description: This document demonstrates how to inject and utilize the authorization service inside of an ASP.NET Core Razor view.
keywords: ASP.NET Core,authorization,IAuthorizationService,Razor authorization
ms.author: riande
manager: wpickett
ms.date: 10/26/2017
ms.topic: article
ms.assetid: 24ce40d8-9b83-4bae-9d4c-a66350fcc8f8
ms.technology: aspnet
ms.prod: asp.net-core
uid: security/authorization/views
---
# View-based authorization

A developer often wants to show, hide, or otherwise modify a UI based on the current user identity. You can access the authorization service within MVC views via [dependency injection](xref:fundamentals/dependency-injection#fundamentals-dependency-injection). To inject the authorization service into a Razor view, use the `@inject` directive:

```cshtml
@using Microsoft.AspNetCore.Authorization
@inject IAuthorizationService AuthorizationService
```

If you want the authorization service in every view, place the `@inject` directive into the *_ViewImports.cshtml* file of the *Views* directory. For more information, see [Dependency injection into views](xref:mvc/views/dependency-injection).

Use the injected authorization service to invoke `AuthorizeAsync` in exactly the same way you would check during [resource based authorization](xref:security/authorization/resourcebased#security-authorization-resource-based-imperative):

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

```cshtml
@if ((await AuthorizationService.AuthorizeAsync(User, "PolicyName")).Succeeded)
{
    <p>This paragraph is displayed because you fulfilled PolicyName.</p>
}
```

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

```cshtml
@if (await AuthorizationService.AuthorizeAsync(User, "PolicyName"))
{
    <p>This paragraph is displayed because you fulfilled PolicyName.</p>
}
```

---

In some cases, the resource will be your view model. Invoke `AuthorizeAsync` in exactly the same way you would check during [resource based authorization](xref:security/authorization/resourcebased#security-authorization-resource-based-imperative):

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

```cshtml
@if ((await AuthorizationService.AuthorizeAsync(User, Model, Operations.Edit)).Succeeded)
{
    <p><a class="btn btn-default" role="button"
        href="@Url.Action("Edit", "Document", new { id = Model.Id })">Edit</a></p>
}
```

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

```cshtml
@if (await AuthorizationService.AuthorizeAsync(User, Model, Operations.Edit))
{
    <p><a class="btn btn-default" role="button"
        href="@Url.Action("Edit", "Document", new { id = Model.Id })">Edit</a></p>
}
```

---

In the preceding code, the model is passed as a resource the policy evaluation should take into consideration.

>[!WARNING]
>Don't rely on showing or hiding parts of your UI as your only authorization method. Hiding a UI element doesn't mean a user cannot access it. You must also authorize the user within your controller code.
