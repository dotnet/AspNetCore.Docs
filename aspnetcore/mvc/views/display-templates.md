---
title: Using DisplayTemplates and EditorTemplates
author: Ducki
ms.author: riande
description: How to use DisplayTemplates and EditorTemplates in ASP.NET Core.
monikerRange: '>= aspnetcore-2.1'
ms.date: 05/22/2022
no-loc: ["DisplayTemplate", "EditorTemplate", Home, Model, "Page Model", "Razor Pages"]
uid: mvc/views/display-templates
---

# Display  and Editor templates in ASP.NET Core

By [Alexander Wicht](https://github.com/Ducki/)

## Display templates

*DisplayTemplates* are a way to customize the display of model fields or create a layer of abstraction between your model values and their display.

A *DisplayTemplate* is a [Razor](xref:mvc/views/razor) markup file (`.cshtml`) file placed in a folder called `DisplayTemplates` in the *Shared* folder of your *Pages* or *Views* folder (depending on whether you are using Razor Pages or MVC).

> [!NOTE]
> As of now, the name of the folder cannot be changed.

By convention, the *DisplayTemplate* file is named after the type you want to create the template for. You can use them for built-in types, like `DateTime` or your own types.

For example, a DisplayTemplate for `DateTime` would be called `DateTime.cshtml` and look like this:
```csharp
@model System.DateTime
<span>
@Model.ToString("yyyy-MM-dd")
</span>
```

The view engine automatically looks up the file in the `DisplayTemplates` folder that matches the name of the type. If it does not find anything, it will fall back to just display the value.

To reference a template whose name does not match the type name, use the `templateName` parameter in the `DisplayFor` method. For example, if we have a template file called `AlternativePerson.cshtml`:
[!code-cshtml[](display-templates/sample/Pages/Index.cshtml?name=snippet_htmlDisplayForTemplate)]

### Custom Models

Consider this custom type `Person`:
[!code-csharp[](display-templates/sample/Models/Person.cs?name=snippet_PersonModel)]

In this case, the `Person` model is a property on the page model. A *DisplayTemplate* `Person.cshtml` for this type could look like this:
[!code-cshtml[](display-templates/sample/Pages/Shared/DisplayTemplates/Person.cshtml)]

Invoke your custom *DisplayTemplate* by calling:
[!code-cshtml[](display-templates/sample/Pages/Index.cshtml?name=snippet_htmlDisplayFor)]

> [!NOTE]
> The [ASP.NET Core scaffolding engine](xref:fundamentals/tools/dotnet-aspnet-codegenerator) outputs templates that use the <xref:Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperDisplayExtensions.DisplayFor*> method as well.

Use one of the available [overloads of the method](xref:Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperDisplayExtensions.DisplayFor*#overloads) that expose the `additionalViewData` parameter if you need to pass additional view data that will be merged into the [View Data Dictionary](xref:mvc/views/overview#viewdata) instance created for the template.

## Editor templates
You can also use templates for form controls. They are called *EditorTemplates* and work the same way as *DisplayTemplates*. The only difference is the name of the folder: instead of *DisplayTemplates*, you need to call it *EditorTemplates*.

To reference them, use the <xref:Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperEditorExtensions.EditorFor*> HTML helper, for example:
[!code-cshtml[](display-templates/sample/Pages/Index.cshtml?name=snippet_htmlEditorFor)]

> [!TIP]
> There is also a <xref:Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperDisplayExtensions.DisplayForModel*> and <xref:Microsoft.AspNetCore.Mvc.Rendering.HtmlHelperEditorExtensions.EditorForModel*> method, which are similar to DisplayFor and EditorFor, but they work with the model of the current view. That means, you can map a template directly to the whole Page Model (or [View Model](xref:mvc/views/overview#strongly-typed-data-viewmodel) when used in an MVC View).

## Additional resources

* [View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/mvc/views/display-templates/sample) ([how to download](xref:index#how-to-download-a-sample))