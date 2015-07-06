OWIN
====

By `Steve Smith`_

ASP.NET 5 supports OWIN, the Open Web Interface for .NET, which allows web applications to be decoupled from web servers. In addition, OWIN defines a standard way for middleware to be used in a pipeline to handle individual requests and associated responses. ASP.NET 5 applications and middleware can interoperate with OWIN-based applications, servers, and middleware.

In this article:
	- `Running OWIN middleware in the ASP.NET pipeline`_
	- `Using ASP.NET Hosting on an OWIN-based server`_
	- `Using ASP.NET middleware in an OWIN pipeline`_
	- `OWIN keys and ASP.NET OWIN adapters`_

`Browse or download samples on GitHub <https://github.com/aspnet/Docs/tree/master/docs/fundamentals/owin/sample>`_.

Running OWIN middleware in the ASP.NET pipeline
-----------------------------------------------

ASP.NET 5's OWIN support is deployed as part of the HttpAbstractions package, in the Microsoft.AspNet.Owin project. You can import OWIN support into your project by adding this package as a dependency in your ``project.json`` file, as shown here:

.. literalinclude:: owin/sample/src/OwinSample/project.json
	:language: javascript
	:lines: 5-10
	:emphasize-lines: 3

OWIN middleware conform to the `OWIN specification <http://owin.org/spec/spec/owin-1.0.0.html>`_, which defines a ``Properties IDictionary<string, object>`` interface that must be used, and also requires certain headers be set (such as ``owin.ResponseBody``). We can construct a very simple example of middleware that follows the OWIN specification to display "Hello World", as shown here:

.. literalinclude:: owin/sample/src/OwinSample/Startup.cs
	:language: c#
	:lines: 26-39
	:dedent: 8

In the above example, notice that the method returns a ``Task`` and accepts an ``IDictionary<string, object>`` as required by OWIN. Within the method, this parameter is used to specify the ``owin.ResponseBody`` and ``owin.ResponseHeaders`` objects within the environment dictionary. Once the headers are set appropriately for the content being returned, a task representing the asynchronous write to the response stream is returned.

Adding OWIN middleware to the ASP.NET pipeline is most easily done using the ``UseOwin`` extension method. Given the ``OwinHello`` method shown above, adding it to the pipeline is a simple matter:

.. literalinclude:: owin/sample/src/OwinSample/Startup.cs
	:language: c#
	:lines: 18-24
	:dedent: 8

You can of course configure other actions to take place within the OWIN pipeline. Whether directly from within the call to ``UseOwin`` as shown below, or through multiple calls to ``UseOwin``. Just remember that response headers should only be modified prior to the first write to the response stream, so configure your pipeline accordingly.

.. code-block:: c#

	app.UseOwin(pipeline =>
	{
		pipeline(next =>
			{
				// do something before
				return OwinHello;
				// do something after
			});
	});

Using ASP.NET Hosting on an OWIN-based server
---------------------------------------------

OWIN-based servers can host ASP.NET applications, since ASP.NET conforms to the OWIN specification. One such server is `Nowin <https://github.com/Bobris/Nowin>`_, a .NET OWIN web server. In the sample for this article, I've included a very simple project that references Nowin and uses it to create a simple server capable of self-hosting ASP.NET 5.

.. literalinclude:: owin/sample/src/NowinSample/NowinServerFactory.cs
	:emphasize-lines: 13,19,22,27,39
	:linenos:
	:language: c#

`IServerFactory <https://github.com/aspnet/Hosting/blob/b75a855b98b7d1e2385ba9695eabdaeab06c138a/src/Microsoft.AspNet.Hosting.Server.Abstractions/IServerFactory.cs>`_ is an ASP.NET interface that requires an Initialize and a Start method. Initialize must return an instance of `IServerInformation <https://github.com/aspnet/Hosting/blob/b75a855b98b7d1e2385ba9695eabdaeab06c138a/src/Microsoft.AspNet.Hosting.Server.Abstractions/IServerInformation.cs>`_, which simply includes the server's name. In this example, the ``NowinServerInformation`` class is defined as a private class within the factory, and is returned by ``Initialize`` as required.

``Initialize`` is responsible for configuring the server, which in this case is done through a series of fluent API calls that hard code the server to listen for requests (to any IP address) on port 5000. Note that the final line of the fluent configuration of the ``builder`` variable specifies that requests will be handled by the private method ``HandleRequest``.

``Start`` is called after ``Initialize`` and accepts the the ``IServerInformation`` created by ``Initialize``, and a callback of type ``Func<IFeatureCollection, Task>``. This callback is assigned to a local field and is ultimately called on each request from within the private ``HandleRequest`` method (which was wired up in ``Initialize``).

With this in place, all that's required to run an ASP.NET application using this custom server is the following command in ``project.json``:

.. literalinclude:: owin/sample/src/NowinSample/project.json
	:emphasize-lines: 14
	:linenos:
	:language: javascript
	:lines: 1-15

When run, this command (equivalent to running ``dnx . web`` from a command line) will search for a package called "NowinSample" that contains an implementation of ``IServerFactory``. If it finds one, it will initialize and start the server as detailed above. Learn more about the built-in ASP.NET :doc:`/fundamentals/servers`.

Using ASP.NET middleware in an OWIN pipeline
--------------------------------------------

OWIN keys and ASP.NET OWIN adapters
-----------------------------------

Summary
-------

