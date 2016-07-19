:version: 1.0.0

Hosting
=======

By `Steve Smith`_

To run an ASP.NET Core app, you need to configure and launch a host using ``WebHostBuilder``.

.. contents:: Sections:
  :local:
  :depth: 1

`View or download sample code <https://github.com/aspnet/Docs/tree/master/aspnet/fundamentals/hosting/sample>`__

What is a Host?
---------------

ASP.NET Core apps require a *host* in which to execute. A host must implement the :dn:iface:`~Microsoft.AspNetCore.Hosting.IWebHost` interface, which exposes collections of features and services, and a ``Start`` method. The host is typically created using an instance of a :dn:class:`~Microsoft.AspNetCore.Hosting.WebHostBuilder`, which in builds and returns a  :dn:class:`~Microsoft.AspNetCore.Hosting.WebHost` instance. The ``WebHost`` has a private ``Server`` property that is used once the application is up and running to handle requests. Learn more about :doc:`servers <servers>`.

What is the difference between a host and a server?
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

The host is responsible for ensuring the application's services and the server are available and properly configured. You can think of the host as being a wrapper around the server. The host is configured to use a particular server; the server is unaware of its host.

Setting up a Host
-----------------

You create a host using an instance of ``WebHostBuilder``. This is typically done in your app's entry point, which by default will be located in a *Program.cs* file. An example *Program.cs*, shown below, demonstrates how to use a ``WebHostBuilder`` to build a host. 

.. literalinclude:: /../common/samples/WebApplication1/src/WebApplication1/Program.cs
  :emphasize-lines: 14-21
  :language: c#
  :caption: Program.cs

The ``WebHostBuilder`` is responsible for creating the host that will bootstrap the server for the app. ``WebHostBuilder`` supports many optional extensions, but the specification of an ``IServer`` is required. The built-in server is Kestrel. Use ``UseKestrel`` (with options, if desired) to set it up as your app's server.

The server's *content root* determines where it searches for content files, like MVC View files. The default content root is the folder the application is run from, which for Kestrel is likely to be a something like ``bin\Debug\netcoreapp1.0``. To specify an alternate content root path, use ``UseContentRoot``. Specifying ``Directory.GetCurrentDirectory`` as the content root will use the web project's root folder as the app's content root when the app is started from this folder (for example, calling ``dotnet run`` from the web project folder).

.. note:: An ASP.NET Core app's content root determines where ASP.NET Core will begin searching for content files, such as MVC Views.

If the app should work with IIS, the ``UseIISIntegration`` method should be called as part of building the host. Note that this does not configure a *server*, like ``UseKestrel`` does. To use IIS with ASP.NET Core, you must specify both ``UseKestrel`` and ``UseIISIntegration``.

A ``Startup`` class, which must define methods for ``Configure`` and ``ConfigureServices``, can be specified by calling ``UseStartup``. Alternately, call ``Configure`` and ``ConfigureServices`` directly on a ``WebHostBuilder`` instance to create a host without a ``Startup`` class definition.

The host will listen on certain configured URLs/ports. Specify the URLs as part of building the host by calling ``UseUrls`` and passing one or more strings. These settings can also be specified in the environment or from the command line.

.. code-block:: c#

    .UseUrls("http://localhost:5000")

The environment of the host can be specified by calling ``UseEnvironment``:

.. code-block:: c#

    .UseEnvironment("Development")

By default, the environment is read from the ``ASPNETCORE_ENVIRONMENT`` environment variable. When using Visual Studio, the environment will be based on settings in the *launchSettings.json* file. :doc:`Learn more about environments <environments>`.

A host can have a default configuration defined, which may be subsequently overridden (for example, in ``Startup`` methods). This is specified using the ``UseConfiguration`` method.

.. code-block:: c#
  :emphasize-lines: 6

  var config = new ConfigurationBuilder()
      .AddJsonFile("hosting.json", optional: true)
      .Build();
        
  var host = new WebHostBuilder()    
      .UseConfiguration(config)
      .Build();

A host's web root can be specified by calling ``UseWebRoot``.

.. code-block:: c#

    .UseWebRoot("siteroot")
    
Once a host is built using ``WebHostBuilder``, it is started by calling its ``Run`` method.

.. code-block:: c#

    host.Run();


Configuring a Host
------------------

Configuration settings.

UseSetting/GetSetting. Specify key/value settings.
WebHostBuilder config keys: https://github.com/aspnet/Hosting/blob/dev/src/Microsoft.AspNetCore.Hosting.Abstractions/WebHostDefaults.cs

Key things to cover:

applicationName: set on IHostingEnvironment.ApplicationName;

startupAssembly: the assembly to search for a Startup class in (unless specified using WebHostBuilder.UseStartup<SomeType>, which overrides this setting). A string with short or long name of the assembly.

detailedErrors: bool; default false; works with captureStartupErrors; when true, will show details of startup exception error, not just generic error page. Defaults to true when environment is set to Development.

environment: defaults to Production. Can be set to anything. Templates use Development. The predefined environments are Development, Staging, and Production, but this is open-ended. These are not case-sensitive. Link off to Environments doc.

webroot: default location for static files. Defaults to wwwroot. Should be set relative to the contentRoot path.

captureStartupErrors: boolean. Defaults to false. Capture any exceptions from the Startup class; attempt to start server anyway, displaying an error page (with exception details if detailedErrors is true) in response to every request.

urls: ; separated list of URL prefixes. For instance, http://localhost:123/foo. You can change localhost to * and will listen to any IP address or host on that port. (note that some of this is server-specific)

contentRoot: Defaults to the application base path. Is set to currentdirectory in templates. Is used to read a non-code files like config files, view files, etc. The default is the location of the actual binary that is running. Example: if you build a project and it goes into /bin, then by default the root would be within bin. To correct for this, we specify CurrentDirectory in the templates so the folder from which you're running (via dotnet run, for instance) becomes the contentRoot. This is also the base path from which webroot is calculated.

Cover the extension methods that set these nicely, as opposed to using these keys directly

Important methods to call and ordering. Refer to hosting samples in hosting repo when working on this doc. (https://github.com/aspnet/Hosting/tree/dev/samples/SampleStartups ) (note samples don't run they're just for reference)

Note that environment variables are loaded first, automatically.
You can specify explicit configuration (with settings for command line, files, whatever) and it will use the keys shown above). This will override anything that was set in environment.

Differences between IIS Integration and Kestrel
-----------------------------------------------

UseKestrel vs. UseIISIntegration are totally different things. We just use IIS as a reverse proxy.
UseKestrel says this is the server I want to use, running on this port, and it hosts the code. It registers Kestrel as an IServerFactory. At runtime, will get the actual IServer service, instantiate it, and run it.
UseIISIntegration will look at environment variables used by IIS/IISExpress and will make a bunch of decisions about running on a dynamic port, things with headers, etc. This method doesn't deal with or create an IServer. It calls UseUrls with the dynamic port and registers some middleware.

Host Configuration References
-----------------------------

IIS (point to publishing on IIS doc)
ngenx (point to hosting on linux doc)
as a Windows Service (point to doc)
embedded in an application (you can host ASPNET inside another app as a subcomponent)
