---
title: Resource-based authorization in ASP.NET Core
author: rick-anderson
description: Learn how to implement resource-based authorization in an ASP.NET Core app when an Authorize attribute won't suffice.
ms.author: scaddie
ms.custom: mvc
ms.date: 11/15/2018
uid: security/authorization/resourcebased
---
# Resource-based authorization in ASP.NET Core

:::moniker range=">= aspnetcore-6.0"

Authorization approach depends on the resource. For example, only the author of a document is authorized to update the document. Consequently, the document must be retrieved from the data store before authorization evaluation can occur.

Attribute evaluation occurs before data binding and before execution of the page handler or action that loads the document. For these reasons, declarative authorization with an `[Authorize]` attribute doesn't suffice. Instead, you can invoke a custom authorization method&mdash;a style known as *imperative authorization*.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/security/authorization/resourcebased/samples/3_0) ([how to download](xref:index#how-to-download-a-sample)).

[Create an ASP.NET Core app with user data protected by authorization](xref:security/authorization/secure-data) contains a sample app that uses resource-based authorization.

## Use imperative authorization

Authorization is implemented as an <xref:Microsoft.AspNetCore.Authorization.IAuthorizationService> service and is registered in the service collection at application startup. The service is made available via [dependency injection](xref:fundamentals/dependency-injection) to page handlers or actions.

[!code-csharp[](resourcebased/samples/3_0/ResourceBasedAuthApp2/Controllers/DocumentController.cs?name=snippet_IAuthServiceDI&highlight=6)]

`IAuthorizationService` has two `AuthorizeAsync` method overloads: one accepting the resource and the policy name and the other accepting the resource and a list of requirements to evaluate.

```csharp
Task<AuthorizationResult> AuthorizeAsync(ClaimsPrincipal user,
                          object resource,
                          IEnumerable<IAuthorizationRequirement> requirements);
Task<AuthorizationResult> AuthorizeAsync(ClaimsPrincipal user,
                          object resource,
                          string policyName);
```

<a name="security-authorization-resource-based-imperative"></a>

In the following example, the resource to be secured is loaded into a custom `Document` object. An `AuthorizeAsync` overload is invoked to determine whether the current user is allowed to edit the provided document. A custom "EditPolicy" authorization policy is factored into the decision. See [Custom policy-based authorization](xref:security/authorization/policies) for more on creating authorization policies.

> [!NOTE]
> The following code samples assume authentication has run and set the `User` property.

[!code-csharp[](resourcebased/samples/3_0/ResourceBasedAuthApp2/Pages/Document/Edit.cshtml.cs?name=snippet_DocumentEditHandler)]

## Write a resource-based handler

Writing a handler for resource-based authorization isn't much different than [writing a plain requirements handler](xref:security/authorization/policies#security-authorization-policies-based-authorization-handler). Create a custom requirement class, and implement a requirement handler class. For more information on creating a requirement class, see [Requirements](xref:security/authorization/policies#requirements).

The handler class specifies both the requirement and resource type. For example, a handler utilizing a `SameAuthorRequirement` and a `Document` resource follows:

[!code-csharp[](resourcebased/samples/3_0/ResourceBasedAuthApp2/Services/DocumentAuthorizationHandler.cs?name=snippet_HandlerAndRequirement)]

In the preceding example, imagine that `SameAuthorRequirement` is a special case of a more generic `SpecificAuthorRequirement` class. The `SpecificAuthorRequirement` class (not shown) contains a `Name` property representing the name of the author. The `Name` property could be set to the current user.

Register the requirement and handler in `Program.cs`:

[!code-csharp[](resourcebased/samples/6_0/ResourceBasedAuthApp2/Program.cs?name=snippet_ConfigureServicesSample&highlight=4-8,10)]

### Operational requirements

If you're making decisions based on the outcomes of CRUD (Create, Read, Update, Delete) operations, use the <xref:Microsoft.AspNetCore.Authorization.Infrastructure.OperationAuthorizationRequirement> helper class. This class enables you to write a single handler instead of an individual class for each operation type. To use it, provide some operation names:

