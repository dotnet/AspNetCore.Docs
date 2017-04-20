---
uid: single-page-application/overview/introduction/other-libraries
title: "Know a library other than Knockout? | Microsoft Docs"
author: madskristensen
description: "Know a library other than Knockout?"
ms.author: aspnetcontent
manager: wpickett
ms.date: 02/05/2013
ms.topic: article
ms.assetid: a8367c6d-ef94-4dff-a010-5eff9e6eea96
ms.technology: 
ms.prod: .net-framework
msc.legacyurl: /single-page-application/overview/introduction/other-libraries
msc.type: authoredcontent
---
Know a library other than Knockout?
====================
by [Mads Kristensen](https://github.com/madskristensen)

The [Single Page Application (SPA) template](knockoutjs-template.md) is a great way to get started writing single-page applications. The template uses [KnockoutJS](http://knockoutjs.com/) to bind application data to DOM elements.

But Knockout is not the only JavaScript library for creating rich client applications. Other libraries solve similar challenges in different ways. You might prefer a one library over another, so we've made several community-created templates available for download. Each of these templates uses a different mix of client JavaScript libraries.

To install a community-created template, visit one of the template pages listed below and click the Download button. The templates are provided as VSIX files.

## BackboneJS

[Backbone.js SPA template](../templates/backbonejs-template.md). This template provides an initial skeleton for developing a [Backbone.js](http://backbonejs.org/) application in ASP.NET MVC. Out of the box it provides basic user login functionality, including user sign-up, sign-in, password reset, and user confirmation with basic email templates.

## BreezeJS

[BreezeJS](http://www.breezejs.com/?utm_source=ms-spa) is an open source library for managing rich data in a JavaScript client. Breeze handles querying, caching, change tracking, validation, and more. Two templates feature Breeze:

- The [Breeze/Knockout](../templates/breezeknockout-template.md) template extends the Knockout SPA template, showing how easily you can build a single-page application with Breeze for data management and KnockoutJS for data binding.
- The [Breeze/Angular](../templates/breezeangular-template.md) template also extends the Knockout SPA template with Breeze, but using the [AngularJS](http://angularjs.org) library for data binding, dependency injection, and screen management.

In addition, the [Hot Towel SPA template](../templates/hottowel-template.md) uses BreezeJS.

## EmberJS

[EmberJS SPA template](../templates/emberjs-template.md). This template uses [Ember](http://emberjs.com/), a powerful MVC JavaScript library that solves a wide array of challenges for building rich client applications.

The Ember SPA template is a re-implementation of the Knockout SPA template, using EmberJS and Handlebars templating.

## Hot Towel

[Hot Towel SPA template](../templates/hottowel-template.md). This template brings in several JavaScript libraries, including Breeze, Knockout, RequireJS and Twitter Bootstrap.

Compared with the other templates listed here, the Hot Towel teample provides a more complete application from which you can build your own. There are more concepts to be aware of, but once you understand them, this template might just be what you are looking for. If you want to build a SPA but can't decide where to start, use Hot Towel and in seconds you'll have a SPA and all the tools you need to build on it.

## Feature table

Here are the features provided by each SPA template:

|  | ASP.NET SPA | Backbone | Breeze/Angular | Breeze/KO | Ember | Hot Towel |
| --- | --- | --- | --- | --- | --- | --- |
| ToDo sample | &#10003; |  | &#10003; | &#10003; | &#10003; |  |
| Bare template |  | &#10003; |  |  |  | &#10003; |
| Navigation and history |  | &#10003; | &#10003; |  | &#10003; | &#10003; |
| Libaries |  |  |  |  |  |  |
| Angular |  |  | &#10003; |  |  |  |
| &#8195;Backbone |  | &#10003; |  |  |  |  |
| Breeze |  |  | &#10003; | &#10003; |  | &#10003; |
| Durandal |  |  |  |  |  | &#10003; |
| Ember |  |  |  |  | &#10003; |  |
| Knockout | &#10003; |  |  | &#10003; |  | &#10003; |