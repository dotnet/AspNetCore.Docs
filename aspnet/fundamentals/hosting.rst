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

Describe what a host is.


Setting up a Host
-----------------

.. literalinclude:: /../common/samples/WebApplication1/src/WebApplication1/Program.cs
  :emphasize-lines: 14-21
  :language: c#
  :caption: Program.cs

Show the Program.cs, Main method, and the basic code used in the standard templates.

An IWebHostBuilder is responsible for bootstrapping a web application.

You must specify an IServer. The build-in server is Kestrel. Use ``UseKestrel`` (with options, if desired) to set it up.

Refer to Servers article for more info on Kestrel and other servers.

UseUrls is how you specify what the host should listen on. This can also come from environment or command line.

  
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
