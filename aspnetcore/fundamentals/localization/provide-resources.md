---
title: Provide localized resources for languages and cultures in an ASP.NET Core app
author: rick-anderson
description: Learn how to provide localized resources for localizing content of an ASP.NET Core app into different languages and cultures.
ms.author: riande
monikerRange: '>= aspnetcore-5.0'
ms.date: 02/23/2023
uid: fundamentals/localization/provide-resources
---
# Provide localized resources for languages and cultures in an ASP.NET Core app

:::moniker range="> aspnetcore-5.0"

By [Rick Anderson](https://twitter.com/RickAndMSFT), [Damien Bowden](https://twitter.com/damien_bod), [Bart Calixto](https://twitter.com/bartmax), [Nadeem Afana](https://afana.me/), and [Hisham Bin Ateya](https://twitter.com/hishambinateya)

One task for localizing an app is to provide localized strings in resource files. This article is about working with resource files.

## `SupportedCultures` and `SupportedUICultures`

ASP.NET Core has two collections of culture values, `SupportedCultures` and `SupportedUICultures`. The <xref:System.Globalization.CultureInfo> object for `SupportedCultures` determines the results of culture-dependent functions, such as date, time, number, and currency formatting. `SupportedCultures` also determines the sorting order of text, casing conventions, and string comparisons. See <xref:System.StringComparer.CurrentCulture?displayProperty=nameWithType> for more info on how the server gets the culture. The `SupportedUICultures` determines which translated strings (from *.resx* files) are looked up by the <xref:System.Resources.ResourceManager>. The `ResourceManager` simply looks up culture-specific strings that are determined by `CurrentUICulture`. Every thread in .NET has `CurrentCulture` and `CurrentUICulture` objects. ASP.NET Core inspects these values when rendering culture-dependent functions. For example, if the current thread's culture is set to "en-US" (English, United States), `DateTime.Now.ToLongDateString()` displays "Thursday, February 18, 2016", but if `CurrentCulture` is set to "es-ES" (Spanish, Spain) the output will be "jueves, 18 de febrero de 2016".

## Resource files

A resource file is a useful mechanism for separating localizable strings from code. Translated strings for the non-default language are isolated in *.resx* resource files. For example, you might want to create a Spanish resource file named *Welcome.es.resx* containing translated strings. "es" is the language code for Spanish. To create this resource file in Visual Studio:

1. In **Solution Explorer**, right click on the folder that will contain the resource file, and then select **Add** > **New Item**.

   ![Nested contextual menu: In Solution Explorer, a contextual menu is open for Resources. A second contextual menu is open for Add showing the New Item command highlighted.](~/fundamentals/localization/_static/newi.png)

1. In the **Search installed templates** box, enter "resource" and name the file.

   ![Add New Item dialog](~/fundamentals/localization/_static/res.png)

1. Enter the key value (native string) in the **Name** column and the translated string in the **Value** column.

   ![Welcome.es.resx file (the Welcome resource file for Spanish) with the word Hello in the Name column and the word Hola (Hello in Spanish) in the Value column](~/fundamentals/localization/_static/hola.png)

   Visual Studio shows the *Welcome.es.resx* file.

   ![Solution Explorer showing the Welcome Spanish (es) resource file](~/fundamentals/localization/_static/se.png)

## Resource file naming

Resources are named for the full type name of their class minus the assembly name. For example, a French resource in a project whose main assembly is `LocalizationWebsite.Web.dll` for the class `LocalizationWebsite.Web.Startup` would be named *Startup.fr.resx*. A resource for the class `LocalizationWebsite.Web.Controllers.HomeController` would be named *Controllers.HomeController.fr.resx*. If your targeted class's namespace isn't the same as the assembly name you will need the full type name. For example, in the sample project a resource for the type `ExtraNamespace.Tools` would be named *ExtraNamespace.Tools.fr.resx*.

In the sample project, the `ConfigureServices` method sets the `ResourcesPath` to "Resources", so the project relative path for the home controller's French resource file is *Resources/Controllers.HomeController.fr.resx*. Alternatively, you can use folders to organize resource files. For the home controller, the path would be *Resources/Controllers/HomeController.fr.resx*. If you don't use the `ResourcesPath` option, the *.resx* file would go in the project base directory. The resource file for `HomeController` would be named *Controllers.HomeController.fr.resx*. The choice of using the dot or path naming convention depends on how you want to organize your resource files.

| Resource name | Dot or path naming |
| ------------   | ------------- |
| Resources/Controllers.HomeController.fr.resx | Dot  |
| Resources/Controllers/HomeController.fr.resx  | Path |

Resource files using `@inject IViewLocalizer` in Razor views follow a similar pattern. The resource file for a view can be named using either dot naming or path naming. Razor view resource files mimic the path of their associated view file. Assuming we set the `ResourcesPath` to "Resources", the French resource file associated with the `Views/Home/About.cshtml` view could be either of the following:

* Resources/Views/Home/About.fr.resx

* Resources/Views.Home.About.fr.resx

If you don't use the `ResourcesPath` option, the *.resx* file for a view would be located in the same folder as the view.

## RootNamespaceAttribute 

The <xref:Microsoft.Extensions.Localization.RootNamespaceAttribute> attribute provides the root namespace of an assembly when the root namespace of an assembly is different than the assembly name. 

> [!WARNING]
> This can occur when a project's name is not a valid .NET identifier. For instance `my-project-name.csproj` will use the root namespace `my_project_name` and the assembly name `my-project-name` leading to this error. 

If the root namespace of an assembly is different than the assembly name:

* Localization does not work by default.
* Localization fails due to the way resources are searched for within the assembly. `RootNamespace` is a build-time value which is not available to the executing process. 

If the `RootNamespace` is different from the `AssemblyName`, include the following in `AssemblyInfo.cs` (with parameter values replaced with the actual values):

```csharp
using System.Reflection;
using Microsoft.Extensions.Localization;

[assembly: ResourceLocation("Resource Folder Name")]
[assembly: RootNamespace("App Root Namespace")]
```

The preceding code enables the successful resolution of resx files.

## Culture fallback behavior

When searching for a resource, localization engages in "culture fallback". Starting from the requested culture, if not found, it reverts to the parent culture of that culture. As an aside, the <xref:System.Globalization.CultureInfo.Parent%2A?displayProperty=nameWithType> property represents the parent culture. This usually (but not always) means removing the national signifier from the language-and-culture code. For example, the dialect of Spanish spoken in Mexico is "es-MX". It has the parent "es"&mdash;Spanish non-specific to any country.

Imagine your site receives a request for a "Welcome" resource using culture "fr-CA". The localization system looks for the following resources, in order, and selects the first match:

* *Welcome.fr-CA.resx*
* *Welcome.fr.resx*
* *Welcome.resx* (if the `NeutralResourcesLanguage` is "fr-CA")

As an example, if you remove the ".fr" culture designator and you have the culture set to French, the default resource file is read and strings are localized. The Resource manager designates a default or fallback resource for when nothing meets your requested culture. If you want to just return the key when missing a resource for the requested culture you must not have a default resource file.

## Generate resource files with Visual Studio

If you create a resource file in Visual Studio without a culture in the file name (for example, *Welcome.resx*), Visual Studio will create a C# class with a property for each string. That's usually not what you want with ASP.NET Core. You typically don't have a default *.resx* resource file (a *.resx* file without the culture name). We suggest you create the *.resx* file with a culture name (for example *Welcome.fr.resx*). When you create a *.resx* file with a culture name, Visual Studio won't generate the class file.

### Add other cultures

Each language and culture combination (other than the default language) requires a unique resource file. You create resource files for different cultures and locales by creating new resource files in which the language codes are part of the file name (for example, **en-us**, **fr-ca**, and **en-gb**). These codes are placed between the file name and the *.resx* file extension, as in *Welcome.es-MX.resx* (Spanish/Mexico).

## Next steps

Localizing an app also involves the following tasks:

* [Make the app's content localizable](xref:fundamentals/localization/make-content-localizable).
* [Implement a strategy to select the language/culture for each request](xref:fundamentals/localization/select-language-culture)

## Additional resources

* [Url culture provider using middleware as filters in ASP.NET Core](https://andrewlock.net/url-culture-provider-using-middleware-as-mvc-filter-in-asp-net-core-1-1-0/)
* [Applying the RouteDataRequest CultureProvider globally with middleware as filters](https://andrewlock.net/applying-the-routedatarequest-cultureprovider-globally-with-middleware-as-filters/)
* <xref:fundamentals/localization>
* <xref:fundamentals/localization/make-content-localizable>
* <xref:fundamentals/localization/select-language-culture>
* <xref:fundamentals/troubleshoot-aspnet-core-localization>
* [Globalizing and localizing .NET applications](/dotnet/standard/globalization-localization/index)
* [Localization.StarterWeb project](https://github.com/aspnet/Entropy/tree/master/samples/Localization.StarterWeb) used in the article.
* [Resources in .resx Files](/dotnet/framework/resources/working-with-resx-files-programmatically)
* [Microsoft Multilingual App Toolkit](https://marketplace.visualstudio.com/items?itemName=MultilingualAppToolkit.MultilingualAppToolkit-18308)
* [Localization & Generics](http://hishambinateya.com/localization-and-generics)

:::moniker-end

[!INCLUDE [provide-resources5](~/fundamentals/localization/includes/provide-resources5.md)]
