---
title: Development-time IIS support in Visual Studio for ASP.NET Core
author: shirhatti
description: Discover support for debugging ASP.NET Core apps when running behind IIS on Windows Server.
ms.author: riande
ms.custom: mvc
ms.date: 11/30/2018
uid: host-and-deploy/iis/development-time-iis-support
---
# Development-time IIS support in Visual Studio for ASP.NET Core

By [Sourabh Shirhatti](https://twitter.com/sshirhatti) and [Luke Latham](https://github.com/guardrex)

This article describes [Visual Studio](https://www.visualstudio.com/vs/) support for debugging ASP.NET Core apps running behind IIS on Windows Server. This topic walks through enabling this feature and setting up a project.

## Prerequisites

* [Visual Studio for Windows](https://www.microsoft.com/net/download/windows)
* **ASP.NET and web development** workload
* **.NET Core cross-platform development** workload
* X.509 security certificate

## Enable IIS

1. Navigate to **Control Panel** > **Programs** > **Programs and Features** > **Turn Windows features on or off** (left side of the screen).
1. Select the **Internet Information Services** check box.

![Windows Features showing Internet Information Services check box checked as a black square (not a checkmark) indicating that some of the IIS features are enabled](development-time-iis-support/_static/enable_iis.png)

The IIS installation may require a system restart.

## Configure IIS

IIS must have a website configured with the following:

* A host name that matches the app's launch profile URL host name.
* Binding for port 443 with an assigned certificate.

For example, the **Host name** for an added website is set to "localhost" (the launch profile will also use "localhost" later in this topic). The port is set to "443" (HTTPS). The **IIS Express Development Certificate** is assigned to the website, but any valid certificate works:

![Add Website window in IIS showing the binding set for localhost on port 443 with a certificate assigned.](development-time-iis-support/_static/add-website-window.png)

If the IIS installation already has a **Default Web Site** with a host name that matches the app's launch profile URL host name:

* Add a port binding for port 443 (HTTPS).
* Assign a valid certificate to the website.

## Enable development-time IIS support in Visual Studio

1. Launch the Visual Studio installer.
1. Select the **Development time IIS support** component. The component is listed as optional in the **Summary** panel for the **ASP.NET and web development** workload. The component installs the [ASP.NET Core Module](xref:host-and-deploy/aspnet-core-module), which is a native IIS module required to run ASP.NET Core apps with IIS.

![Modifying Visual Studio features: The Workloads tab is selected. In the Web and Cloud section, the ASP.NET and web development panel is selected. On the right in the Optional area of the Summary panel, there's a check box for Development time IIS support.](development-time-iis-support/_static/development_time_support.png)

## Configure the project

### HTTPS redirection

For a new project, select the check box to **Configure for HTTPS** in the **New ASP.NET Core Web Application** window:

![New ASP.NET Core Web Application window with the Configure for HTTPS check box selected.](development-time-iis-support/_static/new-app.png)

In an existing project, use HTTPS Redirection Middleware in `Startup.Configure` by calling the [UseHttpsRedirection](/dotnet/api/microsoft.aspnetcore.builder.httpspolicybuilderextensions.usehttpsredirection) extension method:

```csharp
public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
    else
    {
        app.UseExceptionHandler("/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseCookiePolicy();

    app.UseMvc();
}
```

### IIS launch profile

Create a new launch profile to add development-time IIS support:

1. For **Profile**, select the **New** button. Name the profile "IIS" in the popup window. Select **OK** to create the profile.
1. For the **Launch** setting, select **IIS** from the list.
1. Select the check box for **Launch browser** and provide the endpoint URL. Use the HTTPS protocol. This example uses `https://localhost/WebApplication1`.
1. In the **Environment variables** section, select the **Add** button. Provide an environment variable with a key of `ASPNETCORE_ENVIRONMENT` and a value of `Development`.
1. In the **Web Server Settings** area, set the **App URL**. This example uses `https://localhost/WebApplication1`.
1. Save the profile.

![Project properties window with the Debug tab selected. The Profile and Launch settings are set to IIS. The Launch browser feature is enabled with an address of https://localhost/WebApplication1. The same address is also provided in the App URL field of the Web Server Settings area.](development-time-iis-support/_static/project_properties.png)

Alternatively, manually add a launch profile to the [launchSettings.json](http://json.schemastore.org/launchsettings) file in the app:

```json
{
  "iisSettings": {
    "windowsAuthentication": false,
    "anonymousAuthentication": true,
    "iis": {
      "applicationUrl": "https://localhost/WebApplication1",
      "sslPort": 0
    }
  },
  "profiles": {
    "IIS": {
      "commandName": "IIS",
      "launchBrowser": true,
      "launchUrl": "https://localhost/WebApplication1",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}
```

## Run the project

In Visual Studio:

* Confirm that the build configuration drop-down list is set to **Debug**.
* Set the Run button to the **IIS** profile and select the button to start the app.

![The Run button in the VS toolbar is set to the IIS profile with the build configuration drop-down list set to Release.](development-time-iis-support/_static/toolbar.png)

Visual Studio may prompt a restart if not running as an administrator. If prompted, restart Visual Studio.

If an untrusted development certificate is used, the browser may require you to create an exception for the untrusted certificate.

> [!NOTE]
> Debugging a Release build configuration with [Just My Code](/visualstudio/debugger/just-my-code) and compiler optimizations results in a degraded experience. For example, break points aren't hit.

## Additional resources

* [Host ASP.NET Core on Windows with IIS](xref:host-and-deploy/iis/index)
* [Introduction to ASP.NET Core Module](xref:host-and-deploy/aspnet-core-module)
* [ASP.NET Core Module configuration reference](xref:host-and-deploy/aspnet-core-module)
* [Enforce HTTPS](xref:security/enforcing-ssl)
