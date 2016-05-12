.. _nano-server:

ASP.NET Core on Nano Server
===========================

By `Sourabh Shirhatti`_

.. attention:: This tutorial uses a pre-release version of the Nano Server installation option of Windows Server Technical Preview 5. You may use the software in the virtual hard disk image only to internally demonstrate and evaluate it. You may not use the software in a live operating environment. Please see https://go.microsoft.com/fwlink/?LinkId=624232 for specific information about the end date for the preview.

In this tutorial, you'll take an existing ASP.NET Core app and deploy it to a Nano Server instance running IIS.

.. contents:: Sections:
  :local:
  :depth: 1

Introduction
------------

Nano Server is an installation option in Windows Server 2016, offering a tiny footprint, better security and better servicing than Server Core or full Server. Please consult the official `Nano Server documentation <https://technet.microsoft.com/en-us/library/mt126167.aspx>`__ for more details.  There are 3 ways for you try out Nano Server for yourself:

1.	You can download the Windows Server 2016 Technical Preview 5 ISO file, and build a Nano Server image
2.	Download the Nano Server developer VHD
3.	Create a VM in Azure using the Nano Server image in the Azure Gallery. If you don’t have an Azure account, you can get a free 30-day trial

In this tutorial, we will be using the pre-built `Nano Server Developer VHD <https://msdn.microsoft.com/en-us/virtualization/windowscontainers/nano_eula>`_  from Windows Server Technical Preview 5.

Before proceeding with this tutorial, you will need the :doc:`published </publishing/index>` output of an existing ASP.NET Core application. Ensure your application is built to run in a **64-bit** process.

Setting up the Nano Server Instance
-----------------------------------

`Create a new Virtual Machine using Hyper-V <https://technet.microsoft.com/en-us/library/hh846766.aspx>`_ on your development machine using the previously downloaded VHD. The machine will require you to set an administator password before logging on. At the VM console, press F11 to set the password before the first logon.

After setting the local password, you will manage Nano Server using PowerShell remoting.

Connecting to your Nano Server Instance using PowerShell Remoting
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

Open an elevated PowerShell window to add your remote Nano Server instance to your ``TrustedHosts`` list.

.. code:: ps1

  $ip = "10.83.181.14" # replace with the correct IP address
  Set-Item WSMan:\localhost\Client\TrustedHosts "$ip" -Concatenate -Force

Once you have added your Nano Server instance to your ``TrustedHosts``, you can connect to it using PowerShell remoting

.. code:: ps1

  $ip = "10.83.181.14" # replace with the correct IP address
  $s = New-PSSession -ComputerName $ip -Credential ~\Administrator
  Enter-PSSession $s

A successful connection results in a prompt with the following format: ``[10.83.181.14]: PS C:\Users\Administrator\Documents>``

.. code:: ps1

  Install-PackageProvider NanoServerPackage
  Import-PackageProvider NanoServerPackage
  Install-NanoServerPackage -Name Microsoft-NanoServer-IIS-Package


Installing the ASP.NET Core Module
----------------------------------

The :ref:`ASP.NET Core Module <http-platformhandler>` is an IIS 7.5+ module which is responsible for process management of ASP.NET Core HTTP listeners and to proxy requests to processes that it manages. At the moment, the process to install the ASP.NET Core Module for IIS is manual. You will need to install the version of the `.NET Core Windows Server Hosting bundle <https://dot.net/>`__ on a regular (not Nano) machine. After installing you will need to copy the following files:

=======
Installing IIS
--------------

Add the ``NanoServerPackage`` provider from the PowerShell gallery. Once the provider is installed and imported, you can install Windows packages.

.. code:: ps1

  Install-PackageProvider NanoServerPackage
  Import-PackageProvider NanoServerPackage
  Install-NanoServerPackage -Name Microsoft-NanoServer-IIS-Package


Installing the ASP.NET Core Module
----------------------------------

The :ref:`ASP.NET Core Module <http-platformhandler>` is an IIS 7.5+ module which is responsible for process management of ASP.NET Core HTTP listeners and to proxy requests to processes that it manages. Currently, installing ASP.NET Core Module requires the following script:

