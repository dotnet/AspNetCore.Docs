Installing ASP.NET 5 On Windows
===============================
By :ref:`Steve Smith <installing-on-windows-author>` | Originally Published: 28 April 2015 

This article describes how to install ASP.NET 5 on Windows, showing both standalone installation as well as installation with Visual Studio 2015. 

In this article:
	- `Install ASP.NET with Visual Studio`_
	- `Install ASP.NET Standalone`_

Install ASP.NET with Visual Studio
----------------------------------

The easiest way to get started building application with ASP.NET 5 is to install the latest version of Visual Studio 2015 (including the freely available Community edition). Visual Studio is an Integrated Development Environment (IDE), which means it's not just an editor, but also many of the tools you need to build applications, in this case ASP.NET 5 web applications. When installing Visual Studio 2015, you'll want to be sure to specify that you want to install the Microsoft Web Developer Tools.

.. image:: installing-on-windows/_static/web-dev-tools.png

Once Visual Studio is installed, ASP.NET 5 is installed as well. You're ready to :doc:`build your first ASP.NET application </tutorials/your-first-aspnet-application>`.

Install ASP.NET Standalone
--------------------------

Visual Studio isn't the only way to install ASP.NET, and installing an IDE may not be appropriate in some scenarios. You can also install ASP.NET on its own from a command prompt. There are a few steps involved, since we'll need to install and configure the environment in which ASP.NET runs, known as the .NET Execution Environment (DNX). Before installing DNX, we need one more tool, the .NET Version Manager (DNVM).

Install the .NET Version Manager (DNVM)
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

The .NET Version Manager is used to install one or more versions of the .NET Execution Environment, and to manage which version is currently active. To install DNVM on Windows, you need to open a command prompt as an Administrator, and run the following Powershell script:

.. code-block:: console


	@powershell -NoProfile -ExecutionPolicy unrestricted -Command "&{$Branch='dev';iex ((new-object net.webclient).DownloadString('https://raw.githubusercontent.com/aspnet/Home/dev/dnvminstall.ps1'))}"

After the script has run, open a new command prompt and confirm DNVM is working by typing: ``dnvm``
	
Assuming DNVM is configured correctly, you should see a result like this:

.. image:: installing-on-windows/_static/dnvm-prompt.png

Install the .NET Execution Environment (DNX)
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

To install the latest version of DNX using DNVM, run: ``dnvm upgrade``

This command downloads the latest version of DNX and puts it on your user profile so that it is ready to use. 

After this command completes, run: ``dnx`` to confirm DNX is configured correctly.

.. image:: installing-on-windows/_static/dnx-installed.png

Now that DNX is installed, you're ready to begin using ASP.NET 5! 

Summary
-------

You can install ASP.NET 5 on Windows either as a standalone installation, or as part of Visual Studio 2015. In either case, installation is straightforward, and once complete, you're ready to get :doc:`started building your first ASP.NET application </tutorials/your-first-aspnet-application>`.

Related Resources
^^^^^^^^^^^^^^^^^

- :doc:`Installing ASP.NET 5 on OS X <installing-on-mac>`
- :doc:`Your First ASP.NET 5 Application Using Visual Studio </tutorials/your-first-aspnet-application>`

.. _installing-on-windows-author:

.. include:: /_authors/steve-smith.txt
