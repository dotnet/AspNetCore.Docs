---
title: Script Tag Helper in ASP.NET Core
author: rick-anderson
ms.author: riande
description: Discover the ASP.NET Core Script Tag Helper attributes and the role each attribute plays in extending behavior of the HTML Script tag.
ms.custom: mvc
ms.date: 12/18/2018
uid: mvc/views/tag-helpers/builtin-th/script-tag-helper
---
# Script Tag Helper in ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT)

The [Script Tag Helper](xref:Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper) generates a link to a primary or fall back script file. Typically the primary script file is on a [Content Delivery Network](/office365/enterprise/content-delivery-networks#what-exactly-is-a-cdn) (CDN).

[!INCLUDE[](~/includes/cdn.md)]

The Script Tag Helper allows you to specify a CDN for the script file and a fallback when the CDN is not available. The Script Tag Helper provides the performance advantage of a CDN with the robustness of local hosting.

The following Razor markup shows the `script` element of a layout file created with the ASP.NET Core web app template:

[!code-html[](link-tag-helper/sample/_Layout.cshtml?name=snippet2)]

The following is similar to the rendered HTML from the preceding code (in a non-Development environment):

[!code-csharp[](link-tag-helper/sample/HtmlPage2.html)]

In the preceding code, the Script Tag Helper generated the second script ( `<script>  (window.jQuery || document.write(`) element, which tests for `window.jQuery`. If `window.jQuery` is not found, `document.write(` runs and creates a script 

## Commonly used Script Tag Helper attributes

See [Script Tag Helper](xref:Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper) for all the Script Tag Helper attributes, properties, and methods.

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
