---
title: General Data Protection Regulation (GDPR) support in ASP.NET Core
author: rick-anderson
description: Shows how to access the GDPR extension points in a ASP.NET Core web app.
manager: wpickett
monikerRange: '>= aspnetcore-2.1'
ms.author: riande
ms.date: 5/29/2018
ms.prod: asp.net-core
ms.technology: aspnet
ms.topic: article
uid: security/gdpr
---
# EU General Data Protection Regulation (GDPR) support in ASP.NET Core

https://docs.microsoft.com/en-us

By [Rick Anderson](https://twitter.com/RickAndMSFT)

ASP.NET Core provides APIs and templates to help meet some of the [UE General Data Protection Regulation (GDPR)](https://www.eugdpr.org/) requirements:

* The project templates include extension points and stubbed markup you can replace with your privacy and cookie use policy. 
* A cookie consent feature allow you to ask for (and track) consent from your users for storing personal information. If a user has not consented to data collection, non-essential cookies will not be sent to the browser.
* Cookies can be marked as essential. Essential cookies are sent to the browser even when the user has not concented.


## ASP.NET Core GDPR support in template generated code

Razor Pages and MVC projects created with the project templates include the following GDPR support:

* The *_CookieConsentPartial.cshtml* partial view](xref:mvc/views/tag-helpers/builtin-th/partial-tag-helper). 
* [CookiePolicyOptions](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.builder.cookiepolicyoptions?view=aspnetcore-2.0) are initialized in the `Startup` class `ConfigureServices` method.
* [UseCookiePolicy](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.builder.cookiepolicyappbuilderextensions.usecookiepolicy?view=aspnetcore-2.0#Microsoft_AspNetCore_Builder_CookiePolicyAppBuilderExtensions_UseCookiePolicy_Microsoft_AspNetCore_Builder_IApplicationBuilder_) is called in `Startup` class `Configure` method.

### _CookieConsentPartial.cshtml partial view

The *_CookieConsentPartial.cshtml* partial view:


This partial:

  * Gets the state of tracking for the user. If the application is configured to require consent the user much conent before cookies can be tracked.
  * If 
  