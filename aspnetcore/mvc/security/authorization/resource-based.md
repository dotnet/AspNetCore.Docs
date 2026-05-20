---
title: Resource-based authorization in ASP.NET Core MVC
ai-usage: ai-assisted
author: wadepickett
description: Learn how to implement resource-based authorization in an ASP.NET Core MVC app when an [Authorize] attribute doesn't suffice.
ms.author: wpickett
ms.custom: mvc
ms.date: 05/05/2026
uid: mvc/security/authorization/resource-based
---
# Resource-based authorization in ASP.NET Core MVC

This article describes how to authorize users for access to app resources.

In an app, a *resource* is typically represented by a C# class that includes data stored in a collection, such as a [`byte[]` array](xref:System.Byte). The class usually contains additional metadata pertaining to the resource, such as a unique resource identifier, dates, authors, source information, and a friendly name for display in a UI. The collection that holds resource data is usually loaded from physical file content, a cloud storage object, an in-memory object, or data from a database.

Resource-based authorization requires special attention in ASP.NET Core apps. Attribute evaluation occurs before data binding and before execution of an action that loads a resource. Declarative authorization with an `[Authorize]` attribute doesn't suffice for resource-based authorization. Instead, the app must invoke a custom authorization method&mdash;an approach known as *imperative authorization*.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/security/authorization/resource-based) ([how to download](xref:fundamentals/index#how-to-download-a-sample)).

<xref:security/authorization/secure-data> contains a sample app that uses resource-based authorization.

Examples in this article use *primary constructors*, available in C# 12 (.NET 8) or later. For more information, see [Declare primary constructors for classes and structs (C# documentation tutorial)](/dotnet/csharp/whats-new/tutorials/primary-constructors) and [Primary constructors (C# Guide)](/dotnet/csharp/programming-guide/classes-and-structs/instance-constructors#primary-constructors). Sample apps that accompany the article that target versions of .NET earlier than .NET 8 use constructor injection.

## Use imperative authorization

Authorization is implemented as an <xref:Microsoft.AspNetCore.Authorization.IAuthorizationService>, which is registered in the service collection at app startup *by the ASP.NET Core framework*. The service is made available to classes and actions via [dependency injection](xref:fundamentals/dependency-injection). The following controller also injects a document repository, which the developer creates and registers in the service container to manage document operations:

```csharp
public class DocumentController(IAuthorizationService authorizationService,
    IDocumentRepository documentRepository) : Controller
{
    private readonly IAuthorizationService _authorizationService;
    private readonly IDocumentRepository _documentRepository;

    public DocumentController(IAuthorizationService authorizationService,
        IDocumentRepository documentRepository)
    {
        _authorizationService = authorizationService;
        _documentRepository = documentRepository;
    }

    ...
}
```

<xref:Microsoft.AspNetCore.Authorization.IAuthorizationService> has two <xref:Microsoft.AspNetCore.Authorization.IAuthorizationService.AuthorizeAsync%2A> method overloads. One of the overloads accepts a resource and policy name:

```csharp
Task<AuthorizationResult> AuthorizeAsync(
    ClaimsPrincipal user, 
    object resource, 
    string policyName);
```

The other overload accepts a resource and collection of requirements (<xref:Microsoft.AspNetCore.Authorization.IAuthorizationRequirement>) to evaluate:

```csharp
Task<AuthorizationResult> AuthorizeAsync(
    ClaimsPrincipal user, 
    object resource,
    IEnumerable<IAuthorizationRequirement> requirements);
```

