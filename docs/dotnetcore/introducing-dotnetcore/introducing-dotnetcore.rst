Introducing .NET Core
=====================
By `Steve Smith`_ | Originally Published: 1 June 2015 

.. _`Steve Smith`: Author_

.NET Core is a small, optimized runtime that can be targeted by ASP.NET 5 applications. In fact, the new ASP.NET 5 project templates target .NET Core by default, in addition to the .NET Framework. Learn what targeting .NET Core means for your ASP.NET 5 application.

This article covers the following topics:
	- What is .NET Core?
	- Motivation Behind .NET Core
	- .NET Core and ASP.NET
	- .NET Core and NuGet
	- Additional Reading

What is .NET Core
^^^^^^^^^^^^^^^^^

.NET Core 5 is a modular runtime and library implementation that includes a subset of the full .NET Framework. Currently it is feature complete on Windows, and is in-progress builds exist for both Linux and OS X. .NET Core consists of a set of libraries, called "CoreFX", and a small, optimized runtime, called "CoreCLR". .NET Core is open-source, so you can follow progress on the project and contribute to it on GitHub:

	- `.NET Core Libraries (CoreFX) <https://github.com/dotnet/corefx>`_
	- `.NET Core Common Language Runtime (CoreCLR) <https://github.com/dotnet/coreCLR>`_

The CoreCLR runtime is made available via NuGet (Microsoft.CoreCLR); the CoreFX library is also available as a set of individual NuGet packages, factored according to functionality. These packages are named "System.[module]" on `nuget.org <http://www.nuget.org/>`_.

One of the key benefits of .NET Core is its portability. You can package and deploy the CoreCLR with your application, eliminating your application's dependency on an installed version of .NET (e.g. .NET Framework on Windows). You can host multiple applications side-by-side using different versions of the CoreCLR, and upgrade them individually, rather than being forced to upgrade all of them simultaneously.

Another benefit of CoreFX is that it allows developers to target a single common set of libraries across many different platforms. The CoreFX library includes collections, console access, diagnostics, IO, LINQ, JSON, XML, and regular expression support, just to name a few. Applications targeting a variety of devices and deployment models (such as Windows Desktop, Windows Store, Windows Phone, and ASP.NET) can directly target these libraries, avoiding the need to write wrapper code or conditionally compile based on target platform, as was often required with previous versions of the .NET Framework.

Motivation Behind .NET Core
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

The fragmentation of .NET and its capabilities across different platforms is the primary motivation for .NET Core. When .NET first shipped in 2002, it was a single framework, but it didn't take long before the .NET Compact Framework shipped, providing a smaller version of .NET designed for mobile devices. Over the years, this exercise was repeated multiple times, so that today there are different flavors of .NET specific to different platforms. Add to this the further fragmentation created by Mono and Xamarin, which target Linux, Mac, and native iOS and Android devices, and the need for a single common Core of .NET that works the same across all of these platforms becomes even more apparent. Since .NET Core is a full open source project, the Mono community can contribute to it, as well as reference it directly, rather than maintaining copies of libraries CoreFX libraries. .NET Core will not replace Mono, but it will allow the Mono community to reference and share, rather than duplicate, certain common libraries.

In addition to being able to target a variety of different device platforms, there was also pressure from the server side to reduce the overall footprint of the .NET Framework. By factoring the CoreFX libraries and allowing individual applications to pull in only those parts of CoreFX they require (a so-called "pay-for-play" model), server-based applications built with ASP.NET 5 can minimize total deployed size (especially when being deployed side-by-side). This in turn can increase the density of applications cloud hosting environments can support on a given set of hardware resources (though this is not the only way in which ASP.NET has increased app density). This provides increased economies of scale for ASP.NET applications hosted in cloud environments, such as Azure.

..note The overall size of .NET Core doesn't intend to be smaller than the .NET Framework over time, but since it is pay-for-play, most applications that utilize only parts of CoreFX will have a smaller deployment footprint.

