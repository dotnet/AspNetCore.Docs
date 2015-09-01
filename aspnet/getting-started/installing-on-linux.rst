Installing ASP.NET 5 On Linux
================================

By `Daniel Roth`_

ASP.NET 5 runs on the .NET Execution Environment (DNX), which is available on multiple platforms, including Linux. This article describes how to install DNX, and therefore ASP.NET 5, on Linux using .NET Core and Mono.

In this article:
  - `Using Docker`_
  - `Installing on Debian, Ubuntu and derivatives`_
  - `Installing on CentOS, Fedora and derivatives`_

Using Docker
------------

Instructions on how to use the ASP.NET 5 Docker image can be found here: http://blogs.msdn.com/b/webdev/archive/2015/01/14/running-asp-net-5-applications-in-linux-containers-with-docker.aspx

The rest of this section deals with setting up a machine to run applications without the Docker image.

Installing on Debian, Ubuntu and derivatives
--------------------------------------------

The following instructions were tested using Ubuntu 14.04.

Install the .NET Version Manager (DNVM)
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

Use the .NET Version Manager (DNVM) to install different versions of the .NET Execution Environment (DNX) on Linux.

To install DNVM run the following::

    curl -sSL https://raw.githubusercontent.com/aspnet/Home/dev/dnvminstall.sh | DNX_BRANCH=dev sh && source ~/.dnx/dnvm/dnvm.sh
    
Once this step is complete you should be able to run ``dnvm`` and see some help text.

.. note::

    The .NET Version Manager (DNVM) needs unzip to function properly. If you don't have it installed, run ``sudo apt-get install unzip`` to install it before using DNVM to install the .NET Execution Environment (DNX).

Install the .NET Execution Environment (DNX)
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

The .NET Execution Environment (DNX) is used to build and run .NET projects. Use DNVM to install a DNX for `Mono <http://mono-project.com>`_ or .NET Core (see :doc:`choosing-the-right-dotnet`).

To install DNX for .NET Core run::

    dnvm upgrade -r coreclr

.. note:: Running .NET Core on Linux currently requires installing the following additional packages: ``libunwind8``, ``gettext``, ``libssl-dev``, ``libcurl3-dev``, ``zlib1g``
  
.. note:: .NET Core on Linux is still in early preview. Please refer to the latest `Release Notes <https://github.com/aspnet/home/releases>`__ for known issues and limitations.

To install DNX for Mono run::

    dnvm upgrade -r mono

By default DNVM will install a DNX for Mono if no runtime is specified.

.. note:: To use DNX on Mono you must first `install Mono <http://www.mono-project.com/docs/getting-started/install/linux/#debian-ubuntu-and-derivatives>`__ via the ``mono-complete`` package. Ensure that the ``ca-certificates-mono`` package is also installed as `noted <http://www.mono-project.com/docs/getting-started/install/linux/#notes>`__ in the Mono installation instructions.

.. note:: Restoring packages using DNX on Mono may fail with multiple canceled requests. You may be able to work around this issue by setting ``MONO_THREADS_PER_CPU`` to a larger number (ex. 2000).

Install libuv
^^^^^^^^^^^^^

`Libuv <https://github.com/libuv/libuv>`_ is a multi-platform asynchronous IO library that is used by :ref:`kestrel`, a cross-platform HTTP server for hosting ASP.NET 5 web applications.

To build libuv you should do the following::

    sudo apt-get install make automake libtool curl
    curl -sSL https://github.com/libuv/libuv/archive/v1.4.2.tar.gz | sudo tar zxfv - -C /usr/local/src
    cd /usr/local/src/libuv-1.4.2
    sudo sh autogen.sh
    sudo ./configure
    sudo make 
    sudo make install
    sudo rm -rf /usr/local/src/libuv-1.4.2 && cd ~/
    sudo ldconfig

.. note::

    ``make install`` puts ``libuv.so.1`` in ``/usr/local/lib``, in the above commands ```ldconfig`` is used to update ``ld.so.cache`` so that ``dlopen`` (see ``man dlopen``) can load it. If you are getting libuv some other way or not running ``make install`` then you need to ensure that dlopen is capable of loading ``libuv.so.1``.
    
Add NuGet sources
^^^^^^^^^^^^^^^^^

Now that we have installed DNX and the other tools needed to run an ASP.NET 5 application you can configure additional NuGet package sources to get access to the dev builds of all the ASP.NET 5 packages.

The dev package source is: `https://www.myget.org/F/aspnetvnext/api/v2/`

You specify your package sources through your NuGet.Config file.

Edit: ``~/.config/NuGet/NuGet.Config``

The NuGet.Config file should look something like the following

.. code-block:: xml

    <?xml version="1.0" encoding="utf-8"?>
    <configuration>
      <packageSources>
        <add key="AspNetVNext" value="https://www.myget.org/F/aspnetvnext/api/v2/" />
        <add key="nuget.org" value="https://www.nuget.org/api/v2/" />
      </packageSources>
      <disabledPackageSources />
    </configuration>

You should now be able to restore packages from both the official public feed on https://nuget.org and also from the ASP.NET 5 dev builds.

Installing on CentOS, Fedora and derivatives
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

.. note::

    Installation steps for CentOS, Fedora and derivatives are not currently available but should be available soon. The commands are mostly the same, with some differences to account for the different package managers used on these systems. Learn how you can `contribute <https://github.com/aspnet/Docs/blob/master/CONTRIBUTING.md>`_ on GitHub.
  

