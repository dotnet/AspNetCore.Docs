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

ASP.NET Core localization APIs are build from ground up to be extensible, this will allow the developers to customize the localization according their needs. For instance [OrchardCore](https://github.com/orchardCMS/OrchardCore/) takes the initiative to build a `POStringLocalizer` which described in detail [Portable Object localization](fundamentals/portable-object-localization) to use `PO` files to store the localization resources.

This article lists two extensibility points that localization APIs have, including localization culture providers and localization resources baking store.

## Localization Culture Providers

ASP.NET Core localization APIs came up with four providers that can determine the current culture of the web application:

1. `QueryStringRequestCultureProvider`
2. `CookieRequestCultureProvider`
3. `AcceptLanguageHeaderRequestCultureProvider`
4. `CustomRequestCultureProvider`

All the above providers are described in detail [Localization middleware](fundamentals/localization), but in case if non of these providers don't meet your needs, you can build a custom provider using one of the following:
### Using `CustomRequestCultureProvider`

[CustomRequestCultureProvider](/dotnet/api/microsoft.aspnetcore.localization.customrequestcultureprovider?view=aspnetcore-2.1) provides a custom `RequestCultureProvider` that using a simple delegate allows you to determine the current localization culture.

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
As mentioned ealier there are four implementation of `RequestCultureProvider` out of the box, which determines the request culture information from various sources.

The developer can easily use this as extensible point to create a new implementation of `RequestCultureProvider` that determines the request culture information from custom source such as configuration file, database ... etc.

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