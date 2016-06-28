:version: 1.0.0

OWIN
====

By `Steve Smith`_

ASP.NET Core supports OWIN, the Open Web Interface for .NET, which allows web applications to be decoupled from web servers. In addition, OWIN defines a standard way for middleware to be used in a pipeline to handle individual requests and associated responses. ASP.NET Core applications and middleware can interoperate with OWIN-based applications, servers, and middleware.

.. contents:: Sections:
  :local:
  :depth: 1

`View or download sample code <https://github.com/aspnet/Docs/tree/master/aspnet/fundamentals/owin/sample>`__

Running OWIN middleware in the ASP.NET pipeline
-----------------------------------------------

ASP.NET Core's OWIN support is deployed as part of the ``Microsoft.AspNetCore.Owin`` package. You can import OWIN support into your project by adding this package as a dependency in your *project.json* file, as shown here:

.. literalinclude:: owin/sample/src/OwinSample/project.json
  :language: javascript
  :lines: 7-11
  :emphasize-lines: 4

OWIN middleware conform to the `OWIN specification <http://owin.org/spec/spec/owin-1.0.0.html>`_, which defines a ``Func<IDictionary<string, object>, Task>`` interface that must be used, and also requires certain keys be set (such as ``owin.ResponseBody``). We can construct a very simple example of middleware that follows the OWIN specification to display "Hello World", as shown here:

.. literalinclude:: owin/sample/src/OwinSample/Startup.cs
  :language: c#
  :lines: 26-40
  :dedent: 8

In the above example, notice that the method returns a ``Task`` and accepts an ``IDictionary<string, object>`` as required by OWIN. Within the method, this parameter is used to retrieve the ``owin.ResponseBody`` and ``owin.ResponseHeaders`` objects from the environment dictionary. Once the headers are set appropriately for the content being returned, a task representing the asynchronous write to the response stream is returned.

Adding OWIN middleware to the ASP.NET pipeline is most easily done using the ``UseOwin`` extension method. Given the ``OwinHello`` method shown above, adding it to the pipeline is a simple matter:

.. literalinclude:: owin/sample/src/OwinSample/Startup.cs
  :language: c#
  :lines: 18-25
  :dedent: 8

You can of course configure other actions to take place within the OWIN pipeline. Remember that response headers should only be modified prior to the first write to the response stream, so configure your pipeline accordingly.

.. note:: Multiple calls to ``UseOwin`` is discouraged for performance reasons. OWIN components will operate best if grouped together.

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

.. note:: The OWIN support in ASP.NET Core is an evolution of the work that was done for the `Katana project <http://katanaproject.codeplex.com/>`_. Katana's ``IAppBuilder`` component has been replaced by ``IApplicationBuilder``, but if you have existing Katana-based middleware, you can use it within your ASP.NET Core application through the use of a bridge, as shown in the `Owin.IAppBuilderBridge example on GitHub <https://github.com/aspnet/Entropy/tree/master/samples/Owin.IAppBuilderBridge>`_. 

Using ASP.NET Hosting on an OWIN-based server
---------------------------------------------

OWIN-based servers can host ASP.NET applications. One such server is `Nowin <https://github.com/Bobris/Nowin>`_, a .NET OWIN web server. In the sample for this article, I've included a project that references Nowin and uses it to create an ``IServer`` capable of self-hosting ASP.NET Core.

.. literalinclude:: owin/sample/src/NowinSample/NowinServer.cs
  :emphasize-lines: 15
  :linenos:
  :language: c#

``IServer`` is an interface that requires an ``Features`` property and a ``Start`` method.

``Start`` responsible for configuring and starting the server, which in this case is done through a series of fluent API calls that set addresses parsed from the IServerAddressesFeature. Note that the fluent configuration of the ``_builder`` variable specifies that requests will be handled by the ``appFunc`` defined earlier in the method. This ``Func`` is called on each request to process incoming requests.

We'll also add an ``IWebHostBuilder`` extension to make it easy to add and configure the Nowin server.

.. literalinclude:: owin/sample/src/NowinSample/NowinWebHostBuilderExtensions.cs
  :emphasize-lines: 11
  :linenos:
  :language: c#

With this in place, all that's required to run an ASP.NET application using this custom server to call the extension in *Program.cs*:

.. literalinclude:: owin/sample/src/NowinSample/Program.cs
  :emphasize-lines: 15
  :linenos:
  :language: c#

Learn more about ASP.NET :doc:`/fundamentals/servers`.

Run ASP.NET Core on an OWIN-based server and use its WebSockets support
-----------------------------------------------------------------------

Another example of how OWIN-based servers' features can be leveraged by ASP.NET Core is access to features like WebSockets. The .NET OWIN web server used in the previous example has support for Web Sockets built in, which can be leveraged by an ASP.NET Core application. The example below shows a simple web application that supports Web Sockets and echos back anything sent to the server via WebSockets.

.. literalinclude:: owin/sample/src/NowinWebSockets/Startup.cs
  :lines: 11-
  :language: c#
  :linenos:
  :emphasize-lines: 7, 9-10

This `sample  <https://github.com/aspnet/Docs/tree/master/aspnet/fundamentals/owin/sample>`__ is configured using the same ``NowinServer`` as the previous one - the only difference is in how the application is configured in its ``Configure`` method. A test using `a simple websocket client <https://chrome.google.com/webstore/detail/simple-websocket-client/pfdhoblngboilpfeibdedpjgfnlcodoo?hl=en>`_ demonstrates that the application works as expected:

.. image:: owin/_static/websocket-test.png


OWIN keys
---------

