---
title: "Breaking change: Static files: CSV content type changed to standards-compliant"
description: "Learn about the breaking change in ASP.NET Core 5.0 titled Static files: CSV content type changed to standards-compliant"
ms.author: scaddie
ms.date: 10/01/2020
ms.custom: https://github.com/aspnet/Announcements/issues/395
---
# Static files: CSV content type changed to standards-compliant

In ASP.NET Core 5.0, the default `Content-Type` response header value that the [Static File Middleware](/aspnet/core/fundamentals/static-files) uses for *.csv* files has changed to the standards-compliant value `text/csv`.

For discussion on this issue, see [dotnet/aspnetcore#17385](https://github.com/dotnet/AspNetCore/issues/17385).

## Version introduced

5.0 Preview 1

## Old behavior

The `Content-Type` header value `application/octet-stream` was used.

## New behavior

The `Content-Type` header value `text/csv` is used.

## Reason for change

Compliance with the [RFC 7111](https://tools.ietf.org/html/rfc7111#section-5.1) standard.

## Recommended action

If this change impacts your app, you can customize the file extension-to-MIME type mapping. To revert to the `application/octet-stream` MIME type, modify the <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A> method call in `Startup.Configure`. For example:

```csharp
var provider = new FileExtensionContentTypeProvider();
provider.Mappings[".csv"] = MediaTypeNames.Application.Octet;

app.UseStaticFiles(new StaticFileOptions
{
    ContentTypeProvider = provider
});
```

For more information on customizing the mapping, see [FileExtensionContentTypeProvider](/aspnet/core/fundamentals/static-files#fileextensioncontenttypeprovider).

## Affected APIs

<xref:Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider?displayProperty=nameWithType>

<!--

### Category

ASP.NET Core

### Affected APIs

`T:Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider`

-->
