---
title: Resource-based authorization in ASP.NET Core
ai-usage: ai-assisted
author: wadepickett
description: Learn how to implement resource-based authorization in an ASP.NET Core app when an [Authorize] attribute doesn't suffice.
ms.author: wpickett
ms.custom: mvc
ms.date: 05/20/2026
uid: security/authorization/resource-based
---
# Resource-based authorization in ASP.NET Core

This article describes how to authorize users for access to app resources.

In an app, a *resource* is typically represented by a C# class that includes data stored in a collection, such as a [`byte[]` array](xref:System.Byte). The class usually contains additional metadata pertaining to the resource, such as a unique resource identifier, dates, authors, source information, and a friendly name for display in a UI. The collection that holds resource data is usually loaded from physical file content, a cloud storage object, an in-memory object, or data from a database.

Resource-based authorization requires special attention in ASP.NET Core apps. Attribute evaluation occurs before data binding and before execution of any method that loads a resource. Declarative authorization with an `[Authorize]` attribute doesn't suffice for resource-based authorization. Instead, the app must invoke a custom authorization method&mdash;an approach known as *imperative authorization*.

This article uses Razor component examples and focuses on [Blazor](xref:blazor/index) authorization scenarios for ASP.NET Core 3.1 or later. For Razor Pages and MVC guidance, which apply to all releases of ASP.NET Core, see the following resources:

* <xref:razor-pages/security/authorization/resource-based>
* <xref:mvc/security/authorization/resource-based>

Examples in this article use *primary constructors*, available in C# 12 (.NET 8) or later. For more information, see [Declare primary constructors for classes and structs (C# documentation tutorial)](/dotnet/csharp/whats-new/tutorials/primary-constructors) and [Primary constructors (C# Guide)](/dotnet/csharp/programming-guide/classes-and-structs/instance-constructors#primary-constructors).

## Sample app

