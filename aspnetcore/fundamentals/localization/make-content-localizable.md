---
title: Make an ASP.NET Core app's content localizable
author: wadepickett
description: Learn how to make an ASP.NET Core app's content localizable to prepare the app for localizing content into different languages and cultures.
ms.author: wpickett
monikerRange: '>= aspnetcore-5.0'
ms.date: 06/20/2025
uid: fundamentals/localization/make-content-localizable
---
# Make an ASP.NET Core app's content localizable

[!INCLUDE[](~/includes/not-latest-version.md)]

:::moniker range="> aspnetcore-5.0"

By [Hisham Bin Ateya](https://twitter.com/hishambinateya), [Damien Bowden](https://github.com/damienbod), [Bart Calixto](https://twitter.com/bartmax) and [Nadeem Afana](https://afana.me/)

One task for localizing an app is to wrap localizable content with code that facilitates replacing that content for different cultures.

## `IStringLocalizer`

<xref:Microsoft.Extensions.Localization.IStringLocalizer> and <xref:Microsoft.Extensions.Localization.IStringLocalizer%601> were architected to improve productivity when developing localized apps. `IStringLocalizer` uses the <xref:System.Resources.ResourceManager> and <xref:System.Resources.ResourceReader> to provide culture-specific resources at run time. The interface has an indexer and an `IEnumerable` for returning localized strings. `IStringLocalizer` doesn't require storing the default language strings in a resource file. You can develop an app targeted for localization and not need to create resource files early in development.  

The following code example shows how to wrap the string "About Title" for localization.

[!code-csharp[](~/fundamentals/localization/sample/8.x/Localization/Controllers/AboutController.cs)]

In the preceding code, the `IStringLocalizer<T>` implementation comes from [Dependency Injection](~/fundamentals/dependency-injection.md). If the localized value of "About Title" isn't found, then the indexer key is returned, that is, the string "About Title".

You can leave the default language literal strings in the app and wrap them in the localizer, so that you can focus on developing the app. You develop an app with your default language and prepare it for the localization step without first creating a default resource file.

Alternatively, you can use the traditional approach and provide a key to retrieve the default language string. For many developers, the new workflow of not having a default language *.resx* file and simply wrapping the string literals can reduce the overhead of localizing an app. Other developers prefer the traditional work flow as it can be easier to work with long string literals and easier to update localized strings.

## `IHtmlLocalizer`

Use the <xref:Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizer%601> implementation for resources that contain HTML. <xref:Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizer> HTML-encodes arguments that are formatted in the resource string, but doesn't HTML-encode the resource string itself. In the following highlighted code, only the value of the `name` parameter is HTML-encoded.

[!code-csharp[](~/fundamentals/localization/sample/8.x/Localization/Controllers/BookController.cs?highlight=3,5,20&start=1&end=24)]

***NOTE:*** Generally, only localize text, not HTML.

## `IStringLocalizerFactory`

At the lowest level, <xref:Microsoft.Extensions.Localization.IStringLocalizerFactory> can be retrieved from of [Dependency Injection](~/fundamentals/dependency-injection.md):

[!code-csharp[](~/fundamentals/localization/sample/8.x/Localization/Controllers/TestController.cs?highlight=6-12&name=snippet_1)]

The preceding code demonstrates each of the two factory create methods.

## Shared resources

You can partition your localized strings by controller or area, or have just one container. In the sample app, a marker class named `SharedResource` is used for shared resources. The marker class is never called:

[!code-csharp[](~/fundamentals/localization/sample/8.x/Localization/SharedResource.cs)]

In the following sample, the `InfoController` and the `SharedResource` localizers are used:

[!code-csharp[](~/fundamentals/localization/sample/8.x/Localization/Controllers/InfoController.cs?name=snippet_1)]

## View localization

The <xref:Microsoft.AspNetCore.Mvc.Localization.IViewLocalizer> service provides localized strings for a [view](xref:mvc/views/overview). The `ViewLocalizer` class implements this interface and finds the resource location from the view file path. The following code shows how to use the default implementation of `IViewLocalizer`:

[!code-cshtml[](~/fundamentals/localization/sample/8.x/Localization/Views/Home/About.cshtml)]

The default implementation of `IViewLocalizer` finds the resource file based on the view's file name. There's no option to use a global shared resource file. `ViewLocalizer` implements the localizer using `IHtmlLocalizer`, so Razor doesn't HTML-encode the localized string. You can parameterize resource strings, and `IViewLocalizer` HTML-encodes the parameters but not the resource string. Consider the following Razor markup:

```cshtml
@Localizer["<i>Hello</i> <b>{0}!</b>", UserManager.GetUserName(User)]
```

A French resource file could contain the following values:

| Key                        | Value                         |
| -------------------------- | ----------------------------- |
| `<i>Hello</i> <b>{0}!</b>` | `<i>Bonjour</i> <b>{0} !</b>` |

The rendered view would contain the HTML markup from the resource file.

Generally, ***only localize text***, not HTML.

To use a shared resource file in a view, inject `IHtmlLocalizer<T>`:

[!code-cshtml[](~/fundamentals/localization/sample/8.x/Localization/Views/Test/About.cshtml?highlight=5,12)]

## DataAnnotations localization

DataAnnotations error messages are localized with `IStringLocalizer<T>`. Using the option `ResourcesPath = "Resources"`, the error messages in `RegisterViewModel` can be stored in either of the following paths:

* *Resources/ViewModels.Account.RegisterViewModel.fr.resx*
* *Resources/ViewModels/Account/RegisterViewModel.fr.resx*

[!code-csharp[](~/fundamentals/localization/sample/8.x/Localization/ViewModels/Account/RegisterViewModel.cs)]

Non-validation attributes are localized.

<a name="one-resource-string-multiple-classes"></a>

### How to use one resource string for multiple classes

The following code shows how to use one resource string for validation attributes with multiple classes:

```csharp
    services.AddMvc()
        .AddDataAnnotationsLocalization(options => {
            options.DataAnnotationLocalizerProvider = (type, factory) =>
                factory.Create(typeof(SharedResource));
        });
```

In the preceding code, `SharedResource` is the class corresponding to the *.resx* file where the validation messages are stored. With this approach, DataAnnotations only uses `SharedResource`, rather than the resource for each class.

:::moniker-end

:::moniker range=">= aspnetcore-11.0"

## DataAnnotations localization in Minimal APIs and Blazor

Validation localization is available for Minimal API and Blazor apps that opt into the `Microsoft.Extensions.Validation` pipeline by calling `AddValidation()` in `Program.cs`. Localize validation error messages and the display names of validated properties and parameters by also calling `AddValidationLocalization`:

```csharp
builder.Services.AddValidation();
builder.Services.AddValidationLocalization<ValidationResources>();
```

The localization integration does not apply to MVC and Razor Pages apps, or to Blazor forms that don't include `AddValidation`.

> [!NOTE]
 > The integration is provided by the `Microsoft.Extensions.Validation.Localization` package, which builds on the `Microsoft.Extensions.Validation` package. Both packages are included in the Web SDK (`Microsoft.NET.Sdk.Web`) and the Razor SDK (`Microsoft.NET.Sdk.Razor`), so apps that use those SDKs don't need explicit package references. Standalone Blazor WebAssembly apps and other project that do not use the Web SDK or the Razor SDK must reference both packages explicitly:
>
> ```xml
> <PackageReference Include="Microsoft.Extensions.Validation" Version="11.0.0" />
> <PackageReference Include="Microsoft.Extensions.Validation.Localization" Version="11.0.0" />
> ```

### Resource file lookup

By default, validation localization resolves messages and display names from *.resx* resource files using ASP.NET Core's standard <xref:Microsoft.Extensions.Localization.IStringLocalizer> infrastructure. For an overview of authoring and naming *.resx* files, see <xref:fundamentals/localization/provide-resources>.

To use a shared resource file for every validated type, pass a marker type argument to `AddValidationLocalization`:

```csharp
builder.Services.AddValidationLocalization<ValidationResources>();
```

The marker type identifies the *.resx* file the framework uses (for example, `ValidationResources.resx` for the default culture and `ValidationResources.fr.resx` for French).

> [!IMPORTANT]
> A shared resource file is necessary for Minimal APIs, because top-level parameters on Minimal API endpoints don't have a containing type that the default per-type convention can key on.

For per-type resource file resolution, use the non-generic overload of `AddValidationLocalization`:

```csharp
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddValidationLocalization();
```

This approach follows the standard ASP.NET Core convention: under the project's configured `ResourcesPath`, the type's full name (without the project's root namespace prefix) is used as a dotted path. For example, with `ResourcesPath = "Resources"`, a project whose root namespace is `Contoso` looks up validation messages for `Contoso.Models.Customer` in `Resources/Models/Customer.fr.resx` (or equivalently `Resources/Models.Customer.fr.resx`) for French. For a full description of the *.resx* naming and placement conventions, see <xref:fundamentals/localization/provide-resources>.

#### Customize the localizer creation

For full control over which *.resx* file to use for a given validated type, set `ValidationLocalizationOptions.LocalizerProvider`. The delegate receives the validated type and an <xref:Microsoft.Extensions.Localization.IStringLocalizerFactory>, and returns the <xref:Microsoft.Extensions.Localization.IStringLocalizer> to use:

```csharp
builder.Services.AddValidationLocalization(options =>
{
    options.LocalizerProvider = (type, factory) =>
        type is not null && type.Namespace?.StartsWith("Contoso.Admin") == true
            ? factory.Create(typeof(AdminValidationResources))
            : factory.Create(typeof(SharedValidationResources));
});
```

### Localizing from other sources

The localization data doesn't have to come from *.resx* files. Validation localization resolves strings through whichever <xref:Microsoft.Extensions.Localization.IStringLocalizerFactory> is registered in DI. Registering a custom factory implementation switches validation messages to that factory's backing store, with no further configuration:

```csharp
builder.Services.AddSingleton<IStringLocalizerFactory, MyJsonStringLocalizerFactory>();
builder.Services.AddValidation();
builder.Services.AddValidationLocalization();
```

This can be used to load localized messages from JSON files, databases, remote translation services, and other sources.

### What gets localized

When validation localization is configured:

* Error messages whose <xref:System.ComponentModel.DataAnnotations.ValidationAttribute.ErrorMessage> property is set to a resource key are looked up by that key. If no resource entry matches, the literal value of `ErrorMessage` is used as the error message.
* Display names supplied as literal strings through `[Display(Name = "...")]` or `[DisplayName("...")]` are looked up by the literal value as a resource key. If no resource entry matches, the literal value is used as the display name.

Attributes that use static resource localization (via the `DisplayAttribute.ResourceType` and `ValidationAttribute.ErrorMessageResourceType` properties) are not processed by the validation localizer registered by `AddValidationLocalization`.

### Localize the built-in validation messages

Some applications might find it useful to translate or override the default error messages of attributes like <xref:System.ComponentModel.DataAnnotations.RequiredAttribute> and <xref:System.ComponentModel.DataAnnotations.StringLengthAttribute> without setting <xref:System.ComponentModel.DataAnnotations.ValidationAttribute.ErrorMessage> on every attribute instance. This can be achieved by an `ErrorMessageKeyProvider` that derives a resource key programmatically:

```csharp
builder.Services.AddValidationLocalization(options =>
{
    options.ErrorMessageKeyProvider = ctx => ctx.Attribute.ErrorMessage is not null
        ? ctx.Attribute.ErrorMessage
        : $"{ctx.Attribute.GetType().Name}_Error";
});
```

With the preceding configuration, a `[Required]` attribute with no `ErrorMessage` looks up the resource key `RequiredAttribute_Error`, a `[StringLength(50)]` looks up `StringLengthAttribute_Error`, and so on. The key provider runs only when `ErrorMessage` isn't set on the attribute instance, so model-specific overrides via `ErrorMessage = "MyKey"` continue to take precedence.

:::moniker-end

:::moniker range="> aspnetcore-5.0"

## Configure localization services

Localization services are configured in `Program.cs`:

[!code-csharp[](~/fundamentals/localization/sample/6.x/Localization/program.cs?name=snippet_LocalizationConfigurationServices)]

* <xref:Microsoft.Extensions.DependencyInjection.LocalizationServiceCollectionExtensions.AddLocalization%2A> adds the localization services to the services container, including implementations for `IStringLocalizer<T>` and `IStringLocalizerFactory`. The preceding code also sets the resources path to "Resources".

* <xref:Microsoft.Extensions.DependencyInjection.MvcLocalizationMvcBuilderExtensions.AddViewLocalization%2A> adds support for localized view files. In this sample, view localization is based on the view file suffix. For example "fr" in the `Index.fr.cshtml` file.

* <xref:Microsoft.Extensions.DependencyInjection.MvcDataAnnotationsMvcBuilderExtensions.AddDataAnnotationsLocalization%2A> adds support for localized `DataAnnotations` validation messages through `IStringLocalizer` abstractions.

[!INCLUDE[](~/includes/localization/currency.md)]

## Next steps

Localizing an app also involves the following tasks:

* [Provide localized resources for the languages and cultures the app supports](xref:fundamentals/localization/provide-resources)
* [Implement a strategy to select the language/culture for each request](xref:fundamentals/localization/select-language-culture)

## Additional resources

* [Url culture provider using middleware as filters in ASP.NET Core](https://andrewlock.net/url-culture-provider-using-middleware-as-mvc-filter-in-asp-net-core-1-1-0/)
* [Applying the RouteDataRequest CultureProvider globally with middleware as filters](https://andrewlock.net/applying-the-routedatarequest-cultureprovider-globally-with-middleware-as-filters/)
* <xref:fundamentals/localization>
* <xref:fundamentals/localization/provide-resources>
* <xref:fundamentals/localization/select-language-culture>
* <xref:fundamentals/troubleshoot-aspnet-core-localization>
* [Globalizing and localizing .NET applications](/dotnet/standard/globalization-localization/index)
* [Localization.StarterWeb project](https://github.com/aspnet/Entropy/tree/master/samples/Localization.StarterWeb) used in the article.
* [Resources in .resx Files](/dotnet/framework/resources/working-with-resx-files-programmatically)
* [Localization & Generics](http://hishambinateya.com/localization-and-generics)

:::moniker-end

[!INCLUDE [make-content-localizable5](~/fundamentals/localization/includes/make-content-localizable5.md)]
