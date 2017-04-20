---
uid: web-forms/overview/older-versions-getting-started/aspnet-ajax/understanding-asp-net-ajax-localization
title: "Understanding ASP.NET AJAX Localization | Microsoft Docs"
author: scottcate
description: "Localization is the process of designing and integrating support for a specific language and culture into an application or an application component. The Mic..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 03/14/2008
ms.topic: article
ms.assetid: c1a35f18-bab9-41f7-8497-15530c37a09d
ms.technology: dotnet-webforms
ms.prod: .net-framework
msc.legacyurl: /web-forms/overview/older-versions-getting-started/aspnet-ajax/understanding-asp-net-ajax-localization
msc.type: authoredcontent
---
Understanding ASP.NET AJAX Localization
====================
by [Scott Cate](https://github.com/scottcate)

[Download PDF](http://download.microsoft.com/download/C/1/9/C19A3451-1D14-477C-B703-54EF22E197EE/AJAX_tutorial04_Localization_cs.pdf)

> Localization is the process of designing and integrating support for a specific language and culture into an application or an application component. The Microsoft ASP.NET platform provides extensive support for localization for standard ASP.NET applications by integrating the standard .NET localization model; the Microsoft AJAX Framework utilize the integrated model to support the diverse scenarios in which localization can be performed.


## Introduction

Microsoft's ASP.NET technology brings an object-oriented and event-driven programming model and unites it with the benefits of compiled code. However, its server-side processing model has several drawbacks inherent in the technology, many of which can be addressed by the new features included in the System.Web.Extensions namespace, which encapsulates the Microsoft AJAX Services in the .NET Framework 3.5. These extensions enable many rich client features, previously available as part of the ASP.NET 2.0 AJAX Extensions, but now part of the Framework Base Class Library. Controls and features in this namespace include partial rendering of pages without requiring a full page refresh, the ability to access Web Services via client script (including the ASP.NET profiling API), and an extensive client-side API designed to mirror many of the control schemes seen in the ASP.NET server-side control set.

This whitepaper examines the localization features present in the Microsoft AJAX Framework and Microsoft AJAX Script Library, in the context of business need for localization support and reviewing already-integrated support for localization in web applications provided by the .NET Framework. The Microsoft AJAX Script Library utilizes the .resx file format already used by .NET applications, which provides integrated IDE support and a shareable resource type.

This whitepaper is based on the Beta 2 release of Microsoft Visual Studio 2008. This whitepaper also assumes that you will be working with Visual Studio 2008, not Visual Web Developer Express, and will provide walkthroughs according to the user interface of Visual Studio. Some code samples will utilize project templates that may be unavailable in Visual Web Developer Express.

## *The Need for Localization*

Particularly for enterprise application developers and component developers, the ability to create tools that can be aware of the differences between cultures and languages has become increasingly necessary. Designing components with the ability to adapt to the locale of the client increases developer productivity and reduces the amount of work required for the adaptation of a component to function globally.

Localization is the process of designing and integrating support for a specific language and culture into an application or an application component. The Microsoft ASP.NET platform provides extensive support for localization for standard ASP.NET applications by integrating the standard .NET localization model; the Microsoft AJAX Framework utilize the integrated model to support the diverse scenarios in which localization can be performed. With the Microsoft AJAX Framework, scripts can either be localized by being deployed into satellite assemblies, or by utilizing a static file system structure.

## *Embedding Scripts with Satellite Assemblies*

Consistent with the standard .NET Framework localization strategy, resources can be included in satellite assemblies. Satellite assemblies provide several advantages over traditional resource inclusion in binaries - any given localization can be updated without updating the larger image, additional localizations can be deployed simply by installing satellite assemblies into the project folder, and satellite assemblies can be deployed without causing a reload of the main project assembly. Particularly in ASP.NET projects, this is beneficial because it can significantly reduce the amount of system resources used by incremental updates, and minimally disrupts production website usage.

Scripts are embedded into assemblies by including them in managed .resx (or compiled .resources) files, which are included into the assembly at compile-time. Their resources are then made available to the script application through AJAX runtime-generated code, via assembly-level attributes

*Naming Conventions for Embedded Script Files*

The Microsoft AJAX Framework script management supports a variety of options for use in deployment and testing of scripts, and guidelines are provided to facilitate these options.

*To facilitate debugging:*

Release (production) scripts should not include the `.debug` qualifier in the filename. Scripts designed for debugging should include `.debug` in the filename.

*To facilitate localization:*

Neutral-culture scripts should not include any culture identifier in the name of the file. For scripts that contain localized resources, the ISO language code should be specified in the file name. For example, `es-CO` stands for Spanish, Columbia.

The following table summarizes the file naming conventions with examples:

| Filename | Meaning |
| --- | --- |
| Script.js | A release-version culture-neutral script. |
| Script.debug.js | A debug-version culture-neutral script. |
| Script.en-US.js | A release version English, United States script. |
| Script.debug.es-CO.js | A debug-version Spanish, Columbia script. |

## Walkthrough: Create an Localized, Embedded Script

*Please note: this walkthrough requires the use of Visual Studio 2008 as Visual Web Developer Express does not include a project template for class library projects.*

1. Create a new Web Site project with ASP.NET AJAX Extensions integrated. Create another project, a Class Library project, within the solution called LocalizingResources.
2. Add a Jscript file called VerifyDeletion.js to the LocalizingResources project, as well as .resx resources files called DeletionResources.resx and DeletionResources.es.resx. The former will contain culture-neutral resources; the latter will contain Spanish-language resources.
3. Add the following code to VerifyDeletion.js:

[!code-javascript[Main](understanding-asp-net-ajax-localization/samples/sample1.js)]

For those unfamiliar with JavaScript Regex syntax, text within single forward slashes (in the previous example, /FILENAME/ is an example) denotes a RegExp object. The MSDN Library contains an extensive JavaScript reference, and resources on JavaScript native objects can be found online.

1. Add the following resource strings to DeletionResources.resx: 

    **VerifyDelete**: Are you sure you want to delete FILENAME?

    **Deleted**: FILENAME has been deleted.

1. Add the following resource strings to DeletionResources.es.resx: 

    **VerifyDelete**: Est seguro que desee quitar FILENAME?

    **Deleted**: FILENAME se ha quitado.
2. Add the following lines of code to the AssemblyInfo file:

[!code-csharp[Main](understanding-asp-net-ajax-localization/samples/sample2.cs)]

1. Add references to System.Web and System.Web.Extensions to the LocalizingResources project.
2. Add a reference to the LocalizingResources project from the Web Site project.
3. In default.aspx, under the Web Site project, update the ScriptManager control with the following additional markup:

[!code-aspx[Main](understanding-asp-net-ajax-localization/samples/sample3.aspx)]

1. In default.aspx, anywhere on the page, include this markup:

[!code-aspx[Main](understanding-asp-net-ajax-localization/samples/sample4.aspx)]

1. Press F5. If prompted, enable debugging. When the page is loaded, press the Delete button. Note that you are prompted in English (unless your computer is set to prefer Spanish-language resources by default) for confirmation.
2. Close the browser window and return to default.aspx. In the @Page header directive, replace auto for Culture and UICulture with es-ES. Press F5 again to launch the web application in the browser again. This time, note that you are prompted to delete the file in Spanish:


[![](understanding-asp-net-ajax-localization/_static/image2.png)](understanding-asp-net-ajax-localization/_static/image1.png)

([Click to view full-size image](understanding-asp-net-ajax-localization/_static/image3.png))


[![](understanding-asp-net-ajax-localization/_static/image5.png)](understanding-asp-net-ajax-localization/_static/image4.png)

([Click to view full-size image](understanding-asp-net-ajax-localization/_static/image6.png))


Note that there are several variations for this walkthrough. For instance, scripts could be registered with the ScriptManager control programmatically during page load.

## *Including a Static Script File Structure*

When using static script files for deployment, you lose some of the benefits of using the inherent .NET localization scheme. Primarily visible is that you lose the automatic type generated from including script resource files; in the above walkthrough, for example, resources were exposed by an automatically-generated type called Message from the ScriptManager control.

There are, however, some benefits to using a static script file structure. Updates can be performed without recompiling and redeploying satellite assemblies, and the use of a static file structure can also be done to override embedded script, to integrate a minor piece of functionality that may not have been shipped with a component.

Microsoft recommends avoiding a version control issue by automatically generating your script resources during project compilation. When maintaining an extensive script code base, it can become increasingly difficult to ensure that code changes are reflected in each localized script. As an alternative, you can simply maintain one logic script and multiple localization scripts, merging the files while building the project.

Because there are not resources to declaratively include, static script files should be referenced either by adding `<asp:ScriptElement>` elements as a child of the `<Scripts>` tag of the ScriptManager control, or by programmatically adding `ScriptReference` objects to the `Scripts` property of the `ScriptManager` control on the page at runtime.

## *The ScriptManager and its Role in Localization*

The ScriptManager enables several automatic behaviors for localized applications:

- It automatically locates script files based on settings and naming conventions; for instance, it loads debug-enabled scripts when in debugging mode, and loads localized scripts based on the browser's user interface selection.
- It enables the definition of cultures, including custom cultures.
- It enables the compression of script files over HTTP.
- It caches scripts to efficiently manage many requests.
- It adds a layer of indirection to scripts by piping them through an encrypted URL.

Script references can be added to the ScriptManager control either programmatically or by declarative markup. Declarative markup is particularly useful when working with scripts embedded in assemblies other than the web site project itself, as the name of the script will likely not change as revisions are pushed through.

## Summary

As web applications grow to reach a larger audience, the need to be able to reach broader cultures and communities becomes core to a business model; e-commerce web applications need to be able to deal with foreign currencies, content management systems need to be able to not only present their content but also their navigation hints and form fields in other languages, and companies need to know that this need is accessible.

The .NET Framework intrinsically supports a rich localization framework, utilizing satellite assemblies and XML resource (.resx) files to present a uniform way to look up resource strings and images. The ASP.NET AJAX Extensions, including the Microsoft AJAX Framework and Microsoft AJAX Script Library, provide support for this programming model into client-side code, enabling easy resource string lookups. Satellite assemblies support the automatic inclusion of script resources (actual .js files) through ScriptResource.axd as long as the filenames follow a given naming scheme. With this support, the ASP.NET AJAX Extensions simplify the localization of scripts and the globalization of applications.

## *Bio*

Scott Cate has been working with Microsoft Web technologies since 1997 and is the President of myKB.com ([www.myKB.com](http://www.myKB.com)) where he specializes in writing ASP.NET based applications focused on Knowledge Base Software solutions. Scott can be contacted via email at [scott.cate@myKB.com](mailto:scott.cate@myKB.com) or his blog at [ScottCate.com](http://ScottCate.com)

>[!div class="step-by-step"]
[Previous](understanding-asp-net-ajax-authentication-and-profile-application-services.md)
[Next](understanding-asp-net-ajax-web-services.md)