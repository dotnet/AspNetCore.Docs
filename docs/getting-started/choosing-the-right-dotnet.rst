Choosing the Right .NET For You on the Server
=============================================
By :ref:`Daniel Roth <choosing-the-right-dotnet-author>` | Originally Published: 29 April 2015

ASP.NET 5 is based on the :doc:`.NET Execution Environment (DNX) </dnx/overview>`, which supports running cross-platform on Windows, Mac and Linux. When selecting a DNX to use you also have a choice of .NET flavors to pick from: .NET Framework (CLR), :doc:`.NET Core </conceptual-overview/dotnetcore>` (CoreCLR) or `Mono <http://mono-project.com>`_. Which .NET flavor should you choose? Let's look at the pros and cons of each one.

.NET Framework
--------------

The .NET Framework is the most well known and mature of the three options. The .NET Framework is a mature and fully featured framework that ships with Windows. The .NET Framework ecosystem is well established and has been around for well over a decade. The .NET Framework is production ready today and provides the highest level of compatibility for your existing applications and libraries.

The .NET Framework runs on Windows only. It is also a monolithic component with a large API surface area and a slower release cycle. While the code for the .NET Framework is `available for reference <http://referencesource.microsoft.com/>`_ it is not an active open source project.

.NET Core
---------

.NET Core 5 is a modular runtime and library implementation that includes a subset of the .NET Framework. Currently it is feature complete on Windows, and in-progress builds exist for both Linux and OS X. .NET Core consists of a set of libraries, called "CoreFX", and a small, optimized runtime, called "CoreCLR". .NET Core is open-source, so you can follow progress on the project and contribute to it on `GitHub <https://github.com/dotnet>`_.

The CoreCLR runtime (Microsoft.CoreCLR) and CoreFX libraries are distributed via `NuGet <https://www.nuget.org>`_. Because .NET Core has been built as a componentized set of libraries you can limit the API surface area your application uses to just the pieces you need. You can also run .NET Core based applications on much more constrained environments (ex. `Windows Server Nano <http://blogs.technet.com/b/windowsserver/archive/2015/04/08/microsoft-announces-nano-server-for-modern-apps-and-cloud.aspx>`_).

The API factoring in .NET Core was updated to enable better componentization. This means that existing libraries built for the .NET Framework generally need to be recompiled to run on .NET Core. The .NET Core ecosystem is relatively new, but it is rapidly growing with the support of popular .NET packages like JSON.NET, AutoFac, xUnit.net and many others.

Developing on .NET Core allows you to target a single consistent platform that can run on multiple platforms. However, the .NET Core support for Mac and Linux is still very new and not ready for production workloads.

Please see :doc:`/conceptual-overview/dotnetcore` for more details on what .NET Core has to offer.

Mono
----

`Mono <http://mono-project.com>`_ is a port of the .NET Framework built primarily for non-Windows platforms. Mono is open source and cross-platform. It also shares a similar API factoring to the .NET Framework, so many existing managed libraries work on Mono today. Mono is not a supported platform by Microsoft. It is however a good proving ground for cross-platform development while cross-platform support in .NET Core matures.

Summary
-------

The .NET Execution Environment (DNX) and .NET Core make .NET development available to more scenarios than ever before. DNX also gives you the option to target your application at existing available .NET platforms. Which .NET flavor you pick will depend on your specific scenarios, timelines, feature requirements and compatibility requirements.

.. _choosing-the-right-dotnet-author:

.. include:: /_authors/daniel-roth.txt
