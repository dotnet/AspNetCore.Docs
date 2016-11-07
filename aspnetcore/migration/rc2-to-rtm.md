---
title: Migrating from ASP.NET Core RC2 to ASP.NET Core 1.0
author: rick-anderson
ms.author: riande
manager: wpickett
ms.date: 10/14/2016
ms.topic: article
ms.assetid: b672bd6e-7ecf-4504-9ecf-58ae9ec0153f
ms.prod: aspnet-core
uid: migration/rc2-to-rtm
---
# Migrating from ASP.NET Core RC2 to ASP.NET Core 1.0

By [Cesar Blum Silveira](https://github.com/cesarbs)

## Overview

This migration guide covers migrating an ASP.NET Core RC2 application to ASP.NET Core 1.0.

There weren't many significant changes to ASP.NET Core between the RC2 and 1.0 releases. For a complete list of changes, see the [ASP.NET Core 1.0 announcements](https://github.com/aspnet/announcements/issues?q=is%3Aopen+is%3Aissue+milestone%3A1.0.0).

Install the new tools from [https://dot.net/core](https://dot.net/core) and follow the instructions.

Update the global.json to

````javascript
{
     "projects": [ "src", "test" ],
     "sdk": {
         "version": "1.0.0-preview2-003121"
     }
   }
   ````

## Tools

For the tools we ship, you no longer need to use `imports` in *project.json*. For example:

````json
{
     "tools": {
       "Microsoft.AspNetCore.Server.IISIntegration.Tools": {
         "version": "1.0.0-preview1-final",
         "imports": "portable-net45+win8+dnxcore50"
       }
     }
   }
   ````

Becomes:

````json
{
     "tools": {
       "Microsoft.AspNetCore.Server.IISIntegration.Tools": "1.0.0-preview2-final"
     }
   }
   ````

## Hosting

The `UseServer` is no longer available for [`IWebHostBuilder`](http://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/AspNetCore/Hosting/IWebHostBuilder/index.html#Microsoft.AspNetCore.Hosting.IWebHostBuilder). You must now use [`UseKestrel`](http://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/AspNetCore/Hosting/WebHostBuilderKestrelExtensions/index.html#Microsoft.AspNetCore.Hosting.WebHostBuilderKestrelExtensions.UseKestrel) or [`UseWebListener`](http://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/AspNetCore/Hosting/WebHostBuilderWebListenerExtensions/index.html#Microsoft.AspNetCore.Hosting.WebHostBuilderWebListenerExtensions.UseWebListener).

## ASP.NET MVC Core

The `HtmlEncodedString` class has been replaced by [`HtmlString`](http://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/AspNetCore/Html/HtmlString/index.html#Microsoft.AspNetCore.Html.HtmlString) (contained in the  `Microsoft.AspNetCore.Html.Abstractions` package).

## Security

The [`AuthorizationHandler<TRequirement>`](http://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/AspNetCore/Authorization/AuthorizationHandler-TRequirement/index.html#Microsoft.AspNetCore.Authorization.AuthorizationHandler<TRequirement>) class now only contains an asynchronous interface.
