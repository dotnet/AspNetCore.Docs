

ClientHandler Class
===================






This adapts HttpRequestMessages to ASP.NET requests, dispatches them through the pipeline, and returns the
associated HttpResponseMessage.


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
* :dn:cls:`System.Net.Http.HttpMessageHandler`
* :dn:cls:`Microsoft.AspNetCore.TestHost.ClientHandler`








Syntax
------

.. code-block:: csharp

    public class ClientHandler : HttpMessageHandler, IDisposable








.. dn:class:: Microsoft.AspNetCore.TestHost.ClientHandler
    :hidden:

.. dn:class:: Microsoft.AspNetCore.TestHost.ClientHandler

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.TestHost.ClientHandler
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.TestHost.ClientHandler.ClientHandler(Microsoft.AspNetCore.Http.PathString, Microsoft.AspNetCore.Hosting.Server.IHttpApplication<Microsoft.AspNetCore.Hosting.Internal.HostingApplication.Context>)
    
        
    
        
        Create a new handler.
    
        
    
        
        :param pathBase: The base path.
        
        :type pathBase: Microsoft.AspNetCore.Http.PathString
    
        
        :param application: The :any:`Microsoft.AspNetCore.Hosting.Server.IHttpApplication\`1`\.
        
        :type application: Microsoft.AspNetCore.Hosting.Server.IHttpApplication<Microsoft.AspNetCore.Hosting.Server.IHttpApplication`1>{Microsoft.AspNetCore.Hosting.Internal.HostingApplication.Context<Microsoft.AspNetCore.Hosting.Internal.HostingApplication.Context>}
    
        
        .. code-block:: csharp
    
            public ClientHandler(PathString pathBase, IHttpApplication<HostingApplication.Context> application)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.TestHost.ClientHandler
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.TestHost.ClientHandler.SendAsync(System.Net.Http.HttpRequestMessage, System.Threading.CancellationToken)
    
        
    
        
        This adapts HttpRequestMessages to ASP.NET requests, dispatches them through the pipeline, and returns the
        associated HttpResponseMessage.
    
        
    
        
        :type request: System.Net.Http.HttpRequestMessage
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Net.Http.HttpResponseMessage<System.Net.Http.HttpResponseMessage>}
    
        
        .. code-block:: csharp
    
            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    

