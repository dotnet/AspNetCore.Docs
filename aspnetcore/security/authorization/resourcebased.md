---
title: Resource Based Authorization
author: rick-anderson
description: 
keywords: ASP.NET Core,
ms.author: riande
manager: wpickett
ms.date: 10/14/2016
ms.topic: article
ms.assetid: 0902ba17-5304-4a12-a2d4-e0904569e988
ms.technology: aspnet
ms.prod: asp.net-core
uid: security/authorization/resourcebased
---
# Resource Based Authorization

<a name=security-authorization-resource-based></a>

Often authorization depends upon the resource being accessed. For example, a document may have an author property. Only the document author would be allowed to update it, so the resource must be loaded from the document repository before an authorization evaluation can be made. This cannot be done with an Authorize attribute, as attribute evaluation takes place before data binding and before your own code to load a resource runs inside an action. Instead of declarative authorization, the attribute method, we must use imperative authorization, where a developer calls an authorize function within their own code.

## Authorizing within your code

Authorization is implemented as a service, `IAuthorizationService`, registered in the service collection and available via [dependency injection](../../fundamentals/dependency-injection.md#fundamentals-dependency-injection) for Controllers to access.

```csharp
public class DocumentController : Controller
{
    IAuthorizationService _authorizationService;

    public DocumentController(IAuthorizationService authorizationService)
    {
        _authorizationService = authorizationService;
    }
}
```

`IAuthorizationService` has two methods, one where you pass the resource and the policy name and the other where you pass the resource and a list of requirements to evaluate.

```csharp
Task<bool> AuthorizeAsync(ClaimsPrincipal user,
                          object resource,
                          IEnumerable<IAuthorizationRequirement> requirements);
Task<bool> AuthorizeAsync(ClaimsPrincipal user,
                          object resource,
                          string policyName);
```

<a name=security-authorization-resource-based-imperative></a>

To call the service, load your resource within your action then call the `AuthorizeAsync` overload you require. For example:

```csharp
public async Task<IActionResult> Edit(Guid documentId)
{
    Document document = documentRepository.Find(documentId);

    if (document == null)
    {
        return new HttpNotFoundResult();
    }

    if (await _authorizationService.AuthorizeAsync(User, document, "EditPolicy"))
    {
        return View(document);
    }
    else
    {
        return new ChallengeResult();
    }
}
```

## Writing a resource based handler

Writing a handler for resource based authorization is not that much different to [writing a plain requirements handler](policies.md#security-authorization-policies-based-authorization-handler). You create a requirement, and then implement a handler for the requirement, specifying the requirement as before and also the resource type. For example, a handler which might accept a Document resource would look as follows:

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
```

Don't forget you also need to register your handler in the `ConfigureServices` method:

```csharp
services.AddSingleton<IAuthorizationHandler, DocumentAuthorizationHandler>();
```

### Operational Requirements

If you are making decisions based on operations such as read, write, update and delete, you can use the `OperationAuthorizationRequirement` class in the `Microsoft.AspNetCore.Authorization.Infrastructure` namespace. This prebuilt requirement class enables you to write a single handler which has a parameterized operation name, rather than create individual classes for each operation. To use it, provide some operation names:

```csharp
public static class Operations
{
    public static OperationAuthorizationRequirement Create =
        new OperationAuthorizationRequirement { Name = "Create" };
    public static OperationAuthorizationRequirement Read =
        new OperationAuthorizationRequirement   { Name = "Read" };
    public static OperationAuthorizationRequirement Update =
        new OperationAuthorizationRequirement { Name = "Update" };
    public static OperationAuthorizationRequirement Delete =
        new OperationAuthorizationRequirement { Name = "Delete" };
}
```

Your handler could then be implemented as follows, using a hypothetical `Document` class as the resource:

```csharp
public class DocumentAuthorizationHandler :
    AuthorizationHandler<OperationAuthorizationRequirement, Document>
{
    public override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                OperationAuthorizationRequirement requirement,
                                                Document resource)
    {
        // Validate the operation using the resource, the identity and
        // the Name property value from the requirement.

        return Task.CompletedTask;
    }
}
```

You can see the handler works on `OperationAuthorizationRequirement`. The code inside the handler must take the Name property of the supplied requirement into account when making its evaluations.

To call an operational resource handler you need to specify the operation when calling `AuthorizeAsync` in your action. For example:

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

This example checks if the User is able to perform the Read operation for the current `document` instance. If authorization succeeds the view for the document will be returned. If authorization fails returning `ChallengeResult` will inform any authentication middleware authorization has failed and the middleware can take the appropriate response, for example returning a 401 or 403 status code, or redirecting the user to a login page for interactive browser clients.
