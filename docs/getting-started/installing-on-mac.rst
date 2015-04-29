Installing ASP.NET 5 On Mac OS X
================================
By :ref:`Steve Smith <installing-on-mac-author>` | Originally Published: 28 April 2015 

ASP.NET 5 runs on the .NET Execution Environment (DNX), which is available on multiple platforms, including OS X. This article describes how to install DNX, and therefore ASP.NET 5, on OS X, using `Homebrew <http://brew.sh/>`_. 

In this article:
	- `Install ASP.NET 5 on OS X`_

Install ASP.NET 5 on OS X
-------------------------

ASP.NET 5 requires DNX, which is installed and managed by the .NET Version Manager (DNVM). The DNVM is easily installed using a tool called Homebrew, which will also install the correct version of Mono for OS X.

Install Homebrew
^^^^^^^^^^^^^^^^

The first step is to install Homebrew if it's not already installed. This can be done from a Terminal prompt using this script:

.. code-block:: console

	ruby -e "$(curl -fsSL https://raw.githubusercontent.com/Homebrew/install/master/install)"

The installer will inform you of the steps it is taking and pause before proceeding. You can `learn more about Homebrew here <https://github.com/Homebrew/homebrew/tree/master/share/doc/homebrew#readme>`_.

Install the .NET Version Manager (DNVM)
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

Once Homebrew is installed, install the DNVM by running ``brew tap aspnet/dnx`` from a Terminal window. If you need to update your version of DNVM, first run ``brew untap aspnet/dnx`` to delete the old commands, and then run the ``brew tap aspnet/dnx`` command again to get the updated scripts.

.. image:: installing-on-mac/_static/homebrew-tap-aspnet.png

Next, run the command ``brew install dnvm`` to install the .NET Version Manager. This will also automatically install the latest DNX package from the https://www.nuget.org/api/v2 feed. 

.. image:: installing-on-mac/_static/brew-install-dnvm.png

Next, run ``dnvm`` to verify that your terminal understands this command. If it does not, run the command ``source dnvm.sh`` to link it, then try running ``dnvm`` again. You should see something like this:

.. image:: installing-on-mac/_static/run-dnvm.png

To install the latest version of DNX using DNVM, run: ``dnvm upgrade``

Now that DNX is installed, you're ready to begin using ASP.NET 5! Learn how you can :doc:`create a cross-platform console application </dnx/dnx-console>` or a simple ASP.NET MVC application that runs within DNX.

.. TODO: create links to cross-platform console application and simple ASP.NET MVC application running in DNX/command line.

Summary
-------

ASP.NET 5 is built on the cross-platform .NET Execution Environment, which can be installed on OS X as well as Linux and Windows. Installing DNX and ASP.NET 5 on OS X takes just a few minutes, using a few Terminal commands. 

Related Resources
-----------------

- :doc:`Installing ASP.NET 5 on Windows <installing-on-windows>`
- :doc:`Your First ASP.NET 5 Application Using Visual Studio </tutorials/your-first-aspnet-application>`

.. _installing-on-mac-author:

.. include:: /_authors/steve-smith.rst
