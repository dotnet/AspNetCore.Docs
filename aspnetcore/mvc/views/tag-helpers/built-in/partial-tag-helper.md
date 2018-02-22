---
title: Partial Tag Helper
author: scaddie
description: Discover the ASP.NET Core Partial Tag Helper and the role each of its attributes play in rendering a partial view.
manager: wpickett
ms.author: scaddie
ms.custom: mvc
ms.date: 02/22/2018
ms.prod: aspnet-core
ms.technology: aspnet
ms.topic: article
uid: mvc/views/tag-helpers/builtin-th/partial-tag-helper
---
# Partial Tag Helper

By [Scott Addie](https://github.com/scottaddie)

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/mvc/views/tag-helpers/built-in/samples) ([how to download](xref:tutorials/index#how-to-download-a-sample))

The Partial Tag Helper is supported as of ASP.NET Core 2.1. It offers an alternative to [HTML Helper syntax](xref:mvc/views/partial#referencing-a-partial-view) for rendering a [partial view](xref:mvc/views/partial) in Razor Pages or MVC.

An inventory of this Tag Helper's attributes follows.

## asp-for

The `asp-for` attribute assigns an expression to be evaluated against the current model. The following markup loads *_ProductPartial.cshtml*, binding to it the model's `Product` property:

[!code-cshtml[](samples/TagHelpersBuiltIn/Pages/Product.cshtml?name=snippet_AspFor)]

## name

The `name` attribute is required. It indicates the name or the path of the partial view to be rendered. When a partial view name is provided, the [view discovery](xref:mvc/views/overview#view-discovery) process is initiated. That process is bypassed when an explicit path is provided.

The following markup uses an explicit path, indicating that *_ProductPartial.cshtml* is to be loaded from the *Shared* folder. Using the [asp-for](#asp-for) attribute, a model is passed to the partial view for binding.

[!code-cshtml[](samples/TagHelpersBuiltIn/Pages/Product.cshtml?name=snippet_Name)]

## view-data

The `view-data` attribute assigns a [ViewDataDictionary](/dotnet/api/microsoft.aspnetcore.mvc.viewfeatures.viewdatadictionary) to pass to the partial view. The following markup makes the entire ViewData collection accessible to the partial view:

[!code-cshtml[](samples/TagHelpersBuiltIn/Pages/Product.cshtml?name=snippet_ViewData&highlight=5-)]

Notice that the `IsNumberReadOnly` key is set to `true` and added to the ViewData collection. Consequently, `ViewData["IsNumberReadOnly"]` is made accessible within the partial view:

[!code-cshtml[](samples/TagHelpersBuiltIn/Pages/Shared/_ProductViewDataPartial.cshtml?highlight=5)]

In this example, the value of `ViewData["IsNumberReadOnly"]` determines whether the *Number* field is displayed as read only.

## Additional resources

* [Partial views](xref:mvc/views/partial)
* [Weakly-typed data (ViewData and ViewBag)](xref:mvc/views/overview#weakly-typed-data-viewdata-and-viewbag)