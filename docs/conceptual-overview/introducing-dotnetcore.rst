Introducing .NET Core
=====================
By :ref:`Steve Smith <introducing-dotnetcore-author>` | Originally Published: 28 April 2015 

.NET Core is a small, optimized runtime that can be targeted by ASP.NET 5 applications. In fact, the new ASP.NET 5 project templates target .NET Core by default, in addition to the .NET Framework. Learn what targeting .NET Core means for your ASP.NET 5 application.

In this article:
	- `What is .NET Core`_?
	- `Motivation Behind .NET Core`_
	- `Building Applications with .NET Core`_
	- `.NET Core and NuGet`_
	- `Additional Reading`_

What is .NET Core
^^^^^^^^^^^^^^^^^

.NET Core 5 is a modular runtime and library implementation that includes a subset of the .NET Framework. Currently it is feature complete on Windows, and in-progress builds exist for both Linux and OS X. .NET Core consists of a set of libraries, called "CoreFX", and a small, optimized runtime, called "CoreCLR". .NET Core is open-source, so you can follow progress on the project and contribute to it on GitHub:

	- `.NET Core Libraries (CoreFX) <https://github.com/dotnet/corefx>`_
	- `.NET Core Common Language Runtime (CoreCLR) <https://github.com/dotnet/coreCLR>`_

The CoreCLR runtime (Microsoft.CoreCLR) and CoreFX libraries are distributed via NuGet. The CoreFX libraries are factored as individual NuGet packages according to functionality, named "System.[module]" on `nuget.org <http://www.nuget.org/>`_.

One of the key benefits of .NET Core is its portability. You can package and deploy the CoreCLR with your application, eliminating your application's dependency on an installed version of .NET (e.g. .NET Framework on Windows). You can host multiple applications side-by-side using different versions of the CoreCLR, and upgrade them individually, rather than being forced to upgrade all of them simultaneously.

CoreFX has been built as a componentized set of libraries, each requiring the minimum set of library dependencies (e.g. System.Collections only depends on System.Runtime, not System.Xml). This approach enables minimal distributions  of CoreFX libraries (just the ones you need) within an application, alongside CoreCLR. CoreFX includes collections, console access, diagnostics, IO, LINQ, JSON, XML, and regular expression support, just to name a few libraries. Another benefit of CoreFX is that it allows developers to target a single common set of libraries that are supported by multiple platforms. 

Motivation Behind .NET Core
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

When .NET first shipped in 2002, it was a single framework, but it didn't take long before the .NET Compact Framework shipped, providing a smaller version of .NET designed for mobile devices. Over the years, this exercise was repeated multiple times, so that today there are different flavors of .NET specific to different platforms. Add to this the further platform reach provided by Mono and Xamarin, which target Linux, Mac, and native iOS and Android devices. For each platform, a separate vertical stack consisting of runtime, framework, and app model is required to develop .NET applications. One of the primary goals of .NET Core is to provide a single, modular, cross-platform version of .NET that works the same across all of these platforms. Since .NET Core is a fully open source project, the Mono community can benefit from CoreFX libraries. .NET Core will not replace Mono, but it will allow the Mono community to reference and share, rather than duplicate, certain common libraries, and to contribute directly to CoreFX, if desired.

In addition to being able to target a variety of different device platforms, there was also pressure from the server side to reduce the overall footprint, and more importantly, surface area, of the .NET Framework. By factoring the CoreFX libraries and allowing individual applications to pull in only those parts of CoreFX they require (a so-called "pay-for-play" model), server-based applications built with ASP.NET 5 can minimize their dependencies. This, in turn, reduces the frequency with which patches and updates to the framework will impact these applications, since only changes made to the individual pieces of CoreFX leveraged by the application will impact the application. A smaller deployment size for the application is a side benefit, and one that makes more of a difference if many applications are deployed side-by-side on a given server.

..note The overall size of .NET Core doesn't intend to be smaller than the .NET Framework over time, but since it is pay-for-play, most applications that utilize only parts of CoreFX will have a smaller deployment footprint.

