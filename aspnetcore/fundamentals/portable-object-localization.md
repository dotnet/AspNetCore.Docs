---
title: Configure Portable Object localization
author: sebastienros
description: This article introduces Portable Object files and outlines the necessary steps for using them in an ASP.NET Core application.
keywords: ASP.NET Core,localization,culture,language,portable object
ms.author: scaddie
manager: wpickett
ms.date: 09/18/2017
ms.topic: article
ms.technology: aspnet
ms.prod: asp.net-core
uid: fundamentals/portable-object-localization
---
# Configure Portable Object localization in ASP.NET Core

By [Sébastien Ros](https://github.com/sebastienros) and [Scott Addie](https://twitter.com/Scott_Addie)

This article walks through the steps for using Portable Object (PO) files in an ASP.NET Core application.

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/localization/sample/POLocalization)

## What is a PO file?

PO files contain the translated strings for a given language. They prove very useful, as opposed to standard *.resx* files. PO files support pluralization and are distributed as plain text files.

### Example

Here is a sample PO file containing the translation for two strings in French, including one with its plural form:

*fr.po*

```text
#: Services/EmailService.cs:29
msgid "Enter a comma separated list of email addresses."
msgstr "Entrez une liste d'emails séparés par une virgule."

#: Views/Email.cshtml:112
msgid "The email address is \"{0}\"."
msgid_plural "The email addresses are \"{0}\"."
msgstr[0] "L'adresse email est \"{0}\"."
msgstr[1] "Les adresses email sont \"{0}\""
```

This example uses the following syntax:

- `#:`: A comment indicating the context of the string to be translated. The same string might be translated differently depending on where it is being used.
- `msgid`: The untranslated string.
- `msgstr`: The translated string.

In the case of pluralization support, more entries can be defined.

- `msgid_plural`: The untranslated plural string.
- `msgstr[0]`: The translated string for the case 0.
- `msgstr[N]`: The translated string for the case N.