.NET Core and ASP.NET
^^^^^^^^^^^^^^^^^^^^^

ASP.NET 5 can target either the full .NET Framework or .NET Core. In fact, ASP.NET 5 projects can be cross-compiled, targeting both of these frameworks in a single project, and this is how the project templates ship with Visual Studio 2015. For example, the :keyword:`frameworks` section of *project.json* in a new ASP.NET 5 web project will target *dnx451* and *dnxcore50* by default:

.. code-block:: javascript

	"frameworks": {
		"dnx451": { },
		"dnxcore50": { }
	},

*dnx451* is the full .NET Framework; *dnxcore50* is .NET Core 5 (5.0).

Since both the full .NET Framework and .NET Core can both be targeted at the same time by ASP.NET 5, the recommendation is to target both with new applications, resolving issues with dependencies that are incompatible with .NET Core through the use of conditional compilation directives or choosing to require the full .NET Framework, if necessary. Note that ASP.NET 4.6 and earlier target and require the .NET Framework, as always.

.. note:: You can use compiler directives (**#if**) to check for symbols that correspond to the two frameworks: :keyword:`DNX451` and :keyword:`DNXCORE50`.
	
If for instance you have code that uses resources that are not available as part of .NET Core, you can surround them in a conditional compilation directive:

.. code-block:: c#

	#if DNX451
		// utilize resource only available with .NET Framework
	#endif

If you want to only target .NET Core, remove *dnx451* from the *frameworks* listed in *project.json*.

.NET Core and NuGet
^^^^^^^^^^^^^^^^^^^

As part of the effort to *factor* the CoreFX, the individual assemblies are distributed as separate NuGet packages. In fact, NuGet is the primary delivery vehicle for .NET Core. If, for example, you need to use immutable collections, you can install the System.Collections.Immutable package via NuGet. The NuGet version will also align with the assembly version, and will use `semantic versioning <http://semver.org>`_.

Using NuGet allows for much more agile usage of the individual libraries that comprise .NET Core. It also means that an application can list a collection of NuGet packages (and associated version information) and this will comprise both system/framework as well as third-party dependencies required. Further, third-party dependencies can now also express their specific dependencies on framework features, making it much easier to ensure the proper packages and versions are pulled together during the development and build process.

.. note:: Although CoreFX will be made available as a fairly large number of individual NuGet packages, it will continue to ship periodically as a full unit that Microsoft has been tested as a whole. These distributions will most likely ship at a lower cadence than individual packages, allowing time to perform necessary testing, fixes, and the distribution process.

Summary
^^^^^^^

.NET Core is a modular, streamlined subset of the full .NET Framework and CLR. It is fully open-source and provides a common set of libraries that can be targeted across numerous platforms. Its factored approach allows applications to take dependencies only on those portions of the CoreFX that they use, and the smaller runtime is ideal for deployment to both small devices (though it doesn't yet support any) as well as cloud-optimized environments that need to be able to run many small applications side-by-side. Support for targeting .NET Core is built into the ASP.NET 5 project templates that ship with Visual Studio 2015.

Additional Reading
^^^^^^^^^^^^^^^^^^

Learn more about .NET Core:
	- `Immo Landwerth Explains .NET Core <http://blogs.msdn.com/b/dotnet/archive/2014/12/04/introducing-net-core.aspx>`_
	- `What is .NET Core 5 and ASP.NET 5 <http://blogs.msdn.com/b/cesardelatorre/archive/2014/11/18/what-is-net-core-5-and-asp-net-5-within-net-2015-preview.aspx>`_
	- `.NET Core 5 on dotnetfoundation.org <https://www.dotnetfoundation.org/netcore5>`_
	- `.NET Core is Open Source <http://blogs.msdn.com/b/dotnet/archive/2014/11/12/net-core-is-open-source.aspx>`_
	- `.NET Core on GitHub <https://github.com/dotnet/corefx>`_
	
.. include:: /_authors/steve-smith.rst
