---
title: View Based Authorization
author: rick-anderson
ms.author: riande
manager: wpickett
ms.date: 10/14/2016
ms.topic: article
ms.assetid: 24ce40d8-9b83-4bae-9d4c-a66350fcc8f8
ms.prod: aspnet-core
uid: security/authorization/views
---
# View Based Authorization

<a name=security-authorization-views></a>

Often a developer will want to show, hide or otherwise modify a UI based on the current user identity. You can access the authorization service within MVC views via [dependency injection](../../fundamentals/dependency-injection.md#fundamentals-dependency-injection). To inject the authorization service into a Razor view use the `@inject` directive, for example `@inject IAuthorizationService AuthorizationService`. If you want the authorization service in every view then place the `@inject` directive into the `_ViewImports.cshtml` file in the `Views` directory. For more information on dependency injection into views see [Dependency injection into views](../../mvc/views/dependency-injection.md).

Once you have injected the authorization service you use it by calling the [`AuthorizeAsync`](http://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/AspNetCore/Authorization/IAuthorizationService/index.html#Microsoft.AspNetCore.Authorization.IAuthorizationService.AuthorizeAsync) method in exactly the same way as you would check during [resource based authorization](resourcebased.md#security-authorization-resource-based-imperative).

````csharp
@if (await AuthorizationService.AuthorizeAsync(User, "PolicyName"))
   {
       <p>This paragraph is displayed because you fulfilled PolicyName.</p>
   }
   ````

In some cases the resource will be your view model, and you can call [`AuthorizeAsync`](http://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/AspNetCore/Authorization/IAuthorizationService/index.html#Microsoft.AspNetCore.Authorization.IAuthorizationService.AuthorizeAsync) in exactly the same way as you would check during [resource based authorization](resourcebased.md#security-authorization-resource-based-imperative);

````csharp
@if (await AuthorizationService.AuthorizeAsync(User, Model, Operations.Edit))
   {
       <p><a class="btn btn-default" role="button"
           href="@Url.Action("Edit", "Document", new { id = Model.Id })">Edit</a></p>
   }
   ````

Here you can see the model is passed as the resource authorization should take into consideration.

>[!WARNING]
>Do not rely on showing or hiding parts of your UI as your only authorization method. Hiding a UI element does not mean a user cannot access it. You must also authorize the user within your controller code.
