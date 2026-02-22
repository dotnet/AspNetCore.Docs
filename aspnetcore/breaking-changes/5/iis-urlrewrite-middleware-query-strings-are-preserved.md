---
title: "Breaking change: IIS: UrlRewrite middleware query strings are preserved"
description: "Learn about the breaking change in ASP.NET Core 5.0 titled IIS: UrlRewrite middleware query strings are preserved"
ms.author: scaddie
ms.date: 10/01/2020
ms.custom: https://github.com/aspnet/Announcements/issues/420
---
# IIS: UrlRewrite middleware query strings are preserved

An IIS UrlRewrite middleware defect prevented the query string from being preserved in rewrite rules. That defect has been fixed to maintain consistency with the IIS UrlRewrite Module's behavior.

For discussion, see issue [dotnet/aspnetcore#22972](https://github.com/dotnet/aspnetcore/issues/22972).

## Version introduced

ASP.NET Core 5.0

## Old behavior

Consider the following rewrite rule:

```xml
<rule name="MyRule" stopProcessing="true">
  <match url="^about" />
  <action type="Redirect" url="/contact" redirectType="Temporary" appendQueryString="true" />
</rule>
```

The preceding rule doesn't append the query string. A URI like `/about?id=1` redirects to `/contact` instead of `/contact?id=1`. The `appendQueryString` attribute defaults to `true` as well.

## New behavior

The query string is preserved. The URI from the example in [Old behavior](#old-behavior) would be `/contact?id=1`.

## Reason for change

The old behavior didn't match the IIS UrlRewrite Module's behavior. To support porting between the middleware and module, the goal is to maintain consistent behaviors.

## Recommended action

If the behavior of removing the query string is preferred, set the `action` element to `appendQueryString="false"`.

## Affected APIs

<xref:Microsoft.AspNetCore.Rewrite.IISUrlRewriteOptionsExtensions.AddIISUrlRewrite%2A?displayProperty=nameWithType>

<!--

### Category

ASP.NET Core

### Affected APIs

`Overload:Microsoft.AspNetCore.Rewrite.IISUrlRewriteOptionsExtensions.AddIISUrlRewrite`

-->