.. code:: ps1

  copy <update-this>\aspnetcore_schema.xml C:\windows\system32\inetsrv\config\schema
  copy <update-this>\aspnetcore.dll C:\windows\system32\inetsrv

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
  

Enabling the ASP.NET Core Module
--------------------------------

Execute the following PowerShell script in a remote PowerShell session to enable the HttpPlatformHandler module on the Nano server.

.. note:: This script runs on a clean system but is not idempotent. Entries are added each time the script is run. You can restore *applicationHost.config* with backups from *%systemdrive%\inetpub\history*.

.. literalinclude:: nano-server/enable-ancm.ps1
  :language: ps1

Manually Editing *applicationHost.config*
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

Skip this section if you ran the PowerShell script above. Running the PowerShell script above is the recommended approach to enabling the ASP.NET Core Module; alternatively you can edit the *applicationHost.config* file.

Open up *C:\\Windows\\System32\\inetsrv\\config\\applicationHost.config*

Under ``<configSections>`` add

.. literalinclude:: nano-server/applicationHost.config
  :language: xml
  :lines: 42-43
  :dedent: 4
  :emphasize-lines: 2

In the ``system.webServer`` section group, update the handlers section to allow the configured handlers to be overridden.

.. literalinclude:: nano-server/applicationHost.config
  :language: xml
  :lines: 55,63
  :dedent: 8
  :emphasize-lines: 2

Add ``ASP.NET Core Module`` to the ``globalModules`` section

.. literalinclude:: nano-server/applicationHost.config
  :language: xml
  :lines: 210,224
  :dedent: 8
  :emphasize-lines: 2

Additionally, add ``ASP.NET Core Module`` to the ``modules`` section

.. literalinclude:: nano-server/applicationHost.config
  :language: xml
  :lines: 275,286
  :dedent: 8
  :emphasize-lines: 2

Installing .NET Core Framework
------------------------------

If you published a portable app, .NET Core must be installed on the target machine. Execute the following Powershell script in a remote Powershell session to install the .NET Framework on your Nano Server.

.. literalinclude:: nano-server/Download-Dotnet.ps1
  :language: powershell

Publishing the application
--------------------------

Copy over the published output of your existing application to the Nano server. You may need to make changes to your *web.config* to point to where you extracted ``dotnet.exe``. Alternatively, you can add ``dotnet.exe`` to your path.

.. code:: ps1

  $ip = "10.83.181.14" # replace with the correct IP address
  $s = New-PSSession -ComputerName $ip -Credential ~\Administrator
  Copy-Item -ToSession $s -Path <path-to-src>\bin\output\ -Destination C:\HelloAspNetCore -Recurse
  
You may also need to make the following OS changes:

.. code:: ps1

  netsh advfirewall firewall set rule group="File and Printer Sharing" new enable=yes
  net share musicstore=c:\deployed\musicstore /GRANT:EVERYONE`,FULL

Use the following PowerShell snippet to create a new site in IIS for the published app. This script uses the ``DefaultAppPool`` for simplicity. For more considerations on running under an application pool, see :ref:`apppool`.

.. code:: powershell

  Import-module IISAdministration
  New-IISSite -Name "AspNetCore" -PhysicalPath c:\HelloAspNetCore\ -BindingInformation "*:8000:"

Manually Editing *applicationHost.config*
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

You can also create the site by manually editing the *applicationHost.config* file.

.. literalinclude:: nano-server/applicationHost.config
  :language: xml
  :lines: 152,161-168,175
  :dedent: 8
  :emphasize-lines: 2-9

Open a Port in the Firewall
---------------------------

Since we have IIS listening on port **8000** and forwarding request to our application, we will need open up the port to TCP traffic.

.. code:: ps1

  New-NetFirewallRule -Name "AspNet5" -DisplayName "HTTP on TCP/8000" -Protocol TCP -LocalPort 8000 -Action Allow -Enabled True

Running the Application
-----------------------

The published web app should be accessible in browser at ``http://<ip-address>:8000``.
If you have set up logging as described in :ref:`log-redirection`, you should be able to view your logs at *C:\\HelloAspNetCore\\logs*.