[!code-csharp[](resourcebased/samples/3_0/ResourceBasedAuthApp2/Services/DocumentAuthorizationCrudHandler.cs?name=snippet_OperationsClass)]

The handler is implemented as follows, using an `OperationAuthorizationRequirement` requirement and a `Document` resource:

[!code-csharp[](resourcebased/samples/3_0/ResourceBasedAuthApp2/Services/DocumentAuthorizationCrudHandler.cs?name=snippet_Handler)]

The preceding handler validates the operation using the resource, the user's identity, and the requirement's `Name` property.

## Challenge and forbid with an operational resource handler

This section shows how the challenge and forbid action results are processed and how challenge and forbid differ.

To call an operational resource handler, specify the operation when invoking `AuthorizeAsync` in your page handler or action. The following example determines whether the authenticated user is permitted to view the provided document.

> [!NOTE]
> The following code samples assume authentication has run and set the `User` property.

[!code-csharp[](resourcebased/samples/3_0/ResourceBasedAuthApp2/Pages/Document/View.cshtml.cs?name=snippet_DocumentViewHandler&highlight=10-11)]

If authorization succeeds, the page for viewing the document is returned. If authorization fails but the user is authenticated, returning `ForbidResult` informs any authentication middleware that authorization failed. A `ChallengeResult` is returned when authentication must be performed. For interactive browser clients, it may be appropriate to redirect the user to a login page.

:::moniker-end

:::moniker range=">= aspnetcore-3.0 < aspnetcore-6.0"

Authorization approach depends on the resource. For example, only the author of a document is authorized to update the document. Consequently, the document must be retrieved from the data store before authorization evaluation can occur.

Attribute evaluation occurs before data binding and before execution of the page handler or action that loads the document. For these reasons, declarative authorization with an `[Authorize]` attribute doesn't suffice. Instead, you can invoke a custom authorization method&mdash;a style known as *imperative authorization*.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/security/authorization/resourcebased/samples/3_0) ([how to download](xref:index#how-to-download-a-sample)).

[Create an ASP.NET Core app with user data protected by authorization](xref:security/authorization/secure-data) contains a sample app that uses resource-based authorization.

## Use imperative authorization

Authorization is implemented as an <xref:Microsoft.AspNetCore.Authorization.IAuthorizationService> service and is registered in the service collection within the `Startup` class. The service is made available via [dependency injection](xref:fundamentals/dependency-injection) to page handlers or actions.

[!code-csharp[](resourcebased/samples/3_0/ResourceBasedAuthApp2/Controllers/DocumentController.cs?name=snippet_IAuthServiceDI&highlight=6)]

`IAuthorizationService` has two `AuthorizeAsync` method overloads: one accepting the resource and the policy name and the other accepting the resource and a list of requirements to evaluate.

```csharp
Task<AuthorizationResult> AuthorizeAsync(ClaimsPrincipal user,
                          object resource,
                          IEnumerable<IAuthorizationRequirement> requirements);
Task<AuthorizationResult> AuthorizeAsync(ClaimsPrincipal user,
                          object resource,
                          string policyName);
```

<a name="security-authorization-resource-based-imperative"></a>

In the following example, the resource to be secured is loaded into a custom `Document` object. An `AuthorizeAsync` overload is invoked to determine whether the current user is allowed to edit the provided document. A custom "EditPolicy" authorization policy is factored into the decision. See [Custom policy-based authorization](xref:security/authorization/policies) for more on creating authorization policies.

> [!NOTE]
> The following code samples assume authentication has run and set the `User` property.

[!code-csharp[](resourcebased/samples/3_0/ResourceBasedAuthApp2/Pages/Document/Edit.cshtml.cs?name=snippet_DocumentEditHandler)]

## Write a resource-based handler

