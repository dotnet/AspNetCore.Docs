---
title: Configure portable object localization in ASP.NET Core
author: sebastienros
description: This article introduces Portable Object files and outlines steps for using them in an ASP.NET Core application with the Orchard Core framework.
ms.author: scaddie
ms.date: 09/26/2017
uid: fundamentals/portable-object-localization
---
# Configure portable object localization in ASP.NET Core

:::moniker range=">= aspnetcore-6.0"

By  [Hisham Bin Ateya](https://github.com/hishamco) and [Sébastien Ros](https://github.com/sebastienros).

This article walks through the steps for using Portable Object (PO) files in an ASP.NET Core application with the [Orchard Core](https://github.com/OrchardCMS/OrchardCore) framework.

**Note:** Orchard Core isn't a Microsoft product. Microsoft provides no support for this feature.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/localization/sample/6.x/POLocalization) ([how to download](xref:index#how-to-download-a-sample))

## What is a PO file?

PO files are distributed as text files containing the translated strings for a given language. Some advantages of using PO files instead of *.resx* files include:
- PO files support pluralization; *.resx* files don't support pluralization.
- PO files aren't compiled like *.resx* files. As such, specialized tooling and build steps aren't required.
- PO files work well with collaborative online editing tools.

### Example

The following sample PO file contains the translation for two strings in French, including one with its plural form:

*fr.po*

```text
#: Pages/Index.cshtml:13
msgid "Hello world!"
msgstr "Bonjour le monde!"

msgid "There is one item."
msgid_plural "There are {0} items."
msgstr[0] "Il y a un élément."
msgstr[1] "Il y a {0} éléments."
```

This example uses the following syntax:

- `#:`: A comment indicating the context of the string to be translated. The same string might be translated differently depending on where it's being used.
- `msgid`: The untranslated string.
- `msgstr`: The translated string.

For pluralization support, more entries can be defined.

- `msgid_plural`: The untranslated plural string.
- `msgstr[0]`: The translated string for the case 0.
- `msgstr[N]`: The translated string for the case N.

The PO file specification can be found [here](https://www.gnu.org/savannah-checkouts/gnu/gettext/manual/html_node/PO-Files.html).

## Configuring PO file support in ASP.NET Core

This example is based on an ASP.NET Core Web application generated from a Visual Studio 2022 project template.

### Referencing the package

Add a reference to the `OrchardCore.Localization.Core` NuGet package.

The `.csproj` file now contains a line similar to the following (version number may vary):

[!code-xml[](~/fundamentals/localization/sample/6.x/POLocalization/POLocalization.csproj?range=9)]

### Registering the service

Add the required services to `Program.cs`:

[!code-csharp[](~/fundamentals/localization/sample/6.x/POLocalization/Program.cs?name=snippet_LocalizationServices&highlight=9-16)]

Add the following code to your Razor page of choice. `Index.cshtml` is used in this example.

[!code-cshtml[](~/fundamentals/localization/sample/6.x/POLocalization/Pages/Index.cshtml)]

An `IViewLocalizer` instance is injected and used to translate the text "Hello world!".

### Creating a PO file

Create a file named *\<culture code>.po* in your application root folder. In this example, the file name is *fr.po* because the French language is used:

[!code-text[](~/fundamentals/localization/sample/6.x/POLocalization/fr.po)]

This file stores both the string to translate and the French-translated string. Translations revert to their parent culture, if necessary. In this example, the *fr.po* file is used if the requested culture is `fr-FR` or `fr-CA`.

### Testing the application

Run your application, the text **Hello world!** is displayed.

Navigate to the URL `/Index?culture=fr-FR`. The text **Bonjour le monde!** is displayed.

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

See [What is a PO file?](#what-is-a-po-file) for an explanation of what each entry in this example represents.

### Adding a language using different pluralization forms

English and French strings were used in the previous example. English and French have only two pluralization forms and share the same form rules, which is that a cardinality of one is mapped to the first plural form. Any other cardinality is mapped to the second plural form.

Not all languages share the same rules. This is illustrated with the Czech language, which has three plural forms.

Create the `cs.po` file as follows, and note how the pluralization needs three different translations:

[!code-text[](~/fundamentals/localization/sample/6.x/POLocalization/cs.po)]

To accept Czech localizations, add `"cs"` to the list of supported cultures in the `Configure` method:

```csharp
builder.Services
    .Configure<RequestLocalizationOptions>(options => options
        .AddSupportedCultures("fr", "cs")
        .AddSupportedUICultures("fr", "cs"));
```

Edit the `Pages/Index.cshtml` file to render localized, plural strings for several cardinalities:

```cshtml
<p>@Localizer.Plural(1, "There is one item.", "There are {0} items.")</p>
<p>@Localizer.Plural(2, "There is one item.", "There are {0} items.")</p>
<p>@Localizer.Plural(5, "There is one item.", "There are {0} items.")</p>
```

**Note:** In a real world scenario, a variable would be used to represent the count. Here, we repeat the same code with three different values to expose a specific case.

Upon switching cultures, you see the following:

For `/Index`:

```html
There is one item.
There are 2 items.
There are 5 items.
```

For `/Index?culture=fr`:

```html
Il y a un élément.
Il y a 2 éléments.
Il y a 5 éléments.
```

For `/Index?culture=cs`:

```html
Existuje jedna položka.
Existují 2 položky.
Existuje 5 položek.
```

For the Czech culture, the three translations are different. The French and English cultures share the same construction for the two last translated strings.

## Advanced tasks

### Contextualizing strings

Applications often contain the strings to be translated in several places. The same string may have a different translation in certain locations within an app (Razor views or class files). A PO file supports the notion of a file context, which can be used to categorize the string being represented. Using a file context, a string can be translated differently, depending on the file context (or lack of a file context).

The PO localization services use the name of the full class or the view that's used when translating a string. This is accomplished by setting the value on the `msgctxt` entry.

Consider a minor addition to the previous *fr.po* example. A Razor page located at `Pages/Index.cshtml` can be defined as the file context by setting the reserved `msgctxt` entry's value:

```text
msgctxt "Views.Home.About"
msgid "Hello world!"
msgstr "Bonjour le monde!"
```

With the `msgctxt` set as such, text translation occurs when navigating to `/Index?culture=fr-FR`. The translation doesn't occur when navigating to `/Privacy?culture=fr-FR`.

When no specific entry is matched with a given file context, Orchard Core's fallback mechanism looks for an appropriate PO file without a context. Assuming there's no specific file context defined for `Pages/Privacy.cshtml`, navigating to `/Privacy?culture=fr-FR` loads a PO file such as:

[!code-text[](~/fundamentals/localization/sample/6.x/POLocalization/fr.po)]

### Changing the location of PO files

The default location of PO files can be changed in `Programs.cs`:

```csharp
services.AddPortableObjectLocalization(options => options.ResourcesPath = "Localization");
```

In this example, the PO files are loaded from the *Localization* folder.

### Implementing a custom logic for finding localization files

When more complex logic is needed to locate PO files, the `OrchardCore.Localization.PortableObject.ILocalizationFileLocationProvider` interface can be implemented
and registered as a service. This is useful when PO files can be stored in varying locations or when the files have to be found within a hierarchy of folders.

### Using a different default pluralized language

The package includes a `Plural` extension method that's specific to two plural forms. For languages requiring more plural forms, create an extension method. With an extension method, you won't need to provide any localization file for the default language &mdash; the original strings are already available directly in the code.

You can use the more generic `Plural(int count, string[] pluralForms, params object[] arguments)` overload which accepts a string array of translations.

:::moniker-end

:::moniker range="= aspnetcore-5.0"

By [Sébastien Ros](https://github.com/sebastienros), [Scott Addie](https://twitter.com/Scott_Addie) and [Hisham Bin Ateya](https://github.com/hishamco)

This article walks through the steps for using Portable Object (PO) files in an ASP.NET Core application with the [Orchard Core](https://github.com/OrchardCMS/OrchardCore) framework.

**Note:** Orchard Core isn't a Microsoft product. Consequently, Microsoft provides no support for this feature.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/localization/sample/5.x/POLocalization) ([how to download](xref:index#how-to-download-a-sample))

## What is a PO file?

PO files are distributed as text files containing the translated strings for a given language. Some advantages of using PO files instead of *.resx* files include:
- PO files support pluralization; *.resx* files don't support pluralization.
- PO files aren't compiled like *.resx* files. As such, specialized tooling and build steps aren't required.
- PO files work well with collaborative online editing tools.

### Example

Here is a sample PO file containing the translation for two strings in French, including one with its plural form:

*fr.po*

```text
#: Pages/Index.cshtml:13
msgid "Hello world!"
msgstr "Bonjour le monde!"

msgid "There is one item."
msgid_plural "There are {0} items."
msgstr[0] "Il y a un élément."
msgstr[1] "Il y a {0} éléments."
```

This example uses the following syntax:

- `#:`: A comment indicating the context of the string to be translated. The same string might be translated differently depending on where it's being used.
- `msgid`: The untranslated string.
- `msgstr`: The translated string.

In the case of pluralization support, more entries can be defined.

- `msgid_plural`: The untranslated plural string.
- `msgstr[0]`: The translated string for the case 0.
- `msgstr[N]`: The translated string for the case N.

The PO file specification can be found [here](https://www.gnu.org/savannah-checkouts/gnu/gettext/manual/html_node/PO-Files.html).

## Configuring PO file support in ASP.NET Core

This example is based on an ASP.NET Core MVC application generated from a Visual Studio 2019 project template.

### Referencing the package

Add a reference to the `OrchardCore.Localization.Core` NuGet package.

The `.csproj` file now contains a line similar to the following (version number may vary):

[!code-xml[](~/fundamentals/localization/sample/5.x/POLocalization/POLocalization.csproj?range=8)]

### Registering the service

Add the required services to the `ConfigureServices` method of `Startup.cs`:

[!code-csharp[](~/fundamentals/localization/sample/5.x/POLocalization/Startup.cs?name=snippet_ConfigureServices&highlight=4-11)]

Add the required middleware to the `Configure` method of `Startup.cs`:

[!code-csharp[](~/fundamentals/localization/sample/3.x/POLocalization/Startup.cs?name=snippet_Configure&highlight=15)]

Add the following code to your Razor page of choice. `Index.cshtml` is used in this example.

[!code-cshtml[](~/fundamentals/localization/sample/5.x/POLocalization/Pages/Index.cshtml)]

An `IViewLocalizer` instance is injected and used to translate the text "Hello world!".

### Creating a PO file

Create a file named *\<culture code>.po* in your application root folder. In this example, the file name is *fr.po* because the French language is used:

[!code-text[](~/fundamentals/localization/sample/5.x/POLocalization/fr.po)]

This file stores both the string to translate and the French-translated string. Translations revert to their parent culture, if necessary. In this example, the *fr.po* file is used if the requested culture is `fr-FR` or `fr-CA`.

### Testing the application

Run your application, and navigate to the URL `/Index`. The text **Hello world!** is displayed.

Navigate to the URL `/Index?culture=fr-FR`. The text **Bonjour le monde!** is displayed.

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

See [What is a PO file?](#what-is-a-po-file) for an explanation of what each entry in this example represents.

### Adding a language using different pluralization forms

English and French strings were used in the previous example. English and French have only two pluralization forms and share the same form rules, which is that a cardinality of one is mapped to the first plural form. Any other cardinality is mapped to the second plural form.

Not all languages share the same rules. This is illustrated with the Czech language, which has three plural forms.

Create the `cs.po` file as follows, and note how the pluralization needs three different translations:

[!code-text[](~/fundamentals/localization/sample/5.x/POLocalization/cs.po)]

To accept Czech localizations, add `"cs"` to the list of supported cultures in the `ConfigureServices` method:

```csharp
services.Configure<RequestLocalizationOptions>(options => options
                .AddSupportedCultures("fr", "cs")
                .AddSupportedUICultures("fr", "cs")
            );
```

Edit the `Pages/Index.cshtml` file to render localized, plural strings for several cardinalities:

```cshtml
<p>@Localizer.Plural(1, "There is one item.", "There are {0} items.")</p>
<p>@Localizer.Plural(2, "There is one item.", "There are {0} items.")</p>
<p>@Localizer.Plural(5, "There is one item.", "There are {0} items.")</p>
```

**Note:** In a real world scenario, a variable would be used to represent the count. Here, we repeat the same code with three different values to expose a very specific case.

Upon switching cultures, you see the following:

For `/Index`:

```html
There is one item.
There are 2 items.
There are 5 items.
```

For `/Index?culture=fr`:

```html
Il y a un élément.
Il y a 2 éléments.
Il y a 5 éléments.
```

For `/Index?culture=cs`:

```html
Existuje jedna položka.
Existují 2 položky.
Existuje 5 položek.
```

Note that for the Czech culture, the three translations are different. The French and English cultures share the same construction for the two last translated strings.

## Advanced tasks

### Contextualizing strings

Applications often contain the strings to be translated in several places. The same string may have a different translation in certain locations within an app (Razor views or class files). A PO file supports the notion of a file context, which can be used to categorize the string being represented. Using a file context, a string can be translated differently, depending on the file context (or lack of a file context).

The PO localization services use the name of the full class or the view that's used when translating a string. This is accomplished by setting the value on the `msgctxt` entry.

Consider a minor addition to the previous *fr.po* example. A Razor view located at `Pages/Index.cshtml` can be defined as the file context by setting the reserved `msgctxt` entry's value:

```text
msgctxt "Pages.Index"
msgid "Hello world!"
msgstr "Bonjour le monde!"
```

With the `msgctxt` set as such, text translation occurs when navigating to `/Index?culture=fr-FR`. The translation won't occur when navigating to `/Privacy?culture=fr-FR`.

When no specific entry is matched with a given file context, Orchard Core's fallback mechanism looks for an appropriate PO file without a context. Assuming there's no specific file context defined for `Pages/Privacy.cshtml`, navigating to `/Privacy?culture=fr-FR` loads a PO file such as:

[!code-text[](~/fundamentals/localization/sample/5.x/POLocalization/fr.po)]

### Changing the location of PO files

The default location of PO files can be changed in `ConfigureServices`:

```csharp
services.AddPortableObjectLocalization(options => options.ResourcesPath = "Localization");
```

In this example, the PO files are loaded from the *Localization* folder.

### Implementing a custom logic for finding localization files

When more complex logic is needed to locate PO files, the `OrchardCore.Localization.PortableObject.ILocalizationFileLocationProvider` interface can be implemented
and registered as a service. This is useful when PO files can be stored in varying locations or when the files have to be found within a hierarchy of folders.

### Using a different default pluralized language

The package includes a `Plural` extension method that's specific to two plural forms. For languages requiring more plural forms, create an extension method. With an extension method, you won't need to provide any localization file for the default language &mdash; the original strings are already available directly in the code.

You can use the more generic `Plural(int count, string[] pluralForms, params object[] arguments)` overload which accepts a string array of translations.

:::moniker-end

:::moniker range="< aspnetcore-5.0"

By [Sébastien Ros](https://github.com/sebastienros), [Scott Addie](https://twitter.com/Scott_Addie) and [Hisham Bin Ateya](https://github.com/hishamco)

This article walks through the steps for using Portable Object (PO) files in an ASP.NET Core application with the [Orchard Core](https://github.com/OrchardCMS/OrchardCore) framework.

**Note:** Orchard Core isn't a Microsoft product. Consequently, Microsoft provides no support for this feature.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/localization/sample/3.x/POLocalization) ([how to download](xref:index#how-to-download-a-sample))

## What is a PO file?

PO files are distributed as text files containing the translated strings for a given language. Some advantages of using PO files instead of *.resx* files include:
- PO files support pluralization; *.resx* files don't support pluralization.
- PO files aren't compiled like *.resx* files. As such, specialized tooling and build steps aren't required.
- PO files work well with collaborative online editing tools.

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

- `#:`: A comment indicating the context of the string to be translated. The same string might be translated differently depending on where it's being used.
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

Add a reference to the `OrchardCore.Localization.Core` NuGet package.

The `.csproj` file now contains a line similar to the following (version number may vary):

[!code-xml[](~/fundamentals/localization/sample/3.x/POLocalization/POLocalization.csproj?range=8)]

### Registering the service

Add the required services to the `ConfigureServices` method of `Startup.cs`:

[!code-csharp[](~/fundamentals/localization/sample/3.x/POLocalization/Startup.cs?name=snippet_ConfigureServices&highlight=4-21)]

Add the required middleware to the `Configure` method of `Startup.cs`:

[!code-csharp[](~/fundamentals/localization/sample/3.x/POLocalization/Startup.cs?name=snippet_Configure&highlight=15)]

Add the following code to your Razor view of choice. `About.cshtml` is used in this example.

[!code-cshtml[](~/fundamentals/localization/sample/3.x/POLocalization/Views/Home/About.cshtml)]

An `IViewLocalizer` instance is injected and used to translate the text "Hello world!".

### Creating a PO file

Create a file named *\<culture code>.po* in your application root folder. In this example, the file name is *fr.po* because the French language is used:

[!code-text[](~/fundamentals/localization/sample/3.x/POLocalization/fr.po)]

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

See [What is a PO file?](#what-is-a-po-file) for an explanation of what each entry in this example represents.

### Adding a language using different pluralization forms

English and French strings were used in the previous example. English and French have only two pluralization forms and share the same form rules, which is that a cardinality of one is mapped to the first plural form. Any other cardinality is mapped to the second plural form.

Not all languages share the same rules. This is illustrated with the Czech language, which has three plural forms.

Create the `cs.po` file as follows, and note how the pluralization needs three different translations:

[!code-text[](~/fundamentals/localization/sample/3.x/POLocalization/cs.po)]

To accept Czech localizations, add `"cs"` to the list of supported cultures in the `ConfigureServices` method:

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

Edit the `Views/Home/About.cshtml` file to render localized, plural strings for several cardinalities:

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

Applications often contain the strings to be translated in several places. The same string may have a different translation in certain locations within an app (Razor views or class files). A PO file supports the notion of a file context, which can be used to categorize the string being represented. Using a file context, a string can be translated differently, depending on the file context (or lack of a file context).

The PO localization services use the name of the full class or the view that's used when translating a string. This is accomplished by setting the value on the `msgctxt` entry.

Consider a minor addition to the previous *fr.po* example. A Razor view located at `Views/Home/About.cshtml` can be defined as the file context by setting the reserved `msgctxt` entry's value:

```text
msgctxt "Views.Home.About"
msgid "Hello world!"
msgstr "Bonjour le monde!"
```

With the `msgctxt` set as such, text translation occurs when navigating to `/Home/About?culture=fr-FR`. The translation won't occur when navigating to `/Home/Contact?culture=fr-FR`.

When no specific entry is matched with a given file context, Orchard Core's fallback mechanism looks for an appropriate PO file without a context. Assuming there's no specific file context defined for `Views/Home/Contact.cshtml`, navigating to `/Home/Contact?culture=fr-FR` loads a PO file such as:

[!code-text[](~/fundamentals/localization/sample/3.x/POLocalization/fr.po)]

### Changing the location of PO files

The default location of PO files can be changed in `ConfigureServices`:

```csharp
services.AddPortableObjectLocalization(options => options.ResourcesPath = "Localization");
```

In this example, the PO files are loaded from the *Localization* folder.

### Implementing a custom logic for finding localization files

When more complex logic is needed to locate PO files, the `OrchardCore.Localization.PortableObject.ILocalizationFileLocationProvider` interface can be implemented
and registered as a service. This is useful when PO files can be stored in varying locations or when the files have to be found within a hierarchy of folders.

### Using a different default pluralized language

The package includes a `Plural` extension method that's specific to two plural forms. For languages requiring more plural forms, create an extension method. With an extension method, you won't need to provide any localization file for the default language &mdash; the original strings are already available directly in the code.

You can use the more generic `Plural(int count, string[] pluralForms, params object[] arguments)` overload which accepts a string array of translations.

:::moniker-end
