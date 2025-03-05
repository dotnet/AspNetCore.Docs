---
title: What's new in ASP.NET Core 10.0
author: rick-anderson
description: Learn about the new features in ASP.NET Core 10.0.
ms.author: riande
ms.custom: mvc
ms.date: 3/5/2025
uid: aspnetcore-10
---
# What's new in ASP.NET Core 10.0

This article highlights the most significant changes in ASP.NET Core 10.0 with links to relevant documentation.

This article will be updated as new preview releases are made available. See the [Asp.Net Core announcement page](https://github.com/aspnet/announcements/issues?q=is%3Aopen+is%3Aissue+milestone%3A1.0.0-rc2) until this page is updated.

<!-- New content should be added to ~/aspnetcore-9/includes/newFeatureName.md files. This will help prevent merge conflicts in this file. -->

## Blazor

This section describes new features for Blazor.

[!INCLUDE[](~/release-notes/aspnetcore-10/includes/blazor.md)]

## SignalR

This section describes new features for SignalR.

## Minimal APIs

This section describes new features for minimal APIs.

## OpenAPI

This section describes new features for OpenAPI.

[!INCLUDE[](~/release-notes/aspnetcore-10/includes/openApi.md)]

[!INCLUDE[](~/release-notes/aspnetcore-10/includes/responseDescProducesResponseType.md)]

## Authentication and authorization

This section describes new features for authentication and authorization.

## Miscellaneous

This section describes miscellaneous new features in ASP.NET Core 10.0.

[!INCLUDE[](~/release-notes/aspnetcore-10/includes/testAppsTopLevel.md)]

### Detect if URL is local using `RedirectHttpResult.IsLocalUrl`

Use the new [`RedirectHttpResult.IsLocalUrl(url)`](https://source.dot.net/#Microsoft.AspNetCore.Http.Results/RedirectHttpResult.cs,c0ece2e6266cb369) helper method to detect if a URL is local. A URL is considered local if the following are true:

- It doesn't have the [host](https://developer.mozilla.org/docs/Web/API/URL/host) or [authority](https://developer.mozilla.org/docs/Web/URI/Authority) section.
- It has an [absolute path](https://developer.mozilla.org/docs/Learn_web_development/Howto/Web_mechanics/What_is_a_URL#absolute_urls_vs._relative_urls).

URLs using [virtual paths](/previous-versions/aspnet/ms178116(v=vs.100)) `"~/"` are also local.

`IsLocalUrl` is useful for validating URLs before redirecting to them to prevent [open redirection attacks](https://brightsec.com/blog/open-redirect-vulnerabilities/).

```csharp
if (RedirectHttpResult.IsLocalUrl(url))
{
    return Results.LocalRedirect(url);
}
```

Thank you [@martincostello](https://github.com/martincostello) for this contribution!

## Related content
