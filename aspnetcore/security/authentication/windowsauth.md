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

Windows authentication relies on the underlying operating system to authenticate users of ASP.NET Core apps. For obvious reasons, it only works on apps running on Windows hosts. You can use Windows authentication when your server runs on a corporate network using Active Directory domain identities or other Windows accounts to identify users. Windows authentication is a secure form of authentication best suited to intranet environments where client applications and web servers belong to the same Windows domain.

[Learn more about Windows Authentication](https://www.iis.net/configreference/system.webserver/security/authentication/windowsauthentication).

## Enabling Windows Authentication in your app

You can use Window authentication in your ASP.NET Core app hosted in IIS Express by installing the appropriate template or configuring the app's properties.

### Installing the Windows Authentication app template

In Visual Studio, create a new ASP.NET Core Web Application. Next, select Web Application from the list of templates, and click the Change Authentication button. Choose Windows Authentication from the dialog that appears.

![New Project Template - Choose Windows Authentication](windowsauth/_static/vs-windows-auth-template.png)

Once you've create the project, run the application (on Windows) and you should see your username appear in the top right of the page that appears when the app is run.

![Windows Authentication Browser Screenshot](windowsauth/_static/browser-screenshot.png)

During development, this is all that is required to work with Windows Authentication. IIS Express does not require any additional configuration to support Windows Authentication.

### Setting app properties to support Windows authentication

## Enabling Windows Authentication with IIS

IIS uses the [ASP.NET Core Module](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/servers/aspnet-core-module) (ANCM) to host ASP.NET Core apps. The ANCM will flow Windows authentication to IIS by default. Configuration of Windows authentication is done within IIS, not the application project. Take the following steps to configure your ASP.NET Core app to use Windows authentication on a local install of IIS:

### Create a new IIS site

Specify a name and folder and allow it to create a new application pool.

### Customize Authentication

Open the Authentication menu for the site.

![IIS Authentication Menu](windowsauth/_static/iis-authentication-menu.png)

Disable Anonymous Authentication and enable Windows Authentication.

![IIS Authentication Settings](windowsauth/_static/iis-auth-settings.png)

### Publish your project to the IIS site folder

Using Visual Studio or the dotnet CLI, *publish* your app to the destination folder.

![Visual Studio Publish Dialog](windowsauth/_static/vs-publish-app.png)

Learn more about [publishing to IIS](https://docs.microsoft.com/en-us/aspnet/core/publishing/iis).

After completing these steps, you should be able to launch your app from its IIS-bound path and Windows authentication should work correctly.

## Enabling Windows authentication with WebListener

Although Kestrel doesn't support Windows authentication, you can use WebListener. Configure it using code like this:

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

## Working with Windows authentication

If mixing Windows authentication and anonymous access, you can still use the ``[Authorize]`` attribute. Apps that do not have anonymous enabled do not need to use the ``[Authorize]`` attribute at all. In this case, the whole app is treated as requiring authentication, and the server rejects anonymous requests.
