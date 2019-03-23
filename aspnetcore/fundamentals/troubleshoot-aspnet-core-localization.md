---
title: Troubleshoot ASP.NET Core Localization
author: hishamco
description: Learn how to diagnose problems with localization in ASP.NET Core apps.
ms.date: 01/24/2019
uid: fundamentals/troubleshoot-aspnet-core-localization
---
# Troubleshoot ASP.NET Core Localization

By [Hisham Bin Ateya](https://github.com/hishamco)

This article provides instructions on how to diagnose ASP.NET Core app localization issues.

## Localization configuration issues

**Localization middleware order**  
The app may not localize because the localization middleware isn't ordered as expected.

To resolve this issue, ensure that localization middleware is registered before MVC middleware. Otherwise the localization will not applied on the running app.

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

ASP.NET Core has predefined rules and guidelines for localization resources file naming, which are described in detail [here](xref:fundamentals/localization?view=aspnetcore-2.2#resource-file-naming).

## Missing resources

Common causes of resources not being found include:

- Resource names are misspelled in either the `resx` file or the localizer request.
- The resource is missing from the `resx` for some languages, but exists in others.
- If you're still having trouble check the localization log messages (which are at `Debug` log level) for more details about the missing resources.

_**Hint:** In the case of `CookieRequestCultureProvider` be sure there's no single quotes around the cultures inside the localization cookie value. So `c='en-UK'|uic='en-US'` is an invalid cookie value, while `c=en-UK|uic=en-US` is a valid one._

## Resources & Class Libraries issues

## CustomRequestCultureProvider doesn't work as expected

The `RequestLocalizationOptions` class come up with three default providers:

1. `QueryStringRequestCultureProvider`
2. `CookieRequestCultureProvider`
3. `AcceptLanguageHeaderRequestCultureProvider`

The [CustomRequestCultureProvider](/dotnet/api/microsoft.aspnetcore.localization.customrequestcultureprovider?view=aspnetcore-2.1) is allows you to customize how the localization culture is provided in your application, in case the default providers doesn't meet your requirements.

The common cause that custom provider may not work properly is that your provider isn't the first provider in the `RequestCultureProviders` list. To resolve this issue:
- Insert your custom provider at the position 0 in the `RequestCultureProviders` list as the following:
```csharp
options.RequestCultureProviders.Insert(0, new CustomRequestCultureProvider(async context =>
    {
        // My custom request culture logic
        return new ProviderCultureResult("en");
    }));
```
- Use `AddInitialRequestCultureProvider` extension method to set your custom provider as initial provider.

## Root Namespace issues

When the root namespace of an assembly is different than the assembly name, the Localization does not work by default. To avoid this issue use the [RootNamespace](/dotnet/api/microsoft.extensions.localization.rootnamespaceattribute?view=aspnetcore-2.1) which is described in detail [here](xref:fundamentals/localization?view=aspnetcore-2.2#resource-file-naming)

## Resources & Build Action

If you use resource files for localization, it's very important that they have an appropriate build action. They should be **Embedded Resource**, otherwise the `ResourceStringLocalizer` not being able to find these resources.