The PO file specification can be found [here](https://www.gnu.org/savannah-checkouts/gnu/gettext/manual/html_node/PO-Files.html).

## Configuring PO file support in ASP.NET Core

This example is based on an ASP.NET Core MVC application generated from a Visual Studio 2017 project template.

### Referencing the package

Add a reference to the `OrchardCore.Localization.Core` NuGet package. It is available on [MyGet](https://www.myget.org/) at the following package source: https://www.myget.org/F/orchardcore-preview/api/v3/index.json

The *.csproj* file now contains a line similar to the following (version number may vary):

[!code-xml[Main](localization/sample/POLocalization/POLocalization.csproj?range=9)]

### Registering the service

Add the required services to the `ConfigureServices` method of *Startup.cs*:

[!code-csharp[Main](localization/sample/POLocalization/Startup.cs?name=snippet_ConfigureServices&highlight=4-21)]

Add the required middleware to the `Configure` method of *Startup.cs*:

[!code-csharp[Main](localization/sample/POLocalization/Startup.cs?name=snippet_Configure&highlight=15)]

Add the following code to your Razor view of choice. *About.cshtml* is used in this example.

[!code-cshtml[Main](localization/sample/POLocalization/Views/Home/About.cshtml)]

An `IViewLocalizer` instance is injected and used to translate the text `"Hello world!"`.

### Creating a PO file

Create a file named *fr.po*, in your application root folder, containing the following:

[!code-text[Main](localization/sample/POLocalization/fr.po)]

This file stores both the string to translate and the French-translated string. Translations revert to their parent culture, if necessary. In this example, the *fr.po* file is used if the requested culture is `fr-FR` or `fr-CA`.

### Testing the application

Run your application, and navigate to the URL `/Home/About`. The text **Hello world!** is displayed.

Navigate to the URL `/Home/About?culture=fr-FR`. The text **Bonjour le monde!** is displayed.

## Pluralization

PO files support pluralization forms, which is useful when the same string needs to be translated differently based on a cardinality. This task is made complicated by the fact that each language defines custom rules to select which string to use based on the cardinality.

The Orchard Localization package provides an API to invoke these different plural forms automatically.

### Creating pluralization PO files

Add the following content to the previously mentioned *fr.po* file:

```text
msgid "There is one item."
msgid_plural "There are {0} items."
msgstr[0] "Il y a un élément."
msgstr[1] "Il y a {0} éléments."
```

### Adding a language using different pluralization forms

English and French strings were used in the previous example. English and French have only two pluralization forms and share the same form rules, which is that
a cardinality of one is mapped to the first plural form. Any other cardinality is mapped to the second plural form.

Unfortunately, not all languages share the same rules. This is illustrated with the Czech language, which has three plural forms.

Create the `cs.po` file as follows, and note how the pluralization needs three different translations:

[!code-text[Main](localization/sample/POLocalization/cs.po)]

To accept Czech localizations, add `"cs"` to the list of supported cultures in the `ConfigureServices` method of *Startup.cs*:

```csharp
var supportedCultures = new List<CultureInfo>
{
    new CultureInfo("en-US"),
    new CultureInfo("en"),
    new CultureInfo("fr-FR"),
    new CultureInfo("fr"),
    new CultureInfo("cs")
};
```

Edit the *Views/Home/About.cshtml* file to render localized, plural strings for several cardinalities:

```cshtml
<p>@Localizer.Plural(1, "There is one item.", "There are {0} items.")</p>
<p>@Localizer.Plural(2, "There is one item.", "There are {0} items.")</p>
<p>@Localizer.Plural(5, "There is one item.", "There are {0} items.")</p>
```

**Note:** In a real world scenario, a variable would be used to represent the count. Here, we repeat the same code with three different values to expose a very specific case.

Upon switching cultures, you see the following:

For `/Home/About`:

```html
There is one item.
There are 2 items.
There are 5 items.
```

For `/Home/About?culture=fr`:

```html
Il y a un élément.
Il y a 2 éléments.
Il y a 5 éléments.
```

For `/Home/About?culture=cs`:

```html
Existuje jedna položka.
Existují 2 položky.
Existuje 5 položek.
```

Note that for the Czech culture, the three translations are different. The French and English cultures share the same construction for the two last translated strings.

## Advanced tasks

### Contextualizing strings

Applications often contain the same strings to be translated in several places, while requiring the flexibility to define different translations. A PO file supports the notion of a *context*, which can be used to categorize the string being represented.

The PO localization services can use the name of the full class or the view that is used when translating a string. This is accomplished by setting the value on the `msgctx` entry.

Considering the previous example, the entry could have been written as:

*fr.po*

```text
msgctx Views.Home.About
msgid "Hello world!"
msgstr "Bonjour le monde!"
```

When no context is specified, it's used as a fallback for any string whose context doesn't match any specific one.

### Changing the location of PO files

You can change the default location of PO files in the application by setting a base folder name. This is accomplished with the following code in the `ConfigureServices` method of *Startup.cs*:

```csharp
services.AddPortableObjectLocalization(options => options.ResourcesPath = "Localization");
```

In this example, the PO files are loaded from the *Localization* folder.

### Implementing a custom logic for finding localization files

When more complex logic is needed to locate PO files, the `OrchardCore.Localization.PortableObject.ILocalizationFileLocationProvider` interface can be implemented
and registered as a service. This is useful when PO files can be stored in varying locations or when the files have to be found within a hierarchy of folders.

### Using a different default pluralized language

The package includes a `Plural` extension method that is specific to two plural forms, as this is the most common. If your main language is different and requires more plural forms, for instance, create your own extension method. This way, you won't need to provide any localization file for the default language &mdash; the original strings are already available directly in the code.

You can use the more generic `Plural(int count, string[] pluralForms, params object[] arguments)` overload which accepts a string array of translations.