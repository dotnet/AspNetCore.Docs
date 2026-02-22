---
title: "Breaking change: Authorization: Resource in endpoint routing is HttpContext"
description: "Learn about the breaking change in ASP.NET Core 5.0 titled Authorization: Resource in endpoint routing is HttpContext"
ms.author: scaddie
ms.date: 10/01/2020
ms.custom: https://github.com/aspnet/Announcements/issues/423
---
# Authorization: Resource in endpoint routing is HttpContext

When using endpoint routing in ASP.NET Core 3.1, the resource used for authorization is the endpoint. This approach was insufficient for gaining access to the route data (<xref:Microsoft.AspNetCore.Routing.RouteData>). Previously in MVC, an <xref:Microsoft.AspNetCore.Http.HttpContext> resource was passed in, which allows access to both the endpoint (<xref:Microsoft.AspNetCore.Http.Endpoint>) and the route data. This change ensures that the resource passed to authorization is always the `HttpContext`.

## Version introduced

ASP.NET Core 5.0

## Old behavior

When using endpoint routing and the authorization middleware (<xref:Microsoft.AspNetCore.Authorization.AuthorizationMiddleware>) or [[Authorize]](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) attributes, the resource passed to authorization is the matching endpoint.

## New behavior

Endpoint routing passes the `HttpContext` to authorization.

## Reason for change

You can get to the endpoint from the `HttpContext`. However, there was no way to get from the endpoint to things like the route data. There was a loss in functionality from non-endpoint routing.

## Recommended action

If your app uses the endpoint resource, call <xref:Microsoft.AspNetCore.Http.EndpointHttpContextExtensions.GetEndpoint%2A> on the `HttpContext` to continue accessing the endpoint.

You can revert to the old behavior with <xref:System.AppContext.SetSwitch%2A>. For example:

```csharp
AppContext.SetSwitch(
    "Microsoft.AspNetCore.Authorization.SuppressUseHttpContextAsAuthorizationResource",
    isEnabled: true);
```

## Affected APIs

None

<!--

### Category

ASP.NET Core

### Affected APIs

Not detectable via API analysis

-->
