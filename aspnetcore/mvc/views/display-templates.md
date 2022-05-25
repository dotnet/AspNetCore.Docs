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

# Display and Editor templates in ASP.NET Core

By [Alexander Wicht](https://github.com/Ducki/)

Display and Editor templates specify the user interface layout of custom types. Consider the following `Address` model:

[!code-csharp[](display-templates/sample/Address.cs)]

A project that [scaffolds](xref:razor-pages/model#scaffold-the-movie-model) the `Address` model displays the `Address` in the following form:

![view of default scaffolding layout](display-templates/_static/addr.png)

A web site could use a Display Template to show the `Address` in standard format:

![view of default scaffolding layout](display-templates/_static/addr2.png)

Display and Editor templates can also reduce code duplication and maintenance costs. Consider a web site that displays the `Address` model on 20 different pages. If the `Address` model changes, the 20 pages will all need to be updated. If a Display Template is used for the `Address` model, only the Display Template needs to be updated. For example, the model might want to include the country.

[Tag Helpers](xref:mvc/views/tag-helpers/intro) provide an alternative way enable server-side code to participate in creating and rendering HTML elements in Razor files. For more information, see [Tag Helpers compared to HTML Helpers](xref:mvc/views/tag-helpers/intro#tag-helpers-compared-to-html-helpers).

## Display templates

*DisplayTemplates* are a way to customize the display of model fields or create a layer of abstraction between the model values and their display.

A *DisplayTemplate* is a [Razor](xref:mvc/views/razor) file placed in the`DisplayTemplates`folder:

* For Razor Pages apps, in the `Pages/Shared/DisplayTemplates` folder.
* For MVC apps, in the `Views//Shared/DisplayTemplates` folder or the `Views/ControllerName/DisplayTemplates` folder.

By convention, the *DisplayTemplate* file is named after the type to be displayed. The `Address.cshtml` template used in this sample:

[!code-cshtml[](display-templates/sample/Pages/Shared/DisplayTemplates/Address.cshtml)]

<!--
You can use them for built-in types, like `DateTime` or your own types.

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
-->