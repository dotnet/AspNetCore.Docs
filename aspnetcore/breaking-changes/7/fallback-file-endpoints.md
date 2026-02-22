---
title: "Breaking change: Fallback file endpoints"
description: Learn about the breaking change in ASP.NET Core 7.0 where endpoints configured with 'MapFallbackToFile()' now only match 'HEAD' and 'GET' requests.
ms.date: 10/10/2022
ms.custom: https://github.com/aspnet/Announcements/issues/495
---
# Fallback file endpoints

The <xref:Microsoft.AspNetCore.Mvc.ConsumesAttribute> attribute allows controller actions to specify their supported content types. Starting in .NET 6, if a fallback file endpoint was configured, it could match routes that were discarded because the request had a different content type than what was specified in an action's <xref:Microsoft.AspNetCore.Mvc.ConsumesAttribute>. The .NET 6 behavior was an undesirable change from the .NET 5 behavior. This breaking change partially addresses the issue by making fallback file endpoints only match `GET` and `HEAD` requests.

## Version introduced

ASP.NET Core 7.0 RC 2

## Previous behavior

Endpoints configured with <xref:Microsoft.AspNetCore.Builder.StaticFilesEndpointRouteBuilderExtensions.MapFallbackToFile%2A?displayProperty=nameWithType> matched requests made with any request method.

## New behavior

Endpoints configured with <xref:Microsoft.AspNetCore.Builder.StaticFilesEndpointRouteBuilderExtensions.MapFallbackToFile%2A?displayProperty=nameWithType> only match `HEAD` and `GET` requests.

## Type of breaking change

This change can affect [binary compatibility](/dotnet/core/compatibility/categories#binary-compatibility).

## Reason for change

This change partially reverts a larger breaking change accidentally introduced in .NET 6. Since it's highly unusual to expect a fallback file response when making a request with a method other than `HEAD` or `GET`, the impact of this breaking change should be minimal.

## Recommended action

If you want fallback file endpoints to match requests with methods other than HEAD or GET, you can specify additional HTTP request methods using `WithMetadata()`. For example:

```csharp
endpoints.MapFallbackToFile("index.html")
    .WithMetadata(new HttpMethodMetadata(new[] { /* List supported methods here */ }));
```

## Affected APIs

- <xref:Microsoft.AspNetCore.Builder.StaticFilesEndpointRouteBuilderExtensions.MapFallbackToFile%2A?displayProperty=fullName>
