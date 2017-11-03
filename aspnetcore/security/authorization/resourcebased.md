---
title: Resource-based authorization
author: rick-anderson
description: This document explains how to handle resource-based authorization in ASP.NET Core when an Authorize attribute won't suffice.
manager: wpickett
ms.author: riande
ms.custom: mvc
ms.date: 11/03/2017
ms.devlang: csharp
ms.prod: asp.net-core
ms.technology: aspnet
uid: security/authorization/resourcebased
---
# Resource-based authorization

By [Scott Addie](https://twitter.com/Scott_Addie)

Authorization strategy depends upon the resource being accessed. Consider a document which has an author property. Only the author is allowed to update the document. Consequently, the document must be retrieved from the data store before authorization evaluation can occur.

Attribute evaluation occurs before data binding and before execution of the action which loads a resource. For these reasons, declarative authorization with an `[Authorize]` attribute can't be used. Instead, imperative authorization is used&mdash;a developer invokes a custom authorization function.

## Authorize within your code

Authorization is implemented as an `IAuthorizationService` service and is registered in the service collection within the `Startup` class. The service is made available via [dependency injection](xref:fundamentals/dependency-injection#fundamentals-dependency-injection) for controllers to access.

```csharp
using Microsoft.AspNetCore.Authorization;

public class DocumentController : Controller
{
    private readonly IAuthorizationService _authorizationService;

    public DocumentController(IAuthorizationService authorizationService)
    {
        _authorizationService = authorizationService;
    }
}
```

`IAuthorizationService` has two `AuthorizeAsync` method overloads: one accepting the resource and the policy name and the other accepting the resource and a list of requirements to evaluate.

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

```csharp
Task<AuthorizationResult> AuthorizeAsync(ClaimsPrincipal user,
                          object resource,
                          IEnumerable<IAuthorizationRequirement> requirements);
Task<AuthorizationResult> AuthorizeAsync(ClaimsPrincipal user,
                          object resource,
                          string policyName);
```

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

```csharp
Task<bool> AuthorizeAsync(ClaimsPrincipal user,
                          object resource,
                          IEnumerable<IAuthorizationRequirement> requirements);
Task<bool> AuthorizeAsync(ClaimsPrincipal user,
                          object resource,
                          string policyName);
```

---

<a name="security-authorization-resource-based-imperative"></a>

In the following controller, the resource to be secured is loaded into a custom `Document` object. An `AuthorizeAsync` overload is invoked to determine whether the current user is allowed to edit the provided document. The "EditPolicy" authorization policy (not shown) is factored into the decision. See [Custom policy-based authorization](xref:security/authorization/policies) for more on creating authorization policies.

```csharp
public async Task<IActionResult> Edit(Guid documentId)
{
    Document document = documentRepository.Find(documentId);

    if (document == null)
    {
        return new HttpNotFoundResult();
    }

    if ((await _authorizationService.AuthorizeAsync(User, document, "EditPolicy")).Succeeded)
    {
        return View(document);
    }
    else
    {
        return new ChallengeResult();
    }
}
```

## Write a resource-based handler

Writing a handler for resource-based authorization isn't much different than [writing a plain requirements handler](xref:security/authorization/policies#security-authorization-policies-based-authorization-handler). After creating a custom requirement class, implement a requirement handler class. The handler class specifies both the requirement and resource type. For example, a handler utilizing a `MyRequirement` requirement and a `Document` resource looks as follows:

```csharp
public class DocumentAuthorizationHandler : AuthorizationHandler<MyRequirement, Document>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                   MyRequirement requirement,
                                                   Document resource)
    {
        // Validate the requirement against the resource and identity.

        return Task.CompletedTask;
    }
}

public class MyRequirement : IAuthorizationRequirement
{
    // code omitted for brevity
}
```

Don't forget to register the handler in the `Startup.ConfigureServices` method:

```csharp
services.AddSingleton<IAuthorizationHandler, DocumentAuthorizationHandler>();
```

### Operational requirements

If you're making decisions based on the outcomes of CRUD operations, use the native [OperationAuthorizationRequirement](/dotnet/api/microsoft.aspnetcore.authorization.infrastructure.operationauthorizationrequirement) helper class. This requirement class enables you to write a single handler. Its parameterized operation name eliminates the need to create individual classes for each operation type. To use it, provide some operation names:

```csharp
public static class Operations
{
    public static OperationAuthorizationRequirement Create =
        new OperationAuthorizationRequirement { Name = "Create" };
    public static OperationAuthorizationRequirement Read =
        new OperationAuthorizationRequirement { Name = "Read" };
    public static OperationAuthorizationRequirement Update =
        new OperationAuthorizationRequirement { Name = "Update" };
    public static OperationAuthorizationRequirement Delete =
        new OperationAuthorizationRequirement { Name = "Delete" };
}
```

The handler is implemented as follows, using a hypothetical `Document` class as the resource:

```csharp
public class DocumentAuthorizationHandler :
    AuthorizationHandler<OperationAuthorizationRequirement, Document>
{
    public override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                OperationAuthorizationRequirement requirement,
                                                Document resource)
    {
        // Validate the operation using the resource, the identity, and
        // the Name property value from the requirement.

        return Task.CompletedTask;
    }
}
```

The handler works on `OperationAuthorizationRequirement`. The code inside the handler must take the `Name` property of the supplied requirement into account when performing evaluations.

To call an operational resource handler, specify the operation when invoking `AuthorizeAsync` in your action. For example:

```csharp
if (await _authorizationService.AuthorizeAsync(User, document, Operations.Read))
{
    return View(document);
}
else
{
    return new ChallengeResult();
}
```

This example checks if the user is able to perform the read operation for the current `document` instance. If authorization succeeds, the view for the document is returned. If authorization fails, returning `ChallengeResult` informs any authentication middleware that authorization failed and the middleware can take the appropriate response. For example, returning a 401 or 403 status code, or redirecting the user to a login page for interactive browser clients.