Writing a handler for resource-based authorization isn't much different than [writing a plain requirements handler](xref:security/authorization/policies#security-authorization-policies-based-authorization-handler). Create a custom requirement class, and implement a requirement handler class. For more information on creating a requirement class, see [Requirements](xref:security/authorization/policies#requirements).

The handler class specifies both the requirement and resource type. For example, a handler utilizing a `SameAuthorRequirement` and a `Document` resource follows:

[!code-csharp[](resourcebased/samples/3_0/ResourceBasedAuthApp2/Services/DocumentAuthorizationHandler.cs?name=snippet_HandlerAndRequirement)]

In the preceding example, imagine that `SameAuthorRequirement` is a special case of a more generic `SpecificAuthorRequirement` class. The `SpecificAuthorRequirement` class (not shown) contains a `Name` property representing the name of the author. The `Name` property could be set to the current user.

Register the requirement and handler in `Startup.ConfigureServices`:

[!code-csharp[](resourcebased/samples/3_0/ResourceBasedAuthApp2/Startup.cs?name=snippet_ConfigureServicesSample&highlight=4-8,10)]

### Operational requirements

If you're making decisions based on the outcomes of CRUD (Create, Read, Update, Delete) operations, use the <xref:Microsoft.AspNetCore.Authorization.Infrastructure.OperationAuthorizationRequirement> helper class. This class enables you to write a single handler instead of an individual class for each operation type. To use it, provide some operation names:

[!code-csharp[](resourcebased/samples/3_0/ResourceBasedAuthApp2/Services/DocumentAuthorizationCrudHandler.cs?name=snippet_OperationsClass)]

The handler is implemented as follows, using an `OperationAuthorizationRequirement` requirement and a `Document` resource:

[!code-csharp[](resourcebased/samples/3_0/ResourceBasedAuthApp2/Services/DocumentAuthorizationCrudHandler.cs?name=snippet_Handler)]

The preceding handler validates the operation using the resource, the user's identity, and the requirement's `Name` property.

## Challenge and forbid with an operational resource handler

This section shows how the challenge and forbid action results are processed and how challenge and forbid differ.

To call an operational resource handler, specify the operation when invoking `AuthorizeAsync` in your page handler or action. The following example determines whether the authenticated user is permitted to view the provided document.

> [!NOTE]
> The following code samples assume authentication has run and set the `User` property.

[!code-csharp[](resourcebased/samples/3_0/ResourceBasedAuthApp2/Pages/Document/View.cshtml.cs?name=snippet_DocumentViewHandler&highlight=10-11)]

If authorization succeeds, the page for viewing the document is returned. If authorization fails but the user is authenticated, returning `ForbidResult` informs any authentication middleware that authorization failed. A `ChallengeResult` is returned when authentication must be performed. For interactive browser clients, it may be appropriate to redirect the user to a login page.

:::moniker-end

:::moniker range="< aspnetcore-3.0"

Authorization approach depends on the resource. For example, only the author of a document is authorized to update the document. Consequently, the document must be retrieved from the data store before authorization evaluation can occur.

Attribute evaluation occurs before data binding and before execution of the page handler or action that loads the document. For these reasons, declarative authorization with an `[Authorize]` attribute doesn't suffice. Instead, you can invoke a custom authorization method&mdash;a style known as *imperative authorization*.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/security/authorization/resourcebased/samples/2_2) ([how to download](xref:index#how-to-download-a-sample)).

[Create an ASP.NET Core app with user data protected by authorization](xref:security/authorization/secure-data) contains a sample app that uses resource-based authorization.

## Use imperative authorization

Authorization is implemented as an <xref:Microsoft.AspNetCore.Authorization.IAuthorizationService> service and is registered in the service collection within the `Startup` class. The service is made available via [dependency injection](xref:fundamentals/dependency-injection) to page handlers or actions.

[!code-csharp[](resourcebased/samples/3_0/ResourceBasedAuthApp2/Controllers/DocumentController.cs?name=snippet_IAuthServiceDI&highlight=6)]