OWIN depends heavily on an ``IDictionary<string,object>`` used to communicate information throughout an HTTP Request/Response exchange. ASP.NET Core implements all of the required and optional keys outlined in the OWIN specification, as well as some of its own. Note that any keys not required in the OWIN specification are optional and may only be used in some scenarios. When working with OWIN keys, it's a good idea to review the list of `OWIN Key Guidelines and Common Keys <http://owin.org/spec/spec/CommonKeys.html>`_

Request Data (OWIN v1.0.0)
^^^^^^^^^^^^^^^^^^^^^^^^^^

.. list-table::
  :header-rows: 1

  * - Key
    - Value (type)
    - Description
  * - owin.RequestScheme
    - ``String``
    -
  * - owin.RequestMethod
    - ``String``
    -
  * - owin.RequestPathBase
    - ``String``
    -
  * - owin.RequestPath
    - ``String``
    -
  * - owin.RequestQueryString
    - ``String``
    -
  * - owin.RequestProtocol
    - ``String``
    -
  * - owin.RequestHeaders
    - ``IDictionary<string,string[]>``
    -
  * - owin.RequestBody
    - ``Stream``
    - 
 
Request Data (OWIN v1.1.0)
^^^^^^^^^^^^^^^^^^^^^^^^^^

.. list-table::
  :header-rows: 1

  * - Key
    - Value (type)
    - Description
  * - owin.RequestId
    - ``String``
    - Optional

Response Data (OWIN v1.0.0)
^^^^^^^^^^^^^^^^^^^^^^^^^^^

.. list-table::
  :header-rows: 1

  * - Key
    - Value (type)
    - Description
  * - owin.ResponseStatusCode
    - ``int``
    - Optional
  * - owin.ResponseReasonPhrase
    - ``String``
    - Optional
  * - owin.ResponseHeaders
    - ``IDictionary<string,string[]>``
    - 
  * - owin.ResponseBody
    - ``Stream``
    -

Other Data (OWIN v1.0.0)
^^^^^^^^^^^^^^^^^^^^^^^^^^

.. list-table::
  :header-rows: 1
  
  * - Key
    - Value (type)
    - Description
  * - owin.CallCancelled
    - ``CancellationToken``
    -
  * - owin.Version
    - ``String``
    -

Common Keys
^^^^^^^^^^^

.. list-table::
  :header-rows: 1
  
  * - Key
    - Value (type)
    - Description
  * - ssl.ClientCertificate
    - ``X509Certificate``
    -
  * - ssl.LoadClientCertAsync
    - ``Func<Task>``
    -
  * - server.RemoteIpAddress
    - ``String``
    -
  * - server.RemotePort
    - ``String``
    -
  * - server.LocalIpAddress
    - ``String``
    -
  * - server.LocalPort
    - ``String``
    -
  * - server.IsLocal
    - ``bool``
    -
  * - server.OnSendingHeaders
    - ``Action<Action<object>,object>``
    -

SendFiles v0.3.0
^^^^^^^^^^^^^^^^

.. list-table::
  :header-rows: 1

  * - Key
    - Value (type)
    - Description
  * - sendfile.SendAsync
    - See `delegate signature <http://owin.org/spec/extensions/owin-SendFile-Extension-v0.3.0.htm>`_
    - Per Request

Opaque v0.3.0
^^^^^^^^^^^^^


.. list-table::
  :header-rows: 1

  * - Key
    - Value (type)
    - Description
  * - opaque.Version
    - ``String``
    -
  * - opaque.Upgrade
    - ``OpaqueUpgrade``
    - See `delegate signature <http://owin.org/spec/extensions/owin-OpaqueStream-Extension-v0.3.0.htm>`__
  * - opaque.Stream
    - ``Stream``
    -
  * - opaque.CallCancelled
    - ``CancellationToken``
    -

WebSocket v0.3.0
^^^^^^^^^^^^^^^^

.. list-table::
  :header-rows: 1
  
  * - Key
    - Value (type)
    - Description
  * - websocket.Version
    - ``String``
    -
  * - websocket.Accept
    - ``WebSocketAccept``
    - See `delegate signature <http://owin.org/spec/extensions/owin-WebSocket-Extension-v0.4.0.htm>`__.
  * - websocket.AcceptAlt
    -
    - Non-spec
  * - websocket.SubProtocol
    - ``String``
    - See `RFC6455 Section 4.2.2 <https://tools.ietf.org/html/rfc6455#section-4.2.2>`_ Step 5.5
  * - websocket.SendAsync
    - ``WebSocketSendAsync``
    - See `delegate signature <http://owin.org/spec/extensions/owin-WebSocket-Extension-v0.4.0.htm>`__.
  * - websocket.ReceiveAsync
    - ``WebSocketReceiveAsync``
    - See `delegate signature <http://owin.org/spec/extensions/owin-WebSocket-Extension-v0.4.0.htm>`__.
  * - websocket.CloseAsync
    - ``WebSocketCloseAsync``
    - See `delegate signature <http://owin.org/spec/extensions/owin-WebSocket-Extension-v0.4.0.htm>`__.
  * - websocket.CallCancelled
    - ``CancellationToken``
    -
  * - websocket.ClientCloseStatus
    - ``int``
    - Optional
  * - websocket.ClientCloseDescription
    - ``String``
    - Optional

Summary
-------

ASP.NET Core has built-in support for the OWIN specification, providing the compatibility to run ASP.NET Core applications within OWIN-based servers as well as supporting OWIN-based middleware within ASP.NET Core servers.

Additional Resources
--------------------

- :doc:`middleware`
- :doc:`servers`
