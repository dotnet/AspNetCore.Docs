---
title: Resource-based authorization
author: rick-anderson
description: This document explains how to handle resource-based authorization in ASP.NET Core when an Authorize attribute won't suffice.
manager: wpickett
ms.author: scaddie
ms.custom: mvc
ms.date: 11/07/2017
ms.devlang: csharp
ms.prod: asp.net-core
ms.technology: aspnet
uid: security/authorization/resourcebased
---
# Resource-based authorization

By [Scott Addie](https://twitter.com/Scott_Addie)

Authorization strategy depends upon the resource being accessed. Consider a document which has an author property. Only the author is allowed to update the document. Consequently, the document must be retrieved from the data store before authorization evaluation can occur.

Attribute evaluation occurs before data binding and before execution of the action which loads the document. For these reasons, declarative authorization with an `[Authorize]` attribute won't suffice. Instead, you can invoke a custom authorization method&mdash;a style known as imperative authorization.

Use the [sample apps](https://github.com/aspnet/Docs/tree/master/aspnetcore/security/authorization/razor-pages/resourcebased/samples) ([how to download](xref:tutorials/index#how-to-download-a-sample)) to explore the features described in this topic.

## Use imperative authorization

Authorization is implemented as an [IAuthorizationService](/dotnet/api/microsoft.aspnetcore.authorization.iauthorizationservice) service and is registered in the service collection within the `Startup` class. The service is made available via [dependency injection](xref:fundamentals/dependency-injection#fundamentals-dependency-injection) for controllers to access.

[!code-csharp[](resourcebased/samples/ResourceBasedAuthApp2/Controllers/DocumentController.cs?name=snippet_IAuthServiceDI&highlight=6)]

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

In the following controller, the resource to be secured is loaded into a custom `Document` object. An `AuthorizeAsync` overload is invoked to determine whether the current user is allowed to edit the provided document. A custom "EditPolicy" authorization policy is factored into the decision. See [Custom policy-based authorization](xref:security/authorization/policies) for more on creating authorization policies.

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

[!code-csharp[](resourcebased/samples/ResourceBasedAuthApp2/Controllers/DocumentController.cs?name=snippet_DocumentEditAction)]

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

[!code-csharp[](resourcebased/samples/ResourceBasedAuthApp1/Controllers/DocumentController.cs?name=snippet_DocumentEditAction)]

---

## Write a resource-based handler

Writing a handler for resource-based authorization isn't much different than [writing a plain requirements handler](xref:security/authorization/policies#security-authorization-policies-based-authorization-handler). After creating a custom requirement class, implement a requirement handler class. The handler class specifies both the requirement and resource type. For example, a handler utilizing a `SameAuthorRequirement` requirement and a `Document` resource looks as follows:

[!code-csharp[](resourcebased/samples/ResourceBasedAuthApp2/Services/DocumentAuthorizationHandler.cs?name=snippet_HandlerAndRequirement)]

Don't forget to register the requirement and handler in the `Startup.ConfigureServices` method:

[!code-csharp[](resourcebased/samples/ResourceBasedAuthApp2/Startup.cs?name=snippet_ConfigureServicesSample&highlight=3-7,9)]

### Operational requirements

If you're making decisions based on the outcomes of CRUD (**C**reate, **R**ead, **U**pdate, **D**elete) operations, use the native [OperationAuthorizationRequirement](/dotnet/api/microsoft.aspnetcore.authorization.infrastructure.operationauthorizationrequirement) helper class. This requirement class enables you to write a single handler instead of an individual class for each operation type. To use it, provide some operation names:

[!code-csharp[](resourcebased/samples/ResourceBasedAuthApp2/Services/DocumentAuthorizationCrudHandler.cs?name=snippet_OperationsClass)]

The handler is implemented as follows, using a `Document` class as the resource:

[!code-csharp[](resourcebased/samples/ResourceBasedAuthApp2/Services/DocumentAuthorizationCrudHandler.cs?name=snippet_Handler)]

The handler works on `OperationAuthorizationRequirement`. The code inside the handler must take the `Name` property of the supplied requirement into account when performing evaluations.

To call an operational resource handler, specify the operation when invoking `AuthorizeAsync` in your action. For example:

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

[!code-csharp[](resourcebased/samples/ResourceBasedAuthApp2/Controllers/DocumentController.cs?name=snippet_DocumentViewAction&highlight=11)]

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

[!code-csharp[](resourcebased/samples/ResourceBasedAuthApp1/Controllers/DocumentController.cs?name=snippet_DocumentViewAction&highlight=11)]

---

The preceding example checks if the user is able to perform the read operation for the provided document. If authorization succeeds, the view for the document is returned. If authorization fails, returning `ChallengeResult` informs any authentication middleware that authorization failed, and the middleware can take the appropriate response. An appropriate response could be returning a 401 or 403 status code. For interactive browser clients, it could mean redirecting the user to a login page.
