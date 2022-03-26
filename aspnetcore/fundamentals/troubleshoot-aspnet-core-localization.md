---
title: Troubleshoot ASP.NET Core Localization
author: hishamco
description: Learn how to diagnose problems with localization in ASP.NET Core apps.
ms.author: riande
ms.date: 01/24/2019
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: fundamentals/troubleshoot-aspnet-core-localization
---
# Troubleshoot ASP.NET Core Localization

By [Hisham Bin Ateya](https://github.com/hishamco)

This article provides instructions on how to diagnose ASP.NET Core app localization issues.

## Localization configuration issues

**Localization middleware order**  
The app may not localize because the localization middleware isn't ordered as expected.

To resolve this issue, ensure that localization middleware is registered before MVC middleware. Otherwise, the localization middleware isn't applied.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddLocalization(options => options.ResourcesPath = "Resources");

    services.AddMvc();
}
```

**Localization resources path not found**

**Supported Cultures in RequestCultureProvider don't match with registered once**  

## Resource file naming issues

ASP.NET Core has predefined rules and guidelines for localization resources file naming, which are described in detail [here](xref:fundamentals/localization#resource-file-naming).

## Missing resources

Common causes of resources not being found include:

- Resource names are misspelled in either the `resx` file or the localizer request.
- The resource is missing from the `resx` for some languages, but exists in others.
- If you're still having trouble, check the localization log messages (which are at `Debug` log level) for more details about the missing resources.

_**Hint:** When using `CookieRequestCultureProvider`, verify single quotes are not used with the cultures inside the localization cookie value. For example, `c='en-UK'|uic='en-US'` is an invalid cookie value, while `c=en-UK|uic=en-US` is a valid._

## Resources & Class Libraries issues

ASP.NET Core by default provides a way to allow the class libraries to find their resource files via <xref:Microsoft.Extensions.Localization.ResourceLocationAttribute>.

Common issues with class libraries include:
- Missing the `ResourceLocationAttribute` in a class library will prevent `ResourceManagerStringLocalizerFactory` from discovering the resources.
- Resource file naming. For more information, see [Resource file naming issues](#resource-file-naming-issues) section.
- Changing the root namespace of the class library. For more information, see [Root Namespace issues](#root-namespace-issues) section.

## CustomRequestCultureProvider doesn't work as expected

The `RequestLocalizationOptions` class has three default providers:

1. `QueryStringRequestCultureProvider`
2. `CookieRequestCultureProvider`
3. `AcceptLanguageHeaderRequestCultureProvider`

The <xref:Microsoft.AspNetCore.Localization.CustomRequestCultureProvider> allows you to customize how the localization culture is provided in your app. The `CustomRequestCultureProvider` is used when the default providers don't meet your requirements.

- A common reason custom provider don't work properly is that it isn't the first provider in the `RequestCultureProviders` list. To resolve this issue:

- Insert the custom provider at the position 0 in the `RequestCultureProviders` list as the following:

:::moniker range="< aspnetcore-3.0"
```csharp
options.RequestCultureProviders.Insert(0, new CustomRequestCultureProvider(async context =>
    {
        // My custom request culture logic
        return new ProviderCultureResult("en");
    }));
```
:::moniker-end

:::moniker range=">= aspnetcore-3.0"
```csharp
options.AddInitialRequestCultureProvider(new CustomRequestCultureProvider(async context =>
    {
        // My custom request culture logic
        return new ProviderCultureResult("en");
    }));
```
:::moniker-end

- Use `AddInitialRequestCultureProvider` extension method to set the custom provider as initial provider.

## Root Namespace issues

When the root namespace of an assembly is different than the assembly name, localization doesn't work by default. To avoid this issue use [RootNamespace](xref:Microsoft.Extensions.Localization.RootNamespaceAttribute), which is described in detail [here](xref:fundamentals/localization#resource-file-naming)

> [!WARNING]
> This can occur when a project's name is not a valid .NET identifier. For instance `my-project-name.csproj` will use the root namespace `my_project_name` and the assembly name `my-project-name` leading to this error. 

## Resources & Build Action

If you use resource files for localization, it's important that they have an appropriate build action. They should be **Embedded Resource**, otherwise the `ResourceStringLocalizer` is not able to find these resources.
