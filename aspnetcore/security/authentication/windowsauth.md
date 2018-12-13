---
title: Configure Windows Authentication in ASP.NET Core
author: scottaddie
description: Learn how to configure Windows Authentication in ASP.NET Core, using IIS Express, IIS, and HTTP.sys.
ms.author: riande
ms.custom: "mvc, seodec18"
ms.date: 11/01/2018
uid: security/authentication/windowsauth
---
# Configure Windows Authentication in ASP.NET Core

By [Steve Smith](https://ardalis.com) and [Scott Addie](https://twitter.com/Scott_Addie)

Windows Authentication can be configured for ASP.NET Core apps hosted with IIS or [HTTP.sys](xref:fundamentals/servers/httpsys).

## Windows Authentication

Windows Authentication relies on the operating system to authenticate users of ASP.NET Core apps. You can use Windows Authentication when your server runs on a corporate network using Active Directory domain identities or other Windows accounts to identify users. Windows Authentication is best suited to intranet environments in which users, client applications, and web servers belong to the same Windows domain.

[Learn more about Windows Authentication and installing it for IIS](/iis/configuration/system.webServer/security/authentication/windowsAuthentication/).

## Enable Windows Authentication in an ASP.NET Core app

The Visual Studio Web Application template can be configured to support Windows Authentication.

### Use the Windows Authentication app template

In Visual Studio:

1. Create a new ASP.NET Core Web Application.
1. Select Web Application from the list of templates.
1. Select the **Change Authentication** button and select **Windows Authentication**.

Run the app. The username appears in the top right of the app.

![Windows Authentication Browser Screenshot](windowsauth/_static/browser-screenshot.png)

For development work using IIS Express, the template provides all the configuration necessary to use Windows Authentication. The following section shows how to manually configure an ASP.NET Core app for Windows Authentication.

### Visual Studio settings for Windows and anonymous authentication

The Visual Studio project **Properties** page's **Debug** tab provides check boxes for Windows Authentication and anonymous authentication.

![Windows Authentication Browser Screenshot with authentication options highlighted](windowsauth/_static/vs-auth-property-menu.png)

Alternatively, these two properties can be configured in the *launchSettings.json* file:

[!code-json[](windowsauth/sample/launchSettings.json?highlight=3-4)]

## Enable Windows Authentication with IIS

IIS uses the [ASP.NET Core Module](xref:host-and-deploy/aspnet-core-module) to host ASP.NET Core apps. Windows Authentication is configured in IIS, not the app. The following sections show how to use IIS Manager to configure an ASP.NET Core app to use Windows Authentication.

### IIS configuration

Enable the IIS Role Service for Windows Authentication. For more information, see [Enable Windows Authentication in IIS Role Services (see Step 2)](xref:host-and-deploy/iis/index#iis-configuration).

IIS Integration Middleware is configured to automatically authenticate requests by default. For more information, see [Host ASP.NET Core on Windows with IIS: IIS options (AutomaticAuthentication)](xref:host-and-deploy/iis/index#iis-options).

The ASP.NET Core Module is configured to forward the Windows Authentication token to the app by default. For more information, see [ASP.NET Core Module configuration reference: Attributes of the aspNetCore element](xref:host-and-deploy/aspnet-core-module#attributes-of-the-aspnetcore-element).

### Create a new IIS site

Specify a name and folder and allow it to create a new application pool.

### Customize authentication

Open the Authentication features for the site.

![IIS Authentication Menu](windowsauth/_static/iis-authentication-menu.png)

Disable Anonymous Authentication and enable Windows Authentication.

![IIS Authentication Settings](windowsauth/_static/iis-auth-settings.png)

### Publish your project to the IIS site folder

Using Visual Studio or the .NET Core CLI, publish the app to the destination folder.

![Visual Studio Publish Dialog](windowsauth/_static/vs-publish-app.png)

Learn more about [publishing to IIS](xref:host-and-deploy/iis/index).

Launch the app to verify Windows Authentication is working.

## Enable Windows Authentication with HTTP.sys

Although Kestrel doesn't support Windows Authentication, you can use [HTTP.sys](xref:fundamentals/servers/httpsys) to support self-hosted scenarios on Windows. The following example configures the app's web host to use HTTP.sys with Windows Authentication:

[!code-csharp[](windowsauth/sample/Program2x.cs?highlight=9-14)]

> [!NOTE]
> HTTP.sys delegates to kernel mode authentication with the Kerberos authentication protocol. User mode authentication isn't supported with Kerberos and HTTP.sys. The machine account must be used to decrypt the Kerberos token/ticket that's obtained from Active Directory and forwarded by the client to the server to authenticate the user. Register the Service Principal Name (SPN) for the host, not the user of the app.

> [!NOTE]
> HTTP.sys isn't supported on Nano Server version 1709 or later. To use Windows Authentication and HTTP.sys with Nano Server, use a [Server Core (microsoft/windowsservercore) container](https://hub.docker.com/r/microsoft/windowsservercore/). For more information on Server Core, see [What is the Server Core installation option in Windows Server?](/windows-server/administration/server-core/what-is-server-core).

## Work with Windows Authentication

The configuration state of anonymous access determines the way in which the `[Authorize]` and `[AllowAnonymous]` attributes are used in the app. The following two sections explain how to handle the disallowed and allowed configuration states of anonymous access.

### Disallow anonymous access

When Windows Authentication is enabled and anonymous access is disabled, the `[Authorize]` and `[AllowAnonymous]` attributes have no effect. If the IIS site (or HTTP.sys) is configured to disallow anonymous access, the request never reaches your app. For this reason, the `[AllowAnonymous]` attribute isn't applicable.

### Allow anonymous access

When both Windows Authentication and anonymous access are enabled, use the `[Authorize]` and `[AllowAnonymous]` attributes. The `[Authorize]` attribute allows you to secure pieces of the app which truly do require Windows Authentication. The `[AllowAnonymous]` attribute overrides `[Authorize]` attribute usage within apps which allow anonymous access. See [Simple Authorization](xref:security/authorization/simple) for attribute usage details.

In ASP.NET Core 2.x, the `[Authorize]` attribute requires additional configuration in *Startup.cs* to challenge anonymous requests for Windows Authentication. The recommended configuration varies slightly based on the web server being used.

> [!NOTE]
> By default, users who lack authorization to access a page are presented with an empty HTTP 403 response. The [StatusCodePages middleware](xref:fundamentals/error-handling#configure-status-code-pages) can be configured to provide users with a better "Access Denied" experience.

#### IIS

If using IIS, add the following to the `ConfigureServices` method:

```csharp
// IISDefaults requires the following import:
// using Microsoft.AspNetCore.Server.IISIntegration;
services.AddAuthentication(IISDefaults.AuthenticationScheme);
```

#### HTTP.sys

If using HTTP.sys, add the following to the `ConfigureServices` method:

```csharp
// HttpSysDefaults requires the following import:
// using Microsoft.AspNetCore.Server.HttpSys;
services.AddAuthentication(HttpSysDefaults.AuthenticationScheme);
```

### Impersonation

ASP.NET Core doesn't implement impersonation. Apps run with the application identity for all requests, using app pool or process identity. If you need to explicitly perform an action on behalf of a user, use `WindowsIdentity.RunImpersonated`. Run a single action in this context and then close the context.

[!code-csharp[](windowsauth/sample/Startup.cs?name=snippet_Impersonate&highlight=10-18)]

Note that `RunImpersonated` doesn't support asynchronous operations and shouldn't be used for complex scenarios. For example, wrapping entire requests or middleware chains isn't supported or recommended.
