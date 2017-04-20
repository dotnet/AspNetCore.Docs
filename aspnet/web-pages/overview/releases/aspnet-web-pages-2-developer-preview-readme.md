---
uid: web-pages/overview/releases/aspnet-web-pages-2-developer-preview-readme
title: "ASP.NET Web Pages 2 Developer Preview ReadMe | Microsoft Docs"
author: microsoft
description: ""
ms.author: aspnetcontent
manager: wpickett
ms.date: 09/14/2011
ms.topic: article
ms.assetid: 159a92e2-e011-4da7-b61d-2edde2a967da
ms.technology: dotnet-webpages
ms.prod: .net-framework
msc.legacyurl: /web-pages/overview/releases/aspnet-web-pages-2-developer-preview-readme
msc.type: authoredcontent
---
ASP.NET Web Pages 2 Developer Preview ReadMe
====================
by [Microsoft](https://github.com/microsoft)

## ASP.NET Web Pages 2 Developer Preview ReadMe

14 September 2011

### Contents

#### <a id="_Toc303701284"></a>  Installation Notes

To install Web Pages 2 Developer Preview, you have these options:

- Install WebMatrix 2 Beta using the [Web Platform Installer](https://go.microsoft.com/fwlink/?LinkId=226883). WebMatrix is a set of free web development tools that includes ASP.NET Web Pages. For more information, see the installation section in [The Top Features in ASP.NET Web Pages 2 Developer Preview](https://go.microsoft.com/fwlink/?LinkID=227824).

- Install Web Pages 2 Developer Preview directly using the [download link](https://go.microsoft.com/fwlink/?LinkID=226335). Use this approach if you want to create Web Pages applications using a text editor such as Notepad. In order to run Web Pages 2 applications, you must have IIS Express 7.5. (This is included automatically with WebMatrix.) For tips on how to test a Web Pages page using IIS Express, see the sidebar "Creating and Testing ASP.NET Pages Using Your Own Text Editor" in [Getting Started with WebMatrix and ASP.NET Web Pages](https://go.microsoft.com/fwlink/?LinkId=202889).

ASP.NET Web Pages 2 Developer Preview can be installed and can run side-by-side with ASP.NET Web Pages 1. <a id="a"></a>For details, see the section "Running Web Pages Applications Side-by-Side" in [The Top Features in Web Pages 2 Developer Preview](https://go.microsoft.com/fwlink/?LinkID=227824).

#### <a id="_Toc303701285"></a>  Documentation

Tutorials and other information about ASP.NET Web Pages are available on the Web Pages page of the ASP.NET website ([https://www.asp.net/web-pages/](../../index.md)). For information about new features and enhancements in Web Pages 2, see [The Top Features in Web Pages 2 Developer Preview](https://go.microsoft.com/fwlink/?LinkID=227824).

#### <a id="_Toc303701286"></a>  Support

<a id="_Toc209852135"></a><a id="_Toc255833657"></a> This is a preview release and is not officially supported. If you have questions about working with this release, post them to the ASP.NET Web Pages forum ([https://forums.asp.net/1224.aspx/1?WebMatrix](https://forums.asp.net/1224.aspx/1?WebMatrix) ), where members of the ASP.NET community are frequently able to provide informal support.

#### <a id="_Toc303701287"></a>  Software Requirements

ASP.NET Web Pages 2 requires the .NET Framework 4. It also works with the .NET Framework 4.5 Developer Preview release.

<a id="_Toc303701288"></a><a id="_Breaking_Changes"></a>

#### Fixes, Known Issues, and Breaking Changes

<a id="_Toc224729061"></a><a id="_Toc238051347"></a>

- **Is\* methods (for example, IsDateTime) now return correct values for all cultures.** Some methods like *IsDateTime* previously returned *false* when they should have returned *true* because they were previously performing culture-specific checks. These methods have been fixed to now take culture into account. This is a breaking change; if your application relies on the old behavior, it will break.
- **The behavior of the Href method has changed.** Previously, calling Href("~/SomeFile") would return a URL relative to the currently executing file. Now Href("~/SomeFile") always returns an absolute path from the root of the application. For most cases, this behavior won't make a difference in the return value. This change was made to fix certain Ajax scenarios. For example, consider the following example code: 

    [!code-cshtml[Main](aspnet-web-pages-2-developer-preview-readme/samples/sample1.cshtml)]

    This code previously would resolve to Images/Logo.jpg, which would be incorrect for an Ajax request to that page. It will now resolve to the root of the (/MySite/Images/Logo.jpg).
- **The HttpContext.RedirectLocal method has changed**. This method now accepts only URLs that are relative to the current application. Fully qualified URLs are rejected.
- **The ModelState.IsValid method now requires you to call Validate first**. If you are converting your application to use the new input validation methods and are calling the *ModelState.IsValid* method, you must now call *Validation.Validate* beforehand. For example, you must now follow this pattern: 

    [!code-csharp[Main](aspnet-web-pages-2-developer-preview-readme/samples/sample2.cs)]

 However, we recommend that if you use the new input validation methods, don't use *ModelState.IsValid*. Instead, structure your code like this: 

    [!code-csharp[Main](aspnet-web-pages-2-developer-preview-readme/samples/sample3.cs)]
- **On Internet Explorer 7 and Internet Explorer 8, client-side validation does not work**. Client-side validation does not work due to incompatibilities with jQuery 1.6.2, which is included with the default project template. (Server-side validation works.).

#### <a id="_Toc303701289"></a>  Disclaimer

© 2011 Microsoft Corporation. All rights reserved. This document is provided "as-is." Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it.