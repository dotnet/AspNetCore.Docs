

TestServer Class
================





Namespace
    :dn:ns:`Microsoft.AspNetCore.TestHost`
Assemblies
    * Microsoft.AspNetCore.TestHost

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.TestHost.TestServer`








Syntax
------

.. code-block:: csharp

    public class TestServer : IServer, IDisposable








.. dn:class:: Microsoft.AspNetCore.TestHost.TestServer
    :hidden:

.. dn:class:: Microsoft.AspNetCore.TestHost.TestServer

Properties
----------

.. dn:class:: Microsoft.AspNetCore.TestHost.TestServer
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.TestHost.TestServer.BaseAddress
    
        
        :rtype: System.Uri
    
        
        .. code-block:: csharp
    
            public Uri BaseAddress
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.TestHost.TestServer.Host
    
        
        :rtype: Microsoft.AspNetCore.Hosting.IWebHost
    
        
        .. code-block:: csharp
    
            public IWebHost Host
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.TestHost.TestServer.Microsoft.AspNetCore.Hosting.Server.IServer.Features
    
        
        :rtype: Microsoft.AspNetCore.Http.Features.IFeatureCollection
    
        
        .. code-block:: csharp
    
            IFeatureCollection IServer.Features
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.TestHost.TestServer
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.TestHost.TestServer.TestServer(Microsoft.AspNetCore.Hosting.IWebHostBuilder)
    
        
    
        
        :type builder: Microsoft.AspNetCore.Hosting.IWebHostBuilder
    
        
        .. code-block:: csharp
    
            public TestServer(IWebHostBuilder builder)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.TestHost.TestServer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.TestHost.TestServer.CreateClient()
    
        
        :rtype: System.Net.Http.HttpClient
    
        
        .. code-block:: csharp
    
            public HttpClient CreateClient()
    
    .. dn:method:: Microsoft.AspNetCore.TestHost.TestServer.CreateHandler()
    
        
        :rtype: System.Net.Http.HttpMessageHandler
    
        
        .. code-block:: csharp
    
            public HttpMessageHandler CreateHandler()
    
    .. dn:method:: Microsoft.AspNetCore.TestHost.TestServer.CreateRequest(System.String)
    
        
    
        
        Begins constructing a request message for submission.
    
        
    
        
        :type path: System.String
        :rtype: Microsoft.AspNetCore.TestHost.RequestBuilder
        :return: :any:`Microsoft.AspNetCore.TestHost.RequestBuilder` to use in constructing additional request details.
    
        
        .. code-block:: csharp
    
            public RequestBuilder CreateRequest(string path)
    
    .. dn:method:: Microsoft.AspNetCore.TestHost.TestServer.CreateWebSocketClient()
    
        
        :rtype: Microsoft.AspNetCore.TestHost.WebSocketClient
    
        
        .. code-block:: csharp
    
            public WebSocketClient CreateWebSocketClient()
    
    .. dn:method:: Microsoft.AspNetCore.TestHost.TestServer.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    
    .. dn:method:: Microsoft.AspNetCore.TestHost.TestServer.Microsoft.AspNetCore.Hosting.Server.IServer.Start<TContext>(Microsoft.AspNetCore.Hosting.Server.IHttpApplication<TContext>)
    
        
    
        
        :type application: Microsoft.AspNetCore.Hosting.Server.IHttpApplication<Microsoft.AspNetCore.Hosting.Server.IHttpApplication`1>{TContext}
    
        
        .. code-block:: csharp
    
            void IServer.Start<TContext>(IHttpApplication<TContext> application)
    

