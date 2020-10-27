---
title: Configure Windows Authentication in ASP.NET Core
author: scottaddie
description: Learn how to configure Windows Authentication in ASP.NET Core for IIS and HTTP.sys.
monikerRange: '>= aspnetcore-2.1'
ms.author: riande
ms.custom: "mvc, seodec18"
ms.date: 02/26/2020
no-loc: [appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: security/authentication/windowsauth
---
# Configure Windows Authentication in ASP.NET Core

By [Scott Addie](https://twitter.com/Scott_Addie)

::: moniker range=">= aspnetcore-3.0"

Windows Authentication (also known as Negotiate, Kerberos, or NTLM authentication) can be configured for ASP.NET Core apps hosted with [IIS](xref:host-and-deploy/iis/index), [Kestrel](xref:fundamentals/servers/kestrel), or [HTTP.sys](xref:fundamentals/servers/httpsys).

::: moniker-end

::: moniker range="< aspnetcore-3.0"

Windows Authentication (also known as Negotiate, Kerberos, or NTLM authentication) can be configured for ASP.NET Core apps hosted with [IIS](xref:host-and-deploy/iis/index) or [HTTP.sys](xref:fundamentals/servers/httpsys).

::: moniker-end

Windows Authentication relies on the operating system to authenticate users of ASP.NET Core apps. You can use Windows Authentication when your server runs on a corporate network using Active Directory domain identities or Windows accounts to identify users. Windows Authentication is best suited to intranet environments where users, client apps, and web servers belong to the same Windows domain.

> [!NOTE]
> Windows Authentication isn't supported with HTTP/2. Authentication challenges can be sent on HTTP/2 responses, but the client must downgrade to HTTP/1.1 before authenticating.

## Proxy and load balancer scenarios

Windows Authentication is a stateful scenario primarily used in an intranet, where a proxy or load balancer doesn't usually handle traffic between clients and servers. If a proxy or load balancer is used, Windows Authentication only works if the proxy or load balancer:

* Handles the authentication.
* Passes the user authentication information to the app (for example, in a request header), which acts on the authentication information.

An alternative to Windows Authentication in environments where proxies and load balancers are used is Active Directory Federated Services (ADFS) with OpenID Connect (OIDC).

## IIS/IIS Express

Add authentication services by invoking <xref:Microsoft.Extensions.DependencyInjection.AuthenticationServiceCollectionExtensions.AddAuthentication*> (<xref:Microsoft.AspNetCore.Server.IISIntegration?displayProperty=fullName> namespace) in `Startup.ConfigureServices`:

```csharp
services.AddAuthentication(IISDefaults.AuthenticationScheme);
```

### Launch settings (debugger)

Configuration for launch settings only affects the *Properties/launchSettings.json* file for IIS Express and doesn't configure IIS for Windows Authentication. Server configuration is explained in the [IIS](#iis) section.

The **Web Application** template available via Visual Studio or the .NET Core CLI can be configured to support Windows Authentication, which updates the *Properties/launchSettings.json* file automatically.

# [Visual Studio](#tab/visual-studio)

**New project**

1. Create a new project.
1. Select **ASP.NET Core Web Application**. Select **Next**.
1. Provide a name in the **Project name** field. Confirm the **Location** entry is correct or provide a location for the project. Select **Create**.
1. Select **Change** under **Authentication**.
1. In the **Change Authentication** window, select **Windows Authentication**. Select **OK**.
1. Select **Web Application**.
1. Select **Create**.

Run the app. The username appears in the rendered app's user interface.

**Existing project**

The project's properties enable Windows Authentication and disable Anonymous Authentication:

1. Right-click the project in **Solution Explorer** and select **Properties**.
1. Select the **Debug** tab.
1. Clear the check box for **Enable Anonymous Authentication**.
1. Select the check box for **Enable Windows Authentication**.
1. Save and close the property page.

Alternatively, the properties can be configured in the `iisSettings` node of the *launchSettings.json* file:

[!code-json[](windowsauth/sample_snapshot/launchSettings.json?highlight=2-3)]

# [.NET Core CLI](#tab/netcore-cli)

**New project**

Execute the [dotnet new](/dotnet/core/tools/dotnet-new) command with the `webapp` argument (ASP.NET Core Web App) and `--auth Windows` switch:

```dotnetcli
dotnet new webapp --auth Windows
```

**Existing project**

Update the `iisSettings` node of the *launchSettings.json* file:

[!code-json[](windowsauth/sample_snapshot/launchSettings.json?highlight=2-3)]

---

When modifying an existing project, confirm that the project file includes a package reference for the [Microsoft.AspNetCore.App metapackage](xref:fundamentals/metapackage-app) **or** the [Microsoft.AspNetCore.Authentication](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication/) NuGet package.

### IIS

IIS uses the [ASP.NET Core Module](xref:host-and-deploy/aspnet-core-module) to host ASP.NET Core apps. Windows Authentication is configured for IIS via the *web.config* file. The following sections show how to:

* Provide a local *web.config* file that activates Windows Authentication on the server when the app is deployed.
* Use the IIS Manager to configure the *web.config* file of an ASP.NET Core app that has already been deployed to the server.

If you haven't already done so, enable IIS to host ASP.NET Core apps. For more information, see <xref:host-and-deploy/iis/index>.

Enable the IIS Role Service for Windows Authentication. For more information, see [Enable Windows Authentication in IIS Role Services (see Step 2)](xref:host-and-deploy/iis/index#iis-configuration).

[IIS Integration Middleware](xref:host-and-deploy/iis/index#enable-the-iisintegration-components) is configured to automatically authenticate requests by default. For more information, see [Host ASP.NET Core on Windows with IIS: IIS options (AutomaticAuthentication)](xref:host-and-deploy/iis/index#iis-options).

The ASP.NET Core Module is configured to forward the Windows Authentication token to the app by default. For more information, see [ASP.NET Core Module configuration reference: Attributes of the aspNetCore element](xref:host-and-deploy/aspnet-core-module#attributes-of-the-aspnetcore-element).

Use **either** of the following approaches:

* **Before publishing and deploying the project,** add the following *web.config* file to the project root:

  [!code-xml[](windowsauth/sample_snapshot/web_2.config)]

  When the project is published by the .NET Core SDK (without the `<IsTransformWebConfigDisabled>` property set to `true` in the project file), the published *web.config* file includes the `<location><system.webServer><security><authentication>` section. For more information on the `<IsTransformWebConfigDisabled>` property, see <xref:host-and-deploy/iis/index#webconfig-file>.

* **After publishing and deploying the project,** perform server-side configuration with the IIS Manager:

  1. In IIS Manager, select the IIS site under the **Sites** node of the **Connections** sidebar.
  1. Double-click **Authentication** in the **IIS** area.
  1. Select **Anonymous Authentication**. Select **Disable** in the **Actions** sidebar.
  1. Select **Windows Authentication**. Select **Enable** in the **Actions** sidebar.

  When these actions are taken, IIS Manager modifies the app's *web.config* file. A `<system.webServer><security><authentication>` node is added with updated settings for `anonymousAuthentication` and `windowsAuthentication`:

  [!code-xml[](windowsauth/sample_snapshot/web_1.config?highlight=4-5)]

  The `<system.webServer>` section added to the *web.config* file by IIS Manager is outside of the app's `<location>` section added by the .NET Core SDK when the app is published. Because the section is added outside of the `<location>` node, the settings are inherited by any [sub-apps](xref:host-and-deploy/iis/index#sub-applications) to the current app. To prevent inheritance, move the added `<security>` section inside of the `<location><system.webServer>` section that the .NET Core SDK provided.

  When IIS Manager is used to add the IIS configuration, it only affects the app's *web.config* file on the server. A subsequent deployment of the app may overwrite the settings on the server if the server's copy of *web.config* is replaced by the project's *web.config* file. Use **either** of the following approaches to manage the settings:

  * Use IIS Manager to reset the settings in the *web.config* file after the file is overwritten on deployment.
  * Add a *web.config file* to the app locally with the settings.

::: moniker range=">= aspnetcore-3.0"

## Kestrel

The [Microsoft.AspNetCore.Authentication.Negotiate](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.Negotiate) NuGet package can be used with [Kestrel](xref:fundamentals/servers/kestrel) to support Windows Authentication using Negotiate and Kerberos on Windows, Linux, and macOS.

> [!WARNING]
> Credentials can be persisted across requests on a connection. *Negotiate authentication must not be used with proxies unless the proxy maintains a 1:1 connection affinity (a persistent connection) with Kestrel.*

> [!NOTE]
> The Negotiate handler detects if the underlying server supports Windows Authentication natively and if it is enabled. If the server supports Windows Authentication but it is disabled, an error is thrown asking you to enable the server implementation. When Windows Authentication is enabled in the server, the Negotiate handler transparently forwards authentication requests to it.

Add authentication services by invoking <xref:Microsoft.Extensions.DependencyInjection.AuthenticationServiceCollectionExtensions.AddAuthentication*> and <xref:Microsoft.Extensions.DependencyInjection.NegotiateExtensions.AddNegotiate*> in `Startup.ConfigureServices`:

 ```csharp
// using Microsoft.AspNetCore.Authentication.Negotiate;
// using Microsoft.Extensions.DependencyInjection;

services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
    .AddNegotiate();
```

Add Authentication Middleware by calling <xref:Microsoft.AspNetCore.Builder.AuthAppBuilderExtensions.UseAuthentication*> in `Startup.Configure`:

 ```csharp
app.UseAuthentication();
```

For more information on middleware, see <xref:fundamentals/middleware/index>.

<a name="rbac"></a>
### Kerberos authentication and role-based access control (RBAC)

Kerberos authentication on Linux or macOS doesn't provide any role information for an authenticated user. To add role and group information to a Kerberos user, the authentication handler must be configured to retrieve the roles from an LDAP domain. The most basic configuration only specifies an LDAP domain to query against and will use the authenticated user's context to query the LDAP domain:

```csharp
services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
    .AddNegotiate(options =>
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            options.EnableLdap("contoso.com");
        }
    });
```

Some configurations may require specific credentials to query the LDAP domain. The credentials can be specified in the options:

```csharp
services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
    .AddNegotiate(options =>
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            options.EnableLdap("contoso.com");
            options.MachineAccountName = "machineName";
            options.MachineAccountPassword = "PassW0rd";            
        }
    });
```

By default, the negotiate authentication handler resolves nested domains. In a large or complicated LDAP environment, resolving nested domains may result in a slow lookup or a lot of memory being used for each user. Nested domain resolution can be disabled using the `IgnoreNestedGroups` option.

Anonymous requests are allowed. Use [ASP.NET Core Authorization](xref:security/authorization/introduction) to challenge anonymous requests for authentication.

### Windows environment configuration

The [Microsoft.AspNetCore.Authentication.Negotiate](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.Negotiate) component performs [User Mode](/windows-hardware/drivers/gettingstarted/user-mode-and-kernel-mode) authentication. Service Principal Names (SPNs) must be added to the user account running the service, not the machine account. Execute `setspn -S HTTP/myservername.mydomain.com myuser` in an administrative command shell.

### Linux and macOS environment configuration

Instructions for joining a Linux or macOS machine to a Windows domain are available in the [Connect Azure Data Studio to your SQL Server using Windows authentication - Kerberos](/sql/azure-data-studio/enable-kerberos?view=sql-server-2017#join-your-os-to-the-active-directory-domain-controller) article. The instructions create a machine account for the Linux machine on the domain. SPNs must be added to that machine account.

> [!NOTE]
> When following the guidance in the [Connect Azure Data Studio to your SQL Server using Windows authentication - Kerberos](/sql/azure-data-studio/enable-kerberos?view=sql-server-2017#join-your-os-to-the-active-directory-domain-controller) article, replace `python-software-properties` with `python3-software-properties` if needed.

Once the Linux or macOS machine is joined to the domain, additional steps are required to provide a [keytab file](/archive/blogs/pie/all-you-need-to-know-about-keytab-files) with the SPNs:

* On the domain controller, add new web service SPNs to the machine account:
  * `setspn -S HTTP/mywebservice.mydomain.com mymachine`
  * `setspn -S HTTP/mywebservice@MYDOMAIN.COM mymachine`
* Use [ktpass](/windows-server/administration/windows-commands/ktpass) to generate a keytab file:
  * `ktpass -princ HTTP/mywebservice.mydomain.com@MYDOMAIN.COM -pass myKeyTabFilePassword -mapuser MYDOMAIN\mymachine$ -pType KRB5_NT_PRINCIPAL -out c:\temp\mymachine.HTTP.keytab -crypto AES256-SHA1`
  * Some fields must be specified in uppercase as indicated.
* Copy the keytab file to the Linux or macOS machine.
* Select the keytab file via an environment variable: `export KRB5_KTNAME=/tmp/mymachine.HTTP.keytab`
* Invoke `klist` to show the SPNs currently available for use.

> [!NOTE]
> A keytab file contains domain access credentials and must be protected accordingly.

::: moniker-end

## HTTP.sys

[HTTP.sys](xref:fundamentals/servers/httpsys) supports [Kernel Mode](/windows-hardware/drivers/gettingstarted/user-mode-and-kernel-mode) Windows Authentication using Negotiate, NTLM, or Basic authentication.

Add authentication services by invoking <xref:Microsoft.Extensions.DependencyInjection.AuthenticationServiceCollectionExtensions.AddAuthentication*> (<xref:Microsoft.AspNetCore.Server.HttpSys?displayProperty=fullName> namespace) in `Startup.ConfigureServices`:

```csharp
services.AddAuthentication(HttpSysDefaults.AuthenticationScheme);
```

Configure the app's web host to use HTTP.sys with Windows Authentication (*Program.cs*). <xref:Microsoft.AspNetCore.Hosting.WebHostBuilderHttpSysExtensions.UseHttpSys*> is in the <xref:Microsoft.AspNetCore.Server.HttpSys?displayProperty=fullName> namespace.

::: moniker range=">= aspnetcore-3.0"

[!code-csharp[](windowsauth/sample_snapshot/Program_GenericHost.cs?highlight=13-19)]

::: moniker-end

::: moniker range="< aspnetcore-3.0"

[!code-csharp[](windowsauth/sample_snapshot/Program_WebHost.cs?highlight=9-15)]

::: moniker-end

> [!NOTE]
> HTTP.sys delegates to [Kernel Mode](/windows-hardware/drivers/gettingstarted/user-mode-and-kernel-mode) authentication with the Kerberos authentication protocol. [User Mode](/windows-hardware/drivers/gettingstarted/user-mode-and-kernel-mode) authentication isn't supported with Kerberos and HTTP.sys. The machine account must be used to decrypt the Kerberos token/ticket that's obtained from Active Directory and forwarded by the client to the server to authenticate the user. Register the Service Principal Name (SPN) for the host, not the user of the app.

> [!NOTE]
> HTTP.sys isn't supported on Nano Server version 1709 or later. To use Windows Authentication and HTTP.sys with Nano Server, use a [Server Core (microsoft/windowsservercore) container](https://hub.docker.com/r/microsoft/windowsservercore/). For more information on Server Core, see [What is the Server Core installation option in Windows Server?](/windows-server/administration/server-core/what-is-server-core).

## Authorize users

The configuration state of anonymous access determines the way in which the `[Authorize]` and `[AllowAnonymous]` attributes are used in the app. The following two sections explain how to handle the disallowed and allowed configuration states of anonymous access.

### Disallow anonymous access

When Windows Authentication is enabled and anonymous access is disabled, the `[Authorize]` and `[AllowAnonymous]` attributes have no effect. If an IIS site is configured to disallow anonymous access, the request never reaches the app. For this reason, the `[AllowAnonymous]` attribute isn't applicable.

### Allow anonymous access

When both Windows Authentication and anonymous access are enabled, use the `[Authorize]` and `[AllowAnonymous]` attributes. The `[Authorize]` attribute allows you to secure endpoints of the app which require authentication. The `[AllowAnonymous]` attribute overrides the `[Authorize]` attribute in apps that allow anonymous access. For attribute usage details, see <xref:security/authorization/simple>.

> [!NOTE]
> By default, users who lack authorization to access a page are presented with an empty HTTP 403 response. The [StatusCodePages Middleware](xref:fundamentals/error-handling#usestatuscodepages) can be configured to provide users with a better "Access Denied" experience.

## Impersonation

ASP.NET Core doesn't implement impersonation. Apps run with the app's identity for all requests, using app pool or process identity. If the app should perform an action on behalf of a user, use [WindowsIdentity.RunImpersonated](xref:System.Security.Principal.WindowsIdentity.RunImpersonated*) in a [terminal inline middleware](xref:fundamentals/middleware/index#create-a-middleware-pipeline-with-iapplicationbuilder) in `Startup.Configure`. Run a single action in this context and then close the context.

[!code-csharp[](windowsauth/sample_snapshot/Startup.cs?highlight=10-19)]

`RunImpersonated` doesn't support asynchronous operations and shouldn't be used for complex scenarios. For example, wrapping entire requests or middleware chains isn't supported or recommended.

::: moniker range=">= aspnetcore-3.0"

While the [Microsoft.AspNetCore.Authentication.Negotiate](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.Negotiate) package enables authentication on Windows, Linux, and macOS, impersonation is only supported on Windows.

::: moniker-end

## Claims transformations

::: moniker range=">= aspnetcore-3.0"

When hosting with IIS, <xref:Microsoft.AspNetCore.Authentication.AuthenticationService.AuthenticateAsync*> isn't called internally to initialize a user. Therefore, an <xref:Microsoft.AspNetCore.Authentication.IClaimsTransformation> implementation used to transform claims after every authentication isn't activated by default. For more information and a code example that activates claims transformations, see <xref:host-and-deploy/aspnet-core-module#in-process-hosting-model>.

::: moniker-end

::: moniker range="< aspnetcore-3.0"

When hosting with IIS in-process mode, <xref:Microsoft.AspNetCore.Authentication.AuthenticationService.AuthenticateAsync*> isn't called internally to initialize a user. Therefore, an <xref:Microsoft.AspNetCore.Authentication.IClaimsTransformation> implementation used to transform claims after every authentication isn't activated by default. For more information and a code example that activates claims transformations when hosting in-process, see <xref:host-and-deploy/aspnet-core-module#in-process-hosting-model>.

::: moniker-end

## Additional resources

* [dotnet publish](/dotnet/core/tools/dotnet-publish)
* <xref:host-and-deploy/iis/index>
* <xref:host-and-deploy/aspnet-core-module>
* <xref:host-and-deploy/visual-studio-publish-profiles>
