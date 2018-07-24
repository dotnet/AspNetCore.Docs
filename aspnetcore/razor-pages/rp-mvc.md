---
title: Razor Pages compared to ASP.NET Core MVC with controllers and views
author: Rick-Anderson
description: Contrast and compare Razor Pages to controller/view programming in ASP.NET Core
monikerRange: '>= aspnetcore-2.0'
ms.author: riande
ms.date: 8/05/2018
uid: razor-pages/rp-mvc
---
# Razor Pages compared to ASP.NET Core MVC with controllers and views

By [Scott Sauber](https://twitter.com/scottsauber) and [Rick Anderson](https://twitter.com/RickAndMSFT)

Razor Pages is a feature of the ASP.NET Core MVC framework. Razor Pages follows the MVVM pattern. Developers and teams familiar with ASP.NET MVC development:

* Can continue app development featuring controllers and views.
* Can be assured the ASP.NET Core framework will provide improvements to controller/view development.

Razor Pages can be added to controller/view projects. The controller-view approach to MVC may be preferred approach taken by larger teams.

If you haven't tried Razor Pages, consider using them. Many developers find Razor Pages development simpler and more productive than using controllers and views.

Razor Pages advantages over controller/view development:

* **A better folder structure by default that scales better.**  In MVC, the default folder structure  does not scale.  Separate folders for Views, Controllers, and often ViewModels when all three are tightly coupled to one another.  You must bounce between all three folders anytime you need to add or change a feature.  With Razor Pages, your `PageModel` (Controller + ViewModel) are in the same folder as your View.  You hit F7 in Visual Studio to toggle between them.
* **Unit Testing is easier.**  With a Controller, you might have many Actions and some of the dependencies injected that are related to only one or two Actions.  When unit testing a single Action, the dependencies must be mocked or passed in as null. (Unnecessary dependency injection can be mitigated with the Builder pattern).  With Razor Pages, the dependencies you inject in are 100% related to GET, POST, PUT, etc actions in the `PageModel`.
* **Leads to more maintainable code that scales better.**  Controller/view programming can lead to code bloat:
  * Controllers often end up with many `Action` methods, many of which are not related to each other.
  * Controllers contain all the shared code used by all the `Action` methods. Razor Pages include only the code they use. Shared code for Razor Pages is contained in a base class. For example, see [Create a base class to share common code](xref:data/ef-rp/update-related-data#create-a-base-class-to-share-common-code).

 Controllers with many actions, views, and shared code can be difficult to navigate and maintain. Using private methods in a controller can exacerbate the problem. With Razor Pages development, unrelated methods are not added to the `PageModel`. Everything  put in the `PageModel` is related to the Page. 
 Razor Pages follow the [Single responsibility principle](https://wikipedia.org/wiki/Single_responsibility_principle), while MVC does not.
* **Routing is easier.**  By default in Razor Pages, routing matches the folder structure.  This makes nesting folders straightforward.  For example, consider an app where:
  * All of the HR administrator/privileged pages are under the */Administrator* folder.
  * All the Employee pages are under the */Employee* folder.  
  * The app can authorize an entire folder and require the user must be an Administrator to get to any subfolder of */Administrator*. The code to do this is more straightforward that than with multiple Controllers that make up the Administrator features.
* **More secure by default.**  Razor Pages provides:
  * [AntiForgeryToken validation](xref:razor-pages/index#xsrfcsrf-and-razor-pages) by default.
  * You opt-in to the properties that need to be model bound via `[BindProperty]`.  `[BindProperty]` prevents over-posting attacks.
  * The `PageModel` acts like a view model.

## Razor Pages compared to Web Forms

Razor Pages and Web Forms are page focused and each contain a *.cs* file associated with the markup page. Other than the page focus, Razor Pages are very different from Web Forms. It can be difficult to migrate Web Forms code to Razor Pages. Converting between Razor Pages and ASP.NET Core MVC is generally straightforward. Razor Pages and Web Forms have very little in common. Razor Pages and ASP.NET Core MVC share most of the ASP.NET Core framework.