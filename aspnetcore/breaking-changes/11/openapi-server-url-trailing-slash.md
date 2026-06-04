---
title: "Breaking change: OpenAPI server URL no longer has a trailing slash when PathBase is empty"
description: "Learn about the breaking change in ASP.NET Core 11 where the generated OpenAPI document's servers[0].url no longer ends with a trailing slash when the request PathBase is empty."
ms.date: 06/04/2026
ai-usage: ai-assisted
---

# OpenAPI server URL no longer has a trailing slash when PathBase is empty

The server URL that ASP.NET Core writes into the generated OpenAPI document no longer ends with a trailing slash when the request <xref:Microsoft.AspNetCore.Http.HttpRequest.PathBase> is empty. Tooling or contract tests that string-compare `servers[0].url` need to be updated.

## Version introduced

.NET 11

## Previous behavior

Previously, `OpenApiDocumentService.GetOpenApiServers()` used `UriHelper.BuildAbsolute()`, which appends a trailing slash when both `pathBase` and `path` are empty. The generated OpenAPI document contained a `servers` entry with a trailing slash:

```json
{
  "servers": [
    { "url": "https://example.com/" }
  ]
}
```

## New behavior

Starting in ASP.NET Core 11, the trailing slash is stripped when `HttpRequest.PathBase.HasValue` is `false`. The generated OpenAPI document no longer includes the trailing slash:

```json
{
  "servers": [
    { "url": "https://example.com" }
  ]
}
```

If `PathBase` has an explicit value (for example, `/api`), the URL is unchanged and continues to include the path base.

## Type of breaking change

This change is a [behavioral change](/dotnet/core/compatibility/categories#behavioral-change).

## Reason for change

The previous behavior didn't match the OpenAPI 3.1.0 specification examples, which use server URLs without a trailing slash. The change aligns the generated document with the spec and avoids surprises in downstream tooling that's sensitive to the difference. For more information, see [dotnet/aspnetcore#64716](https://github.com/dotnet/aspnetcore/pull/64716).

## Recommended action

If your build pipeline or contract tests compare the generated OpenAPI document against a fixture, update the fixture to remove the trailing slash. If you use a code generator or SDK that constructs request URIs by concatenating the server URL with operation paths, verify that it produces the same URLs as before. Most generators normalize repeated slashes, but a few don't.

If you intentionally want the trailing slash (for example, to match an existing fixture), use an OpenAPI document transformer to write it back:

```csharp
builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer((document, context, ct) =>
    {
        foreach (var server in document.Servers ?? [])
        {
            if (!server.Url.EndsWith('/'))
            {
                server.Url += "/";
            }
        }
        return Task.CompletedTask;
    });
});
```

## Affected APIs

- <xref:Microsoft.AspNetCore.OpenApi.OpenApiRouteHandlerBuilderExtensions?displayProperty=fullName>
- Generated `servers[0].url` in the OpenAPI document produced by [`AddOpenApi`](/aspnet/core/fundamentals/openapi/aspnetcore-openapi).
