---
title: ASP.NET Core on Nano Server
author: rick-anderson
ms.author: riande
manager: wpickett
ms.date: 10/14/2016
ms.topic: article
ms.assetid: 50922cf1-ca58-4006-9236-99b7ff2dd0cf
ms.prod: aspnet-core
uid: tutorials/nano-server
---
# ASP.NET Core on Nano Server

<a name=nano-server></a>

By [Sourabh Shirhatti](https://twitter.com/sshirhatti)

In this tutorial, you'll take an existing ASP.NET Core app and deploy it to a Nano Server instance running IIS.

## Introduction

Nano Server is an installation option in Windows Server 2016, offering a tiny footprint, better security and better servicing than Server Core or full Server. Please consult the official [Nano Server documentation](https://technet.microsoft.com/en-us/library/mt126167.aspx) for more details.  
There are 3 easy ways for you to try out Nano Server, you can download 180 days evaluation versions, when you sign in with your MS account.

1. You can download the Windows Server 2016 ISO file, and build a Nano Server image

2. Download the Nano Server VHD

3. Create a VM in Azure using the Nano Server image in the Azure Gallery. If you don’t have an Azure account, you can get a free 30-day trial

In this tutorial, we will be using the 2nd option, the pre-built Nano Server VHD from Windows Server 2016

Before proceeding with this tutorial, you will need the [published](../publishing/index.md) output of an existing ASP.NET Core application. Ensure your application is built to run in a **64-bit** process.


## Setting up the Nano Server Instance

[Create a new Virtual Machine using Hyper-V](https://technet.microsoft.com/en-us/library/hh846766.aspx) on your development machine using the previously downloaded VHD. The machine will require you to set an administrator password before logging on. At the VM console, press F11 to set the password before the first log in.  
Then you also need to check your new VM's IP address either my checking your DHCP server, fixed IP supplied while provisioning your VM or in Nano Server recovery console's networking settings.

> [!NOTE]
> Let's assume your new VM runs with the local V4 IP address 192.168.1.10.

Now you're able to manage it using PowerShell remoting, which is the only way to fully administer your Nano Server

### Connecting to your Nano Server Instance using PowerShell Remoting

Open an elevated PowerShell window to add your remote Nano Server instance to your `TrustedHosts` list.

> which is necessary when remoting with WinRM over HTTP (default port 5985). After importing a certificate and enabling 
> WinRM over HTTPS/SSL (port 5986) you no longer need to alter the `TrustedHosts` list.


<!-- literal_block {"ids": [], "classes": ["code", "ps1"], "xml:space": "preserve"} -->

````
$nanoServerIpAddress = "192.168.1.10"
   Set-Item WSMan:\localhost\Client\TrustedHosts "$nanoServerIpAddress" -Concatenate -Force
   ````

Once you have added your Nano Server instance to your `TrustedHosts`, you can connect to it using PowerShell remoting

<!-- literal_block {"ids": [], "classes": ["code", "ps1"], "xml:space": "preserve"} -->

````
$nanoServerSession = New-PSSession -ComputerName $nanoServerIpAddress -Credential ~\Administrator
   Enter-PSSession $nanoServerSession
   ````

A successful connection results in a prompt with a format looking like: `[192.168.1.10]: PS C:\Users\Administrator\Documents>`

## Creating a file share

Create a file share on the Nano server so that the published application can be copied to it. Run the following commands in the remote session:

<!-- literal_block {"ids": [], "classes": ["code", "ps1"], "xml:space": "preserve"} -->

````
mkdir C:\PublishedApps\AspNetCoreSampleForNano
   netsh advfirewall firewall set rule group="File and Printer Sharing" new enable=yes
   net share AspNetCoreSampleForNano=c:\PublishedApps\AspNetCoreSampleForNano /GRANT:EVERYONE`,FULL
   ````

After running the above commands you should be able to access this share by visiting `\\<nanoserver-ip-address>\AspNetCoreSampleForNano` in the host machine's Windows Explorer.

## Open port in the Firewall

Run the following commands in the remote session to open up a port in the firewall to let IIS listen for TCP traffic on port 80/tcp.

<!-- literal_block {"ids": [], "classes": ["code", "ps1"], "xml:space": "preserve"} -->

````
New-NetFirewallRule -Name "AspNet5 IIS" -DisplayName "Allow HTTP on TCP/80" -Protocol TCP -LocalPort 80 -Action Allow -Enabled True
   ````

## Installing IIS

Add the `NanoServerPackage` provider from the PowerShell gallery. Once the provider is installed and imported, you can install Windows packages.

Run the following commands in the PowerShell session that was created earlier:

<!-- literal_block {"ids": [], "classes": ["code", "ps1"], "xml:space": "preserve"} -->

````
Install-PackageProvider NanoServerPackage
   Import-PackageProvider NanoServerPackage
   Install-NanoServerPackage -Name Microsoft-NanoServer-Storage-Package
   Install-NanoServerPackage -Name Microsoft-NanoServer-IIS-Package
   ````

To quickly verify if IIS is setup correctly, you can visit the url `http://<nanoserver-ip-address>/` and should see a welcome page. When IIS is installed, by default a web site called `Default Web Site` listening on port 80 is created.

## Installing the ASP.NET Core Module (ANCM)

The ASP.NET Core Module is an IIS 7.5+ module which is responsible for process management of ASP.NET Core HTTP listeners and to proxy requests to processes that it manages. At the moment, the process to install the ASP.NET Core Module for IIS is manual. You will need to install the version of the [.NET Core Windows Server Hosting bundle](https://dot.net/) on a regular (not Nano) machine. After installing the bundle on a regular machine, you will need to copy the following files to the file share that we created earlier.

On a regular (not Nano) machine run the following copy commands:

<!-- literal_block {"ids": [], "classes": ["code", "ps1"], "xml:space": "preserve"} -->

````
copy C:\windows\system32\inetsrv\aspnetcore.dll ``\\<nanoserver-ip-address>\AspNetCoreSampleForNano``
   copy C:\windows\system32\inetsrv\config\schema\aspnetcore_schema.xml ``\\<nanoserver-ip-address>\AspNetCoreSampleForNano``
   ````

On a Nano machine, you will need to copy the following files from the file share that we created earlier to the valid locations. So, run the following copy commands:

<!-- literal_block {"ids": [], "classes": ["code", "ps1"], "xml:space": "preserve"} -->

````
copy C:\PublishedApps\AspNetCoreSampleForNano\aspnetcore.dll C:\windows\system32\inetsrv\
   copy C:\PublishedApps\AspNetCoreSampleForNano\aspnetcore_schema.xml C:\windows\system32\inetsrv\config\schema\
   ````

Run the following script in the remote session:

<!-- literal_block {"xml:space": "preserve", "source": "tutorials/nano-server/enable-ancm.ps1", "ids": [], "linenos": false, "highlight_args": {"linenostart": 1}} -->

````
# Backup existing applicationHost.config
   copy C:\Windows\System32\inetsrv\config\applicationHost.config C:\Windows\System32\inetsrv\config\applicationHost_BeforeInstallingANCM.config

   Import-Module IISAdministration

   # Initialize variables
   $aspNetCoreHandlerFilePath="C:\windows\system32\inetsrv\aspnetcore.dll"
   Reset-IISServerManager -confirm:$false
   $sm = Get-IISServerManager

   # Add AppSettings section 
   $sm.GetApplicationHostConfiguration().RootSectionGroup.Sections.Add("appSettings")

   # Set Allow for handlers section
   $appHostconfig = $sm.GetApplicationHostConfiguration()
   $section = $appHostconfig.GetSection("system.webServer/handlers")
   $section.OverrideMode="Allow"

   # Add aspNetCore section to system.webServer
   $sectionaspNetCore = $appHostConfig.RootSectionGroup.SectionGroups["system.webServer"].Sections.Add("aspNetCore")
   $sectionaspNetCore.OverrideModeDefault = "Allow"
   $sm.CommitChanges()

   # Configure globalModule
   Reset-IISServerManager -confirm:$false
   $globalModules = Get-IISConfigSection "system.webServer/globalModules" | Get-IISConfigCollection
   New-IISConfigCollectionElement $globalModules -ConfigAttribute @{"name"="AspNetCoreModule";"image"=$aspNetCoreHandlerFilePath}

   # Configure module
   $modules = Get-IISConfigSection "system.webServer/modules" | Get-IISConfigCollection
   New-IISConfigCollectionElement $modules -ConfigAttribute @{"name"="AspNetCoreModule"}

   # Backup existing applicationHost.config
   copy C:\Windows\System32\inetsrv\config\applicationHost.config C:\Windows\System32\inetsrv\config\applicationHost_AfterInstallingANCM.config


   ````

> [!NOTE]
> Delete the files `aspnetcore.dll` and `aspnetcore_schema.xml` from the share after the above step.

## Installing .NET Core Framework

If you published a portable app (FDD),
.NET Core must be installed on the target machine. Execute the following Powershell script in a remote Powershell session to install the .NET Framework on your Nano Server.

> to understand the differences of Framework-dependent deployments (FDD) and Self-contained deployments (SCD) check
> [deployment options](https://docs.microsoft.com/en-us/dotnet/articles/core/deploying/)

[!code-powershell[Main](nano-server/Download-Dotnet.ps1)]

## Publishing the application

Copy over the published output of your existing application to the file share.

You may need to make changes to your *web.config* to point to where you extracted `dotnet.exe`. Alternatively, you can add `dotnet.exe` to your path.

Example of how a web.config might look like if `dotnet.exe` was **not** on the path:

<!-- literal_block {"ids": [], "classes": ["code", "xml"], "xml:space": "preserve"} -->

````
<?xml version="1.0" encoding="utf-8"?>
   <configuration>
     <system.webServer>
       <handlers>
         <add name="aspNetCore" path="*" verb="*" modules="AspNetCoreModule" resourceType="Unspecified" />
       </handlers>
       <aspNetCore processPath="C:\dotnet\dotnet.exe" arguments=".\AspNetCoreSampleForNano.dll" stdoutLogEnabled="false" stdoutLogFile=".\logs\stdout" forwardWindowsAuthToken="true" />
     </system.webServer>
   </configuration>
   ````

Run the following commands in the remote session to create a new site in IIS for the published app. This script uses the `DefaultAppPool` for simplicity. For more considerations on running under an application pool, see [Application Pools](../hosting/apppool.md#apppool).

<!-- literal_block {"ids": [], "classes": ["code", "powershell"], "xml:space": "preserve"} -->

````
Import-module IISAdministration
   New-IISSite -Name "AspNetCore" -PhysicalPath c:\PublishedApps\AspNetCoreSampleForNano -BindingInformation "*:8000:"
   ````

## Known issue running .NET Core CLI on Nano Server and Workaround



## Running the Application

The published web app should be accessible in browser at `http://<nanoserver-ip-address>:8000`. If you have set up logging as described in [Log creation and redirection](../hosting/aspnet-core-module.md#log-redirection), you should be able to view your logs at *C:\PublishedApps\AspNetCoreSampleForNano\logs*.
