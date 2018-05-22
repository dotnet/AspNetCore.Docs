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
* A cookie consent feature allows you to ask for (and track) consent from your users for storing personal information. If a user has not consented to data collection, non-essential cookies will not be sent to the browser.
* Cookies can be marked as essential. Essential cookies are sent to the browser even when the user has not consented.

The [sample app](https://github.com/aspnet/Docs/tree/live/aspnetcore/security/gdpr) lets you test most of the GDPR extension points and APIs added to the ASP.NET Core 2.1 templates. See the [ReadMe](https://github.com/aspnet/Docs/tree/live/aspnetcore/security/gdpr) for testing instructions.

[View or download sample code](https://github.com/aspnet/Docs/tree/live/aspnetcore/security/gdpr) ([how to download](xref:tutorials/index#how-to-download-a-sample))

## ASP.NET Core GDPR support in template generated code

Razor Pages and MVC projects created with the project templates include the following GDPR support:

* The *_CookieConsentPartial.cshtml* partial view](xref:mvc/views/tag-helpers/builtin-th/partial-tag-helper). 
* [CookiePolicyOptions](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.builder.cookiepolicyoptions?view=aspnetcore-2.0) are initialized in the `Startup` class `ConfigureServices` method.
* [UseCookiePolicy](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.builder.cookiepolicyappbuilderextensions.usecookiepolicy?view=aspnetcore-2.0#Microsoft_AspNetCore_Builder_CookiePolicyAppBuilderExtensions_UseCookiePolicy_Microsoft_AspNetCore_Builder_IApplicationBuilder_) is called in `Startup` class `Configure` method.

### _CookieConsentPartial.cshtml partial view

The *_CookieConsentPartial.cshtml* partial view:

[!code-html[Main](gdpr/sample/RP/Pages/Shared/_CookieConsentPartial.cshtml)]

This partial:

* Gets the state of tracking for the user. If the application is configured to require consent the user must consent before cookies can be tracked. If consent is required, the cookie consent chrome is fixed on top of the navigation bar created in the *Pages/Shared/_Layout.cshtml* file.
* Provides an HTML `<p>` element to summarize your privacy and cookie use policy.
* Provides a link to *Pages/Privacy.cshtml* where you can detail your site's privacy policy.

### CookiePolicyOptions and UseCookiePolicy

[CookiePolicyOptions](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.builder.cookiepolicyoptions?view=aspnetcore-2.0) are initialized in the `Startup` class `ConfigureServices` method:

[!code-csharp[Main](gdpr/sample/Startup.cs?name=snippet1&highlight=14-20)]

[UseCookiePolicy](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.builder.cookiepolicyappbuilderextensions.usecookiepolicy?view=aspnetcore-2.0#Microsoft_AspNetCore_Builder_CookiePolicyAppBuilderExtensions_UseCookiePolicy_Microsoft_AspNetCore_Builder_IApplicationBuilder_) is called in `Startup` class `Configure` method:

[!code-csharp[Main](gdpr/sample/Startup.cs?name=snippet1&highlight=49)]

## Personal data

ASP.NET Core applications created with indiviual user accounts include code to download and delete personal data.

Select the the user name and then select **Personal data**:

![Manage personal data page](gdpr/_static/pd.png)

To generate the `Account/Manage` code, see [Scaffold Identity ](xref:security/authentication/scaffold-identity).

## Tempdata provider cookie is not essential

The Tempdata provider cookie is not essential. If tracking is disabled, the Tempdata provider is not functional. To enable the Tempdata provider when tracking is disabled, mark the TempData cookie as essential in `ConfigureServices`:

[!code-csharp[Main](gdpr/sample/RP/Startup.cs?name=snippet1)]

## Additional Resources

* [Microsoft.com/GDPR](https://www.microsoft.com/en-us/trustcenter/Privacy/GDPR)