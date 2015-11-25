Choosing the Right .NET For You on the Server
=============================================

By `Daniel Roth`_ and `Rick Anderson`_

ASP.NET 5 is based on the :doc:`.NET Execution Environment (DNX) </dnx/overview>`, which supports running cross-platform on Windows, Mac and Linux. DNX come in three .NET versions: 

- .NET Framework (Also known as the "*Full*" .NET Framework)
- :doc:`.NET Core </conceptual-overview/dotnetcore>` (CoreCLR)
- `Mono <http://mono-project.com>`_

Which .NET flavor should you choose? Let's look at the pros and cons of each one.

.NET Framework
--------------

Pros:

- Most complete, well known, and mature of the three frameworks
- Well established ecosystem that is more than a decade old
- Provides the highest level of compatibility for your existing apps and libraries
- Production ready 
- Ships with Windows

Cons:

- Runs only on Windows
- Monolithic component with a large API surface area
- Slower release cycle
- Not an active open source project (but `available for reference <http://referencesource.microsoft.com/>`__)

.NET Core
---------

- A subset of .NET Framework
- Modular runtime and library
- Feature complete on Windows, and in-progress builds exist for both Linux and OS X. 
- Open-source. You can follow progress on the project, track issues, and contribute to it on `GitHub <https://github.com/dotnet>`_.
- Componentized set of libraries which allows you to limit the API surface area your app. You just add the components you need. 
- Allows you to run .NET Core based apps on much more constrained environments (for example, `Windows Server Nano <http://blogs.technet.com/b/windowsserver/archive/2015/04/08/microsoft-announces-nano-server-for-modern-apps-and-cloud.aspx>`_).

.NET Core consists of:

- **CoreFX**: a set of libraries
- **CoreCLR**: (``Microsoft.CoreCLR``) a small, modular optimized runtime

The CoreCLR runtime and CoreFX libraries are distributed via `NuGet <https://www.nuget.org>`_. 

The API factoring in .NET Core was architected for componentization. This means that existing libraries built for the .NET Framework generally need to be recompiled to run on .NET Core. The ecosystem is relatively new, but it is rapidly growing with the support of popular .NET packages like `JSON.NET <https://github.com/JamesNK/Newtonsoft.Json>`__, `AutoFac <http://autofac.org/>`__, `xUnit <https://github.com/xunit/xunit>`__  and many others.

Developing on .NET Core allows you to target a single consistent platform that can run on multiple platforms. However, the .NET Core support for Mac and Linux is still very new and not ready for production workloads.

Please see :doc:`/conceptual-overview/dotnetcore` for more details on what .NET Core has to offer.

Mono
----

`Mono <http://mono-project.com>`_ is a port of the .NET Framework built primarily for non-Windows platforms. Mono is open source and cross-platform. It also shares a similar API factoring to the .NET Framework, so many existing managed libraries work on Mono today. Mono is not a supported platform by Microsoft. It's a good proving ground for cross-platform development while .NET Core matures.

Related Resources
-----------------

- :doc:`/fundamentals/index`
- `HttpPlatformHandler, Kestrel and WebListener <https://github.com/aspnet/Home/wiki/Servers>`__


