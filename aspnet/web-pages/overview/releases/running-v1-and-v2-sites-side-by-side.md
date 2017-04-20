---
uid: web-pages/overview/releases/running-v1-and-v2-sites-side-by-side
title: "Running Different Versions of ASP.NET Web Pages (Razor) Side by Side | Microsoft Docs"
author: tfitzmac
description: "This article explains how to run ASP.NET Web Pages (Razor) websites on the same computer or server when the websites are configured to use different versions..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 02/10/2014
ms.topic: article
ms.assetid: a861409b-4ae6-4868-9e09-87edfac3535f
ms.technology: dotnet-webpages
ms.prod: .net-framework
msc.legacyurl: /web-pages/overview/releases/running-v1-and-v2-sites-side-by-side
msc.type: authoredcontent
---
Running Different Versions of ASP.NET Web Pages (Razor) Side by Side
====================
by [Tom FitzMacken](https://github.com/tfitzmac)

> This article explains how to run ASP.NET Web Pages (Razor) websites on the same computer or server when the websites are configured to use different versions of ASP.NET Web Pages.
> 
> What you'll learn:
> 
> - What the default behavior is in ASP.NET when you have sites built with ASP.NET Web Pages.
> - How to configure a new site to run with an older version of ASP.NET Web Pages.
>   
> 
> This is the ASP.NET feature introduced in the article:
> 
> - The `webPages:Version` configuration setting.
>   
> 
> ## Software versions
> 
> 
> - ASP.NET Web Pages (Razor) 3
>   
> 
> This tutorial also works with ASP.NET Web Pages 2 and ASP.NET Web Pages 1.0.


ASP.NET Web Pages supports the ability to run websites side by side. This lets you continue to run your older ASP.NET Web Pages applications, build new ASP.NET Web Pages applications, and run all of them on the same computer.

Here are some things to remember when you install the Web Pages with WebMatrix:

- By default, existing Web Pages applications will run as the latest version on your computer. (The assemblies are installed in the global assembly cache (GAC) and are used automatically.)
- If you want to run a site using a different version of ASP.NET Web Pages, you can configure the site to do that. If your site doesn't already have a *web.config* file in the root of the site, create a new one and copy the following XML into it, overwriting the existing content. If the site already contains a *web.config* file, add an `<appSettings>` element like the following one to the `<configuration>` section.

    [!code-xml[Main](running-v1-and-v2-sites-side-by-side/samples/sample1.xml)]
`- If you do not specify a version in the *web.config* file, a site is deployed as the latest version. (The assemblies are copied to the *bin* folder in the deployed site.)
- New applications that you create using the site templates in Web Matrix include the Web Pages version assemblies in the site's *bin* folder.

In general, you can always control which version of Web Pages to use with your site by using NuGet to install the appropriate assemblies into the site's *bin* folder. To find packages, visit [NuGet.org](http://NuGet.org).

## Additional Resources

[The Top Features in ASP.NET Web Pages 2](top-features-in-web-pages-2.md)
