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

## Root Namespace issues