`IAuthorizationService` has two `AuthorizeAsync` method overloads: one accepting the resource and the policy name and the other accepting the resource and a list of requirements to evaluate.

```csharp
Task<AuthorizationResult> AuthorizeAsync(ClaimsPrincipal user,
                          object resource,
                          IEnumerable<IAuthorizationRequirement> requirements);
Task<AuthorizationResult> AuthorizeAsync(ClaimsPrincipal user,
                          object resource,
                          string policyName);
```

<a name="security-authorization-resource-based-imperative"></a>

In the following example, the resource to be secured is loaded into a custom `Document` object. An `AuthorizeAsync` overload is invoked to determine whether the current user is allowed to edit the provided document. A custom "EditPolicy" authorization policy is factored into the decision. See [Custom policy-based authorization](xref:security/authorization/policies) for more on creating authorization policies.

> [!NOTE]
> The following code samples assume authentication has run and set the `User` property.

[!code-csharp[](resourcebased/samples/3_0/ResourceBasedAuthApp2/Pages/Document/Edit.cshtml.cs?name=snippet_DocumentEditHandler)]

## Write a resource-based handler

Writing a handler for resource-based authorization isn't much different than [writing a plain requirements handler](xref:security/authorization/policies#security-authorization-policies-based-authorization-handler). Create a custom requirement class, and implement a requirement handler class. For more information on creating a requirement class, see [Requirements](xref:security/authorization/policies#requirements).

The handler class specifies both the requirement and resource type. For example, a handler utilizing a `SameAuthorRequirement` and a `Document` resource follows:

[!code-csharp[](resourcebased/samples/3_0/ResourceBasedAuthApp2/Services/DocumentAuthorizationHandler.cs?name=snippet_HandlerAndRequirement)]

In the preceding example, imagine that `SameAuthorRequirement` is a special case of a more generic `SpecificAuthorRequirement` class. The `SpecificAuthorRequirement` class (not shown) contains a `Name` property representing the name of the author. The `Name` property could be set to the current user.

Register the requirement and handler in `Startup.ConfigureServices`:

[!code-csharp[](resourcebased/samples/2_2/ResourceBasedAuthApp2/Startup.cs?name=snippet_ConfigureServicesSample&highlight=3-7,9)]

### Operational requirements

If you're making decisions based on the outcomes of CRUD (Create, Read, Update, Delete) operations, use the <xref:Microsoft.AspNetCore.Authorization.Infrastructure.OperationAuthorizationRequirement> helper class. This class enables you to write a single handler instead of an individual class for each operation type. To use it, provide some operation names:

[!code-csharp[](resourcebased/samples/3_0/ResourceBasedAuthApp2/Services/DocumentAuthorizationCrudHandler.cs?name=snippet_OperationsClass)]

The handler is implemented as follows, using an `OperationAuthorizationRequirement` requirement and a `Document` resource:

[!code-csharp[](resourcebased/samples/3_0/ResourceBasedAuthApp2/Services/DocumentAuthorizationCrudHandler.cs?name=snippet_Handler)]

The preceding handler validates the operation using the resource, the user's identity, and the requirement's `Name` property.

## Challenge and forbid with an operational resource handler

This section shows how the challenge and forbid action results are processed and how challenge and forbid differ.

To call an operational resource handler, specify the operation when invoking `AuthorizeAsync` in your page handler or action. The following example determines whether the authenticated user is permitted to view the provided document.

> [!NOTE]
> The following code samples assume authentication has run and set the `User` property.

[!code-csharp[](resourcebased/samples/3_0/ResourceBasedAuthApp2/Pages/Document/View.cshtml.cs?name=snippet_DocumentViewHandler&highlight=10-11)]

If authorization succeeds, the page for viewing the document is returned. If authorization fails but the user is authenticated, returning `ForbidResult` informs any authentication middleware that authorization failed. A `ChallengeResult` is returned when authentication must be performed. For interactive browser clients, it may be appropriate to redirect the user to a login page.

:::moniker-end
