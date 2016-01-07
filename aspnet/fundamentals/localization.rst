ASP.NET 5 Internationalization, Localization and Globalization
========================
By  `Nadeem Afana <https://twitter.com/NadeemAfana>`__ and `Rick Anderson`_

If your website targets users from different parts of the world, users from other languages might like to see your website content in their own language. Creating a multilingual website is not an easy task, but it will certainly allow your site to reach a wider audience. ASP.NET 5 has :doc:`/fundamentals/request-features` (no longer in features)that support different languages and cultures.

We will build an ASP.NET MVC 5 web application that contains the following features:

- It can display contents in different languages.
- It autodetects the language from the user's browser.
- It allows the user to override the language of their browser.

.. contents:: In this article:
  :local:
  :depth: 1
  
Globalization and Localization in ASP.NET 5 and MVC 6
-------------------------------------------------------

Internationalization involves `Globalization <https://msdn.microsoft.com/en-us/library/aa292081(v=vs.71).aspx>`__ and `Localization <https://msdn.microsoft.com/en-us/library/aa292137(v=vs.71).aspx>`__. Globalization is the process of designing applications that support different cultures. Globalization adds support for input, display, and output of a defined set of language scripts that relate to specific geographic areas. 

Localization is the process of adapting a globalized application, which you have already processed for localizability, to a particular culture/locale. The process of localizing your application also requires a basic understanding of relevant character sets commonly used in modern software development and an understanding of the issues associated with them. Although all computers store text as numbers (codes), different systems can (and do) store the same text using different numbers. The localization process refers to translating the application user interface (UI) for a specific culture/locale. 

`Localizability <https://msdn.microsoft.com/en-us/library/aa292135(v=vs.71).aspx>`__ is an intermediate process for verifying that a globalized application is ready for localization

The format for the culture name is "<languagecode2>-<country/regioncode2>", where <languagecode2> is the language code and <country/regioncode2> is the subculture code. Examples include ``es-CL`` for Spanish (Chile), ``en-US`` for English (United States), and ``en-AU`` for English (Australia). See `Language Culture Name <https://msdn.microsoft.com/en-us/library/ee825488(v=cs.20).aspx>`__.

Internationalization is often abbreviated to "I18N". The abbreviation takes the first and last letters and the number of letters between them, so 18 stands for the number of letters between the first "I" and the last "N". The same applies to Globalization (G11N), and Localization (L10N).

Let’s review the terms used so far:

- Globalization (G11N): The process of making an application support different languages and regions.
- Localization (L10N): The process of customizing an application for a given language and region.
- Internationalization (I18N): Describes both globalization and localization.
- Culture: It is a language and, optionally, a region.
- Locale: A locale is the same as a culture.
- Neutral culture: A culture that has a specified language, but not a region. (for example "en", "es")
- Specific culture: A culture that has a specified language and region. (for example "en-US", "en-GB", "es-CL")

ASP.NET 5 allows you to specify two culture values,  `culture <https://github.com/aspnet/Localization/blob/dev/src/Microsoft.AspNet.Localization/ProviderCultureResult.cs>`__ and `uiCulture <https://github.com/aspnet/Localization/blob/dev/src/Microsoft.AspNet.Localization/ProviderCultureResult.cs>`__. **The culture value determines the results of culture-dependent functions, such as the date, number, and currency formatting. The uiCulture determines which resources are to be loaded for the page by the ResourceManager.** The ResourceManager simply looks up culture-specific resources that is determined by CurrentUICulture. Every thread in .NET has CurrentCulture and CurrentUICulture objects. So ASP.NET inspects these values when rendering culture-dependent functions. For example, if current thread's culture (CurrentCulture) is set to "en-US" (English, United States), DateTime.Now.ToLongDateString() shows "Saturday, January 08, 2011", but if CurrentCulture is set to "es-CL" (Spanish, Chile) the result will be "sábado, 08 de enero de 2011".

