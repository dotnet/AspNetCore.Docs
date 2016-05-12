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

Windows Server 2016 Technical Preview offers a new installation option: Nano Server. Nano Server is a remotely administered server operating system optimized for private clouds and datacenters. It takes up far less disk space, sets up significantly faster, and requires far fewer updates and restarts than Windows Server. You can learn more about Nano Server from the `official docs <https://msdn.microsoft.com/en-us/library/mt126167.aspx>`_.

In this tutorial, we will be using the pre-built `Virtual Hard Disk (VHD) for Nano Server <https://msdn.microsoft.com/en-us/virtualization/windowscontainers/nano_eula>`_  from Windows Server Technical Preview 5.

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

If you have successfully connected then your prompt will look like this ``[10.83.181.14]: PS C:\Users\Administrator\Documents>``

Installing IIS
--------------

Add the ``NanoServerPackage`` provider from the PowerShell gallery. Once the provider is installed and imported, you can install Windows packages.

.. code:: ps1

  Install-PackageProvider NanoServerPackage
  Import-PackageProvider NanoServerPackage
  Install-NanoServerPackage -Name Microsoft-NanoServer-IIS-Package


Installing the ASP.NET Core Module
----------------------------------

The :ref:`ASP.NET Core Module <http-platformhandler>` is an IIS 7.5+ module which is responsible for process management of ASP.NET Core HTTP listeners and to proxy requests to processes that it manages. At the moment, the process to install the ASP.NET Core Module for IIS is manual. You will need to install the version of the `.NET Core Windows Server Hosting bundle <https://dot.net/>`__ on a regular (not Nano) machine. After installing you will need to copy the following files:

* *%windir%\\System32\\inetsrv\\aspnetcore.dll*
* *%windir%\\System32\\inetsrv\\config\\schema\\aspnetcore_schema.xml*

On the Nano machine you’ll need to copy those two files to their respective locations.

.. code:: ps1

  Copy-Item .\aspnetcore.dll.dll c:\Windows\System32\inetsrv
  Copy-Item .\aspnetcore_schema.xml c:\Windows\System32\inetsrv\config\schema

Enabling the ASP.NET Core Module
--------------------------------

You can execute the following PowerShell script in a remote PowerShell session to enable the HttpPlatformHandler module on the Nano server.

.. note:: This script runs on a clean system, but is not meant to be idempotent. If you run this multiple times it will add multiple entries. If you end up in a bad state, you can find backups of the *applicationHost.config* file at *%systemdrive%\inetpub\history*.

.. literalinclude:: nano-server/enable-ancm.ps1
  :language: ps1

Manually Editing *applicationHost.config*
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

You can skip this section if you already ran the PowerShell script above. Though is not recommended, you can alternatively enable the HttpPlatformHandler by manually editing the *applicationHost.config* file.

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

Add ``AspNetCoreModule`` to the ``globalModules`` section

.. literalinclude:: nano-server/applicationHost.config
  :language: xml
  :lines: 210,224
  :dedent: 8
  :emphasize-lines: 2

Additionally, add ``AspNetCoreModule`` to the ``modules`` section

.. literalinclude:: nano-server/applicationHost.config
  :language: xml
  :lines: 275,286
  :dedent: 8
  :emphasize-lines: 2

Installing .NET Core Framework
------------------------------

If you published a portable app, you require .NET Core to be installed on your target machine. You can execute the following Powershell script in a remote Powershell session to install the .NET Framework to your Nano Server.

.. literalinclude:: nano-server/Download-Dotnet.ps1
  :language: powershell

Publishing the application
--------------------------

Copy over the published output of your existing application to the Nano server. You may be required to make changes to your *web.config* to point to where you extracted ``dotnet.exe``. Alternatively, you can add ``dotnet.exe`` to your path.

.. code:: ps1

  $ip = "10.83.181.14" # replace with the correct IP address
  $s = New-PSSession -ComputerName $ip -Credential ~\Administrator
  Copy-Item -ToSession $s -Path <path-to-src>\bin\output\ -Destination C:\HelloAspNet5 -Recurse

Use the following PowerShell snippet to create a new site in IIS for our published app. This script uses the ``DefaultAppPool`` for simplicity. For more considerations on running under an application pool, see :ref:`apppool`.

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

At this point your published web application, should be accessible in browser by visiting ``http://<ip-address>:8000``.
If you have set up logging as described in :ref:`log-redirection`, you should be able to view your logs at *C:\\HelloAspNetCore\\logs*.


