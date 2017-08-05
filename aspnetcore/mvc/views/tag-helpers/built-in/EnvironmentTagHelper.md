---
title: Environment Tag Helper in ASP.NET Core
author: pkellner
description: ASP.Net Core Environment Tag Helper defined including all properties
keywords: ASP.NET Core,tag helper
ms.author: riande
manager: wpickett
ms.date: 07/14/2017
ms.topic: article
ms.technology: aspnet
ms.prod: aspnet-core
uid: mvc/views/tag-helpers/builtin-th/EnvironmentTagHelper
---
# Environment Tag Helper in ASP.NET Core

By [Peter Kellner](http://peterkellner.net) and [Hisham Bin Ateya](https://twitter.com/hishambinateya)

The Environment Tag Helper conditionally renders its enclosed content based on the current hosting environment. Its single attribute `names` is a comma separated list of environment names, that if any match to the current environment, will trigger the enclosed content to be rendered.

## Environment Tag Helper Attributes

### names

Accepts a single hosting environment name or a comma-separated list of hosting environment names that trigger the rendering of the enclosed content.

These value(s) are compared to the current value returned from the ASP.NET Core static property `HostingEnvironment.EnvironmentName`.  This value is one of the following: **Staging**; **Development** or **Production**. The comparison ignores case.

An example of a valid `environment` tag helper is:

```cshtml
<environment names="Staging,Production">
  <strong>HostingEnvironment.EnvironmentName is Staging or Production</strong>
</environment>
```

## include and exclude attributes

ASP.NET Core 2.x adds the `include` & `exclude` attributes. These attributes control rendering the enclosed content based on the included or excluded hosting environment names.

### include ASP.NET Core 2.0 and later

The `include` property has a similar behavior of the `names` attribute in ASP.NET Core 1.0.

```cshtml
<environment include="Staging,Production">
  <strong>HostingEnvironment.EnvironmentName is Staging or Production</strong>
</environment>
```

### exclude ASP.NET Core 2.0 and later

In contrast, the `exclude` property lets the `EnvironmentTagHelper` render the enclosed content for all hosting environment names except the one(s) that you specified.

```cshtml
<environment exclude="Development">
  <strong>HostingEnvironment.EnvironmentName is Staging or Production</strong>
</environment>
```

## Additional resources

* <xref:fundamentals/environments>
* <xref:fundamentals/dependency-injection#service-lifetimes-and-registration-options>