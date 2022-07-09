---
title: Partial Tag Helper in ASP.NET Core
author: rick-anderson
description: Discover the ASP.NET Core Partial Tag Helper and the role each of its attributes play in rendering a partial view.
monikerRange: '>= aspnetcore-2.1'
ms.author: scaddie
ms.custom: mvc
ms.date: 04/06/2019
uid: mvc/views/tag-helpers/builtin-th/partial-tag-helper
---
# Partial Tag Helper in ASP.NET Core

By [Scott Addie](https://github.com/scottaddie)

For an overview of Tag Helpers, see <xref:mvc/views/tag-helpers/intro>.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/mvc/views/tag-helpers/built-in/samples) ([how to download](xref:index#how-to-download-a-sample))

## Overview

The Partial Tag Helper is used for rendering a [partial view](xref:mvc/views/partial) in Razor Pages and MVC apps. Consider that it:

* Requires ASP.NET Core 2.1 or later.
* Is an alternative to [HTML Helper syntax](xref:mvc/views/partial#reference-a-partial-view).
* Renders the partial view asynchronously.

The HTML Helper options for rendering a partial view include:

* [`@await Html.PartialAsync`](xref:Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperPartialExtensions.PartialAsync%2A)
* [`@await Html.RenderPartialAsync`](xref:Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperPartialExtensions.RenderPartialAsync%2A)
* [`@Html.Partial`](xref:Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperPartialExtensions.Partial%2A)
* [`@Html.RenderPartial`](xref:Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperPartialExtensions.RenderPartial%2A)

The *Product* model is used in samples throughout this document:

[!code-csharp[](samples/TagHelpersBuiltIn/Models/Product.cs)]

An inventory of the Partial Tag Helper attributes follows.

## name

The `name` attribute is required. It indicates the name or the path of the partial view to be rendered. When a partial view name is provided, the [view discovery](xref:mvc/views/overview#view-discovery) process is initiated. That process is bypassed when an explicit path is provided. For all acceptable `name` values, see [Partial view discovery](xref:mvc/views/partial#partial-view-discovery).

The following markup uses an explicit path, indicating that `_ProductPartial.cshtml` is to be loaded from the *Shared* folder. Using the [for](#for) attribute, a model is passed to the partial view for binding.

[!code-cshtml[](samples/TagHelpersBuiltIn/Pages/Product.cshtml?name=snippet_Name)]

## for

The `for` attribute assigns a <xref:Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExpression> to be evaluated against the current model. A `ModelExpression` infers the `@Model.` syntax. For example, `for="Product"` can be used instead of `for="@Model.Product"`. This default inference behavior is overridden by using the `@` symbol to define an inline expression.

The following markup loads `_ProductPartial.cshtml`:

[!code-cshtml[](samples/TagHelpersBuiltIn/Pages/Product.cshtml?name=snippet_For)]

The partial view is bound to the associated page model's `Product` property:

[!code-csharp[](samples/TagHelpersBuiltIn/Pages/Product.cshtml.cs?highlight=8)]

## model

The `model` attribute assigns a model instance to pass to the partial view. The `model` attribute can't be used with the [for](#for) attribute.

In the following markup, a new `Product` object is instantiated and passed to the `model` attribute for binding:

[!code-cshtml[](samples/TagHelpersBuiltIn/Pages/Product.cshtml?name=snippet_Model)]

## view-data

The `view-data` attribute assigns a <xref:Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary> to pass to the partial view. The following markup makes the entire ViewData collection accessible to the partial view:

[!code-cshtml[](samples/TagHelpersBuiltIn/Pages/Product.cshtml?name=snippet_ViewData&highlight=5-)]

In the preceding code, the `IsNumberReadOnly` key value is set to `true` and added to the ViewData collection. Consequently, `ViewData["IsNumberReadOnly"]` is made accessible within the following partial view:

[!code-cshtml[](samples/TagHelpersBuiltIn/Pages/Shared/_ProductViewDataPartial.cshtml?highlight=5)]

In this example, the value of `ViewData["IsNumberReadOnly"]` determines whether the *Number* field is displayed as read only.

## Migrate from an HTML Helper

Consider the following asynchronous HTML Helper example. A collection of products is iterated and displayed. Per the `PartialAsync` method's first parameter, the `_ProductPartial.cshtml` partial view is loaded. An instance of the `Product` model is passed to the partial view for binding.

[!code-cshtml[](samples/TagHelpersBuiltIn/Pages/Products.cshtml?name=snippet_HtmlHelper&highlight=3)]

The following Partial Tag Helper achieves the same asynchronous rendering behavior as the `PartialAsync` HTML Helper. The `model` attribute is assigned a `Product` model instance for binding to the partial view.

[!code-cshtml[](samples/TagHelpersBuiltIn/Pages/Products.cshtml?name=snippet_TagHelper&highlight=3)]

## Additional resources

* <xref:mvc/views/partial>
* <xref:mvc/views/overview#weakly-typed-data-viewdata-viewdata-attribute-and-viewbag>
