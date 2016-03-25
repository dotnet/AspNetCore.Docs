Choosing the Right .NET For You on the Server
=============================================

By `Daniel Roth`_

ASP.NET Core is based on the `.NET Core`_ project model, which supports building applications that can run cross-platform on Windows, Mac and Linux. When building a .NET Core project you also have a choice of which .NET flavor to target your application at: .NET Framework (CLR), .NET Core (CoreCLR) or `Mono <http://mono-project.com>`_. Which .NET flavor should you choose? Let's look at the pros and cons of each one.

.NET Framework
--------------

The .NET Framework is the most well known and mature of the three options. The .NET Framework is a mature and fully featured framework that ships with Windows. The .NET Framework ecosystem is well established and has been around for well over a decade. The .NET Framework is production ready today and provides the highest level of compatibility for your existing applications and libraries.

The .NET Framework runs on Windows only. It is also a monolithic component with a large API surface area and a slower release cycle. While the code for the .NET Framework is `available for reference <http://referencesource.microsoft.com/>`_ it is not an active open source project.

.NET Core
---------

.NET Core is a modular runtime and library implementation that includes a subset of the .NET Framework. .NET Core is supported on Windows, Mac and Linux. .NET Core consists of a set of libraries, called "CoreFX", and a small, optimized runtime, called "CoreCLR". .NET Core is open-source, so you can follow progress on the project and contribute to it on `GitHub <https://github.com/dotnet>`_.

The CoreCLR runtime (Microsoft.CoreCLR) and CoreFX libraries are distributed via `NuGet`_. Because .NET Core has been built as a componentized set of libraries you can limit the API surface area your application uses to just the pieces you need. You can also run .NET Core based applications on much more constrained environments (ex. `Windows Server Nano <http://blogs.technet.com/b/windowsserver/archive/2015/04/08/microsoft-announces-nano-server-for-modern-apps-and-cloud.aspx>`_).

The API factoring in .NET Core was updated to enable better componentization. This means that existing libraries built for the .NET Framework generally need to be recompiled to run on .NET Core. The .NET Core ecosystem is relatively new, but it is rapidly growing with the support of popular .NET packages like JSON.NET, AutoFac, xUnit.net and many others.

Developing on .NET Core allows you to target a single consistent platform that can run on multiple platforms. 

Mono
----

`Mono <http://mono-project.com>`_ is a port of the .NET Framework built primarily for non-Windows platforms. Mono is open source and cross-platform. It also shares a similar API factoring to the .NET Framework, so many existing managed libraries work on Mono today. Mono is a good proving ground for cross-platform development while cross-platform support in .NET Core matures.

Summary
-------

The .NET Core project model makes .NET development available for more scenarios than ever before. With .NET Core you have the option to target your application at existing available .NET platforms. Which .NET flavor you pick will depend on your specific scenarios, timelines, feature requirements and compatibility requirements.

