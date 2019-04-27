---
title: Link Tag Helper in ASP.NET Core
author: pkellner
description: Discover the ASP.NET Core Link Tag Helper attributes and the role each attribute plays in extending behavior of the HTML Link tag.
ms.author: scaddie
ms.custom: mvc
ms.date: 12/18/2018
uid: mvc/views/tag-helpers/builtin-th/link-tag-helper
---
# Link Tag Helper in ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT)

The [Link Tag Helper](xref:Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper) generates a link to a primary or fall back CSS file. Typically the primary CSS file is on a [Content Delivery Network](/office365/enterprise/content-delivery-networks#what-exactly-is-a-cdn) (CDN).

[!INCLUDE[](~/includes/cdn.md)]

The Link Tag Helper allows you to specify a CDN for the CSS file and a fallback when the CDN is not available. The Link Tag Helper provides the performance advantage of a CDN with the robustness of local hosting.

The following Razor markup shows the `head` element of a layout file created with the ASP.NET Core web app template:

[!code-html[](link-tag-helper/sample/_Layout.cshtml?name=snippet)]

The following code shows the rendered HTML from the preceding code (in a non-Development environment):

[!code-csharp[](link-tag-helper/sample/HtmlPage1.html)]

In the preceding code, the Link Tag Helper generated the `<meta name="x-stylesheet-fallback-test" content="" class="sr-only" />` element and the following JavaScript which is used to verify the requested *bootstrap.min.css* file is available on the CDN. In this case, the CSS file was available so the Tag Helper generated the `<link />` element with the CDN CSS file.

## Commonly used Link Tag Helper attributes

### href

Preferred address of the linked resource. The address is passed thought to the generated HTML in all cases.

### asp-fallback-href

The URL of a CSS stylesheet to fallback to in the case the primary URL fails.

### asp-fallback-test-class

The class name defined in the stylesheet to use for the fallback test. For more information, see <xref:Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper.FallbackTestClass>.

### asp-fallback-test-property

The CSS property name to use for the fallback test. For more information, see <xref:Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper.FallbackTestProperty>.

### asp-fallback-test-value

The CSS property value to use for the fallback test. For more information, see <xref:Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper.FallbackTestValue>.

### asp-fallback-test-value

The CSS property value to use for the fallback test. For more information, see <xref:Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper.FallbackTestValue>

## Additional resources

* <xref:mvc/views/tag-helpers/intro>
* <xref:mvc/controllers/areas>
* <xref:razor-pages/index>
* <xref:mvc/compatibility-version>
