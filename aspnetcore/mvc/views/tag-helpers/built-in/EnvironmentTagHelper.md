---
title: Environment Tag Helper | Microsoft Docs
author: pkellner
description: ASP.Net Core Environment Tag Helper defined including all properties
keywords: ASP.NET Core,tag helper
ms.author: riande
manager: wpickett
ms.date: 02/14/2017
ms.topic: article
ms.assetid: c045d485-d1dc-4cea-a675-46be83b7a035
ms.technology: aspnet
ms.prod: aspnet-core
uid: mvc/views/tag-helpers/builtin-th/EnvironmentTagHelper
---
# Environment Tag Helper

By [Peter Kellner](http://peterkellner.net) 

The Environment Tag Helper conditionally renders its enclosed content based on the current hosting environment. Its single attribute `names` is a comma separated list of environment names, that if any match to the current environment, will trigger the enclosed content to be rendered.

## Environment Tag Helper Attributes

### names

Accepts a single hosting environment name or a comma-separated list of hosting environment names that trigger the rendering of the enclosed content.

These value(s) are compared to the current value returned from the ASP.NET Core static property `HostingEnvironment.EnvironmentName`.  This value is one of the following: **Staging**; **Development** or **Production**. The comparison ignores case.

An example of a valid `environment` tag helper is:

```html
<environment names="Staging,Production">
  <strong>HostingEnvironment.EnvironmentName is Staging or Production</strong>
</environment>
```

## Additional resources

* <xref:fundamentals/environments>
* <xref:fundamentals/dependency-injection#service-lifetimes-and-registration-options>