Building Applications with .NET Core
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

.NET Core can be used to build a variety of applications using different application models including Web applications, console applications and native mobile applications. The .NET Execution Environment (DNX) provides a cross-platform runtime host that you can use to build .NET Core based applications that can run on Windows, Mac and Linux and is the foundation for running ASP.NET applications on .NET Core. Applications running on DNX can target the .NET Framework or .NET Core. In fact, DNX projects can be cross-compiled, targeting both of these frameworks in a single project, and this is how the project templates ship with Visual Studio 2015. For example, the ``frameworks`` section of *project.json* in a new ASP.NET 5 web project will target *dnx451* and *dnxcore50* by default:

.. code-block:: javascript

	"frameworks": {
		"dnx451": { },
		"dnxcore50": { }
	},

``dnx451`` represents the .NET Framework, while ``dnxcore50`` represents .NET Core 5 (5.0). You can use compiler directives (``#if``) to check for symbols that correspond to the two frameworks: ``DNX451`` and ``DNXCORE50``. If for instance you have code that uses resources that are not available as part of .NET Core, you can surround them in a conditional compilation directive:

.. code-block:: c#

	#if DNX451
		// utilize resource only available with .NET Framework
	#endif

The recommendation from the ASP.NET team is to target both frameworks with new applications. If you want to only target .NET Core, remove *dnx451*, or only target .NET Framework, remove *dnxcore50*, from the *frameworks* listed in *project.json*. Note that ASP.NET 4.6 and earlier target and require the .NET Framework, as they always have.

.NET Core and NuGet
^^^^^^^^^^^^^^^^^^^

Using NuGet allows for much more agile usage of the individual libraries that comprise .NET Core. It also means that an application can list a collection of NuGet packages (and associated version information) and this will comprise both system/framework as well as third-party dependencies required. Further, third-party dependencies can now also express their specific dependencies on framework features, making it much easier to ensure the proper packages and versions are pulled together during the development and build process.

If, for example, you need to use immutable collections, you can install the System.Collections.Immutable package via NuGet. The NuGet version will also align with the assembly version, and will use `semantic versioning <http://semver.org>`_.

.. note:: Although CoreFX will be made available as a fairly large number of individual NuGet packages, it will continue to ship periodically as a full unit that Microsoft has tested as a whole. These distributions will most likely ship at a lower cadence than individual packages, allowing time to perform necessary testing, fixes, and the distribution process.

Summary
^^^^^^^

.NET Core is a modular, streamlined subset of the .NET Framework and CLR. It is fully open-source and provides a common set of libraries that can be targeted across numerous platforms. Its factored approach allows applications to take dependencies only on those portions of the CoreFX that they use, and the smaller runtime is ideal for deployment to both small devices (though it doesn't yet support any) as well as cloud-optimized environments that need to be able to run many small applications side-by-side. Support for targeting .NET Core is built into the ASP.NET 5 project templates that ship with Visual Studio 2015.

Additional Reading
^^^^^^^^^^^^^^^^^^

Learn more about .NET Core:
	- `Immo Landwerth Explains .NET Core <http://blogs.msdn.com/b/dotnet/archive/2014/12/04/introducing-net-core.aspx>`_
	- `What is .NET Core 5 and ASP.NET 5 <http://blogs.msdn.com/b/cesardelatorre/archive/2014/11/18/what-is-net-core-5-and-asp-net-5-within-net-2015-preview.aspx>`_
	- `.NET Core 5 on dotnetfoundation.org <https://www.dotnetfoundation.org/netcore5>`_
	- `.NET Core is Open Source <http://blogs.msdn.com/b/dotnet/archive/2014/11/12/net-core-is-open-source.aspx>`_
	- `.NET Core on GitHub <https://github.com/dotnet/corefx>`_
	
.. _introducing-dotnetcore-author:

.. include:: /_authors/steve-smith.txt
