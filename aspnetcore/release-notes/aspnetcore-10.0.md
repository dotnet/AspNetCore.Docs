---
title: What's new in ASP.NET Core in .NET 10
author: wadepickett
description: Learn about the new features in ASP.NET Core in .NET 10.
ms.author: wpickett
ms.custom: mvc
ms.date: 08/14/2025
uid: aspnetcore-10
---
# What's new in ASP.NET Core in .NET 10

This article highlights the most significant changes in ASP.NET Core in .NET 10 with links to relevant documentation.

This article will be updated as new preview releases are made available. For breaking changes, see [Breaking changes in .NET](/dotnet/core/compatibility/10.0#aspnet-core).

## Blazor

This section describes new features for Blazor.

[!INCLUDE[](~/release-notes/aspnetcore-10/includes/blazor.md)]

## Blazor Hybrid

This section describes new features for Blazor Hybrid.

[!INCLUDE[](~/release-notes/aspnetcore-10/includes/blazor-hybrid.md)]

## SignalR

This section describes new features for SignalR.

## Minimal APIs

This section describes new features for minimal APIs.

[!INCLUDE[](~/release-notes/aspnetcore-10/includes/MinApiEmptyStringInFormPost.md)]

[!INCLUDE[](~/release-notes/aspnetcore-10/includes/ValidationSupportMinAPI.md)]

[!INCLUDE[](~/release-notes/aspnetcore-10/includes/MinimalAPIValidationRecordTypes.md)]

[!INCLUDE[](~/release-notes/aspnetcore-10/includes/validation-with-problem.md)]

[!INCLUDE[](~/release-notes/aspnetcore-10/includes/sse.md)]

[!INCLUDE[](~/release-notes/aspnetcore-10/includes/validation-package-move.md)]

[!INCLUDE[](~/release-notes/aspnetcore-10/includes/enhance-validation-classes-records.md)]

## OpenAPI

This section describes new features for OpenAPI.

[!INCLUDE[](~/release-notes/aspnetcore-10/includes/openApi.md)]

[!INCLUDE[](~/release-notes/aspnetcore-10/includes/responseDescProducesResponseType.md)]

[!INCLUDE[](~/release-notes/aspnetcore-10/includes/OpenApiPopulateXMLDocComments.md)]

[!INCLUDE[](~/release-notes/aspnetcore-10/includes/webapiaotTemplateAddedOpenAPI.md)]

[!INCLUDE[](~/release-notes/aspnetcore-10/includes/doc-provider-in-di.md)]

[!INCLUDE[](~/release-notes/aspnetcore-10/includes/xml-comment-generator.md)]

[!INCLUDE[](~/release-notes/aspnetcore-10/includes/formdata-enum-parameters.md)]

[!INCLUDE[](~/release-notes/aspnetcore-10/includes/OpenApiSchemasInTransformers.md)]

[!INCLUDE[](~/release-notes/aspnetcore-10/includes/upgrade-microsoft-openapi-2.md)]

## Authentication and authorization

### Authentication and authorization metrics

Metrics have been added for certain authentication and authorization events in ASP.NET Core. With this change, you can now obtain metrics for the following events:

* Authentication:
  * Authenticated request duration
  * Challenge count
  * Forbid count
  * Sign in count
  * Sign out count
* Authorization:
  * Count of requests requiring authorization

The following image shows an example of the Authenticated request duration metric in the Aspire dashboard:

![Authenticated request duration in the Aspire dashboard](https://github.com/user-attachments/assets/170615e9-ef25-48a1-a482-4933e2e03f03)

For more information, see <xref:log-mon/metrics/built-in#microsoftaspnetcoreauthorization>.

[!INCLUDE[](~/release-notes/aspnetcore-10/includes/avoid-cookie-login-redirects.md)]

## Miscellaneous

This section describes miscellaneous new features in .NET 10.

[!INCLUDE[](~/release-notes/aspnetcore-10/includes/exception-handler.md)]

[!INCLUDE[](~/release-notes/aspnetcore-10/includes/top-level-domain.md)]

[!INCLUDE[](~/release-notes/aspnetcore-10/includes/pipe-reader.md)]

[!INCLUDE[](~/release-notes/aspnetcore-10/includes/memory-eviction.md)]

[!INCLUDE[](~/release-notes/aspnetcore-10/includes/httpsys.md)]

[!INCLUDE[](~/release-notes/aspnetcore-10/includes/testAppsTopLevel.md)]

[!INCLUDE[](~/release-notes/aspnetcore-10/includes/jsonPatch.md)]

### Detect if URL is local using `RedirectHttpResult.IsLocalUrl`

Use the new [`RedirectHttpResult.IsLocalUrl(url)`](https://source.dot.net/#Microsoft.AspNetCore.Http.Results/RedirectHttpResult.cs,c0ece2e6266cb369) helper method to detect if a URL is local. A URL is considered local if the following are true:

* It doesn't have the [host](https://developer.mozilla.org/docs/Web/API/URL/host) or [authority](https://developer.mozilla.org/docs/Web/URI/Authority) section.
* It has an [absolute path](https://developer.mozilla.org/docs/Learn_web_development/Howto/Web_mechanics/What_is_a_URL#absolute_urls_vs._relative_urls).

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

<xref:fundamentals/servers/httpsys>
