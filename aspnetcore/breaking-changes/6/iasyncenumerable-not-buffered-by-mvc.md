---
title: "Breaking change: MVC no longer buffers IAsyncEnumerable types when using System.Text.Json"
description: "Learn about the breaking change in ASP.NET Core 6.0 where MVC no longer buffers IAsyncEnumerable return types when formatting using System.Text.Json."
ms.date: 05/17/2021
ms.custom: https://github.com/aspnet/Announcements/issues/463
---
# MVC doesn't buffer IAsyncEnumerable types when using System.Text.Json

In ASP.NET Core 5, MVC added support for output formatting <xref:System.Collections.Generic.IAsyncEnumerable%601> types by buffering the sequence in memory and formatting the buffered collection. In ASP.NET Core 6, when formatting using <xref:System.Text.Json?displayProperty=fullName>, MVC no longer buffers <xref:System.Collections.Generic.IAsyncEnumerable%601> instances. Instead, MVC relies on the support that <xref:System.Text.Json?displayProperty=fullName> added for these types.

In most cases, the absence of buffering would not be observable by the application. However, some scenarios may have inadvertently relied on the buffering semantics to correctly serialize. For example, returning an <xref:System.Collections.Generic.IAsyncEnumerable%601> that's backed by an Entity Framework query on a type with lazy-loaded properties can result in concurrent query execution, which might not be supported by the provider.

This change does not affect output formatting using Newtonsoft.Json or with XML-based formatters.

## Version introduced

ASP.NET Core 6.0

## Old behavior

<xref:System.Collections.Generic.IAsyncEnumerable%601> instances returned from an MVC action as a value to be formatted using <xref:System.Data.Objects.ObjectResult> or a <xref:System.Web.Mvc.JsonResult> are buffered before being serialized as a synchronous collection.

## New behavior

When formatting using <xref:System.Text.Json?displayProperty=fullName>, MVC no longer buffers <xref:System.Collections.Generic.IAsyncEnumerable%601> instances.

## Reason for change

<xref:System.Text.Json?displayProperty=fullName> added support for streaming <xref:System.Collections.Generic.IAsyncEnumerable%601> types. This allows for a smaller memory footprint during serialization.

## Recommended action

If your application requires buffering, consider manually buffering the <xref:System.Collections.Generic.IAsyncEnumerable%601> object:

```csharp
// Before
public IActionResult Get()
{
    return Ok(dbContext.Blogs);
}

// After
public async Task<IActionResult> Get()
{
    return Ok(await dbContext.Blogs.ToListAsync());
}
```

<!--

## Category

ASP.NET Core

## Affected APIs

Not detectable via API analysis

-->
