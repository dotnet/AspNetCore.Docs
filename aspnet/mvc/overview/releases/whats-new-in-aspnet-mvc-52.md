---
uid: mvc/overview/releases/whats-new-in-aspnet-mvc-52
title: "What’s New in ASP.NET MVC 5.2 | Microsoft Docs"
author: microsoft
description: ""
ms.author: aspnetcontent
manager: wpickett
ms.date: 12/25/2014
ms.topic: article
ms.assetid: 97972587-2720-48b4-b158-f35f2e855fbf
ms.technology: dotnet-mvc
ms.prod: .net-framework
msc.legacyurl: /mvc/overview/releases/whats-new-in-aspnet-mvc-52
msc.type: authoredcontent
---
What’s New in ASP.NET MVC 5.2
====================
by [Microsoft](https://github.com/microsoft)

This topic describes what's new for ASP.NET MVC 5.2, [Microsoft.AspNet.MVC 5.2.2](#52) and [ASP.NET MVC 5.2.3 Beta](#mvc523Beta)

- [Software Requirements](#softRequire)
- [Download](#download)
- [Documentation](#documentation)
- [New Features in ASP.NET MVC 5.2](#new-features)

    - [Attribute routing improvements](#attributerouting)
- [Known Issues and Breaking Changes](#knownbreakingchanges)
- [Bug Fixes](#bug-fixes)
- [Microsoft.AspNet.MVC 5.2.2](#52)

<a id="softRequire"></a>
## Software Requirements

- Visual Studio 2012: Download [ASP.NET and Web Tools 2013.1 for Visual Studio 2012](https://go.microsoft.com/fwlink/?LinkId=390062).
- Visual Studio 2013: Download [Visual Studio 2013 Update](https://go.microsoft.com/fwlink/?LinkId=390064) or higher. This update is needed for editing ASP.NET MVC 5.2 Razor Views.

<a id="download"></a>
## Download

The runtime features are released as NuGet packages on the NuGet gallery. All the runtime packages follow the [Semantic Versioning](http://semver.org/) specification. The latest ASP.NET MVC 5.2 package has the following version: "5.2.0". You can install or update these packages through [NuGet](http://www.nuget.org/packages/Microsoft.AspNet.Mvc/). The release also includes corresponding localized packages on NuGet.

You can install or update to the released NuGet packages by using the NuGet Package Manager Console:

Install-Package Microsoft.AspNet.Mvc -Version 5.2.0

<a id="documentation"></a>
## Documentation

Tutorials and other information about ASP.NET MVC 5.2 are available from the ASP.NET web site ([https://www.asp.net/mvc](../../index.md)).

<a id="new-features"></a>
## New Features in ASP.NET MVC 5.2

<a id="attributerouting"></a>
### Attribute routing improvements

Attribute Routing now provides an extensibility point called IDirectRouteProvider, which allows full control over how attribute routes are discovered and configured. An IDirectRouteProvider is responsible for providing a list of actions and controllers along with associated route information to specify exactly what routing configuration is desired for those actions. An IDirectRouteProvider implementation may be specified when calling MapAttributes/MapHttpAttributeRoutes.

Customizing IDirectRouteProvider will be easiest by extending our default implementation, DefaultDirectRouteProvider. This class provides separate overridable virtual methods to change the logic for discovering attributes, creating route entries, and discovering route prefix and area prefix.

With the new attribute routing extensibility of IDirectRouteProvider, a user could do the following:

1. Support Inheritance of attribute routes. For example, in the following scenario Blog and Store controllers are using an attribute route convention that is defined by the BaseController. 

    [!code-csharp[Main](whats-new-in-aspnet-mvc-52/samples/sample1.cs)]
2. Automatically generate route names for attribute routes. 

    [!code-csharp[Main](whats-new-in-aspnet-mvc-52/samples/sample2.cs)]
3. Modify route prefixes in one central place before the routes get added to the route table.
4. Filter out the controllers on which you want the attribute routing to look for. We hope to blog on 3 and 4 soon.

### Facebook fixes for changed API surface

The MVC Facebook package [was broken](https://aspnetwebstack.codeplex.com/workitem/list/advanced?keyword=&amp;status=All&amp;type=All&amp;priority=All&amp;release=v5.2%20RC&amp;assignedTo=All&amp;component=Facebook&amp;sortField=AssignedTo&amp;sortDirection=Ascending&amp;page=0&amp;reasonClosed=All) due to few API changes made by Facebook. We are also releasing a new Facebook package (Microsoft.AspNet.Facebook 1.0.0) to fix these issues.

<a id="knownbreakingchanges"></a>
## Known Issues and Breaking Changes

### Scaffolding MVC/Web API into a project with 5.2.0 packages results in 5.1.2 packages for ones that don't already exist in the project

Updating NuGet packages for ASP.NET MVC 5.2.0 does not update the Visual Studio tools such as ASP.NET scaffolding or the ASP.NET Web Application project template. They use the previous version of the ASP.NET runtime packages (e.g. 5.1.2 in Update 2). As a result, the ASP.NET scaffolding will install the previous version (e.g. 5.1.2 in Update 2) of the required packages, if they are not already available in your projects. However, the ASP.NET scaffolding in Visual Studio 2013 RTM or Update 1 does not overwrite the latest packages in your projects. If you use ASP.NET scaffolding after updating the packages of your projects to Web API 2.2 or ASP.NET MVC 5.2, make sure the versions of Web API and ASP.NET MVC are consistent.

### Microsoft.jQuery.Unobtrusive.Validation NuGet package installation fails because it is unable to find a version of Microsoft.jQuery.Unobtrusive.Validation compatible to jQuery 1.4.1

Microsoft.jQuery.Unobtrusive.Validation requires jQuery &gt;=1.8 and jQuery.Validation &gt;=1.8. But,jQuery.Validation (1.8) needs jQuery (&#8805; 1.3.2 &amp;&amp; &#8804; 1.6). Because of this, when NuGet installs the JQuery 1.8 and jQuery.Validation 1.8 at the same time, it fails. When you see this issue, you can simply update the version of jQuery.Validation to &gt;= [1.8.0.1](https://www.nuget.org/packages/jQuery.Validation/1.8.0.1) which has the jQuery cap fixed first, you should be able to install Microsoft.jQuery.Unobtrusive.Validation.

### The jquery.Validation nuget package version 1.13.0 does not recognize some international email addresses

jQuery.Validation nuget package version 1.11.1 is the last known version which recognizes following valid email addresses. Any later versions might not be able to recognize them. For example:

E-Mail Address Internationalization (EAI) standard (e.g., [&#29992;&#25143;@domain.com](mailto:&#29992;&#25143;@domain.com))   
 EAI + Internationalized Resource Identifiers (IRIs) (eg., [&#29992;&#25143;@&#1076;&#1086;&#1084;&#1077;&#1085;.&#1088;&#1092;](mailto:&#29992;&#25143;@&#1076;&#1086;&#1084;&#1077;&#1085;.&#1088;&#1092;))

The issue is reported at [https://github.com/jzaefferer/jquery-validation/issues/1222](https://github.com/jzaefferer/jquery-validation/issues/1222)

### Syntax Highlighting for Razor Views in Visual Studio 2013

If you update to ASP.NET MVC 5.2 without updating Visual Studio 2013, you will not get Visual Studio editor support for syntax highlighting while editing the Razor views. You will need to update Visual Studio 2013 to get this support.

<a id="bug-fixes"></a>
## Bug Fixes and Minor feature updates

This release also includes several bug fixes and minor feature updates. You can find the complete list here:

- [5.2 package](https://aspnetwebstack.codeplex.com/workitem/list/advanced?keyword=&amp;status=Closed&amp;type=All&amp;priority=All&amp;release=v5.2%20RC&amp;assignedTo=All&amp;component=MVC&amp;sortField=AssignedTo&amp;sortDirection=Ascending&amp;page=0&amp;reasonClosed=Fixed)

<a id="52"></a>
## Microsoft.AspNet.MVC 5.2.2

This release doesn't have any new features or bug fixes in MVC. We made a [change in Web Pages](https://blogs.msdn.com/b/webdev/archive/2014/07/28/announcing-the-beta-release-of-web-pages-3-2-1.aspx) for a significant performance improvement and have subsequently updated all other dependent packages we own to depend on this new version of Web Pages.

<a id="mvc523Beta"></a>
## ASP.NET MVC 5.2.3 Beta

You can read about the release [here](https://blogs.msdn.com/b/webdev/archive/2014/12/17/asp-net-mvc-5-2-3-web-pages-5-2-3-and-web-api-5-2-3-beta-releases.aspx). This release contains only bug fixes. You can use [this query](https://aspnetwebstack.codeplex.com/workitem/list/advanced?keyword=&amp;status=Closed&amp;type=All&amp;priority=All&amp;release=v5.2.3%20Beta&amp;assignedTo=All&amp;component=MVC&amp;sortField=LastUpdatedDate&amp;sortDirection=Descending&amp;page=0&amp;reasonClosed=Fixed) to see the list of issues fixed in this release.