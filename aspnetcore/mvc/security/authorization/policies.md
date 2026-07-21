---
title: Policy-based authorization in ASP.NET Core MVC
ai-usage: ai-assisted
author: wadepickett
description: Learn how to create and use authorization policy handlers for enforcing authorization requirements in an ASP.NET Core MVC app.
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.date: 07/10/2026
uid: mvc/security/authorization/policies
---
# Policy-based authorization in ASP.NET Core MVC

This article provides additional MVC policy-based authorization scenarios following <xref:security/authorization/policies>, which should be read before this article when learning about policy-based authorization.

## Apply policies to MVC controllers

Apply policies to controllers using the `[Authorize]` attribute with the policy name:

:::moniker range=">= aspnetcore-6.0"

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/policies/6.0/AuthorizationPoliciesSample/Controllers/AtLeast21Controller.cs" id="snippet" highlight="1":::

If multiple policies are applied at the controller and action levels, ***all*** policies must pass before access is granted:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/policies/6.0/AuthorizationPoliciesSample/Controllers/AtLeast21Controller2.cs" id="snippet" highlight="1,4":::

:::moniker-end

:::moniker range="< aspnetcore-6.0"

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/policies/PoliciesAuthApp1/Controllers/AlcoholPurchaseController.cs" id="snippet_AlcoholPurchaseControllerClass" highlight="4":::

:::moniker-end

## Access MVC request context in handlers

The <xref:Microsoft.AspNetCore.Authorization.AuthorizationHandler%601.HandleRequirementAsync%2A?displayProperty=nameWithType> method has two parameters: an <xref:Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext> and the `TRequirement` being handled. Frameworks such as MVC or SignalR are free to add any object to the <xref:Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext.Resource%2A?displayProperty=nameWithType> property to pass extra information.

When using endpoint routing, authorization is typically handled by the Authorization Middleware, and the <xref:Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext.Resource%2A> property is an instance of <xref:Microsoft.AspNetCore.Http.HttpContext>. The context is used to access the current endpoint, which can be used to probe the underlying resource to which you're routing:

```csharp
if (context.Resource is HttpContext httpContext)
{
    var endpoint = httpContext.GetEndpoint();
    var actionDescriptor = 
        endpoint?.Metadata.GetMetadata<ControllerActionDescriptor>();
    ...
}
```

With traditional routing, or when authorization happens as part of MVC's authorization filter, the value of <xref:Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext.Resource%2A> is an <xref:Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext> instance. This property provides access to <xref:Microsoft.AspNetCore.Http.HttpContext>, <xref:Microsoft.AspNetCore.Routing.RouteData>, and everything else provided by MVC and Razor Pages.

The use of the <xref:Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext.Resource%2A> property is framework-specific. Using information in the property limits your authorization policies to particular frameworks. Cast the property using the `is` keyword, and then confirm the cast has succeeded to ensure your code doesn't crash with an <xref:System.InvalidCastException> when run on other frameworks. When the cast succeeds, examine MVC-specific data, such as routing data:

```csharp
using Microsoft.AspNetCore.Mvc.Filters;

...

if (context.Resource is AuthorizationFilterContext mvcContext)
{
    var routeValues = mvcContext.RouteData.Values;
    ...
}
```

> [!NOTE]
> Endpoint routing passes <xref:Microsoft.AspNetCore.Routing.RouteEndpoint> to authorization handlers, unlike traditional routing in MVC apps, which use an authorization handler context resource of type <xref:Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext>. If the app uses MVC authorization filters along with endpoint routing authorization, it may be necessary to handle both types of resources.
