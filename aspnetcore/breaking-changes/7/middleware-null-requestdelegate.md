---
title: "Breaking change: Middleware no longer defers to endpoint with null request delegate"
description: Learn about the breaking change in ASP.NET Core 7.0 where the file-serving middleware no longer no-op when the active endpoint has a null request delegate.
ms.date: 07/18/2022
ms.custom: https://github.com/aspnet/Announcements/issues/488
---
# Middleware no longer defers to endpoint with null request delegate

As detailed in <https://github.com/dotnet/aspnetcore/issues/42413>, the file-serving middleware (`DefaultFilesMiddleware`, `DirectoryBrowserMiddleware`, and `StaticFileMiddleware`) have been updated to no longer no-op (that is, defer to the next middleware in the pipeline) when there's an active endpoint with a `null` request delegate.

## Version introduced

ASP.NET Core 7.0

## Previous behavior

Previously, if the current request had an active endpoint, that is, `HttpContext.GetEndpoint() != null`, the file-serving middleware would perform no action and simply delegate to the next middleware in the request pipeline.

## New behavior

The file-serving middleware will now only perform no action if there's an active endpoint and its `RequestDelegate` property value is not `null`, that is, `HttpContext.GetEndpoint()?.RequestDelegate is not null`.

## Type of breaking change

This change affects [binary compatibility](/dotnet/core/compatibility/categories#binary-compatibility).

## Reason for change

This change enables endpoints to share metadata with endpoint-aware middleware while allowing other middleware that would otherwise defer to also function. Endpoints can be active in the request for the purposes of setting and sharing metadata with middleware that are endpoint-aware so that they can perform their intended function. Other middleware that would previously defer their behavior when an endpoint was active, for example, the file-serving middleware, can also function.

For example, an endpoint with a `null` request delegate containing authorization metadata can be set as the active endpoint for a request. This causes the `AuthorizationMiddleware` to enforce authorization requirements, which, if satisfied, would allow the `StaticFileMiddleware` to serve the requested files.

## Recommended action

If you rely on setting an active endpoint on the request to suppress the behavior of the file-serving middleware, ensure that the endpoint has a non-null value set for its `RequestDelegate` property.

## Affected APIs

- `IApplicationBuilder.UseStaticFiles()`
- `IApplicationBuilder.UseDefaultFiles()`
- `IApplicationBuilder.UseDirectoryBrowser()`
