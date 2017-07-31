---
uid: mvc/mvc3
title: "ASP.NET MVC 3 | Microsoft Docs"
author: rick-anderson
description: "(includes April 2011 Tools Update) ASP.NET MVC 3 is a framework for building scalable, standards-based web applications using well-established design pattern..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 10/05/2010
ms.topic: article
ms.assetid: dddc8812-a0bc-49f9-aafb-caf2064c2b8c
ms.technology: dotnet-mvc
ms.prod: .net-framework
msc.legacyurl: /mvc/mvc3
msc.type: content
---
ASP.NET MVC 3
====================
> *(includes April 2011 Tools Update)*
> 
> ASP.NET MVC 3 is a framework for building scalable, standards-based web applications using well-established design patterns and the power of ASP.NET and the .NET Framework.
> 
> It installs side-by-side with ASP.NET MVC 2, so get started using it today!
> 
> Download the [installer here](https://go.microsoft.com/fwlink/?LinkID=208140)


## Top Features

- Integrated Scaffolding system extensible via NuGet
- HTML 5 enabled project templates
- Expressive Views including the new Razor View Engine
- Powerful hooks with Dependency Injection and Global Action Filters
- Rich JavaScript support with unobtrusive JavaScript, jQuery Validation, and JSON binding
- *Read the full feature list [below](#overview)*

## Top Links

What's New in ASP.NET MVC 3

- Phil Haack: [ASP.NET MVC 3 Released](http://haacked.com/archive/2011/01/13/aspnetmvc3-released.aspx)
- Scott Hanselman: [ASP.NET MVC3, WebMatrix, NuGet, IIS Express and Orchard released - The Microsoft January Web Release in Context](http://www.hanselman.com/blog/ASPNETMVC3WebMatrixNuGetIISExpressAndOrchardReleasedTheMicrosoftJanuaryWebReleaseInContext.aspx)
- Scott Guthrie: [Announcing release of ASP.NET MVC 3, IIS Express, SQL CE 4, Web Farm Framework, Orchard, WebMatrix](https://weblogs.asp.net/scottgu/archive/2011/01/13/announcing-release-of-asp-net-mvc-3-iis-express-sql-ce-4-web-farm-framework-orchard-webmatrix.aspx)
- [Release Notes for ASP.NET MVC 3](../whitepapers/mvc3-release-notes.md)

Installation and Help

- Install ASP.NET MVC 3 using the [Web Platform Installer (recommended)](https://www.microsoft.com/web/handlers/webpi.ashx?command=getinstallerredirect&appid=MVC3)
- Install ASP.NET MVC 3 using the [installer executable](https://go.microsoft.com/fwlink/?LinkID=208140)
- Install [ASP.NET MVC 3 for Visual Studio 11 Developer Preview](https://go.microsoft.com/fwlink/?LinkID=208140)
- Read the [Intro to ASP.NET MVC 3 tutorial](overview/older-versions/getting-started-with-aspnet-mvc3/cs/intro-to-aspnet-mvc-3.md)
- Get help and discuss ASP.NET MVC 3 in the [forums](https://forums.asp.net/1146.aspx)

<a id="overview"></a>
## ASP.NET MVC 3 Overview

ASP.NET MVC 3 builds on ASP.NET MVC 1 and 2, adding great features that both simplify your code and allow deeper extensibility. This topic provides an overview of many of the new features that are included in this release, organized into the following sections:

- [Extensible Scaffolding with MvcScaffold integration](#BM_MvcScaffolding)
- [HTML 5 enabled project templates](#BM_HTML5)
- [The Razor View Engine](#BM_TheRazorViewEngine)
- [Support for Multiple View Engines](#BM_Support_for_Multiple_View_Engines)
- [Controller Improvements](#BM_Controller_Improvements)
- [JavaScript and Ajax](#BM_JavaScript_and_Ajax_Improvements)
- [Model Validation Improvements](#BM_Model_Validation_Improvements)
- [Dependency Injection Improvements](#BM_Dependency_Injection_Improvements)
- [Other New Features](#BM_Other_New_Features)

<a id="BM_MvcScaffolding"></a>

## Extensible Scaffolding with MvcScaffold integration

The new Scaffolding system makes it easier to pick up and start using productively if you're entirely new to the framework, and to automate common development tasks if you're experienced and already know what you're doing.

This is supported by new NuGet *scaffolding* package called **MvcScaffolding**. The term "Scaffolding" is used by many software technologies to mean "quickly generating a basic outline of your software that you can then edit and customize". The scaffolding package we're creating for ASP.NET MVC is greatly beneficial in several scenarios:

- **If you're learning ASP.NET MVC for the first time**, because it gives you a fast way to get some useful, working code, that you can then edit and adapt according to your needs. It saves you from the trauma of looking at a blank page and having no idea where to start!
- **If you know ASP.NET MVC well and are now exploring some new add-on technology** such as an object-relational mapper, a view engine, a testing library, etc., because the creator of that technology may have also created a scaffolding package for it.
- **If your work involves repeatedly creating similar classes or files of some sort**, because you can create custom scaffolders that output test fixtures, deployment scripts, or whatever else you need. Everyone on your team can use your custom scaffolders, too.

Other features in MvcScaffolding include:

- Support for C# and VB projects
- Support for the Razor and ASPX view engines
- Supports scaffolding into ASP.NET MVC areas and using custom view layouts/masters
- You can easily customize the output by editing T4 templates
- You can add entirely new scaffolders using custom PowerShell logic and custom T4 templates. These (and any custom parameters you've given them) automatically appear in the console tab-completion list.
- You can get NuGet packages containing additional scaffolders for different technologies (e.g., there's a proof-of-concept one for LINQ to SQL now) and mix and match them together

The ASP.NET MVC 3 Tools Update includes great Visual Studio support for this scaffolding system, such as:

- Add Controller Dialog now supports full automatic scaffolding of Create, Read, Update, and Delete controller actions and corresponding views. By default, this scaffolds data access code using EF Code First.
- Add Controller Dialog supports *extensible scaffolds* via NuGet packages such as *MvcScaffolding*. This allows plugging in custom scaffolds into the dialog which would allow you to create scaffolds for other data access technologies such as NHibernate or even JET with ODBCDirect if you're so inclined!

For more information about Scaffolding in ASP.NET MVC 3, see the following resources:

- Steve Sanderson's post series, including: 

    1. [Introduction: Scaffold your ASP.NET MVC 3 project with the MvcScaffolding package](http://blog.stevensanderson.com/2011/01/13/scaffold-your-aspnet-mvc-3-project-with-the-mvcscaffolding-package/)
    2. [Standard usage: Typical use cases and options](http://blog.stevensanderson.com/2011/01/13/mvcscaffolding-standard-usage/)
    3. [One-to-Many Relationships](http://blog.stevensanderson.com/2011/01/28/mvcscaffolding-one-to-many-relationships/)
    4. [Scaffolding Actions and Unit Tests](http://blog.stevensanderson.com/2011/03/28/scaffolding-actions-and-unit-tests-with-mvcscaffolding/)
    5. [Overriding the T4 templates](http://blog.stevensanderson.com/2011/04/06/mvcscaffolding-overriding-the-t4-templates/)
    6. [This post: Creating custom scaffolders](http://blog.stevensanderson.com/2011/04/07/mvcscaffolding-creating-custom-scaffolders/)
- Scott Hanselman's post from his PDC 2010 session [Building a Blog with Microsoft "Unnamed Package of Web Love"](http://www.hanselman.com/blog/PDC10BuildingABlogWithMicrosoftUnnamedPackageOfWebLove.aspx)
- [MVC 3 Release Notes](../whitepapers/mvc3-release-notes.md)

<a id="BM_HTML5"></a>

## HTML 5 Project Templates

The New Project dialog includes a checkbox enable HTML 5 versions of project templates. These templates leverage Modernizr 1.7 to provide compatibility support for HTML 5 and CSS 3 in down-level browsers.

<a id="BM_TheRazorViewEngine"></a>

## The Razor View Engine

ASP.NET MVC 3 comes with a new view engine named Razor that offers the following benefits:

- Razor syntax is clean and concise, requiring a minimum number of keystrokes.
- Razor is easy to learn, in part because it's based on existing languages like C# and Visual Basic.
- Visual Studio includes IntelliSense and code colorization for Razor syntax.
- Razor views can be unit tested without requiring that you run the application or launch a web server.

Some new Razor features include the following:

- `@model` syntax for specifying the type being passed to the view.
- `@* *@` comment syntax.
- The ability to specify defaults (such as `layoutpage`) once for an entire site.
- The `Html.Raw` method for displaying text without HTML-encoding it.
- Support for sharing code among multiple views (*\_viewstart.cshtml* or *\_viewstart.vbhtml* files).

Razor also includes  new HTML helpers, such as the following:

- `Chart`. Renders a chart, offering the same features as the chart control in ASP.NET 4.
- `WebGrid`. Renders a data grid, complete with paging and sorting functionality.
- `Crypto`. Uses hashing algorithms to create properly salted and hashed passwords.
- `WebImage`. Renders an image.
- `WebMail`. Sends an email message.

For more information about Razor, see the following resources:

- [Scott Guthrie's blog post introducing Razor](https://weblogs.asp.net/scottgu/archive/2010/07/02/introducing-razor.aspx)
- [Scott Guthrie's blog post introducing the @model keyword](https://weblogs.asp.net/scottgu/archive/2010/10/19/asp-net-mvc-3-new-model-directive-support-in-razor.aspx)
- [Scott Guthrie's blog post introducing Razor layouts](https://weblogs.asp.net/scottgu/archive/2010/10/22/asp-net-mvc-3-layouts.aspx)
- [Razor API Quick Reference](../web-pages/overview/api-reference/asp-net-web-pages-api-reference.md)
- [MVC 3 Release Notes](../whitepapers/mvc3-release-notes.md)

<a id="BM_Support_for_Multiple_View_Engines"></a>

## Support for Multiple View Engines

The **Add View** dialog box in ASP.NET MVC 3 lets you choose the view engine you want to work with, and the **New Project** dialog box lets you specify the default view engine for a project. You can choose the Web Forms view engine (ASPX), Razor, or an open-source view engine such as [Spark](http://sparkviewengine.com/), [NHaml](https://code.google.com/p/nhaml/), or [NDjango](http://ndjango.org/).

<a id="BM_Controller_Improvements"></a>

## Controller Improvements

### Global Action Filters

Sometimes you want to perform logic either before an action method runs or after an action method runs. To support this, ASP.NET MVC 2 provided action filters. Action filters are custom attributes that provide a declarative means to add pre-action and post-action behavior to specific controller action methods. However, in some cases you might want to specify pre-action or post-action behavior that applies to all action methods. MVC 3 lets you specify global filters by adding them to the `GlobalFilters` collection. For more information about global action filters, see the following resources:

- [Scott Guthrie's blog on the MVC 3 Preview](https://weblogs.asp.net/scottgu/archive/2010/07/27/introducing-asp-net-mvc-3-preview-1.aspx)
- [Filtering in ASP.NET MVC](https://msdn.microsoft.com/en-us/library/gg416513(VS.98).aspx)

### New "ViewBag" Property

MVC 2 controllers support a `ViewData` property that enables you to pass data to a view template using a late-bound dictionary API. In MVC 3, you can also use somewhat simpler syntax with the `ViewBag` property to accomplish the same purpose. For example, instead of writing `ViewData["Message"]="text"`, you can write `ViewBag.Message="text"`. You do not need to define any strongly-typed classes to use the `ViewBag` property. Because it is a dynamic property, you can instead just get or set properties and it will resolve them dynamically at run time. Internally, `ViewBag` properties are stored as name/value pairs in the `ViewData` dictionary. (Note: in most pre-release versions of MVC 3, the `ViewBag` property was named the `ViewModel` property.)

### New "ActionResult" Types

The following `ActionResult` types and corresponding helper methods are new or enhanced in MVC 3:

- [HttpNotFoundResult](https://msdn.microsoft.com/en-us/library/system.web.mvc.httpnotfoundresult(v=vs.98).aspx). Returns a 404 HTTP status code to the client.
- [RedirectResult](https://msdn.microsoft.com/en-us/library/system.web.mvc.redirectresult(v=VS.98).aspx). Returns a temporary redirect (HTTP 302 status code) or a permanent redirect (HTTP 301 status code), depending on a Boolean parameter. In conjunction with this change, the [Controller](https://msdn.microsoft.com/en-us/library/system.web.mvc.controller(v=VS.98).aspx) class now has three methods for performing permanent redirects: `RedirectPermanent`, `RedirectToRoutePermanent`, and `RedirectToActionPermanent`. These methods return an instance of `RedirectResult` with the `Permanent` property set to `true`.
- [HttpStatusCodeResult](https://msdn.microsoft.com/en-us/library/system.web.mvc.httpstatuscoderesult(v=VS.98).aspx). Returns a user-specified HTTP status code.

<a id="BM_JavaScript_and_Ajax_Improvements"></a>

## JavaScript and Ajax Improvements

By default, Ajax and validation helpers in MVC 3 use an unobtrusive JavaScript approach. Unobtrusive JavaScript avoids injecting inline JavaScript into HTML. This makes your HTML smaller and less cluttered, and makes it easier to swap out or customize JavaScript libraries. Validation helpers in MVC 3 also use the `jQueryValidate` plugin by default. If you want MVC 2 behavior, you can disable unobtrusive JavaScript using a *web.config* file setting. For more information about JavaScript and Ajax improvements, see the following resources:

- [Basic introduction to unobtrusive JavaScript on the Wikipedia site](http://en.wikipedia.org/wiki/Unobtrusive_JavaScript)
- [Brad Wilson's Unobtrusive JavaScript Post](http://bradwilson.typepad.com/blog/2010/10/mvc3-unobtrusive-ajax.html)
- [Brad Wilson's Unobtrusive JavaScript Validation Post](http://bradwilson.typepad.com/blog/2010/10/mvc3-unobtrusive-validation.html)
- [Creating a MVC 3 Application with Razor and Unobtrusive JavaScript](overview/older-versions/creating-a-mvc-3-application-with-razor-and-unobtrusive-javascript.md) (tutorial on the ASP.NET site)
- [MVC 3 Release Notes](../whitepapers/mvc3-release-notes.md)

### Client-Side Validation Enabled by Default

In earlier versions of MVC, you need to explicitly call the `Html.EnableClientValidation` method from a view in order to enable client-side validation. In MVC 3 this is no longer required because client-side validation is enabled by default. (You can disable this using a setting in the *web.config* file.)

In order for client-side validation to work, you still need to reference the appropriate jQuery and jQuery Validation libraries in your site. You can host those libraries on your own server or reference them from a content delivery network (CDN) like the CDNs from Microsoft or Google.

### Remote Validator

ASP.NET MVC 3 supports the new [RemoteAttribute](https://msdn.microsoft.com/en-us/library/system.web.mvc.remoteattribute(v=VS.98).aspx) class that enables you to take advantage of the jQuery Validation plug-in's remote validator support. This enables the client-side validation library to automatically call a custom method that you define on the server in order to perform validation logic that can only be done server-side.

In the following example, the `Remote` attribute specifies that client validation will call an action named `UserNameAvailable` on the `UsersController` class in order to validate the `UserName` field.

[!code-csharp[Main](mvc3/samples/sample1.cs)]

The following example shows the corresponding controller.

[!code-csharp[Main](mvc3/samples/sample2.cs)]

For more information about how to use the `Remote` attribute, see [How to: Implement Remote Validation in ASP.NET MVC](https://msdn.microsoft.com/en-us/library/gg508808(VS.98).aspx) in the MSDN library.

### JSON Binding Support

ASP.NET MVC 3 includes built-in JSON binding support that enables action methods to receive JSON-encoded data and model-bind it to action-method parameters. This capability is useful in scenarios involving client templates and data binding. (Client templates enable you to format and display a single data item or set of data items by using templates that execute on the client.) MVC 3 enables you to easily connect client templates with action methods on the server that send and receive JSON data. For more information about JSON binding support, see the **JavaScript and AJAX Improvements** section of [Scott Guthrie's MVC 3 Preview blog post](https://weblogs.asp.net/scottgu/archive/2010/07/27/introducing-asp-net-mvc-3-preview-1.aspx).

<a id="BM_Model_Validation_Improvements"></a>

## Model Validation Improvements

### "DataAnnotations" Metadata Attributes

ASP.NET MVC 3 supports `DataAnnotations` metadata attributes such as `DisplayAttribute`.

### "ValidationAttribute" Class

The `ValidationAttribute` class was improved in the .NET Framework 4 to support a new `IsValid` overload that provides more information about the current validation context, such as what object is being validated. This enables richer scenarios where you can validate the current value based on another property of the model. For example, the new `CompareAttribute` attribute lets you compare the values of two properties of a model. In the following example, the `ComparePassword` property must match the `Password` field in order to be valid.

[!code-csharp[Main](mvc3/samples/sample3.cs)]

### Validation Interfaces

The [IValidatableObject](https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.ivalidatableobject.aspx) interface enables you to perform model-level validation, and it enables you to provide validation error messages that are specific to the state of the overall model, or between two properties within the model. MVC 3 now retrieves errors from the `IValidatableObject` interface when model binding, and automatically flags or highlights affected fields within a view using the built-in HTML form helpers.

The [IClientValidatable](https://msdn.microsoft.com/en-us/library/system.web.mvc.iclientvalidatable(v=VS.98).aspx) interface enables ASP.NET MVC to discover at run time whether a validator has support for client validation. This interface has been designed so that it can be integrated with a variety of validation frameworks.

For more information about validation interfaces, see the **Model Validation Improvements** section of [Scott Guthrie's MVC 3 Preview blog post](https://weblogs.asp.net/scottgu/archive/2010/07/27/introducing-asp-net-mvc-3-preview-1.aspx). (However, note that the reference to "IValidateObject" in the blog should be "IValidatableObject".)

<a id="BM_Dependency_Injection_Improvements"></a>

## Dependency Injection Improvements

ASP.NET MVC 3 provides better support for applying Dependency Injection (DI) and for integrating with Dependency Injection or Inversion of Control (IOC) containers. Support for DI has been added in the following areas:

- Controllers (registering and injecting controller factories, injecting controllers).
- Views (registering and injecting view engines, injecting dependencies into view pages).
- Action filters (locating and injecting filters).
- Model binders (registering and injecting).
- Model validation providers (registering and injecting).
- Model metadata providers (registering and injecting).
- Value providers (registering and injecting).

MVC 3 supports the [Common Service Locator](http://commonservicelocator.codeplex.com/) library and any DI container that supports that library's `IServiceLocator` interface. It also supports a new `IDependencyResolver` interface that makes it easier to integrate DI frameworks.

For more information about DI in MVC 3, see the following resources:

- [Brad Wilson's series of blog posts on Service Location](http://bradwilson.typepad.com/blog/2010/07/service-location-pt1-introduction.html)
- [MVC 3 Release Notes](../whitepapers/mvc3-release-notes.md)

<a id="BM_Other_New_Features"></a>

## Other New Features

### NuGet Integration

ASP.NET MVC 3 automatically installs and enables NuGet as part of its setup. NuGet is a free open-source package manager that makes it easy to find, install, and use .NET libraries and tools in your projects. It works with all Visual Studio project types (including ASP.NET Web Forms and ASP.NET MVC).

NuGet enables developers who maintain open source projects (for example, projects like Moq, NHibernate, Ninject, StructureMap, NUnit, Windsor, RhinoMocks, and Elmah) to package their libraries and register them in an online gallery. It is then easy for .NET developers who want to use one of these libraries to find the package and install it in projects they are working on.

With the ASP.NET 3 Tools Update, project templates include JavaScript libraries pre-installed NuGet packages, so they are updatable via NuGet. Entity Framework Code First is also pre-installed as a NuGet package.

For more information about NuGet, see the [NuGet documentation on the CodePlex site](http://nuget.codeplex.com/documentation?title=Package%20Manager%20Console%20Command%20Reference).

### Partial-Page Output Caching

ASP.NET MVC has supported output caching of full page responses since version 1. MVC 3 also supports partial-page output caching, which allows you to easily cache regions or fragments of a response. For more information about caching, see the **Partial Page Output Caching** section of [Scott Guthrie's blog post on the MVC 3 release candidate](https://weblogs.asp.net/scottgu/archive/2010/11/09/announcing-the-asp-net-mvc-3-release-candidate.aspx) and the **Child Action Output Caching** section of the [MVC 3 Release Notes](../whitepapers/mvc3-release-notes.md).

### Granular Control over Request Validation

ASP.NET MVC has built-in request validation that automatically helps protect against XSS and HTML injection attacks. However, sometimes you want to explicitly disable request validation, such as if you want to let users post HTML content (for example, in blog entries or CMS content). You can now add an [AllowHtml](https://msdn.microsoft.com/en-us/library/system.web.mvc.allowhtmlattribute(v=VS.98).aspx) attribute to models or view models to disable request validation on a per-property basis during model binding. For more information about request validation, see the following resources:

- The **Unobtrusive JavaScript and Validation** section in [Scott Guthrie's blog post on the MVC 3 release candidate](https://weblogs.asp.net/scottgu/archive/2010/11/09/announcing-the-asp-net-mvc-3-release-candidate.aspx).
- [MVC 3 Release Notes](../whitepapers/mvc3-release-notes.md)

### Extensible "New Project" Dialog Box

In ASP.NET MVC 3 you can add project templates, view engines, and unit test project frameworks to the **New Project** dialog box.

### Template Scaffolding Improvements

ASP.NET MVC 3 scaffolding templates do a better job of identifying primary-key properties on models and handling them appropriately than in earlier versions of MVC. (For example, the scaffolding templates now make sure that the primary key is not scaffolded as an editable form field.)

By default, the Create and Edit scaffolds now use the `Html.EditorFor` helper instead of the `Html.TextBoxFor` helper. This improves support for metadata on the model in the form of data annotation attributes when the **Add View** dialog box generates a view.

### New Overloads for "Html.LabelFor" and "Html.LabelForModel"

New method overloads have been added for the `LabelFor` and `LabelForModel` helper methods. The new overloads enable you to specify or override the label text.

### Sessionless Controller Support

In ASP.NET MVC 3 you can indicate whether you want a controller class to use session state, and if so, whether session state should be read/write or read-only. For more information about sessionless controller support, see [MVC 3 Release Notes](../whitepapers/mvc3-release-notes.md).

### New "AdditionalMetadataAttribute" Class

You can use the [AdditionalMetadata](https://msdn.microsoft.com/en-us/library/system.web.mvc.additionalmetadataattribute(v=VS.98).aspx) attribute to populate the `ModelMetadata.AdditionalValues` dictionary for a model property. For example, if a view model has a property that should be displayed only to an administrator, you can annotate that property as shown in the following example:

[!code-csharp[Main](mvc3/samples/sample4.cs)]

This metadata is made available to any display or editor template when a product view model is rendered. It is up to you to interpret the metadata information.

### AccountController improvements

The AccountController in the Internet project template has been greatly improved.

### New Intranet Project Template

A new Intranet Project Template is included which enables Windows Authentication and removes the AccountController.
