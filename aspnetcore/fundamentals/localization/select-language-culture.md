---
title: Strategies for selecting language and culture in a localized ASP.NET Core app
ai-usage: ai-assisted
description: Learn how to select a language and culture when localizing content into different languages and cultures in an ASP.NET Core app.
monikerRange: '>= aspnetcore-5.0'
ms.date: 10/30/2026
uid: fundamentals/localization/select-language-culture
---
# Implement a strategy to select the language/culture for each request in a localized ASP.NET Core app

[!INCLUDE[](~/includes/not-latest-version.md)]

:::moniker range=">= aspnetcore-8.0"

[Hisham Bin Ateya](https://twitter.com/hishambinateya), [Damien Bowden](https://github.com/damienbod), [Bart Calixto](https://twitter.com/bartmax), [Nadeem Afana](https://afana.me/), and [Rick Anderson](https://twitter.com/RickAndMSFT)

One task for localizing an app is to implement a strategy for selecting the appropriate culture for each response the app returns.

## Configure Localization middleware

The current culture on a request is set in the localization [Middleware](xref:fundamentals/middleware/index). The localization middleware is enabled in `Program.cs`. The localization middleware must be configured before any middleware that might check the request culture (for example, `app.UseMvcWithDefaultRoute()`).

[!code-csharp[](~/fundamentals/localization/samples/8.x/Localization/Program.cs?name=snippet_RequestLocalizationOptionsConfiguration)]

<xref:Microsoft.AspNetCore.Builder.ApplicationBuilderExtensions.UseRequestLocalization*> initializes a <xref:Microsoft.AspNetCore.Builder.RequestLocalizationOptions> object. On every request the list of <xref:Microsoft.AspNetCore.Localization.RequestCultureProvider> in the <xref:Microsoft.AspNetCore.Builder.RequestLocalizationOptions> is enumerated and the first provider that can successfully determine the request culture is used. The default providers come from the `RequestLocalizationOptions` class:

1. <xref:Microsoft.AspNetCore.Localization.QueryStringRequestCultureProvider>
1. <xref:Microsoft.AspNetCore.Localization.CookieRequestCultureProvider>
1. <xref:Microsoft.AspNetCore.Localization.AcceptLanguageHeaderRequestCultureProvider>

The default list goes from most specific to least specific. Later in the article you'll see how you can change the order and even add a custom culture provider. If none of the providers can determine the request culture, the <xref:Microsoft.AspNetCore.Builder.RequestLocalizationOptions.DefaultRequestCulture> is used.

## QueryStringRequestCultureProvider

Some apps will use a query string to set the <xref:System.Globalization.CultureInfo>. For apps that use the cookie or Accept-Language header approach, adding a query string to the URL is useful for debugging and testing code. By default, the <xref:Microsoft.AspNetCore.Localization.QueryStringRequestCultureProvider> is registered as the first localization provider in the `RequestCultureProvider` list. You pass the query string parameters `culture` and `ui-culture`. The following example sets the specific culture (language and region) to Spanish/Mexico:

```
http://localhost:5000/?culture=es-MX&ui-culture=es-MX
```

If only `culture` or `ui-culture` is passed in, the query string provider sets both values using the one passed in. For example, setting just the culture will set both the `Culture` and the `UICulture`:

```
http://localhost:5000/?culture=es-MX
```

## CookieRequestCultureProvider

Production apps will often provide a mechanism to set the culture with the ASP.NET Core culture cookie. Use the <xref:Microsoft.AspNetCore.Localization.CookieRequestCultureProvider.MakeCookieValue*> method to create a cookie.

The <xref:Microsoft.AspNetCore.Localization.CookieRequestCultureProvider> <xref:Microsoft.AspNetCore.Localization.CookieRequestCultureProvider.DefaultCookieName> returns the default cookie name used to track the user's preferred culture information. The default cookie name is `.AspNetCore.Culture`.

The cookie format is `c=%LANGCODE%|uic=%LANGCODE%`, where `c` is `Culture` and `uic` is `UICulture`, for example:

```
c=en-UK|uic=en-US
```

If only one of the cultures is provided and the other is empty, the provided culture is used for both culture and UI culture.

## The Accept-Language HTTP header

The [Accept-Language header](https://www.w3.org/International/questions/qa-accept-lang-locales) is settable in most browsers and was originally intended to specify the user's language. This setting indicates what the browser has been set to send or has inherited from the underlying operating system. The Accept-Language HTTP header from a browser request isn't an infallible way to detect the user's preferred language (see [Setting language preferences in a browser](https://www.w3.org/International/questions/qa-lang-priorities.en.php)). A production app should include a way for a user to customize their choice of culture.

## Set the Accept-Language HTTP header in Edge

1. Search **Settings** for **Preferred languages**.

1. The preferred languages are listed in the **Preferred languages** box.

1. Select **Add languages** to add to the list.

1. Select **More actions …** next to a language to change the order of preference.

## The Content-Language HTTP header

The [Content-Language](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Language) entity header:

* Is used to describe the languages intended for the audience.
* Allows a user to differentiate according to the users' own preferred language.

Entity headers are used in both HTTP requests and responses.

The `Content-Language` header can be added by setting the property <xref:Microsoft.AspNetCore.Builder.RequestLocalizationOptions.ApplyCurrentCultureToResponseHeaders>.

Adding the [`Content-Language`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Language) header:

* Allows the <xref:Microsoft.AspNetCore.Localization.RequestLocalizationMiddleware> to set the `Content-Language` header with the `CurrentUICulture`.
* Eliminates the need to set the response header `Content-Language` explicitly.

```csharp
app.UseRequestLocalization(new RequestLocalizationOptions
{
    ApplyCurrentCultureToResponseHeaders = true
});
```

## Apply the RouteDataRequest CultureProvider

The <xref:Microsoft.AspNetCore.Localization.Routing.RouteDataRequestCultureProvider> sets the culture based on the value of the `culture` and `ui-culture` route values in the request URL.

To configure `RouteDataRequestCultureProvider`, register the provider in <xref:Microsoft.AspNetCore.Builder.RequestLocalizationOptions> and define route patterns containing the `{culture}` route parameter:

```csharp
var supportedCultures = new[] { "en-US", "fr-FR", "ru" };

var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture("en-US")
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

// Insert RouteDataRequestCultureProvider at the beginning so route data takes precedence
localizationOptions.RequestCultureProviders.Insert(0, new RouteDataRequestCultureProvider());

app.UseRouting();

app.UseRequestLocalization(localizationOptions);
```

> [!NOTE]
> When using `RouteDataRequestCultureProvider`, `app.UseRequestLocalization` must be called after `app.UseRouting` so that route data is available when resolving the culture.

### Localized route templates and fallback

To support both culture-prefixed URLs (such as `/ru/Home/Index` or `/ru/Index`) and culture-less URLs (such as `/Home/Index` or `/Index`) while allowing fallback to other culture providers (like cookies or `Accept-Language` headers), configure a route with a `{culture}` segment alongside a default route.

**Controllers:**

Map a localized route with a `{culture}` segment, followed by the default route without a culture prefix:

```csharp
app.MapControllerRoute(
    name: "localized",
    pattern: "{culture}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
```

With this configuration:
* Requests with a culture prefix (such as `/ru/Home/Index`) match the `localized` route. `RouteDataRequestCultureProvider` determines the request culture from route data.
* If the culture value is absent or unsupported, culture resolution falls back to the next registered provider (such as a cookie or `Accept-Language` header) or to `DefaultRequestCulture`.

**Razor Pages:**

In Razor Pages, relative `@page` templates append parameters to the existing page route (for example, `@page "{culture?}"` on `Pages/Index.cshtml` matches `/Index/ru` rather than `/ru/Index`). To support a culture prefix without replacing the default page route, configure an additional page route using <xref:Microsoft.Extensions.DependencyInjection.PageConventionCollectionExtensions.AddPageRoute*>:

```csharp
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AddPageRoute("/Index", "{culture}/Index");
});
```

To add culture-prefixed routes to all pages in a folder, use <xref:Microsoft.AspNetCore.Mvc.ApplicationModels.PageConventionCollection.AddFolderRouteModelConvention*>:

```csharp
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AddFolderRouteModelConvention("/", model =>
    {
        var selectorCount = model.Selectors.Count;
        for (var i = 0; i < selectorCount; i++)
        {
            var selector = model.Selectors[i];
            model.Selectors.Add(new()
            {
                AttributeRouteModel = new()
                {
                    Order = 1,
                    Template = AttributeRouteModel.CombineTemplates(
                        "{culture}",
                        selector.AttributeRouteModel?.Template)
                }
            });
        }
    });
});
```

For more information, see [Url culture provider using middleware as filters](https://andrewlock.net/url-culture-provider-using-middleware-as-mvc-filter-in-asp-net-core-1-1-0/) and [Applying the RouteDataRequest CultureProvider globally with middleware as filters](https://andrewlock.net/applying-the-routedatarequest-cultureprovider-globally-with-middleware-as-filters/).

## Use a custom provider

Suppose you want to let your customers store their language and culture in your databases. You could write a provider to look up these values for the user. The following code shows how to add a custom provider:

```csharp
private const string enUSCulture = "en-US";

services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo(enUSCulture),
        new CultureInfo("fr")
    };

    options.DefaultRequestCulture = new RequestCulture(culture: enUSCulture, uiCulture: enUSCulture);
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;

    options.AddInitialRequestCultureProvider(new CustomRequestCultureProvider(async context =>
    {
        // My custom request culture logic
        return await Task.FromResult(new ProviderCultureResult("en"));
    }));
});
```

Use `RequestLocalizationOptions` to add or remove localization providers.

## Change request culture providers order

<xref:Microsoft.AspNetCore.Builder.RequestLocalizationOptions> has three default request culture providers: <xref:Microsoft.AspNetCore.Localization.QueryStringRequestCultureProvider>, <xref:Microsoft.AspNetCore.Localization.CookieRequestCultureProvider>, and <xref:Microsoft.AspNetCore.Localization.AcceptLanguageHeaderRequestCultureProvider>. Use [`RequestLocalizationOptions.RequestCultureProviders`](xref:Microsoft.AspNetCore.Builder.RequestLocalizationOptions.RequestCultureProviders) property to change the order of these providers as shown in the following below:

```csharp
    app.UseRequestLocalization(options =>
    {
        var questStringCultureProvider = options.RequestCultureProviders[0];    
        options.RequestCultureProviders.RemoveAt(0);
        options.RequestCultureProviders.Insert(1, questStringCultureProvider);
    });
```

In the preceding example, the order of `QueryStringRequestCultureProvider` and `CookieRequestCultureProvider` is switched, so the `RequestLocalizationMiddleware` looks for the cultures from the cookies first, then the query string.

As previously mentioned, add a custom provider via <xref:Microsoft.AspNetCore.Builder.RequestLocalizationOptionsExtensions.AddInitialRequestCultureProvider*> which sets the order to `0`, so this provider takes the precedence over the others.

## User override culture

The [RequestLocalizationOptions.CultureInfoUseUserOverride](xref:Microsoft.AspNetCore.Builder.RequestLocalizationOptions.CultureInfoUseUserOverride) property allows the app to decide whether or not to use non-default Windows settings for the <xref:System.Globalization.CultureInfo> <xref:System.Globalization.CultureInfo.DateTimeFormat> and <xref:System.Globalization.CultureInfo.NumberFormat> properties. This has ***no*** impact on Linux. This directly corresponds to <xref:System.Globalization.CultureInfo.UseUserOverride>.

```csharp
    app.UseRequestLocalization(options =>
    {
        options.CultureInfoUseUserOverride = false;
    });
```

## Set the culture programmatically

This sample **Localization.StarterWeb** project on [GitHub](https://github.com/aspnet/entropy) contains UI to set the `Culture`. The `Views/Shared/_SelectLanguagePartial.cshtml` file allows you to select the culture from the list of supported cultures:

[!code-cshtml[](~/fundamentals/localization/samples/8.x/Localization/Views/Shared/_SelectLanguagePartial.cshtml)]

The `Views/Shared/_SelectLanguagePartial.cshtml` file is added to the `footer` section of the layout file so it will be available to all views:

[!code-cshtml[](~/fundamentals/localization/samples/8.x/Localization/Views/Shared/_Layout.cshtml?range=43-56&highlight=10)]

The `SetLanguage` method sets the culture cookie.

[!code-csharp[](~/fundamentals/localization/samples/8.x/Localization/Controllers/HomeController.cs?range=57-67)]

You can't plug in the `_SelectLanguagePartial.cshtml` to sample code for this project. The **Localization.StarterWeb** project on [GitHub](https://github.com/aspnet/entropy) has code to flow the `RequestLocalizationOptions` to a Razor partial through the [Dependency Injection](~/fundamentals/dependency-injection.md) container.

## Model binding route data and query strings

See [Globalization behavior of model binding route data and query strings](xref:mvc/models/model-binding#glob).

## Next steps

Localizing an app also involves the following tasks:

* [Make the app's content localizable](xref:fundamentals/localization/make-content-localizable).
* [Provide localized resources for the languages and cultures the app supports](xref:fundamentals/localization/provide-resources)

## Related content

* [Url culture provider using middleware as filters in ASP.NET Core](https://andrewlock.net/url-culture-provider-using-middleware-as-mvc-filter-in-asp-net-core-1-1-0/)
* [Applying the RouteDataRequest CultureProvider globally with middleware as filters](https://andrewlock.net/applying-the-routedatarequest-cultureprovider-globally-with-middleware-as-filters/)
* <xref:fundamentals/localization>
* <xref:fundamentals/localization/make-content-localizable>
* <xref:fundamentals/localization/provide-resources>
* <xref:fundamentals/troubleshoot-aspnet-core-localization>
* [Globalizing and localizing .NET applications](/dotnet/standard/globalization-localization/index)
* [Localization.StarterWeb project](https://github.com/aspnet/Entropy/tree/master/samples/Localization.StarterWeb) used in the article.
* [Resources in .resx Files](/dotnet/framework/resources/working-with-resx-files-programmatically)
* [Localization & Generics](http://hishambinateya.com/localization-and-generics)

:::moniker-end

[!INCLUDE [select-language-culture67](~/fundamentals/localization/includes/select-language-culture67.md)]
[!INCLUDE [select-language-culture5](~/fundamentals/localization/includes/select-language-culture5.md)]