The Blazor Web App sample for this article is the [`BlazorWebAppAuthorization` sample app (`dotnet/AspNetCore.Docs.Samples` GitHub repository)](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/security/authorization/BlazorWebAppAuthorization) ([how to download](xref:index#how-to-download-a-sample)). The sample app uses seeded accounts with preconfigured document objects to demonstrate the examples in this article. For more information, see the sample's README file (`README.md`).

> [!CAUTION]
> This sample app uses an in-memory database to store user information, which isn't suitable for production scenarios. The sample app is intended for demonstration purposes only and shouldn't be used as a starting point for production apps.

## Use imperative authorization

Authorization is implemented as an <xref:Microsoft.AspNetCore.Authorization.IAuthorizationService>, which is registered in the service collection at app startup *by the ASP.NET Core framework*. The service is made available to Razor components and other classes via [dependency injection](xref:fundamentals/dependency-injection):

```razor
@using Microsoft.AspNetCore.Authorization
@inject IAuthorizationService AuthorizationService
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

In the following example, which is fully explained in the [Create a resource-based handler](#create-a-resource-based-handler) section, the secured resource is loaded into a custom `Document` object. An <xref:Microsoft.AspNetCore.Authorization.IAuthorizationService.AuthorizeAsync%2A> overload is invoked to determine whether the current user is allowed access to the document based on the "`SameAuthorPolicy`" authorization policy. If [`authorizationResult.Succeeded`](xref:Microsoft.AspNetCore.Authorization.AuthorizationResult.Succeeded%2A) is `true`, the user is authorized for the document because they authored the document (`Document.Author` matches the user's <xref:System.Security.Principal.IIdentity.Name%2A>):

```csharp
protected override async Task OnParametersSetAsync()
{
    var user = (await AuthStateProvider.GetAuthenticationStateAsync()).User;

    if (user.Identity is not null && user.Identity.IsAuthenticated)
    {
        var document = DocumentRepository.Find(DocumentId);

        ...

        var authorizationResult = await AuthorizationService
            .AuthorizeAsync(user, document, "SameAuthorPolicy");

        ...
    }
}
```

## Create a resource-based handler

Creating a resource-based authorization handler is similar to [creating a plain requirements handler](xref:security/authorization/policies#security-authorization-policies-based-authorization-handler). Create a custom requirement class and implement a requirement handler class. For more information on creating a requirement class, see [Policy-based authorization: Requirements](xref:security/authorization/policies#requirements).

The following demonstration `Document` class is used:

```csharp
namespace BlazorWebAppAuthorization.Models;

public class Document
{
    public string? Author { get; set; }

    public byte[]? Content { get; set; }

    public Guid ID { get; set; }

    public string? Title { get; set; }
}
```

The handler class specifies the requirement and resource type. The following example demonstrates a handler utilizing a `SameAuthorRequirement` requirement and a `Document` resource.

`Services/DocumentAuthorizationHandler.cs`:

```csharp
using Microsoft.AspNetCore.Authorization;
using BlazorWebAppAuthorization.Models;

namespace BlazorWebAppAuthorization.Services;

public class DocumentAuthorizationHandler :
    AuthorizationHandler<SameAuthorRequirement, Document>
{
    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context, 
        SameAuthorRequirement requirement, 
        Document resource)
    {
        if (context.User.Identity?.Name == resource.Author)
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}

public class SameAuthorRequirement : IAuthorizationRequirement { }
```

:::moniker range=">= aspnetcore-6.0"

Register the requirement and handler in `Program.cs`:

```csharp
builder.Services.AddAuthorizationBuilder()
    .AddPolicy("SameAuthorPolicy", policy =>
        policy.Requirements.Add(new SameAuthorRequirement()));

builder.Services.AddSingleton<IAuthorizationHandler, DocumentAuthorizationHandler>();
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

Register the requirement and handler in `Startup.ConfigureServices`:

```csharp
services.AddAuthorization(options =>
{
    options.AddPolicy("SameAuthorPolicy", policy =>
        policy.Requirements.Add(new SameAuthorRequirement()));
});

services.AddSingleton<IAuthorizationHandler, DocumentAuthorizationHandler>();
```

:::moniker-end

For more information on creating authorization policies, see <xref:security/authorization/policies>.

The following `AccessDocument` component calls an <xref:Microsoft.AspNetCore.Authorization.IAuthorizationService.AuthorizeAsync%2A> overload to determine whether the current user is allowed to view a document based on the "`SameAuthorPolicy`" authorization policy. If [`authorizationResult.Succeeded`](xref:Microsoft.AspNetCore.Authorization.AuthorizationResult.Succeeded%2A) is `true`, the user is authorized for the document because they authored the document (`Document.Author` matches the user's <xref:System.Security.Principal.IIdentity.Name%2A>).

`Pages/AccessDocument.razor`:

```razor
@page "/access-document/{documentId}"
@using Microsoft.AspNetCore.Authorization
@using BlazorWebAppAuthorization.Data
@inject AuthenticationStateProvider AuthStateProvider
@inject IAuthorizationService AuthorizationService
@inject IDocumentRepository DocumentRepository

<h1>Access Document</h1>

<AuthorizeView>
    <Authorized>
        <p>Hello, @context.User.Identity?.Name!</p>
        <p>@message</p>
    </Authorized>
    <NotAuthorized>
        <p>You're not authorized to access this page.</p>
    </NotAuthorized>
</AuthorizeView>

@code {
    private string? message;

    [Parameter]
    public string? DocumentId { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        var user = (await AuthStateProvider.GetAuthenticationStateAsync()).User;

        if (user.Identity is not null && user.Identity.IsAuthenticated)
        {
            var document = DocumentRepository.Find(DocumentId);

            if (document == null)
            {
                message = "Document not found.";
                return;
            }

            var authorizationResult = await AuthorizationService
                .AuthorizeAsync(user, document, "SameAuthorPolicy");

            message = authorizationResult.Succeeded
                ? $"You are authorized for document {DocumentId}."
                : $"You are NOT authorized for document {DocumentId}.";
        }
    }
}
```

In the [sample app](#sample-app), each user of the app is authorized access to the seeded document that they authored.

## Operational requirements

To make decisions based on the outcomes of CRUD (Create, Read, Update, Delete) operations, use the <xref:Microsoft.AspNetCore.Authorization.Infrastructure.OperationAuthorizationRequirement> helper class. The helper class enables you to write a single handler instead of an individual class for each operation type. The following `Operations` class establishes all four CRUD operation types:

```csharp
using Microsoft.AspNetCore.Authorization.Infrastructure;

public static class Operations
{
    public static readonly OperationAuthorizationRequirement Create =
        new() { Name = nameof(Create) };
    public static readonly OperationAuthorizationRequirement Delete =
        new() { Name = nameof(Delete) };
    public static readonly OperationAuthorizationRequirement Read =
        new() { Name = nameof(Read) };
    public static readonly OperationAuthorizationRequirement Update =
        new() { Name = nameof(Update) };
}
```

The following `DocumentAuthorizationCrudHandler` authorization handler validates the operation using the resource, the user's identity (role) in some cases, and the requirement's `Name` property:

* All users can read documents.
* Only users in the `Admin` role can create and update documents.
* Only users in the `SuperUser` role can delete documents.

`Services/DocumentAuthorizationCrudHandler.cs`:

```csharp
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using BlazorWebAppAuthorization.Models;

namespace BlazorWebAppAuthorization.Services;

public class DocumentAuthorizationCrudHandler :
    AuthorizationHandler<OperationAuthorizationRequirement, Document>
{
    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        OperationAuthorizationRequirement requirement, 
        Document resource)
    {
        if (requirement.Name == Operations.Create.Name &&
            context.User.IsInRole("Admin"))
        {
            context.Succeed(requirement);
        }

        if (requirement.Name == Operations.Delete.Name &&
            context.User.IsInRole("SuperUser"))
        {
            context.Succeed(requirement);
        }

        if (requirement.Name == Operations.Read.Name)
        {
            context.Succeed(requirement);
        }

        if (requirement.Name == Operations.Update.Name &&
            context.User.IsInRole("Admin"))
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}
```

Where services are registered in the app:

```csharp
builder.Services.AddSingleton<IAuthorizationHandler, DocumentAuthorizationCrudHandler>();
```

Call the overload of <xref:Microsoft.AspNetCore.Authorization.IAuthorizationService.AuthorizeAsync%2A> with the operation to return the authorization result.

For authorization to *create* a document:

```csharp
var authorizationResult = await AuthorizationService
    .AuthorizeAsync(user, document, Operations.Create);
```

For authorization to *read* a document:

```csharp
var authorizationResult = await AuthorizationService
    .AuthorizeAsync(user, document, Operations.Read);
```

For authorization to *delete* a document:

```csharp
var authorizationResult = await AuthorizationService
    .AuthorizeAsync(user, document, Operations.Delete);
```

For authorization to *update* a document:

```csharp
var authorizationResult = await AuthorizationService
    .AuthorizeAsync(user, document, Operations.Update);
```

In the [sample app](#sample-app)'s `AccessDocumentCrud` page:

* Leela (`leela@contoso.com`), as an `Admin` and `SuperUser`, can perform full CRUD operations on resources.
* Harry (`harry@contoso.com`), as only an `Admin`, can create, read, and update resources.
* Sarah (`sarah@contoso.com`), as only a `SuperUser`, can delete and read resources.
