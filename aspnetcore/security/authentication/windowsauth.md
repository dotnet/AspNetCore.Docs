---
title: Configure Windows Authentication in ASP.NET Core
author: ardalis
description: 
keywords: ASP.NET Core,
ms.author: riande
manager: wpickett
ms.date: 7/3/2017
ms.topic: article
ms.assetid: cf119f21-1a2b-49a2-b052-548ccb66ee83
ms.technology: aspnet
ms.prod: asp.net-core
uid: security/authentication/windowsauth
---
# Configure Windows Authentication in ASP.NET Core

By [Steve Smith](https://ardalis.com)

Windows authentication can be configured for ASP.NET Core apps hosted with IIS or WebListener.

## What is Windows Authentication

Windows authentication relies on the underlying operating system to authenticate users of ASP.NET Core apps. For obvious reasons, it only works on apps running on Windows hosts.

## Enabling Windows Authentication with IIS

You can use built-in tooling in Visual Studio. Also see the [Publishing to IIS](https://docs.microsoft.com/en-us/aspnet/core/publishing/iis) article topic. Show the VS experience of using the radio button in the templates to configure Windows Auth.

## Enabling Windows Authentication with WebListener

Although Kestrel doesn't support Windows Authentication, you can use WebListener. Configure it using code like this:

```
var host = new WebHostBuilder()
    ...
    .UseWebListener(options =>
    {
        options.ListenerSettings.Authentication.Schemes = AuthenticationSchemes.Negotiate
                                                     | AuthenticationSchemes.Ntlm;
        options.ListenerSettings.Authentication.AllowAnonymous = false; 
    })
    .Build();
```

## Working with Windows Authentication

If mixing Windows auth and anonymous, you can still use [Authorize] attribute. If you don't have anonymous enabled, you don't need authorize attribute. Whole app is authorized. Server rejects anonymous requests. This applies to weblistener and IIS.

IIS windows auth is configured completely in IIS - no application settings for it. web.config aspnetcore module setting that says flowwindowsauth which is on by default. Link to ANCM doc. "The ANCM will automatically flow auth to the application - see more".