In the following example, the secured resource is loaded into a custom `Document` object. An <xref:Microsoft.AspNetCore.Authorization.IAuthorizationService.AuthorizeAsync%2A> overload is invoked to determine whether the current user is allowed to edit the document via a custom "`EditPolicy`" authorization policy. If [`authorizationResult.Succeeded`](xref:Microsoft.AspNetCore.Authorization.AuthorizationResult.Succeeded%2A) is `true`, the user is authorized for the document because they authored the document (`Document.Author` matches the user's <xref:System.Security.Principal.IIdentity.Name%2A>).

> [!NOTE]
> The following example assumes successful authentication with the `User` property set.

```csharp
[HttpGet]
public async Task<IActionResult> Edit(Guid documentId)
{
    Document document = _documentRepository.Find(documentId);

    ...

    var authorizationResult = await _authorizationService
        .AuthorizeAsync(User, document, "EditPolicy");

    ...
}
```

## Create a resource-based handler

Creating a resource-based authorization handler is similar to [creating a plain requirements handler](xref:security/authorization/policies#security-authorization-policies-based-authorization-handler). Create a custom requirement class and implement a requirement handler class. For more information on creating a requirement class, see the [Policy-based authorization: Requirements](xref:security/authorization/policies#requirements).

The handler class specifies the requirement and resource type. The following example demonstrates a handler utilizing a `SameAuthorRequirement` requirement and a `Document` resource:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/resource-based/3.0/ResourceBasedAuthApp2/Services/DocumentAuthorizationHandler.cs" id="snippet_HandlerAndRequirement":::

In the preceding example, imagine that `SameAuthorRequirement` is a special case of a more generic `SpecificAuthorRequirement` class. The `SpecificAuthorRequirement` class (not shown) contains a `Name` property representing the name of the author. The `Name` property could be set to the current user.

:::moniker range=">= aspnetcore-6.0"

Register the requirement and handler in `Program.cs`:

```csharp
builder.Services.AddAuthorizationBuilder()
    .AddPolicy("EditPolicy", policy =>
        policy.Requirements.Add(new SameAuthorRequirement()));

builder.Services.AddSingleton<IAuthorizationHandler, DocumentAuthorizationHandler>();
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

Register the requirement and handler in `Startup.ConfigureServices`:

```csharp
services.AddAuthorization(options =>
{
    options.AddPolicy("EditPolicy", policy =>
        policy.Requirements.Add(new SameAuthorRequirement()));
});

services.AddSingleton<IAuthorizationHandler, DocumentAuthorizationHandler>();
```

:::moniker-end

For more information on creating authorization policies, see <xref:security/authorization/policies>.

### Operational requirements

To make decisions based on the outcomes of CRUD (Create, Read, Update, Delete) operations, use the <xref:Microsoft.AspNetCore.Authorization.Infrastructure.OperationAuthorizationRequirement> helper class. This class enables you to write a single handler instead of an individual class for each operation type. To use it, provide some operation names:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/resource-based/3.0/ResourceBasedAuthApp2/Services/DocumentAuthorizationCrudHandler.cs" id="snippet_OperationsClass":::

The handler is implemented as follows, using an <xref:Microsoft.AspNetCore.Authorization.Infrastructure.OperationAuthorizationRequirement> requirement and a `Document` resource:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/resource-based/3.0/ResourceBasedAuthApp2/Services/DocumentAuthorizationCrudHandler.cs" id="snippet_Handler":::

The preceding handler validates the operation using the resource, the user's identity, and the requirement's `Name` property.

## Challenge and forbid with an operational resource handler

This section shows how the challenge and forbid action results are processed and how challenge and forbid differ.

When authorization fails but the user is authenticated, the app can return a <xref:Microsoft.AspNetCore.Mvc.ForbidResult>, which informs authentication middleware that authorization failed. Return a <xref:Microsoft.AspNetCore.Mvc.ChallengeResult> for unauthenticated users. For interactive browser clients, it may be appropriate to redirect the user to a login page.

> [!NOTE]
> The following example assumes successful authentication with the `User` property set.

```csharp
if ((await _authorizationService
    .AuthorizeAsync(User, document, Operations.Read)).Succeeded)
{
    return View(document);
}
else if (User.Identity?.IsAuthenticated ?? false)
{
    return new ForbidResult();
}
else
{
    return new ChallengeResult();
}
```
