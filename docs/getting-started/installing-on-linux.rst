Installing ASP.NET 5 On Linux
================================
By :ref:`Daniel Roth <installing-on-linux-author>` | Originally Published: 28 April 2015 

ASP.NET 5 runs on the .NET Execution Environment (DNX), which is available on multiple platforms, including Linux. This article describes how to install DNX, and therefore ASP.NET 5, on Linux using Mono.

.. note::

    You can also run DNX on Mac and Linux using .NET Core. .NET Core for Mac and Linux is still in the early stages of development, but if you want to experiment with it please follow along on `GitHub <https://github.com/aspnet/home>`_.

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

The following instructions were tested using Ubuntu 14.04 and Mint 17.01
    
Install Mono
^^^^^^^^^^^^

`Mono <http://mono-project.com>`_ is an ongoing effort to port the .NET Framework to other platforms. Mono is one of the ways .NET applications can run on platforms other than Windows. ASP.NET 5 requires a version of Mono greater than 4.0.1.

To install Mono::

    sudo apt-key adv --keyserver keyserver.ubuntu.com --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF
    echo "deb http://download.mono-project.com/repo/debian wheezy main" | sudo tee /etc/apt/sources.list.d/mono-xamarin.list
    sudo apt-get update
    sudo apt-get install Mono-Complete

Install libuv
^^^^^^^^^^^^^

`Libuv <https://github.com/libuv/libuv>`_ is a multi-platform asynchronous IO library that is used by the `KestrelHttpServer <https://github.com/aspnet/KestrelHttpServer>`_ that we will use to host our ASP.NET 5 web applications.

To build libuv you should do the following::

    sudo apt-get install automake libtool curl
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
    
Install the .NET Version Manager (DNVM)
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

Now let's get DNVM. To do this run::

    curl -sSL https://raw.githubusercontent.com/aspnet/Home/dev/dnvminstall.sh | DNX_BRANCH=dev sh && source ~/.dnx/dnvm/dnvm.sh
    
Once this step is complete you should be able to run ``dnvm`` and see some help text.

Add NuGet sources
^^^^^^^^^^^^^^^^^

Now that we have DNVM and the other tools needed to run an ASP.NET 5 application you can configure additional NuGet package sources to get access to the dev builds of all the ASP.NET 5 packages.

The nightly package source is: `https://www.myget.org/F/aspnetvnext/api/v2/`

You specify your package sources through your NuGet.config file.

Edit: ``~/.config/NuGet/NuGet.config``

The NuGet.config file should look something like the following

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
    
.. _installing-on-linux-author:
    
.. include:: /_authors/daniel-roth.txt    

