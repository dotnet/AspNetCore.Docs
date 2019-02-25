---
title: Configure Windows Authentication in ASP.NET Core
author: scottaddie
description: Learn how to configure Windows Authentication in ASP.NET Core, using IIS Express, IIS, and HTTP.sys.
monikerRange: '>= aspnetcore-2.1'
ms.author: riande
ms.custom: "mvc, seodec18"
ms.date: 02/25/2019
uid: security/authentication/windowsauth
---
# Configure Windows Authentication in ASP.NET Core

By [Scott Addie](https://twitter.com/Scott_Addie) and [Luke Latham](https://github.com/guardrex)

[Windows Authentication](/iis/configuration/system.webServer/security/authentication/windowsAuthentication/) can be configured for ASP.NET Core apps hosted with [IIS](xref:host-and-deploy/iis/index) or [HTTP.sys](xref:fundamentals/servers/httpsys).

Windows Authentication relies on the operating system to authenticate users of ASP.NET Core apps. You can use Windows Authentication when your server runs on a corporate network using Active Directory domain identities or Windows accounts to identify users. Windows Authentication is best suited to intranet environments where users, client apps, and web servers belong to the same Windows domain.

## Enable Windows Authentication in an ASP.NET Core app

The **Web Application** template available via Visual Studio or the .NET Core CLI can be configured to support Windows Authentication.

# [Visual Studio](#tab/visual-studio)

### Use the Windows Authentication app template for a new project

In Visual Studio:

1. Create a new **ASP.NET Core Web Application**.
1. Select **Web Application** from the list of templates.
1. Select the **Change Authentication** button and select **Windows Authentication**.

Run the app. The username appears in the rendered app's user interface.

### Manual configuration for an existing project

The project's properties allow you to enable Windows Authentication and disable Anonymous Authentication:

1. Right-click the project in Visual Studio's **Solution Explorer** and select **Properties**.
1. Select the **Debug** tab.
1. Clear the check box for **Enable Anonymous Authentication**.
1. Select the check box for **Enable Windows Authentication**.

Alternatively, the properties can be configured in the `iisSettings` node of the *launchSettings.json* file:

[!code-json[](windowsauth/sample_snapshot/launchSettings.json?highlight=2-3)]

# [.NET Core CLI](#tab/netcore-cli)

Use the **Windows Authentication** app template.

Execute the [dotnet new](/dotnet/core/tools/dotnet-new) command with the `webapp` argument (ASP.NET Core Web App) and `--auth Windows` switch:

```console
dotnet new webapp --auth Windows
```

---

When modifying an existing project, confirm that the project file includes a package reference for the [Microsoft.AspNetCore.App metapackage](xref:fundamentals/metapackage-app) **or** the [Microsoft.AspNetCore.Authentication](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication/) NuGet package.

## Enable Windows Authentication with IIS

IIS uses the [ASP.NET Core Module](xref:host-and-deploy/aspnet-core-module) to host ASP.NET Core apps. Windows Authentication is configured for IIS via the *web.config* file. The following sections show how to:

* Provide a local *web.config* file that activates Windows Authentication on the server when the app is deployed.
* Use the IIS Manager to configure the *web.config* file of an ASP.NET Core app that has already been deployed to the server.

### IIS configuration

If you haven't already done so, enable IIS to host ASP.NET Core apps. For more information, see <xref:host-and-deploy/iis/index>.

Enable the IIS Role Service for Windows Authentication. For more information, see [Enable Windows Authentication in IIS Role Services (see Step 2)](xref:host-and-deploy/iis/index#iis-configuration).

IIS Integration Middleware is configured to automatically authenticate requests by default. For more information, see [Host ASP.NET Core on Windows with IIS: IIS options (AutomaticAuthentication)](xref:host-and-deploy/iis/index#iis-options).

The ASP.NET Core Module is configured to forward the Windows Authentication token to the app by default. For more information, see [ASP.NET Core Module configuration reference: Attributes of the aspNetCore element](xref:host-and-deploy/aspnet-core-module#attributes-of-the-aspnetcore-element).

### Create a new IIS site

Specify a name and folder and allow it to create a new application pool.

### Enable Windows Authentication for the app in IIS

Use **either** of the following approaches:

* [Development-side configuration before publishing the app](#development-side-configuration-with-a-local-webconfig-file) (*Recommended*)
* [Server-side configuration after publishing the app](#server-side-configuration-with-the-iis-manager)

#### Development-side configuration with a local web.config file

Perform the following steps **before** you [publish and deploy your project](#publish-and-deploy-your-project-to-the-iis-site-folder).

Add the following *web.config* file to the project root:

[!code-xml[](windowsauth/sample_snapshot/web_2.config)]

When the project is published by the SDK (without the `<IsTransformWebConfigDisabled>` property set to `true` in the project file), the published *web.config* file includes the `<location><system.webServer><security><authentication>` section. For more information on the `<IsTransformWebConfigDisabled>` property, see <xref:host-and-deploy/iis/index#webconfig-file>.

#### Server-side configuration with the IIS Manager

Perform the following steps **after** you [publish and deploy your project](#publish-and-deploy-your-project-to-the-iis-site-folder).

1. In IIS Manager, select the IIS site under the **Sites** node of the **Connections** sidebar.
1. Double-click **Authentication** in the **IIS** area.
1. Select **Anonymous Authentication**. Select **Disable** in the **Actions** sidebar.
1. Select **Windows Authentication**. Select **Enable** in the **Actions** sidebar.

When these actions are taken, IIS Manager modifies the app's *web.config* file. A `<system.webServer><security><authentication>` node is added with updated settings for `anonymousAuthentication` and `windowsAuthentication`:

[!code-xml[](windowsauth/sample_snapshot/web_1.config?highlight=4-5)]

The `<system.webServer>` section added to the *web.config* file by IIS Manager is outside of the app's `<location>` section added by the .NET Core SDK when the app is published. Because the section is added outside of the `<location>` node, the settings are inherited by any [sub-apps](xref:host-and-deploy/iis/index#sub-applications) to the current app. To prevent inheritance, move the added `<security>` section inside of the `<location><system.webServer>` section that the SDK provided.

When IIS Manager is used to add the IIS configuration, it only affects the app's *web.config* file on the server. A subsequent deployment of the app may overwrite the settings on the server if the server's copy of *web.config* is replaced by the project's *web.config* file. Use **either** of the following approaches to manage the settings:

* Use IIS Manager to reset the settings in the *web.config* file after the file is overwritten on deployment.
* Add a *web.config file* to the app locally with the settings. For more information, see the [Development-side configuration](#development-side-configuration-with-a-local-webconfig-file) section.

### Publish and deploy your project to the IIS site folder

Using Visual Studio or the .NET Core CLI, publish and deploy the app to the destination folder.

For more information on hosting with IIS, publishing, and deployment, see the following topics:

* [dotnet publish](/dotnet/core/tools/dotnet-publish)
* <xref:host-and-deploy/iis/index>
* <xref:host-and-deploy/aspnet-core-module>
* <xref:host-and-deploy/visual-studio-publish-profiles>

Launch the app to verify Windows Authentication is working.

## Enable Windows Authentication with HTTP.sys

Although Kestrel doesn't support Windows Authentication, you can use [HTTP.sys](xref:fundamentals/servers/httpsys) to support self-hosted scenarios on Windows. The following example configures the app's web host to use HTTP.sys with Windows Authentication:

[!code-csharp[](windowsauth/sample_snapshot/Program.cs?highlight=9-14)]

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

ASP.NET Core doesn't implement impersonation. Apps run with the app's identity for all requests, using app pool or process identity. If you need to explicitly perform an action on behalf of a user, use [WindowsIdentity.RunImpersonated](xref:System.Security.Principal.WindowsIdentity.RunImpersonated*) in a [terminal inline middleware](xref:fundamentals/middleware/index#create-a-middleware-pipeline-with-iapplicationbuilder) in `Startup.Configure`. Run a single action in this context and then close the context.

[!code-csharp[](windowsauth/sample_snapshot/Startup.cs?highlight=10-19)]

`RunImpersonated` doesn't support asynchronous operations and shouldn't be used for complex scenarios. For example, wrapping entire requests or middleware chains isn't supported or recommended.

### Claims transformations

When hosting in-process, <xref:Microsoft.AspNetCore.Authentication.AuthenticationService.AuthenticateAsync*> isn't called internally to initialize a user. Therefore, an <xref:Microsoft.AspNetCore.Authentication.IClaimsTransformation> implementation used to transform claims after every authentication isn't activated by default. When transforming claims with an <xref:Microsoft.AspNetCore.Authentication.IClaimsTransformation> implementation, call <xref:Microsoft.Extensions.DependencyInjection.AuthenticationServiceCollectionExtensions.AddAuthentication*> to add authentication services. For a code example that activates claims transformations when hosting in-process, see <xref:host-and-deploy/aspnet-core-module#in-process-hosting-model>.
