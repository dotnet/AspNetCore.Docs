---
title: "Breaking change: Response compression always emits Vary: Accept-Encoding"
ai-usage: ai-assisted
description: "Learn about the breaking change in ASP.NET Core 11 where the response compression middleware always appends Vary: Accept-Encoding to responses it sees, even when no compression was applied."
ms.date: 06/04/2026
---
# Response compression always emits Vary: Accept-Encoding

The response compression middleware now appends `Vary: Accept-Encoding` to every response that passes through it, including responses for which it didn't actually compress the body. Downstream caches see more correct cache keys, at the cost of slightly more cache variants when caches don't normalize the `Accept-Encoding` request header.

## Version introduced

.NET 11

## Previous behavior

Previously, the response compression middleware only appended `Vary: Accept-Encoding` to responses it actually compressed. Responses for which compression was skipped—for example, because the content type wasn't in `MimeTypes`, or because the client preferred `identity` encoding—were sent without the `Vary` header added by the middleware.

A downstream cache could therefore serve a compressed response that was stored for `Accept-Encoding: gzip` to a client that only accepted `identity` (and vice versa), unless the cache or the origin already added the header by another means.

## New behavior

Starting in ASP.NET Core 11, the response compression middleware appends `Vary: Accept-Encoding` to the response header collection for every response it sees, whether or not it compressed the body. If the header already contains `Accept-Encoding`, the middleware doesn't add a duplicate token.

## Type of breaking change

This change is a [behavioral change](/dotnet/core/compatibility/categories#behavioral-change).

## Reason for change

Without the `Vary: Accept-Encoding` header on every response, a shared cache can serve a stored encoded response to a client that doesn't accept that encoding. Adding the header unconditionally makes the middleware's response correctly cacheable by HTTP-compliant intermediaries. For more information, see [dotnet/aspnetcore#55092](https://github.com/dotnet/aspnetcore/pull/55092) and the issue it fixes, [dotnet/aspnetcore#48008](https://github.com/dotnet/aspnetcore/issues/48008).

## Recommended action

No source change is required. Verify that any downstream cache (CDN, reverse proxy, browser cache) normalizes the `Accept-Encoding` request header so it doesn't store an unnecessarily large number of variants. Most modern CDNs already do this.

If you don't want the middleware to add the header to a specific response, remove it after the middleware runs:

```csharp
app.UseResponseCompression();

app.Use(async (context, next) =>
{
    context.Response.OnStarting(() =>
    {
        // Remove the Vary header added by UseResponseCompression for a specific path.
        if (context.Request.Path.StartsWithSegments("/no-vary"))
        {
            context.Response.Headers.Remove("Vary");
        }
        return Task.CompletedTask;
    });
    await next();
});
```

## Affected APIs

- <xref:Microsoft.AspNetCore.ResponseCompression.ResponseCompressionMiddleware?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.Builder.ResponseCompressionBuilderExtensions.UseResponseCompression%2A?displayProperty=fullName>
