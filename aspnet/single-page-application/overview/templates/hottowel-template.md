---
uid: single-page-application/overview/templates/hottowel-template
title: "Hot Towel template | Microsoft Docs"
author: madskristensen
description: "HotTowel template"
ms.author: aspnetcontent
manager: wpickett
ms.date: 02/09/2013
ms.topic: article
ms.assetid: 75af2e17-6ed3-4d24-8ea1-bc340027c318
ms.technology: 
ms.prod: .net-framework
msc.legacyurl: /single-page-application/overview/templates/hottowel-template
msc.type: authoredcontent
---
Hot Towel template
====================
by [Mads Kristensen](https://github.com/madskristensen)

> The Hot Towel MVC Template is written by John Papa
> 
> Choose which version to download:
> 
> [Hot Towel MVC Template for Visual Studio 2012](https://visualstudiogallery.msdn.microsoft.com/1f68fbe8-b4e9-4968-9fd3-ddc7cbc52dca)
> 
> [Hot Towel MVC Template for Visual Studio 2013](https://visualstudiogallery.msdn.microsoft.com/1eb8780d-d522-4dcf-bf56-56f0eab305c2)


> Hot Towel: Because you don't want to go to the SPA without one!


Want to build a SPA but can't decide where to start? Use Hot Towel and in seconds you'll have a SPA and all the tools you need to build on it!

Hot Towel creates a great starting point for building a Single Page Application (SPA) with ASP.NET. Out of the box you it provides a modular structure for your code, view navigation, data binding, rich data management and simple but elegant styling. Hot Towel provides everything you need to build a SPA, so you can focus on your app, not the plumbing.

> Learn more about building a SPA from [John Papa's videos, tutorials and Pluralsight courses](http://johnpapa.net/spa?vsix).


## Application Structure

Hot Towel SPA provides an App folder which contains the JavaScript and HTML files that define your application.

Inside the App folder:

- durandal
- services
- viewmodels
- views

The App folder contains a collection of modules. These modules encapsulate functionality and declare dependencies on other modules. The views folder contains the HTML for your application and the viewmodels folder contains the presentation logic for the views (a common MVVM pattern). The services folder is ideal for housing any common services that your application may need such as HTTP data retrieval or local storage interaction. It is common for multiple viewmodels to re-use code from the service modules.

## ASP.NET MVC Server Side Application Structure

Hot Towel builds on the familiar and powerful ASP.NET MVC structure.

- App\_Start
- Content
- Controllers
- Models
- Scripts
- Views

## Featured Libraries

- ASP.NET MVC
- ASP.NET Web API
- ASP.NET Web Optimization - bundling and minification
- [Breeze.js](http://Breezejs.com) - rich data management
- [Durandal.js](http://Durandaljs.com) - navigation and View composition
- [Knockout.js](http://Knockoutjs.com) - data bindings
- [Require.js](http://requirejs.org) - Modularity with AMD and optimization
- [Toastr.js](http://jpapa.me/c7toastr) - pop-up messages
- [Twitter Bootstrap](http://twitter.github.com/bootstrap/) - robust CSS styling

## Installing via the Visual Studio 2012 Hot Towel SPA Template

Hot Towel can be installed as a Visual Studio 2012 template. Just click `File` | `New Project` and choose `ASP.NET MVC 4 Web Application`. Then select the 'Hot Towel Single Page Application" template and run!

## Installing via the NuGet Package

Hot Towel is also a NuGet package that augments an existing empty ASP.NET MVC project. Just install using Nuget and then run!

[!code-powershell[Main](hottowel-template/samples/sample1.ps1)]

## How Do I Build On Hot Towel?

Simply start adding code!

1. Add your own server-side code, preferably Entity Framework and WebAPI (which really shine with Breeze.js)
2. Add views to the `App/views` folder
3. Add viewmodels to the `App/viewmodels` folder
4. Add HTML and Knockout data bindings to your new views
5. Update the navigation routes in `shell.js`

## Walkthrough of the HTML/JavaScript

### Views/HotTowel/index.cshtml

index.cshtml is the starting route and view for the MVC application. It contains all the standard meta tags, css links, and JavaScript references you would expect. The body contains a single `<div>` which is where all of the content (your views) will be placed when they are requested. The `@Scripts.Render` uses Require.js to run the entrance point for the application's code, which is contained in the `main.js` file. A splash screen is provided to demonstrate how to create a splash screen while your app loads.

[!code-cshtml[Main](hottowel-template/samples/sample2.cshtml)]

### App/main.js

The `main.js` file contains the code that will run as soon as your app is loaded. This is where you want to define your navigation routes, set your start up views, and perform any setup/bootstrapping such as priming your application's data.

The `main.js` file defines several of durandal's modules to help the application kick start. The define statement helps resolve the modules dependencies so they are available for the function. First the debugging messages are enabled, which send messages about what events the application is performing to the console window. The app.start code tells durandal framework to start the application. The conventions are set so that durandal knows all views and viewmodels are contained in the same named folders, respectively. Finally, the `app.setRoot` kicks loads the `shell` using a predefined `entrance` animation.

[!code-javascript[Main](hottowel-template/samples/sample3.js)]

## Views

Views are found in the `App/views` folder.

### shell.html

The `shell.html` contains the master layout for your HTML. All of your other views will be composed somewhere in side of your `shell` view. Hot Towel provides a `shell` with three such regions: a header, a content area, and a footer. Each of these regions is loaded with contents form other views when requested.

The `compose` bindings for the header and footer are hard coded in Hot Towel to point to the `nav` and `footer` views, respectively. The compose binding for the section `#content` is bound to the `router` module's active item. In other words, when you click a navigation link it's corresponding view is loaded in this area.

[!code-html[Main](hottowel-template/samples/sample4.html)]

### nav.html

The `nav.html` contains the navigation links for the SPA. This is where the menu structure can be placed, for example. Often this is data bound (using Knockout) to the `router` module to display the navigation you defined in the `shell.js`. Knockout looks for the data-bind attributes and binds those to the `shell` viewmodel to display the navigation routes and to show a progressbar (using Twitter Bootstrap) if the `router` module is in the middle of navigating from one view to another (see `router.isNavigating`).

[!code-html[Main](hottowel-template/samples/sample5.html)]

### home.html and details.html

These views contain HTML for custom views. When the `home` link in the `nav` view's menu is clicked, the `home` view will be placed in the content area of the `shell` view. These views can be augmented or replaced with your own custom views.

### footer.html

The `footer.html` contains HTML that appears in the footer, at the bottom of the `shell` view.

## ViewModels

ViewModels are found in the `App/viewmodels` folder.

### shell.js

The `shell` viewmodel contains properties and functions that are bound to the `shell` view. Often this is where the menu navigation bindings are found (see the `router.mapNav` logic).

[!code-javascript[Main](hottowel-template/samples/sample6.js)]

### home.js and details.js

These viewmodels contain the properties and functions that are bound to the `home` view. it also contains the presentation logic for the view, and is the glue between the data and the view.

[!code-javascript[Main](hottowel-template/samples/sample7.js)]

## Services

Services are found in the App/services folder. Ideally your future services such as a dataservice module, that is responsible for getting and posting remote data, could be placed.

### logger.js

Hot Towel provides a `logger` module in the services folder. The `logger` module is ideal for logging messages to the console and to the user in pop up toasts.