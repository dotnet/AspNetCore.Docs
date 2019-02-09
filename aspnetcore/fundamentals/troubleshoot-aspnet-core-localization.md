---
title: Troubleshoot ASP.NET Core Localization
author: hishamco
description: Learn how to diagnose problems with localization in ASP.NET Core apps.
ms.date: 01/24/2019
uid: fundamentals/troubleshoot-aspnet-core-localization
---
# Troubleshoot ASP.NET Core Localization

By [Hisham Bin Ateya](https://github.com/hishamco)

This article provides instructions on how to diagnose an ASP.NET Core app localization issues.

## Localization configuration issues

**Localization middleware order setup**  
The app may not localized because the localization middleware order doesn't configured as expected.

To resolve such issue, please ensure that localization middleware is registered before MVC middleware, otherwise the localization will not applied on the running app.

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

Resource file naming issues are one of the common problems that we had ever seen in the community, especially the new developers. ASP.NET Core became with set of predefine rules and guidelines for localization resources file naming, which descriped in deatils in [Resource file naming](localization#resource-file-naming)

## Missing resources

Missing localization resources is one of common cases that may occur in many web applications, because the localization resource names are incorrect, the localization resources are not exist in the actual `.resx` files or resource file naming issues as its mentioned above.

To avoid such issues be sure that:
- Your localization resource names are set correctly
- Your localization resources are exist in the `resx` file of the current culture of your application
- Check the localization log messages - which they are in `Debug` level - for more details about the missing resources.

_**Hint:** In the case of `CookieRequestCultureProvider` be sure there's no single quotes surrounds the cultures inside the localization cookie value, so `c='en-UK'|uic='en-US'` is invalid cookie value, while `c=en-UK|uic=en-US` is a valid one._


## Resources & Class Libraries issues

## CustomRequestCultureProvide doesn't work as expected

## Root Namespace issues