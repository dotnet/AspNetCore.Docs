---
title: Globalization and localization in ASP.NET Core
author: rick-anderson
description: Learn how ASP.NET Core provides services and middleware for localizing content into different languages and cultures.
ms.author: riande
monikerRange: '>= aspnetcore-3.1'
ms.date: 02/23/2023
uid: fundamentals/localization
---
# Globalization and localization in ASP.NET Core

:::moniker range="> aspnetcore-5.0"

By [Rick Anderson](https://twitter.com/RickAndMSFT), [Damien Bowden](https://twitter.com/damien_bod), [Bart Calixto](https://twitter.com/bartmax), [Nadeem Afana](https://afana.me/), and [Hisham Bin Ateya](https://twitter.com/hishambinateya)

A multilingual website allows a website to reach a wider audience. ASP.NET Core provides services and middleware for localizing into different languages and cultures.

## Terms

* Globalization (G11N): The process of making an app support different languages and regions. The abbreviation comes from the first and last letters and the number of letters between them.
* Localization (L10N): The process of customizing a globalized app for specific languages and regions.
* Internationalization (I18N): Both globalization and localization.
* Culture: A language and, optionally, a region.
* Neutral culture: A culture that has a specified language, but not a region (for example "en", "es").
* Specific culture: A culture that has a specified language and region (for example, "en-US", "en-GB", "es-CL").
* Parent culture: The neutral culture that contains a specific culture (for example, "en" is the parent culture of "en-US" and "en-GB").
* Locale: A locale is the same as a culture.

## Language and country/region codes

The [RFC 4646](https://www.ietf.org/rfc/rfc4646.txt) format for the culture name is `<language code>-<country/region code>`, where `<language code>` identifies the language and `<country/region code>` identifies the subculture. For example, `es-CL` for Spanish (Chile), `en-US` for English (United States), and `en-AU` for English (Australia). [RFC 4646](https://www.ietf.org/rfc/rfc4646.txt) is a combination of an ISO 639 two-letter lowercase culture code associated with a language and an ISO 3166 two-letter uppercase subculture code associated with a country or region. For more information, see <xref:System.Globalization.CultureInfo?displayProperty=fullName>.

## Tasks to localize an app

Globalizing and localizing an app involves the following tasks:

* [Make an ASP.NET Core app's content localizable](xref:fundamentals/localization/make-content-localizable).
* [Provide localized resources for the cultures the app supports](xref:fundamentals/localization/provide-resources)
* [Implement a strategy to select the culture for each request](xref:fundamentals/localization/select-language-culture)

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/localization/sample) ([how to download](xref:index#how-to-download-a-sample))

<!-- 
Move mini TOC from ## Additional resources to here
## Additional globalization and localization topics
-->
## Additional resources

* [Url culture provider using middleware as filters in ASP.NET Core](https://andrewlock.net/url-culture-provider-using-middleware-as-mvc-filter-in-asp-net-core-1-1-0/)
* [Applying the RouteDataRequest CultureProvider globally with middleware as filters](https://andrewlock.net/applying-the-routedatarequest-cultureprovider-globally-with-middleware-as-filters/)
* [`IStringLocalizer`](xref:fundamentals/localization/make-content-localizable) : Uses the <xref:System.Resources.ResourceManager> and <xref:System.Resources.ResourceReader> to provide culture-specific resources at run time. The interface has an indexer and an `IEnumerable` for returning localized strings.
* [`IHtmlLocalizer`](xref:fundamentals/localization/make-content-localizable#ihtmllocalizer): For resources that contain HTML.
* [View and DataAnnotations](xref:fundamentals/localization/make-content-localizable#view-localization)
* <xref:fundamentals/troubleshoot-aspnet-core-localization>
* [Globalizing and localizing .NET applications](/dotnet/standard/globalization-localization/index)
* [Resources in .resx Files](/dotnet/framework/resources/working-with-resx-files-programmatically)
* [Microsoft Multilingual App Toolkit](https://marketplace.visualstudio.com/items?itemName=MultilingualAppToolkit.MultilingualAppToolkit-18308)
* [Localization & Generics](http://hishambinateya.com/localization-and-generics)

:::moniker-end

[!INCLUDE [localization35](~/fundamentals/localization/includes/localization35.md)]
