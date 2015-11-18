Installing ASP.NET 5 On Windows
===============================

By `Rick Anderson`_, `Steve Smith`_, `Daniel Roth`_

This page shows you how to install ASP.NET 5 on Windows. To run ASP.NET 5 apps on IIS, see :doc:`/publishing/iis`.

.. contents:: In this article:
  :local:
  :depth: 1

Install ASP.NET 5 with Visual Studio
------------------------------------

The easiest way to get started building applications with ASP.NET 5 is to install the latest version of Visual Studio 2015 (including the free Community edition). 

1. Install `Visual Studio 2015 <http://go.microsoft.com/fwlink/?LinkId=532606>`__

  Be sure to specify that you want to include the Microsoft Web Developer Tools.

  .. image:: installing-on-windows/_static/web-dev-tools.png

2. Install `ASP.NET 5 <http://go.microsoft.com/fwlink/?LinkId=627627>`_. 
  
  This will install the latest ASP.NET 5 runtime and tooling.
  
  *NOTE: There is currently a known issue with the ASP.NET 5 RC installer. If you run the installer from a folder that contains previous versions of the MSI installers for DNVM (DotNetVersionManager-x64.msi or DotNetVersionManager-x86.msi) or the ASP.NET tools for Visual Studio (WebToolsExtensionsVS14.msi or WebToolsExtensionsVWD14.msi), the installer will fail with an error "0x80091007 - The hash value is not correct". To work around this issue, run the installer from a folder that does not contain previous versions of the installer files.*
  
3. Enable the ASP.NET 5 command-line tools. Open a command-prompt and run::

    dnvm upgrade

  This will make the default :doc:`/dnx/index` active on the path.

4. On Windows 7 and Windows Server 2008 R2 you will also need to install the `Visual C++ Redistributable for Visual Studio 2012 Update 4 <https://www.microsoft.com/en-us/download/confirmation.aspx?id=30679>`__.
    
You are all set up and ready to write :doc:`your first ASP.NET 5 application </tutorials/your-first-aspnet-application>`!

Install ASP.NET 5 from the command-line
---------------------------------------

You can also install ASP.NET 5 from the command-line. There are a few steps involved, since we'll need to install and configure the environment in which ASP.NET runs, the :doc:`/dnx/index`. To install DNX, we need one more tool, the .NET Version Manager (DNVM).

Install the .NET Version Manager (DNVM)
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

Use .NET Version Manager to install different versions of the .NET Execution Environment (DNX). 

To install DNVM open a command prompt and run the following::

  @powershell -NoProfile -ExecutionPolicy unrestricted -Command "&{$Branch='dev';iex ((new-object net.webclient).DownloadString('https://raw.githubusercontent.com/aspnet/Home/dev/dnvminstall.ps1'))}"

Once this step is complete you should be able to run ``dnvm`` and see some help text.

Install the .NET Execution Environment (DNX)
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

The .NET Execution Environment (DNX) is used to build and run .NET projects. Use DNVM to install DNX for the full .NET Framework or for .NET Core (see :doc:`choosing-the-right-dotnet`).

**To install DNX for .NET Core:**

1. Use DNVM to install DNX for .NET Core::

    dnvm upgrade -r coreclr

**To install DNX for the full .NET Framework:**

1. Use DNVM to install DNX for the full .NET Framework::

    dnvm upgrade -r clr

By default DNVM will install DNX for the full .NET Framework if no runtime is specified.

Related Resources
-----------------

- :doc:`/tutorials/your-first-aspnet-application`
- :doc:`/fundamentals/index`


