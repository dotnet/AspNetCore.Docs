---
title: Localization Extensibility
author: hishamco
description: Learn how to extend the localization APIs in ASP.NET Core apps.
ms.author: riande
ms.date: 03/27/2019
uid: fundamentals/localization-extensibility
---
# Localization Extensibility

By [Hisham Bin Ateya](https://github.com/hishamco)

This article lists the extensibility points on the localization APIs and provides instructions on how to extend ASP.NET Core app localization.

## Extensible Points in Localization APIs

ASP.NET Core localization APIs are built from the ground up to be extensible, this allows developers to customize the localization according to their needs. For instance [OrchardCore](https://github.com/orchardCMS/OrchardCore/) has a `POStringLocalizer` which describes in detail using [Portable Object localization](fundamentals/portable-object-localization) to use `PO` files to store localization resources.

This article lists the two main extensibility points that localization APIs have: `RequestCultureProvider` and `IStringLocalizer`.

## Localization Culture Providers

ASP.NET Core localization APIs has four providers by defult. These determine the current culture of executing request.:

1. `QueryStringRequestCultureProvider`
2. `CookieRequestCultureProvider`
3. `AcceptLanguageHeaderRequestCultureProvider`
4. `CustomRequestCultureProvider`

All the above providers are described in detail in the [Localization middleware](fundamentals/localization) documentation, but if non of these providers don't meet your needs you can build a custom provider using one of the following:
### Using `CustomRequestCultureProvider`

[CustomRequestCultureProvider](/dotnet/api/microsoft.aspnetcore.localization.customrequestcultureprovider?view=aspnetcore-2.1) provides a custom `RequestCultureProvider` that uses a simple delegate to determine the current localization culture.

::: moniker range=">= aspnetcore-2.2"

```csharp
options.AddInitialRequestCultureProvider(new CustomRequestCultureProvider(async context =>
{
    var currentCulture = "en";
    var segments = context.Request.Path.Value.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
    if (segments.Length > 1 && segments[0].Length == 2)
    {
        currentCulture = segments[0];
    }

    var requestCulture = new ProviderCultureResult(culture);
    
    return Task.FromResult(requestCulture);
}));
```
::: moniker-end

::: moniker range="< aspnetcore-2.2"

```csharp
options.RequestCultureProviders.Insert(0, new CustomRequestCultureProvider(async context =>
{
    var currentCulture = "en";
    var segments = context.Request.Path.Value.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
    if (segments.Length > 1 && segments[0].Length == 2)
    {
        currentCulture = segments[0];
    }

    var requestCulture = new ProviderCultureResult(culture);
    
    return Task.FromResult(requestCulture);
}));
```
::: moniker-end

### Using a new implemetation of `RequestCultureProvider`

The developer can also create a new implementation of `RequestCultureProvider` that determines the request culture information from a custom source such as configuration file, database ... etc.

The following example shows `AppSettingsRequestCultureProvider` which extend the `RequestCultureProvider` to determines the request culture information from `appsettings.json`.

```csharp
public class AppSettingsRequestCultureProvider : RequestCultureProvider
{
    public string CultureKey { get; set; } = "culture";

    public string UICultureKey { get; set; } = "ui-culture";

    public override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
    {
        if (httpContext == null)
        {
            throw new ArgumentNullException();
        }

        var configuration = httpContext.RequestServices.GetService<IConfigurationRoot>();
        var culture = configuration[CultureKey];
        var uiCulture = configuration[UICultureKey];

        if (culture == null && uiCulture == null)
        {
            return Task.FromResult((ProviderCultureResult)null);
        }

        if (culture != null && uiCulture == null)
        {
            uiCulture = culture;
        }

        if (culture == null && uiCulture != null)
        {
            culture = uiCulture;
        }
        
        var providerResultCulture = new ProviderCultureResult(culture, uiCulture);

        return Task.FromResult(providerResultCulture);
    }
}
```

## Localization Resources

ASP.NET Core localization provides `ResourceManagerStringLocalizer` which is an implementation of `IStringLocalizer` that is uses `resx` to store localization resources.

But you are not limited to using `resx` files. By implementing `IStringLocalized` you can use any data-source you want.

Here are some examples of projects which implement `IStringLocalizer`: [EFStringLocalizer](https://github.com/aspnet/Entropy/tree/master/samples/Localization.EntityFramework), [JsonStringLocalizer](https://github.com/hishamco/My.Extensions.Localization.Json), [SqlLocalizer](https://github.com/damienbod/AspNetCoreLocalization) .. etc.