---
title: Common errors reference for Azure App Service and IIS with ASP.NET Core
author: guardrex
description: Distinguish common errors when hosting ASP.NET Core apps on Azure Apps Service and IIS.
manager: wpickett
ms.author: riande
ms.custom: mvc
ms.date: 03/13/2017
ms.prod: asp.net-core
ms.technology: aspnet
ms.topic: article
uid: host-and-deploy/azure-iis-errors-reference
---
# Common errors reference for Azure App Service and IIS with ASP.NET Core

By [Luke Latham](https://github.com/guardrex)

The following isn't a complete list of errors. If you encounter an error not listed here, [open a new issue](https://github.com/aspnet/Docs/issues/new) with detailed instructions to reproduce the error.

## Installer unable to obtain VC++ Redistributable

* **Installer Exception:** 0x80072efd or 0x80072f76 - Unspecified error

* **Installer Log Exception&#8224;:** Error 0x80072efd or 0x80072f76: Failed to execute EXE package

  &#8224;The log is located at C:\Users\\{USER}\AppData\Local\Temp\dd_DotNetCoreWinSvrHosting__{timestamp}.log.

Troubleshooting:

* If the system doesn't have Internet access while installing the server hosting bundle, this exception occurs when the installer is prevented from obtaining the *Microsoft Visual C++ 2015 Redistributable*. Obtain an installer from the [Microsoft Download Center](https://www.microsoft.com/download/details.aspx?id=53840). If the installer fails, the server may not receive the .NET Core runtime required to host a framework-dependent deployment (FDD). If hosting an FDD, confirm that the runtime is installed in Programs &amp; Features. If needed, obtain a runtime installer from [.NET Downloads](https://www.microsoft.com/net/download/core). After installing the runtime, restart the system or restart IIS by executing **net stop was /y** followed by **net start w3svc** from a command prompt.

## OS upgrade removed the 32-bit ASP.NET Core Module

* **Application Log:** The Module DLL **C:\WINDOWS\system32\inetsrv\aspnetcore.dll** failed to load. The data is the error.

Troubleshooting:

* Non-OS files in the **C:\Windows\SysWOW64\inetsrv** directory aren't preserved during an OS upgrade. If the ASP.NET Core Module is installed prior to an OS upgrade and then any AppPool is run in 32-bit mode after an OS upgrade, this issue is encountered. After an OS upgrade, repair the ASP.NET Core Module. See [Install the .NET Core Windows Server Hosting bundle](xref:host-and-deploy/iis/index#install-the-net-core-windows-server-hosting-bundle). Select **Repair** when the installer is run.

## Platform conflicts with RID

* **Browser:** HTTP Error 502.5 - Process Failure

* **Application Log:** Application 'MACHINE/WEBROOT/APPHOST/{ASSEMBLY}' with physical root 'C:\{PATH}\' failed to start process with commandline '"C:\\{PATH}{assembly}.{exe|dll}" ', ErrorCode = '0x80004005 : ff.

* **ASP.NET Core Module Log:** Unhandled Exception: System.BadImageFormatException: Could not load file or assembly '{assembly}.dll'. An attempt was made to load a program with an incorrect format.

Troubleshooting:

* Confirm that the app runs locally on Kestrel. A process failure might be the result of a problem within the app. For more information, see [Troubleshooting](xref:host-and-deploy/iis/troubleshoot).

* Confirm that the `<PlatformTarget>` in the *.csproj* doesn't conflict with the RID. For example, don't specify a `<PlatformTarget>` of `x86` and publish with an RID of `win10-x64`, either by using *dotnet publish -c Release -r win10-x64* or by setting the `<RuntimeIdentifiers>` in the *.csproj* to `win10-x64`. The project publishes without warning or error but fails with the above logged exceptions on the system.

* If this exception occurs for an Azure Apps deployment when upgrading an app and deploying newer assemblies, manually delete all files from the prior deployment. Lingering incompatible assemblies can result in a `System.BadImageFormatException` exception when deploying an upgraded app.

## URI endpoint wrong or stopped website

* **Browser:** ERR_CONNECTION_REFUSED

* **Application Log:** No entry

* **ASP.NET Core Module Log:** Log file not created

Troubleshooting:

* Confirm the correct URI endpoint for the app is being used. Check the bindings.

* Confirm that the IIS website isn't in the *Stopped* state.

## CoreWebEngine or W3SVC server features disabled

* **OS Exception:** The IIS 7.0 CoreWebEngine and W3SVC features must be installed to use the ASP.NET Core Module.

Troubleshooting:

* Confirm that the proper role and features are enabled. See [IIS Configuration](xref:host-and-deploy/iis/index#iis-configuration).

## Incorrect website physical path or app missing

* **Browser:** 403 Forbidden - Access is denied **--OR--** 403.14 Forbidden - The Web server is configured to not list the contents of this directory.

* **Application Log:** No entry

* **ASP.NET Core Module Log:** Log file not created

Troubleshooting:

* Check the IIS website **Basic Settings** and the physical app folder. Confirm that the app is in the folder at the IIS website **Physical path**.

## Incorrect role, module not installed, or incorrect permissions

* **Browser:** 500.19 Internal Server Error - The requested page cannot be accessed because the related configuration data for the page is invalid.

* **Application Log:** No entry

* **ASP.NET Core Module Log:** Log file not created

Troubleshooting:

* Confirm that the proper role is enabled. See [IIS Configuration](xref:host-and-deploy/iis/index#iis-configuration).

* Check **Programs &amp; Features** and confirm that the **Microsoft ASP.NET Core Module** has been installed. If the **Microsoft ASP.NET Core Module** isn't present in the list of installed programs, install the module. See [Install the .NET Core Windows Server Hosting bundle](xref:host-and-deploy/iis/index#install-the-net-core-windows-server-hosting-bundle).

* Make sure that the **Application Pool** > **Process Model** > **Identity** is set to **ApplicationPoolIdentity** or the custom identity has the correct permissions to access the app's deployment folder.

## Incorrect processPath, missing PATH variable, hosting bundle not installed, system/IIS not restarted, VC++ Redistributable not installed, or dotnet.exe access violation

* **Browser:** HTTP Error 502.5 - Process Failure

* **Application Log:** Application 'MACHINE/WEBROOT/APPHOST/{ASSEMBLY}' with physical root 'C:\\{PATH}\' failed to start process with commandline '".\{assembly}.exe" ', ErrorCode = '0x80070002 : 0.

* **ASP.NET Core Module Log:** Log file created but empty

Troubleshooting:

* Confirm that the app runs locally on Kestrel. A process failure might be the result of a problem within the app. For more information, see [Troubleshooting](xref:host-and-deploy/iis/troubleshoot).

* Check the *processPath* attribute on the `<aspNetCore>` element in *web.config* to confirm that it's *dotnet* for a framework-dependent deployment (FDD) or *.\{assembly}.exe* for a self-contained deployment (SCD).

* For an FDD, *dotnet.exe* might not be accessible via the PATH settings. Confirm that *C:\Program Files\dotnet\* exists in the System PATH settings.

* For an FDD, *dotnet.exe* might not be accessible for the user identity of the Application Pool. Confirm that the AppPool user identity has access to the *C:\Program Files\dotnet* directory. Confirm that there are no deny rules configured for the AppPool user identity on the *C:\Program Files\dotnet* and app directories.

* An FDD may have been deployed and .NET Core installed without restarting IIS. Either restart the server or restart IIS by executing **net stop was /y** followed by **net start w3svc** from a command prompt.

* An FDD may have been deployed without installing the .NET Core runtime on the hosting system. If the .NET Core runtime hasn't been installed, run the **.NET Core Windows Server Hosting bundle installer** on the system. See [Install the .NET Core Windows Server Hosting bundle](xref:host-and-deploy/iis/index#install-the-net-core-windows-server-hosting-bundle). If attempting to install the .NET Core runtime on a system without an Internet connection, obtain the runtime from [.NET Downloads](https://www.microsoft.com/net/download/core) and run the hosting bundle installer to install the ASP.NET Core Module. Complete the installation by restarting the system or restarting IIS by executing **net stop was /y** followed by **net start w3svc** from a command prompt.

* An FDD may have been deployed and the *Microsoft Visual C++ 2015 Redistributable (x64)* isn't installed on the system. Obtain an installer from the [Microsoft Download Center](https://www.microsoft.com/download/details.aspx?id=53840).

## Incorrect arguments of \<aspNetCore\> element

* **Browser:** HTTP Error 502.5 - Process Failure

* **Application Log:** Application 'MACHINE/WEBROOT/APPHOST/{ASSEMBLY}' with physical root 'C:\\{PATH}\' failed to start process with commandline '"dotnet" .\{assembly}.dll', ErrorCode = '0x80004005 : 80008081.

* **ASP.NET Core Module Log:** The application to execute does not exist: 'PATH\{assembly}.dll'

Troubleshooting:

* Confirm that the app runs locally on Kestrel. A process failure might be the result of a problem within the app. For more information, see [Troubleshooting](xref:host-and-deploy/iis/troubleshoot).

* Examine the *arguments* attribute on the `<aspNetCore>` element in *web.config* to confirm that it's either (a) *.\{assembly}.dll* for a framework-dependent deployment (FDD); or (b) not present, an empty string (*arguments=""*), or a list of the app's arguments (*arguments="arg1, arg2, ..."*) for a self-contained deployment (SCD).

## Missing .NET Framework version

* **Browser:** 502.3 Bad Gateway - There was a connection error while trying to route the request.

* **Application Log:** ErrorCode = Application 'MACHINE/WEBROOT/APPHOST/{ASSEMBLY}' with physical root 'C:\\{PATH}\' failed to start process with commandline '"dotnet" .\{assembly}.dll', ErrorCode = '0x80004005 : 80008081.

* **ASP.NET Core Module Log:** Missing method, file, or assembly exception. The method, file, or assembly specified in the exception is a .NET Framework method, file, or assembly.

Troubleshooting:

* Install the .NET Framework version missing from the system.

* For a framework-dependent deployment (FDD), confirm that the correct runtime installed on the system. If the project is upgraded from 1.1 to 2.0, deployed to the hosting system, and this exception results, ensure that the 2.0 framework is on the hosting system.

## Stopped Application Pool

* **Browser:** 503 Service Unavailable

* **Application Log:** No entry

* **ASP.NET Core Module Log:** Log file not created

Troubleshooting

* Confirm that the Application Pool isn't in the *Stopped* state.

## IIS Integration middleware not implemented

* **Browser:** HTTP Error 502.5 - Process Failure

* **Application Log:** Application 'MACHINE/WEBROOT/APPHOST/{ASSEMBLY}' with physical root 'C:\\{PATH}\' created process with commandline '"C:\\{PATH}\{assembly}.{exe|dll}" ' but either crashed or did not reponse or did not listen on the given port '{PORT}', ErrorCode = '0x800705b4'

* **ASP.NET Core Module Log:** Log file created and shows normal operation.

Troubleshooting

* Confirm that the app runs locally on Kestrel. A process failure might be the result of a problem within the app. For more information, see [Troubleshooting](xref:host-and-deploy/iis/troubleshoot).

* Confirm that either:
  * The IIS Integration middleware is referencedby calling the `UseIISIntegration` method on the app's `WebHostBuilder` (ASP.NET Core 1.x)
  * The apps uses the `CreateDefaultBuilder` method (ASP.NET Core 2.x).
  
  See [Hosting in ASP.NET Core](xref:fundamentals/hosting) for details.

## Sub-application includes a \<handlers\> section

* **Browser:** HTTP Error 500.19 - Internal Server Error

* **Application Log:** No entry

* **ASP.NET Core Module Log:** Log file created and shows normal operation for the root app. Log file not created for the sub-app.

Troubleshooting

* Confirm that the sub-app's *web.config* file doesn't include a `<handlers>` section.

## Application configuration general issue

* **Browser:** HTTP Error 502.5 - Process Failure

* **Application Log:** Application 'MACHINE/WEBROOT/APPHOST/{ASSEMBLY}' with physical root 'C:\\{PATH}\' created process with commandline '"C:\\{PATH}\{assembly}.{exe|dll}" ' but either crashed or did not reponse or did not listen on the given port '{PORT}', ErrorCode = '0x800705b4'

* **ASP.NET Core Module Log:** Log file created but empty

Troubleshooting

* This general exception indicates that the process failed to start, most likely due to an app configuration issue. Referring to [Directory Structure](xref:host-and-deploy/directory-structure), confirm that the app's deployed files and folders are appropriate and that the app's configuration files are present and contain the correct settings for the app and environment. For more information, see [Troubleshooting](xref:host-and-deploy/iis/troubleshoot).
