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

## Resources & Class Libraries issues

## CustomRequestCultureProvide doesn't work as expected

## Root Namespace issues