---
uid: mvc/overview/older-versions-1/views/creating-custom-html-helpers-vb
title: "Creating Custom HTML Helpers (VB) | Microsoft Docs"
author: microsoft
description: "The goal of this tutorial is to demonstrate how you can create custom HTML Helpers that you can use within your MVC views. By taking advantage of HTML Helper..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 10/07/2008
ms.topic: article
ms.assetid: f96f4800-19ef-44c0-b457-55e777eb5de8
ms.technology: dotnet-mvc
ms.prod: .net-framework
msc.legacyurl: /mvc/overview/older-versions-1/views/creating-custom-html-helpers-vb
msc.type: authoredcontent
---
Creating Custom HTML Helpers (VB)
====================
by [Microsoft](https://github.com/microsoft)

[Download PDF](http://download.microsoft.com/download/1/1/f/11f721aa-d749-4ed7-bb89-a681b68894e6/ASPNET_MVC_Tutorial_9_VB.pdf)

> The goal of this tutorial is to demonstrate how you can create custom HTML Helpers that you can use within your MVC views. By taking advantage of HTML Helpers, you can reduce the amount of tedious typing of HTML tags that you must perform to create a standard HTML page.


The goal of this tutorial is to demonstrate how you can create custom HTML Helpers that you can use within your MVC views. By taking advantage of HTML Helpers, you can reduce the amount of tedious typing of HTML tags that you must perform to create a standard HTML page.

In the first part of this tutorial, I describe some of the existing HTML Helpers included with the ASP.NET MVC framework. Next, I describe two methods of creating custom HTML Helpers: I explain how to create custom HTML Helpers by creating a shared method and by creating an extension method.

## Understanding HTML Helpers

An HTML Helper is just a method that returns a string. The string can represent any type of content that you want. For example, you can use HTML Helpers to render standard HTML tags like HTML `<input>` and `<img>` tags. You also can use HTML Helpers to render more complex content such as a tab strip or an HTML table of database data.

The ASP.NET MVC framework includes the following set of standard HTML Helpers (this is not a complete list):

- Html.ActionLink()
- Html.BeginForm()
- Html.CheckBox()
- Html.DropDownList()
- Html.EndForm()
- Html.Hidden()
- Html.ListBox()
- Html.Password()
- Html.RadioButton()
- Html.TextArea()
- Html.TextBox()

For example, consider the form in Listing 1. This form is rendered with the help of two of the standard HTML Helpers (see Figure 1). This form uses the `Html.BeginForm()` and `Html.TextBox()` Helper methods.


[![Page rendered with HTML Helpers](creating-custom-html-helpers-vb/_static/image2.png)](creating-custom-html-helpers-vb/_static/image1.png)

**Figure 01**: Page rendered with HTML Helpers ([Click to view full-size image](creating-custom-html-helpers-vb/_static/image3.png))


**Listing 1 – `Views\Home\Index.aspx`**

[!code-aspx[Main](creating-custom-html-helpers-vb/samples/sample1.aspx)]

The `Html.BeginForm()` Helper method is used to create the opening and closing HTML `<form>` tags. Notice that the `Html.BeginForm()` method is called within a using statement. The using statement ensures that the `<form>` tag gets closed at the end of the using block.

If you prefer, instead of creating a using block, you can call the Html.EndForm() Helper method to close the `<form>` tag. Use whichever approach to creating an opening and closing `<form>` tag that seems most intuitive to you.

The `Html.TextBox()` Helper methods are used in Listing 1 to render HTML `<input>` tags. If you select view source in your browser then you see the HTML source in Listing 2. Notice that the source contains standard HTML tags.

> [!IMPORTANT]
> notice that the `Html.TextBox()`-HTML Helper is rendered with `<%= %>` tags instead of `<% %>` tags. If you don't include the equal sign, then nothing gets rendered to the browser.

The ASP.NET MVC framework contains a small set of helpers. Most likely, you will need to extend the MVC framework with custom HTML Helpers. In the remainder of this tutorial, you learn two methods of creating custom HTML Helpers.

**Listing 2 – `Index.aspx Source`**

[!code-aspx[Main](creating-custom-html-helpers-vb/samples/sample2.aspx)]

### Creating HTML Helpers with Shared Methods

The easiest way to create a new HTML Helper is to create a shared method that returns a string. Imagine, for example, that you decide to create a new HTML Helper that renders an HTML `<label>` tag. You can use the class in Listing 2 to render a `<label>`.

**Listing 2 – `Helpers\LabelHelper.vb`**

[!code-vb[Main](creating-custom-html-helpers-vb/samples/sample3.vb)]

There is nothing special about the class in Listing 2. The `Label()` method simply returns a string.

The modified Index view in Listing 3 uses the `LabelHelper` to render HTML `<label>` tags. Notice that the view includes an `<%@ imports %>` directive that imports the Application1.Helpers namespace.

**Listing 2 – `Views\Home\Index2.aspx`**

[!code-aspx[Main](creating-custom-html-helpers-vb/samples/sample4.aspx)]

### Creating HTML Helpers with Extension Methods

If you want to create HTML Helpers that work just like the standard HTML Helpers included in the ASP.NET MVC framework then you need to create extension methods. Extension methods enable you to add new methods to an existing class. When creating an HTML Helper method, you add new methods to the `HtmlHelper` class represented by a view's Html property.

The Visual Basic module in Listing 3 adds an extension method named `Label()` to the `HtmlHelper` class. There are a couple of things that you should notice about this module. First, notice that the module is decorated with the `<Extension()>` attribute. In order to use this attribute, you must import the `System.Runtime.CompilerServices` namespace

Second, notice that the first parameter of the `Label()` method represents the `HtmlHelper` class. The first parameter of an extension method indicates the class that the extension method extends.

**Listing 3 – `Helpers\LabelExtensions.vb`**

[!code-vb[Main](creating-custom-html-helpers-vb/samples/sample5.vb)]

After you create an extension method, and build your application successfully, the extension method appears in Visual Studio Intellisense like all of the other methods of a class (see Figure 2). The only difference is that extension methods appear with a special symbol next to them (an icon of a downward arrow).


[![Using the Html.Label() extension method](creating-custom-html-helpers-vb/_static/image5.png)](creating-custom-html-helpers-vb/_static/image4.png)

**Figure 02**: Using the Html.Label() extension method  ([Click to view full-size image](creating-custom-html-helpers-vb/_static/image6.png))


The modified Index view in Listing 4 uses the Html.Label() extension method to render all of its &lt;label&gt; tags.

**Listing 4 – `Views\Home\Index3.aspx`**

[!code-aspx[Main](creating-custom-html-helpers-vb/samples/sample6.aspx)]

## Summary

In this tutorial, you learned two methods of creating custom HTML Helpers. First, you learned how to create a custom `Label()` HTML Helper by creating a shared method that returns a string. Next, you learned how to create a custom `Label()` HTML Helper method by creating an extension method on the `HtmlHelper` class.

In this tutorial, I focused on building an extremely simple HTML Helper method. Realize that an HTML Helper can be as complicated as you want. You can build HTML Helpers that render rich content such as tree views, menus, or tables of database data.

>[!div class="step-by-step"]
[Previous](asp-net-mvc-views-overview-vb.md)
[Next](using-the-tagbuilder-class-to-build-html-helpers-vb.md)