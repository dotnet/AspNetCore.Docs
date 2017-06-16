---
uid: mvc/overview/releases/mvc51-release-notes
title: "What's New in ASP.NET MVC 5.1 | Microsoft Docs"
author: microsoft
description: ""
ms.author: aspnetcontent
manager: wpickett
ms.date: 02/27/2014
ms.topic: article
ms.assetid: 9a83a058-9b01-48aa-acce-ec041e694567
ms.technology: dotnet-mvc
ms.prod: .net-framework
msc.legacyurl: /mvc/overview/releases/mvc51-release-notes
msc.type: authoredcontent
---
What's New in ASP.NET MVC 5.1
====================
by [Microsoft](https://github.com/microsoft)

This topic describes what's new for ASP.NET Web MVC 5.1.

- [Software Requirements](#SoftwareRequirements)
- [Download](#download)
- [Documentation](#documentation)
- [New Features in ASP.NET MVC 5.1](#new-features)

    - [Attribute routing improvements](#AttributeRouting)
    - [Bootstrap support for editor templates](#Bootstrap)
    - [Enum support in views](#Enum)
    - [Unobtrusive validation for MinLength/MaxLength Attributes](#Unobtrusive)
    - [Supporting the ‘this' context in Unobtrusive Ajax](#thisContext)
- [Known Issues and Breaking Changes](#KnownBreakingChanges)- [Bug Fixes](#bug-fixes)

<a id="SoftwareRequirements"></a>
## Software Requirements

- Visual Studio 2012: Download [ASP.NET and Web Tools 2013.1 for Visual Studio 2012](https://go.microsoft.com/fwlink/?LinkId=390062).
- Visual Studio 2013: Download [Visual Studio 2013 Update 1](https://go.microsoft.com/fwlink/?LinkId=390064). This update is needed for editing ASP.NET MVC 5.1 Razor Views.

<a id="download"></a>
## Download

The runtime features are released as NuGet packages on the NuGet gallery. All the runtime packages follow the [Semantic Versioning](http://semver.org/) specification. The latest ASP.NET MVC 5.1 RTM package has the following version: "5.1.2". You can install or update these packages through [NuGet](http://www.nuget.org/packages/Microsoft.AspNet.Mvc/). The release also includes corresponding localized packages on NuGet.

You can install or update to the released NuGet packages by using the NuGet Package Manager Console:

[!code-console[Main](mvc51-release-notes/samples/sample1.cmd)]

<a id="documentation"></a>
## Documentation

Tutorials and other information about ASP.NET MVC 5.1 RTM are available from the ASP.NET web site ( https://www.asp.net). 

<a id="new-features"></a>
## New Features in ASP.NET MVC 5.1

<a id="AttributeRouting"></a>

### Attribute routing improvements

 Attribute routing now supports constraints, enabling versioning and header based route selection. Many aspects of attribute routes are now customizable via the `IDirectRouteFactory` interface and `RouteFactoryAttribute` class. The route prefix is now extensible via the `IRoutePrefix` interface and `RoutePrefixAttribute` class. 

<a id="Enum"></a>

### Enum support in views

1. New `@Html.EnumDropDownListFor()` helper methods. These should be used like most of the HTML helpers with the caveat that the expression must evaluate to an [enum](https://msdn.microsoft.com/en-us/library/cc138362.aspx) type or a [Nullable&lt;T&gt;](https://msdn.microsoft.com/en-us/library/2cf62fcy.aspx) where `T` is an [enum](https://msdn.microsoft.com/en-us/library/cc138362.aspx) type. Use `EnumHelper.IsValidForEnumHelper()` to check these requirements.
2. New `EnumHelper.GetSelectList()` methods which return an `IList<SelectListItem>`. This is useful when you need to manipulate a select list prior to calling, for example, `@Html.DropDownListFor()`, or when you wish to display the names which `@Html.EnumDropDownListFor()` shows.

The following code shows these APIs.

[!code-cshtml[Main](mvc51-release-notes/samples/sample2.cshtml)]

You can see a complete example [here](https://aspnet.codeplex.com/SourceControl/latest#Samples/MVC/EnumSample/).

<a id="Bootstrap"></a>

### Bootstrap support for editor templates

We now allow passing in HTML attributes in [EditorFor](https://msdn.microsoft.com/en-us/library/system.web.mvc.html.editorextensions.editorfor(v=vs.100).aspx) as an [anonymous object](https://msdn.microsoft.com/en-us/library/bb397696.aspx).

For example:

[!code-cshtml[Main](mvc51-release-notes/samples/sample3.cshtml)]

<a id="Unobtrusive"></a>

### Unobtrusive validation for MinLengthAttribute and MaxLengthAttribute

Client-side validation for string and array types will now be supported for properties decorated with the [MinLength](https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.minlengthattribute(v=vs.110).aspx) and [MaxLength](https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.maxlengthattribute(v=vs.110).aspx) attributes.

<a id="thisContext"></a>

### Supporting the ‘this' context in Unobtrusive Ajax

The callback functions (`OnBegin, OnComplete, OnFailure, OnSuccess`) will now be able to locate the invoking element via the `this` context. For example:

[!code-html[Main](mvc51-release-notes/samples/sample4.html)]

<a id="KnownBreakingChanges"></a>

## Known Issues and Breaking Changes

### Attribute Routing

Ambiguities in attribute routing matches will now report an error rather than choosing the first match.

Attribute routes are prohibited from using the `{controller}` parameter, and from using the `{action}` parameter on routes placed on actions. Uses of these parameters would very likely lead to ambiguities. 

### Scaffolding MVC/Web API into a project with 5.1 packages results in 5.0 packages for ones that don't already exist in the project

Updating NuGet packages for ASP.NET MVC 5.1 RTM does not update the Visual Studio tools such as ASP.NET scaffolding or the ASP.NET Web Application project template. They use the previous version of the ASP.NET runtime packages (5.0.0.0). As a result, the ASP.NET scaffolding will install the previous version (5.0.0.0) of the required packages, if they are not already available in your projects. However, the ASP.NET scaffolding in Visual Studio 2013 RTM or Update 1 does not overwrite the latest packages in your projects. If you use ASP.NET scaffolding after updating the packages of your projects to Web API 2.1 or ASP.NET MVC 5.1, make sure the versions of Web API and ASP.NET MVC are consistent. 

### Syntax Highlighting for Razor Views in Visual Studio 2013

If you update to ASP.NET MVC 5.1 RTM without updating Visual Studio 2013, you will not get Visual Studio editor support for syntax highlighting while editing the Razor views. You will need to update Visual Studio 2013 to get this support. 

### Type Renames

Some of the types used for attribute routing extensibility are renamed in 5.1 RTM.

| **Old Type Name (5.1 RC)** | **New Type Name (5.1 RTM)** |
| --- | --- |
| IDirectRouteProvider | IDirectRouteFactory |
| RouteProviderAttribute | RouteFactoryAttribute |
| DirectRouteProviderContext | DirectRouteFactoryContext |

<a id="bug-fixes"></a>
## Bug Fixes

This release also includes several bug fixes. You can find the complete list here:

- [5.1.0 package](https://aspnetwebstack.codeplex.com/workitem/list/advanced?keyword=&amp;status=Closed&amp;type=All&amp;priority=All&amp;release=v5.1%20Preview|v5.1%20RTM&amp;assignedTo=All&amp;component=MVC&amp;sortField=AssignedTo&amp;sortDirection=Ascending&amp;page=0&amp;reasonClosed=Fixed)
- [5.1.1 package](https://aspnetwebstack.codeplex.com/workitem/list/advanced?keyword=&amp;status=All&amp;type=All&amp;priority=All&amp;release=v5.1.1%20RTM&amp;assignedTo=All&amp;component=MVC&amp;sortField=AssignedTo&amp;sortDirection=Ascending&amp;page=0&amp;reasonClosed=Fixed)

The 5.1.2 package contains IntelliSense updates but no bug fixes.