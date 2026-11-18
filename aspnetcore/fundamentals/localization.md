---
title: Globalization and localization in ASP.NET Core
description: Learn how ASP.NET Core provides services and middleware for localizing content into different languages and cultures.
monikerRange: '>= aspnetcore-3.1'
ms.date: 11/18/2026
---
# Globalization and localization in ASP.NET Core

[!INCLUDE[](~/includes/not-latest-version.md)]

:::moniker range="> aspnetcore-5.0"

By [Rick Anderson](https://twitter.com/RickAndMSFT), [Damien Bowden](https://github.com/damienbod), [Bart Calixto](https://twitter.com/bartmax), [Nadeem Afana](https://afana.me/), and [Hisham Bin Ateya](https://github.com/hishamco)

A multilingual website allows a website to reach a wider audience. ASP.NET Core provides services and middleware for localizing into different languages and cultures.

For Blazor localization guidance, which adds to or supersedes the guidance in this article, see [ASP.NET Core Blazor globalization and localization](../blazor/globalization-localization.md).

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

* [Make an ASP.NET Core app's content localizable](localization/make-content-localizable.md).
* [Provide localized resources for the cultures the app supports](localization/provide-resources.md)
* [Implement a strategy to select the culture for each request](localization/select-language-culture.md)

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/localization/samples) ([how to download](index.md#how-to-download-a-sample))

## Related content

* [Url culture provider using middleware as filters in ASP.NET Core](https://andrewlock.net/url-culture-provider-using-middleware-as-mvc-filter-in-asp-net-core-1-1-0/)
* [Applying the RouteDataRequest CultureProvider globally with middleware as filters](https://andrewlock.net/applying-the-routedatarequest-cultureprovider-globally-with-middleware-as-filters/)
* [Make an ASP.NET Core app's content localizable](localization/make-content-localizable.md)
* [Provide localized resources for the cultures the app supports](localization/provide-resources.md)
* [Implement a strategy to select the culture for each request](localization/select-language-culture.md)
* [Troubleshoot ASP.NET Core localization](troubleshoot-aspnet-core-localization.md)
* [Globalizing and localizing .NET applications](/dotnet/standard/globalization-localization/index)
* [Resources in .resx Files](/dotnet/framework/resources/working-with-resx-files-programmatically)
* [Localization & Generics](https://hishambinateya.com/localization-and-generics)
* [Tim Heuer's ResX Viewer and Editor (Visual Studio Code)](https://marketplace.visualstudio.com/items?itemName=TimHeuer.resx-editor)

:::moniker-end

[!INCLUDE [localization35](~/fundamentals/localization/includes/localization35.md)]
